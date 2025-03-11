namespace Vista
{
  partial class FormTarjetas
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cboTipoTarjeta;
    private System.Windows.Forms.ComboBox cboPersonas;
    private System.Windows.Forms.TextBox txtNumero;
    private System.Windows.Forms.DateTimePicker dtpVencimiento;
    private System.Windows.Forms.TextBox txtBanco;
    private System.Windows.Forms.TextBox txtEmisora;
    private System.Windows.Forms.TextBox txtAlias;
    private System.Windows.Forms.NumericUpDown nudLimite;
    private System.Windows.Forms.CheckBox chkExtension;
    private System.Windows.Forms.ComboBox cboTenedor;
    private System.Windows.Forms.Button btnGuardar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Label lblTipoTarjeta;
    private System.Windows.Forms.Label lblPersona;
    private System.Windows.Forms.Label lblNumero;
    private System.Windows.Forms.Label lblVencimiento;
    private System.Windows.Forms.Label lblBanco;
    private System.Windows.Forms.Label lblEmisora;
    private System.Windows.Forms.Label lblAlias;
    private System.Windows.Forms.Label lblLimite;
    private System.Windows.Forms.Label lblTenedor;
    private System.Windows.Forms.DataGridView dgvTarjetas;

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
      this.dgvTarjetas = new System.Windows.Forms.DataGridView();
      this.dgvTarjetas.Location = new System.Drawing.Point(20, 20);
      this.dgvTarjetas.Size = new System.Drawing.Size(760, 200);
      this.dgvTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvTarjetas.MultiSelect = false;
      this.dgvTarjetas.ReadOnly = true;

      // Labels
      this.lblTipoTarjeta = new System.Windows.Forms.Label();
      this.lblTipoTarjeta.Location = new System.Drawing.Point(20, 240);
      this.lblTipoTarjeta.Size = new System.Drawing.Size(100, 23);
      this.lblTipoTarjeta.Text = "Tipo:";

      this.lblPersona = new System.Windows.Forms.Label();
      this.lblPersona.Location = new System.Drawing.Point(20, 270);
      this.lblPersona.Size = new System.Drawing.Size(100, 23);
      this.lblPersona.Text = "Titular:";

      this.lblNumero = new System.Windows.Forms.Label();
      this.lblNumero.Location = new System.Drawing.Point(20, 300);
      this.lblNumero.Size = new System.Drawing.Size(100, 23);
      this.lblNumero.Text = "Número:";

      this.lblVencimiento = new System.Windows.Forms.Label();
      this.lblVencimiento.Location = new System.Drawing.Point(20, 330);
      this.lblVencimiento.Size = new System.Drawing.Size(100, 23);
      this.lblVencimiento.Text = "Vencimiento:";

      this.lblBanco = new System.Windows.Forms.Label();
      this.lblBanco.Location = new System.Drawing.Point(20, 360);
      this.lblBanco.Size = new System.Drawing.Size(100, 23);
      this.lblBanco.Text = "Banco:";

      this.lblEmisora = new System.Windows.Forms.Label();
      this.lblEmisora.Location = new System.Drawing.Point(20, 390);
      this.lblEmisora.Size = new System.Drawing.Size(100, 23);
      this.lblEmisora.Text = "Emisora:";

      this.lblAlias = new System.Windows.Forms.Label();
      this.lblAlias.Location = new System.Drawing.Point(20, 420);
      this.lblAlias.Size = new System.Drawing.Size(100, 23);
      this.lblAlias.Text = "Alias:";

      this.lblLimite = new System.Windows.Forms.Label();
      this.lblLimite.Location = new System.Drawing.Point(400, 270);
      this.lblLimite.Size = new System.Drawing.Size(100, 23);
      this.lblLimite.Text = "Límite:";
      this.lblLimite.Visible = false;

      this.lblTenedor = new System.Windows.Forms.Label();
      this.lblTenedor.Location = new System.Drawing.Point(400, 300);
      this.lblTenedor.Size = new System.Drawing.Size(100, 23);
      this.lblTenedor.Text = "Tenedor:";
      this.lblTenedor.Visible = false;

      // ComboBoxes
      this.cboTipoTarjeta = new System.Windows.Forms.ComboBox();
      this.cboTipoTarjeta.Location = new System.Drawing.Point(130, 240);
      this.cboTipoTarjeta.Size = new System.Drawing.Size(200, 23);
      this.cboTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboTipoTarjeta.Items.AddRange(new object[] { "Débito", "Crédito" });

      this.cboPersonas = new System.Windows.Forms.ComboBox();
      this.cboPersonas.Location = new System.Drawing.Point(130, 270);
      this.cboPersonas.Size = new System.Drawing.Size(200, 23);
      this.cboPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      this.cboTenedor = new System.Windows.Forms.ComboBox();
      this.cboTenedor.Location = new System.Drawing.Point(510, 300);
      this.cboTenedor.Size = new System.Drawing.Size(200, 23);
      this.cboTenedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboTenedor.Visible = false;

      // TextBoxes
      this.txtNumero = new System.Windows.Forms.TextBox();
      this.txtNumero.Location = new System.Drawing.Point(130, 300);
      this.txtNumero.Size = new System.Drawing.Size(200, 23);
      this.txtNumero.MaxLength = 16;

      this.txtBanco = new System.Windows.Forms.TextBox();
      this.txtBanco.Location = new System.Drawing.Point(130, 360);
      this.txtBanco.Size = new System.Drawing.Size(200, 23);

      this.txtEmisora = new System.Windows.Forms.TextBox();
      this.txtEmisora.Location = new System.Drawing.Point(130, 390);
      this.txtEmisora.Size = new System.Drawing.Size(200, 23);

      this.txtAlias = new System.Windows.Forms.TextBox();
      this.txtAlias.Location = new System.Drawing.Point(130, 420);
      this.txtAlias.Size = new System.Drawing.Size(200, 23);

      // DateTimePicker
      this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
      this.dtpVencimiento.Location = new System.Drawing.Point(130, 330);
      this.dtpVencimiento.Size = new System.Drawing.Size(200, 23);
      this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      // NumericUpDown
      this.nudLimite = new System.Windows.Forms.NumericUpDown();
      this.nudLimite.Location = new System.Drawing.Point(510, 270);
      this.nudLimite.Size = new System.Drawing.Size(200, 23);
      this.nudLimite.Maximum = 1000000;
      this.nudLimite.DecimalPlaces = 2;
      this.nudLimite.Visible = false;

      // CheckBox
      this.chkExtension = new System.Windows.Forms.CheckBox();
      this.chkExtension.Location = new System.Drawing.Point(400, 240);
      this.chkExtension.Size = new System.Drawing.Size(200, 23);
      this.chkExtension.Text = "Es extensión";
      this.chkExtension.Visible = false;

      // Buttons
      this.btnGuardar = new System.Windows.Forms.Button();
      this.btnGuardar.Location = new System.Drawing.Point(130, 470);
      this.btnGuardar.Size = new System.Drawing.Size(90, 30);
      this.btnGuardar.Text = "Guardar";

      this.btnCancelar = new System.Windows.Forms.Button();
      this.btnCancelar.Location = new System.Drawing.Point(240, 470);
      this.btnCancelar.Size = new System.Drawing.Size(90, 30);
      this.btnCancelar.Text = "Cancelar";

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 520);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvTarjetas,
                this.lblTipoTarjeta, this.cboTipoTarjeta,
                this.lblPersona, this.cboPersonas,
                this.lblNumero, this.txtNumero,
                this.lblVencimiento, this.dtpVencimiento,
                this.lblBanco, this.txtBanco,
                this.lblEmisora, this.txtEmisora,
                this.lblAlias, this.txtAlias,
                this.lblLimite, this.nudLimite,
                this.chkExtension,
                this.lblTenedor, this.cboTenedor,
                this.btnGuardar, this.btnCancelar
            });
      this.Name = "FormTarjetas";
      this.Text = "Gestión de Tarjetas";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLimite)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}