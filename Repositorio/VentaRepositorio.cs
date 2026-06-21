using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Repositorio
{
    public class VentaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public DataTable ListarVentas()
        {
            string query =
            @"SELECT
        V.IdVenta,
        V.CodigoTicket,
        C.Nombre + ' ' +
        C.Apellido AS Cliente,
        V.Total,
        V.FechaVenta
      FROM Ventas V
      INNER JOIN Clientes C
      ON V.IdCliente=C.IdCliente";

            return EjecutarComandoSelect( query);
        }

        public DataTable ObtenerAsientosOcupados(int idHorario)
        {
            string query =
            @"SELECT
        DV.Asiento
      FROM DetalleVenta DV
      INNER JOIN Ventas V
      ON DV.IdVenta = V.IdVenta
      WHERE V.IdHorario=@idHorario";

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

        public int Insertar(Venta venta)
        {
            string query =
            @"INSERT INTO Ventas
    (
        IdCliente,
        IdHorario,
        FechaVenta,
        CantidadEntradas,
        SubTotal,
        IGV,
        Total,
        MetodoPago,
        NumeroAutorizacion,
        Ultimos4Tarjeta,
        Estado,
        CodigoTicket,
        UsuarioRegistro
    )
    VALUES
    (
        @IdCliente,
        @IdHorario,
        GETDATE(),
        @CantidadEntradas,
        @SubTotal,
        @IGV,
        @Total,
        @MetodoPago,
        @NumeroAutorizacion,
        @Ultimos4Tarjeta,
        @Estado,
        @CodigoTicket,
        @UsuarioRegistro
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdCliente",
                        venta.idCliente);

                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        venta.idHorario);

                    comando.Parameters.AddWithValue(
                        "@CantidadEntradas",
                        venta.cantidadEntradas);

                    comando.Parameters.AddWithValue(
                        "@SubTotal",
                        venta.subTotal);

                    comando.Parameters.AddWithValue(
                        "@IGV",
                        venta.igv);

                    comando.Parameters.AddWithValue(
                        "@Total",
                        venta.total);

                    comando.Parameters.AddWithValue(
                        "@MetodoPago",
                        venta.metodoPago);

                    comando.Parameters.AddWithValue(
                        "@NumeroAutorizacion",
                        string.IsNullOrEmpty(
                        venta.numeroAutorizacion)
                        ? (object)DBNull.Value
                        : venta.numeroAutorizacion);

                    comando.Parameters.AddWithValue(
                        "@Ultimos4Tarjeta",
                        string.IsNullOrEmpty(
                        venta.ultimos4Tarjeta)
                        ? (object)DBNull.Value
                        : venta.ultimos4Tarjeta);

                    comando.Parameters.AddWithValue(
                        "@Estado",
                        venta.estado);

                    comando.Parameters.AddWithValue(
                        "@CodigoTicket",
                        venta.codigoTicket);

                    comando.Parameters.AddWithValue(
                        "@UsuarioRegistro",
                        venta.usuarioRegistro);

                    try
                    {
                        conexion.Open();

                        return Convert.ToInt32(
                            comando.ExecuteScalar());
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
        }

        public bool ActualizarEntradasVendidas(
            int idHorario,
            int cantidadEntradas)
        {
            string query =
            @"UPDATE Horarios
              SET EntradasVendidas =
              EntradasVendidas + @Cantidad
              WHERE IdHorario=@IdHorario";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidadEntradas);

                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        idHorario);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ExisteAsientoOcupado(
            int idHorario,
            string asiento)
        {
            string query =
            @"SELECT COUNT(*)
              FROM DetalleVenta DV
              INNER JOIN Ventas V
                    ON DV.IdVenta = V.IdVenta
              WHERE
                    V.IdHorario = @IdHorario
                AND DV.Asiento = @Asiento";

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

        private bool EjecutarInsert( string query, Venta venta)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdCliente",
                        venta.idCliente);

                    comando.Parameters.AddWithValue(
                        "@IdHorario",
                        venta.idHorario);

                    comando.Parameters.AddWithValue(
                        "@CantidadEntradas",
                        venta.cantidadEntradas);

                    comando.Parameters.AddWithValue(
                        "@SubTotal",
                        venta.subTotal);

                    comando.Parameters.AddWithValue(
                        "@IGV",
                        venta.igv);

                    comando.Parameters.AddWithValue(
                        "@Total",
                        venta.total);

                    comando.Parameters.AddWithValue(
                        "@MetodoPago",
                        venta.metodoPago);

                    comando.Parameters.AddWithValue(
                         "@NumeroAutorizacion",
                         string.IsNullOrEmpty(
                         venta.numeroAutorizacion)
                         ? (object)DBNull.Value
                         : venta.numeroAutorizacion);

                    comando.Parameters.AddWithValue(
                        "@Ultimos4Tarjeta",
                        string.IsNullOrEmpty(
                        venta.ultimos4Tarjeta)
                        ? (object)DBNull.Value
                        : venta.ultimos4Tarjeta);

                    comando.Parameters.AddWithValue(
                        "@Estado",
                        venta.estado);

                    comando.Parameters.AddWithValue(
                        "@CodigoTicket",
                        venta.codigoTicket);

                    comando.Parameters.AddWithValue(
                        "@UsuarioRegistro",
                        venta.usuarioRegistro);

                    try
                    {
                        conexion.Open();

                        return comando.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.ToString());

                        return false;
                    }
                }
            }
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

        public DataTable ListarReporteVentas(
DateTime fechaInicio,
DateTime fechaFin,
int idPelicula)
        {
            string query =
            @"SELECT *

      FROM vw_ReporteVentas

      WHERE
      CAST(FechaVenta AS DATE)
      BETWEEN
      CAST(@fechaInicio AS DATE)
      AND
      CAST(@fechaFin AS DATE)";

            if (idPelicula > 0)
            {
                query +=
                " AND IdPelicula=" +
                idPelicula;
            }

            query +=
            " ORDER BY FechaVenta";

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