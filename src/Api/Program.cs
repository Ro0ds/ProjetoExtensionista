using Api.Extensoes;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors(options => 
{
    options.AddPolicy("AllowAll", builder => 
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.ConfiguraConexaoBD(configuration);
services.AdicionaInjecoesDependencias();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
//app.UseHttpsRedirection(); retirado para testes
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();