using Api.Dados;
using Api.Interfaces.Usuario.Cadastro;
using Api.Repositorio.Usuario.Cadastro;
using Api.Servicos.Usuario.Cadastro;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//services.AddScoped<UsuarioCadastroServico, UsuarioCadastroRepositorio>();
services.AddScoped<IUsuarioCadastroRepositorio, UsuarioCadastroRepositorio>();

var stringConexao = configuration.GetConnectionString("ConexaoPadrao");

// pegando conex�o de string do appSettings.json
services.AddDbContext<ApiDbContext>(opt =>
{
    opt.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();