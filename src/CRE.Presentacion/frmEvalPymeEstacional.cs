using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmEvalPymeEstacional : frmBase
    {
        #region Variables

        private string cMsjCaption = "Evaluación de Crédito Pyme Estacional";

        private clsCNEvalPymeEstacional objCapaNegocio;
        private clsEvalCred objEvalCred;
        private clsCreditoProp objSolicitud;
        private List<clsReferenciaEval> listReferencia;
        private DataTable dtEstResEvalM;
        private DataTable dtEstResEvalD;
        private DataTable dtEstResEvalUlt = new DataTable();
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsEvalCualitativa> listEvalCualitativa = new List<clsEvalCualitativa>();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private CRE.CapaNegocio.clsCNCredito objCNCredito;
        private clsCNControlExp cnExp = new clsCNControlExp();
        private clsPropCredito objPropCredito = null;
        private List<clsEstResEval> listEstResEval;
        private clsCNEstadosFinancieros objEstadosFinancieros;
        private bool lformatoSimple;

        // --
        private DataTable dtTipMoneda;
        private DataTable dtTipPeriodo;
        private DataTable dtSectorEconomico;
        private DataTable dtTipReferEval;
        private DataTable dtTipVinculoEval; 
        private DateTime dFechaBase;

        private int idCanal;

        private const int nAnioMinimo = 2000;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        enum TipoFormato
        {
            Simple = 1,
            Completo = 2
        }

        #endregion

        #region Métodos Publicos

        public frmEvalPymeEstacional()
        {
            InitializeComponent();

            this.objCapaNegocio = new clsCNEvalPymeEstacional();
            this.objEstadosFinancieros = new clsCNEstadosFinancieros();
            this.objCNCredito = new CapaNegocio.clsCNCredito();
            this.tabEval.Enabled = false;

            inicializarFormulario();
            habilitarBotones(false);

            this.btnBusqueda.Enabled = true;
            this.btnNuevo.Enabled = true;
        }

        #endregion

        #region Métodos Privados

        private void inicializarFormulario()
        {
            #region Recuperar Datos por default

            DataSet dsResult = this.objCapaNegocio.inicializarPyme();

            //-- Table[0] : Tipos de Moneda
            this.dtTipMoneda = dsResult.Tables[0];

            //-- Table[1] : Tipos de Periodos
            this.dtTipPeriodo = dsResult.Tables[1];

            //-- Table[2] : Tipos de Sector Economico
            this.dtSectorEconomico = dsResult.Tables[2];

            //-- Table[3] : Tipos de Referencia Personal
            this.dtTipReferEval = dsResult.Tables[3];

            //-- Table[4] : Tipos de Vinculo x Tipo de Referencia
            this.dtTipVinculoEval = dsResult.Tables[4];

            #endregion

            #region Asignar Datos

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

            #endregion
        }

        private void recuperarDatos(int idEvalCred)
        {
            #region Recuperar de DataBase

            DataSet dsResult = this.objCapaNegocio.buscarEvalCredito(idEvalCred);

            //-- Table[0] : Evaluacion Maestro
            var aEval = DataTableToList.ConvertTo<clsEvalCred>(dsResult.Tables[0]) as List<clsEvalCred>;
            this.objEvalCred = aEval[0];

            this.objEvalCred.idEstablecimiento = (this.objEvalCred.idEstablecimiento == 0) ? clsVarGlobal.User.idEstablecimiento : this.objEvalCred.idEstablecimiento;
            this.objEvalCred.idTipoEstablec = (this.objEvalCred.idTipoEstablec == 0) ? clsVarGlobal.User.idTipoEstablec : this.objEvalCred.idTipoEstablec;

            //-- Table[1] : Solicitud del Crédito
            var listSolicitud = DataTableToList.ConvertTo<clsCreditoProp>(dsResult.Tables[1]) as List<clsCreditoProp>;
            if (listSolicitud.Count == 1)
            {
                this.objSolicitud = listSolicitud[0];
                this.objSolicitud.idClasificacionInterna = this.objEvalCred.idClasificacionInterna;
                //this.btnAdministradorFiles.idSolicitud = this.objSolicitud.idSolicitud;
                //this.btnAdministradorFiles.actualizarDatos();
                //this.btnAdministradorFiles.Enabled = true;
                this.btnGestObs.Enabled = true;
                this.btnVincularVisita.idSolicitud = this.objSolicitud.idSolicitud;
                this.btnVincularVisita.idCli = this.objEvalCred.idCli;
            }
            else
            {
                MessageBox.Show("La solicitud Nº " + this.objEvalCred.idSolicitud + " no se puede recuperar.",
                    "Recuperando Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnGestObs.Enabled = false;
                return;
            }
            
            //-- Table[2] : Referencias del Cliente
            this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(dsResult.Tables[2]) as List<clsReferenciaEval>;

            //-- Table[3] : Estado de Resultados Maestro
            this.dtEstResEvalM = dsResult.Tables[3];

            //-- Table[4] : Estado de Resultados Detalle
            this.dtEstResEvalD = dsResult.Tables[4];

            //-- Table[5] : Indicadores Financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[5]) as List<clsIndicadorEval>;

            //-- Table[7] : Último Estado de Resultados(Referencia)
            if (dsResult.Tables.Count > 7)
            {
                this.dtEstResEvalUlt = dsResult.Tables[7];
            }

            #endregion

            #region Preparar Objetos

            // -- Propuesta de Crédito
            var objActPrincipal = new clsActividadEconomica();
            objActPrincipal.idTipoActividad = (this.objEvalCred.idTipoActividadPri == 0) ? TipoActividad.Independiente : this.objEvalCred.idTipoActividadPri;
            objActPrincipal.idActividadInterna = this.objEvalCred.idActividadInternaPri;
            objActPrincipal.nAnios = this.objEvalCred.nActPriAnios;
            objActPrincipal.cDireccion = this.objEvalCred.cActPriDireccion;
            objActPrincipal.cReferencia = this.objEvalCred.cActPriReferencia;
            objActPrincipal.cDescripcion = this.objEvalCred.cActPriDescripcion;

            var objActSecundaria = new clsActividadEconomica();
            objActSecundaria.idTipoActividad = (this.objEvalCred.idTipoActividadSec == 0) ? TipoActividad.Independiente : this.objEvalCred.idTipoActividadSec;
            objActSecundaria.idActividadInterna = this.objEvalCred.idActividadInternaSec;
            objActSecundaria.nAnios = this.objEvalCred.nActSecAnios;
            objActSecundaria.cDireccion = this.objEvalCred.cActSecDireccion;
            objActSecundaria.cReferencia = this.objEvalCred.cActSecReferencia;
            objActSecundaria.cDescripcion = this.objEvalCred.cActSecDescripcion;

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

            #endregion

            #region Asignar Fechas para Deudas Financieras

            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);

            Evaluacion.listMesFechasEval = null;
            Evaluacion.listMesFechasEval = new List<clsMesFechasEval>();

            DateTime dFecha;
            for (int i = 1; i < 480; i++) //40 años por 12 meses
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

            #endregion

            #region Asignar a Componentes

            //-- Asignar Datos al formulario General
            this.txtIdEvalCred.Text = String.Format("{0:d8}", this.objEvalCred.idEvalCred);
            this.txtIdSolicitud.Text = (this.objEvalCred.idSolicitud != 0) ? String.Format("{0:d8}", this.objEvalCred.idSolicitud) : "";
            this.txtModCredito.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cModalidadCredito : "";
            this.txtOperacion.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cOperacion : "";
            this.txtTipoCambio.Text = (this.objEvalCred.nTipoCambio != 0) ? this.objEvalCred.nTipoCambio.ToString("n4") : "";

            // -- Evaluación Cualitativa y Referencias
            this.conEvalCualitReferencias.Visible = false;
            this.conEvalCualitReferencias.AsignarDatos(this.listEvalCualitativa, this.listReferencia, this.dtTipReferEval, this.dtTipVinculoEval);
            this.conEvalCualitReferencias.Visible = true;

            // -- Estados Financieros
            this.conEstadosFinancierosPymeEst.asignarDatos(this.objEvalCred, this.objSolicitud, this.dtEstResEvalM, this.dtEstResEvalD, this.dtEstResEvalUlt, this.listIndiFinanc);
            this.lformatoSimple = this.dtEstResEvalM.Rows[0].Field<int>("idMConf") == (int)TipoFormato.Simple ? true : false;

            // -- Propuesta de Crédito
            this.conPropuestaPymeEst.asignarDatos(this.objPropCredito);

            #endregion
        }

        private void habilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnChecklist.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;
            this.btnBusqueda.Enabled = lHabilitado;
            this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnTasaN.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;
        }

        private void habilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado;
            //this.btnAdministradorFiles.lectura = true;
            if (nModo == clsAcciones.EDITAR)
            {
                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnImprimirFlujoCaja.Enabled = false;
                this.btnEnviar.Enabled = false;
                //this.btnAdministradorFiles.lectura = false;
                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;
                btnHabilitarSeguro.Enabled = true;

                habilitarPaginas(true);
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = true;
                btnHabilitarSeguro.Enabled = false;

                habilitarPaginas(false);
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
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;

                habilitarPaginas(false);
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.btnObservacion.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
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
                this.btnTasaN.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;
                this.btnHabilitarSeguro.Enabled = false;
                this.btnEditar.Focus();

                habilitarPaginas(false);
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.btnObservacion.Enabled = false;
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
                this.btnTasaN.Enabled = false;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.btnHabilitarSeguro.Enabled = true;

                habilitarPaginas(true);
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnImprimirFlujoCaja.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = lHabilitado;

                habilitarPaginas(false);
            }
        }

        private void habilitarPaginas(bool lHabilitado)
        {
            this.conEvalCualitReferencias.Enabled = lHabilitado;
            this.conEstadosFinancierosPymeEst.Enabled = lHabilitado;
            this.conPropuestaPymeEst.Enabled = lHabilitado;
        }

        private string evalCredToXML()
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

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private string referenciasToXML()
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

            foreach (clsReferenciaEval rc in this.listReferencia)
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

        private string indicadoresToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idIndicadorEval", typeof(int));
            dt.Columns.Add("nRatio", typeof(decimal));

            foreach (clsIndicadorEval rc in this.listIndiFinanc)
            {
                dt.Rows.Add(rc.idIndicadorEval, rc.nRatio);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "IndicadorEval", "Item");
        }

        private clsMsjError validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            DataRow[] drCostoVentas = this.conEstadosFinancierosPymeEst.obtenerEstPerGan().Select("idEEFF = " + EEFF.CostoVentas);
            decimal nCostoVentas = drCostoVentas[0].Field<decimal>("nValorBase");
            decimal nMonto = this.conEstadosFinancierosPymeEst.obtenerMonto();

            #region Referencias

            if (this.listReferencia.Count < Evaluacion.MinReferencias)
                objMsjError.AddError("Cualit./Refer.: Se requiere un mínimo de dos referencias.");

            if (this.listReferencia.Count > 0)
            {
                int nRefNegativas = (from p in this.listReferencia
                                     where p.nEstado == 2
                                     select p).ToList().Count;

                if (nRefNegativas > 0)
                    objMsjError.AddError("Cualit./Refer.: Tiene registros con ref. negativas.");
            }

            #endregion

            #region Estados Financieros

            //if (nVentasNetas == 0)
            //    objMsjError.AddError("Estados Financ.: Las Ventas Netas estan en CERO.");

            //if (nUDisponible < 0)
            //    objMsjError.AddError("Estados Financ.: Utilidad Disponible es un valor NEGATIVO.");

            //if (nUDisponible > 0 && nOtrosIngresos > nUtilidadNeta)
            //{
            //    objMsjError.AddError("Estados Financ.: \"Otros Ingresos\" es mayor que la \"Utilidad Neta\".");
            //}

            decimal nMontoMaximo = nCostoVentas * 2;
            if (nMonto > nMontoMaximo)
            {
                objMsjError.AddError("Estados Financ.: Monto máximo a otorgar " + nMontoMaximo.ToString("N2") + "(Costo de Ventas * 2)");
            }

            #endregion

            #region Propuesta de Crédito

            var objPropuestaMsjError = this.conPropuestaPymeEst.validar();
            if (objPropuestaMsjError.HasErrors)
            {
                foreach (var err in objPropuestaMsjError.GetListError())
                    objMsjError.AddError("Prop. Crédito: " + err);
            }

            #endregion

            #region Checklist de documentos

            DataTable dtResDocs = cnExp.CNValidarListaDocsEval(this.objSolicitud.idSolicitud);
            if (dtResDocs.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(dtResDocs.Rows[0]["lResultado"]))
                {
                    objMsjError.AddError("Checklist: " + dtResDocs.Rows[0]["cMensaje"].ToString());
                }
            }

            #endregion

            #region Indicadores 

            decimal FinanciamientoCapital = this.listIndiFinanc.Where(x => x.nCodigo == IFN.FinanciamientoCapital).Sum(x => x.nRatio);
            FinanciamientoCapital = Math.Round(FinanciamientoCapital * 100, 2);

            decimal CoberturaPrestamo = this.listIndiFinanc.Where(x => x.nCodigo == IFN.CoberturaPrestamo).Sum(x => x.nRatio);
            CoberturaPrestamo = Math.Round(CoberturaPrestamo * 100, 2);

            if (FinanciamientoCapital < 0)
                objMsjError.AddError("Financiamiento de Capital:  El indicador no debe ser negativo.");

            if (FinanciamientoCapital > 200)
                objMsjError.AddError("Financiamiento de Capital:  El indicador debe ser menor o igual al 200%.");

            if (CoberturaPrestamo < 0)
                objMsjError.AddError("Cobertura de Prestamo:  El indicador no debe ser negativo.");

            if (CoberturaPrestamo > 100)
                objMsjError.AddError("Cobertura de Prestamo:  El indicador debe ser menor o igual al 100%.");

            #endregion

            #region Carga de Archivos

            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(this.objEvalCred.idSolicitud);

            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0) //Estado que indica que existe archivos pendientes.
                objMsjError.AddError(dtCargaArchivos.Rows[0]["cMsg"].ToString());

            //if (!btnAdministradorFiles.obligatoriosCompletos())
            //{
            //    objMsjError.AddError(btnAdministradorFiles.msgObligatorios);
            //}

            #endregion

            return objMsjError;
        }

        private void tituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación Pyme ({0})", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación Pyme ({0}) - {1}", cTipEvalCred, cMensaje);
        }

        private bool revisarAlertaVariable()
        {
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = this.conEstadosFinancierosPymeEst.listarAlertaVariable(this.objEvalCred.idSolicitud, this.objEvalCred.idSectorEcon);

            clsCNAlertaVariable objCNAlertaVariable = new clsCNAlertaVariable();
            List<clsEvalCredAlertaVariable> lstEvalCredAlertaAnterior = objCNAlertaVariable.listarEvalCredAlertaVariable(this.objEvalCred.idEvalCred);

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

        private bool validarIndicadorObser()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.objSolicitud.idSolicitud, 3);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>("lResolCom"));
        }

        private DataTable armarTablaParametros()
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
            drfila[0] = "idSubProducto";
            drfila[1] = this.objSolicitud.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = this.objSolicitud.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = this.conEstadosFinancierosPymeEst.obtenerMonto();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.objEvalCred.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoCuota";
            drfila[1] = this.objEvalCred.nPlazoCuota;
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }

        private bool validarReglas(bool lMostrarAlerta, List<clsReglaNegocioEvaluada> aReglasEvaluadas = null)
        {
            string cNombreFormulario = this.Name;

            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = armarTablaParametros();
            //////////////////**//////////////

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: cNombreFormulario,
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
                                                                            idRegistroExcep: this.objSolicitud.idSolicitud,
                                                                            aReglasEvaluadas: aReglasEvaluadas
                                                                            );
            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            else if (cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {

                return !this.invocarExcepciones(true);
            }
            else
            {
                return false;
            }
        }

        private bool invocarExcepciones(bool lSilencioso)
        {
            clsCreditoProp oEvalCredTemp = this.conEstadosFinancierosPymeEst.condicionesCreditoPropuesto();

            int nIdSolicitud = Convert.ToInt32(this.objEvalCred.idSolicitud);
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            int nIdCliente = Convert.ToInt32(this.objEvalCred.idCli);
            int nIdMoneda = Convert.ToInt32(this.objEvalCred.idMoneda);
            int nIdProducto = Convert.ToInt32(this.objEvalCred.idProducto);
            decimal nValAproba = Convert.ToDecimal(oEvalCredTemp.nMonto);
            int nIdUsuRegist = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            String cOpcion = this.Name;
            String cNombreForm = this.Name;
            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, cNombreForm, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }

        private void CargarConfiguracionSeguro(int nMuestraFrm)
        {
            clsCreditoProp objDatos = new clsCreditoProp();
            objDatos = conEstadosFinancierosPymeEst.condicionesCreditoPropuesto();
            int idSolicitud = this.objEvalCred.idSolicitud;
            int nParam = 1;

            if (objDatos.nPlazoCuota == 0)
            {
                MessageBox.Show("Debe seleccionar frecuencia.", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            objSolicitudCreditoSeguroActual = (objSolicitudCreditoSeguroActual.idSolicitud == 0) ? objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud) : objSolicitudCreditoSeguroActual;
            objSolicitudCreditoSeguroActual.idProducto = objDatos.idProducto;
            objSolicitudCreditoSeguroActual.nMontoSolicitado = objDatos.nMonto;
            objSolicitudCreditoSeguroActual.nCuotas = objDatos.nCuotas;
            objSolicitudCreditoSeguroActual.idTipoPlazo = objDatos.idTipoPeriodo;
            objSolicitudCreditoSeguroActual.nPlazo = objDatos.nPlazoCuota;
            objSolicitudCreditoSeguroActual.idMoneda = objDatos.idMoneda;
            objSolicitudCreditoSeguroActual.cMoneda = objDatos.cMoneda;
            objSolicitudCreditoSeguroActual.dFechaDesembolso = objDatos.dFechaDesembolso;
            objSolicitudCreditoSeguroActual.dFechaCancelacion = clsVarGlobal.dFecSystem;
            objSolicitudCreditoSeguroActual.nDiasGracia = objDatos.nDiasGracia;
            objSolicitudCreditoSeguroActual.nCuotaGracia = objDatos.nCuotasGracia;
            objSolicitudCreditoSeguroActual.lPlanSeguroBD = objSolicitudCreditoSeguroActual.idPaqueteSeguro > 0 ? true : false;
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
        
        #endregion

        #region Eventos

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDTipEvalPymeEstacional"]);

            FrmBuscarEv formBuscarEvPyme = new FrmBuscarEv(cIDsTipEvalCredPyme, "Buscar Evaluaciones Pyme Estacional");
            formBuscarEvPyme.ShowDialog();

            if (formBuscarEvPyme.idCli != 0 && formBuscarEvPyme.idEvalCred != 0)
            {
                this.txtNroDoc.Text = formBuscarEvPyme.cNroDocumento;
                this.txtNombre.Text = formBuscarEvPyme.cNombreCliente;

                (new clsCNSolicitud()).actualizarMontosSolRefi(formBuscarEvPyme.idSolicitud);
                recuperarDatos(formBuscarEvPyme.idEvalCred);

                if (this.objEvalCred.lEditar == true)
                {
                    tituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
                    habilitarBotonesSegunModo(clsAcciones.BUSCAR);
                }
                else
                {
                    tituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    habilitarBotonesSegunModo(clsAcciones.ENVIAR);
                }
            }

            formBuscarEvPyme.Close();
            formBuscarEvPyme.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string cIDTipEvalPymeEstacional = Convert.ToString(clsVarApl.dicVarGen["cIDTipEvalPymeEstacional"]);
            string cIDsSectorEconPymeEstacional = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPymeEstacional"]);
            string cNombreFormulario = this.Name;

            frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDTipEvalPymeEstacional, cIDsSectorEconPymeEstacional, 0, "Nueva Evaluación Pyme Estacional", false);
            nuevaEv.RecuperarNombreFormulario(cNombreFormulario);
            nuevaEv.ShowDialog();

            if (nuevaEv.idCli != 0 && nuevaEv.idEvalCred != 0)
            {
                this.txtNroDoc.Text = nuevaEv.cNroDocumento;
                this.txtNombre.Text = nuevaEv.cNombreCliente;

                recuperarDatos(nuevaEv.idEvalCred);

                habilitarBotonesSegunModo(clsAcciones.NUEVO);

                tituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
            }

            nuevaEv.Close();
            nuevaEv.Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.",
                    "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            var oEvalCredTemp = this.conEstadosFinancierosPymeEst.condicionesCreditoYDestino();

            this.objEvalCred.dFecUltimaEval = new DateTime(2000, 1, 1, 0, 0, 0, 0);
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
            clsPropCredito objPropCredito = this.conPropuestaPymeEst.obtenerDatos();
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

            var dsEstResEval = this.conEstadosFinancierosPymeEst.ObtenerDatos();
            this.dtEstResEvalM = dsEstResEval.Tables[0];
            this.dtEstResEvalD = dsEstResEval.Tables[1];

            // -- Convertir a XML
            string xmlEvalCred = this.evalCredToXML();
            string xmlReferencias = this.referenciasToXML();
            string xmlIndicadorEval = indicadoresToXML();

            var xmlEstResEvalM = clsUtils.ConvertToXML(this.dtEstResEvalM.Copy(), "EstResEvalM", "Item");
            var xmlEstResEvalD = clsUtils.ConvertToXML(this.dtEstResEvalD.Copy(), "EstResEvalD", "Item");

            int nMuestraFrm = 0;

            CargarConfiguracionSeguro(nMuestraFrm);

            DataTable td = this.objCapaNegocio.actualizarEval(this.objEvalCred.idEvalCred,
                        xmlEvalCred,
                        xmlReferencias,
                        xmlEstResEvalM,
                        xmlEstResEvalD,
                        xmlIndicadorEval
            );

            if (td.Rows.Count > 0)
            {
                DataRow drResult = td.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(drResult["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    recuperarDatos(this.objEvalCred.idEvalCred);

                    habilitarBotonesSegunModo(clsAcciones.GRABAR);
                }
            }

            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            validarReglas(false, aReglasEvaluadas);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idCli > 0)
            {
                string cIDTipEvalPymeEstacional = Convert.ToString(clsVarApl.dicVarGen["cIDTipEvalPymeEstacional"]);
                string cIDsSectorEconPymeEstacional = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPymeEstacional"]);

                frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDTipEvalPymeEstacional, cIDsSectorEconPymeEstacional,
                                            this.objEvalCred.idCli, "Vinculación de Solicitud con Evaluación Nº " + this.objEvalCred.idEvalCred.ToString(), true);

                nuevaEv.InicializarValores(this.objEvalCred);
                nuevaEv.ShowDialog();

                this.objEvalCred.idSolicitud = nuevaEv.idSolicitud;
                this.objEvalCred.idProducto = nuevaEv.idProducto;
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;

                if (this.objEvalCred.idSolicitud > 0)
                    recuperarDatos(this.objEvalCred.idEvalCred);

                nuevaEv.Close();
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

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            clsMsjError objMsjError = validar();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!this.validarReglas(true))
            {
                return;
            }
            else
            {
                MessageBox.Show("No se encontraron errores en la Evaluación.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            if (!validarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.",
                    "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsMsjError objMsjError = validar();

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

            if (!validarReglas(true)) return;
            if (this.invocarExcepciones(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a comité de Créditos?",
                "Enviar a Comité de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                if (!this.revisarAlertaVariable()) return;

                clsCreditoProp oEvalCredTemp = this.conEstadosFinancierosPymeEst.condicionesCreditoPropuesto();

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
                    this.idCanal = idCanalAproCredTemp;

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
                            this.idCanal = idCanalAproCredTemp;
                        }
                        else if (idCanalAproCredTemp == Convert.ToInt32(clsVarApl.dicVarGen["idCanalAproCredB"]))
                        {
                            frmCanalResolucionCreditos frmCanalResolCred = new frmCanalResolucionCreditos();
                            frmCanalResolCred.ShowDialog();
                            idCanalAproCredTemp = frmCanalResolCred.idCanalAproCred;

                            if (idCanalAproCredTemp > 0)
                                this.idCanal = idCanalAproCredTemp;
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
                    return;
                
                // ------------------------------------------------------------------------

                oEvalCredTemp.idOrigenCredProp = 2;
                oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                oEvalCredTemp.nCostos = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.CostoVentas).Field<decimal>("nValorBase");

                oEvalCredTemp.nDeudas = 0;
                oEvalCredTemp.nNeto = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.UtilidadBruta).Field<decimal>("nValorBase");
                oEvalCredTemp.nDisponible = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.UtilidadBruta).Field<decimal>("nValorBase");

                if (!this.lformatoSimple)
                {
                    oEvalCredTemp.nDeudas = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.GastosFinancieros).Field<decimal>("nValorBase");
                    oEvalCredTemp.nNeto = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.UtilidadNeta).Field<decimal>("nValorBase");
                    oEvalCredTemp.nDisponible = this.dtEstResEvalD.AsEnumerable()
                            .FirstOrDefault(row => Convert.ToInt32(row["idEEFF"]) == EEFF.ExcedenteMensualFamiliar).Field<decimal>("nValorBase");
                }
                
                string xmlDestCredProp = oEvalCredTemp.GetXml();

                DataTable dtEnvCom = objCapaNegocio.enviarAComiteCreditos(this.objEvalCred.idEvalCred,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    xmlDestCredProp,
                    idCanal,
                    lCanalAproCredEditable
                );

                this.objCapaNegocio.guardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                if (idMsj == 1)
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    habilitarBotonesSegunModo(clsAcciones.ENVIAR);
                    this.objEvalCred.lEstado = false;

                    tituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                }
                else
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void conEstadosFinancierosPymeEst_DeudasClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            FrmDeudasFinanc frmdeudasFinanc = new FrmDeudasFinanc(this.objEvalCred.idEvalCred, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda,
                                                            Evaluacion.MonedaSimbolo);
            frmdeudasFinanc.ShowDialog();

            lGuardado = frmdeudasFinanc.lGuardado;
            if (lGuardado == true)
            {
                this.objEstadosFinancieros.listCredDirectos = frmdeudasFinanc.CredDirectos();
                this.objEstadosFinancieros.listCredIndirect = frmdeudasFinanc.CredIndirect();
                decimal nGastosFinancieros = this.objEstadosFinancieros.obtenerMontoCuotaCDirectos() + this.objEstadosFinancieros.obtenerMontoCuotaCIndirectos();
                this.conEstadosFinancierosPymeEst.actualizarGastosFinancieros(nGastosFinancieros);
            }

            frmdeudasFinanc.Dispose();
        }

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
            Cursor.Current = Cursors.WaitCursor;
            new clsRptEvalPyme(this.objEvalCred.idEvalCred, this.objEvalCred.idSolicitud, null).ImpFlujoCaja();
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objEvalCred.idSolicitud, !this.objEvalCred.lEditar);
                frmCargaArchivo.ShowDialog();
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            if (this.objSolicitud == null)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", "Solicitud Vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmVistaObservacionesApro frmVistaObsAproSol = new frmVistaObservacionesApro(this.objSolicitud.idSolicitud);
            frmVistaObsAproSol.ShowDialog();
        }

        private void btnCopiado_Click(object sender, EventArgs e)
        {
            frmCopiarEval frmCopiarEval = new frmCopiarEval(this.objEvalCred, "Copiado de Evaluaciones");
            frmCopiarEval.ShowDialog();

            if (frmCopiarEval.lEjecutado == true)
            {
                recuperarDatos(this.objEvalCred.idEvalCred);

                btnGrabar.PerformClick();

                MessageBox.Show("Evaluación recuperada correctamente.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            this.validarReglas(false, aReglasEvaluadas);
            this.invocarExcepciones(false);
        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            int nMuestraFrm = 1;
            CargarConfiguracionSeguro(nMuestraFrm);
        }

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
            frmGestObs.lEditar = this.objEvalCred.lEditar;
            frmGestObs.idEtapaEvalCred = 3;
            frmGestObs.nModoFunc = 2;
            frmGestObs.idSolicitud = this.objSolicitud.idSolicitud;
            frmGestObs.ConfigSelecFiltros(true, false, false, true);
            frmGestObs.ShowDialog();
        }

        #endregion

        private void btnTasaN_Click(object sender, EventArgs e)
        {
            if (txtIdSolicitud.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar una solicitud de crédito válido.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTasaNegociable frm = new frmTasaNegociable();
            frm.flowLayoutPanel2.Visible = false;
            frm.grbDato_Solicitud.Visible = false;
            frm.Size = new System.Drawing.Size(705, 500);
            frm.lTasafrm = true;
            frm.BuscarSolicitud(Convert.ToInt32(txtIdSolicitud.Text));
            if (frm.lTasaNegociada == true)
            {
                frm.idSolicitud_frm = Convert.ToInt32(txtIdSolicitud.Text);
                frm.ShowDialog();
            }
        }
    }
}