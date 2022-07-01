using API_BD.MODELS.Entities.Clientes;
using API_BD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository repos;
        public ClientesController(IClienteRepository _repos)
        {
            repos = _repos;
        }

        // Vamos criar quatro endpoits, de uma maneira diferente.

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute] ClienteId cliente) // esse metodo IActionResult, espera retorna algo
        {
           
            var cliente_db = repos.Read(cliente.Id) ;
            return Ok(cliente_db); // como ele espera retornar algo, e ainda não fizemos nada colocamos dizendo que deu 200(sucesso)
        }

        [HttpPost]
        public IActionResult Post(PostClientes  cliente)
        {
            if (string.IsNullOrEmpty(cliente.Name) || string.IsNullOrWhiteSpace(cliente.Name) || cliente.Name.Length <= 2)
            {
                return BadRequest("Nome Inválido");
            }

            if (repos.Create(cliente))
            return Ok("Cliente Cadastrado !");

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PutClientes cliente)
        {
            if (repos.Update(cliente))
            return Ok("Atenção, Dados Atualizados");

            return BadRequest();
        }

        [HttpDelete ("{Id}")]
        public IActionResult Delete([FromRoute] ClienteId cliente)
        {
            if (repos.Delete(cliente.Id))
            return Ok("Cliente Deletado!");

            return BadRequest();
        }
    }
}
