using System;

namespace Insumos.Application.Conceptos.Queries.GetConceptoById;

public sealed record ConceptoResponse(int ConceptoId, string Descripcion, DateTime FechaAlta);