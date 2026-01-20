using Api.Interfaces.Usuario.Cadastro;
using Api.Interfaces.Usuario.Operacoes;
using Api.Repositorio.Usuario.Operacoes;
using Api.Repositorio.Usuario.Cadastro;
using Api.Servicos.Usuario.Cadastro;
using Api.Servicos.Usuario.Operacoes;
using Api.Interfaces.Usuario.Login;
using Api.Repositorio.Usuario.Login;
using Api.Servicos.Usuario.Login;
using Api.Interfaces.Empresa.Cadastro;
using Api.Repositorio.Empresa.Cadastro;
using Api.Servicos.Empresa.Cadastro;
using Api.Interfaces.Endereco.Cadastro;
using Api.Repositorio.Endereco.Cadastro;
using Api.Servicos.Endereco.Cadastro;
using Api.Interfaces.Produto;
using Api.Repositorio.Produto;
using Api.Servicos.Produto;
using Api.Interfaces.Funcionario;
using Api.Repositorio.Funcionario;

namespace Api.Extensoes;

public static class InjecoesDependencias
{
    public static void AdicionaInjecoesDependencias(this IServiceCollection services)
    {
        services.AddScoped<IEnderecoCadastroRepositorio, EnderecoCadastroRepositorio>();
        services.AddScoped<IEnderecoCadastroServico, EnderecoCadastroServico>();

        services.AddScoped<IUsuarioCadastroRepositorio, UsuarioCadastroRepositorio>();
        services.AddScoped<IUsuarioCadastroServico, UsuarioCadastroServico>();
        services.AddScoped<IUsuarioOperacoesRepositorio, UsuarioOperacoesRepositorio>();
        services.AddScoped<IUsuarioOperacoesServico, UsuarioOperacoesServico>();

        services.AddScoped<IUsuarioLoginRepositorio, UsuarioLoginRepositorio>();
        services.AddScoped<IUsuarioLoginServico, UsuarioLoginServico>();

        services.AddScoped<IEmpresaCadastroRepositorio, EmpresaCadastroRepositorio>();
        services.AddScoped<IEmpresaCadastroServico, EmpresaCadastroServico>();

        services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();

        services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
        services.AddScoped<IProdutoServico, ProdutoServico>();
    }
}