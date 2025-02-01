using System;
using Productos.Application.Abstractions.Messaging;

namespace Productos.Application.Conceptos.Queries.GetConceptoById;

public sealed record GetConcpetoByIdQuery(int ConceptoId) : IQuery<ConceptoResponse>;