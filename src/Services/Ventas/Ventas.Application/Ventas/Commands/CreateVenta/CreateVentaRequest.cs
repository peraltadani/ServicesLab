using System;
using Ventas.Domain.Entities;

namespace Ventas.Application.Ventas.Commands.CreateVenta;

public sealed record CreateVentaRequest(DateTime FechaVenta, int ClienteId, int EstadoVentaId, IEnumerable<DetalleVenta> Detalle);