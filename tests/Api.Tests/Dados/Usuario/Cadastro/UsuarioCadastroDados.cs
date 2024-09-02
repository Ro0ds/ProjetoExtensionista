using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;
using Api.Models;

namespace Api.Tests.Dados.Usuario.Cadastro
{
    public class UsuarioCadastroDados
    {
        public static IEnumerable<object[]> Dados =>
            new List<object[]>
            {
                new object[]
                {
                   new UsuarioCadastroRequisicao
                   {
                       NOME = "Maria Clara",
                       SOBRENOME = "da Silva Costa",
                       EMAIL = "mariaclara.silva@exemplo.com",
                       CPF = "12345678900",
                       TELEFONE = "11987654321",
                       CONFIRMACAO_SENHA = "SenhaSegura@2024",
                       ENDERECO = new ENDERECO
                       {
                           CEP = "04567010",
                           RUA = "Avenida Paulista",
                           NUMERO = 1000,
                           BAIRRO = "Bela Vista",
                           CIDADE = "São Paulo",
                           ESTADO = "São Paulo",
                           PAIS = "Brasil"
                       },
                       PERMISSAO = new PERMISSAO
                       {
                           NOME_PERMISSAO = "ADMINISTRADOR",
                           DESCRICAO = "Permissões administrativas completas."
                       },
                       USUARIO_ATIVO = true,
                       DATA_CRIADO = DateTime.Now,
                       SUCESSO = true
                   },
                },
                new object[]
                {
                   new UsuarioCadastroRequisicao
                   {
                        NOME = "João Pedro",
                        SOBRENOME = "Ferreira",
                        EMAIL = "joao.pedro@empresa.com.br",
                        CPF = "98765432100",
                        TELEFONE = "21998765432",
                        CONFIRMACAO_SENHA = "AcessoSeguro@456",
                        ENDERECO = new ENDERECO
                        {
                            CEP = "20040002",
                            RUA = "Rua do Ouvidor",
                            NUMERO = 150,
                            BAIRRO = "Centro",
                            CIDADE = "Rio de Janeiro",
                            ESTADO = "Rio de Janeiro",
                            PAIS = "Brasil"
                        },
                        PERMISSAO = new PERMISSAO
                        {
                            NOME_PERMISSAO = "MODERADOR",
                            DESCRICAO = "Usuário com permissões de moderação."
                        },
                        USUARIO_ATIVO = false,
                        DATA_CRIADO = DateTime.Now.AddDays(-30),
                        SUCESSO = true
                   },
                },
                new object[]
                {
                   new UsuarioCadastroRequisicao
                   {
                       NOME = "Ana Beatriz",
                       SOBRENOME = "Santos",
                       EMAIL = "ana.santos@dominio.com",
                       CPF = "11223344556",
                       TELEFONE = "11987651234",
                       CONFIRMACAO_SENHA = "SenhaAna@123",
                       ENDERECO = new ENDERECO
                       {
                           CEP = "13040002",
                           RUA = "Rua das Flores",
                           NUMERO = 234,
                           BAIRRO = "Jardim das Rosas",
                           CIDADE = "Campinas",
                           ESTADO = "São Paulo",
                           PAIS = "Brasil"
                       },
                       PERMISSAO = new PERMISSAO
                       {
                           NOME_PERMISSAO = "USUARIO",
                           DESCRICAO = "Permissões comuns para visualização."
                       },
                       USUARIO_ATIVO = true,
                       DATA_CRIADO = DateTime.Now.AddMonths(-3),
                       SUCESSO = true
                   },
                },
                new object[]
                {
                   new UsuarioCadastroRequisicao
                   {
                       NOME = "Carlos Eduardo",
                       SOBRENOME = "Mendes Oliveira",
                       EMAIL = "carlos.oliveira@corporativo.com",
                       CPF = "55443322110",
                       TELEFONE = "31999887766",
                       CONFIRMACAO_SENHA = "Carlos@2024",
                       ENDERECO = new ENDERECO
                       {
                           CEP = "30110003",
                           RUA = "Avenida Afonso Pena",
                           NUMERO = 500,
                           BAIRRO = "Centro",
                           CIDADE = "Belo Horizonte",
                           ESTADO = "Minas Gerais",
                           PAIS = "Brasil"
                       },
                       PERMISSAO = new PERMISSAO
                       {
                           NOME_PERMISSAO = "USUARIO",
                           DESCRICAO = "Usuário padrão com permissões limitadas."
                       },
                       USUARIO_ATIVO = true,
                       DATA_CRIADO = DateTime.Now.AddYears(-1),
                       SUCESSO = true
                   },
                },
                new object[]
                {
                   new UsuarioCadastroRequisicao
                   {
                       NOME = "Fernanda Souza",
                       SOBRENOME = "Almeida",
                       EMAIL = "fernanda.almeida@outlook.com",
                       CPF = "99887766554",
                       TELEFONE = "21999887766",
                       CONFIRMACAO_SENHA = "SenhaFernanda@2024",
                       ENDERECO = new ENDERECO
                       {
                           CEP = "40020004",
                           RUA = "Rua das Laranjeiras",
                           NUMERO = 789,
                           BAIRRO = "Centro Histórico",
                           CIDADE = "Salvador",
                           ESTADO = "Bahia",
                           PAIS = "Brasil"
                       },
                       PERMISSAO = new PERMISSAO
                       {
                           NOME_PERMISSAO = "ADMINISTRADOR",
                           DESCRICAO = "Administrador com permissões completas."
                       },
                       USUARIO_ATIVO = true,
                       DATA_CRIADO = DateTime.Now.AddDays(-15),
                       SUCESSO = true
                   }
                }
            };
    }
}