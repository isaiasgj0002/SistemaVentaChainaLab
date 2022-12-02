using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Platos
    {
        private CD_Platos objcd_Plato = new CD_Platos();
        public List<Plato> Listar()
        {
            return objcd_Plato.Listar();
        }
        public int Registrar(Plato obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.descripcion == "")
            {
                Mensaje += "La descripcion es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Plato.registrar(obj, out Mensaje);
            }

        }
        public bool editar(Plato obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.descripcion == "")
            {
                Mensaje += "La descripcion es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Plato.editar(obj, out Mensaje);
            }

        }
        public bool eliminar(Plato obj, out string Mensaje)
        {
            return objcd_Plato.eliminar(obj, out Mensaje);
        }
    }
}
