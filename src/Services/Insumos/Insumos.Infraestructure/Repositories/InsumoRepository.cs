using Insumos.Domain.Abstractions;
using Insumos.Domain.Entities;

namespace Insumos.Infraestructure.Repositories;

public sealed class InsumoRepository : IInsumoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InsumoRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(Insumo insumo) => _dbContext.Set<Insumo>().Add(insumo);
}