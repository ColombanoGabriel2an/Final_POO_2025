using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Controladora;

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


        public FormConsumo()
        {
            InitializeComponent();
            _consumo = new Consumo();
            ConfigurarFormulario();
        }


        public FormConsumo(Consumo consumo)
        {
            InitializeComponent();
            _consumo = consumo;
            _esNuevoConsumo = false;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {

            numMonto.DecimalPlaces = 2;
            numMonto.ThousandsSeparator = true;


            cmbMoneda.SelectedIndex = 0;
        }

        private void FormConsumo_Load(object sender, EventArgs e)
        {
            try
            {

                if (ControladoraDescuento.Instancia.ListarDescuentos().Count == 0)
                {
                    ControladoraDescuento.Instancia.PrecargarDescuentos();
                }

                CargarTarjetas();
                CargarRubros();

                lvDescuentos.View = View.Details;
                lvDescuentos.FullRowSelect = true;
                lvDescuentos.CheckBoxes = true;
                lvDescuentos.GridLines = true;


                if (lvDescuentos.Columns.Count == 0)
                {
                    lvDescuentos.Columns.Add("Descripción", 200);
                    lvDescuentos.Columns.Add("Banco/Entidad", 100);
                    lvDescuentos.Columns.Add("Valor", 100);
                    lvDescuentos.Columns.Add("Vigencia", 150);
                }

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
            try
            {

                _tarjetas = ControladoraTarjeta.Instancia.ListarTarjetas();


                if (_tarjetas.Count == 0)
                {
                    MessageBox.Show("No hay tarjetas registradas. Por favor, registre tarjetas primero.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                cmbTarjeta.Items.Clear();
                foreach (var tarjeta in _tarjetas)
                {

                    string ultimosDigitos = tarjeta.Numero.Length >= 4 ?
                        tarjeta.Numero.Substring(tarjeta.Numero.Length - 4) : tarjeta.Numero;

                    string tipoTarjeta = tarjeta is TarjetaCredito ? "Crédito" : "Débito";
                    string nombreTitular = tarjeta.Titular?.Nombre ?? "Sin titular";

                    cmbTarjeta.Items.Add($"{tipoTarjeta} - {tarjeta.Banco} - *{ultimosDigitos} - {nombreTitular}");
                }

                if (_tarjetas.Count > 0)
                    cmbTarjeta.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las tarjetas: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRubros()
        {

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

            for (int i = 0; i < _tarjetas.Count; i++)
            {
                if (_tarjetas[i].TarjetaId == _consumo.TarjetaId)
                {
                    cmbTarjeta.SelectedIndex = i;
                    break;
                }
            }


            dtpFecha.Value = _consumo.Fecha;
            if (TimeSpan.TryParse(_consumo.Hora, out TimeSpan hora))
            {
                dtpHora.Value = DateTime.Today.Add(hora);
            }


            txtDescripcion.Text = _consumo.Descripcion;
            numMonto.Value = _consumo.Monto;


            for (int i = 0; i < cmbMoneda.Items.Count; i++)
            {
                if (cmbMoneda.Items[i].ToString() == _consumo.Moneda)
                {
                    cmbMoneda.SelectedIndex = i;
                    break;
                }
            }


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


                MostrarConsumosDeTarjeta();
            }
        }

        private void ActualizarInformacionTarjeta()
        {
            if (_consumo.Tarjeta != null)
            {

                if (_consumo.Tarjeta is TarjetaCredito tarjetaCredito)
                {
                    txtLimiteDisponible.Text = $"${tarjetaCredito.Disponible:N2}";
                }
                else if (_consumo.Tarjeta is TarjetaDebito tarjetaDebito)
                {
                    txtLimiteDisponible.Text = $"${tarjetaDebito.Saldo:N2}";
                }
            }
            else
            {
                txtLimiteDisponible.Text = "";
            }


            if (numMonto.Value > 0)
            {
                BuscarDescuentosAplicables();
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            _consumo.Fecha = dtpFecha.Value.Date;



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


            ActualizarMontoFinal();


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
                var todosLosDescuentos = ControladoraDescuento.Instancia.ListarDescuentos();

                if (todosLosDescuentos.Count == 0)
                {
                    ControladoraDescuento.Instancia.PrecargarDescuentos();
                    todosLosDescuentos = ControladoraDescuento.Instancia.ListarDescuentos();
                }

                _descuentosDisponibles = new List<Descuento>();
                string rubroSeleccionado = cmbRubro.SelectedItem?.ToString() ?? "";

                foreach (var descuento in todosLosDescuentos)
                {
                    bool aplicable = true;
                    string razonNoAplicable = "";


                    if (!descuento.Activo)
                    {
                        aplicable = false;
                        razonNoAplicable = "Descuento inactivo";
                        continue;
                    }


                    if (!descuento.EsValido(dtpFecha.Value))
                    {
                        aplicable = false;
                        razonNoAplicable = "Fecha fuera de vigencia";
                        continue;
                    }


                    bool coincideBanco = false;
                    if (string.IsNullOrEmpty(descuento.Banco) ||
                        descuento.Banco == "Todas" ||
                        descuento.Banco.Equals(_consumo.Tarjeta.Banco, StringComparison.OrdinalIgnoreCase))
                    {
                        coincideBanco = true;
                    }


                    bool coincideEmisor = false;
                    if (string.IsNullOrEmpty(descuento.Emisor) ||
                        descuento.Emisor == "Todas" ||
                        descuento.Emisor.Equals(_consumo.Tarjeta.EntidadEmisora, StringComparison.OrdinalIgnoreCase))
                    {
                        coincideEmisor = true;
                    }

                    if (!coincideBanco || !coincideEmisor)
                    {
                        aplicable = false;
                        razonNoAplicable = "No coincide banco o emisor";
                        continue;
                    }


                    if (!string.IsNullOrEmpty(descuento.Rubro) &&
                        descuento.Rubro != "Todos" &&
                        !descuento.Rubro.Equals(rubroSeleccionado, StringComparison.OrdinalIgnoreCase))
                    {
                        aplicable = false;
                        razonNoAplicable = $"No coincide rubro (Descuento: {descuento.Rubro}, Seleccionado: {rubroSeleccionado})";
                        continue;
                    }


                    if (numMonto.Value < descuento.MontoMinimo)
                    {
                        aplicable = false;
                        razonNoAplicable = $"Monto menor al mínimo requerido (${descuento.MontoMinimo})";
                        continue;
                    }


                    if (aplicable)
                    {
                        _descuentosDisponibles.Add(descuento);
                    }
                }


                _descuentosDisponibles = _descuentosDisponibles
                    .OrderByDescending(d => d.Porcentaje > 0 ?
                        Math.Min(numMonto.Value * (d.Porcentaje / 100m), d.TopeReintegro > 0 ? d.TopeReintegro : decimal.MaxValue) :
                        d.MontoFijo)
                    .ToList();

                MostrarDescuentosEnListView();

                if (_descuentosDisponibles.Count == 0)
                {
                    MessageBox.Show("No se encontraron descuentos aplicables para esta tarjeta y monto.\n" +
                                   "Verifique que la fecha, banco, emisor, rubro y monto cumplan con los requisitos.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar descuentos: {ex.Message}\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDescuentosEnListView()
        {
            lvDescuentos.Items.Clear();

            if (_descuentosDisponibles == null || _descuentosDisponibles.Count == 0)
            {
                ListViewItem noItem = new ListViewItem("No hay descuentos disponibles");
                noItem.SubItems.Add("-");
                noItem.SubItems.Add("-");
                noItem.SubItems.Add("-");
                lvDescuentos.Items.Add(noItem);
                return;
            }

            foreach (var descuento in _descuentosDisponibles)
            {

                string descripcionCompleta = !string.IsNullOrEmpty(descuento.Nombre) ?
                    $"{descuento.Nombre} - {descuento.Descripcion}" :
                    descuento.Descripcion;

                ListViewItem item = new ListViewItem(descripcionCompleta);


                string entidadInfo = descuento.Banco ?? "Todas";

                if (!string.IsNullOrEmpty(descuento.Emisor) && descuento.Emisor != "Todas")
                    entidadInfo += $" / {descuento.Emisor}";

                item.SubItems.Add(entidadInfo);


                string valorDescuento;
                decimal ahorroEstimado = 0;

                if (descuento.Porcentaje > 0)
                {
                    ahorroEstimado = numMonto.Value * (descuento.Porcentaje / 100m);
                    if (descuento.TopeReintegro > 0 && ahorroEstimado > descuento.TopeReintegro)
                        ahorroEstimado = descuento.TopeReintegro;

                    valorDescuento = $"{descuento.Porcentaje}%";
                    if (descuento.TopeReintegro > 0)
                        valorDescuento += $" (tope ${descuento.TopeReintegro:N2})";

                    valorDescuento += $"\nAhorro: ${ahorroEstimado:N2}";
                }
                else if (descuento.MontoFijo > 0)
                {
                    ahorroEstimado = descuento.MontoFijo;
                    valorDescuento = $"${descuento.MontoFijo:N2} fijo";
                }
                else
                {
                    valorDescuento = "Sin descuento directo";
                    if (descuento.Descripcion.Contains("cuota"))
                        valorDescuento = "Cuotas sin interés";
                }

                item.SubItems.Add(valorDescuento);


                string vigenciaInfo = $"{descuento.FechaInicio:d} al {descuento.FechaFin:d}";
                if (descuento.MontoMinimo > 0)
                    vigenciaInfo += $"\nMín: ${descuento.MontoMinimo:N2}";
                if (!string.IsNullOrEmpty(descuento.Rubro) && descuento.Rubro != "Todos")
                    vigenciaInfo += $"\nRubro: {descuento.Rubro}";

                item.SubItems.Add(vigenciaInfo);

                item.Tag = descuento;


                bool yaAplicado = _consumo.DescuentosAplicados.Any(d =>
                    d.DescuentoId == descuento.DescuentoId ||
                    (d.Codigo == descuento.Codigo && !string.IsNullOrEmpty(d.Codigo)));

                item.Checked = yaAplicado;


                if (ahorroEstimado > 0)
                {

                    decimal porcentajeAhorro = ahorroEstimado / numMonto.Value;

                    if (porcentajeAhorro >= 0.3m)
                        item.BackColor = Color.LightGreen;
                    else if (porcentajeAhorro >= 0.15m)
                        item.BackColor = Color.PaleGreen;
                    else if (porcentajeAhorro >= 0.05m)
                        item.BackColor = Color.LightCyan;
                }

                lvDescuentos.Items.Add(item);
            }
        }

        private void lvDescuentos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item != null && e.Item.Tag is Descuento descuento)
            {

                if (_consumo.DescuentosAplicados == null)
                    _consumo.DescuentosAplicados = new List<Descuento>();

                if (e.Item.Checked)
                {

                    if (!_consumo.DescuentosAplicados.Contains(descuento))
                    {
                        _consumo.DescuentosAplicados.Add(descuento);
                    }
                }
                else
                {

                    _consumo.DescuentosAplicados.RemoveAll(d =>
                        d.DescuentoId == descuento.DescuentoId ||
                        (d.Descripcion == descuento.Descripcion && d.Banco == descuento.Banco));
                }

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

            lvResumenDescuentos.Items.Clear();

            decimal montoFinal = _consumo.Monto;
            decimal ahorroTotal = 0;


            foreach (var descuento in _consumo.DescuentosAplicados)
            {
                decimal ahorroDescuento = 0;
                string tipoDescuento;


                if (descuento.Porcentaje > 0)
                {

                    ahorroDescuento = _consumo.Monto * (descuento.Porcentaje / 100m);


                    if (descuento.TopeReintegro > 0 && ahorroDescuento > descuento.TopeReintegro)
                        ahorroDescuento = descuento.TopeReintegro;

                    tipoDescuento = $"{descuento.Porcentaje}%";
                }
                else if (descuento.MontoFijo > 0)
                {

                    ahorroDescuento = descuento.MontoFijo;
                    tipoDescuento = "Monto fijo";
                }
                else
                {
                    tipoDescuento = "Otro";
                    ahorroDescuento = 0;
                }


                ListViewItem item = new ListViewItem(descuento.Nombre ?? descuento.Descripcion);
                item.SubItems.Add(tipoDescuento);
                item.SubItems.Add($"${ahorroDescuento:N2}");
                item.SubItems.Add(descuento.Banco);


                if (ahorroDescuento > 0)
                {
                    decimal porcentajeAhorro = ahorroDescuento / _consumo.Monto;

                    if (porcentajeAhorro >= 0.3m)
                        item.BackColor = Color.LightGreen;
                    else if (porcentajeAhorro >= 0.15m)
                        item.BackColor = Color.PaleGreen;
                    else if (porcentajeAhorro >= 0.05m)
                        item.BackColor = Color.LightCyan;
                }

                lvResumenDescuentos.Items.Add(item);


                ahorroTotal += ahorroDescuento;
            }


            montoFinal -= ahorroTotal;
            if (montoFinal < 0) montoFinal = 0;


            lblAhorroTotal.Text = $"Ahorro Total: ${ahorroTotal:N2}";


            txtMontoFinal.Text = $"{_consumo.Moneda} {montoFinal:N2}";


            if (montoFinal < _consumo.Monto)
            {
                txtMontoFinal.ForeColor = Color.Green;
                lblAhorroTotal.ForeColor = Color.Green;
            }
            else
            {
                txtMontoFinal.ForeColor = SystemColors.WindowText;
                lblAhorroTotal.ForeColor = SystemColors.WindowText;
            }


            if (_consumo.DescuentosAplicados.Count == 0)
            {
                ListViewItem noItem = new ListViewItem("No hay descuentos aplicados");
                noItem.SubItems.Add("-");
                noItem.SubItems.Add("-");
                noItem.SubItems.Add("-");
                lvResumenDescuentos.Items.Add(noItem);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {

                    _consumo.Fecha = dtpFecha.Value.Date;
                    _consumo.Hora = dtpHora.Value.ToString("HH:mm");
                    _consumo.Descripcion = txtDescripcion.Text;
                    _consumo.Comercio = txtComercio.Text;
                    _consumo.Monto = numMonto.Value;
                    _consumo.Moneda = cmbMoneda.SelectedItem.ToString();
                    _consumo.Rubro = cmbRubro.SelectedItem.ToString();
                    _consumo.EsRecurrente = chkEsRecurrente.Checked;

                    string resultado = ControladoraConsumo.Instancia.CrearConsumo(_consumo, _consumo.Tarjeta);

                    if (_consumo.Tarjeta is TarjetaCredito tarjetaCredito)
                    {
                        tarjetaCredito.Disponible -= _consumo.CalcularMontoFinal();
                        ControladoraTarjeta.Instancia.ActualizarTarjeta(tarjetaCredito);
                    }
                    else if (_consumo.Tarjeta is TarjetaDebito tarjetaDebito)
                    {
                        tarjetaDebito.Saldo -= _consumo.CalcularMontoFinal();
                        ControladoraTarjeta.Instancia.ActualizarTarjeta(tarjetaDebito);
                    }

                    MessageBox.Show($"{resultado}", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MostrarConsumosDeTarjeta();

                    DialogResult = DialogResult.OK;
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

            if (cmbTarjeta.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una tarjeta.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTarjeta.Focus();
                return false;
            }


            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numMonto.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese una descripción para el consumo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtComercio.Text))
            {
                MessageBox.Show("Ingrese el nombre del comercio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComercio.Focus();
                return false;
            }



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


        private void MostrarConsumosDeTarjeta()
        {
            if (_consumo.Tarjeta == null) return;


            var todosLosConsumos = ControladoraConsumo.Instancia.ListarConsumos();
            List<Consumo> consumosTarjeta = new List<Consumo>();


            foreach (var consumo in todosLosConsumos)
            {
                if (consumo.TarjetaId == _consumo.TarjetaId)
                {
                    consumosTarjeta.Add(consumo);
                }
            }


            if (dgvConsumosActuales.Columns.Count == 0)
            {

                dgvConsumosActuales.Columns.Add("Fecha", "Fecha");
                dgvConsumosActuales.Columns.Add("Descripcion", "Descripción");
                dgvConsumosActuales.Columns.Add("Comercio", "Comercio");
                dgvConsumosActuales.Columns.Add("Monto", "Monto");
            }

            dgvConsumosActuales.Rows.Clear();

            foreach (var consumo in consumosTarjeta)
            {
                int rowIndex = dgvConsumosActuales.Rows.Add();
                DataGridViewRow row = dgvConsumosActuales.Rows[rowIndex];

                row.Cells["Fecha"].Value = consumo.Fecha.ToShortDateString();
                row.Cells["Descripcion"].Value = consumo.Descripcion;
                row.Cells["Comercio"].Value = "Comercio";
                row.Cells["Monto"].Value = $"{consumo.Moneda} {consumo.Monto:N2}";


                if (consumo.Monto > 5000)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }

            lblTotalConsumosActuales.Text = $"Total: {consumosTarjeta.Count} consumos";
        }
    }
}