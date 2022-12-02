using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio obtenerDatos()
        {
            Negocio obj = new Negocio();

            try
            {
                using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
                {
                    StrifoConexion.Open();
                    string query = "select IdNegocio, Nombre,RUC, Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, StrifoConexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(reader["IdNegocio"].ToString()),
                                Nombre = reader["Nombre"].ToString(),
                                RUC = reader["RUC"].ToString(),
                                Direccion = reader["Direccion"].ToString(),

                            };
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio();
            }

            return obj;
        }
        public bool GuardarDatos(Negocio obj, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
                {
                    StrifoConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Nombre = @nombre,");
                    query.AppendLine("RUC = @ruc,");
                    query.AppendLine("Direccion = @direccion");
                    query.AppendLine("where IdNegocio = 1;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@ruc", obj.RUC);
                    cmd.Parameters.AddWithValue("@direccion", obj.Direccion);
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudieron guardar los cambios";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public byte[]obtenerlogo(out bool obtenido)
        {
            obtenido = true;
            byte[] logobytes = new byte[0];
            try
            {
                using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
                {
                    StrifoConexion.Open();
                    string query = "select Logo from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, StrifoConexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logobytes = (byte[])(reader["Logo"]);
                        }
                    }
                }
            }
            catch
            {
                obtenido=false;
                logobytes = new byte[0];
            }
            return logobytes;
        }
        public bool ActualizarLogo(byte[] image, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;
            try
            {
                using (SqlConnection StrifoConexion = new SqlConnection(Conexion.cadena))
                {
                    StrifoConexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Logo = @imagen");
                    query.AppendLine("where IdNegocio = 1;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), StrifoConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@imagen", image);
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
