using CapaEntidad;
using CapaNegocio;
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
    }
}
