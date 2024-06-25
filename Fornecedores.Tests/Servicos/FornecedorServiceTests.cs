using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Infrastructure.IRepository;
using Fornecedores.Model.Models;
using Fornecedores.Services;
using Fornecedores.Services.Exceptions;
using Fornecedores.Services.IServices;
using Fornecedores.Tests.Setup;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Fornecedores.Tests.Servicos;

[TestFixture]
public class FornecedorServiceTests
{
    private IFornecedorService _fornecedorService;
    private IFornecedorRepository _fornecedorRepository;
    private ILogger<FornecedorService> _logger;
    private FornecedorDbContext _dbContext;

    [SetUp]
    public void SetUp()
    {
        this._dbContext = FornecedorDbContextMock.Create();
        this._fornecedorRepository = Substitute.For<IFornecedorRepository>();
        this._logger = Substitute.For<ILogger<FornecedorService>>();
        this._fornecedorService = new FornecedorService(_fornecedorRepository, _logger);
    }
    [TearDown]
    public void TearDown()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }

    [Test]
    public void AtualizarFornecedor_DeveAtualizarNomeEEmailQuandoInformados()
    {
        var fornecedor = new Fornecedor { Id = 1, Nome = "Fornecedor Original", Email = "original@example.com" };
        var fornecedorAtualizado = new Fornecedor { Nome = "Novo Nome", Email = "novoemail@example.com" };
        fornecedor.AtualizarFornecedor(fornecedorAtualizado);
        Assert.That(fornecedor.Nome, Is.EqualTo("Novo Nome"));
        Assert.That(fornecedor.Email, Is.EqualTo("novoemail@example.com"));
    }

    [Test]
    public async Task ObterFornecedor_ThrowServiceException_True()
    {
        int idFornecedor = 999;
        _fornecedorRepository.ObterFornecedor(idFornecedor).Returns(Task.FromResult<Fornecedor>(null));
        var exception = Assert.ThrowsAsync<ServiceException>(async () => await _fornecedorService.ObterFornecedor(idFornecedor));
        Assert.That(exception.Message, Is.EqualTo("Fornecedor não encontrado."));
    }

    [Test]
    public async Task ObterFornecedores_DeveRetornarListaDeFornecedores()
    {
        var fornecedores = new List<Fornecedor>
            {
                new Fornecedor { Id = 1, Nome = "Fornecedor 1", Email = "fornecedor1@example.com" },
                new Fornecedor { Id = 2, Nome = "Fornecedor 2", Email = "fornecedor2@example.com" }
            };
        _fornecedorRepository.ObterFornecedores().Returns(Task.FromResult<IEnumerable<Fornecedor>>(fornecedores));
        var result = await _fornecedorService.ObterFornecedores();
        Assert.That(result.Count(), Is.EqualTo(fornecedores.Count));
    }

    [Test]
    public async Task InserirFornecedor_DeveChamarMetodoInserir()
    {
        var fornecedor = new Fornecedor { Id = 1, Nome = "Novo Fornecedor", Email = "novo@example.com" };
        await _fornecedorService.InserirFornecedor(fornecedor);
        await _fornecedorRepository.Received(1).InserirFornecedor(fornecedor);
        Assert.Pass();
    }

    [Test]
    public async Task AtualizarFornecedor_DeveChamarMetodoAtualizar()
    {
        int idFornecedor = 1;
        var fornecedor = new Fornecedor { Id = 1, Nome = "Fornecedor Atualizado", Email = "atualizado@example.com" };
        _fornecedorRepository.ObterFornecedor(idFornecedor).Returns(Task.FromResult(fornecedor));
        await _fornecedorService.AtualizarFornecedor(idFornecedor, fornecedor);
        await _fornecedorRepository.Received(1).AtualizarFornecedor(idFornecedor, fornecedor);
        Assert.Pass();
    }

    [Test]
    public async Task DeletarFornecedor_DeveChamarMetodoDeletar()
    {
        int idFornecedor = 1;
        var fornecedor = new Fornecedor { Id = idFornecedor, Nome = "Fornecedor a Ser Deletado", Email = "delete@example.com" };
        _fornecedorRepository.ObterFornecedor(idFornecedor).Returns(Task.FromResult(fornecedor));
        await _fornecedorService.DeletarFornecedor(idFornecedor);
        await _fornecedorRepository.Received(1).DeletarFornecedor(idFornecedor);
    }
}
