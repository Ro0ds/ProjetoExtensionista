using Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.DTO.Requisicao.Empresa.Cadastro;
public class EmpresaCadastroRequisicao
{
    [Required]
    [Display(Name = "Nome Fantasia")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(255)]
    public string NomeFantasia { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Razão Social")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(255)]
    public string RazaoSocial { get; set; } = string.Empty;

    [Required]
    [Display(Name = "CNPJ")]
    [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
    [MaxLength(15)]
    public string CNPJ { get; set; } = string.Empty;

    [ForeignKey(nameof(ENDERECO))]
    public int EnderecoId { get; set; }
    public ENDERECO? Endereco { get; set; }

    [Display(Name = "Telefone")]
    [DataType(DataType.PhoneNumber)]
    public string Telefone { get; set; } = string.Empty;

    [Required]
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Campo {} é obrigatório.")]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Data de criação da empresa")]
    public DateTime DataCriacaoEmpresa { get; set; }

    [Required]
    [Display(Name = "Data de criação do cadastro")]
    public DateTime DataCriacaoCadastro { get; set; }

    [Required]
    public int EmpresaAtiva { get; set; } = 0;
}