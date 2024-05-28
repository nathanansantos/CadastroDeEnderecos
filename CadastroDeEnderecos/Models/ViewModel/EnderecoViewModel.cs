using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CadastroDeEnderecos.Models.ViewModel
{
    public class EnderecoViewModel
    {
        HttpClient cliente = new HttpClient();  //Criada uma instância da classe HttpClient. Para enviar solicitações HTTP para o servidor e receber respostas

        public EnderecoViewModel()
        {
            cliente.BaseAddress = new Uri("https://viacep.com.br/ws/"); //Definida a URL base para todas as solicitações HTTP feitas por esse cliente.
            //configurando o cabeçalho “Accept” da solicitação HTTP para indicar que esperamos receber uma resposta no formato JSON 
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<EnderecoModel> GetEnderecoAsync(string cep)
        {
            string cepInformado = cep;
            HttpResponseMessage response = await cliente.GetAsync($"{cepInformado}/json/"); // envia uma solicitação HTTP GET para o cep informado
            if (response.IsSuccessStatusCode) // Verificamos se a resposta HTTP indica sucesso (código de status 2xx). Se for o caso, continuamos processando os dados.
            {
                var dados = await response.Content.ReadAsStringAsync(); // Lemos o conteúdo da resposta HTTP como uma string, que contém os dados do endereço no formato JSON.

                // Essa linha retorna o objeto de endereço preenchido com as informações obtidas.
                return JsonConvert.DeserializeObject<EnderecoModel>(dados); //Desserializamos os dados JSON para um objeto do tipo EnderecoModel.
            }
            return new EnderecoModel(); //Se a resposta HTTP não for bem-sucedida ou se houver algum erro, retornamos um objeto EnderecoModel vazio.
        }
    }
}
