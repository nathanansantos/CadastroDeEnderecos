using CadastroDeEnderecos.Controllers;
using CadastroDeEnderecos.Models;

namespace CadastroDeEnderecos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();

    }
}
