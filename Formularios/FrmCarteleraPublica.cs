using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;
using System.IO;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmCarteleraPublica : Form
    {
        private Cartelera cartelera = new Cartelera();

        private int idPeliculaSeleccionada = 0;

        private string imagenSeleccionada = "";

        private Cine cine = new Cine();

        private Pelicula pelicula = new Pelicula();

        public FrmCarteleraPublica()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmCarteleraPublica_Load(
      object sender,
      EventArgs e)
        {
            picPoster.SizeMode =
            PictureBoxSizeMode.Zoom;

            txtSinopsis.ReadOnly =
            true;

            flowPeliculas.AutoScroll =
            true;

            flowPeliculas.WrapContents =
            true;

            rbHoy.Checked = false;
            rbManana.Checked = false;
            rbEstaSemana.Checked = false;
            rbProximamente.Checked = false;

            CargarCiudades();

            CargarCines();

            CargarGeneros();

            CargarClasificaciones();

            CargarPeliculas();

            AplicarFiltros();
        }

        private void CargarPeliculas()
        {
            flowPeliculas.Controls.Clear();

            DataTable dt =
            cartelera.ListarCarteleraPublica();

            if (dt == null || dt.Rows.Count == 0)
            {
                LimpiarDetallePelicula();

                return;
            }

            foreach (DataRow fila
                in dt.Rows)
            {
                CrearPoster(fila);
            }

            MostrarPelicula(
            dt.Rows[0]);

            btnComprar.Enabled = true;
        }

        private void CrearPoster(
        DataRow fila)
        {
            Panel panel =
            new Panel();

            panel.Width = 180;

            panel.Height = 320;

            PictureBox pic =
            new PictureBox();

            pic.Width = 160;

            pic.Height = 220;

            pic.Left = 10;

            pic.Top = 5;

            pic.SizeMode =
            PictureBoxSizeMode.Zoom;

            pic.Cursor =
            Cursors.Hand;

            pic.BorderStyle =
            BorderStyle.FixedSingle;

            pic.Tag =
            fila;

            string ruta =
            fila["Imagen"]
            .ToString();

            if (File.Exists(ruta))
            {
                pic.Image =
                Image.FromFile(ruta);
            }

            Label lblTituloPoster =
            new Label();

            lblTituloPoster.Width = 160;

            lblTituloPoster.Height = 35;

            lblTituloPoster.Left = 10;

            lblTituloPoster.Top = 225;

            lblTituloPoster.TextAlign =
            ContentAlignment.MiddleCenter;

            lblTituloPoster.Font =
            new Font(
                "Segoe UI",
                9,
                FontStyle.Bold);

            lblTituloPoster.Text =
            fila["Titulo"]
            .ToString();

            Label lblGenero =
            new Label();

            lblGenero.Width = 160;

            lblGenero.Height = 20;

            lblGenero.Left = 10;

            lblGenero.Top = 260;

            lblGenero.TextAlign =
            ContentAlignment.MiddleCenter;

            lblGenero.Text =
            fila["Genero"]
            .ToString();

            Label lblInfo =
            new Label();

            lblInfo.Width = 160;

            lblInfo.Height = 40;

            lblInfo.Left = 10;

            lblInfo.Top = 280;

            lblInfo.TextAlign =
            ContentAlignment.MiddleCenter;

            lblInfo.Text =
            fila["Clasificacion"]
            .ToString()

            + " | "

            + fila["Duracion"]
            .ToString()

            + " min";

            pic.Click +=
            Poster_Click;

            lblTituloPoster.Click +=
            Poster_Click;

            lblGenero.Click +=
            Poster_Click;

            lblInfo.Click +=
            Poster_Click;

            lblTituloPoster.Tag =
            fila;

            lblGenero.Tag =
            fila;

            lblInfo.Tag =
            fila;

            panel.Controls.Add(pic);

            panel.Controls.Add(
            lblTituloPoster);

            panel.Controls.Add(
            lblGenero);

            panel.Controls.Add(
            lblInfo);

            flowPeliculas.Controls
            .Add(panel);
        }

        private void Poster_Click( object sender, EventArgs e)
        {
            Control control =
            (Control)sender;

            DataRow fila =
            (DataRow)control.Tag;

            MostrarPelicula(
            fila);
        }

        private void MostrarPelicula(
        DataRow fila)
        {
            try
            {
                if (fila == null)
                {
                    LimpiarDetallePelicula();

                    return;
                }

                pnlDetalle.Visible = true;

                idPeliculaSeleccionada =
                Convert.ToInt32(
                fila["IdPelicula"]);

                lblTitulo.Text =
                fila["Titulo"]
                .ToString();

                lblDuracion.Text =
                "Duración: " +
                fila["Duracion"]
                .ToString()
                + " min";

                lblClasificacion.Text =
                "Clasificación: " +
                fila["Clasificacion"]
                .ToString();

                txtSinopsis.Text =
                fila["Sinopsis"]
                .ToString();

                lblFechaEstreno.Text =
                Convert.ToDateTime(
                fila["FechaInicio"])
                .ToString(
                "dd/MM/yyyy");

                lblDisponible.Text =
                Convert.ToDateTime(
                fila["FechaFinalizacion"])
                .ToString(
                "dd/MM/yyyy");

                DateTime fechaInicio =
                Convert.ToDateTime(
                fila["FechaInicio"]);

                DateTime fechaFinal =
                Convert.ToDateTime(
                fila["FechaFinalizacion"]);

                DateTime hoy =
                DateTime.Today;

                if (fechaInicio > hoy)
                {
                    lblEstado.Text =
                    "PRÓXIMAMENTE";

                    lblEstado.ForeColor =
                    Color.Blue;
                }
                else if (
                    fechaInicio >= hoy.AddDays(-7))
                {
                    lblEstado.Text =
                    "ESTRENO";

                    lblEstado.ForeColor =
                    Color.Green;
                }
                else if (
                    fechaFinal >= hoy)
                {
                    lblEstado.Text =
                    "EN CARTELERA";

                    lblEstado.ForeColor =
                    Color.DarkOrange;
                }
                else
                {
                    lblEstado.Text =
                    "FINALIZADA";

                    lblEstado.ForeColor =
                    Color.Red;
                }

                imagenSeleccionada =
                fila["Imagen"]
                .ToString();

                if (
                    !string.IsNullOrWhiteSpace(
                    imagenSeleccionada)

                    &&

                    File.Exists(
                    imagenSeleccionada))
                {
                    picPoster.Image =
                    Image.FromFile(
                    imagenSeleccionada);
                }
                else
                {
                    picPoster.Image =
                    null;
                }

                btnComprar.Enabled = true;
            }
            catch (Exception ex)
            {
                LimpiarDetallePelicula();

                MessageBox.Show(
                "Error al mostrar la película.\n\n"
                + ex.Message,
                "CINEPELIS",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }



        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (idPeliculaSeleccionada <= 0)
            {
                MessageBox.Show(
                "Seleccione una película");

                return;
            }

            FrmVentaEntradas frm =
            new FrmVentaEntradas();

            frm.IdPeliculaSeleccionada =
            idPeliculaSeleccionada;

            frm.ShowDialog();
        }

        private void CargarCiudades()
        {
            DataTable dt =
            cine.ListarCiudades();

            cboCiudad.Items.Clear();

            cboCiudad.Items.Add(
            "Todas");

            foreach (DataRow fila
                in dt.Rows)
            {
                cboCiudad.Items.Add(
                fila["Ciudad"]
                .ToString());
            }

            cboCiudad.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            string ciudad = "";

            int idCine = 0;

            string clasificacion = "";

            string genero = "";

            string periodo =
            ObtenerPeriodo();

            if (cboCiudad.Text != "Todas")
            {
                ciudad =
                cboCiudad.Text;
            }

            if (cboCine.SelectedValue != null
                &&
                int.TryParse(
                cboCine.SelectedValue
                .ToString(),
                out int cineSeleccionado))
            {
                idCine =
                cineSeleccionado;
            }

            if (cboClasificacion.Text
                != "Todas")
            {
                clasificacion =
                cboClasificacion.Text;
            }

            if (cboGenero.Text
                != "Todos")
            {
                genero =
                cboGenero.Text;
            }

            DataTable dt =
            cartelera
            .FiltrarCarteleraFecha(
            ciudad,
            idCine,
            clasificacion,
            genero,
            periodo);

            flowPeliculas.Controls.Clear();

            if (dt == null ||
                dt.Rows.Count == 0)
            {
                LimpiarDetallePelicula();

                return;
            }

            foreach (DataRow fila
                in dt.Rows)
            {
                CrearPoster(fila);
            }

            MostrarPelicula(
            dt.Rows[0]);

            btnComprar.Enabled = true;
        }

        private void CargarGeneros()
        {
            DataTable dt =
            pelicula.ListarGeneros();

            cboGenero.Items.Clear();

            cboGenero.Items.Add(
            "Todos");

            foreach (DataRow fila
                in dt.Rows)
            {
                cboGenero.Items.Add(
                fila["Genero"]
                .ToString());
            }

            cboGenero.SelectedIndex = 0;
        }

        private void CargarClasificaciones()
        {
            DataTable dt =
            pelicula
            .ListarClasificaciones();

            cboClasificacion.Items.Clear();

            cboClasificacion.Items.Add(
            "Todas");

            foreach (DataRow fila
                in dt.Rows)
            {
                cboClasificacion.Items.Add(
                fila["Clasificacion"]
                .ToString());
            }

            cboClasificacion.SelectedIndex = 0;
        }

        private void CargarCines()
        {
            DataTable dt =
            new DataTable();

            dt.Columns.Add(
            "IdCine",
            typeof(int));

            dt.Columns.Add(
            "Nombre");

            DataRow filaTodos =
            dt.NewRow();

            filaTodos["IdCine"] = 0;

            filaTodos["Nombre"] = "Todos";

            dt.Rows.Add(
            filaTodos);

            if (cboCiudad.Text != "Todas")
            {
                DataTable dtCines =
                cine.ListarCinesPorCiudad(
                cboCiudad.Text);

                foreach (DataRow fila
                    in dtCines.Rows)
                {
                    dt.ImportRow(
                    fila);
                }
            }

            cboCine.DataSource =
            dt;

            cboCine.DisplayMember =
            "Nombre";

            cboCine.ValueMember =
            "IdCine";

            cboCine.SelectedValue = 0;
        }

        private void cboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCines();

            AplicarFiltros();
        }

        private void cboCine_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cboClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private string ObtenerPeriodo()
        {
            if (rbHoy.Checked)
                return "HOY";

            if (rbManana.Checked)
                return "MANANA";

            if (rbEstaSemana.Checked)
                return "ESTASEMANA";

            if (rbProximamente.Checked)
                return "PROXIMAMENTE";

            return "";
        }


        private void rbHoy_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void rbManana_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void rbEstaSemana_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void rbProximamente_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cboCiudad.SelectedIndex = 0;

            cboGenero.SelectedIndex = 0;

            cboClasificacion.SelectedIndex = 0;

            rbHoy.Checked = false;

            rbManana.Checked = false;

            rbEstaSemana.Checked = false;

            rbProximamente.Checked = false;

            CargarPeliculas();
        }

        private void LimpiarDetallePelicula()
        {
            idPeliculaSeleccionada = 0;

            imagenSeleccionada = "";

            picPoster.Image = null;

            pnlDetalle.Visible = false;

            lblTitulo.Text = "";

            lblDuracion.Text = "";

            lblClasificacion.Text = "";

            lblEstado.Text = "";

            lblFechaEstreno.Text = "";

            lblDisponible.Text = "";

            txtSinopsis.Clear();

            btnComprar.Enabled = false;
        }

        private void lblDuracion_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaEstreno_Click(object sender, EventArgs e)
        {

        }

        private void lblDisponible_Click(object sender, EventArgs e)
        {

        }

        private void lblClasificacion_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
