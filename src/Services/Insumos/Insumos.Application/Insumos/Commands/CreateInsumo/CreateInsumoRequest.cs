namespace Insumos.Application.Insumos.Commands.CreateConcepto;

public sealed record CreateInsumoRequest(int? SubConceptoId, string Descripcion, int UnidadMedidaId, DateTime FechaAlta, decimal? Valuacion);