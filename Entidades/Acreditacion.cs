using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Acreditacion
    {
        public int AcreditacionId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string MedioDePago { get; set; }

        public Acreditacion() { }

        public Acreditacion(Tarjeta tarjeta, DateTime fecha, string descripcion, decimal monto, string medioDePago)
        {
            Tarjeta = tarjeta;
            Fecha = fecha;
            Descripcion = descripcion;
            Monto = monto;
            MedioDePago = medioDePago;
        }

        // ---------------------------------------------------
        public int TarjetaId { get; set; }
        public bool ProcesarAcreditacion()
        {
            if (Tarjeta is TarjetaDebito td)
            {
                td.Saldo += Monto;
                return true;
            }
            else if (Tarjeta is TarjetaCredito tc)
            {
                tc.Disponible += Monto;
                return true;
            }
            return false;
        }

        public string ObtenerInformacionResumen()
        {
            return $"{Fecha.ToShortDateString()} | {Descripcion} | ${Monto:F2} | {MedioDePago}";
        }

    }

}
