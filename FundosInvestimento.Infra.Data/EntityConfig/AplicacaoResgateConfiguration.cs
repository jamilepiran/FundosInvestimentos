using System;
using System.Text;
using System.Collections.Generic;
using FundosInvestimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FundosInvestimento.Infra.Data.EntityConfig
{
    public class AplicacaoResgateConfiguration : IEntityTypeConfiguration<AplicacaoResgate>
    {
        public void Configure(EntityTypeBuilder<AplicacaoResgate> builder)
        {
            builder.HasKey(r => r.AplicacaoResgateId).HasName("AplicacaoResgateId");
            builder.Property(r => r.AplicacaoResgateId).HasColumnName("AplicacaoResgateId").ValueGeneratedOnAdd();
            builder.Property(r => r.TipoMovimentacao).HasColumnName("TipoMovimentacao").HasColumnType("varchar(1)").HasConversion(v => v.ToString(), v => (TpMovimentacao)Enum.Parse(typeof(TpMovimentacao), v)); 
            builder.Property(r => r.Cpf).HasColumnName("Cpf").HasColumnType("varchar(11)").HasMaxLength(11);
            builder.Property(r => r.ValorMovimentacao).HasColumnName("ValorMovimentacao").HasColumnType("decimal(18,2)");
            builder.Property(r => r.DataMovimentacao).HasColumnName("DataMovimentacao").HasColumnType("datetime");
            builder.Property(r => r.FundosId).HasColumnName("FundosId");
            builder.HasOne(c => c.Fundos).WithMany(r => r.AplicacaoResgate).HasForeignKey(r => r.FundosId);
        }
    }
}
