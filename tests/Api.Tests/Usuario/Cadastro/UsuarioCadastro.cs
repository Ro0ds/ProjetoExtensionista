using Api.Models;
using Api.Seguranca;
using Api.Tests.Dados.Usuario.Cadastro;
using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;

namespace Api.Tests.Usuario.Cadastro
{
    public class UsuarioCadastro
    {
        // estrutura padrão para testes
        private readonly UsuarioCadastroRequisicao _requisicao;
        public readonly Senha _senha;

        public UsuarioCadastro()
        {
            _requisicao = new UsuarioCadastroRequisicao
            {
                NOME = "Rodrigo Gabriel",
                SOBRENOME = "de Melo da Silva",
                EMAIL = "digo_gabriel97@yahoo.com.br",
                CPF = "48039408865",
                TELEFONE = "11984390405",
                CONFIRMACAO_SENHA = "Acesso@123",
                ENDERECO = new ENDERECO
                {
                    CEP = "09230610",
                    RUA = "Laureano",
                    NUMERO = 1225,
                    BAIRRO = "Camilopolis",
                    CIDADE = "Santo André",
                    ESTADO = "São Paulo",
                    PAIS = "Brasil"
                },
                PERMISSAO = new PERMISSAO
                {
                    NOME_PERMISSAO = "USUARIO",
                    DESCRICAO = "Usuário com permissões comuns para visualizar o sistema."
                },
                USUARIO_ATIVO = true,
                DATA_CRIADO = DateTime.Now,
                SUCESSO = true
            };
            _senha = new Senha();
        }

        [Theory]
        [InlineData("Acesso@123")]
        [InlineData("123459789")]
        [InlineData("Entrar@123")]
        [InlineData("senhanormal")]
        [InlineData("senhadiferentecom@")]
        public void CadastrarSemBanco(string senhaDigitada)
        {
            _requisicao.CONFIRMACAO_SENHA = senhaDigitada;
            var usuario = _requisicao.MontarUsuario();

            if (usuario.USUARIO_ATIVO)
            {
                Assert.True(_requisicao.SUCESSO);
            }
        }

        [Theory]
        [InlineData("Acesso@123")]
        [InlineData("123459789")]
        [InlineData("Entrar@123")]
        [InlineData("senhanormal")]
        [InlineData("senhadiferentecom@")]
        public void SenhaCriptografando(string senhaDigitada)
        {
            var salt = _senha.GerarSalt();
            var hashSenha = _senha.HashSenha(senhaDigitada, salt);

            Assert.True(hashSenha != senhaDigitada);
        }

        [Theory]
        [InlineData("Acesso@123")]
        [InlineData("123459789")]
        [InlineData("Entrar@123")]
        [InlineData("senhanormal")]
        [InlineData("senhadiferentecom@")]
        public void PossivelFazerLogin(string senhaDigitada)
        {
            _requisicao.CONFIRMACAO_SENHA = senhaDigitada;
            var usuario = _requisicao.MontarUsuario();

            var senhaEstaCorreta = _senha.SenhaEstaCorreta(usuario, _requisicao);

            Assert.True(senhaEstaCorreta);
        }

        [Theory]
        [MemberData(nameof(UsuarioCadastroDados.Dados), MemberType = typeof(UsuarioCadastroDados))]
        public void CadastroDeUsuarioNoBanco(UsuarioCadastroRequisicao requisicao)
        {
            var usuario = requisicao.MontarUsuario();
            UsuarioCadastroResposta resposta = new UsuarioCadastroResposta(usuario);

            var cadastrado = resposta.UsuarioFoiCadastrado(true, usuario);

            Assert.True(cadastrado.Item1);
        }
    }
}