﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Compra
    {
        private CD_Compra objcd_compra = new CD_Compra();
        public int obtenercorrelativo()
        {
            return objcd_compra.obtenercorrelativo();
        }
        public bool Registrar(Compra obj,DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_compra.registrar(obj, DetalleCompra, out Mensaje);
        }
        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objcd_compra.ObtenerCompra(numero);
            if(oCompra.idCompra != 0)
            {
                List<DetalleCompra> oDetalleCompra = objcd_compra.ObtenerDetalleCompra(oCompra.idCompra);
                oCompra.oDetalleCompra = oDetalleCompra;
            }
            return oCompra;
        }
    }
}
