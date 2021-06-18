using Ghostly.Web.Data.Entities;
using Ghostly.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
    

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var administrador = await CheckUsuarioAsync("1010", "Daniel", "David", "daniel.dd1016@gmail.com", "350 634 2748", "Calle Luna Calle Sol", "Administrador");
            var cliente = await CheckUsuarioAsync("2020", "Daniel", "Sucerquia", "Daniel.10_16@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", "Cliente");
            await CheckTipoProductosAsync();
            await CheckAdministradorAsync(administrador);
            await CheckClientesAsync(cliente);
            await CheckProductosAsync();
            await CheckVentasAsync();
        }

        private async Task CheckVentasAsync()
        {
            var cliente = _context.Clientes.FirstOrDefault();
            var producto = _context.Productos.FirstOrDefault();
            if (!_context.Ventas.Any())
            {
                _context.Ventas.Add(new Venta
                {
                    ValorTotal = 800000M,
                    EndDate = DateTime.Today.AddYears(1),
                    Estado = true,
                    Clientes =cliente,
                    Productos =producto,
                    Comentario = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris nec iaculis ex. Nullam gravida nunc eleifend, placerat tellus a, eleifend metus. Phasellus id suscipit magna. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam volutpat ultrices ex, sed cursus sem tincidunt ut. Nullam metus lorem, convallis quis dignissim quis, porttitor quis leo. In hac habitasse platea dictumst. Duis pharetra sed arcu ac viverra. Proin dapibus lobortis commodo. Vivamus non commodo est, ac vehicula augue. Nam enim felis, rutrum in tortor sit amet, efficitur hendrerit augue. Cras pellentesque nisl eu maximus tempor. Curabitur eu efficitur metus. Sed ultricies urna et auctor commodo."
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAdministradorAsync(Usuario usuario)
        {
            if (!_context.Administradores.Any())
            {
                _context.Administradores.Add(new Administrador { Usuario = usuario });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<Usuario> CheckUsuarioAsync(string document, 
            string firstName, 
            string lastName, 
            string email, 
            string phone, 
            string address, 
            string role)
        {
            var usuario = await _userHelper.GetUserByEmailAsync(email);
            if (usuario == null)
            {
                usuario = new Usuario
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(usuario, "123456");
                await _userHelper.AddUserToRoleAsync(usuario, role);
            }

            return usuario;
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Administrador");
            await _userHelper.CheckRoleAsync("Cliente");
        }

        private async Task CheckClientesAsync(Usuario usuario)
        {
            if (!_context.Clientes.Any())
            {
                _context.Clientes.Add(new Cliente { Usuario = usuario });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProductosAsync()
        {
 
            var TipoProducto = _context.TipoProductos.FirstOrDefault();
            if (!_context.Productos.Any())
            {
                AddProducto("Clasic manga corta", 25000M, 10, DateTime.Today, "Negro", "XL", "Hombre", true,  TipoProducto);
                AddProducto("Sorner cuadros", 55000M, 15, DateTime.Today, "blanca", "L", "Hombre", true,  TipoProducto);
                await _context.SaveChangesAsync();
            }
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

        private void AddProducto(
           string nombre,
           decimal precio,
           int cantidad,
           DateTime startDate,
           string color,
           string talla,
           string categoria,
           bool estado,
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
                TipoProducto = tipoProducto

            });
        }
    }
}
