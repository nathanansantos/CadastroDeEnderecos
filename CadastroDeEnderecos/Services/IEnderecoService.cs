using CadastroDeEnderecos.Models;

namespace CadastroDeEnderecos.Services
{
    public interface IEnderecoService
    {
        EnderecoModel ListarPorId(int id);
        List<EnderecoModel> BuscarTodos();
        EnderecoModel Adicionar(EnderecoModel endereco);
        EnderecoModel Atualizar(EnderecoModel endereco);
        bool Apagar(int id);
        public string GerarCsv(List<EnderecoModel> enderecos);
    }
}
            