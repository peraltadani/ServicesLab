using System;
using System.Threading;
using System.Threading.Tasks;
using Insumos.Application.Abstractions.Messaging;
using Insumos.Application.Insumos.Commands.CreateConcepto;
using Insumos.Domain.Abstractions;
using Insumos.Domain.Entities;

namespace Insumos.Application.Insumos.Commands.CreateInsumo;

internal sealed class CreateInsumoCommandHandler : ICommandHandler<CreateInsumoCommand, int>
{
    private readonly IInsumoRepository _insumoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInsumoCommandHandler(IInsumoRepository insumoRepository, IUnitOfWork unitOfWork)
    {
        _insumoRepository = insumoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateInsumoCommand request, CancellationToken cancellationToken)
    {
        var insumo = new Insumo(request.SubConceptoId, request.Descripcion, request.UnidadMedidaId, request.FechaAlta, request.Valuacion);

        _insumoRepository.Insert(insumo);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return insumo.InsumoId;
    }
}