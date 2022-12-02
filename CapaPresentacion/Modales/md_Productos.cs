using CapaEntidad;
using CapaNegocio;
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

namespace CapaPresentacion.Modales
{
    public partial class md_Productos : Form
    {
        public Producto _producto { get; set; }
        public md_Productos()
        {
            InitializeComponent();
        }

        private void md_Productos_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                if (columna.Visible == true)
                {
                    cbbusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cbbusqueda.DisplayMember = "texto";
            cbbusqueda.ValueMember = "Valor";
            cbbusqueda.SelectedIndex = 0;

            try
            {
                List<Producto> ListProducto = new CN_Producto().Listar();
                foreach (Producto Item in ListProducto)
                {
                    if (Item.Estado)
                    {
                        dataGridView1.Rows.Add(new object[] {
                        Item.idProducto,
                        Item.Codigo,
                        Item.Nombre,
                        Item.oCategoria.Descripcion,
                        Item.Stock,
                        Item.PrecioCompra,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icolumn = e.ColumnIndex;
            if (irow >= 0 && icolumn > 0)
            {
                _producto = new Producto()
                {
                    idProducto = Convert.ToInt32(dataGridView1.Rows[irow].Cells["Id"].Value.ToString()),
                    Codigo = dataGridView1.Rows[irow].Cells["Codigo"].Value.ToString(),
                    Nombre = dataGridView1.Rows[irow].Cells["Nombre"].Value.ToString(),
                    Stock = Convert.ToInt32(dataGridView1.Rows[irow].Cells["Stock"].Value.ToString()),
                    PrecioCompra = Convert.ToDecimal(dataGridView1.Rows[irow].Cells["PrecioCompra"].Value.ToString()),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesCombo)cbbusqueda.SelectedItem).Valor.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
