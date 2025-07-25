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
                        descuentoExistente.MontoMinimo = descuento.MontoMinimo;
                        descuentoExistente.FechaInicio = descuento.FechaInicio;
                        descuentoExistente.FechaFin = descuento.FechaFin;
                        descuentoExistente.Tipo = descuento.Tipo;
                        descuentoExistente.Activo = descuento.Activo;
                        descuentoExistente.Acumulable = descuento.Acumulable;

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
                        descuentoExistente.MontoMinimo = descuento.MontoMinimo;
                        descuentoExistente.FechaInicio = descuento.FechaInicio;
                        descuentoExistente.FechaFin = descuento.FechaFin;
                        descuentoExistente.Tipo = descuento.Tipo;
                        descuentoExistente.Activo = descuento.Activo;
                        descuentoExistente.Acumulable = descuento.Acumulable;

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
                        .Where(d => d.FechaInicio <= fechaActual && d.FechaFin >= fechaActual && d.Activo)
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

                    if (!descuento.Activo)
                        return "El descuento no está activo";

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

                    // Calcular nuevo monto
                    decimal montoDescuento = (consumoDb.Monto * descuento.Porcentaje) / 100;
                    if (descuento.TopeReintegro > 0 && montoDescuento > descuento.TopeReintegro)
                        montoDescuento = descuento.TopeReintegro;

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
                            new Descuento("Descuento 10%", DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(1), 10, 0, 1000, "Banco Nación", "Visa", "Supermercados")
                            {
                                Codigo = "DESC10",
                                Nombre = "Descuento 10%",
                                Tipo = "Porcentual"
                            },
                            new Descuento("Descuento 20%", DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(2), 20, 0, 2000, "Banco Galicia", "MasterCard", "Restaurantes")
                            {
                                Codigo = "DESC20",
                                Nombre = "Descuento 20%",
                                Tipo = "Porcentual"
                            },
                            new Descuento("Descuento 5%", DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(3), 5, 0, 500, "Banco Santander", "Visa", "Combustible")
                            {
                                Codigo = "DESC5",
                                Nombre = "Descuento 5%",
                                Tipo = "Porcentual"
                            }
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
