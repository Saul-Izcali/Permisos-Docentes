using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using Proyecto.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Proyecto.Data
{
    public class BDContext : DbContext
    {
        public BDContext (DbContextOptions<BDContext> options)
            : base(options)
        {
        }

        // public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Academia> Academia { get; set; }
        public DbSet<Plantel> Plantel { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Tipo_Permiso> Tipo_Permiso { get; set; }
        // public DbSet<Permiso_Docente> Permiso_Docente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Docente>().Property<int>("Id_Plantel");
            modelBuilder.Entity<Docente>().Property<int>("Id_Academia");
            // modelBuilder.Entity<Permiso_Docente>().Property<int>("Permiso");
            // modelBuilder.Entity<Permiso_Docente>().Property<int>("Docente");
            modelBuilder.Entity<Permiso>().Property<int>("Id_Docente");              //  <--
            modelBuilder.Entity<Permiso>().Property<int>("Id_Tipo");

            //Academia y plantel tiene la mismo tipo de relacion con docente
            //Todo docente necesita un plantel y una academia
            modelBuilder.Entity<Docente>() // cada docente 
                        .HasOne(p => p.Plantel)  // tiene un plantel
                        .WithMany(b => b.DocentesPlantel)  // y un plantel puede tener muchos docentes
                        .HasForeignKey("Id_Plantel"); // y la FK es PlantelId
            modelBuilder.Entity<Docente>() 
                        .HasOne(p => p.Academia)
                        .WithMany(b => b.DocentesAcademia)
                        .HasForeignKey("Id_Academia");

            // modelBuilder.Entity<Permiso_Docente>()
            //             .HasOne(p => p.permisoDocente)
            //             .WithOne(b => b.permisoDocente)
            //             .HasForeignKey("Permiso");
            // modelBuilder.Entity<Permiso_Docente>()
            //             .HasOne(p => p.docentePermiso)  
            //             .WithOne(b => b.docentePermiso)
            //             .HasForeignKey("Docente");


            modelBuilder.Entity<Permiso>() //cada permiso               <--
                        .HasOne(d => d.Docente) // tiene un docente
                        .WithMany(p => p.PermisosDocente) //y un docente puede tener muchos permisos
                        .HasForeignKey("Id_Docente"); // y la FK es DocenteId
            //todo permiso tiene un tipo
            modelBuilder.Entity<Permiso>() //cada permiso 
                        .HasOne(t => t.Tipo) // tiene un tipo
                        .WithMany(p => p.Permisos) //y un permiso solo puede tener un tipo a la vez
                        .HasForeignKey("Id_Tipo");
            
        }   


    }
}

