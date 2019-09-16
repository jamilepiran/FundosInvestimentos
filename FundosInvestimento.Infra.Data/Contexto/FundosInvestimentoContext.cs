using System;
using System.Collections.Generic;
using System.Text;
using FundosInvestimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
                  etd.HasKey(c => c.Id).HasName("Id");
                  //etd.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
                  //etd.Property(c => c.Cnpj).HasColumnName("Cnpj").HasMaxLength(100);
                  //etd.Property(c => c.InvestimentoInicial).HasColumnName("InvestimentoInicial").HasMaxLength(30);
            });
        }


        private void ConfiguraAplicacaoResgate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AplicacaoResgate>(etd =>
            {
                etd.ToTable("AplicacaoResgate");
                etd.HasKey(c => c.Id).HasName("Id");
                //etd.Property(c => c.TipoMovimentacao).HasColumnName("TipoMovimentacao").HasMaxLength(100);
                //etd.Property(c => c.FundoId).HasColumnName("FundoId").HasMaxLength(100);
                //etd.Property(c => c.Cpf).HasColumnName("Cpf").HasMaxLength(30);
                //etd.Property(c => c.ValorMovimentacao).HasColumnName("ValorMovimentacao").HasMaxLength(30);
                //etd.Property(c => c.DataMovimentacao).HasColumnName("DataMovimentacao").HasMaxLength(30);
            });
        }
    }
}
