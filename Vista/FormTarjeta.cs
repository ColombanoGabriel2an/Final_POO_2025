using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;
using Controladora;

namespace Vista
{
    public partial class FormTarjeta : Form
    {
        private Tarjeta tarjetaSeleccionada = null;

        public FormTarjeta()
        {
            InitializeComponent();
        }

        private void FormTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                // Preseleccionar el primer elemento de cada ComboBox
                if (cmbBanco.Items.Count > 0)
                    cmbBanco.SelectedIndex = 0;

                if (cmbEntidadEmisora.Items.Count > 0)
                    cmbEntidadEmisora.SelectedIndex = 0;

                // Cargar personas en el ComboBox
                CargarPersonas();

                // Cargar tarjetas en el DataGridView
                ActualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPersonas()
        {
            List<Persona> personas = ControladoraPersona.Instancia.ListarPersonas();

            cmbTenedor.Items.Clear();
            cmbTenedor.DisplayMember = "Text";
            cmbTenedor.ValueMember = "Value";

            foreach (var persona in personas)
            {
                cmbTenedor.Items.Add(new { Text = $"{persona.Nombre} - {persona.DNI}", Value = persona });
            }

            if (cmbTenedor.Items.Count > 0)
                cmbTenedor.SelectedIndex = 0;
        }

        private void ActualizarDataGridView()
        {
            List<Tarjeta> tarjetas = ControladoraTarjeta.Instancia.ListarTarjetas();

            dgvTarjetas.DataSource = null;

            // Crear una lista de objetos anónimos para mostrar solo las propiedades relevantes
            var tarjetasVista = tarjetas.Select(t => new
            {
                ID = t.TarjetaId,
                Tipo = t is TarjetaCredito ? "Crédito" : "Débito",
                Número = t.Numero,
                Banco = t.Banco,
                EntidadEmisora = t.EntidadEmisora,
                Alias = t.Alias,
                Titular = t.Titular?.Nombre ?? "Sin titular",
                Vencimiento = t.FechaVencimiento.ToShortDateString()
            }).ToList();

            dgvTarjetas.DataSource = tarjetasVista;

            // Ajustar columnas
            if (dgvTarjetas.Columns.Count > 0)
            {
                dgvTarjetas.Columns["ID"].Width = 40;
                dgvTarjetas.Columns["Tipo"].Width = 60;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obligatorios
                if (string.IsNullOrEmpty(txtNumero.Text) ||
                    cmbBanco.SelectedItem == null ||
                    cmbEntidadEmisora.SelectedItem == null ||
                    cmbTenedor.SelectedItem == null)
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal limite = 0;
                decimal disponible = 0;

                if (!decimal.TryParse(txtLimite.Text, out limite) ||
                    !decimal.TryParse(txtDisponible.Text, out disponible))
                {
                    MessageBox.Show("Los valores de límite y disponible deben ser numéricos",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtener la persona seleccionada
                dynamic seleccionado = cmbTenedor.SelectedItem;
                Persona tenedor = seleccionado.Value;

                // Crear la tarjeta
                TarjetaCredito tarjeta = new TarjetaCredito
                {
                    Numero = txtNumero.Text,
                    FechaVencimiento = dtpFechaVencimiento.Value,
                    Banco = cmbBanco.SelectedItem.ToString(),
                    EntidadEmisora = cmbEntidadEmisora.SelectedItem.ToString(),
                    Alias = txtAlias.Text,
                    Limite = limite,
                    Disponible = disponible,
                    IsExtension = chkIsExtension.Checked,
                    Tenedor = tenedor
                };

                // Guardar la tarjeta
                string resultado = ControladoraTarjeta.Instancia.CrearTarjeta(tarjeta, tenedor);
                MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar el DataGridView
                ActualizarDataGridView();

                // Limpiar el formulario
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la tarjeta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Seleccionar la tarjeta
                int id = Convert.ToInt32(dgvTarjetas.Rows[e.RowIndex].Cells["ID"].Value);
                tarjetaSeleccionada = ControladoraTarjeta.Instancia.ListarTarjetas()
                    .FirstOrDefault(t => t.TarjetaId == id);

                // Mostrar sus datos en el formulario (si se requiere)
                // CargarDatosTarjeta(tarjetaSeleccionada);
            }
        }

        private void LimpiarFormulario()
        {
            txtNumero.Clear();
            dtpFechaVencimiento.Value = DateTime.Now;
            cmbBanco.SelectedIndex = -1;
            cmbEntidadEmisora.SelectedIndex = -1;
            txtAlias.Clear();
            txtLimite.Clear();
            txtDisponible.Clear();
            chkIsExtension.Checked = false;
            cmbTenedor.SelectedIndex = -1;
        }
    }
}