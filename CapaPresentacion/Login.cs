using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            List<Usuario> usuario = new CN_Usuarios().Listar();
            Usuario oUsuario = new CN_Usuarios().Listar().Where(u => u.Documento == txtdoc.Text && u.Clave == txtpass.Text).FirstOrDefault();
            FormInicio inicio = new FormInicio(oUsuario);
            if (oUsuario != null)
            {
                inicio.Show();
                this.Hide();
                inicio.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Datos incorrectos, intentalo de nuevo");
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            txtdoc.Text = "";
            txtpass.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpass.UseSystemPasswordChar = false;
            }
            else
            {
                txtpass.UseSystemPasswordChar = true;
            }
        }
    }
}
