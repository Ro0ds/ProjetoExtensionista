using Api.Models;

namespace Api.DTO.Requisicao.Usuario.Operacoes
{
    public class UsuarioOperacoesConsulta
    {
        public required string NOME { get; set; } = string.Empty;
        public required string SOBRENOME { get; set; } = string.Empty;
        public string? NOME_SOCIAL { get; set; }
        public required string EMAIL { get; set; } = string.Empty;
        public required string CPF { get; set; } = string.Empty;
        public string? FOTO { get; set; }
        public required string TELEFONE { get; set; } = string.Empty;
        public required ENDERECO ENDERECO { get; set; }
        public required PERMISSAO PERMISSAO { get; set; }
        public bool USUARIO_ATIVO { get; set; } = true;
        public DateTime DATA_CRIADO { get; set; }

        public bool SUCESSO { get; set; } = false;
        public List<string> ERROS { get; set; } = [];

        public void AdicionarErro(string erro)
        {
            ERROS.Add(erro);
            SUCESSO = false;
        } 
    }
}