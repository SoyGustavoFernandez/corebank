using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMonitorScoringFactorRsgo : frmBase
    {

        #region Variables globales

        private clsCNScoring _cnScoring ;
        private string cTitulo = "Reporte de solicitudes de crédito con riesgo de sobreendeudamiento";
        private int idCli = 0;
        private int idEval = 0;
        private int idTipoPersona = 0;
        private int idTipoEval = 0;
        private string cTipoEval = String.Empty;
        private DateTime dFecha;
        private bool lEsPerfil = false;

        #endregion

        public frmMonitorScoringFactorRsgo()
        {
            InitializeComponent();
            _cnScoring = new clsCNScoring();
        }

        #region Eventos

        private void frmMonitorScoringFactorRsgo_Load(object sender, EventArgs e)
        {
            cboRiesgo.CargarVigentes(0);
            cboRegimenScoring.CargarTodos();
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            cboRiesgo.SelectedValue = 0;
            cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            cboRegimenScoring.SelectedValue = 0;
            verificarPerfilEvaluador();
        }

        private void btnConsultar1_Click(object sender, EventArgs e)
        {
            if (validarFiltros())
            {
                return;
            }

            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;
            int idRiesgo = Convert.ToInt32(cboRiesgo.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idRegimen = Convert.ToInt32(cboRegimenScoring.SelectedValue);
            bool lSoloNuevos = chcSoloNuevos.Checked;
            bool lSoloRecurrentes = chcSoloRecurrentes.Checked;
            if (chcTodos.Checked)
            {
                lSoloNuevos = true;
                lSoloRecurrentes = true;
            }
            DataTable dtEvaluaciones =
                _cnScoring.ListarEvaluacionesScoring(0, dFecIni, dFecFin, idRiesgo, idRegimen, idAgencia, lSoloNuevos, lSoloRecurrentes);
            if (dtEvaluaciones.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para esos filtros", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtgLista.DataSource = dtEvaluaciones;
            formatoDTGEvaluaciones();
            habilitarControles(false);
        }

        private void dtgLista_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgLista.SelectedRows.Count > 0)
            {
                DataTable dtHistoricoEval = _cnScoring.ListarEvaluacionHistoricoScoring(Convert.ToInt32(dtgLista.SelectedRows[0].Cells["idCli"].Value), chcSoloRecurrentes.Checked);
                dtgEvaluaciones.DataSource = dtHistoricoEval;
                darFormatoHistoricoEval();
            }
            else
            {
                this.dtgEvaluaciones.DataSource = null;
            }
        }

        private void dtgEvaluaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                idTipoEval = Convert.ToInt32(dtgEvaluaciones.SelectedRows[0].Cells["idTipoEval"].Value);
                idCli = Convert.ToInt32(dtgEvaluaciones.SelectedRows[0].Cells["idCli"].Value);
                idEval = Convert.ToInt32(dtgEvaluaciones.SelectedRows[0].Cells["idEvaluacion"].Value);
                dFecha = Convert.ToDateTime(dtgEvaluaciones.SelectedRows[0].Cells["dFechaEval"].Value);
                idTipoPersona = Convert.ToInt32(dtgEvaluaciones.SelectedRows[0].Cells["idTipoPersona"].Value);
                cTipoEval = Convert.ToString(dtgEvaluaciones.SelectedRows[0].Cells["TipoEvaluacion"].Value);
            }
        }

        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                frmEvaluacionClientes evaluacionCliente = new frmEvaluacionClientes(idEval,idCli,idTipoEval,dFecha);
                evaluacionCliente.VerEvaluacionUltima();
                evaluacionCliente.ShowDialog();
                if (lEsPerfil)
                {
                    DataTable dtActualizarVisto = _cnScoring.ActualizarAvistoEval(idEval, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna evaluación", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
        }

        private void btnImprirCli_Click(object sender, EventArgs e)
        {
            if (dtgLista.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros en la lista de clientes", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaDesde", dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));

            string reportpath = "rptListaCliUltEvalScoring.rdlc";
            dtslist.Add(new ReportDataSource("DataSet1", dtgLista.DataSource));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        #endregion

        #region Metodos

        private void formatoDTGEvaluaciones()
        {
            foreach (DataGridViewColumn item in this.dtgLista.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgLista.Columns["idCli"].Visible = true;
            dtgLista.Columns["cNombre"].Visible = true;
            dtgLista.Columns["cTipoDoc"].Visible = true;
            dtgLista.Columns["cDocumentoID"].Visible = true;
            dtgLista.Columns["cTipoPersona"].Visible = true;
            dtgLista.Columns["cDocumentoRUC"].Visible = true;
            dtgLista.Columns["cPerfil"].Visible = true;
            dtgLista.Columns["cAgenciaReg"].Visible = true;
            dtgLista.Columns["cAgencia"].Visible = true;
            dtgLista.Columns["nPuntajeCalific"].Visible = true;
            dtgLista.Columns["cCalificativo"].Visible = true;

            dtgLista.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgLista.Columns["cNombre"].HeaderText = "Nombres";
            dtgLista.Columns["cTipoDoc"].HeaderText = "Tipo Doc.";
            dtgLista.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgLista.Columns["cTipoPersona"].HeaderText = "Tipo persona";
            dtgLista.Columns["cDocumentoRUC"].HeaderText = "RUC";
            dtgLista.Columns["cPerfil"].HeaderText = "Perfil riesgo";
            dtgLista.Columns["cAgenciaReg"].HeaderText = "Agencia registro";
            dtgLista.Columns["cAgencia"].HeaderText = "Agencia ultima evaluación";
            dtgLista.Columns["nPuntajeCalific"].HeaderText = "Puntaje";
            dtgLista.Columns["cCalificativo"].HeaderText = "Calificativo";

        }

        private bool validarFiltros()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void habilitarControles(bool val)
        {
            cboRiesgo.Enabled = val;
            cboAgencia.Enabled = val;
            dtpFecIni.Enabled = val;
            dtpFecFin.Enabled = val;
            cboRegimenScoring.Enabled = val;
            chcSoloNuevos.Enabled = val;
            chcSoloRecurrentes.Enabled = val;
            chcTodos.Enabled = val;

            btnConsultar.Enabled = val;
            
        }

        private void darFormatoHistoricoEval()
        {
            foreach (DataGridViewColumn item in this.dtgEvaluaciones.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dtgEvaluaciones.Columns["TipoEvaluacion"].Visible = true;
            dtgEvaluaciones.Columns["dFechaEval"].Visible = true;
            dtgEvaluaciones.Columns["idCli"].Visible = true;
            dtgEvaluaciones.Columns["cRegimen"].Visible = true;
            dtgEvaluaciones.Columns["nPuntajeCalific"].Visible = true;
            dtgEvaluaciones.Columns["cCalificativo"].Visible = true;
            dtgEvaluaciones.Columns["cAgencia"].Visible = true;
            dtgEvaluaciones.Columns["cUsuarioEval"].Visible = true;
            dtgEvaluaciones.Columns["lNuevo"].Visible = true;

            dtgEvaluaciones.Columns["TipoEvaluacion"].HeaderText = "Tipo Evaluación";
            dtgEvaluaciones.Columns["idEvaluacion"].HeaderText = "N° Evaluación";
            dtgEvaluaciones.Columns["dFechaEval"].HeaderText = "Fecha Evaluación";
            dtgEvaluaciones.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgEvaluaciones.Columns["cNombre"].HeaderText = "Nombres";
            dtgEvaluaciones.Columns["cTipoDoc"].HeaderText = "Tipo Doc.";
            dtgEvaluaciones.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgEvaluaciones.Columns["cRegimen"].HeaderText = "Régimen";
            dtgEvaluaciones.Columns["nPuntajeCalific"].HeaderText = "Puntaje";
            dtgEvaluaciones.Columns["cCalificativo"].HeaderText = "Calificativo";
            dtgEvaluaciones.Columns["cAgencia"].HeaderText = "Agencia Eval.";
            dtgEvaluaciones.Columns["cUsuarioEval"].HeaderText = "Usuario Eval.";
            dtgEvaluaciones.Columns["lNuevo"].HeaderText = "Es Nuevo";

            foreach (DataGridViewRow item in dtgEvaluaciones.Rows)
            {
                if (Convert.ToBoolean(item.Cells["lNuevo"].Value))
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                item.Cells["cCalificativo"].Style.BackColor = Color.FromName(item.Cells["cColorRiesgo"].Value.ToString());
            }
        }

        private void verificarPerfilEvaluador()
        {
            DataTable dtPErfil = _cnScoring.ListarPerfilSuperEvalScoring();
            foreach (DataRow item in dtPErfil.Rows)
            {
                if (Convert.ToInt32(item["idPerfil"]) == clsVarGlobal.PerfilUsu.idPerfil)
                {
                    lEsPerfil = true;
                    break;
                }
            }
            if (lEsPerfil)
            {
                cboRiesgo.Enabled = true;
                cboAgencia.Enabled = true;
                chcSoloNuevos.Enabled = true;
            }
            else
            {
                cboRiesgo.Enabled = false;
                cboAgencia.Enabled = false;
                chcSoloNuevos.Checked = false;
                chcSoloNuevos.Enabled = false;
                btnNuevo.Enabled = false;
            }
        }

        #endregion

    }
}
