using Insumos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insumos.Domain.Abstractions
{
    public interface IInsumoRepository
    {
        void Insert(Insumo insumo);
    }
}
