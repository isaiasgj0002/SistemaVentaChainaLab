using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmreportes : Form
    {
        public frmreportes()
        {
            InitializeComponent();
        }

        private void frmreportes_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=db_chainalab;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select TipoDocumento, NumeroDocumento, NombreCliente, MontoPago,MontoCambio,MontoTotal,fechaCreacion From VENTA", con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(row.Cells["MontoTotal"].Value);
            }
            txttotalventas.Text = total.ToString();
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=db_chainalab;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select AVG(MontoTotal) as Promedio from VENTA", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Promedio"].ToString();
            }
        }
    }
}
