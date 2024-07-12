#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Servicio;
using GEN.CapaNegocio;
using GEN.Funciones;

#endregion

namespace CRE.Presentacion
{
    public partial class frmEvalCrediJornal : frmBase
    {
        #region Variables Globales

        private string cMsjCaption = "Evaluación Tu Credi Chamba";

        private clsCNEvalCrediJornal objCapaNegocio;
        private CRE.CapaNegocio.clsCNCredito objCNCredito;
        private clsCNControlExp cnExp = new clsCNControlExp();

        private clsEvalCred objEvalCred;
        private ClsPropCreditoJornal objPropCredito = null;
        private List<clsEvalCualitativa> listEvalCualitativa;

        private List<clsReferenciaEval> listReferencia;

        private List<clsBalGenEval> listBalGenEval;

        private List<clsEstResEval> listEstResEval;

        private List<clsIndicadorEval> listIndiFinanc;

        private List<clsDestCredProp> listDestCredProp;

        private List<clsElemEvalCred> listElemEvalCred;
        private List<clsDescripcionEval> listDescripcionEval;
        private List<clsDetBalGenEval> listInventario;

        private clsCNEstadosFinancieros objEstadosFinancieros;

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
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        private enum eNuevosClientes
        {
            NueBancarizado = 8,
            NueNoBancarizado = 9
        }

        #endregion


        #region Constructores
        public frmEvalCrediJornal()
        {
            InitializeComponent();

            this.objCapaNegocio = new clsCNEvalCrediJornal();
            this.objEstadosFinancieros = new clsCNEstadosFinancieros();
            this.objCNCredito = new CRE.CapaNegocio.clsCNCredito();
            this.tabEval.Enabled = false;

            InicializarFormulario();
            HabilitarBotones(false);

            this.btnBusqueda.Enabled = true;
            this.btnNuevo.Enabled = true;
            this.lBalanceGeneral = false;
        }
        #endregion

