using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
  public class ControladoraTarjeta
  {
    private static ControladoraTarjeta? instancia;

    public static ControladoraTarjeta Instancia
    {
      get
      {
        if (instancia == null)
        {
          instancia = new ControladoraTarjeta();
        }
        return instancia;
      }
    }

    private ControladoraTarjeta()
    {
    }

    public List<Tarjeta> ListarTarjetas()
    {
      try
      {
        using (var context = new Context())
        {
          return context.Tarjetas.Include(t => t.Titular).ToList();
        }
      }
      catch (Exception)
      {
        return new List<Tarjeta>();
      }
    }

    public string CrearTarjeta(Tarjeta tarjeta, Persona titular)
    {
      try
      {
        using (var context = new Context())
        {
          var personaEncontrada = context.Personas.FirstOrDefault(p => p.PersonaId == titular.PersonaId);

          if (personaEncontrada == null)
            return "El titular no existe";

          tarjeta.Titular = personaEncontrada;
          context.Tarjetas.Add(tarjeta);
          context.SaveChanges();

          return "Tarjeta creada correctamente";
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al crear la tarjeta: {ex.Message}";
      }
    }

    public string BorrarTarjeta(Tarjeta tarjeta)
    {
      try
      {
        using (var context = new Context())
        {
          var tarjetaEncontrada = context.Tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
          if (tarjetaEncontrada != null)
          {
            context.Tarjetas.Remove(tarjetaEncontrada);
            context.SaveChanges();
            return "Tarjeta eliminada correctamente";
          }
          else
            return "Tarjeta no encontrada";
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al eliminar la tarjeta: {ex.Message}";
      }
    }

    public string ActualizarTarjeta(Tarjeta tarjeta)
    {
      try
      {
        using (var context = new Context())
        {
          var tarjetaExistente = context.Tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
          if (tarjetaExistente != null)
          {
            tarjetaExistente.Numero = tarjeta.Numero;
            tarjetaExistente.FechaVencimiento = tarjeta.FechaVencimiento;
            tarjetaExistente.Banco = tarjeta.Banco;
            tarjetaExistente.EntidadEmisora = tarjeta.EntidadEmisora;
            tarjetaExistente.Alias = tarjeta.Alias;

            if (tarjetaExistente is TarjetaDebito tdExistente && tarjeta is TarjetaDebito tdNueva)
            {
              tdExistente.Saldo = tdNueva.Saldo;
            }
            else if (tarjetaExistente is TarjetaCredito tcExistente && tarjeta is TarjetaCredito tcNueva)
            {
              tcExistente.Limite = tcNueva.Limite;
              tcExistente.Disponible = tcNueva.Disponible;
              tcExistente.IsExtension = tcNueva.IsExtension;
              tcExistente.Tenedor = tcNueva.Tenedor;
            }

            context.SaveChanges();
            return "Tarjeta actualizada correctamente";
          }
          else
          {
            return "Tarjeta no encontrada";
          }
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al actualizar la tarjeta: {ex.Message}";
      }
    }

    // Obtener tarjeta por ID
    public Tarjeta? ObtenerTarjetaPorId(int tarjetaId)
    {
      try
      {
        using (var context = new Context())
        {
          return context.Tarjetas.Include(t => t.Titular).FirstOrDefault(t => t.TarjetaId == tarjetaId);
        }
      }
      catch (Exception)
      {
        return null;
      }
    }

    public void PrecargarTarjetas()
    {
      try
      {
        using (var context = new Context())
        {
          // Solo precargar si no hay datos
          if (!context.Tarjetas.Any())
          {
            var personas = context.Personas.ToList();
            if (personas.Any())
            {
              var tarjetas = new List<Tarjeta>
                            {
                                new TarjetaDebito("1234-5678-9012-3456", DateTime.Now.AddYears(3), "Banco Nación", "Visa", personas[0], "Mi Débito", 15000),
                                new TarjetaCredito("2345-6789-0123-4567", DateTime.Now.AddYears(4), "Banco Galicia", "MasterCard", personas[1], "Mi Crédito", 50000, 50000, false, personas[1])
                            };

              context.Tarjetas.AddRange(tarjetas);
              context.SaveChanges();
            }
          }
        }
      }
      catch (Exception)
      {
        // Error en precarga, no hacer nada
      }
    }
  }
}
