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
    public class ReporteoController : Controller
    {

        private BDContext context; // instania de la base de datos

        public ReporteoController(BDContext _context){
            context = _context;
        }

        public IActionResult Reporteo(int id)
        {   
            var dosHoras = 0;
            var economico = 0;
            var cumpleaños = 0;
            var docente = context.Docente.Find(id);

            DataTable datos = new DataTable();

            datos.Columns.Add(new DataColumn("Docentes", typeof(string)));
            datos.Columns.Add(new DataColumn("2 horas", typeof(string)));
            datos.Columns.Add(new DataColumn("Economicos", typeof(string)));
            datos.Columns.Add(new DataColumn("Cumpleaños", typeof(string)));

            // 1.- Recorrer todo la tabla permisos buscando los permisos que tienen un id_docente y este
            //      tiene el mismo plantel que el coordinador actual
            // 2.- Si coincide ir contando cada tipo de permiso
            // 3.- Al final agregar la fila de este docente a la dataTable

            foreach (var i in context.Docente) // recorre toda la tabla docente
            {
                foreach (var item in context.Permiso) // recorre toda la tabla permiso
                {
                Console.WriteLine(i.Nomina + "   " + i.Id_Academia + " | " + docente.Id_Academia);
                Console.WriteLine(i.Id_Academia == docente.Id_Academia);
                        // if(i.Id_Plantel == docente.Id_Plantel){ // si el docente del permiso y el coordinador son del mismo plantel
                        // Console.WriteLine(i.Id_Plantel + "  " + i.Nomina);
                            // if(i.Id_Academia == docente.Id_Academia){
                                // Console.WriteLine(i.Id_Academia + "  " + i.Nomina);
                                if(item.Id_Docente == i.Nomina) // ve cuando el id_Docente del permiso coincide con la nomia
                                {
                                    switch(item.Id_Tipo){
                                    case 1: dosHoras++; break;
                                    case 2: economico++; break;
                                    case 3: cumpleaños++; break;
                                    }
                                }
                               
                            // }
                        // }
                }
                if(i.Id_Academia == docente.Id_Academia){
                    if(i.Id_Plantel == docente.Id_Plantel){
                        datos.Rows.Add(new Object[] { i.Nombre, dosHoras, economico, cumpleaños});
                    }
                }
                dosHoras = 0;
                economico = 0;
                cumpleaños = 0;
            }

            string strDatos = "['Docentes', 'Dos horas', 'Economicos', 'Cumpleanos'],ppp";

            foreach (DataRow dr in datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1] + "," + dr[2] + "," + dr[3];
                strDatos = strDatos + "],ppp";
            }

            // strDatos = strDatos + "]";

            Console.WriteLine(strDatos);
            ViewBag.DatosBarra = strDatos;

            return View();
        }



    }
}
