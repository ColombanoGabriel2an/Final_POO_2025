using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modelo
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<TarjetaDebito> TarjetasDebito { get; set; }
        public DbSet<TarjetaCredito> TarjetasCredito { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<Acreditacion> Acreditaciones { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBregistros;
            Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=True;
            Encrypt=False;TrustServerCertificate=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Herencia Tarjeta (TPH: Table per Hierarchy)
            modelBuilder.Entity<Tarjeta>()
                .HasDiscriminator<string>("TipoTarjeta")
                .HasValue<TarjetaDebito>("Debito")
                .HasValue<TarjetaCredito>("Credito");

            // 2. Relacion Persona <-> Tarjeta (Titular)
            //    Tarjeta es abstract, pero TarjetaDebito/TarjetaCredito heredan de ella
            modelBuilder.Entity<Tarjeta>()
                .HasOne(t => t.Titular)
                .WithMany(p => p.Tarjetas)
                .HasForeignKey("PersonaId");
            // Se usa "PersonaId" como FK (asegura que exista esa propiedad en la DB).

            // 3. Consumo -> Tarjeta
            modelBuilder.Entity<Consumo>()
                .HasOne(c => c.Tarjeta)
                .WithMany()
                .HasForeignKey(c => c.TarjetaId);

            // 4. Acreditacion -> Tarjeta
            modelBuilder.Entity<Acreditacion>()
                .HasOne(a => a.Tarjeta)
                .WithMany()
                .HasForeignKey(a => a.TarjetaId);

            // 5. Many-to-Many: Consumo <-> Descuento
            //    Como Descuento no tiene la coleccion inversa, se usa WithMany() sin parametros
            modelBuilder.Entity<Consumo>()
                .HasMany(c => c.DescuentosAplicados)
                .WithMany();

        }
    }
}

