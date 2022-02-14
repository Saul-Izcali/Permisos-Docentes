using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Proyecto.Data;

namespace Proyecto.Models
{
    public static class DataTipoPermiso
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BDContext>>()))
            {
                // Look for any movies.
                if (context.Tipo_Permiso.Any())
                {
                    return;   // DB has been seeded
                }

                context.Tipo_Permiso.AddRange(
                    new Tipo_Permiso
                    {
                        Nombre = "Dos horas",
                    },
                    new Tipo_Permiso
                    {
                        Nombre = "Economico",
                    },
                    new Tipo_Permiso
                    {
                        Nombre = "Cumpleanos",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}