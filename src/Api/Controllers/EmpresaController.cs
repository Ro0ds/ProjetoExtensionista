using Api.Interfaces.Empresa.Cadastro;
using Api.Interfaces.Empresa.Operacoes;
using Common.DTO.Resposta.Empresa.Operacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaOperacoesServico _empresaServico;

    public EmpresaController(IEmpresaOperacoesServico empresaServico)
    {
        _empresaServico = empresaServico;
    }

    [HttpGet("minhas")]
    public async Task<ActionResult<List<EmpresaResposta>>> MinhasEmpresas()
    {
        var usuarioId = ObterUsuarioId();
        var empresas = await _empresaServico.ListarPorUsuario(usuarioId);
        return Ok(empresas);
    }

    private int ObterUsuarioId()
    {
        var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id" || c.Type == ClaimTypes.NameIdentifier);

        if(idClaim != null && int.TryParse(idClaim.Value, out int id))
            return id;
        return 0;
    }
}