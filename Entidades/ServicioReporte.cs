using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ServicioReporte
    {
        public List<Consumo> GenerarReportePorTarjeta(Tarjeta tarjeta, DateTime desde, DateTime hasta)
        {
            var consumos = RepositorioConsumo.Listar();
            return consumos.Where(c => c.Tarjeta.ID == tarjeta.ID && c.Fecha >= desde && c.Fecha <= hasta).ToList();
        }

        public List<Consumo> GenerarReportePorFecha(DateTime desde, DateTime hasta)
        {
            var consumos = RepositorioConsumo.Listar();
            return consumos.Where(c => c.Fecha >= desde && c.Fecha <= hasta).ToList();
        }
    }

}
