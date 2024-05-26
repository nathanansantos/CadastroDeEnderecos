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
    }
}
