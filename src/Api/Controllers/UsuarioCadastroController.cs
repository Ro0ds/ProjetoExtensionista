using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;
using Api.Interfaces.Usuario.Cadastro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/usuario/cadastro")]
    [ApiController]
    public class UsuarioCadastroController : ControllerBase
    {
        private readonly IUsuarioCadastroServico _usuarioServico;

        public UsuarioCadastroController(IUsuarioCadastroServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost("CadastrarUsuario")]  
        public async Task<ActionResult<UsuarioCadastroResposta>> Cadastrar([FromBody] UsuarioCadastroRequisicao requisicao)
        {
            var resposta = await _usuarioServico.CadastrarUsuario(requisicao);

            if(resposta.SUCESSO == false)
            {
                return NotFound(resposta);
            }
            
            return Ok(resposta);
        }
    }
}