using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class Horario
    {
        public int idHorario { get; set; }

        public int idCine { get; set; }

        public int idCartelera { get; set; }
        
        public int numSala { get; set; }

        public string tipoSala { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFinalizacion { get; set; }

        public decimal precioVentaPublico { get; set; }

        public int totalAsientos { get; set; }

        public int cantidadventaPublico { get; set; }

        public int cantidadcorporativo { get; set; }

        public int cantidadmarketing { get; set; }

        public int entradasVendidas { get; set; }

        public int activo { get; set; }

        private readonly HorarioRepositorio repositorio;

        public Horario()
        {
            repositorio = new HorarioRepositorio();
        }

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

        public DataTable Listar()
        {
            return repositorio.Listar();
        }

        public DataTable Buscar(string texto)
        {
            return repositorio.Buscar(texto);
        }

        public DataTable ListarVentaEntradas()
        {
            return repositorio
            .ListarVentaEntradas();
        }

        public DataTable ObtenerHorarioVenta(int idHorario)
        {
            return repositorio
            .ObtenerHorarioVenta(
            idHorario);
        }

        public DataTable ObtenerDisponibilidad(int idHorario)
        {
            return repositorio
            .ObtenerDisponibilidad(
            idHorario);
        }

        public DataTable ListarVentaEntradasPorPelicula(int idPelicula)
        {
            return repositorio
                .ListarVentaEntradasPorPelicula(
                idPelicula);
        }

    }

}