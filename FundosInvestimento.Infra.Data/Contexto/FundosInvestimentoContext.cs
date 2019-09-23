using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FundosInvestimento.Domain.Entities;
using FundosInvestimento.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NJsonSchema.Infrastructure;

namespace FundosInvestimento.Infra.Data.Contexto
{
    public class FundosInvestimentoContext : DbContext
    {
        public FundosInvestimentoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Fundos> Fundos { get; set; }
        public DbSet<AplicacaoResgate> AplicacaoResgate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Since EF Core 2.2, this will apply configs from separate classes which implemented IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ForSqlServerUseIdentityColumns();

            //Mapeando as classes
            modelBuilder.ApplyConfiguration(new FundosConfiguration());
            modelBuilder.ApplyConfiguration(new AplicacaoResgateConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}