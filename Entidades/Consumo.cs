public class Consumo
{
    // Propiedades básicas
    public int ConsumoId { get; set; }
    public int TarjetaId { get; set; }
    public virtual Tarjeta Tarjeta { get; set; }
    public DateTime Fecha { get; set; }
    public string Hora { get; set; }
    public string Descripcion { get; set; }
    public string Vendedor { get; set; }
    public string Rubro { get; set; }
    public decimal Monto { get; set; }
    public string Moneda { get; set; }
    public bool IsRecurrente { get; set; }
    public virtual List<Descuento> DescuentosAplicados { get; set; } = new List<Descuento>();

    // Constructor vacío para Entity Framework
    public Consumo() { }

    // Constructor principal
    public Consumo(Tarjeta tarjeta, DateTime fecha, string hora, string descripcion,
                  string vendedor, string rubro, decimal monto, string moneda,
                  bool isRecurrente = false)
    {
        Tarjeta = tarjeta;
        TarjetaId = tarjeta.TarjetaId;
        Fecha = fecha;
        Hora = hora;
        Descripcion = descripcion;
        Vendedor = vendedor;
        Rubro = rubro;
        Monto = monto;
        Moneda = moneda;
        IsRecurrente = isRecurrente;
    }

    // Método simple para agregar un descuento
    public void AplicarDescuento(Descuento descuento)
    {
        if (!DescuentosAplicados.Contains(descuento))
        {
            DescuentosAplicados.Add(descuento);
        }
    }

    // Método para calcular el monto final con descuentos
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

    // Método para mostrar en Windows Forms
    public string ObtenerInformacionResumen()
    {
        return $"{Fecha.ToShortDateString()} - {Vendedor} - ${Monto}";
    }

    public decimal CalcularMontoFinal()
    {
        decimal montoFinal = Monto;
        foreach (var descuento in DescuentosAplicados)
        {
            decimal descuentoAplicado;
            if (descuento.Porcentaje > 0)
            {
                descuentoAplicado = Math.Min(Monto * (descuento.Porcentaje / 100), descuento.TopeMonto);
            }
            else
            {
                descuentoAplicado = Math.Min(descuento.MontoFijo, descuento.TopeMonto);
            }
            montoFinal -= descuentoAplicado;
        }
        return montoFinal;
    }

    public bool ValidarConsumo()
    {
        return Tarjeta.ValidarTransaccion(Monto);
    }

    public string ObtenerInformacionResumen()
    {
        return $"{Fecha.ToShortDateString()} {Hora} | {Vendedor} | {Rubro} | ${Monto:F2} | Final: ${CalcularMontoFinal():F2}";
    }

    public Consumo CrearConsumoRecurrente(DateTime nuevaFecha, decimal nuevoMonto)
    {
        return new Consumo(Tarjeta, nuevaFecha, Hora, Descripcion, Vendedor, Rubro, nuevoMonto, Moneda, true);
    }
}