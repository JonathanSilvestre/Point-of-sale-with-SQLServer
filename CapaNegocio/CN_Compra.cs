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

        private CD_Compra objCD_Compra = new CD_Compra();

        public int ObtenerCorrelativo()
        {
            return objCD_Compra.ObtenerCorrelativo();
        }

        public bool Registrar(Compra obj,DataTable DetalleCompra, out string mensaje)
        {
           
                return objCD_Compra.Registrar(obj,DetalleCompra, out mensaje);
            

        }

        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objCD_Compra.ObtenerCompra(numero);

            if(oCompra.IdCompra != 0)
            {
                List<DetalleCompra> oDetalleCompra = objCD_Compra.ObtenerDetalleCompra(oCompra.IdCompra);
                oCompra.oDetalleCompras = oDetalleCompra;

            }
            return oCompra;
        }

    }
}
