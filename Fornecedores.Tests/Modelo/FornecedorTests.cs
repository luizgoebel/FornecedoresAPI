using Fornecedores.Model.Models;

namespace Fornecedores.Tests.Modelo;

[TestFixture]
public class FornecedorTests
{
    [Test]
    public void AtualizarFornecedor_DeveAtualizarNomeEEmailQuandoInformados()
    {
        var fornecedor = new Fornecedor { Id = 1, Nome = "Fornecedor Original", Email = "original@example.com" };
        var fornecedorAtualizado = new Fornecedor { Nome = "Novo Nome", Email = "novoemail@example.com" };
        fornecedor.AtualizarFornecedor(fornecedorAtualizado);
        Assert.That(fornecedor.Nome, Is.EqualTo("Novo Nome"));
        Assert.That(fornecedor.Email, Is.EqualTo("novoemail@example.com"));
    }
}
