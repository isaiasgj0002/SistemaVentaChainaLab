using CapaEntidad;
using CapaNegocio;
using ClosedXML;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmdetallecompras : Form
    {
        public frmdetallecompras()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra compra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);
            if(compra.idCompra != 0)
            {
                txtnumerocompra2.Text = compra.NumeroDocumento;
                txtfecha.Text = compra.FechaRegistro;
                txttipo.Text = compra.TipoDocumento;
                txtusuario.Text = compra.oUsuario.NombreCompleto;
                txtrucproveedor.Text = compra.oProveedor.Documento;
                txtrazonsocialproveedor.Text = compra.oProveedor.RazonSocial;
                dataGridView1.Rows.Clear();
                    foreach (DetalleCompra dc in compra.oDetalleCompra)
                    {
                        dataGridView1.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                    }
                txttotal.Text = compra.MontoTotal.ToString("0.00");
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            txtnumerocompra2.Text = "";
            txtfecha.Text = "";
            txttipo.Text = "";
            txtusuario.Text = "";
            txtrucproveedor.Text = "";
            txtrazonsocialproveedor.Text = "";
            dataGridView1.Rows.Clear();
            txttotal.Text = "0.00";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(txttipo.Text == "")
            {
                MessageBox.Show("Error: No ha seleccionado ninguna compra", "No se pudo exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string texto_html = Properties.Resources.PlantillaCompra.ToString();
                Negocio negocio = new CN_Negocio().listar();
                texto_html = texto_html.Replace("@nombrenegocio", negocio.Nombre.ToUpper());
                texto_html = texto_html.Replace("@docnegocio", negocio.RUC);
                texto_html = texto_html.Replace("@direcnegocio", negocio.Direccion);
                texto_html = texto_html.Replace("@tipodocumento", txttipo.Text.ToUpper());
                texto_html = texto_html.Replace("@numerodocumento", txtnumerocompra2.Text);
                texto_html = texto_html.Replace("@docproveedor", txtrucproveedor.Text);
                texto_html = texto_html.Replace("@nombreproveedor", txtrazonsocialproveedor.Text);
                texto_html = texto_html.Replace("@fecharegistro", txtfecha.Text);
                texto_html = texto_html.Replace("@usuarioregistro", txtusuario.Text);
                string filas = string.Empty;
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                    filas += "</tr>";
                }
                texto_html = texto_html.Replace("@filas", filas);
                texto_html = texto_html.Replace("@montototal", txttotal.Text);
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("Compra_{0}.pdf", txtnumerocompra2.Text);
                saveFile.Filter = "Pdf Files|*.pdf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using(FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4,25,25,25,25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        bool obtenido = true;
                        byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);
                        if (obtenido)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfdoc.Left,pdfdoc.GetTop(51));
                            pdfdoc.Add(img);
                        }
                        using(StringReader sr = new StringReader(texto_html))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfdoc, sr);
                        }
                        pdfdoc.Close();
                        stream.Close();
                        MessageBox.Show("Se guardo el documento satisfactoriamente", "Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void frmdetallecompras_Load(object sender, EventArgs e)
        {

        }
    }
}
