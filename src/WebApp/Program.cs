using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp.Interfaces;
using WebApp.JWT;
using WebApp.Pages;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
    });

services.AddHttpClient("extensionistaAPI", client =>
{
    var baseUrl = Environment.GetEnvironmentVariable("ApiSettings__BaseUrl");

    client.BaseAddress = new Uri($"{baseUrl}/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.Name = "AspNetCore.Session";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

services.AddHttpContextAccessor();
services.AddScoped<ITokenService, TokenService>();
services.AddTransient<JwtTokenHandler>();
services.AddScoped<ProdutoApiService>();
services.AddScoped<EmpresaApiService>();

services.AddHttpClient<PrincipalModel>()
    .AddHttpMessageHandler<JwtTokenHandler>();

services.AddHttpClient();
services.AddRazorPages(opt =>
{
    opt.Conventions.AddPageRoute("/Account/Login", "");
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
