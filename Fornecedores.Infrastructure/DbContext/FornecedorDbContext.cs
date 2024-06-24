using Fornecedores.Model;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores.Infrastructure.DbContext;

public class FornecedorDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public FornecedorDbContext(DbContextOptions<FornecedorDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fornecedor>()
            .HasKey(x => x.Id);
    }

    public DbSet<Fornecedor> Fornecedores { get; set; }
}
