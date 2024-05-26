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
        public IActionResult Edit(int id)
        {
            EnderecoModel endereco = _enderecoService.ListarPorId(id);
            return View(endereco);
        }
        public IActionResult DeleteConfirm(int id)
        {
            EnderecoModel endereco = _enderecoService.ListarPorId(id);
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Create(EnderecoModel endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoService.Adicionar(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        [HttpPost]
        public IActionResult Edit(EnderecoModel endereco)
        {
            _enderecoService.Atualizar(endereco);
            return RedirectToAction("Index");
        }
     
        public IActionResult Delete(int id)
        {
            _enderecoService.Apagar(id);
            return RedirectToAction("Index");
        }


    }
}
