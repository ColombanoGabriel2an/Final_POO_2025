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
                // Configurar la visibilidad inicial según el tipo de tarjeta seleccionado
                rbTipoTarjeta_CheckedChanged(this, EventArgs.Empty);

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
                    cmbTenedor.SelectedItem == null ||
                    string.IsNullOrEmpty(txtDisponible.Text))
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la persona seleccionada
                dynamic seleccionado = cmbTenedor.SelectedItem;
                Persona tenedor = seleccionado.Value;

                // Determinar si es tarjeta de crédito o débito
                bool esCredito = rbCredito.Checked;

                // Validar que se ingresó un valor numérico para disponible/saldo
                if (!decimal.TryParse(txtDisponible.Text, out decimal disponibleOSaldo))
                {
                    MessageBox.Show("El valor de " + (esCredito ? "disponible" : "saldo") + " debe ser numérico",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear la tarjeta según el tipo seleccionado
                Tarjeta tarjeta;

                if (esCredito)
                {
                    // Validar límite para tarjeta de crédito
                    if (!decimal.TryParse(txtLimite.Text, out decimal limite))
                    {
                        MessageBox.Show("El valor de límite debe ser numérico",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tarjeta = new TarjetaCredito
                    {
                        Numero = txtNumero.Text,
                        FechaVencimiento = dtpFechaVencimiento.Value,
                        Banco = cmbBanco.SelectedItem.ToString(),
                        EntidadEmisora = cmbEntidadEmisora.SelectedItem.ToString(),
                        Alias = txtAlias.Text,
                        Limite = limite,
                        Disponible = disponibleOSaldo,
                        IsExtension = chkIsExtension.Checked,
                        Tenedor = tenedor,
                        Titular = tenedor  // Asumimos que el tenedor es también el titular
                    };
                }
                else
                {
                    tarjeta = new TarjetaDebito
                    {
                        Numero = txtNumero.Text,
                        FechaVencimiento = dtpFechaVencimiento.Value,
                        Banco = cmbBanco.SelectedItem.ToString(),
                        EntidadEmisora = cmbEntidadEmisora.SelectedItem.ToString(),
                        Alias = txtAlias.Text,
                        Saldo = disponibleOSaldo,
                        Titular = tenedor
                    };
                }

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
            cmbBanco.SelectedIndex = 0;
            cmbEntidadEmisora.SelectedIndex = 0;
            txtAlias.Clear();
            txtLimite.Clear();
            txtDisponible.Clear();
            chkIsExtension.Checked = false;
            cmbTenedor.SelectedIndex = 0;
            rbCredito.Checked = true;
        }

        private void rbTipoTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            bool esCredito = rbCredito.Checked;

            // Mostrar/ocultar campos específicos para tarjeta de crédito
            lblLimite.Visible = esCredito;
            txtLimite.Visible = esCredito;
            chkIsExtension.Visible = esCredito;

            // Cambiar el texto del label según el tipo
            lblDisponible.Text = esCredito ? "Disponible:" : "Saldo:";

            // Limpiar los campos específicos si cambiamos de tipo
            if (!esCredito)
            {
                txtLimite.Text = string.Empty;
                chkIsExtension.Checked = false;
            }
        }
    }
}