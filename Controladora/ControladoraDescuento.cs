using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
