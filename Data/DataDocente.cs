using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class DataDocente
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BDContext>>()))
            {
                if (context.Docente.Any())
                {
                    return; 
                }

                try{
                    context.Docente.AddRange(
                    new Docente
                    {
                        Nomina = 1111,
                        Nombre = "Coordi",
                        Apellido_Paterno = "Coordinador",
                        Apellido_Materno = "Coordinador",
                        Fecha_Nacimiento = DateTime.Parse("1977-05-05"),
                        Coordinador = true,
                        Contraseña = "coordi",
                        Fecha_Ingreso = DateTime.Parse("2000-02-02"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 1222,
                        Nombre = "Coordi2",
                        Apellido_Paterno = "Coordinador2",
                        Apellido_Materno = "Coordinador2",
                        Fecha_Nacimiento = DateTime.Parse("1988-12-12"),
                        Coordinador = true,
                        Contraseña = "coordi2",
                        Fecha_Ingreso = DateTime.Parse("2005-01-01"),
                        Id_Academia = 2,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9999,
                        Nombre = "Leonardo",
                        Apellido_Paterno = "Rodrigez",
                        Apellido_Materno = "Padilla",
                        Fecha_Nacimiento = DateTime.Parse("2002-05-22"),
                        Coordinador = false,
                        Contraseña = "9999",
                        Fecha_Ingreso = DateTime.Parse("2020-06-23"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9001,
                        Nombre = "Florentino",
                        Apellido_Paterno = "Ariza",
                        Apellido_Materno = "Garcia",
                        Fecha_Nacimiento = DateTime.Parse("1950-06-06"),
                        Coordinador = false,
                        Contraseña = "9001",
                        Fecha_Ingreso = DateTime.Parse("1980-06-06"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9002,
                        Nombre = "Fermina",
                        Apellido_Paterno = "Daza",
                        Apellido_Materno = "Marquez",
                        Fecha_Nacimiento = DateTime.Parse("1955-02-20"),
                        Coordinador = false,
                        Contraseña = "9002",
                        Fecha_Ingreso = DateTime.Parse("1995-08-17"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9003,
                        Nombre = "Pepe",
                        Apellido_Paterno = "Flores",
                        Apellido_Materno = "Delgadillo",
                        Fecha_Nacimiento = DateTime.Parse("1988-03-30"),
                        Coordinador = false,
                        Contraseña = "9003",
                        Fecha_Ingreso = DateTime.Parse("2000-02-02"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9004,
                        Nombre = "Sofia",
                        Apellido_Paterno = "Orozco",
                        Apellido_Materno = "Casillas",
                        Fecha_Nacimiento = DateTime.Parse("1993-09-11"),
                        Coordinador = false,
                        Contraseña = "9004",
                        Fecha_Ingreso = DateTime.Parse("2018-01-28"),
                        Id_Academia = 1,
                        Id_Plantel = 1
                    },
                    new Docente
                    {
                        Nomina = 9005,
                        Nombre = "Rodrigo",
                        Apellido_Paterno = "Ramiro",
                        Apellido_Materno = "Ramirez",
                        Fecha_Nacimiento = DateTime.Parse("1980-04-17"),
                        Coordinador = false,
                        Contraseña = "9005",
                        Fecha_Ingreso = DateTime.Parse("2000-12-02"),
                        Id_Academia = 2,
                        Id_Plantel = 1
                    },
                        new Docente
                    {
                        Nomina = 9006,
                        Nombre = "Enrique",
                        Apellido_Paterno = "Gomez",
                        Apellido_Materno = "D",
                        Fecha_Nacimiento = DateTime.Parse("1977-05-05"),
                        Coordinador = false,
                        Contraseña = "9006",
                        Fecha_Ingreso = DateTime.Parse("2000-02-02"),
                        Id_Academia = 2,
                        Id_Plantel = 1
                    }
                );

                context.SaveChanges();
                Console.WriteLine("Docentes Guardados");

                }catch(DbUpdateException e){
                    Console.WriteLine(e);
                }
               
            }
        }
    }
}