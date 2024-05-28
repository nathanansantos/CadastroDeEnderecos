using CadastroDeEnderecos.Data.Map;
using CadastroDeEnderecos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEnderecos.Data
{
    public class ApplicationDbContext : DbContext
    {
        //classe de contexto para comunicar com o bd e criar tabelas
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  //configura mapeamento entre entidades
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap()); //aplicando a configuração definida na classe EnderecoMap ao modelBuilder.

            base.OnModelCreating(modelBuilder); //chamando o método OnModelCreating da classe base.
        }

    }
}
