
using Fornecedores.Infrastructure.DbContext;
using Fornecedores.Model.Models;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Moq;

namespace Fornecedores.Tests.Setup;
public static class FornecedorDbContextMock
{
    public static FornecedorDbContext Create()
    {
        var options = new DbContextOptionsBuilder<FornecedorDbContext>()
            .UseInMemoryDatabase(databaseName: "FornecedoresDB")
            .Options;

        var dbContext = new FornecedorDbContext(options);
        var fakeFornecedores = GetFakeFornecedores().AsQueryable();

        var fornecedoresDbSet = CreateMockDbSet(fakeFornecedores);
        dbContext.Fornecedores = fornecedoresDbSet.Object;

        return dbContext;
    }

    private static Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockDbSet = new Mock<DbSet<T>>();
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        return mockDbSet;
    }

    private static List<Fornecedor> GetFakeFornecedores()
    {
        return new List<Fornecedor>
            {
                new Fornecedor { Id = 1, Nome = "Fornecedor 1", Email = "fornecedor1@example.com" },
                new Fornecedor { Id = 2, Nome = "Fornecedor 2", Email = "fornecedor2@example.com" },
                new Fornecedor { Id = 3, Nome = "Fornecedor 3", Email = "fornecedor3@example.com" }
            };
    }
}
