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
            try
            {
                if (ModelState.IsValid)
                {
                    _enderecoService.Adicionar(endereco);
                    TempData["MensagemSucesso"] = "Endereço cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(endereco);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EnderecoModel endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _enderecoService.Atualizar(endereco);
                    TempData["MensagemSucesso"] = "Endereço alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Edit", endereco);
            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Não foi possível alterar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");

            }
        }
     
        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _enderecoService.Apagar(id);

                if(apagado)
                {

                    TempData["MensagemSucesso"] = "Endereço apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível apagar esse endereço.";

                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                TempData["MensagemErro"] = $"Não foi possível apagar esse endereço. Detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }

            
        }


    }
}
