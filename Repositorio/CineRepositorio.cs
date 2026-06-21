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
                GoogleMaps,
                Imagen,
                CantidadSalas2D,
                CantidadSalas3D,
                CantidadSalas4K,
                CantidadSalasPrime,
                CantidadSalasEventos,
                IdUsuario,
                Activo
            )
            VALUES
            (
                @nombre,
                @ciudad,
                @direccion,
                @googleMaps,
                @imagen,
                @salas2D,
                @salas3D,
                @salas4K,
                @salasPrime,
                @salasEventos,
                @IdUsuario,
                @activo
            )";

            return EjecutarComandoInsert(
                query,
                paramCine);
        }

        public bool Actualizar(Cine paramCine)
        {
            string query =
            @"UPDATE Cines
                SET Nombre = @nombre,
                  Ciudad = @ciudad,
                  Direccion = @direccion,
                  GoogleMaps = @googleMaps,
                  Imagen = @imagen,
                  CantidadSalas2D = @salas2D,
                  CantidadSalas3D = @salas3D,
                  CantidadSalas4K = @salas4K,
                  CantidadSalasPrime = @salasPrime,
                  CantidadSalasEventos = @salasEventos,
                  IdUsuario = @IdUsuario,
                  Activo = @activo,
                  FechaActualizacion = GETDATE()
                WHERE IdCine = @idCine";

            return EjecutarComandoUpdate(
                query,
                paramCine);
        }

        public bool Eliminar(Cine paramCine)
        {
            string query =
            @"UPDATE Cines
              SET Activo = 0,
                  FechaActualizacion = GETDATE()
              WHERE IdCine = @idCine";

            return EjecutarComandoDelete(
                query,
                paramCine);
        }

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdCine,
                Nombre,
                Ciudad,
                Direccion,
                GoogleMaps,
                Imagen,
                CantidadSalas2D,
                CantidadSalas3D,
                CantidadSalas4K,
                CantidadSalasPrime,
                CantidadSalasEventos,
                IdUsuario,
                Activo
              FROM Cines";

            return EjecutarComandoSelect(query);
        }

        public DataTable Buscar(string texto)
        {
            string query =
            @"SELECT
                IdCine,
                Nombre,
                Ciudad,
                Direccion,
                GoogleMaps,
                Imagen,
                CantidadSalas2D,
                CantidadSalas3D,
                CantidadSalas4K,
                CantidadSalasPrime,
                CantidadSalasEventos,
                IdUsuario,
                Activo
              FROM Cines
              WHERE
                    Nombre LIKE @texto
                 OR Ciudad LIKE @texto
                 OR Direccion LIKE @texto";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@texto",
                        "%" + texto + "%");

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
                    "@googleMaps",
                    paramCine.googleMaps);

                    comando.Parameters.AddWithValue(
                    "@imagen",
                    paramCine.imagen);

                    comando.Parameters.AddWithValue(
                    "@salas2D",
                    paramCine.salas2D);

                    comando.Parameters.AddWithValue(
                    "@salas3D",
                    paramCine.salas3D);

                    comando.Parameters.AddWithValue(
                    "@salas4K",
                    paramCine.salas4K);

                    comando.Parameters.AddWithValue(
                    "@salasPrime",
                    paramCine.salasPrime);

                    comando.Parameters.AddWithValue(
                    "@salasEventos",
                    paramCine.salasEventos);

                    comando.Parameters.AddWithValue(
                    "@IdUsuario",
                    paramCine.IdUsuario);

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
                    "@googleMaps",
                    paramCine.googleMaps);

                    comando.Parameters.AddWithValue(
                    "@imagen",
                    paramCine.imagen);

                    comando.Parameters.AddWithValue(
                    "@salas2D",
                    paramCine.salas2D);

                    comando.Parameters.AddWithValue(
                    "@salas3D",
                    paramCine.salas3D);

                    comando.Parameters.AddWithValue(
                    "@salas4K",
                    paramCine.salas4K);

                    comando.Parameters.AddWithValue(
                    "@salasPrime",
                    paramCine.salasPrime);

                    comando.Parameters.AddWithValue(
                    "@salasEventos",
                    paramCine.salasEventos);

                    comando.Parameters.AddWithValue(
                    "@IdUsuario",
                    paramCine.IdUsuario);

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

        public bool ExisteNombre(string nombre)
        {
            string query =
                    @"SELECT COUNT(*)
              FROM Cines
              WHERE Nombre = @nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@nombre",
                        nombre);

                    try
                    {
                        conexion.Open();

                        int cantidad =
                        Convert.ToInt32(
                        comando.ExecuteScalar());

                        return cantidad > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public bool ExisteNombreEdicion(string nombre, int idCine)
        {
            string query =
            @"SELECT COUNT(*)
                  FROM Cines
                  WHERE Nombre = @nombre
                  AND IdCine <> @idCine";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@nombre",
                        nombre);

                    comando.Parameters.AddWithValue(
                        "@idCine",
                        idCine);

                    try
                    {
                        conexion.Open();

                        int cantidad =
                        Convert.ToInt32(
                        comando.ExecuteScalar());

                        return cantidad > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public bool ExisteGoogleMaps(string googleMaps)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Cines
              WHERE GoogleMaps = @googleMaps";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@googleMaps",
                        googleMaps);

                    try
                    {
                        conexion.Open();

                        int cantidad =
                        Convert.ToInt32(
                        comando.ExecuteScalar());

                        return cantidad > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public bool ExisteGoogleMapsEdicion(string googleMaps, int idCine)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Cines
              WHERE GoogleMaps = @googleMaps
              AND IdCine <> @idCine";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@googleMaps",
                        googleMaps);

                    comando.Parameters.AddWithValue(
                        "@idCine",
                        idCine);

                    try
                    {
                        conexion.Open();

                        int cantidad =
                        Convert.ToInt32(
                        comando.ExecuteScalar());

                        return cantidad > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public DataTable ListarCiudades()
        {
            string query =
            @"SELECT DISTINCT
        Ciudad
      FROM Cines
      WHERE Activo = 1
      ORDER BY Ciudad";

            return EjecutarComandoSelect(
                query);
        }

        public DataTable ListarCinesPorCiudad(string ciudad)
        {
            string query =
            @"SELECT

        IdCine,

        Nombre

      FROM Cines

      WHERE
            Activo = 1
        AND Ciudad = @Ciudad

      ORDER BY Nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Ciudad",
                        ciudad);

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