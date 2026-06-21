using System;
using System.Data;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class ReservaTemporalRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool InsertarReserva(
            ReservaTemporal reserva)
        {
            string query =
            @"INSERT INTO ReservaTemporal
            (
                IdHorario,
                Asiento,
                FechaReserva,
                FechaExpiracion,
                Activo
            )
            VALUES
            (
                @IdHorario,
                @Asiento,
                GETDATE(),
                DATEADD(MINUTE,3,GETDATE()),
                1
            )";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        reserva.idHorario);

                    comando.Parameters.AddWithValue(
                        "@Asiento",
                        reserva.asiento);

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

        public bool EliminarReserva(
            int idHorario,
            string asiento)
        {
            string query =
            @"DELETE FROM ReservaTemporal
              WHERE
                    IdHorario=@IdHorario
                AND Asiento=@Asiento";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        idHorario);

                    comando.Parameters.AddWithValue(
                        "@Asiento",
                        asiento);

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

        public bool EliminarReservasHorario(
            int idHorario)
        {
            string query =
            @"DELETE FROM ReservaTemporal
              WHERE IdHorario=@IdHorario";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        idHorario);

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

        public DataTable ObtenerReservados(
            int idHorario)
        {
            string query =
            @"SELECT
                Asiento
              FROM ReservaTemporal
              WHERE
                    IdHorario=@IdHorario
                AND Activo=1
                AND FechaExpiracion > GETDATE()";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        idHorario);

                    try
                    {
                        conexion.Open();

                        DataTable dt =
                        new DataTable();

                        dt.Load(
                            comando.ExecuteReader());

                        return dt;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public bool ExisteReserva(
            int idHorario,
            string asiento)
        {
            string query =
            @"SELECT COUNT(*)
              FROM ReservaTemporal
              WHERE
                    IdHorario=@IdHorario
                AND Asiento=@Asiento
                AND FechaExpiracion > GETDATE()
                AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        idHorario);

                    comando.Parameters.AddWithValue(
                        "@Asiento",
                        asiento);

                    conexion.Open();

                    int cantidad =
                    Convert.ToInt32(
                    comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        public bool EliminarExpirados()
        {
            string query =
            @"DELETE FROM ReservaTemporal
              WHERE FechaExpiracion < GETDATE()";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open();

                        return comando.ExecuteNonQuery() >= 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public DataTable ListarReservas()
        {
            string query =
            @"SELECT *
              FROM ReservaTemporal";

            return EjecutarComandoSelect(query);
        }

        private DataTable EjecutarComandoSelect(
            string query)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open();

                        DataTable dt =
                        new DataTable();

                        dt.Load(
                            comando.ExecuteReader());

                        return dt;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}