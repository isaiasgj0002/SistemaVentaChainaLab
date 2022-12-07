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
        public Venta ObtenerVenta(string numero)
        {
            Venta obj = new Venta();
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select v.IdVenta, u.Nombres,");
                    query.AppendLine("v.NombreCliente,");
                    query.AppendLine("v.TipoDocumento, v.NumeroDocumento,");
                    query.AppendLine("v.MontoPago, v.MontoCambio, v.MontoTotal,");
                    query.AppendLine("convert(char(10),v.fechaCreacion,103)[FechaRegistro]");
                    query.AppendLine("from VENTA v");
                    query.AppendLine("inner join USUARIOS u on u.IdUsuario = v.IdUsuario");
                    query.AppendLine("where v.NumeroDocumento = @numero");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;
                    StrifoConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Venta()
                            {
                                idventa = Convert.ToInt32(dr["IdVenta"]),
                                oUsuario = new Usuario { NombreCompleto = dr["Nombres"].ToString() },
                                nombrecliente = dr["NombreCliente"].ToString(),
                                tipodocumento = dr["TipoDocumento"].ToString(),
                                numerodocumento = dr["NumeroDocumento"].ToString(),
                                montototal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                montopago = Convert.ToDecimal(dr["MontoPago"].ToString()),
                                montocambio = Convert.ToDecimal(dr["MontoCambio"].ToString()),
                                fechacreacion = dr["FechaRegistro"].ToString()
                            };
                            /*
                            lista.Add(new Usuario()
                            {
                                idUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["Nombres"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }

                            });
                            */
                        }
                    }

                }
                catch (Exception ex)
                {
                    obj = new Venta();
                }
                return obj;
            }
        }
        public List<DetalleVenta> ObtenerDetalleVenta(int idventa)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select ");
                    query.AppendLine("p.Nombre, dv.PrecioVenta,dv.Cantidad,dv.Subtotal");
                    query.AppendLine("from DETALLE_VENTA dv");
                    query.AppendLine("inner join productos_platos p on p.IdPlato = dv.IdPlato");
                    query.AppendLine("where dv.IdVenta = @idventa");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.Parameters.AddWithValue("@idventa", idventa);
                    cmd.CommandType = System.Data.CommandType.Text;
                    StrifoConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleVenta()
                            {
                                oPlato = new Plato() { nombre = dr["Nombre"].ToString() },
                                precioventa = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                subtotal = Convert.ToDecimal(dr["Subtotal"].ToString()),

                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<DetalleVenta>();
                }
            }
            return lista;
        }
    }
}
