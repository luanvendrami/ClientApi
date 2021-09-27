using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mapping
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<EnderecoEntidade>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntidade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Endereco");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(p => p.Rua)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasColumnType("varchar(10)");
        }
    }
}
