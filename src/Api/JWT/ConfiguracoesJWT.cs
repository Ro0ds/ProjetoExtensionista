using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Api.JWT
{
    public static class ConfiguracoesJWT
    {
        public static void ConfiguraJWT(this IServiceCollection services, IConfiguration configuration)
        {
            // autenticação config
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => 
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                    };
                    // Captura falhas de autenticação
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // Log para ver qual é o erro de autenticação
                            Console.WriteLine($"Falha na autenticação: {context.Exception.Message}");
                            context.Fail("Falha na autenticação");
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            // Pode personalizar a resposta para falhas de autenticação
                            Console.WriteLine("Falha no token: " + context.ErrorDescription);
                            context.HandleResponse();
                            context.Response.StatusCode = 401; // Unauthorized
                            context.Response.ContentType = "application/json";
                            context.Response.WriteAsync("{\"error\":\"Unauthorized\"}");
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}