using System;
using System.Collections.Generic;
using System.Text;
using FundosInvestimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FundosInvestimento.Infra.Data.Contexto
{
    public class FundosInvestimentoContext : DbContext
    {
        public FundosInvestimentoContext(DbContextOptions<FundosInvestimentoContext> options) : base(options)
        {
        }

        public DbSet<Fundos> Fundos { get; set; }
        public DbSet<AplicacaoResgate> AplicacaoResgate { get; set; }

        protected override void OnModelCreating(ModelBuilder molderBuilder)
        {
            molderBuilder.ForSqlServerUseIdentityColumns();
            molderBuilder.HasDefaultSchema("FundosInvestimento");

            ConfiguraFundos(molderBuilder);
            ConfiguraAplicacaoResgate(molderBuilder);
        }

        private void ConfiguraFundos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fundos>(etd =>
            {
                etd.ToTable("Fundos");
                etd.HasKey(c => c.FundosId).HasName("FundosId");
                etd.Property(c => c.FundosId).HasColumnName("FundosId").ValueGeneratedOnAdd();
                etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
                etd.Property(c => c.Cnpj).HasColumnName("Cnpj").HasMaxLength(100);
                etd.Property(c => c.InvestimentoInicial).HasColumnName("InvestimentoInicial").HasColumnType("decimal(18,2)");
            });
        }


        private void ConfiguraAplicacaoResgate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicacaoResgate>(etd =>
            {
                etd.ToTable("AplicacaoResgate");
                etd.HasKey(c => c.AplicacaoResgateId).HasName("AplicacaoResgateId");
                etd.Property(c => c.AplicacaoResgateId).HasColumnName("AplicacaoResgateId").ValueGeneratedOnAdd();
                etd.Property(c => c.TipoMovimentacao).HasColumnName("TipoMovimentacao").HasConversion(v => v.ToString(), v => (TpMovimentacao)Enum.Parse(typeof(TpMovimentacao), v));
                etd.Property(c => c.FundosId).HasColumnName("FundosId").HasMaxLength(100);
                etd.Property(c => c.Cpf).HasColumnName("Cpf").HasMaxLength(11);
                etd.Property(c => c.ValorMovimentacao).HasColumnName("ValorMovimentacao").HasColumnType("decimal(18,2)");
                etd.Property(c => c.DataMovimentacao).HasColumnName("DataMovimentacao");
            });
        }
    }
}