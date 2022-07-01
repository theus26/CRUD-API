using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_BD.MODELS
{
        [Table (name:"Clientes_Padaria")]
    public class Clientes
    {
        [Key]
        public int id { get; set; }
        [Required, MaxLength(120)]
        public string Name { get; set; }
        public DateTime DataNascimento { get; set; }
        [NotMapped]
        public int Idade  { get; set; }
    }
}
