using Microsoft.AspNetCore.Mvc;
using Api.Interfaces.Usuario.Operacoes;
using Api.DTO.Requisicao.Usuario.Operacoes;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioOperacoesController : ControllerBase
    {
        private readonly IUsuarioOperacoesServico _usuarioOperacoesServico;

        public UsuarioOperacoesController(IUsuarioOperacoesServico usuarioOperacoesServico)
        {
            _usuarioOperacoesServico = usuarioOperacoesServico;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<List<UsuarioOperacoesConsulta>>> ListarUsuarios()
        {
            return Ok(await _usuarioOperacoesServico.BuscarUsuarios());
        }

        [HttpGet("listarPorId/{id}")]
        public async Task<ActionResult<UsuarioOperacoesConsulta>> ListarUsuarioPorId(int id)
        {
            return Ok(await _usuarioOperacoesServico.BuscarUsuarioPorID(id));
        }

        [HttpPut("atualizar")]
        public async Task<ActionResult<UsuarioOperacoesConsulta>> AtualizarUsuario(USUARIO usuario)
        {
            return Ok(await _usuarioOperacoesServico.AtualizarUsuario(usuario));
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<bool>> DeletarUsuario(int id)
        {
            return Ok(await _usuarioOperacoesServico.DeletarUsuario(id));
        }
    }
}