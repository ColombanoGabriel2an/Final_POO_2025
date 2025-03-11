namespace Vista
{
    partial class FormDescuento
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.NumericUpDown nudPorcentaje;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.ComboBox cmbEntidadBancaria;
        private System.Windows.Forms.NumericUpDown nudTopeReintegro;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.CheckBox chkAcumulable;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblEntidadBancaria;
        private System.Windows.Forms.Label lblTopeReintegro;
        private System.Windows.Forms.DataGridView dgvDescuentos;

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
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            nudPorcentaje = new NumericUpDown();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            cmbTipo = new ComboBox();
            cmbEntidadBancaria = new ComboBox();
            nudTopeReintegro = new NumericUpDown();
            chkActivo = new CheckBox();
            chkAcumulable = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            btnBorrar = new Button();
            dgvDescuentos = new DataGridView();
            lblCodigo = new Label();
            lblNombre = new Label();
            lblDescripcion = new Label();
            lblPorcentaje = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            lblTipo = new Label();
            lblEntidadBancaria = new Label();
            lblTopeReintegro = new Label();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTopeReintegro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(152, 35);
            txtCodigo.Margin = new Padding(4, 3, 4, 3);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(233, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(152, 81);
            txtNombre.Margin = new Padding(4, 3, 4, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(233, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(152, 127);
            txtDescripcion.Margin = new Padding(4, 3, 4, 3);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(233, 69);
            txtDescripcion.TabIndex = 5;
            // 
            // nudPorcentaje
            // 
            nudPorcentaje.Location = new Point(152, 219);
            nudPorcentaje.Margin = new Padding(4, 3, 4, 3);
            nudPorcentaje.Name = "nudPorcentaje";
            nudPorcentaje.Size = new Size(233, 23);
            nudPorcentaje.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(152, 254);
            dtpFechaInicio.Margin = new Padding(4, 3, 4, 3);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(233, 23);
            dtpFechaInicio.TabIndex = 9;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(152, 288);
            dtpFechaFin.Margin = new Padding(4, 3, 4, 3);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(233, 23);
            dtpFechaFin.TabIndex = 11;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Promoción", "Cuota sin interés", "Reintegro", "Oferta especial", "Descuento por temporada", "Programa de fidelidad" });
            cmbTipo.Location = new Point(152, 323);
            cmbTipo.Margin = new Padding(4, 3, 4, 3);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(233, 23);
            cmbTipo.TabIndex = 13;
            // 
            // cmbEntidadBancaria
            // 
            cmbEntidadBancaria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEntidadBancaria.FormattingEnabled = true;
            cmbEntidadBancaria.Items.AddRange(new object[] { "Todas", "Banco Nación", "Banco Provincia", "Banco Ciudad", "Banco Galicia", "Banco Santander", "Banco BBVA", "Banco ICBC", "Banco Macro" });
            cmbEntidadBancaria.Location = new Point(152, 358);
            cmbEntidadBancaria.Margin = new Padding(4, 3, 4, 3);
            cmbEntidadBancaria.Name = "cmbEntidadBancaria";
            cmbEntidadBancaria.Size = new Size(233, 23);
            cmbEntidadBancaria.TabIndex = 15;
            // 
            // nudTopeReintegro
            // 
            nudTopeReintegro.DecimalPlaces = 2;
            nudTopeReintegro.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            nudTopeReintegro.Location = new Point(152, 392);
            nudTopeReintegro.Margin = new Padding(4, 3, 4, 3);
            nudTopeReintegro.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTopeReintegro.Name = "nudTopeReintegro";
            nudTopeReintegro.Size = new Size(233, 23);
            nudTopeReintegro.TabIndex = 17;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(152, 427);
            chkActivo.Margin = new Padding(4, 3, 4, 3);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 18;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkAcumulable
            // 
            chkAcumulable.AutoSize = true;
            chkAcumulable.Location = new Point(268, 427);
            chkAcumulable.Margin = new Padding(4, 3, 4, 3);
            chkAcumulable.Name = "chkAcumulable";
            chkAcumulable.Size = new Size(90, 19);
            chkAcumulable.TabIndex = 19;
            chkAcumulable.Text = "Acumulable";
            chkAcumulable.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 462);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 35);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(274, 462);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 35);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(274, 508);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(111, 35);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(152, 508);
            btnBorrar.Margin = new Padding(4, 3, 4, 3);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(111, 35);
            btnBorrar.TabIndex = 23;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // dgvDescuentos
            // 
            dgvDescuentos.AllowUserToAddRows = false;
            dgvDescuentos.AllowUserToDeleteRows = false;
            dgvDescuentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDescuentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDescuentos.Location = new Point(408, 14);
            dgvDescuentos.Margin = new Padding(4, 3, 4, 3);
            dgvDescuentos.MultiSelect = false;
            dgvDescuentos.Name = "dgvDescuentos";
            dgvDescuentos.ReadOnly = true;
            dgvDescuentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDescuentos.Size = new Size(583, 438);
            dgvDescuentos.TabIndex = 24;
            dgvDescuentos.CellClick += dgvDescuentos_CellClick;
            // 
            // lblCodigo
            // 
            lblCodigo.Location = new Point(23, 35);
            lblCodigo.Margin = new Padding(4, 0, 4, 0);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(117, 27);
            lblCodigo.TabIndex = 33;
            lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(23, 81);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(117, 27);
            lblNombre.TabIndex = 32;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.Location = new Point(23, 127);
            lblDescripcion.Margin = new Padding(4, 0, 4, 0);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(117, 27);
            lblDescripcion.TabIndex = 31;
            lblDescripcion.Text = "Descripción:";
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.Location = new Point(23, 219);
            lblPorcentaje.Margin = new Padding(4, 0, 4, 0);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(117, 27);
            lblPorcentaje.TabIndex = 30;
            lblPorcentaje.Text = "Porcentaje de Descuento:";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.Location = new Point(23, 254);
            lblFechaInicio.Margin = new Padding(4, 0, 4, 0);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(117, 27);
            lblFechaInicio.TabIndex = 29;
            lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // lblFechaFin
            // 
            lblFechaFin.Location = new Point(23, 288);
            lblFechaFin.Margin = new Padding(4, 0, 4, 0);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(117, 27);
            lblFechaFin.TabIndex = 28;
            lblFechaFin.Text = "Fecha de Fin:";
            // 
            // lblTipo
            // 
            lblTipo.Location = new Point(23, 323);
            lblTipo.Margin = new Padding(4, 0, 4, 0);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(117, 27);
            lblTipo.TabIndex = 27;
            lblTipo.Text = "Tipo de Descuento:";
            // 
            // lblEntidadBancaria
            // 
            lblEntidadBancaria.Location = new Point(23, 358);
            lblEntidadBancaria.Margin = new Padding(4, 0, 4, 0);
            lblEntidadBancaria.Name = "lblEntidadBancaria";
            lblEntidadBancaria.Size = new Size(117, 27);
            lblEntidadBancaria.TabIndex = 26;
            lblEntidadBancaria.Text = "Entidad Bancaria:";
            // 
            // lblTopeReintegro
            // 
            lblTopeReintegro.Location = new Point(23, 392);
            lblTopeReintegro.Margin = new Padding(4, 0, 4, 0);
            lblTopeReintegro.Name = "lblTopeReintegro";
            lblTopeReintegro.Size = new Size(117, 27);
            lblTopeReintegro.TabIndex = 25;
            lblTopeReintegro.Text = "Tope de Reintegro:";
            // 
            // FormDescuento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 553);
            Controls.Add(dgvDescuentos);
            Controls.Add(btnBorrar);
            Controls.Add(btnSalir);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(chkAcumulable);
            Controls.Add(chkActivo);
            Controls.Add(nudTopeReintegro);
            Controls.Add(lblTopeReintegro);
            Controls.Add(cmbEntidadBancaria);
            Controls.Add(lblEntidadBancaria);
            Controls.Add(cmbTipo);
            Controls.Add(lblTipo);
            Controls.Add(dtpFechaFin);
            Controls.Add(lblFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblFechaInicio);
            Controls.Add(nudPorcentaje);
            Controls.Add(lblPorcentaje);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormDescuento";
            Text = "Gestión de Descuentos";
            Load += FormDescuento_Load;
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTopeReintegro).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
