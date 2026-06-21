using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    internal class Pelicula
    {
        public int idPelicula { get; set; }

        public string titulo { get; set; }

        public string genero { get; set; }

        public int duracion { get; set; }

        public string clasificacion { get; set; }

        public string sinopsis { get; set; }

        public int estreno { get; set; }

        public string idioma { get; set; }

        public string imagen { get; set; }

        public DateTime fechaIngreso { get; set; }

        public DateTime fechaSalida { get; set; }

        public int activo { get; set; }

        private readonly PeliculaRepositorio repositorio;

        public Pelicula()
        {
            repositorio = new PeliculaRepositorio();
        }

        public Pelicula(
            string titulo,
            string genero,
            int duracion,
            string clasificacion,
            string sinopsis,
            int estreno,
            string idioma,
            string imagen,
            DateTime fechaIngreso,
            DateTime fechaSalida)
        {
            this.titulo = titulo;
            this.genero = genero;
            this.duracion = duracion;
            this.clasificacion = clasificacion;
            this.sinopsis = sinopsis;
            this.estreno = estreno;
            this.idioma = idioma;
            this.imagen = imagen;
            this.fechaIngreso = fechaIngreso;
            this.fechaSalida = fechaSalida;
            this.activo = 1;

            repositorio = new PeliculaRepositorio();
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

        public bool ExisteTitulo(string titulo)
        {
            return repositorio.ExisteTitulo(titulo);
        }

        public bool ExisteTituloEdicion(
            string titulo,
            int idPelicula)
        {
            return repositorio.ExisteTituloEdicion(
                titulo,
                idPelicula);
        }

        public DataTable ListarGeneros()
        {
            return repositorio
            .ListarGeneros();
        }

        public DataTable ListarClasificaciones()
        {
            return repositorio
            .ListarClasificaciones();
        }
    }
}