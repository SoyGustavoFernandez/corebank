using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmEvaluacionClientes : frmBase
    {

        #region Variables Globales

        private clsCNScoring _objCnScoring;
        private DataTable dtCalificacion;

        private DateTime dFechaEval;
        private int idEval = 0;
        private const string cTituloMensajes = "Evaluación de clientes Scoring";
        private bool lSoloGrabar = false;

        #endregion

        #region Constructores

        public frmEvaluacionClientes()
        {
            InitializeComponent();
            _objCnScoring = new clsCNScoring();

            cboRiesgo.CargarVigentes(0);

            dtpFechaEval.Value = clsVarGlobal.dFecSystem.Date;
            btnImprimir.Enabled = false;
        }

        public frmEvaluacionClientes(int idCli, int idTipoEval) : this()
        {
            conBusCli.CargardatosCli(idCli);
            CargarDatosCli();
            cboTipoEval.SelectedValue = idTipoEval;
            ProcesarEvaluacion();

            lSoloGrabar = true;
            conBusCli.btnBusCliente.Enabled = false;
            cboTipoEval.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public frmEvaluacionClientes(int idEval, int idCli, int idTipoEval, DateTime dFechaEval) : this()
        {
            conBusCli.CargardatosCli(idCli);
            CargarDatosCli();
            cboTipoEval.SelectedValue = idTipoEval;
            this.dFechaEval = dFechaEval;
            this.idEval = idEval;

            conBusCli.btnBusCliente.Enabled = false;
            cboTipoEval.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        #endregion

        #region Eventos

        private void frmEvaluacionClientes_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            CargarDatosCli();
            activarControlObjetos(this, EventoFormulario.NUEVO);
        }

        private void cboTipoEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoEval.SelectedIndex >= 0)
            {
                int idTipoEval = (int)cboTipoEval.SelectedValue;
                lblTipoEvaluacion.Text = cboTipoEval.Text;
                cboGrupoFactores.CargarTodos(idTipoEval);
                cboGrupoFactores.SelectedIndexChanged += cboGrupoFactores_SelectedIndexChanged;
            }
        }

        private void cboGrupoFactores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoFactores.SelectedIndex >= 0)
            {
                DataRowView row = (DataRowView)cboGrupoFactores.SelectedItem;
                int idFactor = (int)row["idFactor"];
                DataTable dtCalificacion = dtgCalificacion.DataSource as DataTable;
                if (dtCalificacion != null)
                {
                    dtCalificacion.DefaultView.RowFilter = string.Format("idGrupo={0}", idFactor);
                }
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            ProcesarEvaluacion();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GuardarEvaluacion(true);
            activarControlObjetos(this, EventoFormulario.GRABAR);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cIds = txtNroEval.Text;

            DataTable dtEvaluaciones = _objCnScoring.ListaEvalScoringReporte(cIds);
            string reportpath = String.Empty;
            reportpath = dtEvaluaciones.Rows.Count > 0 ? dtEvaluaciones.Rows[0]["cNomReporte"].ToString() : string.Empty;
            if(string.IsNullOrEmpty(reportpath))
            {
                MessageBox.Show("No se encontró reporte para el tipo de evaluación", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cIdsEval", cIds, false));

            dtslist.Add(new ReportDataSource("DSClientes", dtEvaluaciones));
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            btnImprimir.Enabled = true;
            btnGrabar.Enabled = false;
            btnProcesar.Enabled = false;
            btnCancelar.Enabled = true;
            btnSalir.Enabled = true;

            activarControlObjetos(this, EventoFormulario.IMPRIMIR);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            cboTipoEval.Enabled = true;

            btnProcesar.Enabled = false;
            btnGrabar.Enabled = false;
            btnImprimir.Enabled = false;
            btnCancelar.Enabled = false;
        }

        #endregion

        #region Metodos

        public bool GuardarEvaluacion(bool lShowForm)
        {
            bool lFlag = false;
            if (!ValidarParaGuardar(lShowForm))
                return lFlag;

            string xmlDetalle = preparaXMLEvaluacion();
            int idCli = conBusCli.idCli;
            int idTipoEval = (int)cboTipoEval.SelectedValue;
            decimal nValorTotal = Convert.ToDecimal(txtValorTotal.Text);
            int idCalifRiesgo = Convert.ToInt32(cboRiesgo.SelectedValue);
            string cEvalBatch = lShowForm ? string.Empty : "BATCH";
            bool lBatch = !lShowForm;
            DataTable dtInsercion = _objCnScoring.GuardaEvaluacionScoring(idCli, idTipoEval, clsVarGlobal.nIdAgencia,
                                                                        nValorTotal, idCalifRiesgo, clsVarGlobal.User.idUsuario,
                                                                        dtpFechaEval.Value.Date, cEvalBatch, lBatch, xmlDetalle);
            if (dtInsercion.Rows.Count > 0)
            {
                if (lShowForm)
                {
                    MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(),
                                    cTituloMensajes,
                                    MessageBoxButtons.OK,
                                    ((int)dtInsercion.Rows[0]["idError"] == 0 ?
                                        MessageBoxIcon.Information :
                                        MessageBoxIcon.Exclamation));
                }
                if ((int)dtInsercion.Rows[0]["idError"] == 0)
                {
                    if (lShowForm)
                    {
                        idEval = Convert.ToInt32(dtInsercion.Rows[0]["idEvaluacion"].ToString());
                        txtNroEval.Text = idEval.ToString();
                        txtFechaEval.Text = Convert.ToString(dtInsercion.Rows[0]["dFechaEval"].ToString());
                        dtpFechaEval.Value = Convert.ToDateTime(dtInsercion.Rows[0]["dFechaEval"].ToString());
                        dFechaEval = dtpFechaEval.Value;
                    }

                    lFlag = true;
                }
                if (lShowForm)
                {
                    btnImprimir.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnProcesar.Enabled = false;
                    btnCancelar.Enabled = !lSoloGrabar;
                }
            }

            return lFlag;
        }

        public void VerEvaluacionUltima()
        {
            DataTable dtEvaluacion = _objCnScoring.ListarDetalleEvalScoring(idEval);

            clsCNScoring objcnScoring = new clsCNScoring();
            dtCalificacion = objcnScoring.GeneraEvaluacion(0, null, null, null);

            foreach (DataRow item in dtEvaluacion.Rows)
            {
                DataRow drCalifCli0 = dtCalificacion.NewRow();

                drCalifCli0["idFactor"] = Convert.ToInt32(item["idFactorCalific"]);
                drCalifCli0["idFactorPadre"] = item["idFactorPadre"];
                drCalifCli0["Criterios"] = item["cDescripcion"];
                drCalifCli0["Ponderacion"] = item["nPonderacion"];
                drCalifCli0["Valor"] = item["nValor"];
                drCalifCli0["cColumna"] = item["cColumna"]; ;
                drCalifCli0["idDatoCliente"] = item["idDatoCliente"];
                drCalifCli0["DatoCliente"] = item["cDatoCliente"];
                drCalifCli0["Puntaje"] = item["nPuntaje"];
                drCalifCli0["idCalificativo"] = item["idCalificativo"];
                drCalifCli0["cCalificativo"] = item["cCalificativo"];
                drCalifCli0["cColorCalific"] = item["cColorCalific"];
                drCalifCli0["idGrupo"] = item["idGrupo"];
                dtCalificacion.Rows.Add(drCalifCli0);
            }

            dtgCalificacion.DataSource = dtCalificacion;
            FormatoDetalleEvaluacion();
            MostrarConsolidado();
            MostrarResultado();

            txtNroEval.Text = idEval.ToString();
            txtFechaEval.Text = dFechaEval.ToString("dd/MM/yyyy");
            dtpFechaEval.Value = dFechaEval;

            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = true;
            btnProcesar.Enabled = false;

            cboTipoEval.Enabled = false;

            cboGrupoFactores.SelectedIndex = cboGrupoFactores.Items.Count > 0 ? 0 : -1;
        }

        private void CargarDatosCli()
        {
            if (conBusCli.idCli == 0)
                return;

            int idTipoPersona = conBusCli.nidTipoPersona;
            cboTipoEval.CargarPorTipoPersona(idTipoPersona);
            cboTipoEval.SelectedIndexChanged += cboTipoEval_SelectedIndexChanged;

            btnImprimir.Enabled = false;
            btnGrabar.Enabled = false;
            btnProcesar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void MostrarResultado()
        {
            decimal nPuntaje;
            if (!decimal.TryParse(txtValorTotal.Text, out nPuntaje))
                return;

            DataRow result = ObtenerCalificativo(nPuntaje);

            if (result != null)
            {
                cboRiesgo.SelectedValue = result["idCalificativo"];
                txtValorTotal.BackColor = Color.FromName(Convert.ToString(((DataRowView)cboRiesgo.SelectedItem)["cColorRiesgo"]));
            }
            else
            {
                cboRiesgo.SelectedIndex = -1;
                txtValorTotal.BackColor = Color.FromName("Window");
            }
        }

        private void MostrarConsolidado()
        {
            decimal SumaTotal = 0;
            dtCalificacion.AcceptChanges();
            var dtFilter = dtCalificacion.AsEnumerable().Where(x => x.Field<int>("idFactorPadre") == 0);
            DataTable dtConsolidado = dtConsolidado = dtFilter.Any() ? dtFilter.CopyToDataTable() : dtCalificacion.Clone();
            SumaTotal = dtConsolidado.AsEnumerable().Sum(x => x.Field<decimal>("Puntaje"));
            txtValorTotal.Text = SumaTotal.ToString("#,0.00");
            dtgConsolidado.DataSource = dtConsolidado;
            FormatoConsolidado();
        }

        private void LimpiarControles()
        {
            if (((DataTable)dtgCalificacion.DataSource) != null)
                ((DataTable)dtgCalificacion.DataSource).Clear();
            if (((DataTable)dtgConsolidado.DataSource) != null)
                ((DataTable)dtgConsolidado.DataSource).Clear();

            conBusCli.limpiarControles();
            conBusCli.btnBusCliente.Enabled = true;
            conBusCli.txtCodCli.Enabled = true;
            cboGrupoFactores.SelectedIndex = -1;
            idEval = 0;
            txtValorTotal.Text = "0.00";
            txtValorTotal.BackColor = Color.FromName("Window");
            cboTipoEval.SelectedIndex = -1;
            cboGrupoFactores.SelectedIndex = -1;
            cboRiesgo.SelectedIndex = -1;
            conBusCli.txtCodCli.Focus();
        }

        private DataRow ObtenerCalificativo(decimal nPuntaje)
        {
            var result = cboRiesgo.DataSourceRows.FirstOrDefault(item => Convert.ToDecimal(item["nMinCalific"]) <= nPuntaje
                                                                    && nPuntaje <= Convert.ToDecimal(item["nMaxCalific"]));
            return result;
        }

        private void FormatoDetalleEvaluacion()
        {
            foreach (DataGridViewColumn item in this.dtgCalificacion.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCalificacion.Columns["Criterios"].Visible = true;
            dtgCalificacion.Columns["Ponderacion"].Visible = true;
            dtgCalificacion.Columns["DatoCliente"].Visible = true;
            dtgCalificacion.Columns["Valor"].Visible = true;
            dtgCalificacion.Columns["Puntaje"].Visible = true;

            dtgCalificacion.Columns["Criterios"].FillWeight = 100;
            dtgCalificacion.Columns["Ponderacion"].FillWeight = 40;
            dtgCalificacion.Columns["DatoCliente"].FillWeight = 40;
            dtgCalificacion.Columns["Valor"].FillWeight = 40;
            dtgCalificacion.Columns["Puntaje"].FillWeight = 40;

            dtgCalificacion.Columns["Ponderacion"].DefaultCellStyle.Format = "#,0.00";
            dtgCalificacion.Columns["Valor"].DefaultCellStyle.Format = "#,0.00";
            dtgCalificacion.Columns["Puntaje"].DefaultCellStyle.Format = "#,0.00";
        }

        private void FormatoConsolidado()
        {
            foreach (DataGridViewColumn item in dtgConsolidado.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgConsolidado.Columns["Criterios"].Visible = true;
            dtgConsolidado.Columns["Ponderacion"].Visible = true;
            dtgConsolidado.Columns["Valor"].Visible = true;
            dtgConsolidado.Columns["Puntaje"].Visible = true;

            dtgConsolidado.Columns["Criterios"].FillWeight = 100;
            dtgConsolidado.Columns["Ponderacion"].FillWeight = 40;
            dtgConsolidado.Columns["Valor"].FillWeight = 40;
            dtgConsolidado.Columns["Puntaje"].FillWeight = 40;
            dtgConsolidado.Columns["cCalificativo"].FillWeight = 60;

            dtgConsolidado.Columns["Ponderacion"].DefaultCellStyle.Format = "#,0.00";
            dtgConsolidado.Columns["Valor"].DefaultCellStyle.Format = "#,0.00";
            dtgConsolidado.Columns["Puntaje"].DefaultCellStyle.Format = "#,0.00";
        }

        private void CargaEvaluacion(int idCli,int idTipoEval)
        {
            var lstClientes = new List<int>();
            lstClientes.Add(idCli);
            DataTable dtDatosCli = _objCnScoring.ListaDatosCliEvaluacion(lstClientes);
            DataTable dtFactores = cboGrupoFactores.DataSourceTable;
            DataTable dtCriterios = _objCnScoring.ListaFactoresCalificacion(idTipoEval, 0, 0);
            dtCalificacion = _objCnScoring.GeneraEvaluacion(idTipoEval, dtDatosCli.Rows[0], dtFactores, dtCriterios);
            dtgCalificacion.DataSource = dtCalificacion;
            FormatoDetalleEvaluacion();
            MostrarConsolidado();
            MostrarResultado();
            cboGrupoFactores.SelectedIndex = dtCalificacion.Rows.Count > 0 ? 0 : -1;
        }

        private void ProcesarEvaluacion()
        {
            if (!ValidarProcesar())
                return;

            int idCli = conBusCli.idCli;
            int idTipoEval = (int)cboTipoEval.SelectedValue;
            CargaEvaluacion(idCli, idTipoEval);

            btnImprimir.Enabled = false;
            btnGrabar.Enabled = true;
            btnProcesar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private string preparaXMLEvaluacion()
        {
            DataSet DSDetalleEval = new DataSet("DSDetalleEval");
            DSDetalleEval.Tables.Add(dtCalificacion);
            string xmlDetalle = DSDetalleEval.GetXml();
            xmlDetalle = clsCNFormatoXML.EncodingXML(xmlDetalle);
            DSDetalleEval.Tables.Clear();
            return xmlDetalle;
        }

        private bool ValidarProcesar()
        {
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text.Trim()))
            {
                MessageBox.Show("Seleccione el cliente a evaluar.",
                                    cTituloMensajes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboTipoEval.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de evaluacion.",
                                    cTituloMensajes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarParaGuardar(bool lShowMessages)
        {
            if (dtgCalificacion.Rows.Count == 0)
            {
                if (lShowMessages)
                {
                    MessageBox.Show("El tipo de evaluación seleccionado no tiene factores.",
                                        cTituloMensajes,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        #endregion

        
    }
}