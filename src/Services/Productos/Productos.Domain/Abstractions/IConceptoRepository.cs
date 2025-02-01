using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Domain.Abstractions
{
    public interface IConceptoRepository
    {
        void Insert(Concepto concepto);
    }
}
