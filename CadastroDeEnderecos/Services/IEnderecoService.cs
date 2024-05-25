using CadastroDeEnderecos.Models;

namespace CadastroDeEnderecos.Services
{
    public interface IEnderecoService
    {
        List<EnderecoModel> BuscarTodos();
        EnderecoModel Adicionar(EnderecoModel endereco);
    }
}
