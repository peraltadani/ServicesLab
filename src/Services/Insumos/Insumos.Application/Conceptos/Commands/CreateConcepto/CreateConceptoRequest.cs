using System;

namespace Insumos.Application.Conceptos.Commands.CreateConcepto;

public sealed record CreateConceptoRequest(string Descripcion, DateTime FechaAlta);