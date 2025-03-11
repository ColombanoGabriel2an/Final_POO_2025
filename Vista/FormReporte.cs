    using System;
    using System.Linq;
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
                // Cargar el reporte de acreditaciones al cargar el formulario
                CargarReporteAcreditaciones();
            }

            private void CargarReporteAcreditaciones()
            {
                try
                {
                    // Obtener las acreditaciones con sus tarjetas y descuentos asociados
                    //var acreditaciones = ControladoraAcreditacion.Instancia.ListarAcreditacionesConTarjetasYDescuentos();

                    // Asignar la lista de datos al DataGridView
                    //dgvReporte.DataSource = acreditaciones;

                    // Ajustar columnas
                    AjustarColumnas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void AjustarColumnas()
            {
                // Comprobar que las columnas estén disponibles antes de intentar ajustar sus propiedades
                if (dgvReporte.Columns.Count > 0)
                {
                    // Ajustar el tamaño de las columnas si están presentes en el DataGridView
                    dgvReporte.Columns[0].Width = 100;  // Fecha
                    dgvReporte.Columns[1].Width = 150;  // Descripción
                    dgvReporte.Columns[2].Width = 80;   // Monto
                    dgvReporte.Columns[3].Width = 150;  // Tarjeta
                    dgvReporte.Columns[4].Width = 150;  // Descuento
                }
            }

            private void btnCerrar_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
