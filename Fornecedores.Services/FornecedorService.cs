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
    => await _fornecedorRepository.AtualizarFornecedor(id, fornecedor);
    public async Task DeletarFornecedor(int id)
    => await _fornecedorRepository.DeletarFornecedor(id);
    public async Task InserirFornecedor(Fornecedor fornecedor)
    => await _fornecedorRepository.InserirFornecedor(fornecedor);
    public async Task<Fornecedor?> ObterFornecedor(int id)
    => await _fornecedorRepository.ObterFornecedor(id);
    public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
    => await _fornecedorRepository.ObterFornecedores();
}
