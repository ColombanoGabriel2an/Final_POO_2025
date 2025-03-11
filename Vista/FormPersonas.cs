public partial class FormPersonas : Form
{
  private DataGridView dgvPersonas;
  private TextBox txtNombre;
  private TextBox txtApellido;
  private TextBox txtDNI;
  private Button btnAgregar;
  private Button btnModificar;
  private Button btnEliminar;

  public FormPersonas()
  {
    InitializeComponent();
    ConfigurarControles();
    CargarPersonas();
  }

  private void CargarPersonas()
  {
    using (var context = new Context())
    {
      dgvPersonas.DataSource = context.Personas.ToList();
    }
  }

  private void btnAgregar_Click(object sender, EventArgs e)
  {
    var persona = new Persona(
        txtNombre.Text,
        txtApellido.Text,
        txtDNI.Text
    );

    using (var context = new Context())
    {
      context.Personas.Add(persona);
      context.SaveChanges();
    }

    CargarPersonas();
  }
}