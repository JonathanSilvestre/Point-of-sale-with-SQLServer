using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objCD_Cliente = new CapaDatos.CD_Cliente();

        public List<Cliente> Listar()
        {
            return objCD_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Cliente\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Cliente\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Cliente.Registrar(obj, out mensaje);
            }

        }

        public bool Editar(Cliente obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Cliente\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Cliente\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Cliente.Editar(obj, out mensaje);
            }

        }

        public bool Eliminar(Cliente obj, out string mensaje)
        {

            mensaje = string.Empty;

            if (obj.NombreCompleto == "")
            {
                mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (obj.Documento == "")
            {
                mensaje += "Es necesario el numero del Cliente\n";
            }

            if (obj.Correo == "")
            {
                mensaje += "Es necesario el correo del Cliente\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Cliente.Eliminar(obj, out mensaje);
            }


        }
    }
}
