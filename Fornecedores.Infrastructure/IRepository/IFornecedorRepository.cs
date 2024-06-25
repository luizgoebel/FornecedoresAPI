using Fornecedores.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fornecedores.Infrastructure.IRepository;

public interface IFornecedorRepository
{
    Task DeletarFornecedor(int id);
    Task<Fornecedor?> ObterFornecedor(int id);
    Task<IEnumerable<Fornecedor>> ObterFornecedores();
    Task InserirFornecedor(Fornecedor fornecedor);
    Task AtualizarFornecedor(int id, Fornecedor fornecedor);
}
