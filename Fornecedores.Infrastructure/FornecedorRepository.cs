﻿using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fornecedores.Infrastructure;

public class FornecedorRepository : IFornecedorRepository
{
    protected readonly FornecedorDbContext _contexto;

    public FornecedorRepository(FornecedorDbContext dbContext) => this._contexto = dbContext;

    public async Task AtualizarFornecedor(int id, Fornecedor atualizacao)
    {
        Fornecedor fornecedor = RecuperarFornecedor(id);
        fornecedor.AtualizarFornecedor(atualizacao);
        this._contexto.Fornecedores.Update(fornecedor);
        await this._contexto.SaveChangesAsync();
    }
    public async Task DeletarFornecedor(int id)
    {
        Fornecedor fornecedor = RecuperarFornecedor(id);
        this._contexto.Fornecedores.Remove(fornecedor);
        await this._contexto.SaveChangesAsync();
    }
    public async Task InserirFornecedor(Fornecedor fornecedor)
    {
        await this._contexto.Fornecedores.AddAsync(fornecedor);
        await this._contexto.SaveChangesAsync();
    }
    public async Task<Fornecedor?> ObterFornecedor(int id)
    => await this._contexto.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    => this._contexto.Fornecedores.ToList();
    private Fornecedor RecuperarFornecedor(int id)
    => this._contexto.Fornecedores.FirstOrDefault(x => x.Id == id);
}
