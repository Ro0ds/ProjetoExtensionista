using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.DTO.Requisicao.Usuario.Login;
using Common.Enums.USUARIO;
using Api.Interfaces.Usuario.Login;
using Api.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Common.DTO.Resposta.Usuario.Login;
using Api.Interfaces.Usuario.Operacoes;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/usuario/")]
    [ApiController]
    public class UsuarioLoginController : ControllerBase
    {
        private readonly IUsuarioLoginServico _loginServico;
        private readonly IUsuarioOperacoesServico _usuarioOperacoes;
        private readonly IConfiguration _configuration;

        public UsuarioLoginController(IUsuarioLoginServico loginServico, IConfiguration configuration, IUsuarioOperacoesServico usuarioOperacoes)
        {
            _loginServico = loginServico;
            _configuration = configuration;
            _usuarioOperacoes = usuarioOperacoes;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResposta>> Login(UsuarioLoginRequisicao requisicao)
        {
            var resposta = await _loginServico.Logar(requisicao);

            if(resposta.SUCESSO)
            {
                var usuarioID = await _loginServico.BuscarUsuario(requisicao.EMAIL, requisicao.SENHA);
                var usuario = await _usuarioOperacoes.BuscarUsuarioBrutoPorID(usuarioID);

                var token = GerarTokenJWT(
                    secretKey: ChaveJWT.PegarChaveSecreta(_configuration), 
                    userId: usuarioID,
                    issuer: "InovarJuntoAPI",
                    audience: "InovarJuntoFrontend",
                    expireInMinutes: 120,
                    permissaoId: usuario.PERMISSAOID
                    );

                resposta.TOKEN = token;

                return Ok(resposta);
            }

            return Unauthorized();
        }

        private static string GerarTokenJWT(string secretKey, int expireInMinutes, string issuer, string audience, int userId, int permissaoId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64),
                new Claim("roleId", permissaoId.ToString())
            };

            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expireInMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDecriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timespan = date - epoch;

            return (long)timespan.TotalSeconds;
        }
    }
}
