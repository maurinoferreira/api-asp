using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public char Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }

    }
}
