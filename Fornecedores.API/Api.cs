using Fornecedores.Model;
using Fornecedores.Services.IServices;

namespace Fornecedores.API;

public static class Api
{
    private const string Pattern = "/Fornecedores/{id}";

    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Fornecedores", ObterFornecedor);
        app.MapGet(Pattern, ObterFornecedores);
        app.MapPost("/Fornecedores", InsertFornecedor);
        app.MapPut("/Fornecedores", AtualizarFornecedor);
        app.MapDelete("/Fornecedores", DeletarFornecedor);
    }
    private static async Task<IResult> ObterFornecedor(int id, IFornecedorService service)
    {
        return Results.Ok(await service.ObterFornecedor(id));
    }
    private static async Task<IResult> ObterFornecedores(IFornecedorService service)
    {
        return Results.Ok(await service.ObterFornecedores());
    }
    private static async Task<IResult> InsertFornecedor(Fornecedor fornecedor, IFornecedorService service)
    {
        await service.InserirFornecedor(fornecedor);
        return Results.Ok("Fornecedor foi inserido com sucesso!");
    }
    private static async Task<IResult> AtualizarFornecedor(Fornecedor fornecedor, IFornecedorService service)
    {
        await service.AtualizarFornecedor(fornecedor);
        return Results.Ok("Fornecedor foi atualizado com sucesso!");
    }
    private static async Task<IResult> DeletarFornecedor(int id, IFornecedorService service)
    {
        await service.DeletarFornecedor(id);
        return Results.Ok();
    }
}
