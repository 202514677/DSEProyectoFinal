using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class UsuarioRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        #region CRUD

        public bool Insertar(Usuario usuario)
        {
            string query =
            @"INSERT INTO Usuarios
            (
                Dni,
                Nombres,
                Apellidos,
                FechaNacimiento,
                Celular,
                Correo,
                Password,
                Rol,
                Activo,
                FechaRegistro
            )
            VALUES
            (
                @Dni,
                @Nombres,
                @Apellidos,
                @FechaNacimiento,
                @Celular,
                @Correo,
                @Password,
                @Rol,
                @Activo,
                GETDATE()
            )";

            return EjecutarInsert(query, usuario);
        }

        public bool Actualizar(Usuario usuario)
        {
            string query =
            @"UPDATE Usuarios
            SET
                Dni=@Dni,
                Nombres=@Nombres,
                Apellidos=@Apellidos,
                FechaNacimiento=@FechaNacimiento,
                Celular=@Celular,
                Correo=@Correo,
                Password=@Password,
                Rol=@Rol,
                Activo=@Activo,
                FechaActualizacion=GETDATE()
            WHERE
                IdUsuario=@IdUsuario";

            return EjecutarUpdate(query, usuario);
        }

        public bool Eliminar(Usuario usuario)
        {
            string query =
            @"UPDATE Usuarios
              SET
                Activo=0,
                FechaActualizacion=GETDATE()
              WHERE
                IdUsuario=@IdUsuario";

            return EjecutarDelete(query, usuario);
        }

        #endregion

        #region CONSULTAS

        public DataTable Listar()
        {
            string query =
            @"SELECT
                IdUsuario,
                Dni,
                Nombres,
                Apellidos,
                Nombres + ' ' + Apellidos AS Usuario,
                FechaNacimiento,
                Celular,
                Correo,
                Password,
                Rol,
                Activo,
                FechaRegistro,
                FechaActualizacion
            FROM Usuarios
            ORDER BY
                Nombres,
                Apellidos";

            return EjecutarSelect(query);
        }

        public DataTable Buscar(string texto)
        {
            string query =
            @"SELECT
                IdUsuario,
                Dni,
                Nombres,
                Apellidos,
                Nombres + ' ' + Apellidos AS Usuario,
                FechaNacimiento,
                Celular,
                Correo,
                Password,
                Rol,
                Activo,
                FechaRegistro,
                FechaActualizacion
            FROM Usuarios
            WHERE
                Dni LIKE @texto
                OR Nombres LIKE @texto
                OR Apellidos LIKE @texto
                OR Celular LIKE @texto
                OR Correo LIKE @texto
            ORDER BY
            Nombres,
            Apellidos";

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

        public DataTable BuscarPorCorreo(
            string correo)
        {
            string query =
            @"SELECT *
              FROM Usuarios
              WHERE
                Correo=@Correo
                AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Correo",
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

        public DataTable Login(
            string correo,
            string password)
        {
            string query =
            @"SELECT *
              FROM Usuarios
              WHERE
            UPPER(Correo)=UPPER(@Correo)
            AND Password=@Password
            AND Activo=1";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Correo",
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

        #endregion

        #region VALIDACIONES

        public bool ExisteDni(string dni)
        {
            return EjecutarExiste(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE Dni=@Valor",

            dni);
        }

        public bool ExisteCelular(
            string celular)
        {
            return EjecutarExiste(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE Celular=@Valor",

            celular);
        }

        public bool ExisteCorreo(
            string correo)
        {
            return EjecutarExiste(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE Correo=@Valor",

            correo);
        }

        public bool ExisteDniEdicion(
            int idUsuario,
            string dni)
        {
            return EjecutarExisteEdicion(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE
                Dni=@Valor
                AND IdUsuario<>@IdUsuario",

            idUsuario,
            dni);
        }

        public bool ExisteCelularEdicion(
            int idUsuario,
            string celular)
        {
            return EjecutarExisteEdicion(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE
                Celular=@Valor
                AND IdUsuario<>@IdUsuario",

            idUsuario,
            celular);
        }

        public bool ExisteCorreoEdicion(
            int idUsuario,
            string correo)
        {
            return EjecutarExisteEdicion(
            @"SELECT COUNT(*)
              FROM Usuarios
              WHERE
                Correo=@Valor
                AND IdUsuario<>@IdUsuario",

            idUsuario,
            correo);
        }

        #endregion

        #region PRIVADOS

        private bool EjecutarInsert(
            string query,
            Usuario usuario)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    AgregarParametros(
                    comando,
                    usuario);

                    try
                    {
                        conexion.Open();

                        return comando
                        .ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private bool EjecutarUpdate(
            string query,
            Usuario usuario)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        usuario.idUsuario);

                    AgregarParametros(
                    comando,
                    usuario);

                    try
                    {
                        conexion.Open();

                        return comando
                        .ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private bool EjecutarDelete(
            string query,
            Usuario usuario)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        usuario.idUsuario);

                    try
                    {
                        conexion.Open();

                        return comando
                        .ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private DataTable EjecutarSelect(
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                        ex.Message);

                        return null;
                    }
                }
            }
        }

        private void AgregarParametros(
            SqlCommand comando,
            Usuario usuario)
        {
            comando.Parameters.AddWithValue(
                "@Dni",
                usuario.dni);

            comando.Parameters.AddWithValue(
                "@Nombres",
                usuario.nombres);

            comando.Parameters.AddWithValue(
                "@Apellidos",
                usuario.apellidos);

            comando.Parameters.AddWithValue(
                "@FechaNacimiento",
                usuario.fechaNacimiento);

            comando.Parameters.AddWithValue(
                "@Celular",
                usuario.celular);

            comando.Parameters.AddWithValue(
                "@Correo",
                usuario.correo);

            comando.Parameters.AddWithValue(
                "@Password",
                usuario.password);

            comando.Parameters.AddWithValue(
                "@Rol",
                usuario.rol);

            comando.Parameters.AddWithValue(
                "@Activo",
                usuario.activo);
        }

        private bool EjecutarExiste(
            string query,
            string valor)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Valor",
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
            int idUsuario,
            string valor)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    comando.Parameters.AddWithValue(
                        "@Valor",
                        valor);

                    conexion.Open();

                    int cantidad =
                    Convert.ToInt32(
                    comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        #endregion
    }
}