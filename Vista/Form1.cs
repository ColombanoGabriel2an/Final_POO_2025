using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            var frm = new FormPersona();
            frm.ShowDialog();
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            var frm = new FormDescuento();
            frm.ShowDialog();
        }

        private void btnAcreditacion_Click(object sender, EventArgs e)
        {
            var frm = new FormAcreditacion();
            frm.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            var frm = new FormReporte();
            frm.ShowDialog();
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            var frm = new FormTarjeta();
            frm.ShowDialog();
        }

        private void btnConsumo_Click(object sender, EventArgs e)
        {
            var frm = new FormConsumo();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra toda la aplicacion
            Application.Exit();
        }
    }
}
