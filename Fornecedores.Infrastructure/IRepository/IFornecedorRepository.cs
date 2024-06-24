using Fornecedores.Model;

namespace Fornecedores.Infrastructure.IRepository;

public interface IFornecedorRepository
{
    Task DeletarFornecedor(int id);
    Task<Fornecedor?> ObterFornecedor(int id);
    Task<IEnumerable<Fornecedor>> ObterFornecedores();
    Task InserirFornecedor(Fornecedor fornecedor);
    Task AtualizarFornecedor(Fornecedor fornecedor);
}
