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

        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Documento")] public string Document { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Nombre")] public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        [Display(Name = "Apellido")] public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Display(Name = "Telefono")] public string Cellphone { get; set; }
        [Display(Name = "Correo Electronico")] public string Email { get; set; }
        [Display(Name = "Direccion")] public string Address { get; set; }
        [Display(Name = "Nombre Cliente")] public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Documento Cliente")] public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Venta> Ventas { get; set; }
    }
}