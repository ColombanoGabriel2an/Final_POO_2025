using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
    public class ControladoraConsumo
    {
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
        }

        public List<Consumo> ListarConsumos()
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Consumos
                        .Include(c => c.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .Include(c => c.DescuentosAplicados)
                        .ToList();
                }
            }
            catch (Exception)
            {
                return new List<Consumo>();
            }
        }

        public string CrearConsumo(Consumo consumo, Tarjeta tarjeta)
        {
            try
            {
                using (var context = new Context())
                {
                    var tarjetaEncontrada = context.Tarjetas
                        .Include(t => t.Titular)
                        .FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);

                    if (tarjetaEncontrada == null)
                        return "La tarjeta no existe";

                    consumo.Tarjeta = tarjetaEncontrada;
                    context.Consumos.Add(consumo);
                    context.SaveChanges();
                    
                    return $"Consumo registrado para la tarjeta {tarjetaEncontrada.Numero}";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al crear el consumo: {ex.Message}";
            }
        }

        public string BorrarConsumo(Consumo consumo)
        {
            try
            {
                using (var context = new Context())
                {
                    var consumoEncontrado = context.Consumos
                        .FirstOrDefault(c => c.ConsumoId == consumo.ConsumoId);

                    if (consumoEncontrado != null)
                    {
                        context.Consumos.Remove(consumoEncontrado);
                        context.SaveChanges();
                        return "Consumo eliminado correctamente";
                    }
                    else
                        return "Consumo no encontrado";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al eliminar el consumo: {ex.Message}";
            }
        }

        // Obtener consumo por ID
        public Consumo? ObtenerConsumoPorId(int consumoId)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Consumos
                        .Include(c => c.Tarjeta)
                        .ThenInclude(t => t.Titular)
                        .Include(c => c.DescuentosAplicados)
                        .FirstOrDefault(c => c.ConsumoId == consumoId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void PrecargarConsumos()
        {
            try
            {
                using (var context = new Context())
                {
                    // Solo precargar si no hay datos
                    if (!context.Consumos.Any())
                    {
                        var tarjetas = context.Tarjetas.ToList();
                        if (tarjetas.Count >= 2)
                        {
                            var consumos = new List<Consumo>
                            {
                                new Consumo(tarjetas[0], new DateTime(2025, 01, 15), "12:30", "Compra en tienda de tecnología", 300, "ARG"),
                                new Consumo(tarjetas[1], new DateTime(2025, 01, 15), "14:00", "Compra en tienda de ropa", 500, "ARG")
                            };

                            context.Consumos.AddRange(consumos);
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