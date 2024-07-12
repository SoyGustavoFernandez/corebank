using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Servicio;
using EntityLayer.MotorDecisionWebService;

namespace CRE.Presentacion
{
    public partial class frmEvalPyme : frmBase
    {
        #region Variables
        private string cMsjCaption = "Evaluación de Crédito Pyme";

        private clsCNEvalPyme objCapaNegocio;
        private CRE.CapaNegocio.clsCNCredito objCNCredito;
        private clsCNControlExp cnExp = new clsCNControlExp();

        private clsEvalCred objEvalCred;
        private clsPropCredito objPropCredito = null;
        private List<clsEvalCualitativa> listEvalCualitativa;
        private List<clsReferenciaEval> listReferencia;
        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsDestCredProp> listDestCredProp;
        private List<clsElemEvalCred> listElemEvalCred;
        private List<clsDescripcionEval> listDescripcionEval;
        private List<clsDetBalGenEval> listInventario;
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private clsCNEstadosFinancieros objEstadosFinancieros;

        // --
        private DataTable dtTipMoneda;
        private DataTable dtTipPeriodo;
        private DataTable dtSectorEconomico;
        private DataTable dtTipReferEval;
        private DataTable dtTipVinculoEval;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private DateTime dFechaBase;

        private clsCreditoProp objSolicitud;
        private bool lBalanceGeneral;
        private int idCanal;

        private const int nAnioMinimo = 2000;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        FrmBuscarEv objDatosSeguro = new FrmBuscarEv();

        private bool lEsMNB;
        #endregion

        public frmEvalPyme()
        {
            InitializeComponent();

            this.objCapaNegocio = new clsCNEvalPyme();
            this.objEstadosFinancieros = new clsCNEstadosFinancieros();
            this.objCNCredito = new CRE.CapaNegocio.clsCNCredito();
            this.tabEval.Enabled = false;

            InicializarFormulario();
            HabilitarBotones(false);

            this.btnBusqueda.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.lBalanceGeneral = false;
        }

