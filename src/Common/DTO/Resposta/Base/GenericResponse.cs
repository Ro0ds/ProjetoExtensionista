namespace Common.DTO.Resposta.Base;
public class GenericResponse<T> : BaseResposta
{
    public T? Dados { get; set; } 
}