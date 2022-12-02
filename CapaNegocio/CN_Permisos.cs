using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permisos
    {
        private CD_PERMISOS objcd_permisos = new CD_PERMISOS();
        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_permisos.Listar(IdUsuario);
        }
    }
}
