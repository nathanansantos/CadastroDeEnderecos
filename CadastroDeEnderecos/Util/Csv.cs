using CadastroDeEnderecos.Models;
using System.Security.AccessControl;
using System.Text;

namespace CadastroDeEnderecos.Util
{
    public class Csv
    {
        public string GerarCsv(List<EnderecoModel> enderecos)
        {
            var csv = new StringBuilder();
            
            csv.AppendLine("Cep,Logradouro,Complemento,Bairro,Cidade,Uf,Numero");
            foreach (var item in enderecos) { csv.AppendLine($"{item.Cep},{item.Logradouro},{item.Complemento},{item.Bairro},{item.Cidade},{item.Uf},{item.Numero}"); }
            return csv.ToString();
        }
    }
}
