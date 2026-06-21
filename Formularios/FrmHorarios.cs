using System;
using System.Data;
using System.Windows.Forms;
using DSEProyectoFinal.Clases;
using DSEProyectoFinal.Repositorio;

namespace DSEProyectoFinal.Formularios
{
    public partial class FrmHorarios : Form
    {
        private Horario horarioActual = new Horario();
        private HorarioRepositorio repoAux = new HorarioRepositorio();

        public FrmHorarios()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmHorarios_Load(object sender, EventArgs e)
        {

            cboCine.DropDownStyle = ComboBoxStyle.DropDownList;

            cboCartelera.DropDownStyle = ComboBoxStyle.DropDownList;

            cboTipoSala.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarCines();

            CargarCartelera();

            CargarDatos();

            Limpiar();


        }

        private void CargarDatos()
        {
            Horario horario =
            new Horario();

            dgvHorarios.DataSource =
            horario.Listar();

            if (dgvHorarios.Columns.Contains("IdHorario"))
                dgvHorarios.Columns["IdHorario"].Visible = false;

            if (dgvHorarios.Columns.Contains("IdCine"))
                dgvHorarios.Columns["IdCine"].Visible = false;

            if (dgvHorarios.Columns.Contains("IdCartelera"))
                dgvHorarios.Columns["IdCartelera"].Visible = false;

            dgvHorarios.ClearSelection();

            lblTotalHorarios.Text = "Total Horarios: " + dgvHorarios.Rows.Count;

        }
        private void CargarCines()
        {
            Cine cine = new Cine();

            cboCine.DataSource =
            cine.Listar();

            cboCine.DisplayMember =
            "Nombre";

            cboCine.ValueMember =
            "IdCine";

        }

        private void CargarCartelera()
        {
            Cartelera cartelera =
            new Cartelera();

            cboCartelera.DataSource =
            cartelera.Listar();

            cboCartelera.DisplayMember =
            "Titulo";

            cboCartelera.ValueMember =
            "IdCartelera";

            cboCartelera.SelectedIndex = -1;
        }
        private void Limpiar()
        {
            txtId.Clear();

            cboCartelera.SelectedIndex = -1;

            cboCine.SelectedIndex = -1;

            cboTipoSala.SelectedIndex = -1;

            txtNumSala.Clear();

            txtPrecioVentaPublico.Clear();

            txtTotalAsientos.Clear();

            txtVentaPublico.Text = "0";

            txtCorporativo.Text = "0";

            txtMarketing.Text = "0";

            dtpFechaInicio.Value =
            DateTime.Today;

            dtpFechaFinalizacion.Value =
            DateTime.Today;

            chkActivo.Checked = true;

            txtBuscar.Clear();

            ModoNuevo();
        }

        private bool ValidarAsientos()
        {
            int total =
            Convert.ToInt32(
            txtTotalAsientos.Text);

            int publico =
            Convert.ToInt32(
            txtVentaPublico.Text);

            int corporativo =
            Convert.ToInt32(
            txtCorporativo.Text);

            int marketing =
            Convert.ToInt32(
            txtMarketing.Text);

            if ((publico + corporativo + marketing)
                > total)
            {
                MessageBox.Show(
                "La suma de Público, Corporativo y Marketing no puede superar el total de asientos");

                return false;
            }

            return true;
        }

        private void btnGuardar_Click( object sender, EventArgs e)
        {
            if (cboCartelera.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione una cartelera");
                return;
            }

            if (cboCine.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione un cine");
                return;
            }

            if (cboTipoSala.SelectedIndex == -1)
            {
                MessageBox.Show(
                "Seleccione un tipo de sala");
                return;
            }

            if (txtNumSala.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese número de sala");
                return;
            }

            if (txtPrecioVentaPublico.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese precio de venta");
                return;
            }

            if (txtTotalAsientos.Text.Trim() == "")
            {
                MessageBox.Show(
                "Ingrese total de asientos");
                return;
            }

            if (!ValidarAsientos())
            {
                return;
            }

            if (dtpFechaFinalizacion.Value.Date <  dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha inicial");

                return;
            }

            if (repoAux.ExisteSalaOcupada(
                Convert.ToInt32(cboCine.SelectedValue), 
                Convert.ToInt32(txtNumSala.Text), 
                cboTipoSala.Text))
            {
                MessageBox.Show(
                "La sala ya existe para este cine");

                return;
            }

            Horario horario =
            new Horario();

            horario.idCartelera =
            Convert.ToInt32(
            cboCartelera.SelectedValue);

            horario.idCine =
            Convert.ToInt32(
            cboCine.SelectedValue);

            horario.tipoSala =
            cboTipoSala.Text;

            horario.numSala =
            Convert.ToInt32(
            txtNumSala.Text);

            horario.fechaInicio =
            dtpFechaInicio.Value.Date;

            horario.fechaFinalizacion =
            dtpFechaFinalizacion.Value.Date;

            horario.precioVentaPublico =
            Convert.ToDecimal(
            txtPrecioVentaPublico.Text);

            horario.totalAsientos =
            Convert.ToInt32(
            txtTotalAsientos.Text);

            horario.cantidadventaPublico =
            Convert.ToInt32(
            txtVentaPublico.Text);

            horario.cantidadcorporativo =
            Convert.ToInt32(
            txtCorporativo.Text);

            horario.cantidadmarketing =
            Convert.ToInt32(
            txtMarketing.Text);

            horario.entradasVendidas = 0;

            horario.activo =
            chkActivo.Checked ? 1 : 0;

            if (horario.Registrar())
            {
                MessageBox.Show(
                "Horario registrado correctamente");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al registrar");
            }
        }

