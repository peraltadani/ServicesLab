using System;

namespace Productos.Domain.Exceptions.Base;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
        : base(message)
    {
    }
}