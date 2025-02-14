using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Acreditación
    {
        public int ID { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripción { get; set; }
        public decimal Monto { get; set; }
        public string MedioDePago { get; set; }

        public Acreditación(Tarjeta tarjeta, DateTime fecha, string descripción, decimal monto, string medioDePago)
        {
            Tarjeta = tarjeta;
            Fecha = fecha;
            Descripción = descripción;
            Monto = monto;
            MedioDePago = medioDePago;
        }
    }

}
