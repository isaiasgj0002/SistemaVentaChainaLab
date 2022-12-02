using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedores
    {
        private CD_Proveedores objcd_Proveedores = new CD_Proveedores();
        public List<Proveedor> Listar()
        {
            return objcd_Proveedores.Listar();
        }
        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "el documento es obligatorio\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Razon social es obligatorio\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Proveedores.registrar(obj, out Mensaje);
            }

        }
        public bool editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Documento == "")
            {
                Mensaje += "el documento es obligatorio\n";
            }
            if (obj.RazonSocial == "")
            {
                Mensaje += "Razon social es obligatorio\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Proveedores.editar(obj, out Mensaje);
            }
        }
        public bool eliminar(Proveedor obj, out string Mensaje)
        {
            return objcd_Proveedores.eliminar(obj, out Mensaje);
        }
    }
}