        #region Métodos Privados
        private void InicializarFormulario()
        {
            #region Recuperar Datos por default
            DataSet dsResult = this.objCapaNegocio.InicializarPyme();

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

        private void RecuperarDatos(int idEvalCred)
        {
            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged -= new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged -= new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged -= new System.EventHandler(this.conCondiCredito_PlazoChanged);

            #region Recuperar de DataBase
            DataSet dsResult = this.objCapaNegocio.BuscarEvalCredito(idEvalCred);

            //-- Table[0] : Evaluacion Maestro
            var aEval = DataTableToList.ConvertTo<clsEvalCred>(dsResult.Tables[0]) as List<clsEvalCred>;
            this.objEvalCred = aEval[0];

            this.objEvalCred.idEstablecimiento = (this.objEvalCred.idEstablecimiento == 0) ? clsVarGlobal.User.idEstablecimiento : this.objEvalCred.idEstablecimiento;
            this.objEvalCred.idTipoEstablec = (this.objEvalCred.idTipoEstablec == 0) ? clsVarGlobal.User.idTipoEstablec : this.objEvalCred.idTipoEstablec;

            if (this.objEvalCred.idSolicitud > 0)
            {
                //-- Table[1] : Solicitud del Crédito
                var aSolicitud = DataTableToList.ConvertTo<clsCreditoProp>(dsResult.Tables[1]) as List<clsCreditoProp>;
                if (aSolicitud.Count == 1)
                {
                    this.objSolicitud = aSolicitud[0];
                    this.objSolicitud.idClasificacionInterna = this.objEvalCred.idClasificacionInterna;
                    //btnAdministradorFiles1.idSolicitud = this.objSolicitud.idSolicitud;
                    //btnAdministradorFiles1.actualizarDatos();
                    //btnAdministradorFiles1.Enabled = true;
                    this.btnGestObs.Enabled = true;
                    btnVincularVisita1.idSolicitud = this.objSolicitud.idSolicitud;
                    btnVincularVisita1.idCli = this.objEvalCred.idCli;
                }
                else
                {
                    MessageBox.Show("La solicitud Nº " + this.objEvalCred.idSolicitud + " no se puede recuperar.",
                        "Recuperando Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.btnGestObs.Enabled = false;
                    return;
                }
            }
            else
            {
                this.objSolicitud = new clsCreditoProp();
                this.btnGestObs.Enabled = false;
            }

            //-- Table[2] : Evaluacion Cualitativa
            this.listEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(dsResult.Tables[2]) as List<clsEvalCualitativa>;

            //-- Table[3] : Referencias del Cliente
            this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(dsResult.Tables[3]) as List<clsReferenciaEval>;

            //-- Table[4] : Balance General
            this.listBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(dsResult.Tables[4]) as List<clsBalGenEval>;

            //-- Table[5] : Estado de Resultados
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsResult.Tables[5]) as List<clsEstResEval>;

            //-- Table[6] : Indicadores Financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[6]) as List<clsIndicadorEval>;

            //-- Table[7] : Lista de Destino de Crédito
            this.dtTipDestCred = dsResult.Tables[7];

            //-- Table[8] : Lista del Detalle de los Destinos de Crédito
            this.dtTipDestCredDetalle = dsResult.Tables[8];

            //-- Table[9] : Destinos de Crédito Propuesto
            this.listDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(dsResult.Tables[9]) as List<clsDestCredProp>;

            //-- Table[10] : Lista de Elementos(controles) NO habilitados
            this.listElemEvalCred = DataTableToList.ConvertTo<clsElemEvalCred>(dsResult.Tables[10]) as List<clsElemEvalCred>;

            //-- Table[11] : Lista Tipos de descripciones
            this.listDescripcionEval = DataTableToList.ConvertTo<clsDescripcionEval>(dsResult.Tables[11]) as List<clsDescripcionEval>;

            //-- Table[12] : Lista de Inventario
            this.listInventario = DataTableToList.ConvertTo<clsDetBalGenEval>(dsResult.Tables[12]) as List<clsDetBalGenEval>;
            #endregion

            #region Preparar Objetos
            //Evaluacion.DataTableMoneda = this.dtTipMoneda;

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

            decimal nMontoCapitalTrabajo = this.listDestCredProp.Where(x => x.idTipDestCred == Evaluacion.CapitalTrabajo).Sum(x => x.nMonto);

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

            #region Asignar a Componentes
            //-- Asignar Datos al formulario General
            this.txtIdEvalCred.Text = String.Format("{0:d8}", this.objEvalCred.idEvalCred);
            this.txtIdSolicitud.Text = (this.objEvalCred.idSolicitud != 0) ? String.Format("{0:d8}", this.objEvalCred.idSolicitud) : "";
            this.txtModCredito.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cModalidadCredito : "";
            this.txtOperacion.Text = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.cOperacion : "";
            this.txtTipoCambio.Text = (this.objEvalCred.nTipoCambio != 0) ? this.objEvalCred.nTipoCambio.ToString("n4") : "";

            // -- Visualizamos el tab Evaluación Cualitativa y Referencias
            this.conEvalCualitReferencias.Visible = false;
            this.conEvalCualitReferencias.AsignarDatos(this.listEvalCualitativa, this.listReferencia, this.dtTipReferEval, this.dtTipVinculoEval);
            this.conEvalCualitReferencias.Visible = true;

            decimal nCapitalParacomercio = 0;
            this.conEstadosFinancieros.AsignarDatos(this.listBalGenEval, this.listEstResEval, this.listIndiFinanc, this.listInventario,
                this.objEvalCred.nCapitalPropuesto, this.objEvalCred.nCuotaAprox, nMontoCapitalTrabajo, this.objEvalCred.nTotalPasivoAC, nCapitalParacomercio, this.objEvalCred.idSectorEcon, 
                this.objEvalCred.idTipEvalCred, 0, 0, this.objEvalCred.idEvalCred, this.objEvalCred.idCli, this.objSolicitud.idDestino);

            this.conCondiCredito.AsignarDataTable(this.dtTipMoneda, this.dtTipPeriodo, this.dtTipDestCred, this.dtTipDestCredDetalle, this.dtSectorEconomico);
            this.conCondiCredito.AsignarDatos(this.objEvalCred, this.objSolicitud, this.listDestCredProp, this.listBalGenEval, this.listEstResEval);

            this.conPropuesta.AsignarDatos(this.objPropCredito);
            #endregion

            #region Configurar Formulario de Evaluación
            this.lBalanceGeneral = true;
            foreach (var elem in this.listElemEvalCred)
            {
                if (elem.lHabilitado == false)
                {
                    if (elem.nCodigo == ElemEvalCred.BalanceGeneral)
                    {
                        this.lBalanceGeneral = false;
                        this.conEstadosFinancieros.BalanceGeneralEnabled = false;
                    }

                    //if (elem.nCodigo == ElemEvalCred.EstadoResultados)

                    //if (elem.nCodigo == ElemEvalCred.FlujoCaja)
                    //    this.conEstadosFinancieros.ButtonFlujoCaja = false;

                    //if (elem.nCodigo == ElemEvalCred.UltEvaluacion)
                    //    this.conEstadosFinancieros.UltEvaluacionEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleDeudas)
                        this.conEstadosFinancieros.ButtonDeudas = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleBBGG)
                        this.conEstadosFinancieros.ButtonBalanceGeneral = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleEERR)
                        this.conEstadosFinancieros.ButtonEstadosResultados = false;

                    if (elem.nCodigo == ElemEvalCred.ActSecundaria)
                        this.conPropuesta.ConActSecundariaEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.EntFamiliar)
                        this.conPropuesta.TxtEntFamiliarEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.DesPrestamo)
                        this.conPropuesta.TxtDestPrestamoEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.AntCrediticios)
                        this.conPropuesta.TxtAntecedentesEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.AnaIndicadores)
                        this.conPropuesta.TxtIndFinancierosEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.DesGarantias)
                        this.conPropuesta.TxtGarantiasEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.Conclusiones)
                        this.conPropuesta.TxtConclusionesEnabled = false;
                }
            }
            #endregion

            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged += new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged += new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged += new System.EventHandler(this.conCondiCredito_PlazoChanged);

            this.conEstadosFinancieros.UltEvaluacionLimpiarCeldas = false;
            this.conEstadosFinancieros.UltEvaluacionChecked = true;
            this.conEstadosFinancieros.UltEvaluacionLimpiarCeldas = true;

            #region Asignar Fechas
            DateTime dFechaActualEval = Convert.ToDateTime(Evaluacion.FechaActualEval);
            this.dFechaBase = new DateTime(dFechaActualEval.Year, dFechaActualEval.Month, 1);

            Evaluacion.listMesFechasEval = null;
            Evaluacion.listMesFechasEval = new List<clsMesFechasEval>();

            DateTime dFecha;
            for (int i = 1; i < 480; i++)     //40 años por 12 meses
            {
                //dFecha = (new DateTime(this.dFechaBase.Year, this.dFechaBase.Month, 1)).AddMonths(i);
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

            decimal nPuntajeEvalCualitativa = this.listEvalCualitativa.Sum(x => Convert.ToDecimal(x.oPuntaje));
            this.conEstadosFinancieros.PuntajeEvalCualitativa(nPuntajeEvalCualitativa);
            conCondiCredito_CuotaAproximadaChanged(null, null);
            //this.conEstadosFinancieros.ActualizarIndicadores();
            ActualizarRcc();

            //-- Evaluar si pertenece al MNB
            DataTable dtMNB = new clsCNMotorDecision().ClasificacionInternaxCli(this.objEvalCred.idSolicitud);
            int clasInternaCli = Convert.ToInt32(dtMNB.Rows[0]["idClasifInterna"]);
            this.lEsMNB = clasInternaCli == 9 ? true : false;
        }

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnTasaN.Enabled = lHabilitado;
            //this.btnDenegar.Enabled = lHabilitado;
            //this.btnChecklist.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;
            //this.btnVincular.Enabled = lHabilitado;
            this.btnBusqueda.Enabled = lHabilitado;
            this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
            //this.btnCancelar.Enabled = lHabilitado;
            //this.btnSalir.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;
        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado;
            //this.btnAdministradorFiles1.lectura = true;
            if (nModo == clsAcciones.EDITAR)
            {
                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnImprimirFlujoCaja.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                //this.btnAdministradorFiles1.lectura = false;
                //this.btnDenegar.Enabled = lHabilitado;
                //this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                //this.btnVincular.Enabled = lHabilitado;
                //this.btnBusqueda.Enabled = lHabilitado;
                //this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                //this.btnCancelar.Enabled = lHabilitado;
                //this.btnObservacion1.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;
                btnHabilitarSeguro.Enabled = true;


                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                //this.btnDenegar.Enabled = lHabilitado;
                //this.btnChecklist.Enabled = lHabilitado;
                //this.btnValidar.Enabled = lHabilitado;
                //this.btnVincular.Enabled = lHabilitado;
                //this.btnBusqueda.Enabled = lHabilitado;
                //this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = false;
                //this.btnCancelar.Enabled = lHabilitado;
                //this.btnObservacion1.Enabled = lHabilitado;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = true;
                btnHabilitarSeguro.Enabled = false;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.ENVIAR)
            {
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                //this.btnDenegar.Enabled = lHabilitado;
                //this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                //this.btnCancelar.Enabled = lHabilitado;
                //this.btnObservacion1.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = false;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.btnObservacion1.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnImprimirFlujoCaja.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                //this.btnDenegar.Enabled = true;
                //this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                //this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                //this.btnCancelar.Enabled = lHabilitado;
                //this.btnObservacion1.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = true;
                btnHabilitarSeguro.Enabled = false;

                this.btnEditar.Focus();

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.btnObservacion1.Enabled = false;
                this.tabEval.Enabled = true;

                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnImprimirFlujoCaja.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                //this.btnDenegar.Enabled = lHabilitado;
                //this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                //this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;
                this.btnGrabar.Enabled = lHabilitado;
                //this.btnCancelar.Enabled = lHabilitado;
                this.btnCopiado.Enabled = false;
                this.btnExcepciones.Enabled = false;
                btnHabilitarSeguro.Enabled = true;

                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnImprimirFlujoCaja.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                //this.btnDenegar.Enabled = lHabilitado;
                //this.btnChecklist.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;
                //this.btnCancelar.Enabled = lHabilitado;
                //this.btnObservacion1.Enabled = lHabilitado;
                this.btnCopiado.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = lHabilitado;

                HabilitarPaginas(false);
            }
        }

        private void HabilitarPaginas(bool lHabilitado)
        {
            this.conEvalCualitReferencias.Enabled = lHabilitado;
            this.conEstadosFinancieros.Enabled = lHabilitado;
            this.conCondiCredito.Enabled = (this.objEvalCred.idSolicitud > 0) ? lHabilitado : false;
            this.conPropuesta.Enabled = lHabilitado;
        }

        private string EvalCredToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idUsuMod", typeof(int));
            //dt.Columns.Add("dFecMod", typeof(DateTime));
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
            //row["dFecMod"] = clsVarGlobal.dFecSystem;
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

        private string EvalCualitativaCredToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEvalCualitativa", typeof(int));
            dt.Columns.Add("idItemCualit", typeof(int));
            dt.Columns.Add("nPuntaje", typeof(decimal));
            dt.Columns.Add("nComputado", typeof(decimal));
            dt.Columns.Add("lAutomatico", typeof(bool));

            foreach (clsEvalCualitativa ev in this.listEvalCualitativa)
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

        private string BalGenEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idBalGenEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));

            foreach (clsBalGenEval bg in listBalGenEval)
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

        private string EstResEvalToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idEstResEval", typeof(int));
            dt.Columns.Add("nTotalUltEvMA", typeof(decimal));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nAnalisisVerti", typeof(decimal));
            dt.Columns.Add("nAnalisisHoriz", typeof(decimal));
            dt.Columns.Add("nTotalMN", typeof(decimal));
            dt.Columns.Add("nTotalME", typeof(decimal));

            foreach (clsEstResEval er in listEstResEval)
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

        private string DestCredPropToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idDestCredProp", typeof(int));
            dt.Columns.Add("idTipDestCred", typeof(int));
            dt.Columns.Add("idDetalle", typeof(int));
            dt.Columns.Add("nPorcentaje", typeof(decimal));
            dt.Columns.Add("nMonto", typeof(decimal));

            foreach (clsDestCredProp dc in this.listDestCredProp)
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

        private string ReferenciasToXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idReferenciaEval", typeof(int));
            dt.Columns.Add("idTipReferEval", typeof(int));
            dt.Columns.Add("idTipVinculoEval", typeof(int));
            dt.Columns.Add("cConcepto", typeof(string));
            dt.Columns.Add("cDireccion", typeof(string));
            dt.Columns.Add("cNumeroCelular", typeof(string));
            dt.Columns.Add("nEstado", typeof(byte));
            dt.Columns.Add("cComentarios", typeof(string)); //paulgpp

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
                    rc.cComentarios // paulgpp
                );
            }

            return clsUtils.ConvertToXML(dt.Copy(), "ReferenciaEval", "Item");
        }

        private string IndicadoresToXML()
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

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            var nTotalActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
            var nTotalPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);
            var nVentasNetas = this.listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            var nUDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);
            var nCaja = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Caja).Sum(x => x.nTotalMA);
            decimal nTotalPrestamos = this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosCP).Sum(x => x.nTotalMA) +
                                 this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosLP).Sum(x => x.nTotalMA);

            var nOtrosIngresos = this.listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            var nUtilidadNeta = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);

            decimal nPorcentaje = this.listDestCredProp.Sum(x => x.nPorcentaje);


            #region Propuesta de Crédito
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
            if (this.lBalanceGeneral)
            {
                if (nTotalActivo == 0)
                    objMsjError.AddError("Estados Financ.: Total Activo es CERO.");

                /*if (nTotalPatrimonio < 0)
                    objMsjError.AddError("Estados Financ.: Total Patrimonio es NEGATIVO.");*/

                if (nTotalPrestamos < this.objEvalCred.nTotalDeudas)
                    objMsjError.AddError("Estados Financ.: Actualice las Deudas con Entidades Financieras.");

            }

            if (nVentasNetas == 0)
                objMsjError.AddError("Estados Financ.: Las Ventas Netas estan en CERO.");

            if (nUDisponible < 0)
                objMsjError.AddError("Estados Financ.: Utilidad Disponible es un valor NEGATIVO.");

            if (nUDisponible > 0 && nOtrosIngresos > nUtilidadNeta)
            {
                objMsjError.AddError("Estados Financ.: \"Otros Ingresos\" es mayor que la \"Utilidad Neta\".");
            }

            if (this.objEvalCred.nCajaInicial > nCaja)
            {
                objMsjError.AddError("Estados Financ.: \"Caja Inicial\" es mayor a la Cuenta. del BBGG.");
            }

            /*foreach (clsIndicadorEval oIndFinac in this.listIndiFinanc)
            {
                if (oIndFinac.nRatio < 0)
                {
                    objMsjError.AddError("Estados Financ.: Los indicadores Financ. están en NEGATIVO.");
                    break;
                }
            }*/
            #endregion

            #region Condiciones del Crédito
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

            #region Validacion Activo a adquirir
            decimal nPorcentajeActivoAdquirir = 0;
            decimal nMontoActivoFijo = 0;
            decimal nValorActivoAdquirir = 0;

            nPorcentajeActivoAdquirir = Convert.ToDecimal(clsVarApl.dicVarGen["nPorcentajeActivoAdquirir"]);
            nValorActivoAdquirir = conCondiCredito.ObtenerActivoAdquirir();
            nMontoActivoFijo = listDestCredProp.Where(p => p.nCodigo == 2).Sum(p => p.nMonto); //Activo Fijo: nCodigo = 2

            if ((nValorActivoAdquirir * nPorcentajeActivoAdquirir) < nMontoActivoFijo)
            {
                objMsjError.AddError("Activo Fijo: Sólo podemos financiar el 80% de un activo fijo.");
            }

            //if (!btnAdministradorFiles1.obligatoriosCompletos())
            //{
            //    objMsjError.AddError(btnAdministradorFiles1.msgObligatorios);
            //}
            #endregion
            
            #region Indicadores 

            decimal nEndeudamiento = this.listIndiFinanc.Where(x => x.nCodigo == 3).Sum(x => x.nRatio);
            nEndeudamiento = Math.Round(nEndeudamiento * 100, 2);
            
            decimal nCapacidad = this.listIndiFinanc.Where(x => x.nCodigo == 6).Sum(x => x.nRatio);
            nCapacidad = Math.Round(nCapacidad * 100, 2);
            
            decimal nCompraDeuda = Convert.ToDecimal(this.listDestCredProp.Where(x => x.cDestinoCredito == "Compra de deuda").Sum(x => x.nPorcentaje));
            nCompraDeuda = Math.Round(nCompraDeuda * 100, 2);
            
            decimal nLibreDispo = Convert.ToDecimal(this.listDestCredProp.Where(x => x.cDestinoCredito == "Libre disponibilidad").Sum(x => x.nPorcentaje));
            nLibreDispo = Math.Round(nLibreDispo * 100, 2);

            int nOperacion = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.idOperacion : 0;

            if (nCompraDeuda > 0)
            {
                if ((nEndeudamiento > 90) && ((nOperacion != 2) && (nOperacion != 6)))
                {
                    objMsjError.AddError("Endeudamiento:  El indicador endeudamiento total  proyectado para el destino compra de deuda debe ser menor o igual al 90%.");

                }

            }
            else
            {
                if ((nEndeudamiento > 100) && ((nOperacion != 2) && (nOperacion != 6)))
                {
                    objMsjError.AddError("Endeudamiento:  El Indicador endeudamiento total proyectado debe ser menor o igual al 100%.");
                }
            }


            if (nLibreDispo > 0)
            {
                if (nCapacidad > 65)//65
                {
                    objMsjError.AddError("Capacidad de Pago:  El indicador  capacidad de pago para el libre disponibilidad  debe ser menor o igual al 65%.");
                }
            }
            else if (nCompraDeuda > 0)
            {
                if (nCapacidad > 70)//70
                {
                    objMsjError.AddError("Capacidad de Pago:  El indicador  capacidad de pago para el destino compra de deuda debe ser menor o igual al 70%.");
                }
            }
            else
            {
                if (nCapacidad > 80 && ((nOperacion != 2) && (nOperacion != 6)))//(nCapacidad > 80)
                {
                    objMsjError.AddError("Capacidad de Pago:  El indicador capacidad de pago del solicitante debe ser menor o igual al 80%.");
                }

                else if (nCapacidad > 100 && ((nOperacion == 2) || (nOperacion == 6)))//(nCapacidad > 100)
                {
                    objMsjError.AddError("Capacidad de Pago:  El indicador capacidad de pago del solicitante debe ser menor o igual al 100%.");
                }


            }
                        
            #endregion

            #region OpRiesgos


            DataTable dtOpRiesgos = objCapaNegocio.CNValidarVisitas(this.objEvalCred.idEvalCred);
            string cMsj2 = dtOpRiesgos.Rows[0]["cMensaje"].ToString();
            int idMsj2 = Convert.ToInt32(dtOpRiesgos.Rows[0]["cNroMsj"]);

            if (idMsj2 == 3)
            {
                objMsjError.AddError(cMsj2);
            }


            #endregion

            #region Carga de Archivos
            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(this.objEvalCred.idSolicitud);
            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
            {
                objMsjError.AddError(dtCargaArchivos.Rows[0]["cMsg"].ToString());
            }
            #endregion


            return objMsjError;
        }

        private void RecuperarEvalCredito()
        {
            DataSet ds = this.objCapaNegocio.RecuperarEvalCredito(this.objEvalCred.idEvalCred);

            //-- Table[0] : Evaluacion Cualitativa
            this.listEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[0]) as List<clsEvalCualitativa>;

            //-- Table[1] : Referencias del Cliente
            this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(ds.Tables[1]) as List<clsReferenciaEval>;

            //-- Table[2] : Destinos de Crédito Propuesto
            this.listDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(ds.Tables[2]) as List<clsDestCredProp>;

            //-- Actualizar Datos
            this.conEvalCualitReferencias.ActualizarDatos(this.listEvalCualitativa, this.listReferencia);
            this.conCondiCredito.ActualizarDatos(this.objEvalCred.nCapitalPropuesto, this.listDestCredProp);
            ActualizarRcc();
        }

        private void TituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación Pyme ({0})", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación Pyme ({0}) - {1}", cTipEvalCred, cMensaje);
        }

        private void ActualizarEstadosFinancieros()
        {
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();

            DataTable td = this.objCapaNegocio.ActEstFinancieroslEval(this.objEvalCred.idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

        private void ActualizarRcc()
        {
            decimal nIngresosMN = 0,
                    nIngresosME = 0,
                    nEgresosMN = 0,
                    nEgresosME = 0,
                    nDeudasEntFinanMN = 0,
                    nDeudasEntFinanME = 0;

            nIngresosMN = this.listEstResEval.Where(x => x.nTipoTrans == 1).Sum(x => x.nTotalMN);
            nIngresosME = this.listEstResEval.Where(x => x.nTipoTrans == 1).Sum(x => x.nTotalME);
            nEgresosMN = this.listEstResEval.Where(x => x.nTipoTrans == 2).Sum(x => x.nTotalMN);
            nEgresosME = this.listEstResEval.Where(x => x.nTipoTrans == 2).Sum(x => x.nTotalME);
            nDeudasEntFinanMN = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMN);
            nDeudasEntFinanME = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalME);

            decimal nCuotaAprox = this.conCondiCredito.CuotaAprox();
            //clsEvalCred oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();

            this.conCondiCredito.ActualizarRcc(nIngresosMN, nIngresosME, nEgresosMN, nEgresosME, nCuotaAprox,
                (nDeudasEntFinanMN + nDeudasEntFinanME * this.objEvalCred.nTipoCambio));
        }

        private void RecuperarDetalleEstRes(int idEvalCred)
        {
            DataSet ds = (new clsCNEvaluacion()).RecuperarDetalleGeneralEstResultadosEval(idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listVentasCostos = DataTableToList.ConvertTo<clsVentasCostos>(ds.Tables[1]) as List<clsVentasCostos>;
            var listCosteoEval = DataTableToList.ConvertTo<clsCosteo>(ds.Tables[2]) as List<clsCosteo>;
            var listVarFlujoCaja = DataTableToList.ConvertTo<clsVarFlujoCajaEval>(ds.Tables[3]) as List<clsVarFlujoCajaEval>;
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[4]) as List<clsDeudasEval>;
            var listDeudaCuotaPago = DataTableToList.ConvertTo<clsCuotaPago>(ds.Tables[5]) as List<clsCuotaPago>;

            // -- Organizar listas
            #region Detalle de los Estado Resultados
            var listGFamiliares = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosFamiliares
                                   select p).ToList();

            var listGPersonales = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosPersonales
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
            this.objEstadosFinancieros.listGPersonales = listGPersonales;
            this.objEstadosFinancieros.listGOperativos = listGOperativos;
            this.objEstadosFinancieros.listOtrosEgresos = listOtrosEgresos;
            this.objEstadosFinancieros.listOtrosIngresos = listOtrosIngresos;
            this.objEstadosFinancieros.listCredDirectos = listSalRCCDirectos;
            this.objEstadosFinancieros.listCredIndirect = listSalRCCDIndirec;
        }
        private bool revisarAlertaVariable()
        {
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = this.conEstadosFinancieros.listarAlertaVariable(this.objEvalCred.idSolicitud, this.objEvalCred.idSectorEcon);


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
        #endregion

        #region Eventos
        private void tabEval_Selected(object sender, TabControlEventArgs e)
        {
            if (tabEval.SelectedTab == tabEval.TabPages["tbpCondCredito"] && this.objEvalCred.idSolicitud == 0)
            {
                this.plMsjBloqueo.Location = new System.Drawing.Point(260, 121);
                this.plMsjBloqueo.Visible = true;
            }
            else
            {
                this.plMsjBloqueo.Visible = false;
                this.plMsjBloqueo.Location = new System.Drawing.Point(759, 319);
            }

            // -- Evento de Cambio de TabPage
            /*if (tabEval.SelectedTab == tabEval.TabPages["tbpEstFinancie"] && this.lCargadoTabEstFinancieros == false)
            {
                this.lCargadoTabEstFinancieros = true;
                this.conEstadosFinancieros.AsignarDatos(this.listBalGenEval, this.listEstResEval);
            }
            else if (tabEval.SelectedTab == tabEval.TabPages["tbpCondCredito"] && this.lCargadoTabConCredito == false)
            {
                this.lCargadoTabConCredito = true;
                this.conCondiCredito.AsignarDataTable(this.dtTipMoneda, this.dtTipPeriodo, this.dtTipDestCred, this.dtTipDestCredDetalle, this.dtSectorEconomico);
                this.conCondiCredito.AsignarDatos(this.objEvalCred, this.objSolicitud, this.listDestCredProp, this.listIndiFinanc, this.listBalGenEval, this.listEstResEval);
            }
            else if (tabEval.SelectedTab == tabEval.TabPages["tbpPropCredito"] && this.lCargadoTabPropuesta == false)
            {
                this.lCargadoTabPropuesta = true;
                this.conPropuesta.AsignarDatos(this.objPropCredito);
            }*/
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredPyme"]);

            FrmBuscarEv formBuscarEvPyme = new FrmBuscarEv(cIDsTipEvalCredPyme, "Buscar Evaluaciones Pyme");
            formBuscarEvPyme.ShowDialog();

            if (formBuscarEvPyme.idCli != 0 && formBuscarEvPyme.idEvalCred != 0)
            {
                this.txtNroDoc.Text = formBuscarEvPyme.cNroDocumento;
                this.txtNombre.Text = formBuscarEvPyme.cNombreCliente;

                (new clsCNSolicitud()).actualizarMontosSolRefi(formBuscarEvPyme.idSolicitud);
                RecuperarDatos(formBuscarEvPyme.idEvalCred);
                RecuperarDetalleEstRes(formBuscarEvPyme.idEvalCred);

                if (this.objEvalCred.lEditar == true)
                {
                    TituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
                    HabilitarBotonesSegunModo(clsAcciones.BUSCAR);
                }
                else
                {
                    TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                }
            }

            formBuscarEvPyme.Close();
            formBuscarEvPyme.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredPyme"]);
            string cIDsSectorEconPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPyme"]);
            string cNombreFormulario = this.Name;

            frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDsTipEvalCredPyme, cIDsSectorEconPyme, 0, "Nueva Evaluación Pyme", false);
            nuevaEv.RecuperarNombreFormulario(cNombreFormulario);
            nuevaEv.ShowDialog();

            if (nuevaEv.idCli != 0 && nuevaEv.idEvalCred != 0)
            {
                this.txtNroDoc.Text = nuevaEv.cNroDocumento;
                this.txtNombre.Text = nuevaEv.cNombreCliente;

                RecuperarDatos(nuevaEv.idEvalCred);
                RecuperarDetalleEstRes(nuevaEv.idEvalCred);

                HabilitarBotonesSegunModo(clsAcciones.NUEVO);

                TituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
            }

            nuevaEv.Close();
            nuevaEv.Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser("lResolCom"))
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            var oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();
            //TODO: SolTechnologies - 23.Validaciones del Porspecto Nuevo No Bancarizado

            DataTable dtexiste = new clsCNMotorDecision().ValidaExistenciaMNB(oEvalCredTemp.idSolicitud);

            if (dtexiste.Rows.Count > 0)
            {
                //Tercera Validacion del MNB
                clsVarGen nMontoDecisionEngineMax = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecisionMax"));
                decimal montoParametrisableMax = Convert.ToDecimal(nMontoDecisionEngineMax.cValVar);
                decimal montoSolic = oEvalCredTemp.nCapitalPropuesto;
                if (montoSolic > montoParametrisableMax)
                {
                    MessageBox.Show("El monto del Modelo no Bancarizado no debe exceder los S/." + montoParametrisableMax, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            this.objEvalCred.dFecUltimaEval = this.conEstadosFinancieros.UltimaFechaEvaluacion();

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

            // -- Convertir a XML
            string xmlEvalCred = this.EvalCredToXML();
            string xmlEvalCualit = this.EvalCualitativaCredToXML();
            string xmlReferencias = this.ReferenciasToXML();
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();
            string xmlDestCredProp = this.DestCredPropToXML();
            string xmlRcc = this.conCondiCredito.RccToXML(this.objEvalCred.idEvalCred);
            string xmlIndicadorEval = IndicadoresToXML();

            int nMuestraFrm = 0;
            
            CargarConfiguracionSeguro(nMuestraFrm);

            DataTable td = this.objCapaNegocio.ActualizarEval(this.objEvalCred.idEvalCred,
                        xmlEvalCred,
                        xmlEvalCualit,
                        xmlReferencias,
                        xmlBalGenEval,
                        xmlEstResEval,
                        xmlDestCredProp,
                        xmlRcc,
                        xmlIndicadorEval
            );

            if (td.Rows.Count > 0)
            {
                DataRow drResult = td.Rows[0];

                if (drResult["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(drResult["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RecuperarEvalCredito();

                    HabilitarBotonesSegunModo(clsAcciones.GRABAR);
                }
            }

            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            ValidarReglas(false, aReglasEvaluadas);

            //TODO: SolTechnologies - 24.Evaluacion PYME
            #region MNB - Motor de decisiones
            int idEval = Convert.ToInt32(txtIdEvalCred.Text);
            int idCli = Convert.ToInt32(oEvalCredTemp.idCli);

            DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(this.objEvalCred.idSolicitud);


            if (this.lEsMNB && existe.Rows.Count > 0)
            {
                //Actualiza el monto y plazo que ingresa al Motor de decisiones 
                decimal monto = Convert.ToDecimal(oEvalCredTemp.nCapitalPropuesto);
                int nuevoPlazoCuota = oEvalCredTemp.nPlazoCuota;
                int nuevoCuotas = oEvalCredTemp.nCuotas;
                int nuevoIdPeriodo = oEvalCredTemp.idTipoPeriodo;
                int nuevoPlazo = (nuevoIdPeriodo == 1) ? 30 * nuevoCuotas : nuevoPlazoCuota * nuevoCuotas;

                clsVarGen nMontoDecisionEngine = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecision"));
                decimal montoParametrisable = Convert.ToDecimal(nMontoDecisionEngine.cValVar);

                bool migra = monto < montoParametrisable ? true : false;

                var motorDecision = new clsMotorDecision();
                var respuestaMNB = motorDecision.CallMotorDecisionEvaluacion(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, this.Name);

                if (respuestaMNB == null)
                    MessageBox.Show("No se ha podido establecer conexión con el Motor de decisiones", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                motorDecision.MensajesPorExcepcionesYRespuestaApi(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, aReglasEvaluadas, respuestaMNB);

                if (migra)
                {
                    MessageBox.Show("Debe pasar por un proceso de evaluacion resumida", "Motor de Decisión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    new clsCNMotorDecision().MigracionEvalMNB(idEval, "frmEvalResumenPreAprob");
                    this.Close();
                    this.Dispose();
                }
            }
            #endregion
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idCli > 0)
            {
                string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredPyme"]);
                string cIDsSectorEconPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPyme"]);

                frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDsTipEvalCredPyme, cIDsSectorEconPyme,
                                            this.objEvalCred.idCli, "Vinculación de Solicitud con Evaluación Nº " + this.objEvalCred.idEvalCred.ToString(), true);

                nuevaEv.InicializarValores(this.objEvalCred);
                nuevaEv.ShowDialog();

                this.objEvalCred.idSolicitud = nuevaEv.idSolicitud;
                this.objEvalCred.idProducto = nuevaEv.idProducto;
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;

                if (this.objEvalCred.idSolicitud > 0)
                    RecuperarDatos(this.objEvalCred.idEvalCred);

                nuevaEv.Close();
            }
        }

        //private void btnChecklist_Click(object sender, EventArgs e)
        //{
        //    //if (this.objEvalCred.idSolicitud == 0)
        //    //{
        //    //    MessageBox.Show("No hay una solicitud de crédito vinculada a esta evaluación", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return;
        //    //}

        //    //frmListaDocObligatoriosCre frmListaDocObligatoriosCre = new frmListaDocObligatoriosCre(
        //    //    this.objEvalCred.idTipoPersona, this.objEvalCred.idProducto, this.objEvalCred.idSolicitud);

        //    //frmListaDocObligatoriosCre.ShowDialog();
        //    //frmListaDocObligatoriosCre.Dispose();
        //}

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            clsMsjError objMsjError = Validar();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!this.ValidarReglas(true))
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
            if (!ValidarIndicadorObser("lResolCom"))
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            clsMsjError objMsjError = Validar();

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

            if (!ValidarReglas(true)) return;
            if (this.invocarExcepciones(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //TODO: SolTechnologies - 22.Se verifica el flujo de aprobacion de la solicitd del MNB
            DataTable existe = new clsCNMotorDecision().ValidaExistenciaMNB(this.objEvalCred.idSolicitud);
            if (existe.Rows.Count > 0)
            {
                DataTable dtScoreMNB = new clsCNMotorDecision().ListarScoreMNB(this.objEvalCred.idSolicitud);
                int resultadoScoreMNB = 0;

                if (dtScoreMNB.Rows.Count > 0)
                    resultadoScoreMNB = Convert.ToInt32(dtScoreMNB.Rows[0]["idPrediccion"]);

                if (resultadoScoreMNB == 1) //Aceptado
                {
                    clsRespuestaServidor objRespuesta = new clsCNExcepcionesCreditos().validarAprobExcepcioneReglaNeg(this.objEvalCred.idSolicitud);
                    if (objRespuesta.idResultado == ResultadoServidor.Error)
                    {
                        MessageBox.Show(objRespuesta.cMensaje, "ALERTA DE EXCEPCIÓN DE REGLA CREDITICIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!this.revisarAlertaVariable()) return;

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
                    }

                    /*  Guardar Expedientes - Evaluacion de Credito  */
                    bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                    if (!lRespuesta)
                        return;

                    // ------------------------------------------------------------------------

                    oEvalCredTemp.idOrigenCredProp = 2;
                    oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                    oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                    oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                    oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                    string xmlDestCredProp = oEvalCredTemp.GetXml();

                    DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditos(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    this.objCapaNegocio.GuardarHistoricoBalGenEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
                    this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                    new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanalAproCredTemp);

                    string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                    int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                    if (idMsj == 1)
                    {
                        this.objCNAprobacionCredito.InicializarAprobacionEvalCred(this.objEvalCred.idEvalCred, 3265, 224, clsVarGlobal.dFecSystem);
                        bool aprobCreAut = this.GestionarAprobacion();
                        if (!aprobCreAut)
                        {
                            return;
            }
                        DialogResult msg = MessageBox.Show("El Prospecto ha sido Aprobado por el Motor de decisiones.\n " +
                        "Debera continuar con el proceso de desembolso.", "¡Envio exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                        this.objEvalCred.lEstado = false;
                        TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    }
                    else
                    {
                        MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (resultadoScoreMNB == 2) //Excepcion
                {
                    if (!this.revisarAlertaVariable()) return;

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
                    }

                    /*  Guardar Expedientes - Evaluacion de Credito  */
                    bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Evaluacion de Credito", this.objEvalCred.idSolicitud, this);
                    if (!lRespuesta)
                        return;

                    // ------------------------------------------------------------------------

                    oEvalCredTemp.idOrigenCredProp = 2;
                    oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                    oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                    oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                    oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                    oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                    string xmlDestCredProp = oEvalCredTemp.GetXml();

                    DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditos(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    this.objCapaNegocio.GuardarHistoricoBalGenEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
                    this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                    new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanalAproCredTemp);

                    string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                    int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                    if (idMsj == 1)
                    {
                        DialogResult msg = MessageBox.Show("El Prospecto se encuentra en Excepción por el Motor de decisiones.\n " +
                        "Debe solicitar la Aprobacion del Jefe de Oficina.", "¡Envio exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                        this.objEvalCred.lEstado = false;
                        TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                    }
                    else
                    {
                        MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (resultadoScoreMNB == 3) //Rechazado
                {
                    DialogResult msg = MessageBox.Show("El prospecto se encuentra rechazado por el Motor de Decisiones, debera rechazar la solicitud.",
                    "Error de envio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult msg = MessageBox.Show("No se ha podido establecer conexion con el Motor de Decisiones.\n" +
                    "Comunicate con un administrador.", "Error de envio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {

            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a comité de Créditos?",
                "Enviar a Comité de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                if (!this.revisarAlertaVariable()) return;

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
                // ------------------------------------------------------------------------

                oEvalCredTemp.idOrigenCredProp = 2;
                oEvalCredTemp.idSolicitud = this.objEvalCred.idSolicitud;
                oEvalCredTemp.cComentarios = "PROPUESTA DE EVALUACIÓN";

                oEvalCredTemp.nActivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalActivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPasivo = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPasivo).Sum(x => x.nTotalMA);
                oEvalCredTemp.nInventario = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
                oEvalCredTemp.nPatrimonio = this.listBalGenEval.Where(x => x.idEEFF == EEFF.TotalPatrimonio).Sum(x => x.nTotalMA);

                oEvalCredTemp.nCostos = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDeudas = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
                oEvalCredTemp.nNeto = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);
                oEvalCredTemp.nDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);

                string xmlDestCredProp = oEvalCredTemp.GetXml();

                DataTable dtEnvCom = objCapaNegocio.EnviarAComiteCreditos(this.objEvalCred.idEvalCred,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    xmlDestCredProp,
                    idCanal,
                    lCanalAproCredEditable
                );

                this.objCapaNegocio.GuardarHistoricoBalGenEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
                this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                string cMsj = dtEnvCom.Rows[0]["cMensaje"].ToString();
                int idMsj = Convert.ToInt32(dtEnvCom.Rows[0]["nResultado"]);

                if (idMsj == 1)
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarBotonesSegunModo(clsAcciones.ENVIAR);
                    this.objEvalCred.lEstado = false;

                    TituloForm(this.objEvalCred.cTipEvalCred, "Sólo lectura");
                }
                else
                {
                    MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        }

        private bool GestionarAprobacion()
        {
            bool flagcheck = false;
            clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();

            DialogResult resMensaje = MessageBox.Show(
                  "Acepto las condiciones anteriormente descritas,\n"
                + "declaro  y  aseguro   que   esta  propuesta  de\n"
                + "crédito   cumple  con   todos  los  requisitos,\n"
                + "documentación,  verificación  y  evaluación que\n"
                + "corresponde  según  las normativas  internas de\n"
                + "créditos  de  la  empresa.   Asimismo,  declaro\n"
                + "conocer  que  toda  vulneración  a  los  puntos\n"
                + "anteriores, constituye en una infracción sujeta\n"
                + "a sanción  disciplinaria  según  el  reglamento\n"
                + "interno    de   la   empresa   e  inclusive  de\n"
                + "comprobarse la falsedad en lo declarado, conoce\n"
                + "que  corresponde a  la  empresa promover acción\n"
                + "civil (laboral) y/o penal por  el delito contra\n"
                + "la  Fe  Pública  previsto  en el vigente Código\n"
                + "Penal.", "APROBACIÓN DE CRÉDITO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resMensaje == DialogResult.No)
            {
                return flagcheck;
            }

            DataTable dtGes = new clsCNAprobacionCredito().GestionarAprobacion(this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred, clsVarGlobal.nIdAgencia, oEvalCredTemp.nMonto, true); //Aprobacion automatica
            List<clsAprobacionCredito> objAproCred = new List<clsAprobacionCredito>();
            objAproCred = DataTableToList.ConvertTo<clsAprobacionCredito>(dtGes) as List<clsAprobacionCredito>;

            if (objAproCred[0].idError == 0)
            {
                DialogResult dlres = MessageBox.Show("" + objAproCred[0].cMensaje, "Aprobacion en proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlres == DialogResult.Yes)
                {
                    new frmAprobacionCred().GuardarDecisionAprobador(objAproCred[0].idEstadoEvalCred, 4, objAproCred[0].idNivelAprobacion, objAproCred[0].lEnviaSolInfRiesgos, objAproCred[0].lRevision, this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred);
                    flagcheck = true;
                }
            }
            else if (objAproCred[0].idError == 1)
            {
                MessageBox.Show("" + objAproCred[0].cMensaje, "Error al intentar consultar aprobacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return flagcheck;
            }
            return flagcheck;
        }

        private void conEstadosFinancieros_DeudasClick(object sender, EventArgs e)
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

                this.objEvalCred.nTotalDeudas = this.objEstadosFinancieros.CDirectosTotalSaldoMA();
                this.objEvalCred.nTotalPasivoAC = this.objEstadosFinancieros.TotalPasivoAC();

                ActualizarEstadoResultados();
                ActualizarEstadosFinancieros();
            }

            frmdeudasFinanc.Dispose();
        }

        private void conEstadosFinancieros_BBGGClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            string cTipEval = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];

            frmDetalleBalGen formDetalleBalGen = new frmDetalleBalGen(this.listDescripcionEval, this.objEvalCred.idEvalCred,
                Evaluacion.TipoCambio, Evaluacion.idMoneda, Evaluacion.MonedaSimbolo, cTipEval);
            formDetalleBalGen.ShowDialog();

            lGuardado = formDetalleBalGen.lGuardado;

            if (lGuardado == true)
            {
                this.objEvalCred.nCajaInicial = formDetalleBalGen.CajaInicial();
                this.listInventario = formDetalleBalGen.ListaInventario();

                decimal nTotalMaqEquipos = formDetalleBalGen.TotalMaqEquipos();
                decimal nTotalHerramOtros = formDetalleBalGen.TotalHerramOtros();
                decimal nTotalInventario = formDetalleBalGen.TotalInventario();
                decimal nTotalInmuebles = formDetalleBalGen.TotalInmuebles();

                formDetalleBalGen.Dispose();

                foreach (clsBalGenEval item in this.listBalGenEval)
                {
                    if (item.idEEFF == EEFF.MaqEquipos) item.nTotalMA = nTotalMaqEquipos;
                    else if (item.idEEFF == EEFF.HerramOtros) item.nTotalMA = nTotalHerramOtros;
                    else if (item.idEEFF == EEFF.Inventario) item.nTotalMA = nTotalInventario;
                    else if (item.idEEFF == EEFF.Inmuebles) item.nTotalMA = nTotalInmuebles;
                }

                this.conEstadosFinancieros.ListBalanceGeneral = this.listBalGenEval;

                ActualizarEstadosFinancieros();
                this.objCapaNegocio.GuardarHistoricoBalGenEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
            }
        }

        private void conEstadosFinancieros_EERRClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            string cTipEval = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];

            frmDetalleEstRes formDetalleEstRes = new frmDetalleEstRes(this.listDescripcionEval, this.objEvalCred.idEvalCred,
                Evaluacion.TipoCambio, Evaluacion.idMoneda, Evaluacion.MonedaSimbolo, cTipEval, this.objEvalCred.idTipEvalCred, this.objEvalCred);
            formDetalleEstRes.ShowDialog();

            lGuardado = formDetalleEstRes.lGuardado;
            if (lGuardado == true)
            {
                this.objEstadosFinancieros.listVentasCostos = formDetalleEstRes.VentasCostos();
                this.objEstadosFinancieros.listGFamiliares = formDetalleEstRes.GFamiliares();
                this.objEstadosFinancieros.listGPersonales = formDetalleEstRes.GPersonales();
                this.objEstadosFinancieros.listGOperativos = formDetalleEstRes.GOperativos();
                this.objEstadosFinancieros.listOtrosEgresos = formDetalleEstRes.OtrosEgresos();
                this.objEstadosFinancieros.listOtrosIngresos = formDetalleEstRes.OtrosIngresos();

                ActualizarEstadoResultados();
                ActualizarEstadosFinancieros();
                this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
            }

            formDetalleEstRes.Dispose();
        }

        private void conCondiCredito_ActividadInternaSelectedIndexChanged(object sender, EventArgs e)
        {
            this.conPropuesta.ActualizarActividadInterna(this.conCondiCredito.ObtenerIdActividadInterna());
        }

        private void conCondiCredito_CuotaAproximadaChanged(object sender, EventArgs e)
        {
            int nPlazo = this.conCondiCredito.Plazo();
            Evaluacion.PlazoEval = 1;

            foreach (clsIndicadorEval oInd in this.listIndiFinanc)
            {
                if (oInd.nCodigo == 4) oInd.nValorMinimo = this.conCondiCredito.TEM();
            }

            this.conEstadosFinancieros.ActualizarPorIndPorMPropPorMAprox(this.listIndiFinanc, this.conCondiCredito.Monto(), this.conCondiCredito.CuotaAprox());
            ActualizarRcc();
        }

        private void conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged(object sender, EventArgs e)
        {
            decimal nDestinoCapitalTrabajo = this.conCondiCredito.MontoDestinadoParaCapitalTrabajo();
            this.conEstadosFinancieros.ActualizarPorDestinoCapitalTrabajo(nDestinoCapitalTrabajo);
        }

        private void conEvalCualitReferencias_EvalCualitativaCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var nPuntajeEvalCualitativa = this.conEvalCualitReferencias.TotalPuntaje();
            this.conEstadosFinancieros.ActualizarPuntajeEvalCualitativa(nPuntajeEvalCualitativa);
        }

        private void conEstadosFinancieros_CellValueChangedEstadosFinancieros(object sender, DataGridViewCellEventArgs e)
        {
            decimal nCapitalParacomercio = 0;
            this.conEstadosFinancieros.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, this.listInventario, this.objEvalCred.nTotalPasivoAC, nCapitalParacomercio);
            ActualizarRcc();
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

        private void conCondiCredito_SectorEconSelectedIndexChanged(object sender, EventArgs e)
        {
            clsEvalCred oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();
            this.objEvalCred.idSectorEcon = oEvalCredTemp.idSectorEcon;

            this.conEstadosFinancieros.ActualizarPorSectorEconomico(this.objEvalCred.idSectorEcon);
        }

        private void conCondiCredito_PlazoChanged(object sender, EventArgs e)
        {

        }

        private void conEvalCualitReferencias_ActualizarEvalCualitativoClick(object sender, EventArgs e)
        {
            List<clsEvalCualitativa> lstEvalCualitActualizado = this.objCapaNegocio.ActualizarEvalCualit(this.objEvalCred.idEvalCred);

            if (lstEvalCualitActualizado != null)
            {
                DialogResult dialogResult = MessageBox.Show("Se perderá los datos ingresados en la evaluación cualitativa.\n\n¿Desea continuar?", cMsjCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Se obtiene nuevamente todos los items de la eval. cualitativa
                    if (lstEvalCualitActualizado.Where(x => x.idEvalCualitativa == 0).Count() > 0)
                    {
                        this.listEvalCualitativa.Clear();
                        this.listEvalCualitativa.AddRange(lstEvalCualitActualizado);

                        conEvalCualitReferencias.ActualizarEvalCualitativo(lstEvalCualitActualizado);
                    }
                    else
                    {
                        foreach (clsEvalCualitativa objEvalCualit in this.listEvalCualitativa)
                        {
                            var objEvCua = lstEvalCualitActualizado.Where(x => x.idEvalCualitativa == objEvalCualit.idEvalCualitativa).SingleOrDefault();

                            if (objEvCua != null)
                                objEvalCualit.oPuntaje = objEvCua.nPuntaje;
                        } 

                        conEvalCualitReferencias.ActualizarEvalCualitativo();
                    }
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
        #endregion

        private void ActualizarEstadoResultados()
        {
            int nPlazo = this.conCondiCredito.Plazo();
            this.objEstadosFinancieros.ActualizarPlazo(nPlazo, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, this.objEvalCred.idTipEvalCred);

            //--------------------------------
            decimal nTotalVentas = this.objEstadosFinancieros.TotalVentasMA();
            decimal nTotalCostos = this.objEstadosFinancieros.TotalCostosMA();
            decimal nTotalGFamiliares = this.objEstadosFinancieros.TotalGFamiliaresMA();
            decimal nTotalGPersonales = this.objEstadosFinancieros.TotalGPersonalesMA();
            decimal nTotalGOperativos = this.objEstadosFinancieros.TotalGOperativosMA();
            decimal nTotalOtrosIngresos = this.objEstadosFinancieros.TotalOtrosIngresosMA();
            decimal nTotalOtrosEgresos = this.objEstadosFinancieros.TotalOtrosEgresosMA();
            decimal nGastosFinancieros = this.objEstadosFinancieros.TotalGFinancierosMA();

            decimal nTotalVentasMN = this.objEstadosFinancieros.TotalVentasMN();
            decimal nTotalCostosMN = this.objEstadosFinancieros.TotalCostosMN();
            decimal nTotalGFamiliaresMN = this.objEstadosFinancieros.TotalGFamiliaresMN();
            decimal nTotalGPersonalesMN = this.objEstadosFinancieros.TotalGPersonalesMN();
            decimal nTotalGOperativosMN = this.objEstadosFinancieros.TotalGOperativosMN();
            decimal nTotalOtrosIngresosMN = this.objEstadosFinancieros.TotalOtrosIngresosMN();
            decimal nTotalOtrosEgresosMN = this.objEstadosFinancieros.TotalOtrosEgresosMN();
            decimal nGastosFinancierosMN = this.objEstadosFinancieros.TotalGFinancierosMN();

            decimal nTotalVentasME = this.objEstadosFinancieros.TotalVentasME();
            decimal nTotalCostosME = this.objEstadosFinancieros.TotalCostosME();
            decimal nTotalGFamiliaresME = this.objEstadosFinancieros.TotalGFamiliaresME();
            decimal nTotalGPersonalesME = this.objEstadosFinancieros.TotalGPersonalesME();
            decimal nTotalGOperativosME = this.objEstadosFinancieros.TotalGOperativosME();
            decimal nTotalOtrosIngresosME = this.objEstadosFinancieros.TotalOtrosIngresosME();
            decimal nTotalOtrosEgresosME = this.objEstadosFinancieros.TotalOtrosEgresosME();
            decimal nGastosFinancierosME = this.objEstadosFinancieros.TotalGFinancierosME();

            //--------------------------------
            decimal nCDirectosTotalSaldoCortoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoCortoPlazoMA();
            decimal nCDirectosTotalSaldoLargoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoLargoPlazoMA();
            decimal nLargoPlazo = nCDirectosTotalSaldoLargoPlazo + this.objEstadosFinancieros.ProvicionCIndirectosMA();
            //--------------------------------

            foreach (clsEstResEval item in this.listEstResEval)
            {
                if (item.idEEFF == EEFF.VentasNetas)
                {
                    item.nTotalMA = nTotalVentas;
                    item.nTotalMN = nTotalVentasMN;
                    item.nTotalME = nTotalVentasME;
                }
                else if (item.idEEFF == EEFF.CostoVentas)
                {
                    item.nTotalMA = nTotalCostos;
                    item.nTotalMN = nTotalCostosMN;
                    item.nTotalME = nTotalCostosME;
                }
                else if (item.idEEFF == EEFF.GastosNegocio)
                {
                    item.nTotalMA = nTotalGOperativos + nTotalGPersonales;
                    item.nTotalMN = nTotalGOperativosMN + nTotalGPersonalesMN;
                    item.nTotalME = nTotalGOperativosME + nTotalGPersonalesME;
                }
                else if (item.idEEFF == EEFF.OtrosIngresos)
                {
                    item.nTotalMA = nTotalOtrosIngresos;
                    item.nTotalMN = nTotalOtrosIngresosMN;
                    item.nTotalME = nTotalOtrosIngresosME;
                }
                else if (item.idEEFF == EEFF.OtrosEgresos)
                {
                    item.nTotalMA = nTotalOtrosEgresos;
                    item.nTotalMN = nTotalOtrosEgresosMN;
                    item.nTotalME = nTotalOtrosEgresosME;
                }
                else if (item.idEEFF == EEFF.GastosFamiliares)
                {
                    item.nTotalMA = nTotalGFamiliares;
                    item.nTotalMN = nTotalGFamiliaresMN;
                    item.nTotalME = nTotalGFamiliaresME;
                }
                else if (item.idEEFF == EEFF.GastosFinancieros)
                {
                    item.nTotalMA = nGastosFinancieros;
                    item.nTotalMN = nGastosFinancierosMN;
                    item.nTotalME = nGastosFinancierosME;
                }
            }

            foreach (clsBalGenEval item in this.listBalGenEval)
            {
                if (item.idEEFF == EEFF.PrestamosCP) item.nTotalMA = nCDirectosTotalSaldoCortoPlazo;
                else if (item.idEEFF == EEFF.PrestamosLP) item.nTotalMA = nLargoPlazo;
            }

            this.conEstadosFinancieros.ListBalanceGeneral = this.listBalGenEval;
            this.conEstadosFinancieros.ListEstadoResultados = this.listEstResEval;

            this.conEstadosFinancieros.ActualizarIndicadores();
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

        private DataTable ArmarTablaParametros()
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

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = oEvalCredTemp.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = oEvalCredTemp.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool ValidarReglas(bool lMostrarAlerta, List<clsReglaNegocioEvaluada> aReglasEvaluadas = null)
        {
            string cNombreFormulario = this.Name;
            if (this.lEsMNB)
            {
                cNombreFormulario = "ReglasMNB_CredPyme";
            }

            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
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

        private void btnCopiado_Click(object sender, EventArgs e)
        {
            frmCopiarEval frmCopiarEval = new frmCopiarEval(this.objEvalCred, "Copiado de Evaluaciones");
            frmCopiarEval.ShowDialog();

            if (frmCopiarEval.lEjecutado == true)
            {
                RecuperarDatos(this.objEvalCred.idEvalCred);
                RecuperarDetalleEstRes(this.objEvalCred.idEvalCred);

                btnGrabar.PerformClick();

                MessageBox.Show("Evaluación recuperada correctamente.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void conEstadosFinancieros_EHZTLClick(object sender, EventArgs e)
        {
            frmBusHorizontal frmBusHorizontal = new frmBusHorizontal(this.objEvalCred.idCli, this.objEvalCred.idTipEvalCred, "Buscar Evalaución Horizontal");
            frmBusHorizontal.ShowDialog();

            if (frmBusHorizontal.listBalGenEval == null || frmBusHorizontal.listEstResEval == null) return;

            List<clsEstResEval> listEstResEvalHoriz = frmBusHorizontal.listEstResEval;
            List<clsBalGenEval> listBalGenEvalHoriz = frmBusHorizontal.listBalGenEval;

            decimal nTotal = 0;
            int nPlazoUltEval = (frmBusHorizontal.nPlazoUltEval == null || frmBusHorizontal.nPlazoUltEval <= 0 || Evaluacion.PlazoEval == 1) ? 1 : frmBusHorizontal.nPlazoUltEval;
            int nPlazoEvalAct = Evaluacion.PlazoEval;

            foreach (clsBalGenEval item in this.listBalGenEval)
            {
                nTotal = (from p in listBalGenEvalHoriz
                          where p.idEEFF == item.idEEFF
                          select p).ToList().Sum(x => x.nTotalMA);
                item.nTotalUltEvMA = nTotal;
            }

            this.conEstadosFinancieros.ListBalanceGeneral = this.listBalGenEval;

            foreach (clsEstResEval item in this.listEstResEval)
            {
                nTotal = (from p in listEstResEvalHoriz
                          where p.idEEFF == item.idEEFF
                          select p).ToList().Sum(x => x.nTotalMA);
                item.nTotalUltEvMA = Math.Round((nTotal / nPlazoUltEval) * nPlazoEvalAct, 2);
            }

            this.conEstadosFinancieros.ListEstadoResultados = this.listEstResEval;

            this.conEstadosFinancieros.ActualizarFechaUltEval(frmBusHorizontal.dFechaUltEval);
            //this.conEstadosFinancieros.Refresh();
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
            this.ValidarReglas(false, aReglasEvaluadas);
            this.invocarExcepciones(false);
            //TODO: SolTechnologies - 25.Muestra el resultado del score en el btn Excepcion
            int idSolicitud = this.objEvalCred.idSolicitud;
            var aReglasTruncantesFallidas = aReglasEvaluadas.FindAll(x => x.lResul == "NO" && x.lIndExcepcion == 0);
            if (aReglasTruncantesFallidas.Count > 0)
            {
                List<String> listExp = new List<String>();
                foreach (var item in aReglasTruncantesFallidas)
                {
                    listExp.Add(item.cMensajeError);
                }
                var _cMotivoRechazo = string.Join("\r\n", listExp);

                frmRespuestaMotor msjRespuesta = new frmRespuestaMotor(
                                                        3
                                                        , idSolicitud
                                                        , "Rechazado"
                                                        , DateTime.Now.ToString("hh:mm:ss tt")
                                                        , "Rechazado por reglas No Excepcionables."
                                                        , _cMotivoRechazo
                                                        );
                msjRespuesta.ShowDialog();

            }
            else
            {
                if (idSolicitud > 0)
                {
                    var dtscoreMNB = new clsCNMotorDecision().ValidaRestriccionesMNB(idSolicitud);
                    if (dtscoreMNB.Rows.Count > 0)
                    {
                        var ultimoScoreMNB = dtscoreMNB.Rows[0];
                        string hora = DateTime.Now.ToString("hh:mm:ss tt");
                        int idScoreMNB = Convert.ToInt32(dtscoreMNB.Rows[0]["idPrediccion"]);

                        DataTable _configuracionMotor = new clsCNMotorDecision().ListarConfiguracion();
                        if (_configuracionMotor.Rows.Count > 0)
                        {
                            string comentario = string.Empty;
                            foreach (DataRow item in _configuracionMotor.Rows)
                            {
                                if (Convert.ToInt32(item["idRespuesta"]) == idScoreMNB)
                                {
                                    comentario = item["Comentario"].ToString();
                                }
                            }

                            //comentario = comentario + "\r\n" + ultimoScoreMNB["CMotivoRechazo"].ToString();

                            frmRespuestaMotor msjRespuesta =
                            new frmRespuestaMotor(Convert.ToInt32(ultimoScoreMNB["idPrediccion"]),
                                                  idSolicitud,
                                                  ultimoScoreMNB["cResultadoModelo"].ToString().ToUpper(),
                                                  hora,
                                                  comentario,
                                                  "");
                            msjRespuesta.ShowDialog();

                            return;
                        }
                    }
                }
            }

        }

        private bool invocarExcepciones(bool lSilencioso)
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

            String cNombreForm = this.Name;
            if (this.lEsMNB) cNombreForm = "ReglasMNB_CredPyme";

            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, cNombreForm, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }
        
        private void CargarConfiguracionSeguro(int nMuestraFrm)
        {
            clsCreditoProp objDatos = new clsCreditoProp();
            objDatos = conCondiCredito.ObtenerCreditoPropuesto();
            int idSolicitud = this.objEvalCred.idSolicitud;
            int nParam = 1;

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
            frmGestObs.ConfigHabilitarFiltros(false, true, true, false);
            frmGestObs.ShowDialog();
        }

        private bool ValidarIndicadorObser(string cFiltro)
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.objSolicitud.idSolicitud, 3);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>(cFiltro));
        }

        private void boton1_Click(object sender, EventArgs e)
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
