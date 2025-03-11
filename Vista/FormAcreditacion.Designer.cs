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
            txtDescripcion = new TextBox();
            nudMonto = new NumericUpDown();
            dtpFecha = new DateTimePicker();
            cmbTarjetas = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            btnBorrar = new Button();
            lblDescripcion = new Label();
            lblMonto = new Label();
            lblFecha = new Label();
            lblTarjeta = new Label();
            ((System.ComponentModel.ISupportInitialize)nudMonto).BeginInit();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(130, 30);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // nudMonto
            // 
            nudMonto.Location = new Point(130, 70);
            nudMonto.Name = "nudMonto";
            nudMonto.Size = new Size(200, 23);
            nudMonto.TabIndex = 3;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(130, 110);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 5;
            // 
            // cmbTarjetas
            // 
            cmbTarjetas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarjetas.FormattingEnabled = true;
            cmbTarjetas.Location = new Point(130, 150);
            cmbTarjetas.Name = "cmbTarjetas";
            cmbTarjetas.Size = new Size(200, 23);
            cmbTarjetas.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(130, 190);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(95, 30);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(235, 190);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(95, 30);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(235, 230);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(95, 30);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(130, 230);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(95, 30);
            btnBorrar.TabIndex = 12;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(20, 30);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(100, 23);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblMonto
            // 
            lblMonto.Location = new Point(20, 70);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(100, 23);
            lblMonto.TabIndex = 1;
            lblMonto.Text = "Monto:";
            // 
            // lblFecha
            // 
            lblFecha.Location = new Point(20, 110);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(100, 40);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha de Acreditación:";
            // 
            // lblTarjeta
            // 
            lblTarjeta.Location = new Point(20, 150);
            lblTarjeta.Name = "lblTarjeta";
            lblTarjeta.Size = new Size(100, 23);
            lblTarjeta.TabIndex = 3;
            lblTarjeta.Text = "Tarjeta:";
            // 
            // FormAcreditacion
            // 
            ClientSize = new Size(380, 280);
            Controls.Add(lblDescripcion);
            Controls.Add(lblMonto);
            Controls.Add(lblFecha);
            Controls.Add(lblTarjeta);
            Controls.Add(cmbTarjetas);
            Controls.Add(dtpFecha);
            Controls.Add(nudMonto);
            Controls.Add(txtDescripcion);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalir);
            Controls.Add(btnBorrar);
            Name = "FormAcreditacion";
            Text = "Gestión de Acreditaciones";
            Load += FormAcreditacion_Load;
            ((System.ComponentModel.ISupportInitialize)nudMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
