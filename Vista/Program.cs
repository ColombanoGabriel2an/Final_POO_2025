using Controladora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Llamar a los métodos para precargar los datos
            ControladoraPersona.Instancia.PrecargarPersonas();
            ControladoraTarjeta.Instancia.PrecargarTarjetas();
            ControladoraDescuento.Instancia.PrecargarDescuentos();
            ControladoraAcreditacion.Instancia.PrecargarAcreditaciones();
            ControladoraConsumo.Instancia.PrecargarConsumos();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
