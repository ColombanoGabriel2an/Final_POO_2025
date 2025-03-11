namespace Vista
{
    partial class FormTarjeta
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblEntidadEmisora;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblLimite;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label lblTenedorId;

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
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.cmbEntidadEmisora = new System.Windows.Forms.ComboBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.txtDisponible = new System.Windows.Forms.TextBox();
            this.chkIsExtension = new System.Windows.Forms.CheckBox();
            this.txtTenedorId = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblEntidadEmisora = new System.Windows.Forms.Label();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblLimite = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblTenedorId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(12, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(200, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.PlaceholderText = "Número de Tarjeta";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(12, 78);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVencimiento.TabIndex = 1;
            // 
            // cmbBanco
            // 
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Items.AddRange(new object[] {
          "Banco Nación",
          "Banco Provincia",
          "Banco Ciudad",
          "Banco Galicia",
          "Banco Santander",
          "Banco BBVA",
          "Banco ICBC",
          "Banco Macro"
      });
            this.cmbBanco.Location = new System.Drawing.Point(12, 128);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(200, 21);
            this.cmbBanco.TabIndex = 2;
            // 
            // cmbEntidadEmisora
            // 
            this.cmbEntidadEmisora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntidadEmisora.FormattingEnabled = true;
            this.cmbEntidadEmisora.Items.AddRange(new object[] {
          "VISA",
          "MasterCard",
          "American Express",
          "Naranja",
          "Cabal",
          "Diners Club"
      });
            this.cmbEntidadEmisora.Location = new System.Drawing.Point(12, 178);
            this.cmbEntidadEmisora.Name = "cmbEntidadEmisora";
            this.cmbEntidadEmisora.Size = new System.Drawing.Size(200, 21);
            this.cmbEntidadEmisora.TabIndex = 3;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(12, 228);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(200, 20);
            this.txtAlias.TabIndex = 4;
            this.txtAlias.PlaceholderText = "Alias";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(12, 278);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(200, 20);
            this.txtLimite.TabIndex = 5;
            this.txtLimite.PlaceholderText = "Límite";
            // 
            // txtDisponible
            // 
            this.txtDisponible.Location = new System.Drawing.Point(12, 328);
            this.txtDisponible.Name = "txtDisponible";
            this.txtDisponible.Size = new System.Drawing.Size(200, 20);
            this.txtDisponible.TabIndex = 6;
            this.txtDisponible.PlaceholderText = "Disponible";
            // 
            // chkIsExtension
            // 
            this.chkIsExtension.AutoSize = true;
            this.chkIsExtension.Location = new System.Drawing.Point(12, 378);
            this.chkIsExtension.Name = "chkIsExtension";
            this.chkIsExtension.Size = new System.Drawing.Size(78, 17);
            this.chkIsExtension.TabIndex = 7;
            this.chkIsExtension.Text = "Es Extensión";
            this.chkIsExtension.UseVisualStyleBackColor = true;
            // 
            // txtTenedorId
            // 
            this.txtTenedorId.Location = new System.Drawing.Point(12, 428);
            this.txtTenedorId.Name = "txtTenedorId";
            this.txtTenedorId.Size = new System.Drawing.Size(200, 20);
            this.txtTenedorId.TabIndex = 8;
            this.txtTenedorId.PlaceholderText = "ID del Tenedor";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 478);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(12, 12);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 10;
            this.lblNumero.Text = "Número:";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(12, 62);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(108, 13);
            this.lblFechaVencimiento.TabIndex = 11;
            this.lblFechaVencimiento.Text = "Fecha de Vencimiento:";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(12, 112);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 12;
            this.lblBanco.Text = "Banco:";
            // 
            // lblEntidadEmisora
            // 
            this.lblEntidadEmisora.AutoSize = true;
            this.lblEntidadEmisora.Location = new System.Drawing.Point(12, 162);
            this.lblEntidadEmisora.Name = "lblEntidadEmisora";
            this.lblEntidadEmisora.Size = new System.Drawing.Size(85, 13);
            this.lblEntidadEmisora.TabIndex = 13;
            this.lblEntidadEmisora.Text = "Entidad Emisora:";
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(12, 212);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(32, 13);
            this.lblAlias.TabIndex = 14;
            this.lblAlias.Text = "Alias:";
            // 
            // lblLimite
            // 
            this.lblLimite.AutoSize = true;
            this.lblLimite.Location = new System.Drawing.Point(12, 262);
            this.lblLimite.Name = "lblLimite";
            this.lblLimite.Size = new System.Drawing.Size(37, 13);
            this.lblLimite.TabIndex = 15;
            this.lblLimite.Text = "Límite:";
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Location = new System.Drawing.Point(12, 312);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(59, 13);
            this.lblDisponible.TabIndex = 16;
            this.lblDisponible.Text = "Disponible:";
            // 
            // lblTenedorId
            // 
            this.lblTenedorId.AutoSize = true;
            this.lblTenedorId.Location = new System.Drawing.Point(12, 412);
            this.lblTenedorId.Name = "lblTenedorId";
            this.lblTenedorId.Size = new System.Drawing.Size(63, 13);
            this.lblTenedorId.TabIndex = 17;
            this.lblTenedorId.Text = "ID Tenedor:";
            // 
            // TarjetaForm
            // 
            this.ClientSize = new System.Drawing.Size(224, 513);
            this.Controls.Add(this.lblTenedorId);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.lblLimite);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.lblEntidadEmisora);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTenedorId);
            this.Controls.Add(this.chkIsExtension);
            this.Controls.Add(this.txtDisponible);
            this.Controls.Add(this.txtLimite);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.cmbEntidadEmisora);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.txtNumero);
            this.Name = "TarjetaForm";
            this.Text = "Formulario de Tarjeta";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.ComboBox cmbEntidadEmisora;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.TextBox txtDisponible;
        private System.Windows.Forms.CheckBox chkIsExtension;
        private System.Windows.Forms.TextBox txtTenedorId;
        private System.Windows.Forms.Button btnGuardar;
    }
}
