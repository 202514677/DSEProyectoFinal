namespace DSEProyectoFinal
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrarse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.peliculasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaDeEntradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dulceriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentaDulceria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.cinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.peliculasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.horariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carteleraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dulceriaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.peliculasToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cinesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dulceriaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disposiciónSalasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.miPerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.tmHora = new System.Windows.Forms.Timer(this.components);
            this.todasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.estrenosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restricciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInicio,
            this.peliculasToolStripMenuItem,
            this.dulceriaToolStripMenuItem,
            this.mnuMantenimiento,
            this.mnuReportes,
            this.mnuUsuarios});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuInicio
            // 
            this.mnuInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIniciarSesion,
            this.mnuCerrarSesion,
            this.mnuRegistrarse,
            this.mnuSalir});
            this.mnuInicio.Name = "mnuInicio";
            this.mnuInicio.Size = new System.Drawing.Size(48, 20);
            this.mnuInicio.Text = "Inicio";
            // 
            // mnuIniciarSesion
            // 
            this.mnuIniciarSesion.Name = "mnuIniciarSesion";
            this.mnuIniciarSesion.Size = new System.Drawing.Size(143, 22);
            this.mnuIniciarSesion.Text = "Iniciar sesión";
            this.mnuIniciarSesion.Click += new System.EventHandler(this.iniciarSesiónToolStripMenuItem_Click);
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.mnuCerrarSesion.Text = "Cerrar Sesión";
            this.mnuCerrarSesion.Visible = false;
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // mnuRegistrarse
            // 
            this.mnuRegistrarse.Name = "mnuRegistrarse";
            this.mnuRegistrarse.Size = new System.Drawing.Size(143, 22);
            this.mnuRegistrarse.Text = "Registrarse";
            this.mnuRegistrarse.Click += new System.EventHandler(this.mnuRegistrarse_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(143, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // peliculasToolStripMenuItem
            // 
            this.peliculasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todasToolStripMenuItem,
            this.ventaDeEntradasToolStripMenuItem,
            this.todasToolStripMenuItem1,
            this.estrenosToolStripMenuItem,
            this.restricciónToolStripMenuItem});
            this.peliculasToolStripMenuItem.Name = "peliculasToolStripMenuItem";
            this.peliculasToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.peliculasToolStripMenuItem.Text = "Peliculas";
            // 
            // todasToolStripMenuItem
            // 
            this.todasToolStripMenuItem.Name = "todasToolStripMenuItem";
            this.todasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.todasToolStripMenuItem.Text = "Cartelera";
            this.todasToolStripMenuItem.Click += new System.EventHandler(this.todasToolStripMenuItem_Click);
            // 
            // ventaDeEntradasToolStripMenuItem
            // 
            this.ventaDeEntradasToolStripMenuItem.Name = "ventaDeEntradasToolStripMenuItem";
            this.ventaDeEntradasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ventaDeEntradasToolStripMenuItem.Text = "Venta de Entradas";
            this.ventaDeEntradasToolStripMenuItem.Click += new System.EventHandler(this.ventaDeEntradasToolStripMenuItem_Click);
            // 
            // dulceriaToolStripMenuItem
            // 
            this.dulceriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVentaDulceria});
            this.dulceriaToolStripMenuItem.Name = "dulceriaToolStripMenuItem";
            this.dulceriaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.dulceriaToolStripMenuItem.Text = "Dulceria";
            // 
            // mnuVentaDulceria
            // 
            this.mnuVentaDulceria.Name = "mnuVentaDulceria";
            this.mnuVentaDulceria.Size = new System.Drawing.Size(149, 22);
            this.mnuVentaDulceria.Text = "Venta Dulcería";
            this.mnuVentaDulceria.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cinesToolStripMenuItem1,
            this.peliculasToolStripMenuItem1,
            this.horariosToolStripMenuItem,
            this.carteleraToolStripMenuItem,
            this.clientesToolStripMenuItem1,
            this.usuarioToolStripMenuItem,
            this.dulceriaToolStripMenuItem1});
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(101, 20);
            this.mnuMantenimiento.Text = "Mantenimiento";
            this.mnuMantenimiento.Visible = false;
            // 
            // cinesToolStripMenuItem1
            // 
            this.cinesToolStripMenuItem1.Name = "cinesToolStripMenuItem1";
            this.cinesToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.cinesToolStripMenuItem1.Text = "Cines";
            this.cinesToolStripMenuItem1.Click += new System.EventHandler(this.cinesToolStripMenuItem1_Click);
            // 
            // peliculasToolStripMenuItem1
            // 
            this.peliculasToolStripMenuItem1.Name = "peliculasToolStripMenuItem1";
            this.peliculasToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.peliculasToolStripMenuItem1.Text = "Peliculas";
            this.peliculasToolStripMenuItem1.Click += new System.EventHandler(this.peliculasToolStripMenuItem1_Click);
            // 
            // horariosToolStripMenuItem
            // 
            this.horariosToolStripMenuItem.Name = "horariosToolStripMenuItem";
            this.horariosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.horariosToolStripMenuItem.Text = "Horarios";
            this.horariosToolStripMenuItem.Click += new System.EventHandler(this.horariosToolStripMenuItem_Click);
            // 
            // carteleraToolStripMenuItem
            // 
            this.carteleraToolStripMenuItem.Name = "carteleraToolStripMenuItem";
            this.carteleraToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.carteleraToolStripMenuItem.Text = "Cartelera";
            this.carteleraToolStripMenuItem.Click += new System.EventHandler(this.carteleraToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.usuarioToolStripMenuItem.Text = "Usuarios";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // dulceriaToolStripMenuItem1
            // 
            this.dulceriaToolStripMenuItem1.Name = "dulceriaToolStripMenuItem1";
            this.dulceriaToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.dulceriaToolStripMenuItem1.Text = "Dulceria";
            this.dulceriaToolStripMenuItem1.Click += new System.EventHandler(this.dulceriaToolStripMenuItem1_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peliculasToolStripMenuItem2,
            this.cinesToolStripMenuItem2,
            this.dulceriaToolStripMenuItem2,
            this.clientesToolStripMenuItem,
            this.disposiciónSalasToolStripMenuItem});
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(65, 20);
            this.mnuReportes.Text = "Reportes";
            this.mnuReportes.Visible = false;
            // 
            // peliculasToolStripMenuItem2
            // 
            this.peliculasToolStripMenuItem2.Name = "peliculasToolStripMenuItem2";
            this.peliculasToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.peliculasToolStripMenuItem2.Text = "Peliculas";
            this.peliculasToolStripMenuItem2.Click += new System.EventHandler(this.peliculasToolStripMenuItem2_Click);
            // 
            // cinesToolStripMenuItem2
            // 
            this.cinesToolStripMenuItem2.Name = "cinesToolStripMenuItem2";
            this.cinesToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.cinesToolStripMenuItem2.Text = "Ventas de Peliculas";
            this.cinesToolStripMenuItem2.Click += new System.EventHandler(this.cinesToolStripMenuItem2_Click);
            // 
            // dulceriaToolStripMenuItem2
            // 
            this.dulceriaToolStripMenuItem2.Name = "dulceriaToolStripMenuItem2";
            this.dulceriaToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.dulceriaToolStripMenuItem2.Text = "Ventas de Dulceria";
            this.dulceriaToolStripMenuItem2.Click += new System.EventHandler(this.dulceriaToolStripMenuItem2_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // disposiciónSalasToolStripMenuItem
            // 
            this.disposiciónSalasToolStripMenuItem.Name = "disposiciónSalasToolStripMenuItem";
            this.disposiciónSalasToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.disposiciónSalasToolStripMenuItem.Text = "Ocupación de Salas";
            this.disposiciónSalasToolStripMenuItem.Click += new System.EventHandler(this.disposiciónSalasToolStripMenuItem_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPerfilToolStripMenuItem,
            this.cambiarContraseñaToolStripMenuItem,
            this.puntosToolStripMenuItem});
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(59, 20);
            this.mnuUsuarios.Text = "Usuario";
            this.mnuUsuarios.Visible = false;
            // 
            // miPerfilToolStripMenuItem
            // 
            this.miPerfilToolStripMenuItem.Name = "miPerfilToolStripMenuItem";
            this.miPerfilToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.miPerfilToolStripMenuItem.Text = "Mi Perfil";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            // 
            // puntosToolStripMenuItem
            // 
            this.puntosToolStripMenuItem.Name = "puntosToolStripMenuItem";
            this.puntosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.puntosToolStripMenuItem.Text = "Puntos";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.statusStrip1);
            this.panelPrincipal.Controls.Add(this.picBanner);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 24);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(800, 426);
            this.panelPrincipal.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblFecha});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(47, 17);
            this.lblUsuario.Text = "Usuario";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 17);
            this.lblFecha.Text = "Fecha";
            // 
            // picBanner
            // 
            this.picBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBanner.BackgroundImage")));
            this.picBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBanner.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBanner.InitialImage")));
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(800, 426);
            this.picBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBanner.TabIndex = 0;
            this.picBanner.TabStop = false;
            // 
            // tmHora
            // 
            this.tmHora.Enabled = true;
            this.tmHora.Interval = 1000;
            this.tmHora.Tick += new System.EventHandler(this.tmHora_Tick);
            // 
            // todasToolStripMenuItem1
            // 
            this.todasToolStripMenuItem1.Name = "todasToolStripMenuItem1";
            this.todasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.todasToolStripMenuItem1.Text = "Todas";
            this.todasToolStripMenuItem1.Click += new System.EventHandler(this.todasToolStripMenuItem1_Click);
            // 
            // estrenosToolStripMenuItem
            // 
            this.estrenosToolStripMenuItem.Name = "estrenosToolStripMenuItem";
            this.estrenosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.estrenosToolStripMenuItem.Text = "Estrenos";
            this.estrenosToolStripMenuItem.Click += new System.EventHandler(this.estrenosToolStripMenuItem_Click);
            // 
            // restricciónToolStripMenuItem
            // 
            this.restricciónToolStripMenuItem.Name = "restricciónToolStripMenuItem";
            this.restricciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restricciónToolStripMenuItem.Text = "Restricción";
            this.restricciónToolStripMenuItem.Click += new System.EventHandler(this.restricciónToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CinePelis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dulceriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem cinesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem horariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dulceriaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuInicio;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrarse;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.ToolStripMenuItem ventaDeEntradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuVentaDulceria;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem peliculasToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cinesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dulceriaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem carteleraToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.Timer tmHora;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem miPerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disposiciónSalasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem estrenosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restricciónToolStripMenuItem;
    }
}

