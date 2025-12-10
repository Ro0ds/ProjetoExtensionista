using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFieldNamesCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPRESA_ENDERECO_ENDERECO_ID",
                table: "EMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_ENDERECO_ID",
                table: "EMPRESA");

            migrationBuilder.AlterColumn<string>(
                name: "RAZAO_SOCIAL",
                table: "EMPRESA",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NOME_FANTASIA",
                table: "EMPRESA",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPRESA",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "EMPRESA",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ENDERECOID",
                table: "EMPRESA",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ENDERECOID",
                table: "EMPRESA",
                column: "ENDERECOID");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPRESA_ENDERECO_ENDERECOID",
                table: "EMPRESA",
                column: "ENDERECOID",
                principalTable: "ENDERECO",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMPRESA_ENDERECO_ENDERECOID",
                table: "EMPRESA");

            migrationBuilder.DropIndex(
                name: "IX_EMPRESA_ENDERECOID",
                table: "EMPRESA");

            migrationBuilder.DropColumn(
                name: "ENDERECOID",
                table: "EMPRESA");

            migrationBuilder.AlterColumn<string>(
                name: "RAZAO_SOCIAL",
                table: "EMPRESA",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "NOME_FANTASIA",
                table: "EMPRESA",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "EMPRESA",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "EMPRESA",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ENDERECO_ID",
                table: "EMPRESA",
                column: "ENDERECO_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EMPRESA_ENDERECO_ENDERECO_ID",
                table: "EMPRESA",
                column: "ENDERECO_ID",
                principalTable: "ENDERECO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
