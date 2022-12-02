using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class FormInicio : Form
    {
        private static Usuario usuarioactual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null; 
        public FormInicio(Usuario objusuario)
        {
            usuarioactual = objusuario;
            InitializeComponent();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new CN_Permisos().Listar(usuarioactual.idUsuario);
            foreach(IconMenuItem iconmenu in menuStrip1.Items)
            {
                bool encontrado = listaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }
            lbluser.Text = usuarioactual.NombreCompleto.ToString();
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            if(FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.IndianRed;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmusuarios());
        }

        private void icmcategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmcategoria());
        }

        private void icmproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmproducto());
        }

        private void icmregistrar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmventas());
        }

        private void icmdetalle_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmdetalleventa());
        }

        private void icmregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmcompras(usuarioactual));
        }

        private void icmdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmdetallecompras());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmproveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmreportes());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmacercade());
        }

        private void menureservas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmreservas());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmclientes());
        }

        private void imcplatos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmplatos());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmnegocio());
        }
    }
}
