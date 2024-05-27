using CadastroDeEnderecos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace CadastroDeEnderecos.ViewComponents
{
    //public class Menu : ViewComponent
    //{
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

    //        if (string.IsNullOrEmpty(sessaoUsuario)) return null;

    //        UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

    //        return View(usuario);
    //    }
    //}
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return View(new UsuarioModel()); // Retorna uma instância vazia de UsuarioModel

            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }

}
