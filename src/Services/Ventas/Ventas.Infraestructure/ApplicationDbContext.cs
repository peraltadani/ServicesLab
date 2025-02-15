using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Ventas.Domain.Abstractions;

namespace Ventas.Infraestructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public IDbTransaction BeginTransaction(CancellationToken cancellationToken = default)
    {
        var transaction = Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
}