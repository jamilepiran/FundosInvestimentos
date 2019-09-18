using System;
using System.Collections.Generic;
using System.Text;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NJsonSchema.Infrastructure;

namespace FundosInvestimento.Infra.Data.Contexto
{
    public class FundosInvestimentoContext : DbContext
    {
        public FundosInvestimentoContext(DbContextOptions options) : base(options)
        {

        }

        //public FundosInvestimentoContext()
        //{
        //}

        public DbSet<Fundos> Fundos { get; set; }
        public DbSet<AplicacaoResgate> AplicacaoResgate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("FundosInvestimento");

            //Mapeando as classes
            modelBuilder.ApplyConfiguration(new FundosConfiguration());
            modelBuilder.ApplyConfiguration(new AplicacaoResgateConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}