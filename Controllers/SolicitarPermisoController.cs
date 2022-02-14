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


namespace Proyecto.Controllers
{
    public class SolicitarPermisoController : Controller
    {

        private BDContext context; // Instancia de la base de datos

        public SolicitarPermisoController(BDContext _context)
        {
            context = _context;
        }

        public IActionResult SolicitarInicio(int id){

            ViewBag.id = id;
            TempData["PermisoValido"] = null;
            return View("SolicitarPermiso");
        }

 
        [HttpPost]
        public IActionResult SolicitarPermiso(Permiso permiso, string tipoPermiso, int id, string horario){
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(Int32.Parse(tipoPermiso));
            Console.WriteLine("------------------------------------------");
            
            var docente = context.Docente.Find(id);

            if(Int32.Parse(tipoPermiso) != 1){
                permiso.Horario = "Todo el dia";
            }else{
                permiso.Horario = horario;
            }

            var Permiso = new Permiso{
                Id_Docente = id,
                Valido = false,
                Id_Tipo = Int32.Parse(tipoPermiso),
                Inicio = permiso.Inicio,
                Termino = permiso.Termino,
                Horario = permiso.Horario
            };

            try{
                if(ModelState.IsValid){

                    // Antes de la fecha actual, para todos
                    if(Permiso.Inicio < DateTime.Today){ 
                        Console.WriteLine("Ya paso la fecha solicitada");
                        TempData["error"] = "Ya paso la fecha solicitada";
                        return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                    }

// -------------------- ECONOMICO
                    if(Permiso.Id_Tipo == 2){ 
                        if(Permiso.Inicio < DateTime.Today.AddDays(2)){ //minimo 2 dias de anticipacion
                            Console.WriteLine("No hay suficiente anticipacion");
                            TempData["error"] = "No hay suficiente anticipacion";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }
                        // Que no estén comprendidos en los cinco días hábiles anteriores o posteriores al periodo de vacaciones 
                        if(Permiso.Inicio < DateTime.Parse("2021-06-25") && Permiso.Inicio > DateTime.Parse("2021-06-20") ||
                            Permiso.Inicio < DateTime.Parse("2021-08-13") && Permiso.Inicio > DateTime.Parse("2021-08-09")){
                            Console.WriteLine("Se encuentra muy cerca del periodo vacacional");
                            TempData["error"] = "Se encuentra muy cerca del periodo vacacional";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }

                        // No pueden ser mas de 3 dias consecutivos
                        if((Permiso.Termino.DayOfYear - Permiso.Inicio.DayOfYear) > 3){
                            Console.WriteLine("No se puede solicitar 3 permisos consecutivos de este tipo");
                            TempData["error"] = "No se puede solicitar 3 permisos consecutivos de este tipo";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }


                        // tendran que estar separados cuanto menos por 1 mes
                        foreach(var p in context.Permiso){
                            if(p.Id_Docente == id){
                                if(p.Id_Tipo == 2){
                                        var mes = p.Termino.Month;
                                        if(mes == Permiso.Inicio.Month){
                                            Console.WriteLine("No se puede solicitar mas de 1 serie de estos permisos al mes");
                                            TempData["error"] = "No se puede solicitar mas de 1 serie de estos permisos al mes";
                                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                        }
                                }
                            }
                        }

                        // Que no estén comprendidos un día antes o después de suspensión programada por sucesión de días inhábiles
                        // el calendario del ceti no dice


                        var cont = 0;
                        // maximo 9 de estos permisos por año
                        foreach(var p in context.Permiso){
                            if(p.Id_Docente == id){
                                if(p.Id_Tipo == 2){
                                        cont = p.Termino.DayOfYear - p.Inicio.DayOfYear;
                                        if(cont >= 9){
                                            Console.WriteLine("No se puede solicitar mas de 9 permisos economicos al año");
                                            TempData["error"] = "No se puede solicitar mas de 9 permisos economicos al año";
                                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                        }
                                }
                            }
                        }

                        // no se pueden acomular con otros permisos
                        foreach(var p in context.Permiso){
                            if(p.Id_Docente == id){
                                if( (Permiso.Inicio.DayOfYear - p.Inicio.DayOfYear) < 1 || (Permiso.Termino.DayOfYear - p.Termino.DayOfYear) < 1){
                                    Console.WriteLine("No se puede acumular con otros permisos");
                                    TempData["error"] = "No se puede acumular con otros permisos";
                                    return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                }
                            }
                        }

                    }

// -------------------- CUMPLEAÑOS
                    if(Permiso.Id_Tipo == 3){
                        // solo uno por año
                        foreach(var p in context.Permiso){
                            if(p.Id_Docente == id){
                                if(p.Id_Tipo == 3){
                                    if(p.Valido == true){
                                        Console.WriteLine("Solo puede ser 1 por año de este tipo de permiso");
                                        TempData["error"] = "Solo puede ser 1 por año de este tipo de permiso";
                                        return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                    }
                                }
                            }
                        }
                        //tambien debe ser el mismo dia
                        if(DateTime.Compare(Permiso.Inicio, Permiso.Termino )!= 0){ // deben ser el mismo dia
                            Console.WriteLine("El permiso debe tener fechas iguales");
                            TempData["error"] = "El permiso debe tener fechas iguales";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }
                        // el dia debe estar maximo 6 meses despues de su cumpleaños
                        var fechaNacimiento = docente.Fecha_Nacimiento;
                        if(permiso.Inicio < fechaNacimiento){
                            Console.WriteLine("El permiso debe ser solicitado despues del cumpleaños");
                            TempData["error"] = "El permiso debe ser solicitado despues del cumpleaños";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }else{
                            if( (permiso.Inicio.DayOfYear - fechaNacimiento.DayOfYear) > 183 ){
                                Console.WriteLine(permiso.Inicio.DayOfYear - fechaNacimiento.DayOfYear);
                                Console.WriteLine("El permiso debe ser maximo 6 meses despues del cumpleaños");
                                TempData["error"] = "El permiso debe ser maximo 6 meses despues del cumpleaños";
                                return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                            }
                        }

                    }

// -------------------- 2 HORAS
                    if(Permiso.Id_Tipo == 1){
                        if(DateTime.Compare(Permiso.Inicio, Permiso.Termino )!= 0){ // deben ser el mismo dia
                            Console.WriteLine("El permiso debe tener fechas iguales");
                            TempData["error"] = "El permiso debe tener fechas iguales";
                            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                        }
                        // especificar si es en la mañana o en la tarde       -----      cumplido

                        // maximo 2 permisos cada 15 dias
                        var cont1 = 0;
                        var cont2 = 0;
                        foreach (var item in context.Permiso)  // recorre toda la tabla permisos
                        {
                            if(item.Id_Docente == id){  // entra si el id de un docente en un permiso coincide con el docente que estamos trabajando
                                if(Permiso.Inicio.Month == item.Inicio.Month){  //si el permiso solicitado y el permiso que se recorre son del mismo mes
                                    if(Permiso.Inicio.Day < 15){ // si el permiso solicitado esta dentro de la primera o segunda quincena
                                        if(item.Inicio.Day < 15){ // si el permiso recorrido esta dentro de la primera quincena
                                            cont1++; // aumenta contador
                                            if(cont1 >= 2){
                                                Console.WriteLine("No se pueden solicitar mas de 2 permisos de 2 horas en menos de 15 dias");
                                                TempData["error"] = "El permiso debe tener fechas iguales";
                                                return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                            }
                                        }
                                    }else{
                                        if(item.Inicio.Day > 15){
                                            cont2++;
                                            if(cont2 >= 2){
                                                Console.WriteLine("No se pueden solicitar mas de 2 permisos de 2 horas en menos de 15 dias");
                                                TempData["error"] = "El permiso debe tener fechas iguales";
                                                return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
                                            }
                                        }
                                    }
                                }
                            }
                        }



                        // especificar motivo
                        
                    }

                    context.Permiso.Add(Permiso);
                    context.SaveChanges();
                    Console.WriteLine("Permiso guardado");

                    TempData["PermisoValido"] = "El permiso fue realizado";

                    return RedirectToAction("Docente", "Docente", new {id = id});
                }
            }catch(DbUpdateException){
                Console.WriteLine("Ocurrio un error al guardar el permiso");
            }

            return RedirectToAction("SolicitarInicio", "SolicitarPermiso", new {id = id});
        }

    }
}