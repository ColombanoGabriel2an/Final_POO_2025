using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
  public class ControladoraDescuento
  {
    private static ControladoraDescuento? instancia;

    public static ControladoraDescuento Instancia
    {
      get
      {
        if (instancia == null)
        {
          instancia = new ControladoraDescuento();
        }
        return instancia;
      }
    }

    private ControladoraDescuento()
    {
    }

    public List<Descuento> ListarDescuentos()
    {
      try
      {
        using (var context = new Context())
        {
          return context.Descuentos.ToList();
        }
      }
      catch (Exception)
      {
        return new List<Descuento>();
      }
    }

    public string CrearDescuento(Descuento descuento)
    {
      try
      {
        using (var context = new Context())
        {
          // Verificar si ya existe un descuento con el mismo código
          var descuentoExistente = context.Descuentos.FirstOrDefault(d => d.Codigo == descuento.Codigo);

          if (descuentoExistente != null)
          {
            // Actualizar el descuento existente
            descuentoExistente.Nombre = descuento.Nombre;
            descuentoExistente.Porcentaje = descuento.Porcentaje;
            descuentoExistente.MontoMaximo = descuento.MontoMaximo;
            descuentoExistente.FechaInicio = descuento.FechaInicio;
            descuentoExistente.FechaFin = descuento.FechaFin;
            descuentoExistente.TipoDescuento = descuento.TipoDescuento;
            descuentoExistente.CantidadUsos = descuento.CantidadUsos;
            descuentoExistente.UsosDisponibles = descuento.UsosDisponibles;

            context.SaveChanges();
            return $"Descuento '{descuento.Nombre}' actualizado correctamente";
          }
          else
          {
            // Crear un nuevo descuento
            context.Descuentos.Add(descuento);
            context.SaveChanges();
            return $"Descuento '{descuento.Nombre}' creado correctamente";
          }
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al crear/actualizar el descuento: {ex.Message}";
      }
    }

    public string BorrarDescuento(Descuento descuento)
    {
      try
      {
        using (var context = new Context())
        {
          var descuentoEncontrado = context.Descuentos.FirstOrDefault(d => d.DescuentoId == descuento.DescuentoId);
          if (descuentoEncontrado != null)
          {
            context.Descuentos.Remove(descuentoEncontrado);
            context.SaveChanges();
            return "Descuento eliminado correctamente";
          }
          else
            return "Descuento no encontrado";
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al eliminar el descuento: {ex.Message}";
      }
    }

    public string ActualizarDescuento(Descuento descuento)
    {
      try
      {
        using (var context = new Context())
        {
          var descuentoExistente = context.Descuentos.FirstOrDefault(d => d.DescuentoId == descuento.DescuentoId);
          if (descuentoExistente != null)
          {
            descuentoExistente.Nombre = descuento.Nombre;
            descuentoExistente.Codigo = descuento.Codigo;
            descuentoExistente.Porcentaje = descuento.Porcentaje;
            descuentoExistente.MontoMaximo = descuento.MontoMaximo;
            descuentoExistente.FechaInicio = descuento.FechaInicio;
            descuentoExistente.FechaFin = descuento.FechaFin;
            descuentoExistente.TipoDescuento = descuento.TipoDescuento;
            descuentoExistente.CantidadUsos = descuento.CantidadUsos;
            descuentoExistente.UsosDisponibles = descuento.UsosDisponibles;

            context.SaveChanges();
            return "Descuento actualizado correctamente";
          }
          else
          {
            return "Descuento no encontrado";
          }
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al actualizar el descuento: {ex.Message}";
      }
    }

    // Obtener descuento por ID
    public Descuento? ObtenerDescuentoPorId(int descuentoId)
    {
      try
      {
        using (var context = new Context())
        {
          return context.Descuentos.FirstOrDefault(d => d.DescuentoId == descuentoId);
        }
      }
      catch (Exception)
      {
        return null;
      }
    }

    // Buscar descuento por código
    public Descuento? BuscarDescuentoPorCodigo(string codigo)
    {
      try
      {
        using (var context = new Context())
        {
          return context.Descuentos.FirstOrDefault(d => d.Codigo == codigo);
        }
      }
      catch (Exception)
      {
        return null;
      }
    }

    // Obtener descuentos válidos
    public List<Descuento> ObtenerDescuentosValidos()
    {
      try
      {
        using (var context = new Context())
        {
          var fechaActual = DateTime.Now;
          return context.Descuentos
              .Where(d => d.FechaInicio <= fechaActual && d.FechaFin >= fechaActual && d.UsosDisponibles > 0)
              .ToList();
        }
      }
      catch (Exception)
      {
        return new List<Descuento>();
      }
    }

    public string AplicarDescuento(Consumo consumo, string codigoDescuento)
    {
      try
      {
        using (var context = new Context())
        {
          var descuento = context.Descuentos.FirstOrDefault(d => d.Codigo == codigoDescuento);

          if (descuento == null)
            return "El código de descuento no existe";

          var fechaActual = DateTime.Now;
          if (descuento.FechaInicio > fechaActual || descuento.FechaFin < fechaActual)
            return "El descuento no está vigente";

          if (descuento.UsosDisponibles <= 0)
            return "El descuento ya no tiene usos disponibles";

          var consumoDb = context.Consumos
              .Include(c => c.DescuentosAplicados)
              .FirstOrDefault(c => c.ConsumoId == consumo.ConsumoId);

          if (consumoDb == null)
            return "El consumo no existe";

          // Verificar si ya tiene este descuento aplicado
          if (consumoDb.DescuentosAplicados.Any(d => d.DescuentoId == descuento.DescuentoId))
            return "Este descuento ya está aplicado al consumo";

          // Aplicar descuento
          consumoDb.DescuentosAplicados.Add(descuento);
          descuento.UsosDisponibles--;

          // Calcular nuevo monto
          decimal montoDescuento = (consumoDb.Monto * descuento.Porcentaje) / 100;
          if (descuento.MontoMaximo > 0 && montoDescuento > descuento.MontoMaximo)
            montoDescuento = descuento.MontoMaximo;

          context.SaveChanges();

          return $"Descuento aplicado correctamente. Ahorro: ${montoDescuento:F2}";
        }
      }
      catch (Exception ex)
      {
        return $"Ocurrió un error al aplicar el descuento: {ex.Message}";
      }
    }

    public void PrecargarDescuentos()
    {
      try
      {
        using (var context = new Context())
        {
          // Solo precargar si no hay datos
          if (!context.Descuentos.Any())
          {
            var descuentos = new List<Descuento>
                        {
                            new Descuento("DESC10", "Descuento 10%", 10, 1000, DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(1), "Porcentual", 100, 100),
                            new Descuento("DESC20", "Descuento 20%", 20, 2000, DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(2), "Porcentual", 50, 50),
                            new Descuento("DESC5", "Descuento 5%", 5, 500, DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(3), "Porcentual", 200, 200)
                        };

            context.Descuentos.AddRange(descuentos);
            context.SaveChanges();
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
