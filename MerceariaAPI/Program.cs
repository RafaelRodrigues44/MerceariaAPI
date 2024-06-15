using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MerceariaAPI.Areas.Identity.Models;
using MerceariaAPI.Areas.Identity.Repositories.Role;
using MerceariaAPI.Areas.Identity.Repositories.User;
using MerceariaAPI.Areas.Identity.Repositories.Type;
using MerceariaAPI.Data;
using MerceariaAPI.Repositories;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITypeUserRepository, TypeUserRepository>();

// Registro do repositório genérico para todas as entidades
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<AppDbContext>();

// Configuração do JWT
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = key
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            // Evita o redirecionamento automático para a página de login padrão do browser
            context.HandleResponse();
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.Redirect("/Auth/AccessDenied");
            }
            return Task.CompletedTask;
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.Redirect("/Auth/AccessDenied");
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

// Configuração da sessão
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

// Middleware para passar o token JWT para todas as requisições
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Append("Authorization", "Bearer " + token);
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

// Adicionar middleware para tratar exceções de autorização
app.Use(async (context, next) =>
{
    await next.Invoke();

    if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
    {
        context.Response.Redirect("/Auth/AccessDenied");
    }
    else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
    {
        context.Response.Redirect("/Auth/AccessDenied");
    }
});

// Adicionando a configuração para carregar a view index.html ao acessar o root da aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Adicione uma rota específica para AccessDenied, se necessário
app.MapControllerRoute(
    name: "accessDenied",
    pattern: "Auth/AccessDenied",
    defaults: new { controller = "Auth", action = "AccessDenied" });

app.Run();
