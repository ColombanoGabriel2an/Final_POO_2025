using System;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Controladora;

namespace Vista
{
    public partial class FormDescuento : Form
    {
        private Descuento descuentoSeleccionado = null;

        public FormDescuento()
        {
            InitializeComponent();
        }

        private void FormDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                // Preseleccionar el primer elemento de cada ComboBox
                if (cmbTipo.Items.Count > 0)
                    cmbTipo.SelectedIndex = 0;

                if (cmbEntidadBancaria.Items.Count > 0)
                    cmbEntidadBancaria.SelectedIndex = 0;

                // Cargar descuentos en el DataGridView
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarDataGridView()
        {
            List<Descuento> descuentos = ControladoraDescuento.Instancia.ListarDescuentos();

            dgvDescuentos.DataSource = null;

            // Crear una lista de objetos anónimos para mostrar solo las propiedades relevantes
            var descuentosVista = descuentos.Select(d => new
            {
                ID = d.DescuentoId,
                Código = d.Codigo,
                Nombre = d.Nombre,
                Porcentaje = d.Porcentaje,
                MontoMinimo = d.MontoMinimo,
                Activo = d.Activo ? "Sí" : "No",
                FechaInicio = d.FechaInicio.ToShortDateString(),
                FechaFin = d.FechaFin.ToShortDateString(),
            }).ToList();

            dgvDescuentos.DataSource = descuentosVista;

            // Ajustar columnas
            if (dgvDescuentos.Columns.Count > 0)
            {
                dgvDescuentos.Columns["ID"].Width = 40;
                dgvDescuentos.Columns["Código"].Width = 80;
                dgvDescuentos.Columns["Nombre"].Width = 150;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Guardar el descuento
                string resultado = ControladoraDescuento.Instancia.CrearDescuento(descuento);
                MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar el DataGridView
                ActualizarDataGridView();

                // Limpiar el formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el descuento: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDescuentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Seleccionar el descuento
                int id = Convert.ToInt32(dgvDescuentos.Rows[e.RowIndex].Cells["ID"].Value);
                descuentoSeleccionado = ControladoraDescuento.Instancia.ListarDescuentos()
                    .FirstOrDefault(d => d.DescuentoId == id);

                // Mostrar sus datos en el formulario
                CargarDatosDescuento(descuentoSeleccionado);
            }
        }

        private void CargarDatosDescuento(Descuento descuento)
        {
            if (descuento != null)
            {
                txtCodigo.Text = descuento.Codigo;
                txtNombre.Text = descuento.Nombre;
                txtDescripcion.Text = descuento.Descripcion;
                nudPorcentaje.Value = descuento.Porcentaje;
                dtpFechaInicio.Value = descuento.FechaInicio;
                dtpFechaFin.Value = descuento.FechaFin;
                cmbTipo.SelectedItem = descuento.Tipo;
                cmbEntidadBancaria.SelectedItem = descuento.EntidadBancaria;
                nudMontoMinimo.Value = descuento.MontoMinimo;
                chkActivo.Checked = descuento.Activo;
                chkAcumulable.Checked = descuento.Acumulable;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            nudPorcentaje.Value = 10;
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today.AddDays(30);
            cmbTipo.SelectedIndex = 0;
            cmbEntidadBancaria.SelectedIndex = 0;
            nudMontoMinimo.Value = 0;
            chkActivo.Checked = true;
            chkAcumulable.Checked = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
