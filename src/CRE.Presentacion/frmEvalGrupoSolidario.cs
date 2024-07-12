using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using CLI.CapaNegocio;
namespace CRE.Presentacion
{
    public partial class frmEvalGrupoSolidario : frmBase
    {
        #region Variables
        private clsEvalCredGrupoSol objEvalCredGrupoSol;
        private List<clsEvalCredIntegGrupoSol> lstEvalCredIntegGrupoSol;
        private clsCreditoProp objCreditoProp;

        private clsSolicitudCredGrupoSol lstSolicitudCredGrupoSol = new clsSolicitudCredGrupoSol();
        private List<clsSolCredGSIntegrante> lstSolCredGSIntegrante = new List<clsSolCredGSIntegrante>();
        private bool lValidacion = false;
        private const string TITULO_FORM = "Grupo Solidario - Evaluación";

        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        #endregion

        #region Constructor
        public frmEvalGrupoSolidario()
        {
            InitializeComponent();

            clsCreditoProp oCreditoProp = new clsCreditoProp();
            oCreditoProp.idTipoPeriodo = 1;
            oCreditoProp.idAgencia = clsVarGlobal.nIdAgencia;
            oCreditoProp.dFechaDesembolso = clsVarGlobal.dFecSystem;
            oCreditoProp.nMonto = 0;
            oCreditoProp.nTasaCompensatoria = 0;
            oCreditoProp.nMontoMinimo = 0;
            oCreditoProp.nMontoMaximo = 500;
            oCreditoProp.nCuotas = 1;
            conCondiCreditoGrupoSol.AsignarDatos(oCreditoProp);

            HabilitarFormulario(EventoFormulario.CANCELAR);
            HabilitarBotones(false);
            this.conBusGrupoSol1.HabilitarBusqueda();

            btnVincularVisita1.lIndividual = false;
        }
        #endregion

