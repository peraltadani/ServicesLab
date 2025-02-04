using System;

namespace Insumos.Application.Insumos.Queries.GetInsumoById;

public sealed record InsumoResponse(int InsumoId, int? SubConceptoId, string Descripcion, int UnidadMedidaId, DateTime FechaAlta, DateTime? FechaBaja, decimal? Valuacion);