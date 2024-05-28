using CadastroDeEnderecos.Models;
using CadastroDeEnderecos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using CadastroDeEnderecos.Helper;

namespace CadastroDeEnderecos.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        private readonly ISessao _sessao;

        //Injeção de dependência para inicializar uma sessão do usuários e os metodos de endereçoService
        public EnderecoController(IEnderecoService enderecoService, ISessao sessao)
        {
            _enderecoService = enderecoService;
            _sessao = sessao;
        }

        //Busca e retorna uma lista de endereços
        public IActionResult Index()
        {
            List<EnderecoModel> enderecos = _enderecoService.BuscarTodos();
            return View(enderecos);
        }

        //Retorna a view Create
        public IActionResult Create()
        {
            return View();
        }

        //Busca um id específico para editar
        public IActionResult Edit(int id)
        {
            EnderecoModel endereco = _enderecoService.ListarPorId(id);
            return View(endereco);
        }

        //Busca um id específico para confirmar a exclusão
        public IActionResult DeleteConfirm(int id)
        {
            EnderecoModel endereco = _enderecoService.ListarPorId(id);
            return View(endereco);
        }

        //usando metodo POST para enviar dados do formulário html para o banco
        [HttpPost]
        public IActionResult Create(EnderecoModel endereco)
        {
            try
            {
                //se for possivel adicionar um endereço, será retornado uma mensagem de sucesso
                _enderecoService.Adicionar(endereco);
                TempData["MensagemSucesso"] = "Endereço cadastrado com sucesso!";
                return RedirectToAction("Index");
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
                //se for possivel atualizar um endereço, será retornado uma mensagem de sucesso
                _enderecoService.Atualizar(endereco);
                TempData["MensagemSucesso"] = "Endereço alterado com sucesso!";
                return RedirectToAction("Index");
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
                //retorna true se for possivel apagar e exibe mensagem de sucesso
                bool apagado = _enderecoService.Apagar(id);

                if (apagado)
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

        public IActionResult ExportarCsv()
        {
            var dados = _enderecoService.BuscarTodos(); //lista os endereços
            var csv = _enderecoService.GerarCsv(dados); //gera o csv dos endereços atraves do metodo responsavel
            var bytes = Encoding.UTF8.GetBytes(csv); //convertendo a string csv em um array de bytes usando a codificação UTF-8.
            var arquivo = "dados.csv"; //nomeando o arquivo csv

            return File(bytes, "text/csv", arquivo); //retornando arquivo com o conteúdo em bytes, especificando o tipo como “text/csv” e o nome do arquivo como “dados.csv”.
        }
    }
}
