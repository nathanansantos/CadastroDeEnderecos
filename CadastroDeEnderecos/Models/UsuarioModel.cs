using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }

        public virtual List<EnderecoModel> Enderecos { get; set; }

        //public ICollection<EnderecoModel> Enderecos { get; set; }
    }
}

