using Api.Interfaces.Usuario.Cadastro;
using Api.Interfaces.Usuario.Operacoes;
using Api.Repositorio.Usuario.Operacoes;
using Api.Repositorio.Usuario.Cadastro;
using Api.Servicos.Usuario.Cadastro;
using Api.Servicos.Usuario.Operacoes;

namespace Api.Extensoes
{
    public static class InjecoesDependencias
    {
        public static void AdicionaInjecoesDependencias(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioCadastroRepositorio, UsuarioCadastroRepositorio>();
            services.AddScoped<IUsuarioCadastroServico, UsuarioCadastroServico>();
            services.AddScoped<IUsuarioOperacoesRepositorio, UsuarioOperacoesRepositorio>();
            services.AddScoped<IUsuarioOperacoesServico, UsuarioOperacoesServico>();
        }
    }
}