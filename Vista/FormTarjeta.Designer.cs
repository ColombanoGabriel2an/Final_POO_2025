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
        private System.Windows.Forms.GroupBox gbTipoTarjeta;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbDebito;

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
            this.cmbTenedor = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblEntidadEmisora = new System.Windows.Forms.Label();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblLimite = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.lblTenedor = new System.Windows.Forms.Label();
            this.dgvTarjetas = new System.Windows.Forms.DataGridView();
            this.gbTipoTarjeta = new System.Windows.Forms.GroupBox();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbDebito = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(12, 88);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(200, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.PlaceholderText = "Número de Tarjeta";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(12, 138);
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
            this.cmbBanco.Location = new System.Drawing.Point(12, 188);
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
          "Mastercard",
          "American Express",
          "Naranja",
          "Cabal",
      });
            this.cmbEntidadEmisora.Location = new System.Drawing.Point(12, 238);
            this.cmbEntidadEmisora.Name = "cmbEntidadEmisora";
            this.cmbEntidadEmisora.Size = new System.Drawing.Size(200, 21);
            this.cmbEntidadEmisora.TabIndex = 3;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(12, 288);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(200, 20);
            this.txtAlias.TabIndex = 4;
            this.txtAlias.PlaceholderText = "Alias";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(12, 338);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(200, 20);
            this.txtLimite.TabIndex = 5;
            this.txtLimite.PlaceholderText = "Límite";
            // 
            // txtDisponible
            // 
            this.txtDisponible.Location = new System.Drawing.Point(12, 388);
            this.txtDisponible.Name = "txtDisponible";
            this.txtDisponible.Size = new System.Drawing.Size(200, 20);
            this.txtDisponible.TabIndex = 6;
            this.txtDisponible.PlaceholderText = "Disponible";
            // 
            // chkIsExtension
            // 
            this.chkIsExtension.AutoSize = true;
            this.chkIsExtension.Location = new System.Drawing.Point(12, 438);
            this.chkIsExtension.Name = "chkIsExtension";
            this.chkIsExtension.Size = new System.Drawing.Size(78, 17);
            this.chkIsExtension.TabIndex = 7;
            this.chkIsExtension.Text = "Es Extensión";
            this.chkIsExtension.UseVisualStyleBackColor = true;
            // 
            // cmbTenedor
            // 
            this.cmbTenedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenedor.FormattingEnabled = true;
            this.cmbTenedor.Location = new System.Drawing.Point(12, 488);
            this.cmbTenedor.Name = "cmbTenedor";
            this.cmbTenedor.Size = new System.Drawing.Size(200, 21);
            this.cmbTenedor.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 538);
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
            this.lblNumero.Location = new System.Drawing.Point(12, 72);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(47, 13);
            this.lblNumero.TabIndex = 10;
            this.lblNumero.Text = "Número:";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(12, 122);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(108, 13);
            this.lblFechaVencimiento.TabIndex = 11;
            this.lblFechaVencimiento.Text = "Fecha de Vencimiento:";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(12, 172);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 12;
            this.lblBanco.Text = "Banco:";
            // 
            // lblEntidadEmisora
            // 
            this.lblEntidadEmisora.AutoSize = true;
            this.lblEntidadEmisora.Location = new System.Drawing.Point(12, 222);
            this.lblEntidadEmisora.Name = "lblEntidadEmisora";
            this.lblEntidadEmisora.Size = new System.Drawing.Size(85, 13);
            this.lblEntidadEmisora.TabIndex = 13;
            this.lblEntidadEmisora.Text = "Entidad Emisora:";
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(12, 272);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(32, 13);
            this.lblAlias.TabIndex = 14;
            this.lblAlias.Text = "Alias:";
            // 
            // lblLimite
            // 
            this.lblLimite.AutoSize = true;
            this.lblLimite.Location = new System.Drawing.Point(12, 322);
            this.lblLimite.Name = "lblLimite";
            this.lblLimite.Size = new System.Drawing.Size(37, 13);
            this.lblLimite.TabIndex = 15;
            this.lblLimite.Text = "Límite:";
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Location = new System.Drawing.Point(12, 372);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(59, 13);
            this.lblDisponible.TabIndex = 16;
            this.lblDisponible.Text = "Disponible:";
            // 
            // lblTenedor
            // 
            this.lblTenedor.AutoSize = true;
            this.lblTenedor.Location = new System.Drawing.Point(12, 472);
            this.lblTenedor.Name = "lblTenedor";
            this.lblTenedor.Size = new System.Drawing.Size(52, 13);
            this.lblTenedor.TabIndex = 17;
            this.lblTenedor.Text = "Tenedor:";
            // 
            // dgvTarjetas
            // 
            this.dgvTarjetas.AllowUserToAddRows = false;
            this.dgvTarjetas.AllowUserToDeleteRows = false;
            this.dgvTarjetas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarjetas.Location = new System.Drawing.Point(250, 28);
            this.dgvTarjetas.MultiSelect = false;
            this.dgvTarjetas.Name = "dgvTarjetas";
            this.dgvTarjetas.ReadOnly = true;
            this.dgvTarjetas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarjetas.Size = new System.Drawing.Size(500, 473);
            this.dgvTarjetas.TabIndex = 18;
            this.dgvTarjetas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarjetas_CellClick);
            // 
            // gbTipoTarjeta
            // 
            this.gbTipoTarjeta.Location = new System.Drawing.Point(12, 12);
            this.gbTipoTarjeta.Name = "gbTipoTarjeta";
            this.gbTipoTarjeta.Size = new System.Drawing.Size(200, 50);
            this.gbTipoTarjeta.TabIndex = 0;
            this.gbTipoTarjeta.TabStop = false;
            this.gbTipoTarjeta.Text = "Tipo de Tarjeta";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Checked = true;
            this.rbCredito.Location = new System.Drawing.Point(15, 20);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(61, 17);
            this.rbCredito.TabIndex = 0;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            this.rbCredito.CheckedChanged += new System.EventHandler(this.rbTipoTarjeta_CheckedChanged);
            // 
            // rbDebito
            // 
            this.rbDebito.AutoSize = true;
            this.rbDebito.Location = new System.Drawing.Point(110, 20);
            this.rbDebito.Name = "rbDebito";
            this.rbDebito.Size = new System.Drawing.Size(57, 17);
            this.rbDebito.TabIndex = 1;
            this.rbDebito.Text = "Débito";
            this.rbDebito.UseVisualStyleBackColor = true;
            this.rbDebito.CheckedChanged += new System.EventHandler(this.rbTipoTarjeta_CheckedChanged);
            // 
            // TarjetaForm
            // 
            this.ClientSize = new System.Drawing.Size(770, 573);
            this.Controls.Add(this.gbTipoTarjeta);
            this.gbTipoTarjeta.Controls.Add(this.rbCredito);
            this.gbTipoTarjeta.Controls.Add(this.rbDebito);
            this.Controls.Add(this.dgvTarjetas);
            this.Controls.Add(this.lblTenedor);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.lblLimite);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.lblEntidadEmisora);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbTenedor);
            this.Controls.Add(this.chkIsExtension);
            this.Controls.Add(this.txtDisponible);
            this.Controls.Add(this.txtLimite);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.cmbEntidadEmisora);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.txtNumero);
            this.Name = "TarjetaForm";
            this.Text = "Gestión de Tarjetas";
            this.Load += new System.EventHandler(this.FormTarjeta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbTenedor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvTarjetas;
        private System.Windows.Forms.Label lblTenedor;
    }
}