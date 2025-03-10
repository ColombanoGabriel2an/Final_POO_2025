using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraDescuento
    {
        private Context context;
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
            context = new Context();
        }

        public List<Descuento> ListarDescuentos()
        {
            return context.Descuentos.ToList();
        }

        public string CrearDescuento(Descuento descuento)
        {
            try
            {
                // Validar fechas o condiciones específicas según lo necesites.
                context.Descuentos.Add(descuento);
                context.SaveChanges();
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
            catch (Exception)
            {
                return "Ocurrió un error al eliminar el descuento";
            }
        }
    }
}
