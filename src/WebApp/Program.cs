using Common.Infra;
using WebApp.Interfaces;
using WebApp.JWT;
using WebApp.Pages;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

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
