using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class UsuarioSemSenhaModel
    {
        //classe usado como modelo para criação do bd. foi usado data notations pra especificar tipo de dados e restrições
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]

        public string Usuario { get; set; }



    }
}

