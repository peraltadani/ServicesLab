﻿using Ventas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.Abstractions
{
    public interface IVentaRepository
    {
        void Insert(Venta venta);
    }
}
