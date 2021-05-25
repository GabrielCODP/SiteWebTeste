using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSiteWeb.Migrations
{
    public partial class Teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Departamento_DepartamentoId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_DepartamentoId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_DepartamentoId",
                table: "Produto",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Departamento_DepartamentoId",
                table: "Produto",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
