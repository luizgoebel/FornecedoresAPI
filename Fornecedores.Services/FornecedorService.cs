using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model;
using Fornecedores.Services.IServices;

namespace Fornecedores.Services;

public class FornecedorService : IFornecedorService
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public async Task AtualizarFornecedor(Fornecedor fornecedor)
    => await _fornecedorRepository.AtualizarFornecedor(fornecedor);
    public async Task DeletarFornecedor(int id)
    => await _fornecedorRepository.DeletarFornecedor(id);
    public async Task InserirFornecedor(Fornecedor fornecedor)
    => await _fornecedorRepository.InserirFornecedor(fornecedor);
    public async Task<Fornecedor?> ObterFornecedor(int id)
    => await _fornecedorRepository.ObterFornecedor(id);
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    => await _fornecedorRepository.ObterFornecedores();
}
