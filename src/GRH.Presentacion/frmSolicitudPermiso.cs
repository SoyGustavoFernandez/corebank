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
using Microsoft.Reporting.WinForms;

namespace GRH.Presentacion
{
    public partial class frmSolicitudPermiso : frmBase
    {
        private string cTipTrxPermiso = "";

        clsCNPermisoJustificacion objPermiso = new clsCNPermisoJustificacion();
                
        DataTable dtPermisosUsuario;

        public frmSolicitudPermiso()
        {
            InitializeComponent();
        }

        private void HabilitarControles(bool lHabilitar)
        {
            dtgPermisosUsuario.Enabled = !lHabilitar;
            cboTipoPermiso.Enabled = lHabilitar;

            if (lHabilitar)
            {
                HabilitarControlesTipoPermiso(Convert.ToInt32(cboTipoPermiso.SelectedValue));
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFinal.Enabled = false;
                cboTurnoUsuario.Enabled = false;
                dtpHoraInicio.Enabled = false;
                dtpHoraFinal.Enabled = false;
            }

            cboMotivoInasistencia.Enabled = lHabilitar;

            btnImprimir.Enabled = !lHabilitar;
            btnNuevo.Enabled = !lHabilitar;
            btnEliminar.Enabled = !lHabilitar;
            btnGrabar.Enabled = lHabilitar;
            btnCancelar.Enabled = lHabilitar;
        }

        private void HabilitarControlesTipoPermiso(int nTipoPermiso)
        {
            if (nTipoPermiso == 1)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFinal.Enabled = true;
                cboTurnoUsuario.Enabled = false;
                dtpHoraInicio.Enabled = false;
                dtpHoraFinal.Enabled = false;
            }

            if (nTipoPermiso == 2)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFinal.Enabled = false;
                cboTurnoUsuario.Enabled = true;
                dtpHoraInicio.Enabled = false;
                dtpHoraFinal.Enabled = false;
            }

