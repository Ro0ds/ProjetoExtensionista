using Api.Dados;
using Api.DTO.Requisicao.Usuario.Operacoes;
using Api.Interfaces.Usuario.Operacoes;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorio.Usuario.Operacoes
{
    public class UsuarioOperacoesRepositorio : IUsuarioOperacoesRepositorio
    {
        private readonly ApiDbContext _dbContext;


        public UsuarioOperacoesRepositorio(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioOperacoesConsulta>> Listar()
        {
            List<USUARIO> usuarios = 
                await _dbContext.USUARIO
                .Include(e => e.ENDERECO)
                .Include(p => p.PERMISSAO)
                .ToListAsync();

            List<UsuarioOperacoesConsulta> usuariosMontados = new List<UsuarioOperacoesConsulta>();

            if(usuarios.Count > 0)
            {
                foreach(var usuario in usuarios)
                {
                    usuariosMontados.Add(MontarUsuario(usuario: usuario, sucesso: true));
                }
            }

            return usuariosMontados;
        }

        public async Task<UsuarioOperacoesConsulta> ListarPorID(int usuarioID)
        {
            var usuario = 
                await _dbContext.USUARIO
                .Where(u => u.ID == usuarioID)
                .Include(e => e.ENDERECO)
                .Include(p => p.PERMISSAO)
                .SingleOrDefaultAsync();

            return MontarUsuario(usuario!, sucesso: true);
        }

        public async Task<UsuarioOperacoesConsulta> Atualizar(USUARIO usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            _dbContext.USUARIO.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return MontarUsuario(usuario, sucesso: true);
        }

        public async Task<bool> Deletar(int usuarioID)
        {
            var usuario = 
                await _dbContext.USUARIO
                    .Where(u => u.ID == usuarioID)
                    .Include(e => e.ENDERECO)
                    .Include(p => p.PERMISSAO)
                    .SingleOrDefaultAsync();
            try
            {
                _dbContext.ENDERECO.Remove(usuario!.ENDERECO!);
                _dbContext.PERMISSAO.Remove(usuario!.PERMISSAO!);
                _dbContext.USUARIO.Remove(usuario!);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public UsuarioOperacoesConsulta MontarUsuario(USUARIO usuario, List<string>? erros = null, bool sucesso = false)
        {
            return new UsuarioOperacoesConsulta
            {
                NOME = usuario.NOME,
                SOBRENOME = usuario.SOBRENOME,
                NOME_SOCIAL = usuario.NOME_SOCIAL,
                EMAIL = usuario.EMAIL,
                CPF = usuario.CPF,
                FOTO = usuario.FOTO,
                TELEFONE = usuario.TELEFONE,
                ENDERECO = usuario.ENDERECO!,
                PERMISSAO = usuario.PERMISSAO!,
                USUARIO_ATIVO = usuario.USUARIO_ATIVO,
                DATA_CRIADO = usuario.DATA_CRIADO,
                SUCESSO = sucesso,
                ERROS = erros!
            };
        }
    }
}
