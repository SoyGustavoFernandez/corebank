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
using GEN.Funciones;
using GEN.CapaNegocio;
using GEN.Servicio;
using EntityLayer.MotorDecisionWebService;
#endregion 


namespace CRE.Presentacion
{
    public partial class frmEvalCredFacilito : frmBase
    {
        #region Variables Globales
        clsCliente objCliente = new clsCliente();
        clsSolicitudCredSimp objSolicitudSimp = new clsSolicitudCredSimp();
        private int idSolicitud { get; set; }
         

        private string cMsjCaption = "Evaluación de Crédito Facilito";

        private clsCNEvalCredSimp objCapaNegocio;
        private CRE.CapaNegocio.clsCNCredito objCNCredito;
        private clsCNControlExp cnExp = new clsCNControlExp();
        private clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
        private clsCNEvaluacion objCNEvaluacion = new clsCNEvaluacion();
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsEvalCred objEvalCred;
        private ClsPropSimpleCred objPropCredito = null;
        private List<clsEvalCualitativa> listEvalCualitativa;
        private List<clsReferenciaEval> listReferencia;
        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsDestCredProp> listDestCredProp;
        private List<clsElemEvalCred> listElemEvalCred;
        private List<clsDescripcionEval> listDescripcionEval;
        private List<clsDetBalGenEval> listInventario;
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();

        private clsCNEstadosFinancieros objEstadosFinancieros;

        private DataTable dtTipMoneda;
        private DataTable dtTipPeriodo;
        private DataTable dtSectorEconomico;
        private DataTable dtTipReferEval;
        private DataTable dtTipVinculoEval;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private DateTime dFechaBase;

        private clsCreditoProp objSolicitud = new clsCreditoProp();
        private bool lBalanceGeneral;
        private int idCanal;

        private const int nAnioMinimo = 2000;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private List<clsTipoCicloMensual> lstTipoCMensual { get; set; }
        private List<clsDetalleSaldoInterviniente> lstDetalleSaldoInter { get; set; }
        private clsActividadEconomicaConfig objConfigActividadEcon { get; set; }

        private string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"]);
        private string cIDsSectorEconPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPYMEFacilito"]);


        List<clsCreditoProp> listCredSolicitado = new List<clsCreditoProp>();
        List<clsTipEvalCred> listTipEvalCred = new List<clsTipEvalCred>();
        List<clsProductoTipEval> listProdTipEval = new List<clsProductoTipEval>();
        private List<clsDeudasEval> listRCCSaldosDirectos = new List<clsDeudasEval>();
        private List<clsDeudasEval> listRCCSaldosIndirectos = new List<clsDeudasEval>();
        private List<clsDeudasEval> listCRACSaldos = new List<clsDeudasEval>();
        private List<clsDeudasEval> listEFinSaldos = new List<clsDeudasEval>();
        private decimal nTipoCambio = Evaluacion.TipoCambio;

        private int idEvalCred = 0;

        private List<clsProductoCredSimp> lstProductoEval { get; set; }

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();

        private bool lEsMNB;
        private List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();

        clsCNSeleccionarDocEvalAnterior objCNCargaArchivoDocEval = new clsCNSeleccionarDocEvalAnterior();

        #endregion

        #region Constructores
        public frmEvalCredFacilito()
        {
            InitializeComponent();

            InicializarComponentes();
            this.lBalanceGeneral = false;

        }
        #endregion

