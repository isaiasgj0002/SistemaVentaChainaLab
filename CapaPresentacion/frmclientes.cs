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

namespace CapaPresentacion
{
    public partial class frmclientes : Form
    {
        public frmclientes()
        {
            InitializeComponent();
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

        private void frmclientes_Load(object sender, EventArgs e)
        {
            cbestado.Items.Add(new OpcionesCombo() { Valor = 1, texto = "Activo" });
            cbestado.Items.Add(new OpcionesCombo() { Valor = 0, texto = "No Activo" });
            cbestado.DisplayMember = "texto";
            cbestado.ValueMember = "valor";
            cbestado.SelectedIndex = 0;
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbbusqueda.Items.Add(new OpcionesCombo() { Valor = columna.Name, texto = columna.HeaderText });
                }
            }
            cbbusqueda.DisplayMember = "texto";
            cbbusqueda.ValueMember = "Valor";
            cbbusqueda.SelectedIndex = 0;
            try
            {
                List<Cliente> ListCliente = new CN_Clientes().Listar();
                foreach (Cliente Item in ListCliente)
                {
                    dataGridView1.Rows.Add(new object[] {
                    "",
                    Item.idCliente,
                    Item.NombreCompleto,
                    Item.Correo,
                    Item.Telefono,
                    Item.Estado == true ? 1 : 0,
                    Item.Estado == true ? "Activo" : "No activo"
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            txtid.Text = "0";
        }
        public void actualizar()
        {
            dataGridView1.Rows.Clear();
            List<Cliente> ListCliente = new CN_Clientes().Listar();
            foreach (Cliente Item in ListCliente)
            {
                dataGridView1.Rows.Add(new object[] {
                    "",
                    Item.idCliente,
                    Item.NombreCompleto,
                    Item.Correo,
                    Item.Telefono,
                    Item.Estado == true ? 1 : 0,
                    Item.Estado == true ? "Activo" : "No activo"
                    });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Cliente objcliente = new Cliente()
            {
                idCliente = Convert.ToInt32(txtid.Text),
                NombreCompleto = tctnombres.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
            };
            int idclientegenerado = new CN_Clientes().Registrar(objcliente, out Mensaje);
            if (idclientegenerado != 0)
            {
                actualizar();
                //dataGridView1.Rows.Add(new object[] {"",idplatogenerado,txtnombre.Text,txtdesc.Text,
                //((OpcionesCombo)cbcate.SelectedItem).Valor.ToString(),
                //((OpcionesCombo)cbcate.SelectedItem).texto.ToString(),
                //((OpcionesCombo)cbestado.SelectedItem).Valor.ToString(),
                //((OpcionesCombo)cbestado.SelectedItem).texto.ToString()
                //});
                limpiar();
                MessageBox.Show("Cliente agregado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: " + Mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            limpiar();
        }
        private void limpiar()
        {
            txtid.Text = "0";
            tctnombres.Text = "";
            txtcorreo.Text = "";
            txttelefono.Text = "";
            cbestado.SelectedIndex = 0;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Cliente obcliente = new Cliente()
            {
                idCliente = Convert.ToInt32(txtid.Text),
                NombreCompleto = tctnombres.Text,
                Correo = txtcorreo.Text,
                Telefono = txttelefono.Text,
                Estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
            };
            bool resultado = new CN_Clientes().editar(obcliente, out Mensaje);

            if (resultado)
            {
                MessageBox.Show("Se actualizo el cliente");
                //DataGridViewRow row = dataGridView1.CurrentCell.RowIndex;
                //row.Cells
                actualizar();
                limpiar();
                btnguardar.Enabled = true;
                btnmodificar.Enabled = false;
                btneliminar.Enabled = false;
                txtid.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Error: " + Mensaje, "No se pudo editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var h = Properties.Resources.icons8_check_20.Width;
                var w = Properties.Resources.icons8_check_20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.icons8_check_20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                btnmodificar.Enabled = true;
                btneliminar.Enabled = true;
                btnguardar.Enabled = false;
                txtid.ReadOnly = true;
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtid.Text = dataGridView1.Rows[indice].Cells["Id"].Value.ToString();
                    tctnombres.Text = dataGridView1.Rows[indice].Cells["Nombres"].Value.ToString();
                    txtcorreo.Text = dataGridView1.Rows[indice].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dataGridView1.Rows[indice].Cells["Telefono"].Value.ToString();
                    foreach (OpcionesCombo oc in cbestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dataGridView1.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cbestado.Items.IndexOf(oc);
                            cbestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Mensaje = string.Empty;
                Cliente obcliente = new Cliente()
                {
                    idCliente = Convert.ToInt32(txtid.Text),
                };
                bool respuesta = new CN_Clientes().eliminar(obcliente, out Mensaje);
                if (respuesta)
                {
                    actualizar();
                    limpiar();
                    btnguardar.Enabled = true;
                    btnmodificar.Enabled = false;
                    btneliminar.Enabled = false;
                    txtid.ReadOnly = false;
                    MessageBox.Show("Se elimino el cliente");
                }
                else
                {
                    MessageBox.Show("Error: " + Mensaje, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
