using System.Data;
using System.Data.SqlClient;

namespace DSEProyectoFinal.Repositorio
{
    public class RolRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdRol,
                Nombre
            FROM Roles
            WHERE Activo=1
            ORDER BY Nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
        }
    }
}