using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;
using Api.Interfaces.Usuario.Login;
using Api.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/usuario/")]
    [ApiController]
    public class UsuarioLoginController : ControllerBase
    {
        private readonly IUsuarioLoginServico _loginServico;
        private readonly IConfiguration _configuration;

        public UsuarioLoginController(IUsuarioLoginServico loginServico, IConfiguration configuration)
        {
            _loginServico = loginServico;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResposta>> Login(UsuarioLoginRequisicao requisicao)
        {
            var resposta = await _loginServico.Logar(requisicao);

            if(resposta.SUCESSO)
            {
                var token = GerarTokenJWT(
                    secretKey: ChaveJWT.PegarChaveSecreta(_configuration), 
                    issuer: "InovarJuntoAPI",
                    audience: "InovarJuntoFrontend",
                    expireInMinutes: 60 
                    );

                resposta.TOKEN = token;

                return resposta;
            }

            return Ok();
        }

        [Authorize]
        [HttpGet("teste")]
        public ActionResult<string> TesteAutorizacao()
        {
            //var token = Request.Headers.Authorization.ToString().Replace("Bearer", "");

            return Ok("autorizado");
        }

        private static string GerarTokenJWT(string secretKey, int expireInMinutes, string issuer, string audience)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "subject"),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };

            // var token = new JwtSecurityToken(
            //     issuer: issuer,
            //     audience: audience,
            //     claims: claims,
            //     expires: DateTime.UtcNow.AddMinutes(expireInMinutes),
            //     signingCredentials: credentials);

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
