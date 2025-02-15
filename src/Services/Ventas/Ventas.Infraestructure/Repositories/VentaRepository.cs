using Ventas.Domain.Abstractions;
using Ventas.Domain.Entities;

namespace Ventas.Infraestructure.Repositories;

public sealed class VentaRepository : IVentaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VentaRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(Venta venta) => _dbContext.Set<Venta>().Add(venta);
}