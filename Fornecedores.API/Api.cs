using Fornecedores.Model.Models;
using Fornecedores.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Fornecedores.API;

public static class Api
{
    private const string Pattern = "api/Fornecedores";

    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(Pattern, ObterFornecedores);
        app.MapGet($"{Pattern}/{"id"}", ObterFornecedor);
        app.MapPost(Pattern, InsertFornecedor);
        app.MapPut($"{Pattern}/{"id"}", AtualizarFornecedor);
        app.MapDelete($"{Pattern}/{"id"}", DeletarFornecedor);
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
    private static async Task<IResult> AtualizarFornecedor(int id, Fornecedor fornecedor, IFornecedorService service)
    {
        await service.AtualizarFornecedor(id, fornecedor);
        return Results.Ok("Fornecedor foi atualizado com sucesso!");
    }
    private static async Task<IResult> DeletarFornecedor(int id, IFornecedorService service)
    {
        await service.DeletarFornecedor(id);
        return Results.Ok("Fornecedor deletado com sucesso!");
    }
}
