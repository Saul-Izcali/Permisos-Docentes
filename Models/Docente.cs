using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Docente
    {
        [Key] // establece a nomina como nuestra PK
        // [Required(ErrorMessage = "La nomina es requerida")] // no permite null, ejemplo un text sin nada
        [Range(0001, 9999, ErrorMessage = "La nomina no cumple la cantidad de digitos")] // fuera de ese rango es invalido
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  //significa que es proporcionado por el usuario
        public int Nomina { get; set; }

        [Display(Name = "Nombre")] // si por ejemplo se pone en un label este atributo va decir "Nombre"
        [StringLength(40, ErrorMessage = "El nombre excede los caracteres")]
        // [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(40, ErrorMessage = "El apellido excede los caracteres")]
        // [Required(ErrorMessage = "El Apellido es requerido")]
        public string Apellido_Paterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(40, ErrorMessage = "El apellido excede los caracteres")]
        // [Required(ErrorMessage = "El Apellido es requerido")]
        public string Apellido_Materno { get; set; }

        [DataType(DataType.Date)] // Especifica que no nos interesa la hora, solo la fecha
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] //formato para ingresar la fecha
        // [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime Fecha_Nacimiento { get; set; }

        public bool Coordinador { get; set; }

        [Display(Name = "Contraseña")]
        [StringLength(40, ErrorMessage = "La contraseña excede los caracteres")]
        // [Required(ErrorMessage = "La contraseña es requerida")]
        public string Contraseña {get; set;}

        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] 
        public DateTime Fecha_Ingreso {get; set;}


        // // Como un docente solo puede tener una academia, un plantel y una cuenta son una sola entidad y no una coleccion
        public Academia Academia { get; set; }  //propiedad de navegacion 

        // [Required(ErrorMessage = "La Academia es requerida")]
        public int Id_Academia {get; set;}   // llave foranea 
        

        public Plantel Plantel { get; set; }    //propiedad de navegacion 
    
        // [Required(ErrorMessage = "El plantel es requerido")]
        public int Id_Plantel {get; set;}   // llave foranea 


        public List<Permiso> PermisosDocente { get; set; } //propiedad de navegacion con los permisos
        // public Permiso_Docente docentePermiso { get; set; } //propiedad de navegacion con permiso_docente
        // Un docenete puede tener varios permisos, por eso es una lista
    }
}


