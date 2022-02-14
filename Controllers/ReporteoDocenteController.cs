using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Proyecto.Data;

namespace Proyecto.Controllers
{
    public class ReporteoDocenteController : Controller
    {

        private BDContext context; // instania de la base de datos

        public ReporteoDocenteController(BDContext _context){
            context = _context;
        }

        public IActionResult ReporteoDocente(int id)
        {   
            ViewBag.id = id;
            int dosHoras = 0, economico = 0, cumpleaños = 0;

            foreach (var item in context.Permiso)
            {
                if(item.Id_Docente == id){
                    switch(item.Id_Tipo){
                        case 1: dosHoras++; break;
                        case 2: economico++; break;
                        case 3: cumpleaños++; break;
                    }
                }
            }

            ViewBag.doshoras = dosHoras;
            ViewBag.economico = economico;
            ViewBag.cumpleaños = cumpleaños;

            return View();
        }



    }
}
