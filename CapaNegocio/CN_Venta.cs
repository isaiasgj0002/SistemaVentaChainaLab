using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objcd_venta = new CD_Venta();
        public int obtenercorrelativo()
        {
            return objcd_venta.obtenercorrelativo();
        }
        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_venta.registrar(obj, DetalleVenta, out Mensaje);
        }
        public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = objcd_venta.ObtenerVenta(numero);
            if (oVenta.idventa != 0)
            {
                List<DetalleVenta> oDetalleVenta = objcd_venta.ObtenerDetalleVenta(oVenta.idventa);
                oVenta.oDetalleVenta = oDetalleVenta;
            }
            return oVenta;
        }
    }
}
