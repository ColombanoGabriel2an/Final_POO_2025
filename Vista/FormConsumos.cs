public partial class FormConsumos : Form
{
  private ComboBox cboTarjetas;
  private DateTimePicker dtpFecha;
  private DateTimePicker dtpHora;
  private TextBox txtDescripcion;
  private TextBox txtVendedor;
  private ComboBox cboRubro;
  private NumericUpDown nudMonto;
  private CheckBox chkRecurrente;
  private ListBox lstDescuentos;

  private void btnRegistrar_Click(object sender, EventArgs e)
  {
    using (var context = new Context())
    {
      var consumo = new Consumo(
          (Tarjeta)cboTarjetas.SelectedItem,
          dtpFecha.Value,
          dtpHora.Value.ToString("HH:mm"),
          txtDescripcion.Text,
          txtVendedor.Text,
          cboRubro.Text,
          nudMonto.Value,
          "ARS",
          chkRecurrente.Checked
      );

      foreach (Descuento descuento in lstDescuentos.SelectedItems)
      {
        consumo.AplicarDescuento(descuento);
      }

      if (!consumo.ValidarConsumo())
      {
        MessageBox.Show("Fondos insuficientes o límite excedido");
        return;
      }

      context.Consumos.Add(consumo);
      context.SaveChanges();
    }
  }
}