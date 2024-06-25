using Fornecedores.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fornecedores.Services.IServices
{
    /// <summary>
    /// Interface que define operações de serviço para manipulação de fornecedores.
    /// </summary>
    public interface IFornecedorService
    {
        /// <summary>
        /// Deleta um fornecedor pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor a ser deletado.</param>
        /// <returns>Uma tarefa que representa a operação de deleção.</returns>
        Task DeletarFornecedor(int id);

        /// <summary>
        /// Obtém um fornecedor pelo seu identificador único.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor a ser obtido.</param>
        /// <returns>O fornecedor encontrado ou nulo se não existir.</returns>
        Task<Fornecedor?> ObterFornecedor(int id);

        /// <summary>
        /// Obtém todos os fornecedores cadastrados.
        /// </summary>
        /// <returns>Uma coleção contendo todos os fornecedores.</returns>
        Task<IEnumerable<Fornecedor>> ObterFornecedores();

        /// <summary>
        /// Insere um novo fornecedor.
        /// </summary>
        /// <param name="fornecedor">Objeto contendo os dados do novo fornecedor a ser inserido.</param>
        /// <returns>Uma tarefa que representa a operação de inserção.</returns>
        Task InserirFornecedor(Fornecedor fornecedor);

        /// <summary>
        /// Atualiza os dados de um fornecedor.
        /// </summary>
        /// <param name="id">Identificador único do fornecedor.</param>
        /// <param name="fornecedorDto">Objeto contendo os novos dados do fornecedor.</param>
        /// <returns>Uma tarefa que representa a operação de atualização.</returns>
        Task AtualizarFornecedor(int id, Fornecedor fornecedor);
    }
}
