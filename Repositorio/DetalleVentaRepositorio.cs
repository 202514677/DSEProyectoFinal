using System;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class DetalleVentaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool Insertar(
            DetalleVenta detalle)
        {
            string query =
            @"INSERT INTO DetalleVenta
            (
                IdVenta,
                Asiento,
                Precio
            )
            VALUES
            (
                @IdVenta,
                @Asiento,
                @Precio
            )";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdVenta",
                        detalle.idVenta);

                    comando.Parameters.AddWithValue(
                        "@Asiento",
                        detalle.asiento);

                    comando.Parameters.AddWithValue(
                        "@Precio",
                        detalle.precio);

                    try
                    {
                        conexion.Open();

                        return comando.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
    }
}