using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmEvalAgricolaMEC : frmBase
    {
        private FrmBuscarEv formBuscarEv;

        private clsCNEvalAgrico objCNEvalAgrico;
        private clsEvalCred objEvalCred;
        private CRE.CapaNegocio.clsCNCredito objCNCredito = new CRE.CapaNegocio.clsCNCredito();
        private clsCreditoProp objSolicitud;
        private clsPropCredito objPropCredito = null;
        clsActividadEconomica objActPrincipal = new clsActividadEconomica();
        clsActividadEconomica objActSecundaria = new clsActividadEconomica();

        private List<clsEvalCualitativa> lstEvalCualitativa;
        private List<clsReferenciaEval> lstReferencia;
        private List<clsBalGenEval> lstBalGenEval;
        private List<clsEstResEval> lstEstResEval;
        private List<clsIndicadorEval> lstIndiFinanc;
        private List<clsDestCredProp> lstDestCredProp;
        private List<clsElemEvalCred> lstElemEvalCred;
        private List<clsDescripcionEval> lstDescripcionEval;
        private List<clsDetBalGenEval> lstInventario;

        private DataTable dtTipMoneda;
        private DataTable dtTipPeriodo;
        private DataTable dtSectorEconomico;
        private DataTable dtTipReferEval;
        private DataTable dtTipVinculoEval;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private DateTime dFechaBase;

        private clsCNEstadosFinancieros objEstadosFinancieros;

        private bool lBalanceGeneral;
        private int idCanal;

        private const int nAnioMinimo = 2000;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private List<clsEvaluacionCultivoAgrico> lstEvaluacionCultivosAgrico;

        private string cMsjCaption = "Evaluación de Crédito MEC Agrícola";

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        public int nPlazoPropuestoMeses
        {
            get {
                return this.conCondiCredito.Plazo();
            }
        }

        public decimal nCuotaAproximada
        {
            get
            {
                return this.conCondiCredito.CuotaAprox();
            }
        }


        public frmEvalAgricolaMEC()
        {
            InitializeComponent();

            this.objCNEvalAgrico = new clsCNEvalAgrico();
            this.objEstadosFinancieros = new clsCNEstadosFinancieros();
            this.tabEval.Enabled = false;

            iniciarFormulario();
            HabilitarBotones(false);

            this.btnBusqueda.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.lBalanceGeneral = false;
            this.conCondiCredito.lMostrarBtnPropDesembolsos = false;
        }

        #region métodos privados
        private void iniciarFormulario()
        {
            DataSet dsResult = this.objCNEvalAgrico.InicializarAgrico();

            this.dtTipMoneda = dsResult.Tables[0];
            this.dtTipPeriodo = dsResult.Tables[1];
            this.dtSectorEconomico = dsResult.Tables[2];
            this.dtTipReferEval = dsResult.Tables[3];
            this.dtTipVinculoEval = dsResult.Tables[4];

            Evaluacion.DataTableMoneda = this.dtTipMoneda;

            var dtTipoFrecuencia = new DataTable();
            dtTipoFrecuencia.Columns.Add("idFrecuencia", typeof(int));
            dtTipoFrecuencia.Columns.Add("cFrecuencia", typeof(string));
            dtTipoFrecuencia.Columns.Add("cAbreviatura", typeof(string));
            dtTipoFrecuencia.Rows.Add(1, "MENSUAL", "MEN");
            dtTipoFrecuencia.Rows.Add(2, "BIMENSUAL", "BIM");
            dtTipoFrecuencia.Rows.Add(3, "TRIMESTRAL", "TRI");
            dtTipoFrecuencia.Rows.Add(4, "CUATRIMESTRAL", "CUA");
            dtTipoFrecuencia.Rows.Add(5, "QUIMESTRAL", "QUI");
            dtTipoFrecuencia.Rows.Add(6, "SEMESTRAL", "SEM");
            dtTipoFrecuencia.Rows.Add(12, "ANUAL", "ANU");
            Evaluacion.DataTipoFrecuencia = dtTipoFrecuencia;


        }

        private void cargarFormulario(int idEvalCred, int idAccion, string cDocumento, string cNombre)
        {
            this.quitarEventos();
            this.obtenerDatos(idEvalCred);
            this.asignarCamposFormulario(cDocumento, cNombre);
            this.configurarObjetoEvaluacion();

            if (idAccion == 0)
                idAccion = this.objEvalCred.lEditar == true ? clsAcciones.BUSCAR : clsAcciones.ENVIAR;

            if (idAccion == clsAcciones.BUSCAR || idAccion == clsAcciones.NUEVO)
            {
                this.tituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
                HabilitarBotonesSegunModo(idAccion);
            }
            else if (idAccion == clsAcciones.ENVIAR)
            {
                this.tituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                HabilitarBotonesSegunModo(idAccion);
            }

            this.agregarEventos();
        }

        private void actualizarEstadosFinancieros()
        {
            string xmlBalGenEval = this.xmlBalGenEval();
            string xmlEstResEval = this.xmlEstResEval();

            DataTable td = this.objCNEvalAgrico.ActEstFinancieroslEval(this.objEvalCred.idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        private string xmlEvalCred()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idUsuMod", typeof(int));

            dt.Columns.Add("nCapitalPropuesto", typeof(decimal));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nCuotas", typeof(int));
            dt.Columns.Add("idTipoPeriodo", typeof(int));
            dt.Columns.Add("nPlazoCuota", typeof(int));
            dt.Columns.Add("nDiasGracia", typeof(int));
            dt.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dt.Columns.Add("idTasa", typeof(int));
            dt.Columns.Add("nTEA", typeof(decimal));
            dt.Columns.Add("nTEM", typeof(decimal));
            dt.Columns.Add("nCuotaAprox", typeof(decimal));
            dt.Columns.Add("dFecUltimaEval", typeof(DateTime));
            dt.Columns.Add("dFecActualEval", typeof(DateTime));
            dt.Columns.Add("nCajaInicial", typeof(decimal));
            dt.Columns.Add("idActividad", typeof(int));
            dt.Columns.Add("idSectorEcon", typeof(int));
            dt.Columns.Add("lActSecundaria", typeof(bool));
            dt.Columns.Add("idActividadInternaPri", typeof(int));
            dt.Columns.Add("idTipoActividadPri", typeof(int));
            dt.Columns.Add("nActPriAnios", typeof(int));
            dt.Columns.Add("cActPriDireccion", typeof(string));
            dt.Columns.Add("cActPriReferencia", typeof(string));
            dt.Columns.Add("cActPriDescripcion", typeof(string));
            dt.Columns.Add("idActividadInternaSec", typeof(int));
            dt.Columns.Add("idTipoActividadSec", typeof(int));
            dt.Columns.Add("nActSecAnios", typeof(int));
            dt.Columns.Add("cActSecDireccion", typeof(string));
            dt.Columns.Add("cActSecReferencia", typeof(string));
            dt.Columns.Add("cActSecDescripcion", typeof(string));
            dt.Columns.Add("cComEntFamiliar", typeof(string));
            dt.Columns.Add("cComDestCredito", typeof(string));
            dt.Columns.Add("cComAnteCred", typeof(string));
            dt.Columns.Add("cComAnalisisFinan", typeof(string));
            dt.Columns.Add("cComGarantias", typeof(string));
            dt.Columns.Add("cComConclusiones", typeof(string));
            dt.Columns.Add("lExpuestoRcc", typeof(bool));
            dt.Columns.Add("nTotalPasivoAC", typeof(decimal));

            dt.Columns.Add("nPlazo", typeof(int));
            dt.Columns.Add("nCuotasGracia", typeof(int));
            dt.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dt.Columns.Add("cCalendarioPagos", typeof(string));
            dt.Columns.Add("nTotalMontoPagar", typeof(decimal));
            dt.Columns.Add("nActivoAdquirir", typeof(decimal));
            dt.Columns.Add("nSaldoAcumuladoInicial", typeof(decimal));
            dt.Columns.Add("nDisponibleInicial", typeof(decimal));
            dt.Columns.Add("nSaldoAcumuladoFinal", typeof(decimal));

            dt.Columns.Add("idCultivoEval", typeof(int));
            dt.Columns.Add("idVariedadCultivoEval", typeof(int));

            DataRow row = dt.NewRow();

            row["idEvalCred"] = this.objEvalCred.idEvalCred;
            row["idUsuMod"] = clsVarGlobal.User.idUsuario;

            row["nCapitalPropuesto"] = this.objEvalCred.nCapitalPropuesto;
            row["idMoneda"] = this.objEvalCred.idMoneda;
            row["nCuotas"] = this.objEvalCred.nCuotas;
            row["idTipoPeriodo"] = this.objEvalCred.idTipoPeriodo;
            row["nPlazoCuota"] = this.objEvalCred.nPlazoCuota;
            row["nDiasGracia"] = this.objEvalCred.nDiasGracia;
            row["dFechaDesembolso"] = this.objEvalCred.dFechaDesembolso;
            row["idTasa"] = this.objEvalCred.idTasa;
            row["nTEA"] = this.objEvalCred.nTEA;
            row["nTEM"] = clsMathFinanciera.TEM(Convert.ToDouble(this.objEvalCred.nTEA));
            row["nCuotaAprox"] = this.objEvalCred.nCuotaAprox;
            row["dFecUltimaEval"] = this.objEvalCred.dFecUltimaEval;    //validr
            row["dFecActualEval"] = this.objEvalCred.dFecActualEval;
            row["nCajaInicial"] = this.objEvalCred.nCajaInicial;
            row["idActividad"] = this.objEvalCred.idActividad;
            row["idSectorEcon"] = this.objEvalCred.idSectorEcon;
            row["lActSecundaria"] = this.objEvalCred.lActSecundaria;
            row["idActividadInternaPri"] = this.objEvalCred.idActividadInternaPri;
            row["idTipoActividadPri"] = this.objEvalCred.idTipoActividadPri;
            row["nActPriAnios"] = this.objEvalCred.nActPriAnios;
            row["cActPriDireccion"] = this.objEvalCred.cActPriDireccion;
            row["cActPriReferencia"] = this.objEvalCred.cActPriReferencia;
            row["cActPriDescripcion"] = this.objEvalCred.cActPriDescripcion;
            row["idActividadInternaSec"] = this.objEvalCred.idActividadInternaSec;
            row["idTipoActividadSec"] = this.objEvalCred.idTipoActividadSec;
            row["nActSecAnios"] = this.objEvalCred.nActSecAnios;
            row["cActSecDireccion"] = this.objEvalCred.cActSecDireccion;
            row["cActSecReferencia"] = this.objEvalCred.cActSecReferencia;
            row["cActSecDescripcion"] = this.objEvalCred.cActSecDescripcion;
            row["cComEntFamiliar"] = this.objEvalCred.cComEntFamiliar;
            row["cComDestCredito"] = this.objEvalCred.cComDestCredito;
            row["cComAnteCred"] = this.objEvalCred.cComAnteCred;
            row["cComAnalisisFinan"] = this.objEvalCred.cComAnalisisFinan;
            row["cComGarantias"] = this.objEvalCred.cComGarantias;
            row["cComConclusiones"] = this.objEvalCred.cComConclusiones;
            row["lExpuestoRcc"] = this.objEvalCred.lExpuestoRcc;
            row["nTotalPasivoAC"] = this.objEvalCred.nTotalPasivoAC;
            row["nPlazo"] = this.objEvalCred.nPlazo;
            row["nCuotasGracia"] = this.objEvalCred.nCuotasGracia;
            row["nCuotaGraciaAprox"] = this.objEvalCred.nCuotaGraciaAprox;
            row["cCalendarioPagos"] = this.objEvalCred.cCalendarioPagos;
            row["nTotalMontoPagar"] = this.objEvalCred.nTotalMontoPagar;
            row["nActivoAdquirir"] = this.objEvalCred.nActivoAdquirir;
            row["nSaldoAcumuladoInicial"] = this.objEvalCred.nSaldoAcumuladoInicial;
            row["nDisponibleInicial"] = this.objEvalCred.nDisponibleInicial;
            row["nSaldoAcumuladoFinal"] = this.objEvalCred.nSaldoAcumuladoFinal;
            row["idCultivoEval"] = this.objEvalCred.idCultivoEval;
            row["idVariedadCultivoEval"] = this.objEvalCred.idVariedadCultivoEval;

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private string xmlEvalCualitativaCred()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCualitativa", typeof(int));
            dt.Columns.Add("idItemCualit", typeof(int));
            dt.Columns.Add("nPuntaje", typeof(decimal));
            dt.Columns.Add("nComputado", typeof(decimal));
            dt.Columns.Add("lAutomatico", typeof(bool));

            foreach (clsEvalCualitativa ev in this.lstEvalCualitativa)
            {
                dt.Rows.Add(
                    ev.idEvalCualitativa,
                    ev.idItemCualit,
                    Convert.ToDecimal(ev.oPuntaje),
                    ev.nComputado,
                    ev.lAutomatico
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCualitativa", "Item");
        }

        private string xmlBalGenEval()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idBalGenEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));

            foreach (clsBalGenEval bg in lstBalGenEval)
            {
                dt.Rows.Add(
                    bg.idBalGenEval,
                    bg.nTotalUltEvMA,
                    bg.nTotalMA,
                    bg.nAnalisisVerti,
                    bg.nAnalisisHoriz
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "BalGenEval", "Item");
        }

        private string xmlEstResEval()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEstResEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));
            dt.Columns.Add("nTotalMN", typeof(decimal));
            dt.Columns.Add("nTotalME", typeof(decimal));

            foreach (clsEstResEval er in lstEstResEval)
            {
                dt.Rows.Add(
                    er.idEstResEval,
                    er.nTotalUltEvMA,
                    er.nTotalMA,
                    er.nAnalisisVerti,
                    er.nAnalisisHoriz,
                    er.nTotalMN,
                    er.nTotalME
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "EstResEval", "Item");
        }

        private string xmlDestCredProp()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idDestCredProp", typeof(int));
            dt.Columns.Add("idTipDestCred", typeof(int));
            dt.Columns.Add("idDetalle", typeof(int));
            dt.Columns.Add("nPorcentaje", typeof(decimal));
            dt.Columns.Add("nMonto", typeof(decimal));

            foreach (clsDestCredProp dc in this.lstDestCredProp)
            {
                dc.nMontoProp = this.objEvalCred.nCapitalPropuesto;
                dt.Rows.Add(
                    dc.idDestCredProp,
                    dc.idTipDestCred,
                    dc.idDetalle,
                    dc.nPorcentaje,
                    dc.nMonto
                );
            }
            return clsUtils.ConvertToXML(dt.Copy(), "DestCredProp", "Item");
        }

        private string xmlReferencias()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReferenciaEval", typeof(int));
            dt.Columns.Add("idTipReferEval", typeof(int));
            dt.Columns.Add("idTipVinculoEval", typeof(int));
            dt.Columns.Add("cConcepto", typeof(string));
            dt.Columns.Add("cDireccion", typeof(string));
            dt.Columns.Add("cNumeroCelular", typeof(string));
            dt.Columns.Add("nEstado", typeof(byte));
            dt.Columns.Add("cComentarios", typeof(string));

            foreach (clsReferenciaEval rc in this.lstReferencia)
            {
                dt.Rows.Add(
                    rc.idReferenciaEval,
                    rc.idTipReferEval,
                    rc.idTipVinculoEval,
                    rc.cConcepto,
                    rc.cDireccion,
                    rc.cNumeroCelular,
                    rc.nEstado,
                    rc.cComentarios
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "ReferenciaEval", "Item");
        }

        private string xmlIndicadores()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idIndicadorEval", typeof(int));
            dt.Columns.Add("nRatio", typeof(decimal));

            foreach (clsIndicadorEval rc in this.lstIndiFinanc)
            {
                dt.Rows.Add(rc.idIndicadorEval, rc.nRatio);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "IndicadorEval", "Item");
        }

        private string xmlDetalleEstRes()
        {
            List<clsDetEstResEval> lstDetalleEstRes = new List<clsDetEstResEval>();
            lstDetalleEstRes.AddRange(this.objEstadosFinancieros.listGFamiliares);
            lstDetalleEstRes.AddRange(this.objEstadosFinancieros.listGOperativos);
            lstDetalleEstRes.AddRange(this.objEstadosFinancieros.listOtrosEgresos);
            lstDetalleEstRes.AddRange(this.objEstadosFinancieros.listOtrosIngresos);

            DataTable dt = new DataTable();
            dt.Columns.Add("idDetEstResEval", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));

            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));

            foreach (var detEstRes in lstDetalleEstRes)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
                row["idEEFF"] = detEstRes.idEEFF;
                row["cDescripcion"] = detEstRes.cDescripcion;
                row["idDescripcion"] = detEstRes.idDescripcion;
                row["idMoneda"] = detEstRes.idMoneda;
                row["idUnidMedida"] = detEstRes.idUnidMedida;
                row["nCantidad"] = detEstRes.nCantidad;
                row["nPUnitario"] = detEstRes.nPUnitario;
                row["nTotal"] = detEstRes.nTotal;
                row["idMonedaMA"] = detEstRes.idMonedaMA;
                row["nTotalMA"] = detEstRes.nTotalMA;

                row["nFrecuencia"] = detEstRes.nFrecuencia;
                row["dMesVenta"] = detEstRes.dMesVenta;
                row["nMesVenta"] = detEstRes.nMesVenta;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
        }

        private void HabilitarPaginas(bool lHabilitado)
        {
            this.conEvalCualitReferencias.Enabled = lHabilitado;
            this.conCondiCredito.Enabled = (this.objEvalCred.idSolicitud > 0) ? lHabilitado : false;
            this.conPropuesta.Enabled = lHabilitado;
        }

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;

            this.btnChecklist.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;

            this.btnBusqueda.Enabled = lHabilitado;
            this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;

        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado; 
            if (nModo == clsAcciones.EDITAR)
            { 
                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnImprimirFlujoCaja.Enabled = false;
                this.btnEnviar.Enabled = false;

                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;

                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;
                this.grbCultivos.Enabled = true;
                this.btnHabilitarSeguro.Enabled = true;

                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = true;

                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = false;

                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = true;
                this.grbCultivos.Enabled = false;
                this.btnHabilitarSeguro.Enabled = false;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.ENVIAR)
            {
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = lHabilitado;

                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;
                this.grbCultivos.Enabled = false;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnObservacion1.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = true;

                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;

                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;
                this.grbCultivos.Enabled = false;

                this.btnEditar.Focus();

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnObservacion1.Enabled = false;
                this.tabEval.Enabled = true;

                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnImprimirFlujoCaja.Enabled = false;
                this.btnEnviar.Enabled = false;

                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;

                this.btnBusqueda.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.grbCultivos.Enabled = true;
                this.btnHabilitarSeguro.Enabled = true;

                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnImprimirFlujoCaja.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;

                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;
                this.grbCultivos.Enabled = false;

                HabilitarPaginas(false);
            }
            this.conEstadosFinancieros.lEditable = !this.btnEditar.Enabled;
        }

        private void asignarCamposFormulario(string cDocumento, string cNombre)
        {
            this.txtNroDoc.Text = cDocumento;
            this.txtNombre.Text = cNombre;

            this.txtIdEvalCred.Text = String.Format("{0:d8}", this.objEvalCred.idEvalCred);
            this.txtIdSolicitud.Text = (this.objEvalCred.idSolicitud != 0) ? String.Format("{0:d8}", this.objEvalCred.idSolicitud) : "";
            this.txtModCredito.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cModalidadCredito : "";
            this.txtOperacion.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cOperacion : "";
            this.txtTipoCambio.Text = (this.objEvalCred.nTipoCambio != 0) ? this.objEvalCred.nTipoCambio.ToString("") : "";
        }

        private void quitarEventos()
        {
            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.CuotaAproximadaChanged -= new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged -= new System.EventHandler(this.conCondiCredito_PlazoChanged);
        }

        private void agregarEventos()
        {
            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.CuotaAproximadaChanged += new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged += new System.EventHandler(this.conCondiCredito_PlazoChanged);
        }

        private void obtenerDatos(int idEvalCred)
        {
            DataSet dsResult = this.objCNEvalAgrico.BuscarEvalCredito(idEvalCred);
            this.cargarEvaluacion(dsResult);
            this.cargarSolicitud(dsResult);
            this.cargarEvaluacionCualitativaReferencias(dsResult);
            this.cargarEEFF(dsResult);
            this.cargarDetalleEEFF(idEvalCred);
            this.cargarDestinoCredito(dsResult);
            this.cargarActividadesEconomicas();
            this.cargarCondicionesCredito();
            this.cargarPropuestaCredito();
            this.cargarOtrosElementosEvaluacion(dsResult);
        }

        private void cargarEvaluacion(DataSet ds)
        {
            List<clsEvalCred> lstEvalCred = DataTableToList.ConvertTo<clsEvalCred>(ds.Tables[0]) as List<clsEvalCred>;
            this.objEvalCred = lstEvalCred[0];
            this.objEvalCred.idEstablecimiento = (this.objEvalCred.idEstablecimiento == 0) ? clsVarGlobal.User.idEstablecimiento : this.objEvalCred.idEstablecimiento;
            this.objEvalCred.idTipoEstablec = (this.objEvalCred.idTipoEstablec == 0) ? clsVarGlobal.User.idTipoEstablec : this.objEvalCred.idTipoEstablec;
            cboCultivoEval1.SelectedValue = objEvalCred.idCultivoEval;
            cboVariedadCultivoEval1.CargaVariedadPorCultivo(objEvalCred.idCultivoEval);
            cboVariedadCultivoEval1.SelectedValue = objEvalCred.idVariedadCultivoEval;
        }

        private void cargarSolicitud(DataSet ds)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                List<clsCreditoProp>  lstSolicitud = DataTableToList.ConvertTo<clsCreditoProp>(ds.Tables[1]) as List<clsCreditoProp>;
                if (lstSolicitud.Count == 1)
                {
                    this.objSolicitud = lstSolicitud[0];
                     this.objSolicitud.idClasificacionInterna = this.objEvalCred.idClasificacionInterna;
                    //btnAdministradorFiles1.idSolicitud = this.objSolicitud.idSolicitud;
                    //btnAdministradorFiles1.actualizarDatos();
                    //btnAdministradorFiles1.Enabled = true;

                    btnVincularVisita1.idSolicitud = this.objSolicitud.idSolicitud;
                    btnVincularVisita1.idCli = this.objEvalCred.idCli;
                }
                else
                {
                    MessageBox.Show("La solicitud Nº " + this.objEvalCred.idSolicitud + " no se puede recuperar.",
                        "Recuperando Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                this.objSolicitud = new clsCreditoProp();
            }
        }

        private void cargarEvaluacionCualitativaReferencias(DataSet ds)
        {
            this.lstEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[2]) as List<clsEvalCualitativa>;            
            this.lstReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(ds.Tables[3]) as List<clsReferenciaEval>;

            this.conEvalCualitReferencias.Visible = false;
            this.conEvalCualitReferencias.AsignarDatos(this.lstEvalCualitativa, this.lstReferencia, this.dtTipReferEval, this.dtTipVinculoEval);
            this.conEvalCualitReferencias.Visible = true;
        }

        private void cargarEEFF(DataSet ds)
        {            
            this.lstBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(ds.Tables[4]) as List<clsBalGenEval>;
            this.lstEstResEval = DataTableToList.ConvertTo<clsEstResEval>(ds.Tables[5]) as List<clsEstResEval>;
            this.lstIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(ds.Tables[6]) as List<clsIndicadorEval>;

            decimal nTotalMontoPagar = this.conCondiCredito.TotalMontoPagar();
            decimal nCapitalParacomercio = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.Caja).Sum(x => x.nTotalMA);

            this.conEstadosFinancieros.asignarDatos(this.lstBalGenEval, this.lstEstResEval, this.lstIndiFinanc, this.lstInventario, this.objEvalCred);
        }

        private void cargarDetalleEEFF(int idEvalCred)
        {
            DataSet ds = (new clsCNEvaluacion()).RecuperarDetalleGeneralEstResultadosEval(idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listVentasCostos = DataTableToList.ConvertTo<clsVentasCostos>(ds.Tables[1]) as List<clsVentasCostos>;
            var listCosteoEval = DataTableToList.ConvertTo<clsCosteo>(ds.Tables[2]) as List<clsCosteo>;
            var listVarFlujoCaja = DataTableToList.ConvertTo<clsVarFlujoCajaEval>(ds.Tables[3]) as List<clsVarFlujoCajaEval>;
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[4]) as List<clsDeudasEval>;
            var listDeudaCuotaPago = DataTableToList.ConvertTo<clsCuotaPago>(ds.Tables[5]) as List<clsCuotaPago>;

            #region Detalle de los Estado Resultados
            var listGFamiliares = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosFamiliares
                                   select p).ToList();

            var listGOperativos = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosOperativos
                                   select p).ToList();

            var listOtrosIngresos = (from p in listDetEstResEval
                                     where p.idEEFF == EEFF.OtrosIngresos
                                     select p).ToList();

            var listOtrosEgresos = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.OtrosEgresos
                                    select p).ToList();
            #endregion

            #region Detalle de las ventas y costos
            // Se asigna sus costeos a sus ventas
            foreach (clsVentasCostos oVnCostos in listVentasCostos)
            {
                oVnCostos.listCosteo = (from p in listCosteoEval
                                        where p.idVentasCostos == oVnCostos.idVentasCostos
                                        select p).ToList();
            }
            #endregion

            #region Deudas con entidades financieras
            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();

            // se asigna sus cronograma de pagos a las deudas que tiene
            foreach (clsDeudasEval oDeudasEval in listSalRCCDirectos)
            {
                var listDCPago = (from p in listDeudaCuotaPago
                                  where p.idDeudasEval == oDeudasEval.idDeudasEval
                                  select p).ToList();

                oDeudasEval.listCuotaPago = (listDCPago.Count > 0) ? listDCPago : new List<clsCuotaPago>();
            }
            #endregion

            this.objEstadosFinancieros.listVentasCostos = listVentasCostos;
            this.objEstadosFinancieros.listGFamiliares = listGFamiliares;
            this.objEstadosFinancieros.listGOperativos = listGOperativos;
            this.objEstadosFinancieros.listOtrosEgresos = listOtrosEgresos;
            this.objEstadosFinancieros.listOtrosIngresos = listOtrosIngresos;
            this.objEstadosFinancieros.listCredDirectos = listSalRCCDirectos;
            this.objEstadosFinancieros.listCredIndirect = listSalRCCDIndirec;
        }

        private void cargarDestinoCredito(DataSet ds)
        {
            //-- Table[7] : Lista de Destino de Crédito
            this.dtTipDestCred = ds.Tables[7];

            //-- Table[8] : Lista del Detalle de los Destinos de Crédito
            this.dtTipDestCredDetalle = ds.Tables[8];

            //-- Table[9] : Destinos de Crédito Propuesto
            this.lstDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(ds.Tables[9]) as List<clsDestCredProp>;
        }

        private void cargarActividadesEconomicas()
        {
            objActPrincipal.idTipoActividad = (this.objEvalCred.idTipoActividadPri == 0) ? TipoActividad.Independiente : this.objEvalCred.idTipoActividadPri;
            objActPrincipal.idActividadInterna = this.objEvalCred.idActividadInternaPri;
            objActPrincipal.nAnios = this.objEvalCred.nActPriAnios;
            objActPrincipal.cDireccion = this.objEvalCred.cActPriDireccion;
            objActPrincipal.cReferencia = this.objEvalCred.cActPriReferencia;
            objActPrincipal.cDescripcion = this.objEvalCred.cActPriDescripcion;

            objActSecundaria.idTipoActividad = (this.objEvalCred.idTipoActividadSec == 0) ? TipoActividad.Independiente : this.objEvalCred.idTipoActividadSec;
            objActSecundaria.idActividadInterna = this.objEvalCred.idActividadInternaSec;
            objActSecundaria.nAnios = this.objEvalCred.nActSecAnios;
            objActSecundaria.cDireccion = this.objEvalCred.cActSecDireccion;
            objActSecundaria.cReferencia = this.objEvalCred.cActSecReferencia;
            objActSecundaria.cDescripcion = this.objEvalCred.cActSecDescripcion;
        }

        private void cargarPropuestaCredito()
        {
            this.objPropCredito = new clsPropCredito();
            this.objPropCredito.lActSecundaria = this.objEvalCred.lActSecundaria;
            this.objPropCredito.oActPrincipal = objActPrincipal;
            this.objPropCredito.oActSecundaria = objActSecundaria;
            this.objPropCredito.cComEntFamiliar = this.objEvalCred.cComEntFamiliar;
            this.objPropCredito.cComDestCredito = this.objEvalCred.cComDestCredito;
            this.objPropCredito.cComAnteCred = this.objEvalCred.cComAnteCred;
            this.objPropCredito.cComAnalisisFinan = this.objEvalCred.cComAnalisisFinan;
            this.objPropCredito.cComGarantias = this.objEvalCred.cComGarantias;
            this.objPropCredito.cComConclusiones = this.objEvalCred.cComConclusiones;

            this.conPropuesta.AsignarDatos(this.objPropCredito);
        }

        private void cargarCondicionesCredito()
        {
            this.conCondiCredito.AsignarDataTable(this.dtTipMoneda, this.dtTipPeriodo, this.dtTipDestCred, this.dtTipDestCredDetalle, this.dtSectorEconomico);
            this.conCondiCredito.AsignarDatos(this.objEvalCred, this.objSolicitud, this.lstDestCredProp, this.lstBalGenEval, this.lstEstResEval);

            int nPlazo = this.conCondiCredito.Plazo();
            this.objEstadosFinancieros.actualizarPlazoAgricolaMEC(nPlazo, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, this.objEvalCred.idTipEvalCred);
            this.conEstadosFinancieros.CreditoPropuesto = this.conCondiCredito.ObtenerCreditoPropuesto();
        }

        private void cargarOtrosElementosEvaluacion(DataSet ds)
        {
            //-- Table[10] : Lista de Elementos(controles) NO habilitados
            this.lstElemEvalCred = DataTableToList.ConvertTo<clsElemEvalCred>(ds.Tables[10]) as List<clsElemEvalCred>;

            //-- Table[11] : Lista Tipos de descripciones
            this.lstDescripcionEval = DataTableToList.ConvertTo<clsDescripcionEval>(ds.Tables[11]) as List<clsDescripcionEval>;

            //-- Table[12] : Lista de Inventario
            this.lstInventario = DataTableToList.ConvertTo<clsDetBalGenEval>(ds.Tables[12]) as List<clsDetBalGenEval>;
        }

        private void configurarObjetoEvaluacion()
        {
            var aMoneda = (from p in Evaluacion.DataTableMoneda.AsEnumerable()
                           where p.Field<int>("idMoneda") == this.objEvalCred.idMoneda
                           select new
                           {
                               cSimbolo = p.Field<string>("cSimbolo"),
                               idMoneda = p.Field<int>("idMoneda")
                           }).ToList().FirstOrDefault();

            if (aMoneda == null)
            {
                Evaluacion.idMoneda = 1;
                Evaluacion.MonedaSimbolo = "S/.";
            }
            else
            {
                Evaluacion.TipoCambio = this.objEvalCred.nTipoCambio;
                Evaluacion.idMoneda = this.objEvalCred.idMoneda;
                Evaluacion.MonedaSimbolo = aMoneda.cSimbolo;
            }

            Evaluacion.CapitalTrabajo = Convert.ToInt32(clsVarApl.dicVarGen["nIDCapitalTrabajo"]);
            Evaluacion.FechaActualEval = this.objEvalCred.dFecActualEval;

            if (((DateTime)(this.objEvalCred.dFecUltimaEval)).Year < nAnioMinimo) Evaluacion.FechaUltimaEval = null;
            else Evaluacion.FechaUltimaEval = this.objEvalCred.dFecUltimaEval;

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);

            Evaluacion.listMesFechasEval = null;
            Evaluacion.listMesFechasEval = new List<clsMesFechasEval>();

            DateTime dFecha;
            for (int i = 1; i < 480; i++)     //40 años por 12 meses
            {
                dFecha = this.dFechaBase.AddMonths(i);
                Evaluacion.listMesFechasEval.Add(new clsMesFechasEval()
                {
                    nMes = i,
                    dFecha = dFecha,
                    cFechaCorto = dFecha.ToString("MMM/yy").ToUpper(),
                    cFechaLargo = dFecha.ToString("MMMM/yy").ToUpper()
                });
            }

            this.lBalanceGeneral = true;

            conCondiCredito_CuotaAproximadaChanged(null, null);
        }

        private void recalcularEEFF(int nPlazoMeses)
        {
            this.objEstadosFinancieros.actualizarPlazoAgricolaMEC(nPlazoMeses, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, this.objEvalCred.idTipEvalCred);

            this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosFinancieros).nTotalMA = this.objEstadosFinancieros.TotalGFinancierosAnualizadoMA();
            this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosFamiliares).nTotalMA = this.objEstadosFinancieros.nTotalPlazoGastosFamiliaresMA();
            this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosOperativos).nTotalMA = this.objEstadosFinancieros.nTotalPlazoGastosOperativosMA();
            this.lstEstResEval.Find(x => x.idEEFF == EEFF.OtrosEgresos).nTotalMA = this.objEstadosFinancieros.nTotalPlazoOtrosEgresosMA();
            this.lstEstResEval.Find(x => x.idEEFF == EEFF.OtrosIngresos).nTotalMA = this.objEstadosFinancieros.nTotalPlazoOtrosIngresosMA();

            this.conEstadosFinancieros._lstEstResEval = this.lstEstResEval;
            this.lstEstResEval = this.conEstadosFinancieros._lstEstResEval;

            this.actualizarEstadosFinancieros();
        }

        private bool evaluarReglaIIFF(string cRegla, int nValor)
        {
            DataTable dt = new DataTable();
            string cReglaReemplazada = cRegla.Replace("x", nValor.ToString());
            cReglaReemplazada = cReglaReemplazada.Replace("TEA", objEvalCred.nTEA.ToString());

            bool lResultado = (bool)dt.Compute(cReglaReemplazada, "");

            return lResultado;
        }

        private clsMsjError validarEvaluacion()
        {
            clsMsjError objMsjError = new clsMsjError();

            #region evaluación cualitativa y referencias
            int nTotalPuntaje = Convert.ToInt32(this.conEvalCualitReferencias.TotalPuntaje());
            if (nTotalPuntaje < 30)
            {
                objMsjError.AddError("Puntaje Mínimo:  El puntaje mínimo de la evaluación cualitativa es 30.");
            }

            if (this.lstReferencia.Count < Evaluacion.MinReferencias)
                objMsjError.AddError("Cualit./Refer.: Se requiere un mínimo de dos referencias.");

            if (this.lstReferencia.Count > 0)
            {
                int nRefNegativas = (from p in this.lstReferencia where p.nEstado == 2 select p).ToList().Count;

                if (nRefNegativas > 0)
                    objMsjError.AddError("Cualit./Refer.: Tiene registros con ref. negativas.");
            }
            #endregion

            #region BBGG
            decimal nTotalActivo = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
            decimal nTotalPrestamos = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosCP).Sum(x => x.nTotalMA)
                + this.lstBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosLP).Sum(x => x.nTotalMA);

            if (this.lBalanceGeneral)
            {
                if (nTotalActivo == 0)
                    objMsjError.AddError("Estados Financ.: Total Activo es CERO.");

                if (nTotalPrestamos < this.objEvalCred.nTotalDeudas)
                    objMsjError.AddError("Estados Financ.: Actualice las Deudas con Entidades Financieras.");

            }
            #endregion

            #region IIFF
            foreach (clsIndicadorEval oIndFinac in this.lstIndiFinanc)
            {
                if (oIndFinac.nRatio < 0)
                {
                    if (!objSolicitud.idOperacion.In(2, 6))
                    {
                        objMsjError.AddError("Estados Financ.: Los indicadores Financ. están en NEGATIVO.");
                    }
                    break;
                }
            }

            decimal nEndeudamiento = this.lstIndiFinanc.Where(x => x.nCodigo == 3).Sum(x => x.nRatio);
            nEndeudamiento = Math.Round(nEndeudamiento * 100, 2);
            int nOperacion = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.idOperacion : 0;

            if (nEndeudamiento > 80 && ((nOperacion != 2) && (nOperacion != 6)))
            {
                objMsjError.AddError("Endeudamiento:  El Indicador endeudamiento total proyectado debe ser menor o igual al 80%.");
            }

            int nIndicadorValor = 0;
            string cRegla = string.Empty;

            foreach (clsIndicadorEval objIndFin in this.lstIndiFinanc)
            {
                if (objIndFin.nCodigo.In(6))
                {
                    if (objIndFin.nTipoVariable == 2)
                    {
                        nIndicadorValor = (int)(objIndFin.nRatio * 100);
                    }
                    else
                    {
                        nIndicadorValor = (int)objIndFin.nRatio;
                    }

                    cRegla = objIndFin.cDescRegla;

                    if (!this.evaluarReglaIIFF(cRegla, nIndicadorValor))
                    {
                        objMsjError.AddError(string.Concat("El indicador financiero [", objIndFin.cDescripcion, "] no cumple con la regla [", objIndFin.cDescRegla, "]."));
                    }
                }
            }
            #endregion

            #region Condiciones del Crédito
            decimal nPorcentaje = this.lstDestCredProp.Sum(x => x.nPorcentaje);

            var objCondiCreditoMsjError = this.conCondiCredito.Validar();
            if (objCondiCreditoMsjError.HasErrors)
            {
                foreach (var err in objCondiCreditoMsjError.GetListError())
                    objMsjError.AddError("Cond. Crédito: " + err);
            }

            if (nPorcentaje < 1)
                objMsjError.AddError("Cond. Crédito: Total % de Destinos del Crédito es MENOR al 100%.");

            if (nPorcentaje > 1)
                objMsjError.AddError("Cond. Crédito: Total % de Destinos del Crédito es MAYOR al 100%.");
            #endregion

            #region Propuesta de Crédito
            var objPropuestaMsjError = this.conPropuesta.Validar();
            if (objPropuestaMsjError.HasErrors)
            {
                foreach (var err in objPropuestaMsjError.GetListError())
                    objMsjError.AddError("Prop. Crédito: " + err);
            }
            #endregion

            #region activo fijo
            decimal nPorcentajeActivoAdquirir = 0;
            decimal nMontoActivoFijo = 0;
            decimal nValorActivoAdquirir = 0;

            nPorcentajeActivoAdquirir = Convert.ToDecimal(clsVarApl.dicVarGen["nPorcentajeActivoAdquirir"]);
            nValorActivoAdquirir = conCondiCredito.ObtenerActivoAdquirir();
            nMontoActivoFijo = lstDestCredProp.Where(p => p.nCodigo == 2).Sum(p => p.nMonto); //Activo Fijo: nCodigo = 2

            if ((nValorActivoAdquirir * nPorcentajeActivoAdquirir) < nMontoActivoFijo)
            {
                objMsjError.AddError("Activo Fijo: Sólo podemos financiar el 80% de un activo fijo.");
            }
            #endregion

            #region cultivo
            if (cboCultivoEval1.SelectedIndex < 0)
            {
                objMsjError.AddError("Cultivo: Seleccione el cultivo");
            }

            if (cboVariedadCultivoEval1.SelectedIndex < 0)
            {
                objMsjError.AddError("Cultivo: Seleccione la variedad del cultivo");
            }
            #endregion

            #region riesgos
            DataTable dtOpRiesgos = objCNEvalAgrico.CNValidarVisitas(this.objEvalCred.idEvalCred);
            string cMsj2 = dtOpRiesgos.Rows[0]["cMensaje"].ToString();
            int idMsj2 = Convert.ToInt32(dtOpRiesgos.Rows[0]["cNroMsj"]);

            if (idMsj2 == 3)
            {
                objMsjError.AddError(cMsj2);
            }
            #endregion

            #region carga de Archivos
            //if (!btnAdministradorFiles1.obligatoriosCompletos())
            //{
            //    objMsjError.AddError(btnAdministradorFiles1.msgObligatorios);
            //}

            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(this.objEvalCred.idSolicitud);
            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
            {
                objMsjError.AddError(dtCargaArchivos.Rows[0]["cMsg"].ToString());
            }
            #endregion

            return objMsjError;
        }

        private DataTable dtParametrosEvaluacion()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.objEvalCred.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = this.objEvalCred.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEvalCred";
            drfila[1] = this.objEvalCred.idEvalCred;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = this.objSolicitud.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = this.objSolicitud.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = this.conCondiCredito.PlazoTotal();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = this.conCondiCredito.Monto();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool excepcionesPendientes(bool lSilencioso)
        {
            clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();

            int nIdSolicitud = Convert.ToInt32(this.objEvalCred.idSolicitud);
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            int nIdCliente = Convert.ToInt32(this.objEvalCred.idCli);
            int nIdMoneda = Convert.ToInt32(this.objEvalCred.idMoneda);
            int nIdProducto = Convert.ToInt32(this.objEvalCred.idProducto);
            decimal nValAproba = Convert.ToDecimal(oEvalCredTemp.nMonto);
            int nIdUsuRegist = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            String cOpcion = this.Name;
            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, this.Name, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }

        private bool validarReglas(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = dtParametrosEvaluacion();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(
                dtTablaParametros: dtParametros,
                cNombreFormulario: this.Name,
                idAgencia: clsVarGlobal.nIdAgencia,
                idCliente: this.objEvalCred.idCli,
                idEstadoOperac: 1,
                idMoneda: this.objEvalCred.idMoneda,
                idProducto: this.objEvalCred.idProducto,
                nValAproba: this.objEvalCred.nCapitalPropuesto,
                idDocument: this.objEvalCred.idSolicitud,
                dFecSolici: clsVarGlobal.dFecSystem,
                idMotivo: 2,
                idEstadoSol: 13,
                idUsuRegist: clsVarGlobal.User.idUsuario,
                idSolApr: ref nNivAuto, lMostrarAlerta: lMostrarAlerta,
                idRegistroExcep: this.objSolicitud.idSolicitud
            );

            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            else if (cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {

                return !this.excepcionesPendientes(false);
            }
            else
            {
                return false;
            }

        }

        private void denegarSolicitudCredDesfavorable()
        {
            clsRespuestaServidor objRespuestaServidor = (new clsCNAlertaVariable()).denegarSolicitudCredDesfavorable(this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool alertaVariable()
        {
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = this.conEstadosFinancieros.lstAlertaVariable(
                this.objEvalCred.idSolicitud,
                this.objEvalCred.idSectorEcon,
                this.objEvalCred.nCapitalPropuesto,
                this.nCuotaAproximada,
                this.objSolicitud.idDestino
            );

            clsCNAlertaVariable objCNAlertaVariable = new clsCNAlertaVariable();
            List<clsEvalCredAlertaVariable> lstEvalCredAlertaAnterior = objCNAlertaVariable.listarEvalCredAlertaVariable(this.objEvalCred.idEvalCred);
            lstEvalCredAlertaAnterior = lstEvalCredAlertaAnterior.Where(x => x.idClaseAnalisis != 6).ToList();

            if (lstEvalCredAlertaAnterior.Count > 0)
            {
               foreach (clsEvalCredAlertaVariable alertaEvaluacion in lstEvalCredAlerta)
                {
                    foreach (clsEvalCredAlertaVariable alertaBD in lstEvalCredAlertaAnterior)
                    {
                        if (alertaEvaluacion.idAlertaVariable == alertaBD.idAlertaVariable && alertaEvaluacion.cValor == alertaBD.cValor)
                        {
                            alertaEvaluacion.cAlertaVariable = alertaBD.cAlertaVariable;
                            alertaEvaluacion.cClaseAnalisis = alertaBD.cClaseAnalisis;
                            alertaEvaluacion.cIdsPerfil = alertaBD.cIdsPerfil;
                            alertaEvaluacion.cIdsSectorEcon = alertaBD.cIdsSectorEcon;
                            alertaEvaluacion.cSustento = alertaBD.cSustento;
                            alertaEvaluacion.cTipoAnalisis = alertaBD.cTipoAnalisis;
                            alertaEvaluacion.cValor = alertaBD.cValor;
                            alertaEvaluacion.idAlertaVariable = alertaBD.idAlertaVariable;
                            alertaEvaluacion.idClaseAnalisis = alertaBD.idClaseAnalisis;
                            alertaEvaluacion.idEvalCred = alertaBD.idEvalCred;
                            alertaEvaluacion.idEvalCredAlertaVariable = alertaBD.idEvalCredAlertaVariable;
                            alertaEvaluacion.idFuncionDinamica = alertaBD.idFuncionDinamica;
                            alertaEvaluacion.idSolicitud = alertaBD.idSolicitud;
                            alertaEvaluacion.idTipoAnalisis = alertaBD.idTipoAnalisis;
                            alertaEvaluacion.idTipoResolucion = alertaBD.idTipoResolucion;
                            alertaEvaluacion.idTipoResolucionRecd = alertaBD.idTipoResolucionRecd;
                            alertaEvaluacion.idUsuResolucion = alertaBD.idUsuResolucion;
                            alertaEvaluacion.lReqVistoBueno = alertaBD.lReqVistoBueno;
                            alertaEvaluacion.cComenRevision = alertaBD.cComenRevision;
                        }
                    }
                }
            }
            
            if (lstEvalCredAlerta.Count == 0 && lstEvalCredAlertaAnterior.Count > 0)
            {
                lstEvalCredAlerta = new List<clsEvalCredAlertaVariable>(lstEvalCredAlertaAnterior);
                foreach (clsEvalCredAlertaVariable alertaEvaluacion in lstEvalCredAlerta)
                {
                    alertaEvaluacion.lVigente = false;
                }
            }
            else
            {
                lstEvalCredAlerta.AddRange(this.objCNEvalAgrico.lstAlertaCultivo(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario));
            }

            DataTable dtAplicabilidad = objCNAlertaVariable.aplicabilidadEvalCredAlertaVar(this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred);

            if (dtAplicabilidad.Rows.Count == 0)
            {
                MessageBox.Show("¡No se pudo validar la aplicabilidad de las alertas de evaluación de crédito!\n\n"
                    + "* No se permitirá enviar la propuesta a la etapa de aprobación sin esta validación.",
                    "VALIDACION REQUERIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (dtAplicabilidad.Rows[0].Field<bool>("lAplicarAlertas"))
            {
                frmEvalCredAlertaVariable objFrmEvalCredAlertaVariable = new frmEvalCredAlertaVariable(lstEvalCredAlerta, this.objEvalCred.idSolicitud);
                objFrmEvalCredAlertaVariable.grabarEvalCredAlertaVariable();
                if (objFrmEvalCredAlertaVariable.nRecdDesfavorable > 0)
                {
                    MessageBox.Show("¡La propuesta de crédito actual tiene " +
                        objFrmEvalCredAlertaVariable.nRecdDesfavorable + " reconsideración(es) de visto(s) bueno(s) desfavorable(s)!\n\n" +
                        "**El crédito será denegado automáticamente.",
                        "DENEGADO AUTOMATICO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.denegarSolicitudCredDesfavorable();
                    return false;
                }
                else if (objFrmEvalCredAlertaVariable.nDesfavorable > 0)
                {
                    DialogResult idResultado = MessageBox.Show("¡La propuesta de crédito actual tiene " +
                        objFrmEvalCredAlertaVariable.nDesfavorable + " visto(s) bueno(s) desfavorable(s)!\n\n" +
                            "¿Desea detener el proceso para solicitar una reconsideración de visto bueno?\n" +
                            "Seleccione la opción 'SI' para solicitar una reconsideración de visto bueno.\n" +
                            "Seleccione la opción 'NO' para denegar el crédito.",
                            "CONFIRMACION DE DENEGADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (idResultado != DialogResult.Yes)
                    {
                        DialogResult idReconfirmacion = MessageBox.Show("¡El crédito será denegado!\n\n" +
                        "¿Está seguro de DENEGAR el crédito?",
                        "RECONFIRMACION DE DENEGADO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (idReconfirmacion == DialogResult.Yes)
                        {
                            this.denegarSolicitudCredDesfavorable();
                        }
                    }
                    return false;
                }
                else if (objFrmEvalCredAlertaVariable.nSinResolucion > 0)
                {
                    MessageBox.Show(string.Concat("¡Se ha(n) encontrado ", objFrmEvalCredAlertaVariable.nSinResolucion, " alerta(s) sin Visto Bueno!\n\n" +
                            "*Para la atención de las alertas de evaluación debe comunicarse con el responsable de Visto Bueno asignado a su Oficina o Región.",
                            "**Todas las alertas deben tener Visto Bueno Favorable  para continuar con el envío."),
                        "ALERTAS SIN VISTO BUENO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }

                return objFrmEvalCredAlertaVariable.lGrabado;
            }
            else if (dtAplicabilidad.Rows[0].Field<bool>("lGrabAlertNoAplicadas"))
            {
                clsRespuestaServidor objRespuestaServidor = objCNAlertaVariable.grabarEvalCredAlertaVariable(lstEvalCredAlerta, false);
                if (objRespuestaServidor.idResultado == ResultadoServidor.Error)
                {
                    MessageBox.Show("¡Ha ocurrido un error al intentar grabar alertas de evaluación no aplicadas!",
                        "ERROR DE GRABADO DE ALERTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }

            return true;
        }

        private void tituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación MEC Agrícola ({0})", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación MEC Agrícola ({0}) - {1}", cTipEvalCred, cMensaje);
        }

        private void recuperarEvalCredito()
        {
            DataSet ds = this.objCNEvalAgrico.RecuperarEvalCredito(this.objEvalCred.idEvalCred);

            //-- Table[0] : Evaluacion Cualitativa
            this.lstEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[0]) as List<clsEvalCualitativa>;

            //-- Table[1] : Referencias del Cliente
            this.lstReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(ds.Tables[1]) as List<clsReferenciaEval>;

            //-- Table[2] : Destinos de Crédito Propuesto
            this.lstDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(ds.Tables[2]) as List<clsDestCredProp>;

            //-- Actualizar Datos
            this.conEvalCualitReferencias.ActualizarDatos(this.lstEvalCualitativa, this.lstReferencia);
            this.conCondiCredito.ActualizarDatos(this.objEvalCred.nCapitalPropuesto, this.lstDestCredProp);
        }
        #endregion

        private void CargarConfiguracionSeguro(int nMuestraFrm)
        {
            clsCreditoProp objDatos = new clsCreditoProp();
            objDatos        = conCondiCredito.ObtenerCreditoPropuesto();
            int idSolicitud = this.objEvalCred.idSolicitud;
            int nParam      = 1;

            if (objDatos.nPlazoCuota == 0)
            {
                MessageBox.Show("Debe seleccionar frecuencia.", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            objSolicitudCreditoSeguroActual = (objSolicitudCreditoSeguroActual.idSolicitud == 0) ? objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud) : objSolicitudCreditoSeguroActual;
            objSolicitudCreditoSeguroActual.idProducto        = objDatos.idProducto;
            objSolicitudCreditoSeguroActual.nMontoSolicitado  = objDatos.nMonto;
            objSolicitudCreditoSeguroActual.nCuotas           = objDatos.nCuotas;
            objSolicitudCreditoSeguroActual.idTipoPlazo       = objDatos.idTipoPeriodo;
            objSolicitudCreditoSeguroActual.nPlazo            = objDatos.nPlazoCuota;
            objSolicitudCreditoSeguroActual.idMoneda          = objDatos.idMoneda;
            objSolicitudCreditoSeguroActual.cMoneda           = objDatos.cMoneda;
            objSolicitudCreditoSeguroActual.dFechaDesembolso  = objDatos.dFechaDesembolso;
            objSolicitudCreditoSeguroActual.dFechaCancelacion = clsVarGlobal.dFecSystem;
            objSolicitudCreditoSeguroActual.nDiasGracia       = objDatos.nDiasGracia;
            objSolicitudCreditoSeguroActual.nCuotaGracia      = objDatos.nCuotasGracia;
            objSolicitudCreditoSeguroActual.lPlanSeguroBD     = objSolicitudCreditoSeguroActual.idPaqueteSeguro > 0 ? true : false;

            frmSolicitudCreditoCargaSeguro frmCreditoCargaSeguro = new frmSolicitudCreditoCargaSeguro(objSolicitudCreditoSeguroActual, nParam);

            if (nMuestraFrm == 1)
            {
                frmCreditoCargaSeguro.ShowDialog();
            }
            else if (nMuestraFrm == 0)
            {
                //frmCreditoCargaSeguro.Visible = false;
                //frmCreditoCargaSeguro.FormBorderStyle = FormBorderStyle.None;
                //frmCreditoCargaSeguro.Show();
                //frmCreditoCargaSeguro.Close();
                frmCreditoCargaSeguro.EnvioDatos();
            }

            //objSolicitudCreditoSeguroActual = frmCreditoCargaSeguro.objSolicitudCreditoCargaSeguro;
            
            if (objSolicitudCreditoSeguroActual.nEstado == 1)
            {
                if ((objSolicitudCreditoSeguroActual.lAceptacionListaSeguro) || objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
                {
                    string xmlSolicitudCreditoSeguro = objSolicitudCreditoSeguroActual.GetXml();

                    DataTable dtResultadoSeguro = new clsCNCreditoCargaSeguro().CNRegistrarSolicitudCreditoSeguro(this.objEvalCred.idSolicitud, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                    if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 0 || Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == -1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 1)
                    {
                        MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        #region eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
            {
                MessageBox.Show("No se ha seleccionado la evaluación", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCred.idSolicitud, this.objEvalCred.idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void btnImprimirFlujoCaja_Click(object sender, EventArgs e)
        {
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            #region validar datos de la evaluacion
            clsMsjError objMsjError = validarEvaluacion();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();
                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("La evaluación aún no esta vinculada.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            if (!validarReglas(true)) return;

            if (this.excepcionesPendientes(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones a reglas de negocios.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a comité de Créditos?",
                "Enviar a Comité de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                if (!this.alertaVariable()) return;
                clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();

                // ------------------------------------------------------------------------
                int idCanalAproCredTemp = 0;
                int lCanalAproCredEditable = 0;

                DataTable dt = this.objCNCredito.DeterminarCanalAprobacion(this.objEvalCred.idEstablecimiento,
                    this.objEvalCred.idTipoEstablec,
                    this.objEvalCred.idSolicitud,
                    this.objEvalCred.idCli,
                    (oEvalCredTemp.idMoneda == 1) ? oEvalCredTemp.nMonto : oEvalCredTemp.nMonto * this.objEvalCred.nTipoCambio,
                    oEvalCredTemp.idProducto,
                    this.objSolicitud.idOperacion
                );

                if (dt.Rows.Count > 0)
                {
                    idCanalAproCredTemp = Convert.ToInt32(dt.Rows[0]["idCanalAproCred"]);
                    idCanal = idCanalAproCredTemp;

                    if (idCanalAproCredTemp <= 0)
                    {
                        MessageBox.Show(dt.Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    lCanalAproCredEditable = Convert.ToInt32(dt.Rows[0]["lCanalAproCredEditable"]);

                    if (lCanalAproCredEditable == 1)    // Se puede cambiar el canal de otorgamiento
                    {
                        if (idCanalAproCredTemp == Convert.ToInt32(clsVarApl.dicVarGen["idCanalAproCredA"]))
                        {
                            idCanal = idCanalAproCredTemp;
                        }
                        else if (idCanalAproCredTemp == Convert.ToInt32(clsVarApl.dicVarGen["idCanalAproCredB"]))
                        {
                            frmCanalResolucionCreditos frmCanalResolCred = new frmCanalResolucionCreditos();
                            frmCanalResolCred.ShowDialog();
                            idCanalAproCredTemp = frmCanalResolCred.idCanalAproCred;

                            if (idCanalAproCredTemp > 0)
                                idCanal = idCanalAproCredTemp;
                            else
                            {
                                MessageBox.Show("No se seleccionó ningún canal de aprobación de créditos, por lo tanto se cancelará el envío a comité de créditos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                /*  Guardar Expedientes - Evaluacion de Credito  */
                bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                if (!lRespuesta)
                {
                    return;
                }
                // -------------------------------------------------------------------------

                oEvalCredTemp.idOrigenCredProp = 2;
                oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                oEvalCredTemp.nActivo = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPasivo = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nInventario = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPatrimonio = this.lstBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                oEvalCredTemp.nCostos = this.lstEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDeudas = this.lstEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                oEvalCredTemp.nNeto = this.lstEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDisponible = this.lstEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                string xmlDestCredProp = oEvalCredTemp.GetXml();

                DataTable dtEnvCom = objCNEvalAgrico.EnviarAComiteCreditos(this.objEvalCred.idEvalCred,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    xmlDestCredProp,
                    idCanal,
                    lCanalAproCredEditable
                );

                string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                if (idMsj == 1)
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                    this.objEvalCred.lEstado = false;
                    this.tituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                }
                else
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objEvalCred.idSolicitud, !this.objEvalCred.lEditar);
                frmCargaArchivo.ShowDialog();
            }
        }

        private void btnAdministradorFiles1_Click(object sender, EventArgs e)
        {
        }

        private void btnVincularVisita1_Click(object sender, EventArgs e)
        {
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            this.validarReglas(false);
            this.excepcionesPendientes(false);
        }

        private void btnObservacion1_Click(object sender, EventArgs e)
        {
            if (this.objSolicitud == null)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", "Solicitud Vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmVistaObservacionesApro frmVistaObsAproSol = new frmVistaObservacionesApro(this.objSolicitud.idSolicitud);
            frmVistaObsAproSol.ShowDialog();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            clsMsjError objMsjError = validarEvaluacion();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("No se encontraron errores en la Evaluación.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada a esta evaluación", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmListaDocObligatoriosCre frmListaDocObligatoriosCre = new frmListaDocObligatoriosCre(
                this.objEvalCred.idTipoPersona, this.objEvalCred.idProducto, this.objEvalCred.idSolicitud);

            frmListaDocObligatoriosCre.ShowDialog();
            frmListaDocObligatoriosCre.Dispose();
        }

        private void btnCopiado_Click(object sender, EventArgs e)
        {
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCred = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredMECAgricola"]);

            this.formBuscarEv = new FrmBuscarEv(cIDsTipEvalCred, "Buscar Evaluaciones MEC Agrícola");
            formBuscarEv.ShowDialog();

            if (formBuscarEv.idCli != 0 && formBuscarEv.idEvalCred != 0)
            {
                (new clsCNSolicitud()).actualizarMontosSolRefi(formBuscarEv.idSolicitud);
                this.cargarFormulario(formBuscarEv.idEvalCred, 0, formBuscarEv.cNroDocumento, formBuscarEv.cNombreCliente);
            }

            formBuscarEv.Close();
            formBuscarEv.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCred = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredMECAgricola"]);
            string cIDsSectorEcon = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconAgrico"]);

            frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDsTipEvalCred, cIDsSectorEcon, 0, "Nueva Evaluación MEC Agrícola", false);
            nuevaEv.ShowDialog();

            if (nuevaEv.idCli != 0 && nuevaEv.idEvalCred != 0)
            {
                this.cargarFormulario(nuevaEv.idEvalCred, clsAcciones.NUEVO, nuevaEv.cNroDocumento, nuevaEv.cNombreCliente);
            }

            nuevaEv.Close();
            nuevaEv.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();

            this.objEvalCred.nCapitalPropuesto = oEvalCredTemp.nCapitalPropuesto;
            this.objEvalCred.nCuotas = oEvalCredTemp.nCuotas;
            this.objEvalCred.idTipoPeriodo = oEvalCredTemp.idTipoPeriodo;
            this.objEvalCred.nPlazoCuota = oEvalCredTemp.nPlazoCuota;
            this.objEvalCred.nDiasGracia = oEvalCredTemp.nDiasGracia;
            this.objEvalCred.dFechaDesembolso = oEvalCredTemp.dFechaDesembolso;
            this.objEvalCred.nTEA = oEvalCredTemp.nTEA;
            this.objEvalCred.idTasa = oEvalCredTemp.idTasa;
            this.objEvalCred.nCuotaAprox = oEvalCredTemp.nCuotaAprox;
            this.objEvalCred.nCuotasGracia = oEvalCredTemp.nCuotasGracia;
            this.objEvalCred.nPlazo = oEvalCredTemp.nPlazo;
            this.objEvalCred.nCuotaAprox = oEvalCredTemp.nCuotaAprox;
            this.objEvalCred.nCuotaGraciaAprox = oEvalCredTemp.nCuotaGraciaAprox;
            this.objEvalCred.cCalendarioPagos = oEvalCredTemp.cCalendarioPagos;
            this.objEvalCred.nTotalMontoPagar = oEvalCredTemp.nTotalMontoPagar;

            this.objEvalCred.idActividadInternaPri = oEvalCredTemp.idActividadInternaPri;
            this.objEvalCred.idActividad = oEvalCredTemp.idActividad;
            this.objEvalCred.idSectorEcon = oEvalCredTemp.idSectorEcon;
            this.objEvalCred.nActivoAdquirir = oEvalCredTemp.nActivoAdquirir;

            // Recuperar información de la propuesta de crédito
            clsPropCredito objPropCredito = this.conPropuesta.ObtenerDatos();
            clsActividadEconomica oActPrin = objPropCredito.oActPrincipal;
            clsActividadEconomica oActSecu = objPropCredito.oActSecundaria;

            this.objEvalCred.lActSecundaria = objPropCredito.lActSecundaria;

            this.objEvalCred.idActividadInternaPri = oActPrin.idActividadInterna;
            this.objEvalCred.idTipoActividadPri = oActPrin.idTipoActividad;
            this.objEvalCred.nActPriAnios = oActPrin.nAnios;
            this.objEvalCred.cActPriDireccion = oActPrin.cDireccion;
            this.objEvalCred.cActPriReferencia = oActPrin.cReferencia;
            this.objEvalCred.cActPriDescripcion = oActPrin.cDescripcion;

            if (this.objEvalCred.lActSecundaria == false)
                oActSecu = new clsActividadEconomica();

            this.objEvalCred.idActividadInternaSec = oActSecu.idActividadInterna;
            this.objEvalCred.idTipoActividadSec = oActSecu.idTipoActividad;
            this.objEvalCred.nActSecAnios = oActSecu.nAnios;
            this.objEvalCred.cActSecDireccion = oActSecu.cDireccion;
            this.objEvalCred.cActSecReferencia = oActSecu.cReferencia;
            this.objEvalCred.cActSecDescripcion = oActSecu.cDescripcion;

            this.objEvalCred.cComEntFamiliar = objPropCredito.cComEntFamiliar;
            this.objEvalCred.cComDestCredito = objPropCredito.cComDestCredito;
            this.objEvalCred.cComAnteCred = objPropCredito.cComAnteCred;
            this.objEvalCred.cComAnalisisFinan = objPropCredito.cComAnalisisFinan;
            this.objEvalCred.cComGarantias = objPropCredito.cComGarantias;
            this.objEvalCred.cComConclusiones = objPropCredito.cComConclusiones;
            this.objEvalCred.idCultivoEval = Convert.ToInt32(cboCultivoEval1.SelectedValue);
            this.objEvalCred.idVariedadCultivoEval = Convert.ToInt32(cboVariedadCultivoEval1.SelectedValue);

            string xmlEvalCred = this.xmlEvalCred();
            string xmlEvalCualit = this.xmlEvalCualitativaCred();
            string xmlReferencias = this.xmlReferencias();
            string xmlBalGenEval = this.xmlBalGenEval();
            string xmlEstResEval = this.xmlEstResEval();
            string xmlDestCredProp = this.xmlDestCredProp();
            string xmlDetEstResEval = this.xmlDetalleEstRes();
            string xmlIndicadorEval = xmlIndicadores();

            int nMuestraFrm = 0;
            CargarConfiguracionSeguro(nMuestraFrm);

            DataTable td = this.objCNEvalAgrico.ActualizarEval(this.objEvalCred.idEvalCred,
                        xmlEvalCred,
                        xmlEvalCualit,
                        xmlReferencias,
                        xmlBalGenEval,
                        xmlEstResEval,
                        xmlDestCredProp,
                        xmlDetEstResEval,
                        xmlIndicadorEval
            );

            if (td.Rows.Count > 0)
            {
                DataRow drResult = td.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(drResult["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.recuperarEvalCredito();
                    HabilitarBotonesSegunModo(clsAcciones.GRABAR);
                }
            }

            this.validarReglas(false);
        }
        #endregion

        #region eventos - evaluación cualitativa y referencias
        private void conEvalCualitReferencias_EvalCualitativaCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
        #endregion

        #region eventos - EEFF
        private void conEstadosFinancieros_DeudasClick(object sender, EventArgs e)
        {
            FrmDeudasFinanc frmdeudasFinanc = new FrmDeudasFinanc(
                this.objEvalCred.idEvalCred, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, Evaluacion.MonedaSimbolo
            );
            frmdeudasFinanc.ShowDialog();

            if (frmdeudasFinanc.lGuardado)
            {
                this.objEstadosFinancieros.listCredDirectos = frmdeudasFinanc.CredDirectos();
                this.objEstadosFinancieros.listCredIndirect = frmdeudasFinanc.CredIndirect();

                this.objEvalCred.nTotalDeudas = this.objEstadosFinancieros.CDirectosTotalSaldoMA();
                this.objEvalCred.nTotalPasivoAC = this.objEstadosFinancieros.TotalPasivoAC();

                foreach (clsBalGenEval item in this.lstBalGenEval)
                {
                    if (item.idEEFF == EEFF.PrestamosCP)
                        item.nTotalMA = this.objEstadosFinancieros.CDirectosTotalSaldoCortoPlazoMA();
                    else if (item.idEEFF == EEFF.PrestamosLP)
                        item.nTotalMA = this.objEstadosFinancieros.CDirectosTotalSaldoLargoPlazoMA() + this.objEstadosFinancieros.ProvicionCIndirectosMA();
                }
                this.conEstadosFinancieros._lstBalGenEval = this.lstBalGenEval;
                this.lstBalGenEval = this.conEstadosFinancieros._lstBalGenEval;

                this.lstEstResEval.Find(x => x.idEEFF == EEFF.GastosFinancieros).nTotalMA = this.objEstadosFinancieros.TotalGFinancierosAnualizadoMA();
                this.conEstadosFinancieros._lstEstResEval = this.lstEstResEval;
                this.lstEstResEval = this.conEstadosFinancieros._lstEstResEval;

                this.actualizarEstadosFinancieros();
            }

            frmdeudasFinanc.Dispose();
        }

        private void conEstadosFinancieros_ActividadAgricolaClick(object sender, EventArgs e)
        {
            frmDetalleActividadAgricola frmDetalleActividadAgricola = new frmDetalleActividadAgricola(objEvalCred, true);
            frmDetalleActividadAgricola.ShowDialog();
            this.lstEvaluacionCultivosAgrico = frmDetalleActividadAgricola.getEvaluacionCultivosAgrico();

            decimal nVentasNetas = this.lstEvaluacionCultivosAgrico.Sum(obj => obj.nMontoIngresos);

            this.lstEstResEval.Find(x => x.idEEFF == EEFF.VentasNetas).nTotalMA = nVentasNetas;
            this.lstEstResEval.Find(x => x.idEEFF == EEFF.CostoVentas).nTotalMA = this.lstEvaluacionCultivosAgrico.Sum(obj => obj.nMontoEgresos);

            foreach (clsEstResEval item in this.lstEstResEval)
            {
                item.nVentasNetas = nVentasNetas;
            }

            this.conEstadosFinancieros._lstEstResEval = this.lstEstResEval;
            this.lstEstResEval = this.conEstadosFinancieros._lstEstResEval;

            this.actualizarEstadosFinancieros();
        }

        private void conEstadosFinancieros_BBGGClick(object sender, EventArgs e)
        {
            frmDetalleBalGenAgricola frmDetalleBalGenAgricola = new frmDetalleBalGenAgricola(objEvalCred, !this.btnEditar.Enabled);
            frmDetalleBalGenAgricola.ShowDialog();

            if (frmDetalleBalGenAgricola.lGuardado)
            {
                foreach (clsBalGenEval item in this.lstBalGenEval)
                {
                    if (item.idEEFF == EEFF.Insumos) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAInsumos();
                    else if (item.idEEFF == EEFF.ProductosProceso) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAProductosProceso();
                    else if (item.idEEFF == EEFF.ProductosTerminado) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAProductosTerminado();
                    else if (item.idEEFF == EEFF.ActBiologico) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAActivosBiologicos();
                    else if (item.idEEFF == EEFF.MaqEquipos) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAMaquinariasEquipos();
                    else if (item.idEEFF == EEFF.Inmuebles) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAInmuebles();
                    else if (item.idEEFF == EEFF.Vehiculos) item.nTotalMA = frmDetalleBalGenAgricola.nTotalMAVehiculos();
                }
                this.conEstadosFinancieros._lstBalGenEval = this.lstBalGenEval;
                this.lstBalGenEval = this.conEstadosFinancieros._lstBalGenEval;

                this.actualizarEstadosFinancieros();
            }

            frmDetalleBalGenAgricola.Dispose();
        }

        private void conEstadosFinancieros_EERRClick(object sender, EventArgs e)
        {
            frmDetalleEstResAgricola frmDetalleEstResAgricola = new frmDetalleEstResAgricola(this.lstDescripcionEval, this.objEvalCred, !this.btnEditar.Enabled);
            frmDetalleEstResAgricola.ShowDialog();

            if (frmDetalleEstResAgricola.lGuardado)
            {
                this.objEstadosFinancieros.listGFamiliares = frmDetalleEstResAgricola.lstGastosFamiliares;
                this.objEstadosFinancieros.listGOperativos = frmDetalleEstResAgricola.lstGastosOperativos;
                this.objEstadosFinancieros.listOtrosEgresos = frmDetalleEstResAgricola.lstOtrosEgresos;
                this.objEstadosFinancieros.listOtrosIngresos = frmDetalleEstResAgricola.lstOtrosIngresos;

                this.recalcularEEFF(this.nPlazoPropuestoMeses);
            }

            frmDetalleEstResAgricola.Dispose();
        }

        private void conEstadosFinancieros_CellValueChangedEstadosFinancieros(object sender, DataGridViewCellEventArgs e)
        {
        }
        #endregion

        #region eventos - condiciones crédito
        private void conCondiCredito_PlazoChanged(object sender, EventArgs e)
        {
            this.recalcularEEFF(this.nPlazoPropuestoMeses);
        }

        private void conCondiCredito_SectorEconSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void conCondiCredito_CuotaAproximadaChanged(object sender, EventArgs e)
        {
            this.conEstadosFinancieros.CreditoPropuesto = this.conCondiCredito.ObtenerCreditoPropuesto();
            this.conEstadosFinancieros.calcularIIFF();
        }

        private void conCondiCredito_ActividadInternaSelectedIndexChanged(object sender, EventArgs e)
        {
            this.conPropuesta.ActualizarActividadInterna(this.conCondiCredito.ObtenerIdActividadInterna());
        }

        private void cboCultivoEval_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCultivo = Convert.ToInt32(cboCultivoEval1.SelectedValue);
            cboVariedadCultivoEval1.CargaVariedadPorCultivo(idCultivo);
        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            int nMuestraFrm = 1;
            CargarConfiguracionSeguro(nMuestraFrm);
        }
        #endregion
    }
}
