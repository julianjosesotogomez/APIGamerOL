using APIGamerOL.Application.Contracts;
using APIGamerOL.Application;
using APIGamerOL.Domain.Services.SecureDomainServices;
using APIGamerOL.Domain.Services.SecureDomainServices.Contracts;
using APIGamerOL.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

//Inyeccion de dependencias de DomainServices
builder.Services.AddScoped<ISecureDomainServices, SecureDomainServices>();

builder.Services.AddDbContext<SecureContext>(options =>
options.UseSqlServer("Data Source=JULIANSOTOGOMEZ\\SQLEXPRESS;Initial Catalog=GamerOL;Integrated Security=false;User ID=sa; Password=Blink3027@;MultipleActiveResultSets=True;"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
