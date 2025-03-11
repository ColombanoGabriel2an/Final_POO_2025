namespace Vista
{
    partial class FormAcreditacion
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbTarjetas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTarjeta;

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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbTarjetas = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.SuspendLayout();

            // txtDescripcion
            this.txtDescripcion.Location = new System.Drawing.Point(130, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 20);
            this.txtDescripcion.TabIndex = 1;

            // nudMonto
            this.nudMonto.Location = new System.Drawing.Point(130, 70);
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(200, 20);
            this.nudMonto.TabIndex = 3;

            // dtpFecha
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(130, 110);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 5;

            // cmbTarjetas
            this.cmbTarjetas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjetas.FormattingEnabled = true;
            this.cmbTarjetas.Location = new System.Drawing.Point(130, 150);
            this.cmbTarjetas.Name = "cmbTarjetas";
            this.cmbTarjetas.Size = new System.Drawing.Size(200, 21);
            this.cmbTarjetas.TabIndex = 7;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(130, 190);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 30);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(235, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(235, 230);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 30);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // btnBorrar
            this.btnBorrar.Location = new System.Drawing.Point(130, 230);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(95, 30);
            this.btnBorrar.TabIndex = 12;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);

            // lblDescripcion
            this.lblDescripcion.Location = new System.Drawing.Point(20, 30);
            this.lblDescripcion.Text = "Descripción:";

            // lblMonto
            this.lblMonto.Location = new System.Drawing.Point(20, 70);
            this.lblMonto.Text = "Monto:";

            // lblFecha
            this.lblFecha.Location = new System.Drawing.Point(20, 110);
            this.lblFecha.Text = "Fecha de Acreditación:";

            // lblTarjeta
            this.lblTarjeta.Location = new System.Drawing.Point(20, 150);
            this.lblTarjeta.Text = "Tarjeta:";

            // FormAcreditacion
            this.ClientSize = new System.Drawing.Size(380, 280);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.cmbTarjetas);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.nudMonto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Name = "FormAcreditacion";
            this.Text = "Gestión de Acreditaciones";
            this.Load += new System.EventHandler(this.FormAcreditacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
