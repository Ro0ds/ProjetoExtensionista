using Api.Dados;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensoes
{
    public static class ConexaoBD
    {
        public static void ConfiguraConexaoBD(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConexao = configuration.GetConnectionString("ConexaoPadrao");

            // pegando conexão de string do appSettings.json
            services.AddDbContext<ApiDbContext>(opt =>
            {
                opt.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
            });
        }
    }
}