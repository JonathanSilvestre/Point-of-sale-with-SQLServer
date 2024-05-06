using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_PERMISO objCD_permiso = new CapaDatos.CD_PERMISO();

        public List<Permiso> Listar(int IdUsuario)
        {
            return objCD_permiso.Listar(IdUsuario);
        }
    }
}
