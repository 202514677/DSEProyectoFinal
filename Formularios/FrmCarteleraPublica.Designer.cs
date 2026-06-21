namespace DSEProyectoFinal.Formularios
{
    partial class FrmCarteleraPublica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarteleraPublica));
            this.flowPeliculas = new System.Windows.Forms.FlowLayoutPanel();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.txtSinopsis = new System.Windows.Forms.RichTextBox();
            this.btnComprar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCiudad = new System.Windows.Forms.ComboBox();
            this.cboCine = new System.Windows.Forms.ComboBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblCine = new System.Windows.Forms.Label();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.lblClasificacionFiltro = new System.Windows.Forms.Label();
            this.cboGenero = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.rbProximamente = new System.Windows.Forms.RadioButton();
            this.rbHoy = new System.Windows.Forms.RadioButton();
            this.rbManana = new System.Windows.Forms.RadioButton();
            this.rbEstaSemana = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFechaEstreno = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPeliculas
            // 
            this.flowPeliculas.AutoScroll = true;
            this.flowPeliculas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPeliculas.Location = new System.Drawing.Point(43, 195);
            this.flowPeliculas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowPeliculas.Name = "flowPeliculas";
            this.flowPeliculas.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.flowPeliculas.Size = new System.Drawing.Size(756, 168);
            this.flowPeliculas.TabIndex = 0;
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(29, 31);
            this.picPoster.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(292, 214);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPoster.TabIndex = 1;
            this.picPoster.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(42, 19);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(826, 23);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracion.Location = new System.Drawing.Point(476, 55);
            this.lblDuracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(58, 13);
            this.lblDuracion.TabIndex = 3;
            this.lblDuracion.Text = "Duración";
            this.lblDuracion.Click += new System.EventHandler(this.lblDuracion_Click);
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.Location = new System.Drawing.Point(476, 91);
            this.lblClasificacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(79, 13);
            this.lblClasificacion.TabIndex = 4;
            this.lblClasificacion.Text = "Clasificacion";
            this.lblClasificacion.Click += new System.EventHandler(this.lblClasificacion_Click);
            // 
            // txtSinopsis
            // 
            this.txtSinopsis.Location = new System.Drawing.Point(428, 159);
            this.txtSinopsis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSinopsis.Name = "txtSinopsis";
            this.txtSinopsis.ReadOnly = true;
            this.txtSinopsis.Size = new System.Drawing.Size(265, 96);
            this.txtSinopsis.TabIndex = 5;
            this.txtSinopsis.Text = "Sinopsis";
            // 
            // btnComprar
            // 
            this.btnComprar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprar.ForeColor = System.Drawing.Color.White;
            this.btnComprar.Location = new System.Drawing.Point(758, 195);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(167, 30);
            this.btnComprar.TabIndex = 6;
            this.btnComprar.Text = "Comprar Entradas";
            this.btnComprar.UseVisualStyleBackColor = false;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filtros";
            // 
            // cboCiudad
            // 
            this.cboCiudad.FormattingEnabled = true;
            this.cboCiudad.Location = new System.Drawing.Point(124, 154);
            this.cboCiudad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCiudad.Name = "cboCiudad";
            this.cboCiudad.Size = new System.Drawing.Size(140, 21);
            this.cboCiudad.TabIndex = 9;
            this.cboCiudad.SelectedIndexChanged += new System.EventHandler(this.cboCiudad_SelectedIndexChanged);
            // 
            // cboCine
            // 
            this.cboCine.FormattingEnabled = true;
            this.cboCine.Location = new System.Drawing.Point(292, 154);
            this.cboCine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboCine.Name = "cboCine";
            this.cboCine.Size = new System.Drawing.Size(140, 21);
            this.cboCine.TabIndex = 10;
            this.cboCine.SelectedIndexChanged += new System.EventHandler(this.cboCine_SelectedIndexChanged);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.Location = new System.Drawing.Point(166, 130);
            this.lblCiudad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(46, 13);
            this.lblCiudad.TabIndex = 11;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblCine
            // 
            this.lblCine.AutoSize = true;
            this.lblCine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCine.Location = new System.Drawing.Point(348, 130);
            this.lblCine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCine.Name = "lblCine";
            this.lblCine.Size = new System.Drawing.Size(32, 13);
            this.lblCine.TabIndex = 12;
            this.lblCine.Text = "Cine";
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.FormattingEnabled = true;
            this.cboClasificacion.Location = new System.Drawing.Point(460, 154);
            this.cboClasificacion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(140, 21);
            this.cboClasificacion.TabIndex = 13;
            this.cboClasificacion.SelectedIndexChanged += new System.EventHandler(this.cboClasificacion_SelectedIndexChanged);
            // 
            // lblClasificacionFiltro
            // 
            this.lblClasificacionFiltro.AutoSize = true;
            this.lblClasificacionFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacionFiltro.Location = new System.Drawing.Point(488, 130);
            this.lblClasificacionFiltro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClasificacionFiltro.Name = "lblClasificacionFiltro";
            this.lblClasificacionFiltro.Size = new System.Drawing.Size(79, 13);
            this.lblClasificacionFiltro.TabIndex = 14;
            this.lblClasificacionFiltro.Text = "Clasificación";
            // 
            // cboGenero
            // 
            this.cboGenero.FormattingEnabled = true;
            this.cboGenero.Location = new System.Drawing.Point(628, 154);
            this.cboGenero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGenero.Name = "cboGenero";
            this.cboGenero.Size = new System.Drawing.Size(140, 21);
            this.cboGenero.TabIndex = 15;
            this.cboGenero.SelectedIndexChanged += new System.EventHandler(this.cboGenero_SelectedIndexChanged);
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(670, 130);
            this.lblGenero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(48, 13);
            this.lblGenero.TabIndex = 16;
            this.lblGenero.Text = "Género";
            // 
            // rbProximamente
            // 
            this.rbProximamente.AutoSize = true;
            this.rbProximamente.Location = new System.Drawing.Point(864, 322);
            this.rbProximamente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbProximamente.Name = "rbProximamente";
            this.rbProximamente.Size = new System.Drawing.Size(103, 17);
            this.rbProximamente.TabIndex = 17;
            this.rbProximamente.TabStop = true;
            this.rbProximamente.Text = "Proximamente";
            this.rbProximamente.UseVisualStyleBackColor = true;
            this.rbProximamente.CheckedChanged += new System.EventHandler(this.rbProximamente_CheckedChanged);
            // 
            // rbHoy
            // 
            this.rbHoy.AutoSize = true;
            this.rbHoy.Location = new System.Drawing.Point(864, 250);
            this.rbHoy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbHoy.Name = "rbHoy";
            this.rbHoy.Size = new System.Drawing.Size(47, 17);
            this.rbHoy.TabIndex = 18;
            this.rbHoy.TabStop = true;
            this.rbHoy.Text = "Hoy";
            this.rbHoy.UseVisualStyleBackColor = true;
            this.rbHoy.CheckedChanged += new System.EventHandler(this.rbHoy_CheckedChanged);
            // 
            // rbManana
            // 
            this.rbManana.AutoSize = true;
            this.rbManana.Location = new System.Drawing.Point(864, 274);
            this.rbManana.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbManana.Name = "rbManana";
            this.rbManana.Size = new System.Drawing.Size(70, 17);
            this.rbManana.TabIndex = 19;
            this.rbManana.TabStop = true;
            this.rbManana.Text = "Mañana";
            this.rbManana.UseVisualStyleBackColor = true;
            this.rbManana.CheckedChanged += new System.EventHandler(this.rbManana_CheckedChanged);
            // 
            // rbEstaSemana
            // 
            this.rbEstaSemana.AutoSize = true;
            this.rbEstaSemana.Location = new System.Drawing.Point(864, 298);
            this.rbEstaSemana.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbEstaSemana.Name = "rbEstaSemana";
            this.rbEstaSemana.Size = new System.Drawing.Size(99, 17);
            this.rbEstaSemana.TabIndex = 20;
            this.rbEstaSemana.TabStop = true;
            this.rbEstaSemana.Text = "Esta Semana";
            this.rbEstaSemana.UseVisualStyleBackColor = true;
            this.rbEstaSemana.CheckedChanged += new System.EventHandler(this.rbEstaSemana_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(850, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Filtrar por Fecha";
            // 
            // lblFechaEstreno
            // 
            this.lblFechaEstreno.AutoSize = true;
            this.lblFechaEstreno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEstreno.Location = new System.Drawing.Point(658, 55);
            this.lblFechaEstreno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaEstreno.Name = "lblFechaEstreno";
            this.lblFechaEstreno.Size = new System.Drawing.Size(89, 13);
            this.lblFechaEstreno.TabIndex = 22;
            this.lblFechaEstreno.Text = "Fecha Estreno";
            this.lblFechaEstreno.Click += new System.EventHandler(this.lblFechaEstreno_Click);
            // 
            // lblDisponible
            // 
            this.lblDisponible.AutoSize = true;
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.Location = new System.Drawing.Point(658, 91);
            this.lblDisponible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(103, 13);
            this.lblDisponible.TabIndex = 23;
            this.lblDisponible.Text = "Disponible Hasta\n";
            this.lblDisponible.Click += new System.EventHandler(this.lblDisponible_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(850, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "de Estreno:";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(841, 147);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(140, 30);
            this.btnLimpiarFiltros.TabIndex = 25;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(476, 127);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(46, 13);
            this.lblEstado.TabIndex = 26;
            this.lblEstado.Text = "Estado";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetalle.Controls.Add(this.lblEstado);
            this.pnlDetalle.Controls.Add(this.lblTitulo);
            this.pnlDetalle.Controls.Add(this.lblFechaEstreno);
            this.pnlDetalle.Controls.Add(this.lblDuracion);
            this.pnlDetalle.Controls.Add(this.lblDisponible);
            this.pnlDetalle.Controls.Add(this.lblClasificacion);
            this.pnlDetalle.Controls.Add(this.txtSinopsis);
            this.pnlDetalle.Controls.Add(this.btnComprar);
            this.pnlDetalle.Controls.Add(this.picPoster);
            this.pnlDetalle.Location = new System.Drawing.Point(14, 392);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(953, 276);
            this.pnlDetalle.TabIndex = 27;
            this.pnlDetalle.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(528, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(184, 20);
            this.label14.TabIndex = 44;
            this.label14.Text = "Películas en Cartelera";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(40, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 84);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(528, 58);
            this.label35.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(192, 20);
            this.label35.TabIndex = 76;
            this.label35.Text = "¡Vive la magia del cine!";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Crimson;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(878, 355);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 30);
            this.btnSalir.TabIndex = 77;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCarteleraPublica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1048, 667);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbEstaSemana);
            this.Controls.Add(this.rbManana);
            this.Controls.Add(this.rbHoy);
            this.Controls.Add(this.rbProximamente);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.cboGenero);
            this.Controls.Add(this.lblClasificacionFiltro);
            this.Controls.Add(this.cboClasificacion);
            this.Controls.Add(this.lblCine);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.cboCine);
            this.Controls.Add(this.cboCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowPeliculas);
            this.Controls.Add(this.pnlDetalle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmCarteleraPublica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuestra Cartelera";
            this.Load += new System.EventHandler(this.FrmCarteleraPublica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPeliculas;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.RichTextBox txtSinopsis;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCiudad;
        private System.Windows.Forms.ComboBox cboCine;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblCine;
        private System.Windows.Forms.ComboBox cboClasificacion;
        private System.Windows.Forms.Label lblClasificacionFiltro;
        private System.Windows.Forms.ComboBox cboGenero;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.RadioButton rbProximamente;
        private System.Windows.Forms.RadioButton rbHoy;
        private System.Windows.Forms.RadioButton rbManana;
        private System.Windows.Forms.RadioButton rbEstaSemana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFechaEstreno;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnSalir;
    }
}