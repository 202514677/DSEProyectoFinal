using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DSEProyectoFinal.Clases
{

    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=BD_CINEPELIS;Integrated Security=True");
        }
    }

}