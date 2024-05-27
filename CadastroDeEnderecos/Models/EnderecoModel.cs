using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeEnderecos.Models
{
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "{0} é obrigatório")]
        //[StringLength(9,ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("cep")]
        public string Cep { get; set; }

        //[Required(ErrorMessage = "{0} é obrigatório")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }


        //[StringLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]

        [JsonProperty("complemento")]
        public string? Complemento { get; set; }

        //[Required(ErrorMessage = "O {0} é obrigatório")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        //[Required(ErrorMessage = "A {0} é obrigatório")]
        //[StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        //[Required(ErrorMessage = "O {0} é obrigatório")]
        //[StringLength(2, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        [JsonProperty("uf")]
        public string Uf { get; set; }

        //[Required(ErrorMessage = "O {0} é obrigatório")]

        public int Numero { get; set; }

        //[ForeignKey("UsuarioId")]
        //public UsuarioModel Usuario { get; set; }
        //public int UsuarioId { get; set; }

    }



}

