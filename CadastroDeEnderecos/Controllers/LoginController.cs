using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEnderecos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    UsuarioModel usuario = _usuarioService.BuscarPorLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválido(s). Tente novamente!";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Tente novamente!";

                //}
                return View("Index");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível logar esse usuario. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
