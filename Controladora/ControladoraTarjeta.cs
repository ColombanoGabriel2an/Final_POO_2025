using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
    public class ControladoraTarjeta
    {
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
        }

        public List<Tarjeta> ListarTarjetas()
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Tarjetas.Include(t => t.Titular).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Tarjeta>();
            }
        }

        public string CrearTarjeta(Tarjeta tarjeta, Persona titular)
        {
            try
            {
                using (var context = new Context())
                {
                    var personaEncontrada = context.Personas.FirstOrDefault(p => p.PersonaId == titular.PersonaId);

                    if (personaEncontrada == null)
                        return "El titular no existe";

                    tarjeta.Titular = personaEncontrada;
                    tarjeta.PersonaId = personaEncontrada.PersonaId;

                    // Para tarjetas de crédito, también configurar TenedorId y Tenedor
                    if (tarjeta is TarjetaCredito tarjetaCredito)
                    {
                        tarjetaCredito.TenedorId = personaEncontrada.PersonaId;
                        tarjetaCredito.Tenedor = personaEncontrada;
                    }

                    context.Tarjetas.Add(tarjeta);
                    context.SaveChanges();

                    return "Tarjeta creada correctamente";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al crear la tarjeta: {ex.Message}";
            }
        }

        public string BorrarTarjeta(Tarjeta tarjeta)
        {
            try
            {
                using (var context = new Context())
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
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al eliminar la tarjeta: {ex.Message}";
            }
        }

        public string ActualizarTarjeta(Tarjeta tarjeta)
        {
            try
            {
                using (var context = new Context())
                {
                    var tarjetaExistente = context.Tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
                    if (tarjetaExistente != null)
                    {
                        tarjetaExistente.Numero = tarjeta.Numero;
                        tarjetaExistente.FechaVencimiento = tarjeta.FechaVencimiento;
                        tarjetaExistente.Banco = tarjeta.Banco;
                        tarjetaExistente.EntidadEmisora = tarjeta.EntidadEmisora;
                        tarjetaExistente.Alias = tarjeta.Alias;

                        if (tarjetaExistente is TarjetaDebito tdExistente && tarjeta is TarjetaDebito tdNueva)
                        {
                            tdExistente.Saldo = tdNueva.Saldo;
                        }
                        else if (tarjetaExistente is TarjetaCredito tcExistente && tarjeta is TarjetaCredito tcNueva)
                        {
                            tcExistente.Limite = tcNueva.Limite;
                            tcExistente.Disponible = tcNueva.Disponible;
                            tcExistente.IsExtension = tcNueva.IsExtension;
                            tcExistente.Tenedor = tcNueva.Tenedor;
                        }

                        context.SaveChanges();
                        return "Tarjeta actualizada correctamente";
                    }
                    else
                    {
                        return "Tarjeta no encontrada";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al actualizar la tarjeta: {ex.Message}";
            }
        }

        // Obtener tarjeta por ID
        public Tarjeta? ObtenerTarjetaPorId(int tarjetaId)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Tarjetas.Include(t => t.Titular).FirstOrDefault(t => t.TarjetaId == tarjetaId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
