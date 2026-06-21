using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmCines : Form
    {
        public FrmCines()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmCines_Load(object sender, EventArgs e)
        {        
            cboCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            

            cboCiudad.Items.Add("Lima");
            cboCiudad.Items.Add("Arequipa");
            cboCiudad.Items.Add("Cusco");
            CargarDatos();
            ModoNuevo();
            dgvCines.ClearSelection();
        }

        private void Limpiar()
        {
            txtId.Clear();

            txtNombre.Clear();

            txtDireccion.Clear();

            txtGoogleMaps.Clear();

            txtImagen.Clear();

            txtSalas2D.Clear();

            txtSalas3D.Clear();

            txtSalas4K.Clear();

            txtSalasPrime.Clear();

            txtSalasEventos.Clear();

            txtBuscar.Clear();

            cboCiudad.SelectedIndex = -1;            

            chkActivo.Checked = true;

            picPelicula.Image = null;

            txtNombre.Focus();
        }

        private void CargarDatos()
        {
            Cine cine = new Cine();

            dgvCines.DataSource = cine.Listar();

            dgvCines.Columns["IdCine"].Visible = false;
            dgvCines.Columns["GoogleMaps"].Visible = false;
            dgvCines.Columns["Imagen"].Visible = false;
            dgvCines.Columns["IdUsuario"].Visible = false;

            if (dgvCines.Columns.Contains("FechaRegistro"))
            {
                dgvCines.Columns["FechaRegistro"].Visible = false;
            }

            if (dgvCines.Columns.Contains("FechaActualizacion"))
            {
                dgvCines.Columns["FechaActualizacion"].Visible = false;
            }
                  
            dgvCines.ClearSelection();

            lblTotalCines.Text = "Total Cines: " + dgvCines.Rows.Count;
        }

        private void btnGuardar_Click( object sender, EventArgs e)
        {
            // Validar Nombre

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese el nombre del cine");

                txtNombre.Focus();

                return;
            }

            if (txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show(
                "El nombre debe tener al menos 3 caracteres");

                txtNombre.Focus();

                return;
            }

            // Validar Ciudad

            if (cboCiudad.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione una ciudad");

                cboCiudad.Focus();

                return;
            }

            // Validar Dirección

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese la dirección");

                txtDireccion.Focus();

                return;
            }

            if (txtDireccion.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                "Ingrese una dirección válida");

                txtDireccion.Focus();

                return;
            }

            // Si dejan vacías las cantidades de salas
            // automáticamente colocar 0

            if (txtSalas2D.Text.Trim() == "")
                txtSalas2D.Text = "0";

            if (txtSalas3D.Text.Trim() == "")
                txtSalas3D.Text = "0";

            if (txtSalas4K.Text.Trim() == "")
                txtSalas4K.Text = "0";

            if (txtSalasPrime.Text.Trim() == "")
                txtSalasPrime.Text = "0";

            if (txtSalasEventos.Text.Trim() == "")
                txtSalasEventos.Text = "0";

            // Validar que exista al menos una sala

            int totalSalas =
            Convert.ToInt32(txtSalas2D.Text)
            +
            Convert.ToInt32(txtSalas3D.Text)
            +
            Convert.ToInt32(txtSalas4K.Text)
            +
            Convert.ToInt32(txtSalasPrime.Text)
            +
            Convert.ToInt32(txtSalasEventos.Text);

            if (totalSalas <= 0)
            {
                MessageBox.Show(
                "Debe registrar al menos una sala");

                return;
            }

            // Validar nombre duplicado

            Cine cineValidacion =
            new Cine();

            if (cineValidacion.ExisteNombre(txtNombre.Text.Trim()))
            {
                MessageBox.Show(
                "Ya existe un cine con ese nombre");

                txtNombre.Focus();

                return;
            }

            if (txtGoogleMaps.Text.Trim() != "")
            {
                if (!txtGoogleMaps.Text.ToLower().Contains("google"))
                {
                    MessageBox.Show(
                    "Ingrese un enlace válido de Google Maps");

                    txtGoogleMaps.Focus();

                    return;
                }
            }

            if (txtGoogleMaps.Text.Trim() != "")
            {
                if (cineValidacion.ExisteGoogleMaps(txtGoogleMaps.Text.Trim()))
                {
                    MessageBox.Show(
                    "Ya existe un cine con esa ubicación de Google Maps");

                    txtGoogleMaps.Focus();

                    return;
                }
            }

            if (txtImagen.Text.Trim() != "")
            {
                if (
                   !txtImagen.Text.ToLower().EndsWith(".jpg")
                   &&
                   !txtImagen.Text.ToLower().EndsWith(".jpeg")
                   &&
                   !txtImagen.Text.ToLower().EndsWith(".png")
                   )
                {
                    MessageBox.Show(
                    "La imagen debe ser JPG o PNG");

                    txtImagen.Focus();

                    return;
                }
            }

            // Crear objeto

            Cine cine = new Cine();

            cine.nombre =
            txtNombre.Text.Trim();

            cine.ciudad =
            cboCiudad.Text;

            cine.direccion =
            txtDireccion.Text.Trim();

            cine.googleMaps =
            txtGoogleMaps.Text.Trim();

            cine.imagen =
            txtImagen.Text.Trim();

            cine.salas2D =
            Convert.ToInt32(txtSalas2D.Text);

            cine.salas3D =
            Convert.ToInt32(txtSalas3D.Text);

            cine.salas4K =
            Convert.ToInt32(txtSalas4K.Text);

            cine.salasPrime =
            Convert.ToInt32(txtSalasPrime.Text);

            cine.salasEventos =
            Convert.ToInt32(txtSalasEventos.Text);

            cine.IdUsuario = 1; // Pendiente de crear FrmUsuarios

            cine.activo =
            chkActivo.Checked ? 1 : 0;

            // Guardar

            if (cine.Registrar())
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

        private void dgvCines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarRegistro();
            
        }

        private void btnEditar_Click( object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro para editar");

                return;
            }

            // Validar Nombre

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese el nombre del cine");

                txtNombre.Focus();

                return;
            }

            if (txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show(
                "El nombre debe tener al menos 3 caracteres");

                txtNombre.Focus();

                return;
            }

            // Validar Ciudad

            if (cboCiudad.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione una ciudad");

                cboCiudad.Focus();

                return;
            }

            // Validar Dirección

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese la dirección");

                txtDireccion.Focus();

                return;
            }

            if (txtDireccion.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                "Ingrese una dirección válida");

                txtDireccion.Focus();

                return;
            }

            Cine cineValidacion = new Cine();

            if (cineValidacion.ExisteNombreEdicion(txtNombre.Text.Trim(), Convert.ToInt32(txtId.Text)))
            {
                MessageBox.Show(
                "Ya existe otro cine con ese nombre");

                txtNombre.Focus();

                return;
            }

            if (txtGoogleMaps.Text.Trim() != "")
            {
                if (cineValidacion.ExisteGoogleMapsEdicion(
                    txtGoogleMaps.Text.Trim(),
                    Convert.ToInt32(txtId.Text)))
                {
                    MessageBox.Show(
                    "Ya existe otro cine con esa ubicación de Google Maps");

                    txtGoogleMaps.Focus();

                    return;
                }
            }

            if (txtGoogleMaps.Text.Trim() != "")
            {
                if (!txtGoogleMaps.Text.Contains("google"))
                {
                    MessageBox.Show(
                    "Ingrese un enlace válido de Google Maps");

                    txtGoogleMaps.Focus();

                    return;
                }
            }


            // Completar valores vacíos

            if (txtSalas2D.Text.Trim() == "")
                txtSalas2D.Text = "0";

            if (txtSalas3D.Text.Trim() == "")
                txtSalas3D.Text = "0";

            if (txtSalas4K.Text.Trim() == "")
                txtSalas4K.Text = "0";

            if (txtSalasPrime.Text.Trim() == "")
                txtSalasPrime.Text = "0";

            if (txtSalasEventos.Text.Trim() == "")
                txtSalasEventos.Text = "0";

            // Validar total de salas

            int totalSalas =
            Convert.ToInt32(txtSalas2D.Text)
            +
            Convert.ToInt32(txtSalas3D.Text)
            +
            Convert.ToInt32(txtSalas4K.Text)
            +
            Convert.ToInt32(txtSalasPrime.Text)
            +
            Convert.ToInt32(txtSalasEventos.Text);

            if (totalSalas <= 0)
            {
                MessageBox.Show(
                "Debe registrar al menos una sala");

                return;
            }

            if (txtImagen.Text.Trim() != "")
            {
                if (
                   !txtImagen.Text.ToLower().EndsWith(".jpg")
                   &&
                   !txtImagen.Text.ToLower().EndsWith(".jpeg")
                   &&
                   !txtImagen.Text.ToLower().EndsWith(".png")
                   )
                {
                    MessageBox.Show(
                    "La imagen debe ser JPG o PNG");

                    txtImagen.Focus();

                    return;
                }
            }

            // Crear objeto

            Cine cine = new Cine();

            cine.idCine =
            Convert.ToInt32(txtId.Text);

            cine.nombre =
            txtNombre.Text.Trim();

            cine.ciudad =
            cboCiudad.Text;

            cine.direccion =
            txtDireccion.Text.Trim();

            cine.googleMaps =
            txtGoogleMaps.Text.Trim();

            cine.imagen =
            txtImagen.Text.Trim();

            cine.salas2D =
            Convert.ToInt32(txtSalas2D.Text);

            cine.salas3D =
            Convert.ToInt32(txtSalas3D.Text);

            cine.salas4K =
            Convert.ToInt32(txtSalas4K.Text);

            cine.salasPrime =
            Convert.ToInt32(txtSalasPrime.Text);

            cine.salasEventos =
            Convert.ToInt32(txtSalasEventos.Text);

            cine.IdUsuario = 1;

            //cine.IdUsuario = Convert.ToInt32(cboUsuarios.SelectedValue);

            cine.activo =
            chkActivo.Checked ? 1 : 0;

            // Actualizar

            if (cine.Actualizar())
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
                "Seleccione un registro para eliminar");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(
            "¿Está seguro de desactivar el cine?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            Cine cine = new Cine();

            cine.idCine =
            Convert.ToInt32(txtId.Text);

            if (cine.Eliminar())
            {
                MessageBox.Show(
                "Cine desactivado correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al desactivar");
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            dgvCines.ClearSelection();

            txtId.Clear();

            ModoNuevo();

            txtNombre.Focus();
        }

        private void btnBuscar_Click( object sender, EventArgs e)
        {
            Cine cine = new Cine();

            dgvCines.DataSource =
            cine.Buscar(txtBuscar.Text);

            if (dgvCines.Rows.Count > 0)
            {
                dgvCines.Rows[0].Selected = true;

                CargarRegistro();
            }
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e)
        {
            Cine cine = new Cine();

            dgvCines.DataSource =
            cine.Buscar(
            txtBuscar.Text.Trim());

            if (dgvCines.Rows.Count > 0)
            {
                dgvCines.Rows[0].Selected = true;

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

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CargarRegistro()
        {
            if (dgvCines.CurrentRow == null)
            {
                return;
            }

            txtId.Text =
            dgvCines.CurrentRow.Cells["IdCine"]
            .Value.ToString();

            txtNombre.Text =
            dgvCines.CurrentRow.Cells["Nombre"]
            .Value.ToString();

            cboCiudad.Text =
            dgvCines.CurrentRow.Cells["Ciudad"]
            .Value.ToString();

            txtDireccion.Text =
            dgvCines.CurrentRow.Cells["Direccion"]
            .Value.ToString();

            txtGoogleMaps.Text =
            dgvCines.CurrentRow.Cells["GoogleMaps"]
            .Value.ToString();

            txtImagen.Text =
            dgvCines.CurrentRow.Cells["Imagen"]
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

            txtSalas2D.Text =
            dgvCines.CurrentRow.Cells["CantidadSalas2D"]
            .Value.ToString();

            txtSalas3D.Text =
            dgvCines.CurrentRow.Cells["CantidadSalas3D"]
            .Value.ToString();

            txtSalas4K.Text =
            dgvCines.CurrentRow.Cells["CantidadSalas4K"]
            .Value.ToString();

            txtSalasPrime.Text =
            dgvCines.CurrentRow.Cells["CantidadSalasPrime"]
            .Value.ToString();

            txtSalasEventos.Text =
            dgvCines.CurrentRow.Cells["CantidadSalasEventos"]
            .Value.ToString();

            // cboUsuarios.SelectedValue =
            // dgvCines.CurrentRow.Cells["IdUsuario"].Value;

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvCines.CurrentRow.Cells["Activo"]
            .Value);

            if (!chkActivo.Checked)
            {
                btnEliminar.Enabled = false;
            }

            ModoEdicion();
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
