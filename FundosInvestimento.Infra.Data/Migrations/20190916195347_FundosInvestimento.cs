using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundosInvestimento.Infra.Data.Migrations
{
    public partial class FundosInvestimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FundosInvestimento");

            migrationBuilder.CreateTable(
                name: "AplicacaoResgate",
                schema: "FundosInvestimento",
                columns: table => new
                {
                    AplicacaoResgateId = table.Column<Guid>(nullable: false),
                    TipoMovimentacao = table.Column<string>(nullable: false),
                    FundosId = table.Column<Guid>(maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: true),
                    ValorMovimentacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AplicacaoResgateId", x => x.AplicacaoResgateId);
                });

            migrationBuilder.CreateTable(
                name: "Fundos",
                schema: "FundosInvestimento",
                columns: table => new
                {
                    FundosId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 100, nullable: true),
                    InvestimentoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FundosId", x => x.FundosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoResgate",
                schema: "FundosInvestimento");

            migrationBuilder.DropTable(
                name: "Fundos",
                schema: "FundosInvestimento");
        }
    }
}
