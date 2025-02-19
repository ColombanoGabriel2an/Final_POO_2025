using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Tarjeta
    {
        public int TarjetaId { get; set; }
        public string Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Banco { get; set; }
        public string EntidadEmisora { get; set; }
        public Persona Titular { get; set; }
        public string Alias { get; set; }

        protected Tarjeta(string numero, DateTime fechaVencimiento, string banco, string entidadEmisora, Persona titular, string alias)
        {
            Numero = numero;
            FechaVencimiento = fechaVencimiento;
            Banco = banco;
            EntidadEmisora = entidadEmisora;
            Titular = titular;
            Alias = alias;
        }
    }

    public class TarjetaDebito : Tarjeta
    {
        public decimal Saldo { get; set; }

        public TarjetaDebito(string numero, DateTime fechaVencimiento, string banco, string entidadEmisora, Persona titular, string alias, decimal saldo)
            : base(numero, fechaVencimiento, banco, entidadEmisora, titular, alias)
        {
            Saldo = saldo;
        }
    }

    public class TarjetaCredito : Tarjeta
    {
        public decimal Limite { get; set; }
        public decimal Disponible { get; set; }
        public bool IsExtension { get; set; }
        public Persona Tenedor { get; set; }

        public TarjetaCredito(string numero, DateTime fechaVencimiento, string banco, string entidadEmisora, Persona titular, string alias, bool isExtension, Persona tenedor, decimal limite, decimal disponible)
            : base(numero, fechaVencimiento, banco, entidadEmisora, titular, alias)
        {
            IsExtension = isExtension;
            Tenedor = tenedor;
            Limite = limite;
            Disponible = disponible;
        }

        // ---------------------------------------------------
        public int PersonaId { get; set; }

        // Relaciones con Acreditaciones y Consumos
        public virtual ICollection<Acreditacion> Acreditaciones { get; set; } = new List<Acreditacion>();
        public virtual ICollection<Consumo> Consumos { get; set; } = new List<Consumo>();
    }
}

}
