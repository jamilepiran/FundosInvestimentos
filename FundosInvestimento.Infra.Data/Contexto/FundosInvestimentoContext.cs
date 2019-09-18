using System;
using System.Collections.Generic;
using System.Text;
using FundosInvestimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NJsonSchema.Infrastructure;

namespace FundosInvestimento.Infra.Data.Contexto
{
    public class FundosInvestimentoContext : DbContext
    {
        public FundosInvestimentoContext(DbContextOptions<FundosInvestimentoContext> options) : base(options)
        {
        }

        public FundosInvestimentoContext()
        {
        }

        public DbSet<Fundos> Fundos { get; set; }
        public DbSet<AplicacaoResgate> AplicacaoResgate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("FundosInvestimento");

            ConfiguraFundos(modelBuilder);
            ConfiguraAplicacaoResgate(modelBuilder);
        }

        //Mapeando as entidades com Fluent API
        private void ConfiguraFundos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fundos>(etd =>
            {
                etd.ToTable("Fundos");
                etd.HasKey(c => c.FundosId).HasName("FundosId");
                etd.Property(c => c.FundosId).HasColumnName("FundosId").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("Nome").HasColumnType("varchar(150)").HasMaxLength(150);
                etd.Property(c => c.Cnpj).HasColumnName("Cnpj").HasColumnType("varchar(14)").HasMaxLength(14);
                etd.Property(c => c.InvestimentoInicial).HasColumnName("InvestimentoInicial").HasColumnType("decimal(18,2)");
            });
        }

        //Mapeando as entidades com Fluent API
        private void ConfiguraAplicacaoResgate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicacaoResgate>(etd =>
            {
                etd.ToTable("AplicacaoResgate");
                etd.HasKey(r => r.AplicacaoResgateId).HasName("AplicacaoResgateId");
                etd.Property(r => r.AplicacaoResgateId).HasColumnName("AplicacaoResgateId").ValueGeneratedOnAdd();
                etd.Property(r => r.TipoMovimentacao).HasColumnName("TipoMovimentacao").HasColumnType("varchar(1)").HasConversion(v => v.ToString(), v => (TpMovimentacao)Enum.Parse(typeof(TpMovimentacao), v));
                etd.Property(r => r.FundosId).HasColumnName("FundosId").HasMaxLength(100);
                etd.Property(r => r.Cpf).HasColumnName("Cpf").HasColumnType("varchar(11)").HasMaxLength(11);
                etd.Property(r => r.ValorMovimentacao).HasColumnName("ValorMovimentacao").HasColumnType("decimal(18,2)");
                etd.Property(r => r.DataMovimentacao).HasColumnName("DataMovimentacao").HasColumnType("datetime");
                etd.HasOne(c => c.Fundos).WithMany(r => r.AplicacaoResgate);
            });
        }
    }
}