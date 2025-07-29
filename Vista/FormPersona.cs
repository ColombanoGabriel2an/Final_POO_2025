using Controladora;
using Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormPersona : Form
    {
        private Persona personaSeleccionada = null;

        public FormPersona()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            var lista = ControladoraPersona.Instancia.ListarPersonas();
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = lista;
            LimpiarCampos();
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

            // Refrescar la grilla y limpiar campos
            btnListar_Click(null, null);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (personaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una persona para modificar.");
                return;
            }

            // Actualizar los datos de la persona seleccionada
            personaSeleccionada.Nombre = txtNombre.Text;
            personaSeleccionada.Apellido = txtApellido.Text;
            personaSeleccionada.DNI = txtDNI.Text;

            var mensaje = ControladoraPersona.Instancia.ModificarPersona(personaSeleccionada);
            MessageBox.Show(mensaje);

            // Refrescar la grilla y limpiar campos
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

        private void dgvPersonas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow != null)
            {
                personaSeleccionada = (Persona)dgvPersonas.CurrentRow.DataBoundItem;
                CargarDatosEnCampos(personaSeleccionada);
            }
        }

        private void CargarDatosEnCampos(Persona persona)
        {
            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
            txtDNI.Text = persona.DNI;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            personaSeleccionada = null;
        }
    }
}

