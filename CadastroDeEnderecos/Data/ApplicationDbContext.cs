using CadastroDeEnderecos.Data.Map;
using CadastroDeEnderecos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeEnderecos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EnderecoMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
