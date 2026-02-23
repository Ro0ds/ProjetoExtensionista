namespace Common.DTO.Resposta.Base;
public class BaseResposta
{
    public bool Sucesso { get; set; } = true;
    public List<string> Erros { get; set; } = new List<string>();

    public void AdicionarErro(string erro)
    {
        Sucesso = false;
        Erros.Add(erro);
    }
}