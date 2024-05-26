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

        public EnderecoModel Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoDB = ListarPorId(endereco.Id);

            if (enderecoDB == null) throw new System.Exception("Houve um erro na atualização do contato");

            enderecoDB.Cep = endereco.Cep;
            enderecoDB.Logradouro = endereco.Logradouro;
            enderecoDB.Bairro = endereco.Bairro;
            enderecoDB.Cidade = endereco.Cidade;
            enderecoDB.Complemento = endereco.Complemento;
            enderecoDB.Uf = endereco.Uf;
            enderecoDB.Numero = endereco.Numero;

            _context.Enderecos.Update(enderecoDB);
            _context.SaveChanges();

            return enderecoDB;
        }

        public List<EnderecoModel> BuscarTodos()
        {
            return _context.Enderecos.ToList();
        }

        public bool Apagar(int id)
        {
            EnderecoModel enderecoDB = ListarPorId(id);

            if (enderecoDB == null) throw new System.Exception("Houve um erro na exclusão do contato");

            _context.Enderecos.Remove(enderecoDB);
            _context.SaveChanges();

            return true;
        }

        public EnderecoModel ListarPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(x => x.Id == id);
        }

    }
}
