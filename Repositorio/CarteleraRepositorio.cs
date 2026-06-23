using DSEProyectoFinal.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace DSEProyectoFinal.Repositorio
{
    public class CarteleraRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public DataTable ListarCarteleraPublica()
        {
            string query =
            @"SELECT

    C.IdCartelera,

    C.IdCine,

    P.IdPelicula,

    P.Titulo,

    P.Sinopsis,

    P.Duracion,

    P.Clasificacion,

    P.Genero,

    P.Imagen,

    C.FechaInicio,

    C.FechaFinalizacion,

    C.HoraProyeccion

    FROM Cartelera C

    INNER JOIN Peliculas P
        ON C.IdPelicula = P.IdPelicula

    WHERE
        C.Activo = 1
        AND GETDATE()
        BETWEEN
        C.FechaInicio
        AND
        C.FechaFinalizacion

    ORDER BY P.Titulo";

            return EjecutarSelect(
                query);
        }

        public DataTable ObtenerPeliculaCartelera(
    int idPelicula)
        {
            string query =
            @"SELECT

        IdCine,

        IdPelicula,

        Titulo,

        Sinopsis,

        Duracion,

        Clasificacion,

        Imagen

    FROM Peliculas

    WHERE
        IdPelicula=@IdPelicula";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdPelicula",
                        idPelicula);

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


        public bool Insertar(Cartelera paramCartelera)
        {
            string query =
            @"INSERT INTO Cartelera
    (
        IdCine,
        IdPelicula,
        FechaInicio,
        FechaFinalizacion,
        FechaRegistro,
        FechaActualizacion,
        HoraProyeccion,
        Activo
    )
    VALUES
    (
        @IdCine,
        @IdPelicula,
        @FechaInicio,
        @FechaFinalizacion,
        GETDATE(),
        GETDATE(),
        @HoraProyeccion,
        @Activo
    )";

            return EjecutarInsert(
                query,
                paramCartelera);
        }

        public bool Actualizar(Cartelera paramCartelera)
        {
            string query =
            @"UPDATE Cartelera
            SET
                IdCine=@IdCine,
                IdPelicula=@IdPelicula,
                FechaInicio=@FechaInicio,
                FechaFinalizacion=@FechaFinalizacion,
                HoraProyeccion=@HoraProyeccion,
                Activo=@Activo,
                FechaActualizacion=GETDATE()
            WHERE IdCartelera=@IdCartelera";

            return EjecutarUpdate(
                query,
                paramCartelera);
        }

        public bool Eliminar(Cartelera paramCartelera)
        {
            string query =
            @"UPDATE Cartelera
              SET Activo = 0,
                  FechaActualizacion = GETDATE()
              WHERE IdCartelera=@IdCartelera";

            return EjecutarDelete(
                query,
                paramCartelera);
        }

        public DataTable Listar()
        {
            string query =
                @"SELECT

                    C.IdCartelera,

                    C.IdCine,

                    CI.Nombre AS Cine,

                    C.IdPelicula,

                    P.Titulo,

                    P.Genero,

                    P.Clasificacion,

                    P.Imagen,

                    C.FechaInicio,

                    C.FechaFinalizacion,

                    C.Activo,

                    C.FechaRegistro,

                    C.FechaActualizacion,

                    C.HoraProyeccion

                FROM Cartelera C

                INNER JOIN Peliculas P
                    ON C.IdPelicula=P.IdPelicula

                INNER JOIN Cines CI
                    ON C.IdCine=CI.IdCine";

            return EjecutarSelect(query);
        }

        public DataTable Buscar(string texto)
        {
            string query =
            @"SELECT

                C.IdCartelera,

                C.IdCine,

                CI.Nombre AS Cine,

                C.IdPelicula,

                P.Titulo,

                P.Genero,

                P.Clasificacion,

                P.Imagen,

                C.FechaInicio,

                C.FechaFinalizacion,

                C.HoraProyeccion,

                C.Activo

            FROM Cartelera C

            INNER JOIN Peliculas P
                ON C.IdPelicula=P.IdPelicula

            INNER JOIN Cines CI
                ON C.IdCine=CI.IdCine

            WHERE

                  P.Titulo LIKE @texto

               OR P.Genero LIKE @texto

               OR P.Clasificacion LIKE @texto

               OR CI.Nombre LIKE @texto

               OR CI.Ciudad LIKE @texto";

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

        public bool ExisteCarteleraActiva(
        int idCine,
        int idPelicula,
        DateTime fechaInicio,
        DateTime fechaFinalizacion)
        {
            string query =
            @"SELECT COUNT(*)
            FROM Cartelera
            WHERE
                  IdCine=@IdCine
              AND IdPelicula=@IdPelicula
              AND Activo=1
              AND
              (
                    @FechaInicio BETWEEN FechaInicio AND FechaFinalizacion
                 OR @FechaFinalizacion BETWEEN FechaInicio AND FechaFinalizacion
                 OR FechaInicio BETWEEN @FechaInicio AND @FechaFinalizacion
              )";

            using (SqlConnection conexion =
                        new SqlConnection(connectionString))
                    {
                        using (SqlCommand comando =
                            new SqlCommand(query, conexion))
                        {

                            comando.Parameters.AddWithValue(
                                "@IdCine",
                                idCine);

                            comando.Parameters.AddWithValue(
                                 "@IdPelicula",
                                  idPelicula);

                            comando.Parameters.AddWithValue(
                                "@FechaInicio",
                                fechaInicio);

                            comando.Parameters.AddWithValue(
                                "@FechaFinalizacion",
                                fechaFinalizacion);

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

        public bool ExisteCarteleraActivaEdicion(
        int idCartelera,
        int idCine,
        int idPelicula,
        DateTime fechaInicio,
        DateTime fechaFinalizacion)
        {
            string query =
            @"SELECT COUNT(*)
            FROM Cartelera
            WHERE
                  IdCartelera<>@IdCartelera
              AND IdCine=@IdCine
              AND IdPelicula=@IdPelicula
              AND Activo=1
              AND
              (
                    @FechaInicio BETWEEN FechaInicio AND FechaFinalizacion
                 OR @FechaFinalizacion BETWEEN FechaInicio AND FechaFinalizacion
                 OR FechaInicio BETWEEN @FechaInicio AND @FechaFinalizacion
              )";

            using (SqlConnection conexion =
                        new SqlConnection(connectionString))
                    {
                        using (SqlCommand comando =
                            new SqlCommand(query, conexion))
                        {
                            comando.Parameters.AddWithValue(
                                "@IdCartelera",
                                idCartelera);

                            comando.Parameters.AddWithValue(
                                "@IdCine",
                                idCine);

                            comando.Parameters.AddWithValue(
                                "@IdPelicula",
                                idPelicula);

                            comando.Parameters.AddWithValue(
                                "@FechaInicio",
                                fechaInicio);

                            comando.Parameters.AddWithValue(
                                "@FechaFinalizacion",
                                fechaFinalizacion);

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

        private bool EjecutarInsert(
        string query,
        Cartelera c)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                    "@IdCine",
                    c.idCine);

                    comando.Parameters.AddWithValue(
                    "@IdPelicula",
                    c.idPelicula);

                    comando.Parameters.AddWithValue(
                    "@FechaInicio",
                    c.fechaInicio);

                    comando.Parameters.AddWithValue(
                    "@FechaFinalizacion",
                    c.fechaFinalizacion);

                    comando.Parameters.AddWithValue(
                    "@HoraProyeccion",
                    c.horaProyeccion);

                    comando.Parameters.AddWithValue(
                    "@Activo",
                    c.activo);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private bool EjecutarUpdate(
        string query,
        Cartelera c)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                    "@IdCartelera",
                    c.idCartelera);

                    comando.Parameters.AddWithValue(
                    "@IdCine",
                    c.idCine);

                    comando.Parameters.AddWithValue(
                    "@IdPelicula",
                    c.idPelicula);

                    comando.Parameters.AddWithValue(
                    "@FechaInicio",
                    c.fechaInicio);

                    comando.Parameters.AddWithValue(
                    "@FechaFinalizacion",
                    c.fechaFinalizacion);

                    comando.Parameters.AddWithValue(
                    "@HoraProyeccion",
                    c.horaProyeccion);

                    comando.Parameters.AddWithValue(
                    "@Activo",
                    c.activo);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private bool EjecutarDelete(
        string query,
        Cartelera c)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                    "@IdCartelera",
                    c.idCartelera);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private DataTable EjecutarSelect(string query)
        {
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

        public DataTable FiltrarCartelera(
    string ciudad,
    int idCine,
    string clasificacion,
    string genero)
        {
            string query =
            @"SELECT DISTINCT

        C.IdCartelera,

        C.IdCine,

        P.IdPelicula,

        P.Titulo,

        P.Sinopsis,

        P.Duracion,

        P.Clasificacion,

        P.Genero,

        P.Imagen

    FROM Cartelera C

    INNER JOIN Peliculas P
        ON C.IdPelicula=P.IdPelicula

    INNER JOIN Cines CI
    ON C.IdCine=CI.IdCine

    WHERE
        C.Activo=1";

            if (!string.IsNullOrEmpty(ciudad))
            {
                query +=
                " AND CI.Ciudad='" +
                ciudad + "'";
            }

            if (idCine > 0)
            {
                query +=
                " AND CI.IdCine=" +
                idCine;
            }

            if (!string.IsNullOrEmpty(
                clasificacion))
            {
                query +=
                " AND P.Clasificacion='" +
                clasificacion + "'";
            }

            if (!string.IsNullOrEmpty(
                genero))
            {
                query +=
                " AND P.Genero='" +
                genero + "'";
            }

            query +=
            " ORDER BY P.Titulo";

            return EjecutarSelect(
            query);
        }

        public DataTable FiltrarCarteleraFecha(
 string ciudad,
 int idCine,
 string clasificacion,
 string genero,
 string periodo)
        {
            string query =
            @"SELECT DISTINCT

        C.IdCartelera,

        C.IdCine,

        P.IdPelicula,

        P.Titulo,

        P.Sinopsis,

        P.Duracion,

        P.Clasificacion,

        P.Genero,

        P.Imagen,

        C.FechaInicio,

        C.FechaFinalizacion,

        C.HoraProyeccion

    FROM Cartelera C

    INNER JOIN Peliculas P
        ON C.IdPelicula=P.IdPelicula

    INNER JOIN Cines CI
        ON C.IdCine=CI.IdCine

    WHERE
        C.Activo=1";

            if (!string.IsNullOrWhiteSpace(ciudad)
                && ciudad != "Todas")
            {
                query +=
                " AND CI.Ciudad='" +
                ciudad + "'";
            }

            if (idCine > 0)
            {
                query +=
                " AND C.IdCine=" +
                idCine;
            }

            if (!string.IsNullOrWhiteSpace(clasificacion)
                && clasificacion != "Todas")
            {
                query +=
                " AND P.Clasificacion='" +
                clasificacion + "'";
            }

            if (!string.IsNullOrWhiteSpace(genero)
                && genero != "Todos")
            {
                query +=
                " AND P.Genero='" +
                genero + "'";
            }

            switch (periodo)
            {
                case "HOY":

                    query +=
                    @" AND
            CAST(C.FechaInicio AS DATE)
            =
            CAST(GETDATE() AS DATE)";
                    break;

                case "MANANA":

                    query +=
                    @" AND
            CAST(C.FechaInicio AS DATE)
            =
            DATEADD(
                DAY,
                1,
                CAST(GETDATE() AS DATE)
            )";
                    break;

                case "ESTASEMANA":

                    query +=
                    @" AND
            CAST(C.FechaInicio AS DATE)
            BETWEEN
            CAST(GETDATE() AS DATE)

            AND

            DATEADD(
                DAY,
                7,
                CAST(GETDATE() AS DATE)
            )";
                    break;

                case "PROXIMAMENTE":

                    query +=
                    @" AND
            CAST(C.FechaInicio AS DATE)
            >
            DATEADD(
                DAY,
                7,
                CAST(GETDATE() AS DATE)
            )";
                    break;
            }

            query +=
            " ORDER BY P.Titulo";

            return EjecutarSelect(query);
        }

    }
}
