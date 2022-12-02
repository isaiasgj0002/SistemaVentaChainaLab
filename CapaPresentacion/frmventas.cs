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
        public frmventas()
        {
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
                }
                else
                {
                    txtnombreplato.Select();
                }
            }
        }
    }
}
