using System;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class DetalleVenta
    {
        public int idDetalleVenta { get; set; }

        public int idVenta { get; set; }

        public string asiento { get; set; }

        public decimal precio { get; set; }

        private readonly DetalleVentaRepositorio repositorio;

        public DetalleVenta()
        {
            repositorio =
            new DetalleVentaRepositorio();
        }

        public bool Registrar()
        {
            return repositorio.Insertar(this);
        }
    }
}
