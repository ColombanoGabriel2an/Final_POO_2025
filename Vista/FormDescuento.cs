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
                if (cmbBanco.Items.Count > 0)
                    cmbBanco.SelectedIndex = 0;
                if (cmbEmisor.Items.Count > 0)
                    cmbEmisor.SelectedIndex = 0;
                if (cmbRubro.Items.Count > 0)
                    cmbRubro.SelectedIndex = 0;

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

            // Crear una lista de objetos anónimos para mostrar propiedades relevantes
            var descuentosVista = descuentos.Select(d => new
            {
                ID = d.DescuentoId,
                Código = d.Codigo,
                Nombre = d.Nombre,
                Banco = d.Banco,
                Emisor = d.Emisor,
                Rubro = d.Rubro,
                Porcentaje = d.Porcentaje,
                TopeReintegro = d.TopeReintegro,
                Activo = d.Activo ? "Sí" : "No",
                FechaInicio = d.FechaInicio.ToShortDateString(),
                FechaFin = d.FechaFin.ToShortDateString()
            }).ToList();

            dgvDescuentos.DataSource = descuentosVista;

            // Ajustar el ancho de las columnas del DataGridView
            if (dgvDescuentos.Columns.Count > 0)
            {
                dgvDescuentos.Columns["ID"].Width = 40;
                dgvDescuentos.Columns["Código"].Width = 80;
                dgvDescuentos.Columns["Nombre"].Width = 120;
                dgvDescuentos.Columns["Banco"].Width = 100;
                dgvDescuentos.Columns["Emisor"].Width = 100;
                dgvDescuentos.Columns["Rubro"].Width = 100;
                dgvDescuentos.Columns["Porcentaje"].Width = 60;
                dgvDescuentos.Columns["TopeReintegro"].Width = 100;
                dgvDescuentos.Columns["Activo"].Width = 50;
                dgvDescuentos.Columns["FechaInicio"].Width = 80;
                dgvDescuentos.Columns["FechaFin"].Width = 80;
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
                    Banco = cmbBanco.SelectedItem.ToString(),  // Ahora añadimos el banco
                    Emisor = cmbEmisor.SelectedItem.ToString(), // Añadimos el emisor
                    Rubro = cmbRubro.SelectedItem.ToString(),  // Añadimos el rubro
                    TopeReintegro = nudTopeReintegro.Value,
                    Activo = chkActivo.Checked,
                    Acumulable = chkAcumulable.Checked
                };

                // Si se está editando un descuento existente, mantener su ID
                if (descuentoSeleccionado != null)
                {
                    descuento.DescuentoId = descuentoSeleccionado.DescuentoId;
                }

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

                // Seleccionar el tipo si existe en el combo
                if (!string.IsNullOrEmpty(descuento.Tipo) && cmbTipo.Items.Contains(descuento.Tipo))
                    cmbTipo.SelectedItem = descuento.Tipo;
                else
                    cmbTipo.SelectedIndex = 0;

                // Seleccionar el banco si existe en el combo
                if (!string.IsNullOrEmpty(descuento.Banco) && cmbBanco.Items.Contains(descuento.Banco))
                    cmbBanco.SelectedItem = descuento.Banco;
                else
                    cmbBanco.SelectedIndex = 0;

                // Seleccionar el emisor si existe en el combo
                if (!string.IsNullOrEmpty(descuento.Emisor) && cmbEmisor.Items.Contains(descuento.Emisor))
                    cmbEmisor.SelectedItem = descuento.Emisor;
                else
                    cmbEmisor.SelectedIndex = 0;

                // Seleccionar el rubro si existe en el combo
                if (!string.IsNullOrEmpty(descuento.Rubro) && cmbRubro.Items.Contains(descuento.Rubro))
                    cmbRubro.SelectedItem = descuento.Rubro;
                else
                    cmbRubro.SelectedIndex = 0;

                nudTopeReintegro.Value = descuento.TopeReintegro;
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
            cmbBanco.SelectedIndex = 0;  // Resetear banco
            cmbEmisor.SelectedIndex = 0; // Resetear emisor
            cmbRubro.SelectedIndex = 0;  // Resetear rubro
            nudTopeReintegro.Value = 5000;  // Valor predeterminado para el Tope de Reintegro
            chkActivo.Checked = true;
            chkAcumulable.Checked = false;
            descuentoSeleccionado = null; // Limpiar la referencia al descuento seleccionado
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (descuentoSeleccionado != null)
            {
                var result = MessageBox.Show("¿Está seguro de que desea borrar este descuento?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string resultado = ControladoraDescuento.Instancia.BorrarDescuento(descuentoSeleccionado);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarDataGridView();
                    LimpiarFormulario();
                }
            }
        }


    }
}