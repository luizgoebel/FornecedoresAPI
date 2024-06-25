using Fornecedores.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fornecedores.Infrastructure.IRepository
{
    /// <summary>
    /// Interface que define operações para manipulação de fornecedores no repositório.
    /// </summary>
    public interface IFornecedorRepository
    {
        /// <summary>
        /// Deleta um fornecedor do repositório pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor a ser deletado.</param>
        /// <returns>Uma tarefa que representa a operação de deleção.</returns>
        Task DeletarFornecedor(int id);

        /// <summary>
        /// Obtém um fornecedor do repositório pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor a ser obtido.</param>
        /// <returns>O fornecedor encontrado ou nulo se não existir.</returns>
        Task<Fornecedor?> ObterFornecedor(int id);

        /// <summary>
        /// Obtém todos os fornecedores cadastrados no repositório.
        /// </summary>
        /// <returns>Uma coleção contendo todos os fornecedores.</returns>
        Task<IEnumerable<Fornecedor>> ObterFornecedores();

        /// <summary>
        /// Insere um novo fornecedor no repositório.
        /// </summary>
        /// <param name="fornecedor">Objeto contendo os dados do novo fornecedor a ser inserido.</param>
        /// <returns>Uma tarefa que representa a operação de inserção.</returns>
        Task InserirFornecedor(Fornecedor fornecedor);

        /// <summary>
        /// Atualiza os dados de um fornecedor no repositório.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor.</param>
        /// <param name="fornecedor">Objeto contendo os novos dados do fornecedor.</param>
        /// <returns>Uma tarefa que representa a operação de atualização.</returns>
        Task AtualizarFornecedor(int id, Fornecedor fornecedor);
    }
}
