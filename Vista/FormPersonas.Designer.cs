namespace Vista
{
  partial class FormPersonas
  {
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgvPersonas;
    private System.Windows.Forms.TextBox txtNombre;
    private System.Windows.Forms.TextBox txtApellido;
    private System.Windows.Forms.TextBox txtDNI;
    private System.Windows.Forms.Button btnAgregar;
    private System.Windows.Forms.Button btnModificar;
    private System.Windows.Forms.Button btnEliminar;
    private System.Windows.Forms.Label lblNombre;
    private System.Windows.Forms.Label lblApellido;
    private System.Windows.Forms.Label lblDNI;

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
      this.dgvPersonas = new System.Windows.Forms.DataGridView();
      this.dgvPersonas.Location = new System.Drawing.Point(20, 20);
      this.dgvPersonas.Size = new System.Drawing.Size(760, 200);
      this.dgvPersonas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvPersonas.MultiSelect = false;
      this.dgvPersonas.ReadOnly = true;

      // Labels
      this.lblNombre = new System.Windows.Forms.Label();
      this.lblNombre.Location = new System.Drawing.Point(20, 240);
      this.lblNombre.Size = new System.Drawing.Size(100, 23);
      this.lblNombre.Text = "Nombre:";

      this.lblApellido = new System.Windows.Forms.Label();
      this.lblApellido.Location = new System.Drawing.Point(20, 270);
      this.lblApellido.Size = new System.Drawing.Size(100, 23);
      this.lblApellido.Text = "Apellido:";

      this.lblDNI = new System.Windows.Forms.Label();
      this.lblDNI.Location = new System.Drawing.Point(20, 300);
      this.lblDNI.Size = new System.Drawing.Size(100, 23);
      this.lblDNI.Text = "DNI:";

      // TextBoxes
      this.txtNombre = new System.Windows.Forms.TextBox();
      this.txtNombre.Location = new System.Drawing.Point(130, 240);
      this.txtNombre.Size = new System.Drawing.Size(200, 23);

      this.txtApellido = new System.Windows.Forms.TextBox();
      this.txtApellido.Location = new System.Drawing.Point(130, 270);
      this.txtApellido.Size = new System.Drawing.Size(200, 23);

      this.txtDNI = new System.Windows.Forms.TextBox();
      this.txtDNI.Location = new System.Drawing.Point(130, 300);
      this.txtDNI.Size = new System.Drawing.Size(200, 23);
      this.txtDNI.MaxLength = 8;

      // Buttons
      this.btnAgregar = new System.Windows.Forms.Button();
      this.btnAgregar.Location = new System.Drawing.Point(130, 340);
      this.btnAgregar.Size = new System.Drawing.Size(90, 30);
      this.btnAgregar.Text = "Agregar";

      this.btnModificar = new System.Windows.Forms.Button();
      this.btnModificar.Location = new System.Drawing.Point(240, 340);
      this.btnModificar.Size = new System.Drawing.Size(90, 30);
      this.btnModificar.Text = "Modificar";
      this.btnModificar.Enabled = false;

      this.btnEliminar = new System.Windows.Forms.Button();
      this.btnEliminar.Location = new System.Drawing.Point(350, 340);
      this.btnEliminar.Size = new System.Drawing.Size(90, 30);
      this.btnEliminar.Text = "Eliminar";
      this.btnEliminar.Enabled = false;

      // Form Config
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 400);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvPersonas,
                this.lblNombre, this.txtNombre,
                this.lblApellido, this.txtApellido,
                this.lblDNI, this.txtDNI,
                this.btnAgregar, this.btnModificar, this.btnEliminar
            });
      this.Name = "FormPersonas";
      this.Text = "Gestión de Personas";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}