        private void btnEditar_Click( object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            if (!ValidarAsientos())
            {
                return;
            }

            if (dtpFechaFinalizacion.Value.Date <  dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha inicial");

                return;
            }

            if (repoAux.ExisteSalaOcupada(
                Convert.ToInt32(cboCine.SelectedValue),
                Convert.ToInt32(txtNumSala.Text),
                cboTipoSala.Text))
            {
                MessageBox.Show("Ya existe una sala con esos datos");

                return;
            }

            Horario horario =
            new Horario();

            horario.idHorario =
            Convert.ToInt32(
            txtId.Text);

            horario.idCartelera =
            Convert.ToInt32(
            cboCartelera.SelectedValue);

            horario.idCine =
            Convert.ToInt32(
            cboCine.SelectedValue);

            horario.tipoSala =
            cboTipoSala.Text;

            horario.numSala =
            Convert.ToInt32(
            txtNumSala.Text);

            horario.fechaInicio =
            dtpFechaInicio.Value.Date;

            horario.fechaFinalizacion =
            dtpFechaFinalizacion.Value.Date;

            horario.precioVentaPublico =
            Convert.ToDecimal(
            txtPrecioVentaPublico.Text);

            horario.totalAsientos =
            Convert.ToInt32(
            txtTotalAsientos.Text);

            horario.cantidadventaPublico =
            Convert.ToInt32(
            txtVentaPublico.Text);

            horario.cantidadcorporativo =
            Convert.ToInt32(
            txtCorporativo.Text);

            horario.cantidadmarketing =
            Convert.ToInt32(
            txtMarketing.Text);

            horario.activo =
            chkActivo.Checked ? 1 : 0;

            if (horario.Actualizar())
            {
                MessageBox.Show(
                "Horario actualizado");

                CargarDatos();

                btnNuevo.PerformClick();
            }
            else
            {
                MessageBox.Show(
                "Error al actualizar");
            }
        }

        private void btnEliminar_Click( object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "")
            {
                MessageBox.Show(
                "Seleccione un registro");

                return;
            }

            DialogResult respuesta =
            MessageBox.Show(
            "¿Desea desactivar este horario?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                return;
            }

            Horario horario =
            new Horario();

            horario.idHorario =
            Convert.ToInt32(
            txtId.Text);

            if (horario.Eliminar())
            {
                MessageBox.Show(
                "Horario desactivado");

                CargarDatos();

                btnNuevo.PerformClick();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Horario horario = new Horario();

            dgvHorarios.DataSource =
            horario.Buscar(
            txtBuscar.Text);

        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvHorarios.CurrentRow != null)
            {
                CargarRegistro();
            }
        }

        private void btnNuevo_Click( object sender, EventArgs e)
        {
            Limpiar();

            dgvHorarios.ClearSelection();

            ModoNuevo();

            cboCartelera.Focus();

        }

        private void btnSalir_Click( object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged( object sender, EventArgs e)
        {
            Horario horario =
            new Horario();

            dgvHorarios.DataSource =
            horario.Buscar(
            txtBuscar.Text.Trim());

            if (dgvHorarios.Rows.Count > 0)
            {
                dgvHorarios.Rows[0].Selected = true;

                CargarRegistro();
            }
        }

        private void CargarRegistro()
        {
            if (dgvHorarios.CurrentRow == null)
                return;

            txtId.Text =
            dgvHorarios.CurrentRow
            .Cells["IdHorario"]
            .Value.ToString();

            if (dgvHorarios.CurrentRow.Cells["IdCartelera"].Value != DBNull.Value)
            {
                cboCartelera.SelectedValue =
                Convert.ToInt32(
                dgvHorarios.CurrentRow.Cells["IdCartelera"].Value);
            }
            else
            {
                cboCartelera.SelectedIndex = -1;
            }

            cboCine.SelectedValue =
            Convert.ToInt32(
            dgvHorarios.CurrentRow
            .Cells["IdCine"].Value);

            cboTipoSala.Text =
            dgvHorarios.CurrentRow
            .Cells["TipoSala"]
            .Value.ToString();

            txtNumSala.Text =
            dgvHorarios.CurrentRow
            .Cells["NumSala"]
            .Value.ToString();

            txtPrecioVentaPublico.Text =
            dgvHorarios.CurrentRow
            .Cells["PrecioVentaPublico"]
            .Value.ToString();

            txtTotalAsientos.Text =
            dgvHorarios.CurrentRow
            .Cells["TotalAsientos"]
            .Value.ToString();

            txtVentaPublico.Text =
            dgvHorarios.CurrentRow
            .Cells["CantidadVentaPublico"]
            .Value.ToString();

            txtCorporativo.Text =
            dgvHorarios.CurrentRow
            .Cells["CantidadCorporativo"]
            .Value.ToString();

            txtMarketing.Text =
            dgvHorarios.CurrentRow
            .Cells["CantidadMarketing"]
            .Value.ToString();

            dtpFechaInicio.Value =
            Convert.ToDateTime(
            dgvHorarios.CurrentRow
            .Cells["FechaInicio"]
            .Value);

            dtpFechaFinalizacion.Value =
            Convert.ToDateTime(
            dgvHorarios.CurrentRow
            .Cells["FechaFinalizacion"]
            .Value);

            chkActivo.Checked =
            Convert.ToBoolean(
            dgvHorarios.CurrentRow
            .Cells["Activo"]
            .Value);

            ModoEdicion();
        }
             

        private void ModoNuevo()
        {
            btnGuardar.Enabled = true;

            btnEditar.Enabled = false;

            btnEliminar.Enabled = false;
        }

        private void ModoEdicion()
        {
            btnGuardar.Enabled = false;

            btnEditar.Enabled = true;

            btnEliminar.Enabled = true;
        }


    }
}