using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmplatos : Form
    {
        public frmplatos()
        {
            InitializeComponent();
        }

        private void frmplatos_Load(object sender, EventArgs e)
        {
            cbestado.Items.Add(new OpcionesCombo() { Valor = 1, texto = "Activo" });
            cbestado.Items.Add(new OpcionesCombo() { Valor = 0, texto = "No Activo" });
            cbestado.DisplayMember = "texto";
            cbestado.ValueMember = "valor";
            cbestado.SelectedIndex = 0;
            List<Categoria> ListaCategoria = new CN_Categoria().Listar();
            foreach (Categoria Item in ListaCategoria)
            {
                cbcate.Items.Add(new OpcionesCombo() { Valor = Item.IdCategoria, texto = Item.Descripcion });
            }
            cbcate.DisplayMember = "texto";
            cbcate.ValueMember = "Valor";
            cbcate.SelectedIndex = 0;
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
                List<Plato> ListPlato = new CN_Platos().Listar();
                foreach (Plato Item in ListPlato)
                {
                    dataGridView1.Rows.Add(new object[] {
                    "",
                    Item.idplato,
                    Item.nombre,
                    Item.descripcion,
                    Item.oCategoria.IdCategoria,
                    Item.oCategoria.Descripcion,
                    Item.stock,
                    Item.precioventa,
                    Item.estado == true ? 1 : 0,
                    Item.estado == true ? "Activo" : "No activo"
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
            List<Plato> ListPlato = new CN_Platos().Listar();
            foreach (Plato Item in ListPlato)
            {
                dataGridView1.Rows.Add(new object[] {
                    "",
                    Item.idplato,
                    Item.nombre,
                    Item.descripcion,
                    Item.oCategoria.IdCategoria,
                    Item.oCategoria.Descripcion,
                    Item.stock,
                    Item.precioventa,
                    Item.estado == true ? 1 : 0,
                    Item.estado == true ? "Activo" : "No activo"
                    });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Plato objplato = new Plato()
            {
                idplato = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                descripcion = txtdesc.Text,
                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionesCombo)cbcate.SelectedItem).Valor) },
                estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
            };
            int idplatogenerado = new CN_Platos().Registrar(objplato, out Mensaje);
            if (idplatogenerado != 0)
            {
                actualizar();
                //dataGridView1.Rows.Add(new object[] {"",idplatogenerado,txtnombre.Text,txtdesc.Text,
                //((OpcionesCombo)cbcate.SelectedItem).Valor.ToString(),
                //((OpcionesCombo)cbcate.SelectedItem).texto.ToString(),
                //((OpcionesCombo)cbestado.SelectedItem).Valor.ToString(),
                //((OpcionesCombo)cbestado.SelectedItem).texto.ToString()
                //});
                limpiar();
                MessageBox.Show("Plato agregado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtnombre.Text = "";
            txtdesc.Text = "";
            cbcate.SelectedIndex = 0;
            cbestado.SelectedIndex = 0;
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
                    txtnombre.Text = dataGridView1.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdesc.Text = dataGridView1.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionesCombo oc in cbcate.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dataGridView1.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cbcate.Items.IndexOf(oc);
                            cbcate.SelectedIndex = indice_combo;
                            break;
                        }
                    }
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
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;
            Plato objplato = new Plato()
            {
                idplato = Convert.ToInt32(txtid.Text),
                nombre = txtnombre.Text,
                descripcion = txtdesc.Text,

                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(((OpcionesCombo)cbcate.SelectedItem).Valor) },
                estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
            };
            bool resultado = new CN_Platos().editar(objplato, out Mensaje);

            if (resultado)
            {
                MessageBox.Show("Se actualizo el plato");
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el plato", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Mensaje = string.Empty;
                Plato obplato = new Plato()
                {
                    idplato = Convert.ToInt32(txtid.Text),
                };
                bool respuesta = new CN_Platos().eliminar(obplato, out Mensaje);
                if (respuesta)
                {
                    actualizar();
                    limpiar();
                    btnguardar.Enabled = true;
                    btnmodificar.Enabled = false;
                    btneliminar.Enabled = false;
                    txtid.ReadOnly = false;
                    MessageBox.Show("Se elimino el plato");
                }
                else
                {
                    MessageBox.Show("Error: " + Mensaje, "No se pudo eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    if (dataGridViewRow.Visible)
                    {
                        dt.Rows.Add(new object[]
                        {
                            dataGridViewRow.Cells[2].Value.ToString(),
                            dataGridViewRow.Cells[3].Value.ToString(),
                            dataGridViewRow.Cells[5].Value.ToString(),
                            dataGridViewRow.Cells[6].Value.ToString(),
                            dataGridViewRow.Cells[7].Value.ToString(),
                            dataGridViewRow.Cells[9].Value.ToString(),
                        });
                    }
                }
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReportePlatos_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte generado correctamente");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: " + "No hay datos disponibles para exportar", "No se pudo exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
