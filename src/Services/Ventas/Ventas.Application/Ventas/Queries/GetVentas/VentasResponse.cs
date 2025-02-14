using System;
using Ventas.Domain.Entities;

namespace Ventas.Application.Ventas.Queries.GetVentas;

public sealed record VentasResponse(int VentaId, DateTime FechaVenta, int ClienteId, int EstadoVentaId, IEnumerable<DetalleVenta> Detalle);