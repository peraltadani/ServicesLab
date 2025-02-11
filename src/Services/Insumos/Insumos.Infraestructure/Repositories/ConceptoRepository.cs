using Insumos.Domain.Abstractions;
using Insumos.Domain.Entities;

namespace Insumos.Infraestructure.Repositories;

public sealed class ConceptoRepository : IConceptoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ConceptoRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(Concepto concepto) => _dbContext.Set<Concepto>().Add(concepto);
}