using Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Modelo
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Acreditacion> Acreditaciones { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Reemplaza "YourConnectionStringHere" con tu cadena de conexión real.
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí puedes agregar configuraciones adicionales con Fluent API si es necesario.
        }
    }
}
