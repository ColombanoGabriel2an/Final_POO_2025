using Controladora;
using Modelo;
using Microsoft.EntityFrameworkCore;
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
            // Asegurar que la base de datos esté creada y actualizada
            try
            {
                using (var context = new Context())
                {
                    context.Database.EnsureCreated();
                    // Si quieres usar migraciones en lugar de EnsureCreated(), usa:
                    // context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
