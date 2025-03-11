namespace Vista
{
  partial class FormReportes
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox cboTarjetas;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Button btnGenerar;
    private System.Windows.Forms.DataGridView dgvMovimientos;
    private System.Windows.Forms.Label lblTarjeta;
    private System.Windows.Forms.Label lblDesde;
    private System.Windows.Forms.Label lblHasta;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblDescuentos;

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

      this.lblDesde = new System.Windows.Forms.Label();
      this.lblDesde.Location = new System.Drawing.Point(20, 50);
      this.lblDesde.Size = new System.Drawing.Size(100, 23);
      this.lblDesde.Text = "Desde:";

      this.lblHasta = new System.Windows.Forms.Label();
      this.lblHasta.Location = new System.Drawing.Point(350, 50);
      this.lblHasta.Size = new System.Drawing.Size(100, 23);
      this.lblHasta.Text = "Hasta:";

      this.lblTotal = new System.Windows.Forms.Label();
      this.lblTotal.Location = new System.Drawing.Point(20, 520);
      this.lblTotal.Size = new System.Drawing.Size(200, 23);
      this.lblTotal.Text = "Total: $0.00";
      this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

      this.lblDescuentos = new System.Windows.Forms.Label();
      this.lblDescuentos.Location = new System.Drawing.Point(350, 520);
      this.lblDescuentos.Size = new System.Drawing.Size(200, 23);
      this.lblDescuentos.Text = "Descuentos: $0.00";
      this.lblDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

      // ComboBox
      this.cboTarjetas = new System.Windows.Forms.ComboBox();
      this.cboTarjetas.Location = new System.Drawing.Point(130, 20);
      this.cboTarjetas.Size = new System.Drawing.Size(200, 23);
      this.cboTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

      // DateTimePickers
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.dtpDesde.Location = new System.Drawing.Point(130, 50);
      this.dtpDesde.Size = new System.Drawing.Size(200, 23);
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.dtpHasta.Location = new System.Drawing.Point(460, 50);
      this.dtpHasta.Size = new System.Drawing.Size(200, 23);
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

      // Button
      this.btnGenerar = new System.Windows.Forms.Button();
      this.btnGenerar.Location = new System.Drawing.Point(680, 45);
      this.btnGenerar.Size = new System.Drawing.Size(90, 30);
      this.btnGenerar.Text = "Generar";

      // DataGridView
      this.dgvMovimientos = new System.Windows.Forms.DataGridView();
      this.dgvMovimientos.Location = new System.Drawing.Point(20, 90);
      this.dgvMovimientos.Size = new System.Drawing.Size(750, 420);
      this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvMovimientos.MultiSelect = false;
      this.dgvMovimientos.ReadOnly = true;

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 560);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTarjeta, this.cboTarjetas,
                this.lblDesde, this.dtpDesde,
                this.lblHasta, this.dtpHasta,
                this.btnGenerar,
                this.dgvMovimientos,
                this.lblTotal,
                this.lblDescuentos
            });
      this.Name = "FormReportes";
      this.Text = "Reportes de Movimientos";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}