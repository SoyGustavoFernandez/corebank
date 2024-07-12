using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmMantenimientoVacaciones : frmBase
    {
        clsCNVacaciones objVacaciones = new clsCNVacaciones();

        DataTable dtVacacionesUsuario;

        public frmMantenimientoVacaciones()
        {
            InitializeComponent();
        }

        private void CargarDetallePago(int idVacaciones)
        {
            DataTable dtDetallePago = objVacaciones.CNDetallePagosVacaciones(idVacaciones);

            dtgDetallePago.DataSource = dtDetallePago;
        }

        private void CargarDetalleUso(int idVacaciones)
        {
            DataTable dtDetalleUso = objVacaciones.CNDetalleUsoVacaciones(idVacaciones);

            dtgDetalleUso.DataSource = dtDetalleUso;

            if (dtDetalleUso.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
            }
            else
            { 
                btnEliminar.Enabled = true;
            }
        }

        private void EliminarVacaciones(int idVacaciones, int idPagVacaciones)
        {
            DataTable dtEliVacac = objVacaciones.CNEliminaVacaciones(idVacaciones, idPagVacaciones);
            MessageBox.Show(dtEliVacac.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Vacaciones", MessageBoxButtons.OK, ((int)dtEliVacac.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtEliVacac.Rows[0]["idError"] != 0)
            {
                return;
            }
        }

        private void frmMantenimientoVacaciones_Load(object sender, EventArgs e)
        {
            conBusPersonal.HabilitarControles(true);
            cboVacacionesUsuario.Enabled = true;
            cboTipoUsoVacaciones.Enabled = false;
            nudNroDias.Enabled = false;
            dtpFechaInicioUso.Enabled = false;

            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            dtpFechaFinUso.Value = dtpFechaInicioUso.Value.AddDays(Convert.ToInt32(nudNroDias.Value));
        }

        private void conBusPersonal_BuscarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusPersonal.txtCod.Text))
            {
                return;
            }
            dtVacacionesUsuario = objVacaciones.CNListarVacacionesUsuario(Convert.ToInt32(conBusPersonal.txtCod.Text));

            cboVacacionesUsuario.DataSource = dtVacacionesUsuario;
            cboVacacionesUsuario.ValueMember = dtVacacionesUsuario.Columns["idVacaciones"].ToString();
            cboVacacionesUsuario.DisplayMember = dtVacacionesUsuario.Columns["cPeriodo"].ToString();

            if (dtVacacionesUsuario.Rows.Count > 0)
            {
                btnNuevo.Enabled = true;
            }
            else
            {
                btnNuevo.Enabled = false;
            }
            conBusPersonal.txtCod.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void cboVacacionesUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idVacaciones = Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["idVacaciones"]);

            dtpFechaInicioVac.Value = Convert.ToDateTime(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["dFechaInicio"]);
            dtpFechaFinVac.Value = Convert.ToDateTime(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["dFechaFin"]);
            nudDiasPagados.Value = Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasPagados"]);
            nudDiasPendientePago.Value = Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasVacacion"]) -
                                         Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasPagados"]);
            nudDiasUsados.Value = Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasUsados"]);
            nudDiasPendienteUso.Value = Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasVacacion"]) -
                                        Convert.ToInt32(dtVacacionesUsuario.Rows[cboVacacionesUsuario.SelectedIndex]["nDiasUsados"]);  //nDiasPagados

            CargarDetallePago(idVacaciones);
            CargarDetalleUso(idVacaciones);
        }

        private void cboTipoUsoVacaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnGrabar.Enabled == true)
            {
                if ((int)cboTipoUsoVacaciones.SelectedValue == 1)
                {
                    lblFechaInicioUso.Visible = true;
                    dtpFechaInicioUso.Visible = true;
                    lblFechaFinUso.Visible = true;
                    dtpFechaFinUso.Visible = true;
                }
                else
                {
                    dtpFechaInicioUso.Value = clsVarGlobal.dFecSystem;
                    lblFechaInicioUso.Visible = false;
                    dtpFechaInicioUso.Visible = false;
                    lblFechaFinUso.Visible = false;
                    dtpFechaFinUso.Visible = false;
                }
            }
        }

        private void nudNroDias_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinUso.Value = dtpFechaInicioUso.Value.AddDays(Convert.ToInt32(nudNroDias.Value));
        }

        private void dtpFechaInicioUso_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFinUso.Value = dtpFechaInicioUso.Value.AddDays(Convert.ToInt32(nudNroDias.Value));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusPersonal.txtCod.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador...Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.txtCod.Focus();
                return;
            }
            if (string.IsNullOrEmpty(conBusPersonal.txtNom.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador...Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.txtCod.Focus();
                return;
            }

            conBusPersonal.HabilitarControles(false);
            cboVacacionesUsuario.Enabled = false;
            cboTipoUsoVacaciones.Enabled = true;
            nudNroDias.Enabled = true;
            dtpFechaInicioUso.Enabled = true;

            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            int idVacaciones = Convert.ToInt32(cboVacacionesUsuario.SelectedValue);
            int idPagVacaciones = Convert.ToInt32(dtgDetallePago.Rows[dtgDetallePago.SelectedCells[0].RowIndex].Cells["dtgtxtIdPagoVacaciones"].Value.ToString());

            EliminarVacaciones(idVacaciones, idPagVacaciones);
            CargarDetallePago(idVacaciones);
            CargarDetalleUso(idVacaciones);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusPersonal.HabilitarControles(true);
            cboVacacionesUsuario.Enabled = true;
            cboTipoUsoVacaciones.Enabled = false;
            nudNroDias.Enabled = false;
            dtpFechaInicioUso.Enabled = false;

            btnNuevo.Enabled = true;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            conBusPersonal.HabilitarControles(true);
            cboVacacionesUsuario.Enabled = true;
            cboTipoUsoVacaciones.Enabled = false;
            nudNroDias.Enabled = false;
            dtpFechaInicioUso.Enabled = false;

            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;

            int idUsuario = Convert.ToInt32(conBusPersonal.txtCod.Text);
            int idVacaciones = Convert.ToInt32(cboVacacionesUsuario.SelectedValue);
            int idTipoUso = Convert.ToInt32(cboTipoUsoVacaciones.SelectedValue);
            int nDiasUso = Convert.ToInt32(nudNroDias.Value);
            DateTime dFechaInicio = dtpFechaInicioUso.Value;
            DateTime dFechaFin = dtpFechaFinUso.Value;

            DataTable dtRegistrarUsoVacaciones = objVacaciones.CNRegistrarUsoVacaciones(idUsuario, idVacaciones, idTipoUso, nDiasUso, dFechaInicio, dFechaFin, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
            MessageBox.Show(dtRegistrarUsoVacaciones.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Vacaciones", MessageBoxButtons.OK, ((int)dtRegistrarUsoVacaciones.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            if ((int)dtRegistrarUsoVacaciones.Rows[0]["idError"] != 0) return;

            CargarDetallePago(idVacaciones);
            CargarDetalleUso(idVacaciones);
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(conBusPersonal.txtCod.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador...Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.txtCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusPersonal.txtNom.Text))
            {
                MessageBox.Show("Primero debe buscar al colaborador...Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonal.txtCod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboVacacionesUsuario.Text))
            {
                MessageBox.Show("Debe Seleccionar por lo menos un periodo...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboVacacionesUsuario.Focus();
                return false;
            }
            if (cboVacacionesUsuario.SelectedIndex<0)
            {
                MessageBox.Show("Debe Seleccionar por lo menos un periodo...Verificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboVacacionesUsuario.Focus();
                return false;
            }
            return true;
        }


    }
}