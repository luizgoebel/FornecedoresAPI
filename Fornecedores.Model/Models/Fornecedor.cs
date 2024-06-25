namespace Fornecedores.Model.Models;

public class Fornecedor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public void AtualizarFornecedor(Fornecedor fornecedorAtualizado)
    {
        this.Nome = string.IsNullOrEmpty(fornecedorAtualizado.Nome) ? this.Nome : fornecedorAtualizado.Nome;
        this.Email = string.IsNullOrEmpty(fornecedorAtualizado.Email) ? this.Email : fornecedorAtualizado.Email;
    }
}
