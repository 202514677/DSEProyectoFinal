using System;
using System.Data;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    internal class CineRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool Insertar(Cine paramCine)
        {
            string query =
            @"INSERT INTO Cines
            (
                Nombre,
                Ciudad,
                Direccion,
                Activo
            )
            VALUES
            (
                @nombre,
                @ciudad,
                @direccion,
                @activo
            )";

            return EjecutarComandoInsert(query, paramCine);
        }

        public bool Actualizar(Cine paramCine)
        {
            string query =
            @"UPDATE Cines
              SET Nombre = @nombre,
                  Ciudad = @ciudad,
                  Direccion = @direccion,
                  Activo = @activo
              WHERE IdCine = @idCine";

            return EjecutarComandoUpdate(query, paramCine);
        }

        public bool Eliminar(Cine paramCine)
        {
            string query =
            @"DELETE FROM Cines
              WHERE IdCine = @idCine";

            return EjecutarComandoDelete(query, paramCine);
        }

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdCine,
                Nombre,
                Ciudad,
                Direccion,
                Activo
              FROM Cines";

            return EjecutarComandoSelect(query);
        }

        public DataTable Buscar(string nombre)
        {
            string query =
            @"SELECT
        IdCine,
        Nombre,
        Ciudad,
        Direccion,
        Activo
      FROM Cines
      WHERE Nombre LIKE @nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@nombre",
                        "%" + nombre + "%");

                    try
                    {
                        conexion.Open();

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            DataTable dt =
                                new DataTable();

                            dt.Load(reader);

                            return dt;
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        private bool EjecutarComandoInsert(
            string query,
            Cine paramCine)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@nombre",
                        paramCine.nombre);

                    comando.Parameters.AddWithValue(
                        "@ciudad",
                        paramCine.ciudad);

                    comando.Parameters.AddWithValue(
                        "@direccion",
                        paramCine.direccion);

                    comando.Parameters.AddWithValue(
                        "@activo",
                        paramCine.activo);

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

        private bool EjecutarComandoUpdate(
            string query,
            Cine paramCine)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idCine",
                        paramCine.idCine);

                    comando.Parameters.AddWithValue(
                        "@nombre",
                        paramCine.nombre);

                    comando.Parameters.AddWithValue(
                        "@ciudad",
                        paramCine.ciudad);

                    comando.Parameters.AddWithValue(
                        "@direccion",
                        paramCine.direccion);

                    comando.Parameters.AddWithValue(
                        "@activo",
                        paramCine.activo);

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

        private bool EjecutarComandoDelete(
            string query,
            Cine paramCine)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idCine",
                        paramCine.idCine);

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

                        using (SqlDataReader reader =
                            comando.ExecuteReader())
                        {
                            DataTable dt =
                                new DataTable();

                            dt.Load(reader);

                            return dt;
                        }
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