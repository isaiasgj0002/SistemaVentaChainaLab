using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Productos objcd_Producto = new CD_Productos();
        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }
        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "El codigo es obligatorio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "La descripcion es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Producto.registrar(obj, out Mensaje);
            }

        }
        public bool editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Codigo == "")
            {
                Mensaje += "El codigo es obligatorio\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.Descripcion == "")
            {
                Mensaje += "La descripcion es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Producto.editar(obj, out Mensaje);
            }

        }
        public bool eliminar(Producto obj, out string Mensaje)
        {
            return objcd_Producto.eliminar(obj, out Mensaje);
        }
    }
}
