using APIGamerOL.Application.Contracts;
using APIGamerOL.Application;
using APIGamerOL.Domain.Services.SecureDomainServices;
using APIGamerOL.Domain.Services.SecureDomainServices.Contracts;
using APIGamerOL.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
