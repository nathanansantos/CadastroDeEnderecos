using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class UsuarioSemSenhaModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]

        public string Usuario { get; set; }



    }
}

