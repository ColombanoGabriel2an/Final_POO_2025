using System.Windows.Forms;

namespace Vista
{
    partial class FormConsumo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblTarjeta = new Label();
            cmbTarjeta = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblComercio = new Label();
            txtComercio = new TextBox();
            lblRubro = new Label();
            cmbRubro = new ComboBox();
            lblMonto = new Label();
            numMonto = new NumericUpDown();
            lblMoneda = new Label();
            cmbMoneda = new ComboBox();
            lvDescuentos = new ListView();
            chDescripcion = new ColumnHeader();
            chBanco = new ColumnHeader();
            chValor = new ColumnHeader();
            chVigencia = new ColumnHeader();
            chSeleccionar = new ColumnHeader();
            btnBuscarDescuentos = new Button();
            lblMontoOriginal = new Label();
            txtMontoOriginal = new TextBox();
            lblMontoFinal = new Label();
            txtMontoFinal = new TextBox();
            lblLimiteDisponible = new Label();
            txtLimiteDisponible = new TextBox();
            chkEsRecurrente = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            gbConsumosActuales = new GroupBox();
            dgvConsumosActuales = new DataGridView();
            lblTotalConsumosActuales = new Label();
            gbResumenDescuentos = new GroupBox();
            lvResumenDescuentos = new ListView();
            lblAhorroTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            gbConsumosActuales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsumosActuales).BeginInit();
            gbResumenDescuentos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(14, 10);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(212, 24);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Consumo";
            // 
            // lblTarjeta
            // 
            lblTarjeta.AutoSize = true;
            lblTarjeta.Location = new Point(16, 58);
            lblTarjeta.Margin = new Padding(4, 0, 4, 0);
            lblTarjeta.Name = "lblTarjeta";
            lblTarjeta.Size = new Size(44, 15);
            lblTarjeta.TabIndex = 1;
            lblTarjeta.Text = "Tarjeta:";
            // 
            // cmbTarjeta
            // 
            cmbTarjeta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarjeta.FormattingEnabled = true;
            cmbTarjeta.Location = new Point(140, 58);
            cmbTarjeta.Margin = new Padding(4, 3, 4, 3);
            cmbTarjeta.Name = "cmbTarjeta";
            cmbTarjeta.Size = new Size(291, 23);
            cmbTarjeta.TabIndex = 2;
            cmbTarjeta.SelectedIndexChanged += cmbTarjeta_SelectedIndexChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(16, 92);
            lblFecha.Margin = new Padding(4, 0, 4, 0);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(140, 92);
            dtpFecha.Margin = new Padding(4, 3, 4, 3);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(139, 23);
            dtpFecha.TabIndex = 4;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(292, 92);
            lblHora.Margin = new Padding(4, 0, 4, 0);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(36, 15);
            lblHora.TabIndex = 5;
            lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(338, 92);
            dtpHora.Margin = new Padding(4, 3, 4, 3);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(93, 23);
            dtpHora.TabIndex = 6;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(16, 127);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 7;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(140, 127);
            txtDescripcion.Margin = new Padding(4, 3, 4, 3);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(291, 46);
            txtDescripcion.TabIndex = 8;
            // 
            // lblComercio
            // 
            lblComercio.AutoSize = true;
            lblComercio.Location = new Point(16, 185);
            lblComercio.Margin = new Padding(4, 0, 4, 0);
            lblComercio.Name = "lblComercio";
            lblComercio.Size = new Size(62, 15);
            lblComercio.TabIndex = 9;
            lblComercio.Text = "Comercio:";
            // 
            // txtComercio
            // 
            txtComercio.Location = new Point(140, 185);
            txtComercio.Margin = new Padding(4, 3, 4, 3);
            txtComercio.Name = "txtComercio";
            txtComercio.Size = new Size(291, 23);
            txtComercio.TabIndex = 10;
            // 
            // lblRubro
            // 
            lblRubro.AutoSize = true;
            lblRubro.Location = new Point(16, 219);
            lblRubro.Margin = new Padding(4, 0, 4, 0);
            lblRubro.Name = "lblRubro";
            lblRubro.Size = new Size(42, 15);
            lblRubro.TabIndex = 11;
            lblRubro.Text = "Rubro:";
            // 
            // cmbRubro
            // 
            cmbRubro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRubro.FormattingEnabled = true;
            cmbRubro.Location = new Point(140, 219);
            cmbRubro.Margin = new Padding(4, 3, 4, 3);
            cmbRubro.Name = "cmbRubro";
            cmbRubro.Size = new Size(291, 23);
            cmbRubro.TabIndex = 12;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(16, 254);
            lblMonto.Margin = new Padding(4, 0, 4, 0);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(46, 15);
            lblMonto.TabIndex = 13;
            lblMonto.Text = "Monto:";
            // 
            // numMonto
            // 
            numMonto.DecimalPlaces = 2;
            numMonto.Location = new Point(140, 254);
            numMonto.Margin = new Padding(4, 3, 4, 3);
            numMonto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(140, 23);
            numMonto.TabIndex = 14;
            numMonto.ValueChanged += numMonto_ValueChanged;
            // 
            // lblMoneda
            // 
            lblMoneda.AutoSize = true;
            lblMoneda.Location = new Point(292, 254);
            lblMoneda.Margin = new Padding(4, 0, 4, 0);
            lblMoneda.Name = "lblMoneda";
            lblMoneda.Size = new Size(54, 15);
            lblMoneda.TabIndex = 15;
            lblMoneda.Text = "Moneda:";
            // 
            // cmbMoneda
            // 
            cmbMoneda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMoneda.FormattingEnabled = true;
            cmbMoneda.Items.AddRange(new object[] { "ARS", "USD", "EUR" });
            cmbMoneda.Location = new Point(350, 254);
            cmbMoneda.Margin = new Padding(4, 3, 4, 3);
            cmbMoneda.Name = "cmbMoneda";
            cmbMoneda.Size = new Size(81, 23);
            cmbMoneda.TabIndex = 16;
            // 
            // lvDescuentos
            // 
            lvDescuentos.CheckBoxes = true;
            lvDescuentos.Columns.AddRange(new ColumnHeader[] { chDescripcion, chBanco, chValor, chVigencia });
            lvDescuentos.FullRowSelect = true;
            lvDescuentos.GridLines = true;
            lvDescuentos.Location = new Point(16, 288);
            lvDescuentos.Margin = new Padding(4, 3, 4, 3);
            lvDescuentos.Name = "lvDescuentos";
            lvDescuentos.Size = new Size(606, 127);
            lvDescuentos.TabIndex = 18;
            lvDescuentos.UseCompatibleStateImageBehavior = false;
            lvDescuentos.View = View.Details;
            lvDescuentos.ItemChecked += lvDescuentos_ItemChecked;
            // 
            // btnBuscarDescuentos
            // 
            btnBuscarDescuentos.Location = new Point(455, 254);
            btnBuscarDescuentos.Margin = new Padding(4, 3, 4, 3);
            btnBuscarDescuentos.Name = "btnBuscarDescuentos";
            btnBuscarDescuentos.Size = new Size(152, 29);
            btnBuscarDescuentos.TabIndex = 19;
            btnBuscarDescuentos.Text = "Buscar Descuentos";
            btnBuscarDescuentos.UseVisualStyleBackColor = true;
            btnBuscarDescuentos.Click += btnBuscarDescuentos_Click;
            // 
            // lblMontoOriginal
            // 
            lblMontoOriginal.AutoSize = true;
            lblMontoOriginal.Location = new Point(16, 581);
            lblMontoOriginal.Margin = new Padding(4, 0, 4, 0);
            lblMontoOriginal.Name = "lblMontoOriginal";
            lblMontoOriginal.Size = new Size(91, 15);
            lblMontoOriginal.TabIndex = 20;
            lblMontoOriginal.Text = "Monto Original:";
            // 
            // txtMontoOriginal
            // 
            txtMontoOriginal.Location = new Point(140, 581);
            txtMontoOriginal.Margin = new Padding(4, 3, 4, 3);
            txtMontoOriginal.Name = "txtMontoOriginal";
            txtMontoOriginal.ReadOnly = true;
            txtMontoOriginal.Size = new Size(116, 23);
            txtMontoOriginal.TabIndex = 21;
            // 
            // lblMontoFinal
            // 
            lblMontoFinal.AutoSize = true;
            lblMontoFinal.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMontoFinal.Location = new Point(292, 581);
            lblMontoFinal.Margin = new Padding(4, 0, 4, 0);
            lblMontoFinal.Name = "lblMontoFinal";
            lblMontoFinal.Size = new Size(77, 13);
            lblMontoFinal.TabIndex = 22;
            lblMontoFinal.Text = "Monto Final:";
            // 
            // txtMontoFinal
            // 
            txtMontoFinal.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtMontoFinal.Location = new Point(385, 581);
            txtMontoFinal.Margin = new Padding(4, 3, 4, 3);
            txtMontoFinal.Name = "txtMontoFinal";
            txtMontoFinal.ReadOnly = true;
            txtMontoFinal.Size = new Size(116, 20);
            txtMontoFinal.TabIndex = 23;
            // 
            // lblLimiteDisponible
            // 
            lblLimiteDisponible.AutoSize = true;
            lblLimiteDisponible.Location = new Point(16, 615);
            lblLimiteDisponible.Margin = new Padding(4, 0, 4, 0);
            lblLimiteDisponible.Name = "lblLimiteDisponible";
            lblLimiteDisponible.Size = new Size(104, 15);
            lblLimiteDisponible.TabIndex = 24;
            lblLimiteDisponible.Text = "Límite/Disponible:";
            // 
            // txtLimiteDisponible
            // 
            txtLimiteDisponible.Location = new Point(140, 615);
            txtLimiteDisponible.Margin = new Padding(4, 3, 4, 3);
            txtLimiteDisponible.Name = "txtLimiteDisponible";
            txtLimiteDisponible.ReadOnly = true;
            txtLimiteDisponible.Size = new Size(116, 23);
            txtLimiteDisponible.TabIndex = 25;
            // 
            // chkEsRecurrente
            // 
            chkEsRecurrente.AutoSize = true;
            chkEsRecurrente.Location = new Point(385, 615);
            chkEsRecurrente.Margin = new Padding(4, 3, 4, 3);
            chkEsRecurrente.Name = "chkEsRecurrente";
            chkEsRecurrente.Size = new Size(135, 19);
            chkEsRecurrente.TabIndex = 26;
            chkEsRecurrente.Text = "Consumo recurrente";
            chkEsRecurrente.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(198, 650);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(117, 35);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(327, 650);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 35);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // gbConsumosActuales
            // 
            gbConsumosActuales.Controls.Add(dgvConsumosActuales);
            gbConsumosActuales.Controls.Add(lblTotalConsumosActuales);
            gbConsumosActuales.Location = new Point(642, 58);
            gbConsumosActuales.Margin = new Padding(4, 3, 4, 3);
            gbConsumosActuales.Name = "gbConsumosActuales";
            gbConsumosActuales.Padding = new Padding(4, 3, 4, 3);
            gbConsumosActuales.Size = new Size(467, 462);
            gbConsumosActuales.TabIndex = 0;
            gbConsumosActuales.TabStop = false;
            gbConsumosActuales.Text = "Consumos actuales de la tarjeta";
            // 
            // dgvConsumosActuales
            // 
            dgvConsumosActuales.AllowUserToAddRows = false;
            dgvConsumosActuales.AllowUserToDeleteRows = false;
            dgvConsumosActuales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsumosActuales.Location = new Point(12, 23);
            dgvConsumosActuales.Margin = new Padding(4, 3, 4, 3);
            dgvConsumosActuales.Name = "dgvConsumosActuales";
            dgvConsumosActuales.ReadOnly = true;
            dgvConsumosActuales.Size = new Size(443, 404);
            dgvConsumosActuales.TabIndex = 0;
            // 
            // lblTotalConsumosActuales
            // 
            lblTotalConsumosActuales.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalConsumosActuales.Location = new Point(12, 433);
            lblTotalConsumosActuales.Margin = new Padding(4, 0, 4, 0);
            lblTotalConsumosActuales.Name = "lblTotalConsumosActuales";
            lblTotalConsumosActuales.Size = new Size(443, 23);
            lblTotalConsumosActuales.TabIndex = 1;
            lblTotalConsumosActuales.TextAlign = ContentAlignment.MiddleRight;
            // 
            // gbResumenDescuentos
            // 
            gbResumenDescuentos.Controls.Add(lvResumenDescuentos);
            gbResumenDescuentos.Controls.Add(lblAhorroTotal);
            gbResumenDescuentos.Location = new Point(16, 420);
            gbResumenDescuentos.Margin = new Padding(4, 3, 4, 3);
            gbResumenDescuentos.Name = "gbResumenDescuentos";
            gbResumenDescuentos.Padding = new Padding(4, 3, 4, 3);
            gbResumenDescuentos.Size = new Size(607, 138);
            gbResumenDescuentos.TabIndex = 29;
            gbResumenDescuentos.TabStop = false;
            gbResumenDescuentos.Text = "Resumen de Descuentos Aplicados";
            // 
            // lvResumenDescuentos
            // 
            lvResumenDescuentos.FullRowSelect = true;
            lvResumenDescuentos.GridLines = true;
            lvResumenDescuentos.Location = new Point(12, 23);
            lvResumenDescuentos.Margin = new Padding(4, 3, 4, 3);
            lvResumenDescuentos.Name = "lvResumenDescuentos";
            lvResumenDescuentos.Size = new Size(583, 80);
            lvResumenDescuentos.TabIndex = 30;
            lvResumenDescuentos.UseCompatibleStateImageBehavior = false;
            lvResumenDescuentos.View = View.Details;
            // 
            // lblAhorroTotal
            // 
            lblAhorroTotal.AutoSize = true;
            lblAhorroTotal.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblAhorroTotal.Location = new Point(408, 110);
            lblAhorroTotal.Margin = new Padding(4, 0, 4, 0);
            lblAhorroTotal.Name = "lblAhorroTotal";
            lblAhorroTotal.Size = new Size(129, 15);
            lblAhorroTotal.TabIndex = 31;
            lblAhorroTotal.Text = "Ahorro Total: $0.00";
            lblAhorroTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormConsumo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(gbConsumosActuales);
            Controls.Add(gbResumenDescuentos);
            Controls.Add(lblTitulo);
            Controls.Add(lblTarjeta);
            Controls.Add(cmbTarjeta);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblHora);
            Controls.Add(dtpHora);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblComercio);
            Controls.Add(txtComercio);
            Controls.Add(lblRubro);
            Controls.Add(cmbRubro);
            Controls.Add(lblMonto);
            Controls.Add(numMonto);
            Controls.Add(lblMoneda);
            Controls.Add(cmbMoneda);
            Controls.Add(lvDescuentos);
            Controls.Add(btnBuscarDescuentos);
            Controls.Add(lblMontoOriginal);
            Controls.Add(txtMontoOriginal);
            Controls.Add(lblMontoFinal);
            Controls.Add(txtMontoFinal);
            Controls.Add(lblLimiteDisponible);
            Controls.Add(txtLimiteDisponible);
            Controls.Add(chkEsRecurrente);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormConsumo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Consumo";
            Load += FormConsumo_Load;
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            gbConsumosActuales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsumosActuales).EndInit();
            gbResumenDescuentos.ResumeLayout(false);
            gbResumenDescuentos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblComercio;
        private System.Windows.Forms.TextBox txtComercio;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.ListView lvDescuentos;
        private System.Windows.Forms.ColumnHeader chDescripcion;
        private System.Windows.Forms.ColumnHeader chBanco;
        private System.Windows.Forms.ColumnHeader chValor;
        private System.Windows.Forms.ColumnHeader chVigencia;
        private System.Windows.Forms.ColumnHeader chSeleccionar;
        private System.Windows.Forms.Button btnBuscarDescuentos;
        private System.Windows.Forms.Label lblMontoOriginal;
        private System.Windows.Forms.TextBox txtMontoOriginal;
        private System.Windows.Forms.Label lblMontoFinal;
        private System.Windows.Forms.TextBox txtMontoFinal;
        private System.Windows.Forms.Label lblLimiteDisponible;
        private System.Windows.Forms.TextBox txtLimiteDisponible;
        private System.Windows.Forms.CheckBox chkEsRecurrente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbConsumosActuales;
        private System.Windows.Forms.DataGridView dgvConsumosActuales;
        private System.Windows.Forms.Label lblTotalConsumosActuales;
        private System.Windows.Forms.GroupBox gbResumenDescuentos;
        private System.Windows.Forms.ListView lvResumenDescuentos;
        private System.Windows.Forms.Label lblAhorroTotal;
    }
}