using CapaEntidad;
using CapaNegocio;
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
    public partial class frmdetalleventa : Form
    {
        public frmdetalleventa()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Venta venta = new CN_Venta().ObtenerVenta(txtbusqueda.Text);
            if (venta.idventa != 0)
            {
                txtnumeroventa2.Text = venta.numerodocumento;
                txtfecha.Text = venta.fechacreacion;
                txttipo.Text = venta.tipodocumento;
                txtusuario.Text = venta.oUsuario.NombreCompleto;
                txtnombrecliente.Text = venta.nombrecliente;
                dataGridView1.Rows.Clear();
                foreach (DetalleVenta dc in venta.oDetalleVenta)
                {
                    dataGridView1.Rows.Add(new object[] { dc.oPlato.nombre, dc.precioventa, dc.cantidad, dc.subtotal });
                }
                txttotal.Text = venta.montototal.ToString("0.00");
                txtmontopago.Text = venta.montopago.ToString("0.00");
                txtmontocambio.Text = venta.montocambio.ToString("0.00");
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            txtnumeroventa2.Text = "";
            txtfecha.Text = "";
            txttipo.Text = "";
            txtusuario.Text = "";
            txtnombrecliente.Text = "";
            dataGridView1.Rows.Clear();
            txttotal.Text = "0.00";
        }

        private void frmdetalleventa_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txttipo.Text == "")
            {
                MessageBox.Show("Error: No ha seleccionado ninguna compra", "No se pudo exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string texto_html = Properties.Resources.PlantillaVenta.ToString();
                Negocio negocio = new CN_Negocio().listar();
                texto_html = texto_html.Replace("@nombrenegocio", negocio.Nombre.ToUpper());
                texto_html = texto_html.Replace("@docnegocio", negocio.RUC);
                texto_html = texto_html.Replace("@direcnegocio", negocio.Direccion);
                texto_html = texto_html.Replace("@tipodocumento", txttipo.Text.ToUpper());
                texto_html = texto_html.Replace("@numerodocumento", txtnumeroventa2.Text);
                texto_html = texto_html.Replace("@nombrecliente", txtnombrecliente.Text);
                texto_html = texto_html.Replace("@fecharegistro", txtfecha.Text);
                texto_html = texto_html.Replace("@usuarioregistro", txtusuario.Text);
                string filas = string.Empty;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    filas += "<tr>";
                    filas += "<td>" + row.Cells["Plato"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Precio"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                    filas += "<td>" + row.Cells["Subtotal"].Value.ToString() + "</td>";
                    filas += "</tr>";
                }
                texto_html = texto_html.Replace("@filas", filas);
                texto_html = texto_html.Replace("@montototal", txttotal.Text);
                texto_html = texto_html.Replace("@pagocon", txtmontopago.Text);
                texto_html = texto_html.Replace("@cambio", txtmontocambio.Text);
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("Venta_{0}.pdf", txtnumeroventa2.Text);
                saveFile.Filter = "Pdf Files|*.pdf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 25, 25, 25, 25);
                        PdfWriter writer = PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        bool obtenido = true;
                        byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);
                        if (obtenido)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteimage);
                            img.ScaleToFit(60, 60);
                            img.Alignment = iTextSharp.text.Image.UNDERLYING;
                            img.SetAbsolutePosition(pdfdoc.Left, pdfdoc.GetTop(51));
                            pdfdoc.Add(img);
                        }
                        using (StringReader sr = new StringReader(texto_html))
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
    }
}
