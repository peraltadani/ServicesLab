using Productos.Domain.Exceptions.Base;
using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Domain.Exceptions
{
    public sealed class ConceptoNotFoundException : NotFoundException
    {
        public ConceptoNotFoundException(int conceptoId)
            : base($"The Concepto with the identifier {conceptoId} was not found.")
        {
        }
    }
}
