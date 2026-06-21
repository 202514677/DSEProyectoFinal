using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class ProductoDulceria
    {
        public int idProducto { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string categoria { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public string imagen { get; set; }

        public int activo { get; set; }

        private readonly ProductoDulceriaRepositorio repositorio;

        public ProductoDulceria()
        {
            repositorio =
            new ProductoDulceriaRepositorio();
        }

        #region CRUD

        public bool Registrar()
        {
            return repositorio.Insertar(this);
        }

        public bool Actualizar()
        {
            return repositorio.Actualizar(this);
        }

        public bool Eliminar()
        {
            return repositorio.Eliminar(this);
        }

        #endregion

        #region CONSULTAS

        public DataTable Listar()
        {
            return repositorio.Listar();
        }

        public DataTable Buscar(
            string texto)
        {
            return repositorio.Buscar(
            texto);
        }

        #endregion

        #region VALIDACIONES

        public bool ExisteNombre(
            string nombre)
        {
            return repositorio.ExisteNombre(
            nombre);
        }

        public bool ExisteNombreEdicion(
            int idProducto,
            string nombre)
        {
            return repositorio.ExisteNombreEdicion(
            idProducto,
            nombre);
        }

        #endregion
    }
}