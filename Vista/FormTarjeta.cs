using System;
using System.Windows.Forms;
using Entidades;
using Controladora;

namespace Vista
{
    public partial class FormTarjeta : Form
    {
        public FormTarjeta()
        {
            InitializeComponent();

            // Preseleccionar el primer elemento de cada ComboBox
            if (cmbBanco.Items.Count > 0)
                cmbBanco.SelectedIndex = 0;

            if (cmbEntidadEmisora.Items.Count > 0)
                cmbEntidadEmisora.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var tarjeta = new TarjetaCredito
            {
                Numero = txtNumero.Text,
                FechaVencimiento = dtpFechaVencimiento.Value,
                Banco = cmbBanco.SelectedItem?.ToString(),  // Changed from txtBanco.Text
                EntidadEmisora = cmbEntidadEmisora.SelectedItem?.ToString(), // Changed from txtEntidadEmisora.Text
                Alias = txtAlias.Text,
                Limite = decimal.Parse(txtLimite.Text),
                Disponible = decimal.Parse(txtDisponible.Text),
                IsExtension = chkIsExtension.Checked,
                Tenedor = new Persona { PersonaId = int.Parse(txtTenedorId.Text) }
            };

            MessageBox.Show("Tarjeta guardada exitosamente.");
        }
    }
}