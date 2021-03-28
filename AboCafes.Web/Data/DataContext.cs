using AboCafes.Common.Entities;
using AboCafes.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }


        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Corregimiento> Corregimientos { get; set; }
        public DbSet<Vereda> Veredas { get; set; }
        public DbSet<Finca> Fincas { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Hectarea> Hectareas { get; set; }
        public DbSet<Parafertil> Parafertils { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Tercero> Terceros { get; set; }
        public DbSet<Cafe> Cafes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Tercero>()
               .HasIndex(t => t.Documento)
               .IsUnique();



            modelBuilder.Entity<Departamento>(dep =>
            {
                dep.HasIndex("Name").IsUnique();
                dep.HasMany(c => c.Ciudades).WithOne(d => d.Departamento).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Ciudad>(ciu =>
            {
                ciu.HasIndex("Name", "DepartamentoId").IsUnique();
                ciu.HasOne(d => d.Departamento).WithMany(c => c.Ciudades).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Corregimiento>(cor =>
            {
                cor.HasIndex("Name", "CiudadId").IsUnique();
                cor.HasOne(c => c.Ciudad).WithMany(d => d.Corregimientos).OnDelete(DeleteBehavior.Cascade);
            });

        }

    }
}
