using Entidades;

namespace Controladora
{
    public class ControladoraAcreditacion
    {
        private List<Acreditacion> acreditaciones;
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
            acreditaciones = new List<Acreditacion>();
        }

        public List<Acreditacion> ListarAcreditaciones()
        {
            return acreditaciones;
        }

        public string CrearAcreditacion(Acreditacion acreditacion, Tarjeta tarjeta)
        {
            try
            {
                var tarjetaEncontrada = ControladoraTarjeta.Instancia.ListarTarjetas()
                    .FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);

                if (tarjetaEncontrada == null)
                    return "La tarjeta no existe";

                // Generar ID si es necesario
                if (acreditacion.AcreditacionId <= 0)
                {
                    acreditacion.AcreditacionId = acreditaciones.Count > 0
                        ? acreditaciones.Max(a => a.AcreditacionId) + 1 : 1;
                }

                // Asocia la tarjeta encontrada a la acreditación
                acreditacion.Tarjeta = tarjetaEncontrada;

                // Aquí lógica para actualizar saldos, etc.
                acreditaciones.Add(acreditacion);
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
                var acreditacionEncontrada = acreditaciones
                    .FirstOrDefault(a => a.AcreditacionId == acreditacion.AcreditacionId);

                if (acreditacionEncontrada != null)
                {
                    acreditaciones.Remove(acreditacionEncontrada);
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