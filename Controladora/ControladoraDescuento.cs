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
            Descuento descuento1 = new Descuento
            {
                Codigo = "SUPER30",
                Nombre = "Miércoles de descuentos",
                Descripcion = "30% los miércoles en supermercados",
                FechaInicio = new DateTime(2025, 01, 01),
                FechaFin = new DateTime(2025, 06, 30),
                Porcentaje = 30,
                MontoFijo = 0,
                TopeReintegro = 3000,
                Banco = "Banco Santander",
                Emisor = "VISA",
                Rubro = "Supermercados",
                Tipo = "Porcentual",
                Activo = true,
                Acumulable = false
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento1);

            // Restaurantes
            Descuento descuento2 = new Descuento
            {
                Codigo = "REST2X1",
                Nombre = "2x1 en Restaurantes",
                Descripcion = "2x1 en restaurantes adheridos",
                FechaInicio = new DateTime(2025, 03, 01),
                FechaFin = new DateTime(2025, 04, 30),
                Porcentaje = 50,
                MontoFijo = 0,
                TopeReintegro = 1500,
                Banco = "Banco BBVA",
                Emisor = "American Express",
                Rubro = "Restaurantes",
                Tipo = "Porcentual",
                Activo = true,
                Acumulable = false
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento2);

            // Farmacias
            Descuento descuento3 = new Descuento
            {
                Codigo = "FARM15",
                Nombre = "Descuento en Farmacias",
                Descripcion = "15% todos los días en farmacias",
                FechaInicio = new DateTime(2025, 01, 01),
                FechaFin = new DateTime(2025, 12, 31),
                Porcentaje = 15,
                MontoFijo = 0,
                TopeReintegro = 1000,
                Banco = "Banco Nación",
                Emisor = "Mastercard",
                Rubro = "Farmacias",
                Tipo = "Porcentual",
                Activo = true,
                Acumulable = true
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento3);

            // Farmacias - Monto fijo
            Descuento descuento4 = new Descuento
            {
                Codigo = "FARM500",
                Nombre = "Reintegro en Farmacias",
                Descripcion = "$500 de descuento en compras superiores a $3000",
                FechaInicio = new DateTime(2025, 03, 15),
                FechaFin = new DateTime(2025, 04, 15),
                Porcentaje = 0,
                MontoFijo = 500,
                TopeReintegro = 3000,
                Banco = "Banco BBVA",
                Emisor = "VISA",
                Rubro = "Farmacias",
                Tipo = "Monto Fijo",
                Activo = true,
                Acumulable = false
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento4);

            // Electrónica - Cuotas
            Descuento descuento5 = new Descuento
            {
                Codigo = "TECH12C",
                Nombre = "12 Cuotas Tecnología",
                Descripcion = "12 cuotas sin interés en tecnología",
                FechaInicio = new DateTime(2025, 01, 01),
                FechaFin = new DateTime(2025, 12, 31),
                Porcentaje = 0,
                MontoFijo = 0,
                MontoMinimo = 0,
                TopeReintegro = 10000,
                Banco = "Banco Santander",
                Emisor = "VISA",
                Rubro = "Electrónica",
                Tipo = "Financiación",
                Activo = true,
                Acumulable = true
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento5);

            // Electrónica - Porcentual
            Descuento descuento6 = new Descuento
            {
                Codigo = "TECH20",
                Nombre = "Descuento en Tecnología",
                Descripcion = "20% en artículos seleccionados de tecnología",
                FechaInicio = new DateTime(2025, 03, 01),
                FechaFin = new DateTime(2025, 03, 31),
                Porcentaje = 20,
                MontoFijo = 0,
                TopeReintegro = 5000,
                Banco = "Banco BBVA",
                Emisor = "Mastercard",
                Rubro = "Electrónica",
                Tipo = "Porcentual",
                Activo = true,
                Acumulable = false
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento6);

            // Indumentaria - Fines de semana
            Descuento descuento7 = new Descuento
            {
                Codigo = "ROPA30FDS",
                Nombre = "Fines de Semana de Moda",
                Descripcion = "30% en ropa los fines de semana",
                FechaInicio = new DateTime(2025, 02, 01),
                FechaFin = new DateTime(2025, 08, 31),
                Porcentaje = 30,
                MontoFijo = 0,
                TopeReintegro = 4000,
                Banco = "Banco Macro",
                Emisor = "VISA",
                Rubro = "Ropa",
                Tipo = "Porcentual",
                Activo = true,
                Acumulable = false
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento7);

            // Indumentaria - Cuotas + Descuento
            Descuento descuento8 = new Descuento
            {
                Codigo = "ROPA3C10",
                Nombre = "Cuotas + Descuento",
                Descripcion = "3 cuotas sin interés + 10% off",
                FechaInicio = new DateTime(2025, 01, 01),
                FechaFin = new DateTime(2025, 12, 31),
                Porcentaje = 10,
                MontoFijo = 0,
                MontoMinimo = 2000,
                TopeReintegro = 5000,
                Banco = "Banco Macro",
                Emisor = "Mastercard",
                Rubro = "Ropa",
                Tipo = "Mixto",
                Activo = true,
                Acumulable = true
            };
            ControladoraDescuento.Instancia.CrearDescuento(descuento8);
        }

    }
}