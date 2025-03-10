using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controladora
{
    public class ServicioReporte
    {
        private readonly Context _context;

        // Se inyecta el contexto en el constructor
        public ServicioReporte(Context context)
        {
            _context = context;
        }

        // Reporte de consumos por tarjeta en un rango de fechas
        public List<Consumo> GenerarReportePorTarjeta(int tarjetaId, DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Consumos
                .Where(c => c.TarjetaId == tarjetaId && c.Fecha >= fechaInicio && c.Fecha <= fechaFin)
                .Include(c => c.Tarjeta)
                .ToList();
        }

        // Reporte general de consumos en un rango de fechas
        public List<Consumo> GenerarReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Consumos
                .Where(c => c.Fecha >= fechaInicio && c.Fecha <= fechaFin)
                .Include(c => c.Tarjeta)
                .ToList();
        }
    }
}