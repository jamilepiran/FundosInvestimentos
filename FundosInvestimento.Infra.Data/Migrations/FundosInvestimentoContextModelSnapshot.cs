﻿// <auto-generated />
using System;
using FundosInvestimento.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FundosInvestimento.Infra.Data.Migrations
{
    [DbContext(typeof(FundosInvestimentoContext))]
    partial class FundosInvestimentoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("FundosInvestimento")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FundosInvestimento.Domain.Entities.AplicacaoResgate", b =>
                {
                    b.Property<Guid>("AplicacaoResgateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AplicacaoResgateId");

                    b.Property<string>("Cpf")
                        .HasColumnName("Cpf")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnName("DataMovimentacao");

                    b.Property<Guid>("FundosId")
                        .HasColumnName("FundosId")
                        .HasMaxLength(100);

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnName("TipoMovimentacao");

                    b.Property<decimal>("ValorMovimentacao")
                        .HasColumnName("ValorMovimentacao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AplicacaoResgateId")
                        .HasName("AplicacaoResgateId");

                    b.ToTable("AplicacaoResgate");
                });

            modelBuilder.Entity("FundosInvestimento.Domain.Entities.Fundos", b =>
                {
                    b.Property<Guid>("FundosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FundosId");

                    b.Property<string>("Cnpj")
                        .HasColumnName("Cnpj")
                        .HasMaxLength(100);

                    b.Property<decimal>("InvestimentoInicial")
                        .HasColumnName("InvestimentoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasMaxLength(100);

                    b.HasKey("FundosId")
                        .HasName("FundosId");

                    b.ToTable("Fundos");
                });
#pragma warning restore 612, 618
        }
    }
}
