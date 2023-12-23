using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Produto",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DescricaoProduto = table.Column<string>(nullable: false),
                Situacao = table.Column<bool>(nullable: false),
                DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                CodigoFornecedor = table.Column<string>("varchar(10)", nullable: false),
                DescricaoFornecedor = table.Column<string>(nullable: false),
                CnpjFornecedor = table.Column<string>("varchar(14)", nullable: false)
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
