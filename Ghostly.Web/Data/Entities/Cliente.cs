﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
