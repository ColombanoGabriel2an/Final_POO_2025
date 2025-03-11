using System;
using System.Linq;
using System.Windows.Forms;
using Controladora;
using Entidades;

namespace Vista
{
    public partial class FormAcreditacion : Form
    {
        public FormAcreditacion()
        {
            InitializeComponent();
        }

        private void FormAcreditacion_Load(object sender, EventArgs e)
        {
            // Cargar tarjetas en el ComboBox
            CargarTarjetas();
        }

        private void CargarTarjetas()
        {
            var tarjetas = ControladoraTarjeta.Instancia.ListarTarjetas();
            cmbTarjetas.DataSource = tarjetas;
            cmbTarjetas.DisplayMember = "Alias";
            cmbTarjetas.ValueMember = "TarjetaId";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrEmpty(txtDescripcion.Text) || nudMonto.Value <= 0)
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una nueva acreditación
                var acreditacion = new Acreditacion
                {
                    AcreditacionId = ControladoraAcreditacion.Instancia.GenerarIdAcreditacion(), // Se generará automáticamente
                    Fecha = dtpFecha.Value,
                    Descripcion = txtDescripcion.Text,
                    Monto = nudMonto.Value,
                    TarjetaId = (int)cmbTarjetas.SelectedValue
                };

                // Guardar la acreditación
                //string resultado = ControladoraAcreditacion.Instancia.CrearAcreditacion(acreditacion);
                //MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la acreditación: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Clear();
            nudMonto.Value = 0;
            cmbTarjetas.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Lógica para borrar una acreditación si es necesario
            // Por ejemplo, buscar por ID o número de acreditación y eliminarlo de la lista
        }
    }
}
