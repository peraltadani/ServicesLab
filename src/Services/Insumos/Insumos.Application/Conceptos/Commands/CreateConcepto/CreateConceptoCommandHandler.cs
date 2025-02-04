using Insumos.Application.Abstractions.Messaging;
using Insumos.Domain.Abstractions;
using Insumos.Domain.Entities;

namespace Insumos.Application.Conceptos.Commands.CreateConcepto;

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