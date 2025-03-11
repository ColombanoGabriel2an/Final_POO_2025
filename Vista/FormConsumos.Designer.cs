namespace Vista
{
  partial class FormConsumos
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cboTarjetas;
    private System.Windows.Forms.DateTimePicker dtpFecha;
    private System.Windows.Forms.DateTimePicker dtpHora;
    private System.Windows.Forms.TextBox txtDescripcion;
    private System.Windows.Forms.TextBox txtVendedor;
    private System.Windows.Forms.ComboBox cboRubro;
    private System.Windows.Forms.NumericUpDown nudMonto;
    private System.Windows.Forms.CheckBox chkRecurrente;
    private System.Windows.Forms.ListBox lstDescuentos;
    private System.Windows.Forms.Button btnRegistrar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Label lblTarjeta;
    private System.Windows.Forms.Label lblFecha;
    private System.Windows.Forms.Label lblHora;
    private System.Windows.Forms.Label lblDescripcion;
    private System.Windows.Forms.Label lblVendedor;
    private System.Windows.Forms.Label lblRubro;
    private System.Windows.Forms.Label lblMonto;
    private System.Windows.Forms.Label lblDescuentos;
    private System.Windows.Forms.Label lblMontoFinal;

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

      // Labels
      this.lblTarjeta = new System.Windows.Forms.Label();
      this.lblTarjeta.Location = new System.Drawing.Point(20, 20);
      this.lblTarjeta.Size = new System.Drawing.Size(100, 23);
      this.lblTarjeta.Text = "Tarjeta:";

      this.lblFecha = new System.Windows.Forms.Label();
      this.lblFecha.Location = new System.Drawing.Point(20, 50);
      this.lblFecha.Size = new System.Drawing.Size(100, 23);
      this.lblFecha.Text = "Fecha:";

      this.lblHora = new System.Windows.Forms.Label();
      this.lblHora.Location = new System.Drawing.Point(350, 50);
      this.lblHora.Size = new System.Drawing.Size(100, 23);
      this.lblHora.Text = "Hora:";

      this.lblDescripcion = new System.Windows.Forms.Label();
      this.lblDescripcion.Location = new System.Drawing.Point(20, 80);
      this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
      this.lblDescripcion.Text = "Descripción:";

      this.lblVendedor = new System.Windows.Forms.Label();
      this.lblVendedor.Location = new System.Drawing.Point(20, 110);
      this.lblVendedor.Size = new System.Drawing.Size(100, 23);
      this.lblVendedor.Text = "Vendedor:";

      this.lblRubro = new System.Windows.Forms.Label();
      this.lblRubro.Location = new System.Drawing.Point(20, 140);
      this.lblRubro.Size = new System.Drawing.Size(100, 23);
      this.lblRubro.Text = "Rubro:";

      this.lblMonto = new System.Windows.Forms.Label();
      this.lblMonto.Location = new System.Drawing.Point(20, 170);
      this.lblMonto.Size = new System.Drawing.Size(100, 23);
      this.lblMonto.Text = "Monto:";

      this.lblDescuentos = new System.Windows.Forms.Label();
      this.lblDescuentos.Location = new System.Drawing.Point(20, 200);
      this.lblDescuentos.Size = new System.Drawing.Size(100, 23);
      this.lblDescuentos.Text = "Descuentos:";

      this.lblMontoFinal = new System.Windows.Forms.Label();
      this.lblMontoFinal.Location = new System.Drawing.Point(20, 380);
      this.lblMontoFinal.Size = new System.Drawing.Size(200, 23);
      this.lblMontoFinal.Text = "Monto Final: $0.00";
      this.lblMontoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

      // Controls
      this.cboTarjetas = new System.Windows.Forms.ComboBox();
      this.cboTarjetas.Location = new System.Drawing.Point(130, 20);
      this.cboTarjetas.Size = new System.Drawing.Size(200, 23);
      this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.dtpFecha = new System.Windows.Forms.DateTimePicker();
      this.dtpFecha.Location = new System.Drawing.Point(130, 50);
      this.dtpFecha.Size = new System.Drawing.Size(200, 23);
      this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      this.dtpHora = new System.Windows.Forms.DateTimePicker();
      this.dtpHora.Location = new System.Drawing.Point(460, 50);
      this.dtpHora.Size = new System.Drawing.Size(200, 23);
      this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.dtpHora.ShowUpDown = true;

      this.txtDescripcion = new System.Windows.Forms.TextBox();
      this.txtDescripcion.Location = new System.Drawing.Point(130, 80);
      this.txtDescripcion.Size = new System.Drawing.Size(530, 23);

      this.txtVendedor = new System.Windows.Forms.TextBox();
      this.txtVendedor.Location = new System.Drawing.Point(130, 110);
      this.txtVendedor.Size = new System.Drawing.Size(200, 23);

      this.cboRubro = new System.Windows.Forms.ComboBox();
      this.cboRubro.Location = new System.Drawing.Point(130, 140);
      this.cboRubro.Size = new System.Drawing.Size(200, 23);
      this.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.nudMonto = new System.Windows.Forms.NumericUpDown();
      this.nudMonto.Location = new System.Drawing.Point(130, 170);
      this.nudMonto.Size = new System.Drawing.Size(200, 23);
      this.nudMonto.DecimalPlaces = 2;
      this.nudMonto.Maximum = 1000000;

      this.lstDescuentos = new System.Windows.Forms.ListBox();
      this.lstDescuentos.Location = new System.Drawing.Point(130, 200);
      this.lstDescuentos.Size = new System.Drawing.Size(530, 150);
      this.lstDescuentos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;

      this.chkRecurrente = new System.Windows.Forms.CheckBox();
      this.chkRecurrente.Location = new System.Drawing.Point(130, 360);
      this.chkRecurrente.Size = new System.Drawing.Size(200, 20);
      this.chkRecurrente.Text = "Consumo Recurrente";

      this.btnRegistrar = new System.Windows.Forms.Button();
      this.btnRegistrar.Location = new System.Drawing.Point(460, 420);
      this.btnRegistrar.Size = new System.Drawing.Size(90, 30);
      this.btnRegistrar.Text = "Registrar";

      this.btnCancelar = new System.Windows.Forms.Button();
      this.btnCancelar.Location = new System.Drawing.Point(570, 420);
      this.btnCancelar.Size = new System.Drawing.Size(90, 30);
      this.btnCancelar.Text = "Cancelar";

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(700, 480);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTarjeta, this.cboTarjetas,
                this.lblFecha, this.dtpFecha,
                this.lblHora, this.dtpHora,
                this.lblDescripcion, this.txtDescripcion,
                this.lblVendedor, this.txtVendedor,
                this.lblRubro, this.cboRubro,
                this.lblMonto, this.nudMonto,
                this.lblDescuentos, this.lstDescuentos,
                this.chkRecurrente,
                this.lblMontoFinal,
                this.btnRegistrar, this.btnCancelar
            });
      this.Name = "FormConsumos";
      this.Text = "Registro de Consumo";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}