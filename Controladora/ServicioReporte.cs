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
        private static ServicioReporte? instancia;

        public static ServicioReporte Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ServicioReporte();
                }
                return instancia;
            }
        }

        // Reporte de consumos por tarjeta en un rango de fechas
        public List<Consumo> GenerarReportePorTarjeta(int tarjetaId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Consumo> resultado = new List<Consumo>();
            List<Consumo> todosLosConsumos = ControladoraConsumo.Instancia.ListarConsumos();

            foreach (var consumo in todosLosConsumos)
            {
                if (consumo.Tarjeta.TarjetaId == tarjetaId &&
                    consumo.Fecha >= fechaInicio &&
                    consumo.Fecha <= fechaFin)
                {
                    resultado.Add(consumo);
                }
            }

            return resultado;
        }

        // Reporte general de consumos en un rango de fechas
        public List<Consumo> GenerarReportePorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Consumo> resultado = new List<Consumo>();
            List<Consumo> todosLosConsumos = ControladoraConsumo.Instancia.ListarConsumos();

            foreach (var consumo in todosLosConsumos)
            {
                if (consumo.Fecha >= fechaInicio && consumo.Fecha <= fechaFin)
                {
                    resultado.Add(consumo);
                }
            }

            return resultado;
        }

        // Método adicional para generar reporte de acreditaciones por tarjeta
        public List<Acreditacion> GenerarReporteAcreditacionesPorTarjeta(int tarjetaId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Acreditacion> resultado = new List<Acreditacion>();
            List<Acreditacion> todasLasAcreditaciones = ControladoraAcreditacion.Instancia.ListarAcreditaciones();

            foreach (var acreditacion in todasLasAcreditaciones)
            {
                if (acreditacion.Tarjeta.TarjetaId == tarjetaId &&
                    acreditacion.Fecha >= fechaInicio &&
                    acreditacion.Fecha <= fechaFin)
                {
                    resultado.Add(acreditacion);
                }
            }

            return resultado;
        }
    }
}