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
    public partial class FrmReportePeliculas : Form
    {
        public FrmReportePeliculas()
        {
            InitializeComponent();
        }

        private void FrmReportePeliculas_Load(
 object sender,
 EventArgs e)
        {
            PeliculaRepositorio pelicula =
            new PeliculaRepositorio();

            DataTable dt =
            pelicula.ListarReporte();

            ReportDataSource origen =
            new ReportDataSource(
            "DsPeliculas",
            dt);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
            origen);

            reportViewer1.LocalReport.ReportEmbeddedResource =
            "DSEProyectoFinal.RDLC.ReportePeliculas.rdlc";

            reportViewer1.RefreshReport();
        }

        private void CargarReporte()
        {
            PeliculaRepositorio pelicula =
            new PeliculaRepositorio();

            DataTable dt =
            pelicula.ListarReporteFecha(
            dtpDesde.Value.Date,
            dtpHasta.Value.Date);

            ReportDataSource origen =
            new ReportDataSource(
            "DsPeliculas",
            dt);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
            origen);

            reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
