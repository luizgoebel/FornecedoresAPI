using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model.Models;
using Fornecedores.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fornecedores.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;
    public FornecedorService(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

    public async Task AtualizarFornecedor(int id, Fornecedor fornecedor)
    {
        try
        {
            if (id <= 0)
                throw new System.Exception("Preencher o id.");
            if (fornecedor is null)
                throw new System.Exception("Preencher os dados");
            await _fornecedorRepository.AtualizarFornecedor(id, fornecedor);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task DeletarFornecedor(int id)
    {
        if (id <= 0)
            throw new System.Exception("Preencher o id.");
        await _fornecedorRepository.DeletarFornecedor(id);
    }
    public async Task InserirFornecedor(Fornecedor fornecedor)
    {
        try
        {
            if (fornecedor is null)
                throw new System.Exception("Preencher os dados.");

            await _fornecedorRepository.InserirFornecedor(fornecedor);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task<Fornecedor?> ObterFornecedor(int id)
    {
        try
        {
            return await _fornecedorRepository.ObterFornecedor(id)
                ?? throw new System.Exception("Fornecedor não encontrado.");
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    {
        try
        {
            return await _fornecedorRepository.ObterFornecedores()
             ?? throw new System.Exception("Não há fornecedores cadastrados.");
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
