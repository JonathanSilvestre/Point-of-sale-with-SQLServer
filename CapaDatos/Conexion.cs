using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
