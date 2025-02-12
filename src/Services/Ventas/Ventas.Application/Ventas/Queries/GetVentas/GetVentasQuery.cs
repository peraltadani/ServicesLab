using System;
using Ventas.Application.Abstractions.Messaging;

namespace Ventas.Application.Ventas.Queries.GetConceptos;

public sealed record GetVentasQuery() : IQuery<IEnumerable<VentasResponse>>;