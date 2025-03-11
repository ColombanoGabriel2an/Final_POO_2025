﻿using Entidades;


namespace Controladora
{
    public class ControladoraConsumo
    {
        private List<Consumo> consumos;
        private static ControladoraConsumo? instancia;

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
            consumos = new List<Consumo>();
        }

        public List<Consumo> ListarConsumos()
        {
            return consumos;
        }

        public string CrearConsumo(Consumo consumo, Tarjeta tarjeta)
        {
            try
            {
                var tarjetaEncontrada = ControladoraTarjeta.Instancia.ListarTarjetas()
                    .FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);

                if (tarjetaEncontrada == null)
                    return "La tarjeta no existe";

                // Generar ID si es necesario
                if (consumo.ConsumoId <= 0)
                {
                    consumo.ConsumoId = consumos.Count > 0
                        ? consumos.Max(c => c.ConsumoId) + 1 : 1;
                }

                consumo.Tarjeta = tarjetaEncontrada;
                consumos.Add(consumo);
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
                var consumoEncontrado = consumos
                    .FirstOrDefault(c => c.ConsumoId == consumo.ConsumoId);

                if (consumoEncontrado != null)
                {
                    consumos.Remove(consumoEncontrado);
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