using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    CEP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    BAIRRO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIDADE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ESTADO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAIS = table.Column<string>(type: "longtext", nullable: false)
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
                    NOME_FANTASIA = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RAZAO_SOCIAL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNPJ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECOID = table.Column<int>(type: "int", nullable: false),
                    TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATA_CRIACAO_EMPRESA = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_CRIACAO_CADASTRO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EMPRESA_ATIVA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPRESA_ENDERECO_ENDERECOID",
                        column: x => x.ENDERECOID,
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
                    SENHAID = table.Column<int>(type: "int", nullable: false),
                    CARGO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ENDERECOID = table.Column<int>(type: "int", nullable: false),
                    PERMISSAOID = table.Column<int>(type: "int", nullable: false),
                    USUARIO_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DATA_CRIADO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_ADMISSAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DATA_DEMISSAO = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_ENDERECO_ENDERECOID",
                        column: x => x.ENDERECOID,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_PERMISSAO_PERMISSAOID",
                        column: x => x.PERMISSAOID,
                        principalTable: "PERMISSAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_SENHA_SENHAID",
                        column: x => x.SENHAID,
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
                    NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SOBRENOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME_SOCIAL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FOTO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TELEFONE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USUARIO_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DATA_CRIADO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SENHAID = table.Column<int>(type: "int", nullable: false),
                    ENDERECOID = table.Column<int>(type: "int", nullable: false),
                    PERMISSAOID = table.Column<int>(type: "int", nullable: false),
                    FUNCIONARIOID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_ENDERECO_ENDERECOID",
                        column: x => x.ENDERECOID,
                        principalTable: "ENDERECO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_FUNCIONARIO_FUNCIONARIOID",
                        column: x => x.FUNCIONARIOID,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USUARIO_PERMISSAO_PERMISSAOID",
                        column: x => x.PERMISSAOID,
                        principalTable: "PERMISSAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USUARIO_SENHA_SENHAID",
                        column: x => x.SENHAID,
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
                    USUARIOID = table.Column<int>(type: "int", nullable: false),
                    EMPRESAID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_EMPRESA_EMPRESAID",
                        column: x => x.EMPRESAID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_USUARIO_USUARIOID",
                        column: x => x.USUARIOID,
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
                    CATEGORIAID = table.Column<int>(type: "int", nullable: false),
                    EMPRESAID = table.Column<int>(type: "int", nullable: false),
                    USUARIOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA_CATEGORIAID",
                        column: x => x.CATEGORIAID,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_EMPRESA_EMPRESAID",
                        column: x => x.EMPRESAID,
                        principalTable: "EMPRESA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUTO_USUARIO_USUARIOID",
                        column: x => x.USUARIOID,
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
                    PRODUTOID = table.Column<int>(type: "int", nullable: false),
                    USUARIOID = table.Column<int>(type: "int", nullable: false),
                    FUNCIONARIOID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_HISTORICO_MOVIMENTACOES_FUNCIONARIO_FUNCIONARIOID",
                        column: x => x.FUNCIONARIOID,
                        principalTable: "FUNCIONARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORICO_MOVIMENTACOES_PRODUTO_PRODUTOID",
                        column: x => x.PRODUTOID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORICO_MOVIMENTACOES_USUARIO_USUARIOID",
                        column: x => x.USUARIOID,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_EMPRESAID",
                table: "CATEGORIA",
                column: "EMPRESAID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_USUARIOID",
                table: "CATEGORIA",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPRESA_ENDERECOID",
                table: "EMPRESA",
                column: "ENDERECOID");

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
                name: "IX_FUNCIONARIO_PERMISSAOID",
                table: "FUNCIONARIO",
                column: "PERMISSAOID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_SENHAID",
                table: "FUNCIONARIO",
                column: "SENHAID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_FUNCIONARIOID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "FUNCIONARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_PRODUTOID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "PRODUTOID");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_MOVIMENTACOES_USUARIOID",
                table: "HISTORICO_MOVIMENTACOES",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_CATEGORIAID",
                table: "PRODUTO",
                column: "CATEGORIAID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_EMPRESAID",
                table: "PRODUTO",
                column: "EMPRESAID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_USUARIOID",
                table: "PRODUTO",
                column: "USUARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_ENDERECOID",
                table: "USUARIO",
                column: "ENDERECOID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_FUNCIONARIOID",
                table: "USUARIO",
                column: "FUNCIONARIOID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERMISSAOID",
                table: "USUARIO",
                column: "PERMISSAOID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_SENHAID",
                table: "USUARIO",
                column: "SENHAID");
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
