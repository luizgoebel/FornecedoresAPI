using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Infrastructure;

public class FornecedorRepository : IFornecedorRepository
{
    protected readonly FornecedorDbContext _contexto;
    public async Task AtualizarFornecedor(Fornecedor fornecedor)
    => _contexto.Fornecedores.Update(fornecedor);
    public async Task DeletarFornecedor(int id)
    => _contexto.Fornecedores.FindAsync(id);
    public async Task InserirFornecedor(Fornecedor fornecedor)
    => await _contexto.Fornecedores.AddAsync(fornecedor);
    public async Task<Fornecedor?> ObterFornecedor(int id)
    => await _contexto.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    => _contexto.Fornecedores.ToList();
}
