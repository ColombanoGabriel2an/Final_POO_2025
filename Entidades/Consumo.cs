using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consumo
    {
        public int ID { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripción { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public List<Descuento> DescuentosAplicados { get; set; }

        public Consumo(Tarjeta tarjeta, DateTime fecha, string hora, string descripción, decimal monto, string moneda)
        {
            Tarjeta = tarjeta;
            Fecha = fecha;
            Hora = hora;
            Descripción = descripción;
            Monto = monto;
            Moneda = moneda;
            DescuentosAplicados = new List<Descuento>();
        }

        public void AplicarDescuento(Descuento descuento)
        {
            if (descuento.EsVálido(Fecha) && !DescuentosAplicados.Contains(descuento))
            {
                DescuentosAplicados.Add(descuento);
            }
        }

        public decimal CalcularMontoFinal()
        {
            decimal montoFinal = Monto;
            foreach (var descuento in DescuentosAplicados)
            {
                if (descuento.Porcentaje > 0)
                {
                    montoFinal -= Monto * (descuento.Porcentaje / 100);
                }
                else
                {
                    montoFinal -= descuento.MontoFijo;
                }
            }
            return montoFinal;
        }
    }

}
