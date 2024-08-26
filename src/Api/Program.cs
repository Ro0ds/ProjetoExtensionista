using Api.Dados;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var stringConexao = configuration.GetConnectionString("ConexaoPadrao");

// pegando conexão de string do appSettings.json
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
