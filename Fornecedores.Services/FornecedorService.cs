﻿using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model.Models;
using Fornecedores.Services.Exceptions;
using Fornecedores.Services.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fornecedores.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly ILogger<FornecedorService> _logger;

    public FornecedorService(IFornecedorRepository fornecedorRepository, ILogger<FornecedorService> logger)
    {
        this._fornecedorRepository = fornecedorRepository;
        this._logger = logger;
    }

    public async Task AtualizarFornecedor(int id, Fornecedor fornecedorDto)
    {
        try
        {
            if (id <= 0)
                throw new ServiceException("Preencher o id.");
            if (fornecedorDto is null)
                throw new ServiceException("Preencher os dados.");
            Fornecedor fornecedor = await _fornecedorRepository.ObterFornecedor(id)
                ?? throw new ServiceException("Fornecedor não encontrado.");
            await this._fornecedorRepository.AtualizarFornecedor(id, fornecedorDto);
            this._logger.LogInformation($"Fornecedor atualizado com sucesso.");
        }
        catch (ServiceException ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw new ServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw;
        }
    }
    public async Task DeletarFornecedor(int id)
    {
        try
        {
            if (id <= 0)
                throw new ServiceException("Preencher o id.");
            await this._fornecedorRepository.DeletarFornecedor(id);
            this._logger.LogInformation($"Fornecedor deletado com sucesso.");
        }
        catch (ServiceException ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw new ServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw;
        }
    }
    public async Task InserirFornecedor(Fornecedor fornecedor)
    {
        try
        {
            if (fornecedor is null)
                throw new ServiceException("Preencher os dados.");
            await this._fornecedorRepository.InserirFornecedor(fornecedor);
            this._logger.LogError($"Fornecedor Adicionado com sucesso.");

        }
        catch (ServiceException ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw new ServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw;
        }
    }
    public async Task<Fornecedor?> ObterFornecedor(int id)
    {
        try
        {
            if (id <= 0)
                throw new ServiceException("Preencher o id.");
            return await this._fornecedorRepository.ObterFornecedor(id)
                ?? throw new ServiceException("Fornecedor não encontrado.");
        }
        catch (ServiceException ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw new ServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw;
        }
    }
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    {
        try
        {
            return await this._fornecedorRepository.ObterFornecedores()
             ?? throw new ServiceException("Não há fornecedores cadastrados.");
        }
        catch (ServiceException ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw new ServiceException(ex.Message);
        }
        catch (Exception ex)
        {
            this._logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
