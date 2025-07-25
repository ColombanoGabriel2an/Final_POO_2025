using Controladora;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Inicializando base de datos...");

      try
      {
        // Asegurar que la base de datos esté creada y actualizada
        using (var context = new Context())
        {
          Console.WriteLine("Creando base de datos...");
          context.Database.EnsureCreated();
          Console.WriteLine("✓ Base de datos creada exitosamente");
        }

        Console.WriteLine("Precargando datos...");

        // Precargar personas
        ControladoraPersona.Instancia.PrecargarPersonas();
        Console.WriteLine("✓ Personas precargadas");

        // Precargar tarjetas
        ControladoraTarjeta.Instancia.PrecargarTarjetas();
        Console.WriteLine("✓ Tarjetas precargadas");

        // Precargar descuentos
        ControladoraDescuento.Instancia.PrecargarDescuentos();
        Console.WriteLine("✓ Descuentos precargados");

        // Precargar acreditaciones
        ControladoraAcreditacion.Instancia.PrecargarAcreditaciones();
        Console.WriteLine("✓ Acreditaciones precargadas");

        // Precargar consumos
        ControladoraConsumo.Instancia.PrecargarConsumos();
        Console.WriteLine("✓ Consumos precargados");

        Console.WriteLine("\n¡Base de datos inicializada y datos precargados exitosamente!");

        // Mostrar estadísticas
        Console.WriteLine("\n=== ESTADÍSTICAS ===");
        Console.WriteLine($"Personas: {ControladoraPersona.Instancia.ListarPersonas().Count}");
        Console.WriteLine($"Tarjetas: {ControladoraTarjeta.Instancia.ListarTarjetas().Count}");
        Console.WriteLine($"Descuentos: {ControladoraDescuento.Instancia.ListarDescuentos().Count}");
        Console.WriteLine($"Acreditaciones: {ControladoraAcreditacion.Instancia.ListarAcreditaciones().Count}");
        Console.WriteLine($"Consumos: {ControladoraConsumo.Instancia.ListarConsumos().Count}");

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        Console.WriteLine($"Detalles: {ex.InnerException?.Message}");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
      }
    }
  }
}
