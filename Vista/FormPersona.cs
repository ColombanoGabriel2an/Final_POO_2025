using Controladora;
using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormPersona : Form
    {
        public FormPersona()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var lista = ControladoraPersona.Instancia.ListarPersonas();
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = lista;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Creamos una nueva persona a partir de los datos ingresados
            var persona = new Persona
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text
            };

            var mensaje = ControladoraPersona.Instancia.CrearPersona(persona);
            MessageBox.Show(mensaje);

            // Refrescar la grilla
            btnListar_Click(null, null);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow != null)
            {
                var personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;
                var mensaje = ControladoraPersona.Instancia.BorrarPersona(personaSeleccionada);
                MessageBox.Show(mensaje);

                // Refrescar la grilla
                btnListar_Click(null, null);
            }
        }
    }
}

