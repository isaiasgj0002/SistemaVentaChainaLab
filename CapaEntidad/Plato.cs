using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Plato
    {
        public int idplato { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Categoria oCategoria { get; set; } 
        public int stock { get; set; } 
        public decimal precioventa { get; set; } 
        public bool estado { get; set; } 
        public string fechacreacion { get; set; }
    }
}
