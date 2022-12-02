using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Venta
    {
        public int obtenercorrelativo()
        {
            int idcorrelativo = 0;
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*)+1 from VENTA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.CommandType = CommandType.Text;
                    StrifoConexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
                return idcorrelativo;
            }
        }
        public bool registrar(Venta obj, DataTable DetalleVenta, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    /*
                    @IdUsuario int,
    @TipoDocumento varchar(500),
    @NumeroDocumento varchar(500),
    @IdCliente int,
    @NombreCliente varchar(500),
    @MontoPago decimal(18, 2),
    @MontoCambio decimal(18, 2),
    @MontoTotal decimal(18, 2),
    @DetalleVenta[EDettalle_Venta] READONLY,
    @Resultado int output,
    @Mensaje varchar(500) OUTPUT
                    */
                    SqlCommand cmd = new SqlCommand("RegistrarVenta", StrifoConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.tipodocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.numerodocumento);
                    cmd.Parameters.AddWithValue("IdCliente", obj.idcliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.nombrecliente);
                    cmd.Parameters.AddWithValue("MontoPago", obj.montopago);
                    cmd.Parameters.AddWithValue("MontoCambio", obj.montocambio);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.montototal);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    StrifoConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
                return respuesta;
            }
        }
    }
}
