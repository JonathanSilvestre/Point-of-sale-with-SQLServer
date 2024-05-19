using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCD_Categoria = new CapaDatos.CD_Categoria();
        public List<Categoria> Listar()
        {
            return objCD_Categoria.Listar();
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Categoria.Registrar(obj, out mensaje);
            }

        }

        public bool Editar(Categoria obj, out string mensaje)
        {

            mensaje = string.Empty;

            
            if (obj.Descripcion == "")
            {
                mensaje += "Es necesario la descripcion de la Categoria\n";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Categoria.Editar(obj, out mensaje);
            }

        }

        public bool Eliminar(Categoria obj, out string mensaje)
        {
                return objCD_Categoria.Eliminar(obj, out mensaje);
         }


        
    }
}
