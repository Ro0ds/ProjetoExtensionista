using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;
using Api.Interfaces.Usuario.Login;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/usuario/")]
    [ApiController]
    public class UsuarioLoginController : ControllerBase
    {
        private readonly IUsuarioLoginServico _loginServico;

        public UsuarioLoginController(IUsuarioLoginServico loginServico)
        {
            _loginServico = loginServico;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResposta>> Login(UsuarioLoginRequisicao requisicao)
        {
            return Ok(await _loginServico.Logar(requisicao));
        }
    }
}
