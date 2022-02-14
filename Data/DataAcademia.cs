using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class DataAcademia
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BDContext>>()))
            {
                // Look for any movies.
                if (context.Academia.Any())
                {
                    return;   // DB has been seeded
                }

                context.Academia.AddRange(
                    new Academia
                    {
                        Nombre = "Software"
                    },

                    new Academia
                    {
                        Nombre = "Farmacos"
                    },

                    new Academia
                    {
                        Nombre = "Control"
                    },

                    new Academia
                    {
                        Nombre = "Mecanica"
                    },

                    new Academia
                    {
                        Nombre = "Electronica"
                    },

                    new Academia
                    {
                        Nombre = "Maquinas"
                    },

                    new Academia
                    {
                        Nombre = "Construccion"
                    },

                    new Academia
                    {
                        Nombre = "Electromecanica"
                    },

                    new Academia
                    {
                        Nombre = "Basicas"
                    },

                    new Academia
                    {
                        Nombre = "Administrativas"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}