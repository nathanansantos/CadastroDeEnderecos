using CadastroDeEnderecos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeEnderecos.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
       public void Configure(EntityTypeBuilder<EnderecoModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
        }
    }
}