        #region Métodos
        private void ObtenerEvaluacion(int idGrupoSolidario)
        {
            //this.conCondiCreditoGrupoSol.ChangeCondiCredito -= new System.EventHandler(this.conCondiCreditoGrupoSol_ChangeCondiCredito);

            DataSet ds = (new clsCNGrupoSolidario()).ObtenerEvalCredGrupoSol(idGrupoSolidario);
            decimal nMontoTotal = 0;

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No se encontró evaluación para el Código del Grupo" + "", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["idUsuario"]) != clsVarGlobal.User.idUsuario)
                {
                    MessageBox.Show("La Solicitud del grupo solidario lo debe evaluar solo el usuario: " + ds.Tables[0].Rows[0]["cWinUser"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // --Evaluacion de un Grupo Solidario
                var listEvalCredGrupoSol = DataTableToList.ConvertTo<clsEvalCredGrupoSol>(ds.Tables[0]) as List<clsEvalCredGrupoSol>;
                this.objEvalCredGrupoSol = listEvalCredGrupoSol[0];

                // --Evaluación de los integrantes del Grupo Solidario
                this.lstEvalCredIntegGrupoSol = (new clsCNGrupoSolidario()).ListarEvalCredsIntegsGrupoSol(this.objEvalCredGrupoSol.idGrupoSolidario, this.objEvalCredGrupoSol.idEvalCredGrupoSol);

                // --Asignación de valores
                nMontoTotal = this.lstEvalCredIntegGrupoSol.Sum(x => x.nMonto);

                // --Asignación de textbox
                this.txtComSituacionAct.Text = this.objEvalCredGrupoSol.cComSituacionAct;
                this.txtComGarantias.Text = this.objEvalCredGrupoSol.cComGarantias;
                this.txtComConclusiones.Text = this.objEvalCredGrupoSol.cComConclusiones;

                // --Asignación de de las condiciones del crédito
                this.objCreditoProp = new clsCreditoProp();
                this.objCreditoProp.idMoneda = this.objEvalCredGrupoSol.idMoneda;
                this.objCreditoProp.nCuotas = this.objEvalCredGrupoSol.nCuotas;
                this.objCreditoProp.idTipoPeriodo = this.objEvalCredGrupoSol.idTipoPeriodo;
                this.objCreditoProp.nPlazoCuota = this.objEvalCredGrupoSol.nPlazoCuota;
                this.objCreditoProp.nDiasGracia = this.objEvalCredGrupoSol.nDiasGracia;
                this.objCreditoProp.nCuotasGracia = this.objEvalCredGrupoSol.nCuotasGracia;
                this.objCreditoProp.dFechaDesembolso = this.objEvalCredGrupoSol.dFechaDesembolso;
                this.objCreditoProp.idAsesor = this.objEvalCredGrupoSol.idAsesor;
                this.objCreditoProp.idAgencia = this.objEvalCredGrupoSol.idAgencia;
                this.objCreditoProp.idProducto = this.objEvalCredGrupoSol.idProducto;
                this.objCreditoProp.idSubProducto = this.objEvalCredGrupoSol.idSubProducto;
                this.objCreditoProp.idOperacion = this.objEvalCredGrupoSol.idOperacion;
                this.objCreditoProp.idModalidadCredito = this.objEvalCredGrupoSol.idModalidadCredito;
                this.objCreditoProp.idModalidadDes = this.objEvalCredGrupoSol.idModalidadDes;
                this.objCreditoProp.idTasa = this.objEvalCredGrupoSol.idTasa;

                this.objCreditoProp.nMonto = nMontoTotal;
                this.objCreditoProp.nMontoSolicitado = nMontoTotal;
                this.objCreditoProp.nMontoMinimo = this.lstEvalCredIntegGrupoSol.Min(x => x.nMonto);
                this.objCreditoProp.nMontoMaximo = this.lstEvalCredIntegGrupoSol.Max(x => x.nMonto);
                this.objCreditoProp.nCuotaAprox = 100;

                this.objCreditoProp.idGrupoSolidario = objEvalCredGrupoSol.idGrupoSolidario;
                this.objCreditoProp.idSolicitudCredGrupoSol = objEvalCredGrupoSol.idSolicitudCredGrupoSol;
                this.objCreditoProp.idEvalCredGrupoSol = objEvalCredGrupoSol.idEvalCredGrupoSol;

                //this.txtTipoCambio.Text = this.objEvalCredGrupoSol.nTipoCambio.ToString("n4");
                this.btnVincularVisita1.idSolicitudGrupoSol = this.objCreditoProp.idSolicitudCredGrupoSol;
                this.btnVincularVisita1.idGrupoSolidario = idGrupoSolidario;

                conCondiCreditoGrupoSol.AsignarDatos(this.objCreditoProp);
                conCondiCreditoGrupoSol.idTipoGrupoSolidario = conBusGrupoSol1.obtenerTipoGrupoSol();
                
                this.dtgIntegrantes.DataSource = this.lstEvalCredIntegGrupoSol;

                FormatearDataGridIntegrantes();

                this.dtgIntegrantes.ClearSelection();

            }
        }

        private void validarReglas()
        {
            obtenerSolicitudGrupo();
            obtenerSolicitudes();
            string cNombreFormulario = this.Name;
            frmReglasGrupo frmExcepcionesGrupo = new frmReglasGrupo(3, cNombreFormulario, lstSolicitudCredGrupoSol, lstSolCredGSIntegrante);
            frmExcepcionesGrupo.ShowDialog();
            lstSolCredGSIntegrante.Clear();
            this.lValidacion = frmExcepcionesGrupo.lEstado;
        }

        private void obtenerSolicitudGrupo()
        {
            lstSolicitudCredGrupoSol.idSolicitudCredGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol;
            lstSolicitudCredGrupoSol.idGrupoSolidario = this.objEvalCredGrupoSol.idGrupoSolidario;
            lstSolicitudCredGrupoSol.idProducto = objCreditoProp.idProducto;
            lstSolicitudCredGrupoSol.idModalidadCredito = this.objEvalCredGrupoSol.idModalidadCredito;
            lstSolicitudCredGrupoSol.dFecDesemb = objCreditoProp.dFechaDesembolso;
            lstSolicitudCredGrupoSol.dFechaPrimeraCuota = objCreditoProp.dFechaPrimeraCuota;
            lstSolicitudCredGrupoSol.nCuotas = objCreditoProp.nCuotas;
            lstSolicitudCredGrupoSol.nPlazoCuota = objCreditoProp.nPlazoCuota;
            lstSolicitudCredGrupoSol.idAgencia = Convert.ToInt32(clsVarGlobal.nIdAgencia);
            lstSolicitudCredGrupoSol.idTipoPeriodo = objCreditoProp.idTipoPeriodo;
            lstSolicitudCredGrupoSol.cNombreGrupo = this.objEvalCredGrupoSol.cNombre;
            lstSolicitudCredGrupoSol.idGrupoSolidarioCiclo = this.objEvalCredGrupoSol.idGrupoSolidarioCiclo;
        }

        private void obtenerSolicitudes()
        {
            for (int i = 0; i < this.dtgIntegrantes.Rows.Count; i++)
            {
                lstSolCredGSIntegrante.Add(
                    new clsSolCredGSIntegrante()
                    {
                        idSolicitud = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idSolicitud"].Value),
                        idSolicitudCredGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol,
                        idCli = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idCli"].Value),
                        nMonto = Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nMonto"].Value),
                        idDetalleGasto = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idDetalleGasto"].Value),
                        //idDestino = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idDestino"].Value),
                        cNombreCompleto = Convert.ToString(this.dtgIntegrantes.Rows[i].Cells["cNombre"].Value),
                    }
                );
            }
        }

        private string EvalCredGrupoSolXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCredGrupoSol", typeof(int));
            dt.Columns.Add("nMonto", typeof(decimal));
            dt.Columns.Add("nCuotas", typeof(int));
            dt.Columns.Add("idTipoPeriodo", typeof(int));
            dt.Columns.Add("nPlazoCuota", typeof(int));
            dt.Columns.Add("nDiasGracia", typeof(int));
            dt.Columns.Add("nCuotasGracia", typeof(int));
            dt.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dt.Columns.Add("idTasa", typeof(int));
            //dt.Columns.Add("nTasaEfectivaAnual", typeof(decimal));
            //dt.Columns.Add("nTasaCompensatoria", typeof(decimal));

            dt.Columns.Add("cComSituacionAct", typeof(string));
            dt.Columns.Add("cComGarantias", typeof(string));
            dt.Columns.Add("cComConclusiones", typeof(string));

            dt.Columns.Add("idUsuModifica", typeof(int));
            dt.Columns.Add("dFechaMod", typeof(DateTime));

            dt.Rows.Add(
                    this.objEvalCredGrupoSol.idEvalCredGrupoSol,
                    this.lstEvalCredIntegGrupoSol.Sum(x => x.nMonto),
                    this.objCreditoProp.nCuotas,
                    this.objCreditoProp.idTipoPeriodo,
                    this.objCreditoProp.nPlazoCuota,
                    this.objCreditoProp.nDiasGracia,
                    this.objCreditoProp.nCuotasGracia,
                    this.objCreditoProp.dFechaDesembolso,
                    this.objCreditoProp.idTasa,
                    this.txtComSituacionAct.Text,
                    this.txtComGarantias.Text,
                    this.txtComConclusiones.Text,
                    clsVarGlobal.PerfilUsu.idUsuario,
                    clsVarGlobal.dFecSystem
            );

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCredGrupoSol", "Item");
        }

        private string EvalIntegrantesXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idSolicitud", typeof(int));
            dt.Columns.Add("nMonto", typeof(decimal));
            dt.Columns.Add("idTasa", typeof(int));
            dt.Columns.Add("nTEA", typeof(decimal));
            dt.Columns.Add("nTEM", typeof(decimal));
            dt.Columns.Add("nCuotaAprox", typeof(decimal));
            dt.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dt.Columns.Add("nPlazo", typeof(int));
            dt.Columns.Add("idActividad", typeof(int));
            dt.Columns.Add("idActividadInterna", typeof(int));
            dt.Columns.Add("nTIM", typeof(decimal));

            dt.Columns.Add("nSaldoCapital", typeof(decimal));
            dt.Columns.Add("nIntMoraOtros", typeof(decimal));
            dt.Columns.Add("nMontoAmpliado", typeof(decimal));

            dt.Columns.Add("idPaqueteSeguro", typeof(int));

            foreach (clsEvalCredIntegGrupoSol obj in this.lstEvalCredIntegGrupoSol)
            {
                dt.Rows.Add(
                    obj.idEvalCred,
                    obj.idSolicitud,
                    obj.nMonto,
                    obj.idTasa,
                    obj.nTEA,
                    obj.nTEM,
                    obj.nCuotaAprox,
                    obj.nCuotaGraciaAprox,
                    obj.nPlazo,
                    obj.idActividad,
                    obj.idActividadInterna,
                    obj.nTIM,
                    obj.nSaldoCapital,
                    obj.nIntMoraOtros,
                    obj.nMontoAmpliado,
                    obj.idPaqueteSeguro
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "SolCredIntegrante", "Item");
        }

        private void LimpiarFormulario()
        {
            conCondiCreditoGrupoSol.LimpiarControl();
            this.dtgIntegrantes.DataSource = null;

            this.txtComSituacionAct.Text = string.Empty;
            this.txtComGarantias.Text = string.Empty;
            this.txtComConclusiones.Text = string.Empty;

            this.objEvalCredGrupoSol = null;
            this.lstEvalCredIntegGrupoSol = null;
            this.objCreditoProp = null;
        }

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
            this.btnCancelar.Enabled = lHabilitado;

            this.btnImprimirEvalCualit.Enabled = lHabilitado;
            this.btnImprimirEERR.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;

            this.grbBotonesEvaluacion.Enabled = lHabilitado;
            this.grbPropuesta.Enabled = lHabilitado;
        }

