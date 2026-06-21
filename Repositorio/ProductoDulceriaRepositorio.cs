using System;
using System.Data;
using System.Data.SqlClient;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Repositorio
{
    public class ProductoDulceriaRepositorio
    {
        private string connectionString =
        "Server=localhost;Database=BD_CINEPELIS;Trusted_Connection=True;";

        #region CRUD

        public bool Insertar(
            ProductoDulceria producto)
        {
            string query =
            @"INSERT INTO ProductosDulceria
            (
                Nombre,
                Descripcion,
                Categoria,
                Precio,
                Stock,
                Imagen,
                Activo,
                FechaRegistro
            )
            VALUES
            (
                @Nombre,
                @Descripcion,
                @Categoria,
                @Precio,
                @Stock,
                @Imagen,
                @Activo,
                GETDATE()
            )";

            return EjecutarInsert(
            query,
            producto);
        }

        public bool Actualizar(
            ProductoDulceria producto)
        {
            string query =
            @"UPDATE ProductosDulceria
              SET
                Nombre=@Nombre,
                Descripcion=@Descripcion,
                Categoria=@Categoria,
                Precio=@Precio,
                Stock=@Stock,
                Imagen=@Imagen,
                Activo=@Activo,
                FechaActualizacion=GETDATE()
              WHERE
                IdProducto=@IdProducto";

            return EjecutarUpdate(
            query,
            producto);
        }

        public bool Eliminar(
            ProductoDulceria producto)
        {
            string query =
            @"UPDATE ProductosDulceria
              SET
                Activo=0,
                FechaActualizacion=GETDATE()
              WHERE
                IdProducto=@IdProducto";

            return EjecutarDelete(
            query,
            producto);
        }

        #endregion


        #region CONSULTAS

        public DataTable Listar()
        {
            string query =
            @"SELECT

                IdProducto,

                Nombre,

                Descripcion,

                Categoria,

                Precio,

                Stock,

                Imagen,

                Activo,

                FechaRegistro,

                FechaActualizacion

            FROM ProductosDulceria

            ORDER BY Nombre";

            return EjecutarSelect(
            query);
        }

        public DataTable Buscar(
            string texto)
        {
            string query =
            @"SELECT

                IdProducto,

                Nombre,

                Descripcion,

                Categoria,

                Precio,

                Stock,

                Imagen,

                Activo,

                FechaRegistro,

                FechaActualizacion

            FROM ProductosDulceria

            WHERE

                Nombre LIKE @Texto

                OR Categoria LIKE @Texto

            ORDER BY Nombre";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Texto",
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

        #endregion


        #region VALIDACIONES

        public bool ExisteNombre(
            string nombre)
        {
            string query =
            @"SELECT COUNT(*)

              FROM ProductosDulceria

              WHERE Nombre=@Valor";

            return EjecutarExiste(
            query,
            nombre);
        }

        public bool ExisteNombreEdicion(
            int idProducto,
            string nombre)
        {
            string query =
            @"SELECT COUNT(*)

              FROM ProductosDulceria

              WHERE

                    Nombre=@Valor

                AND IdProducto<>@IdProducto";

            return EjecutarExisteEdicion(
            query,
            idProducto,
            nombre);
        }

        #endregion


        #region MÉTODOS PRIVADOS

        private void AgregarParametros(
            SqlCommand comando,
            ProductoDulceria producto)
        {
            comando.Parameters.AddWithValue(
                "@Nombre",
                producto.nombre);

            comando.Parameters.AddWithValue(
                "@Descripcion",
                producto.descripcion);

            comando.Parameters.AddWithValue(
                "@Categoria",
                producto.categoria);

            comando.Parameters.AddWithValue(
                "@Precio",
                producto.precio);

            comando.Parameters.AddWithValue(
                "@Stock",
                producto.stock);

            comando.Parameters.AddWithValue(
                "@Imagen",
                producto.imagen);

            comando.Parameters.AddWithValue(
                "@Activo",
                producto.activo);
        }


        private bool EjecutarInsert(
            string query,
            ProductoDulceria producto)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    AgregarParametros(
                    comando,
                    producto);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        private bool EjecutarUpdate(
            string query,
            ProductoDulceria producto)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    AgregarParametros(
                    comando,
                    producto);

                    comando.Parameters.AddWithValue(
                        "@IdProducto",
                        producto.idProducto);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }


        private bool EjecutarDelete(
            string query,
            ProductoDulceria producto)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdProducto",
                        producto.idProducto);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
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
                    conexion.Open();

                    DataTable dt =
                    new DataTable();

                    dt.Load(
                    comando.ExecuteReader());

                    return dt;
                }
            }
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
            int idProducto,
            string valor)
        {
            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

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

        public bool ActualizarStock(
int idProducto,
int cantidadVendida)
        {
            string query =
            @"UPDATE ProductosDulceria
      SET Stock = Stock - @Cantidad
      WHERE IdProducto=@IdProducto";

            using (SqlConnection conexion =
                new SqlConnection(connectionString))
            {
                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidadVendida);

                    comando.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    conexion.Open();

                    return comando.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}