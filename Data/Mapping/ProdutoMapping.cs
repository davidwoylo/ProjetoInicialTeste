using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DescricaoProduto)
              .IsRequired()
              .HasColumnName("DescricaoProduto");

            builder.Property(x => x.Situacao)
              .IsRequired()
              .HasColumnName("Situacao");

            builder.Property(x => x.DataFabricacao)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnName("DataFabricacao");

            builder.Property(x => x.DataValidade)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasColumnName("DataValidade");

            builder.Property(x => x.CodigoFornecedor)
              .IsRequired()
              .HasColumnType("varchar(10)")
              .HasColumnName("CodigoFornecedor");

            builder.Property(x => x.DescricaoFornecedor)
              .IsRequired()
              .HasColumnName("DescricaoFornecedor");
            
            builder.Property(x => x.CnpjFornecedor)
              .IsRequired()
              .HasColumnType("varchar(14)")
              .HasColumnName("CnpjFornecedor");

        }
    }
}
