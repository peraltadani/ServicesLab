using System;

namespace Insumos.Application.Conceptos.Queries.GetConceptos;

public sealed record ConceptosResponse(int ConceptoId, string Descripcion, DateTime FechaAlta);