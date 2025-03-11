using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consumo
    {
        public int ConsumoId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public List<Descuento> DescuentosAplicados { get; set; } = new List<Descuento>();

        public Consumo() { }
        public Consumo(Tarjeta tarjeta, DateTime fecha, string hora, string descripcion, decimal monto, string moneda)
        {
            Tarjeta = tarjeta;
            Fecha = fecha;
            Hora = hora;
            Descripcion = descripcion;
            Monto = monto;
            Moneda = moneda;
        }

        public void AplicarDescuento(Descuento descuento)
        {
            if (descuento.EsValido(Fecha) && !DescuentosAplicados.Contains(descuento))
            {
                DescuentosAplicados.Add(descuento);
            }
        }

        public decimal CalcularMontoFinal()
        {
            decimal montoFinal = Monto;
            decimal ahorroTotal = 0;

            foreach (var descuento in DescuentosAplicados)
            {
                decimal ahorroDescuento = 0;

                if (!descuento.EsValido(Fecha))
                    continue;

                if (Monto < descuento.MontoMinimo)
                    continue;

                if (descuento.Porcentaje > 0)
                {
                    ahorroDescuento = Monto * (descuento.Porcentaje / 100m);

                    if (descuento.TopeReintegro > 0 && ahorroDescuento > descuento.TopeReintegro)
                        ahorroDescuento = descuento.TopeReintegro;
                }
                else if (descuento.MontoFijo > 0)
                {
                    ahorroDescuento = descuento.MontoFijo;


                    if (descuento.TopeReintegro > 0 && ahorroDescuento > descuento.TopeReintegro)
                        ahorroDescuento = descuento.TopeReintegro;
                }

                ahorroTotal += ahorroDescuento;
            }


            montoFinal -= ahorroTotal;


            if (montoFinal < 0)
                montoFinal = 0;

            return montoFinal;
        }


        public int TarjetaId { get; set; }
    }
}
