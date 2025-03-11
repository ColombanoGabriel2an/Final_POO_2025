namespace Vista
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnPersona;
        private System.Windows.Forms.Button btnDescuento;
        private System.Windows.Forms.Button btnAcreditacion;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnTarjeta;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnPersona = new System.Windows.Forms.Button();
            this.btnDescuento = new System.Windows.Forms.Button();
            this.btnAcreditacion = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnTarjeta = new System.Windows.Forms.Button();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPersona
            // 
            this.btnPersona.Location = new System.Drawing.Point(30, 30);
            this.btnPersona.Name = "btnPersona";
            this.btnPersona.Size = new System.Drawing.Size(150, 35);
            this.btnPersona.TabIndex = 0;
            this.btnPersona.Text = "Persona";
            this.btnPersona.UseVisualStyleBackColor = true;
            this.btnPersona.Click += new System.EventHandler(this.btnPersona_Click);
            // 
            // btnDescuento
            // 
            this.btnDescuento.Location = new System.Drawing.Point(30, 70);
            this.btnDescuento.Name = "btnDescuento";
            this.btnDescuento.Size = new System.Drawing.Size(150, 35);
            this.btnDescuento.TabIndex = 1;
            this.btnDescuento.Text = "Descuento";
            this.btnDescuento.UseVisualStyleBackColor = true;
            this.btnDescuento.Click += new System.EventHandler(this.btnDescuento_Click);
            // 
            // btnAcreditacion
            // 
            this.btnAcreditacion.Location = new System.Drawing.Point(30, 110);
            this.btnAcreditacion.Name = "btnAcreditacion";
            this.btnAcreditacion.Size = new System.Drawing.Size(150, 35);
            this.btnAcreditacion.TabIndex = 2;
            this.btnAcreditacion.Text = "Acreditacion";
            this.btnAcreditacion.UseVisualStyleBackColor = true;
            this.btnAcreditacion.Click += new System.EventHandler(this.btnAcreditacion_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(30, 150);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(150, 35);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnTarjeta
            // 
            this.btnTarjeta.Location = new System.Drawing.Point(30, 190);
            this.btnTarjeta.Name = "btnTarjeta";
            this.btnTarjeta.Size = new System.Drawing.Size(150, 35);
            this.btnTarjeta.TabIndex = 4;
            this.btnTarjeta.Text = "Tarjeta";
            this.btnTarjeta.UseVisualStyleBackColor = true;
            this.btnTarjeta.Click += new System.EventHandler(this.btnTarjeta_Click);
            // 
            // btnConsumo
            // 
            this.btnConsumo.Location = new System.Drawing.Point(30, 230);
            this.btnConsumo.Name = "btnConsumo";
            this.btnConsumo.Size = new System.Drawing.Size(150, 35);
            this.btnConsumo.TabIndex = 5;
            this.btnConsumo.Text = "Consumo";
            this.btnConsumo.UseVisualStyleBackColor = true;
            this.btnConsumo.Click += new System.EventHandler(this.btnConsumo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(30, 280);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(150, 35);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConsumo);
            this.Controls.Add(this.btnTarjeta);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.btnAcreditacion);
            this.Controls.Add(this.btnDescuento);
            this.Controls.Add(this.btnPersona);
            this.Name = "Form1";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
