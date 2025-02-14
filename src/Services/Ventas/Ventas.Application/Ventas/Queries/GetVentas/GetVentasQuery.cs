using System;
using Ventas.Application.Abstractions.Messaging;

namespace Ventas.Application.Ventas.Queries.GetVentas;

public sealed record GetVentasQuery() : IQuery<IEnumerable<VentasResponse>>;