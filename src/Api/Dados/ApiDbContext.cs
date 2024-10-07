using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Dados
{
    public class ApiDbContext : DbContext
    {
        // DI -> criação do contexto do banco de dados
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // definição das tabelas do sistema
        public DbSet<USUARIO> USUARIO {  get; set; }
        public DbSet<EMPRESA> EMPRESA {  get; set; }
        public DbSet<FUNCIONARIO> FUNCIONARIO {  get; set; }
        public DbSet<SENHA> SENHA {  get; set; }
        public DbSet<CATEGORIA> CATEGORIA {  get; set; }
        public DbSet<PRODUTO> PRODUTO {  get; set; }
        public DbSet<ENDERECO> ENDERECO {  get; set; }
        public DbSet<HISTORICO_MOVIMENTACOES> HISTORICO_MOVIMENTACOES {  get; set; }
        public DbSet<PERMISSAO> PERMISSAO {  get; set; }
    }
}