using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insumos.Domain.Entities
{
    public class Concepto
    {
        public Concepto(string descripcion, DateTime fechaAlta)
        {
            this.Descripcion = descripcion;
            this.FechaAlta = fechaAlta;
        }

        public int ConceptoId { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaAlta { get; set; }

    }
}
