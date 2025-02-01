using System;

namespace Productos.Application.Conceptos.Queries.GetConceptoById;

public sealed record ConceptoResponse(int ConceptoId, string Descripcion, DateTime FechaAlta);