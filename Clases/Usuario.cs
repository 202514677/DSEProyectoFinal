using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class Usuario
    {
        public int idUsuario { get; set; }

        public string dni { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string celular { get; set; }

        public string correo { get; set; }

        public string password { get; set; }

        public string rol { get; set; }

        public int activo { get; set; }

        public string tokenAcceso { get; set; }

        public DateTime fechaToken { get; set; }

        private readonly UsuarioRepositorio repositorio;

        public Usuario()
        {
            repositorio =
            new UsuarioRepositorio();
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

        public DataTable Buscar(
            string texto)
        {
            return repositorio.Buscar(
            texto);
        }

        public DataTable BuscarPorCorreo(
            string correo)
        {
            return repositorio.BuscarPorCorreo(
            correo);
        }

        public bool ExisteDni(
            string dni)
        {
            return repositorio.ExisteDni(
            dni);
        }

        public bool ExisteCelular(
            string celular)
        {
            return repositorio.ExisteCelular(
            celular);
        }

        public bool ExisteCorreo(
            string correo)
        {
            return repositorio.ExisteCorreo(
            correo);
        }

        public bool ExisteDniEdicion(
            int idUsuario,
            string dni)
        {
            return repositorio
            .ExisteDniEdicion(
            idUsuario,
            dni);
        }

        public bool ExisteCelularEdicion(
            int idUsuario,
            string celular)
        {
            return repositorio
            .ExisteCelularEdicion(
            idUsuario,
            celular);
        }

        public bool ExisteCorreoEdicion(
            int idUsuario,
            string correo)
        {
            return repositorio
            .ExisteCorreoEdicion(
            idUsuario,
            correo);
        }

        public DataTable Login(
            string correo,
            string password)
        {
            return repositorio.Login(
            correo,
            password);
        }
    }
}