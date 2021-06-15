using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ghostly.Web.Data.Entities
{
    public class ImageProducto
    {
        public int Id { get; set; }

        [Display(Name = "Imagen del producto")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";

        public Producto Producto { get; set; }

    }
}
