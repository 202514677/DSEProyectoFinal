using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class ReservaTemporal
    {
        public int idReserva { get; set; }

        public int idHorario { get; set; }

        public string asiento { get; set; }

        public DateTime fechaReserva { get; set; }

        public DateTime fechaExpiracion { get; set; }

        public int activo { get; set; }

        private readonly ReservaTemporalRepositorio repositorio;

        public ReservaTemporal()
        {
            repositorio =
            new ReservaTemporalRepositorio();
        }

        public bool InsertarReserva()
        {
            return repositorio.InsertarReserva(this);
        }

        public DataTable ObtenerReservados(
        int idHorario)
        {
            return repositorio.ObtenerReservados(
            idHorario);
        }

        public bool ExisteReserva(
        int idHorario,
        string asiento)
        {
            return repositorio.ExisteReserva(
            idHorario,
            asiento);
        }

        public bool EliminarReserva(
        int idHorario,
        string asiento)
        {
            return repositorio.EliminarReserva(
            idHorario,
            asiento);
        }

        public bool EliminarReservasHorario(
        int idHorario)
        {
            return repositorio.EliminarReservasHorario(
            idHorario);
        }

        public bool EliminarExpirados()
        {
            return repositorio.EliminarExpirados();
        }
    }
}