using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo; // Si tu Context se encuentra en Modelo
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraAcreditacion
    {
        private Context context;
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

        private ControladoraAcreditacion()
        {
            context = new Context();
        }

        public List<Acreditacion> ListarAcreditaciones()
        {
            return context.Acreditaciones.Include(a => a.Tarjeta).ToList();
        }

        public string CrearAcreditacion(Acreditacion acreditacion, Tarjeta tarjeta)
        {
            try
            {
                var tarjetaEncontrada = context.Tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
                if (tarjetaEncontrada == null)
                    return "La tarjeta no existe";

                // Asocia la tarjeta encontrada a la acreditación.
                acreditacion.Tarjeta = tarjetaEncontrada;

                // Aquí podrías incluir lógica para actualizar saldos, etc.
                context.Acreditaciones.Add(acreditacion);
                context.SaveChanges();
                return $"Acreditación creada para la tarjeta {tarjetaEncontrada.Numero}";
            }
            catch (Exception)
            {
                return "Ocurrió un error al crear la acreditación";
            }
        }

        public string BorrarAcreditacion(Acreditacion acreditacion)
        {
            try
            {
                var acreditacionEncontrada = context.Acreditaciones.FirstOrDefault(a => a.AcreditacionId == acreditacion.AcreditacionId);
                if (acreditacionEncontrada != null)
                {
                    context.Acreditaciones.Remove(acreditacionEncontrada);
                    context.SaveChanges();
                    return "Acreditación eliminada correctamente";
                }
                else
                    return "Acreditación no encontrada";
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar la acreditación";
            }
        }
    }
}
