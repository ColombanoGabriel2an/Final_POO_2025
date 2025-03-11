using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraAcreditacion
    {
        // Lista en memoria de las Acreditaciones
        private List<Acreditacion> acreditaciones;

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
            acreditaciones = new List<Acreditacion>();
        }

        // Método para listar todas las Acreditaciones
        public List<Acreditacion> ListarAcreditaciones()
        {
            return acreditaciones;
        }

        // Crear una nueva Acreditación
        public string CrearAcreditacion(Acreditacion acreditacion, Tarjeta tarjeta)
        {
            try
            {
                // Buscar la tarjeta en el sistema
                var tarjetaEncontrada = ControladoraTarjeta.Instancia.ListarTarjetas()
                    .FirstOrDefault(t => t.Numero == tarjeta.Numero); // Asumimos que la tarjeta se busca por el número

                if (tarjetaEncontrada == null)
                    return "La tarjeta no existe";

                // Generar ID si es necesario
                if (acreditacion.AcreditacionId <= 0)
                {
                    acreditacion.AcreditacionId = GenerarIdAcreditacion();
                }

                // Asociamos la tarjeta encontrada a la acreditación
                acreditacion.Tarjeta = tarjetaEncontrada;

                // Lógica adicional para actualizar saldos o realizar otras operaciones

                // Agregar la acreditación a la lista
                acreditaciones.Add(acreditacion);

                return $"Acreditación creada para la tarjeta {tarjetaEncontrada.Numero}";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al crear la acreditación: {ex.Message}";
            }
        }

        // Borrar una acreditación
        public string BorrarAcreditacion(Acreditacion acreditacion)
        {
            try
            {
                var acreditacionEncontrada = acreditaciones
                    .FirstOrDefault(a => a.AcreditacionId == acreditacion.AcreditacionId);

                if (acreditacionEncontrada != null)
                {
                    acreditaciones.Remove(acreditacionEncontrada);
                    return "Acreditación eliminada correctamente";
                }
                else
                {
                    return "Acreditación no encontrada";
                }
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar la acreditación";
            }
        }

        // Precargar datos de Acreditaciones (ejemplo con tarjetas precargadas)
        public void PrecargarAcreditaciones()
        {
            try
            {
                // Precargamos dos tarjetas para asociar a las acreditaciones
                var tarjeta1 = ControladoraTarjeta.Instancia.ListarTarjetas().First(t => t.Numero == "1111222233334444");
                var tarjeta2 = ControladoraTarjeta.Instancia.ListarTarjetas().First(t => t.Numero == "5555666677778888");

                // Crear algunas acreditaciones y asociarlas a las tarjetas
                var acreditacion1 = new Acreditacion
                {
                    Descripcion = "Acreditación por compra",
                    Fecha = DateTime.Now,
                    Monto = 1000,
                    Tarjeta = tarjeta1
                };

                var acreditacion2 = new Acreditacion
                {
                    Descripcion = "Acreditación por pago de factura",
                    Fecha = DateTime.Now,
                    Monto = 2000,
                    Tarjeta = tarjeta2
                };

                // Agregar las acreditaciones a la lista
                CrearAcreditacion(acreditacion1, tarjeta1);
                CrearAcreditacion(acreditacion2, tarjeta2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al precargar acreditaciones: {ex.Message}");
            }
        }

        // Generar un ID único para cada Acreditación
        public int GenerarIdAcreditacion()
        {
            if (acreditaciones.Count > 0)
            {
                return acreditaciones.Max(a => a.AcreditacionId) + 1;
            }
            else
            {
                return 1; // Si no hay acreditaciones, el primer ID será 1
            }
        }

    }
}
