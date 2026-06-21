using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class DetalleVentaDulceria
    {
        public int idDetalleVentaDulceria { get; set; }

        public int idVentaDulceria { get; set; }

        public int idProducto { get; set; }

        public int cantidad { get; set; }

        public decimal precio { get; set; }

        public decimal subTotal { get; set; }

        private readonly DetalleVentaDulceriaRepositorio repositorio;

        public DetalleVentaDulceria()
        {
            repositorio =
            new DetalleVentaDulceriaRepositorio();
        }

        public bool Registrar()
        {
            return repositorio.Insertar(this);
        }
    }
}