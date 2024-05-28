using CadastroDeEnderecos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.X86;

namespace CadastroDeEnderecos.ViewComponents
{
    public class Menu : ViewComponent
    {
        //esse método é responsável por verificar se o usuário está logado, obter os detalhes do usuário e renderizar a view
        public async Task<IViewComponentResult> InvokeAsync() //Invoca a ViewComponent e renderizar a visualização associada.
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado"); //obtem o valor da sessao

            if (string.IsNullOrEmpty(sessaoUsuario))
                return View(new UsuarioModel()); // Se não houver valor (ou se for vazio), significa que o usuário não está logado.

            //Se houver um valor na sessão, estamos desserializando esse valor em um objeto UsuarioModel. Isso permite que o aplicativo obtenha os detalhes do usuário logado.
            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario); 

            return View(usuario);
        }
    }

}
