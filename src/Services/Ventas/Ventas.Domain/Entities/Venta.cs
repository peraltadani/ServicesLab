using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Entities
{
    public class Venta
    {

        public Venta(DateTime fechaVenta, int clienteId, int estadoVentaId)
        {
            FechaVenta = fechaVenta;
            ClienteId = clienteId;
            EstadoVentaId = estadoVentaId;
        }

        public int VentaId { get; set; }

        public DateTime FechaVenta { get; set; }

        public int EstadoVentaId { get; set; }

        public int ClienteId { get; set; }

        public IEnumerable<DetalleVenta> Detalle { get; set; }

    }

}
