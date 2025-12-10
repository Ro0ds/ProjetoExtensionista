namespace Common.DTO.Resposta.Endereco.Cadastro;
public class EnderecoCadastroResposta
{
    public bool Sucesso { get; set; }
    public int EnderecoId { get; set; }
    public List<string> Erros { get; private set; }

    public EnderecoCadastroResposta()
    {
        Sucesso = false;
        EnderecoId = 0;
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