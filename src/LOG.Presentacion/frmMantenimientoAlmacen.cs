using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmMantenimientoAlmacen : frmBase
    {
        #region Variables

        string cTipOpera = string.Empty;
        clsCNAlmacen objAlmacen = new clsCNAlmacen();

        #endregion

        #region Eventos

        private void frmMantenimientoAlmacen_Load(object sender, EventArgs e)
        {
            cboEstablecimiento.CargarEstablecimiento(Convert.ToInt32(cboAgencia.SelectedValue));
            ListarAlmacenAgencia(Convert.ToInt32(cboAgencia.SelectedValue));
            HabilitarControles(false);
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);

            ListarAlmacenAgencia(idAgencia);
            cboEstablecimiento.CargarEstablecimiento(idAgencia);
            HabilitarControles(false);
        }

        private void dtgAlmacenAgencia_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosAlmacen();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            LimpiarControles();
            cTipOpera = "N";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles(true);
            cTipOpera = "A";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatosAlmacen();
            cTipOpera = "";
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            HabilitarControles(false);

            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idEstablecimiento = Convert.ToInt32(cboEstablecimiento.SelectedValue);

            if (cTipOpera == "N")
            {
                InsertarAlmacen(txtNombreAlmacen.Text, idAgencia,idEstablecimiento);
            }
            if (cTipOpera == "A")
            {
                int idAlmacen = (int)dtgAlmacenAgencia.CurrentRow.Cells["dtgtxtIdAlmacen"].Value;
                ActualizarAlmacen(idAlmacen, txtNombreAlmacen.Text, idAgencia, idEstablecimiento);
            }
            ListarAlmacenAgencia((int)cboAgencia.SelectedValue);
            cTipOpera = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAlmacen = (int)dtgAlmacenAgencia.CurrentRow.Cells["dtgtxtIdAlmacen"].Value;
            EliminarAlmacen(idAlmacen);
            ListarAlmacenAgencia((int)cboAgencia.SelectedValue);
            cTipOpera = "";
        }

        #endregion

        #region Metodos

        public frmMantenimientoAlmacen()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtNombreAlmacen.Clear();
            cboEstablecimiento.SelectedIndex = -1;
        }

        private void HabilitarControles(bool lHabilitar)
        {
            cboAgencia.Enabled = !lHabilitar;
            dtgAlmacenAgencia.Enabled = !lHabilitar;
            txtNombreAlmacen.Enabled = lHabilitar;
            cboEstablecimiento.Enabled = lHabilitar;

            btnNuevo.Enabled = !lHabilitar;
            btnEditar.Enabled = !lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;

            if (dtgAlmacenAgencia.RowCount > 0)
            {
                btnEliminar.Enabled = !lHabilitar;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void ListarAlmacenAgencia(int idAgencia)
        {
            DataTable dtAlmacenAgencia = objAlmacen.CNListarAlmacenAgencia(idAgencia);
            dtgAlmacenAgencia.DataSource = dtAlmacenAgencia;
        }

        private void InsertarAlmacen(string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            DataTable dtResultado = objAlmacen.CNInsertarAlmacen(cNombreAlmacen, idAgencia,IdEstablecimiento);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Almacén", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void ActualizarAlmacen(int idAlmacen, string cNombreAlmacen, int idAgencia, int IdEstablecimiento)
        {
            DataTable dtResultado = objAlmacen.CNActualizarAlmacen(idAlmacen, cNombreAlmacen, idAgencia,IdEstablecimiento);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Almacén", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void EliminarAlmacen(int idAlmacen)
        {
            DataTable dtResultado = objAlmacen.CNEliminarAlmacen(idAlmacen);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Almacén", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
        }

        private void MostrarDatosAlmacen()
        {
            if (dtgAlmacenAgencia.SelectedRows.Count > 0)
            {
                txtNombreAlmacen.Text = Convert.ToString(dtgAlmacenAgencia.CurrentRow.Cells["dtgtxtNombreAlmacen"].Value);
                cboEstablecimiento.SelectedValue = Convert.ToInt32(dtgAlmacenAgencia.CurrentRow.Cells["dtgtxtIdEstablecimiento"].Value);

                HabilitarControles(false);
                cTipOpera = "";
            }
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(txtNombreAlmacen.Text))
            {
                MessageBox.Show("Ingresar Nombre de Almacén", "Mantenimiento de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreAlmacen.Focus();
                return false;
            }

            if (cboEstablecimiento.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccionar Establecimiento", "Mantenimiento de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstablecimiento.Focus();
                return false;
            }

            return true;
        }

        #endregion
 
    }
}
