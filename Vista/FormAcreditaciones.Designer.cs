namespace Vista
{
  partial class FormAcreditaciones
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cboTarjetas;
    private System.Windows.Forms.DateTimePicker dtpFecha;
    private System.Windows.Forms.TextBox txtDescripcion;
    private System.Windows.Forms.NumericUpDown nudMonto;
    private System.Windows.Forms.ComboBox cboMedioPago;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Label lblTarjeta;
    private System.Windows.Forms.Label lblFecha;
    private System.Windows.Forms.Label lblDescripcion;
    private System.Windows.Forms.Label lblMonto;
    private System.Windows.Forms.Label lblMedioPago;

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

      this.lblDescripcion = new System.Windows.Forms.Label();
      this.lblDescripcion.Location = new System.Drawing.Point(20, 80);
      this.lblDescripcion.Size = new System.Drawing.Size(100, 23);
      this.lblDescripcion.Text = "Descripción:";

      this.lblMonto = new System.Windows.Forms.Label();
      this.lblMonto.Location = new System.Drawing.Point(20, 110);
      this.lblMonto.Size = new System.Drawing.Size(100, 23);
      this.lblMonto.Text = "Monto:";

      this.lblMedioPago = new System.Windows.Forms.Label();
      this.lblMedioPago.Location = new System.Drawing.Point(20, 140);
      this.lblMedioPago.Size = new System.Drawing.Size(100, 23);
      this.lblMedioPago.Text = "Medio de Pago:";

      // Controls
      this.cboTarjetas = new System.Windows.Forms.ComboBox();
      this.cboTarjetas.Location = new System.Drawing.Point(130, 20);
      this.cboTarjetas.Size = new System.Drawing.Size(300, 23);
      this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.dtpFecha = new System.Windows.Forms.DateTimePicker();
      this.dtpFecha.Location = new System.Drawing.Point(130, 50);
      this.dtpFecha.Size = new System.Drawing.Size(200, 23);
      this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      this.txtDescripcion = new System.Windows.Forms.TextBox();
      this.txtDescripcion.Location = new System.Drawing.Point(130, 80);
      this.txtDescripcion.Size = new System.Drawing.Size(300, 23);

      this.nudMonto = new System.Windows.Forms.NumericUpDown();
      this.nudMonto.Location = new System.Drawing.Point(130, 110);
      this.nudMonto.Size = new System.Drawing.Size(200, 23);
      this.nudMonto.DecimalPlaces = 2;
      this.nudMonto.Maximum = 1000000;

      this.cboMedioPago = new System.Windows.Forms.ComboBox();
      this.cboMedioPago.Location = new System.Drawing.Point(130, 140);
      this.cboMedioPago.Size = new System.Drawing.Size(200, 23);
      this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.btnGuardar = new System.Windows.Forms.Button();
      this.btnGuardar.Location = new System.Drawing.Point(130, 180);
      this.btnGuardar.Size = new System.Drawing.Size(90, 30);
      this.btnGuardar.Text = "Guardar";

      this.btnCancelar = new System.Windows.Forms.Button();
      this.btnCancelar.Location = new System.Drawing.Point(240, 180);
      this.btnCancelar.Size = new System.Drawing.Size(90, 30);
      this.btnCancelar.Text = "Cancelar";

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(460, 240);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTarjeta, this.cboTarjetas,
                this.lblFecha, this.dtpFecha,
                this.lblDescripcion, this.txtDescripcion,
                this.lblMonto, this.nudMonto,
                this.lblMedioPago, this.cboMedioPago,
                this.btnGuardar, this.btnCancelar
            });
      this.Name = "FormAcreditaciones";
      this.Text = "Registro de Acreditación";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}