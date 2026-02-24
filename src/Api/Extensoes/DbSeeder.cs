using Api.Dados;
using Common.Models;
using Common.Seguranca;

namespace Api.Extensoes;

public static class DbSeeder
{
    public static async Task SeedAdminAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApiDbContext>();

        if(!context.USUARIO.Any(u => u.PERMISSAOID == 1))
        {
            Senha senhaHashing = new Senha();
            string password = Environment.GetEnvironmentVariable("DEFAULT_ADMIN_PASSWORD")!;

            byte[] saltBytes = senhaHashing.GerarSalt();
            string hashedPassword = senhaHashing.HashSenha(password, saltBytes);
            string base64Salt = Convert.ToBase64String(saltBytes);
            byte[] retrieveSaltBytes = Convert.FromBase64String(base64Salt);

            var admin = new USUARIO
            {
                NOME = "Administrador",
                EMAIL = Environment.GetEnvironmentVariable("DEFAULT_ADMIN_EMAIL")!,
                SENHA = new SENHA
                {
                    HASH = hashedPassword,
                    PASSWORD = base64Salt,
                    SALT = retrieveSaltBytes
                },
                CPF = "11111111111",
                USUARIO_ATIVO = true,
                DATA_CRIADO = DateTime.UtcNow,
                PERMISSAOID = 1,                
                ENDERECO = new ENDERECO
                {
                    CEP = "1111",
                    RUA = "1111",
                    NUMERO = 1111,
                    BAIRRO = "1111",
                    CIDADE = "1111",
                    ESTADO = "11",
                    PAIS = "11"
                }
            };

            context.USUARIO.Add(admin);
            await context.SaveChangesAsync();
        }
    }
}