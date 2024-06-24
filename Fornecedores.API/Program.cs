using Fornecedores.API;
using Fornecedores.Infrastructure;
using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Services;
using Fornecedores.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do DbContext
builder.Services.AddDbContext<FornecedorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Configura��o dos servi�os
builder.Services.AddSingleton<IFornecedorService, FornecedorService>();
builder.Services.AddSingleton<IFornecedorRepository, FornecedorRepository>();

// Configura��o do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiFornecedores", Version = "v1" });
});
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Middleware para habilitar o Swagger JSON endpoint
app.UseSwagger();

// Middleware para habilitar o Swagger UI (interface do usu�rio)
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiFornecedores V1");
});

// Configura��o adicional do pipeline HTTP
app.UseHttpsRedirection();
app.ConfigureApi();  // Supondo que isso configura o resto da API, ajuste conforme necess�rio

app.Run();
