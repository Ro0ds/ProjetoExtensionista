namespace Common.Infra;
public class Rotas
{
    public static string APIRoute { get;  } = "https://localhost:7071/api/";
    public static string UsuarioLogin { get; } = "usuario/login";
    public static string BuscarUsuarioPorID { get; set; } = "usuario/listarPorId/";
}