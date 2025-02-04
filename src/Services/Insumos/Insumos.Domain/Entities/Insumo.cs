using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insumos.Domain.Entities
{
    public class Insumo
    {
        public Insumo(int? subConceptoId, string descripcion, int unidadMedidaId, DateTime fechaAlta, decimal? valuacion)
        {
            SubConceptoId = subConceptoId;
            Descripcion = descripcion;
            UnidadMedidaId = unidadMedidaId;
            FechaAlta = fechaAlta;
            Valuacion = valuacion;
        }

        public int InsumoId { get; set; }

        public int? SubConceptoId { get; set; }

        public string Descripcion { get; set; }

        public int UnidadMedidaId { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public decimal? Valuacion { get; set; }

    }
}
