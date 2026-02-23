using Common.DTO.Resposta.Produto;

namespace Common.DTO.Resposta.Base;
public class GenericResponse<T> : BaseResposta
{
    public T? Dados { get; set; }

    public static implicit operator GenericResponse<T>(List<ProdutoResposta> v)
    {
        throw new NotImplementedException();
    }
}