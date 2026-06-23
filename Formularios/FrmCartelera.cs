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
    public partial class FrmCartelera : Form
    {
        private Cartelera carteleraActual = new Cartelera();
        public FrmCartelera()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmCartelera_Load( object sender, EventArgs e)
        {
            cboPelicula.DropDownStyle =
            ComboBoxStyle.DropDownList;

            CargarCines();

            CargarPeliculas();

            CargarDatos();

            ModoNuevo();

            Limpiar();

            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true;
        }

        private void CargarPeliculas()
        {
            Pelicula pelicula =
            new Pelicula();

            cboPelicula.DataSource =
            pelicula.Listar();

            cboPelicula.DisplayMember =
            "Titulo";

            cboPelicula.ValueMember =
            "IdPelicula";

            cboPelicula.SelectedIndex = -1;
        }

        private void CargarDatos()
        {
            Cartelera cartelera =
            new Cartelera();

            dgvCartelera.DataSource =
            cartelera.Listar();

            if (dgvCartelera.Columns.Contains("IdCartelera"))
                dgvCartelera.Columns["IdCartelera"].Visible = false;

            if (dgvCartelera.Columns.Contains("IdPelicula"))
                dgvCartelera.Columns["IdPelicula"].Visible = false;

            if (dgvCartelera.Columns.Contains("Imagen"))
                dgvCartelera.Columns["Imagen"].Visible = false;

            if (dgvCartelera.Columns.Contains("FechaRegistro"))
                dgvCartelera.Columns["FechaRegistro"].Visible = false;

            if (dgvCartelera.Columns.Contains("FechaActualizacion"))
                dgvCartelera.Columns["FechaActualizacion"].Visible = false;

            dgvCartelera.ClearSelection();

            lblTotalCarteleras.Text = "Total Carteleras: " + dgvCartelera.Rows.Count;
        }
        private void Limpiar()
        {
            txtId.Clear();

            txtBuscar.Clear();

            cboPelicula.SelectedIndex = -1;

            cboCine.SelectedIndex = -1;

            dtpFechaInicio.Value =
            DateTime.Today;

            dtpFechaFinalizacion.Value =
            DateTime.Today;

            dtpHora.Value = DateTime.Now;

            chkActivo.Checked = true;

            picPelicula.Image = null;
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

        private void MostrarImagen()
        {
            if (dgvCartelera.CurrentRow == null)
            {
                picPelicula.Image = null;
                return;
            }

            if (dgvCartelera.CurrentRow.Cells["Imagen"].Value == null)
            {
                picPelicula.Image = null;
                return;
            }

            string ruta =
            dgvCartelera.CurrentRow.Cells["Imagen"]
            .Value.ToString();

            if (ruta.Trim() == "")
            {
                picPelicula.Image = null;
                return;
            }

            if (File.Exists(ruta))
            {
                try
                {
                    picPelicula.Image =
                    Image.FromFile(ruta);
                }
                catch
                {
                    picPelicula.Image = null;
                }
            }
            else
            {
                picPelicula.Image = null;
            }
        }

        private void CargarRegistro()
        {
            if (dgvCartelera.CurrentRow == null)
                return;

            txtId.Text =
            dgvCartelera.CurrentRow.Cells["IdCartelera"]
            .Value.ToString();

            cboCine.SelectedValue =
            dgvCartelera.CurrentRow
            .Cells["IdCine"]
            .Value;

            cboPelicula.SelectedValue =
            dgvCartelera.CurrentRow.Cells["IdPelicula"]
            .Value;

            dtpFechaInicio.Value =
            Convert.ToDateTime(
            dgvCartelera.CurrentRow.Cells["FechaInicio"]
            .Value);

            dtpFechaFinalizacion.Value =
            Convert.ToDateTime(
            dgvCartelera.CurrentRow.Cells["FechaFinalizacion"]
            .Value);

            if (dgvCartelera.CurrentRow.Cells["HoraProyeccion"].Value != DBNull.Value)
            {
                dtpHora.Value =
                DateTime.Today.Add(
                (TimeSpan)dgvCartelera.CurrentRow
                .Cells["HoraProyeccion"].Value);
            }


            chkActivo.Checked =
            Convert.ToBoolean(
            dgvCartelera.CurrentRow.Cells["Activo"]
            .Value);

            MostrarImagen();

            ModoEdicion();
        }

        private void dgvCartelera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarRegistro();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            dgvCartelera.ClearSelection();

            ModoNuevo();

            cboPelicula.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboPelicula.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione una película");

                cboPelicula.Focus();

                return;
            }

            if (dtpFechaFinalizacion.Value.Date <
                dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                "La fecha final no puede ser menor que la fecha inicial");

                return;
            }

            Cartelera validacion = new Cartelera();

            if (validacion.ExisteCarteleraActiva(
     Convert.ToInt32(cboCine.SelectedValue),
     Convert.ToInt32(cboPelicula.SelectedValue),
     dtpFechaInicio.Value.Date,
     dtpFechaFinalizacion.Value.Date))
            {
                MessageBox.Show(
                "La película ya tiene una cartelera activa en esas fechas para ese cine");

                return;
            }

            Cartelera cartelera = new Cartelera();

            cartelera.idCine =
            Convert.ToInt32(
            cboCine.SelectedValue);

            cartelera.idPelicula =
            Convert.ToInt32(
            cboPelicula.SelectedValue);

            cartelera.fechaInicio =
            dtpFechaInicio.Value.Date;

            cartelera.fechaFinalizacion =
            dtpFechaFinalizacion.Value.Date;

            cartelera.horaProyeccion =
            dtpHora.Value.TimeOfDay;

            cartelera.activo =
            chkActivo.Checked ? 1 : 0;

            if (cartelera.Registrar())
            {
                MessageBox.Show(
                "Cartelera registrada correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al guardar");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            if (dtpFechaFinalizacion.Value.Date <
                dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                "La fecha final no puede ser menor que la fecha inicial");

                return;
            }

            Cartelera validacion = new Cartelera();

            if (validacion.ExisteCarteleraActivaEdicion(
    Convert.ToInt32(txtId.Text),
    Convert.ToInt32(cboCine.SelectedValue),
    Convert.ToInt32(cboPelicula.SelectedValue),
    dtpFechaInicio.Value.Date,
    dtpFechaFinalizacion.Value.Date))
            {
                MessageBox.Show(
                "La película ya tiene otra cartelera activa en esas fechas para ese cine");

                return;
            }

            Cartelera cartelera =
            new Cartelera();

            cartelera.idCartelera =
            Convert.ToInt32(
            txtId.Text);

            cartelera.idCine =
            Convert.ToInt32(
            cboCine.SelectedValue);

            cartelera.idPelicula =
            Convert.ToInt32(
            cboPelicula.SelectedValue);

            cartelera.fechaInicio =
            dtpFechaInicio.Value.Date;

            cartelera.fechaFinalizacion =
            dtpFechaFinalizacion.Value.Date;

            cartelera.horaProyeccion =
            dtpHora.Value.TimeOfDay;
            

            cartelera.activo =
            chkActivo.Checked ? 1 : 0;

            if (cartelera.Actualizar())
            {
                MessageBox.Show(
                "Registro actualizado");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(
            "¿Desea desactivar esta cartelera?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            Cartelera cartelera =
            new Cartelera();

            cartelera.idCartelera =
            Convert.ToInt32(
            txtId.Text);

            if (cartelera.Eliminar())
            {
                MessageBox.Show(
                "Cartelera desactivada");

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
            Cartelera cartelera =   new Cartelera();

            dgvCartelera.DataSource =
            cartelera.Buscar(
            txtBuscar.Text.Trim());

            if (dgvCartelera.Rows.Count > 0)
            {
                dgvCartelera.Rows[0].Selected = true;

                CargarRegistro();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cartelera cartelera =  new Cartelera();

            dgvCartelera.DataSource =
            cartelera.Buscar(
            txtBuscar.Text.Trim());

            if (dgvCartelera.Rows.Count > 0)
            {
                dgvCartelera.Rows[0].Selected = true;

                CargarRegistro();
            }
            else
            {
                btnNuevo.PerformClick();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarCines()
        {
            Cine cine =
            new Cine();

            cboCine.DataSource =
            cine.Listar();

            cboCine.DisplayMember =
            "Nombre";

            cboCine.ValueMember =
            "IdCine";

            cboCine.SelectedIndex = -1;
        }
    }
}