        #region Metodos
        private void TituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación Tu Credi Chamba ({0})", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación Tu Credi Chamba ({0}) - {1}", cTipEvalCred, cMensaje);
        }

        private void RecuperarDatos(int idEvalCred)
        {
            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged -= new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged -= new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);

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
                    //btnAdministradorFiles.idSolicitud = this.objSolicitud.idSolicitud;
                    //btnAdministradorFiles.actualizarDatos();
                    //btnAdministradorFiles.Enabled = true;
                    this.btnGestObs.Enabled = true;
                    btnVincularVisita.idSolicitud = this.objSolicitud.idSolicitud;
                    btnVincularVisita.idCli = this.objEvalCred.idCli;
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
            this.listBalGenEval = new List<clsBalGenEval>();

            //-- Table[5] : Estado de Resultados
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsResult.Tables[5]) as List<clsEstResEval>;

            //-- Table[6] : Indicadores Financieros
            this.listIndiFinanc = DataTableToList.ConvertTo<clsIndicadorEval>(dsResult.Tables[6]) as List<clsIndicadorEval>;
            var listIndiFinancCamEC = this.listIndiFinanc;
            this.listIndiFinanc = this.listIndiFinanc.FindAll(x => x.nCodigo != IFN.EndeudamientoTotal);

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

            if (ValidaCampaniaEstamosContigo())
            {
                decimal nMontoParametro = decimal.Zero;
                if ((new int[] { (int)eNuevosClientes.NueNoBancarizado, (int)eNuevosClientes.NueBancarizado }).Contains(this.objSolicitud.idClasificacionInterna))
                    nMontoParametro = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoCamEstConNue"]);
                else
                    nMontoParametro = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoCamEstConReg"]);

                if (objSolicitud.nMonto > nMontoParametro)
                {
                    this.listBalGenEval = DataTableToList.ConvertTo<clsBalGenEval>(dsResult.Tables[4]) as List<clsBalGenEval>;
                    this.listIndiFinanc = listIndiFinancCamEC;
                }

                this.conEstadosFinancieros.ButtonEstadosResultados = false;
                this.conEstadosFinancieros.EERRCampaniaEstamosContigo();
            }

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

            this.objPropCredito = new ClsPropCreditoJornal();
            this.objPropCredito.oActPrincipal = objActPrincipal;
            this.objPropCredito.cComPropCliente = this.objEvalCred.cComPropCliente;
            this.objPropCredito.cComPropCredito = this.objEvalCred.cComPropCredito;

            #endregion

            #region Asignar a Componentes
            //-- Asignar Datos al formulario General
            this.txtIDEvalCred.Text = String.Format("{0:d8}", this.objEvalCred.idEvalCred);
            this.txtIDSolicitud.Text = (this.objEvalCred.idSolicitud != 0) ? String.Format("{0:d8}", this.objEvalCred.idSolicitud) : "";
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
                this.objEvalCred.idTipEvalCred, 0, 0, this.objEvalCred.idEvalCred, this.objEvalCred.idCli, this.objSolicitud.idDestino, this.objEvalCred.idProducto);

            this.conCondiCredito.AsignarDataTable(this.dtTipMoneda, this.dtTipPeriodo, this.dtTipDestCred, this.dtTipDestCredDetalle, this.dtSectorEconomico);
            this.conCondiCredito.AsignarDatos(this.objEvalCred, this.objSolicitud, this.listDestCredProp, this.listBalGenEval, this.listEstResEval);

            this.conPropuestaCrediJornal.AsignarDatos(this.objPropCredito);
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

                    if (elem.nCodigo == ElemEvalCred.DetalleDeudas)
                        this.conEstadosFinancieros.ButtonDeudas = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleBBGG)
                        this.conEstadosFinancieros.ButtonBalanceGeneral = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleEERR)
                        this.conEstadosFinancieros.ButtonEstadosResultados = false;

                    if (elem.nCodigo == ElemEvalCred.EntFamiliar)
                        this.conPropuestaCrediJornal.TxtDatosClienteEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.DesPrestamo)
                        this.conPropuestaCrediJornal.TxtDatosCreditoEnabled = false;

                }
            }
            #endregion

            this.conEvalCualitReferencias.EvalCualitativaCellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEvalCualitReferencias_EvalCualitativaCellValueChanged);
            this.conCondiCredito.ActividadInternaSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros += new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged += new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged += new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged += new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);

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
        }

        private void RecuperarDetalleEstRes(int idEvalCred)
        {
            DataSet ds = objCapaNegocio.RecuperarDetalleGeneralEstResultadosEval(idEvalCred);

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listJornalResumenIngreso = DataTableToList.ConvertTo<clsJornalResumenIng>(ds.Tables[6]) as List<clsJornalResumenIng>;
            var listJornalDetalleIngreso = DataTableToList.ConvertTo<clsJornalDetalleIng>(ds.Tables[7]) as List<clsJornalDetalleIng>;

            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[3]) as List<clsDeudasEval>;
            var listDeudaCuotaPago = DataTableToList.ConvertTo<clsCuotaPago>(ds.Tables[4]) as List<clsCuotaPago>;

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

            #region Detalle del Ingreso Jornal
            // Se asigna su costeo a sus ventas
            foreach (clsJornalResumenIng objResumenJornal in listJornalResumenIngreso)
            {
                objResumenJornal.lstDetalleIng = (from p in listJornalDetalleIngreso
                                                  where p.idEvalJornalResumenIng == objResumenJornal.idEvalJornalResumenIng
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

            this.objEstadosFinancieros.listJornalIngreso = listJornalResumenIngreso;
            this.objEstadosFinancieros.listGFamiliares = listGFamiliares;
            this.objEstadosFinancieros.listGPersonales = listGPersonales;
            this.objEstadosFinancieros.listGOperativos = listGOperativos;
            this.objEstadosFinancieros.listOtrosEgresos = listOtrosEgresos;
            this.objEstadosFinancieros.listOtrosIngresos = listOtrosIngresos;
            this.objEstadosFinancieros.listCredDirectos = listSalRCCDirectos;
            this.objEstadosFinancieros.listCredIndirect = listSalRCCDIndirec;
        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado;
            //this.btnAdministradorFiles.lectura = true;
            if (nModo == clsAcciones.EDITAR)
            {
                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                this.btnExcepciones.Enabled = false;
                //this.btnAdministradorFiles.lectura = false;
                this.btnValidar.Enabled = lHabilitado;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnHabilitarSeguro.Enabled = true;

                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnExcepciones.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnHabilitarSeguro.Enabled = false;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.ENVIAR)
            {
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.BUSCAR)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.tabEval.Enabled = true;

                lHabilitado = false;

                this.btnImprimir.Enabled = true;
                this.btnEnviar.Enabled = true;
                this.btnTasaN.Enabled = true;
                this.btnExcepciones.Enabled = true;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = true;
                this.btnCargaArhivos.Enabled = true;
                this.btnGrabar.Enabled = lHabilitado;

                this.btnEditar.Focus();

                HabilitarPaginas(false);
            }
            else if (nModo == clsAcciones.NUEVO)
            {
                this.btnVincular.Enabled = (this.objEvalCred.idSolicitud == 0) ? true : false;
                this.tabEval.Enabled = true;

                lHabilitado = true;

                this.btnImprimir.Enabled = false;
                this.btnEnviar.Enabled = false;
                this.btnTasaN.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.btnValidar.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;
                this.btnGrabar.Enabled = lHabilitado;
                this.btnHabilitarSeguro.Enabled = true;

                HabilitarPaginas(true);
            }
            else if (nModo == clsAcciones.DENEGAR)
            {
                lHabilitado = false;

                this.btnImprimir.Enabled = lHabilitado;
                this.btnEnviar.Enabled = lHabilitado;
                this.btnTasaN.Enabled = lHabilitado;
                this.btnExcepciones.Enabled = lHabilitado;
                this.btnValidar.Enabled = lHabilitado;
                this.btnVincular.Enabled = lHabilitado;
                this.btnBusqueda.Enabled = lHabilitado;
                this.btnNuevo.Enabled = lHabilitado;
                this.btnEditar.Enabled = lHabilitado;
                this.btnCargaArhivos.Enabled = lHabilitado;
                this.btnGrabar.Enabled = lHabilitado;

                HabilitarPaginas(false);
            }
        }

        private void HabilitarPaginas(bool lHabilitado)
        {
            this.conEvalCualitReferencias.Enabled = lHabilitado;
            this.conEstadosFinancieros.Enabled = lHabilitado;
            this.conCondiCredito.Enabled = (this.objEvalCred.idSolicitud > 0) ? lHabilitado : false;
            this.conPropuestaCrediJornal.Enabled = lHabilitado;
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

            this.conCondiCredito.ActualizarRcc(nIngresosMN, nIngresosME, nEgresosMN, nEgresosME, nCuotaAprox,
                (nDeudasEntFinanMN + nDeudasEntFinanME * this.objEvalCred.nTipoCambio));
        }

        private void InicializarFormulario()
        {
            #region Recuperar Datos por default
            DataSet dsResult = this.objCapaNegocio.InicializarCrediJornal();

            //-- Table[0] : Tipos de Moneda
            this.dtTipMoneda = dsResult.Tables[0];

            //-- Table[1] : Tipos de Periodos
            this.dtTipPeriodo = dsResult.Tables[1];

            //-- Table[2] : Tipos de Sector Económico
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

        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnTasaN.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;
            this.btnBusqueda.Enabled = lHabilitado;
            this.btnNuevo.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser("lResolCom"))
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            var oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();
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
            ClsPropCreditoJornal objPropCredito = this.conPropuestaCrediJornal.ObtenerDatos();
            clsActividadEconomica oActPrin = objPropCredito.oActPrincipal;

            this.objEvalCred.idActividadInternaPri = oActPrin.idActividadInterna;
            this.objEvalCred.idTipoActividadPri = oActPrin.idTipoActividad;
            this.objEvalCred.nActPriAnios = oActPrin.nAnios;
            this.objEvalCred.cActPriDireccion = oActPrin.cDireccion;
            this.objEvalCred.cActPriReferencia = oActPrin.cReferencia;
            this.objEvalCred.cActPriDescripcion = oActPrin.cDescripcion;

            this.objEvalCred.cComPropCliente = objPropCredito.cComPropCliente;
            this.objEvalCred.cComPropCredito = objPropCredito.cComPropCredito;

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

            ValidarReglas(false);
        }

        private string EvalCredToXML()
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

            dt.Columns.Add("cComPropCliente", typeof(string));
            dt.Columns.Add("cComPropCredito", typeof(string));

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
            row["dFecUltimaEval"] = this.objEvalCred.dFecUltimaEval;
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
            row["cComPropCliente"] = this.objEvalCred.cComPropCliente;
            row["cComPropCredito"] = this.objEvalCred.cComPropCredito;

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

        private bool ValidarReglas(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametros,
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
                                                                            idRegistroExcep: this.objSolicitud.idSolicitud);
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
            drfila[0] = "nDiasGracia";
            drfila[1] = this.conCondiCredito.DiasGracia();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.conCondiCredito.TipoPeriodo();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoSinGracia";
            drfila[1] = this.conCondiCredito.Plazo();
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
            drfila[0] = "frecuencia";
            drfila[1] = oEvalCredTemp.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
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
            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, this.Name, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
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
            decimal nGastosFamiliaresTotal = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosJrnlFamiliares).Sum(x => x.nTotalMA);



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

            if (nUDisponible < 0)
                objMsjError.AddError("Estados Financ.: Utilidad Disponible es un valor NEGATIVO.");

            if (nGastosFamiliaresTotal == decimal.Zero)
                objMsjError.AddError("Estados Financ.: Los Gastos Familiares están en CERO.");

            #endregion

            #region Condiciones del Crédito
            var objCondiCreditoMsjError = this.conCondiCredito.Validar();
            if (objCondiCreditoMsjError.HasErrors)
            {
                foreach (var err in objCondiCreditoMsjError.GetListError())
                    objMsjError.AddError("Cond. Crédito: " + err);
            }
            #endregion

            #region Propuesta de Crédito
            var objPropuestaMsjError = this.conPropuestaCrediJornal.Validar();
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

            //if (!btnAdministradorFiles.obligatoriosCompletos())
            //{
            //    objMsjError.AddError(btnAdministradorFiles.msgObligatorios);
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

            if (nCapacidad > 80)
            {
                objMsjError.AddError("Capacidad de Pago:  El indicador capacidad de pago debe ser menor o igual al 80%.");
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

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idCli > 0)
            {
                string cIDsTipEvalCredJornal = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredJornal"]);
                string cIDsSectorEconJornal = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconJornal"]);

                frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDsTipEvalCredJornal, cIDsSectorEconJornal,
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

        private bool revisarAlertaVariable()
        {
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = this.conEstadosFinancieros.listarAlertaVariable(this.objEvalCred.idSolicitud, this.objEvalCred.idSectorEcon);


            clsCNAlertaVariable objCNAlertaVariable = new clsCNAlertaVariable();
            List<clsEvalCredAlertaVariable> lstEvalCredAlertaAnterior = objCNAlertaVariable.listarEvalCredAlertaVariable(this.objEvalCred.idEvalCred);

            if (lstEvalCredAlertaAnterior.Count > 0)
            {
                Dictionary<int, clsEvalCredAlertaVariable> dctEvalCredAlerta = lstEvalCredAlerta.ToDictionary(x => x.idAlertaVariable);
                foreach (clsEvalCredAlertaVariable objAlerta in lstEvalCredAlertaAnterior)
                {
                    dctEvalCredAlerta[objAlerta.idAlertaVariable] = objAlerta;
                }

                lstEvalCredAlerta.Clear();
                lstEvalCredAlerta = dctEvalCredAlerta.Values.ToList();
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
                frmEvalCredAlertaVariable objFrmEvalCredAlertaVariable = new frmEvalCredAlertaVariable(lstEvalCredAlerta);
                objFrmEvalCredAlertaVariable.ShowDialog();
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

        private void ActualizarEstadoResultados()
        {
            int nPlazo = this.conCondiCredito.Plazo();
            this.objEstadosFinancieros.ActualizarPlazo(nPlazo, this.objEvalCred.nTipoCambio, this.objEvalCred.idMoneda, this.objEvalCred.idTipEvalCred);

            //--------------------------------
            decimal nTotalIngresoTitular = this.objEstadosFinancieros.TotalIngJornalTitularMN();
            decimal nTotalIngresoConyuge = this.objEstadosFinancieros.TotalIngJornalConyugeMN();
            decimal nTotalGFamiliares = this.objEstadosFinancieros.TotalGFamiliaresMA();
            decimal nGastosFinancieros = this.objEstadosFinancieros.TotalGFinancierosMA();

            decimal nTotalIngresoTitularMN = this.objEstadosFinancieros.TotalIngJornalTitularMN();
            decimal nTotalIngresoConyugeMN = this.objEstadosFinancieros.TotalIngJornalConyugeMN();
            decimal nTotalGFamiliaresMN = this.objEstadosFinancieros.TotalGFamiliaresMN();
            decimal nGastosFinancierosMN = this.objEstadosFinancieros.TotalGFinancierosMN();

            decimal nTotalIngresoConyugeME = 0;
            decimal nTotalIngresoTitularME = 0;
            decimal nTotalGFamiliaresME = this.objEstadosFinancieros.TotalGFamiliaresME();
            decimal nGastosFinancierosME = this.objEstadosFinancieros.TotalGFinancierosME();

            //--------------------------------
            decimal nCDirectosTotalSaldoCortoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoCortoPlazoMA();
            decimal nCDirectosTotalSaldoLargoPlazo = this.objEstadosFinancieros.CDirectosTotalSaldoLargoPlazoMA();
            decimal nLargoPlazo = nCDirectosTotalSaldoLargoPlazo + this.objEstadosFinancieros.ProvicionCIndirectosMA();
            //--------------------------------

            foreach (clsEstResEval item in this.listEstResEval)
            {
                if (item.idEEFF == EEFF.IngresoJrnlTitular)
                {
                    item.nTotalMA = nTotalIngresoTitular;
                    item.nTotalMN = nTotalIngresoTitularMN;
                    item.nTotalME = nTotalIngresoTitularME;
                }
                else if (item.idEEFF == EEFF.IngresoJrnlCónyuge)
                {
                    item.nTotalMA = nTotalIngresoConyuge;
                    item.nTotalMN = nTotalIngresoConyugeMN;
                    item.nTotalME = nTotalIngresoConyugeME;
                }
                else if (item.idEEFF == EEFF.GastosJrnlFamiliares)
                {
                    item.nTotalMA = nTotalGFamiliares;
                    item.nTotalMN = nTotalGFamiliaresMN;
                    item.nTotalME = nTotalGFamiliaresME;
                }
                else if (item.idEEFF == EEFF.GastosJrnlFinancieros)
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

        private void ActualizarEstadosFinancieros()
        {
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();

            DataTable td = this.objCapaNegocio.ActEstFinancieroslEval(this.objEvalCred.idEvalCred, xmlBalGenEval, xmlEstResEval);
        }

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
            objSolicitudCreditoSeguroActual.dFechaPrimeraCuota = objDatos.dFechaPrimeraCuota;
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

        private bool ValidaCampaniaEstamosContigo()
        {
            string cProductosEstamosContigo = clsVarApl.dicVarGen["nSubProductoCamEstCon"];
            String[] cProdCampania = cProductosEstamosContigo.Split(',');
            int[] nProdCampania = Array.ConvertAll<string, int>(cProdCampania, int.Parse);

            if (nProdCampania.Contains(this.objSolicitud.idProducto))
                return true;
            else
                return false;
        }

        #endregion

        #region Eventos
        private void frmEvalCrediJornal_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCredJornal = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredJornal"]);
            string cIDsSectorEconJornal = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconJornal"]);
            string cNombreFormulario = this.Name;

            frmNuevaEvPyme nuevaEv = new frmNuevaEvPyme(cIDsTipEvalCredJornal, cIDsSectorEconJornal, 0, "Nueva Evaluación Tu Credi Chamba", false);
            nuevaEv.RecuperarNombreFormulario(cNombreFormulario);
            nuevaEv.ShowDialog();

            if (nuevaEv.idCli != 0 && nuevaEv.idEvalCred != 0)
            {
                this.txtDocumentoID.Text = nuevaEv.cNroDocumento;
                this.txtNombre.Text = nuevaEv.cNombreCliente;

                RecuperarDatos(nuevaEv.idEvalCred);
                RecuperarDetalleEstRes(nuevaEv.idEvalCred);

                HabilitarBotonesSegunModo(clsAcciones.NUEVO);

                TituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
            }

            nuevaEv.Close();
            nuevaEv.Dispose();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cIDsTipEvalCredJornal = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredJornal"]);

            FrmBuscarEv frmBuscarEvJornal = new FrmBuscarEv(cIDsTipEvalCredJornal, "Buscar Evaluaciones Tu Credi Chamba");
            frmBuscarEvJornal.ShowDialog();

            if (frmBuscarEvJornal.idCli != 0 && frmBuscarEvJornal.idEvalCred != 0)
            {
                this.txtDocumentoID.Text = frmBuscarEvJornal.cNroDocumento;
                this.txtNombre.Text = frmBuscarEvJornal.cNombreCliente;

                (new clsCNSolicitud()).actualizarMontosSolRefi(frmBuscarEvJornal.idSolicitud);
                RecuperarDatos(frmBuscarEvJornal.idEvalCred);
                RecuperarDetalleEstRes(frmBuscarEvJornal.idEvalCred);

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

            frmBuscarEvJornal.Close();
            frmBuscarEvJornal.Dispose();
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

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objEvalCred.idSolicitud, !this.objEvalCred.lEditar);
                frmCargaArchivo.ShowDialog();
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

            bool lCamEstCon = ValidaCampaniaEstamosContigo();

            string msgAlerta = (lCamEstCon) ? "La evaluación se enviará por comite extraordinario. ¿Desea continuar?" :
                "¿Seguro que deseas enviar a comité de Créditos?";


            DialogResult dg = MessageBox.Show(msgAlerta, "Enviar a Comité de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
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

                    if (lCanalAproCredEditable == 1)
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

                string cProductos = Convert.ToString(clsVarApl.dicVarGen["cProductoModAprobAutomatico"]);
                List<int> lstProductosPermitidos = cProductos.Split(',').Select(Int32.Parse).ToList();

                DataTable dtEnvCom = new DataTable();
                if (lstProductosPermitidos.Any(item => item == objEvalCred.idProducto))
                {
                    dtEnvCom = (new GEN.CapaNegocio.clsCNSolicitud()).CNGuardarModeloScoring(objEvalCred.idEvalCred, objEvalCred.idSolicitud);
                }
                else
                {
                    dtEnvCom = objCapaNegocio.EnviarAComiteCreditos(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );
                }

                if (lCamEstCon && this.listBalGenEval.Count > 0)
                    this.objCapaNegocio.GuardarHistoricoBalGenEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                //new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanalAproCredTemp);

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

        private void conCondiCredito_ActividadInternaSelectedIndexChanged(object sender, EventArgs e)
        {
            this.conPropuestaCrediJornal.ActualizarActividadInterna(this.conCondiCredito.ObtenerIdActividadInterna());
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

        private void conCondiCredito_SectorEconSelectedIndexChanged(object sender, EventArgs e)
        {
            clsEvalCred oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();
            this.objEvalCred.idSectorEcon = oEvalCredTemp.idSectorEcon;

            this.conEstadosFinancieros.ActualizarPorSectorEconomico(this.objEvalCred.idSectorEcon);
        }

        private void conEstadosFinancieros_CellValueChangedEstadosFinancieros(object sender, DataGridViewCellEventArgs e)
        {
            decimal nCapitalParacomercio = 0;
            this.conEstadosFinancieros.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, this.listInventario, this.objEvalCred.nTotalPasivoAC, nCapitalParacomercio);
            ActualizarRcc();
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

        private void conEstadosFinancieros_EERRClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            string cTipEval = clsVarApl.dicVarGen["cIDsTipEvalCredJornal"];

            frmDetalleEstResCrediJornal frmDetalleEstResJornal = new frmDetalleEstResCrediJornal(this.listDescripcionEval, this.objEvalCred.idEvalCred,
                Evaluacion.TipoCambio, Evaluacion.idMoneda, Evaluacion.MonedaSimbolo, cTipEval, this.objEvalCred.idTipEvalCred, this.objEvalCred);
            frmDetalleEstResJornal.ShowDialog();

            lGuardado = frmDetalleEstResJornal.lGuardado;
            if (lGuardado == true)
            {
                this.objEstadosFinancieros.listJornalIngreso = frmDetalleEstResJornal.IngresoJornal();
                this.objEstadosFinancieros.listGFamiliares = frmDetalleEstResJornal.GFamiliares();

                ActualizarEstadoResultados();
                ActualizarEstadosFinancieros();
                this.objCapaNegocio.GuardarHistoricoEstResEval(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
            }

            frmDetalleEstResJornal.Dispose();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            clsMsjError objMsjError = Validar();

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

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            this.ValidarReglas(false);
            this.invocarExcepciones(false);
        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            int nMuestraFrm = 1;
            CargarConfiguracionSeguro(nMuestraFrm);
        }
        #endregion


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
            if (txtIDSolicitud.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar una solicitud de crédito válido.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTasaNegociable frm = new frmTasaNegociable();
            frm.flowLayoutPanel2.Visible = false;
            frm.grbDato_Solicitud.Visible = false;
            frm.Size = new System.Drawing.Size(705, 500);
            frm.lTasafrm = true;
            frm.BuscarSolicitud(Convert.ToInt32(txtIDSolicitud.Text));
            if (frm.lTasaNegociada == true)
            {
                frm.idSolicitud_frm = Convert.ToInt32(txtIDSolicitud.Text);
                frm.ShowDialog();
            }
        }
    }
}


