using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraTarjeta
    {
        private List<Tarjeta> tarjetas;
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
            tarjetas = new List<Tarjeta>();
        }

        public List<Tarjeta> ListarTarjetas()
        {
            return tarjetas;
        }

        public string CrearTarjeta(Tarjeta tarjeta, Persona titular)
        {
            try
            {
                var personaEncontrada = ControladoraPersona.Instancia.ListarPersonas()
                    .FirstOrDefault(p => p.PersonaId == titular.PersonaId);

                if (personaEncontrada == null)
                    return "El titular no existe";

                // Generar ID si es necesario
                if (tarjeta.TarjetaId <= 0)
                {
                    tarjeta.TarjetaId = tarjetas.Count > 0
                        ? tarjetas.Max(t => t.TarjetaId) + 1 : 1;
                }

                tarjeta.Titular = personaEncontrada;
                tarjetas.Add(tarjeta);
                return $"Tarjeta {tarjeta.Numero} creada para {personaEncontrada.Nombre}";
            }
            catch (Exception)
            {
                return "Ocurrió un error al crear la tarjeta";
            }
        }

        public string BorrarTarjeta(Tarjeta tarjeta)
        {
            try
            {
                var tarjetaEncontrada = tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
                if (tarjetaEncontrada != null)
                {
                    tarjetas.Remove(tarjetaEncontrada);
                    return "Tarjeta eliminada correctamente";
                }
                else
                    return "Tarjeta no encontrada";
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar la tarjeta";
            }
        }
    }
}
