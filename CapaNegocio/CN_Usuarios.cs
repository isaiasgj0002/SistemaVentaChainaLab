using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "La clave es obligatoria\n";
            }
            if(Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_usuario.registrar(obj, out Mensaje);
            }
            
        }
        public bool editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "El documento es obligatorio\n";
            }
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Clave == "")
            {
                Mensaje += "La clave es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.editar(obj, out Mensaje);
            }
            
        }
        public bool eliminar(Usuario obj, out string Mensaje)
        {
            return objcd_usuario.eliminar(obj, out Mensaje);
        }
    }
}
