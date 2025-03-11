using Entidades;

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

        public void ActualizarTarjeta(Tarjeta tarjeta)
        {
            var tarjetaExistente = tarjetas.FirstOrDefault(t => t.TarjetaId == tarjeta.TarjetaId);
            if (tarjetaExistente != null)
            {
                int indice = tarjetas.IndexOf(tarjetaExistente);
                tarjetas[indice] = tarjeta;
            }
        }


        public void PrecargarTarjetas()
        {
            var persona1 = ControladoraPersona.Instancia.ListarPersonas().First(p => p.PersonaId == 1);
            var persona2 = ControladoraPersona.Instancia.ListarPersonas().First(p => p.PersonaId == 2);
            var persona3 = ControladoraPersona.Instancia.ListarPersonas().First(p => p.PersonaId == 3);
            var persona4 = ControladoraPersona.Instancia.ListarPersonas().First(p => p.PersonaId == 4);

            ControladoraTarjeta.Instancia.CrearTarjeta(new TarjetaDebito("1111222233334444", new DateTime(2026, 12, 31), "Banco BBVA", "VISA", persona1, "BBVA Mati", 100000), persona1);
            ControladoraTarjeta.Instancia.CrearTarjeta(new TarjetaCredito("5555666677778888", new DateTime(2028, 10, 01), "Banco Macro", "Mastercard", persona2, "Macro Mati", true, persona2, 1000000, 500000), persona2);
            ControladoraTarjeta.Instancia.CrearTarjeta(new TarjetaCredito("1234123412341234", new DateTime(2027, 01, 01), "Banco Santander", "VISA", persona3, "VISA Gabi", false, persona3, 1500000, 1200000), persona3);
            ControladoraTarjeta.Instancia.CrearTarjeta(new TarjetaDebito("567856785678", new DateTime(2030, 02, 02), "Banco BBVA", "Mastercard", persona4, "Naranja Pedro", 200000), persona4);
            ControladoraTarjeta.Instancia.CrearTarjeta(new TarjetaCredito("5555666677778888", new DateTime(2028, 10, 01), "Banco BBVA", "Mastercard", persona1, "BBVA MC Mati", true, persona1, 1000000, 500000), persona1);
        }
    }
}