using Insumos.Domain.Exceptions.Base;
using Insumos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insumos.Domain.Exceptions
{
    public sealed class InsumoNotFoundException : NotFoundException
    {
        public InsumoNotFoundException(int insumoId)
            : base($"The Concepto with the identifier {insumoId} was not found.")
        {
        }
    }
}
