namespace Api.Interfaces.Funcionario;
public interface IFuncionarioRepositorio
{
    Task<bool> VerificarVinculo(int usuarioId, int empresaId);
    Task<int?> ObterFuncionarioIdPorUsuario(int usuarioId);
}