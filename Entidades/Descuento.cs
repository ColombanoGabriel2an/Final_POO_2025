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
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal MontoMinimo { get; set; }
        public string Tipo { get; set; }
        public string EntidadBancaria { get; set; }
        public bool Activo { get; set; }
        public bool Acumulable { get; set; }

        // Campos originales para mantener compatibilidad
        public decimal MontoFijo { get; set; }
        public decimal TopeReintegro { get; set; }
        public string Banco { get; set; }
        public string Emisor { get; set; }
        public string Rubro { get; set; }

        public Descuento()
        {
            Activo = true;
            FechaInicio = DateTime.Today;
            FechaFin = DateTime.Today.AddDays(30);
        }

        public Descuento(string descripcion, DateTime fechaInicio, DateTime fechaFin, decimal porcentaje,
            decimal montoFijo, decimal topeReintegro, string banco, string emisor, string rubro)
        {
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Porcentaje = porcentaje;
            MontoFijo = montoFijo;
            TopeReintegro = topeReintegro;
            Banco = banco;
            EntidadBancaria = banco; // Sincronizar con el nuevo campo
            Emisor = emisor;
            Rubro = rubro;
            Activo = true;
        }

        public bool EsValido(DateTime fecha)
        {
            return fecha >= FechaInicio && fecha <= FechaFin && Activo;
        }
    }
}