        private void Reporte()
        {
            if (this.objEvalCredGrupoSol == null) return;

            clsCNGrupoSolidario cnRep = new clsCNGrupoSolidario();
            string idEval = Convert.ToString(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            int nIdEval = Convert.ToInt32(idEval);
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;

            DataTable dtData2 = cnRep.ReporteEvaluacion(nIdEval);
            DataTable dtData3 = cnRep.ReporteEvaluacion3(nIdEval);
            DataTable dtData4 = cnRep.ReporteEvaluacion4(nIdEval);
            DataTable dtData5 = cnRep.ReporteEvaluacion5(nIdEval);
            DataTable dtData6 = cnRep.ReporteEvaluacion6(nIdEval);
            DataTable dtData7 = cnRep.ReporteEvaluacion7(nIdEval);
            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsResEvalGrupal2", dtData2));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal3", dtData3));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal4", dtData4));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData5));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData6));
                dtsList.Add(new ReportDataSource("dsExcepcionesIndividuales", dtData7));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", idEval.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptResuEvalGrupal.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (String.IsNullOrWhiteSpace(this.txtComSituacionAct.Text))
            {
                objMsjError.AddError("La descripción de la Situación está vacía.");
            }

            if (String.IsNullOrWhiteSpace(this.txtComGarantias.Text))
            {
                objMsjError.AddError("La descripción de las Garantías está vacía.");
            }

            if (String.IsNullOrWhiteSpace(this.txtComConclusiones.Text))
            {
                objMsjError.AddError("La descripción de las conclusiones está vacía.");
            }

