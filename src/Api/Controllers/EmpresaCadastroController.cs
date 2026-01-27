using Api.Interfaces.Empresa.Cadastro;
using Common.DTO.Requisicao.Empresa.Cadastro;
using Common.DTO.Resposta.Empresa.Operacoes;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmpresaCadastroController : ControllerBase
{
    private readonly IEmpresaCadastroServico _empresaCadastroServico;

    public EmpresaCadastroController(IEmpresaCadastroServico empresaCadastroServico)
    {
        _empresaCadastroServico = empresaCadastroServico;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarEmpresa([FromBody]EmpresaCadastroRequisicao requisicao)
    {
        var resposta = await _empresaCadastroServico.Cadastrar(requisicao);
        if(resposta.Sucesso)
        {
            return Ok(resposta);
        }

        return BadRequest(resposta);
    }
}