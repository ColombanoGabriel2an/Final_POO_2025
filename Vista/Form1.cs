using System;
using System.Drawing;
using System.Windows.Forms;
using Entidades;

namespace Final_POO_2025
{
    public partial class Form1 : Form
    {
        private Button btnPersonas;
        private Button btnTarjetas;
        private Button btnConsumos;
        private Button btnAcreditaciones;
        private Button btnDescuentos;
        private Button btnReportes;
        private Label lblTitulo;

        public Form1()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarBotones();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Sistema de Gestión de Tarjetas";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
        }

        private void ConfigurarBotones()
        {
            lblTitulo = new Label
            {
                Text = "Sistema de Gestión de Tarjetas y Consumos",
                Size = new Size(400, 30),
                Location = new Point(200, 30),
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnPersonas = new Button
            {
                Text = "Gestión de Personas",
                Size = new Size(200, 50),
                Location = new Point(300, 100),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            btnTarjetas = new Button
            {
                Text = "Gestión de Tarjetas",
                Size = new Size(200, 50),
                Location = new Point(300, 170),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            btnConsumos = new Button
            {
                Text = "Registrar Consumo",
                Size = new Size(200, 50),
                Location = new Point(300, 240),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            btnAcreditaciones = new Button
            {
                Text = "Registrar Acreditación",
                Size = new Size(200, 50),
                Location = new Point(300, 310),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            btnDescuentos = new Button
            {
                Text = "Gestión de Descuentos",
                Size = new Size(200, 50),
                Location = new Point(300, 380),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            btnReportes = new Button
            {
                Text = "Reportes",
                Size = new Size(200, 50),
                Location = new Point(300, 450),
                Font = new Font("Arial", 12),
                BackColor = Color.LightBlue
            };

            // Agregar hover effect
            foreach (Button btn in new[] { btnPersonas, btnTarjetas, btnConsumos,
                                         btnAcreditaciones, btnDescuentos, btnReportes })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = Color.SkyBlue;
                btn.MouseLeave += (s, e) => btn.BackColor = Color.LightBlue;
            }

            this.Controls.AddRange(new Control[] {
                lblTitulo, btnPersonas, btnTarjetas, btnConsumos,
                btnAcreditaciones, btnDescuentos, btnReportes
            });

            // Event handlers
            btnPersonas.Click += (s, e) => AbrirFormulario<FormPersonas>();
            btnTarjetas.Click += (s, e) => AbrirFormulario<FormTarjetas>();
            btnConsumos.Click += (s, e) => AbrirFormulario<FormConsumos>();
            btnAcreditaciones.Click += (s, e) => AbrirFormulario<FormAcreditaciones>();
            btnDescuentos.Click += (s, e) => AbrirFormulario<FormDescuentos>();
            btnReportes.Click += (s, e) => AbrirFormulario<FormReportes>();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            try
            {
                var form = new T();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}