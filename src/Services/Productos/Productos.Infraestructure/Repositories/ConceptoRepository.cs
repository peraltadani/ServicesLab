using Productos.Domain.Abstractions;
using Productos.Domain.Entities;

namespace Productos.Infrastructure.Repositories;

public sealed class ConceptoRepository : IConceptoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ConceptoRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(Concepto concepto) => _dbContext.Set<Concepto>().Add(concepto);
}