using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraAcreditacion
    {
        // Instancia única de la Controladora
        private static ControladoraAcreditacion? instancia;
        public static ControladoraAcreditacion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraAcreditacion();
                }
                return instancia;
            }
        }

        // Constructor privado
        private ControladoraAcreditacion()
        {
        }

        // Método para listar todas las Acreditaciones
        public List<Acreditacion> ListarAcreditaciones()
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Acreditaciones
                        .Include(a => a.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Acreditacion>();
            }
        }

        // Crear una nueva Acreditación
        public string CrearAcreditacion(Acreditacion acreditacion, Tarjeta tarjeta)
        {
            try
            {
                using (var context = new Context())
                {
                    // Buscar la tarjeta en el sistema
                    var tarjetaEncontrada = context.Tarjetas
                        .Include(t => t.Titular)
                        .FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);

                    if (tarjetaEncontrada == null)
                        return "La tarjeta no existe";

                    acreditacion.Tarjeta = tarjetaEncontrada;
                    context.Acreditaciones.Add(acreditacion);
                    context.SaveChanges();

                    return $"Acreditación creada correctamente para la tarjeta {tarjetaEncontrada.Numero}";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al crear la acreditación: {ex.Message}";
            }
        }

        // Eliminar una Acreditación
        public string EliminarAcreditacion(Acreditacion acreditacion)
        {
            try
            {
                using (var context = new Context())
                {
                    var acreditacionEncontrada = context.Acreditaciones
                        .FirstOrDefault(a => a.AcreditacionId == acreditacion.AcreditacionId);

                    if (acreditacionEncontrada != null)
                    {
                        context.Acreditaciones.Remove(acreditacionEncontrada);
                        context.SaveChanges();
                        return "Acreditación eliminada correctamente";
                    }
                    else
                        return "Acreditación no encontrada";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al eliminar la acreditación: {ex.Message}";
            }
        }

        // Obtener acreditación por ID
        public Acreditacion? ObtenerAcreditacionPorId(int acreditacionId)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Acreditaciones
                        .Include(a => a.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .FirstOrDefault(a => a.AcreditacionId == acreditacionId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Obtener acreditaciones por tarjeta
        public List<Acreditacion> ObtenerAcreditacionesPorTarjeta(int tarjetaId)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Acreditaciones
                        .Include(a => a.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .Where(a => a.TarjetaId == tarjetaId)
                        .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Acreditacion>();
            }
        }

        // Obtener acreditaciones en un rango de fechas
        public List<Acreditacion> ObtenerAcreditacionesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Acreditaciones
                        .Include(a => a.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .Where(a => a.Fecha >= fechaInicio && a.Fecha <= fechaFin)
                        .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Acreditacion>();
            }
        }

        public void PrecargarAcreditaciones()
        {
            try
            {
                using (var context = new Context())
                {
                    // Solo precargar si no hay datos
                    if (!context.Acreditaciones.Any())
                    {
                        var tarjetas = context.Tarjetas.ToList();
                        if (tarjetas.Any())
                        {
                            var acreditaciones = new List<Acreditacion>
                            {
                                new Acreditacion(tarjetas[0], new DateTime(2025, 01, 10), "Transferencia bancaria", 5000, "Transferencia"),
                                new Acreditacion(tarjetas[0], new DateTime(2025, 01, 20), "Depósito efectivo", 2000, "Efectivo")
                            };

                            if (tarjetas.Count > 1)
                            {
                                acreditaciones.Add(new Acreditacion(tarjetas[1], new DateTime(2025, 01, 15), "Transferencia online", 3000, "Transferencia"));
                            }

                            context.Acreditaciones.AddRange(acreditaciones);
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
