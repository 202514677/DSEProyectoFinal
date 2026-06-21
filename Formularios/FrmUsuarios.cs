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
    public partial class FrmUsuarios : Form
    {
        private Usuario usuario = new Usuario();

        private bool nuevo = false;
        public FrmUsuarios()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();

            CargarUsuarios();

            Limpiar();

            ConfigurarBotones();
        }

        private void Limpiar()
        {
            txtIdUsuario.Clear();

            txtDni.Clear();

            txtNombres.Clear();

            txtApellidos.Clear();

            txtCelular.Clear();

            txtCorreo.Clear();

            txtPassword.Clear();

            cboRol.SelectedIndex = -1;

            chkActivo.Checked = true;

            txtBuscar.Clear();

            dtpFechaNacimiento.Value = DateTime.Today;
        }

        private void ConfigurarFormulario()
        {
            txtIdUsuario.ReadOnly = true;

            txtNombres.CharacterCasing =
            CharacterCasing.Upper;

            txtApellidos.CharacterCasing =
            CharacterCasing.Upper;

            txtCorreo.CharacterCasing =
            CharacterCasing.Lower;

            cboRol.DropDownStyle =
            ComboBoxStyle.DropDownList;

            cboRol.Items.Clear();

            cboRol.Items.Add(
            "ADMINISTRADOR");

            cboRol.Items.Add(
            "SUPERVISOR");

            cboRol.Items.Add(
            "USUARIO");
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

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource =
            usuario.Listar();

            FormatoGrid();

            lblTotalUsuarios.Text = "Total Usuarios: " + dgvUsuarios.Rows.Count;
        }

        private void FormatoGrid()
        {
            if (dgvUsuarios.Rows.Count == 0)
                return;

            dgvUsuarios.Columns[
            "IdUsuario"].Visible = false;

            dgvUsuarios.Columns[
            "FechaActualizacion"].Visible = false;

            dgvUsuarios.Columns[
            "Dni"].HeaderText =
            "DNI";

            dgvUsuarios.Columns[
            "Usuario"].HeaderText =
            "Usuario";

            dgvUsuarios.Columns[
            "Celular"].HeaderText =
            "Celular";

            dgvUsuarios.Columns[
            "Correo"].HeaderText =
            "Correo";

            dgvUsuarios.Columns[
            "Rol"].HeaderText =
            "Rol";

            dgvUsuarios.Columns[
            "Activo"].HeaderText =
            "Activo";

            dgvUsuarios.Columns[
            "FechaRegistro"].HeaderText =
            "Fecha Registro";

            dgvUsuarios.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.ReadOnly = true;

            dgvUsuarios.AllowUserToAddRows = false;
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

            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese nombres");

                txtNombres.Focus();

                return false;
            }

            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese apellidos");

                txtApellidos.Focus();

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

            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese correo electrónico");

                txtCorreo.Focus();

                return false;
            }

            txtCorreo.Text =
            txtCorreo.Text
            .Trim()
            .ToLower();

            // Validación de correo
            string patronCorreo =
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$";

            if (!Regex.IsMatch(
                txtCorreo.Text,
                patronCorreo))
            {
                MessageBox.Show(

                "Correo electrónico inválido.\n\nEjemplo:\nusuario@gmail.com",

                "Usuarios",

                MessageBoxButtons.OK,

                MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese contraseña");

                txtPassword.Focus();

                return false;
            }

            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show(
                "La contraseña debe tener al menos 4 caracteres");

                txtPassword.Focus();

                return false;
            }

            if (cboRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione un rol");

                cboRol.Focus();

                return false;
            }

            if (dtpFechaNacimiento.Value >
                DateTime.Today)
            {
                MessageBox.Show(
                "Fecha de nacimiento inválida");

                dtpFechaNacimiento.Focus();

                return false;
            }

            int edad =
            DateTime.Today.Year -
            dtpFechaNacimiento.Value.Year;

            if (dtpFechaNacimiento.Value >
                DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
                MessageBox.Show(
                "El usuario debe ser mayor de edad");

                dtpFechaNacimiento.Focus();

                return false;
            }

            // VALIDACIONES DE DUPLICADOS
            if (nuevo)
            {
                if (usuario.ExisteDni(
                    txtDni.Text.Trim()))
                {
                    MessageBox.Show(
                    "El DNI ya existe");

                    txtDni.Focus();

                    return false;
                }

                if (usuario.ExisteCelular(
                    txtCelular.Text.Trim()))
                {
                    MessageBox.Show(
                    "El celular ya existe");

                    txtCelular.Focus();

                    return false;
                }

                if (usuario.ExisteCorreo(
                    txtCorreo.Text.Trim()))
                {
                    MessageBox.Show(
                    "El correo ya existe");

                    txtCorreo.Focus();

                    return false;
                }
            }
            else
            {
                int idUsuario =
                Convert.ToInt32(
                txtIdUsuario.Text);

                if (usuario.ExisteDniEdicion(
                    idUsuario,
                    txtDni.Text.Trim()))
                {
                    MessageBox.Show(
                    "El DNI ya existe");

                    txtDni.Focus();

                    return false;
                }

                if (usuario.ExisteCelularEdicion(
                    idUsuario,
                    txtCelular.Text.Trim()))
                {
                    MessageBox.Show(
                    "El celular ya existe");

                    txtCelular.Focus();

                    return false;
                }

                if (usuario.ExisteCorreoEdicion(
                    idUsuario,
                    txtCorreo.Text.Trim()))
                {
                    MessageBox.Show(
                    "El correo ya existe");

                    txtCorreo.Focus();

                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_Click( object sender,  EventArgs e)
        {
            if (!ValidarDatos())
                return;

            Usuario nuevoUsuario =
            new Usuario();

            nuevoUsuario.dni =
            txtDni.Text.Trim();

            nuevoUsuario.nombres =
            txtNombres.Text.Trim();

            nuevoUsuario.apellidos =
            txtApellidos.Text.Trim();

            nuevoUsuario.fechaNacimiento =
            dtpFechaNacimiento.Value;

            nuevoUsuario.celular =
            txtCelular.Text.Trim();

            nuevoUsuario.correo =
            txtCorreo.Text.Trim();

            nuevoUsuario.password =
            txtPassword.Text.Trim();

            nuevoUsuario.rol =
            cboRol.Text;

            nuevoUsuario.activo =
            chkActivo.Checked ? 1 : 0;

            if (nuevoUsuario.Registrar())
            {
                MessageBox.Show(
                "Usuario registrado correctamente");

                CargarUsuarios();

                Limpiar();

                nuevo = false;

                ConfigurarBotones();
            }
            else
            {
                MessageBox.Show(
                "Error al registrar usuario");
            }
        }

        private void btnEditar_Click( object sender, EventArgs e)
        {
            if (txtIdUsuario.Text == "")
            {
                MessageBox.Show(
                "Seleccione un usuario");

                return;
            }

            if (!ValidarDatos())
                return;

            Usuario usuarioEditar =
            new Usuario();

            usuarioEditar.idUsuario =
            Convert.ToInt32(
            txtIdUsuario.Text);

            usuarioEditar.dni =
            txtDni.Text.Trim();

            usuarioEditar.nombres =
            txtNombres.Text.Trim();

            usuarioEditar.apellidos =
            txtApellidos.Text.Trim();

            usuarioEditar.fechaNacimiento =
            dtpFechaNacimiento.Value;

            usuarioEditar.celular =
            txtCelular.Text.Trim();

            usuarioEditar.correo =
            txtCorreo.Text.Trim();

            usuarioEditar.password =
            txtPassword.Text.Trim();

            usuarioEditar.rol =
            cboRol.Text;

            usuarioEditar.activo =
            chkActivo.Checked ? 1 : 0;

            if (usuarioEditar.Actualizar())
            {
                MessageBox.Show(
                "Usuario actualizado");

                CargarUsuarios();

                Limpiar();
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e)
        {
            if (txtIdUsuario.Text == "")
            {
                MessageBox.Show(
                "Seleccione un usuario");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(

            "¿Desea eliminar el usuario?",

            "Usuarios",

            MessageBoxButtons.YesNo,

            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            Usuario usuarioEliminar =
            new Usuario();

            usuarioEliminar.idUsuario =
            Convert.ToInt32(
            txtIdUsuario.Text);

            if (usuarioEliminar.Eliminar())
            {
                MessageBox.Show(
                "Usuario eliminado");

                CargarUsuarios();

                Limpiar();
            }
        }

        private void btnBuscar_Click( object sender, EventArgs e)
        {
            dgvUsuarios.DataSource =
            usuario.Buscar(
            txtBuscar.Text.Trim());

            FormatoGrid();
        }

        private void txtBuscar_TextChanged( object sender,  EventArgs e)
        {
            dgvUsuarios.DataSource =
            usuario.Buscar(
            txtBuscar.Text.Trim());

            FormatoGrid();
        }

        private void dgvUsuarios_CellClick( object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtIdUsuario.Text =
            dgvUsuarios.CurrentRow.Cells[
            "IdUsuario"].Value.ToString();

            txtDni.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Dni"].Value.ToString();

            txtNombres.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Nombres"].Value.ToString();

            txtApellidos.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Apellidos"].Value.ToString();

            txtCelular.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Celular"].Value.ToString();

            txtCorreo.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Correo"].Value.ToString();

            txtPassword.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Password"].Value.ToString();

            cboRol.Text =
            dgvUsuarios.CurrentRow.Cells[
            "Rol"].Value.ToString();

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvUsuarios.CurrentRow.Cells[
            "Activo"].Value);

            dtpFechaNacimiento.Value =
            Convert.ToDateTime(
            dgvUsuarios.CurrentRow.Cells[
            "FechaNacimiento"].Value);

            nuevo = false;

            ConfigurarBotones();
        }

        private void btnNuevo_Click( object sender,  EventArgs e)
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

        private void txtNombres_KeyPress( object sender,  KeyPressEventArgs e)
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

        private void txtApellidos_KeyPress(  object sender, KeyPressEventArgs e)
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

        private void txtPassword_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_Leave( object sender,  EventArgs e)
        {
            txtCorreo.Text =
            txtCorreo.Text
            .Trim()
            .ToLower();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

