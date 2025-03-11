namespace Vista
{
  partial class FormDescuentos
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgvDescuentos;
    private System.Windows.Forms.DateTimePicker dtpFechaInicio;
    private System.Windows.Forms.DateTimePicker dtpFechaFin;
    private System.Windows.Forms.TextBox txtDescripcion;
    private System.Windows.Forms.NumericUpDown nudPorcentaje;
    private System.Windows.Forms.NumericUpDown nudMontoFijo;
    private System.Windows.Forms.NumericUpDown nudTopeMonto;
    private System.Windows.Forms.ComboBox cboBanco;
    private System.Windows.Forms.ComboBox cboEmisor;
    private System.Windows.Forms.ComboBox cboRubro;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Button btnEliminar;
    private System.Windows.Forms.Label lblFechaInicio;
    private System.Windows.Forms.Label lblFechaFin;
    private System.Windows.Forms.Label lblDescripcion;
    private System.Windows.Forms.Label lblPorcentaje;
    private System.Windows.Forms.Label lblMontoFijo;
    private System.Windows.Forms.Label lblTopeMonto;
    private System.Windows.Forms.Label lblBanco;
    private System.Windows.Forms.Label lblEmisor;
    private System.Windows.Forms.Label lblRubro;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();

      // DataGridView
      this.dgvDescuentos = new System.Windows.Forms.DataGridView();
      this.dgvDescuentos.Location = new System.Drawing.Point(20, 20);
      this.dgvDescuentos.Size = new System.Drawing.Size(760, 200);
      this.dgvDescuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvDescuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvDescuentos.MultiSelect = false;
      this.dgvDescuentos.ReadOnly = true;

      // Labels
      this.lblDescripcion = new System.Windows.Forms.Label();
      this.lblDescripcion.Location = new System.Drawing.Point(20, 240);
      this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
      this.lblDescripcion.Text = "Descripción:";

      this.lblFechaInicio = new System.Windows.Forms.Label();
      this.lblFechaInicio.Location = new System.Drawing.Point(20, 270);
      this.lblFechaInicio.Size = new System.Drawing.Size(100, 23);
      this.lblFechaInicio.Text = "Fecha Inicio:";

      this.lblFechaFin = new System.Windows.Forms.Label();
      this.lblFechaFin.Location = new System.Drawing.Point(350, 270);
      this.lblFechaFin.Size = new System.Drawing.Size(100, 23);
      this.lblFechaFin.Text = "Fecha Fin:";

      this.lblPorcentaje = new System.Windows.Forms.Label();
      this.lblPorcentaje.Location = new System.Drawing.Point(20, 300);
      this.lblPorcentaje.Size = new System.Drawing.Size(100, 23);
      this.lblPorcentaje.Text = "Porcentaje:";

      this.lblMontoFijo = new System.Windows.Forms.Label();
      this.lblMontoFijo.Location = new System.Drawing.Point(350, 300);
      this.lblMontoFijo.Size = new System.Drawing.Size(100, 23);
      this.lblMontoFijo.Text = "Monto Fijo:";

      this.lblTopeMonto = new System.Windows.Forms.Label();
      this.lblTopeMonto.Location = new System.Drawing.Point(20, 330);
      this.lblTopeMonto.Size = new System.Drawing.Size(100, 23);
      this.lblTopeMonto.Text = "Tope:";

      this.lblBanco = new System.Windows.Forms.Label();
      this.lblBanco.Location = new System.Drawing.Point(20, 360);
      this.lblBanco.Size = new System.Drawing.Size(100, 23);
      this.lblBanco.Text = "Banco:";

      this.lblEmisor = new System.Windows.Forms.Label();
      this.lblEmisor.Location = new System.Drawing.Point(350, 360);
      this.lblEmisor.Size = new System.Drawing.Size(100, 23);
      this.lblEmisor.Text = "Emisor:";

      this.lblRubro = new System.Windows.Forms.Label();
      this.lblRubro.Location = new System.Drawing.Point(20, 390);
      this.lblRubro.Size = new System.Drawing.Size(100, 23);
      this.lblRubro.Text = "Rubro:";

      // TextBox
      this.txtDescripcion = new System.Windows.Forms.TextBox();
      this.txtDescripcion.Location = new System.Drawing.Point(130, 240);
      this.txtDescripcion.Size = new System.Drawing.Size(650, 23);

      // DateTimePickers
      this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
      this.dtpFechaInicio.Location = new System.Drawing.Point(130, 270);
      this.dtpFechaInicio.Size = new System.Drawing.Size(200, 23);
      this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
      this.dtpFechaFin.Location = new System.Drawing.Point(460, 270);
      this.dtpFechaFin.Size = new System.Drawing.Size(200, 23);
      this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      // NumericUpDowns
      this.nudPorcentaje = new System.Windows.Forms.NumericUpDown();
      this.nudPorcentaje.Location = new System.Drawing.Point(130, 300);
      this.nudPorcentaje.Size = new System.Drawing.Size(200, 23);
      this.nudPorcentaje.DecimalPlaces = 2;
      this.nudPorcentaje.Maximum = 100;

      this.nudMontoFijo = new System.Windows.Forms.NumericUpDown();
      this.nudMontoFijo.Location = new System.Drawing.Point(460, 300);
      this.nudMontoFijo.Size = new System.Drawing.Size(200, 23);
      this.nudMontoFijo.DecimalPlaces = 2;
      this.nudMontoFijo.Maximum = 1000000;

      this.nudTopeMonto = new System.Windows.Forms.NumericUpDown();
      this.nudTopeMonto.Location = new System.Drawing.Point(130, 330);
      this.nudTopeMonto.Size = new System.Drawing.Size(200, 23);
      this.nudTopeMonto.DecimalPlaces = 2;
      this.nudTopeMonto.Maximum = 1000000;

      // ComboBoxes
      this.cboBanco = new System.Windows.Forms.ComboBox();
      this.cboBanco.Location = new System.Drawing.Point(130, 360);
      this.cboBanco.Size = new System.Drawing.Size(200, 23);
      this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.cboEmisor = new System.Windows.Forms.ComboBox();
      this.cboEmisor.Location = new System.Drawing.Point(460, 360);
      this.cboEmisor.Size = new System.Drawing.Size(200, 23);
      this.cboEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.cboRubro = new System.Windows.Forms.ComboBox();
      this.cboRubro.Location = new System.Drawing.Point(130, 390);
      this.cboRubro.Size = new System.Drawing.Size(200, 23);
      this.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      // Buttons
      this.btnGuardar = new System.Windows.Forms.Button();
      this.btnGuardar.Location = new System.Drawing.Point(130, 430);
      this.btnGuardar.Size = new System.Drawing.Size(90, 30);
      this.btnGuardar.Text = "Guardar";

      this.btnEliminar = new System.Windows.Forms.Button();
      this.btnEliminar.Location = new System.Drawing.Point(240, 430);
      this.btnEliminar.Size = new System.Drawing.Size(90, 30);
      this.btnEliminar.Text = "Eliminar";
      this.btnEliminar.Enabled = false;

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 480);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvDescuentos,
                this.lblDescripcion, this.txtDescripcion,
                this.lblFechaInicio, this.dtpFechaInicio,
                this.lblFechaFin, this.dtpFechaFin,
                this.lblPorcentaje, this.nudPorcentaje,
                this.lblMontoFijo, this.nudMontoFijo,
                this.lblTopeMonto, this.nudTopeMonto,
                this.lblBanco, this.cboBanco,
                this.lblEmisor, this.cboEmisor,
                this.lblRubro, this.cboRubro,
                this.btnGuardar, this.btnEliminar
            });
      this.Name = "FormDescuentos";
      this.Text = "Gestión de Descuentos";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMontoFijo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudTopeMonto)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}