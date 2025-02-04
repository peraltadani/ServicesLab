using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Insumos.Queries.GetInsumoById;

public sealed record GetInsumoByIdQuery(int InsumoId) : IQuery<InsumoResponse>;