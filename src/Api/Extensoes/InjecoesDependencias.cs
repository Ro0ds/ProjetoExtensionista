using Api.Interfaces.Usuario.Cadastro;
using Api.Repositorio.Usuario.Cadastro;
using Api.Servicos.Usuario.Cadastro;

namespace Api.Extensoes
{
    public static class InjecoesDependencias
    {
        public static void AdicionaInjecoesDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioCadastroRepositorio, UsuarioCadastroRepositorio>();
            services.AddScoped<IUsuarioCadastroServico, UsuarioCadastroServico>();
        }
    }
}