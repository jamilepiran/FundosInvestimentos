﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FundosInvestimento.Infra.Data.Migrations
{
    public partial class FundosInvestimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fundos",
                columns: table => new
                {
                    FundosId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    InvestimentoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FundosId", x => x.FundosId);
                });

            migrationBuilder.CreateTable(
                name: "AplicacaoResgate",
                columns: table => new
                {
                    AplicacaoResgateId = table.Column<Guid>(nullable: false),
                    TipoMovimentacao = table.Column<string>(type: "varchar(1)", nullable: false),
                    FundosId = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    ValorMovimentacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AplicacaoResgateId", x => x.AplicacaoResgateId);
                    table.ForeignKey(
                        name: "FK_AplicacaoResgate_Fundos_FundosId",
                        column: x => x.FundosId,
                        principalTable: "Fundos",
                        principalColumn: "FundosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicacaoResgate_FundosId",
                table: "AplicacaoResgate",
                column: "FundosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoResgate");

            migrationBuilder.DropTable(
                name: "Fundos");
        }
    }
}