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
    public partial class md_Platos : Form
    {
        public Plato _plato { get; set; }
        public md_Platos()
        {
            InitializeComponent();
        }

        private void md_Platos_Load(object sender, EventArgs e)
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
                List<Plato> ListPlato = new CN_Platos().Listar();
                foreach (Plato Item in ListPlato)
                {
                    if (Item.estado)
                    {
                        dataGridView1.Rows.Add(new object[] {
                        Item.idplato,
                        Item.nombre,
                        Item.oCategoria.Descripcion,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int irow = e.RowIndex;
            int icolumn = e.ColumnIndex;
            if (irow >= 0 && icolumn > 0)
            {
                _plato = new Plato()
                {
                    idplato = Convert.ToInt32(dataGridView1.Rows[irow].Cells["Id"].Value.ToString()),
                    nombre = dataGridView1.Rows[irow].Cells["Nombre"].Value.ToString(),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
