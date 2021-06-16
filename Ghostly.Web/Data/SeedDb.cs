using Ghostly.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoProductosAsync();
            await CheckUsersAsync();
            await CheckClientesAsync();
            await CheckProductosAsync();

        }
        private async Task CheckTipoProductosAsync()
        {
            if (!_context.TipoProductos.Any())
            {
                _context.TipoProductos.Add(new Entities.TipoProducto { Nombre = "Chaqueta" });
                _context.TipoProductos.Add(new Entities.TipoProducto { Nombre = "Camiseta" });
                _context.TipoProductos.Add(new Entities.TipoProducto { Nombre = "Accesorio" });
                _context.TipoProductos.Add(new Entities.TipoProducto { Nombre = "Short" });
                _context.TipoProductos.Add(new Entities.TipoProducto { Nombre = "Faldas" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                AddUser("8989898", "Juan", "Zuluaga", "310 325 3221", "Calle Luna Calle Sol");
                AddUser("7655544", "Jose", "Cardona", "300 327 3221", "Calle 77 #22 21");
                AddUser("6565555", "Maria", "López", "350 329 3221", "Carrera 56 #22 21");
                await _context.SaveChangesAsync();
            }
        }

        private void AddUser(
            string document,
            string firstName,
            string lastName,
            string cellPhone,
            string address)
        {
            _context.Users.Add(new User
            {
                Address = address,
                Cellphone = cellPhone,
                Document = document,
                FirstName = firstName,
                LastName = lastName
            });
        }

        private async Task CheckClientesAsync()
        {
            if (!_context.Clientes.Any())
            {
                AddCliente("876543", "Ramon", "Gamboa", "310 322 3221", "RamonGam@gmail.com", "Calle Luna Calle Sol");
                AddCliente("654565", "Julian", "Martinez", "300 322 3221", "tinezjuli9@gmail.com", "Calle 77 #22 21");
                AddCliente("214231", "Carmenza", "Ruiz", "350 322 3221", "MenzaRuiz132@gmail.com", "Carrera 56 #22 21");
                await _context.SaveChangesAsync();
            }
        }

        private void AddCliente(string document, string firstName, string lastName, string cellPhone, string email, string address)
        {
            _context.Clientes.Add(new Cliente
            {
                Address = address,
                Cellphone = cellPhone,
                Document = document,
                FirstName = firstName,
                Email = email,
                LastName = lastName
            });
        }
        private async Task CheckProductosAsync()
        {
            var user = _context.Users.FirstOrDefault();
            var tipoProducto = _context.TipoProductos.FirstOrDefault();
            if (!_context.Productos.Any())
            {
                AddProducto("Clasic manga corta", 25000M,10, DateTime.Today, "Negro", "XL", "Hombre", true,user, tipoProducto);
                AddProducto("Sorner cuadros", 55000M, 15, DateTime.Today, "blanca", "L", "Hombre", true, user, tipoProducto);
                await _context.SaveChangesAsync();
            }
        }
        private void AddProducto(
            string nombre,
            decimal precio,
            int cantidad,
            DateTime startDate,
            string color,
            string talla,
            string categoria,
            bool estado,
            User user,
            TipoProducto tipoProducto
            )
        {
            _context.Productos.Add(new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad,
                StartDate = DateTime.Today,
                Color = color,
                Talla = talla,
                Categoria = categoria,
                Estado = true,
                User = user,
                TipoProducto = tipoProducto

            });
        }
    }
}

    