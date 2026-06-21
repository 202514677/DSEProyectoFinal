using DSEProyectoFinal.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace DSEProyectoFinal.Repositorio
{
    internal class PeliculaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool Insertar(Pelicula paramPelicula)
        {
            string query =
            @"INSERT INTO Peliculas
            (
                Titulo,
                Genero,
                Duracion,
                Clasificacion,
                Sinopsis,
                Estreno,
                Idioma,
                Imagen,
                FechaIngreso,
                FechaSalida,
                Activo,
                FechaRegistro
            )
            VALUES
            (
                @titulo,
                @genero,
                @duracion,
                @clasificacion,
                @sinopsis,
                @estreno,
                @idioma,
                @imagen,
                @fechaIngreso,
                @fechaSalida,
                @activo,
                GETDATE()
            )";

            return EjecutarComandoInsert(
                query,
                paramPelicula);
        }

        public bool Actualizar(Pelicula paramPelicula)
        {
            string query =
            @"UPDATE Peliculas
              SET Titulo = @titulo,
                  Genero = @genero,
                  Duracion = @duracion,
                  Clasificacion = @clasificacion,
                  Sinopsis = @sinopsis,
                  Estreno = @estreno,
                  Idioma = @idioma,
                  Imagen = @imagen,
                  FechaIngreso = @fechaIngreso,
                  FechaSalida = @fechaSalida,
                  Activo = @activo,
                  FechaActualizacion = GETDATE()
              WHERE IdPelicula = @idPelicula";

            return EjecutarComandoUpdate(
                query,
                paramPelicula);
        }

        public bool Eliminar(Pelicula paramPelicula)
        {
            string query =
            @"UPDATE Peliculas
              SET Activo = 0,
                  FechaActualizacion = GETDATE()
              WHERE IdPelicula = @idPelicula";

            return EjecutarComandoDelete(
                query,
                paramPelicula);
        }

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdPelicula,
                Titulo,
                Genero,
                Duracion,
                Clasificacion,
                Sinopsis,
                Estreno,
                Idioma,
                Imagen,
                FechaIngreso,
                FechaSalida,
                Activo,
                FechaRegistro,
                FechaActualizacion
              FROM Peliculas";

            return EjecutarComandoSelect(query);
        }

        public DataTable Buscar(string texto)
        {
            string query =
            @"SELECT
                IdPelicula,
                Titulo,
                Genero,
                Duracion,
                Clasificacion,
                Sinopsis,
                Estreno,
                Idioma,
                Imagen,
                FechaIngreso,
                FechaSalida,
                Activo,
                FechaRegistro,
                FechaActualizacion
              FROM Peliculas
              WHERE
                    Titulo LIKE @texto
                 OR Genero LIKE @texto
                 OR Clasificacion LIKE @texto
                 OR Sinopsis LIKE @texto
                 OR Idioma LIKE @texto";

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

        public bool ExisteTitulo(string titulo)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Peliculas
              WHERE Titulo = @titulo";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@titulo",
                        titulo);

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

        public bool ExisteTituloEdicion(
            string titulo,
            int idPelicula)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Peliculas
              WHERE Titulo = @titulo
              AND IdPelicula <> @idPelicula";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@titulo",
                        titulo);

                    comando.Parameters.AddWithValue(
                        "@idPelicula",
                        idPelicula);

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

        private bool EjecutarComandoInsert(
            string query,
            Pelicula paramPelicula)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@titulo",
                        paramPelicula.titulo);

                    comando.Parameters.AddWithValue("@genero",
                        paramPelicula.genero);

                    comando.Parameters.AddWithValue("@duracion",
                        paramPelicula.duracion);

                    comando.Parameters.AddWithValue("@clasificacion",
                        paramPelicula.clasificacion);

                    comando.Parameters.AddWithValue("@sinopsis",
                        paramPelicula.sinopsis);

                    comando.Parameters.AddWithValue("@estreno",
                        paramPelicula.estreno);

                    comando.Parameters.AddWithValue("@idioma",
                        paramPelicula.idioma);

                    comando.Parameters.AddWithValue("@imagen",
                        paramPelicula.imagen);

                    comando.Parameters.AddWithValue("@fechaIngreso",
                        paramPelicula.fechaIngreso);

                    comando.Parameters.AddWithValue("@fechaSalida",
                        paramPelicula.fechaSalida);

                    comando.Parameters.AddWithValue("@activo",
                        paramPelicula.activo);

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
            Pelicula paramPelicula)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@idPelicula",
                        paramPelicula.idPelicula);

                    comando.Parameters.AddWithValue("@titulo",
                        paramPelicula.titulo);

                    comando.Parameters.AddWithValue("@genero",
                        paramPelicula.genero);

                    comando.Parameters.AddWithValue("@duracion",
                        paramPelicula.duracion);

                    comando.Parameters.AddWithValue("@clasificacion",
                        paramPelicula.clasificacion);

                    comando.Parameters.AddWithValue("@sinopsis",
                        paramPelicula.sinopsis);

                    comando.Parameters.AddWithValue("@estreno",
                        paramPelicula.estreno);

                    comando.Parameters.AddWithValue("@idioma",
                        paramPelicula.idioma);

                    comando.Parameters.AddWithValue("@imagen",
                        paramPelicula.imagen);

                    comando.Parameters.AddWithValue("@fechaIngreso",
                        paramPelicula.fechaIngreso);

                    comando.Parameters.AddWithValue("@fechaSalida",
                        paramPelicula.fechaSalida);

                    comando.Parameters.AddWithValue("@activo",
                        paramPelicula.activo);

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
            Pelicula paramPelicula)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idPelicula",
                        paramPelicula.idPelicula);

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

        public DataTable ListarGeneros()
        {
            string query =
            @"SELECT DISTINCT
        Genero
      FROM Peliculas
      WHERE Activo = 1
      ORDER BY Genero";

            return EjecutarComandoSelect(
                query);
        }

        public DataTable ListarClasificaciones()
        {
            string query =
            @"SELECT DISTINCT
        Clasificacion
      FROM Peliculas
      WHERE Activo = 1
      ORDER BY Clasificacion";

            return EjecutarComandoSelect(
                query);
        }


        public DataTable ListarReporte()
        {
            string query =
            @"SELECT *
      FROM vw_ReportePeliculas
      ORDER BY Titulo";

            return EjecutarComandoSelect(
            query);
        }

        public DataTable ListarReporte(
 string filtro)
        {
            string query =
            @"SELECT *
      FROM vw_ReportePeliculas";

            if (filtro == "ESTRENOS")
            {
                query +=
                " WHERE Estreno=1";
            }
            else if (filtro == "MÁS VISTAS")
            {
                query +=
                " ORDER BY CantidadVistas DESC";
            }
            else if (filtro != "TODAS")
            {
                query +=
                " WHERE Genero=@genero ORDER BY Titulo";
            }

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    if (filtro != "TODAS"
                        &&
                        filtro != "ESTRENOS"
                        &&
                        filtro != "MÁS VISTAS")
                    {
                        comando.Parameters.AddWithValue(
                        "@genero",
                        filtro);
                    }

                    conexion.Open();

                    SqlDataReader reader =
                    comando.ExecuteReader();

                    DataTable dt =
                    new DataTable();

                    dt.Load(reader);

                    return dt;
                }
            }
        }

    }
}