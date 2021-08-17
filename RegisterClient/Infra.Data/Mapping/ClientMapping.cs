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
    public class ClientMapping : IEntityTypeConfiguration<ClientDto>
    {
        public void Configure(EntityTypeBuilder<ClientDto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Client");

            builder.Property(p => p.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Rg)
                .IsRequired()
                .HasColumnType("varchar(12)");

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");
        }
    }
}
