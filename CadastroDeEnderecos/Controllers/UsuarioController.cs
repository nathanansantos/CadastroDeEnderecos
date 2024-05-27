using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEnderecos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioService.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioModel novoUsuario)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    novoUsuario = _usuarioService.Adicionar(novoUsuario);
                    TempData["MensagemSucesso"] = "Endereço cadastrado com sucesso!";
                    return RedirectToAction("Index");
                //}
                //return View(novoUsuario);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            UsuarioModel usuario = _usuarioService.ListarPorId(id);
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Edit(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Usuario = usuarioSemSenhaModel.Usuario,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioService.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Não foi possível alterar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }

        public IActionResult DeleteConfirm(int id)
        {
            UsuarioModel usuario = _usuarioService.ListarPorId(id);
            return View(usuario);
        }

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
