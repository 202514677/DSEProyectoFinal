using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string dni { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string celular { get; set; }

        public string email { get; set; }

        public int activo { get; set; }

        public DateTime fechaRegistro { get; set; }

        public DateTime fechaActualizacion { get; set; }

        public string password { get; set; }

        public string tokenAcceso { get; set; }

        public DateTime fechaToken { get; set; }



        private readonly ClienteRepositorio repositorio;

        public Cliente()
        {
            repositorio =
            new ClienteRepositorio();
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

        public DataTable BuscarPorDni(
            string dni)
        {
            return repositorio.BuscarPorDni(
            dni);
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

        public bool ExisteEmail(
            string email)
        {
            return repositorio.ExisteEmail(
            email);
        }

        public bool ExisteDniEdicion(
            int idCliente,
            string dni)
        {
            return repositorio.ExisteDniEdicion(
                idCliente,
                dni);
        }

        public bool ExisteCelularEdicion(
            int idCliente,
            string celular)
        {
            return repositorio.ExisteCelularEdicion(
                idCliente,
                celular);
        }

        public bool ExisteEmailEdicion(
            int idCliente,
            string email)
        {
            return repositorio.ExisteEmailEdicion(
                idCliente,
                email);
        }

        public DataTable Login(
        string correo,
        string password)
        {
            return repositorio.Login(
            correo,
            password);
        }

        public DataTable BuscarPorCorreo(string correo)
        {
            return repositorio
            .BuscarPorCorreo(
            correo);
        }
    }
}