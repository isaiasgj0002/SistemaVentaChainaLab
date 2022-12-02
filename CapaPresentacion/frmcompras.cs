using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmcompras : Form
    {
        private Usuario _usuario;
        public frmcompras(Usuario ousuario = null)
        {
            _usuario = ousuario;
            InitializeComponent();
        }

        private void frmcompras_Load(object sender, EventArgs e)
        {
            cbdoc.Items.Add(new OpcionesCombo() { Valor = "Boleta", texto = "Boleta" });
            cbdoc.Items.Add(new OpcionesCombo() { Valor = "Factura", texto = "Factura" });
            cbdoc.DisplayMember = "texto";
            cbdoc.ValueMember = "valor";
            cbdoc.SelectedIndex = 0;
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtidproveedor.Text = "0";
            txtidprod.Text = "0";
        }

        private void btnbuscarprov_Click(object sender, EventArgs e)
        {
            using(var modal = new md_proveedor())
            {
                var result = modal.ShowDialog();
                if(result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtruc.Text = modal._Proveedor.Documento;
                    txtrsocialproveedor.Text = modal._Proveedor.RazonSocial;
                }
                else
                {
                    txtruc.Select();
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            using (var modal = new md_Productos())
            {
                var result = modal.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtidprod.Text = modal._producto.idProducto.ToString();
                    txtnombreprod.Text = modal._producto.Nombre;
                    txtcodprod.Text = modal._producto.Codigo;
                    txxprecomp.Select();
                }
                else
                {
                    txtcodprod.Select();
                }
            }
        }

        private void txtcodprod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Producto oProducto = new CN_Producto().Listar().Where(p => p.Codigo == txtcodprod.Text && p.Estado == true).FirstOrDefault();
                if(oProducto != null)
                {
                    txtcodprod.BackColor = System.Drawing.Color.Honeydew;
                    txtidprod.Text = oProducto.idProducto.ToString();
                    txtnombreprod.Text = oProducto.Nombre;
                    txxprecomp.Select();
                }
                else
                {
                    txtcodprod.BackColor = System.Drawing.Color.MistyRose;
                    txtidprod.Text = "0";
                    txtnombreprod.Text = "";
                    MessageBox.Show("Error: Producto inactivo o no registrado", "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            bool producto_agregado = false;
            if (int.Parse(txtidprod.Text) == 0)
            {
                MessageBox.Show("Error: Debe seleccionar un producto", "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!decimal.TryParse(txxprecomp.Text, out preciocompra))
            {
                MessageBox.Show("Error: Precio compra - Formato de moneda incorrecto", "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txxprecomp.Select();
                return;
            }
            foreach(DataGridViewRow fila in dataGridView1.Rows)
            {
                    if (fila.Cells["IdProducto"].Value?.ToString() == txtidprod.Text)
                    {
                        producto_agregado = true;
                        break;
                    }
            }
            if (!producto_agregado)
            {
                dataGridView1.Rows.Add(new object[] {
                    txtidprod.Text,
                    txtnombreprod.Text,
                    preciocompra.ToString("0.00"),
                    nupcantidad.Value.ToString(),
                    (nupcantidad.Value * preciocompra).ToString("0.00")
                });
                calcularTotal();
                limpiarproducto();
                txtcodprod.Select();
            }
        }
        private void limpiarproducto()
        {
            txtidprod.Text = "0";
            txtcodprod.Text = "";
            txtcodprod.BackColor = System.Drawing.Color.White;
            txtnombreprod.Text = "";
            txxprecomp.Text = "";
            nupcantidad.Value = 1;
        }
        private void calcularTotal()
        {
            decimal total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
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

        private void txxprecomp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if(txxprecomp.Text.Trim().Length==0&& e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
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

        private void btnregistrarguardarcompra_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Error: Debe seleccionar un proveedor", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Error: Debe seleccionar al menos un producto", "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable DetalleCompra = new DataTable();
            DetalleCompra.Columns.Add("IdProducto", typeof(int));
            DetalleCompra.Columns.Add("PrecioCompra", typeof(decimal));
            DetalleCompra.Columns.Add("Cantidad", typeof(int));
            DetalleCompra.Columns.Add("MontoTotal", typeof(decimal));
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                DetalleCompra.Rows.Add(new object[]
                {
                    Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                    row.Cells["PrecioCompra"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Subtotal"].Value.ToString()
                });
            }
            int idcorrelativo = new CN_Compra().obtenercorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);
            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { idUsuario = _usuario.idUsuario},
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text)},
                TipoDocumento =((OpcionesCombo)cbdoc.SelectedItem).texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txttotal.Text)
            };
            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, DetalleCompra, out mensaje);
            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generado: \n" + numerodocumento + "\n\n¿Desea copiar al portapapeles?","Satisfactorio",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);
                }
                txtidproveedor.Text = "0";
                txtruc.Text = "";
                txtrsocialproveedor.Text = "";
                dataGridView1.Rows.Clear();
                calcularTotal();
            }
            else
            {
                MessageBox.Show("Error: "+mensaje, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
