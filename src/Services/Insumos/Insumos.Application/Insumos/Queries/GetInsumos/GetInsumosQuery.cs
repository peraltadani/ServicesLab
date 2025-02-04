using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Insumos.Queries.GetInsumos;

public sealed record GetInsumosQuery() : IQuery<IEnumerable<InsumosResponse>>;