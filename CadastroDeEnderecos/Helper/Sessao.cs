using CadastroDeEnderecos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace CadastroDeEnderecos.Helper
{
    public class Sessao : ISessao
    {
        //O IHttpContextAccessor é uma interface que fornece acesso ao contexto HTTP atual, incluindo informações sobre a solicitação e a resposta.
        private readonly IHttpContextAccessor _httpContext;

        //construtor usado para inicializar o contexto HTTP na classe Sessao, permitindo que ela interaja com os detalhes da solicitação HTTP.
        public Sessao(IHttpContextAccessor httpcontext)
        {
            _httpContext = httpcontext;        
        }
        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            //verifica se o valor da sessão é nulo ou vazio. se for, retornamos null, indicando que não há sessão de usuário ativa.
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario); //se houver um valor na sessão, estamos desserializando esse valor
        }

        //esse método é usado para criar ou atualizar a sessão de um usuário, armazenando informações relevantes (como detalhes do usuário) para uso posterior
        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        //usado para remover a sessão do usuario
        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
