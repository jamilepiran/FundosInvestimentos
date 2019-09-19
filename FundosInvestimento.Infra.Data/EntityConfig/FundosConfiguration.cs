using System;
using System.Text;
using System.Collections.Generic;
using FundosInvestimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FundosInvestimento.Infra.Data.EntityConfig
{
    public class FundosConfiguration : IEntityTypeConfiguration<Fundos>
    {
        public void Configure(EntityTypeBuilder<Fundos> builder)
        {
            builder.ToTable("Fundos");
            builder.HasKey(c => c.FundosId).HasName("FundosId");
            builder.Property(c => c.FundosId).HasColumnName("FundosId").ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasColumnName("Nome").HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(c => c.Cnpj).HasColumnName("Cnpj").HasColumnType("varchar(14)").HasMaxLength(14);
            builder.Property(c => c.InvestimentoInicial).HasColumnName("InvestimentoInicial").HasColumnType("decimal(18,2)");
        }
    }
}