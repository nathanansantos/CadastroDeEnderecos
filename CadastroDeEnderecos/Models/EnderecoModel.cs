using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeEnderecos.Models
{
    public class EnderecoModel
    {
        //classe usado como modelo para criação do bd. foi usado data notations pra especificar tipo de dados e restrições
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("cep")]
        public string Cep { get; set; } //cep foi definido como string para caso alguem insira hífen (" - ") entre o valor do cep

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [StringLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        [JsonProperty("complemento")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [StringLength(2, ErrorMessage = "O {0} deve ter no máximo {1} caracteres.")]
        [JsonProperty("uf")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public int Numero { get; set; }

        public int? UsuarioId { get; set; } 

        public UsuarioModel Usuario { get; set; }   

    }



}

