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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Limpa os provedores de log existentes
    logging.AddConsole();     // Adiciona o provedor de log para o console
});

// Configuração do DbContext
builder.Services.AddDbContext<FornecedorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(FornecedorDbContext).Assembly.FullName);
        }));

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

// Verifica se está em ambiente de desenvolvimento e aplica as Migrations se necessário
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<FornecedorDbContext>();
        dbContext.Database.Migrate(); // Aplica as Migrations se necessário
        logger.LogInformation("Migrations aplicadas com sucesso.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ocorreu um erro ao aplicar as Migrations.");
        throw;
    }
}

app.UseHttpsRedirection();
app.ConfigureApi();

app.Run();
