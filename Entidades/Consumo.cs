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
                // No calcular si el descuento no está activo o está fuera de fecha
                if (!descuento.Activo || !descuento.EsValido(Fecha))
                    continue;

                // Aplicar descuento porcentual
                if (descuento.Porcentaje > 0)
                {
                    decimal ahorro = montoFinal * (descuento.Porcentaje / 100m);

                    // Aplicar tope de reintegro si existe
                    if (descuento.TopeReintegro > 0 && ahorro > descuento.TopeReintegro)
                        ahorro = descuento.TopeReintegro;

                    montoFinal -= ahorro;
                }
                // Aplicar descuento de monto fijo
                else if (descuento.MontoFijo > 0)
                {
                    montoFinal -= descuento.MontoFijo;
                }
            }

            // Evitar montos negativos
            if (montoFinal < 0)
                montoFinal = 0;

            return montoFinal;
        }

        public int TarjetaId { get; set; }
    }
}