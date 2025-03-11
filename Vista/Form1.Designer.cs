namespace Vista
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button btnTarjetas;
        private System.Windows.Forms.Button btnConsumos;
        private System.Windows.Forms.Button btnAcreditaciones;
        private System.Windows.Forms.Button btnDescuentos;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label lblTitulo;

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
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnTarjetas = new System.Windows.Forms.Button();
            this.btnConsumos = new System.Windows.Forms.Button();
            this.btnAcreditaciones = new System.Windows.Forms.Button();
            this.btnDescuentos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(200, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            this.lblTitulo.Text = "Sistema de Gestión de Tarjetas y Consumos";

            // btnPersonas
            this.btnPersonas.Location = new System.Drawing.Point(300, 100);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(200, 50);
            this.btnPersonas.Text = "Gestión de Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;

            // btnTarjetas
            this.btnTarjetas.Location = new System.Drawing.Point(300, 170);
            this.btnTarjetas.Name = "btnTarjetas";
            this.btnTarjetas.Size = new System.Drawing.Size(200, 50);
            this.btnTarjetas.Text = "Gestión de Tarjetas";
            this.btnTarjetas.UseVisualStyleBackColor = true;

            // btnConsumos
            this.btnConsumos.Location = new System.Drawing.Point(300, 240);
            this.btnConsumos.Name = "btnConsumos";
            this.btnConsumos.Size = new System.Drawing.Size(200, 50);
            this.btnConsumos.Text = "Registrar Consumo";
            this.btnConsumos.UseVisualStyleBackColor = true;

            // btnAcreditaciones
            this.btnAcreditaciones.Location = new System.Drawing.Point(300, 310);
            this.btnAcreditaciones.Name = "btnAcreditaciones";
            this.btnAcreditaciones.Size = new System.Drawing.Size(200, 50);
            this.btnAcreditaciones.Text = "Registrar Acreditación";
            this.btnAcreditaciones.UseVisualStyleBackColor = true;

            // btnDescuentos
            this.btnDescuentos.Location = new System.Drawing.Point(300, 380);
            this.btnDescuentos.Name = "btnDescuentos";
            this.btnDescuentos.Size = new System.Drawing.Size(200, 50);
            this.btnDescuentos.Text = "Gestión de Descuentos";
            this.btnDescuentos.UseVisualStyleBackColor = true;

            // btnReportes
            this.btnReportes.Location = new System.Drawing.Point(300, 450);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(200, 50);
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnPersonas);
            this.Controls.Add(this.btnTarjetas);
            this.Controls.Add(this.btnConsumos);
            this.Controls.Add(this.btnAcreditaciones);
            this.Controls.Add(this.btnDescuentos);
            this.Controls.Add(this.btnReportes);
            this.Name = "Form1";
            this.Text = "Sistema de Gestión de Tarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}