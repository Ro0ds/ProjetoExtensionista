namespace Common.DTO.Resposta.Usuario.Login
{
    public class UsuarioLoginResposta
    {
        public bool SUCESSO { get; set; } = false;
        public string TOKEN { get; set; } = string.Empty;
        public string NOME { get; set; } = string.Empty;
        public bool MANTER_LOGADO { get; set; } = false;
        public string ERROS { get; set; } = string.Empty;
    }
}