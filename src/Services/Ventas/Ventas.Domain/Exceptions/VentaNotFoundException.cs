using Ventas.Domain.Exceptions.Base;
using Ventas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Exceptions
{
    public sealed class VentaNotFoundException : NotFoundException
    {
        public VentaNotFoundException(int ventaId)
            : base($"The Venta with the identifier {ventaId} was not found.")
        {
        }
    }
}
