﻿namespace Vista
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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nudPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.cmbEntidadBancaria = new System.Windows.Forms.ComboBox();
            this.nudTopeReintegro = new System.Windows.Forms.NumericUpDown();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.chkAcumulable = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dgvDescuentos = new System.Windows.Forms.DataGridView();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblEntidadBancaria = new System.Windows.Forms.Label();
            this.lblTopeReintegro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopeReintegro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            this.SuspendLayout();

            // txtCodigo
            this.txtCodigo.Location = new System.Drawing.Point(130, 30);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(200, 20);
            this.txtCodigo.TabIndex = 1;

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(130, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 3;

            // txtDescripcion
            this.txtDescripcion.Location = new System.Drawing.Point(130, 110);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 60);
            this.txtDescripcion.TabIndex = 5;

            // nudPorcentaje
            this.nudPorcentaje.Location = new System.Drawing.Point(130, 190);
            this.nudPorcentaje.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudPorcentaje.Name = "nudPorcentaje";
            this.nudPorcentaje.Size = new System.Drawing.Size(200, 20);
            this.nudPorcentaje.TabIndex = 7;

            // dtpFechaInicio
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(130, 220);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 9;

            // dtpFechaFin
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(130, 250);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 11;

            // cmbTipo
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
                "Promoción",
                "Cuota sin interés",
                "Reintegro",
                "Oferta especial",
                "Descuento por temporada",
                "Programa de fidelidad"
            });
            this.cmbTipo.Location = new System.Drawing.Point(130, 280);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(200, 21);
            this.cmbTipo.TabIndex = 13;

            // cmbEntidadBancaria
            this.cmbEntidadBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntidadBancaria.FormattingEnabled = true;
            this.cmbEntidadBancaria.Items.AddRange(new object[] {
                "Todas",
                "Banco Nación",
                "Banco Provincia",
                "Banco Ciudad",
                "Banco Galicia",
                "Banco Santander",
                "Banco BBVA",
                "Banco ICBC",
                "Banco Macro"
            });
            this.cmbEntidadBancaria.Location = new System.Drawing.Point(130, 310);
            this.cmbEntidadBancaria.Name = "cmbEntidadBancaria";
            this.cmbEntidadBancaria.Size = new System.Drawing.Size(200, 21);
            this.cmbEntidadBancaria.TabIndex = 15;

            // nudTopeReintegro
            this.nudTopeReintegro.DecimalPlaces = 2;
            this.nudTopeReintegro.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudTopeReintegro.Location = new System.Drawing.Point(130, 340);
            this.nudTopeReintegro.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudTopeReintegro.Name = "nudTopeReintegro";
            this.nudTopeReintegro.Size = new System.Drawing.Size(200, 20);
            this.nudTopeReintegro.TabIndex = 17;

            // chkActivo
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(130, 370);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 18;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;

            // chkAcumulable
            this.chkAcumulable.AutoSize = true;
            this.chkAcumulable.Location = new System.Drawing.Point(230, 370);
            this.chkAcumulable.Name = "chkAcumulable";
            this.chkAcumulable.Size = new System.Drawing.Size(80, 17);
            this.chkAcumulable.TabIndex = 19;
            this.chkAcumulable.Text = "Acumulable";
            this.chkAcumulable.UseVisualStyleBackColor = true;

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(130, 400);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 30);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(235, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 30);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(235, 440);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 30);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // btnBorrar
            this.btnBorrar.Location = new System.Drawing.Point(130, 440);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(95, 30);
            this.btnBorrar.TabIndex = 23;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);

            // dgvDescuentos
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.AllowUserToDeleteRows = false;
            this.dgvDescuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Location = new System.Drawing.Point(350, 12);
            this.dgvDescuentos.MultiSelect = false;
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.ReadOnly = true;
            this.dgvDescuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDescuentos.Size = new System.Drawing.Size(500, 380);
            this.dgvDescuentos.TabIndex = 24;
            this.dgvDescuentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDescuentos_CellClick);

            // Labels
            this.lblCodigo.Location = new System.Drawing.Point(20, 30);
            this.lblCodigo.Text = "Código:";
            this.lblNombre.Location = new System.Drawing.Point(20, 70);
            this.lblNombre.Text = "Nombre:";
            this.lblDescripcion.Location = new System.Drawing.Point(20, 110);
            this.lblDescripcion.Text = "Descripción:";
            this.lblPorcentaje.Location = new System.Drawing.Point(20, 190);
            this.lblPorcentaje.Text = "Porcentaje de Descuento:";
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 220);
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            this.lblFechaFin.Location = new System.Drawing.Point(20, 250);
            this.lblFechaFin.Text = "Fecha de Fin:";
            this.lblTipo.Location = new System.Drawing.Point(20, 280);
            this.lblTipo.Text = "Tipo de Descuento:";
            this.lblEntidadBancaria.Location = new System.Drawing.Point(20, 310);
            this.lblEntidadBancaria.Text = "Entidad Bancaria:";
            this.lblTopeReintegro.Location = new System.Drawing.Point(20, 340);
            this.lblTopeReintegro.Text = "Tope de Reintegro:";

            // FormDescuento
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.dgvDescuentos);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkAcumulable);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.nudTopeReintegro);
            this.Controls.Add(this.lblTopeReintegro);
            this.Controls.Add(this.cmbEntidadBancaria);
            this.Controls.Add(this.lblEntidadBancaria);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.nudPorcentaje);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "FormDescuento";
            this.Text = "Gestión de Descuentos";
            this.Load += new System.EventHandler(this.FormDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopeReintegro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
