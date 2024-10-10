using Api.Dados;
using Api.Models;
using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;
using Api.Interfaces.Usuario.Login;
using Microsoft.EntityFrameworkCore;
using Api.Seguranca;

namespace Api.Repositorio.Usuario.Login
{
    public class UsuarioLoginRepositorio : IUsuarioLoginRepositorio
    {
        private readonly ApiDbContext _dbContext;

        public UsuarioLoginRepositorio(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<USUARIO?> BuscarUsuario(string email, string senha)
        {
            return await _dbContext.USUARIO
                .Where(u => u.EMAIL == email)
                .Include(s => s.SENHA)
                .SingleOrDefaultAsync();
        }

        public async Task<UsuarioLoginResposta> Logar(UsuarioLoginRequisicao requisicao)
        {
            var usuario = await BuscarUsuario(requisicao.EMAIL, requisicao.SENHA);

            if(usuario != null) // usuário encontrado
            {
                // verificar se a senha coincide
                Senha hashedSenha = new Senha();
                var senhaEstaCorreta = hashedSenha.SenhaEstaCorreta(usuario, requisicao.SENHA);

                if(senhaEstaCorreta)
                {
                    return MontarResposta
                    (
                        nome: string.IsNullOrWhiteSpace(usuario.NOME) ? usuario.NOME_SOCIAL : usuario.NOME,
                        token: ""
                    );
                }
                
                return MontarResposta
                (
                    manter_logado: false,
                    sucesso: false,
                    erros: "A senha não coincide."
                );
            }

            return MontarResposta
            (
                manter_logado: false,
                sucesso: false,
                erros: "Usuário não encontrado."
            );
        }

        private static UsuarioLoginResposta MontarResposta(string nome = "", string token = "", bool manter_logado = true, bool sucesso = true, string erros = "")
        {
            return new UsuarioLoginResposta
            {
                NOME = nome,
                TOKEN = token,
                SUCESSO = sucesso,
                MANTER_LOGADO = manter_logado,
                ERROS = erros
            };
        }
    }
}