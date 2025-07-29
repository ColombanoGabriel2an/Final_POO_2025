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
            string currentDir = Directory.GetCurrentDirectory();
            string projectRoot = Path.GetFullPath(Path.Combine(currentDir, "..", "..", ".."));
            string dbPath = Path.Combine(projectRoot, "DBregistros.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        // Método para aplicar migraciones pendientes
        public void AplicarMigraciones()
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Herencia Tarjeta (TPH: Table per Hierarchy)
            modelBuilder.Entity<Tarjeta>()
                .HasDiscriminator<string>("TipoTarjeta")
                .HasValue<TarjetaDebito>("Debito")
                .HasValue<TarjetaCredito>("Credito");

            // 2. Configurar auto-incremento para todas las entidades
            modelBuilder.Entity<Persona>()
                .Property(p => p.PersonaId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Tarjeta>()
                .Property(t => t.TarjetaId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Consumo>()
                .Property(c => c.ConsumoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Descuento>()
                .Property(d => d.DescuentoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Acreditacion>()
                .Property(a => a.AcreditacionId)
                .ValueGeneratedOnAdd();

            // 3. Relacion Persona <-> Tarjeta (Titular)
            modelBuilder.Entity<Tarjeta>()
                .HasOne(t => t.Titular)
                .WithMany(p => p.Tarjetas)
                .HasForeignKey("PersonaId");

            // 4. Consumo -> Tarjeta
            modelBuilder.Entity<Consumo>()
                .HasOne(c => c.Tarjeta)
                .WithMany()
                .HasForeignKey(c => c.TarjetaId);

            // 5. Acreditacion -> Tarjeta
            modelBuilder.Entity<Acreditacion>()
                .HasOne(a => a.Tarjeta)
                .WithMany()
                .HasForeignKey(a => a.TarjetaId);

            // 6. Many-to-Many: Consumo <-> Descuento
            modelBuilder.Entity<Consumo>()
                .HasMany(c => c.DescuentosAplicados)
                .WithMany();

            // 7. Seeding de datos con HasData (sin IDs explícitos para auto-incremento)
            modelBuilder.Entity<Persona>().HasData(
                new Persona { PersonaId = 1, Nombre = "Gabriel", Apellido = "Colombano", DNI = "44555998" },
                new Persona { PersonaId = 2, Nombre = "Matias", Apellido = "Llanos", DNI = "12355666" },
                new Persona { PersonaId = 3, Nombre = "Laureano", Apellido = "Gallegos", DNI = "12577889" },
                new Persona { PersonaId = 4, Nombre = "Pedro", Apellido = "Lopez", DNI = "13344895" }
            );

            modelBuilder.Entity<Descuento>().HasData(
                new Descuento { 
                    DescuentoId = 1,
                    Codigo = "SUPER30", 
                    Nombre = "Miércoles de descuentos", 
                    Descripcion = "30% los miércoles en supermercados", 
                    FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 6, 30), 
                    Porcentaje = 30, 
                    MontoMinimo = 0,
                    MontoFijo = 0, 
                    TopeReintegro = 3000, 
                    Banco = "Banco Santander", 
                    Emisor = "VISA", 
                    Rubro = "Supermercados", 
                    Tipo = "Porcentual", 
                    Activo = true, 
                    Acumulable = false },
                
                new Descuento { 
                    DescuentoId = 2,
                    Codigo = "REST2X1", 
                    Nombre = "2x1 en Restaurantes", 
                    Descripcion = "2x1 en restaurantes adheridos", 
                    FechaInicio = new DateTime(2025, 3, 1), 
                    FechaFin = new DateTime(2025, 4, 30), 
                    Porcentaje = 50, 
                    MontoMinimo = 0,
                    MontoFijo = 0, 
                    TopeReintegro = 1500, 
                    Banco = "Banco BBVA", 
                    Emisor = "American Express", 
                    Rubro = "Restaurantes", 
                    Tipo = "Porcentual", 
                    Activo = true, 
                    Acumulable = false },

                new Descuento { 
                    DescuentoId = 3,
                    Codigo = "FARM15", 
                    Nombre = "Descuento en Farmacias", 
                    Descripcion = "15% todos los días en farmacias", 
                    FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 12, 31), 
                    Porcentaje = 15, 
                    MontoMinimo = 0,
                    MontoFijo = 0, 
                    TopeReintegro = 1000, 
                    Banco = "Banco Nación", 
                    Emisor = "Mastercard", 
                    Rubro = "Farmacias", 
                    Tipo = "Porcentual", 
                    Activo = true, 
                    Acumulable = true }
            );

            modelBuilder.Entity<TarjetaDebito>().HasData(
                new TarjetaDebito
                {
                    TarjetaId = 1,
                    Numero = "1111222233334444",
                    FechaVencimiento = new DateTime(2026, 12, 31),
                    Banco = "Banco BBVA",
                    EntidadEmisora = "VISA",
                    PersonaId = 2, // Referencia a Matias
                    Alias = "BBVA Mati",
                    Saldo = 100000
                }
            );

            modelBuilder.Entity<TarjetaCredito>().HasData(
                new TarjetaCredito
                {
                    TarjetaId = 2,
                    Numero = "5555666677778888",
                    FechaVencimiento = new DateTime(2028, 10, 1),
                    Banco = "Banco Macro",
                    EntidadEmisora = "Mastercard",
                    PersonaId = 2, // Referencia a Matias
                    TenedorId = 2,
                    Alias = "Macro Mati",
                    IsExtension = true,
                    Limite = 1000000,
                    Disponible = 500000
                }
            );
        }
    }
}

