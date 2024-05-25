using CadastroDeEnderecos.Data;
using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeEnderecos.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }
        public IActionResult Index()
        {
            List<EnderecoModel> enderecos = _enderecoService.BuscarTodos();
            return View(enderecos);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EnderecoModel endereco)
        {
            _enderecoService.Adicionar(endereco);
            return RedirectToAction("Index");
        }

    }
}
