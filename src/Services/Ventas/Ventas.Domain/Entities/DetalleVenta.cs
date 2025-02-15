using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Entities
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }

        public int VentaId { get; set; }

        public int InsumoId { get; set; }

        public decimal Cantidad { get; set; } 

    }
}
