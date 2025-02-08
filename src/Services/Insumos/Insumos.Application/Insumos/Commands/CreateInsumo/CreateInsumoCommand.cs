using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Insumos.Commands.CreateInsumo;

public sealed record CreateInsumoCommand(int? SubConceptoId, string Descripcion, int UnidadMedidaId, DateTime FechaAlta, decimal? UltimoPrecioCompra) : ICommand<int>;