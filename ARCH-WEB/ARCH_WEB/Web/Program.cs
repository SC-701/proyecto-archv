using Abstracciones.Interfaces.Reglas;
using Microsoft.AspNetCore.Authentication.Cookies;
using Autorizacion.Abstracciones.DA;
using Autorizacion.Abstracciones.Flujo;
using Autorizacion.DA;
using Autorizacion.DA.Repositorios;
using Autorizacion.Flujo;
using Autorizacion.Middleware;
using Reglas;

var builder = WebApplication.CreateBuilder(args);

//Configuración Autenticación
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/cuenta/Login";
        options.LogoutPath = "/cuenta/Logout";
        options.AccessDeniedPath = "/cuenta/Accesodenegado";
    });

//Configuración Autorización
builder.Services.AddTransient<IRepositorioDapper, RepositorioDapper>();
builder.Services.AddTransient<ISeguridadDA, SeguridadDA>();
builder.Services.AddTransient<IAutorizacionFlujo, AutorizacionFlujo>();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");

    options.Conventions.AllowAnonymousToPage("/Cuenta/Login");
    options.Conventions.AllowAnonymousToPage("/Cuenta/Registro");
    options.Conventions.AllowAnonymousToPage("/Cuenta/AccesoDenegado");
});
builder.Services.AddScoped<IConfiguracion, Configuracion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.AutorizacionClaims();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
