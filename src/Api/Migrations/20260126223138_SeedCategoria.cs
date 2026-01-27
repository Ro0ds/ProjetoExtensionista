using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CATEGORIA",
                columns: new[] { "ID", "DATA_CRIACAO", "DESCRICAO", "NOME" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9448), "Produtos gerais", "Geral" },
                    { 2, new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9450), "Eletrônicos e gadgets", "Eletrônicos" },
                    { 3, new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9452), "Vestuário", "Roupas" },
                    { 4, new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9453), "Alimentos e bebidas", "Alimentos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
