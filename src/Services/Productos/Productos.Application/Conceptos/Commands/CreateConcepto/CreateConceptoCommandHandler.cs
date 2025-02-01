using System;
using System.Threading;
using System.Threading.Tasks;
using Productos.Application.Abstractions.Messaging;
using Productos.Application.Conceptos.Commands.CreateConcepto;
using Productos.Domain.Abstractions;
using Productos.Domain.Entities;

namespace Productos.Application.Conceptos.Commands.CreateWebinar;

internal sealed class CreateConceptoCommandHandler : ICommandHandler<CreateConceptoCommand, int>
{
    private readonly IConceptoRepository _conceptoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateConceptoCommandHandler(IConceptoRepository conceptoRepository, IUnitOfWork unitOfWork)
    {
        _conceptoRepository = conceptoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateConceptoCommand request, CancellationToken cancellationToken)
    {
        var concepto = new Concepto(request.Descripcion, request.FechaAlta);

        _conceptoRepository.Insert(concepto);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return concepto.ConceptoId;
    }
}