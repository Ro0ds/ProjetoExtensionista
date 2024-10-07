using Api.DTO.Requisicao.Usuario.Operacoes;
using Api.Interfaces.Usuario.Operacoes;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Servicos.Usuario.Operacoes
{
    public class UsuarioOperacoesServico : IUsuarioOperacoesServico 
    {
        private readonly IUsuarioOperacoesRepositorio _repositorio;

        public UsuarioOperacoesServico(IUsuarioOperacoesRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<UsuarioOperacoesConsulta> AtualizarUsuario(USUARIO usuario)
        {
            if(usuario != null)
            {
                var resposta = await _repositorio.Atualizar(usuario);

                if(resposta.SUCESSO)
                {
                    return resposta;
                }
                throw new Exception("Não foi possível atualizar o usuário.");
            }
            throw new Exception("Usuário não existe.");
        }

        public async Task<bool> DeletarUsuario(int usuarioID)
        {
            var usuario = await _repositorio.ListarBrutoPorID(usuarioID);

            if(usuario != null)
            {
                return await _repositorio.Deletar(usuarioID);
            }
            return false;
        }

        public async Task<List<UsuarioOperacoesConsulta>> BuscarUsuarios()
        {
            return await _repositorio.Listar();
        }

        public async Task<UsuarioOperacoesConsulta> BuscarUsuarioPorID(int usuarioID)
        {
            var resposta = await _repositorio.ListarPorID(usuarioID);

            if(resposta != null)
            {
                return resposta;
            }

            throw new Exception("Não foi possível encontrar usuário");
        }

        public async Task<USUARIO> BuscarUsuarioBrutoPorID(int usuarioID)
        {
            var resposta = await _repositorio.ListarBrutoPorID(usuarioID);

            if(resposta != null)
            {
                return resposta;
            }

            throw new Exception("Não foi possível encontrar usuário");
        }
    }
}