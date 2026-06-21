using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Formularios;
using DSEProyectoFinal.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSEProyectoFinal
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmPrincipal_Load( object sender, EventArgs e)
        {
            tmHora.Start();

            lblFecha.Text =
            DateTime.Now.ToString(
            "dd/MM/yyyy HH:mm:ss");

            SesionActual.NombreCompleto = "";

            SesionActual.Rol = "";

            SesionActual.TipoUsuario = "";

            ActualizarSesion();
        }

        private void cinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCines frm = new FrmCines();

            frm.ShowDialog();
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHorarios frm = new FrmHorarios();
            frm.ShowDialog();
        }

        private void peliculasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPeliculas frm = new FrmPeliculas();
            frm.ShowDialog();
        }

        private void ventaDeEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaEntradas frm = new FrmVentaEntradas();
            frm.ShowDialog();
        }

        private void carteleraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCartelera frm = new FrmCartelera();
            frm.ShowDialog();
        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCarteleraPublica frm = new FrmCarteleraPublica();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();

            if (
                frm.ShowDialog()
                ==
                DialogResult.OK)
            {
                ActualizarSesion();
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }

        private void tmHora_Tick(object sender, EventArgs e)
        {
            lblFecha.Text =  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ConfigurarPermisos()
        {
            // Menús de sesión

            mnuIniciarSesion.Visible = true;

            mnuRegistrarse.Visible = true;

            mnuCerrarSesion.Visible = false;


            // Menús administrativos

            mnuMantenimiento.Visible = false;

            mnuUsuarios.Visible = false;

            mnuReportes.Visible = false;


            // Sin sesión iniciada

            if (SesionActual.NombreCompleto == "")
            {
                lblUsuario.Text = "Invitado";

                return;
            }


            // Hay sesión activa

            mnuIniciarSesion.Visible = false;

            mnuRegistrarse.Visible = false;

            mnuCerrarSesion.Visible = true;


            // CLIENTE

            if (SesionActual.TipoUsuario == "CLIENTE")
            {
                return;
            }


            // ADMINISTRADOR

            if (SesionActual.Rol == "ADMINISTRADOR")
            {
                mnuMantenimiento.Visible = true;

                mnuUsuarios.Visible = true;

                mnuReportes.Visible = true;

                return;
            }


            // SUPERVISOR

            if (SesionActual.Rol == "SUPERVISOR")
            {
                mnuMantenimiento.Visible = true;

                mnuReportes.Visible = true;

                return;
            }


            // USUARIO

            if (SesionActual.Rol == "USUARIO")
            {
                mnuMantenimiento.Visible = true;

                return;
            }
        }

        public void ActualizarSesion()
        {
            if (SesionActual.NombreCompleto == "")
            {
                lblUsuario.Text = "Invitado";
            }
            else
            {
                lblUsuario.Text =
                "Bienvenido: "
                + SesionActual.NombreCompleto
                + " - "
                + SesionActual.Rol;
            }

            ConfigurarPermisos();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta =
             MessageBox.Show( "¿Desea salir del sistema?", "CinePelis",

             MessageBoxButtons.YesNo,

             MessageBoxIcon.Question);

            if (respuesta ==
                DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuCerrarSesion_Click( object sender, EventArgs e)
        {
            DialogResult respuesta =
            MessageBox.Show(
            "¿Desea cerrar sesión?",
            "CinePelis",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            SesionActual.IdUsuario = 0;

            SesionActual.NombreCompleto = "";

            SesionActual.Correo = "";

            SesionActual.Rol = "";

            SesionActual.TipoUsuario = "";

            ActualizarSesion();

            MessageBox.Show(
            "Sesión cerrada correctamente");
        }

        private void mnuRegistrarse_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();

            frm.ModoRegistro = true;

            frm.ShowDialog();
        }

        private void dulceriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProductosDulceria frm = new FrmProductosDulceria();
            frm.ShowDialog();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentaDulceria frm = new FrmVentaDulceria();
            frm.ShowDialog();
        }

        private void peliculasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmReportePeliculas frm = new FrmReportePeliculas();

            frm.ShowDialog();
        }
    }
}
