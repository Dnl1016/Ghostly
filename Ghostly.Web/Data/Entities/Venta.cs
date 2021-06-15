using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        [Display(Name = "Valor total")]
        [Required(ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Fecha Venta")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        public string Comentario { get; set; }

        [Display(Name = "Fecha Venta")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocal => EndDate.ToLocalTime();

        public Producto Productos { get; set; }
        public Cliente Clientes { get; set; }

        public User User { get; set; }
    }
}
