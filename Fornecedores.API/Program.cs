using Fornecedores.API;
using Fornecedores.API.Middlewares;
using Fornecedores.Infrastructure;
using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Services;
using Fornecedores.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Limpa os provedores de log existentes
    logging.AddConsole();     // Adiciona o provedor de log para o console
});

builder.Services.AddDbContext<FornecedorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Fornecedores", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Fornecedores V1");
});

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Aplicativo iniciado.");

app.UseHttpsRedirection();
app.ConfigureApi();

app.Run();
