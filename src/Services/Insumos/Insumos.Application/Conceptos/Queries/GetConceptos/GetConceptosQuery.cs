using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Conceptos.Queries.GetConceptos;

public sealed record GetConcpetosQuery() : IQuery<IEnumerable<ConceptosResponse>>;