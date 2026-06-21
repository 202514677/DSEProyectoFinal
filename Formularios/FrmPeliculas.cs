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
    public partial class FrmPeliculas : Form
    {
        public FrmPeliculas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPeliculas_Load(object sender, EventArgs e)
        {
            CargarDatos();

            ModoNuevo();

            chkActivo.Checked = true;
        }

        private void Limpiar()
        {
            txtId.Clear();

            txtTitulo.Clear();

            txtDuracion.Clear();

            txtIdioma.Clear();

            txtImagen.Clear();

            txtBuscar.Clear();

            cboGenero.SelectedIndex = -1;

            cboClasificacion.SelectedIndex = -1;

            rtbSinopsis.Clear();

            chkEstreno.Checked = false;

            chkActivo.Checked = true;

            dtpFechaIngreso.Value =
            DateTime.Today;

            dtpFechaSalida.Value =
            DateTime.Today;

            picPelicula.Image = null;

            txtTitulo.Focus();
        }

        private void CargarDatos()
        {
            Pelicula pelicula =
            new Pelicula();

            dgvPeliculas.DataSource =
            pelicula.Listar();

            if (dgvPeliculas.Columns.Contains("IdPelicula"))
                dgvPeliculas.Columns["IdPelicula"].Visible = false;

            if (dgvPeliculas.Columns.Contains("Imagen"))
                dgvPeliculas.Columns["Imagen"].Visible = false;

            if (dgvPeliculas.Columns.Contains("FechaRegistro"))
                dgvPeliculas.Columns["FechaRegistro"].Visible = false;

            if (dgvPeliculas.Columns.Contains("FechaActualizacion"))
                dgvPeliculas.Columns["FechaActualizacion"].Visible = false;

            dgvPeliculas.ClearSelection();

            lblTotalPeliculas.Text = "Total Películas: " + dgvPeliculas.Rows.Count;
        }

        private void ModoNuevo()
        {
            btnGuardar.Enabled = true;

            btnEditar.Enabled = false;

            btnEliminar.Enabled = false;
        }

        private void ModoEdicion()
        {
            btnGuardar.Enabled = false;

            btnEditar.Enabled = true;

            btnEliminar.Enabled = true;
        }

        private void CargarRegistro()
        {
            if (dgvPeliculas.CurrentRow == null)
            {
                return;
            }

            txtId.Text =
            dgvPeliculas.CurrentRow.Cells["IdPelicula"]
            .Value.ToString();

            txtTitulo.Text =
            dgvPeliculas.CurrentRow.Cells["Titulo"]
            .Value.ToString();

            cboGenero.Text =
            dgvPeliculas.CurrentRow.Cells["Genero"]
            .Value.ToString();

            txtDuracion.Text =
            dgvPeliculas.CurrentRow.Cells["Duracion"]
            .Value.ToString();

            cboClasificacion.Text =
            dgvPeliculas.CurrentRow.Cells["Clasificacion"]
            .Value.ToString();

            rtbSinopsis.Text =
            dgvPeliculas.CurrentRow.Cells["Sinopsis"]
            .Value.ToString();

            chkEstreno.Checked =
            Convert.ToBoolean(
            dgvPeliculas.CurrentRow.Cells["Estreno"]
            .Value);

            txtIdioma.Text =
            dgvPeliculas.CurrentRow.Cells["Idioma"]
            .Value.ToString();

            txtImagen.Text =
            dgvPeliculas.CurrentRow.Cells["Imagen"]
            .Value.ToString();

            if (File.Exists(txtImagen.Text))
            {
                picPelicula.Image =
                Image.FromFile(
                txtImagen.Text);
            }
            else
            {
                picPelicula.Image = null;
            }

            if (dgvPeliculas.CurrentRow.Cells["FechaIngreso"].Value != DBNull.Value)
            {
                dtpFechaIngreso.Value =
                Convert.ToDateTime(
                dgvPeliculas.CurrentRow.Cells["FechaIngreso"].Value);
            }
            else
            {
                dtpFechaIngreso.Value =
                DateTime.Today;
            }

            if (dgvPeliculas.CurrentRow.Cells["FechaSalida"].Value != DBNull.Value)
            {
                dtpFechaSalida.Value =
                Convert.ToDateTime(
                dgvPeliculas.CurrentRow.Cells["FechaSalida"].Value);
            }
            else
            {
                dtpFechaSalida.Value =
                DateTime.Today;
            }

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvPeliculas.CurrentRow.Cells["Activo"]
            .Value);

            ModoEdicion();
        }

        private void btnNuevo_Click( object sender, EventArgs e)
        {
            Limpiar();

            dgvPeliculas.ClearSelection();

            ModoNuevo();
        }

        private void btnGuardar_Click( object sender, EventArgs e)
        {
            if (txtTitulo.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese el título de la película");

                txtTitulo.Focus();

                return;
            }

            if (txtTitulo.Text.Trim().Length < 2)
            {
                MessageBox.Show(
                "Ingrese un título válido");

                txtTitulo.Focus();

                return;
            }

            if (cboGenero.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un género");

                cboGenero.Focus();

                return;
            }

            if (txtDuracion.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese la duración");

                txtDuracion.Focus();

                return;
            }

            if (Convert.ToInt32(txtDuracion.Text) < 30)
            {
                MessageBox.Show(
                "La duración debe ser mayor a 30 minutos");

                txtDuracion.Focus();

                return;
            }

            if (cboClasificacion.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione una clasificación");

                cboClasificacion.Focus();

                return;
            }

            if (rtbSinopsis.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese la sinopsis");

                rtbSinopsis.Focus();

                return;
            }

            if (rtbSinopsis.Text.Trim().Length < 20)
            {
                MessageBox.Show(
                "La sinopsis debe tener al menos 20 caracteres");

                rtbSinopsis.Focus();

                return;
            }

            if (txtIdioma.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese el idioma");

                txtIdioma.Focus();

                return;
            }

            if (dtpFechaSalida.Value.Date <
                dtpFechaIngreso.Value.Date)
            {
                MessageBox.Show(
                "La fecha de salida no puede ser menor a la fecha de ingreso");

                return;
            }

            if (txtImagen.Text.Trim() != "")
            {
                string imagen =
                txtImagen.Text.ToLower();

                if (!imagen.EndsWith(".jpg") &&
                    !imagen.EndsWith(".jpeg") &&
                    !imagen.EndsWith(".png"))
                {
                    MessageBox.Show(
                    "La imagen debe ser JPG o PNG");

                    txtImagen.Focus();

                    return;
                }
            }

            Pelicula peliculaValidacion =
            new Pelicula();

            if (peliculaValidacion.ExisteTitulo(
                txtTitulo.Text.Trim()))
            {
                MessageBox.Show(
                "Ya existe una película con ese título");

                txtTitulo.Focus();

                return;
            }

            Pelicula pelicula =
            new Pelicula();

            pelicula.titulo =
            txtTitulo.Text.Trim();

            pelicula.genero =
            cboGenero.Text;

            pelicula.duracion =
            Convert.ToInt32(
            txtDuracion.Text);

            pelicula.clasificacion =
            cboClasificacion.Text;

            pelicula.sinopsis =
            rtbSinopsis.Text.Trim();

            pelicula.estreno =
            chkEstreno.Checked ? 1 : 0;

            pelicula.idioma =
            txtIdioma.Text.Trim();

            pelicula.imagen =
            txtImagen.Text.Trim();

            pelicula.fechaIngreso =
            dtpFechaIngreso.Value.Date;

            pelicula.fechaSalida =
            dtpFechaSalida.Value.Date;

            pelicula.activo =
            chkActivo.Checked ? 1 : 0;

            if (pelicula.Registrar())
            {
                MessageBox.Show(
                "Registro guardado correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al guardar");
            }
        }

        private void dgvPeliculas_CellClick( object sender,     DataGridViewCellEventArgs e)
        {
            CargarRegistro();
        }

        private void btnEditar_Click(
object sender,
EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            Pelicula peliculaValidacion =
            new Pelicula();

            if (peliculaValidacion.ExisteTituloEdicion(
                txtTitulo.Text.Trim(),
                Convert.ToInt32(txtId.Text)))
            {
                MessageBox.Show(
                "Ya existe otra película con ese título");

                txtTitulo.Focus();

                return;
            }

            if (dtpFechaSalida.Value.Date <
                dtpFechaIngreso.Value.Date)
            {
                MessageBox.Show(
                "La fecha de salida no puede ser menor a la fecha de ingreso");

                return;
            }

            Pelicula pelicula =
            new Pelicula();

            pelicula.idPelicula =
            Convert.ToInt32(txtId.Text);

            pelicula.titulo =
            txtTitulo.Text.Trim();

            pelicula.genero =
            cboGenero.Text;

            pelicula.duracion =
            Convert.ToInt32(
            txtDuracion.Text);

            pelicula.clasificacion =
            cboClasificacion.Text;

            pelicula.sinopsis =
            rtbSinopsis.Text.Trim();

            pelicula.estreno =
            chkEstreno.Checked ? 1 : 0;

            pelicula.idioma =
            txtIdioma.Text.Trim();

            pelicula.imagen =
            txtImagen.Text.Trim();

            pelicula.fechaIngreso =
            dtpFechaIngreso.Value.Date;

            pelicula.fechaSalida =
            dtpFechaSalida.Value.Date;

            pelicula.activo =
            chkActivo.Checked ? 1 : 0;

            if (pelicula.Actualizar())
            {
                MessageBox.Show(
                "Registro actualizado correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al actualizar");
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(
            "¿Está seguro de desactivar la película?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            Pelicula pelicula =
            new Pelicula();

            pelicula.idPelicula =
            Convert.ToInt32(txtId.Text);

            if (pelicula.Eliminar())
            {
                MessageBox.Show(
                "Película desactivada correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al desactivar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Pelicula pelicula =   new Pelicula();

            dgvPeliculas.DataSource =
            pelicula.Buscar(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e)
        {
            Pelicula pelicula =
            new Pelicula();

            dgvPeliculas.DataSource =
            pelicula.Buscar(
            txtBuscar.Text.Trim());

            if (dgvPeliculas.Rows.Count > 0)
            {
                dgvPeliculas.Rows[0].Selected = true;

                CargarRegistro();
            }
            else
            {
                btnNuevo.PerformClick();
            }
        }

        private void btnSalir_Click( object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnImagen_Click( object sender, EventArgs e)
        {
            OpenFileDialog archivo =
            new OpenFileDialog();

            archivo.Title =
            "Seleccione una imagen";

            archivo.Filter =
            "Imagenes|*.jpg;*.jpeg;*.png";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text =
                archivo.FileName;

                if (File.Exists(archivo.FileName))
                {
                    picPelicula.Image =
                    Image.FromFile(
                    archivo.FileName);
                }
            }
        }
    }
}
