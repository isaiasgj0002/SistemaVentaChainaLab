using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        private CD_Clientes objcd_Clientes = new CD_Clientes();
        public List<Cliente> Listar()
        {
            return objcd_Clientes.Listar();
        }
        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "el nombre es obligatorio\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Clientes.registrar(obj, out Mensaje);
            }

        }
        public bool editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.NombreCompleto == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Clientes.editar(obj, out Mensaje);
            }

        }
        public bool eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_Clientes.eliminar(obj, out Mensaje);
        }
    }
}
