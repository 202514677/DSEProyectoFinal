using DSEProyectoFinal.Repositorio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEProyectoFinal.Reportes
{
    public partial class FrmReporteVentas : Form
    {
        public FrmReporteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteVentas_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource =
            "DSEProyectoFinal.RDLC.ReporteVentas.rdlc";

            dtpDesde.Value =
            DateTime.Today.AddMonths(-1);

            dtpHasta.Value =
            DateTime.Today.AddMonths(1);            

            CargarComboPeliculas();

            CargarReporte();
        }

        private void CargarComboPeliculas()
        {
            PeliculaRepositorio pelicula =
            new PeliculaRepositorio();

            DataTable dt =
            pelicula.ListarCombo();

            DataRow fila =
            dt.NewRow();

            fila["IdPelicula"] = 0;
            fila["Titulo"] = "TODAS";

            dt.Rows.InsertAt(
            fila,
            0);

            cboPelicula.DataSource =
            dt;

            cboPelicula.DisplayMember =
            "Titulo";

            cboPelicula.ValueMember =
            "IdPelicula";
        }

        private void CargarReporte()
        {
            VentaRepositorio venta =
            new VentaRepositorio();

            DataTable dt =
            venta.ListarReporteVentas(

            dtpDesde.Value.Date,

            dtpHasta.Value.Date,

            Convert.ToInt32(
            cboPelicula.SelectedValue));

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource origen =
            new ReportDataSource(
            "DsVentas",
            dt);

            reportViewer1.LocalReport.DataSources.Add(
            origen);

            reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
