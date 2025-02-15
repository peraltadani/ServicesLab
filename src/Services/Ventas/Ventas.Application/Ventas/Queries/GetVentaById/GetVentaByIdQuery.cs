using System;
using Ventas.Application.Abstractions.Messaging;

namespace Ventas.Application.Ventas.Queries.GetVentaById;

public sealed record GetVentaByIdQuery(int VentaId) : IQuery<VentaResponse>;