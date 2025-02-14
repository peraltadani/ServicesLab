using FluentValidation;
using Ventas.Application.Ventas.Commands.CreateVenta;

namespace Ventas.Application.Ventas.Commands.CreateConcepto;

public sealed class CreateVentaCommandValidator : AbstractValidator<CreateVentaCommand>
{
    public CreateVentaCommandValidator()
    {
        RuleFor(x => x.FechaVenta).NotEmpty();

        RuleFor(x => x.ClienteId).NotEmpty();

        RuleFor(x => x.EstadoVentaId).NotEmpty();   
    }
}