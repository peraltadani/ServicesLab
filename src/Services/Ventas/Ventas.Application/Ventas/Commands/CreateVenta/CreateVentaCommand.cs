using System;
using Ventas.Application.Abstractions.Messaging;
using Ventas.Domain.Entities;

namespace Ventas.Application.Ventas.Commands.CreateVenta;

public sealed record CreateVentaCommand(DateTime FechaVenta, int ClienteId, int EstadoVentaId, IEnumerable<DetalleVenta> Detalle) : ICommand<int>;