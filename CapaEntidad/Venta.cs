using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int idventa { get; set; }
        public Usuario oUsuario { get; set; }
        public string tipodocumento { get; set; }
        public string numerodocumento { get; set; }
        public int idcliente { get; set; }
        public string nombrecliente { get; set; }
        public decimal montopago { get; set; } 
        public decimal montocambio { get; set; }
        public decimal montototal { get; set; }
        public List<DetalleVenta> oDetalleVenta;
        public string fechacreacion { get; set; }
    }
}
