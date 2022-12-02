using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Negocio
    {
        private CD_Negocio objcdnegocio = new CD_Negocio();
        public Negocio listar()
        {
            return objcdnegocio.obtenerDatos();
        }
        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.Nombre == "")
            {
                Mensaje += "El nombre es obligatorio\n";
            }
            if (obj.RUC == "")
            {
                Mensaje += "El RUC es obligatorio\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje += "La direccion es obligatoria\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcdnegocio.GuardarDatos(obj, out Mensaje);
            }

        }
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcdnegocio.obtenerlogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objcdnegocio.ActualizarLogo(imagen, out mensaje);
        }
    }
}
