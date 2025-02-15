using Ventas.Application.Abstractions.Messaging;
using Ventas.Domain.Abstractions;
using Ventas.Domain.Entities;
namespace Ventas.Application.Ventas.Commands.CreateVenta;

internal sealed class CreateVentaCommandHandler : ICommandHandler<CreateVentaCommand, int>
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IDetalleVentaRepository _detalleVentaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVentaCommandHandler(IVentaRepository ventaRepository, IDetalleVentaRepository detalleVentaRepository, IUnitOfWork unitOfWork)
    {
        _ventaRepository = ventaRepository;
        _detalleVentaRepository = detalleVentaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateVentaCommand request, CancellationToken cancellationToken)
    {

        var venta = new Venta(request.FechaVenta, request.ClienteId, request.EstadoVentaId);
        
        using var transaction = _unitOfWork.BeginTransaction(cancellationToken);

        try
        {
            _ventaRepository.Insert(venta);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach(var detalle in request.Detalle)
            {
                detalle.VentaId = venta.VentaId;

                _detalleVentaRepository.Insert(detalle);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();

            throw;
        }     

        return venta.VentaId;
    }
}