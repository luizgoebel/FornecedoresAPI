using Fornecedores.API;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Services;
using Fornecedores.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IFornecedorService, FornecedorService>();
builder.Services.AddSingleton<IFornecedorRepository, FornecedorRepository>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureApi();

app.Run();