            DataTable dtRes = (new clsCNGrupoSolidario()).ValidarGrupoSolidario(objEvalCredGrupoSol.idEvalCredGrupoSol);
            if ((Convert.ToInt32(dtRes.Rows[0]["lValido"]) == 2) && (Convert.ToInt32(dtRes.Rows[0]["lValidoMin"]) == 2))
            {
                objMsjError.AddError("Una o mas de las capacidades de pago de los integrantes tienen el valor de 0%.");
            }
            else if ((Convert.ToInt32(dtRes.Rows[0]["lValido"]) == 0) && (Convert.ToInt32(dtRes.Rows[0]["lValidoMin"]) == 0))
            {
                objMsjError.AddError("Una o mas de las capacidades de pago de los integrantes esta fuera del límite establecido (CP máxima 80%) y (CP mínima mayor a 0%).");
            }
            else if ((Convert.ToInt32(dtRes.Rows[0]["lValido"]) == 1) && (Convert.ToInt32(dtRes.Rows[0]["lValidoMin"]) == 0))
            {
                objMsjError.AddError("Una o mas de las capacidades de pago de los integrantes esta fuera del límite establecido (CP mínima mayor a 0%)");
            }
            else if ((Convert.ToInt32(dtRes.Rows[0]["lValido"]) == 0) && (Convert.ToInt32(dtRes.Rows[0]["lValidoMin"]) == 1))
            {
                objMsjError.AddError("Una o mas de las capacidades de pago de los integrantes esta fuera del límite establecido (CP máxima 80%)");
            }

            dtRes = null;
            dtRes = (new clsCNGrupoSolidario()).ValidarEvalCualitativaGrupoSolidario(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            if (Convert.ToInt32(dtRes.Rows[0]["lValido"]) == 0)
            {
                objMsjError.AddError("No se registro la evaluación cualitativa");
            }

            if (validarExpedienteGS())
            {
                objMsjError.AddError("Expedientes de Grupo Solidario Incompletos");
            }

            return objMsjError;
        }

        private void FormatearDataGridIntegrantes()
        {
            foreach (DataGridViewColumn column in this.dtgIntegrantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIntegrantes.Columns["nNro"].DisplayIndex = 0;
            dtgIntegrantes.Columns["idSolicitud"].DisplayIndex = 1;
            dtgIntegrantes.Columns["cNombre"].DisplayIndex = 2;
            dtgIntegrantes.Columns["nMonto"].DisplayIndex = 3;
            dtgIntegrantes.Columns["nTEA"].DisplayIndex = 4;
            dtgIntegrantes.Columns["nTIM"].DisplayIndex = 5;
            dtgIntegrantes.Columns["nCuotaAprox"].DisplayIndex = 6;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].DisplayIndex = 7;
            dtgIntegrantes.Columns["cActividadInterna"].DisplayIndex = 8;

            dtgIntegrantes.Columns["nNro"].Visible = true;
            dtgIntegrantes.Columns["idSolicitud"].Visible = true;
            dtgIntegrantes.Columns["cNombre"].Visible = true;
            dtgIntegrantes.Columns["nMonto"].Visible = true;
            dtgIntegrantes.Columns["nTEA"].Visible = true;
            dtgIntegrantes.Columns["nTIM"].Visible = true;
            dtgIntegrantes.Columns["nCuotaAprox"].Visible = true;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].Visible = true;
            dtgIntegrantes.Columns["cActividadInterna"].Visible = true;

            dtgIntegrantes.Columns["nNro"].HeaderText = "N.";
            dtgIntegrantes.Columns["idSolicitud"].HeaderText = "Cod. Solicitud";
            dtgIntegrantes.Columns["cNombre"].HeaderText = "Cliente";
            dtgIntegrantes.Columns["nMonto"].HeaderText = "Monto S.";
            dtgIntegrantes.Columns["nTEA"].HeaderText = "TEA";
            dtgIntegrantes.Columns["nTIM"].HeaderText = "TIM";
            dtgIntegrantes.Columns["nCuotaAprox"].HeaderText = "Cuota Aprox.";
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].HeaderText = "Cuota Gracia Aprox.";
            dtgIntegrantes.Columns["cActividadInterna"].HeaderText = "Actividad";

