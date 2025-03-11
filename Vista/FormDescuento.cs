using System;
using System.Windows.Forms;
using Entidades;
using Controladora;

namespace Vista
{
    public partial class FormDescuento : Form
    {
        public FormDescuento()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            dtpFechaInicio.Value = DateTime.Today;

            dtpFechaFin.Value = DateTime.Today.AddDays(30);

            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;

            if (cmbEntidadBancaria.Items.Count > 0)
                cmbEntidadBancaria.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Debe ingresar un código de descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar un nombre para el descuento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }

                if (dtpFechaInicio.Value > dtpFechaFin.Value)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpFechaInicio.Focus();
                    return;
                }

                var descuento = new Descuento
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Porcentaje = nudPorcentaje.Value,
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value,
                    Tipo = cmbTipo.SelectedItem.ToString(),
                    EntidadBancaria = cmbEntidadBancaria.SelectedItem.ToString(),
                    MontoMinimo = nudMontoMinimo.Value,
                    Activo = chkActivo.Checked,
                    Acumulable = chkAcumulable.Checked
                };

                MessageBox.Show("Descuento guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el descuento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            nudPorcentaje.Value = 10;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(30);
            cmbTipo.SelectedIndex = 0;
            cmbEntidadBancaria.SelectedIndex = 0;
            nudMontoMinimo.Value = 0;
            chkActivo.Checked = true;
            chkAcumulable.Checked = false;
            txtCodigo.Focus();
        }
    }

}