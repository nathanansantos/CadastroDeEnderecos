using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CadastroDeEnderecos.Models.ViewModel
{
    public class EnderecoViewModel
    {
        HttpClient cliente = new HttpClient();

        public EnderecoViewModel()
        {
            cliente.BaseAddress = new Uri("https://viacep.com.br/ws/");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<EnderecoModel> GetEnderecoAsync(string cep)
        {
            string cepInformado = cep;
            HttpResponseMessage response = await cliente.GetAsync($"{cepInformado}/json/");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<EnderecoModel>(dados);
            }
            return new EnderecoModel();
        }
    }
}
