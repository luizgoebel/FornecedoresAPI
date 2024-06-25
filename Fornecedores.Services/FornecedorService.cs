using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model.Models;
using Fornecedores.Services.Exceptions;
using Fornecedores.Services.IServices;
using System;
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
                throw new ServiceException("Preencher o id.");
            if (fornecedor is null)
                throw new ServiceException("Preencher os dados");
            await _fornecedorRepository.AtualizarFornecedor(id, fornecedor);
        }
        catch (ServiceException ex)
        {
            throw new ServiceException(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task DeletarFornecedor(int id)
    {
        try
        {
            if (id <= 0)
                throw new ServiceException("Preencher o id.");
            await _fornecedorRepository.DeletarFornecedor(id);
        }
        catch (ServiceException ex)
        {
            throw new ServiceException(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task InserirFornecedor(Fornecedor fornecedor)
    {
        try
        {
            if (fornecedor is null)
                throw new ServiceException("Preencher os dados.");

            await _fornecedorRepository.InserirFornecedor(fornecedor);
        }
        catch (ServiceException ex)
        {
            throw new ServiceException(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Fornecedor?> ObterFornecedor(int id)
    {
        try
        {
            if(id <= 0)
                throw new ServiceException("Preencher o id.");
            return await _fornecedorRepository.ObterFornecedor(id)
                ?? throw new ServiceException("Fornecedor não encontrado.");
        }
        catch (ServiceException ex)
        {
            throw new ServiceException(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    {
        try
        {
            return await _fornecedorRepository.ObterFornecedores()
             ?? throw new ServiceException("Não há fornecedores cadastrados.");
        }
        catch (ServiceException ex)
        {
            throw new ServiceException(ex.Message);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
