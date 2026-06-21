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
    public partial class FrmReporteClientes : Form
    {
        public FrmReporteClientes()
        {
            InitializeComponent();
        }

        private void FrmReporteClientes_Load(
 object sender,
 EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource =
            "DSEProyectoFinal.RDLC.ReporteClientes.rdlc";

            dtpDesde.Value =
            DateTime.Today.AddMonths(-3);

            dtpHasta.Value =
            DateTime.Today;

            CargarReporte();
        }

        private void CargarReporte()
        {
            ClienteRepositorio cliente =
            new ClienteRepositorio();

            DataTable dt =
            cliente.ListarReporte(
            dtpDesde.Value.Date,
            dtpHasta.Value.Date);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource origen =
            new ReportDataSource(
            "DsClientes",
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
