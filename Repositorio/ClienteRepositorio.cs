using System;
using System.Data;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class ClienteRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        public bool Insertar(Cliente paramCliente)
        {
            string query =
            @"INSERT INTO Clientes
            (
                Dni,
                Nombre,
                Apellido,
                Celular,
                Email,
                Activo,
                FechaRegistro
            )
            VALUES
            (
                @dni,
                @nombre,
                @apellido,
                @celular,
                @email,
                @activo,
                GETDATE()
            )";

            return EjecutarComandoInsert(
                query,
                paramCliente);
        }

        public bool Actualizar(Cliente paramCliente)
        {
            string query =
            @"UPDATE Clientes
              SET Dni = @dni,
                  Nombre = @nombre,
                  Apellido = @apellido,
                  Celular = @celular,
                  Email = @email,
                  Activo = @activo,
                  FechaActualizacion = GETDATE()
              WHERE IdCliente = @idCliente";

            return EjecutarComandoUpdate(
                query,
                paramCliente);
        }

        public bool Eliminar(Cliente paramCliente)
        {
            string query =
            @"UPDATE Clientes
              SET Activo = 0,
                  FechaActualizacion = GETDATE()
              WHERE IdCliente = @idCliente";

            return EjecutarComandoDelete(
                query,
                paramCliente);
        }

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdCliente,
                Dni,
                Nombre + ' ' + Apellido AS Cliente,
                Nombre,
                Apellido,
                Celular,
                Email,
                Activo,
                FechaRegistro,
                FechaActualizacion
              FROM Clientes
              ORDER BY Nombre,
                       Apellido";

            return EjecutarComandoSelect(
                query);
        }

        public DataTable Buscar(
            string texto)
        {
            string query =
            @"SELECT
                IdCliente,
                Dni,
                Nombre + ' ' + Apellido AS Cliente,
                Nombre,
                Apellido,
                Celular,
                Email,
                Activo,
                FechaRegistro,
                FechaActualizacion
              FROM Clientes
              WHERE
                    Dni LIKE @texto
                 OR Nombre LIKE @texto
                 OR Apellido LIKE @texto
                 OR Celular LIKE @texto
                 OR Email LIKE @texto
              ORDER BY Nombre,
                       Apellido";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@texto",
                        "%" + texto + "%");

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                        comando.ExecuteReader());

                    return dt;
                }
            }
        }

        public DataTable BuscarPorDni(
            string dni)
        {
            string query =
            @"SELECT *
              FROM Clientes
              WHERE Dni=@dni
              AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@dni",
                        dni);

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                        comando.ExecuteReader());

                    return dt;
                }
            }
        }

        public bool ExisteDni(
            string dni)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Dni=@dni";

            return EjecutarExiste(
                query,
                "@dni",
                dni);
        }

        public bool ExisteCelular(
            string celular)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Celular=@celular";

            return EjecutarExiste(
                query,
                "@celular",
                celular);
        }

        public bool ExisteEmail(
            string email)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Email=@email";

            return EjecutarExiste(
                query,
                "@email",
                email);
        }

        public bool ExisteDniEdicion(
            int idCliente,
            string dni)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Dni=@dni
              AND IdCliente<>@idCliente";

            return EjecutarExisteEdicion(
                query,
                "@dni",
                dni,
                idCliente);
        }

        public bool ExisteCelularEdicion(
            int idCliente,
            string celular)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Celular=@celular
              AND IdCliente<>@idCliente";

            return EjecutarExisteEdicion(
                query,
                "@celular",
                celular,
                idCliente);
        }

        public bool ExisteEmailEdicion(
            int idCliente,
            string email)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Clientes
              WHERE Email=@email
              AND IdCliente<>@idCliente";

            return EjecutarExisteEdicion(
                query,
                "@email",
                email,
                idCliente);
        }

        private bool EjecutarComandoInsert(
            string query,
            Cliente paramCliente)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@dni",
                        paramCliente.dni);

                    comando.Parameters.AddWithValue(
                        "@nombre",
                        paramCliente.nombre);

                    comando.Parameters.AddWithValue(
                        "@apellido",
                        paramCliente.apellido);

                    comando.Parameters.AddWithValue(
                        "@celular",
                        paramCliente.celular);

                    comando.Parameters.AddWithValue(
                        "@email",
                        paramCliente.email);

                    comando.Parameters.AddWithValue(
                        "@activo",
                        paramCliente.activo);

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
            Cliente paramCliente)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idCliente",
                        paramCliente.idCliente);

                    comando.Parameters.AddWithValue(
                        "@dni",
                        paramCliente.dni);

                    comando.Parameters.AddWithValue(
                        "@nombre",
                        paramCliente.nombre);

                    comando.Parameters.AddWithValue(
                        "@apellido",
                        paramCliente.apellido);

                    comando.Parameters.AddWithValue(
                        "@celular",
                        paramCliente.celular);

                    comando.Parameters.AddWithValue(
                        "@email",
                        paramCliente.email);

                    comando.Parameters.AddWithValue(
                        "@activo",
                        paramCliente.activo);

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
            Cliente paramCliente)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@idCliente",
                        paramCliente.idCliente);

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

        private bool EjecutarExiste(
            string query,
            string parametro,
            string valor)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        parametro,
                        valor);

                    conexion.Open();

                    int cantidad =
                    Convert.ToInt32(
                        comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        private bool EjecutarExisteEdicion(
            string query,
            string parametro,
            string valor,
            int idCliente)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        parametro,
                        valor);

                    comando.Parameters.AddWithValue(
                        "@idCliente",
                        idCliente);

                    conexion.Open();

                    int cantidad =
                    Convert.ToInt32(
                        comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        public DataTable Login( string correo, string password)
        {
            string query =
            @"SELECT *
      FROM Clientes
      WHERE
            UPPER(Email)=UPPER(@Email)
        AND Password=@Password
        AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Email",
                        correo);

                    comando.Parameters.AddWithValue(
                        "@Password",
                        password);

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
        }

        public DataTable ListarReporte(
DateTime fechaInicio,
DateTime fechaFin)
        {
            string query =
            @"SELECT *

    FROM vw_ReporteClientes

    WHERE
    CAST(FechaRegistro AS DATE)
    BETWEEN
    CAST(@fechaInicio AS DATE)
    AND
    CAST(@fechaFin AS DATE)

    ORDER BY Nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
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

        public DataTable BuscarPorCorreo(string correo)
        {
            string query =
            @"SELECT *

      FROM Clientes

      WHERE
      Email=@Email
      AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                    "@Email",
                    correo);

                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
        }

    }
}