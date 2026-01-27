using Common.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InicializacaoPermissoes permissoes = new InicializacaoPermissoes(modelBuilder);

            permissoes.Seed();

            modelBuilder.Entity<CATEGORIA>().HasData(
                new CATEGORIA { ID = 1, NOME = "Geral", DESCRICAO = "Produtos gerais", DATA_CRIACAO = DateTime.UtcNow },
                new CATEGORIA { ID = 2, NOME = "Eletrônicos", DESCRICAO = "Eletrônicos e gadgets", DATA_CRIACAO = DateTime.UtcNow },
                new CATEGORIA { ID = 3, NOME = "Roupas", DESCRICAO = "Vestuário", DATA_CRIACAO = DateTime.UtcNow },
                new CATEGORIA { ID = 4, NOME = "Alimentos", DESCRICAO = "Alimentos e bebidas", DATA_CRIACAO = DateTime.UtcNow }
                );
        }
    }
}