using CapaEntidad;
using CapaNegocio;
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
    public partial class frmnegocio : Form
    {
        public frmnegocio()
        {
            InitializeComponent();
        }

        public Image bytetoimage(byte[] imagebytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagebytes, 0, imagebytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }

        private void frmnegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimagen = new CN_Negocio().ObtenerLogo(out obtenido);
            if (obtenido)
            {
                piclogo.Image = bytetoimage(byteimagen);
            }
            Negocio datos = new CN_Negocio().listar();
            txtnombre.Text = datos.Nombre;
            txtruc.Text = datos.RUC;
            txtdir.Text = datos.Direccion;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio obj = new Negocio()
            {
                Nombre = txtnombre.Text,
                RUC = txtruc.Text,
                Direccion = txtdir.Text
            };
            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Datos guardados correctamente");
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
        }

        private void icbsubirimagen_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimagen = File.ReadAllBytes(ofd.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(byteimagen, out mensaje);
                if (respuesta)
                {
                    piclogo.Image = bytetoimage(byteimagen);
                }
                else
                {
                    MessageBox.Show("Error: " + mensaje);
                }
            }
        }
    }
}
