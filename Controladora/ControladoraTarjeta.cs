using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraTarjeta
    {
        private Context context;
        private static ControladoraTarjeta instancia;

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
            context = new Context();
        }

        public List<Tarjeta> ListarTarjetas()
        {
            return context.Tarjetas.Include(t => t.Titular).ToList();
        }

        public string CrearTarjeta(Tarjeta tarjeta, Persona titular)
        {
            try
            {
                var personaEncontrada = context.Personas.FirstOrDefault(p => p.PersonaId == titular.PersonaId);
                if (personaEncontrada == null)
                    return "El titular no existe";

                tarjeta.Titular = personaEncontrada;
                context.Tarjetas.Add(tarjeta);
                context.SaveChanges();
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
            catch (Exception)
            {
                return "Ocurrió un error al eliminar la tarjeta";
            }
        }
    }
}
