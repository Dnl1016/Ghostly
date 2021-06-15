using Ghostly.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<ImageProducto> imageProductos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
