using System;
using System.Data;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class VentaDulceriaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public int Insertar(
            VentaDulceria venta)
        {
            string query =
            @"INSERT INTO VentasDulceria
            (
                IdCliente,
                FechaVenta,
                SubTotal,
                IGV,
                Total,
                MetodoPago,
                NumeroAutorizacion,
                Ultimos4Tarjeta,
                Estado,
                CodigoTicket,
                QrTexto,
                UsuarioRegistro
            )
            OUTPUT INSERTED.IdVentaDulceria
            VALUES
            (
                @IdCliente,
                GETDATE(),
                @SubTotal,
                @IGV,
                @Total,
                @MetodoPago,
                @NumeroAutorizacion,
                @Ultimos4Tarjeta,
                @Estado,
                @CodigoTicket,
                @QrTexto,
                @UsuarioRegistro
            )";

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
                        (object)venta.numeroAutorizacion
                        ?? DBNull.Value);

                    comando.Parameters.AddWithValue(
                        "@Ultimos4Tarjeta",
                        (object)venta.ultimos4Tarjeta
                        ?? DBNull.Value);

                    comando.Parameters.AddWithValue(
                        "@Estado",
                        venta.estado);

                    comando.Parameters.AddWithValue(
                        "@CodigoTicket",
                        venta.codigoTicket);

                    comando.Parameters.AddWithValue(
                        "@QrTexto",
                        venta.qrTexto);

                    comando.Parameters.AddWithValue(
                        "@UsuarioRegistro",
                        venta.usuarioRegistro);

                    conexion.Open();

                    return Convert.ToInt32(
                        comando.ExecuteScalar());
                }
            }
        }

        public DataTable ListarVentas()
        {
            string query =
            @"SELECT *
            FROM VentasDulceria
            ORDER BY FechaVenta DESC";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                SqlDataAdapter da =
                new SqlDataAdapter(
                query,
                conexion);

                DataTable dt =
                new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable ListarReporteDulceria(
DateTime fechaInicio,
DateTime fechaFin,
string categoria)
        {
            string query =
            @"SELECT *

      FROM vw_ReporteDulceria

      WHERE
      CAST(FechaVenta AS DATE)
      BETWEEN
      CAST(@fechaInicio AS DATE)
      AND
      CAST(@fechaFin AS DATE)";

            if (categoria != "TODAS")
            {
                query +=
                " AND Categoria='" +
                categoria + "'";
            }

            query +=
            " ORDER BY CantidadVendida DESC";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                SqlCommand comando =
                new SqlCommand(query, conexion);

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