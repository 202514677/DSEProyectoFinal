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
using System.IO;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmDetallePelicula : Form
    {

        private Pelicula pelicula;
        public FrmDetallePelicula(Pelicula peliculaSeleccionada)
        {
            InitializeComponent();

            pelicula = peliculaSeleccionada;
        }

        private void FrmDetallePelicula_Load(
object sender,
EventArgs e)
        {
            lblTitulo.Text =
            pelicula.titulo;

            lblGenero.Text =
            pelicula.genero;

            lblDuracion.Text =
            pelicula.duracion +
            " min";

            lblClasificacion.Text =
            pelicula.clasificacion;

            txtSinopsis.Text =
            pelicula.sinopsis;

            string rutaImagen =
            Path.Combine(
            Application.StartupPath,
            pelicula.imagen);

            if (File.Exists(rutaImagen))
            {
                picPelicula.ImageLocation =
                rutaImagen;
            }
        }


    }
}
