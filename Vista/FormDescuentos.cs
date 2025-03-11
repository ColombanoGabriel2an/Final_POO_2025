using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;

public partial class FormDescuentos : Form
{
  private DataGridView dgvDescuentos;
  private DateTimePicker dtpFechaInicio;
  private DateTimePicker dtpFechaFin;
  private TextBox txtDescripcion;
  private NumericUpDown nudPorcentaje;
  private NumericUpDown nudMontoFijo;
  private NumericUpDown nudTopeMonto;
  private ComboBox cboBanco;
  private ComboBox cboEmisor;
  private ComboBox cboRubro;
  private Button btnGuardar;
  private Button btnEliminar;
  private Label lblFechaInicio;
  private Label lblFechaFin;
  private Label lblDescripcion;
  private Label lblPorcentaje;
  private Label lblMontoFijo;
  private Label lblTopeMonto;
  private Label lblBanco;
  private Label lblEmisor;
  private Label lblRubro;

  public FormDescuentos()
  {
    InitializeComponent();
    ConfigurarControles();
    CargarDatos();
  }

  private void ConfigurarControles()
  {
    this.Text = "Gestión de Descuentos";
    this.Size = new Size(800, 600);
    this.StartPosition = FormStartPosition.CenterScreen;

    // Configuración del DataGridView
    dgvDescuentos = new DataGridView
    {
      Location = new Point(20, 20),
      Size = new Size(750, 200),
      AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
      SelectionMode = DataGridViewSelectionMode.FullRowSelect,
      MultiSelect = false
    };

    // Configuración de controles para nuevo descuento
    lblDescripcion = new Label { Text = "Descripción:", Location = new Point(20, 240) };
    txtDescripcion = new TextBox { Location = new Point(100, 240), Size = new Size(200, 20) };

    lblFechaInicio = new Label { Text = "Fecha Inicio:", Location = new Point(20, 270) };
    dtpFechaInicio = new DateTimePicker { Location = new Point(100, 270), Size = new Size(200, 20) };

    lblFechaFin = new Label { Text = "Fecha Fin:", Location = new Point(320, 270) };
    dtpFechaFin = new DateTimePicker { Location = new Point(400, 270), Size = new Size(200, 20) };

    lblPorcentaje = new Label { Text = "Porcentaje:", Location = new Point(20, 300) };
    nudPorcentaje = new NumericUpDown
    {
      Location = new Point(100, 300),
      Size = new Size(100, 20),
      DecimalPlaces = 2,
      Maximum = 100
    };

    lblMontoFijo = new Label { Text = "Monto Fijo:", Location = new Point(320, 300) };
    nudMontoFijo = new NumericUpDown
    {
      Location = new Point(400, 300),
      Size = new Size(100, 20),
      DecimalPlaces = 2,
      Maximum = 1000000
    };

    lblTopeMonto = new Label { Text = "Tope:", Location = new Point(520, 300) };
    nudTopeMonto = new NumericUpDown
    {
      Location = new Point(580, 300),
      Size = new Size(100, 20),
      DecimalPlaces = 2,
      Maximum = 1000000
    };

    lblBanco = new Label { Text = "Banco:", Location = new Point(20, 330) };
    cboBanco = new ComboBox { Location = new Point(100, 330), Size = new Size(200, 20) };

    lblEmisor = new Label { Text = "Emisor:", Location = new Point(320, 330) };
    cboEmisor = new ComboBox { Location = new Point(400, 330), Size = new Size(200, 20) };

    lblRubro = new Label { Text = "Rubro:", Location = new Point(20, 360) };
    cboRubro = new ComboBox { Location = new Point(100, 360), Size = new Size(200, 20) };

    btnGuardar = new Button
    {
      Text = "Guardar",
      Location = new Point(300, 400),
      Size = new Size(90, 30)
    };

    btnEliminar = new Button
    {
      Text = "Eliminar",
      Location = new Point(400, 400),
      Size = new Size(90, 30)
    };

    // Agregar controles al formulario
    this.Controls.AddRange(new Control[] {
            dgvDescuentos,
            lblDescripcion, txtDescripcion,
            lblFechaInicio, dtpFechaInicio,
            lblFechaFin, dtpFechaFin,
            lblPorcentaje, nudPorcentaje,
            lblMontoFijo, nudMontoFijo,
            lblTopeMonto, nudTopeMonto,
            lblBanco, cboBanco,
            lblEmisor, cboEmisor,
            lblRubro, cboRubro,
            btnGuardar, btnEliminar
        });

    // Eventos
    btnGuardar.Click += btnGuardar_Click;
    btnEliminar.Click += btnEliminar_Click;
    dgvDescuentos.SelectionChanged += dgvDescuentos_SelectionChanged;

    CargarCombos();
  }

