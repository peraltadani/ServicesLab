using System;
using Productos.Application.Abstractions.Messaging;

namespace Productos.Application.Conceptos.Queries.GetConceptos;

public sealed record GetConcpetosQuery() : IQuery<IEnumerable<ConceptosResponse>>;