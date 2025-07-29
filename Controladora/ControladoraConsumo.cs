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

                    // Validar que los campos requeridos estén completos
                    if (string.IsNullOrEmpty(consumo.Descripcion))
                        return "La descripción es requerida";
                    if (string.IsNullOrEmpty(consumo.Moneda))
                        return "La moneda es requerida";
                    if (string.IsNullOrEmpty(consumo.Hora))
                        return "La hora es requerida";

                    // Configurar la tarjeta
                    consumo.Tarjeta = tarjetaEncontrada;
                    consumo.TarjetaId = tarjetaEncontrada.TarjetaId;

                    // Manejar descuentos aplicados si los hay
                    if (consumo.DescuentosAplicados?.Any() == true)
                    {
                        var descuentosValidos = new List<Descuento>();
                        foreach (var descuento in consumo.DescuentosAplicados.ToList())
                        {
                            // Buscar el descuento existente en la base de datos
                            var descuentoExistente = context.Descuentos
                                .FirstOrDefault(d => d.DescuentoId == descuento.DescuentoId);
                            
                            if (descuentoExistente != null)
                            {
                                descuentosValidos.Add(descuentoExistente);
                            }
                        }
                        
                        // Limpiar la lista original y agregar los descuentos existentes
                        consumo.DescuentosAplicados.Clear();
                        foreach (var descuento in descuentosValidos)
                        {
                            consumo.DescuentosAplicados.Add(descuento);
                        }
                    }

                    context.Consumos.Add(consumo);
                    context.SaveChanges();

                    return $"Consumo registrado para la tarjeta {tarjetaEncontrada.Numero}";
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                // Error específico de base de datos
                var innerException = dbEx.InnerException?.Message ?? "Sin detalles adicionales";
                return $"Error de base de datos: {dbEx.Message}. Detalles: {innerException}";
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

        // Obtener todos los descuentos disponibles
        public List<Descuento> ListarDescuentos()
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Descuentos.Where(d => d.Activo).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Descuento>();
            }
        }
    }
}