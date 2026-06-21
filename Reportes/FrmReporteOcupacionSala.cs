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
    public partial class FrmReporteOcupacionSala : Form
    {
        public FrmReporteOcupacionSala()
        {
            InitializeComponent();
        }

        private void FrmReporteOcupacionSala_Load(
 object sender,
 EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource =
            "DSEProyectoFinal.RDLC.ReporteOcupacionSala.rdlc";

            dtpDesde.Value =
            DateTime.Today.AddMonths(-1);

            dtpHasta.Value =
            DateTime.Today.AddMonths(1);

            CargarComboCines();

            CargarComboPeliculas();

            CargarReporte();
        }

        private void CargarReporte()
        {
            HorarioRepositorio horario =
            new HorarioRepositorio();

            DataTable dt =
            horario.ListarReporteOcupacionSala(

            dtpDesde.Value.Date,

            dtpHasta.Value.Date,

            Convert.ToInt32(
            cboCine.SelectedValue),

            Convert.ToInt32(
            cboPelicula.SelectedValue));

            reportViewer1.LocalReport.DataSources.Clear();

          /*  MessageBox.Show(
dt.Rows.Count.ToString()); */

            ReportDataSource origen =
            new ReportDataSource(
            "DsOcupacionSala",
            dt);

            reportViewer1.LocalReport.DataSources.Add(
            origen);

            reportViewer1.RefreshReport();
        }

        private void CargarComboCines()
        {
            CineRepositorio cine =
            new CineRepositorio();

            DataTable dt =
            cine.ListarCombo();

            DataRow fila =
            dt.NewRow();

            fila["IdCine"] = 0;
            fila["Nombre"] = "TODOS";

            dt.Rows.InsertAt(
            fila,
            0);

            cboCine.DataSource =
            dt;

            cboCine.DisplayMember =
            "Nombre";

            cboCine.ValueMember =
            "IdCine";
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
