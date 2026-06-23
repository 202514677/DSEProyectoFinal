using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmLogin : Form
    {
        private Usuario usuario = new Usuario();

        private Cliente cliente =  new Cliente();

        private string codigoToken = "";

        // true = envía email real
        // false = modo pruebas
        private bool enviarCorreoReal = false;

        //Recuperar contraseña
        private bool RecuperacionModoPrueba = true;

        private bool accesoTemporalActivo = false;

        private const string PASSWORD_TEMPORAL =  "5678";

        public string CorreoPredeterminado
        {
            get;
            set;
        }

        public FrmLogin()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmLogin_Load( object sender, EventArgs e)
        {
            cboTipoUsuario.Items.Clear();

            cboTipoUsuario.Items.Add("CLIENTE");

            cboTipoUsuario.Items.Add("USUARIO");

            cboTipoUsuario.SelectedIndex = 0;

            txtCorreo.Clear();

            txtPassword.Clear();

            txtToken.Clear();

            txtToken.Enabled = true;

            btnEntrar.Enabled = false;

            btnEnviarCodigo.Enabled = true;

            txtCorreo.Focus();

            if (!string.IsNullOrEmpty(CorreoPredeterminado))
            {
                txtCorreo.Text =
                CorreoPredeterminado;

                txtPassword.Text = "1234";
            }
        }

        private string GenerarToken()
        {
            Random random =
            new Random();

            /*return random
            .Next(
            100000,
            999999)
            .ToString();*/

            return "1234";
        }

        private void EnviarCodigo( string correoDestino,  string token)
        {
            try
            {
                MailMessage correo =
                new MailMessage();

                correo.From =
                new MailAddress(
                "cinepelis@gmail.com");

                correo.To.Add(
                correoDestino);

                correo.Subject =
                "Código de Acceso CinePelis";

                correo.Body =
                "Su código de acceso es: "
                + token;

                SmtpClient servidor =
                new SmtpClient(
                "smtp.gmail.com",
                587);

                servidor.Credentials =
                new NetworkCredential(

                "cinepelis@gmail.com",

                "CLAVE_APP_GMAIL");

                servidor.EnableSsl =
                true;

                servidor.Send(
                correo);

                MessageBox.Show(
                "Código enviado correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        private void btnEnviarCodigo_Click( object sender, EventArgs e)
        {
            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese correo electrónico");

                txtCorreo.Focus();

                return;
            }

            codigoToken =
            GenerarToken();

            if (enviarCorreoReal)
            {
                EnviarCodigo(
                txtCorreo.Text.Trim(),
                codigoToken);

                MessageBox.Show(
                "Código enviado correctamente");
            }
            else
            {
                MessageBox.Show(

                "Modo pruebas.\n\n" +

                "Token generado: " +

                codigoToken,

                "CinePelis");

                // opcional
                txtToken.Text =
                codigoToken;
            }

            btnEnviarCodigo.Enabled =
            false;

            btnEntrar.Enabled =
            true;

            txtToken.Focus();
        }

        private void btnEntrar_Click(
     object sender,
     EventArgs e)
        {
            if (cboTipoUsuario.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione tipo de usuario");

                return;
            }

            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese correo electrónico");

                txtCorreo.Focus();

                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese contraseña");

                txtPassword.Focus();

                return;
            }

            if (txtToken.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese token");

                txtToken.Focus();

                return;
            }

            if (txtToken.Text.Trim() != codigoToken)
            {
                MessageBox.Show(
                "Token incorrecto");

                txtToken.Focus();

                txtToken.SelectAll();

                return;
            }

            DataTable dt =
            new DataTable();

            if (cboTipoUsuario.Text == "USUARIO")
            {
                dt =
                usuario.Login(
                txtCorreo.Text.Trim(),
                txtPassword.Text.Trim());
            }
            else
            {
                dt =
                cliente.Login(
                txtCorreo.Text.Trim(),
                txtPassword.Text.Trim());
            }

            // ==========================================
            // LOGIN FALLIDO
            // ==========================================

            if (dt.Rows.Count == 0)
            {
                // Recuperación de contraseña en modo prueba
                if (
                    cboTipoUsuario.Text == "CLIENTE"
                    &&
                    accesoTemporalActivo
                    &&
                    txtPassword.Text.Trim() == PASSWORD_TEMPORAL)
                {
                    dt =
                    cliente.BuscarPorCorreo(
                    txtCorreo.Text.Trim());

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show(
                        "Correo o contraseña incorrectos");

                        txtPassword.Focus();

                        txtPassword.SelectAll();

                        return;
                    }
                }
                else
                {
                    MessageBox.Show(
                    "Correo o contraseña incorrectos");

                    txtPassword.Focus();

                    txtPassword.SelectAll();

                    return;
                }
            }

            // =====================
            // USUARIO
            // =====================

            if (cboTipoUsuario.Text == "USUARIO")
            {
                SesionActual.IdUsuario =
                Convert.ToInt32(
                dt.Rows[0]["IdUsuario"]);

                SesionActual.NombreCompleto =
                dt.Rows[0]["Nombres"].ToString()
                + " "
                +
                dt.Rows[0]["Apellidos"].ToString();

                SesionActual.Correo =
                dt.Rows[0]["Correo"].ToString();

                if (dt.Rows[0]["Rol"] == DBNull.Value)
                {
                    SesionActual.Rol =
                    "USUARIO";
                }
                else
                {
                    SesionActual.Rol =
                    dt.Rows[0]["Rol"]
                    .ToString()
                    .Trim()
                    .ToUpper();
                }

                SesionActual.TipoUsuario =
                "USUARIO";
            }

            // =====================
            // CLIENTE
            // =====================

            else
            {
                SesionActual.IdUsuario =
                Convert.ToInt32(
                dt.Rows[0]["IdCliente"]);

                SesionActual.NombreCompleto =
                dt.Rows[0]["Nombre"].ToString()
                + " "
                +
                dt.Rows[0]["Apellido"].ToString();

                SesionActual.Correo =
                dt.Rows[0]["Email"].ToString();

                SesionActual.Rol =
                "CLIENTE";

                SesionActual.TipoUsuario =
                "CLIENTE";
            }

            // =====================
            // LIMPIEZA
            // =====================

            btnEnviarCodigo.Enabled =
            true;

            txtToken.Clear();

            codigoToken = "";

            // Desactivar contraseña temporal
            accesoTemporalActivo =
            false;

            this.DialogResult =
            DialogResult.OK;

            this.Close();
        }

        private void btnRecuperarPassword_Click(
      object sender,
      EventArgs e)
        {
            if (cboTipoUsuario.Text != "CLIENTE")
            {
                MessageBox.Show(
                "La recuperación de contraseña sólo está disponible para clientes.");

                return;
            }

            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese su correo electrónico.");

                txtCorreo.Focus();

                return;
            }

            Cliente cliente =
            new Cliente();

            DataTable dt =
            cliente.BuscarPorCorreo(
            txtCorreo.Text.Trim());

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                "No existe ningún cliente registrado con ese correo.");

                return;
            }

            // Por seguridad, reiniciar el estado
            accesoTemporalActivo = false;

            if (RecuperacionModoPrueba)
            {
                accesoTemporalActivo = true;

                MessageBox.Show(

                "Se ha enviado una nueva contraseña temporal al correo electrónico.\n\n"

                +

                "Para fines académicos y de prueba la contraseña temporal es:\n\n"

                +

                PASSWORD_TEMPORAL

                +

                "\n\nEsta contraseña permitirá un acceso temporal al sistema.\n\n"

                +

                "Recuerde solicitar un nuevo código si vuelve a olvidar su contraseña.",

                "Recuperar contraseña",

                MessageBoxButtons.OK,

                MessageBoxIcon.Information);

                // Opcional: colocar la clave temporal automáticamente
                txtPassword.Text =  PASSWORD_TEMPORAL;

                txtPassword.Focus();

                txtPassword.SelectAll();

                return;
            }

            // Entregas futuras
            // string passwordNueva =
            // GenerarPasswordAleatoria();

            // EnviarCorreoPasswordTemporal(
            // txtCorreo.Text,
            // passwordNueva);
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            accesoTemporalActivo = false;
        }
    }
}
