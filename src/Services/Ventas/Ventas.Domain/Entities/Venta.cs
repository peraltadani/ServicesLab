using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime FechaVenta { get; set; }

        public int EstadoVentaId { get; set; }

        public int ClienteId { get; set; }

    }

}
