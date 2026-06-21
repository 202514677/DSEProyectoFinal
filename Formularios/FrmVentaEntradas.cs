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
using QRCoder;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmVentaEntradas : Form
    {
        private Timer timerReserva = new Timer();

        private int segundosRestantes =   180;

        private int ultimoHorarioSeleccionado = -1;

        private bool restaurandoHorario = false;


        public int IdPeliculaSeleccionada
        {
            get;
            set;
        }

        public FrmVentaEntradas()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private Horario horario = new Horario();

        private Cliente cliente = new Cliente();

        private Venta venta = new Venta();

        private ReservaTemporal reserva = new ReservaTemporal();

        private void FrmVentaEntradas_Load( object sender, EventArgs e)
        {
            reserva.EliminarExpirados();

            cboMetodoPago.DropDownStyle =
            ComboBoxStyle.DropDownList;

            cboHorario.DropDownStyle =
            ComboBoxStyle.DropDownList;

            cboMetodoPago.Items.Clear();

            cboMetodoPago.Items.Add("YAPE");
            cboMetodoPago.Items.Add("PLIN");
            cboMetodoPago.Items.Add("TARJETA");

            txtDni.MaxLength = 8;

            txtCelular.MaxLength = 9;

            txtCelularPago.MaxLength = 9;

            txtNumeroTarjeta.MaxLength = 16;

            txtCVV.MaxLength = 3;

            picQR.SizeMode =
            PictureBoxSizeMode.Zoom;

            timerReserva.Interval = 1000;

            timerReserva.Tick +=
            TimerReserva_Tick;

            lblTiempo.Text = "03:00";

            Limpiar();

            if (IdPeliculaSeleccionada > 0)
            {
                CargarHorariosPeliculaSeleccionada();
            }
            else
            {
                CargarHorarios();
            }

            pnlYapePlin.Visible = false;

            pnlTarjeta.Visible = false;
        }

        private void Limpiar()
        {
            // Cliente
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCelular.Clear();
            txtEmail.Clear();

            // Función
            txtPelicula.Clear();
            txtCine.Clear();
            txtSala.Clear();
            txtTipoSala.Clear();
            txtFecha.Clear();
            txtPrecio.Clear();

            // Pago
            txtCelularPago.Clear();
            txtNumeroAutorizacion.Clear();

            txtNumeroTarjeta.Clear();
            txtTitular.Clear();
            txtCVV.Clear();

            cboMarca.SelectedIndex = -1;

            cboMes.SelectedIndex = -1;

            cboAnio.SelectedIndex = -1;

            cboMetodoPago.SelectedIndex = -1;

            // Totales
            txtCantidad.Text = "0";
            txtSubTotal.Text = "0.00";
            txtIGV.Text = "0.00";
            txtTotal.Text = "0.00";

            cboHorario.SelectedIndex = -1;

            // Asientos
            lstDisponibles.Items.Clear();
            lstSeleccionados.Items.Clear();

            // QR
            picQR.Image = null;

            pnlYapePlin.Visible = false;
            pnlTarjeta.Visible = false;

            ConfigurarModoCliente(false);

            cboHorario.Enabled = true;
        }

        private void ModoNuevo()
        {
            btnProcesarVenta.Enabled = true;
        }

        private void CargarHorarios()
        {
            DataTable dt =
            horario.ListarVentaEntradas();

            cboHorario.DataSource = null;

            cboHorario.DisplayMember =
            "Descripcion";

            cboHorario.ValueMember =
            "IdHorario";

            cboHorario.DataSource = dt;

            cboHorario.SelectedIndex = -1;
        }

        private void cboHorario_SelectedIndexChanged(
  object sender,
  EventArgs e)
        {
            if (restaurandoHorario)
                return;

            if (cboHorario.SelectedIndex == -1)
            {
                txtPelicula.Clear();
                txtCine.Clear();
                txtSala.Clear();
                txtTipoSala.Clear();
                txtFecha.Clear();
                txtPrecio.Clear();

                return;
            }

            if (cboHorario.SelectedValue == null)
                return;

            if (cboHorario.SelectedValue is DataRowView)
                return;

            if (lstSeleccionados.Items.Count > 0)
            {
                DialogResult respuesta =
                MessageBox.Show(

                "Se perderán los asientos seleccionados.\n\n¿Desea cambiar de horario?",

                "CINEPELIS",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                {
                    restaurandoHorario = true;

                    if (ultimoHorarioSeleccionado > 0)
                    {
                        cboHorario.SelectedValue =
                        ultimoHorarioSeleccionado;
                    }

                    restaurandoHorario = false;

                    return;
                }

                LiberarReservasSeleccionadas();

                lstSeleccionados.Items.Clear();

                timerReserva.Stop();

                segundosRestantes = 180;

                lblTiempo.Text = "03:00";
            }

            ultimoHorarioSeleccionado =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            MostrarHorario();

            RefrescarAsientos();

            CalcularTotales();
        }
        private void MostrarHorario()
        {
            if (cboHorario.SelectedValue == null)
                return;

            if (cboHorario.SelectedValue is DataRowView)
                return;

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            DataTable dt =
            horario.ObtenerHorarioVenta(
            idHorario);

            if (dt.Rows.Count == 0)
                return;

            txtPelicula.Text =
            dt.Rows[0]["Titulo"]
            .ToString();

            txtCine.Text =
            dt.Rows[0]["Cine"]
            .ToString();

            txtSala.Text =
            dt.Rows[0]["NumSala"]
            .ToString();

            txtTipoSala.Text =
            dt.Rows[0]["TipoSala"]
            .ToString();

            txtFecha.Text =
            Convert.ToDateTime(
            dt.Rows[0]["FechaInicio"])
            .ToShortDateString();

            txtPrecio.Text =
            dt.Rows[0]["PrecioVentaPublico"]
            .ToString();
        }

        private void GenerarAsientos()
        {
            lstDisponibles.Items.Clear();

            for (char fila = 'A';
                fila <= 'J';
                fila++)
            {
                for (int numero = 1;
                    numero <= 10;
                    numero++)
                {
                    lstDisponibles.Items.Add(
                    fila.ToString() +
                    numero.ToString());
                }
            }
        }

        private void MarcarOcupados()
        {
            if (cboHorario.SelectedValue == null)
                return;

            if (cboHorario.SelectedValue is DataRowView)
                return;

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            // VENDIDOS

            DataTable dtVendidos =
            venta.ObtenerAsientosOcupados(
            idHorario);

            foreach (DataRow fila
                in dtVendidos.Rows)
            {
                string asiento =
                fila["Asiento"]
                .ToString();

                lstDisponibles
                .Items
                .Remove(asiento);
            }

            // RESERVADOS

            DataTable dtReservados =
            reserva.ObtenerReservados(
            idHorario);

            foreach (DataRow fila
                in dtReservados.Rows)
            {
                string asiento =
                fila["Asiento"]
                .ToString();

                lstDisponibles
                .Items
                .Remove(asiento);
            }
        }

        private void btnAgregarAsiento_Click( object sender,  EventArgs e)
        {
            if (cboHorario.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione un horario");

                cboHorario.Focus();

                return;
            }

            if (lstDisponibles.SelectedItem == null)
            {
                MessageBox.Show(
                "Seleccione un asiento");

                return;
            }

            string asiento =
            lstDisponibles
            .SelectedItem
            .ToString();

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            if (reserva.ExisteReserva(
                idHorario,
                asiento))
            {
                MessageBox.Show(
                "El asiento ya fue reservado por otro usuario.");

                RefrescarAsientos();

                return;
            }

            if (venta.ExisteAsientoOcupado(
                idHorario,
                asiento))
            {
                MessageBox.Show(
                "El asiento ya fue vendido.");

                RefrescarAsientos();

                return;
            }

            ReservaTemporal nuevaReserva =
            new ReservaTemporal();

            nuevaReserva.idHorario =
            idHorario;

            nuevaReserva.asiento =
            asiento;

            if (!nuevaReserva.InsertarReserva())
            {
                MessageBox.Show(
                "No se pudo reservar el asiento.");

                RefrescarAsientos();

                return;
            }

            lstSeleccionados.Items.Add(
            asiento);

            List<string> lista =
            lstSeleccionados.Items
            .Cast<string>()
            .OrderBy(x => x)
            .ToList();

            lstSeleccionados.Items.Clear();

            foreach (string item in lista)
            {
                lstSeleccionados.Items.Add(
                item);
            }

            lstDisponibles.Items.Remove(
            asiento);

            CalcularTotales();

            if (lstSeleccionados.Items.Count == 1)
            {
                IniciarTemporizador();
            }
        }

        private void btnQuitarAsiento_Click( object sender, EventArgs e)
        {
            if (lstSeleccionados.SelectedItem == null)
            {
                MessageBox.Show(
                "Seleccione un asiento");

                return;
            }

            string asiento =
            lstSeleccionados
            .SelectedItem
            .ToString();

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            if (!reserva.EliminarReserva(
                idHorario,
                asiento))
            {
                MessageBox.Show(
                "No se pudo liberar el asiento");

                return;
            }

            lstDisponibles.Items.Add(
            asiento);

            List<string> lista =
            lstDisponibles.Items
            .Cast<string>()
            .OrderBy(x => x)
            .ToList();

            lstDisponibles.Items.Clear();

            foreach (string item in lista)
            {
                lstDisponibles.Items.Add(item);
            }

            lstSeleccionados.Items.Remove(
            asiento);

            CalcularTotales();

            if (lstSeleccionados.Items.Count == 0)
            {
                timerReserva.Stop();

                segundosRestantes = 180;

                lblTiempo.Text = "03:00";

                lblTiempo.ForeColor =
                Color.Black;

                RefrescarAsientos();
            }
        }

        private void CalcularTotales()
        {
            int cantidad =
            lstSeleccionados.Items.Count;

            decimal precio = 0;

            decimal.TryParse(
                txtPrecio.Text,
                out precio);

            decimal subtotal =
            cantidad * precio;

            decimal igv =
            subtotal * 0.18m;

            decimal total =
            subtotal + igv;

            txtCantidad.Text =
            cantidad.ToString();

            txtSubTotal.Text =
            subtotal.ToString("0.00");

            txtIGV.Text =
            igv.ToString("0.00");

            txtTotal.Text =
            total.ToString("0.00");
        }

        private void cboMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlYapePlin.Visible = false;

            pnlTarjeta.Visible = false;

            if (cboMetodoPago.Text == "YAPE")
            {
                pnlYapePlin.Visible = true;
            }

            if (cboMetodoPago.Text == "PLIN")
            {
                pnlYapePlin.Visible = true;
            }

            if (cboMetodoPago.Text == "TARJETA")
            {
                pnlTarjeta.Visible = true;
            }
        }

        private void BuscarCliente()
        {
            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese DNI");

                txtDni.Focus();

                return;
            }

            DataTable dt =
            cliente.BuscarPorDni(
            txtDni.Text.Trim());

            if (dt == null ||
                dt.Rows.Count == 0)
            {
                MessageBox.Show(
                "Cliente no encontrado. Puede registrar uno nuevo.");

                txtNombre.Clear();
                txtApellido.Clear();
                txtCelular.Clear();
                txtEmail.Clear();

                ConfigurarModoCliente(false);

                txtNombre.Focus();

                return;
            }

            txtNombre.Text =
            dt.Rows[0]["Nombre"]
            .ToString();

            txtApellido.Text =
            dt.Rows[0]["Apellido"]
            .ToString();

            txtCelular.Text =
            dt.Rows[0]["Celular"]
            .ToString();

            txtEmail.Text =
            dt.Rows[0]["Email"]
            .ToString();

            ConfigurarModoCliente(true);

            MessageBox.Show(
            "Cliente encontrado");
        }


        private bool ValidarPago()
        {
            if (cboMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione forma de pago");

                cboMetodoPago.Focus();

                return false;
            }

            // YAPE Y PLIN
            if (
                cboMetodoPago.Text == "YAPE"
                ||
                cboMetodoPago.Text == "PLIN")
            {
                if (txtCelularPago.Text.Trim() == "")
                {
                    MessageBox.Show(
                    "Ingrese celular de pago");

                    txtCelularPago.Focus();

                    return false;
                }

                if (txtCelularPago.Text.Length != 9)
                {
                    MessageBox.Show(
                    "El celular debe tener 9 dígitos");

                    txtCelularPago.Focus();

                    return false;
                }

                if (!txtCelularPago.Text.StartsWith("9"))
                {
                    MessageBox.Show(
                    "El celular debe empezar con 9");

                    txtCelularPago.Focus();

                    return false;
                }

                if (txtNumeroAutorizacion.Text.Trim() == "")
                {
                    MessageBox.Show(
                    "Ingrese número de autorización");

                    txtNumeroAutorizacion.Focus();

                    return false;
                }

                // Simulación de rechazo
                if (txtCelularPago.Text ==
                    "999999999")
                {
                    MessageBox.Show(
                    "Transacción rechazada");

                    return false;
                }

                return true;
            }

            // TARJETA
            if (cboMetodoPago.Text == "TARJETA")
            {
                if (txtNumeroTarjeta.Text.Trim() == "")
                {
                    MessageBox.Show(
                    "Ingrese número de tarjeta");

                    txtNumeroTarjeta.Focus();

                    return false;
                }

                if (txtNumeroTarjeta.Text.Length != 16)
                {
                    MessageBox.Show(
                    "La tarjeta debe tener 16 dígitos");

                    txtNumeroTarjeta.Focus();

                    return false;
                }

                if (cboMarca.SelectedIndex == -1)
                {
                    MessageBox.Show(
                    "Seleccione la marca de la tarjeta");

                    cboMarca.Focus();

                    return false;
                }

                if (cboMes.SelectedIndex == -1)
                {
                    MessageBox.Show(
                    "Seleccione el mes de vencimiento");

                    cboMes.Focus();

                    return false;
                }

                if (cboAnio.SelectedIndex == -1)
                {
                    MessageBox.Show(
                    "Seleccione el año de vencimiento");

                    cboAnio.Focus();

                    return false;
                }

                // Validar fecha de vencimiento
                int mesSeleccionado =
                Convert.ToInt32(
                cboMes.Text);

                int anioSeleccionado =
                Convert.ToInt32(
                cboAnio.Text);

                int mesActual =
                DateTime.Now.Month;

                int anioActual =
                DateTime.Now.Year;

                if (anioSeleccionado < anioActual)
                {
                    MessageBox.Show(

                    "La tarjeta seleccionada se encuentra vencida.",

                    "CINEPELIS",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Warning);

                    cboAnio.Focus();

                    return false;
                }

                if (
                    anioSeleccionado == anioActual
                    &&
                    mesSeleccionado < mesActual)
                {
                    MessageBox.Show(

                    "La tarjeta seleccionada se encuentra vencida.",

                    "CINEPELIS",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Warning);

                    cboMes.Focus();

                    return false;
                }

                // Evitar años irreales
                if (
                    anioSeleccionado >
                    DateTime.Now.Year + 10)
                {
                    MessageBox.Show(

                    "Año de expiración inválido",

                    "CINEPELIS",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Warning);

                    cboAnio.Focus();

                    return false;
                }

                if (txtTitular.Text.Trim() == "")
                {
                    MessageBox.Show(
                    "Ingrese nombre del titular");

                    txtTitular.Focus();

                    return false;
                }

                if (txtCVV.Text.Trim() == "")
                {
                    MessageBox.Show(
                    "Ingrese CVV");

                    txtCVV.Focus();

                    return false;
                }

                if (txtCVV.Text.Length != 3)
                {
                    MessageBox.Show(
                    "CVV inválido");

                    txtCVV.Focus();

                    return false;
                }

                // Simulación de fondos insuficientes
                if (
                    txtNumeroTarjeta.Text ==
                    "1111111111111111")
                {
                    MessageBox.Show(

                    "Fondos insuficientes",

                    "CINEPELIS",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Warning);

                    return false;
                }

                return true;
            }

            MessageBox.Show(
            "Seleccione forma de pago");

            return false;
        }

        private void btnNuevo_Click( object sender, EventArgs e)
        {
            LiberarReservasSeleccionadas();

            timerReserva.Stop();

            segundosRestantes = 180;

            lblTiempo.Text = "03:00";

            lblTiempo.ForeColor =
            Color.Black;

            Limpiar();

            GenerarAsientos();

            ultimoHorarioSeleccionado = -1;

            restaurandoHorario = false;

            cboHorario.Enabled = true;

            CargarHorarios();

            cboHorario.SelectedIndex = -1;

            btnProcesarVenta.Enabled = true;

            txtDni.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarDatosVenta()
        {
            if (!ValidarDni())
            {
                return false;
            }

            if (!ValidarCelular())
            {
                return false;
            }

            if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese DNI");

                return false;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese Nombre");

                return false;
            }

            if (cboHorario.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione horario");

                return false;
            }

            if (lstSeleccionados.Items.Count == 0)
            {
                MessageBox.Show(
                "Seleccione al menos un asiento");

                return false;
            }

            if (!ValidarCelularPago())
            {
                return false;
            }

            return true;
        }

        private string GenerarCodigoTicket()
        {
            return "TK-" +
                   DateTime.Now.ToString(
                   "yyyyMMddHHmmss");
        }

        private string GenerarTextoQR(string codigoTicket)
        {
            string asientos = "";

            foreach (var item in lstSeleccionados.Items)
            {
                asientos +=
                item.ToString() + " ";
            }

            return
            "TICKET: " + codigoTicket +

            "\nPELICULA: " +
            txtPelicula.Text +

            "\nCINE: " +
            txtCine.Text +

            "\nSALA: " +
            txtSala.Text +

            "\nTIPO SALA: " +
            txtTipoSala.Text +

            "\nFECHA: " +
            txtFecha.Text +

            "\nCLIENTE DNI: " +
            txtDni.Text +

            "\nCLIENTE: " +
            txtNombre.Text + " " +
            txtApellido.Text +

            "\nASIENTOS: " +
            asientos +

            "\nTOTAL: S/ " +
            txtTotal.Text +

            "\nCinePelis. Muchas gracias por su compra";
        }

        private void GenerarQR(string textoQR)
        {
            QRCodeGenerator qrGenerator =
            new QRCodeGenerator();

            QRCodeData qrCodeData =
            qrGenerator.CreateQrCode(
            textoQR,
            QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode =
            new QRCode(qrCodeData);

            Bitmap qrImage = qrCode.GetGraphic(25);

            picQR.Image =
            qrImage;
        }

        private void MostrarTicket(string codigoTicket)
        {
            string asientos = "";

            foreach (var item
                in lstSeleccionados.Items)
            {
                asientos +=
                item.ToString() + " ";
            }

            MessageBox.Show(

             "TICKET: " + codigoTicket +

            "\nPELICULA: " +
            txtPelicula.Text +

            "\nCINE: " +
            txtCine.Text +

            "\nSALA: " +
            txtSala.Text +

            "\nTIPO SALA: " +
            txtTipoSala.Text +

            "\nFECHA: " +
            txtFecha.Text +

            "\nCLIENTE DNI: " +
            txtDni.Text +

            "\nCLIENTE: " +
            txtNombre.Text + " " +
            txtApellido.Text +

            "\nASIENTOS: " +
            asientos +

            "\nTOTAL: S/ " +
            txtTotal.Text +

            "\nCinePelis. Muchas gracias por su compra");
        }

        private void btnProcesarVenta_Click( object sender, EventArgs e)
        {
            btnProcesarVenta.Enabled = false;

            try
            {
                if (!ValidarDatosVenta())
                    return;

                if (!ValidarDisponibilidad())
                    return;

                if (!ValidarPago())
                    return;

                string codigoTicket =
                GenerarCodigoTicket();

                int idCliente = 0;

                DataTable dtCliente =
                cliente.BuscarPorDni(
                txtDni.Text.Trim());

                if (dtCliente.Rows.Count > 0)
                {
                    idCliente =
                    Convert.ToInt32(
                    dtCliente.Rows[0]["IdCliente"]);
                }
                else
                {
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

                    nuevoCliente.activo = 1;

                    if (!nuevoCliente.Registrar())
                    {
                        MessageBox.Show(
                        "Error al registrar cliente");

                        return;
                    }

                    DataTable dtNuevo =
                    cliente.BuscarPorDni(
                    txtDni.Text.Trim());

                    if (dtNuevo.Rows.Count == 0)
                    {
                        MessageBox.Show(
                        "No se pudo registrar el cliente");

                        return;
                    }

                    idCliente =
                    Convert.ToInt32(
                    dtNuevo.Rows[0]["IdCliente"]);
                }

                Venta nuevaVenta =
                new Venta();

                nuevaVenta.idCliente =
                idCliente;

                nuevaVenta.idHorario =
                Convert.ToInt32(
                cboHorario.SelectedValue);

                nuevaVenta.cantidadEntradas =
                lstSeleccionados.Items.Count;

                nuevaVenta.subTotal =
                Convert.ToDecimal(
                txtSubTotal.Text);

                nuevaVenta.igv =
                Convert.ToDecimal(
                txtIGV.Text);

                nuevaVenta.total =
                Convert.ToDecimal(
                txtTotal.Text);

                nuevaVenta.metodoPago =
                cboMetodoPago.Text;

                nuevaVenta.estado =
                "PAGADO";

                nuevaVenta.codigoTicket =
                codigoTicket;

                nuevaVenta.usuarioRegistro =
                1;

                if (cboMetodoPago.Text == "TARJETA")
                {
                    string tarjeta =
                    txtNumeroTarjeta.Text;

                    nuevaVenta.ultimos4Tarjeta =
                    tarjeta.Substring(
                    tarjeta.Length - 4);
                }
                else
                {
                    nuevaVenta.numeroAutorizacion =
                    txtNumeroAutorizacion.Text;
                }

                int idVenta =
                nuevaVenta.Registrar();

                if (idVenta == 0)
                {
                    MessageBox.Show(
                    "Error al registrar venta");

                    return;
                }

                foreach (var item
                    in lstSeleccionados.Items)
                {
                    DetalleVenta detalle =
                    new DetalleVenta();

                    detalle.idVenta =
                    idVenta;

                    detalle.asiento =
                    item.ToString();

                    detalle.precio =
                    Convert.ToDecimal(
                    txtPrecio.Text);

                    if (!detalle.Registrar())
                    {
                        MessageBox.Show(

                        "No se pudo registrar el asiento: " +

                        item.ToString(),

                        "Error",

                        MessageBoxButtons.OK,

                        MessageBoxIcon.Error);

                        return;
                    }
                }

                VentaRepositorio repo =
                new VentaRepositorio();

                repo.ActualizarEntradasVendidas(
                Convert.ToInt32(
                cboHorario.SelectedValue),

                lstSeleccionados.Items.Count);

                string textoQR =
                GenerarTextoQR(
                codigoTicket);

                GenerarQR(
                textoQR);

                LiberarReservasSeleccionadas();

                timerReserva.Stop();

                segundosRestantes = 180;

                lblTiempo.Text = "03:00";

                lblTiempo.ForeColor =
                Color.Black;

                MostrarTicket(
                codigoTicket);

                MessageBox.Show(
                "Venta registrada correctamente");

                IdPeliculaSeleccionada = 0;

                btnNuevo.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(

                "Ocurrió un error al procesar la venta.\n\n" +

                ex.Message,

                "CINEPELIS",

                MessageBoxButtons.OK,

                MessageBoxIcon.Error);
            }
            finally
            {
                btnProcesarVenta.Enabled = true;
            }
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarCliente();
            }
        }

        private void ConfigurarModoCliente(bool clienteExistente)
        {
            txtNombre.ReadOnly =
            clienteExistente;

            txtApellido.ReadOnly =
            clienteExistente;

            txtCelular.ReadOnly =
            clienteExistente;

            txtEmail.ReadOnly =
            clienteExistente;
        }

        private bool ValidarDni()
        {
            if (txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show(
                "El DNI debe tener 8 dígitos");

                txtDni.Focus();

                return false;
            }

            if (!txtDni.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                "El DNI solo debe contener números");

                txtDni.Focus();

                return false;
            }

            return true;
        }

        private bool ValidarCelular()
        {
            if (txtCelular.Text.Trim().Length != 9)
            {
                MessageBox.Show(
                "El celular debe tener 9 dígitos");

                txtCelular.Focus();

                return false;
            }

            if (!txtCelular.Text.StartsWith("9"))
            {
                MessageBox.Show(
                "El celular debe iniciar con 9");

                txtCelular.Focus();

                return false;
            }

            if (!txtCelular.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                "El celular solo debe contener números");

                txtCelular.Focus();

                return false;
            }

            return true;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&  !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCelularPago()
        {
            if (cboMetodoPago.Text != "YAPE" &&
                cboMetodoPago.Text != "PLIN")
            {
                return true;
            }

            if (txtCelularPago.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese el celular del pago");

                txtCelularPago.Focus();

                return false;
            }

            if (txtCelularPago.Text.Trim().Length != 9)
            {
                MessageBox.Show(
                "El celular de pago debe tener 9 dígitos");

                txtCelularPago.Focus();

                return false;
            }

            if (!txtCelularPago.Text.StartsWith("9"))
            {
                MessageBox.Show(
                "El celular de pago debe iniciar con 9");

                txtCelularPago.Focus();

                return false;
            }

            if (!txtCelularPago.Text.All(char.IsDigit))
            {
                MessageBox.Show(
                "El celular de pago solo debe contener números");

                txtCelularPago.Focus();

                return false;
            }

            return true;
        }

        private void txtCelularPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarDisponibilidad()
        {
            if (cboHorario.SelectedValue == null)
            {
                MessageBox.Show(
                "Seleccione un horario");

                return false;
            }

            if (cboHorario.SelectedValue is DataRowView)
            {
                return false;
            }

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            DataTable dt =
            horario.ObtenerDisponibilidad(
            idHorario);

            if (dt == null ||
                dt.Rows.Count == 0)
            {
                MessageBox.Show(
                "Horario no encontrado");

                return false;
            }

            int disponibles =
            Convert.ToInt32(
            dt.Rows[0]["CantidadVentaPublico"]);

            int vendidos =
            Convert.ToInt32(
            dt.Rows[0]["EntradasVendidas"]);

            int solicitados =
            lstSeleccionados.Items.Count;

            int restantes =
            disponibles - vendidos;

            if (solicitados > restantes)
            {
                MessageBox.Show(
                "Solo quedan " +
                restantes +
                " entradas disponibles.");

                return false;
            }

            return true;
        }

        private void IniciarTemporizador()
        {
            if (timerReserva.Enabled)
                return;

            segundosRestantes = 180;

            lblTiempo.Text = "03:00";

            lblTiempo.ForeColor =
            Color.Black;

            timerReserva.Start();
        }

        private void TimerReserva_Tick( object sender, EventArgs e)
        {
            segundosRestantes--;

            TimeSpan tiempo =
            TimeSpan.FromSeconds(
            segundosRestantes);

            lblTiempo.Text =
            tiempo.ToString(@"mm\:ss");

            if (segundosRestantes <= 30)
            {
                lblTiempo.ForeColor =
                Color.Red;
            }
            else
            {
                lblTiempo.ForeColor =
                Color.Black;
            }

            if (segundosRestantes <= 0)
            {
                timerReserva.Stop();

                LiberarReservasSeleccionadas();

                MessageBox.Show(
                "Tiempo agotado.\nLos asientos fueron liberados.");

                lstSeleccionados.Items.Clear();

                RefrescarAsientos();

                CalcularTotales();

                lblTiempo.Text = "03:00";

                lblTiempo.ForeColor =
                Color.Black;

                segundosRestantes = 180;
            }
        }

        private void LiberarReservasSeleccionadas()
        {
            if (cboHorario.SelectedValue == null)
                return;

            if (cboHorario.SelectedValue is DataRowView)
                return;

            int idHorario =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            foreach (var item
                in lstSeleccionados.Items)
            {
                reserva.EliminarReserva(
                    idHorario,
                    item.ToString());
            }
        }
        private void RefrescarAsientos()
        {
            lstDisponibles.Items.Clear();

            GenerarAsientos();

            MarcarOcupados();

            CalcularTotales();
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmVentaEntradas_FormClosing(object sender, FormClosingEventArgs e)
        {
            LiberarReservasSeleccionadas();

            timerReserva.Stop();

            segundosRestantes = 180;

            IdPeliculaSeleccionada = 0;
        }

        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&  !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CargarHorariosPeliculaSeleccionada()
        {
            if (IdPeliculaSeleccionada <= 0)
            {
                CargarHorarios();
                return;
            }

            DataTable dt =
            horario.ListarVentaEntradasPorPelicula(
            IdPeliculaSeleccionada);

            if (dt == null ||
                dt.Rows.Count == 0)
            {
                MessageBox.Show(
                "No existen horarios para esta película");

                cboHorario.DataSource = null;

                txtPelicula.Clear();
                txtCine.Clear();
                txtSala.Clear();
                txtTipoSala.Clear();
                txtFecha.Clear();
                txtPrecio.Clear();

                return;
            }

            cboHorario.DataSource = null;

            cboHorario.DisplayMember =
            "Descripcion";

            cboHorario.ValueMember =
            "IdHorario";

            cboHorario.DataSource =
            dt;

            // Si solo hay un horario, lo selecciona automáticamente
            if (dt.Rows.Count == 1)
            {
                cboHorario.SelectedIndex = 0;

                // Viene desde Cartelera Pública
                cboHorario.Enabled = false;
            }
            else
            {
                // Hay varios horarios para la misma película
                cboHorario.Enabled = true;

                // Selecciona el primero para mostrar la información
                cboHorario.SelectedIndex = 0;
            }

            ultimoHorarioSeleccionado =
            Convert.ToInt32(
            cboHorario.SelectedValue);

            MostrarHorario();

            RefrescarAsientos();

            CalcularTotales();
        }


    }
}
