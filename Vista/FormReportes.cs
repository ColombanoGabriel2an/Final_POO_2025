public partial class FormReportes : Form
{
  private ComboBox cboTarjetas;
  private DateTimePicker dtpDesde;
  private DateTimePicker dtpHasta;
  private DataGridView dgvMovimientos;
  private Label lblTotal;
  private Label lblDescuentos;

  private void btnGenerar_Click(object sender, EventArgs e)
  {
    using (var context = new Context())
    {
      var tarjeta = (Tarjeta)cboTarjetas.SelectedItem;
      var movimientos = context.Consumos
          .Where(c => c.TarjetaId == tarjeta.TarjetaId &&
                     c.Fecha >= dtpDesde.Value &&
                     c.Fecha <= dtpHasta.Value)
          .OrderBy(c => c.Fecha)
          .ThenBy(c => c.Hora)
          .ToList();

      dgvMovimientos.DataSource = movimientos;

      decimal total = movimientos.Sum(m => m.Monto);
      decimal totalConDescuentos = movimientos.Sum(m => m.CalcularMontoFinal());

      lblTotal.Text = $"Total: ${total:F2}";
      lblDescuentos.Text = $"Ahorrado: ${total - totalConDescuentos:F2}";
    }
  }
}