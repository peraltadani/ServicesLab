using System;
using Ventas.Domain.Entities;

namespace Ventas.Application.Ventas.Queries.GetVentaById;

public sealed record VentaResponse(int VentaId, DateTime FechaVenta, int ClienteId, int EstadoVentaId, IEnumerable<DetalleVenta> Detalle);