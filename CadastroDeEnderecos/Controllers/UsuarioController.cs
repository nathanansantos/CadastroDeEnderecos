using CadastroDeEnderecos.Helper;
using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEnderecos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISessao _sessao;

        //Injeção de dependência para inicializar uma sessão do usuários e os metodos de endereçoService

        public UsuarioController(IUsuarioService usuarioService, ISessao sessao)
        {
            _sessao = sessao;
            _usuarioService = usuarioService;
        }

        //mostra usuarios cadastrados
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioService.BuscarTodos();
            return View(usuarios);
        }

        //retorna pagina para criar usuarios
        public IActionResult Create()
        {
            return View();
        }

        //cria usuarios
        [HttpPost]
        public IActionResult Create(UsuarioModel novoUsuario)
        {
            try
            {

                novoUsuario = _usuarioService.Adicionar(novoUsuario);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index", "Endereco");

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar esse usuário. Detalhe do erro: {ex.InnerException}";
                return RedirectToAction("Index");
            }
        }

        //abre a pagina para editar o usuario selecionado
        public IActionResult Edit(int id)
        {
            UsuarioModel usuario = _usuarioService.ListarPorId(id);
            return View(usuario);
        }

        //edita o usuario sem senha
        [HttpPost]
        public IActionResult Edit(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Usuario = usuarioSemSenhaModel.Usuario,

                    };

                    usuario = _usuarioService.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
 
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Não foi possível alterar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        //abre pagina de confirmação de exclusão
        public IActionResult DeleteConfirm(int id)
        {
            UsuarioModel usuario = _usuarioService.ListarPorId(id);
            return View(usuario);
        }

        //executa exclusão
        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _usuarioService.Apagar(id);

                if (apagado)
                {

                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar esse usuario.";

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Não foi possível apagar esse usuario. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
