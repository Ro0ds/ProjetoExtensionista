using Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Common.DTO.Requisicao.Endereco.Cadastro;
public class EnderecoCadastroRequisicao
{
    [Required]
    [Display(Name = "CEP")]
    [DataType(DataType.PostalCode, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(8)]
    public string CEP { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Rua")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(100)]
    public string RUA { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Número")]
    public int NUMERO { get; set; }

    [Required]
    [Display(Name = "Bairro")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(50)]
    public string BAIRRO { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Cidade")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(100)]
    public string CIDADE { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Estado")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(20)]
    public string ESTADO { get; set; } = string.Empty;

    [Display(Name = "País")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(30)]
    public string PAIS { get; set; } = string.Empty;

    public ENDERECO MontarEndereco(EnderecoCadastroRequisicao requisicao)
    {
        return new ENDERECO
        {
            CEP = requisicao.CEP,
            RUA = requisicao.RUA,
            NUMERO = requisicao.NUMERO,
            BAIRRO = requisicao.BAIRRO,
            CIDADE = requisicao.CIDADE,
            ESTADO = requisicao.ESTADO,
            PAIS = requisicao.PAIS,
        };
    }

    public (bool Sucesso, EnderecoCadastroRequisicao requisicao, string[]? Erros) VerificarCampos(EnderecoCadastroRequisicao requisicao)
    {
        if(requisicao.CEP.Contains('.') || requisicao.CEP.Contains('-'))
            requisicao.CEP = requisicao.CEP.Replace('.', char.MinValue).Replace('-', char.MinValue);

        // TODO: verificar se existe mais alguma outra regra

        return (Sucesso: true, requisicao, Array.Empty<string>());
    }
}