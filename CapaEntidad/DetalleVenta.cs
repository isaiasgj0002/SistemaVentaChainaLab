using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int iddetalleventa { get; set; }
        public Plato oPlato{get;set;}
        public decimal precioventa { get; set; } 
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }   
        public string fechacreacion { get; set; }
    }
}
