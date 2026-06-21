using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class Rol
    {
        public int idRol { get; set; }

        public string nombre { get; set; }

        public int activo { get; set; }

        private readonly RolRepositorio repositorio;

        public Rol()
        {
            repositorio =
            new RolRepositorio();
        }

        public DataTable Listar()
        {
            return repositorio.Listar();
        }
    }
}
