using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;
using QRCoder;
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
    public partial class FrmVentaDulceria : Form
    {

        private Cliente cliente = new Cliente();

        private ProductoDulceria producto =  new ProductoDulceria();

        private VentaDulceria venta = new VentaDulceria();

        private DetalleVentaDulceria detalle = new DetalleVentaDulceria();

        private ProductoDulceriaRepositorio productoRepositorio =  new ProductoDulceriaRepositorio();

        private string codigoTicketActual = "";
     
        public FrmVentaDulceria()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmVentaDulceria_Load( object sender, EventArgs e)
        {
            ConfigurarGrid();

            CargarProductos();

            CargarMetodoPago();

            OcultarPanelesPago();

            Limpiar();


        }

        private void ConfigurarGrid()
        {
            dgvDetalle.Columns.Clear();

            dgvDetalle.Columns.Add(
                "IdProducto",
                "IdProducto");

            dgvDetalle.Columns.Add(
                "Producto",
                "Producto");

            dgvDetalle.Columns.Add(
                "Cantidad",
                "Cantidad");

            dgvDetalle.Columns.Add(
                "Precio",
                "Precio");

            dgvDetalle.Columns.Add(
                "SubTotal",
                "SubTotal");


            dgvDetalle.Columns["IdProducto"].Visible =
            false;

            dgvDetalle.Columns["Producto"].Width =
            140;

            dgvDetalle.Columns["Cantidad"].Width =
            60;

            dgvDetalle.Columns["Precio"].Width =
            70;

            dgvDetalle.Columns["SubTotal"].Width =
            80;


            dgvDetalle.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvDetalle.MultiSelect = false;

            dgvDetalle.AllowUserToAddRows = false;

            dgvDetalle.ReadOnly = true;
        }

        private void CargarProductos()
        {
            cboProducto.DataSource =
            producto.Listar();

            cboProducto.DisplayMember =
            "Nombre";

            cboProducto.ValueMember =
            "IdProducto";

            cboProducto.SelectedIndex = -1;
        }

        private void CargarMetodoPago()
        {
            cboMetodoPago.Items.Clear();

            cboMetodoPago.Items.Add(
                "EFECTIVO");

            cboMetodoPago.Items.Add(
                "YAPE");

            cboMetodoPago.Items.Add(
                "PLIN");

            cboMetodoPago.Items.Add(
                "TARJETA");

            cboMetodoPago.SelectedIndex = -1;
        }

        private void OcultarPanelesPago()
        {
            pnlYapePlin.Visible =
            false;

            pnlTarjeta.Visible =
            false;
        }
        private void Limpiar()
        {
            txtDni.Clear();

            txtNombre.Clear();

            txtApellido.Clear();

            txtCelular.Clear();

            txtEmail.Clear();


            cboProducto.SelectedIndex = -1;

            txtPrecio.Clear();

            nudCantidad.Text = "1";

            txtStock.Clear();


            dgvDetalle.Rows.Clear();


            txtCantidad.Text = "0";

            txtSubTotal.Text = "0.00";

            txtIGV.Text = "0.00";

            txtTotal.Text = "0.00";


            cboMetodoPago.SelectedIndex = -1;


            txtCelularPago.Clear();

            txtNumeroAutorizacion.Clear();

            txtNumeroTarjeta.Clear();

            txtTitular.Clear();

            txtCVV.Clear();


            cboMarca.SelectedIndex = -1;

            cboMes.SelectedIndex = -1;

            cboAnio.SelectedIndex = -1;


            picQR.Image = null;

            OcultarPanelesPago();

            txtDni.Focus();
        }

        private void BuscarCliente()
        {
            if (txtDni.Text.Trim() == "")
                return;

            DataTable dt =
            cliente.BuscarPorDni(
            txtDni.Text.Trim());

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                "Cliente no encontrado");

                txtNombre.Clear();
                txtApellido.Clear();
                txtCelular.Clear();
                txtEmail.Clear();

                return;
            }

            txtNombre.Text =
            dt.Rows[0]["Nombre"].ToString();

            txtApellido.Text =
            dt.Rows[0]["Apellido"].ToString();

            txtCelular.Text =
            dt.Rows[0]["Celular"].ToString();

            txtEmail.Text =
            dt.Rows[0]["Email"].ToString();
        }

        private void btnBuscarCliente_Click( object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void cboProducto_SelectedIndexChanged( object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex == -1)
                return;

            DataTable dt =
            producto.Buscar(
            cboProducto.Text);

            if (dt.Rows.Count == 0)
                return;

            txtPrecio.Text =
            Convert.ToDecimal(
            dt.Rows[0]["Precio"])
            .ToString("N2");

            txtStock.Text =
            dt.Rows[0]["Stock"]
            .ToString();
        }

        private void btnAgregar_Click( object sender, EventArgs e)
        {
            // Validar producto
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione un producto",
                "Venta Dulcería",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                cboProducto.Focus();

                return;
            }

            int cantidad =
            Convert.ToInt32(
            nudCantidad.Text);

            if (cantidad <= 0)
            {
                MessageBox.Show(
                "La cantidad debe ser mayor a cero");

                nudCantidad.Focus();

                return;
            }

            int stock =
            Convert.ToInt32(
            txtStock.Text);

            if (cantidad > stock)
            {
                MessageBox.Show(
                "Stock insuficiente");

                nudCantidad.Focus();

                return;
            }

            // Verificar si el producto ya fue agregado
            foreach (DataGridViewRow fila
                in dgvDetalle.Rows)
            {
                if (fila.Cells["IdProducto"].Value != null)
                {
                    if (fila.Cells["IdProducto"].Value.ToString()
                        ==
                        cboProducto.SelectedValue.ToString())
                    {
                        MessageBox.Show(
                        "El producto ya fue agregado.\n\nModifique la cantidad o elimine la fila actual.",
                        "Venta Dulcería",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        return;
                    }
                }
            }

            decimal precio =
            Convert.ToDecimal(
            txtPrecio.Text);

            decimal subtotal =
            precio * cantidad;

            dgvDetalle.Rows.Add(

                cboProducto.SelectedValue,

                cboProducto.Text,

                cantidad,

                precio.ToString("N2"),

                subtotal.ToString("N2"));

            CalcularTotales();

            // Preparar siguiente producto
            cboProducto.SelectedIndex = -1;

            txtPrecio.Clear();

            txtStock.Clear();

            nudCantidad.Text = "1";

            cboProducto.Focus();
        }

        private void btnQuitar_Click( object sender,  EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
                return;

            if (dgvDetalle.CurrentRow == null)
                return;

            dgvDetalle.Rows.Remove(
            dgvDetalle.CurrentRow);

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;

            int cantidad = 0;

            foreach (DataGridViewRow fila
                in dgvDetalle.Rows)
            {
                subtotal +=
                Convert.ToDecimal(
                fila.Cells["SubTotal"].Value);

                cantidad +=
                Convert.ToInt32(
                fila.Cells["Cantidad"].Value);
            }

            decimal igv =
            subtotal * 0.18m;

            decimal total =
            subtotal + igv;


            txtCantidad.Text =
            cantidad.ToString();

            txtSubTotal.Text =
            subtotal.ToString("N2");

            txtIGV.Text =
            igv.ToString("N2");

            txtTotal.Text =
            total.ToString("N2");
        }

        private void cboMetodoPago_SelectedIndexChanged(
object sender,
EventArgs e)
        {
            OcultarPanelesPago();

            if (cboMetodoPago.SelectedIndex == -1)
                return;

            switch (cboMetodoPago.Text)
            {
                case "YAPE":
                case "PLIN":

                    pnlYapePlin.Visible = true;

                    break;


                case "TARJETA":

                    pnlTarjeta.Visible = true;

                    break;
            }
        }

        private bool ValidarPago()
        {
            if (cboMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione forma de pago");

                return false;
            }

            // EFECTIVO
            if (cboMetodoPago.Text == "EFECTIVO")
                return true;


            // YAPE Y PLIN
            if (cboMetodoPago.Text == "YAPE"
                ||
                cboMetodoPago.Text == "PLIN")
            {
                if (txtCelularPago.Text.Length != 9)
                {
                    MessageBox.Show(
                    "Ingrese un celular válido");

                    return false;
                }

                if (!txtCelularPago.Text.StartsWith("9"))
                {
                    MessageBox.Show(
                    "El celular debe iniciar con 9");

                    return false;
                }

                return true;
            }


            // TARJETA

            if (txtTitular.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese titular");

                return false;
            }

            if (txtNumeroTarjeta.Text.Length < 16)
            {
                MessageBox.Show(
                "Número de tarjeta inválido");

                return false;
            }

            if (txtCVV.Text.Length != 3)
            {
                MessageBox.Show(
                "CVV inválido");

                return false;
            }

            if (cboMarca.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione marca");

                return false;
            }

            if (cboMes.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione mes");

                return false;
            }

            if (cboAnio.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione año");

                return false;
            }

            int mes =
            Convert.ToInt32(
            cboMes.Text);

            int anio =
            Convert.ToInt32(
            cboAnio.Text);

            DateTime fechaVencimiento =
            new DateTime(
                anio,
                mes,
                DateTime.DaysInMonth(
                anio,
                mes));

            if (fechaVencimiento <
                DateTime.Now.Date)
            {
                MessageBox.Show(
                "Tarjeta vencida");

                return false;
            }

            return true;
        }

        private string GenerarCodigoTicket()
        {
            return
            "VD-"
            +
            DateTime.Now.ToString(
            "yyyyMMddHHmmss");
        }

        private string GenerarTextoTicket()
        {
            string ticket = "";

            ticket +=
            "================================="
            + Environment.NewLine;

            ticket +=
            "            CINEPELIS"
            + Environment.NewLine;

            ticket +=
            "             DULCERIA"
            + Environment.NewLine;

            ticket +=
            "================================="
            + Environment.NewLine;

            ticket +=
            "Ticket : "
            + codigoTicketActual
            + Environment.NewLine;

            ticket +=
            "Fecha : "
            + DateTime.Now.ToString(
            "dd/MM/yyyy HH:mm")
            + Environment.NewLine
            + Environment.NewLine;

            ticket +=
            "Cliente:"
            + Environment.NewLine;

            ticket +=
            txtNombre.Text
            + " "
            + txtApellido.Text
            + Environment.NewLine;

            ticket +=
            "---------------------------------"
            + Environment.NewLine;

            ticket +=
            "PRODUCTOS"
            + Environment.NewLine;

            ticket +=
            "---------------------------------"
            + Environment.NewLine;

            foreach (DataGridViewRow fila
                in dgvDetalle.Rows)
            {
                ticket +=

                fila.Cells["Cantidad"].Value

                + " x "

                + fila.Cells["Producto"].Value

                + "    S/"

                + Convert.ToDecimal(
                fila.Cells["SubTotal"].Value)
                .ToString("N2")

                + Environment.NewLine;
            }

            ticket +=
            "---------------------------------"
            + Environment.NewLine;

            ticket +=
            "Cantidad : "
            + txtCantidad.Text
            + Environment.NewLine;

            ticket +=
            "SubTotal : S/"
            + txtSubTotal.Text
            + Environment.NewLine;

            ticket +=
            "IGV      : S/"
            + txtIGV.Text
            + Environment.NewLine;

            ticket +=
            "TOTAL    : S/"
            + txtTotal.Text
            + Environment.NewLine;

            ticket +=
            "Forma Pago : "
            + cboMetodoPago.Text
            + Environment.NewLine;

            ticket +=
            "================================="
            + Environment.NewLine;

            ticket +=
            "Gracias por su compra"
            + Environment.NewLine;

            ticket +=
            "www.CinePelis.com"
            + Environment.NewLine;

            ticket +=
            "=================================";

            return ticket;
        }

        private void GenerarQR(string textoQR)
        {
            QRCodeGenerator qrGenerator =
            new QRCodeGenerator();

            QRCodeData qrCodeData =
            qrGenerator.CreateQrCode(
                textoQR,
                QRCodeGenerator.ECCLevel.M);

            QRCode qrCode =
            new QRCode(qrCodeData);

            Bitmap qrImage =
            qrCode.GetGraphic(
                25,
                Color.Black,
                Color.White,
                true);

            picQR.Image = qrImage;

            picQR.SizeMode =
            PictureBoxSizeMode.Zoom;

            picQR.BackColor =
            Color.White;
        }

        private void MostrarTicket()
        {
            string productos = "";

            foreach (DataGridViewRow fila
                in dgvDetalle.Rows)
            {
                productos +=

                fila.Cells["Cantidad"].Value

                + " x "

                + fila.Cells["Producto"].Value

                + "    S/ "

                + Convert.ToDecimal(
                fila.Cells["SubTotal"].Value)
                .ToString("N2")

                + Environment.NewLine;
            }

            MessageBox.Show(

            "TICKET: "
            + codigoTicketActual

            +

            "\nFECHA: "
            + DateTime.Now.ToString(
            "dd/MM/yyyy HH:mm")

            +

            "\nCLIENTE DNI: "
            + txtDni.Text

            +

            "\nCLIENTE: "
            + txtNombre.Text
            + " "
            + txtApellido.Text

            +

            "\nPRODUCTOS:\n"
            + productos

            +

            "\nTOTAL: S/ "
            + txtTotal.Text

            +

            "\nFORMA DE PAGO: "
            + cboMetodoPago.Text

            +

            "\nCinePelis. Muchas gracias por su compra",

            "CINEPELIS",

            MessageBoxButtons.OK,

            MessageBoxIcon.Information);
        }

        private void btnProcesarVenta_Click(
  object sender,
  EventArgs e)
        {
            btnProcesarVenta.Enabled = false;

            try
            {
                //-----------------------------------
                // VALIDAR PRODUCTOS
                //-----------------------------------

                if (dgvDetalle.Rows.Count == 0)
                {
                    MessageBox.Show(
                    "Debe agregar al menos un producto.");

                    return;
                }

                //-----------------------------------
                // VALIDAR PAGO
                //-----------------------------------

                if (!ValidarPago())
                {
                    return;
                }

                //-----------------------------------
                // GENERAR TICKET
                //-----------------------------------

                codigoTicketActual =
                GenerarCodigoTicket();

                string textoQR =
                GenerarTextoQR();

                //-----------------------------------
                // CLIENTE
                //-----------------------------------

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
                    MessageBox.Show(
                    "Cliente no encontrado.");

                    return;
                }

                //-----------------------------------
                // CABECERA
                //-----------------------------------

                VentaDulceria venta =
                new VentaDulceria();

                venta.idCliente =
                idCliente;

                venta.subTotal =
                Convert.ToDecimal(
                txtSubTotal.Text);

                venta.igv =
                Convert.ToDecimal(
                txtIGV.Text);

                venta.total =
                Convert.ToDecimal(
                txtTotal.Text);

                venta.metodoPago =
                cboMetodoPago.Text;

                venta.estado =
                "PAGADO";

                venta.codigoTicket =
                codigoTicketActual;

                venta.qrTexto =
                textoQR;

                venta.usuarioRegistro =
                SesionActual.IdUsuario;

                if (cboMetodoPago.Text == "TARJETA")
                {
                    string tarjeta =
                    txtNumeroTarjeta.Text;

                    venta.ultimos4Tarjeta =
                    tarjeta.Substring(
                    tarjeta.Length - 4);
                }
                else
                {
                    venta.numeroAutorizacion =
                    txtNumeroAutorizacion.Text;
                }

                //-----------------------------------
                // GUARDAR CABECERA
                //-----------------------------------

                int idVenta =
                venta.Registrar();

                if (idVenta == 0)
                {
                    MessageBox.Show(
                    "No se pudo registrar la venta.");

                    return;
                }

                //-----------------------------------
                // GUARDAR DETALLE
                //-----------------------------------

                foreach (DataGridViewRow fila
                    in dgvDetalle.Rows)
                {
                    DetalleVentaDulceria detalle =
                    new DetalleVentaDulceria();

                    detalle.idVentaDulceria =
                    idVenta;

                    detalle.idProducto =
                    Convert.ToInt32(
                    fila.Cells["IdProducto"].Value);

                    detalle.cantidad =
                    Convert.ToInt32(
                    fila.Cells["Cantidad"].Value);

                    detalle.precio =
                    Convert.ToDecimal(
                    fila.Cells["Precio"].Value);

                    detalle.subTotal =
                    Convert.ToDecimal(
                    fila.Cells["SubTotal"].Value);

                    detalle.Registrar();

                    //-----------------------------------
                    // ACTUALIZAR STOCK
                    //-----------------------------------

                    productoRepositorio.ActualizarStock(

                    detalle.idProducto,

                    detalle.cantidad);
                }

                //-----------------------------------
                // GENERAR QR
                //-----------------------------------

                GenerarQR(
                textoQR);

                //-----------------------------------
                // MOSTRAR TICKET
                //-----------------------------------

                MostrarTicket();

                //-----------------------------------
                // MENSAJE FINAL
                //-----------------------------------

                DialogResult respuesta =
                MessageBox.Show(

                "🎬 Compra realizada exitosamente.\n\n" +

                "¿Desea realizar otra compra?",

                "CINEPELIS",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    btnNuevo.PerformClick();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(

                "Error al procesar la venta\n\n"

                + ex.Message,

                "CINEPELIS",

                MessageBoxButtons.OK,

                MessageBoxIcon.Error);
            }
            finally
            {
                btnProcesarVenta.Enabled = true;
            }
        }

        private void btnNuevo_Click( object sender,  EventArgs e)
        {
            //-----------------------------------
            // CLIENTE
            //-----------------------------------

            txtDni.Clear();

            txtNombre.Clear();

            txtApellido.Clear();

            txtCelular.Clear();

            txtEmail.Clear();

            //-----------------------------------
            // PRODUCTO
            //-----------------------------------

            cboProducto.SelectedIndex = -1;

            txtPrecio.Clear();

            txtStock.Clear();

            nudCantidad.Text = "1";

            //-----------------------------------
            // DETALLE
            //-----------------------------------

            dgvDetalle.Rows.Clear();

            //-----------------------------------
            // TOTALES
            //-----------------------------------

            txtCantidad.Text = "0";

            txtSubTotal.Text = "0.00";

            txtIGV.Text = "0.00";

            txtTotal.Text = "0.00";

            //-----------------------------------
            // FORMA DE PAGO
            //-----------------------------------

            cboMetodoPago.SelectedIndex = -1;

            txtCelularPago.Clear();

            txtNumeroAutorizacion.Clear();

            txtNumeroTarjeta.Clear();

            txtTitular.Clear();

            txtCVV.Clear();

            cboMarca.SelectedIndex = -1;

            cboMes.SelectedIndex = -1;

            cboAnio.SelectedIndex = -1;

            //-----------------------------------
            // OCULTAR PANELES
            //-----------------------------------

            pnlYapePlin.Visible = false;

            pnlTarjeta.Visible = false;

            //-----------------------------------
            // QR
            //-----------------------------------

            picQR.Image = null;

            //-----------------------------------
            // TICKET
            //-----------------------------------

            codigoTicketActual = "";

            txtDni.Focus();

            btnProcesarVenta.Enabled = true;
        }

        private void btnSalir_Click( object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCelularPago_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtCelularPago.Text.Length >= 9
                &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroTarjeta_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtNumeroTarjeta.Text.Length >= 16
                &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCVV_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtCVV.Text.Length >= 3
                &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtDni.Text.Length >= 8
                &&
                !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private string GenerarTextoQR()
        {
            string productos = "";

            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                productos +=

                fila.Cells["Cantidad"].Value

                + " x "

                + fila.Cells["Producto"].Value

                + " ";
            }

            return

            "TICKET: "
            + codigoTicketActual

            +

            "\nCLIENTE DNI: "
            + txtDni.Text

            +

            "\nCLIENTE: "
            + txtNombre.Text
            + " "
            + txtApellido.Text

            +

            "\nPRODUCTOS: "
            + productos

            +

            "\nTOTAL: S/ "
            + txtTotal.Text

            +

            "\nFORMA DE PAGO: "
            + cboMetodoPago.Text

            +

            "\nCinePelis. Muchas gracias por su compra";
        }

    }
}
