using Api.Dados;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensoes;

public static class ConexaoBD
{
    public static void ConfiguraConexaoBD(this IServiceCollection services, IConfiguration configuration)
    {
        var stringConexao = configuration.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 45));
                
        // pegando conexão de string do appSettings.json
        services.AddDbContext<ApiDbContext>(opt =>
        {
            opt.UseMySql(stringConexao, serverVersion);
        });
    }
}