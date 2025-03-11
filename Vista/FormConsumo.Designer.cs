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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblComercio = new System.Windows.Forms.Label();
            this.txtComercio = new System.Windows.Forms.TextBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.gbDescuentos = new System.Windows.Forms.GroupBox();
            this.lvDescuentos = new System.Windows.Forms.ListView();
            this.chDescripcion = new System.Windows.Forms.ColumnHeader();
            this.chBanco = new System.Windows.Forms.ColumnHeader();
            this.chValor = new System.Windows.Forms.ColumnHeader();
            this.chVigencia = new System.Windows.Forms.ColumnHeader();
            this.chSeleccionar = new System.Windows.Forms.ColumnHeader();
            this.btnBuscarDescuentos = new System.Windows.Forms.Button();
            this.lblMontoOriginal = new System.Windows.Forms.Label();
            this.txtMontoOriginal = new System.Windows.Forms.TextBox();
            this.lblMontoFinal = new System.Windows.Forms.Label();
            this.txtMontoFinal = new System.Windows.Forms.TextBox();
            this.lblLimiteDisponible = new System.Windows.Forms.Label();
            this.txtLimiteDisponible = new System.Windows.Forms.TextBox();
            this.chkEsRecurrente = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Consumo";

            // lblTarjeta
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(14, 50);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(46, 13);
            this.lblTarjeta.TabIndex = 1;
            this.lblTarjeta.Text = "Tarjeta:";

            // cmbTarjeta
            this.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(120, 50);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(250, 21);
            this.cmbTarjeta.TabIndex = 2;
            this.cmbTarjeta.SelectedIndexChanged += new System.EventHandler(this.cmbTarjeta_SelectedIndexChanged);

            // lblFecha
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(14, 80);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";

            // dtpFecha
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(120, 80);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 20);
            this.dtpFecha.TabIndex = 4;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);

            // lblHora
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(250, 80);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 13);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "Hora:";

            // dtpHora
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(290, 80);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(80, 20);
            this.dtpHora.TabIndex = 6;

            // lblDescripcion
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(14, 110);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripción:";

            // txtDescripcion
            this.txtDescripcion.Location = new System.Drawing.Point(120, 110);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(250, 40);
            this.txtDescripcion.TabIndex = 8;

            // lblComercio
            this.lblComercio.AutoSize = true;
            this.lblComercio.Location = new System.Drawing.Point(14, 160);
            this.lblComercio.Name = "lblComercio";
            this.lblComercio.Size = new System.Drawing.Size(54, 13);
            this.lblComercio.TabIndex = 9;
            this.lblComercio.Text = "Comercio:";

            // txtComercio
            this.txtComercio.Location = new System.Drawing.Point(120, 160);
            this.txtComercio.Name = "txtComercio";
            this.txtComercio.Size = new System.Drawing.Size(250, 20);
            this.txtComercio.TabIndex = 10;

            // lblRubro
            this.lblRubro.AutoSize = true;
            this.lblRubro.Location = new System.Drawing.Point(14, 190);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(39, 13);
            this.lblRubro.TabIndex = 11;
            this.lblRubro.Text = "Rubro:";

            // cmbRubro
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(120, 190);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(250, 21);
            this.cmbRubro.TabIndex = 12;

            // lblMonto
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(14, 220);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 13;
            this.lblMonto.Text = "Monto:";

            // numMonto
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Location = new System.Drawing.Point(120, 220);
            this.numMonto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(120, 20);
            this.numMonto.TabIndex = 14;
            this.numMonto.ValueChanged += new System.EventHandler(this.numMonto_ValueChanged);

            // lblMoneda
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(250, 220);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 15;
            this.lblMoneda.Text = "Moneda:";

            // cmbMoneda
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] { "ARS", "USD", "EUR" });
            this.cmbMoneda.Location = new System.Drawing.Point(300, 220);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(70, 21);
            this.cmbMoneda.TabIndex = 16;

            // gbDescuentos
            this.gbDescuentos.Location = new System.Drawing.Point(14, 250);
            this.gbDescuentos.Name = "gbDescuentos";
            this.gbDescuentos.Size = new System.Drawing.Size(520, 200);
            this.gbDescuentos.TabIndex = 17;
            this.gbDescuentos.TabStop = false;
            this.gbDescuentos.Text = "Descuentos Aplicables";

            // lvDescuentos
            this.lvDescuentos.CheckBoxes = true;
            this.lvDescuentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.chDescripcion,
                this.chBanco,
                this.chValor,
                this.chVigencia
            });
            this.lvDescuentos.FullRowSelect = true;
            this.lvDescuentos.GridLines = true;
            this.lvDescuentos.HideSelection = false;
            this.lvDescuentos.Location = new System.Drawing.Point(20, 290);
            this.lvDescuentos.Name = "lvDescuentos";
            this.lvDescuentos.Size = new System.Drawing.Size(500, 150);
            this.lvDescuentos.TabIndex = 18;
            this.lvDescuentos.UseCompatibleStateImageBehavior = false;
            this.lvDescuentos.View = System.Windows.Forms.View.Details;
            this.lvDescuentos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvDescuentos_ItemChecked);

            // chDescripcion
            this.chDescripcion.Text = "Descripción";
            this.chDescripcion.Width = 200;

            // chBanco
            this.chBanco.Text = "Banco/Entidad";
            this.chBanco.Width = 100;

            // chValor
            this.chValor.Text = "Valor";
            this.chValor.Width = 100;

            // chVigencia
            this.chVigencia.Text = "Vigencia";
            this.chVigencia.Width = 100;

            // btnBuscarDescuentos
            this.btnBuscarDescuentos.Location = new System.Drawing.Point(390, 220);
            this.btnBuscarDescuentos.Name = "btnBuscarDescuentos";
            this.btnBuscarDescuentos.Size = new System.Drawing.Size(130, 25);
            this.btnBuscarDescuentos.TabIndex = 19;
            this.btnBuscarDescuentos.Text = "Buscar Descuentos";
            this.btnBuscarDescuentos.UseVisualStyleBackColor = true;
            this.btnBuscarDescuentos.Click += new System.EventHandler(this.btnBuscarDescuentos_Click);

            // lblMontoOriginal
            this.lblMontoOriginal.AutoSize = true;
            this.lblMontoOriginal.Location = new System.Drawing.Point(14, 460);
            this.lblMontoOriginal.Name = "lblMontoOriginal";
            this.lblMontoOriginal.Size = new System.Drawing.Size(78, 13);
            this.lblMontoOriginal.TabIndex = 20;
            this.lblMontoOriginal.Text = "Monto Original:";

            // txtMontoOriginal
            this.txtMontoOriginal.Location = new System.Drawing.Point(120, 460);
            this.txtMontoOriginal.Name = "txtMontoOriginal";
            this.txtMontoOriginal.ReadOnly = true;
            this.txtMontoOriginal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoOriginal.TabIndex = 21;

            // lblMontoFinal
            this.lblMontoFinal.AutoSize = true;
            this.lblMontoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoFinal.Location = new System.Drawing.Point(250, 460);
            this.lblMontoFinal.Name = "lblMontoFinal";
            this.lblMontoFinal.Size = new System.Drawing.Size(78, 13);
            this.lblMontoFinal.TabIndex = 22;
            this.lblMontoFinal.Text = "Monto Final:";

            // txtMontoFinal
            this.txtMontoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoFinal.Location = new System.Drawing.Point(330, 460);
            this.txtMontoFinal.Name = "txtMontoFinal";
            this.txtMontoFinal.ReadOnly = true;
            this.txtMontoFinal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoFinal.TabIndex = 23;

            // lblLimiteDisponible
            this.lblLimiteDisponible.AutoSize = true;
            this.lblLimiteDisponible.Location = new System.Drawing.Point(14, 490);
            this.lblLimiteDisponible.Name = "lblLimiteDisponible";
            this.lblLimiteDisponible.Size = new System.Drawing.Size(99, 13);
            this.lblLimiteDisponible.TabIndex = 24;
            this.lblLimiteDisponible.Text = "Límite/Disponible:";

            // txtLimiteDisponible
            this.txtLimiteDisponible.Location = new System.Drawing.Point(120, 490);
            this.txtLimiteDisponible.Name = "txtLimiteDisponible";
            this.txtLimiteDisponible.ReadOnly = true;
            this.txtLimiteDisponible.Size = new System.Drawing.Size(100, 20);
            this.txtLimiteDisponible.TabIndex = 25;

            // chkEsRecurrente
            this.chkEsRecurrente.AutoSize = true;
            this.chkEsRecurrente.Location = new System.Drawing.Point(330, 490);
            this.chkEsRecurrente.Name = "chkEsRecurrente";
            this.chkEsRecurrente.Size = new System.Drawing.Size(115, 17);
            this.chkEsRecurrente.TabIndex = 26;
            this.chkEsRecurrente.Text = "Consumo recurrente";
            this.chkEsRecurrente.UseVisualStyleBackColor = true;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(170, 520);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(280, 520);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FormConsumo
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 570);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.cmbTarjeta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblComercio);
            this.Controls.Add(this.txtComercio);
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.numMonto);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.gbDescuentos);
            this.Controls.Add(this.lvDescuentos);
            this.Controls.Add(this.btnBuscarDescuentos);
            this.Controls.Add(this.lblMontoOriginal);
            this.Controls.Add(this.txtMontoOriginal);
            this.Controls.Add(this.lblMontoFinal);
            this.Controls.Add(this.txtMontoFinal);
            this.Controls.Add(this.lblLimiteDisponible);
            this.Controls.Add(this.txtLimiteDisponible);
            this.Controls.Add(this.chkEsRecurrente);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "FormConsumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Consumo";
            this.Load += new System.EventHandler(this.FormConsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbDescuentos;
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
    }
}