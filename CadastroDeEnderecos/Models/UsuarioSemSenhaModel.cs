using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class UsuarioSemSenhaModel
    {
        //[Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "{0} informado não é valido!")]
        public string Email { get; set; }


        //[Required(ErrorMessage = "Senha é obrigatória.")]
        //[StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        

        //public ICollection<EnderecoModel> Enderecos { get; set; }
    }
}

