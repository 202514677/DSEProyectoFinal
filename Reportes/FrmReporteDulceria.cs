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

namespace DSEProyectoFinal.Reportes
{
    public partial class FrmReporteDulceria : Form
    {
        public FrmReporteDulceria()
        {
            InitializeComponent();
        }

        private void FrmReporteDulceria_Load(
   object sender,
   EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource =
            "DSEProyectoFinal.RDLC.ReporteDulceria.rdlc";

            dtpDesde.Value =
            DateTime.Today.AddMonths(-1);

            dtpHasta.Value =
            DateTime.Today;

            CargarCategorias();

            CargarReporte();
        }

        private void CargarCategorias()
        {
            cboCategoria.Items.Clear();

            cboCategoria.Items.Add("TODAS");
            cboCategoria.Items.Add("CANCHITAS");
            cboCategoria.Items.Add("BEBIDAS");
            cboCategoria.Items.Add("CHOCOLATES");
            cboCategoria.Items.Add("COMBOS");

            cboCategoria.SelectedIndex = 0;
        }

        private void CargarReporte()
        {
            VentaDulceriaRepositorio venta =
            new VentaDulceriaRepositorio();

            DataTable dt =
            venta.ListarReporteDulceria(

            dtpDesde.Value.Date,

            dtpHasta.Value.Date,

            cboCategoria.Text);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource origen =
            new ReportDataSource(
            "DsDulceria",
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
