public partial class FormTarjetas : Form
{
  private ComboBox cboTipoTarjeta;
  private ComboBox cboPersonas;
  private TextBox txtNumero;
  private DateTimePicker dtpVencimiento;
  private TextBox txtBanco;
  private TextBox txtEmisora;
  private TextBox txtAlias;
  private NumericUpDown nudLimite;
  private CheckBox chkExtension;
  private ComboBox cboTenedor;

  public FormTarjetas()
  {
    InitializeComponent();
    ConfigurarControles();
    CargarCombos();
  }

  private void btnGuardar_Click(object sender, EventArgs e)
  {
    using (var context = new Context())
    {
      Tarjeta tarjeta;
      var titular = (Persona)cboPersonas.SelectedItem;

      if (cboTipoTarjeta.Text == "Débito")
      {
        tarjeta = new TarjetaDebito(
            txtNumero.Text,
            dtpVencimiento.Value,
            txtBanco.Text,
            txtEmisora.Text,
            titular,
            txtAlias.Text,
            0
        );
      }
      else
      {
        tarjeta = new TarjetaCredito(
            txtNumero.Text,
            dtpVencimiento.Value,
            txtBanco.Text,
            txtEmisora.Text,
            titular,
            txtAlias.Text,
            chkExtension.Checked,
            (Persona)cboTenedor.SelectedItem,
            nudLimite.Value,
            nudLimite.Value
        );
      }

      context.Tarjetas.Add(tarjeta);
      context.SaveChanges();
    }
  }
}