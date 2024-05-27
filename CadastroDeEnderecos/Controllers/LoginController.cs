using CadastroDeEnderecos.Helper;
using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEnderecos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioService usuarioService, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            //Redireciona para a home se o usuario estiver logado
            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoDoUsuario(usuario);
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