            if (nTipoPermiso == 3)
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFinal.Enabled = false;
                cboTurnoUsuario.Enabled = true;
                dtpHoraInicio.Enabled = true;
                dtpHoraFinal.Enabled = true;
            }
        }

        private void CargarListaPermisos(int idUsuario)
        {
            dtPermisosUsuario = objPermiso.CNListarPermisosUsuario(idUsuario);


            if (dtPermisosUsuario.Rows.Count > 0)
            {
                this.dtgPermisosUsuario.SelectionChanged -= new System.EventHandler(this.dtgPermisosUsuario_SelectionChanged);
                dtgPermisosUsuario.DataSource = dtPermisosUsuario;
                dtgPermisosUsuario.ClearSelection();
                this.dtgPermisosUsuario.SelectionChanged += new System.EventHandler(this.dtgPermisosUsuario_SelectionChanged);
                dtgPermisosUsuario.Rows[0].Selected = true;
            }

            if (dtPermisosUsuario.Rows.Count == 0)
            {
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;

                this.dtgPermisosUsuario.SelectionChanged -= new System.EventHandler(this.dtgPermisosUsuario_SelectionChanged);
                dtgPermisosUsuario.DataSource = dtPermisosUsuario;
                ////dtgPermisosUsuario.DataSource = null;
                this.dtgPermisosUsuario.SelectionChanged += new System.EventHandler(this.dtgPermisosUsuario_SelectionChanged);
            }
        }

        private void frmSolicitudPermiso_Load(object sender, EventArgs e)
        {
            int idUsuario = clsVarGlobal.PerfilUsu.idUsuario;

            cboMotivoInasistencia.ListarMotivosPermisoRRHH();
            
            conBusPersonal.txtCod.Text = idUsuario.ToString();
            conBusPersonal.BusPerByCod();
            conBusPersonal.HabilitarControles(false);

            HabilitarControles(false);
            CargarListaPermisos(idUsuario);
        }

        private void dtgPermisosUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dtPermisosUsuario.Rows.Count<=0)
            {
                return;
            }
            if (dtgPermisosUsuario.RowCount > 0)
            {
                int iFilaTipOpe = Convert.ToInt32(dtgPermisosUsuario.CurrentRow.Index);

                cboTipoPermiso.SelectedValue = dtPermisosUsuario.Rows[iFilaTipOpe]["idTipoPermiso"];
                cboMotivoInasistencia.SelectedValue = dtPermisosUsuario.Rows[iFilaTipOpe]["idMotivo"];
                dtpFechaInicio.Value = Convert.ToDateTime(dtPermisosUsuario.Rows[iFilaTipOpe]["dFechaInicio"]);
                dtpFechaFinal.Value = Convert.ToDateTime(dtPermisosUsuario.Rows[iFilaTipOpe]["dFechaFin"]);
                cboTurnoUsuario.SelectedValue = dtPermisosUsuario.Rows[iFilaTipOpe]["idDetalleHorario"];
                dtpHoraInicio.Value = Convert.ToDateTime(dtPermisosUsuario.Rows[iFilaTipOpe]["cHoraInicio"]);
                dtpHoraFinal.Value = Convert.ToDateTime(dtPermisosUsuario.Rows[iFilaTipOpe]["cHoraFin"]);

                int idEstado = Convert.ToInt32(dtPermisosUsuario.Rows[iFilaTipOpe]["idEstado"]);

                if (idEstado == 2 || idEstado == 3)
                {
                    btnEliminar.Enabled = false;
                    btnImprimir.Enabled = true;
                }
                else
                {
                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = false;
                }
            }
        }

        private void cboTipoPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTipoPermiso = Convert.ToInt32(cboTipoPermiso.SelectedValue);

            if (idTipoPermiso == 1)
            {
                cboTurnoUsuario.ListarTurnosFechaUsuarioTodos(Convert.ToInt32(conBusPersonal.txtCod.Text), dtpFechaInicio.Value);
                cboTurnoUsuario.SelectedValue = (cTipTrxPermiso == "" ? cboTurnoUsuario.SelectedValue : 0);
            }
            else
            {
                cboTurnoUsuario.ListarTurnosFechaUsuario(Convert.ToInt32(conBusPersonal.txtCod.Text), dtpFechaInicio.Value);
            }

            if (cTipTrxPermiso != "")
            {
                HabilitarControlesTipoPermiso(Convert.ToInt32(cboTipoPermiso.SelectedValue));
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            int idTipoPermiso = Convert.ToInt32(cboTipoPermiso.SelectedValue);

            if (idTipoPermiso == 1)
            {
                cboTurnoUsuario.ListarTurnosFechaUsuarioTodos(Convert.ToInt32(conBusPersonal.txtCod.Text), dtpFechaInicio.Value);
                cboTurnoUsuario.SelectedValue = (cTipTrxPermiso == "" ? cboTurnoUsuario.SelectedValue : 0);
            }
            else
            {
                cboTurnoUsuario.ListarTurnosFechaUsuario(Convert.ToInt32(conBusPersonal.txtCod.Text), dtpFechaInicio.Value);
            }

            if (cTipTrxPermiso != "" && (dtpFechaInicio.Value > dtpFechaFinal.Value || Convert.ToString(Convert.ToInt32(cboTipoPermiso.SelectedValue)) != "1"))
            {
                dtpFechaFinal.Value = dtpFechaInicio.Value;
            }
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (cTipTrxPermiso != "" && dtpFechaFinal.Value < dtpFechaInicio.Value)
            {
                dtpFechaInicio.Value = dtpFechaFinal.Value;
            }
        }

        private void cboTurnoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cTipTrxPermiso != "")
            {
                int idTipoPermiso = Convert.ToInt32(cboTipoPermiso.SelectedValue);
                dtpHoraInicio.Value = Convert.ToDateTime(cboTurnoUsuario.dtTurno.Rows[cboTurnoUsuario.SelectedIndex]["cHoraIngreso"]).AddMinutes(idTipoPermiso == 3 ? 1 : 0);
                dtpHoraFinal.Value = Convert.ToDateTime(cboTurnoUsuario.dtTurno.Rows[cboTurnoUsuario.SelectedIndex]["cHoraSalida"]);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgPermisosUsuario.Rows.Count <= 0)
            {
                MessageBox.Show("No existen registros a imprimir...Verificar", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cTipTrxPermiso = "";

            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            int iFilaPermiso = dtgPermisosUsuario.SelectedCells[0].RowIndex;
            int idPermiso = (int)dtPermisosUsuario.Rows[iFilaPermiso]["idPermiso"];

            DataTable dtPapeletaPermiso = objPermiso.CNPapeletaPermiso(idPermiso);

            if (dtPapeletaPermiso.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Clear();
                dtsList.Add(new ReportDataSource("dsPapeletaPermiso", dtPapeletaPermiso));

                string reportPath = "rptPapeletaPermiso.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Clear();
                paramList.Add(new ReportParameter("cNomEmpresa", cNomEmpresa, false));
                paramList.Add(new ReportParameter("cNomAgencia", cNomAgencia, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen datos para la Papeleta de Permiso", "Papeleta de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            cTipTrxPermiso = "N";
            cboTipoPermiso.SelectedValue = 0;
            int idTipoPermiso = Convert.ToInt32(cboTipoPermiso.SelectedValue);
            dtpFechaInicio.Value = clsVarApl.dicVarGen["dFechaGRH"].AddDays(idTipoPermiso == 1 ? 1 : 0);
            dtpFechaFinal.Value = dtpFechaInicio.Value;
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgPermisosUsuario.Rows.Count<=0)
            {
                MessageBox.Show("No existen registros a eliminar...Verificar", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //int iFilaPermiso = dtgPermisosUsuario.SelectedCells[0].RowIndex;
            int iFilaPermiso = Convert.ToInt32(dtgPermisosUsuario.CurrentRow.Index);

            int idPermiso = (int)dtPermisosUsuario.Rows[iFilaPermiso]["idPermiso"];
            DataTable dtEliminarPermiso = objPermiso.CNEliminarSolicitudPermiso(idPermiso, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
            MessageBox.Show(dtEliminarPermiso.Rows[0]["cMensaje"].ToString(), "Solicitud de Permiso", MessageBoxButtons.OK, ((int)dtEliminarPermiso.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            CargarListaPermisos(Convert.ToInt32(conBusPersonal.txtCod.Text));
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(conBusPersonal.txtCod.Text);
            int idTipoPermiso = Convert.ToInt32(cboTipoPermiso.SelectedValue);
            int idMotivo = Convert.ToInt32(cboMotivoInasistencia.SelectedValue);
            DateTime dFechaInicio = dtpFechaInicio.Value;
            DateTime dFechaFin = (idTipoPermiso == 1 ? dtpFechaFinal.Value : dtpFechaInicio.Value);
            int idDetalleHorario = Convert.ToInt32(cboTurnoUsuario.SelectedValue);
            DateTime dHoraInicio = dtpHoraInicio.Value;
            DateTime dHoraFin = dtpHoraFinal.Value;

            // Validaciones

            if (!Validar())
            {
                return;
            }

            if (string.IsNullOrEmpty(cboTipoPermiso.Text))
            {
                MessageBox.Show("Debe Seleccionar el tipo de permiso", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPermiso.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cboMotivoInasistencia.Text))
            {
                MessageBox.Show("Debe Seleccionar el motivo de insistencia", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoInasistencia.Focus();
                return;
            }

            if (dFechaInicio <= clsVarApl.dicVarGen["dFechaGRH"] && idTipoPermiso == 1) // Permiso por Dia
            {
                MessageBox.Show("Fecha Inicial debe ser mayor a Fecha de Sistema", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Value = clsVarApl.dicVarGen["dFechaGRH"].AddDays(1);
                dtpFechaInicio.Focus();
                return;
            }
            if (dFechaInicio < clsVarApl.dicVarGen["dFechaGRH"] && idTipoPermiso != 1) // Permiso por Turno y Hora
            {
                MessageBox.Show("Fecha Inicial debe ser mayor o igual a Fecha de Sistema", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicio.Value = clsVarApl.dicVarGen["dFechaGRH"];
                dtpFechaInicio.Focus();
                return;
            }
            if (dFechaFin < dFechaInicio)
            {
                MessageBox.Show("Fecha Final debe ser mayor o igual a Fecha Inicial", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaFinal.Focus();
                return;
            }
            if (cboTurnoUsuario.Items.Count <= 1 && idTipoPermiso == 1) // Permiso por Dia
            {
                MessageBox.Show("No tiene turnos para la fecha indicada", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboTurnoUsuario.Items.Count == 0 && idTipoPermiso != 1) // Permiso por Turno y Hora
            {
                MessageBox.Show("No tiene turnos para la fecha indicada", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dHoraFin < dHoraInicio)
            {
                MessageBox.Show("Hora Final debe ser mayor o igual a Hora Inicial", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpHoraFinal.Focus();
                return;
            }
            DateTime dHoraMinimo = Convert.ToDateTime(cboTurnoUsuario.dtTurno.Rows[cboTurnoUsuario.SelectedIndex]["cHoraIngreso"]);
            DateTime dHoraMaximo = Convert.ToDateTime(cboTurnoUsuario.dtTurno.Rows[cboTurnoUsuario.SelectedIndex]["cHoraSalida"]);
            if (dHoraInicio <= dHoraMinimo && idTipoPermiso == 3)
            {
                MessageBox.Show("Hora Inicial de Permiso debe ser mayor a Inicio de Turno", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpHoraInicio.Value = dHoraMinimo.AddMinutes(1);
                dtpHoraInicio.Focus();
                return;
            }
            if (dHoraFin > dHoraMaximo && idTipoPermiso == 3)
            {
                MessageBox.Show("Hora Final de Permiso debe ser menor o igual a Fin de Turno", "Solicitud de Permiso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpHoraFinal.Value = dHoraMaximo;
                dtpHoraFinal.Focus();
                return;
            }

            // Guardar Permiso
            if (cTipTrxPermiso == "N")
            {
                DataTable dtRegistrarPermiso = objPermiso.CNRegistrarSolicitudPermiso(idUsuario, idTipoPermiso, idMotivo, dFechaInicio, dFechaFin, idDetalleHorario, dHoraInicio, dHoraFin, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);

                MessageBox.Show(dtRegistrarPermiso.Rows[0]["cMensaje"].ToString(), "Solicitud de Permiso", MessageBoxButtons.OK, ((int)dtRegistrarPermiso.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
                if ((int)dtRegistrarPermiso.Rows[0]["idError"] != 0) return;
            }

            cTipTrxPermiso = "";
            CargarListaPermisos(idUsuario);
            HabilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cTipTrxPermiso = "";
            HabilitarControles(false);
            if (dtgPermisosUsuario.Rows.Count <= 0)
            {
                btnEliminar.Enabled = false;
                btnImprimir.Enabled = false;
            }
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

            return true;
        }
    }
}
