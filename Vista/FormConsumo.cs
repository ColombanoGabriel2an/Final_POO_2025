using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FormConsumo : Form
    {
        private Consumo _consumo;
        private List<Tarjeta> _tarjetas;
        private List<string> _rubros;
        private List<Descuento> _descuentosDisponibles;
        private decimal _montoOriginal;
        private bool _esNuevoConsumo = true;

        // Constructor para un nuevo consumo
        public FormConsumo()
        {
            InitializeComponent();
            _consumo = new Consumo();
            ConfigurarFormulario();
        }

        // Constructor para editar un consumo existente
        public FormConsumo(Consumo consumo)
        {
            InitializeComponent();
            _consumo = consumo;
            _esNuevoConsumo = false;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configurar formato de moneda en el NumericUpDown
            numMonto.DecimalPlaces = 2;
            numMonto.ThousandsSeparator = true;

            // Establecer moneda predeterminada
            cmbMoneda.SelectedIndex = 0; // ARS
        }

        private void FormConsumo_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTarjetas();
                CargarRubros();

                if (!_esNuevoConsumo)
                {
                    CargarDatosConsumoPrevio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos iniciales: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTarjetas()
        {
            // En un caso real, esto vendría de un servicio o repositorio
            _tarjetas = new List<Tarjeta>();
            // Simular la carga de tarjetas desde la base de datos
            // TODO: Reemplazar con llamada al servicio correspondiente

            cmbTarjeta.Items.Clear();
            foreach (var tarjeta in _tarjetas)
            {
                cmbTarjeta.Items.Add($"{tarjeta.Alias} - {tarjeta.Numero.Substring(12, 4)}");
            }

            if (_tarjetas.Count > 0)
                cmbTarjeta.SelectedIndex = 0;
        }

        private void CargarRubros()
        {
            // En un caso real, los rubros vendrían de un catálogo en la base de datos
            _rubros = new List<string>
            {
                "Supermercados",
                "Restaurantes",
                "Indumentaria",
                "Electrónica",
                "Servicios",
                "Combustible",
                "Farmacia",
                "Entretenimiento",
                "Otros"
            };

            cmbRubro.Items.Clear();
            cmbRubro.Items.AddRange(_rubros.ToArray());
            cmbRubro.SelectedIndex = 0;
        }

        private void CargarDatosConsumoPrevio()
        {
            // Seleccionar la tarjeta correspondiente
            for (int i = 0; i < _tarjetas.Count; i++)
            {
                if (_tarjetas[i].TarjetaId == _consumo.TarjetaId)
                {
                    cmbTarjeta.SelectedIndex = i;
                    break;
                }
            }

            // Establecer fecha y hora
            dtpFecha.Value = _consumo.Fecha;
            if (TimeSpan.TryParse(_consumo.Hora, out TimeSpan hora))
            {
                dtpHora.Value = DateTime.Today.Add(hora);
            }

            // Establecer descripción y otros campos
            txtDescripcion.Text = _consumo.Descripcion;
            numMonto.Value = _consumo.Monto;

            // Seleccionar moneda
            for (int i = 0; i < cmbMoneda.Items.Count; i++)
            {
                if (cmbMoneda.Items[i].ToString() == _consumo.Moneda)
                {
                    cmbMoneda.SelectedIndex = i;
                    break;
                }
            }

            // Cargar descuentos aplicados
            BuscarDescuentosAplicables();
            ActualizarMontos();
        }

        private void cmbTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTarjeta.SelectedIndex >= 0)
            {
                _consumo.Tarjeta = _tarjetas[cmbTarjeta.SelectedIndex];
                _consumo.TarjetaId = _consumo.Tarjeta.TarjetaId;
                ActualizarInformacionTarjeta();
            }
        }

        private void ActualizarInformacionTarjeta()
        {
            if (_consumo.Tarjeta != null)
            {
                // Mostrar límite/disponible según sea tarjeta de crédito o débito
                if (_consumo.Tarjeta is TarjetaCredito tarjetaCredito)
                {
                    txtLimiteDisponible.Text = $"Límite: ${tarjetaCredito.Limite:N2} - Disponible: ${tarjetaCredito.Disponible:N2}";
                }
                else if (_consumo.Tarjeta is TarjetaDebito tarjetaDebito)
                {
                    txtLimiteDisponible.Text = $"Saldo disponible: ${tarjetaDebito.Saldo:N2}";
                }
            }
            else
            {
                txtLimiteDisponible.Text = "";
            }

            // Si cambia la tarjeta, buscar nuevamente los descuentos aplicables
            if (numMonto.Value > 0)
            {
                BuscarDescuentosAplicables();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Actualizar la fecha del consumo
            _consumo.Fecha = dtpFecha.Value.Date;

            // Si ya hay monto y tarjeta seleccionada, buscar nuevamente los descuentos
            // ya que los descuentos pueden depender de la fecha
            if (numMonto.Value > 0 && cmbTarjeta.SelectedIndex >= 0)
            {
                BuscarDescuentosAplicables();
            }
        }

        private void numMonto_ValueChanged(object sender, EventArgs e)
        {
            _montoOriginal = numMonto.Value;
            _consumo.Monto = _montoOriginal;
            txtMontoOriginal.Text = $"{_consumo.Moneda} {_montoOriginal:N2}";

            // Actualizar monto final (inicialmente igual al original)
            ActualizarMontoFinal();

            // Si hay tarjeta seleccionada, buscar descuentos aplicables
            if (cmbTarjeta.SelectedIndex >= 0)
            {
                BuscarDescuentosAplicables();
            }
        }

        private void btnBuscarDescuentos_Click(object sender, EventArgs e)
        {
            BuscarDescuentosAplicables();
        }

        private void BuscarDescuentosAplicables()
        {
            if (_consumo.Tarjeta == null || numMonto.Value <= 0)
            {
                MessageBox.Show("Debe seleccionar una tarjeta y especificar un monto válido para buscar descuentos.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // En un caso real, esto se obtendría de un servicio o repositorio
                _descuentosDisponibles = new List<Descuento>();
                // TODO: Implementar llamada al servicio de descuentos
                // _descuentosDisponibles = _descuentoService.ObtenerDescuentosAplicables(_consumo.Tarjeta, dtpFecha.Value, cmbRubro.Text);

                // Simular algunos descuentos para pruebas
                SimularDescuentosDisponibles();

                // Mostrar descuentos en el ListView
                MostrarDescuentosEnListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar descuentos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SimularDescuentosDisponibles()
        {
            _descuentosDisponibles = new List<Descuento>
            {
                new Descuento
                {
                    Descripcion = "Promoción fin de semana",
                    Porcentaje = 10,
                    FechaInicio = DateTime.Today.AddDays(-10),
                    FechaFin = DateTime.Today.AddDays(20),
                    EntidadBancaria = "Banco Nación"
                },
                new Descuento
                {
                    Descripcion = "Descuento primera compra",
                    MontoFijo = 500,
                    FechaInicio = DateTime.Today.AddDays(-30),
                    FechaFin = DateTime.Today.AddDays(60),
                    EntidadBancaria = "VISA"
                }
            };

            // Si estamos editando, marcar los descuentos ya aplicados
            if (!_esNuevoConsumo)
            {
                foreach (var descuentoAplicado in _consumo.DescuentosAplicados)
                {
                    var descuentoEnLista = _descuentosDisponibles.FirstOrDefault(d =>
                        d.Descripcion == descuentoAplicado.Descripcion &&
                        d.EntidadBancaria == descuentoAplicado.EntidadBancaria);

                    if (descuentoEnLista == null)
                    {
                        _descuentosDisponibles.Add(descuentoAplicado);
                    }
                }
            }
        }

        private void MostrarDescuentosEnListView()
        {
            lvDescuentos.Items.Clear();

            foreach (var descuento in _descuentosDisponibles)
            {
                ListViewItem item = new ListViewItem(descuento.Descripcion);
                item.SubItems.Add(descuento.EntidadBancaria);

                // Mostrar valor del descuento (porcentaje o monto fijo)
                if (descuento.Porcentaje > 0)
                {
                    item.SubItems.Add($"{descuento.Porcentaje}%");
                }
                else
                {
                    item.SubItems.Add($"${descuento.MontoFijo:N2}");
                }

                // Mostrar vigencia
                item.SubItems.Add($"{descuento.FechaInicio:d} al {descuento.FechaFin:d}");

                // Guardar referencia al objeto descuento
                item.Tag = descuento;

                // Marcar como seleccionado si ya fue aplicado
                if (_consumo.DescuentosAplicados.Any(d =>
                    d.Descripcion == descuento.Descripcion &&
                    d.EntidadBancaria == descuento.EntidadBancaria))
                {
                    item.Checked = true;
                }

                lvDescuentos.Items.Add(item);
            }
        }

        private void lvDescuentos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item != null && e.Item.Tag is Descuento descuento)
            {
                if (e.Item.Checked)
                {
                    // Agregar descuento a la lista si no existe ya
                    if (!_consumo.DescuentosAplicados.Contains(descuento))
                    {
                        _consumo.DescuentosAplicados.Add(descuento);
                    }
                }
                else
                {
                    // Remover descuento de la lista
                    _consumo.DescuentosAplicados.RemoveAll(d =>
                        d.Descripcion == descuento.Descripcion &&
                        d.EntidadBancaria == descuento.EntidadBancaria);
                }

                // Actualizar monto final con descuentos aplicados
                ActualizarMontoFinal();
            }
        }

        private void ActualizarMontos()
        {
            txtMontoOriginal.Text = $"{_consumo.Moneda} {_consumo.Monto:N2}";
            ActualizarMontoFinal();
        }

        private void ActualizarMontoFinal()
        {
            decimal montoFinal = _consumo.CalcularMontoFinal();
            txtMontoFinal.Text = $"{_consumo.Moneda} {montoFinal:N2}";

            // Colorear para destacar el ahorro
            if (montoFinal < _consumo.Monto)
            {
                txtMontoFinal.ForeColor = Color.Green;
            }
            else
            {
                txtMontoFinal.ForeColor = SystemColors.WindowText;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    // Actualizar datos del consumo
                    _consumo.Fecha = dtpFecha.Value.Date;
                    _consumo.Hora = dtpHora.Value.ToString("HH:mm");
                    _consumo.Descripcion = txtDescripcion.Text;
                    _consumo.Monto = numMonto.Value;
                    _consumo.Moneda = cmbMoneda.SelectedItem.ToString();

                    MessageBox.Show("Consumo guardado correctamente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el consumo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            // Validar que se haya seleccionado una tarjeta
            if (cmbTarjeta.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una tarjeta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTarjeta.Focus();
                return false;
            }

            // Validar monto
            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return false;
            }

            // Validar descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para el consumo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            // Validar que el comercio no esté vacío
            if (string.IsNullOrWhiteSpace(txtComercio.Text))
            {
                MessageBox.Show("Ingrese el nombre del comercio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComercio.Focus();
                return false;
            }

            // Validar que el monto no supere el límite disponible para tarjeta de crédito
            // o el saldo para tarjeta de débito
            decimal montoFinal = _consumo.CalcularMontoFinal();
            if (_consumo.Tarjeta is TarjetaCredito tarjetaCredito)
            {
                if (montoFinal > tarjetaCredito.Disponible)
                {
                    MessageBox.Show($"El monto supera el disponible de la tarjeta de crédito ({tarjetaCredito.Disponible:C2}).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numMonto.Focus();
                    return false;
                }
            }
            else if (_consumo.Tarjeta is TarjetaDebito tarjetaDebito)
            {
                if (montoFinal > tarjetaDebito.Saldo)
                {
                    MessageBox.Show($"El monto supera el saldo disponible de la tarjeta de débito ({tarjetaDebito.Saldo:C2}).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numMonto.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}