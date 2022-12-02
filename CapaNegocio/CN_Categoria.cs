using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categorias objcd_Categoria = new CD_Categorias();
        public List<Categoria> Listar()
        {
            return objcd_Categoria.Listar();
        }
        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
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
                return objcd_Categoria.registrar(obj, out Mensaje);
            }

        }
        public bool editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
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
                return objcd_Categoria.editar(obj, out Mensaje);
            }

        }
        public bool eliminar(Categoria obj, out string Mensaje)
        {
            return objcd_Categoria.eliminar(obj, out Mensaje);
        }
    }
}
