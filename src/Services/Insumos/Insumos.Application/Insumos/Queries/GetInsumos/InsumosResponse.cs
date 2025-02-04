using System;

namespace Insumos.Application.Insumos.Queries.GetInsumos;

public sealed record InsumosResponse(int InsumoId, int? SubConceptoId, string Descripcion, int UnidadMedidaId, DateTime FechaAlta, DateTime? FechaBaja, decimal? Valuacion);