using DSEProyectoFinal.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmCines : Form
    {
        public FrmCines()
        {
            InitializeComponent();
        }

        private void FrmCines_Load(object sender, EventArgs e)
        {
            cboCiudad.Items.Add("Lima");
            cboCiudad.Items.Add("Arequipa");
            cboCiudad.Items.Add("Cusco");
            CargarDatos();
        }

        private void Limpiar()
        {
            txtId.Clear();

            txtNombre.Clear();

            txtDireccion.Clear();

            cboCiudad.SelectedIndex = -1;

            txtNombre.Focus();
        }

        private void CargarDatos()
        {
            Cine cine = new Cine();

            dgvCines.DataSource = cine.Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del cine");
                txtNombre.Focus();
                return;
            }

            if (cboCiudad.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione una ciudad");
                cboCiudad.Focus();
                return;
            }

            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la dirección");
                txtDireccion.Focus();
                return;
            }

            Cine cine = new Cine(
                txtNombre.Text,
                cboCiudad.Text,
                txtDireccion.Text
            );

            if (cine.Registrar())
            {
                MessageBox.Show("Registro guardado correctamente");

                CargarDatos();

                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void dgvCines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCines.CurrentRow == null)
                return;

            txtId.Text =
            dgvCines.CurrentRow.Cells["IdCine"].Value.ToString();

            txtNombre.Text =
            dgvCines.CurrentRow.Cells["Nombre"].Value.ToString();

            cboCiudad.Text =
            dgvCines.CurrentRow.Cells["Ciudad"].Value.ToString();

            txtDireccion.Text =
            dgvCines.CurrentRow.Cells["Direccion"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            Cine cine = new Cine();

            cine.idCine =
            Convert.ToInt32(txtId.Text);

            cine.nombre =
            txtNombre.Text;

            cine.ciudad =
            cboCiudad.Text;

            cine.direccion =
            txtDireccion.Text;

            cine.activo = 1;

            if (cine.Actualizar())
            {
                MessageBox.Show("Registro actualizado");

                CargarDatos();

                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            DialogResult respuesta =
                MessageBox.Show(
                "¿Desea eliminar el registro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            Cine cine = new Cine();

            cine.idCine =
            Convert.ToInt32(txtId.Text);

            if (cine.Eliminar())
            {
                MessageBox.Show("Registro eliminado");

                CargarDatos();

                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            CargarDatos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cine cine = new Cine();

            dgvCines.DataSource =
            cine.Buscar(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cine cine = new Cine();

            dgvCines.DataSource =
            cine.Buscar(txtBuscar.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
