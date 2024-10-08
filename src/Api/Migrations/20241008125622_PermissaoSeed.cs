using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class PermissaoSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PERMISSAO",
                columns: new[] { "ID", "DESCRICAO", "NOME_PERMISSAO" },
                values: new object[,]
                {
                    { 1, "Usuário com permissões administrativas do sistema inteiro.", "Administrador" },
                    { 2, "Usuário com permissões básicas do sistema inteiro.", "Usuário" },
                    { 3, "Usuário com permissões administrativas dentro de uma empresa.", "Responsável" },
                    { 4, "Usuário com permissões básicas dentro de uma empresa.", "Funcionário" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PERMISSAO",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PERMISSAO",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PERMISSAO",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PERMISSAO",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
