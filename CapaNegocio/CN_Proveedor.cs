using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objCD_Proveedor = new CapaDatos.CD_Proveedor();

        public List<Proveedor> Listar()
        {
            return objCD_Proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.RazonSocial == "")
            {
                mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Proveedor\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Proveedor.Registrar(obj, out mensaje);
            }

        }

        public bool Editar(Proveedor obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.RazonSocial == "")
            {
                mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Proveedor\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Proveedor.Editar(obj, out mensaje);
            }

        }

        public bool Eliminar(Proveedor obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.RazonSocial == "")
            {
                mensaje += "Es necesario la razon social del Proveedor\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Proveedor\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Proveedor.Eliminar(obj, out mensaje);
            }


        }
    }
}
