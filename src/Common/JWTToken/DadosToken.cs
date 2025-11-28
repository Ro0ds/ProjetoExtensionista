namespace Common.JWTToken;
public class DadosToken
{
    public int Id { get; set; }
    public Guid TokenId { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Permissao { get; set; } = string.Empty;
    public DateTime Expira { get; set; }
    public string CriadoPor { get; } = "InovarJuntoAPI";
    public string UsadoPor { get; } = "InovarJuntoFrontend";
}