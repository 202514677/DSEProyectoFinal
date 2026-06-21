using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class Cartelera
    {
        public int idCartelera { get; set; }

        public int idCine { get; set; }

        public int idPelicula { get; set; }

        public DateTime fechaInicio { get; set; }

        public DateTime fechaFinalizacion { get; set; }

        public int activo { get; set; }

        private readonly CarteleraRepositorio repositorio;

        public Cartelera()
        {
            repositorio =
            new CarteleraRepositorio();
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

        public bool ExisteCarteleraActiva(
        int idCine,
        int idPelicula,
        DateTime fechaInicio,
        DateTime fechaFinalizacion)
        {
            return repositorio.ExisteCarteleraActiva(
                idCine,
                idPelicula,
                fechaInicio,
                fechaFinalizacion);
        }

        public bool ExisteCarteleraActivaEdicion(
            int idCartelera,
            int idCine,
            int idPelicula,
            DateTime fechaInicio,
            DateTime fechaFinalizacion)
        {
            return repositorio.ExisteCarteleraActivaEdicion(
                idCartelera,
                idCine,
                idPelicula,
                fechaInicio,
                fechaFinalizacion);
        }

        public DataTable ListarCarteleraPublica()
        {
            return repositorio
            .ListarCarteleraPublica();
        }

        public DataTable ObtenerPeliculaCartelera(
            int idPelicula)
        {
            return repositorio
            .ObtenerPeliculaCartelera(
            idPelicula);
        }

        public DataTable FiltrarCartelera(
        string ciudad,
        int idCine,
        string clasificacion,
        string genero)
        {
            return repositorio
            .FiltrarCartelera(
            ciudad,
            idCine,
            clasificacion,
            genero);
        }

        public DataTable FiltrarCarteleraFecha(
        string ciudad,
        int idCine,
        string clasificacion,
        string genero,
    string periodo)
        {
            return repositorio
            .FiltrarCarteleraFecha(
            ciudad,
            idCine,
            clasificacion,
            genero,
            periodo);
        }
    }
}