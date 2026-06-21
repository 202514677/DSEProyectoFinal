using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class DetalleVentaDulceriaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool Insertar(
            DetalleVentaDulceria detalle)
        {
            string query =
            @"INSERT INTO DetalleVentaDulceria
            (
                IdVentaDulceria,
                IdProducto,
                Cantidad,
                Precio,
                SubTotal
            )
            VALUES
            (
                @IdVentaDulceria,
                @IdProducto,
                @Cantidad,
                @Precio,
                @SubTotal
            )";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdVentaDulceria",
                        detalle.idVentaDulceria);

                    comando.Parameters.AddWithValue(
                        "@IdProducto",
                        detalle.idProducto);

                    comando.Parameters.AddWithValue(
                        "@Cantidad",
                        detalle.cantidad);

                    comando.Parameters.AddWithValue(
                        "@Precio",
                        detalle.precio);

                    comando.Parameters.AddWithValue(
                        "@SubTotal",
                        detalle.subTotal);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}