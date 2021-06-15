using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Nombre del producto")] public string Nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [Display(Name = "Fecha de creacion")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }



        [Display(Name = "Cantidad del producto")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public int Cantidad { get; set; }

        [Display(Name = "Fecha de creacion")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Color { get; set; }

        [Display(Name = "Talla")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Talla { get; set; }

        [Display(Name = "Categoria del producto")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string Categoria { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }


        [Display(Name = "Fecha de creacion")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public TipoProducto TipoProducto { get; set; }

        public User User { get; set; }

        public ICollection<ImageProducto> ImageProductos { get; set; }
        
        public ICollection<Venta> Ventas  { get; set; }
    }
}
