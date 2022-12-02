using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmusuarios : Form
    {
        public frmusuarios()
        {
            InitializeComponent();
        }

        private void frmusuarios_Load(object sender, EventArgs e)
        {
            cbestado.Items.Add(new OpcionesCombo() { Valor = 1, texto = "Activo" });
            cbestado.Items.Add(new OpcionesCombo() { Valor = 0, texto = "No Activo" });
            cbestado.DisplayMember = "texto";
            cbestado.ValueMember = "valor";
            cbestado.SelectedIndex = 0;
            List<Rol> ListaRol = new CN_Rol().Listar();
            foreach (Rol Item in ListaRol)
            {
                cbrol.Items.Add(new OpcionesCombo() { Valor = Item.IdRol, texto = Item.Descripcion });
            }
            cbrol.DisplayMember = "texto";
            cbrol.ValueMember = "Valor";
            cbrol.SelectedIndex = 0;
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

            List<Usuario> ListUsuario = new CN_Usuarios().Listar();
            foreach (Usuario Item in ListUsuario)
            {
                dataGridView1.Rows.Add(new object[] {"",Item.idUsuario,Item.Documento,Item.NombreCompleto,Item.Correo,Item.Clave,
                Item.oRol.IdRol,
                Item.oRol.Descripcion,
                Item.Estado == true ? 1 : 0,
                Item.Estado == true ? "Activo" : "No activo"
              });
            }
            txtid.Text = "0";
        }

        private void chkbmostrarclave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbmostrarclave.Checked == true)
            {
                txtpassword.UseSystemPasswordChar = false;
                txtpassword2.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
                txtpassword2.UseSystemPasswordChar = true;
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if(txtpassword.Text == txtpassword2.Text)
            {
                string Mensaje = string.Empty;
                Usuario objusuario = new Usuario()
                {
                    idUsuario = Convert.ToInt32(txtid.Text),
                    Documento = txtdoc.Text,
                    NombreCompleto = txtnombres.Text,
                    Correo = txtcorreo.Text,
                    Clave = txtpassword.Text,
                    oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionesCombo)cbrol.SelectedItem).Valor) },
                    Estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
                };
                int idusuariogenerado = new CN_Usuarios().Registrar(objusuario, out Mensaje);
                if (idusuariogenerado != 0)
                {
                    dataGridView1.Rows.Add(new object[] {"",idusuariogenerado,txtdoc.Text,txtnombres.Text,txtcorreo.Text,txtpassword.Text,
                ((OpcionesCombo)cbrol.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cbrol.SelectedItem).texto.ToString(),
                ((OpcionesCombo)cbestado.SelectedItem).Valor.ToString(),
                ((OpcionesCombo)cbestado.SelectedItem).texto.ToString()
                });
                    limpiar();
                    MessageBox.Show("Usuario agregado correctamente","Exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: " + Mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                limpiar();
            }
            else
            {
                MessageBox.Show("Error: Las contraseñas no coinciden", "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar()
        {
            txtid.Text = "0";
            txtdoc.Text = "";
            txtnombres.Text = "";
            txtcorreo.Text = "";
            txtpassword.Text = "";
            txtpassword2.Text = "";
            cbrol.SelectedIndex = 0;
            cbestado.SelectedIndex = 0;
        }
        public void actualizar()
        {
            dataGridView1.Rows.Clear();
            List<Usuario> ListUsuario = new CN_Usuarios().Listar();
            foreach (Usuario Item in ListUsuario)
            {
                dataGridView1.Rows.Add(new object[] {"",Item.idUsuario,Item.Documento,Item.NombreCompleto,Item.Correo,Item.Clave,
                Item.oRol.IdRol,
                Item.oRol.Descripcion,
                Item.Estado == true ? 1 : 0,
                Item.Estado == true ? "Activo" : "No activo"
              });
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
                    txtdoc.Text = dataGridView1.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombres.Text = dataGridView1.Rows[indice].Cells["Nombres"].Value.ToString();
                    txtcorreo.Text = dataGridView1.Rows[indice].Cells["Correo"].Value.ToString();
                    txtpassword.Text = dataGridView1.Rows[indice].Cells["Clave"].Value.ToString();
                    txtpassword2.Text = dataGridView1.Rows[indice].Cells["Clave"].Value.ToString();
                    foreach (OpcionesCombo oc in cbrol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dataGridView1.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cbrol.Items.IndexOf(oc);
                            cbrol.SelectedIndex = indice_combo;
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
            if (txtpassword.Text == txtpassword2.Text)
            {
                string Mensaje = string.Empty;
                Usuario objusuario = new Usuario()
                {
                    idUsuario = Convert.ToInt32(txtid.Text),
                    Documento = txtdoc.Text,
                    NombreCompleto = txtnombres.Text,
                    Correo = txtcorreo.Text,
                    Clave = txtpassword.Text,
                    oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionesCombo)cbrol.SelectedItem).Valor) },
                    Estado = Convert.ToInt32(((OpcionesCombo)cbestado.SelectedItem).Valor) == 1 ? true : false
                };
                bool resultado = new CN_Usuarios().editar(objusuario, out Mensaje);

                if (resultado)
                {
                    MessageBox.Show("Se actualizo el usuario");
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
            else
            {
                MessageBox.Show("Error: Las contraseñas no coinciden", "No se pudo editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea eliminar el usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Mensaje = string.Empty;
                Usuario objusuario = new Usuario()
                {
                    idUsuario = Convert.ToInt32(txtid.Text),
                };
                bool respuesta = new CN_Usuarios().eliminar(objusuario, out Mensaje);
                if (respuesta)
                {
                    actualizar();
                    limpiar();
                    btnguardar.Enabled = true;
                    btnmodificar.Enabled = false;
                    btneliminar.Enabled = false;
                    txtid.ReadOnly = false;
                    MessageBox.Show("Se elimino el usuario");
                }
                else
                {
                    MessageBox.Show("Error: " + Mensaje,"No se pudo eliminar",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesCombo)cbbusqueda.SelectedItem).Valor.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper())){
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

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
