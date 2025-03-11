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

  private void CargarCombos()
  {
    // Tipo de Tarjeta
    cboTipoTarjeta.Items.AddRange(new string[] { "Débito", "Crédito" });

    // Bancos
    txtBanco.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    txtBanco.AutoCompleteSource = AutoCompleteSource.CustomSource;
    txtBanco.AutoCompleteCustomSource.AddRange(new string[]
    {
        "Banco Nación",
        "Banco Galicia",
        "Banco Santander",
        "BBVA",
        "Banco Macro",
        "Banco Provincia"
    });

    // Emisoras
    txtEmisora.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    txtEmisora.AutoCompleteSource = AutoCompleteSource.CustomSource;
    txtEmisora.AutoCompleteCustomSource.AddRange(new string[]
    {
        "Visa",
        "Mastercard",
        "American Express",
        "Cabal"
    });
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