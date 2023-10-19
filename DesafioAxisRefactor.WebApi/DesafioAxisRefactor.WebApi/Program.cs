using DesafioAxisRefactor.Domain.Interfaces.Repositories;
using DesafioAxisRefactor.Domain.Services.Interfaces;
using DesafioAxisRefactor.Domain.Services.Validation;
using DesafioAxisRefactor.Infrastructure.Data.Context;
using DesafioAxisRefactor.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIAxisDesafio", Description = "Desafio da empresa Axis", Version = "v1" });
});

string connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

services.AddDbContext<DesafioAxisRefactorContext>(options =>
    options.UseNpgsql(connectionString));

//injeção de dependencias

services.AddScoped<ICooperadoRepository, CooperadoRepository>();
services.AddScoped<ICooperativaRepository, CooperativaRepository>();
services.AddScoped<IFavoritosRepository, FavoritosRepository>();
services.AddScoped<ICooperativaValidation, CooperativaValidation>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIDesafioAxis v1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
