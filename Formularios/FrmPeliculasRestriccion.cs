using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmPeliculasRestriccion : Form
    {
        public FrmPeliculasRestriccion()
        {
            InitializeComponent();
        }

       
        private void FrmPeliculasRestriccion_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            CargarRestriccion();
        }

        // MÉTODO PARA FILTRAR SOLO 18+
        private void CargarRestriccion(string texto = "")
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Peliculas WHERE Clasificacion = '+18' AND Activo = 1";

                if (!string.IsNullOrEmpty(texto))
                {
                    query += " AND Titulo LIKE @texto";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                if (!string.IsNullOrEmpty(texto))
                {
                    da.SelectCommand.Parameters.AddWithValue("@texto", "%" + texto + "%");
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                MostrarPeliculas(dt);
            }
        }

        // TARJETAS
        private void MostrarPeliculas(DataTable dt)
        {
            flpPeliculasRestriccion.Controls.Clear();

            if (dt.Rows.Count == 0)
            {
                Label lbl = new Label();
                lbl.Text = "No hay películas restringidas";
                lbl.ForeColor = Color.Red;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Margin = new Padding(20);

                flpPeliculasRestriccion.Controls.Add(lbl);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Panel card = new Panel();
                card.Width = 180;
                card.Height = 300;
                card.BackColor = Color.White;
                card.Margin = new Padding(15);
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Padding = new Padding(5);
                card.Cursor = Cursors.Hand;

                // IMAGEN
                PictureBox pic = new PictureBox();
                pic.Width = 160;
                pic.Height = 200;
                pic.Top = 10;
                pic.Left = 10;
                pic.SizeMode = PictureBoxSizeMode.Zoom;

                string rutaImagen = Path.Combine(Application.StartupPath, row["Imagen"].ToString());

                if (File.Exists(rutaImagen))
                {
                    pic.ImageLocation = rutaImagen;
                }
                else
                {
                    pic.Image = Properties.Resources.cinepelis;
                }

                // TÍTULO
                Label lblTitulo = new Label();
                lblTitulo.Text = row["Titulo"].ToString();
                lblTitulo.Top = 215;
                lblTitulo.Left = 10;
                lblTitulo.Width = 160;
                lblTitulo.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // DETALLE
                Label lblDetalle = new Label();
                lblDetalle.Text =
                    row["Genero"].ToString() + ", " +
                    row["Duracion"].ToString() + " min, " +
                    row["Clasificacion"].ToString();

                lblDetalle.Top = 240;
                lblDetalle.Left = 10;
                lblDetalle.Width = 160;
                lblDetalle.Font = new Font("Segoe UI", 8);

                // ETIQUETA 18+
                Label lbl18 = new Label();
                lbl18.Text = "18+";
                lbl18.BackColor = Color.Black;
                lbl18.ForeColor = Color.White;
                lbl18.AutoSize = true;
                lbl18.Padding = new Padding(5);
                lbl18.Left = 0;
                lbl18.Top = 0;

                card.Controls.Add(lbl18);

                // EFECTO HOVER
                card.MouseEnter += (s, e) =>
                {
                    card.BackColor = Color.LightGray;
                };

                card.MouseLeave += (s, e) =>
                {
                    card.BackColor = Color.White;
                };

                // CLICK
                card.Click += (s, e) =>
                {
                    Pelicula peli = new Pelicula();
                    peli.idPelicula = Convert.ToInt32(row["IdPelicula"]);
                    peli.titulo = row["Titulo"].ToString();
                    peli.genero = row["Genero"].ToString();
                    peli.duracion = Convert.ToInt32(row["Duracion"]);
                    peli.clasificacion = row["Clasificacion"].ToString();
                    peli.sinopsis = row["Sinopsis"].ToString();
                    peli.estreno = Convert.ToInt32(row["Estreno"]);
                    peli.activo = Convert.ToInt32(row["Activo"]);
                    peli.imagen = row["Imagen"].ToString();

                    new FrmDetallePelicula(peli).ShowDialog();
                };

                pic.Click += (s, e) =>
                {
                    Pelicula peli = new Pelicula();
                    peli.idPelicula = Convert.ToInt32(row["IdPelicula"]);
                    peli.titulo = row["Titulo"].ToString();
                    peli.genero = row["Genero"].ToString();
                    peli.duracion = Convert.ToInt32(row["Duracion"]);
                    peli.clasificacion = row["Clasificacion"].ToString();
                    peli.sinopsis = row["Sinopsis"].ToString();
                    peli.estreno = Convert.ToInt32(row["Estreno"]);
                    peli.activo = Convert.ToInt32(row["Activo"]);
                    peli.imagen = row["Imagen"].ToString();

                    new FrmDetallePelicula(peli).ShowDialog();
                };

                // AGREGAR CONTROLES
                card.Controls.Add(pic);
                card.Controls.Add(lblTitulo);
                card.Controls.Add(lblDetalle);

                flpPeliculasRestriccion.Controls.Add(card);
            }
        }

        // BUSCADOR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarRestriccion(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarRestriccion(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmVentaEntradas frm = new FrmVentaEntradas();
            frm.ShowDialog();
        }
    }
}