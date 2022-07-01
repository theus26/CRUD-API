using API_BD.MODELS;
using API_BD.MODELS.Entities.Clientes;

namespace API_BD.Repositories
{
    public interface IClienteRepository
    {
      
        public bool Create(PostClientes cliente);
        public Clientes Read(int id);
        public bool Update(PutClientes cliente);
        public bool Delete(int id);

    }

    public class ClienteRepository: IClienteRepository //passei como herança
    {
        private readonly _DbContext db;

        public ClienteRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostClientes cliente)
        {
            try
            {

                var cliente_db = new Clientes()
                {
                     // ESTOU ACESSANDO O MODEL CLIENTE PARA O METODO POST
                     Name = cliente.Name,
                     DataNascimento = cliente.Data_Nascimento

                };
                db.clliente.Add(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Clientes Read (int id)
        {
            try
            {
                var cliente_db = db.clliente.Find(id);
                var idade = DateTime.Today.Year - cliente_db.DataNascimento.Year;
                cliente_db.Idade = idade;
                return cliente_db;
            }
            catch
            {
                return new Clientes();
            }
        }

        public bool Update(PutClientes cliente)
        {
            try
            {
                var cliente_db = db.clliente.Find(cliente.id);
                cliente_db.Name = cliente.Name;
                cliente_db.DataNascimento = cliente.Data_Nascimento;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var cliente_db = db.clliente.Find(id);
                db.clliente.Remove(cliente_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
