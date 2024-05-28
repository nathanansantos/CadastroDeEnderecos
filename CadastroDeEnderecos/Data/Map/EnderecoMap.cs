using CadastroDeEnderecos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CadastroDeEnderecos.Data.Map
{
    //essa classe é usada para configurar o mapeamento de entidade  entre a classe de modelo EnderecoModel e a tabela correspondente no banco de dados.
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
       public void Configure(EntityTypeBuilder<EnderecoModel> builder) 
        {
            builder.HasKey(x => x.Id); //definindo a chave primária da entidade EnderecoModel.
            builder.HasOne(x => x.Usuario); //Essa linha configura um relacionamento entre a entidade EnderecoModel e outra entidade chamada Usuario.
        }
    }
}
