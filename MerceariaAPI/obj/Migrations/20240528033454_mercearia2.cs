using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerceariaAPI.Migrations
{
    /// <inheritdoc />
    public partial class mercearia2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_TipoProdutos_TipoProdutoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_TipoProdutoId",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produtos_TipoProdutoId",
                table: "Produtos",
                column: "TipoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_TipoProdutos_TipoProdutoId",
                table: "Produtos",
                column: "TipoProdutoId",
                principalTable: "TipoProdutos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
