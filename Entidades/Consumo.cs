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

        // ---------------------------------------------------
        public int TarjetaId { get; set; }

        // Lista de descuentos aplicados (modelo simple; si fuera many-to-many, se necesitaria una tabla intermedia)
    }
}

