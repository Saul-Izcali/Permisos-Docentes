using System;
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
    public class HomeController : Controller
    {

        private BDContext context; // instania de la base de datos

        public HomeController(BDContext _context){
            context = _context;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Ingresar(string usuario, string password){
            foreach(var maestro in context.Docente){
                if(usuario == maestro.Nomina.ToString() && password == maestro.Contraseña.ToString()){
                        return RedirectToAction("Docente", "Docente", new {id = maestro.Nomina});
                }
            } 

            return RedirectToAction("Login");
        }


    }
}
