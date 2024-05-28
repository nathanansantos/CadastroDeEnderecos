using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class LoginModel
    {
        //classe usado como modelo para criação do bd. foi usado data notations pra especificar tipo de dados e restrições
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 8)]
        public string Senha { get; set; }
    }
}
