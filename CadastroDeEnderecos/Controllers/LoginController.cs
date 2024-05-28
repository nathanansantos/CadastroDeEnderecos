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

        //Injeção de dependência para inicializar uma sessão do usuários e os metodos de endereçoService

        public LoginController(IUsuarioService usuarioService, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioService = usuarioService;
        }

        //se houver uma sessão bem-sucedida, ele acessará a pagina
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Endereco");
            return View();
        }

        //usuario desloga do sistema
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        //acessa o sistema enviando os dados de login
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {

                UsuarioModel usuario = _usuarioService.BuscarPorLogin(loginModel.Login);
                //se o usuario existir
                if (usuario != null)
                {
                    if (usuario.SenhaValida(loginModel.Senha)) //se sua senha for valida
                    { 
                        _sessao.CriarSessaoDoUsuario(usuario); //cria uma sessao e entra na pagina
                        return RedirectToAction("Index", "Endereco");
                    }

                    TempData["MensagemErro"] = $"Senha inválido(s). Tente novamente!";
                }
                TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Tente novamente!";

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
