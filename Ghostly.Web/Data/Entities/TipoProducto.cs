using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data.Entities
{
    public class TipoProducto
    {
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Tipo de producto")] public string Nombre { get; set; }

        public ICollection <Producto> Productos { get; set; }
    }
}
