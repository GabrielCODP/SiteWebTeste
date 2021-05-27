using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSiteWeb.Migrations
{
    public partial class TesteEscolhaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "TotalDeVendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TotalDeVendas_ProdutoId",
                table: "TotalDeVendas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TotalDeVendas_Produto_ProdutoId",
                table: "TotalDeVendas",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TotalDeVendas_Produto_ProdutoId",
                table: "TotalDeVendas");

            migrationBuilder.DropIndex(
                name: "IX_TotalDeVendas_ProdutoId",
                table: "TotalDeVendas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "TotalDeVendas");
        }
    }
}
