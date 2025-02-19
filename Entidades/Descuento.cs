using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Descuento
    {
        public int DescuentoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal MontoFijo { get; set; }
        public decimal TopeMonto { get; set; }
        public string Banco { get; set; }
        public string Emisor { get; set; }
        public string Rubro { get; set; }

        public Descuento(string descripcion, DateTime fechaInicio, DateTime fechaFin, decimal porcentaje, decimal montoFijo, decimal topeMonto, string banco, string emisor, string rubro)
        {
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Porcentaje = porcentaje;
            MontoFijo = montoFijo;
            TopeMonto = topeMonto;
            Banco = banco;
            Emisor = emisor;
            Rubro = rubro;
        }

        public bool EsValido(DateTime fecha)
        {
            return fecha >= FechaInicio && fecha <= FechaFin;
        }
    }

}
