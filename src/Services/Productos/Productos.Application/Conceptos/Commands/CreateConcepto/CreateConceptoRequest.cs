using System;

namespace Productos.Application.Conceptos.Commands.CreateConcepto;

public sealed record CreateConceptoRequest(string Descripcion, DateTime FechaAlta);