            dtgIntegrantes.Columns["nNro"].FillWeight = 10;
            dtgIntegrantes.Columns["idSolicitud"].FillWeight = 15;
            dtgIntegrantes.Columns["cNombre"].FillWeight = 55;
            dtgIntegrantes.Columns["nMonto"].FillWeight = 25;
            dtgIntegrantes.Columns["nTEA"].FillWeight = 15;
            dtgIntegrantes.Columns["nTIM"].FillWeight = 15;
            dtgIntegrantes.Columns["nCuotaAprox"].FillWeight = 15;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].FillWeight = 15;
            dtgIntegrantes.Columns["cActividadInterna"].FillWeight = 40;

            dtgIntegrantes.Columns["nMonto"].DefaultCellStyle.Format = "### ### ##0.00";
            dtgIntegrantes.Columns["nTEA"].DefaultCellStyle.Format = "##0.00";
            dtgIntegrantes.Columns["nTIM"].DefaultCellStyle.Format = "##0.00";

            dtgIntegrantes.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private bool validarExpedienteGS()
        {
            bool lFaltante = false;
            DataTable dtExpediente = (new clsCNGrupoSolidario()).validarExpedienteGrupoSolidario(this.objEvalCredGrupoSol.idSolicitudCredGrupoSol);
            foreach (DataRow row in dtExpediente.Rows)
            {

                if (!Convert.ToBoolean(row["lDni"]) || !Convert.ToBoolean(row["lPosIntg"]) || !Convert.ToBoolean(row["lSentinel"]))
                {
                    lFaltante = true;
                    break;
                }
            }

            return lFaltante;
        }
        #endregion

        #region Eventos
        #region Botones
        private void btnEstResultados_Click(object sender, EventArgs e)
        {
            frmGrupoSolEvalIntegrantes frm = new frmGrupoSolEvalIntegrantes(this.objEvalCredGrupoSol.idEvalCredGrupoSol, this.lstEvalCredIntegGrupoSol);
            frm.lstEvalCredIntegGrupoSolidario = this.lstEvalCredIntegGrupoSol;
            frm.nCuotas = Convert.ToInt32(conCondiCreditoGrupoSol.txtNroCuotas.Text);
            frm.ShowDialog();

            if (frm.lGuardado == true)
            {
                //hacer algo 
            }
        }

        private void btnEvalCualitativa_Click(object sender, EventArgs e)
        {
            frmGrupoSolEvalCualitativa frm = new frmGrupoSolEvalCualitativa(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            frm.ShowDialog();
            frm.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //if (!NotificarPorSMSPaqueteSeguro())  --DESESTIMADO, DESCOMENTAR SI SE REQUIERE NOTIFICAR POR SMS
            //    return;

            clsCreditoProp obj = conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            //this.objCreditoProp.idMoneda = obj.idMoneda;
            //this.objCreditoProp.nMonto = Monto();
            this.objCreditoProp.nMonto = 0;
            this.objCreditoProp.nCuotas = obj.nCuotas;
            this.objCreditoProp.idTipoPeriodo = obj.idTipoPeriodo;
            this.objCreditoProp.nPlazoCuota = obj.nPlazoCuota;
            //this.objCreditoProp.nPlazo = obj.nPlazo;
            this.objCreditoProp.nDiasGracia = obj.nDiasGracia;
            this.objCreditoProp.nCuotasGracia = obj.nCuotasGracia;
            this.objCreditoProp.dFechaDesembolso = obj.dFechaDesembolso;
            //this.objCreditoProp.nTasaCompensatoria = obj.nTasaCompensatoria;
            this.objCreditoProp.idProducto = obj.idProducto;
            this.objCreditoProp.idTasa = obj.idTasa;

            string xmlEvalCredGrupoSol = EvalCredGrupoSolXML();
            string xmlSolCredIntegrante = EvalIntegrantesXML();

            DataTable dt = (new clsCNGrupoSolidario()).GuardarEvalCredGrupoSol(this.objEvalCredGrupoSol.idGrupoSolidario, xmlEvalCredGrupoSol, xmlSolCredIntegrante);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HabilitarFormulario(EventoFormulario.GRABAR);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.EDITAR);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.CANCELAR);

            int idGrupoSolidario = conBusGrupoSol1.idGrupoSolidario;

            if (idGrupoSolidario > 0)
            {
                ObtenerEvaluacion(idGrupoSolidario);
            }
            else
            {
                conBusGrupoSol1.LimpiarControl();
                conBusGrupoSol1.HabilitarBusqueda();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.NUEVO);
        }

        private void HabilitarFormulario(EventoFormulario eButton)
        {
            switch (eButton)
            {
                case EventoFormulario.NUEVO:
                    LimpiarFormulario();

                    this.tbcBase1.Enabled = false;

                    this.btnImprimirEvalCualit.Enabled = false;
                    this.btnImprimirEERR.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    this.btnEnviar.Enabled = false;
                    this.btnNuevo.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnObservacion.Enabled = false;
                    this.btnValidar.Enabled = false;

                    break;

                case EventoFormulario.EDITAR:
                    this.tbcBase1.Enabled = true;

                    //this.grbCondicionesCredito.Enabled = false;
                    this.grbBotonesEvaluacion.Enabled = true;
                    this.grbPropuesta.Enabled = true;

                    this.btnGrabar.Enabled = true;
                    this.btnCancelar.Enabled = true;
                    this.btnEditar.Enabled = false;

                    this.btnImprimirEvalCualit.Enabled = false;
                    this.btnImprimirEERR.Enabled = false;
                    this.btnExcepciones.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnObservacion.Enabled = true;

                    this.btnEditarCondCredito.Enabled = true;
                    this.btnValidar.Enabled = false;
                    break;

                case EventoFormulario.GRABAR:
                    this.tbcBase1.Enabled = true;

                    //this.grbCondicionesCredito.Enabled = false;
                    this.grbBotonesEvaluacion.Enabled = false;
                    this.grbPropuesta.Enabled = false;

                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;

                    this.btnGrabarCondCredito.Enabled = false;
                    this.btnCancelarCondCredito.Enabled = false;
                    this.btnEditarCondCredito.Enabled = false;

                    this.btnImprimirEvalCualit.Enabled = true;
                    this.btnImprimirEERR.Enabled = true;
                    this.btnExcepciones.Enabled = false;
                    this.btnEnviar.Enabled = true;
                    this.btnObservacion.Enabled = false;

                    this.dtgIntegrantes.ClearSelection();
                    this.btnValidar.Enabled = true;
                    break;

                case EventoFormulario.CANCELAR:
                    this.tbcBase1.Enabled = true;

                    //this.grbCondicionesCredito.Enabled = false;
                    this.grbBotonesEvaluacion.Enabled = false;
                    this.grbPropuesta.Enabled = false;

                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = true;

                    this.btnImprimirEvalCualit.Enabled = true;
                    this.btnImprimirEERR.Enabled = true;
                    this.btnExcepciones.Enabled = false;
                    this.btnEnviar.Enabled = true;
                    this.btnObservacion.Enabled = false;

                    this.btnGrabarCondCredito.Enabled = false;
                    this.btnCancelarCondCredito.Enabled = false;
                    this.btnEditarCondCredito.Enabled = false;

                    this.dtgIntegrantes.ClearSelection();
                    this.btnValidar.Enabled = true;
                    break;

                case EventoFormulario.ENVIAR:
                    //this.grbCondicionesCredito.Enabled = false;
                    this.grbBotonesEvaluacion.Enabled = false;
                    this.grbPropuesta.Enabled = false;

                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnEditar.Enabled = false;

                    this.btnImprimirEvalCualit.Enabled = true;
                    this.btnImprimirEERR.Enabled = true;
                    this.btnExcepciones.Enabled = false;
                    this.btnEnviar.Enabled = false;

                    this.btnGrabarCondCredito.Enabled = false;
                    this.btnCancelarCondCredito.Enabled = false;
                    this.btnEditarCondCredito.Enabled = false;

                    this.dtgIntegrantes.ClearSelection();
                    this.btnValidar.Enabled = false;
                    break;
            }
        }

        private void btnEditarCondCredito_Click(object sender, EventArgs e)
        {
            this.btnGrabarCondCredito.Enabled = true;
            this.btnCancelarCondCredito.Enabled = true;
            this.btnEditarCondCredito.Enabled = false;

            this.conCondiCreditoGrupoSol.Enabled = true;
            this.pnIntegrantes.Enabled = true;

            HabilitarBotones(false);
        }

        private void btnGrabarCondCredito_Click(object sender, EventArgs e)
        {
            this.btnGrabarCondCredito.Enabled = false;
            this.btnCancelarCondCredito.Enabled = false;
            this.btnEditarCondCredito.Enabled = true;

            this.conCondiCreditoGrupoSol.Enabled = false;
            this.pnIntegrantes.Enabled = false;

            HabilitarFormulario(EventoFormulario.EDITAR);
        }

        private void btnCancelarCondCredito_Click(object sender, EventArgs e)
        {
            this.btnGrabarCondCredito.Enabled = false;
            this.btnCancelarCondCredito.Enabled = false;
            this.btnEditarCondCredito.Enabled = true;

            this.conCondiCreditoGrupoSol.Enabled = false;
            this.pnIntegrantes.Enabled = false;

            HabilitarFormulario(EventoFormulario.EDITAR);
        }

        private void frmEvalGrupoSolidario_Shown(object sender, EventArgs e)
        {
            conBusGrupoSol1.txtIdGrupoSolidario.Focus();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            clsCreditoProp obj = conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            this.lValidacion = false;
            this.btnEnviar.Enabled = false;

            btnValidar.PerformClick();

            if (!this.lValidacion)
            {
                this.btnEnviar.Enabled = true;
                return;
            }

            this.lValidacion = false;
            this.validarReglas();
            if (!this.lValidacion)
            {
                this.btnEnviar.Enabled = true;
                return;
            }
            //this.btnEnviar.Enabled = false;
            clsCNGrupoSolidario objCNGrupoSol = new clsCNGrupoSolidario();
            string str = this.EvalIntegrantesXML();

            DataTable dtRes = objCNGrupoSol.EnviarEvalCredGSAApro(
                this.objEvalCredGrupoSol.idEvalCredGrupoSol,
                this.objEvalCredGrupoSol.idSolicitudCredGrupoSol,
                this.lstEvalCredIntegGrupoSol.GetXml(),
                clsVarGlobal.User.idUsuario,
                clsVarGlobal.dFecSystem
            );

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ENVIO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.HabilitarFormulario(EventoFormulario.ENVIAR);

                /*  Guardar Expedientes - Evaluacion GS  */
                clsProcesoExp.guardarCopiaExpediente("GS - Evaluacion de Credito", this.objEvalCredGrupoSol.idSolicitudCredGrupoSol, this, "grupal");
            }
            else
            {
                this.btnEnviar.Enabled = true;
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR DE ENVIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        private void btnImprimirEvalCualit_Click(object sender, EventArgs e)
        {
            if (this.objEvalCredGrupoSol == null) return;

            DataSet ds = (new clsCNGrupoSolidario()).ObtenerFichaEvalCualitativa(this.objEvalCredGrupoSol.idEvalCredGrupoSol);

            if (ds.Tables.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", ds.Tables[0]));
                dtsList.Add(new ReportDataSource("dsEvalCualita", ds.Tables[1]));
                dtsList.Add(new ReportDataSource("dsDescripcion", ds.Tables[2]));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", this.objEvalCredGrupoSol.idEvalCredGrupoSol.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
                //paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptEvalCualitativaGrupoSol.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            validarReglas();
        }

        private void tsmIntegrantes_Click(object sender, EventArgs e)
        {

            if (this.dtgIntegrantes.SelectedRows.Count <= 0) return;

            int nRowIndex = this.dtgIntegrantes.SelectedRows[0].Index;

            clsMsjError objError = conCondiCreditoGrupoSol.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show(objError.GetErrors(), "Solicitud creditos grupos solidarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal nMonto = Convert.ToDecimal(this.dtgIntegrantes.Rows[nRowIndex].Cells["nMonto"].Value);
            decimal nMontoMax = Convert.ToDecimal(this.dtgIntegrantes.Rows[nRowIndex].Cells["nMontoMax"].Value);

            //frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(nMonto, idDestino, cDestino, idActividad, idActividadInterna);
            clsEvalCredIntegGrupoSol objEdit = (clsEvalCredIntegGrupoSol) this.dtgIntegrantes.SelectedRows[0].DataBoundItem;
            frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(obtenerSolCreditoIndividual(objEdit), 2);
            objCondiCredInt.nMontoModificado = objEdit.nMonto;
            objCondiCredInt.nMontoMax = objEdit.nMontoMax;

            objCondiCredInt.ShowDialog();
             
            if (!objCondiCredInt.lAcepta)
                return;

            nMonto = objCondiCredInt.nMontoModificado;
            this.dtgIntegrantes.Rows[nRowIndex].Cells["nMonto"].Value = nMonto;  



            //this.objCreditoProp.nMonto = lstEvalCredIntegGrupoSol.Sum(x => x.nMonto);
            //this.objCreditoProp.nMontoMinimo = lstEvalCredIntegGrupoSol.Min(x => x.nMonto);
            //this.objCreditoProp.nMontoMaximo = lstEvalCredIntegGrupoSol.Max(x => x.nMonto);

            lstEvalCredIntegGrupoSol[nRowIndex].idTasa = objCondiCredInt.objCreditoProp.idTasa;
            lstEvalCredIntegGrupoSol[nRowIndex].nTEA = objCondiCredInt.objCreditoProp.nTasaCompensatoria;
            lstEvalCredIntegGrupoSol[nRowIndex].nTIM = objCondiCredInt.objCreditoProp.nTasaMoratoria;
            lstEvalCredIntegGrupoSol[nRowIndex].nTEM = objCondiCredInt.objCreditoProp.nTem;
            lstEvalCredIntegGrupoSol[nRowIndex].nMonto = objCondiCredInt.objCreditoProp.nMonto;
            lstEvalCredIntegGrupoSol[nRowIndex].nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
            lstEvalCredIntegGrupoSol[nRowIndex].nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;

            lstEvalCredIntegGrupoSol[nRowIndex].nMontoAmpliado = objCondiCredInt.objCreditoProp.nMonto - (objEdit.nSaldoCapital + objEdit.nIntMoraOtros);

            lstEvalCredIntegGrupoSol[nRowIndex].idPaqueteSeguro = objCondiCredInt.idPaqueteSeguro;

            this.dtgIntegrantes.Refresh();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            this.lValidacion = false;

            clsMsjError objMsjError = Validar();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.lValidacion = false;
            }
            else
            {
                MessageBox.Show("No se encontraron errores en la Evaluación.", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lValidacion = true;
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            frmVistaObsAproGrupoSol frmVistaObsAproSol = new frmVistaObsAproGrupoSol(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            frmVistaObsAproSol.ShowDialog();
        }

        private void conBusGrupoSol1_ClicBuscar(object sender, EventArgs e)
        {
            HabilitarFormulario(EventoFormulario.NUEVO);

            int idGrupoSolidario = conBusGrupoSol1.idGrupoSolidario;

            if (idGrupoSolidario > 0)
            {
                ObtenerEvaluacion(idGrupoSolidario);
            }
            else
            {
                conBusGrupoSol1.LimpiarControl();
                conBusGrupoSol1.HabilitarBusqueda();
                conBusGrupoSol1.Focus();
                conBusGrupoSol1.txtIdGrupoSolidario.Focus();
            }

            if (this.objEvalCredGrupoSol == null) return;

            this.btnImprimirEERR.Enabled = true;
            this.btnImprimirEvalCualit.Enabled = true;

            if (this.objEvalCredGrupoSol.lEditar == true)
            {
                this.btnEditar.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnValidar.Enabled = true;

                this.Text = "Grupo Solidario - Evaluación";
            }
            else
            {
                this.btnEditar.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnValidar.Enabled = false;

                this.Text = "Grupo Solidario - Evaluación (sólo lectura)";
            }
        }

        #endregion

        private void conCondiCreditoGrupoSol_ChangeCondiCredito(object sender, EventArgs e)
        {
            actualizarCondCredIntegrantes();
        }

        private void actualizarCondCredIntegrantes()
            {
            if (dtgIntegrantes.DataSource == null)
                return;

            int nRowIndex = -1;

            clsMsjError objError = conCondiCreditoGrupoSol.Validar();
            clsCreditoProp objProp = conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            if (objError.HasErrors)
            {
                MessageBox.Show(objError.GetErrors(), "Evaluación Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (clsEvalCredIntegGrupoSol objEvalCredIntegGrupoSol in lstEvalCredIntegGrupoSol)
            {
                frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(obtenerSolCreditoIndividual(objEvalCredIntegGrupoSol), 2);
                objCondiCredInt.CalcularCuotaAproxIntegrante(false);
                objEvalCredIntegGrupoSol.nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
                objEvalCredIntegGrupoSol.nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;
            }
            this.dtgIntegrantes.Refresh();
        }

        private clsCreditoProp obtenerSolCreditoIndividual(clsEvalCredIntegGrupoSol objEvalCredIntegGrupoSol)
        {
            clsEvalCredIntegGrupoSol obj = objEvalCredIntegGrupoSol;
            clsCreditoProp objObt = conCondiCreditoGrupoSol.ObtenerCondicionesCreditoGrupoSol(0);
            objObt.idOperacion = obj.idOperacion;
            objObt.idTasa = obj.idTasa;
            objObt.nTasaCompensatoria = obj.nTEA;
            objObt.nTasaMoratoria = obj.nTIM;
            objObt.idActividad = obj.idActividad;
            objObt.nMonto = obj.nMonto;
            objObt.cNombreGrupoSol = conBusGrupoSol1.cGrupoSolidario;
            objObt.cNombreCli = obj.cNombre;
            objObt.idCli = obj.idCli;
            objObt.idActividad = obj.idActividad;
            objObt.idActividadInterna = obj.idActividadInterna;
            objObt.idSolicitud = obj.idSolicitud;
            objObt.lConTasaNegociable = obj.lConTasaNegociable;
            objObt.idModalidadCredito = obj.idModalidadCredito;
            objObt.idClasificacionInterna = obj.idClasificacionInterna;
            objObt.idDetalleGasto = obj.idDetalleGasto;

            objObt.nMontoCancelacion = obj.nSaldoCapital + obj.nIntMoraOtros;
            objObt.nMontoAmpliar = obj.nMontoAmpliado;

            objObt.idPaqueteSeguro = obj.idPaqueteSeguro;

            return objObt;
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            if (this.objCreditoProp == null)
            {
                MessageBox.Show("No se ha encontrado una Solicitud de Crédito", "Carga de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (this.objCreditoProp.idSolicitudCredGrupoSol != 0)
            {
                frmExpedienteGrupoSolidario frmExpediente = new frmExpedienteGrupoSolidario();
                frmExpediente.idSolicitud = this.objCreditoProp.idSolicitudCredGrupoSol;
                frmExpediente.lEditar = this.objEvalCredGrupoSol.lEditar;
                frmExpediente.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha encontrado una Solicitud de Crédito", "Carga de Expediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string cMsjCaption = "Expediente Grupo Solidario";
            if (this.objEvalCredGrupoSol == null)
            {
                MessageBox.Show("No se ha seleccionado un Grupo Solidario", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.objEvalCredGrupoSol.idSolicitudCredGrupoSol == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.objEvalCredGrupoSol.idGrupoSolidario == 0)
            {
                MessageBox.Show("No se ha ingresado el Grupo Solidario", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCredGrupoSol.idSolicitudCredGrupoSol, this.objEvalCredGrupoSol.idGrupoSolidario, "grupal");
            frmExpLinea.ShowDialog();
        }

        private bool NotificarPorSMSPaqueteSeguro()
        {
            if (lstEvalCredIntegGrupoSol.All(x => x.idPaqueteSeguro == -1))
                return true;

            var listaPaquetesSeleccionados = lstEvalCredIntegGrupoSol.Where(x => x.idPaqueteSeguro != -1).ToList();

            clsCNPaqueteSeguro cnPaqueteSeguro = new clsCNPaqueteSeguro();
            clsCNCliente cnCliente = new clsCNCliente();
            clsServicioSMS cnServicioSMS = new clsServicioSMS();
            var listaPaquetesSeguro = cnPaqueteSeguro.CNListarTodosLosPaqueteDeSeguro();
            var clsListaPaquetesSeguro = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(listaPaquetesSeguro) as List<clsMantenimientoPaqueteSeguro>;

            var listaTelefonos = new List<clsRegistroTelefono>();

            foreach (var item in listaPaquetesSeleccionados)
            {
                var dtTelefonos = (DataTableToList.ConvertTo<clsRegistroTelefono>(new clsCNCliente().CNDevuelveTelefonosActivosCliente(item.idCli)) as List<clsRegistroTelefono>).FirstOrDefault();
                if (dtTelefonos == null || string.IsNullOrEmpty(dtTelefonos.cNumeroTelefonico))
                {
                    MessageBox.Show("El cliente " + item.cNombre + " no tiene registrado su número de teléfono. No se puede enviar el mensaje de texto. Actualice y vuelva a intentar", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                listaTelefonos.Add(dtTelefonos);
            }

            foreach (var item in listaPaquetesSeleccionados)
            {
                clsMantenimientoPaqueteSeguro objpaquete = clsListaPaquetesSeguro.Where(x => x.idPaqueteSeguro == item.idPaqueteSeguro).FirstOrDefault();
                string cTelefono = listaTelefonos.Where(x => x.idCli == item.idCli).FirstOrDefault().cNumeroTelefonico;
                clsSmsRequest requestSMS = new clsSmsRequest
                {
                    phone = cTelefono,
                    content = "Caja Los Andes informa que se ha adquirido el plan de seguros " + objpaquete.cNombreCompleto + " en etapa de evaluación, el cual podrá consultar en el siguiente enlace: " + objpaquete.cLink 
                };
                clsSmsResponse responseSMS = cnServicioSMS.EnviarSMS(requestSMS);
                cnServicioSMS.GuardarTramaSMS(requestSMS, responseSMS, item.idCli);
            }

            MessageBox.Show("Se ha enviado los SMS a los clientes con algún plan de seguro seleccionado", TITULO_FORM, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        #endregion
    }
}
