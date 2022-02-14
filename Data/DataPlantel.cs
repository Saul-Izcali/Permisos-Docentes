using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Data;
using System;
using System.Linq;

namespace Proyecto.Models
{
    public static class DataPlantel
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BDContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BDContext>>()))
            {
                if (context.Plantel.Any())
                {
                    return; 
                }

                context.Plantel.AddRange(
                    new Plantel
                    {
                        Nombre = "Colomos"
                    },

                    new Plantel
                    {
                        Nombre = "Tonala"
                    },

                    new Plantel
                    {
                        Nombre = "Rio Nilo"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}