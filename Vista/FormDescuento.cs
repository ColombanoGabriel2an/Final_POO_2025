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

            // Crear una lista de objetos anónimos para mostrar solo las propiedades relevantes de los descuentos
            var descuentosVista = descuentos.Select(d => new
            {
                ID = d.DescuentoId,
                Código = d.Codigo,
                Nombre = d.Nombre,
                Porcentaje = d.Porcentaje,
                TopeReintegro = d.TopeReintegro, // Monto máximo a reintegrar
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
                dgvDescuentos.Columns["Nombre"].Width = 150;
                dgvDescuentos.Columns["Porcentaje"].Width = 60;
                dgvDescuentos.Columns["TopeReintegro"].Width = 100;
                dgvDescuentos.Columns["Activo"].Width = 50;
                dgvDescuentos.Columns["FechaInicio"].Width = 100;
                dgvDescuentos.Columns["FechaFin"].Width = 100;
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

                // Buscar si el descuento ya existe por el código
                var descuentoExistente = ControladoraDescuento.Instancia.ListarDescuentos()
                    .FirstOrDefault(d => d.Codigo == txtCodigo.Text);

                if (descuentoExistente != null)
                {
                    // Si el descuento ya existe, actualizar los valores
                    descuentoExistente.Nombre = txtNombre.Text;
                    descuentoExistente.Descripcion = txtDescripcion.Text;
                    descuentoExistente.Porcentaje = nudPorcentaje.Value;
                    descuentoExistente.FechaInicio = dtpFechaInicio.Value;
                    descuentoExistente.FechaFin = dtpFechaFin.Value;
                    descuentoExistente.Tipo = cmbTipo.SelectedItem.ToString();
                    //descuentoExistente.EntidadBancaria = cmbEntidadBancaria.SelectedItem.ToString();
                    descuentoExistente.TopeReintegro = nudTopeReintegro.Value;
                    descuentoExistente.Activo = chkActivo.Checked;
                    descuentoExistente.Acumulable = chkAcumulable.Checked;

                    // Guardar el descuento actualizado
                    string resultado = ControladoraDescuento.Instancia.ActualizarDescuento(descuentoExistente);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Si el descuento no existe, crear uno nuevo
                    var nuevoDescuento = new Descuento
                    {
                        Codigo = txtCodigo.Text,
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Porcentaje = nudPorcentaje.Value,
                        FechaInicio = dtpFechaInicio.Value,
                        FechaFin = dtpFechaFin.Value,
                        Tipo = cmbTipo.SelectedItem.ToString(),
                        //EntidadBancaria = cmbEntidadBancaria.SelectedItem.ToString(),
                        TopeReintegro = nudTopeReintegro.Value,
                        Activo = chkActivo.Checked,
                        Acumulable = chkAcumulable.Checked
                    };

                    // Guardar el nuevo descuento
                    string resultado = ControladoraDescuento.Instancia.CrearDescuento(nuevoDescuento);
                    MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                //cmbEntidadBancaria.SelectedItem = descuento.EntidadBancaria;
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
            cmbEntidadBancaria.SelectedIndex = 0;
            nudTopeReintegro.Value = 5000;  // Valor predeterminado para el Tope de Reintegro
            chkActivo.Checked = true;
            chkAcumulable.Checked = false;
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
