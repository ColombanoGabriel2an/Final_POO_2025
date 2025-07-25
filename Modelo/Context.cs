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
            // Usar SQLite para compatibilidad multiplataforma
            optionsBuilder.UseSqlite(@"Data Source=DBregistros.db");
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

            // 6. Seeding de datos iniciales
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Personas
            modelBuilder.Entity<Persona>().HasData(
                new Persona { PersonaId = 1, Nombre = "Gabriel", Apellido = "Colombano", DNI = "44555998" },
                new Persona { PersonaId = 2, Nombre = "Matias", Apellido = "Llanos", DNI = "12355666" },
                new Persona { PersonaId = 3, Nombre = "Laureano", Apellido = "Gallegos", DNI = "12577889" },
                new Persona { PersonaId = 4, Nombre = "Pedro", Apellido = "Lopez", DNI = "13344895" }
            );

            // Seed Descuentos
            modelBuilder.Entity<Descuento>().HasData(
                new Descuento
                {
                    DescuentoId = 1,
                    Codigo = "DESC10",
                    Nombre = "Descuento 10%",
                    Descripcion = "Descuento del 10% en compras",
                    Porcentaje = 10,
                    MontoMinimo = 100,
                    MontoFijo = 0,
                    TopeReintegro = 1000,
                    FechaInicio = new DateTime(2025, 7, 24),
                    FechaFin = new DateTime(2025, 8, 24),
                    Tipo = "Porcentual",
                    Activo = true,
                    Acumulable = true,
                    Banco = "Todos",
                    Emisor = "Sistema",
                    Rubro = "Todos"
                },
                new Descuento
                {
                    DescuentoId = 2,
                    Codigo = "DESC20",
                    Nombre = "Descuento 20%",
                    Descripcion = "Descuento del 20% en compras",
                    Porcentaje = 20,
                    MontoMinimo = 500,
                    MontoFijo = 0,
                    TopeReintegro = 2000,
                    FechaInicio = new DateTime(2025, 7, 24),
                    FechaFin = new DateTime(2025, 9, 24),
                    Tipo = "Porcentual",
                    Activo = true,
                    Acumulable = false,
                    Banco = "Banco Nación",
                    Emisor = "Sistema",
                    Rubro = "Alimentación"
                },
                new Descuento
                {
                    DescuentoId = 3,
                    Codigo = "DESC5",
                    Nombre = "Descuento 5%",
                    Descripcion = "Descuento del 5% en compras",
                    Porcentaje = 5,
                    MontoMinimo = 50,
                    MontoFijo = 0,
                    TopeReintegro = 500,
                    FechaInicio = new DateTime(2025, 7, 24),
                    FechaFin = new DateTime(2025, 10, 24),
                    Tipo = "Porcentual",
                    Activo = true,
                    Acumulable = true,
                    Banco = "Todos",
                    Emisor = "Sistema",
                    Rubro = "Todos"
                }
            );
        }
    }
}

