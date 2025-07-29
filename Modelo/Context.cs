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

            // Seed Consumos
            modelBuilder.Entity<Consumo>().HasData(
                new Consumo { ConsumoId = 1, TarjetaId = 1, Fecha = new DateTime(2025, 1, 15), Hora = "12:30", 
                    Descripcion = "Compra en tienda de tecnología", Monto = 300, Moneda = "ARG", Rubro = "Electrónica", 
                    Comercio = "Star Computacion", EsRecurrente = false
                },

                new Consumo { ConsumoId = 2, TarjetaId = 2, Fecha = new DateTime(2025, 1, 15), Hora = "14:00", 
                    Descripcion = "Compra en tienda de ropa", Monto = 500, Moneda = "ARG", Rubro = "Ropa", 
                    Comercio = "Sport 78", EsRecurrente = false }
            );


            // Seed Descuentos
            modelBuilder.Entity<Descuento>().HasData(

                new Descuento { 
                    DescuentoId = 1, Codigo = "SUPER30", Nombre = "Miércoles de descuentos", 
                    Descripcion = "30% los miércoles en supermercados", 
                    FechaInicio = new DateTime(2025, 1, 1), FechaFin = new DateTime(2025, 6, 30), 
                    Porcentaje = 30, MontoFijo = 0, TopeReintegro = 3000, Banco = "Banco Santander", 
                    Emisor = "VISA", Rubro = "Supermercados", Tipo = "Porcentual", Activo = true, Acumulable = false },
                
                new Descuento { 
                    DescuentoId = 2, Codigo = "REST2X1", Nombre = "2x1 en Restaurantes", 
                    Descripcion = "2x1 en restaurantes adheridos", FechaInicio = new DateTime(2025, 3, 1), 
                    FechaFin = new DateTime(2025, 4, 30), Porcentaje = 50, MontoFijo = 0, TopeReintegro = 1500, Banco = "Banco BBVA", 
                    Emisor = "American Express", Rubro = "Restaurantes", Tipo = "Porcentual", Activo = true, Acumulable = false },

                new Descuento { DescuentoId = 3, Codigo = "FARM15", Nombre = "Descuento en Farmacias", 
                    Descripcion = "15% todos los días en farmacias", FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 12, 31), Porcentaje = 15, MontoFijo = 0, TopeReintegro = 1000, Banco = "Banco Nación", 
                    Emisor = "Mastercard", Rubro = "Farmacias", Tipo = "Porcentual", Activo = true, Acumulable = true },

                new Descuento { 
                    DescuentoId = 4, Codigo = "FARM500", Nombre = "Reintegro en Farmacias", 
                    Descripcion = "$500 de descuento en compras superiores a $3000", FechaInicio = new DateTime(2025, 3, 15), 
                    FechaFin = new DateTime(2025, 4, 15), Porcentaje = 0, MontoFijo = 500, TopeReintegro = 3000, Banco = "Banco BBVA", 
                    Emisor = "VISA", Rubro = "Farmacias", Tipo = "Monto Fijo", Activo = true, Acumulable = false },

                new Descuento { 
                    DescuentoId = 5, Codigo = "TECH12C", Nombre = "12 Cuotas Tecnología", 
                    Descripcion = "12 cuotas sin interés en tecnología", FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 12, 31), Porcentaje = 0, MontoFijo = 0, MontoMinimo = 0, TopeReintegro = 10000, 
                    Banco = "Banco Santander", Emisor = "VISA", Rubro = "Electrónica", Tipo = "Financiación", Activo = true, Acumulable = true },

                new Descuento { 
                    DescuentoId = 6, Codigo = "TECH20", Nombre = "Descuento en Tecnología", 
                    Descripcion = "20% en artículos seleccionados de tecnología", FechaInicio = new DateTime(2025, 3, 1), 
                    FechaFin = new DateTime(2025, 3, 31), Porcentaje = 20, MontoFijo = 0, TopeReintegro = 5000, Banco = "Banco BBVA", 
                    Emisor = "Mastercard", Rubro = "Electrónica", Tipo = "Porcentual", Activo = true, Acumulable = false },

                new Descuento { 
                    DescuentoId = 7, Codigo = "ROPA30FDS", Nombre = "Fines de Semana de Moda", 
                    Descripcion = "30% en ropa los fines de semana", FechaInicio = new DateTime(2025, 2, 1), 
                    FechaFin = new DateTime(2025, 8, 31), Porcentaje = 30, MontoFijo = 0, TopeReintegro = 4000, Banco = "Banco Macro", 
                    Emisor = "VISA", Rubro = "Indumentaria", Tipo = "Porcentual", Activo = true, Acumulable = false },

                new Descuento { 
                    DescuentoId = 8, Codigo = "ROPA3C10", Nombre = "Cuotas + Descuento", 
                    Descripcion = "3 cuotas sin interés + 10% off", FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 12, 31), Porcentaje = 10, MontoFijo = 0, MontoMinimo = 2000, TopeReintegro = 5000, 
                    Banco = "Banco Macro", Emisor = "Mastercard", Rubro = "Indumentaria", Tipo = "Mixto", Activo = true, Acumulable = true },

                new Descuento { 
                    DescuentoId = 9, Codigo = "ROPA6C20", Nombre = "Cuotas + Descuento", 
                    Descripcion = "6 cuotas sin interés + 20% off", FechaInicio = new DateTime(2025, 1, 1), 
                    FechaFin = new DateTime(2025, 12, 31), Porcentaje = 20, MontoFijo = 0, MontoMinimo = 2000, TopeReintegro = 5000, 
                    Banco = "Banco BBVA", Emisor = "Mastercard", Rubro = "Indumentaria", Tipo = "Mixto", Activo = true, Acumulable = true }
            );

            // Seed Tarjetas
            modelBuilder.Entity<TarjetaDebito>().HasData(
                new TarjetaDebito
                {
                    TarjetaId = 1,
                    Numero = "1111222233334444",
                    FechaVencimiento = new DateTime(2026, 12, 31),
                    Banco = "Banco BBVA",
                    EntidadEmisora = "VISA",
                    PersonaId = 2,
                    Alias = "BBVA Mati",
                    Saldo = 100000
                },
                new TarjetaDebito
                {
                    TarjetaId = 4,
                    Numero = "5678567856785678",
                    FechaVencimiento = new DateTime(2030, 2, 2),
                    Banco = "Banco BBVA",
                    EntidadEmisora = "Mastercard",
                    PersonaId = 4,
                    Alias = "Naranja Pedro",
                    Saldo = 200000
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
                    PersonaId = 2,
                    TenedorId = 2,
                    Alias = "Macro Mati",
                    IsExtension = true,
                    Limite = 1000000,
                    Disponible = 500000
                },
                new TarjetaCredito
                {
                    TarjetaId = 3,
                    Numero = "1234123412341234",
                    FechaVencimiento = new DateTime(2027, 1, 1),
                    Banco = "Banco Santander",
                    EntidadEmisora = "VISA",
                    PersonaId = 1,
                    TenedorId = 1,
                    Alias = "VISA Gabi",
                    IsExtension = false,
                    Limite = 1500000,
                    Disponible = 1200000
                },
                new TarjetaCredito
                {
                    TarjetaId = 5,
                    Numero = "5555666677778888",
                    FechaVencimiento = new DateTime(2028, 10, 1),
                    Banco = "Banco BBVA",
                    EntidadEmisora = "Mastercard",
                    PersonaId = 2,
                    TenedorId = 2,
                    Alias = "BBVA MC Mati",
                    IsExtension = true,
                    Limite = 1000000,
                    Disponible = 500000
                }
            );

        }
    }
}

