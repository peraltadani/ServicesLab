using FluentValidation;

namespace Insumos.Application.Conceptos.Commands.CreateConcepto;

public sealed class CreateConceptoCommandValidator : AbstractValidator<CreateConceptoCommand>
{
    public CreateConceptoCommandValidator()
    {
        RuleFor(x => x.Descripcion).NotEmpty();

        RuleFor(x => x.FechaAlta).NotEmpty();
    }
}