using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Plantel
    {
        [Key]
        public int Id_Plantel { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public List<Docente> DocentesPlantel { get; set; }  //propiedad de navegacion hacia todos los docentes

        //No se si esta entidad necesita una propiedad de clave externa o de navegacion con docente, creo que no

    }
}


