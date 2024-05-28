
using CadastroDeEnderecos.Data;
using CadastroDeEnderecos.Models;
using System.Text;

namespace CadastroDeEnderecos.Services
{
    public class EnderecoService : IEnderecoService
    {
        //criando injeção de dependencia para uso da classe de contexto

        private readonly ApplicationDbContext _context;
        public EnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }

        //metodo de adição de endereço
        public EnderecoModel Adicionar(EnderecoModel endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();

            return endereco;
        }

        //metodo de atualização de endereço
        public EnderecoModel Atualizar(EnderecoModel endereco)
        {
            EnderecoModel enderecoDB = ListarPorId(endereco.Id); //pega um endereço especifico

            //se nao encontrar o id, dispara uma exceção
            if (enderecoDB == null) throw new Exception("Houve um erro na atualização do contato"); 

            //atribuindo valor do endereço selecionado ao objeto enderecoDB para atualização
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

        //busca os endereços
        public List<EnderecoModel> BuscarTodos()
        {
            return _context.Enderecos.ToList();
        }

        //seleciona o id especifico e apaga
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
            return _context.Enderecos.FirstOrDefault(x => x.Id == id); //retorna o id espeficado
        }

        public List<EnderecoModel> ArquivoCsv()
        {
            return _context.Enderecos.ToList(); //selecion
        }

        public string GerarCsv(List<EnderecoModel> enderecos)
        {
            var csv = new StringBuilder();

            csv.AppendLine("Cep,Logradouro,Complemento,Bairro,Cidade,Uf,Numero");
            foreach (var item in enderecos) //varre a lista de endereços que chega por parametro
            {
                csv.AppendLine($"{item.Cep},{item.Logradouro},{item.Complemento},{item.Bairro},{item.Cidade},{item.Uf},{item.Numero}"); //adiciona na variavel csv os dados da lista
            }
            return csv.ToString(); //retorna em formato de string
        }
    }
}

