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
using System.Text.RegularExpressions;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmClientes : Form
    {
        private Cliente cliente = new Cliente();

        private bool nuevo = false;

        public bool ModoRegistro
        {
            get;
            set;
        }

        public FrmClientes()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmClientes_Load( object sender, EventArgs e)
        {
            ConfigurarFormulario();

            CargarClientes();

            Limpiar();

            ConfigurarBotones();

            ConfigurarModo();
        }

        private void Limpiar()
        {
            txtIdCliente.Clear();

            txtDni.Clear();

            txtNombre.Clear();

            txtApellido.Clear();

            txtCelular.Clear();

            txtEmail.Clear();

            chkActivo.Checked = true;

            txtBuscar.Clear();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource =
            cliente.Listar();

            FormatoGrid();

            lblTotalClientes.Text = "Total Clientes: " + dgvClientes.Rows.Count;
        }

        private void ConfigurarBotones()
        {
            btnGuardar.Enabled =
            nuevo;

            btnEditar.Enabled =
            !nuevo;

            btnEliminar.Enabled =
            !nuevo;
        }

        private bool ValidarDatos()
        {
            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese DNI");

                txtDni.Focus();

                return false;
            }

            if (txtDni.Text.Length != 8)
            {
                MessageBox.Show(
                "El DNI debe tener 8 dígitos");

                txtDni.Focus();

                return false;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese nombres");

                txtNombre.Focus();

                return false;
            }

            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese apellidos");

                txtApellido.Focus();

                return false;
            }

            if (txtCelular.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese celular");

                txtCelular.Focus();

                return false;
            }

            if (txtCelular.Text.Length != 9)
            {
                MessageBox.Show(
                "El celular debe tener 9 dígitos");

                txtCelular.Focus();

                return false;
            }

            if (!txtCelular.Text.StartsWith("9"))
            {
                MessageBox.Show(
                "El celular debe empezar con 9");

                txtCelular.Focus();

                return false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese correo electrónico");

                txtEmail.Focus();

                return false;
            }

            txtEmail.Text =
            txtEmail.Text
            .Trim()
            .ToLower();

            // Validación del correo
            string patronCorreo =
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$";

            if (!Regex.IsMatch(
                txtEmail.Text,
                patronCorreo))
            {
                MessageBox.Show(

                "Correo electrónico inválido.\n\nEjemplo:\nusuario@gmail.com",

                "Clientes",

                MessageBoxButtons.OK,

                MessageBoxIcon.Warning);

                txtEmail.Focus();

                return false;
            }

            // VALIDACIONES DE DUPLICADOS
            if (nuevo)
            {
                if (cliente.ExisteDni(
                    txtDni.Text.Trim()))
                {
                    MessageBox.Show(
                    "El DNI ya existe");

                    txtDni.Focus();

                    return false;
                }

                if (cliente.ExisteCelular(
                    txtCelular.Text.Trim()))
                {
                    MessageBox.Show(
                    "El celular ya existe");

                    txtCelular.Focus();

                    return false;
                }

                if (cliente.ExisteEmail(
                    txtEmail.Text.Trim()))
                {
                    MessageBox.Show(
                    "El correo electrónico ya existe");

                    txtEmail.Focus();

                    return false;
                }
            }
            else
            {
                int idCliente =
                Convert.ToInt32(
                txtIdCliente.Text);

                if (cliente.ExisteDniEdicion(
                    idCliente,
                    txtDni.Text.Trim()))
                {
                    MessageBox.Show(
                    "El DNI ya existe");

                    txtDni.Focus();

                    return false;
                }

                if (cliente.ExisteCelularEdicion(
                    idCliente,
                    txtCelular.Text.Trim()))
                {
                    MessageBox.Show(
                    "El celular ya existe");

                    txtCelular.Focus();

                    return false;
                }

                if (cliente.ExisteEmailEdicion(
                    idCliente,
                    txtEmail.Text.Trim()))
                {
                    MessageBox.Show(
                    "El correo electrónico ya existe");

                    txtEmail.Focus();

                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_Click( object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Cliente nuevoCliente =
            new Cliente();

            nuevoCliente.dni =
            txtDni.Text.Trim();

            nuevoCliente.nombre =
            txtNombre.Text.Trim();

            nuevoCliente.apellido =
            txtApellido.Text.Trim();

            nuevoCliente.celular =
            txtCelular.Text.Trim();

            nuevoCliente.email =
            txtEmail.Text.Trim();

            if (ModoRegistro)
            {
                nuevoCliente.activo = 1;
            }
            else
            {
                nuevoCliente.activo =
                chkActivo.Checked ? 1 : 0;
            }

            // Contraseña por defecto
            nuevoCliente.password =
            "1234";

            if (nuevoCliente.Registrar())
            {
                // REGISTRO DESDE EL MENÚ "REGISTRARSE"
                if (ModoRegistro)
                {
                    DialogResult respuesta =
                    MessageBox.Show(

                    "Cliente registrado correctamente.\n\n" +
                    "La contraseña inicial es: 1234\n\n" +
                    "¿Desea iniciar sesión ahora?",

                    "Registro de Clientes",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        this.Close();

                        FrmLogin frm =
                        new FrmLogin();

                        // Opcional: dejar precargado el correo
                        frm.CorreoPredeterminado =
                        txtEmail.Text.Trim();

                        frm.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }

                // REGISTRO DESDE MANTENIMIENTO → CLIENTES
                else
                {
                    MessageBox.Show(

                    "Cliente registrado correctamente",

                    "Clientes",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Information);

                    CargarClientes();

                    Limpiar();

                    nuevo = false;

                    ConfigurarBotones();

                    txtDni.Focus();
                }
            }
            else
            {
                MessageBox.Show(

                "Error al registrar cliente",

                "Clientes",

                MessageBoxButtons.OK,

                MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click( object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show(
                "Seleccione un cliente");

                return;
            }

            if (!ValidarDatos())
            {
                return;
            }

            Cliente clienteEditar =
            new Cliente();

            clienteEditar.idCliente =
            Convert.ToInt32(
            txtIdCliente.Text);

            clienteEditar.dni =
            txtDni.Text.Trim();

            clienteEditar.nombre =
            txtNombre.Text.Trim();

            clienteEditar.apellido =
            txtApellido.Text.Trim();

            clienteEditar.celular =
            txtCelular.Text.Trim();

            clienteEditar.email =
            txtEmail.Text.Trim();

            clienteEditar.activo =
            chkActivo.Checked ? 1 : 0;

            if (clienteEditar.Actualizar())
            {
                MessageBox.Show(
                "Cliente actualizado correctamente");

                CargarClientes();

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
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show(
                "Seleccione un cliente");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(

            "¿Desea eliminar el cliente?",

            "Clientes",

            MessageBoxButtons.YesNo,

            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            Cliente clienteEliminar =
            new Cliente();

            clienteEliminar.idCliente =
            Convert.ToInt32(
            txtIdCliente.Text);

            if (clienteEliminar.Eliminar())
            {
                MessageBox.Show(
                "Cliente eliminado");

                CargarClientes();

                Limpiar();
            }
        }

        private void btnBuscar_Click( object sender, EventArgs e)
        {
            dgvClientes.DataSource =
            cliente.Buscar(
            txtBuscar.Text.Trim());

            FormatoGrid();
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e)
        {
            dgvClientes.DataSource =
            cliente.Buscar(
            txtBuscar.Text.Trim());

            FormatoGrid();
        }

        private void dgvClientes_CellClick( object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtIdCliente.Text =
            dgvClientes.CurrentRow.Cells[
            "IdCliente"].Value.ToString();

            txtDni.Text =
            dgvClientes.CurrentRow.Cells[
            "Dni"].Value.ToString();

            txtNombre.Text =
            dgvClientes.CurrentRow.Cells[
            "Nombre"].Value.ToString();

            txtApellido.Text =
            dgvClientes.CurrentRow.Cells[
            "Apellido"].Value.ToString();

            txtCelular.Text =
            dgvClientes.CurrentRow.Cells[
            "Celular"].Value.ToString();

            txtEmail.Text =
            dgvClientes.CurrentRow.Cells[
            "Email"].Value.ToString();

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvClientes.CurrentRow.Cells[
            "Activo"].Value);

            nuevo = false;

            ConfigurarBotones();
        }

        private void btnNuevo_Click( object sender, EventArgs e)
        {
            Limpiar();

            nuevo = true;

            chkActivo.Checked = true;

            txtDni.Focus();

            ConfigurarBotones();
        }

        private void txtDni_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (
                txtDni.Text.Length >= 8
                &&
                !char.IsControl(
                e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (
                txtCelular.Text.Length >= 9
                &&
                !char.IsControl(
                e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                &&
                !char.IsLetter(e.KeyChar)
                &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                &&
                !char.IsLetter(e.KeyChar)
                &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void FormatoGrid()
        {
            if (dgvClientes.Rows.Count == 0)
                return;

            dgvClientes.Columns[
            "IdCliente"].Visible = false;

            dgvClientes.Columns[
            "FechaActualizacion"].Visible = false;

            dgvClientes.Columns[
            "Activo"].HeaderText =
            "Activo";

            dgvClientes.Columns[
            "Dni"].HeaderText =
            "DNI";

            dgvClientes.Columns[
            "Cliente"].HeaderText =
            "Cliente";

            dgvClientes.Columns[
            "Celular"].HeaderText =
            "Celular";

            dgvClientes.Columns[
            "Email"].HeaderText =
            "Correo";

            dgvClientes.Columns[
            "FechaRegistro"].HeaderText =
            "Fecha Registro";

            dgvClientes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvClientes.MultiSelect = false;

            dgvClientes.ReadOnly = true;

            dgvClientes.AllowUserToAddRows = false;
        }

        private void ConfigurarFormulario()
        {
            txtIdCliente.ReadOnly = true;

            txtBuscar.CharacterCasing =
            CharacterCasing.Upper;

            txtNombre.CharacterCasing =
            CharacterCasing.Upper;

            txtApellido.CharacterCasing =
            CharacterCasing.Upper;

            txtEmail.CharacterCasing =
            CharacterCasing.Lower;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarModo()
        {
            if (!ModoRegistro)
                return;

            this.Text =
            "Registro de Clientes";

            lblIdCliente.Visible = false;
            txtIdCliente.Visible = false;

            btnNuevo.Visible = false;

            btnEditar.Visible = false;

            btnEliminar.Visible = false;

            btnBuscar.Visible = false;

            txtBuscar.Visible = false;

            dgvClientes.Visible = false;

            chkActivo.Checked = true;

            chkActivo.Enabled = false;

            // El botón Guardar debe estar habilitado
            btnGuardar.Enabled = true;

            // No depende del botón Nuevo
            nuevo = true;

            btnGuardar.Left = 120;

            btnSalir.Left = 260;

            lblTotalClientes.Visible = false;
            
        }

    }
 }

