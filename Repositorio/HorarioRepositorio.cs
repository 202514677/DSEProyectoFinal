using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class HorarioRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public DataTable ListarVentaEntradas()
        {
            string query =
            @"SELECT

        H.IdHorario,

        P.Titulo +
        ' - Sala ' +
        CAST(H.NumSala AS VARCHAR)
        AS Descripcion

      FROM Horarios H

      INNER JOIN Cartelera C
      ON H.IdCartelera=C.IdCartelera

      INNER JOIN Peliculas P
      ON C.IdPelicula=P.IdPelicula

      WHERE H.Activo=1";

            return EjecutarComandoSelect(
                query);
        }

        public DataTable ObtenerHorarioVenta(int idHorario)
        {
            string query =
            @"SELECT

        P.Titulo,

        CI.Nombre AS Cine,

        H.NumSala,

        H.TipoSala,

        H.FechaInicio,

        H.PrecioVentaPublico,

        H.CantidadVentaPublico,

        H.EntradasVendidas

      FROM Horarios H

      INNER JOIN Cines CI
      ON H.IdCine=CI.IdCine

      INNER JOIN Cartelera C
      ON H.IdCartelera=C.IdCartelera

      INNER JOIN Peliculas P
      ON C.IdPelicula=P.IdPelicula

      WHERE H.IdHorario=@idHorario";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idHorario",
                        idHorario);

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
        }

        public bool Insertar(Horario paramHorario)
        {
            string query =
            @"INSERT INTO Horarios
            (
                IdCine,
                IdCartelera,
                NumSala,
                TipoSala,
                FechaInicio,
                FechaFinalizacion,
                PrecioVentaPublico,
                TotalAsientos,
                CantidadVentaPublico,
                CantidadCorporativo,
                CantidadMarketing,
                EntradasVendidas,
                Activo
            )
            VALUES
            (
                @IdCine,
                @IdCartelera,
                @NumSala,
                @TipoSala,
                @FechaInicio,
                @FechaFinalizacion,
                @PrecioVentaPublico,
                @TotalAsientos,
                @CantidadVentaPublico,
                @CantidadCorporativo,
                @CantidadMarketing,
                @EntradasVendidas,
                @Activo
            )";

            return EjecutarComandoInsert(query, paramHorario);
        }

        public bool Actualizar(Horario paramHorario)
        {
            string query =
            @"UPDATE Horarios
              SET
                  IdCine = @IdCine,
                  IdCartelera = @IdCartelera,
                  NumSala = @NumSala,
                  TipoSala = @TipoSala,
                  FechaInicio = @FechaInicio,
                  FechaFinalizacion = @FechaFinalizacion,
                  PrecioVentaPublico = @PrecioVentaPublico,
                  TotalAsientos = @TotalAsientos,
                  CantidadVentaPublico = @CantidadVentaPublico,
                  CantidadCorporativo = @CantidadCorporativo,
                  CantidadMarketing = @CantidadMarketing,
                  EntradasVendidas = @EntradasVendidas,
                  Activo = @Activo
              WHERE IdHorario = @IdHorario";

            return EjecutarComandoUpdate(query, paramHorario);
        }

        public bool Eliminar(Horario paramHorario)
        {
            string query =
            @"UPDATE Horarios
              SET Activo = 0
              WHERE IdHorario = @IdHorario";

            return EjecutarComandoDelete(query, paramHorario);
        }

        public DataTable Listar()
        {
            string query =
            @"SELECT
                H.IdHorario,
                H.IdCine,
                H.IdCartelera,

                C.Nombre AS Cine,

                P.Titulo AS Pelicula,

                H.NumSala,
                H.TipoSala,

                H.FechaInicio,
                H.FechaFinalizacion,

                H.PrecioVentaPublico,

                H.TotalAsientos,

                H.CantidadVentaPublico,

                H.CantidadCorporativo,

                H.CantidadMarketing,

                H.EntradasVendidas,

                H.Activo

              FROM Horarios H

              INNER JOIN Cines C
              ON H.IdCine = C.IdCine

              INNER JOIN Cartelera CA
              ON H.IdCartelera = CA.IdCartelera

              INNER JOIN Peliculas P
              ON CA.IdPelicula = P.IdPelicula

              WHERE H.Activo = 1";

            return EjecutarComandoSelect(query);
        }

        public DataTable Buscar(string texto)
        {
            string query =
            @"SELECT
                H.IdHorario,
                H.IdCine,
                H.IdCartelera,

                C.Nombre AS Cine,

                P.Titulo AS Pelicula,

                H.NumSala,
                H.TipoSala,

                H.FechaInicio,
                H.FechaFinalizacion,

                H.PrecioVentaPublico,

                H.TotalAsientos,

                H.CantidadVentaPublico,

                H.CantidadCorporativo,

                H.CantidadMarketing,

                H.EntradasVendidas,

                H.Activo

              FROM Horarios H

              INNER JOIN Cines C
              ON H.IdCine = C.IdCine

              INNER JOIN Cartelera CA
              ON H.IdCartelera = CA.IdCartelera

              INNER JOIN Peliculas P
              ON CA.IdPelicula = P.IdPelicula

              WHERE
                    P.Titulo LIKE @texto
                 OR C.Nombre LIKE @texto
                 OR H.TipoSala LIKE @texto";

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

        public bool ExisteSalaOcupada(
            int idCine,
            int numSala,
            string tipoSala)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Horarios
              WHERE IdCine = @IdCine
              AND NumSala = @NumSala
              AND TipoSala = @TipoSala
              AND Activo = 1";

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
                        "@NumSala",
                        numSala);

                    comando.Parameters.AddWithValue(
                        "@TipoSala",
                        tipoSala);

                    conexion.Open();

                    int cantidad =
                    Convert.ToInt32(
                    comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        private bool EjecutarComandoInsert(
            string query,
            Horario h)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    AgregarParametros(comando, h);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private bool EjecutarComandoUpdate(
            string query,
            Horario h)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        h.idHorario);

                    AgregarParametros(comando, h);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private bool EjecutarComandoDelete(
            string query,
            Horario h)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        h.idHorario);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        private void AgregarParametros(
            SqlCommand comando,
            Horario h)
        {
            comando.Parameters.AddWithValue(
                "@IdCine",
                h.idCine);

            comando.Parameters.AddWithValue(
                "@IdCartelera",
                h.idCartelera);

            comando.Parameters.AddWithValue(
                "@NumSala",
                h.numSala);

            comando.Parameters.AddWithValue(
                "@TipoSala",
                h.tipoSala);

            comando.Parameters.AddWithValue(
                "@FechaInicio",
                h.fechaInicio);

            comando.Parameters.AddWithValue(
                "@FechaFinalizacion",
                h.fechaFinalizacion);

            comando.Parameters.AddWithValue(
                "@PrecioVentaPublico",
                h.precioVentaPublico);

            comando.Parameters.AddWithValue(
                "@TotalAsientos",
                h.totalAsientos);

            comando.Parameters.AddWithValue(
                "@CantidadVentaPublico",
                h.cantidadventaPublico);

            comando.Parameters.AddWithValue(
                "@CantidadCorporativo",
                h.cantidadcorporativo);

            comando.Parameters.AddWithValue(
                "@CantidadMarketing",
                h.cantidadmarketing);

            comando.Parameters.AddWithValue(
                "@EntradasVendidas",
                h.entradasVendidas);

            comando.Parameters.AddWithValue(
                "@Activo",
                h.activo);
        }

        private DataTable EjecutarComandoSelect(string query)
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

        public DataTable ObtenerDisponibilidad( int idHorario)
        {
            string query =
            @"SELECT
        CantidadVentaPublico,
        EntradasVendidas
      FROM Horarios
      WHERE IdHorario=@idHorario";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idHorario",
                        idHorario);

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
        }

        public DataTable ListarVentaEntradasPorPelicula(
    int idPelicula)
        {
            string query =
            @"SELECT

        H.IdHorario,

        P.Titulo +
        ' - Sala ' +
        CAST(H.NumSala AS VARCHAR)
        AS Descripcion

    FROM Horarios H

    INNER JOIN Cartelera C
        ON H.IdCartelera = C.IdCartelera

    INNER JOIN Peliculas P
        ON C.IdPelicula = P.IdPelicula

    WHERE
        H.Activo = 1
        AND P.IdPelicula = @IdPelicula";

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

        public DataTable ListarReporteOcupacionSala(
 DateTime fechaInicio,
 DateTime fechaFin,
 int idCine,
 int idPelicula)
        {
            string query =
            @"SELECT *

    FROM vw_ReporteOcupacionSala

    WHERE
    CAST(FechaInicio AS DATE)
    BETWEEN
    CAST(@fechaInicio AS DATE)
    AND
    CAST(@fechaFin AS DATE)";

            if (idCine > 0)
            {
                query +=
                " AND IdCine=" +
                idCine;
            }

            if (idPelicula > 0)
            {
                query +=
                " AND IdPelicula=" +
                idPelicula;
            }

            query +=
            @" ORDER BY
       Cine,
       Pelicula,
       NumSala";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                SqlCommand comando =
                new SqlCommand(query,
                conexion);

                comando.Parameters.AddWithValue(
                "@fechaInicio",
                fechaInicio);

                comando.Parameters.AddWithValue(
                "@fechaFin",
                fechaFin);

                try
                {
                    conexion.Open();

                    SqlDataReader reader =
                    comando.ExecuteReader();

                    DataTable dt =
                    new DataTable();

                    dt.Load(reader);

                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    ex.Message,
                    "Reporte Ocupación Sala");

                    return new DataTable();
                }
            }
        }

    }
}