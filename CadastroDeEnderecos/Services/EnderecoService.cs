using CadastroDeEnderecos.Data;
using CadastroDeEnderecos.Models;

namespace CadastroDeEnderecos.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ApplicationDbContext _context;
        public EnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }
  
        public EnderecoModel Adicionar(EnderecoModel endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

        public List<EnderecoModel> BuscarTodos()
        {
            return _context.Enderecos.ToList();
        }
    }
}
