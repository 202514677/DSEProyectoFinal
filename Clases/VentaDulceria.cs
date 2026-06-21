using System;
using System.Data;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Clases
{
    public class VentaDulceria
    {
        public int idVentaDulceria { get; set; }

        public int idCliente { get; set; }

        public DateTime fechaVenta { get; set; }

        public decimal subTotal { get; set; }

        public decimal igv { get; set; }

        public decimal total { get; set; }

        public string metodoPago { get; set; }

        public string numeroAutorizacion { get; set; }

        public string ultimos4Tarjeta { get; set; }

        public string estado { get; set; }

        public string codigoTicket { get; set; }

        public string qrTexto { get; set; }

        public int usuarioRegistro { get; set; }

        private readonly VentaDulceriaRepositorio repositorio;

        public VentaDulceria()
        {
            repositorio =
            new VentaDulceriaRepositorio();
        }

        public int Registrar()
        {
            return repositorio.Insertar(this);
        }

        public DataTable ListarVentas()
        {
            return repositorio.ListarVentas();
        }
    }
}