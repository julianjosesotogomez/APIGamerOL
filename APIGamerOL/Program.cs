using APIGamerOL.Application.Contracts;
using APIGamerOL.Application;
using APIGamerOL.Domain.Services.SecureDomainServices;
using APIGamerOL.Domain.Services.SecureDomainServices.Contracts;
using APIGamerOL.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APIGamerOL.Domain.Services.CRUDDomainServices.Contracts;
using APIGamerOL.Domain.Services.CRUDDomainServices;
using AutoMapper;
using FluentAssertions.Common;
using APIGamerOL.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuracion de TOKEN 
builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes  =Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion de depencias de Application
builder.Services.AddScoped<ISecureApplication, SecureApplication>();
builder.Services.AddScoped<ICRUDApplication, CRUDApplication>();

//Inyeccion de dependencias de DomainServices
builder.Services.AddScoped<ISecureDomainServices, SecureDomainServices>();
builder.Services.AddScoped<ICRUDDomainServices,CRUDDomainServices>();

// Configuracion Automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperConfig());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var stringconnectionBD = builder.Configuration.GetSection("ConnectionStrings").GetSection("SecureContext").ToString();

builder.Services.AddDbContext<SecureContext>(options =>
options.UseSqlServer("Data Source=JULIANSOTOGOMEZ\\SQLEXPRESS;Initial Catalog=GamerOL;Integrated Security=false;User ID=sa; Password=Blink3027@;MultipleActiveResultSets=True;"));
builder.Services.AddDbContext<CRUDContext>(options =>
options.UseSqlServer("Data Source=JULIANSOTOGOMEZ\\SQLEXPRESS;Initial Catalog=GamerOL;Integrated Security=false;User ID=sa; Password=Blink3027@;MultipleActiveResultSets=True;"));

//Configuracion de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS", x =>
    {
        x.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("PoliticaCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
