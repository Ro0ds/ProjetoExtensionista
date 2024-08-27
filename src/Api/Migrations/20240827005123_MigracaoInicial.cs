using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUA = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIDADE = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ESTADO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAIS = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PERMISSAO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME_PERMISSAO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRICAO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSAO", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SENHA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PASSWORD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HASH = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SALT = table.Column<byte[]>(type: "longblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENHA", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME_FANTASIA = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RAZAO_SOCIAL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNPJ = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECO_ID = table.Column<int>(type: "int", nullable: false),
                    TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_CRIACAO_EMPRESA = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_CRIACAO_CADASTRO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EMPRESA_ATIVA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPRESA_ENDERECO_ENDERECO_ID",
                        column: x => x.ENDERECO_ID,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FUNCIONARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SOBRENOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME_SOCIAL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FOTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA_ID = table.Column<int>(type: "int", nullable: false),
                    CARGO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECO_ID = table.Column<int>(type: "int", nullable: false),
                    PERMISSAO_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DATA_CRIADO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ADMISSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_DEMISSAO = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_ENDERECO_ENDERECO_ID",
                        column: x => x.ENDERECO_ID,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_PERMISSAO_PERMISSAO_ID",
                        column: x => x.PERMISSAO_ID,
                        principalTable: "PERMISSAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_SENHA_SENHA_ID",
                        column: x => x.SENHA_ID,
                        principalTable: "SENHA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SOBRENOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME_SOCIAL = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FOTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA_ID = table.Column<int>(type: "int", nullable: false),
                    ENDERECO_ID = table.Column<int>(type: "int", nullable: false),
                    PERMISSAO_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DATA_CRIADO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FUNCIONARIO_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_ENDERECO_ENDERECO_ID",
                        column: x => x.ENDERECO_ID,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_FUNCIONARIO_FUNCIONARIO_ID",
                        column: x => x.FUNCIONARIO_ID,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISSAO_PERMISSAO_ID",
                        column: x => x.PERMISSAO_ID,
                        principalTable: "PERMISSAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_SENHA_SENHA_ID",
                        column: x => x.SENHA_ID,
                        principalTable: "SENHA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRICAO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false),
                    EMPRESA_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DESCRICAO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRECO = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false),
                    CATEGORIA_ID = table.Column<int>(type: "int", nullable: false),
                    EMPRESA_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_EMPRESA_EMPRESA_ID",
                        column: x => x.EMPRESA_ID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HISTORICO_MOVIMENTACOES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PRODUTO_ID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "int", nullable: false),
                    FUNCIONARIO_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    TIPO_MOVIMENTACAO = table.Column<int>(type: "int", nullable: false),
                    DATA_MOVIMENTACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_MOVIMENTACOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HISTORICO_MOVIMENTACOES_FUNCIONARIO_FUNCIONARIO_ID",
                        column: x => x.FUNCIONARIO_ID,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORICO_MOVIMENTACOES_PRODUTO_PRODUTO_ID",
                        column: x => x.PRODUTO_ID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORICO_MOVIMENTACOES_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_EMPRESA_ID",
                table: "CATEGORIA",
                column: "EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_USUARIO_ID",
                table: "CATEGORIA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ENDERECO_ID",
                table: "EMPRESA",
                column: "ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_EMAIL",
                table: "FUNCIONARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_ENDERECO_ID",
                table: "FUNCIONARIO",
                column: "ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_PERMISSAO_ID",
                table: "FUNCIONARIO",
                column: "PERMISSAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_SENHA_ID",
                table: "FUNCIONARIO",
                column: "SENHA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_FUNCIONARIO_ID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "FUNCIONARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_PRODUTO_ID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "PRODUTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_USUARIO_ID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_CATEGORIA_ID",
                table: "PRODUTO",
                column: "CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_EMPRESA_ID",
                table: "PRODUTO",
                column: "EMPRESA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_USUARIO_ID",
                table: "PRODUTO",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ENDERECO_ID",
                table: "USUARIO",
                column: "ENDERECO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FUNCIONARIO_ID",
                table: "USUARIO",
                column: "FUNCIONARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERMISSAO_ID",
                table: "USUARIO",
                column: "PERMISSAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_SENHA_ID",
                table: "USUARIO",
                column: "SENHA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HISTORICO_MOVIMENTACOES");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "EMPRESA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "PERMISSAO");

            migrationBuilder.DropTable(
                name: "SENHA");
        }
    }
}
