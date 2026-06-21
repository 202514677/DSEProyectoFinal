using DSEProyectoFinal.Clases;
using Microsoft.Win32;
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
    public partial class FrmProductosDulceria : Form
    {
        private ProductoDulceria producto = new ProductoDulceria();

        private bool nuevo = false;
        public FrmProductosDulceria()
        {
            InitializeComponent();
        }

        private void FrmProductosDulceria_Load( object sender, EventArgs e)
        {
            CargarCategorias();

            CargarProductos();

            Limpiar();

            ConfigurarBotones();
        }

        private void CargarCategorias()
        {
            cboCategoria.Items.Clear();

            cboCategoria.Items.Add(
            "CANCHITAS");

            cboCategoria.Items.Add(
            "BEBIDAS");

            cboCategoria.Items.Add(
            "COMBOS");

            cboCategoria.Items.Add(
            "NACHOS");

            cboCategoria.Items.Add(
            "HELADOS");

            cboCategoria.Items.Add(
            "CHOCOLATES");

            cboCategoria.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource =
            producto.Listar();

            FormatoGrid();
        }

        private void Limpiar()
        {
            txtIdProducto.Clear();

            txtNombre.Clear();

            txtDescripcion.Clear();

            cboCategoria.SelectedIndex = -1;

            txtPrecio.Clear();

            txtStock.Clear();

            txtImagen.Clear();

            chkActivo.Checked = true;

            pictureBox2.Image = null;

            txtNombre.Focus();
        }
        private void ConfigurarBotones()
        {
            btnNuevo.Enabled =
            !nuevo;

            btnGuardar.Enabled =
            nuevo;

            btnEditar.Enabled =
            !nuevo;

            btnEliminar.Enabled =
            !nuevo;
        }
        private bool ValidarDatos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese nombre del producto");

                txtNombre.Focus();

                return false;
            }

            if (cboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione categoría");

                cboCategoria.Focus();

                return false;
            }

            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese precio");

                txtPrecio.Focus();

                return false;
            }

            if (Convert.ToDecimal(txtPrecio.Text) <= 0)
            {
                MessageBox.Show(
                "El precio debe ser mayor a cero");

                txtPrecio.Focus();

                return false;
            }

            if (txtStock.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese stock");

                txtStock.Focus();

                return false;
            }

            if (Convert.ToInt32(txtStock.Text) < 0)
            {
                MessageBox.Show(
                "Stock inválido");

                txtStock.Focus();

                return false;
            }

            // Registro nuevo
            if (nuevo)
            {
                if (producto.ExisteNombre(
                    txtNombre.Text.Trim()))
                {
                    MessageBox.Show(
                    "Ya existe un producto con ese nombre");

                    txtNombre.Focus();

                    txtNombre.SelectAll();

                    return false;
                }
            }
            else
            {
                if (producto.ExisteNombreEdicion(
                    Convert.ToInt32(
                    txtIdProducto.Text),

                    txtNombre.Text.Trim()))
                {
                    MessageBox.Show(
                    "Ya existe un producto con ese nombre");

                    txtNombre.Focus();

                    txtNombre.SelectAll();

                    return false;
                }
            }

            return true;
        }
        private void FormatoGrid()
        {
            if (dgvProductos.Columns.Count == 0)
                return;

            // Ocultar columnas
            dgvProductos.Columns["IdProducto"].Visible = false;

            dgvProductos.Columns["Imagen"].Visible = false;

            dgvProductos.Columns["FechaRegistro"].Visible = false;

            dgvProductos.Columns["FechaActualizacion"].Visible = false;


            // Encabezados
            dgvProductos.Columns["Nombre"].HeaderText =
            "Producto";

            dgvProductos.Columns["Descripcion"].HeaderText =
            "Descripción";

            dgvProductos.Columns["Categoria"].HeaderText =
            "Categoría";

            dgvProductos.Columns["Precio"].HeaderText =
            "Precio";

            dgvProductos.Columns["Stock"].HeaderText =
            "Stock";

            dgvProductos.Columns["Activo"].HeaderText =
            "Activo";


            // Formato monetario
            dgvProductos.Columns["Precio"].DefaultCellStyle.Format =
            "N2";


            dgvProductos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.MultiSelect = false;

            dgvProductos.ReadOnly = true;

            dgvProductos.AllowUserToAddRows = false;
        }

        private void CargarImagen()
        {
            if (string.IsNullOrWhiteSpace(
                txtImagen.Text))
            {
                pictureBox2.Image = null;

                return;
            }

            try
            {
                if (File.Exists(
                    txtImagen.Text))
                {
                    pictureBox2.ImageLocation =
                    txtImagen.Text;

                    pictureBox2.SizeMode =
                    PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
            catch
            {
                pictureBox2.Image = null;
            }
        }

        private void btnNuevo_Click( object sender, EventArgs e)
        {
            nuevo = true;

            Limpiar();

            ConfigurarBotones();

            txtNombre.Focus();
        }

        private void btnGuardar_Click( object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            producto.nombre =
            txtNombre.Text.Trim();

            producto.descripcion =
            txtDescripcion.Text.Trim();

            producto.categoria =
            cboCategoria.Text;

            producto.precio =
            Convert.ToDecimal(
            txtPrecio.Text);

            producto.stock =
            Convert.ToInt32(
            txtStock.Text);

            producto.imagen =
            txtImagen.Text.Trim();

            producto.activo =
            chkActivo.Checked ? 1 : 0;

            if (producto.Registrar())
            {
                MessageBox.Show(
                "Producto registrado correctamente");

                CargarProductos();

                Limpiar();

                nuevo = false;

                ConfigurarBotones();
            }
            else
            {
                MessageBox.Show(
                "Error al registrar producto");
            }
        }

        private void btnEditar_Click( object sender, EventArgs e)
        {
            if (txtIdProducto.Text == "")
            {
                MessageBox.Show(
                "Seleccione un producto");

                return;
            }

            if (!ValidarDatos())
                return;

            producto.idProducto =
            Convert.ToInt32(
            txtIdProducto.Text);

            producto.nombre =
            txtNombre.Text.Trim();

            producto.descripcion =
            txtDescripcion.Text.Trim();

            producto.categoria =
            cboCategoria.Text;

            producto.precio =
            Convert.ToDecimal(
            txtPrecio.Text);

            producto.stock =
            Convert.ToInt32(
            txtStock.Text);

            producto.imagen =
            txtImagen.Text.Trim();

            producto.activo =
            chkActivo.Checked ? 1 : 0;

            if (producto.Actualizar())
            {
                MessageBox.Show(
                "Producto actualizado correctamente");

                CargarProductos();

                Limpiar();
            }
            else
            {
                MessageBox.Show(
                "Error al actualizar");
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e)
        {
            if (txtIdProducto.Text == "")
            {
                MessageBox.Show(
                "Seleccione un producto");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(

            "¿Desea eliminar el producto?",

            "Productos Dulcería",

            MessageBoxButtons.YesNo,

            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            producto.idProducto =
            Convert.ToInt32(
            txtIdProducto.Text);

            if (producto.Eliminar())
            {
                MessageBox.Show(
                "Producto eliminado");

                CargarProductos();

                Limpiar();
            }
        }

        private void txtPrecio_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(
                e.KeyChar))
                return;

            if (char.IsDigit(
                e.KeyChar))
                return;

            if (e.KeyChar == '.'
                &&
                !txtPrecio.Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txtStock_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(
                e.KeyChar)
                &&
                !char.IsDigit(
                e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(
                e.KeyChar)
                &&
                !char.IsLetter(
                e.KeyChar)
                &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e)
        {
            dgvProductos.DataSource =
            producto.Buscar(
            txtBuscar.Text.Trim());

            FormatoGrid();
        }

        private void dgvProductos_CellClick( object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows.Count == 0)
                return;

            txtIdProducto.Text =
            dgvProductos.CurrentRow.Cells[
            "IdProducto"].Value.ToString();

            txtNombre.Text =
            dgvProductos.CurrentRow.Cells[
            "Nombre"].Value.ToString();

            txtDescripcion.Text =
            dgvProductos.CurrentRow.Cells[
            "Descripcion"].Value.ToString();

            string categoria =
             dgvProductos.CurrentRow.Cells[
             "Categoria"].Value.ToString();

            int indice =
            cboCategoria.FindStringExact(
            categoria);

            if (indice >= 0)
            {
                cboCategoria.SelectedIndex =
                indice;
            }
            else
            {
                cboCategoria.SelectedIndex = -1;
            }

            txtPrecio.Text =
            dgvProductos.CurrentRow.Cells[
            "Precio"].Value.ToString();

            txtStock.Text =
            dgvProductos.CurrentRow.Cells[
            "Stock"].Value.ToString();

            txtImagen.Text =
            dgvProductos.CurrentRow.Cells[
            "Imagen"].Value.ToString();

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvProductos.CurrentRow.Cells[
            "Activo"].Value);

            CargarImagen();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialogo =
            new System.Windows.Forms.OpenFileDialog();

            dialogo.Filter =
            "Archivos de imagen|*.jpg;*.jpeg;*.png";

            dialogo.Title =
            "Seleccionar imagen";

            if (dialogo.ShowDialog()
                == DialogResult.OK)
            {
                txtImagen.Text =
                dialogo.FileName;

                CargarImagen();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
