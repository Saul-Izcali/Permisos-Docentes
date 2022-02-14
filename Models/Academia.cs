using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Academia
    {
        [Key]
        public int Id_Academia { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public List<Docente> DocentesAcademia { get; set; }  //propiedad de navegacion hacia todos los docentes
        
    }
}





