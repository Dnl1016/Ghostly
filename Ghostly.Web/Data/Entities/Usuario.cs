using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ghostly.Web.Data.Entities
{
    public class Usuario : IdentityUser
    {
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Documento")] public string Document { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Nombre")] public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Apellido")] public string LastName { get; set; }
        [Display(Name = "Direccion")] public string Address { get; set; }

        [Display(Name = "Nombre Cliente")] public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Documento Cliente")] public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
