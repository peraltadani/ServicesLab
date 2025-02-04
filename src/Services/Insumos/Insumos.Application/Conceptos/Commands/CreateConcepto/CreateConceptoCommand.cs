using System;
using Insumos.Application.Abstractions.Messaging;

namespace Insumos.Application.Conceptos.Commands.CreateConcepto;

public sealed record CreateConceptoCommand(string Descripcion, DateTime FechaAlta) : ICommand<int>;