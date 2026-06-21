using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    internal class Cine
    {
        public int idCine { get; set; }

        public string nombre { get; set; }

        public string ciudad { get; set; }

        public string direccion { get; set; }

        public string googleMaps { get; set; }

        public string imagen { get; set; }

        public int salas2D { get; set; }

        public int salas3D { get; set; }

        public int salas4K { get; set; }

        public int salasPrime { get; set; }

        public int salasEventos { get; set; }

        public int IdUsuario { get; set; }

        public int activo { get; set; }

        private readonly CineRepositorio repositorio;

        public Cine()
        {
            repositorio = new CineRepositorio();
        }

        public Cine(
            string nombre,
            string ciudad,
            string direccion)
        {
            this.nombre = nombre;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.activo = 1;

            repositorio = new CineRepositorio();
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

        public DataTable Buscar(string nombre)
        {
            return repositorio.Buscar(nombre);
        }

        public bool ExisteNombre(string nombre)
        {
            return repositorio.ExisteNombre(nombre);
        }

        public bool ExisteNombreEdicion( string nombre, int idCine)
        {
            return repositorio.ExisteNombreEdicion(
                nombre,
                idCine);
        }

        public bool ExisteGoogleMaps(string googleMaps)
        {
            return repositorio.ExisteGoogleMaps(googleMaps);
        }

        public bool ExisteGoogleMapsEdicion( string googleMaps, int idCine)
        {
            return repositorio.ExisteGoogleMapsEdicion( googleMaps, idCine);
        }

        public DataTable ListarCiudades()
        {
            return repositorio
            .ListarCiudades();
        }

        public DataTable ListarCinesPorCiudad(
            string ciudad)
        {
            return repositorio
            .ListarCinesPorCiudad(
            ciudad);
        }
    }
}