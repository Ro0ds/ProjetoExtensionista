using Api.Interfaces.Produto;
using Common.DTO.Requisicao.Produto.Cadastro;
using Common.DTO.Requisicao.Produto.Movimentacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoServico _produtoServico;

    public ProdutoController(IProdutoServico produtoServico)
    {
        _produtoServico = produtoServico;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        // filtrar pela empresaId do user logado
        var resultado = await _produtoServico.ListarTodos();

        if(resultado.Sucesso)
            return Ok(resultado.Dados);

        return BadRequest(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromBody] ProdutoCadastroRequisicao requisicao)
    {
        requisicao.UsuarioId = ObterUsuarioId();

        var resultado = await _produtoServico.Cadastrar(requisicao);

        if(resultado.Sucesso)
            return Ok(resultado);

        return BadRequest(resultado);
    }

    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar([FromBody] ProdutoMovimentacaoRequisicao requisicao)
    {
        requisicao.UsuarioId = ObterUsuarioId();

        var resultado = await _produtoServico.MovimentarEstoque(requisicao);

        if(resultado.Sucesso)
            return Ok(resultado);

        return BadRequest(resultado);
    }

    private int ObterUsuarioId()
    {
        var idClaim = User.Claims.FirstOrDefault(c => c.Type == "id" || c.Type == ClaimTypes.NameIdentifier);

        if(idClaim != null && int.TryParse(idClaim.Value, out int id))
            return id;
        return 0;
    }
}