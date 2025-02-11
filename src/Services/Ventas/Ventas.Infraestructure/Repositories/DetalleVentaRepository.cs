using Ventas.Domain.Entities;
using Ventas.Domain.Abstractions;

namespace Ventas.Infraestructure.Repositories;

public sealed class DetalleVentaRepository : IDetalleVentaRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DetalleVentaRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(DetalleVenta detalleVenta) => _dbContext.Set<DetalleVenta>().Add(detalleVenta);
}