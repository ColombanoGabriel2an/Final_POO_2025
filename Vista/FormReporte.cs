using System;
using System.Windows.Forms;
using Controladora;

namespace Vista
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            // Cargar el reporte de acreditaciones con tarjetas y descuentos al cargar el formulario
            CargarReporteAcreditaciones();
        }

        private void CargarReporteAcreditaciones()
        {
            try
            {
                // Obtener las acreditaciones con sus tarjetas y descuentos asociados desde ServicioReporte
                //var acreditaciones = ServicioReporte.Instancia.ListarAcreditacionesConTarjetasYDescuentos(DateTime.Now.AddMonths(-1), DateTime.Now); // Ejemplo de rango de fechas

                // Asignar la lista de datos al DataGridView
               // dgvReporte.DataSource = acreditaciones;

                // Ajustar columnas para una mejor visualización
                //AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarColumnas()
        {
            // Ajuste de columnas de DataGridView
            if (dgvReporte.Columns.Count > 0)
            {
                dgvReporte.Columns["Fecha"].Width = 100;
                dgvReporte.Columns["Descripcion"].Width = 200;
                dgvReporte.Columns["Monto"].Width = 100;
                dgvReporte.Columns["Tarjeta"].Width = 150;
                dgvReporte.Columns["Descuento"].Width = 150;

                // Formato para el campo Fecha
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
