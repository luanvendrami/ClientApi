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
    class FornecedoresMapeamento : IEntityTypeConfiguration<FornecedorEntidade>
    {
        public void Configure(EntityTypeBuilder<FornecedorEntidade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Fornecedor");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(70)");

            builder.Property(p => p.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(11)");
        }
    }
}
