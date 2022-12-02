using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.SymbolStore;
using System.ComponentModel;

namespace CapaDatos
{
    public class CD_Compra
    {
        public int obtenercorrelativo()
        {
            int idcorrelativo = 0;
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*)+1 from COMPRA");
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
        /*@IdUsuario int,
    @IdProveedor int,
    @TipoDocumento varchar(500),
    @NumeroDocumento varchar(500),
    @MontoTotal decimal(18,2), */
        public bool registrar(Compra obj, DataTable DetalleCompra, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RegistrarCompra", StrifoConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.oUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("TipoDocumento", obj.TipoDocumento);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
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
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select C.IdCompra,");
                    query.AppendLine("u.Nombres, ");
                    query.AppendLine("P.Documento,");
                    query.AppendLine("P.RazonSocial, C.TipoDocumento, C.NumeroDocumento, C.MontoTotal, convert(char(10),C.fechaCreacion,103)[fechaRegistro]");
                    query.AppendLine("from COMPRA C");
                    query.AppendLine("inner join USUARIOS U on C.IdUsuario = U.IdUsuario");
                    query.AppendLine("inner join PROVEEDOR P on P.IdProveedor = C.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;
                    StrifoConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                idCompra = Convert.ToInt32(dr["IdCompra"]),
                                oUsuario = new Usuario { NombreCompleto = dr["Nombres"].ToString() },
                                oProveedor = new Proveedor { Documento = dr["Documento"].ToString(), RazonSocial = dr["RazonSocial"].ToString() },
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
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
                    obj = new Compra();
                }
                return obj;
            }
        }
        public List<DetalleCompra> ObtenerDetalleCompra(int idcompra)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select PR.Nombre, DC.PrecioCompra, DC.Cantidad, DC.MontoTotal ");
                    query.AppendLine("from DETALLE_COMPRA DC inner JOIN PRODUCTOS PR on DC.IdProducto = PR.IdProducto");
                    query.AppendLine("where IdCompra = @idcompra");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;
                    StrifoConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DetalleCompra()
                            {
                                oProducto = new Producto() {Nombre = dr["Nombre"].ToString() },
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),

                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<DetalleCompra>();
                }
            }
            return lista;
        }
    }
}
