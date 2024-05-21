using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Producto
    {

        private CD_Producto objCD_Producto = new CapaDatos.CD_Producto();

        public List<Producto> Listar()
        {
            return objCD_Producto.Listar();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el codigo del Producto\n";
            }

            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre del Producto\n";
            }

            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion del Producto\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Producto.Registrar(obj, out mensaje);
            }

        }

        public bool Editar(Producto obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                mensaje += "Es necesario el codigo del Producto\n";
            }

            if (obj.Nombre == "")
            {
                mensaje += "Es necesario el nombre del Producto\n";
            }

            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion del Producto\n";
            }
            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Producto.Editar(obj, out mensaje);
            }

        }

        public bool Eliminar(Producto obj, out string mensaje)
        {
                return objCD_Producto.Eliminar(obj, out mensaje);
        }

     }
}
