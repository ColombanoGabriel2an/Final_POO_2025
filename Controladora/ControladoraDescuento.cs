using Entidades;

namespace Controladora
{
    public class ControladoraDescuento
    {
        private List<Descuento> descuentos;
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
            descuentos = new List<Descuento>();
        }

        public List<Descuento> ListarDescuentos()
        {
            return descuentos;
        }

        public string CrearDescuento(Descuento descuento)
        {
            try
            {
                if (descuento.DescuentoId <= 0)
                {
                    descuento.DescuentoId = descuentos.Count > 0
                        ? descuentos.Max(d => d.DescuentoId) + 1 : 1;
                }

                descuentos.Add(descuento);
                return $"Descuento '{descuento.Descripcion}' creado correctamente";
            }
            catch (Exception)
            {
                return "Ocurrió un error al crear el descuento";
            }
        }

        public string BorrarDescuento(Descuento descuento)
        {
            try
            {
                var descuentoEncontrado = descuentos.FirstOrDefault(d => d.DescuentoId == descuento.DescuentoId);
                if (descuentoEncontrado != null)
                {
                    descuentos.Remove(descuentoEncontrado);
                    return "Descuento eliminado correctamente";
                }
                else
                    return "Descuento no encontrado";
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar el descuento";
            }
        }

        public void PrecargarDescuentos()
        {
            ControladoraDescuento.Instancia.CrearDescuento(new Descuento("Descuento del 10%", new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), 10, 0, 0, "Banco Nación", "Emisor", "Electrónica"));
            ControladoraDescuento.Instancia.CrearDescuento(new Descuento("Descuento del 20%", new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), 20, 0, 0, "BBVA", "Emisor", "Ropa"));
            ControladoraDescuento.Instancia.CrearDescuento(new Descuento("12 Cuotas sin interés", new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), 0, 0, 0, "Cabal", "Emisor", "Muebles"));
            ControladoraDescuento.Instancia.CrearDescuento(new Descuento("Promo 15%", new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), 15, 0, 0, "Macro", "Emisor", "Automóvil"));
        }

    }
}
