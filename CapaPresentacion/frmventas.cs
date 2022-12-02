using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace CapaPresentacion
{
    public partial class frmventas : Form
    {
        private Usuario _usuario;
        public frmventas(Usuario ousuario = null)
        {
            _usuario = ousuario;
            InitializeComponent();
        }

        private void frmventas_Load(object sender, EventArgs e)
        {
            cbdoc.Items.Add(new OpcionesCombo() { Valor = "Boleta", texto = "Boleta" });
            cbdoc.Items.Add(new OpcionesCombo() { Valor = "Factura", texto = "Factura" });
            cbdoc.DisplayMember = "texto";
            cbdoc.ValueMember = "valor";
            cbdoc.SelectedIndex = 0;
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidcliente.Text = "0";
            txtidplato.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            using (var modal = new md_Clientes())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidcliente.Text = modal._Cliente.idCliente.ToString();
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto;
                    txtnombreplato.Select();
                }
                else
                {
                    txtnombrecliente.Select();
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            using (var modal = new md_Platos())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidplato.Text = modal._plato.idplato.ToString();
                    txtnombreplato.Text = modal._plato.nombre;
                    txxprevent.Text = modal._plato.precioventa.ToString("0.00");
                    nupcantidad.Select();
                }
                else
                {
                    txtnombreplato.Select();
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            bool plato_agregado = false;
            if (int.Parse(txtidplato.Text) == 0)
            {
                MessageBox.Show("Error: Debe seleccionar un plato", "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txxprevent.Text, out precioventa))
            {
                MessageBox.Show("Error: Precio venta - Formato de moneda incorrecto", "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txxprevent.Select();
                return;
            }
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.Cells["IdPlato"].Value?.ToString() == txtidplato.Text)
                {
                    plato_agregado = true;
                    break;
                }
            }
            if (!plato_agregado)
            {
                dataGridView1.Rows.Add(new object[] {
                    txtidplato.Text,
                    txtnombreplato.Text,
                    precioventa.ToString("0.00"),
                    nupcantidad.Value.ToString(),
                    (nupcantidad.Value * precioventa).ToString("0.00")
                });
                calcularTotal();
                limpiarplato();
                txtnombreplato.Select();
            }
        }
        private void limpiarplato()
        {
            txtidplato.Text = "0";
            txtnombreplato.Text = "";
            txxprevent.Text = "";
            nupcantidad.Value = 1;
        }
        private void calcularTotal()
        {
            decimal total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value.ToString());
                }
                txttotal.Text = total.ToString("0.00");
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var h = Properties.Resources.delete_button_png_28566.Width;
                var w = Properties.Resources.delete_button_png_28566.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.delete_button_png_28566, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    dataGridView1.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void txxprevent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txxprevent.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtpagacon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagacon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void calcularVuelto()
        {
            if (txttotal.Text.Trim() == "")
            {
                MessageBox.Show("Error: Debe seleccionar un plato", "Error al calcular vuelto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal pagacon;
            decimal total = Convert.ToDecimal(txttotal.Text);
            if (txtpagacon.Text.Trim() == "")
            {
                txtpagacon.Text = "0";
            }
            if(decimal.TryParse(txtpagacon.Text.Trim(),out pagacon))
            {
                if (pagacon < total)
                {
                    txtcambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon-total;
                    txtcambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtpagacon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                calcularVuelto();
            }
        }

        private void btnregistrarguardarcompra_Click(object sender, EventArgs e)
        {
            calcularVuelto();
            if (Convert.ToInt32(txtidcliente.Text) == 0)
            {
                MessageBox.Show("Error: Debe seleccionar un cliente", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Error: Debe seleccionar al menos un plato", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable DetalleVenta = new DataTable();
            DetalleVenta.Columns.Add("IdPlato", typeof(int));
            DetalleVenta.Columns.Add("PrecioVenta", typeof(decimal));
            DetalleVenta.Columns.Add("Cantidad", typeof(int));
            DetalleVenta.Columns.Add("Subtotal", typeof(decimal));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DetalleVenta.Rows.Add(new object[]
                {
                    Convert.ToInt32(row.Cells["IdPlato"].Value.ToString()),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()
                });
            }
            int idcorrelativo = new CN_Venta().obtenercorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);
            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { idUsuario = _usuario.idUsuario },
                idcliente = Convert.ToInt32(txtidcliente.Text),
                nombrecliente = txtnombrecliente.Text,
                tipodocumento = ((OpcionesCombo)cbdoc.SelectedItem).texto,
                numerodocumento = numerodocumento,
                montopago = Convert.ToDecimal(txtpagacon.Text),
                montocambio = Convert.ToDecimal(txtcambio.Text),
                montototal = Convert.ToDecimal(txttotal.Text)
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Venta().Registrar(oVenta, DetalleVenta, out mensaje);
            if (respuesta)
            {
                var result = MessageBox.Show("Numero de venta generado: \n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?", "Satisfactorio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);
                }
                txtidcliente.Text = "0";
                txtnombrecliente.Text = "";
                txtnombreplato.Text = "";
                dataGridView1.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Error: " + mensaje, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
