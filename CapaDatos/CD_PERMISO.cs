using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {
                    StringBuilder query= new StringBuilder();
                    query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idusuario");
                    /*select p.IdRol,p.NombreMenu from PERMISO p
                    inner join ROL r on r.IdRol = p.IdRol
                    inner join USUARIO u on u.IdRol = r.IdRol
                    where u.IdUsuario = 2*/

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idusuario",idusuario);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"])},
                                NombreMenu = dr["NombreMenu"].ToString(),                            
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
