using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioAlterado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_ENDERECO_ENDERECOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_PERMISSAO_PERMISSAOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_SENHA_SENHAID",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_USUARIO_FUNCIONARIO_FUNCIONARIOID",
                table: "USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_USUARIO_FUNCIONARIOID",
                table: "USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_EMAIL",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_ENDERECOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_SENHAID",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "DATA_CRIADO",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "ENDERECOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "FOTO",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "NOME",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "NOME_SOCIAL",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "SOBRENOME",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "TELEFONE",
                table: "FUNCIONARIO");

            migrationBuilder.RenameColumn(
                name: "USUARIO_ATIVO",
                table: "FUNCIONARIO",
                newName: "ATIVO");

            migrationBuilder.RenameColumn(
                name: "SENHAID",
                table: "FUNCIONARIO",
                newName: "USUARIOID");

            migrationBuilder.RenameColumn(
                name: "PERMISSAOID",
                table: "FUNCIONARIO",
                newName: "EMPRESAID");

            migrationBuilder.RenameIndex(
                name: "IX_FUNCIONARIO_PERMISSAOID",
                table: "FUNCIONARIO",
                newName: "IX_FUNCIONARIO_EMPRESAID");

            migrationBuilder.AlterColumn<string>(
                name: "CARGO",
                table: "FUNCIONARIO",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "SALARIO",
                table: "FUNCIONARIO",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_USUARIOID",
                table: "FUNCIONARIO",
                column: "USUARIOID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_EMPRESA_EMPRESAID",
                table: "FUNCIONARIO",
                column: "EMPRESAID",
                principalTable: "EMPRESA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_USUARIO_USUARIOID",
                table: "FUNCIONARIO",
                column: "USUARIOID",
                principalTable: "USUARIO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_EMPRESA_EMPRESAID",
                table: "FUNCIONARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_FUNCIONARIO_USUARIO_USUARIOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropIndex(
                name: "IX_FUNCIONARIO_USUARIOID",
                table: "FUNCIONARIO");

            migrationBuilder.DropColumn(
                name: "SALARIO",
                table: "FUNCIONARIO");

            migrationBuilder.RenameColumn(
                name: "USUARIOID",
                table: "FUNCIONARIO",
                newName: "SENHAID");

            migrationBuilder.RenameColumn(
                name: "EMPRESAID",
                table: "FUNCIONARIO",
                newName: "PERMISSAOID");

            migrationBuilder.RenameColumn(
                name: "ATIVO",
                table: "FUNCIONARIO",
                newName: "USUARIO_ATIVO");

            migrationBuilder.RenameIndex(
                name: "IX_FUNCIONARIO_EMPRESAID",
                table: "FUNCIONARIO",
                newName: "IX_FUNCIONARIO_PERMISSAOID");

            migrationBuilder.AlterColumn<string>(
                name: "CARGO",
                table: "FUNCIONARIO",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "FUNCIONARIO",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_CRIADO",
                table: "FUNCIONARIO",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "FUNCIONARIO",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ENDERECOID",
                table: "FUNCIONARIO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FOTO",
                table: "FUNCIONARIO",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NOME",
                table: "FUNCIONARIO",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NOME_SOCIAL",
                table: "FUNCIONARIO",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SOBRENOME",
                table: "FUNCIONARIO",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TELEFONE",
                table: "FUNCIONARIO",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FUNCIONARIOID",
                table: "USUARIO",
                column: "FUNCIONARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_EMAIL",
                table: "FUNCIONARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ENDERECOID",
                table: "FUNCIONARIO",
                column: "ENDERECOID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_SENHAID",
                table: "FUNCIONARIO",
                column: "SENHAID");

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_ENDERECO_ENDERECOID",
                table: "FUNCIONARIO",
                column: "ENDERECOID",
                principalTable: "ENDERECO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_PERMISSAO_PERMISSAOID",
                table: "FUNCIONARIO",
                column: "PERMISSAOID",
                principalTable: "PERMISSAO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FUNCIONARIO_SENHA_SENHAID",
                table: "FUNCIONARIO",
                column: "SENHAID",
                principalTable: "SENHA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIO_FUNCIONARIO_FUNCIONARIOID",
                table: "USUARIO",
                column: "FUNCIONARIOID",
                principalTable: "FUNCIONARIO",
                principalColumn: "ID");
        }
    }
}
