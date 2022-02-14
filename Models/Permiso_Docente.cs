using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Models
{
    public class Permiso_Docente
    {

        [Key]
        public int Numero {get; set;}

        public int Permiso {get; set;}  // FK
        public Permiso permisoDocente {get; set;}
        public int Docente {get; set;}  // FK
        public Docente docentePermiso {get; set;}


    }


}