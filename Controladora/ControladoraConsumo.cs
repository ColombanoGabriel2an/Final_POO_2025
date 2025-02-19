using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraConsumo
    {
        private Context context;
        private static ControladoraConsumo instancia;

        public static ControladoraConsumo Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraConsumo();
                }
                return instancia;
            }
        }

        private ControladoraConsumo()
        {
            context = new Context();
        }

        public List<Consumo> ListarConsumos()
        {
            return context.Consumos.Include(c => c.Tarjeta).ToList();
        }

        public string CrearConsumo(Consumo consumo, Tarjeta tarjeta)
        {
            try
            {
                var tarjetaEncontrada = context.Tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
                if (tarjetaEncontrada == null)
                    return "La tarjeta no existe";

                consumo.Tarjeta = tarjetaEncontrada;
                // Aquí podrías aplicar validaciones y calcular descuentos si es necesario.
                context.Consumos.Add(consumo);
                context.SaveChanges();
                return $"Consumo registrado para la tarjeta {tarjetaEncontrada.Numero}";
            }
            catch (Exception)
            {
                return "Ocurrió un error al crear el consumo";
            }
        }

        public string BorrarConsumo(Consumo consumo)
        {
            try
            {
                var consumoEncontrado = context.Consumos.FirstOrDefault(c => c.ConsumoId == consumo.ConsumoId);
                if (consumoEncontrado != null)
                {
                    context.Consumos.Remove(consumoEncontrado);
                    context.SaveChanges();
                    return "Consumo eliminado correctamente";
                }
                else
                    return "Consumo no encontrado";
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar el consumo";
            }
        }
    }
}
