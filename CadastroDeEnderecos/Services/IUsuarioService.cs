using CadastroDeEnderecos.Models;

namespace CadastroDeEnderecos.Services
{
    public interface IUsuarioService
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar( UsuarioModel usuario);
        bool Apagar(int id);
    }
}
