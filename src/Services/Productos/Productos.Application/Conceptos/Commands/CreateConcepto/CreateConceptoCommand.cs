using System;
using Productos.Application.Abstractions.Messaging;

namespace Productos.Application.Conceptos.Commands.CreateConcepto;

public sealed record CreateConceptoCommand(string Descripcion, DateTime FechaAlta) : ICommand<int>;