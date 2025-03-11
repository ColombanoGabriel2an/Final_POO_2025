public partial class FormAcreditaciones : Form
{
  private ComboBox cboTarjetas;
  private DateTimePicker dtpFecha;
  private TextBox txtDescripcion;
  private NumericUpDown nudMonto;
  private ComboBox cboMedioPago;
  private Button btnGuardar;
  private Button btnCancelar;
  private Label lblTarjeta;
  private Label lblFecha;
  private Label lblDescripcion;
  private Label lblMonto;
  private Label lblMedioPago;

  public FormAcreditaciones()
  {
    InitializeComponent();
    ConfigurarControles();
    CargarCombos();
  }

  private void ConfigurarControles()
  {
    this.Text = "Registrar Acreditación";
    this.Size = new Size(400, 400);
    this.StartPosition = FormStartPosition.CenterParent;

    lblTarjeta = new Label
    {
      Text = "Tarjeta:",
      Location = new Point(20, 20),
      Size = new Size(100, 20)
    };

    cboTarjetas = new ComboBox
    {
      Location = new Point(130, 20),
      Size = new Size(200, 20),
      DropDownStyle = ComboBoxStyle.DropDownList
    };

    lblFecha = new Label
    {
      Text = "Fecha:",
      Location = new Point(20, 60),
      Size = new Size(100, 20)
    };

    dtpFecha = new DateTimePicker
    {
      Location = new Point(130, 60),
      Size = new Size(200, 20)
    };

    lblDescripcion = new Label
    {
      Text = "Descripción:",
      Location = new Point(20, 100),
      Size = new Size(100, 20)
    };

    txtDescripcion = new TextBox
    {
      Location = new Point(130, 100),
      Size = new Size(200, 20)
    };

    lblMonto = new Label
    {
      Text = "Monto:",
      Location = new Point(20, 140),
      Size = new Size(100, 20)
    };

    nudMonto = new NumericUpDown
    {
      Location = new Point(130, 140),
      Size = new Size(200, 20),
      Minimum = 0,
      Maximum = 1000000,
      DecimalPlaces = 2
    };

    lblMedioPago = new Label
    {
      Text = "Medio de Pago:",
      Location = new Point(20, 180),
      Size = new Size(100, 20)
    };

    cboMedioPago = new ComboBox
    {
      Location = new Point(130, 180),
      Size = new Size(200, 20),
      DropDownStyle = ComboBoxStyle.DropDownList
    };

    btnGuardar = new Button
    {
      Text = "Guardar",
      Location = new Point(130, 280),
      Size = new Size(90, 30)
    };

    btnCancelar = new Button
    {
      Text = "Cancelar",
      Location = new Point(240, 280),
      Size = new Size(90, 30)
    };

    this.Controls.AddRange(new Control[] {
            lblTarjeta, cboTarjetas,
            lblFecha, dtpFecha,
            lblDescripcion, txtDescripcion,
            lblMonto, nudMonto,
            lblMedioPago, cboMedioPago,
            btnGuardar, btnCancelar
        });

    btnGuardar.Click += btnGuardar_Click;
    btnCancelar.Click += (s, e) => this.Close();
  }

  private void CargarCombos()
  {
    using (var context = new Context())
    {
      cboTarjetas.DataSource = context.Tarjetas.ToList();
      cboTarjetas.DisplayMember = "Alias";
    }

    cboMedioPago.Items.AddRange(new string[] {
            "Transferencia",
            "Depósito",
            "Cheque",
            "Débito"
        });
    cboMedioPago.SelectedIndex = 0;
  }

  private void btnGuardar_Click(object sender, EventArgs e)
  {
    if (ValidarDatos())
    {
      using (var context = new Context())
      {
        var acreditacion = new Acreditacion(
            (Tarjeta)cboTarjetas.SelectedItem,
            dtpFecha.Value,
            txtDescripcion.Text,
            nudMonto.Value,
            cboMedioPago.Text
        );

        if (acreditacion.ProcesarAcreditacion())
        {
          context.Acreditaciones.Add(acreditacion);
          context.SaveChanges();
          MessageBox.Show("Acreditación registrada correctamente");
          this.Close();
        }
        else
        {
          MessageBox.Show("Error al procesar la acreditación");
        }
      }
    }
  }

  private bool ValidarDatos()
  {
    if (cboTarjetas.SelectedItem == null)
    {
      MessageBox.Show("Debe seleccionar una tarjeta");
      return false;
    }

    if (string.IsNullOrEmpty(txtDescripcion.Text))
    {
      MessageBox.Show("Debe ingresar una descripción");
      return false;
    }

    if (nudMonto.Value <= 0)
    {
      MessageBox.Show("El monto debe ser mayor a 0");
      return false;
    }

    return true;
  }
}