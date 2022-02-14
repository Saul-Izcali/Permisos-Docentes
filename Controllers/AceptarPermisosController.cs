using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Data;
using Proyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
// using System.Data;


namespace Proyecto.Controllers
{
    public class AceptarPermisosController : Controller
    {

        private BDContext context; // Instancia de la base de datos

        public AceptarPermisosController(BDContext _context)
        {
            context = _context;
        }

        public IActionResult AceptarPermisos(int id)
        {
            ViewBag.id = id;
            ViewBag.listaDocentes = context.Docente.ToList();
            IEnumerable<Permiso> listaPermisos = context.Permiso;
            return View(listaPermisos);
        }

        [HttpGet]
        public IActionResult AceptarPermiso(int? id) // al aceptar cambia el estado a aceptado
        {
            Console.WriteLine("----------------------------------------------------" + id);
            if(id == 0){
                Console.WriteLine("id nulo");
                return NotFound();
            }

            var permiso = context.Permiso.Find(id);

            if(permiso == null){
                Console.WriteLine("Permiso no encontrado");
                return NotFound();
            }

            try{
                permiso.Valido = true;
                Console.WriteLine("Permiso valido");
                context.SaveChanges(); 
            }catch(DbUpdateException){
                Console.WriteLine("Ocurrio algun error al guardar el permiso");
            }

            return RedirectToAction("AceptarPermisos");
        }

        public IActionResult DenegarPermiso(int? id) // al denegar el permiso lo elimina de la bd
        {
            if(id == 0){
                Console.WriteLine("id nulo");
                return NotFound();
            }

            var permiso = context.Permiso.Find(id);

            if(permiso == null){
                Console.WriteLine("Permiso no encontrado");
                return NotFound();
            }

            try{
                context.Permiso.Remove(permiso);
                Console.WriteLine("Permiso Eliminado");
                context.SaveChanges(); 
            }catch(DbUpdateException){
                Console.WriteLine("Ocurrio algun error al eliminar el permiso");
            }

            return RedirectToAction("AceptarPermisos");
        }
    }
}