        #region Eventos
        private void conBusCliSimp_EventoPostBuscar(object sender, EventArgs e)
        {
            objCliente = conBusCliSimp.objCliente;

            if (objCliente.idCli == 0)
            {
                MessageBox.Show("No se encontró los Datos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (objCliente.lIndDatosBasic)
            {
                MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            conSolicitudSimp.AsignarCliente(objCliente);
            objSolicitudSimp = conSolicitudSimp.objSolicitud;
            conBusCliSimp.Enabled = false;

            if ((!lstProductoEval.Any(item => item.idSubProducto == objSolicitudSimp.idProducto)))
            {
                HabilitarBotonesSegunModo(clsAccionSol.SOL_DEFECTO);
                MessageBox.Show("El Producto de la Solicitud no esta permitido para el registro por este formulario.", "Registro Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (objSolicitudSimp.objProductoCredSimp.cSubProducto == "EFECTIVO AL INSTANTE")
            {
                if ((objCliente.idClasifInterna == 1 || objCliente.idClasifInterna == 2 || objCliente.idClasifInterna == 3) && objSolicitudSimp.nCapitalSolicitado <= 10000) { }
                else if (objSolicitudSimp.nCapitalSolicitado <= 5000) { }
                else
                {
                    HabilitarBotonesSegunModo(clsAccionSol.SOL_DEFECTO);
                    MessageBox.Show("El Monto de la Solicitud no esta permitido para el registro por este formulario.", "Registro Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataTable dtSolEstado = objCNSolicitud.SolicitudClienteEstado(objCliente.idCli, 1);

            if (objSolicitudSimp.idSolicitud != 0)
            {
                idSolicitud = Convert.ToInt32(dtSolEstado.Rows[0]["idSolicitud"]);
                conSolicitudSimp.CargarDatosSolicitud(idSolicitud);


                if (objSolicitudSimp.idEstado.In(13,19))
                {
                    CargarDatosEvaluacion();
                    HabilitarControlesEvaluacion(true);
                }
                else
                {
                    HabilitarBotonesSegunModo(clsAccionSol.SOL_RECUPERAR);
                    cargarDatosCompSolicitud();
                }
            }
            else
            {

                HabilitarBotonesSegunModo(clsAccionSol.SOL_NUEVO);
                conSolicitudSimp.AsignarDatosDefecto();
            }

            //-- Evaluar si pertenece al MNB
            this.lEsMNB = objCliente.idClasifInterna == 9 ? true : false;

        }

        private void btnCancelarSolicitud_Click(object sender, EventArgs e)
        {
            conBusCliSimp.limpiarControles();
            conBusCliSimp.Enabled = true;

            conSolicitudSimp.Enabled = false;
            conSolicitudSimp.Limpiar();
        }

        private void btnEnviarSolicitud_Click(object sender, EventArgs e)
        {
             if (!ValidarIndicadorObser())
             {
                MessageBox.Show("La solicitud debe estar en 'Resolución Completa' para pasar a la siguiente etapa.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

            if (this.invocarExcepciones(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            conSolicitudSimp.EnviarSolicitud();
            NuevaEvaluacion();
            objSolicitudSimp = conSolicitudSimp.objSolicitud;

            if (objSolicitudSimp.idEstado.In(13,19))
            {
                HabilitarControlesEvaluacion(true);
                HabilitarBotonesSegunModo(clsAccionSol.SOL_ENVIAR);
            }
            else
            {
                HabilitarBotonesSegunModo(clsAccionSol.SOL_RECUPERAR);
            }
        }

        private void btnGrabarSolicitud_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //TODO: SolTechnologies - 31.Validaciones del Porspecto Nuevo No Bancarizado

            //Obtiene parámetros para intentos rechazados
            clsVarGen valIntentosDia = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIntentosDia"));
            int nIntentosDia = Convert.ToInt32(valIntentosDia.cValVar);
            clsVarGen valIntentosMes = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIntentosMes"));
            int nIntentosMes = Convert.ToInt32(valIntentosMes.cValVar);

            int idCli = (conBusCliSimp.txtCodCli.Text != "") ? Convert.ToInt32(conBusCliSimp.txtCodCli.Text) : -1;
            bool lvalidaProspectoMNB = validaProspectoMNB(idCli);
            if (lvalidaProspectoMNB == true)
            {
                //Primera Validacion del MNB
                DataTable dtScoreMNBxMes = new clsCNMotorDecision().ListaScoroMNBxMes(idCli);
                if (dtScoreMNBxMes.Rows.Count >= nIntentosMes)
                {
                    MessageBox.Show("El prospecto no puede generar más de " + nIntentosMes + " solicitudes del motor al mes.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Segunda validacion: Intentos rechazados diarios
                DataTable dtScorexCli = new clsCNMotorDecision().BuscaScoreMNBxCliente(idCli);
                string dFechaHoy = clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd");
                string cExpresion = "dFechaP = '" + dFechaHoy + "' AND idPrediccion = 3";
                DataRow[] dtIntentosHoy = dtScorexCli.Select(cExpresion);
                if (dtIntentosHoy.Length >= nIntentosDia)
                {
                    MessageBox.Show("El prospecto no puede generar más de " + nIntentosDia + " solicitudes del motor por día.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Segunda Validacion del MNB
                TimeSpan? tRestante = TimeSpan.Zero;
                bool lRechazadoMNB = new clsMotorDecision().ValidaCliRechazadoMNB(idCli, out tRestante);

                if (lRechazadoMNB)
                {
                    string dias = (tRestante.HasValue) ? tRestante.Value.Days.ToString() : TimeSpan.Zero.Days.ToString();
                    MessageBox.Show("El prospecto no podra generar una nueva solicitud hasta dentro de " + dias + " dias.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Tercera Validacion del MNB
                clsVarGen nMontoDecisionEngineMax = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nMontoMotorDecisionMax"));
                decimal montoParametrisableMax = Convert.ToDecimal(nMontoDecisionEngineMax.cValVar);
                decimal montoSolic = Convert.ToDecimal(conSolicitudSimp.objSolicitud.nCapitalSolicitado);
                if (montoSolic > montoParametrisableMax)
                {
                    MessageBox.Show("El monto excede los S/." + montoParametrisableMax + " permitidos por el Motor de Decisiones del Modelo no bancarizado, la solicitud continuará por su flujo normal.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lvalidaProspectoMNB = false;
                }
            }

            clsMsjError objErrorSolicitud = conSolicitudSimp.GrabarSolicitud();

            if (objErrorSolicitud.HasErrors)
            {
                return;
            }
            else
            {
                objSolicitudSimp = conSolicitudSimp.objSolicitud;
                cargarDatosCompSolicitud();

                

                //TODO: SolTechnologies - 8.Iniciación del piloto con el modelo no bancarizado pyme-consumo 
                int idSol = (objSolicitudSimp.idSolicitud != 0) ? objSolicitudSimp.idSolicitud : -1;
                if (lvalidaProspectoMNB)
                {
                    //Actualiza el monto y plazo que ingresa al Motor de decisiones 
                    decimal monto = Convert.ToDecimal(objSolicitudSimp.nCapitalSolicitado);
                    int nuevoCuotas = objSolicitudSimp.nCuotas;
                    int nuevoPlazo = 30 * nuevoCuotas;

                    // Parametros del Motor de decisiones:
                    var motorDecision = new clsMotorDecision();
                    var respuestaMNB = motorDecision.CallMotorDecisionEvaluacion(idSol, monto, nuevoPlazo, false, this.Name);

                    if (respuestaMNB == null)
                    {
                        MessageBox.Show("No se ha podido establecer conexión con el Motor de decisiones.\n" +
                        "Si continua al proceso de evaluacion, el prospecto no sera parte del Modelo No Bancarizado.\n" +
                        "Si desea esperar al Motor de decisiones, comuniquese con un administrador", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        DialogResult dlres = MessageBox.Show("¿Desea continuar sin el Modelo No Bancarizado?", "Motor de decisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlres == DialogResult.No)
                        {
                            this.Close();
                            this.Dispose();
                            return;
                        }
                    }

                    motorDecision.MensajesPorExcepcionesYRespuestaApi(this.objEvalCred.idSolicitud, monto, nuevoPlazo, false, aReglasEvaluadas, respuestaMNB, false);

                }

                HabilitarBotonesSegunModo(clsAccionSol.SOL_GRABAR);
            }
        }

        private void btnEditarSolicitud_Click(object sender, EventArgs e)
        {
            conSolicitudSimp.EditarSolicitud();
            HabilitarBotonesSegunModo(clsAccionSol.SOL_EDITAR);
        }

        private void tabEval_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (objSolicitudSimp.idEstado.In(0, 1))
            {
                e.Cancel = true;
            }
        }

        private void conSolicitudSimp_EventoPostIntervinientes(object sender, EventArgs e)
        {
            if (idEvalCred != 0)
            {
                DataTable dtDetalleInterviniend = this.objCapaNegocio.CNRecuperarDetalleSaldoInterviniente(idEvalCred);
                this.lstDetalleSaldoInter = (dtDetalleInterviniend.Rows.Count > 0) ? DataTableToList.ConvertTo<clsDetalleSaldoInterviniente>(dtDetalleInterviniend) as List<clsDetalleSaldoInterviniente> : new List<clsDetalleSaldoInterviniente>();

                conDetalleSaldoInterviniente.AsignarDatos(lstDetalleSaldoInter);
                conDetalleSaldoInterviniente.Invalidate(true);
                conDetalleSaldoInterviniente.Update();
            }
        }

        private void conSolicitudSimp_EventoValidarReglas(object sender, EventArgs e)
        {

            clsSolicitudCredSimp objSolReglas = conSolicitudSimp.objSolicitud;
            conSolicitudSimp.cCumpleReglas = "NoCumple";

            DataTable dtParametroSolicitud = ArmarTablaParametrosSolicitud();
            DataTable dtParametrosEval = ArmarTablaParametrosEvaluacion();

            dtParametroSolicitud.Merge(dtParametrosEval);

            clsCNValidaReglasDinamicas objCNReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;

            string cNombreFormulario = this.Name;
            if (this.lEsMNB)
            {
                cNombreFormulario = "ReglasMNB_CredFacilito";
            }

            conSolicitudSimp.cCumpleReglas = objCNReglasDinamicas.ValidarReglasCreditos(dtParametroSolicitud, cNombreFormulario,
                                                                   clsVarGlobal.nIdAgencia, objCliente.idCli,
                                                                   1, objSolReglas.idMoneda, objSolReglas.objProductoCredSimp.idProducto,
                                                                   objSolReglas.nCapitalSolicitado, objSolReglas.idSolicitud, clsVarGlobal.dFecSystem,
                                                                   2, 1,
                                                                   clsVarGlobal.User.idUsuario, ref nNivAuto, true, false, objSolReglas.idSolicitud,
                                                                   this.aReglasEvaluadas);

        }

        private void btnHabilitarSeguro_Click(object sender, EventArgs e)
        {
            int nMuestraFrm = 1;
            CargarConfiguracionSeguro(nMuestraFrm);
        }
        #endregion

        #region Métodos
        public void InicializarComponentes()
        {
            objCliente = new clsCliente();
            objSolicitudSimp = new clsSolicitudCredSimp();
            objConfigActividadEcon = new clsActividadEconomicaConfig();
            conSolicitudSimp.cIDsTipEvalCred = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"]);
            conSolicitudSimp.cIDsSectorEcon = Convert.ToString(clsVarApl.dicVarGen["cIDsSectorEconPYMEFacilito"]);
            conSolicitudSimp.btnTasaNegociada.Visible = false;

            objEvalCred = new clsEvalCred();

            #region Evaluacion
            this.objCapaNegocio = new clsCNEvalCredSimp();
            this.objEstadosFinancieros = new clsCNEstadosFinancieros();
            this.objCNCredito = new CRE.CapaNegocio.clsCNCredito();
            this.tabEval.Enabled = false;
            #endregion 
        }

        public void CargarDatosComponentes()
        {
            lstProductoEval = objCNSolicitud.CNRecuperarProductoSimpTipEval(conSolicitudSimp.cIDsTipEvalCred);

            conSolicitudSimp.lstTipoOperacionPermitido = new List<int> { 1, 4 };
            conSolicitudSimp.cNombreFormulario = this.Name;
            conSolicitudSimp.idProductoDefecto = (lstProductoEval.Count > 0) ? lstProductoEval[0].idSubProducto : 0;
            conSolicitudSimp.CargarDatosComponentes();

            HabilitarControlesEvaluacion(false);
        }

        public void HabilitarControlesEvaluacion(bool lHabilitado)
        {
            if (!lHabilitado)
            {
                tabEval.TabPages.Remove(tbpReferencias);
                tabEval.TabPages.Remove(tbpEstadosfinanciero);
                tabEval.TabPages.Remove(tbpCondicionesPropuestaCredito);
            }
            else
            {
                tabEval.TabPages.Add(tbpReferencias);
                tabEval.TabPages.Add(tbpEstadosfinanciero);
                tabEval.TabPages.Add(tbpCondicionesPropuestaCredito);
            }
        }

        public void Limpiar()
        {

        }

        public void LimpiarSolicitud()
        {
            objSolicitudSimp = new clsSolicitudCredSimp();
            conSolicitudSimp.Limpiar();
        }

        private DataTable ArmarTablaParametrosSolicitud()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            clsSolicitudCredSimp objSolicitudRegla = conSolicitudSimp.objSolicitud;
            clsCliente objClienteRegla = conSolicitudSimp.objCliente;

            int idUsuario = clsVarGlobal.User.idUsuario;

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idSolicitud";
            drfila[1] = objSolicitudRegla.idSolicitud.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idEtapa";
            drfila[1] = "1";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dni";
            drfila[1] = "'" + ((!String.IsNullOrWhiteSpace(objClienteRegla.cDocumentoID)) ? objClienteRegla.cDocumentoID : "0") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idCli";
            drfila[1] = objClienteRegla.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoTasaCredito";
            drfila[1] = objSolicitudRegla.objTasaCredSimp.idTipoTasa.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoPersona";
            drfila[1] = objClienteRegla.IdTipoPersona;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaSolicitud";
            drfila[1] = "'" + objSolicitudRegla.dFechaRegistro.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nTipoOperacion";
            drfila[1] = objSolicitudRegla.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_Monto";
            drfila[1] = objSolicitudRegla.nCapitalSolicitado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idMoneda";
            drfila[1] = objSolicitudRegla.idMoneda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nCuotas";
            drfila[1] = objSolicitudRegla.nCuotas.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoPeriodo";
            drfila[1] = objSolicitudRegla.idTipoPeriodo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_frecuencia";
            drfila[1] = objSolicitudRegla.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoOperacion";
            drfila[1] = objSolicitudRegla.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nDiasGracia";
            drfila[1] = objSolicitudRegla.nDiasGracia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaDesembolso";
            drfila[1] = "'" + objSolicitudRegla.dFechaDesembolsoSugerido.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idActivEcon";
            drfila[1] = objSolicitudRegla.idActividadInterna.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_PersonalCre";
            drfila[1] = idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nTipoCredito";
            drfila[1] = objSolicitudRegla.objProductoCredSimp.idTipoProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_SubTipoCredito";
            drfila[1] = objSolicitudRegla.objProductoCredSimp.idSubTipoProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_Producto";
            drfila[1] = objSolicitudRegla.objProductoCredSimp.idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_SubProducto";
            drfila[1] = objSolicitudRegla.objProductoCredSimp.idSubProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_DestinoCredito";
            drfila[1] = objSolicitudRegla.idDestino.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_TasaEfecMes";
            drfila[1] = objSolicitudRegla.objTasaCredSimp.nTasaSeleccionada.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_TasaEfecMin";
            drfila[1] = objSolicitudRegla.objTasaCredSimp.nTasaCompensatoria.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_TasaEfecMax";
            drfila[1] = objSolicitudRegla.objTasaCredSimp.nTasaCompensatoriaMax.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_ModDesembolso";
            drfila[1] = objSolicitudRegla.idModalidadDes;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_cNomAge";
            drfila[1] = "'" + clsVarGlobal.cNomAge.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_lVigente";
            drfila[1] = clsVarGlobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoAsesorFam = new GEN.CapaNegocio.clsCNCredito();
            DataTable SaldoIndividual = SaldoAsesorFam.CNRetornSaldoxAseFam(objClienteRegla.idCli, objSolicitudRegla.nCapitalSolicitado, objSolicitud.idMoneda, clsVarGlobal.nIdAgencia);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nSaldoInd";
            drfila[1] = SaldoIndividual.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoTotalAsesorFam = new GEN.CapaNegocio.clsCNCredito();
            DataTable SaldoGlobal = SaldoTotalAsesorFam.CNRetornSaldoTotalAseFam(clsVarGlobal.nIdAgencia, objSolicitudRegla.nCapitalSolicitado, objSolicitud.idMoneda);
            drfila = dtTablaParametros.NewRow();

            drfila[0] = "s_nSaldoGlobal";
            drfila[1] = SaldoGlobal.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);

            string idCuentas = "";
            var aCuenta = conSolicitudSimp.dtCreditoRelacionado.AsEnumerable().Where(row => row.RowState != DataRowState.Deleted).Select(item => Convert.ToString(item.Field<int>("idCuenta"))).ToArray();
            idCuentas = String.Join(",", aCuenta);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_cCadenaIdCuenta";
            drfila[1] = "'" + idCuentas + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nCapitalSocialYReservas";
            drfila[1] = clsVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idModalidadCredito";
            drfila[1] = objSolicitudRegla.idModalidadCredito.ToString();
            dtTablaParametros.Rows.Add(drfila);

            int nPlazoTotal = conSolicitudSimp.ObtenerTotalDiasCredito();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nPlazo";
            drfila[1] = nPlazoTotal;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_nCuotasGracia";
            drfila[1] = objSolicitudRegla.nCuotasGracia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_dFechaProximoVencimiento";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoCliente";
            drfila[1] = objSolicitudRegla.idTipoCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "s_idTipoLocalActividad";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = objSolicitudSimp.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = objSolicitudSimp.nPlazoCuota;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        public void cargarDatosCompSolicitud()
        {
            //btnAdministradorFiles1.idSolicitud = objSolicitudSimp.idSolicitud;
            //btnAdministradorFiles1.actualizarDatos();
            //btnAdministradorFiles1.Enabled = true;

            btnVincularVisita.idSolicitud = objSolicitudSimp.idSolicitud;
            btnVincularVisita.idCli = objCliente.idCli;
        }

        public DataTable GenerarCalendarioPagoSol()
        {
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            DataTable dtCalendarioPagos = new DataTable();
            dtCalendarioPagos = objCNPlanPago.CalculaPpgCuotasConstantes(
                objSolicitudSimp.nCapitalSolicitado, objSolicitudSimp.objTasaCredSimp.nTasaSeleccionada / 100.00m,
                objSolicitudSimp.dFechaDesembolsoSugerido, objSolicitudSimp.nCuotas,
                objSolicitudSimp.nDiasGracia, Convert.ToInt16(objSolicitudSimp.idTipoPeriodo),
                objSolicitudSimp.nPlazoCuota, 0,
                new DataTable(), objSolicitudSimp.idMoneda,
                new DataTable(), objSolicitudSimp.dFechaPrimeraCuota
            );

            if (objSolicitudSimp.nCuotasGracia > 0)
            {
                dtCalendarioPagos = objCNPlanPago.CalcularCuotasGracia(
                    dtCalendarioPagos, objSolicitudSimp.nCapitalSolicitado,
                    objSolicitudSimp.objTasaCredSimp.nTasaSeleccionada / 100.00m, objSolicitudSimp.dFechaDesembolsoSugerido,
                    objSolicitudSimp.nDiasGracia, Convert.ToInt16(objSolicitudSimp.idTipoPeriodo),
                    objSolicitudSimp.nPlazoCuota, new DataTable(),
                    objSolicitudSimp.idMoneda, new DataTable(),
                    objSolicitudSimp.dFechaPrimeraCuota, objSolicitudSimp.nCuotas,
                    objSolicitudSimp.nCuotasGracia
                );
            }

            return dtCalendarioPagos;
        }

        public string CalendarioPagosXML()
        {
            DataTable dtCalendarioPagos = GenerarCalendarioPagoSol();
            
            var listCuotaConst = (from p in dtCalendarioPagos.AsEnumerable()
                                  select new
                                  {
                                      nDiasAcu = p.Field<int>("dias_acu"),
                                      nCuota = p.Field<decimal>("imp_cuota")
                                  }).ToList();

            DataTable dt = new DataTable();

            dt.Columns.Add("d", typeof(int));
            dt.Columns.Add("c", typeof(decimal));

            foreach (var bg in listCuotaConst)
            {
                dt.Rows.Add(bg.nDiasAcu, bg.nCuota);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "Pagos", "ct")
                .Replace(">    <", "><")
                .Replace(">  <", "><");
        }

        public decimal ObtenerMontoTotal()
        {
            DataTable dtCalendario = GenerarCalendarioPagoSol();

            if (dtCalendario.Rows.Count > 0)
                return Convert.ToDecimal(dtCalendario.Compute("Sum(imp_cuota)", ""));

            return 0;
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

        #region Evaluacion Presencial-remota
        private void ValidarVisitaPresencialRemota()
        {
            string cNombreFormulario = this.Name;
            List<Tuple<int, string>> listTiposEvaluacionPresencialRemota = new List<Tuple<int, string>>();

            DataTable dtTipoEvaluacion = objCNCargaArchivoDocEval.CNListaTipoEvaluacion();

            foreach (DataRow row in dtTipoEvaluacion.Rows)
            {
                int idTipEvalConfig = Convert.ToInt32(row["idTipEvalConfig"]);
                DataTable dtRespuestaEvalPreRem = ArmarTablaParametrosEvalPreRemo(idTipEvalConfig);
                string cCumpleReglas = new clsCNValidaReglaConfig().ValidarReglasConfig(dtRespuestaEvalPreRem, cNombreFormulario, idTipEvalConfig);

                if (cCumpleReglas == "OK")
                {
                    string cTipEvalConfig = row["cTipEvalConfig"].ToString();
                    Tuple<int, string> listTipoEvaluacionTuple = new Tuple<int, string>(idTipEvalConfig, cTipEvalConfig);

                    if (idTipEvalConfig == 3)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                    else if (idTipEvalConfig == 2)
                    {
                        listTiposEvaluacionPresencialRemota.Add(listTipoEvaluacionTuple);
                    }
                }
            }

            if (listTiposEvaluacionPresencialRemota.Count > 0)
            {
                RecuperarDocEvalAnterior(listTiposEvaluacionPresencialRemota);
            }
            else
            {
                MessageBox.Show("No cumple con las reglas de validación para una solicitud anterior.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private DataTable ArmarTablaParametrosEvalPreRemo(int idTipEvalConfig)
        {
            DataTable dtTablaParametrosEval = new DataTable();
            dtTablaParametrosEval.Columns.Add("cNombreCampo");
            dtTablaParametrosEval.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametrosEval.NewRow();

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.objSolicitud.idCli;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idTipEvalConfig";
            drfila[1] = idTipEvalConfig;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "nMontoSol";
            drfila[1] = this.objSolicitud.nMonto;
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "cIdTipEvalCred";
            drfila[1] = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"]);
            dtTablaParametrosEval.Rows.Add(drfila);

            drfila = dtTablaParametrosEval.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario;
            dtTablaParametrosEval.Rows.Add(drfila);

            return dtTablaParametrosEval;
        }

        private void RecuperarDocEvalAnterior(List<Tuple<int, string>> listTiposEvaluacion)
        {
            int idTipEvalConfig = listTiposEvaluacion[0].Item1;
            int idSolicitudAnterior = 0;
            int idSolicitud = this.objSolicitud.idSolicitud;
            string cIdTipEvalCred = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"]);
            int idEvalCredAnterior = 0;
            int idTipEvalConfigRespuesta = 0;

            DataTable dtSolicitudEvalAnterior = objCNCargaArchivoDocEval.CNRecuperaSolicitudAnterior(this.objSolicitud.idCli, Convert.ToDateTime(Evaluacion.FechaActualEval), cIdTipEvalCred, idTipEvalConfig);

            if (Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]) == 0)
            {
                MessageBox.Show("La validación de las reglas remota y presencial ha fallado.", "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtSolicitudEvalAnterior.Rows.Count > 0)
            {
                idSolicitudAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idSolicitud"]);

                frmSeleccionarDocEvalAnterior frmSeleccionarDoc = new frmSeleccionarDocEvalAnterior(idSolicitudAnterior, idSolicitud, listTiposEvaluacion);
                idTipEvalConfigRespuesta = frmSeleccionarDoc.idTipEvalConfig;
                frmSeleccionarDoc.ShowDialog();

                idEvalCredAnterior = Convert.ToInt32(dtSolicitudEvalAnterior.Rows[0]["idEvalCred"]);
                ActualizaInformacionEvaluacion(this.idEvalCred, idEvalCredAnterior, idTipEvalConfigRespuesta, cIdTipEvalCred);
            }
        }

        private void ActualizaInformacionEvaluacion(int idEvalCredActual, int idEvalCredAnterior, int idTipEvalConfig, string cIdTipEvalCred)
        {
            DataTable dt = objCNCargaArchivoDocEval.CNActualizaInformacionEvaluacion(idEvalCredActual, idEvalCredAnterior, idTipEvalConfig, cIdTipEvalCred);

            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["idMsje"]) == 0)
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dt.Rows[0]["cMsje"].ToString(), "Evaluación modalidad remota o presencial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        #endregion

        #region Evaluacion
        #region Métodos Privados
        private void InicializarFormulario()
        {
            #region Recuperar Datos por default
            DataSet dsResult = this.objCapaNegocio.CNInicializarCredFacilito();

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


        public void CargarDatosEvaluacion()
        {
            string cIDsTipEvalCredPyme = Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"]);

            DataTable dt = this.objCNEvaluacion.ListarEvaluacionPorCliente(objCliente.idCli, clsVarGlobal.User.idUsuario, cIDsTipEvalCredPyme);
            if (dt.Rows.Count == 0)
            {
                return;
            }

            var rows = dt.AsEnumerable().Where(item => Convert.ToInt32(item["idSolicitud"]) == objSolicitudSimp.idSolicitud);
            DataTable dtFiltro = (rows.Any()) ? rows.CopyToDataTable() : dt.Clone();

            if (dtFiltro.Rows.Count > 0)
            {

                (new clsCNSolicitud()).actualizarMontosSolRefi(objSolicitud.idSolicitud);
                RecuperarDatos(Convert.ToInt32(dtFiltro.Rows[0]["idEvalCred"]));
                RecuperarDetalleEstRes(Convert.ToInt32(dtFiltro.Rows[0]["idEvalCred"]));

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
        }

        private void NuevaEvaluacion()
        {
            CargarNuevaEvaluacion();
            if (objCliente.idCli != 0 && idEvalCred != 0)
            {
                conBusCliSimp.cargarDatosCli(objCliente.idCli);

                RecuperarDatos(idEvalCred);
                RecuperarDetalleEstRes(idEvalCred);

                HabilitarBotonesSegunModo(clsAcciones.NUEVO);

                TituloForm(this.objEvalCred.cTipEvalCred, "Para edición");
            }
        }

        private void CargarNuevaEvaluacion()
        {
            BuscarCliente(objCliente.idCli);
            GrabarEvaluacion();
        }

        private void BuscarCliente(int idCli)
        {
            if (idCli != 0)
            {
                #region Cargar Datos de BD
                DataSet ds = this.objCNEvaluacion.BuscarSolicitudesPorCliente(idCli, clsVarGlobal.User.idUsuario, this.cIDsTipEvalCredPyme, this.cIDsSectorEconPyme);
                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("¡No se ha encontrado ninguna solicitud enviada para este tipo de evaluación!",
                        "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //-- Table[0] : Variables Globales
                DataTable tdVarGlobales = ds.Tables[0];
                Evaluacion.TipoCambio = Convert.ToDecimal(tdVarGlobales.Rows[0]["nTipoCambio"]);

                //-- Table[1] : Solicitud de Crédito
                this.listCredSolicitado = DataTableToList.ConvertTo<clsCreditoProp>(ds.Tables[1]) as List<clsCreditoProp>;

                //-- Table[2] : Tipos de Evaluación
                this.listTipEvalCred = DataTableToList.ConvertTo<clsTipEvalCred>(ds.Tables[2]) as List<clsTipEvalCred>;

                //-- Table[3] : Sectores Economicos
                this.dtSectorEconomico = ds.Tables[3];

                //-- Table[4] : Tipos de productos por tipos de evaluación
                this.listProdTipEval = DataTableToList.ConvertTo<clsProductoTipEval>(ds.Tables[4]) as List<clsProductoTipEval>;

                //-- Evaluar si pertenece al MNB
                int idSolicitud = this.conSolicitudSimp.GetIdSolicitud(); 

                DataTable dtMNB = new clsCNMotorDecision().ClasificacionInternaxCli(idSolicitud);
                if (dtMNB.Rows.Count>0)
                {
                    int clasInternaCli = Convert.ToInt32(dtMNB.Rows[0]["idClasifInterna"]);
                    this.lEsMNB = clasInternaCli == 9 ? true : false;
                }
                else
                {
                    this.lEsMNB = false;
                }
                #endregion


                #region Asignar datos a los controles
                if (objCliente.nAniosActEco <= 0)
                {
                    MessageBox.Show("Años de Actividad debe ser mayor que CERO." +
                        "* Solucione este problema revisando la Fecha de Inicio de Actividad Económica en el formulario de Registro de Clientes.", "AÑOS DE ACTIVIDAD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion

                if (listCredSolicitado.Count > 0)
                {
                    this.btnGestObs.Enabled = true;
                    this.objSolicitud = this.listCredSolicitado[0];

                    var objMsjError = ValidarVinculacionConSolicitud(this.objSolicitud.idProducto, this.objSolicitud.idEvalCred);

                    if (objMsjError.HasErrors)
                    {
                        string cMsj = "No se puede vincular por las siguientes razones: \n\n" + objMsjError.GetErrors();
                        MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    CargarDatosDeuda();
                    this.listRCCSaldosDirectos = ObtenerRCCSaldosDirectos();
                    this.listRCCSaldosIndirectos = ObtenerRCCSaldosIndirectos();
                    this.listCRACSaldos = ObtenerCRACSaldos();
                    this.listEFinSaldos = ObtenerEFinSaldos();

                }
                else
                {
                    return;
                }
            }
        }

        public decimal ObtenerSaldoTotal()
        {
            decimal nTotal = 0;
            if (this.listRCCSaldosDirectos != null)
                nTotal += this.listRCCSaldosDirectos.Sum(x => x.nSCapTotalMA);

            if (this.listCRACSaldos != null)
                nTotal += this.listCRACSaldos.Sum(x => x.nSCapTotalMA);

            if (this.listEFinSaldos != null)
                nTotal += this.listEFinSaldos.Sum(x => x.nSCapTotalMA);

            return nTotal;
        }

        public List<clsDeudasEval> ObtenerRCCSaldosDirectos()
        {
            return this.listRCCSaldosDirectos;
        }

        public List<clsDeudasEval> ObtenerRCCSaldosIndirectos()
        {
            return this.listRCCSaldosIndirectos;
        }

        public List<clsDeudasEval> ObtenerCRACSaldos()
        {
            return this.listCRACSaldos;
        }

        public List<clsDeudasEval> ObtenerEFinSaldos()
        {
            return this.listEFinSaldos;
        }

        public void CargarDatosDeuda()
        {
            #region Obtener datos DB
            DataSet ds = (new clsCNEvalPyme()).ObtenerSaldosEntFinancieras(objCliente.cDocumentoID, 0, objSolicitudSimp.idSolicitud);

            //-- Table[0] : Saldos RCC
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[0]) as List<clsDeudasEval>;

            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();

            this.listRCCSaldosDirectos = listSalRCCDirectos;
            this.listRCCSaldosIndirectos = listSalRCCDIndirec;

            //-- Table[1] : Saldos CRAC - LASA
            this.listCRACSaldos = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[1]) as List<clsDeudasEval>;
            #endregion

            #region Configurar Objetos

            int i, c = this.listRCCSaldosDirectos.Count;
            for (i = 0; i < c; i++)
            {
                this.listRCCSaldosDirectos[i].nTipoCambio = this.nTipoCambio;
                this.listRCCSaldosDirectos[i].idMonedaMA = this.objSolicitudSimp.idMoneda;
                this.listRCCSaldosDirectos[i].nSCapCortoPlz = this.listRCCSaldosDirectos[i].nSCapTotalSis;
            }

            c = this.listCRACSaldos.Count;
            for (i = 0; i < c; i++)
            {
                this.listCRACSaldos[i].nTipoCambio = this.nTipoCambio;
                this.listCRACSaldos[i].idMonedaMA = this.objSolicitudSimp.idMoneda;
                if (this.listCRACSaldos[i].idTipoDeuda == TipoDeuda.Directo)
                {
                    this.listCRACSaldos[i].nSCapCortoPlz = this.listCRACSaldos[i].nSCapTotalSis;
                }
                else
                {
                    this.listCRACSaldos[i].nSCapLargoPlz = this.listCRACSaldos[i].nSCapTotalSis;
                    this.listCRACSaldos[i].nSCapCortoPlz = decimal.Zero;
                }
            }
            #endregion
        }

        private clsMsjError ValidarVinculacionConSolicitud(int idProducto, int idEvalCred)
        {
            clsMsjError objMsjError = new clsMsjError();

            if (!EsValidoProducto(idProducto))
            {
                objMsjError.AddError("El producto no es valido para esta evaluación.");
            }

            if (EstaVinculado(idEvalCred))
            {
                objMsjError.AddError("La solicitud ya está vinculado con la Evaluación Nº " + idEvalCred.ToString("D6") + ".");
            }

            return objMsjError;
        }

        private bool EsValidoProducto(int idProducto)
        {
            clsProductoTipEval objProductoTipEval = this.listProdTipEval.Find(x => x.idProducto == idProducto);

            if (objProductoTipEval == null) return false;
            else return true;
        }

        private bool EstaVinculado(int idEvalCred)
        {
            if (idEvalCred > 0) return true;
            return false;
        }

        private void GrabarEvaluacion()
        {
            clsMsjError objMsjError = ValidarGrabar();

            if (objMsjError.HasErrors)
            {
                MessageBox.Show(objMsjError.GetErrors(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region Saldos con entidades financieras
            List<clsDeudasEval> objSaldosDeudas = new List<clsDeudasEval>();
            foreach (clsDeudasEval saldos in this.listRCCSaldosDirectos)
            {
                saldos.nCuotasPag = 0;
                saldos.nCuotasPen = 0;
                saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                saldos.nSCapLargoPlz = 0;
                saldos.nMontoCuota = 0;
                saldos.lAutomatico = true;
                objSaldosDeudas.Add(saldos);
            }

            foreach (clsDeudasEval saldos in this.listRCCSaldosIndirectos)
            {
                saldos.nCuotasPag = 0;
                saldos.nCuotasPen = 0;
                saldos.nSCapCortoPlz = 0;
                saldos.nSCapLargoPlz = saldos.nSCapTotalSis;
                saldos.nMontoCuota = 0;
                saldos.lAutomatico = true;
                objSaldosDeudas.Add(saldos);
            }

            foreach (clsDeudasEval saldos in this.listCRACSaldos)
            {
                if (saldos.idTipoDeuda == TipoDeuda.Directo)
                {
                    saldos.nSCapCortoPlz = saldos.nSCapTotalSis;
                    saldos.nSCapLargoPlz = decimal.Zero;
                }
                else
                {
                    saldos.nSCapCortoPlz = decimal.Zero;
                    saldos.nSCapLargoPlz = saldos.nSCapTotalSis;
                }
                saldos.dFechaConsulta = clsVarGlobal.dFecSystem; ;
                saldos.lAutomatico = true;
                saldos.idTipoCredito = 4;

                objSaldosDeudas.Add(saldos);
            }

            foreach (clsDeudasEval saldos in this.listEFinSaldos)
            {
                if (saldos.nSCapTotal > 0)
                {
                    saldos.idDeudasEval = 0;
                    saldos.idTipoDeuda = 1;
                    saldos.idCuenta = 0;
                    saldos.idProducto = 0;
                    saldos.nSCapLargoPlz = 0;
                    saldos.dFechaConsulta = clsVarGlobal.dFecSystem;
                    saldos.lAutomatico = false;
                    saldos.idTipoCredito = 0;

                    objSaldosDeudas.Add(saldos);
                }
            }
            #endregion

            string xmlEvalCred = EvalCredEnXML();
            string xmlSaldosDeudas = SaldosEnXML(objSaldosDeudas);

            DataTable td = this.objCNEvaluacion.GrabarNuevaEvalCred(xmlEvalCred, xmlSaldosDeudas, clsVarGlobal.User.idEstablecimiento);
            if (td.Rows.Count > 0)
            {
                if (td.Rows[0]["idMsje"].ToString().Equals("0"))
                {
                    MessageBox.Show(td.Rows[0]["cMsje"].ToString(), this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.idEvalCred = Convert.ToInt32(td.Rows[0]["idEvalCred"]);

                    #region ValidarPDS
                    DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(objSolicitudSimp.idSolicitud);
                    if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                    {
                        MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                    //Visita Presencial-Remoto
                    ValidarVisitaPresencialRemota();
                }
            }

        }

        private clsMsjError ValidarGrabar()
        {
            clsMsjError objMsjError = new clsMsjError();

            return objMsjError;
        }

        private string EvalCredEnXML()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idTipEvalCred", typeof(int));
            dt.Columns.Add("idCli", typeof(int));
            dt.Columns.Add("idSolicitud", typeof(int));
            dt.Columns.Add("idUsuReg", typeof(int));
            dt.Columns.Add("idAgencia", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("dFecReg", typeof(DateTime));
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
            dt.Columns.Add("idActividad", typeof(int));
            dt.Columns.Add("idSectorEcon", typeof(int));
            dt.Columns.Add("idActividadInternaPri", typeof(int));
            dt.Columns.Add("nActPriAnios", typeof(int));
            dt.Columns.Add("nTotalDeudas", typeof(decimal));
            dt.Columns.Add("nPlazo", typeof(int));
            dt.Columns.Add("nCuotasGracia", typeof(int));
            dt.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dt.Columns.Add("cCalendarioPagos", typeof(string));
            dt.Columns.Add("nTotalMontoPagar", typeof(decimal));

            DataRow row = dt.NewRow();

            decimal nTEM = clsMathFinanciera.TEM(Convert.ToDouble(objSolicitudSimp.objTasaCredSimp.nTasaSeleccionada));
            int nPlazo = (objSolicitudSimp.idTipoPeriodo == 1) ? objSolicitudSimp.nCuotas : Convert.ToInt32(Math.Round(((objSolicitudSimp.nCuotas * objSolicitudSimp.nPlazoCuota) / 30.00), 0));

            row["idTipEvalCred"] = Convert.ToInt32(this.cIDsTipEvalCredPyme.Split(',')[0]);
            row["idCli"] = this.objCliente.idCli;
            row["idSolicitud"] = objSolicitudSimp.idSolicitud; ;
            row["idUsuReg"] = clsVarGlobal.User.idUsuario;
            row["idAgencia"] = clsVarGlobal.nIdAgencia;
            row["idProducto"] = objSolicitudSimp.idProducto;
            row["dFecReg"] = clsVarGlobal.dFecSystem;
            row["nCapitalPropuesto"] = objSolicitudSimp.nCapitalSolicitado;
            row["idMoneda"] = objSolicitudSimp.idMoneda;
            row["nCuotas"] = objSolicitudSimp.nCuotas;
            row["idTipoPeriodo"] = objSolicitudSimp.idTipoPeriodo;
            row["nPlazoCuota"] = objSolicitudSimp.nPlazoCuota;
            row["nDiasGracia"] = objSolicitudSimp.nDiasGracia;
            row["dFechaDesembolso"] = objSolicitudSimp.dFechaDesembolsoSugerido;
            row["idTasa"] = objSolicitudSimp.objTasaCredSimp.idTasa;
            row["nTEA"] = objSolicitudSimp.objTasaCredSimp.nTasaSeleccionada;
            row["nTEM"] = nTEM;
            row["idActividad"] = objSolicitudSimp.idActividad;
            row["idSectorEcon"] = objSolicitudSimp.idSectorEconomico;
            row["idActividadInternaPri"] = objSolicitudSimp.idActividadInterna;
            row["nActPriAnios"] = objCliente.nAniosActEco;
            row["nTotalDeudas"] = ObtenerSaldoTotal();
            row["nPlazo"] = nPlazo;
            row["nCuotasGracia"] = objSolicitudSimp.nCuotasGracia;
            row["nCuotaGraciaAprox"] = objSolicitudSimp.nCuotaGraciaAprox;
            row["cCalendarioPagos"] = CalendarioPagosXML();
            row["nTotalMontoPagar"] = ObtenerMontoTotal();

            dt.Rows.Add(row);

            return clsUtils.ConvertToXML(dt.Copy(), "EvalCred", "Item");
        }

        private string SaldosEnXML(List<clsDeudasEval> listDeudas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idTipoDeuda", typeof(int));
            dt.Columns.Add("idDeudaCA", typeof(int));
            dt.Columns.Add("cCodigoEmpresa", typeof(string));
            dt.Columns.Add("cNombreEmpresa", typeof(string));
            dt.Columns.Add("idCuenta", typeof(int));
            dt.Columns.Add("idProducto", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("nMontoAprobado", typeof(decimal));
            dt.Columns.Add("nCuotasPag", typeof(int));
            dt.Columns.Add("nCuotasPen", typeof(int));
            dt.Columns.Add("nCuotasTotal", typeof(int));
            dt.Columns.Add("nSCapTotalSis", typeof(decimal));
            dt.Columns.Add("nSCapTotal", typeof(decimal));
            dt.Columns.Add("nSCapCortoPlz", typeof(decimal));
            dt.Columns.Add("nSCapLargoPlz", typeof(decimal));
            dt.Columns.Add("nMontoCuota", typeof(decimal));
            dt.Columns.Add("cCronograma", typeof(string));
            dt.Columns.Add("dFechaConsulta", typeof(DateTime));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("lAutomatico", typeof(bool));
            dt.Columns.Add("idTipoCredito", typeof(int));

            dt.Columns.Add("lUtilizada", typeof(bool));
            dt.Columns.Add("idTipoInterv", typeof(int));

            foreach (var deuda in listDeudas)
            {
                DataRow row = dt.NewRow();

                //newCustomersRow["idDeudasEval"] = rcc.idDeudasEval;
                //newCustomersRow["idEvalCred"] = rcc.idEvalCred;
                row["idTipoDeuda"] = deuda.idTipoDeuda;
                row["idDeudaCA"] = deuda.idDeudaCA; //false
                row["cCodigoEmpresa"] = deuda.cCodigoEmpresa;
                row["cNombreEmpresa"] = deuda.cNombreEmpresa;
                row["idCuenta"] = deuda.idCuenta;
                row["idProducto"] = deuda.idProducto;
                row["idMoneda"] = deuda.idMoneda;
                row["nMontoAprobado"] = deuda.nMontoAprobado;
                row["nCuotasPag"] = deuda.nCuotasPag;
                row["nCuotasPen"] = deuda.nCuotasPen;
                row["nCuotasTotal"] = deuda.nCuotasTotal;
                row["nSCapTotalSis"] = deuda.nSCapTotalSis;
                row["nSCapTotal"] = deuda.nSCapTotal;
                row["nSCapCortoPlz"] = deuda.nSCapCortoPlz;
                row["nSCapLargoPlz"] = deuda.nSCapLargoPlz;
                row["nMontoCuota"] = deuda.nMontoCuota;
                row["cCronograma"] = deuda.cCronograma;
                row["dFechaConsulta"] = deuda.dFechaConsulta;
                row["idMonedaMA"] = this.objSolicitud.idMoneda;
                row["lAutomatico"] = deuda.lAutomatico;
                row["idTipoCredito"] = deuda.idTipoCredito;

                row["lUtilizada"] = deuda.lUtilizada;
                row["idTipoInterv"] = deuda.idTipoInterv;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DeudasEval", "Item");
        }


        private void RecuperarDatos(int idEvalCred)
        {
            this.conCondiCredito.ActividadInternaSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_ActividadInternaSelectedIndexChanged);
            this.conEstadosFinancieros.CellValueChangedEstadosFinancieros -= new System.Windows.Forms.DataGridViewCellEventHandler(this.conEstadosFinancieros_CellValueChangedEstadosFinancieros);
            this.conCondiCredito.ActualizarPorDestinoCapitalTrabajoChanged -= new System.EventHandler(this.conCondiCredito_ActualizarPorDestinoCapitalTrabajoChanged);
            this.conCondiCredito.CuotaAproximadaChanged -= new System.EventHandler(this.conCondiCredito_CuotaAproximadaChanged);
            this.conCondiCredito.SectorEconSelectedIndexChanged -= new System.EventHandler(this.conCondiCredito_SectorEconSelectedIndexChanged);
            this.conCondiCredito.PlazoChanged -= new System.EventHandler(this.conCondiCredito_PlazoChanged);

            #region Recuperar de DataBase
            DataSet dsResult = this.objCapaNegocio.CNBuscarEvalCreditoFacilito(idEvalCred);

            DataTable dtDetalleInterviniend = this.objCapaNegocio.CNRecuperarDetalleSaldoInterviniente(idEvalCred);
            this.lstDetalleSaldoInter = (dtDetalleInterviniend.Rows.Count > 0) ? DataTableToList.ConvertTo<clsDetalleSaldoInterviniente>(dtDetalleInterviniend) as List<clsDetalleSaldoInterviniente> : new List<clsDetalleSaldoInterviniente>();
            DataTable dtConfigAct = this.objCapaNegocio.CNRecuperarConfigActividadEconomica(idEvalCred);
            this.objConfigActividadEcon = (dtConfigAct.Rows.Count > 0) ? (DataTableToList.ConvertTo<clsActividadEconomicaConfig>(dtConfigAct) as List<clsActividadEconomicaConfig>)[0] : new clsActividadEconomicaConfig();
            this.objConfigActividadEcon = (objConfigActividadEcon.nMargenGanancia != 0) ? objConfigActividadEcon : new clsActividadEconomicaConfig();
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
                    this.btnGestObs.Enabled = true;
                    this.objSolicitud = aSolicitud[0];
                    this.objSolicitud.idClasificacionInterna = this.objEvalCred.idClasificacionInterna;
                    cargarDatosCompSolicitud();
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

            this.objPropCredito = new ClsPropSimpleCred();
            this.conPropuestaSimpCred.lHabilitarTipActividad = false;
            this.objPropCredito.oActPrincipal = objActPrincipal;
            this.objPropCredito.oActPrincipal.idTipoActividad = 2;
            this.objPropCredito.cComPropCliente = this.objEvalCred.cComPropCliente;
            this.objPropCredito.cComPropCredito = this.objEvalCred.cComPropCredito;

            #endregion

            #region Asignar a Componentes
            this.conReferenciasSimp.AsignarDataTable(this.dtTipReferEval, this.dtTipVinculoEval);
            this.conReferenciasSimp.AsignarDatos(this.listReferencia);
            if (this.objEvalCred.idSolicitud != 0)
            {
                this.conBusSolEval.AsignarDatos(this.objEvalCred.idSolicitud, this.objEvalCred.idEvalCred, this.objSolicitud.cOperacion, this.objSolicitud.cModalidadCredito);
            }
            

            this.conDetalleSaldoInterviniente.AsignarDatos(lstDetalleSaldoInter);

            
            decimal nCapitalParacomercio = 0;
            this.conEstadosFinancieros.AsignarDatos(this.listBalGenEval, this.listEstResEval, this.listIndiFinanc, this.listInventario,
                this.objEvalCred.nCapitalPropuesto, this.objEvalCred.nCuotaAprox, nMontoCapitalTrabajo, this.objEvalCred.nTotalPasivoAC, nCapitalParacomercio, this.objEvalCred.idSectorEcon,
                this.objEvalCred.idTipEvalCred, 0, 0, this.objEvalCred.idEvalCred, this.objEvalCred.idCli, this.objSolicitud.idDestino);

            this.conCondiCredito.AsignarDataTable(this.dtTipMoneda, this.dtTipPeriodo, this.dtTipDestCred, this.dtTipDestCredDetalle, this.dtSectorEconomico);
            this.conCondiCredito.AsignarDatos(this.objEvalCred, this.objSolicitud, this.listDestCredProp, this.listBalGenEval, this.listEstResEval);

            this.conPropuestaSimpCred.AsignarDatos(this.objPropCredito);
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
                    
                    if (elem.nCodigo == ElemEvalCred.DetalleCliente)
                        this.conPropuestaSimpCred.TxtDatosClienteEnabled = false;

                    if (elem.nCodigo == ElemEvalCred.DetalleCredito)
                        this.conPropuestaSimpCred.TxtDatosClienteEnabled = false;
                }
            }
            #endregion

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
            for (int i = 1; i < 480; i++)
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
            ActualizarRcc();
        }
        
        private void HabilitarBotones(bool lHabilitado)
        {
            this.btnImprimir.Enabled = lHabilitado;
            this.btnEnviar.Enabled = lHabilitado;
            this.btnExcepciones.Enabled = lHabilitado;
            this.btnValidar.Enabled = lHabilitado;
            this.btnEditar.Enabled = lHabilitado;
            this.btnCargaArhivos.Enabled = lHabilitado;
            this.btnGrabar.Enabled = lHabilitado;
        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            bool lHabilitado;
            //this.btnAdministradorFiles1.lectura = true;
            switch (nModo)
            {
                case clsAcciones.EDITAR:
                    lHabilitado = true;

                    this.btnImprimir.Enabled = false;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    //this.btnAdministradorFiles1.lectura = false;
                    this.btnValidar.Enabled = lHabilitado;
                    this.btnEditar.Enabled = false;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnGrabar.Enabled = lHabilitado;
                    this.btnExcepciones.Enabled = false;
                    this.btnHabilitarSeguro.Enabled = true;

                    HabilitarPaginas(true);
                    break;
                case clsAcciones.GRABAR:
                    lHabilitado = false;

                    this.btnImprimir.Enabled = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnExcepciones.Enabled = true;
                    this.btnHabilitarSeguro.Enabled = false;

                    HabilitarPaginas(false);
                    break;
                case clsAcciones.ENVIAR:
                    this.tabEval.Enabled = true;

                    lHabilitado = false;

                    this.btnImprimir.Enabled = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = lHabilitado;
                    this.btnValidar.Enabled = lHabilitado;
                    this.btnEditar.Enabled = lHabilitado;
                    this.btnCargaArhivos.Enabled = lHabilitado;
                    this.btnGrabar.Enabled = lHabilitado;
                    this.btnExcepciones.Enabled = false;

                    HabilitarPaginas(false);
                    break;
                case clsAcciones.BUSCAR:
                    this.btnObservacion.Enabled = (this.objEvalCred.idSolicitud == 0) ? false : true;
                    this.tabEval.Enabled = true;

                    lHabilitado = false;

                    this.btnImprimir.Enabled = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = true;
                    this.btnEnviar.Visible = true;
                    this.btnValidar.Enabled = lHabilitado;
                    this.btnEditar.Enabled = true;
                    this.btnEditar.Visible = true;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnGrabar.Enabled = lHabilitado;
                    this.btnGrabar.Visible = true;
                    this.btnGrabarSolicitud.Enabled = false;
                    this.btnGrabarSolicitud.Visible = false;
                    this.btnEditarSolicitud.Enabled = false;
                    this.btnEditarSolicitud.Visible = false;
                    this.btnEnviarSolicitud.Enabled = false;
                    this.btnEnviarSolicitud.Visible = false;

                    this.btnExcepciones.Enabled = true;

                    this.btnEditar.Focus();

                    HabilitarPaginas(false);
                    break;
                case clsAcciones.NUEVO:
                    this.btnObservacion.Enabled = false;
                    this.tabEval.Enabled = true;

                    lHabilitado = true;

                    this.btnImprimir.Enabled = false;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnValidar.Enabled = lHabilitado;
                    this.btnEditar.Enabled = false;
                    this.btnCargaArhivos.Enabled = false;
                    this.btnGrabar.Enabled = lHabilitado;
                    this.btnExcepciones.Enabled = false;

                    HabilitarPaginas(true);
                    break;
                case clsAcciones.DENEGAR:
                    lHabilitado = false;

                    this.btnImprimir.Enabled = lHabilitado;
                    this.btnVincularVisita.Enabled = false;
                    this.btnTasaN.Enabled = false;
                    this.btnEnviar.Enabled = lHabilitado;
                    this.btnEditar.Enabled = lHabilitado;
                    this.btnCargaArhivos.Enabled = lHabilitado;
                    this.btnGrabar.Enabled = lHabilitado;
                    this.btnExcepciones.Enabled = false;

                    HabilitarPaginas(false);
                    break;
                case clsAccionSol.SOL_NUEVO:
                    this.tabEval.Enabled = true;

                    this.btnImprimir.Enabled = false;
                    this.btnImprimir.Visible = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = false;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCargaArhivos.Enabled = false;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = false;

                    this.btnGrabarSolicitud.Enabled = true;
                    this.btnGrabarSolicitud.Visible = true;
                    this.btnEditarSolicitud.Enabled = false;
                    this.btnEditarSolicitud.Visible = true;
                    this.btnEnviarSolicitud.Enabled = false;
                    this.btnEnviarSolicitud.Visible = true;
                    this.btnCancelarSolicitud.Enabled = false;
                    this.btnCancelarSolicitud.Visible = false;

                    HabilitarPaginasSol(true);
                    break;

                case clsAccionSol.SOL_RECUPERAR:
                    this.tabEval.Enabled = true;

                    this.btnImprimir.Enabled = true;
                    this.btnImprimir.Visible = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = false;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = false;

                    this.btnGrabarSolicitud.Enabled = false;
                    this.btnGrabarSolicitud.Visible = true;
                    this.btnEditarSolicitud.Enabled = (objSolicitudSimp.objProductoCredSimp.cSubProducto == "EFECTIVO AL INSTANTE") ? false : true;
                    this.btnEditarSolicitud.Visible = true;
                    this.btnEnviarSolicitud.Enabled = (objSolicitudSimp.idEstado == 1) ? true : false;
                    this.btnEnviarSolicitud.Visible = true;
                    this.btnCancelarSolicitud.Enabled = false;
                    this.btnCancelarSolicitud.Visible = true;

                    HabilitarPaginasSol(false);
                    break;
                case clsAccionSol.SOL_ENVIAR:
                    this.tabEval.Enabled = true;

                    this.btnImprimir.Enabled = true;
                    this.btnImprimir.Visible = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = true;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = true;
                    this.btnGrabar.Enabled = true;
                    this.btnGrabar.Visible = true;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = true;

                    this.btnGrabarSolicitud.Enabled     = false;
                    this.btnGrabarSolicitud.Visible     = false;
                    this.btnEditarSolicitud.Enabled     = false;
                    this.btnEditarSolicitud.Visible     = false;
                    this.btnEnviarSolicitud.Enabled     = false;
                    this.btnEnviarSolicitud.Visible     = false;
                    this.btnCancelarSolicitud.Enabled   = false;
                    this.btnCancelarSolicitud.Visible   = false;
                    HabilitarPaginasSol(true);
                    break;
                case clsAccionSol.SOL_GRABAR:
                    this.tabEval.Enabled = true;

                    this.btnImprimir.Enabled = true;
                    this.btnImprimir.Visible = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = false;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = true;

                    this.btnGrabarSolicitud.Enabled = false;
                    this.btnGrabarSolicitud.Visible = true;
                    this.btnEditarSolicitud.Enabled = true;
                    this.btnEditarSolicitud.Visible = true;
                    this.btnEnviarSolicitud.Enabled = (objSolicitudSimp.idEstado == 1) ? true : false;
                    this.btnEnviarSolicitud.Visible = true;
                    this.btnCancelarSolicitud.Enabled = false;
                    this.btnCancelarSolicitud.Visible = false;

                    HabilitarPaginasSol(false);
                    break;
                case clsAccionSol.SOL_EDITAR:
                    this.tabEval.Enabled = true;

                    this.btnImprimir.Enabled = true;
                    this.btnImprimir.Visible = true;
                    this.btnVincularVisita.Enabled = true;
                    this.btnTasaN.Enabled = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = false;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    //this.btnAdministradorFiles1.lectura = false;
                    this.btnCargaArhivos.Enabled = true;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = false;

                    this.btnGrabarSolicitud.Enabled = true;
                    this.btnGrabarSolicitud.Visible = true;
                    this.btnEditarSolicitud.Enabled = false;
                    this.btnEditarSolicitud.Visible = true;
                    this.btnEnviarSolicitud.Enabled = false;
                    this.btnEnviarSolicitud.Visible = true;
                    this.btnCancelarSolicitud.Enabled = false;
                    this.btnCancelarSolicitud.Visible = false;

                    HabilitarPaginasSol(true);
                    break;
                case clsAccionSol.SOL_DEFECTO:
                    this.tabEval.Enabled = true;
                    this.conSolicitudSimp.Enabled = false;
                    //this.btnAdministradorFiles1.Enabled = false;
                    this.btnVincularVisita.Enabled = false;
                    this.btnTasaN.Enabled = false;

                    this.btnImprimir.Enabled = false;
                    this.btnImprimir.Visible = true;
                    this.btnEnviar.Enabled = false;
                    this.btnEnviar.Visible = false;
                    this.btnEditar.Enabled = false;
                    this.btnEditar.Visible = false;
                    this.btnGrabar.Enabled = false;
                    this.btnGrabar.Visible = false;
                    this.btnCargaArhivos.Enabled = false;
                    this.btnCargaArhivos.Visible = true;
                    this.btnExcepciones.Enabled = false;

                    this.btnGrabarSolicitud.Enabled = false;
                    this.btnGrabarSolicitud.Visible = true;
                    this.btnEditarSolicitud.Enabled = false;
                    this.btnEditarSolicitud.Visible = true;
                    this.btnEnviarSolicitud.Enabled = false;
                    this.btnEnviarSolicitud.Visible = true;
                    this.btnCancelarSolicitud.Enabled = false;
                    this.btnCancelarSolicitud.Visible = false;

                    HabilitarPaginasSol(true);
                    break;
                default:
                    break;
            }
        }

        private void HabilitarPaginas(bool lHabilitado)
        {
            this.conReferenciasSimp.Enabled = lHabilitado;

            this.conEstadosFinancieros.Enabled = lHabilitado;
            this.conCondiCredito.Enabled = (this.objEvalCred.idSolicitud > 0) ? lHabilitado : false;
            this.conPropuestaSimpCred.Enabled = lHabilitado;
        }

        private void HabilitarPaginasSol(bool lHabilitado)
        {
            this.conSolicitudSimp.Enabled = lHabilitado;
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

        private clsMsjError Validar()
        {
            clsMsjError objMsjError = new clsMsjError();

            if(this.objSolicitudSimp.objProductoCredSimp.cSubProducto == "EFECTIVO AL INSTANTE")
            {
                DataTable dtConfigAct = this.objCapaNegocio.CNRecuperarConfigActividadEconomica(this.objEvalCred.idEvalCred);
                if (dtConfigAct.Rows.Count > 0)
                {
                    this.objConfigActividadEcon = (dtConfigAct.Rows.Count > 0) ? (DataTableToList.ConvertTo<clsActividadEconomicaConfig>(dtConfigAct) as List<clsActividadEconomicaConfig>)[0] : new clsActividadEconomicaConfig();
                    this.objConfigActividadEcon = (objConfigActividadEcon.nMargenGanancia != 0) ? objConfigActividadEcon : new clsActividadEconomicaConfig();
                }
                else
                {
                    objMsjError.AddError("Efectivo al Instante: Primero debe guardar los cambios / verificar datos completos en Mantenimiento de Cliente.");
                    return objMsjError;
                }
            }

            var nVentasNetas = this.listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            var nUDisponible = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadDisponible).Sum(x => x.nTotalMA);
            var nCaja = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Caja).Sum(x => x.nTotalMA);
            decimal nTotalPrestamos = this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosCP).Sum(x => x.nTotalMA) +
                                 this.listBalGenEval.Where(x => x.idEEFF == EEFF.PrestamosLP).Sum(x => x.nTotalMA);

            var nOtrosIngresos = this.listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            var nUtilidadNeta = this.listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadNeta).Sum(x => x.nTotalMA);

            var nGastosFamiliares = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);
            var nGastosOperativos = this.listEstResEval.Where(x => x.idEEFF == EEFF.GastosNegocio).Sum(x => x.nTotalMA);

            var nCostoVentas = this.listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);

            decimal nPorcentaje = this.listDestCredProp.Sum(x => x.nPorcentaje);


            #region Propuesta de Crédito
            if (this.listReferencia.Count < Evaluacion.MinReferencias)
                objMsjError.AddError("Refer.: Se requiere un mínimo de dos referencias.");

            if (this.listReferencia.Where(item => item.idTipReferEval == 1).Count() == 0)
                objMsjError.AddError("Refer.: Se requiere un mínimo de 1 Referencia COMERCIAL.");

            if (this.listReferencia.Where(item => item.idTipReferEval == 2).Count() == 0)
                objMsjError.AddError("Refer.: Se requiere un mínimo de 1 Referencia PERSONAL.");

            clsMsjError objErroRef = ValidarReferencia();
            if (objErroRef.HasErrors)
                objMsjError.addList(objErroRef);

            #endregion

            #region Estados Financieros

            if (nVentasNetas == 0)
                objMsjError.AddError("Estados Financ.: Las Ventas Netas estan en CERO.");

            if (nUDisponible < 0)
                objMsjError.AddError("Estados Financ.: Utilidad Disponible es un valor NEGATIVO.");

            if (nUDisponible > 0 && nOtrosIngresos > nUtilidadNeta)
            {
                objMsjError.AddError("Estados Financ.: \"Otros Ingresos\" es mayor que la \"Utilidad Neta\".");
            }

            if (objConfigActividadEcon.idActividadEconomicaConfig == 0)
            {
                objMsjError.AddError("Estados Financ.: La actividad seleccionada no tiene un Margen de Ganancia.");
            }

            if (nGastosFamiliares == 0)
                objMsjError.AddError("Estados Financ.: Los Gastos Familiares estan en CERO.");

            if (nGastosOperativos == 0)
                objMsjError.AddError("Estados Financ.: Los Gastos Operativos estan en CERO.");

            if (nCostoVentas == 0)
                objMsjError.AddError("Estados Financ.: El Costo de Ventas está en CERO.");

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
            var objPropuestaMsjError = this.conPropuestaSimpCred.Validar();
            if (objPropuestaMsjError.HasErrors)
            {
                foreach (var err in objPropuestaMsjError.GetListError())
                    objMsjError.AddError("Prop. Crédito: " + err);
            }
            #endregion

            
            #region Archivos de Riesgos

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

            int nOperacion = (this.objEvalCred.idSolicitud != 0) ? this.objSolicitud.idOperacion : 0;

            if (nCapacidad > 80 && ((nOperacion != 2) && (nOperacion != 6)))//(nCapacidad > 80)
            {
                objMsjError.AddError("Capacidad de Pago:  El indicador capacidad de pago del solicitante debe ser menor o igual al 80%.");
            }

            else if (nCapacidad > 100 && ((nOperacion == 2) || (nOperacion == 6)))//(nCapacidad > 100)
            {
                objMsjError.AddError("Capacidad de Pago:  El indicador capacidad de pago del solicitante debe ser menor o igual al 100%.");
            }

            #endregion

            #region OpRiesgos


            DataTable dtOpRiesgos = objCapaNegocio.CNCNValidarVisitasFacilito(this.objEvalCred.idEvalCred);
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

        private clsMsjError ValidarReferencia()
        {
            clsMsjError objMsjError = new clsMsjError();

            if (listReferencia.Any(item => String.IsNullOrWhiteSpace(item.cConcepto) || String.IsNullOrWhiteSpace(item.cDireccion) || String.IsNullOrWhiteSpace(item.cComentarios)))
                objMsjError.AddError("Refer.: Los datos de las Referencias no pueden quedar en Blanco.");

            return objMsjError;
        }

        private void RecuperarEvalCredito()
        {
            DataSet ds = this.objCapaNegocio.CNRecuperarEvalCreditoFacilito(this.objEvalCred.idEvalCred);

            //-- Table[0] : Evaluacion Cualitativa
            this.listEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(ds.Tables[0]) as List<clsEvalCualitativa>;

            //-- Table[1] : Referencias del Cliente
            this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(ds.Tables[1]) as List<clsReferenciaEval>;

            //-- Table[2] : Destinos de Crédito Propuesto
            this.listDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(ds.Tables[2]) as List<clsDestCredProp>;

            //-- Actualizar Datos
            this.conReferenciasSimp.AsignarDatos(this.listReferencia);

            this.conCondiCredito.ActualizarDatos(this.objEvalCred.nCapitalPropuesto, this.listDestCredProp);
            ActualizarRcc();
        }

        private void TituloForm(string cTipEvalCred, string cMensaje = null)
        {
            if (String.IsNullOrEmpty(cMensaje))
                this.Text = String.Format("Evaluación ({0})", cTipEvalCred);
            else
                this.Text = String.Format("Evaluación ({0}) - {1}", cTipEvalCred, cMensaje);
        }

        private void ActualizarEstadosFinancieros()
        {
            string xmlBalGenEval = this.BalGenEvalToXML();
            string xmlEstResEval = this.EstResEvalToXML();

            DataTable td = this.objCapaNegocio.CNActEstFinancieroslEvalFacilito(this.objEvalCred.idEvalCred, xmlBalGenEval, xmlEstResEval);
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

        private void RecuperarDetalleEstRes(int idEvalCred)
        {
            DataSet ds = objCapaNegocio.CNRecuperarDetalleGeneralEstResultadosEvalFacilito(idEvalCred);


            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listCVentaDiario = DataTableToList.ConvertTo<clsEvalSimpCicloDiario>(ds.Tables[6]) as List<clsEvalSimpCicloDiario>;
            var listCVentaDiarioDetalle = DataTableToList.ConvertTo<clsEvalSimpCicloDiarioDetalle>(ds.Tables[7]) as List<clsEvalSimpCicloDiarioDetalle>;
            var listCVentaMensual = DataTableToList.ConvertTo<clsEvalSimpCicloMensual>(ds.Tables[9]) as List<clsEvalSimpCicloMensual>;
            var listCVentaMensualDetalle = DataTableToList.ConvertTo<clsEvalSimpCicloMensualDetalle>(ds.Tables[10]) as List<clsEvalSimpCicloMensualDetalle>;
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(ds.Tables[4]) as List<clsDeudasEval>;
            var listDeudaCuotaPago = DataTableToList.ConvertTo<clsCuotaPago>(ds.Tables[5]) as List<clsCuotaPago>;

            #region Detalle de los Estado Resultados
            var listGFamiliares = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosFamiliares
                                   select p).ToList();

            var listGOperativos = (from p in listDetEstResEval
                                   where p.idEEFF == EEFF.GastosNegocio
                                   select p).ToList();

            #endregion

            #region Detalle de las ventas y costos
            
            foreach (clsEvalSimpCicloDiario oCVentaDiario in listCVentaDiario)
                oCVentaDiario.lstDetalleDiario = listCVentaDiarioDetalle.Where(x => x.idEvalSimpCicloDiario == oCVentaDiario.idEvalSimpCicloDiario).ToList();

            foreach (clsEvalSimpCicloMensual oCVentaMensual in listCVentaMensual)
                oCVentaMensual.lstDetalleMensual = listCVentaMensualDetalle.Where(x => x.idEvalSimpCicloMensual == oCVentaMensual.idEvalSimpCicloMensual).ToList();

            #endregion

            #region Deudas con entidades financieras
            var listSalRCCDirectos = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Directo
                                      select p).ToList();

            var listSalRCCDIndirec = (from p in listSaldosRCC
                                      where p.idTipoDeuda == TipoDeuda.Indirecto
                                      select p).ToList();

            foreach (clsDeudasEval oDeudasEval in listSalRCCDirectos)
            {
                var listDCPago = (from p in listDeudaCuotaPago
                                  where p.idDeudasEval == oDeudasEval.idDeudasEval
                                  select p).ToList();

                oDeudasEval.listCuotaPago = (listDCPago.Count > 0) ? listDCPago : new List<clsCuotaPago>();
            }
            #endregion

            this.objEstadosFinancieros.listGFamiliares = listGFamiliares;
            this.objEstadosFinancieros.listGOperativos = listGOperativos;
            this.objEstadosFinancieros.listCVentaMensual = listCVentaMensual;
            this.objEstadosFinancieros.nVentasTotalNormal = listCVentaDiario.Sum(item => item.nMontoTotal) * 4;
            this.objEstadosFinancieros.nMargenCosteoActividad = (objConfigActividadEcon.idActividadEconomicaConfig != 0) ? 100 - objConfigActividadEcon.nMargenGanancia : 0;
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
            decimal nTotalVentas = this.objEstadosFinancieros.TotalVentaSimpMN();
            decimal nTotalCostos = this.objEstadosFinancieros.TotalCostosSimpMN();

            decimal nTotalGFamiliares = this.objEstadosFinancieros.TotalGFamiliaresMA();
            decimal nTotalGOperativos = this.objEstadosFinancieros.TotalGOperativosMA();
            decimal nTotalOtrosIngresos = this.conEstadosFinancieros.ListEstadoResultados.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            decimal nTotalOtrosEgresos = this.conEstadosFinancieros.ListEstadoResultados.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);

            decimal nGastosFinancieros = this.objEstadosFinancieros.TotalGFinancierosMA();

            decimal nTotalVentasMN = this.objEstadosFinancieros.TotalVentaSimpMN();
            decimal nTotalCostosMN = this.objEstadosFinancieros.TotalCostosSimpMN();
            decimal nTotalGFamiliaresMN = this.objEstadosFinancieros.TotalGFamiliaresMN();
            decimal nTotalGOperativosMN = this.objEstadosFinancieros.TotalGOperativosMN();
            decimal nTotalOtrosIngresosMN = this.conEstadosFinancieros.ListEstadoResultados.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            decimal nTotalOtrosEgresosMN = this.conEstadosFinancieros.ListEstadoResultados.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);
            decimal nGastosFinancierosMN = this.objEstadosFinancieros.TotalGFinancierosMN();

            decimal nTotalVentasME = 0;
            decimal nTotalCostosME = 0;
            decimal nTotalGFamiliaresME = 0;
            decimal nTotalGOperativosME = 0;
            decimal nTotalOtrosIngresosME = 0;
            decimal nTotalOtrosEgresosME = 0;
            decimal nGastosFinancierosME = 0;

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
                    item.nTotalMA = nTotalGOperativos;
                    item.nTotalMN = nTotalGOperativosMN;
                    item.nTotalME = nTotalGOperativosME;
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

            this.conEstadosFinancieros.ListEstadoResultados = this.listEstResEval;

            this.conEstadosFinancieros.ActualizarIndicadores();
        }

        private DataTable ArmarTablaParametrosEvaluacion()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idCli";
            drfila[1] = this.objEvalCred.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idSolicitud";
            drfila[1] = this.objEvalCred.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idEvalCred";
            drfila[1] = this.objEvalCred.idEvalCred;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_nTipoOperacion";
            drfila[1] = this.objSolicitud.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idSubProducto";
            drfila[1] = this.objSolicitud.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idModalidadCredito";
            drfila[1] = this.objSolicitud.idModalidadCredito;
            dtTablaParametros.Rows.Add(drfila);

            clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_nPlazo";
            drfila[1] = this.conCondiCredito.PlazoTotal();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_Monto";
            drfila[1] = this.conCondiCredito.Monto();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_idTipoPeriodo";
            drfila[1] = this.objEvalCred.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "e_frecuencia";
            drfila[1] = this.objEvalCred.nPlazoCuota;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private bool ValidarReglas(bool lMostrarAlerta, List<clsReglaNegocioEvaluada> aReglasEvaluadas = null)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametroSol = ArmarTablaParametrosSolicitud();
            DataTable dtParametrosEval = ArmarTablaParametrosEvaluacion();
            dtParametroSol.Merge(dtParametrosEval);

            string cNombreFormulario = this.Name;
            if (this.lEsMNB)
            {
                cNombreFormulario = "ReglasMNB_CredFacilito";
            }

            //////////////////**//////////////

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametroSol,
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
                                                                            aReglasEvaluadas: aReglasEvaluadas);
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
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            int nIdUsuRegist = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            int nIdSolicitud, nIdCliente, nIdMoneda, nIdProducto;
            decimal nValAproba;

            if (Convert.ToInt32(this.objEvalCred.idEvalCred) != 0)
            {
                clsCreditoProp oEvalCredTemp = this.conCondiCredito.CondicionesCreditoPropuesto();
                nIdSolicitud = Convert.ToInt32(this.objEvalCred.idSolicitud);
                nIdCliente = Convert.ToInt32(this.objEvalCred.idCli);
                nIdMoneda = Convert.ToInt32(this.objEvalCred.idMoneda);
                nIdProducto = Convert.ToInt32(this.objEvalCred.idProducto);
                nValAproba = Convert.ToDecimal(oEvalCredTemp.nMonto);
            }
            else
            {
                clsSolicitudCredSimp objSolReglas = this.conSolicitudSimp.objSolicitud;
                nIdSolicitud = Convert.ToInt32(objSolReglas.idSolicitud);
                nIdCliente = Convert.ToInt32(objSolReglas.idCli);
                nIdMoneda = Convert.ToInt32(objSolReglas.idMoneda);
                nIdProducto = Convert.ToInt32(objSolReglas.idProducto);
                nValAproba = Convert.ToDecimal(objSolReglas.nCapitalSolicitado);
            }

            String cNombreForm = this.Name;
            if (this.lEsMNB) cNombreForm = "ReglasMNB_CredFacilito";

            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, cNombreForm, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }
        #endregion

        #region Eventos

        private void frmEvalCredFacilito_Load(object sender, EventArgs e)
        {
            #region Solicitud
            CargarDatosComponentes();
            #endregion

            InicializarFormulario();
            HabilitarBotones(false);
            HabilitarBotonesSegunModo(clsAccionSol.SOL_DEFECTO);

            lstDetalleSaldoInter = new List<clsDetalleSaldoInterviniente>();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            var oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();

            clsMsjError objMsjError = ValidarReferencia();

            if (objMsjError.HasErrors)
            {
                string cMsj = "Corrija los siguientes " + (objMsjError.GetListError()).Count + " errores encontrados: \n\n" + objMsjError.GetErrors();

                MessageBox.Show(cMsj, this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


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
            ClsPropSimpleCred objPropCredito = this.conPropuestaSimpCred.ObtenerDatos();
            clsActividadEconomica oActPrin = objPropCredito.oActPrincipal;
            clsActividadEconomica oActSecu = new clsActividadEconomica();

            this.objEvalCred.lActSecundaria = false;

            this.objEvalCred.idActividadInternaPri = oActPrin.idActividadInterna;
            this.objEvalCred.idTipoActividadPri = oActPrin.idTipoActividad;
            this.objEvalCred.nActPriAnios = oActPrin.nAnios;
            this.objEvalCred.cActPriDireccion = oActPrin.cDireccion;
            this.objEvalCred.cActPriReferencia = oActPrin.cReferencia;
            this.objEvalCred.cActPriDescripcion = oActPrin.cDescripcion;

            this.objEvalCred.idActividadInternaSec = oActSecu.idActividadInterna;
            this.objEvalCred.idTipoActividadSec = oActSecu.idTipoActividad;
            this.objEvalCred.nActSecAnios = oActSecu.nAnios;
            this.objEvalCred.cActSecDireccion = oActSecu.cDireccion;
            this.objEvalCred.cActSecReferencia = oActSecu.cReferencia;
            this.objEvalCred.cActSecDescripcion = oActSecu.cDescripcion;

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

            DataTable td = this.objCapaNegocio.CNActualizarEvalFacilito(this.objEvalCred.idEvalCred,
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

            ValidarReglas(false, this.aReglasEvaluadas);

            //TODO: SolTechnologies - 32.Evaluacion Credito Facilito
            #region MNB - Motor de decisiones

            int idCli = Convert.ToInt32(oEvalCredTemp.idCli);
            DataTable dtMNB = new clsCNMotorDecision().ClasificacionInternaxCli(this.objEvalCred.idSolicitud);
            int clasInternaCli = Convert.ToInt32(dtMNB.Rows[0]["idClasifInterna"]);
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

                bool migra = false;

                var motorDecision = new clsMotorDecision();
                var respuestaMNB = motorDecision.CallMotorDecisionEvaluacion(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, "");

                if (respuestaMNB == null)
                    MessageBox.Show("No se ha podido establecer conexión con el Motor de decisiones", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                motorDecision.MensajesPorExcepcionesYRespuestaApi(this.objEvalCred.idSolicitud, monto, nuevoPlazo, migra, aReglasEvaluadas, respuestaMNB);

            }

            #endregion
        }

        //TODO: SolTechnologies - 37.Determina si el prospecto pertenece al MNB
        private bool validaProspectoMNB(int idCli)
        {
            bool validaProspectoMNB = false;

            //Clasificacion interna
            DataTable dtCliMNB = new clsCNMotorDecision().ClasificacionInternaMNB(idCli);
            int idClasificacionInternaCli = Convert.ToInt32(dtCliMNB.Rows[0]["idClasifInterna"]);

            //Agencia activa
            clsVarGen lstVariables = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("lMotorDecision"));
            string cAgenciasVigentes = lstVariables.cValVar.ToString();
            List<int> listAgenciasVigentes = cAgenciasVigentes.Split(',').Select(int.Parse).ToList();
            int idAgencia = clsVarGlobal.nIdAgencia;
            bool validaAgencia = false;
            foreach (var item in listAgenciasVigentes)
            {
                if (item == idAgencia)
                {
                    validaAgencia = true;
                    break;
                }
            }

            if (idClasificacionInternaCli == 9 && validaAgencia == true)
                validaProspectoMNB = true;

            return validaProspectoMNB;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.GRABAR);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
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

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null) return;

            if (!ValidarIndicadorObser())
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

            if (!this.ValidarReglas(true)) return;
            if (this.invocarExcepciones(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //TODO: SolTechnologies - 30.Se verifica el flujo de aprobacion de la solicitd del MNB
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

                    DataTable dtEnvCom = objCapaNegocio.CNEnviarAComiteCreditosFacilito(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    this.objCapaNegocio.CNGuardarHistoricoEstResEvalFacilito(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
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

                    DataTable dtEnvCom = objCapaNegocio.CNEnviarAComiteCreditosFacilito(this.objEvalCred.idEvalCred,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem,
                        xmlDestCredProp,
                        idCanal,
                        lCanalAproCredEditable
                    );

                    this.objCapaNegocio.CNGuardarHistoricoEstResEvalFacilito(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

                    new clsCNMotorDecision().ModificaNivelAprobacionMNB(this.objEvalCred.idEvalCred, idCanalAproCredTemp);

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
            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a aprobación de créditos por comité extraordinario?",
                "Enviar a Comité de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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

                DataTable dtEnvCom = objCapaNegocio.CNEnviarAComiteCreditosFacilito(this.objEvalCred.idEvalCred,
                    clsVarGlobal.User.idUsuario,
                    clsVarGlobal.dFecSystem,
                    xmlDestCredProp,
                    idCanal,
                    lCanalAproCredEditable
                );

                this.objCapaNegocio.CNGuardarHistoricoEstResEvalFacilito(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);

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

        private void conEstadosFinancieros_EERRClick(object sender, EventArgs e)
        {
            bool lGuardado = false;

            string cTipEval = clsVarApl.dicVarGen["cIDsTipEvalPYMEFacilito"];

            frmDetalleEstResFacilito formDetalleEstRes = new frmDetalleEstResFacilito(this.listDescripcionEval, this.objEvalCred.idEvalCred,
                Evaluacion.TipoCambio, Evaluacion.idMoneda, Evaluacion.MonedaSimbolo, cTipEval, this.objEvalCred.idTipEvalCred, this.objEvalCred);
            formDetalleEstRes.ShowDialog();

            lGuardado = formDetalleEstRes.lGuardado;
            if (lGuardado == true)
            {
                this.objEstadosFinancieros.listGFamiliares = formDetalleEstRes.GFamiliares();
                this.objEstadosFinancieros.listGOperativos = formDetalleEstRes.GOperativos();

                this.objEstadosFinancieros.listCVentaMensual = formDetalleEstRes.EvalCVentaMensual();
                this.objEstadosFinancieros.nVentasTotalNormal = formDetalleEstRes.EvalCVentaNormal();
                this.objEstadosFinancieros.nMargenCosteoActividad = (objConfigActividadEcon.idActividadEconomicaConfig != 0) ? 100 - objConfigActividadEcon.nMargenGanancia : 0;

                ActualizarEstadoResultados();
                ActualizarEstadosFinancieros();
                this.objCapaNegocio.CNGuardarHistoricoEstResEvalFacilito(this.objEvalCred.idEvalCred, clsVarGlobal.User.idUsuario);
            }

            formDetalleEstRes.Dispose();
        }

        private void conCondiCredito_ActividadInternaSelectedIndexChanged(object sender, EventArgs e)
        {
            this.conPropuestaSimpCred.ActualizarActividadInterna(this.conCondiCredito.ObtenerIdActividadInterna());
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

        private void conEstadosFinancieros_CellValueChangedEstadosFinancieros(object sender, DataGridViewCellEventArgs e)
        {
            decimal nCapitalParacomercio = 0;
            this.conEstadosFinancieros.ActualizarPorEstadosFinancieros(this.listBalGenEval, this.listEstResEval, this.listInventario, this.objEvalCred.nTotalPasivoAC, nCapitalParacomercio);
            ActualizarRcc();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idSolicitud, idCli;
            if (Convert.ToInt32(this.objEvalCred.idEvalCred) != 0)
            {
                idSolicitud = this.objEvalCred.idSolicitud;
                idCli = this.objEvalCred.idCli;
            }
            else
            {
                idSolicitud = this.conSolicitudSimp.objSolicitud.idSolicitud;
                idCli = this.conSolicitudSimp.objSolicitud.idCli;
            }

            if (idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(idSolicitud, idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void conCondiCredito_SectorEconSelectedIndexChanged(object sender, EventArgs e)
        {
            clsEvalCred oEvalCredTemp = this.conCondiCredito.CondicionesCreditoYDestino();
            this.objEvalCred.idSectorEcon = oEvalCredTemp.idSectorEcon;

            this.conEstadosFinancieros.ActualizarPorSectorEconomico(this.objEvalCred.idSectorEcon);
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objSolicitudSimp.idSolicitud > 0 && this.objSolicitudSimp.idEstado.In(0, 1))
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objSolicitudSimp.idSolicitud, !this.conSolicitudSimp.lEditable);
                frmCargaArchivo.ShowDialog();
            }
            else if (this.objEvalCred.idSolicitud > 0)
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

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            //TODO: SolTechnologies - 33.Muestra el resultado del score en el btn Excepcion
            int idSolicitud = this.objEvalCred.idSolicitud;
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

                        //return;
                    }
                }
            }

            if (Convert.ToInt32(this.objEvalCred.idEvalCred) != 0)
            {
                List<clsReglaNegocioEvaluada> aReglasEvaluadas = new List<clsReglaNegocioEvaluada>();
                this.ValidarReglas(false, aReglasEvaluadas);

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

            }
            else
            {
                this.conSolicitudSimp_EventoValidarReglas(null, null);
            }
            this.invocarExcepciones(false);
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
            this.conEstadosFinancieros.Refresh();
        }

        private void conCondiCredito_PlazoChanged(object sender, EventArgs e)
        {

        }

        private int obtenerIdSolicitud() 
        {
            if (Convert.ToInt32(this.objEvalCred.idEvalCred) != 0)
            {
                return this.objEvalCred.idSolicitud;
            }
            else
            {
                return this.conSolicitudSimp.objSolicitud.idSolicitud;
            }
        }

        #endregion

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
            frmGestObs.lEditar = this.objEvalCred.lEditar;
            frmGestObs.idEtapaEvalCred = 3;
            frmGestObs.nModoFunc = 2;
            frmGestObs.idSolicitud = obtenerIdSolicitud();
            frmGestObs.ConfigSelecFiltros(true, false, false, true);
            frmGestObs.ConfigHabilitarFiltros(false, true, true, false);
            frmGestObs.ShowDialog();
        }

        private bool ValidarIndicadorObser()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(obtenerIdSolicitud(), 3);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>("lResolCom"));
        }

        #endregion

        private void boton1_Click(object sender, EventArgs e)
        {
            if (conSolicitudSimp.txtCodSolicitud.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar una solicitud de crédito válido.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTasaNegociable frm = new frmTasaNegociable();
            frm.flowLayoutPanel2.Visible = false;
            frm.grbDato_Solicitud.Visible = false;
            frm.Size = new System.Drawing.Size(705, 500);
            frm.lTasafrm = true;
            frm.BuscarSolicitud(Convert.ToInt32(conSolicitudSimp.txtCodSolicitud.Text));
            if (frm.lTasaNegociada == true)
            {
                frm.idSolicitud_frm = Convert.ToInt32(conSolicitudSimp.txtCodSolicitud.Text);
                frm.ShowDialog();
            }
        }

        
    }
}
