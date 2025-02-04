using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Conceptos.Queries.GetConceptoById;

public sealed record GetConcpetoByIdQuery(int ConceptoId) : IQuery<ConceptoResponse>;