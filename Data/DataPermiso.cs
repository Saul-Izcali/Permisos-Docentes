using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class DataPermiso
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BDContext>>()))
            {
                if (context.Permiso.Any())
                {
                    return; 
                }

                context.Permiso.AddRange(
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-02-22"),
                        Termino = DateTime.Parse("2021-02-23"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-03-22"),
                        Termino = DateTime.Parse("2021-03-23"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-04-22"),
                        Termino = DateTime.Parse("2021-04-23"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-05-22"),
                        Termino = DateTime.Parse("2021-05-23"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{  // cumpleaños
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 3,
                        Inicio = DateTime.Parse("2021-06-01"),
                        Termino = DateTime.Parse("2021-06-01"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 1,
                        Inicio = DateTime.Parse("2021-02-22"),
                        Termino = DateTime.Parse("2021-02-22"),
                        Horario = "Mañana"
                    },
                    new Permiso{
                        Id_Docente = 9999,
                        Valido = true,
                        Id_Tipo = 1,
                        Inicio = DateTime.Parse("2021-05-01"),
                        Termino = DateTime.Parse("2021-05-01"),
                        Horario = "Tarde"
                    },
                    new Permiso{
                        Id_Docente = 9001,
                        Valido = true,
                        Id_Tipo = 1,
                        Inicio = DateTime.Parse("2021-05-01"),
                        Termino = DateTime.Parse("2021-05-01"),
                        Horario = "Tarde"
                    },
                    new Permiso{
                        Id_Docente = 9001,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-06-10"),
                        Termino = DateTime.Parse("2021-06-11"),
                        Horario = "Todo el dia"
                    },
                    new Permiso{
                        Id_Docente = 9002,
                        Valido = true,
                        Id_Tipo = 2,
                        Inicio = DateTime.Parse("2021-06-10"),
                        Termino = DateTime.Parse("2021-06-11"),
                        Horario = "Todo el dia"
                    }
                    
                );
                context.SaveChanges();
                Console.WriteLine("Permisos Guardados");
            }
        }
    }
}