  private void CargarCombos()
  {
    cboBanco.Items.AddRange(new string[] { "Banco A", "Banco B", "Banco C" });
    cboEmisor.Items.AddRange(new string[] { "Visa", "Mastercard", "American Express" });
    cboRubro.Items.AddRange(new string[] { "Supermercado", "Restaurante", "Combustible", "Indumentaria" });
  }

  private void CargarDatos()
  {
    using (var context = new Context())
    {
      dgvDescuentos.DataSource = context.Descuentos.ToList();
    }
  }

  private void btnGuardar_Click(object sender, EventArgs e)
  {
    if (ValidarDatos())
    {
      using (var context = new Context())
      {
        var descuento = new Descuento(
            txtDescripcion.Text,
            dtpFechaInicio.Value,
            dtpFechaFin.Value,
            nudPorcentaje.Value,
            nudMontoFijo.Value,
            nudTopeMonto.Value,
            cboBanco.Text,
            cboEmisor.Text,
            cboRubro.Text
        );

        context.Descuentos.Add(descuento);
        context.SaveChanges();
        CargarDatos();
        LimpiarCampos();
      }
    }
  }

  private void btnEliminar_Click(object sender, EventArgs e)
  {
    if (dgvDescuentos.SelectedRows.Count > 0)
    {
      var descuento = (Descuento)dgvDescuentos.SelectedRows[0].DataBoundItem;
      using (var context = new Context())
      {
        context.Descuentos.Remove(descuento);
        context.SaveChanges();
        CargarDatos();
      }
    }
  }

  private void dgvDescuentos_SelectionChanged(object sender, EventArgs e)
  {
    if (dgvDescuentos.SelectedRows.Count > 0)
    {
      var descuento = (Descuento)dgvDescuentos.SelectedRows[0].DataBoundItem;
      CargarDescuentoEnControles(descuento);
    }
  }

  private void CargarDescuentoEnControles(Descuento descuento)
  {
    txtDescripcion.Text = descuento.Descripcion;
    dtpFechaInicio.Value = descuento.FechaInicio;
    dtpFechaFin.Value = descuento.FechaFin;
    nudPorcentaje.Value = descuento.Porcentaje;
    nudMontoFijo.Value = descuento.MontoFijo;
    nudTopeMonto.Value = descuento.TopeMonto;
    cboBanco.Text = descuento.Banco;
    cboEmisor.Text = descuento.Emisor;
    cboRubro.Text = descuento.Rubro;
  }

  private void LimpiarCampos()
  {
    txtDescripcion.Clear();
    dtpFechaInicio.Value = DateTime.Now;
    dtpFechaFin.Value = DateTime.Now;
    nudPorcentaje.Value = 0;
    nudMontoFijo.Value = 0;
    nudTopeMonto.Value = 0;
    cboBanco.SelectedIndex = -1;
    cboEmisor.SelectedIndex = -1;
    cboRubro.SelectedIndex = -1;
  }

  private bool ValidarDatos()
  {
    if (string.IsNullOrEmpty(txtDescripcion.Text))
    {
      MessageBox.Show("Debe ingresar una descripción");
      return false;
    }

    if (dtpFechaFin.Value < dtpFechaInicio.Value)
    {
      MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio");
      return false;
    }

    if (nudPorcentaje.Value == 0 && nudMontoFijo.Value == 0)
    {
      MessageBox.Show("Debe ingresar un porcentaje o monto fijo");
      return false;
    }

    if (string.IsNullOrEmpty(cboBanco.Text))
    {
      MessageBox.Show("Debe seleccionar un banco");
      return false;
    }

    return true;
  }
}