using Fornecedores.Infrastructure.DbContext;
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

    public FornecedorRepository(FornecedorDbContext dbContext)
    {
        _contexto = dbContext;
    }

    public async Task AtualizarFornecedor(int id, Fornecedor atualizacao)
    {
        Fornecedor fornecedor = RecuperarFornecedor(id);
        fornecedor.Nome = atualizacao.Nome;
        fornecedor.Email = atualizacao.Email;
        _contexto.Fornecedores.Update(fornecedor);
        await _contexto.SaveChangesAsync();
    }
    public async Task DeletarFornecedor(int id)
    => _contexto.Fornecedores.FindAsync(id);
    public async Task InserirFornecedor(Fornecedor fornecedor)
    => await _contexto.Fornecedores.AddAsync(fornecedor);
    public async Task<Fornecedor?> ObterFornecedor(int id)
    => await _contexto.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    => _contexto.Fornecedores.ToList();
    private Fornecedor RecuperarFornecedor(int id)
    {
        return _contexto.Fornecedores.FirstOrDefault(x => x.Id == id);
    }
}
