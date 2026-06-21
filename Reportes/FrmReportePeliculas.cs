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
using DSEProyectoFinal.Repositorio;
using DSEProyectoFinal.Clases;



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

            cboFiltro.SelectedIndex = 0;
        }

        private void CargarReporte()
        {
            PeliculaRepositorio pelicula =
            new PeliculaRepositorio();

            DataTable dt =
            pelicula.ListarReporte(
            cboFiltro.Text);

            ReportDataSource origen =
            new ReportDataSource(
            "DsPeliculas",
            dt);

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(
            origen);

            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
