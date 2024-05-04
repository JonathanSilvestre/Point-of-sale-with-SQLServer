using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objCD_Usuario = new CapaDatos.CD_Usuario();

        public List<Usuario> Listar()
        {
            return objCD_Usuario.Listar();
        }
    }
}
