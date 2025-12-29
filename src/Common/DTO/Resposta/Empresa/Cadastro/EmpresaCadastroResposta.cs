namespace Common.DTO.Resposta.Empresa.Cadastro;
public class EmpresaCadastroResposta
{
    public bool Sucesso { get; set; }
    public int EmpresaId { get; set; }
    public List<string> Erros { get; private set; }

    public EmpresaCadastroResposta()
    {
        Sucesso = false;
        EmpresaId = 0;
        Erros = new List<string>();
    }

    public void AdicionarErro(string erro)
    {
        Erros.Add(erro);
    }

    public void AdicionarErros(string[] erros)
    {
        Erros.AddRange(erros);
    }
}