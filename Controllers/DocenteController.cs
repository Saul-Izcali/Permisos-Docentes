using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Data;
using Proyecto.Models;
// using Proyecto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
// using System.Data;


namespace Proyecto.Controllers
{
    public class DocenteController : Controller
    {

        private BDContext context; // Instancia de la base de datos
        // public int nomina {get; set;}

        public DocenteController(BDContext _context)
        {
            context = _context;
        }

        public IActionResult Docente(int id)
        {
            
            var docente = context.Docente.Find(id);
            if(docente.Coordinador == true){
                // TempData["coordinador"] = "true";
                ViewBag.coordi = true;
            }

            ViewBag.listaPermisos = context.Permiso.ToList();
            ViewBag.id = id;


            // IEnumerable<Permiso> ListaPermisos = context.Permiso;
            return View("Docente");
        }

    }
}