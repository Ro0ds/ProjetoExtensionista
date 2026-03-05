using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoUsuarioProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTO_USUARIO_USUARIOID",
                table: "PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_PRODUTO_USUARIOID",
                table: "PRODUTO");

            migrationBuilder.DropColumn(
                name: "FUNCIONARIOID",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "USUARIOID",
                table: "PRODUTO");

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 1,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 3, 4, 22, 58, 39, 427, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 2,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 3, 4, 22, 58, 39, 427, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 3,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 3, 4, 22, 58, 39, 427, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 4,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 3, 4, 22, 58, 39, 427, DateTimeKind.Utc).AddTicks(9987));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FUNCIONARIOID",
                table: "USUARIO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "USUARIOID",
                table: "PRODUTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 1,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 2,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 3,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "ID",
                keyValue: 4,
                column: "DATA_CRIACAO",
                value: new DateTime(2026, 1, 26, 22, 31, 38, 153, DateTimeKind.Utc).AddTicks(9453));

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_USUARIOID",
                table: "PRODUTO",
                column: "USUARIOID");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTO_USUARIO_USUARIOID",
                table: "PRODUTO",
                column: "USUARIOID",
                principalTable: "USUARIO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
