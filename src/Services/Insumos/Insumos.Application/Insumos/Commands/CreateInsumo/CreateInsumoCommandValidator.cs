using FluentValidation;

namespace Insumos.Application.Insumos.Commands.CreateInsumo;

public sealed class CreateInsumosValidator : AbstractValidator<CreateInsumoCommand>
{
    public CreateInsumosValidator()
    {
        RuleFor(x => x.UnidadMedidaId).NotEmpty();

        RuleFor(x => x.Descripcion).NotEmpty();

        RuleFor(x => x.FechaAlta).NotEmpty();
    }
}