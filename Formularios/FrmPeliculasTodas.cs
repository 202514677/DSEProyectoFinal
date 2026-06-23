using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DSEProyectoFinal.Clases;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmPeliculasTodas : Form
    {
        public FrmPeliculasTodas()
        {
            InitializeComponent();
        }

        //CARGA AUTOMÁTICA AL ABRIR
        private void FrmPeliculasTodas_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 240, 240);
            CargarTodas();
        }

        //MÉTODO PARA CARGAR TODAS LAS PELÍCULAS
        private void CargarTodas(string texto = "")
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT * FROM Peliculas WHERE Activo = 1";

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

        //MÉTODO PARA MOSTRAR TARJETAS
        private void MostrarPeliculas(DataTable dt)
        {
            flpPeliculasTodas.Controls.Clear();

            if (dt.Rows.Count == 0)
            {
                Label lbl = new Label();
                lbl.Text = "Película no encontrada";
                lbl.ForeColor = Color.Red;
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.AutoSize = true;
                lbl.Margin = new Padding(20);

                flpPeliculasTodas.Controls.Add(lbl);
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

                //IMAGEN
                PictureBox pic = new PictureBox();
                pic.Width = 160;
                pic.Height = 200;
                pic.Top = 10;
                pic.Left = 10;
                pic.SizeMode = PictureBoxSizeMode.Zoom;

                string rutaImagen = Path.Combine(Application.StartupPath, row["Imagen"].ToString());

                //MessageBox.Show(rutaImagen);

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

                // ETIQUETA ESTRENO
                if (Convert.ToBoolean(row["Estreno"]) == true)
                {
                    Label lblEstreno = new Label();
                    lblEstreno.Text = "ESTRENO";
                    lblEstreno.BackColor = Color.Red;
                    lblEstreno.ForeColor = Color.White;
                    lblEstreno.AutoSize = true;
                    lblEstreno.Padding = new Padding(5);
                    lblEstreno.Left = 0;
                    lblEstreno.Top = 0;

                    card.Controls.Add(lblEstreno);
                }

                // EFECTO HOVER
                card.MouseEnter += (s, e) =>
                {
                    card.BackColor = Color.LightGray;
                };

                card.MouseLeave += (s, e) =>
                {
                    card.BackColor = Color.White;
                };

                // CLICK PARA ABRIR DETALLE
                card.Click += (s, e) =>
                {
                    Pelicula peliSeleccionada = new Pelicula();
                    peliSeleccionada.idPelicula = Convert.ToInt32(row["IdPelicula"]);
                    peliSeleccionada.titulo = row["Titulo"].ToString();
                    peliSeleccionada.genero = row["Genero"].ToString();
                    peliSeleccionada.duracion = Convert.ToInt32(row["Duracion"]);
                    peliSeleccionada.clasificacion = row["Clasificacion"].ToString();
                    peliSeleccionada.sinopsis = row["Sinopsis"].ToString();
                    peliSeleccionada.estreno = Convert.ToInt32(row["Estreno"]);
                    peliSeleccionada.activo = Convert.ToInt32(row["Activo"]);
                    peliSeleccionada.imagen = row["Imagen"].ToString();

                    new FrmDetallePelicula(peliSeleccionada).ShowDialog();
                };

                pic.Click += (s, e) =>
                {
                    Pelicula peliSeleccionada = new Pelicula();
                    peliSeleccionada.idPelicula = Convert.ToInt32(row["IdPelicula"]);
                    peliSeleccionada.titulo = row["Titulo"].ToString();
                    peliSeleccionada.genero = row["Genero"].ToString();
                    peliSeleccionada.duracion = Convert.ToInt32(row["Duracion"]);
                    peliSeleccionada.clasificacion = row["Clasificacion"].ToString();
                    peliSeleccionada.sinopsis = row["Sinopsis"].ToString();
                    peliSeleccionada.estreno = Convert.ToInt32(row["Estreno"]);
                    peliSeleccionada.activo = Convert.ToInt32(row["Activo"]);
                    peliSeleccionada.imagen = row["Imagen"].ToString();

                    new FrmDetallePelicula(peliSeleccionada).ShowDialog();
                };

                // AGREGAR CONTROLES
                card.Controls.Add(pic);
                card.Controls.Add(lblTitulo);
                card.Controls.Add(lblDetalle);

                flpPeliculasTodas.Controls.Add(card);
            }
        }

        // BUSCADOR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarTodas(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTodas(txtBuscar.Text);
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
