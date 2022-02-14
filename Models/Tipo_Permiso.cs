using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Tipo_Permiso
    {
        [Key]
        [Display(Name = "Id del permiso")]
        [Required(ErrorMessage = "El permiso es requerido")]
        public int ID_permiso {get; set;}

        [Display(Name = "Tipo del permiso")]
        [StringLength(50, ErrorMessage = "El permiso excede los caracteres")]
        public string Nombre {get; set;}


        public List<Permiso> Permisos {get; set;}  // Propiedad de navegacion con el permiso, un permiso solo puede tener un tipo de permiso a la vez
    }
}


