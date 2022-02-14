using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Permiso
    {
        [Key]
        [Required]
        public int Id_Permiso { get; set; }

        public bool Valido { get; set; }
        // public bool Estado { get; set; }
        public string Horario {get; set;}

        [Required(ErrorMessage = "La Fecha de inicio es requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Inicio { get; set; }

        [Required(ErrorMessage = "La Fecha de Termino es requerida")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Termino { get; set; }

        public string Motivo {get; set;}


        // public Permiso_Docente permisoDocente { get; set; }    //Propiedad de navegacion, un permiso tiene un docente
        public int Id_Docente {get; set;}    //llave foranea
        public Docente Docente { get; set; }    //Propiedad de navegacion, un permiso tiene un docente


        [Required(ErrorMessage = "El tipo es requerido")]
        public int Id_Tipo {get; set;}           //llave foranea
        public Tipo_Permiso Tipo { get; set; }  //Propiedad de navegacion, un perimiso tiene un docente

    }
}


