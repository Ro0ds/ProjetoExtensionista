using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaAlterado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIA_EMPRESA_EMPRESAID",
                table: "CATEGORIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIA_USUARIO_USUARIOID",
                table: "CATEGORIA");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORIA_EMPRESAID",
                table: "CATEGORIA");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORIA_USUARIOID",
                table: "CATEGORIA");

            migrationBuilder.DropColumn(
                name: "EMPRESAID",
                table: "CATEGORIA");

            migrationBuilder.DropColumn(
                name: "USUARIOID",
                table: "CATEGORIA");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "CATEGORIA",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CATEGORIA",
                keyColumn: "DESCRICAO",
                keyValue: null,
                column: "DESCRICAO",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "CATEGORIA",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EMPRESAID",
                table: "CATEGORIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "USUARIOID",
                table: "CATEGORIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_EMPRESAID",
                table: "CATEGORIA",
                column: "EMPRESAID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_USUARIOID",
                table: "CATEGORIA",
                column: "USUARIOID");

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIA_EMPRESA_EMPRESAID",
                table: "CATEGORIA",
                column: "EMPRESAID",
                principalTable: "EMPRESA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIA_USUARIO_USUARIOID",
                table: "CATEGORIA",
                column: "USUARIOID",
                principalTable: "USUARIO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
