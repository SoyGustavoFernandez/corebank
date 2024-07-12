 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using EntityLayer;
using CRE.CapaNegocio;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.Servicio;
using GEN.Servicio;
using EntityLayer.MotorDecisionWebService;
using System.Globalization;
using CRE.ControlBase;
using System.Windows.Interop;
using CLI.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmRegistroSolicitudCredito : frmBase
    {
        #region Variables Globales
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        CRE.CapaNegocio.clsCNSolicitudAmortiza cnsoliAmortiza = new CRE.CapaNegocio.clsCNSolicitudAmortiza();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        clsSolicitudAmortiza soliAmortiza = null;
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();
        List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = new List<clsMantenimientoPaqueteSeguro>();       
        private clsCNPaqueteSeguro objPaqueteSeguroCN = new clsCNPaqueteSeguro();
        DataTable dtCreditosAmp;
        DataTable dtSolicitud = new DataTable("dtSolicitud");
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;
        int idTasa = 0, nContador = 0, idEvaluacion, CodPro = 1, nEstado = 0, idAgencia = clsVarGlobal.nIdAgencia, idPreSolicitud = 0;
        bool indClasif = false, lIndicaDatoBasico = false;
        int idCuenta = 0, idSoliCambio = 0, nidTipoPersona = 0;//Se usará en la tabla de Parámetros
        string cComentAproba = "";
        char Transaccion = Convert.ToChar("I");
        int nTipoCliente;
        clsCNVincAseProm cnasepromo = new clsCNVincAseProm();
        CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();
        private const string cTituloMsjes = "Registro de solicitud de créditos";
        private bool lConTasaNegociable = false;
        private decimal nTasaCompensatoriaRefi = 0.00m;
        private decimal nTasaMoratoriaRefi = 0.00m;
        
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();
        public int idPaqueteSeguro = 0;

        private int idTipoTasaCredito = 0;
        private int idCuentaCredito = 0;
        
        private decimal nTasaCampana = 0.0000m;       
        private int idTasaRepro = 0;
        private decimal nTasaRepro = 0.0000m;
        private decimal nTasaMoraRepro = 0.0000m;
        
        private int idCreditosPreAprobados = 0;
        private int idActividadInterna = 0;
        private clsVisita objSel; 
        private bool lUsuarioCampana = false;
        private bool lDesplazamientoEOB = false;        
        private List<clsDatosCampana> lstDatosCampana = new List<clsDatosCampana>();
        private bool lCumpleCondicionesCampana = false;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private bool lEditar = false;
        private bool lRegistrar = false;
        private bool lOpinionRiesgos;

        private bool lPerteneceOtraAgencia = false;
        private int idClasificacionInterna;
        private string cClasifInternaTmp;
        public bool lFrmPosConsolidada = false;

        ClsOfertaClienteExclusivo objOferta;
        List<ClsProductoExclusivo> listProd;

        int[] nArrayIdCampaniaRef;
        int nAlmacenarTasaCredito = 0;
 
        enum eTipoPeriodoCred {FechaFija = 1 , PeriodoFijo = 2 , CuotasLibres = 3 }
        enum ePeriodoCred
        {Diario         = 1,
         Quinquenal     = 2,
         Mensual        = 3,	
         Bimensual      = 4,	
         Trimestral     = 5,	
         Cuatrimestral  = 6,	
         Quinquemestral = 7,	
         Semestral      = 8,	
         Anual          = 9,	
         Unicuota       = 10
        }

        enum eOperacion 
        { 
          Otorgamiento           = 1, 
          Refinanciacion         = 2, 
          Reprogramacion         = 3, 
          Ampliacion             = 4, 
          CartaFianza            = 5, 
          RefinanciacionNovacion = 6
        }

        #endregion

        public frmRegistroSolicitudCredito()
        {      
            InitializeComponent();

            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;

            cboTipoCredito.CargarProducto(CodPro);
            cboEstadoCredito1.CargaEstado(0);
            cargarDatosSolicitud(0);
            nContador = 0;
            cboEstadoCredito1.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 1;
            cboSubTipoCredito.SelectedValue = 2;
            cboModDesemb1.SelectedValue = 0;
            this.txtCodCliente.Enabled = true;
            this.txtCodigoSol.Enabled = true;
            this.btnBusCliente.Enabled = true;
            this.btn_Vincular2.Enabled = false;
            this.btnGestObs.Enabled = false;
            this.conCreditoPeriodo.limpiarControles();
            cboFuenteRecurso1.CargarItems();
            mostrarObjetosAmpliacion(false);
            CargarComponenteCampana();
            //this.conActividadCIIU1.cboActividadInterna1.Width = 242;
            //this.conActividadCIIU1.cboActividadEco.Width = 242;
            //this.conActividadCIIU1.cboGrupoCiiu.Width = 242;
            //this.conActividadCIIU1.cboCIIU.Width = 242;

            GEN.BotonesBase.btnBusSolicitud btn = new GEN.BotonesBase.btnBusSolicitud();
            this.btnAsesor.BackgroundImage = btn.BackgroundImage;

            nudNroCuoGracia.Enabled = false;

            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
        }

        public frmRegistroSolicitudCredito(ClsOfertaClienteExclusivoMejorado objOferta)
        {
            InitializeComponent();


            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;

            cboTipoCredito.CargarProducto(CodPro);
            cboEstadoCredito1.CargaEstado(0);
            cargarDatosSolicitud(0);
            nContador = 0;
            cboEstadoCredito1.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 1;
            cboSubTipoCredito.SelectedValue = 2;
            cboModDesemb1.SelectedValue = 0;
            this.txtCodCliente.Enabled = true;
            this.txtCodigoSol.Enabled = true;
            this.btnBusCliente.Enabled = true;
            this.btn_Vincular2.Enabled = false;
            this.btnGestObs.Enabled = false;
            this.conCreditoPeriodo.limpiarControles();
            cboFuenteRecurso1.CargarItems();
            mostrarObjetosAmpliacion(false);
            CargarComponenteCampana();

            lFrmPosConsolidada=true;
            GEN.BotonesBase.btnBusSolicitud btn = new GEN.BotonesBase.btnBusSolicitud();
            this.btnAsesor.BackgroundImage = btn.BackgroundImage;

            nudNroCuoGracia.Enabled = false;

            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
    
            //nudCuotas.Value = 0;
            //cargaload();
            AccionBusCliente(objOferta);

        }

        #region Eventos
        private void BuscarClientereferenciado(string cDni)
        {
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            DataTable tablaCli = listarCli.ListarClientes("1", cDni, 0);

            DatoBusqueda modelbusqueda=new DatoBusqueda();
              
            if (tablaCli.Rows.Count>0)
            {
                    modelbusqueda.pcNroDoc = tablaCli.Rows[0]["cDocumentoID"].ToString();
                if (ValidaCliBaseNegativa(cDni, clsVarGlobal.idModulo,clsVarGlobal.lBaseNegativa))
                {                    
                    return;
                }

            modelbusqueda.idEstadoCli = (int)tablaCli.Rows[0]["idEstadoCli"];
            modelbusqueda.pcCodCli = tablaCli.Rows[0]["idCli"].ToString();
            modelbusqueda.pcNomCli = tablaCli.Rows[0]["cNombre"].ToString();                                
            modelbusqueda.pcDireccion = tablaCli.Rows[0]["cDireccion"].ToString();
            modelbusqueda.pnTipoPersona = (int)tablaCli.Rows[0]["IdTipoPersona"];
            modelbusqueda.pcCodCliLargo = tablaCli.Rows[0]["cCodCliente"].ToString();
            modelbusqueda.pnTipoDocumento = (int)tablaCli.Rows[0]["idTipoDocumento"];
            modelbusqueda.pIndicaDatoBasico = (bool)tablaCli.Rows[0]["lIndDatosBasic"];
            modelbusqueda.pcTipoDocumento = tablaCli.Rows[0]["cTipoDoc"].ToString();
            modelbusqueda.pnIdClasifInt = tablaCli.Rows[0]["idClasifInterna"].ToString();
            modelbusqueda.pcClasifInt = tablaCli.Rows[0]["cClasifInterna"].ToString();
            modelbusqueda.pnIdCondDom = (int)tablaCli.Rows[0]["idCondDomicilio"] ;
            modelbusqueda.pcRucCli = tablaCli.Rows[0]["cDocumentoAdicional"].ToString();
            modelbusqueda.idTipoCliente = (tablaCli.Rows[0]["idTipoCliente"] == DBNull.Value) ? 0 : Convert.ToInt32(tablaCli.Rows[0]["idTipoCliente"]);
            modelbusqueda.nAniosActEco = Convert.ToInt32(tablaCli.Rows[0]["nAniosActEco"]);
            this.idActividadInterna = Convert.ToInt32(tablaCli.Rows[0]["idActividadInterna"]);
            this.idClasificacionInterna = Convert.ToInt32(tablaCli.Rows[0]["idClasificacionInterna"]);

            if (modelbusqueda.idEstadoCli.In(2, 4))
                {
                    if (modelbusqueda.pnTipoPersona == 1)
                    {
                        MessageBox.Show("El cliente se encuentra en estado FALLECIDO","Búsqueda de clientes",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (modelbusqueda.pnIdCondDom.In(3, 4))
                        {
                            MessageBox.Show("La condición del domicilio del cliente se encuentra como NO HABIDO y en estado BAJA DE OFICIO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("El cliente se encuentra en estado BAJA DE OFICIO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        
                    }
                }
            if (modelbusqueda.idEstadoCli.In(1, 3) && modelbusqueda.pnIdCondDom.In(3, 4))
                {
                    MessageBox.Show("La condición del domicilio del cliente se encuentra como NO HABIDO", "Búsqueda de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            if (modelbusqueda.pcCodCli == "" || string.IsNullOrEmpty(modelbusqueda.pcCodCli))
            {
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCliente.Text = "0";
                txtNombre.Text = "";
                txtNroDocIde.Text = "";
                idClasificacionInterna = 0;
            }
            else
            {
                if (Convert.ToBoolean(modelbusqueda.pIndicaDatoBasico) == true)
                {
                    MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lIndicaDatoBasico = true;
                    txtCodInst.Text = "";
                    txtCodAge.Text = "";
                    txtCodCliente.Text = "0";
                    txtNombre.Text = "";
                    txtNroDocIde.Text = "";
                    idClasificacionInterna = 0;
                    return;
                }

                //idClasificacionInterna = Convert.ToInt32(modelbusqueda.pcClasifInt);
                lblCalificacionInterna.Text = modelbusqueda.pcClasifInt;

                CambiarClasificacionInterna(Convert.ToInt32(modelbusqueda.pcCodCli), idClasificacionInterna);

                lblCalificacionInterna.Text = cClasifInternaTmp;

                txtCodInst.Text = modelbusqueda.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = modelbusqueda.pcCodCliLargo.Substring(3, 3);
                txtCodCliente.Text = modelbusqueda.pcCodCliLargo.Substring(6);
                txtNombre.Text = modelbusqueda.pcNomCli;
                txtNroDocIde.Text = modelbusqueda.pcNroDoc;
                nTipoCliente = modelbusqueda.idTipoCliente;

                this.nudAniosActEco.Value = modelbusqueda.nAniosActEco;
                //this.idActividadInterna = FrmBus.idActividadInterna;

                if (this.idActividadInterna > 0)
                {
                    this.conActividadCIIU1.cargarActividadInterna(this.idActividadInterna);
                    this.conActividadCIIU1.Enabled = false;
                }

                initClienteRecurrente(nTipoCliente);
                btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);

            }
        }
        private void AccionBusCliente(ClsOfertaClienteExclusivoMejorado objOferta)
        {
            limpiar();
            txtCodCliente.Enabled = true;
            txtCodigoSol.Enabled = true;
            BuscarClientereferenciado(objOferta.cDocumentoID);

            if (lIndicaDatoBasico)
            {
                return;
            }
            Int32 idcli = 0;
            idcli = Convert.ToInt32(txtCodCliente.Text);
            AlertaCreditosVinculados(idcli);
            if (idcli == 0)
            {
                this.txtCodigoSol.Enabled = true;
                this.txtCodCliente.Enabled = true;
                this.txtCodCliente.Focus();
                return;
            }
            else
            {
                this.btnGrabar1.Enabled = true;
                this.txtCodCliente.Enabled = false;
                this.btnBusCliente.Enabled = false;
                this.txtCodigoSol.Enabled = false;
                clsCNBuscarCli listarCli2 = new clsCNBuscarCli();
                DataTable dtCliente = listarCli2.ListarclixIdCli(idcli);
                if (dtCliente.Rows.Count > 0)
                {
                    nidTipoPersona = Convert.ToInt32(dtCliente.Rows[0]["IdTipoPersona"]);
                    deshabilitarTipoSeguro();
                }
                buscarSolicitudClienteOferta(objOferta);

            }
            btnBusCliente.Enabled = false;
            btnCancelar1.Enabled = false;
        }
        //public void cargaload()
        //{
        //    conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
        //    conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
        //    dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;

        //    cboPromotores1.filtrarPorCanal(1);

        //    activarControlObjetos(this, EventoFormulario.INICIO);
        //    lblTipoTasaCredito.Text = "";
        //    //cboPromotores1.ListarPromotoresCredYNinguno(0);
        //    cboPromotores1.SelectedIndex = -1;
        //    //cboPersonalCreditos.SelectedIndex = -1;
        //    cboEstadoCredito1.SelectedValue = 0;
        //    cboDestinoCredito.SelectedIndex = -1;

        //    txtTasCompensatoriaMin.TabStop = false;
        //    txtTasCompensatoriaMax.TabStop = false;
        //    btnExcepciones.Enabled = false;

        //    /******************** Convierte a partir de si_finVaribale->cProductosCampRefi ***************************/
        //    string cIdCampania = clsVarApl.dicVarGen["cProductosCampRefi"];
        //    String[] cArrayIdCampania;
        //    cArrayIdCampania = cIdCampania.Split(',');
        //    nArrayIdCampaniaRef = Array.ConvertAll<string, int>(cArrayIdCampania, int.Parse);

        //    dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
        //    /****************************************************************************************************/


        //    cboDetalleGasto1.listarDetalleGastoEnSolicitud();
        //    cboDetalleGasto1.SelectedIndex = -1;
        //    cboDetalleGasto1.SelectedIndexChanged += cboDetalleGasto1_SelectedIndexChanged;
        //    conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
        //    conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
        //    dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
        //}
        private void frmRegistroSolicitudCredito_Load(object sender, EventArgs e)
        {
            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;

            cboPromotores1.filtrarPorCanal(1);

            activarControlObjetos(this, EventoFormulario.INICIO);
            lblTipoTasaCredito.Text = "";
            //cboPromotores1.ListarPromotoresCredYNinguno(0);
            cboPromotores1.SelectedIndex = -1;
            //cboPersonalCreditos.SelectedIndex = -1;
            cboEstadoCredito1.SelectedValue = 0;
            cboDestinoCredito.SelectedIndex = -1;

            txtTasCompensatoriaMin.TabStop = false;
            txtTasCompensatoriaMax.TabStop = false;
            btnExcepciones.Enabled = false;

            /******************** Convierte a partir de si_finVaribale->cProductosCampRefi ***************************/
            string cIdCampania = clsVarApl.dicVarGen["cProductosCampRefi"];
            String[] cArrayIdCampania;
            cArrayIdCampania = cIdCampania.Split(',');
            nArrayIdCampaniaRef = Array.ConvertAll<string, int>(cArrayIdCampania, int.Parse);

            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            /****************************************************************************************************/            


            cboDetalleGasto1.listarDetalleGastoEnSolicitud();
            cboDetalleGasto1.SelectedIndex = -1;
            cboDetalleGasto1.SelectedIndexChanged += cboDetalleGasto1_SelectedIndexChanged;
            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
            dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;

            if (cboDetalleGasto1.SelectedIndex != -1)
            {
                CargarPaqueteSeguro(idPaqueteSeguro, false);
                cboPaqueteSeguro1.Enabled = false;
            }

            validarPlanesDeSeguroActivados();
        }

        private void validarPlanesDeSeguroActivados()
        {
            //Obtengo la lista de todos los paquetes de seguro vigentes
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (lstPaqueteSeguros.Count == 0)
            {
                lblPaqueteSeguro.Visible = false;
                cboPaqueteSeguro1.Visible = false;
            }
        }

        private bool validarEnvioSolicitudAprobacion()
        {
            DataTable dtValidarEnvioSolApro = (new clsCNEvaluacion()).validarEnvioSolicitudAprobacion(Convert.ToInt32(txtCodigoSol.Text.Trim()));
            bool lValido = false;
            if (dtValidarEnvioSolApro.Rows.Count > 0)
            {
                lValido = Convert.ToBoolean(dtValidarEnvioSolApro.Rows[0]["lValido"]);
            }

            if (lValido)
            {
                this.enviarAprobacion();
                /*  Guardar Expedientes - Solicitud de Credito  */
                clsProcesoExp.guardarCopiaExpediente("Solicitud de Credito", Convert.ToInt32(txtCodigoSol.Text.Trim()), this);
                return true;
            }
            return false;
        }

        private void enviarAprobacion()
        {

            if (!grabarEvalCredBasica())
                return;

            DialogResult dg = MessageBox.Show("¿Seguro que deseas enviar a aprobación de Créditos?",
                "Enviar a Aprobación de Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dg == DialogResult.Yes)
            {
                //clsCreditoProp oEvalCredTemp = this.conCreditoTasa.ObtenerCreditoPropuesto();

                // ------------------------------------------------------------------------
                int idCanal = 0;
                int idCanalAproCredTemp = 0;
                int nCantidadCanales = 0;
                int lCanalAproCredEditable = 0;

                DataSet dsCanales = (new clsCNEvaluacion()).DeterminarCanalesAprobacion(clsVarGlobal.User.idEstablecimiento,
                    clsVarGlobal.User.idTipoEstablec,
                    Convert.ToInt32(txtCodigoSol.Text),
                    Convert.ToInt32(txtCodCliente.Text),
                    Convert.ToDecimal(txtMonto.Text),
                    Convert.ToInt32(cboSubProducto.SelectedValue),
                    Convert.ToInt32(this.cboOperacionCre1.SelectedValue)
                    );

                if (dsCanales.Tables.Count > 0)
                {
                    nCantidadCanales = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["nCantidadCanales"]);

                    if (nCantidadCanales == -1)
                    {
                        MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (nCantidadCanales == 0)
                    {
                        MessageBox.Show(dsCanales.Tables[0].Rows[0]["cMensaje"].ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else { return; }

                if (nCantidadCanales == 1)
                {
                    idCanal = Convert.ToInt32(dsCanales.Tables[1].Rows[0]["idCanalAproCred"]);
                }
                else
                {
                    this.btnEnviar.Enabled = false;
                    this.btnCargaArhivos.Enabled = false;

                    lCanalAproCredEditable = Convert.ToInt32(dsCanales.Tables[0].Rows[0]["lCanalAproCredEditable"]);

                    if (lCanalAproCredEditable == 1)    // Se puede cambiar el canal de otorgamiento
                    {
                        frmCanalResolucionCreditos frmCanalResolCred = new frmCanalResolucionCreditos(dsCanales.Tables[1]);
                        frmCanalResolCred.ShowDialog();
                        idCanalAproCredTemp = frmCanalResolCred.idCanalAproCred;

                        if (idCanalAproCredTemp > 0)
                            idCanal = idCanalAproCredTemp;
                        else
                        {
                            MessageBox.Show("No se seleccionó ningún canal de aprobación de créditos, por lo tanto se cancelará en envío a aprobación de créditos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnEnviar.Enabled = true;
                            this.btnCargaArhivos.Enabled = true;
                            return;
                        }
                    }
                }
                this.btnEnviar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;

                DataTable dtResultadoEnvio = (new clsCNEvaluacion()).enviarSolicitudAprobacion(
                     Convert.ToInt32(txtCodigoSol.Text),
                     Convert.ToInt32(txtNumEva.Text),
                     Convert.ToInt32(this.cboOperacionCre1.SelectedValue),
                     clsVarGlobal.User.idUsuario,
                     clsVarGlobal.dFecSystem,
                     idCanal,
                     false);

                if (Convert.ToInt32(dtResultadoEnvio.Rows[0]["idResultado"]) == 1)
                {
                    MessageBox.Show("" + dtResultadoEnvio.Rows[0]["cMensaje"].ToString(), "Solicitud Enviada a Aprobacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.btnGrabar1.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    this.btnEnviar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("" + dtResultadoEnvio.Rows[0]["cMensaje"].ToString(), "Error de Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.btnEnviar.Enabled = false;
                    this.btnCargaArhivos.Enabled = false;
                }

            }
        }

        private bool grabarEvalCredBasica()
        {
            DataTable dtResultadoServidor = (new clsCNEvaluacion()).grabarEvalCredBasico(
                Convert.ToInt32(txtCodigoSol.Text), 0, clsVarGlobal.User.idUsuario);
            if (Convert.ToInt32(dtResultadoServidor.Rows[0]["idResultado"]) == 1)
            {
                this.txtNumEva.Text = Convert.ToString(dtResultadoServidor.Rows[0]["idEvalCred"]);
                return true;
            }
            else
            {
                MessageBox.Show("" + dtResultadoServidor.Rows[0]["cMensaje"].ToString(), "Error Evaluacion Basica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void cboProducto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(CodPro);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
                cboSubTipoCredito.CargarProducto(999);
            }

            asignarTasa();
        }

        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(CodPro);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
                cboProducto.CargarProducto(999);
            }
            asignarTasa();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                CodPro = Convert.ToInt32(cboProducto.SelectedValue);

                if (Convert.ToInt32(this.cboOperacionCre1.SelectedValue) == 3) //REPROGRAMACION
                {
                    cboSubProducto.CargarProducto(CodPro, false, false);
                }
                else
                {
                    cboSubProducto.CargarProducto(CodPro);
                }
            }
            else
            {
                cboProducto.SelectedIndex = 0;
                cboSubProducto.CargarProducto(999);
            }
            asignarTasa();
        }

        private void nudCuotas_ValueChanged(object sender, EventArgs e)
        {
            this.conCreditoPeriodo.actualizarCuotas((int)nudCuotas.Value);
            int? idOperacion = (int?)cboOperacionCre1.SelectedValue;
            if(idOperacion != null && idOperacion == 3)
                return;
            asignarTasa();
        }

        private void nudPlazo_ValueChanged(object sender, EventArgs e)
        {
            //CalcularDiasGracia();
            int? idOperacion = (int?)cboOperacionCre1.SelectedValue;
            if (idOperacion != null && idOperacion == 3)
                return;
            asignarTasa();
        }

        private void cboSubProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtTasaCompensatoria.Enabled = true;
            if (cboSubProducto.SelectedIndex > -1)
            {
                int idProducto = Convert.ToInt32(this.cboSubProducto.SelectedValue);
                int idOperacion = Convert.ToInt32(cboOperacionCre1.SelectedValue);
                if (idProducto > 0 && !idOperacion.In(2,3,6))//IN(refinanciamiento, reprogramacion, novacion)
                {
                    this.cboTipoLocalActividad.cargarTipoLocalActividad(idProducto);
                this.cboTipoLocalActividad.SelectedIndex = -1;
                    this.cboDestinoCredito.cargarEspecificos(idProducto);
                asignarTasa();
                }
                else if (idOperacion.In(2, 6) && idProducto.In(nArrayIdCampaniaRef))
                {
                    asignarTasa();
                }
                else
                {
                    asignarTasa();
                }
            }
            else
            {
                txtTasaMora.Text = "0";
            }
        }

        private void txtCodigoSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Int32 CodSol = Convert.ToInt32(txtCodigoSol.Text);
                cargarDatosSolicitud(CodSol);

                if (dtSolicitud.Rows.Count > 0)
                {
                    int idEstadoSol = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);
                    grbDato_Solicitud.Enabled = false;
                    cboModalidadCredito.Enabled = false;
                    cboModDesemb1.Enabled = false;
                    this.btnGestObs.Enabled = true;
                    if (!(idEstadoSol > 1) || idEstadoSol == 11)
                    {
                        this.grbDato_Solicitud.Enabled = false;
                        cboModalidadCredito.Enabled = false;
                        cboModDesemb1.Enabled = false;
                        this.txtCodCliente.Enabled = false;
                        this.btnBusCliente.Enabled = false;
                        this.btnEnviar.Enabled = (idEstadoSol == 1) ? true : false;
                        this.btnEditar.Enabled = true;
                        this.btnEditar.Visible = true;
                        this.btnGrabar1.Enabled = false;
                        this.btnGrabar1.Visible = false;
                        this.txtCodigoSol.Enabled = false;
                    }
                    else
                    {
                        
                        btnEnviar.Enabled = false;
                        btnGrabar1.Enabled = false;
                        return;
                    }
                    this.btn_Vincular2.Enabled = true;

                    btnExcepciones.Enabled = true;


                }
                else
                {
                    MessageBox.Show("No se encuentra datos de la Solicitud", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtCodCliente.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    this.txtCodigoSol.Enabled = true;
                    this.btnBusCliente.Enabled = true;
                    this.btnGestObs.Enabled = false;
                    this.txtCodCliente.Focus();
                    this.limpiar();
                    return;
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validarSolicitudAct())
            {
                return;
            }
            if (validarBloqueoEAI())
            {
                return;
            }
            if (validarSubProductoEAI())
            {
                return;
            }
            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            lRegistrar = true;
            grabar();
            lRegistrar = false;
            /*
            clsEjecucionEncuesta objEjecutarEncuesta = new clsEjecucionEncuesta(this.Name, typeof(frmRegistroSolicitudCredito).Namespace, Convert.ToInt32(txtCodCliente.Text), txtNroDocIde.Text);
            objEjecutarEncuesta.RevisaEjecucionEncuesta();
             */
        }

        private bool validarRefiNovacion()
        {
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)
            {
                if (dtgCuentaCreditoVinculado.Rows.Count <= 0)
                {
                    MessageBox.Show("Debe vincular al menos un crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (estaEnDatos(clsVarApl.dicVarGen["nProdPermitRefinanciar"], Convert.ToInt32(cboSubProducto.SelectedValue)))
                {
                    MessageBox.Show("Debe vincular al menos un crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }


        private bool ValidarSeguros()
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
            if (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado) //1	SEGURO MULTIRIESGO
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                {
                    MessageBox.Show("El seguro multiriesgo solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Ir al tab 2
                    return false;
                }
                //VERIFICAR QUE NO EXCEDA DE LOS 100,000.00
                if (Convert.ToDecimal(txtMonto.Text) > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo supera los " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //VERIFICAR QUE SE CUMPLA EL MONTO MINIMO
                if (Convert.ToDecimal(txtMonto.Text) < Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo para aplicar multiriesgo debe ser mayor o igual a " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado = false;
                    return false;
                }
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1)
                {
                    //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                    if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                    {
                        //VERIFICAR SI TIENE OTRO SEGURO MULTIRIESGO
                        DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && fila.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"]) //FILTRANDO MULTIRIESGO
                                      select fila).FirstOrDefault();
                        if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    //VERIFICAR QUE EN LOS DATOS DE DIRECCION PRINCIPAL, EL CLIENTE TENGA LOS CINCO CAMPOS AGREGADOS EN ESTE REQUERIMIENTO
                    DataTable tbDirCli = new clsCNDirecCli().ListaDirCli(objSolicitudCreditoCargaSeguro.idCli);
                    DataRow ieRegistro = (from fila in tbDirCli.AsEnumerable()
                                          where fila.Field<bool>("lDirPrincipal") == true
                                          select fila).FirstOrDefault();
                    if (ieRegistro == null)
                    {
                        MessageBox.Show("No tiene registrado una dirección. No puedes seleccionar este seguro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        bool tieneCamposInvalidos = tbDirCli.AsEnumerable().Any(row =>
                        {
                            int nAñoConstruccion = Convert.ToInt32(string.IsNullOrEmpty(row["nAñoConstruccion"].ToString()) ? 0 : row["nAñoConstruccion"]);
                            int nPisos = Convert.ToInt32(string.IsNullOrEmpty(row["nPisos"].ToString()) ? 0 : row["nPisos"]);
                            string nSotanos = row["nSotanos"].ToString();
                            int nIdTipoEstructura = Convert.ToInt32(string.IsNullOrEmpty(row["nIdTipoEstructura"].ToString()) ? 0 : row["nIdTipoEstructura"]);
                            int nIdUsoDelPredio = Convert.ToInt32(string.IsNullOrEmpty(row["nIdUsoDelPredio"].ToString()) ? 0 : row["nIdUsoDelPredio"]);
                            return nAñoConstruccion == 0 || nAñoConstruccion < Convert.ToInt32(clsVarApl.dicVarGen["nAnioMinimoConstruccion"]) || nPisos == 0 || string.IsNullOrEmpty(nSotanos) || nIdTipoEstructura == 0 || nIdUsoDelPredio == 0;
                        });
                        if (tieneCamposInvalidos)
                        {
                            MessageBox.Show("Primero actualiza la dirección y completa los datos exigidos para el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            #region PlanesDeSeguro
            else if (lstPaqueteSeguros.Select(p => p.idPaqueteSeguro).ToList().Contains(objSolicitudCreditoCargaSeguro.idPaqueteSeguro))
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoCargaSeguro.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoCargaSeguro.idCli))
                {
                    MessageBox.Show("Los planes de seguro solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                if (objSolicitudCreditoCargaSeguro.idOperacion != 2 && objSolicitudCreditoCargaSeguro.idOperacion != 4)
                {
                    DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(objSolicitudCreditoCargaSeguro.idCli);
                    DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                  where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                                  select fila).FirstOrDefault();
                    if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion == 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (dr != null && objSolicitudCreditoCargaSeguro.idOperacion != 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            limpiar();
            txtCodCliente.Enabled = true;
            txtCodigoSol.Enabled = true;
            BuscarCliente();
            
            if (lIndicaDatoBasico)
            {
                return;
            }
            Int32 idcli = 0;
            idcli = Convert.ToInt32(txtCodCliente.Text);
            AlertaCreditosVinculados(idcli);
            if (idcli == 0)
            {
                this.txtCodigoSol.Enabled = true;
                this.txtCodCliente.Enabled = true;
                this.txtCodCliente.Focus();
                return;
            }
            else
            {
                this.btnGrabar1.Enabled = true;
                this.txtCodCliente.Enabled = false;
                this.btnBusCliente.Enabled = false;
                this.txtCodigoSol.Enabled = false;
                clsCNBuscarCli listarCli2 = new clsCNBuscarCli();
                DataTable dtCliente = listarCli2.ListarclixIdCli(idcli);
                if (dtCliente.Rows.Count > 0)
                {
                    nidTipoPersona = Convert.ToInt32(dtCliente.Rows[0]["IdTipoPersona"]);
                    deshabilitarTipoSeguro();
                }
                buscarSolicitudCliente(idcli);

            }
        }

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarSolicitudcliente();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCancelar1_Click_1(object sender, EventArgs e)
        {
            this.limpiarControles();
        }

        private void btn_Vincular2_Click(object sender, EventArgs e)
        {
            Int32 nIdCliente = Convert.ToInt32(this.txtCodCliente.Text);
            Int32 nIdSolCre = Convert.ToInt32(this.txtCodigoSol.Text);
            Int32 TipoCred = Convert.ToInt32(cboTipoCredito.SelectedValue);
            Int32 nSolicitud = Convert.ToInt32(txtCodigoSol.Text);
            if (TipoCred == 3)
            {
                FrmBusEvaConsumo frmBusEvaCon1 = new FrmBusEvaConsumo();
                frmBusEvaCon1.cargadatos(nIdCliente, nIdSolCre, TipoCred);
                txtNumEva.Text = Convert.ToString(frmBusEvaCon1.nNumEvalCons);
            }
            else if (TipoCred.In(2, 10, 11, 12, 13))
            {
                frmBusEvaEmpr frmBusEvaEmpr = new frmBusEvaEmpr();
                frmBusEvaEmpr.cargadatos(nIdCliente, nIdSolCre, TipoCred);
                txtNumEva.Text = Convert.ToString(frmBusEvaEmpr.nNumEvalCons);
            }
            if (txtNumEva.Text == "0")
            {
                txtNumEva.Text = idEvaluacion.ToString();
            }
        }
        private void calcularFechaPrimeraCuota()
        {
            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                conCreditoPrimeraCuota.calcPrimeraCuota(
                    this.conCreditoPeriodo.idTipoPeriodo,
                this.conCreditoPeriodo.nPeriodoDia,
                this.dtFechaDesembolso.Value,
                this.conCreditoPeriodo.idPeriodo);

                this.nudDiasGracia.Value = conCreditoPrimeraCuota.nDiasGracia;
                this.conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.nPeriodoDia);

                if (this.conCreditoPrimeraCuota.lDiaAjustado)
                    this.conCreditoPeriodo.actualizarDia(this.conCreditoPrimeraCuota.nDia);
            }
        }

        private void conCreditoPeriodo_ChangePeriodo(object sender, EventArgs e)
        {
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.lPeriodoDiaValido && this.conCreditoPeriodo.lTipoPeriodoValido)
            {
                this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
                if (this.conCreditoPeriodo.lUnicuota)
                    this.nudCuotas.Enabled = false;
                else
                    this.nudCuotas.Enabled = true;
                this.nudCuotas.ValueChanged -= nudCuotas_ValueChanged;
                this.nudCuotas.Value = this.conCreditoPeriodo.nCuotas;
                this.nudCuotas.ValueChanged -= nudCuotas_ValueChanged;
            }
        }
        private void conCreditoPeriodo_ChangeTipoPeriodo(object sender, EventArgs e)
        {
            int nPerDiaReset = 0;
            this.conCreditoPrimeraCuota.resetearFechaSelec(this.dtFechaDesembolso.Value, this.conCreditoPeriodo.idTipoPeriodo, ref nPerDiaReset);
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.nudDiasGracia.Value = 0;
                this.nudCuotas.Enabled = true;
                if ((int)this.nudCuotas.Value == 1)
                    this.nudCuotas.Value = 2;
                this.nudNroCuoGracia.Value = 0;
                this.nudNroCuoGracia.Enabled = false;
            }
            else if (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                this.nudDiasGracia.Value = 0;
                this.nudNroCuoGracia.Value = 0;
                this.nudNroCuoGracia.Enabled = true;
                this.nudNroCuoGracia.Maximum = 80;
            }
            else
            {
                this.nudDiasGracia.Value = 0;
                this.nudDiasGracia.Enabled = false;
                this.nudCuotas.Value = 1;
                this.nudCuotas.Enabled = false;
                this.nudNroCuoGracia.Value = 0;
                this.nudNroCuoGracia.Enabled = false;
            }

            this.conCreditoPeriodo.actualizarDia(nPerDiaReset);
            this.calcularFechaPrimeraCuota();
            asignarTasa();
        }
        private void cboFuenteRecurso1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboFuenteRecurso1.SelectedIndex == 1)
            {
                this.btnAdeudado.Enabled = true;
            }
            else
            {
                this.btnAdeudado.Enabled = false;
                txtIdAdeudado.Text = "";
                txtcDescripcion.Text = "";
            }

        }

        private void btnAdeudado_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoCredito.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(cboDestinoCredito.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar el Destino del crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                MessageBox.Show("El monto solicitado debe ser mayor a CERO", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(cboMoneda1.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar el tipo de Moneda", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Int32 nidTipoCre = Convert.ToInt32(this.cboTipoCredito.SelectedValue);
            Int32 nidDestinoCre = Convert.ToInt32(this.cboDestinoCredito.SelectedValue);
            Decimal nMonto = Convert.ToDecimal(txtMonto.Text);
            Int32 idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);

            frmBuscaAdeudadoCre frmAdeudado = new frmBuscaAdeudadoCre();
            frmAdeudado.cargadatos(nidTipoCre, nidDestinoCre, nMonto, idMoneda, clsVarGlobal.nIdAgencia);

            txtIdAdeudado.Text = Convert.ToString(frmAdeudado.IdAdeudado);
            txtcDescripcion.Text = Convert.ToString(frmAdeudado.cDescripcion);
        }

        private void cboOperacionCre1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCuentaCredito = 0;

            if (cboOperacionCre1.SelectedIndex >= 0)
            {

                if (Transaccion == Convert.ToChar("U"))
                {
                    Transaccion = Convert.ToChar("I");
                    this.limpiar();
                    this.txtCodCliente.Enabled = true;
                    this.btnBusCliente.Enabled = true;
                    this.txtCodigoSol.Enabled = true;
                    this.btnGrabar1.Enabled = false;
                    if (dtCreditosAmp != null)
                    {
                        dtCreditosAmp.Clear();
                    }
                    this.txtCodCliente.Focus();
                    return;
                }
                txtTasaCompensatoria.Enabled = true;
                bloquearControlesCartaFianza(false);

                cargaDestinoXOperacion();


                #region Reprogramacion
                if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 3 && nContador > 0)
                {
                    if (string.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        return;
                    }
                    int idCli = Convert.ToInt32(txtCodCliente.Text);
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                    if (dtDatosCuentaSolCliente.Rows.Count == 0)
                    {
                        MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboOperacionCre1.SelectedValue = 1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("A continuación seleccione el crédito a reprogramar", "Selección de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                        frmBusCuenCli.CargarDatos(idCli, "C", "[5]");
                        frmBusCuenCli.ShowDialog();
                        idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                        if (idCuenta == 0)
                        {
                            MessageBox.Show("No seleccionó una cuenta de crédito \n la operación se cambiará por otorgamiento", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboOperacionCre1.SelectedValue = 1;
                            return;
                        }

                        if (cargarDatosReprogramacion(idCuenta))
                        {
                            hablitarReprogramacion(false);
                        }
                        else
                        {
                            cboOperacionCre1.SelectedValue = 1;
                        }
                        Int32 idcliRep = 0;
                        idcliRep = Convert.ToInt32(txtCodCliente.Text);
                        List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;
                        DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(idcliRep);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto")) //FILTRANDO PAQUETES
                                      select fila).FirstOrDefault();
                        if (dr != null)
                        {
                            string msg = string.Format("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro");
                            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboPaqueteSeguro1.Enabled=false;
                        }
                    }
                    mostrarObjetosAmpliacion(false);
                    DesplazarObjetosEOB(false);
                    cboModDesemb1.Enabled = false;
                    cboModDesemb1.SelectedValue = 1;
                    cboDestinoCredito.SelectedValue = 34;
                }

                #endregion

                #region Ampliaciones
                else if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4 && nContador > 0)
                {
                    if (string.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        return;
                    }
                    int idCli = Convert.ToInt32(txtCodCliente.Text);
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                    if (dtDatosCuentaSolCliente.Rows.Count == 0)
                    {
                        MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboOperacionCre1.SelectedValue = 1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("A continuación seleccione el crédito a Ampliar", "Selección de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                        frmBusCuenCli.CargarDatos(idCli, "C", "[5]");
                        frmBusCuenCli.ShowDialog();
                        idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);
                        int idProducto = frmBusCuenCli.idProducto;
                        if (idCuenta == 0)
                        {
                            MessageBox.Show("No seleccionó una cuenta de crédito \n la operación se cambiará por otorgamiento", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboOperacionCre1.SelectedValue = 1;
                            return;
                        }

                        if (estaEnDatos(clsVarApl.dicVarGen["cProductosAgricola"], idProducto))
                        {
                            MessageBox.Show("El producto agricola no puede ser ampliado", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                            
                            return;
                        }

                        idCuentaCredito = idCuenta;
                        if (this.objOferta == null)
                        {
                            limpiarOtraOperacion();
                        }
                        
                        hablitarAmpliacion(true);
                        mostrarObjetosAmpliacion(true);
                        DesplazarObjetosEOB(true);
                        cargarCuentasVinculadasASolicitud(-1);
                        agregarCreditos(idCuenta);
                        cargarDatosAesorDeCliente(idCli);
                        cboModDesemb1.Enabled = true;

                        if (this.objOferta != null)
                        {
                            clsCNSolicitud lValorProgImpuloMyPeru = new clsCNSolicitud();
                            DataTable dtVerificacion;
                            dtVerificacion = lValorProgImpuloMyPeru.CNVerificaCampImpulsoMyperu(this.objOferta.idGrupoCamp);
                            Boolean lValor = Convert.ToBoolean(dtVerificacion.Rows[0]["lValor"]);

                            if (lValor)
                            {
                                ObtenerDestinoRefinNovado();
                    }
                }

                    }
                }
                #endregion

                #region Refinanciación
                else if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 && nContador > 0)
                {
                    if (string.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        return;
                    }

                    int idCli = Convert.ToInt32(txtCodCliente.Text);
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                    if (dtDatosCuentaSolCliente.Rows.Count == 0)
                    {
                        MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboOperacionCre1.SelectedValue = 1;
                        return;
                    }
                    else
                    {
                        limpiarOtraOperacion();
                        hablitarAmpliacion(true);
                        mostrarObjetosAmpliacion(true);
                        DesplazarObjetosEOB(true);
                        cargarCuentasVinculadasASolicitud(-1);
                        cargarDatosAesorDeCliente(idCli);
                        txtMontoAmpliacion.Visible = false;
                        lblMontoAmplia.Visible = false;
                        dtgCuentaCreditoVinculado.ClearSelection();
                        cboModDesemb1.Enabled = false;
                        cboModDesemb1.SelectedValue = 1;
                        cboDestinoCredito.Enabled = false;
                        txtTasaCompensatoria.Enabled = false;

                        //agregar todos los creditos con productos que esten permitidos
                        DataTable dtCreditosRefinanciar = cnsolicitud.obtenerCreditosRefinanciar(idCli);
                        if (dtCreditosRefinanciar.Rows.Count == 0)
                        {
                            MessageBox.Show("Cliente seleccionado no tiene cuentas para refinanciar", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboOperacionCre1.SelectedValue = 1;
                            return;
                        }
                        if (dtCreditosRefinanciar.AsEnumerable().Any(x => x.Field<decimal>("nSalInteres") < 0))
                        {
                            MessageBox.Show("No se pueden refinanciar cuentas con intereses pagados por adelantado.", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboOperacionCre1.SelectedValue = 1;
                            return;
                        }
                        foreach (DataRow drCreditoRefi in dtCreditosRefinanciar.Rows)
                        {
                            DataRow drCredito = dtCreditosAmp.NewRow();
                            drCredito["idSolicitud"] = "0";
                            drCredito["idCuenta"] = drCreditoRefi["idCuenta"];
                            drCredito["nTotal"] = drCreditoRefi["nTotal"];
                            drCredito["nSalCapital"] = drCreditoRefi["nSalCapital"];
                            drCredito["nSalInteres"] = drCreditoRefi["nSalInteres"];
                            drCredito["nSalMora"] = drCreditoRefi["nSalMora"];
                            drCredito["nSalOtros"] = drCreditoRefi["nSalOtros"];
                            drCredito["nSalIntComp"] = drCreditoRefi["nSalIntComp"];
                            drCredito["lPermQuitar"] = drCreditoRefi["lPermQuitar"];
                            drCredito["nTasaCompensatoria"] = drCreditoRefi["nTasaCompensatoria"];
                            drCredito["nTasaMoratoria"] = drCreditoRefi["nTasaMoratoria"];
                            drCredito["nCapitalDesembolso"] = drCreditoRefi["nCapitalDesembolso"];
                            drCredito["nSaldoDeudor"] = drCreditoRefi["nSaldoDeudor"];
                            dtCreditosAmp.Rows.Add(drCredito);
                        }

                        txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
                        txtMonto.Text = txtSalTotalCre.Text;
                        dtgCuentaCreditoVinculado.ClearSelection();
                        btnQuitar.Enabled = false;
                        determinarTasaRefinanciamiento();
                        //Verificando si tiene campaña
                        cargarTasaCampaña(false);
                        ObtenerDestinoRefinNovado();
                    }
                }
                #endregion

                #region Cartas Fianza
                else if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 5)
        {
                    bloquearControlesCartaFianza(true);
                }
                #endregion

                #region Novación
                else if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6 && nContador > 0)
                {
                    if (string.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        return;
                    }

                    int idCli = Convert.ToInt32(txtCodCliente.Text);

                    limpiarOtraOperacion();
                    hablitarAmpliacion(true);
                    mostrarObjetosAmpliacion(true);
                    DesplazarObjetosEOB(true);
                    cargarCuentasVinculadasASolicitud(-1);
                    cargarDatosAesorDeCliente(idCli);
                    txtMontoAmpliacion.Visible = false;
                    lblMontoAmplia.Visible = false;
                    dtgCuentaCreditoVinculado.ClearSelection();
                    cboModDesemb1.Enabled = false;
                    cboModDesemb1.SelectedValue = 1;
                    cboDestinoCredito.Enabled = false;
                    txtTasaCompensatoria.Enabled = false;

                    txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
                    txtMonto.Text = txtSalTotalCre.Text;
                    btnQuitar.Enabled = true;

                    determinarTasaRefinanciamiento();

                }
                #endregion

                else
                {
                    limpiarOtraOperacion();
                    hablitarAmpliacion(true);
                    mostrarObjetosAmpliacion(false);
                    DesplazarObjetosEOB(false);
                    cboModDesemb1.Enabled = true;
                    cboMoneda1.Enabled = true;
                    if(VerificarUsuarioCampana() && !string.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        int idCliente = Convert.ToInt32(txtCodCliente.Text);
                        AsignarDatosCampana();
                    }

                }
                nContador++;
            }

            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) != 3)
                asignarTasa();
        }

        private void determinarTasaRefinanciamiento()
        {
            decimal nMontoDesembolsoMayor = 0.00m;
            foreach (DataRow row in dtCreditosAmp.Rows)
            {
                if (Convert.ToDecimal(row["nCapitalDesembolso"]) > nMontoDesembolsoMayor)
                {
                    nMontoDesembolsoMayor = Convert.ToDecimal(row["nCapitalDesembolso"]);
                    nTasaCompensatoriaRefi = Convert.ToDecimal(row["nTasaCompensatoria"]);
                    nTasaMoratoriaRefi = Convert.ToDecimal(row["nTasaMoratoria"]);
                }
            }

            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)
            {
                txtTasaCompensatoria.Text = nTasaCompensatoriaRefi.ToString("0.0000");
                txtTasaMora.Text = nTasaMoratoriaRefi.ToString("0.0000");
                txtTasaCompensatoria.Enabled = false;
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            asignarTasa();
        }

        private void cboMoneda1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboMoneda1.SelectedIndex >= 0)
            {
                if ((int)cboOperacionCre1.SelectedValue == 2)
                {
                    asignarMontoRefina(soliAmortiza);
                }
                asignarTasa();
            }
        }

        private void btnLeer1_Click(object sender, EventArgs e)
        {
            frmMensaje frmMensaje = new frmMensaje();
            frmMensaje.cMotivoAproba = cComentAproba;
            frmMensaje.ShowDialog();
        }

        private void nudCuotas_Enter(object sender, EventArgs e)
        {
            int nLonTex = nudCuotas.Value.ToString().Length;
            nudCuotas.Select(0, nLonTex);
        }

        private void nudDiasGracia_DragEnter(object sender, DragEventArgs e)
        {
            int nLonTex = nudDiasGracia.Value.ToString().Length;
            nudDiasGracia.Select(0, nLonTex);
        }

        private void txtTotalCreditoAmp_TextChanged(object sender, EventArgs e)
        {
            if (txtMontoAmpliacion.Text.Trim() != "")
            {
                if (txtSalTotalCre.Text.Trim() == "")
                {
                    txtMonto.Text = (Convert.ToDecimal(0) + Convert.ToDecimal(txtMontoAmpliacion.Text)).ToString();
                }
                else
                {
                    txtMonto.Text = (Convert.ToDecimal(txtSalTotalCre.Text) + Convert.ToDecimal(txtMontoAmpliacion.Text)).ToString();
                }
            }
            else
            {
                txtMonto.Clear();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgCuentaCreditoVinculado.SelectedRows.Count > 0)
            {
                dtgCuentaCreditoVinculado.Rows.RemoveAt(this.dtgCuentaCreditoVinculado.SelectedCells[0].RowIndex);
                txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
                determinarTasaRefinanciamiento();
                if ((int)cboOperacionCre1.SelectedValue == 2 || (int)cboOperacionCre1.SelectedValue == 4 || (int)cboOperacionCre1.SelectedValue == 6)
                {
                    txtMonto.Text = txtSalTotalCre.Text;
                }
                ObtenerDestinoRefinNovado();
            }
            else
            {
                MessageBox.Show("Seleccione por favor un item para quitar", "Desvincular crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodCliente.Text))
            {
                return;
            }
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
            {
                int idCli = Convert.ToInt32(txtCodCliente.Text);
                clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                if (dtDatosCuentaSolCliente.Rows.Count == 0)
                {
                    MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboOperacionCre1.SelectedValue = 1;
                    return;
                }
                else
                {
                    GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                    frmBusCuenCli.CargarDatos(idCli, "C", "[5]");
                    frmBusCuenCli.ShowDialog();
                    idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                    //Validar que no exista una solicitud pendiente o aprobada
                    if (idCuenta != 0)
                    {
                        if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
                        {
                            if (estaEnDatos(clsVarApl.dicVarGen["cProductosAgricola"], frmBusCuenCli.idProducto))
                            {
                                MessageBox.Show("El producto agricola no puede ser ampliado", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                            
                                return;
                            }
                        }


                        DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(idCli, idCuenta);
                        if (SolicDuplicada.Rows.Count > 0)
                        {
                            MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                            "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            btnGrabar1.Enabled = false;
                            btnCancelar1.Enabled = true;
                            return;
                        }
                        if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)
                        {
                            if (!cnsolicitud.ValidaProdRefinanciacion(idCuenta))
                            {
                                MessageBox.Show("El crédito seleccionado no puede ser refinanciado por los siguientes motivos:\n - El crédito está castigado\n - El producto del crédito no está permitido refinanciar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnGrabar1.Enabled = false;
                                btnCancelar1.Enabled = true;
                                return;
                            }
                        }

                        agregarCreditos(idCuenta);
                    }
                }
                txtTotalCreditoAmp_TextChanged(sender, e);
                if ((int)cboOperacionCre1.SelectedValue == 2)
                {
                    txtMonto.Text = txtSalTotalCre.Text;
                }
                determinarTasaRefinanciamiento();

                if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
                {
                    ObtenerDestinoRefinNovado(); 
            }
            }
            else
            {
                GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                frmBusCuenCli.conBusCli.btnBusCliente.Visible = true;
                frmBusCuenCli.ShowDialog();
                idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);
                if (idCuenta != 0)
                {
                    DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(frmBusCuenCli.idCli, idCuenta);
                    if (SolicDuplicada.Rows.Count > 0)
                    {
                        MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                        "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        btnGrabar1.Enabled = false;
                        btnCancelar1.Enabled = true;
                        return;
                    }
                    if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)
                    {
                        if (!cnsolicitud.ValidaProdRefinanciacion(idCuenta))
                        {
                            MessageBox.Show("El crédito seleccionado no puede ser refinanciado por los siguientes motivos:\n - El crédito está castigado\n - El producto del crédito no está permitido refinanciar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            btnGrabar1.Enabled = false;
                            btnCancelar1.Enabled = true;
                            return;
                        }
                    }

                    agregarCreditos(idCuenta);
                    determinarTasaRefinanciamiento();
                    ObtenerDestinoRefinNovado();
                }
            }
        }

        private void btnPreSolicitud_Click(object sender, EventArgs e)
        {
            frmListadoPreSolictud frmpresolicitud = new frmListadoPreSolictud();
            frmpresolicitud.ShowDialog();
            idPreSolicitud = frmpresolicitud.idPreSolicitud;
            if (idPreSolicitud > 0)
            {
                this.limpiar();
                this.btnGrabar1.Enabled = false;
                this.txtCodigoSol.Enabled = true;
                this.btnBusCliente.Enabled = true;
                this.txtCodigoSol.Enabled = true;

                var drPreSolicitud = frmpresolicitud.drPreSolicitud;
                txtMonto.Text = drPreSolicitud["nMontoSolicitado"].ToString();
                nudCuotas.Value = Convert.ToDecimal(drPreSolicitud["nCuotas"]);
                this.conCreditoPeriodo.asignarPeriodoCredito(
                    Convert.ToInt32(drPreSolicitud["idTipoPeriodo"]),
                    Convert.ToInt32(drPreSolicitud["nPlazoCuota"]),
                    (int)OperacionCredito.Otorgamiento,
                    (int)nudCuotas.Value
                    );

                conCreditoPrimeraCuota.asignarPrimeraCuota(
                    conCreditoPeriodo.idTipoPeriodo,
                    conCreditoPeriodo.nPeriodoDia,
                    (int)nudDiasGracia.Value,
                    this.dtFechaDesembolso.Value,
                    (int)nudCuotas.Value,
                    (int)OperacionCredito.Otorgamiento);

                this.cboMoneda1.SelectedValue = Convert.ToInt32(drPreSolicitud["idMoneda"]);

                if (drPreSolicitud["idCli"] != DBNull.Value)
                {
                    txtCodCliente.Text = drPreSolicitud["idCli"].ToString();
                    txtCodCliente_KeyPress(sender, new KeyPressEventArgs((char)13));
                }
                else
                {
                    MessageBox.Show("La pre solicitud es de un NO CLIENTE, \n deberá registrar como cliente primero, \n y luego registrar la solicitud de crédito", "Validación pre solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        

        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTasaCredito.SelectedIndex > -1)
            {
                var drTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;
                txtTasCompensatoriaMin.Text = Convert.ToString(drTasa["nTasaCompensatoria"]);
                txtTasCompensatoriaMax.Text = Convert.ToString(drTasa["nTasaCompensatoriaMax"]);
                txtTasaMora.Text = Convert.ToString(drTasa["nTasaMoratoria"]);
                this.idTipoTasaCredito = Convert.ToInt32(drTasa["idTipoTasaCredito"]);
                
                if (txtTasCompensatoriaMin.Text == txtTasCompensatoriaMax.Text)
                {
                    txtTasaCompensatoria.Enabled = false;
                    txtTasaCompensatoria.Text = txtTasCompensatoriaMax.Text;
                }
                else
                {
                    txtTasaCompensatoria.Focus();
                    txtTasaCompensatoria.SelectAll();
                    txtTasaCompensatoria.Enabled = true;
                }

                if (lConTasaNegociable)
                {
                    if (Convert.ToDecimal(drTasa["nTasaNegAprobada"]) > 0)
                    {
                        txtTasaCompensatoria.Text = drTasa["nTasaNegAprobada"].ToString();
                        txtTasaCompensatoria.Enabled = false;
                    }
                    else
                    {
                        txtTasaCompensatoria.Enabled = true;
                    }

                }

                txtTasaCompensatoria.ReadOnly = false;
                if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)
                {
                    txtTasaCompensatoria.ReadOnly = true;
                }

                int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
                if ((Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6) && idProducto.In(nArrayIdCampaniaRef))
                {
                    txtTasaCompensatoria.Text = "";
                    txtTasaCompensatoria.Enabled = true;
                    txtTasaCompensatoria.ReadOnly = false;
                }


            }
        }

        private void cboPersonalCreditos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAsesor_Click(object sender, EventArgs e)
        {
            frmAsignarAsesorSolicitud frmasignarasesor = new frmAsignarAsesorSolicitud();
            frmasignarasesor.ShowDialog();
        }

        private void cboPromotores1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dtFechaDesembolso_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtFechaDesembolso.Value < clsVarGlobal.dFecSystem &&
                Convert.ToInt32(this.cboOperacionCre1.SelectedValue)!=(int)OperacionCredito.ReprogramacionCambioFecha)
            {
                this.dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;
                this.dtFechaDesembolso.MinDate = clsVarGlobal.dFecSystem;
                this.dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;
                return;
            }

            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                if (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo
                    && !this.conCreditoPeriodo.lUnicuota
                    && Convert.ToInt32(this.cboOperacionCre1.SelectedValue) != (int)OperacionCredito.ReprogramacionCambioFecha)
                    this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
        }
            else
            {
                this.conCreditoPrimeraCuota.inicializarFecha(this.dtFechaDesembolso.Value);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //TODO: SolTechnologies - 10.Evalua si la solicitud fue rechazada por el Motor de Decisiones del MNB
            int idSolicitud = (this.txtCodigoSol.Text != "") ? Convert.ToInt32(txtCodigoSol.Text) : -1;
            var dtMNB = new clsCNMotorDecision().ValidaRestriccionesMNB(idSolicitud);
            if (dtMNB.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtMNB.Rows[0]["idPrediccion"]) == 3)
                {
                    MessageBox.Show("La solicitud se encuentra Rechazada por el Motor de Decisiones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                    this.Close();
                    return;
                }
            }

            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!this.validacionCreditoJornalero())
            {
                return;
            }

            if (string.IsNullOrEmpty(txtCodigoSol.Text))
            {
                MessageBox.Show("Número de solicitud no válida.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cboPersonalCreditos.SelectedIndex < 0)
            {
                MessageBox.Show("Debe de seleccionar asesor de negocios", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboPersonalCreditos.Focus();
                return;
            }

            if (dtSolicitud.Rows.Count < 1)
            {
                MessageBox.Show("Solicitud de creditos no válida.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(cboDetalleGasto1.SelectedValue) == 2)
            {
                if (!validarSeguroConyugal()) return;
            }

            foreach (DataColumn column in dtSolicitud.Columns)
            {
                column.ReadOnly = false;
            }

            if (!this.ValidaTipoOferta())
                return;

            if (validarSolicitudEAI(idSolicitud))
            {
                return;
            }

            if(invocarExcepciones(false))
            {
                return;
            }

            if (this.validarEnvioSolicitudAprobacion()) return;            


            dtSolicitud.Columns["idActividad"].ReadOnly = false;
            dtSolicitud.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
            dtSolicitud.Rows[0]["IdMoneda"] = cboMoneda1.SelectedValue;
            dtSolicitud.Rows[0]["nCuotas"] = nudCuotas.Value;
            dtSolicitud.Rows[0]["nPlazoCuota"] = this.conCreditoPeriodo.nPeriodoDia;
            dtSolicitud.Rows[0]["idEstado"] = 13;
            dtSolicitud.Rows[0]["idUsuario"] = (int?)cboPersonalCreditos.SelectedValue ?? 0;
            dtSolicitud.Rows[0]["idProducto"] = cboSubProducto.SelectedValue;
            dtSolicitud.Rows[0]["tObservacion"] = txtObservacion.Text;
            dtSolicitud.Rows[0]["idDestino"] = cboDestinoCredito.SelectedValue;
            dtSolicitud.Rows[0]["nTasaCompensatoria"] = txtTasaCompensatoria.Text;
            dtSolicitud.Rows[0]["idTasa"] = (int)cboTipoTasaCredito.SelectedValue;// idTasa;
            dtSolicitud.Rows[0]["idActividad"] = this.conActividadCIIU1.cboCIIU.SelectedValue;
            dtSolicitud.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
            dtSolicitud.Rows[0]["ndiasgracia"] = nudDiasGracia.Value;
            dtSolicitud.Rows[0]["idTipoPeriodo"] = conCreditoPeriodo.idTipoPeriodo;
            dtSolicitud.Rows[0]["idRecurso"] = cboFuenteRecurso1.SelectedValue;
            dtSolicitud.Rows[0]["idOperacion"] = cboOperacionCre1.SelectedValue;
            dtSolicitud.Rows[0]["nMontoAmpliado"] = (txtMontoAmpliacion.Text.Trim() == "") ? "0" : txtMontoAmpliacion.Text;
            dtSolicitud.Rows[0]["nSaldoCreditos"] = (txtSalTotalCre.Text.Trim() == "") ? "0" : txtSalTotalCre.Text;
            dtSolicitud.Rows[0]["idModalidadCredito"] = cboModalidadCredito.SelectedValue;
            dtSolicitud.Columns["idPromotor"].ReadOnly = false;
            dtSolicitud.Rows[0]["idPromotor"] = (int?)cboPromotores1.SelectedValue ?? 0;
            dtSolicitud.Rows[0]["cComentAproba"] = cComentAproba;//-->
            dtSolicitud.Rows[0]["idActividadInterna"] = Convert.ToInt32(this.conActividadCIIU1.cboActividadInterna1.SelectedValue);
            dtSolicitud.Rows[0]["idPreSolicitud"] = idPreSolicitud;
            dtSolicitud.Rows[0]["idAdeudado"] = (String.IsNullOrEmpty(txtIdAdeudado.Text.Trim())) ? "0" : txtIdAdeudado.Text;

            DataSet ds = new DataSet("dssolici");
            ds.Tables.Add(dtSolicitud);
            string XmlSoli = ds.GetXml();
            XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
            ds.Tables.Clear();

            clsCreditoProp objCreditoProp = retornaCreditoProp();
            string xmlCreditoProp = String.Empty;
            if (objCreditoProp != null)
            {
                xmlCreditoProp = objCreditoProp.GetXml();
            }
            else
            {
                xmlCreditoProp = new clsCreditoProp().GetXml();
            }

            /*  Guardar Expedientes - Solicitud de Credito  */
            bool lRespuesta = clsProcesoExp.guardarCopiaExpediente("Solicitud de Credito", Convert.ToInt32(txtCodigoSol.Text.Trim()), this);
            if (!lRespuesta)
            {
                return;
            }

            clsDBResp objDbResp = new clsCNSolicitud().CNEnviaAEvaluacion(XmlSoli, xmlCreditoProp, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar1.Enabled = false;
                btnEnviar.Enabled = false;
                this.btnCargaArhivos.Enabled = false;
                btnExcepciones.Enabled = false;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            btnEditar.Enabled = false;
            btnEditar.Visible = false;
            btnGrabar1.Visible = true;
            btnGrabar1.Enabled = false;
        }
        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            //TODO: SolTechnologies - 9.Muestra el resultado del score en el btn Excepcion
            int idSolicitud = (this.txtCodigoSol.Text != "") ? Convert.ToInt32(txtCodigoSol.Text) : -1;
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

                        frmRespuestaMotor msjRespuesta =
                        new frmRespuestaMotor(Convert.ToInt32(ultimoScoreMNB["idPrediccion"]),
                                              idSolicitud,
                                              ultimoScoreMNB["cResultadoModelo"].ToString().ToUpper(),
                                              hora,
                                              comentario);
                        msjRespuesta.ShowDialog();

                        //return;
                    }
                }
            }

            invocarExcepciones();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            decimal nMontoActual = (!String.IsNullOrEmpty(txtMonto.Text)) ? Convert.ToDecimal(txtMonto.Text) : 0 ;
            decimal nMontoSolicitadoSeguro = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro + objSolicitudCreditoCargaSeguro.nMontoPrimaTotal;
            if (objSolicitudCreditoCargaSeguro.idSolicitud != 0 && nMontoActual == nMontoSolicitadoSeguro )
            {
                objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro = objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro;
            }
            else
            {
                objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro = (!String.IsNullOrEmpty(txtMonto.Text)) ? Convert.ToDecimal(txtMonto.Text) : 0;
            }
        }
        #endregion

        #region Métodos
        private void limpiarControles()
        {
            this.nAlmacenarTasaCredito = 0;
            this.grbDato_Solicitud.Enabled = true;
            cboModalidadCredito.Enabled = true;
            cboModDesemb1.Enabled = true;
            this.idActividadInterna = 0;
            this.nudAniosActEco.Value = 0;
            this.conActividadCIIU1.Enabled = true;


            this.limpiar();
            this.txtCodCliente.Enabled = true;
            this.btnBusCliente.Enabled = true;
            this.txtCodigoSol.Enabled = true;
            this.btnGrabar1.Enabled = false;
            this.btnEnviar.Enabled = true;
            this.btnCargaArhivos.Enabled = true;
            this.cboDestinoCredito.Enabled = true;
            btnExcepciones.Enabled = false;
            if (dtCreditosAmp != null)
            {
                dtCreditosAmp.Clear();
            }
            this.txtCodCliente.Focus();
            mostrarObjetosAmpliacion(false);
            DesplazarObjetosEOB(false);
            nTasaCampana = 0;
            idTasaRepro = 0;
            nTasaRepro = 0.0000m;
            nTasaMoraRepro = 0.0000m;
            //btnAdministradorFiles1.idSolicitud = 0;
            this.objSel = null;
            btnVincularVisita1.idSolicitud = 0;
            btnVincularVisita1.idCli = 0;

            btnVincularVisita1.idSolicitud = 0;
            btnVincularVisita1.idCli = 0;
            objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
            objSolicitudCreditoCargaSeguro.idPaqueteSeguro = 0;
            idPaqueteSeguro= objSolicitudCreditoCargaSeguro.idPaqueteSeguro;

            this.btnEditar.Visible = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar1.Enabled = true;
            this.btnGrabar1.Visible = true;
            lEditar = false;
            this.objOferta = null;
            this.listProd = null;

            cboDetalleGasto1.SelectedIndex = -1;
            cboDetalleGasto1.Enabled = true;
            lblDesembolso.Text = "Desembolso";
            idPaqueteSeguro = 0;
            cboPaqueteSeguro1.Enabled = true;
            cboPaqueteSeguro1.SelectedIndex = -1;
        }
        private bool invocarExcepciones(bool lGrabar = true)
        {
            if (txtCodigoSol.Text.Length > 0)
            {
                int nIdSolicitud = Convert.ToInt32(txtCodigoSol.Text);
                int nIdAgencia = clsVarGlobal.nIdAgencia;
                int nIdCliente = Convert.ToInt32(txtCodCliente.Text);
                int nIdMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
                int nIdProducto = Convert.ToInt32(cboProducto.SelectedValue);
                decimal nValAproba = Convert.ToDecimal((txtMonto.Text.Trim() == "") ? "0" : txtMonto.Text);
                int nIdUsuRegist = Convert.ToInt32(cboPersonalCreditos.SelectedValue);
                String cOpcion = this.Name;
                frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, this.Name, false);

                if (objGestionExcepcion.nPendientes > 0)
                {
                    return true;
                }

                if(lGrabar)
                    grabar();
            }
            else
            {
                btnExcepciones.Enabled = false;
            }
            return false;
        }
        private void bloquearControlesCartaFianza(bool lBloquear)
        {
            nudDiasGracia.Value = 0;
            conCreditoPeriodo.lTipoPeriodoEnabled = !lBloquear;
            //btnEnviar.Enabled = !lBloquear;
            conCreditoPeriodo.TipoPeridoIndex = (lBloquear) ? 1 : -1;
            nudCuotas.Enabled = !lBloquear;
            nudCuotas.Value = (lBloquear) ? 1 : 0;
            nudNroCuoGracia.Enabled = !lBloquear;
            nudNroCuoGracia.Value = 0;

            txtTasaCompensatoria.Enabled = !lBloquear;
            txtTasaCompensatoria.Text = "0.00";
            cboModalidadCredito.Enabled = !lBloquear;
            cboModalidadCredito.SelectedIndex = (lBloquear) ? 0 : -1;
            cboModDesemb1.Enabled = !lBloquear;
            cboModDesemb1.SelectedIndex = (lBloquear) ? 0 : -1;

            if (lBloquear)
            {
                this.conCreditoPeriodo.PeriodoText = "Plazo:";
                //this.lblBase1.Text = "en días";
                this.lblDesembolso.Text = "Fecha inicio/vigencia";
                //this.nudPlazo.Maximum = 9999;
            }

        }

        private void asignarMontoRefina(clsSolicitudAmortiza soliAmortiza)
        {
            int idMoneda = (int)cboMoneda1.SelectedValue;
            decimal ntotRefina = 0.0M;

            if (idMoneda == 1)
            {
                foreach (var item in soliAmortiza.listaDetalle)
                {
                    var credito = new CRE.CapaNegocio.clsCNCredito().retornaDatosCredito(item.idCuenta);
                    if (item.idMoneda == 1)
                    {
                        ntotRefina = ntotRefina + credito.nCapitalDesembolso - credito.nCapitalPagado;
                    }
                    else if (item.idMoneda == 2)
                    {
                        ntotRefina = ntotRefina + ((credito.nCapitalDesembolso - credito.nCapitalPagado) * (decimal)clsVarApl.dicVarGen["nTipoCambio"]);
                    }
                }
            }

            else if (idMoneda == 2)
            {
                foreach (var item in soliAmortiza.listaDetalle)
                {
                    var credito = new CRE.CapaNegocio.clsCNCredito().retornaDatosCredito(item.idCuenta);
                    if (item.idMoneda == 1)
                    {
                        ntotRefina = ntotRefina + ((credito.nCapitalDesembolso - credito.nCapitalPagado) / (decimal)clsVarApl.dicVarGen["nTipoCambio"]);
                    }
                    else if (item.idMoneda == 2)
                    {
                        ntotRefina = ntotRefina + credito.nCapitalDesembolso - credito.nCapitalPagado;
                    }
                }
            }

            txtMonto.Text = string.Format("{0:0.00}", ntotRefina);
            txtMonto.Enabled = false;
        }

        private void asignarTasa()
        {
            if (Convert.ToInt32(nudCuotas.Value) != 0 && this.conCreditoPeriodo.idTipoPeriodo != 0 && this.conCreditoPeriodo.nPeriodoDia != 0)
            {
                cboTipoTasaCredito.DataSource = null;
                int nPlazo = obtenerTotalDias(Convert.ToDateTime(dtFechaDesembolso.Value), Convert.ToInt32(nudCuotas.Value), Convert.ToInt32(nudDiasGracia.Value.ToString()), this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.nPeriodoDia);
                int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
                decimal nMonto = Convert.ToDecimal(string.IsNullOrEmpty(txtMonto.Text) ? "0.00" : txtMonto.Text);
                int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);

                clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
                DataTable dtTasa;
                if (this.lConTasaNegociable)
                {
                    dtTasa = TasaCredito.ListaTasaEval(nPlazo, idProducto, nMonto, idMoneda, idAgencia, Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]), idClasificacionInterna);
                }
                else
                {
                    dtTasa = TasaCredito.ListaTasaCredito(nPlazo, idProducto, nMonto, idMoneda, idAgencia, Convert.ToInt32(cboOperacionCre1.SelectedValue), idClasificacionInterna);
                }
                if (dtTasa.Rows.Count > 0)
                {

                    cboTipoTasaCredito.DataSource = dtTasa;
                    cboTipoTasaCredito.DisplayMember = "cDescripcion";
                    cboTipoTasaCredito.ValueMember = "idTasa";
                    var idTipoTasaCredito = Convert.ToInt32(dtTasa.Rows[0]["idTipoTasaCredito"]); 

                    //if (idTipoTasaCredito == 1 && Transaccion == 'I')
                    if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() == dtTasa.Rows[0]["nTasaCompensatoriaMax"].ToString() && Transaccion == 'I')
                    {
                        txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                        txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                        txtTasaMora.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
                        idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);

                        lblTipoTasaCredito.Text = Convert.ToString(dtTasa.Rows[0]["cDescripcion"]);
                        txtTasaCompensatoria.Enabled = false;
                        txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                        nTasaCampana = 0;
                    }
                    else
                    {
                        txtTasaCompensatoria.Enabled = true;
                                                                      
                        if (dtSolicitud != null)
                        {
                            if (dtSolicitud.Rows.Count > 0)
                            {
                                bool lValidarRangoSolicitud =   Convert.ToDecimal(dtSolicitud.Rows[0]["nTasaCompensatoria"]) >= Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoria"]) &&
                                                                Convert.ToDecimal(dtSolicitud.Rows[0]["nTasaCompensatoria"]) <= Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                                decimal nTasaActual = (!String.IsNullOrEmpty(txtTasaCompensatoria.Text)) ? Convert.ToDecimal(txtTasaCompensatoria.Text) : 0 ;
                                bool lValidaRangoActual =   nTasaActual >= Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoria"]) &&
                                                            nTasaActual <= Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                                txtTasaCompensatoria.Text = (lValidarRangoSolicitud) ? Convert.ToString(dtSolicitud.Rows[0]["nTasaCompensatoria"]) : (lValidaRangoActual) ? txtTasaCompensatoria.Text : "" ;
                                txtTasaMora.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaMoratoria"]);
                                cargarTasaCampaña();
                                
                            }
                            else
                            {
                                if ((Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6) && !idProducto.In(nArrayIdCampaniaRef))
                                {
                                    txtTasaCompensatoria.Text = nTasaCompensatoriaRefi.ToString("0.0000");
                                    txtTasaMora.Text = nTasaMoratoriaRefi.ToString("0.0000");
                                    txtTasaCompensatoria.Enabled = false;
                                    nTasaCampana = 0;
                                }
                                else if ((Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6) && idProducto.In(nArrayIdCampaniaRef))
                                {
                                    txtTasaCompensatoria.Text = "";
                                    txtTasaCompensatoria.Enabled = true;
                                    txtTasaCompensatoria.ReadOnly = false;
                                }
                                else
                                {
                                    cargarTasaCampaña();
                                }
                            }
                        }
                        else
                        {
                            cargarTasaCampaña();
                        }
                    }
                }
                else
                {
                    txtTasCompensatoriaMin.Text = "";
                    txtTasCompensatoriaMax.Text = "";
                    txtTasaCompensatoria.Text = "";
                    txtTasaMora.Text = "";
                }
            }
        }

        private void cargarTasaCampaña(bool lCargaTasa = true)
        {
            //=================================================================================
            // Se esta obteniendo si el cliente tiene registrado una campaña para el producto seleccionado
            //=================================================================================
            int _idCli = (String.IsNullOrWhiteSpace(txtCodCliente.Text)) ? (dtSolicitud.Rows.Count > 0) ? Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]) : 0 : Convert.ToInt32(txtCodCliente.Text);
            int _idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
            int _idOperacion = Convert.ToInt32(this.cboOperacionCre1.SelectedValue);

            DataTable dtRes = new clsCNBuscarCli().CNValidarClienteCreditoTasaCamp(_idCli, _idProducto, _idOperacion);
            if (dtRes.Rows.Count > 0)
            {
                nTasaCampana = (lCargaTasa) ? Convert.ToDecimal(dtRes.Rows[0]["nTasa"]): 0 ;
                if (!(dtSolicitud.Rows.Count == 1) && !lRegistrar )
                {
                    this.txtTasaCompensatoria.Text = string.Empty;
                    this.cboTipoTasaCredito.SelectedIndex = -1;
                    if (lCargaTasa)
                    {
                        txtTasaCompensatoria.Text = Convert.ToDecimal(dtRes.Rows[0]["nTasa"]).ToString("0.0000");
                        idCreditosPreAprobados = Convert.ToInt32(dtRes.Rows[0]["idCreditosPreAprobados"]);
                    }
                    else
                    {
                        MessageBox.Show("El cliente tiene configurado la campaña " + dtRes.Rows[0]["cGrupoCamp"].ToString());
                        idCreditosPreAprobados = Convert.ToInt32(dtRes.Rows[0]["idCreditosPreAprobados"]);
                    }
                    //txtTasaCompensatoria.Enabled = false;
                }
            }
            else
            {
                DataTable dtComprobarProdutCamp = new clsCNProducto().CNComprobarProductCamp(_idProducto);

                if (Convert.ToInt32(dtComprobarProdutCamp.Rows[0]["nResultado"]) == 1)
                {
                    this.txtTasaCompensatoria.Text = string.Empty;
                    this.cboTipoTasaCredito.SelectedIndex = -1;
                    this.txtTasaCompensatoria.Enabled = false;//this.txtTasaCompensatoria
                    this.cboTipoTasaCredito.Enabled = false;
                    MessageBox.Show("El cliente no esta incluido en el grupo para el producto:\n" + this.cboSubProducto.Text, "Cliente no incluido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.txtTasaCompensatoria.Enabled = true;
                    this.cboTipoTasaCredito.Enabled = true;
                }
            }
            //=================================================================================
            // Fin
            //=================================================================================
        }

        private void cargarDatosSolicitud(int idSolictud)
        {
            objSolicitudCreditoCargaSeguro = new clsCNCreditoCargaSeguro().CNObtenerSolicitudCargaSeguro(idSolictud);
            dtSolicitud = cnsolicitud.ConsultaSolicitud(idSolictud);

            GEN.CapaNegocio.clsCNCredito ConsultAdeudado = new GEN.CapaNegocio.clsCNCredito();
            DataTable dtAdeudado = new DataTable();

            if (dtSolicitud.Rows.Count > 0)
            {
                cboDetalleGasto1.SelectedIndexChanged -= cboDetalleGasto1_SelectedIndexChanged;
                cboDetalleGasto1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idDetalleGasto"]);
                cboDetalleGasto1.SelectedIndexChanged += cboDetalleGasto1_SelectedIndexChanged;

                idPaqueteSeguro= Convert.ToInt32(string.IsNullOrEmpty(dtSolicitud.Rows[0]["idPaqueteSeguro"].ToString()) ? 0 : dtSolicitud.Rows[0]["idPaqueteSeguro"]);                
                CargarPaqueteSeguro(idPaqueteSeguro,true);

                int idCanalRegistro = Convert.ToInt32(dtSolicitud.Rows[0]["idCanalRegistro"]);
                if (idCanalRegistro == 2)
                {
                    MessageBox.Show("Esta solicitud de créditos se realizó por el Andy Collector, continuar el flujo por ese canal", "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btnVincularVisita1.idSolicitud = idSolictud;
                btnVincularVisita1.idCli = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);

                int idestadoSol = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);
                if (idestadoSol > 1 && idestadoSol < 11 || idestadoSol == 12 || idestadoSol == 14)
                {
                    if ((idestadoSol > 1 && idestadoSol < 11 || idestadoSol == 12 || idestadoSol == 14))
                    {
                        MessageBox.Show("Estado de Solicitud diferente a SOLICITADO", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    Transaccion = Convert.ToChar("X");
                    this.limpiar();
                    this.btnGrabar1.Enabled = false;
                    this.txtCodigoSol.Enabled = true;
                    this.txtCodCliente.Enabled = true;
                    this.btnBusCliente.Enabled = true;
                    this.txtCodCliente.Focus();
                        return; 
                    }
                    else
                    {
                    //btnAdministradorFiles1.idSolicitud = Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]);
                    //btnAdministradorFiles1.actualizarDatos();
                    //btnAdministradorFiles1.lectura = false;

                    cboOperacionCre1.SelectedIndexChanged -= cboOperacionCre1_SelectedIndexChanged;
                    
                    Transaccion = Convert.ToChar("U");
                    nidTipoPersona = Convert.ToInt32(dtSolicitud.Rows[0]["IdTipoPersona"].ToString());
                    deshabilitarTipoSeguro();
                    cboOperacionCre1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]);
                    cboOperacionCre1.SelectedIndexChanged += cboOperacionCre1_SelectedIndexChanged;
                    
                    cargaDestinoXOperacion();

                    this.conCreditoPeriodo.asignarPeriodoCredito(
                        Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPeriodo"]),
                        Convert.ToInt32(dtSolicitud.Rows[0]["nPlazoCuota"]),
                        Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]),
                        Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]),
                        Convert.ToInt32(dtSolicitud.Rows[0]["idPeriodoCredito"])
                        );                    

                    lConTasaNegociable = Convert.ToBoolean(dtSolicitud.Rows[0]["lConTasaNegociable"]);
                    txtMonto.Text = dtSolicitud.Rows[0]["nCapitalSolicitado"].ToString();
                    cboMoneda1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            
                    nudCuotas.Value = Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]);

                    nudDiasGracia.Value = Convert.ToInt32(dtSolicitud.Rows[0]["ndiasgracia"]);
                    dtFechaDesembolso.ValueChanged -= dtFechaDesembolso_ValueChanged;
                    dtFechaDesembolso.Value = Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"]);
                    dtFechaDesembolso.ValueChanged += dtFechaDesembolso_ValueChanged;

                    conCreditoPrimeraCuota.asignarPrimeraCuota(
                        conCreditoPeriodo.idTipoPeriodo,
                        conCreditoPeriodo.nPeriodoDia,
                        (int)nudDiasGracia.Value,
                        dtFechaDesembolso.Value,
                        (int)nudCuotas.Value,
                        Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]),
                        default(DateTime),
                        Convert.ToInt32(dtSolicitud.Rows[0]["idPeriodoCredito"])
                        );

                    if (conCreditoPrimeraCuota.lDiaAjustado)
                    {
                        MessageBox.Show("Se cambia el día de pago de " + conCreditoPeriodo.nPeriodoDia.ToString()
                            + " a " + conCreditoPrimeraCuota.dFecha.Day.ToString()
                            + ", pues la diferencia mínima en dias entre la fecha de desembolso y la fecha de primera cuota es 20."
                            , "DIA AJUSTADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.dFecha.Day);
                    }

                    cboEstadoCredito1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);
                    cboPersonalCreditos.SelectedValue = dtSolicitud.Rows[0]["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["idUsuario"]);
                    cboTipoCredito.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["nTipCre"]);
                    cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["nSubTip"]);
                    cboProducto.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["nProdu"]);
                    cboSubProducto.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["nSubPro"]);
                    cboModDesemb1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idModalidadDes"]);
                    txtObservacion.Text = Convert.ToString(dtSolicitud.Rows[0]["tObservacion"]);
                    txtNombre.Text = Convert.ToString(dtSolicitud.Rows[0]["cNombre"]);
                    txtNroDocIde.Text = Convert.ToString(dtSolicitud.Rows[0]["cDocumentoID"]);
                    cboDestinoCredito.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idDestino"]);
                    idClasificacionInterna = Convert.ToInt32(dtSolicitud.Rows[0]["idClasificacionInterna"]);

                    var idActividadInterna = dtSolicitud.Rows[0]["idActividadInterna"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["idActividadInterna"]);
                    conActividadCIIU1.cargarActividadInterna(idActividadInterna);

                    this.cboTipoLocalActividad.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoLocalActividad"]);

                    
                    cboFuenteRecurso1.SelectedValue = Convert.ToString(dtSolicitud.Rows[0]["idRecurso"]);
                    txtIdAdeudado.Text = Convert.ToString(dtSolicitud.Rows[0]["idAdeudado"]);

                    idTasa = dtSolicitud.Rows[0]["idTasa"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["idTasa"]);
                    txtTasaCompensatoria.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaCompensatoria"]);
                    txtTasaMora.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaMoratoria"]);

                    idCuenta = Convert.ToInt32(dtSolicitud.Rows[0]["idCuenta"]);
                    idSoliCambio = Convert.ToInt32(dtSolicitud.Rows[0]["idSoliCambio"]);
                    cboModalidadCredito.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idModalidadCredito"]);//-->
                    txtMontoAmpliacion.TextChanged -= new EventHandler(txtTotalCreditoAmp_TextChanged);
                    txtMontoAmpliacion.Text = dtSolicitud.Rows[0]["nMontoAmpliado"].ToString();
                    txtMontoAmpliacion.TextChanged += new EventHandler(txtTotalCreditoAmp_TextChanged);
                    txtCodInst.Text = Convert.ToString(dtSolicitud.Rows[0]["cCodCliente"]).Substring(0, 3);
                    txtCodAge.Text = Convert.ToString(dtSolicitud.Rows[0]["cCodCliente"]).Substring(3, 3);
                    txtCodCliente.Text = Convert.ToString(dtSolicitud.Rows[0]["cCodCliente"]).Substring(6);
                    cboPromotores1.SelectedValue = dtSolicitud.Rows[0]["idPromotor"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["idPromotor"]);
                    DataTable dtEvaluacion = cnsolicitud.CNRetornaEvalCredito(Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]), Convert.ToInt32(dtSolicitud.Rows[0]["nTipCre"]));
                    idEvaluacion = Convert.ToInt32(dtEvaluacion.Rows[0]["IdEvaluacion"]);
                    cComentAproba = dtSolicitud.Rows[0]["cComentAproba"].ToString();
                    idPreSolicitud = dtSolicitud.Rows[0]["idPreSolicitud"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["idPreSolicitud"]);

                    nudNroCuoGracia.Value = dtSolicitud.Rows[0]["nCuotasGracia"] == DBNull.Value ? 0 : Convert.ToInt32(dtSolicitud.Rows[0]["nCuotasGracia"]);
                    //Habilitar el Boton para visualizar el comentario del aprobador
                    txtCodigoSol.Text = dtSolicitud.Rows[0]["idSolicitud"].ToString();
                    this.btnGestObs.Enabled = true;
                    cboDestinoCredito.Enabled = true;

                    if (this.objOferta != null)
                    {
                        clsCNSolicitud lValorProgImpuloMyPeru = new clsCNSolicitud();
                        DataTable dtVerificacion;
                        dtVerificacion = lValorProgImpuloMyPeru.CNVerificaCampImpulsoMyperu(this.objOferta.idGrupoCamp);
                        Boolean lValor = Convert.ToBoolean(dtVerificacion.Rows[0]["lValor"]);

                        if (lValor)
                        {
                            cboDestinoCredito.Enabled = false;
                        }
                    }
                    
                    initClienteRecurrente(Convert.ToInt32(dtSolicitud.Rows[0]["idTipoCli"]));
                    clsCNBuscarCli listarCli = new clsCNBuscarCli();
                    cboEstablecimiento.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idEOBDesembolso"]);

                    this.ObtenerOfertaSolicitud(Convert.ToInt32(dtSolicitud.Rows[0]["idOferta"]));
                
                    cargarTasaCampaña();

                    if (cComentAproba.Count() > 2)
                    {
                        btnLeer1.Enabled = true;
                    }
                    // this.txtNumEva.Text = idEvaluacion.ToString();
                    this.txtNumEva.Text = dtSolicitud.Rows[0]["nEvaluacion"].ToString();

                    if (Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]) == 1) nContador++;

                    if (Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]) == 3)
                    {
                        hablitarReprogramacion(false);
                    }
                    else if (Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]) == 4)
                    {
                        mostrarObjetosAmpliacion(true);
                        DesplazarObjetosEOB(true);
                        cargarCuentasVinculadasASolicitud(Convert.ToInt32(txtCodigoSol.Text));

                        if (dtgCuentaCreditoVinculado.Rows.Count > 0)
                        {
                            DataTable dtTemp = (dtgCuentaCreditoVinculado.DataSource) as DataTable;
                            idCuentaCredito = Convert.ToInt32(dtTemp.Rows[0]["idCuenta"]);
                        }
                    }
                    else if (Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]) == 2)
                    {
                        mostrarObjetosAmpliacion(true);
                        DesplazarObjetosEOB(true);
                        txtMontoAmpliacion.Visible = false;
                        lblMontoAmplia.Visible = false;
                        dtgCuentaCreditoVinculado.ClearSelection();
                        cargarCuentasVinculadasASolicitud(Convert.ToInt32(txtCodigoSol.Text));
                        cboDestinoCredito.Enabled = false;
                    }
                    else if (Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]) == 6)
                    {
                        mostrarObjetosAmpliacion(true);
                        DesplazarObjetosEOB(true);
                        txtMontoAmpliacion.Visible = false;
                        lblMontoAmplia.Visible = false;
                        dtgCuentaCreditoVinculado.ClearSelection();
                        cargarCuentasVinculadasASolicitud(Convert.ToInt32(txtCodigoSol.Text));
                        cboDestinoCredito.Enabled = false;
                    }

                    if (txtIdAdeudado.nvalor != 0)
                    {
                        if (Convert.ToInt32(txtIdAdeudado.Text) > 0)
                        {
                            dtAdeudado = ConsultAdeudado.CNRetornaAdeudado(Convert.ToInt32(txtIdAdeudado.Text));
                            txtcDescripcion.Text = Convert.ToString(dtAdeudado.Rows[0]["cDescripcionLinea"]);
                        }
                    }

                    this.btnGrabar1.Enabled = true;
                    this.btn_Vincular2.Enabled = true;
                    txtCodCliente.Enabled = false;
                    btnExcepciones.Enabled = true;

                    if ((int)this.nudCuotas.Value == 1)
                    {
                        this.nudCuotas.Enabled = false;
                    }

                    DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(idSolictud);
                    if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                    {
                        MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (idestadoSol == 13)//no volver a editar cuando ya cumplio todo, la edicion sera desde la aprobacion o propuesta
                    {
                        MessageBox.Show("Solicitud enviada a evaluación", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGrabar1.Enabled = false;
                        cboEstadoCredito1.Enabled = false;
                        btnExcepciones.Enabled = false;
                        //btnAdministradorFiles1.lectura = true;
                    }

                    if (estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue == 5)
                    {
                        bloquearControlesCartaFianza(true);
                        btnEnviar.Enabled = true;//false;
                        this.btnCargaArhivos.Enabled = true;

                        int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);

                        DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idSolicitud);
                        if ((dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) == 0))
                        {
                            btnGrabar1.Enabled = false;
                            cboEstadoCredito1.Enabled = false;
                            btnExcepciones.Enabled = false;
                        }
                    }
                }
                if (Convert.ToInt32(cboOperacionCre1.SelectedValue) != 3)
                {
                    asignarTasa();
                }
                else
                {
                    TasaReprogramacion(idTasa);
                    txtTasaCompensatoria.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaCompensatoria"]);
                    txtTasaMora.Text = Convert.ToString(dtSolicitud.Rows[0]["nTasaMoratoria"]);
                    hablitarReprogramacion(false);
                    }
                cboTipoTasaCredito.SelectedValue = idTasa;
                
                }   
            else
            {
                Transaccion = Convert.ToChar("I");
                dtpFechaSol.Value = dFechaSistema;
                dtFechaDesembolso.Value = dFechaSistema;
                this.btnGrabar1.Enabled = true;
                this.txtCodigoSol.Enabled = true;
                // this.txtCodCliente.Enabled = true;
                this.btnBusCliente.Enabled = true;
                this.btnGestObs.Enabled = false;
                nContador++;
                cboDetalleGasto1.SelectedIndex = -1;
                if(cboPaqueteSeguro1.Items.Count == 0)
                    cboPaqueteSeguro1.AgregarNinguno();
                cboPaqueteSeguro1.SelectedIndex = -1;
            }
        }

        private void cargaDestinoXOperacion()
        {
            int idProducto = Convert.ToInt32(this.cboSubProducto.SelectedValue);
            int idTipoOperacion = Convert.ToInt32(cboOperacionCre1.SelectedValue);

            if (idTipoOperacion == 3)
            {
                cboDestinoCredito.cargarEspeciales();
            }
            else if(idTipoOperacion == 2 || idTipoOperacion == 6 )
            {
                cboDestinoCredito.cargar();
            }
            else if (idProducto > 0)
            {
                cboDestinoCredito.cargarEspecificos(idProducto);
            }
            else
            {
                cboDestinoCredito.cargar();
            }
        }

        private bool cargarDatosReprogramacion(int idCre)
        {
            //Validar que no exista una solicitud pendiente o aprobada
            if (string.IsNullOrEmpty(txtCodCliente.Text.Trim()))
            {
                MessageBox.Show("Código de cliente no válido", "Validación registro de solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(Convert.ToInt32(txtCodCliente.Text.Trim()), idCre);
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = true;
                return false;
            }

            GEN.CapaNegocio.clsCNCredito ConsultAdeudado = new GEN.CapaNegocio.clsCNCredito();
            DataTable Adeudado = new DataTable();

            CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
            clsCredito entCredito = credito.retornaDatosCredito(idCre);

            //if (entCredito.nAtraso > 0)
            //{
            //    MessageBox.Show("Crédito seleccionado no cumple con días de atraso igual a cero(0)", "Validación de reprogramación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            clsPlanPago planpago = new CRE.CapaNegocio.clsCNPlanPago().retonarPlanPagoTotal(entCredito.idCuenta);
            
            decimal nCapitalProgPendiente = planpago.Where(x => x.idEstadocuota == 1).Sum(x => x.nCapital);

            DataTable datsolrepro = cnsolicitud.ConsultaSolicitud(entCredito.idSolicitud);

            DateTime dFechaUltPagDesem = entCredito.dFechaDesembolso;
            if (planpago.Exists(x => x.idEstadocuota == 2))
            {
                clsCuota objUltCuotaPag = planpago.Where(x => x.idEstadocuota == 2).OrderBy(x => x.idCuota).Last();
                dFechaUltPagDesem = objUltCuotaPag.dFechaProg;
            }

            this.dtFechaDesembolso.ValueChanged -= this.dtFechaDesembolso_ValueChanged;
            this.dtFechaDesembolso.Value = dFechaUltPagDesem;
            this.dtFechaDesembolso.ValueChanged -= this.dtFechaDesembolso_ValueChanged;

            DateTime dFechaProxVenc = clsVarGlobal.dFecSystem;
            if (planpago.Exists(x => x.idEstadocuota == 1))
            {
                clsCuota objCuotaProxVenc = planpago.Where(x => x.idEstadocuota == 1).OrderBy(x => x.idCuota).First();
                dFechaProxVenc = objCuotaProxVenc.dFechaProg;
                if (dFechaProxVenc < clsVarGlobal.dFecSystem)
                {
                    DialogResult idRespuesta = MessageBox.Show("Se ha detectado que la fecha de próximo vencimiento ( " +
                        dFechaProxVenc.ToString("dd/MM/yyyy") + " ) es menor a la fecha del sistema ( " +
                        clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy") +
                        " ), esto sugiere que se trata de un crédito en MORA.\n\n" +
                        "¡Es posible que, por la MORA, las reglas de negocio no le permitan avanzar a la etapa de EVALUACIÓN!\n" +
                        "*Si decide continuar la fecha de primera cuota permitida será " + clsVarGlobal.dFecSystem.AddDays(1).ToString("dd/MM/yyyy") + "\n\n" +
                        "¿Desea continuar con el registro de todas formas?"
                    , "AJUSTE DE FECHA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (idRespuesta == DialogResult.No)
                    {
                        this.limpiar();
                        return false;
                    }
                    dFechaProxVenc = clsVarGlobal.dFecSystem.AddDays(1);
                }

            }

            txtMonto.Text = string.Format("{0:#,0.00}", nCapitalProgPendiente);
            cboMoneda1.SelectedValue = entCredito.IdMoneda;
            nudCuotas.Value = planpago.Count(x => x.idEstadocuota == 1);
            nudDiasGracia.Value = Convert.ToInt32(datsolrepro.Rows[0]["ndiasgracia"]);

            bool lUnicuota = (planpago.Count == 1);
            conCreditoPeriodo.asignarPeriodoCredReprog(
                Convert.ToInt32(datsolrepro.Rows[0]["idTipoPeriodo"]),
                Convert.ToInt32(datsolrepro.Rows[0]["nPlazoCuota"]),
                (int)OperacionCredito.ReprogramacionCambioFecha,
                (int)nudCuotas.Value,
                lUnicuota
                );
            conCreditoPrimeraCuota.asignarPrimeraCuotaReprog(
                conCreditoPeriodo.idTipoPeriodo,
                conCreditoPeriodo.nPeriodoDia,
                (int)nudDiasGracia.Value,
                this.dtFechaDesembolso.Value,
                (int)nudCuotas.Value,
                (int)OperacionCredito.ReprogramacionCambioFecha,
                dFechaProxVenc,
                lUnicuota
                );

            this.nudDiasGracia.Value = conCreditoPrimeraCuota.nDiasGracia;

            if (conCreditoPrimeraCuota.lDiaAjustado)
            {
                MessageBox.Show("Se cambia el día de pago de " + conCreditoPeriodo.nPeriodoDia.ToString()
                    + " a " + conCreditoPrimeraCuota.dFecha.Day.ToString()
                    + ", pues la diferencia mínima en días entre la fecha de desembolso y la fecha de primera cuota es 20."
                    , "DÍA AJUSTADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.dFecha.Day);
            }
            
            cboEstadoCredito1.SelectedValue = 0;//Convert.ToInt32(datsolrepro.Rows[0]["idEstado"]);            
            cboPersonalCreditos.SelectedValue = datsolrepro.Rows[0]["idUsuario"] == DBNull.Value ? 0 : Convert.ToInt32(datsolrepro.Rows[0]["idUsuario"]);
            cboTipoCredito.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["nTipCre"]);
            cboSubTipoCredito.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["nSubTip"]);
            cboProducto.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["nProdu"]);
            cboSubProducto.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["nSubPro"]);
            cboModDesemb1.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["idModalidadDes"]);
            txtCodCliente.Text = Convert.ToString(datsolrepro.Rows[0]["idCli"]);
            txtNombre.Text = Convert.ToString(datsolrepro.Rows[0]["cNombre"]);
            txtNroDocIde.Text = Convert.ToString(datsolrepro.Rows[0]["cDocumentoID"]);
            cboDestinoCredito.SelectedValue = datsolrepro.Rows[0]["idDestino"] == DBNull.Value? 1 : Convert.ToInt32(datsolrepro.Rows[0]["idDestino"]);
            idPreSolicitud = 0;

            var idActividadInterna = datsolrepro.Rows[0]["idActividadInterna"] == DBNull.Value ? 0 : Convert.ToInt32(datsolrepro.Rows[0]["idActividadInterna"]);
            conActividadCIIU1.cargarActividadInterna(idActividadInterna);

            
            cboFuenteRecurso1.SelectedValue = Convert.ToString(datsolrepro.Rows[0]["idRecurso"]);
            txtIdAdeudado.Text = Convert.ToString(datsolrepro.Rows[0]["idAdeudado"]);
            cboModalidadCredito.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["idModalidadCredito"]);
            if (datsolrepro.Rows[0]["idPromotor"] != DBNull.Value)
            {
                cboPromotores1.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["idPromotor"]);
            }
            cComentAproba = datsolrepro.Rows[0]["cComentAproba"].ToString();//-->
            if (string.IsNullOrEmpty(txtIdAdeudado.Text) == false)
            {
                Adeudado = ConsultAdeudado.CNRetornaAdeudado(Convert.ToInt32(txtIdAdeudado.Text));
                txtcDescripcion.Text = Convert.ToString(Adeudado.Rows[0]["cDescripcionLinea"]);
            }
            idTasa = datsolrepro.Rows[0]["idTasa"] == DBNull.Value ? 0 : Convert.ToInt32(datsolrepro.Rows[0]["idTasa"]);
            TasaReprogramacion(idTasa);
            txtTasaCompensatoria.Text = entCredito.nTasaCompensatoria.ToString("#,0.0000");
            txtTasaMora.Text = entCredito.nTasaMoratoria.ToString("#,0.0000");

            idTasaRepro = idTasa;
            nTasaRepro = entCredito.nTasaCompensatoria;
            nTasaMoraRepro = entCredito.nTasaMoratoria;

            cboDetalleGasto1.SelectedValue = Convert.ToInt32(datsolrepro.Rows[0]["idDetalleGasto"]);
            return true;
        }
        
        private void TasaReprogramacion(int idTasa)
        {
            clsCNTasaCredito TasaCredito = new clsCNTasaCredito();
            DataTable dtTasa;
            dtTasa = TasaCredito.TasaCreditoNegociable(idTasa);
            if (dtTasa.Rows.Count > 0)
            {
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                cboTipoTasaCredito.DataSource = dtTasa;
                cboTipoTasaCredito.SelectedIndex = 0;

                txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
            }
            else
            {
                txtTasCompensatoriaMin.Text = "";
                txtTasCompensatoriaMax.Text = "";
                txtTasaCompensatoria.Text = "";
                txtTasaMora.Text = "";
            }
        }

        private void insertarSolicitud()
        {
            lPerteneceOtraAgencia = false;
            cboTipoTasaCredito.SelectedValue = this.nAlmacenarTasaCredito;         
            string cCumpleReglas = String.Empty;
            string xmlCreditoProp = String.Empty;
            clsCreditoProp objCreditoProp = null;

            int idOferta = 0;
            if (this.objOferta != null)
            {
                string[] cProductosOferta = clsVarApl.dicVarGen["cProductosSegmentacion"].ToString().Split(',');
                int[] nProductosOferta = Array.ConvertAll<string, int>(cProductosOferta, int.Parse);

                int idSubProdActual = Convert.ToInt32(cboSubProducto.SelectedValue.ToString());
                int idOperActual = Convert.ToInt32(cboOperacionCre1.SelectedValue.ToString());
                if (idSubProdActual.In(nProductosOferta) && idOperActual!=3)
                {
                    idOferta = this.objOferta.idOferta;
                }
            }

            if (Transaccion == Convert.ToChar("X"))
            {
                nEstado = 1;
            }

            #region Actualiza Solicitud

            if (Transaccion == Convert.ToChar("U"))
            {
                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                DataTable dtParametros = ArmarTablaParametros();

                /*cCumpleReglas = cnregladinamica.ValidarReglas(dtParametros, this.Name,
                                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(txtCodCliente.Text),
                                                                   1, Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToInt32(cboProducto.SelectedValue),
                                                                   Decimal.Parse(txtMonto.Text), int.Parse(txtCodigoSol.Text), clsVarGlobal.dFecSystem,
                                                                   2, 1,
                                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);*/

                cCumpleReglas = cnregladinamica.ValidarReglasCreditos(dtParametros, this.Name,
                                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(txtCodCliente.Text),
                                                                   1, Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToInt32(cboProducto.SelectedValue),
                                                                   Decimal.Parse(txtMonto.Text), int.Parse(txtCodigoSol.Text), clsVarGlobal.dFecSystem,
                                                                   2, 1,
                                                                   clsVarGlobal.User.idUsuario, ref nNivAuto, true, false, Convert.ToInt32(txtCodigoSol.Text));
                int idEstadoSol = 0;
                //bool lFlagExcepciones = PermitirActualizarPorExcepcionCred(Convert.ToInt32(txtCodigoSol.Text));
                if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp") )
                {
                    idEstadoSol = 1;
                }
                else
                {
                    //idEstadoSol = cCumpleReglas.Equals("ExcepcionRechazada") ? 3 : 0;
                    idEstadoSol = 0;
                }


                    int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);
                    DataTable BusAgeSol = new clsCNSolicitud().CNBuscaAgenciaSolCre(idSolicitud);

                    if (Convert.ToInt32(BusAgeSol.Rows[0]["idAgencia"]) == clsVarGlobal.nIdAgencia)
                    {
                        foreach (DataColumn column in dtSolicitud.Columns)
                        {
                            column.ReadOnly = false;
                            column.AllowDBNull = true;
                        }

                        dtSolicitud.Columns["idActividad"].ReadOnly = false;
                        dtSolicitud.Columns["idOperacion"].ReadOnly = false;
                        dtSolicitud.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
                        dtSolicitud.Rows[0]["IdMoneda"] = cboMoneda1.SelectedValue;
                        dtSolicitud.Rows[0]["nCuotas"] = nudCuotas.Value;
                        dtSolicitud.Rows[0]["nPlazoCuota"] = this.conCreditoPeriodo.nPeriodoDia;
                        dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"] = dtFechaDesembolso.Value;

                        dtSolicitud.Rows[0]["idEstado"] = idEstadoSol;
                        //    dtSolicitud.Rows[0]["idEstado"] = cCumpleReglas.Equals("ExcepcionRechazada") ? 3 : 0;

                        dtSolicitud.Rows[0]["idUsuario"] = (int?) cboPersonalCreditos.SelectedValue ?? 0;
                        dtSolicitud.Rows[0]["idProducto"] = cboSubProducto.SelectedValue;
                        dtSolicitud.Rows[0]["tObservacion"] = txtObservacion.Text;
                        dtSolicitud.Rows[0]["idDestino"] = cboDestinoCredito.SelectedValue;
                        dtSolicitud.Rows[0]["nTasaCompensatoria"] = txtTasaCompensatoria.Text;
                        dtSolicitud.Rows[0]["nTasaMoratoria"] = txtTasaMora.Text;
                        dtSolicitud.Rows[0]["idTasa"] = (int)cboTipoTasaCredito.SelectedValue;// idTasa;
                        dtSolicitud.Rows[0]["idActividad"] = this.conActividadCIIU1.cboCIIU.SelectedValue;
                        dtSolicitud.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
                        dtSolicitud.Rows[0]["ndiasgracia"] = nudDiasGracia.Value;
                        dtSolicitud.Rows[0]["idTipoPeriodo"] = this.conCreditoPeriodo.idTipoPeriodo;
                        dtSolicitud.Rows[0]["idRecurso"] = cboFuenteRecurso1.SelectedValue;
                        dtSolicitud.Rows[0]["idOperacion"] = cboOperacionCre1.SelectedValue;
                        dtSolicitud.Rows[0]["nMontoAmpliado"] = (txtMontoAmpliacion.Text.Trim() == "") ? "0" : txtMontoAmpliacion.Text;
                        dtSolicitud.Rows[0]["nSaldoCreditos"] = (txtSalTotalCre.Text.Trim() == "") ? "0" : txtSalTotalCre.Text;
                        dtSolicitud.Rows[0]["idModalidadCredito"] = cboModalidadCredito.SelectedValue;
                        dtSolicitud.Rows[0]["idPromotor"] = (int?)cboPromotores1.SelectedValue ?? 0;
                        dtSolicitud.Columns["cComentAproba"].ReadOnly = false;
                        dtSolicitud.Rows[0]["cComentAproba"] = cComentAproba;//-->
                        dtSolicitud.Rows[0]["idActividadInterna"] = Convert.ToInt32(this.conActividadCIIU1.cboActividadInterna1.SelectedValue);
                        
                        dtSolicitud.Rows[0]["idPreSolicitud"] = idPreSolicitud;
                        dtSolicitud.Rows[0]["idAdeudado"] = (String.IsNullOrEmpty(txtIdAdeudado.Text.Trim())) ? "0" : txtIdAdeudado.Text;
                        dtSolicitud.Rows[0]["nCuotasGracia"] = nudNroCuoGracia.Value;
                        dtSolicitud.Rows[0]["idVisita"] = (this.objSel == null) ? 0 : this.objSel.idVisita;
                        dtSolicitud.Rows[0]["idEOBDesembolso"] = (cboEstablecimiento.SelectedIndex == -1) ? 0 : cboEstablecimiento.SelectedValue;

                        dtSolicitud.Rows[0]["idTipoLocalActividad"] = 0; 
                        dtSolicitud.Rows[0]["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
                        dtSolicitud.Rows[0]["idDetallegasto"] = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
                        dtSolicitud.Rows[0]["idPeriodoCredito"] = this.conCreditoPeriodo.idPeriodo;
	                idPaqueteSeguro = (Convert.ToInt32(cboPaqueteSeguro1.SelectedValue) == -1) ? 0 : Convert.ToInt32(cboPaqueteSeguro1.SelectedValue);
	                dtSolicitud.Rows[0]["idPaqueteSeguro"] = idPaqueteSeguro;
	                dtSolicitud.Rows[0]["idFrmPaqueteSeguro"] = objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;

                        btnVincularVisita1.idSolicitud = idSolicitud;
                        btnVincularVisita1.idCli = Convert.ToInt32(this.txtCodCliente.Text);

                        DataSet ds = new DataSet("dssolici");
                        ds.Tables.Add(dtSolicitud);
                        string XmlSoli = ds.GetXml();
                        XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                        ds.Tables.Clear();

                        //creditos Ampliados
                        string XmlCreAmp;
                        XmlCreAmp = XmlCreditosAmpliados();

                        objCreditoProp = retornaCreditoProp();
                        xmlCreditoProp = objCreditoProp.GetXml();


                        
                        DataTable InsSol = new clsCNSolicitud().InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, idCuenta, idSoliCambio,
                                                                                    XmlCreAmp, false, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idOferta, Convert.ToInt32(cboCanalVendedor1.SelectedValue), lOpinionRiesgos);
                        this.txtCodigoSol.Text = InsSol.Rows[0]["idCodSol"].ToString();
                        btnVincularVisita1.idSolicitud = Convert.ToInt32(InsSol.Rows[0]["idCodSol"]);
                        btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);


                        MessageBox.Show("Solicitud fue actualizada correctamente", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No puede modificar la solicitud porque pertenece a la " + Convert.ToString(BusAgeSol.Rows[0]["cNombreAge"]), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        lPerteneceOtraAgencia = true;
                    }

                //}

                //if ((cCumpleReglas.Equals("NoCumple") && !lFlagExcepciones) || (cCumpleReglas.Equals("NoCumpleSoloExcp") && !lFlagExcepciones))
                //{
                //    foreach (DataColumn column in dtSolicitud.Columns)
                //    {
                //        column.ReadOnly = false;
                //    }

                //    dtSolicitud.Columns["idActividad"].ReadOnly = false;
                //    dtSolicitud.Rows[0]["nCapitalSolicitado"] = txtMonto.Text;
                //    dtSolicitud.Rows[0]["IdMoneda"] = cboMoneda1.SelectedValue;
                //    dtSolicitud.Rows[0]["nCuotas"] = nudCuotas.Value;
                //    dtSolicitud.Rows[0]["nPlazoCuota"] = nudPlazo.Value;
                //    dtSolicitud.Rows[0]["idEstado"] = cCumpleReglas.Equals("ExcepcionRechazada") ? 3 : 0;
                //    dtSolicitud.Rows[0]["idUsuario"] = (int?)cboPersonalCreditos.SelectedValue ?? 0;
                //    dtSolicitud.Rows[0]["idProducto"] = cboSubProducto.SelectedValue;
                //    dtSolicitud.Rows[0]["tObservacion"] = txtObservacion.Text;
                //    dtSolicitud.Rows[0]["idDestino"] = cboDestinoCredito.SelectedValue;
                //    dtSolicitud.Rows[0]["nTasaCompensatoria"] = txtTasaCompensatoria.Text;
                //    dtSolicitud.Rows[0]["idTasa"] = (int)cboTipoTasaCredito.SelectedValue;// idTasa;
                //    dtSolicitud.Rows[0]["idActividad"] = this.conActividadCIIU1.cboCIIU.SelectedValue;
                //    dtSolicitud.Rows[0]["idModalidadDes"] = cboModDesemb1.SelectedValue;
                //    dtSolicitud.Rows[0]["ndiasgracia"] = nudDiasGracia.Value;
                //    dtSolicitud.Rows[0]["idTipoPeriodo"] = cboTipoPeriodo.SelectedValue;
                //    dtSolicitud.Rows[0]["idRecurso"] = cboFuenteRecurso1.SelectedValue;
                //    dtSolicitud.Rows[0]["idOperacion"] = cboOperacionCre1.SelectedValue;
                //    dtSolicitud.Rows[0]["nMontoAmpliado"] = (txtMontoAmpliacion.Text.Trim() == "") ? "0" : txtMontoAmpliacion.Text;
                //    dtSolicitud.Rows[0]["nSaldoCreditos"] = (txtSalTotalCre.Text.Trim() == "") ? "0" : txtSalTotalCre.Text;
                //    dtSolicitud.Rows[0]["idModalidadCredito"] = cboModalidadCredito.SelectedValue;
                //    dtSolicitud.Columns["idPromotor"].ReadOnly = false;
                //    dtSolicitud.Rows[0]["idPromotor"] = (int?)cboPromotores1.SelectedValue ?? 0;
                //    dtSolicitud.Rows[0]["cComentAproba"] = cComentAproba;//-->
                //    dtSolicitud.Rows[0]["idActividadInterna"] = Convert.ToInt32(this.conActividadCIIU1.cboActividadInterna1.SelectedValue);
                //    dtSolicitud.Rows[0]["lVerificacion"] = chcVerificacion.Checked;
                //    dtSolicitud.Rows[0]["cVerificacion"] = txtVerificacionDom.Text.Trim();
                //    dtSolicitud.Rows[0]["idPreSolicitud"] = idPreSolicitud;
                //    dtSolicitud.Rows[0]["idAdeudado"] = (String.IsNullOrEmpty(txtIdAdeudado.Text.Trim())) ? "0" : txtIdAdeudado.Text;

                //    DataSet ds = new DataSet("dssolici");
                //    ds.Tables.Add(dtSolicitud);
                //    string XmlSoli = ds.GetXml();
                //    XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                //    ds.Tables.Clear();

                //    //creditos Ampliados
                //    //string XmlCreAmp;
                //    //XmlCreAmp = XmlCreditosAmpliados();

                //    DataTable InsSol = new clsCNSolicitud().InsertaActualizaSolicitud(XmlSoli, null, clsVarGlobal.nIdAgencia, idCuenta, idSoliCambio, null, false, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                //    this.txtCodigoSol.Text = InsSol.Rows[0]["idCodSol"].ToString();
                //    btnGrabar1.Enabled = false;

                //    //MessageBox.Show("Solicitud fue actualizada correctamente", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            #endregion

            #region Inserta solicitud
            else
            {
                foreach (DataColumn column in dtSolicitud.Columns)
                {
                    column.ReadOnly = false;
                    column.AllowDBNull = true;
                }

                dtSolicitud.Rows.Clear();
                DataRow dr = dtSolicitud.NewRow();

                dtSolicitud.Columns["idActividad"].ReadOnly = false;
                dr["nCapitalSolicitado"] = txtMonto.Text;
                dr["IdMoneda"] = cboMoneda1.SelectedValue;
                dr["idOperacion"] = cboOperacionCre1.SelectedValue;
                dr["nCuotas"] = nudCuotas.Value;
                dr["nPlazoCuota"] = this.conCreditoPeriodo.nPeriodoDia;
                dr["dFechaDesembolsoSugerido"] = dtFechaDesembolso.Value;
                dr["idEstado"] = 0;
                dr["idUsuario"] = (int?)cboPersonalCreditos.SelectedValue ?? 0;
                dr["idProducto"] = cboSubProducto.SelectedValue;
                dr["nTasaCompensatoria"] = txtTasaCompensatoria.Text;
                dr["nTasaMoratoria"] = txtTasaMora.Text;
                dr["dFechaRegistro"] = dtpFechaSol.Value;
                dr["idCli"] = txtCodCliente.Text;
                dr["tObservacion"] = txtObservacion.Text;
                dr["idDestino"] = cboDestinoCredito.SelectedValue;
                dr["idTipoCli"] = nTipoCliente;
                dr["idTasa"] = (int)cboTipoTasaCredito.SelectedValue;// idTasa;
                dr["idActividad"] = this.conActividadCIIU1.cboCIIU.SelectedValue;
                dr["ndiasgracia"] = nudDiasGracia.Value;
                dr["idModalidadDes"] = cboModDesemb1.SelectedValue;
                dr["idTipoPeriodo"] = this.conCreditoPeriodo.idTipoPeriodo;
                dr["idRecurso"] = cboFuenteRecurso1.SelectedValue;
                dr["idCuenta"] = 0;
                dr["idSoliCambio"] = 0;
                dr["nMontoAmpliado"] = (txtMontoAmpliacion.Text.Equals("")) ? "0" : txtMontoAmpliacion.Text;
                dr["nSaldoCreditos"] = (txtSalTotalCre.Text.Equals("")) ? "0" : txtSalTotalCre.Text;
                dr["idModalidadCredito"] = cboModalidadCredito.SelectedValue;//-->
                dr["idPromotor"] = (int?)cboPromotores1.SelectedValue ?? 0;
                dr["cComentAproba"] = cComentAproba;
                dr["idActividadInterna"] = Convert.ToInt32(this.conActividadCIIU1.cboActividadInterna1.SelectedValue);
                dr["nEvaluacion"] = 0;
                dr["cTipoEvaluacion"] = "";
                dr["idPreSolicitud"] = idPreSolicitud;
                dr["idAdeudado"] = (String.IsNullOrEmpty(txtIdAdeudado.Text.Trim())) ? "0" : txtIdAdeudado.Text;
                dr["nCuotasGracia"] = nudNroCuoGracia.Value;
                dr["idCreditosPreAprobados"] = this.idCreditosPreAprobados;
                dr["idVisita"] = (this.objSel == null) ? 0 : this.objSel.idVisita;
                dr["idEOBDesembolso"] = (cboEstablecimiento.SelectedIndex == -1) ? 0 : cboEstablecimiento.SelectedValue;
                dr["idTipoLocalActividad"] = 0;
                dr["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
                dr["idDetallegasto"] = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
                dr["idPeriodoCredito"] = this.conCreditoPeriodo.idPeriodo;
                dr["idPaqueteSeguro"] = Convert.ToInt32(cboPaqueteSeguro1.SelectedValue);
                dr["idFrmPaqueteSeguro"] = objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;
                dtSolicitud.Rows.Add(dr);

                DataSet ds = new DataSet("dssolici");
                ds.Tables.Add(dtSolicitud);
                string XmlSoli = ds.GetXml();
                XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                ds.Tables.Clear();

                //creditos Ampliados
                string XmlCreAmp;
                XmlCreAmp = XmlCreditosAmpliados();

                objCreditoProp = retornaCreditoProp();
                xmlCreditoProp = objCreditoProp.GetXml();

                clsCNSolicitud InsertaActualizaSol = new clsCNSolicitud();
                DataTable InsSol = InsertaActualizaSol.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, idCuenta, idSoliCambio, XmlCreAmp, false, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idOferta, Convert.ToInt32(cboCanalVendedor1.SelectedValue), lOpinionRiesgos);
                this.txtCodigoSol.Text = InsSol.Rows[0]["idCodSol"].ToString();
                //btnAdministradorFiles1.idSolicitud = Convert.ToInt32(InsSol.Rows[0]["idCodSol"]);
                //btnAdministradorFiles1.actualizarDatos();
                //btnAdministradorFiles1.lectura = false;
                btnGrabar1.Enabled = false;

                btnVincularVisita1.idSolicitud = Convert.ToInt32(InsSol.Rows[0]["idCodSol"]);
                btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);

                int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
                cCumpleReglas = cnregladinamica.ValidarReglasCreditos(ArmarTablaParametros(), this.Name,
                                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(txtCodCliente.Text),
                                                                   1, Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToInt32(cboProducto.SelectedValue),
                                                                   Decimal.Parse(txtMonto.Text), int.Parse(txtCodigoSol.Text), clsVarGlobal.dFecSystem,
                                                                   2, 1,
                                                                   clsVarGlobal.User.idUsuario, ref  nNivAuto, true, false, Convert.ToInt32(txtCodigoSol.Text));

                //bool lFlagExcepciones = PermitirActualizarPorExcepcionCred(Convert.ToInt32(txtCodigoSol.Text));
                if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp"))
                {
                    int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);

                    InsertaActualizaSol.CNActualizaEstadoSolCre(idSolicitud, 1);
                }
                else
                {
                    this.btnGrabar1.Enabled = true;
                }

                MessageBox.Show(String.Format("Solicitud N° {0} registrada correctamente.", txtCodigoSol.Text), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                decimal nMontoOpiRecuperaciones = Convert.ToDecimal(clsVarApl.dicVarGen["nMontoOpinionRecuperaciones"]);
               
                DataTable dtResultado = (new clsCNSolicitudAmortiza()).consultarOpinionRecuperacion(Convert.ToInt32(txtCodigoSol.Text));
                int nSoliRecu= Convert.ToInt32(dtResultado.Rows[0]["nSolicitud"]);

                if ((Convert.ToDecimal(txtMonto.Text) >= nMontoOpiRecuperaciones && (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre1.SelectedValue) == 6)) || nSoliRecu>0 )
                {
                    MessageBox.Show(String.Format("Se generó solicitud para opinión de recuperaciones."), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            #endregion

            if (Convert.ToInt32(txtCodigoSol.Text) != 0 && (objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro) || objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
            {
                string xmlSolicitudCreditoSeguro = objSolicitudCreditoCargaSeguro.GetXml();

                DataTable dtResultadoSeguro = new clsCNCreditoCargaSeguro().CNRegistrarSolicitudCreditoSeguro(Convert.ToInt32(txtCodigoSol.Text), xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 0 || Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == -1)
                {
                    MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (objCreditoProp != null)
            {
                this.AlertaCreditos50000(Convert.ToInt32(this.txtCodigoSol.Text), objCreditoProp.nMontoSolicitado);
            }
        }

        private string XmlCreditosAmpliados()
        {
            DataSet dsCreAmp = new DataSet("dsCreAmp");

            if (dtCreditosAmp == null)
            {
                DataTable newDtCreAmp = new DataTable("Table1");
                dsCreAmp.Tables.Add(newDtCreAmp);
            }
            else
            {
                dsCreAmp.Tables.Add(dtCreditosAmp);
            }
            string XmlCreAmp = dsCreAmp.GetXml();
            XmlCreAmp = clsCNFormatoXML.EncodingXML(XmlCreAmp);
            dsCreAmp.Tables.Clear();
            return XmlCreAmp;
        }

        public decimal obtenerCuotaAproximadaCalendarioPago()
        {
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            DataTable dtCalendarioPagos = new DataTable();
            dtCalendarioPagos = objCNPlanPago.CalculaPpgCuotasConstantes(
                Convert.ToDecimal(txtMonto.Text),
                Convert.ToDecimal(txtTasaCompensatoria.Text) / 100.00m,
                dtFechaDesembolso.Value,
                Convert.ToInt32(nudCuotas.Value),
                Convert.ToInt32(nudDiasGracia.Value),
                Convert.ToInt16(this.conCreditoPeriodo.idTipoPeriodo),
                this.conCreditoPeriodo.nPeriodoDia,
                0,
                new DataTable(),
                Convert.ToInt32(cboMoneda1.SelectedValue),
                new DataTable(),
                conCreditoPrimeraCuota.dFecha
            );

            if (nudNroCuoGracia.Value > 0)
            {
                dtCalendarioPagos = objCNPlanPago.CalcularCuotasGracia(
                    dtCalendarioPagos,
                    Convert.ToDecimal(txtMonto.Text),
                    Convert.ToDecimal(txtTasaCompensatoria.Text) / 100.00m,
                    dtFechaDesembolso.Value,
                    Convert.ToInt32(nudDiasGracia.Value),
                    Convert.ToInt16(this.conCreditoPeriodo.idTipoPeriodo),
                    this.conCreditoPeriodo.nPeriodoDia,
                    new DataTable(),
                    Convert.ToInt32(cboMoneda1.SelectedValue),
                    new DataTable(),
                    conCreditoPrimeraCuota.dFecha,
                    Convert.ToInt32(nudCuotas.Value),
                    Convert.ToInt32(nudNroCuoGracia.Value)
                );
            }

            if (dtCalendarioPagos.Rows.Count > 0)
                return Convert.ToDecimal(dtCalendarioPagos.Rows[0]["imp_cuota"]);

            return 0;
        }
        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");
            //123
            int idUsuario = cboPersonalCreditos.SelectedValue == DBNull.Value ? 0 : Convert.ToInt32(cboPersonalCreditos.SelectedValue);

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = string.IsNullOrEmpty(txtCodigoSol.Text.Trim()) ? 0 : Convert.ToInt32(txtCodigoSol.Text.Trim());
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotaAproximada";
            drfila[1] = obtenerCuotaAproximadaCalendarioPago();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dni";
            drfila[1] = txtNroDocIde.Text != "" ? "'" + txtNroDocIde.Text.Trim() + "'" : "'0'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = txtCodCliente.Text.Trim();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoTasaCredito";
            drfila[1] = this.idTipoTasaCredito;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSolicitud";
            drfila[1] = "'" + dtpFechaSol.Value.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";
            drfila[1] = cboOperacionCre1.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = txtMonto.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda1.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = nudCuotas.Value.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = this.conCreditoPeriodo.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = this.conCreditoPeriodo.nPeriodoDia.ToString();
            dtTablaParametros.Rows.Add(drfila);


                drfila = dtTablaParametros.NewRow();
                drfila[0] = "idCuenta";
                drfila[1] = idCuentaCredito;
                dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = cboOperacionCre1.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nDiasGracia";
            drfila[1] = nudDiasGracia.Value;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaDesembolso";
            drfila[1] = "'" + dtFechaDesembolso.Value.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaPriCuota";
            drfila[1] = "'" + this.conCreditoPrimeraCuota.dFechaPriCuota().ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idActivEcon";
            drfila[1] = this.conActividadCIIU1.cboActividadEco.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "CIIU";
            drfila[1] = this.conActividadCIIU1.cboCIIU.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "PersonalCre";
            drfila[1] = idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoCredito";
            drfila[1] = cboTipoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubTipoCredito";
            drfila[1] = cboSubTipoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Producto";
            drfila[1] = cboProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "SubProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "DestinoCredito";
            drfila[1] = cboDestinoCredito.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idFuenteRecur";
            drfila[1] = cboFuenteRecurso1.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAdeudado";
            drfila[1] = txtIdAdeudado.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMes";
            drfila[1] = txtTasaCompensatoria.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMin";
            drfila[1] = txtTasCompensatoriaMin.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "TasaEfecMax";
            drfila[1] = txtTasCompensatoriaMax.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "ModDesembolso";
            drfila[1] = cboModDesemb1.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = "'" + clsVarGlobal.cNomAge.Trim() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfilUsu";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfilUsu.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVigente";
            drfila[1] = clsVarGlobal.PerfilUsu.lVigente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoAsesorFam = new GEN.CapaNegocio.clsCNCredito();
            DataTable SaldoIndividual = SaldoAsesorFam.CNRetornSaldoxAseFam(Convert.ToInt32(txtCodCliente.Text.Trim()), Convert.ToDecimal(txtMonto.Text), Convert.ToInt32(cboMoneda1.SelectedValue), clsVarGlobal.nIdAgencia);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nSaldoInd";
            drfila[1] = SaldoIndividual.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);

            GEN.CapaNegocio.clsCNCredito SaldoTotalAsesorFam = new GEN.CapaNegocio.clsCNCredito();
            DataTable SaldoGlobal = SaldoTotalAsesorFam.CNRetornSaldoTotalAseFam(clsVarGlobal.nIdAgencia, Convert.ToDecimal(txtMonto.Text), Convert.ToInt32(cboMoneda1.SelectedValue));
            drfila = dtTablaParametros.NewRow();

            drfila[0] = "nSaldoGlobal";
            drfila[1] = SaldoGlobal.Rows[0]["SaldoTotal"];
            dtTablaParametros.Rows.Add(drfila);
            //agregar idCuenta en una sola cadena
            string idCuentas = "";

            //if (dtCreditosAmp != null && dtCreditosAmp.Rows.Count > 0)
            //{
            //    foreach (DataRow item in dtCreditosAmp.Rows)
            //    {
            //        idCuentas = idCuentas + "," + item[1].ToString();
            //    }
            //    idCuentas = idCuentas.Substring(1);
            //}


            if (dtgCuentaCreditoVinculado.DataSource != null && dtgCuentaCreditoVinculado.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dtgCuentaCreditoVinculado.Rows)
                {
                    idCuentas = idCuentas + "," + item.Cells[1].Value.ToString();
                }
                idCuentas = idCuentas.Substring(1);
            }

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cCadenaIdCuenta";
            drfila[1] = "'" + idCuentas + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = clsVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdTipologiaCre";
            drfila[1] = Convert.ToInt32(cboModalidadCredito.SelectedValue).ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoTasaCredito";
            drfila[1] = (int?)cboTipoTasaCredito.SelectedValue ?? 0;
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCredito";
            drfila[1] = (int?)cboModalidadCredito.SelectedValue ?? 0;
            dtTablaParametros.Rows.Add(drfila);

            int nPlazoTotal = obtenerTotalDias(Convert.ToDateTime(dtFechaDesembolso.Text), Convert.ToInt32(nudCuotas.Value), Convert.ToInt32(nudDiasGracia.Value.ToString()), this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.nPeriodoDia);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = nPlazoTotal;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = cboSubProducto.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotasGracia";
            drfila[1] = nudNroCuoGracia.Value.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaProximoVencimiento";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCliente";
            drfila[1] = this.nTipoCliente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoLocalActividad";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOferta";
            drfila[1] = (this.objOferta == null)? "0" : this.objOferta.idOferta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.nMontoOferta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.nPlazo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacionOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idOperacion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModalidadCreditoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idModalidadCredito.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nFrecuenciaOferta";
            drfila[1] = (this.objOferta == null) ? "0" : (this.objOferta.nMeses/30).ToString(); // crear un campo donde se obtenga los meses de frecuencia
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProdUno";
            drfila[1] = (this.listProd == null) ? "0" : (this.listProd[0].idProducto).ToString(); // crear un campo donde se obtenga los meses de frecuencia
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProdDos";
            drfila[1] = (this.listProd == null) ? "0" : (this.listProd.Count>1)?(this.listProd[1].idProducto).ToString(): "0"; // crear un campo donde se obtenga los meses de frecuencia
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProdTres";
            drfila[1] = (this.listProd == null) ? "0" : (this.listProd.Count>2)?(this.listProd[2].idProducto).ToString(): "0"; // crear un campo donde se obtenga los meses de frecuencia
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDestinoOferta";
            drfila[1] = (this.objOferta == null) ? "0" : this.objOferta.idDestinoCredito.ToString(); // crear un campo donde se obtenga el destino de la Oferta
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDetGasto";
            drfila[1] = cboDetalleGasto1.SelectedValue == null ? "0" : cboDetalleGasto1.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }

        private bool estaEnDatos(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');
            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidaTipoPeriodoRural()
        {
            bool lflag = true;

            string idEvalRural = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cIDsTipEvalCredRural")).cValVar;
            DataTable dtProductosRural = new clsCNSolicitud().CNRecuperarProductoTipEval(idEvalRural);
            var lstPeriodos = new clsCNTipoPeriodo().listarPeriodoCredito();
            var lstPeriodosPermitidos = lstPeriodos.FindAll(x => x.idPeriodoCredito == (int)ePeriodoCred.Mensual || x.idPeriodoCredito == (int)ePeriodoCred.Unicuota);

            int idSubProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
            int idTipoPeriodo = this.conCreditoPeriodo.idTipoPeriodo;
            int idPeridoFijo = (this.conCreditoPeriodo.idPeriodo > 0) ? this.conCreditoPeriodo.idPeriodo : 0;
            var objPeriodoElejido = lstPeriodos.Find(x => x.idPeriodoCredito == idPeridoFijo);

            List<int> lstSubProductos = new List<int>();
            foreach (DataRow item in dtProductosRural.Rows)
            {
                lstSubProductos.Add(Convert.ToInt32(item["idProducto"]));
            }

            if (idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres && !lstSubProductos.Contains(idSubProducto)) //Para Cuotas Libres
            {
                MessageBox.Show("Cuotas libres solo está disponible para los productos Agrícola Rural y Pecuario Rural.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lflag = false;
            }
            else if(lstSubProductos.Contains(idSubProducto) 
                && idTipoPeriodo == (int)eTipoPeriodoCred.FechaFija) //Para el sub Producto Rural
            {
                MessageBox.Show("Para los productos Agrícola Rural y Pecuario Rural no está disponible Fecha Fija.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lflag = false;
            }
            else if (lstSubProductos.Contains(idSubProducto) 
                && idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo 
                && (!lstPeriodosPermitidos.Contains(objPeriodoElejido))) //Para el sub Producto Rural
            {
                MessageBox.Show("Para los productos Agrícola Rural y Pecuario Rural no está disponible el Periodo seleccionado.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lflag = false;
            }

            return lflag;
        }

        private bool ValidaCuotasLibres()
        {
            bool lflag = true;
            if (this.conCreditoPeriodo.idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres)
            {
                switch ((int)cboOperacionCre1.SelectedValue)
                {
                    case (int)eOperacion.Otorgamiento:
                        lflag = true;
                        break;

                    case (int)eOperacion.Refinanciacion:
                        lflag = true;
                        break;

                    default:
                        lflag = false;
                        break;
                }
            }
            
            if (!lflag)
                MessageBox.Show("Cuotas libres solo está disponible en Otorgamiento y Refinanciacion.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return lflag;
        }
        private bool validaActualizacion()
        {

            if (string.IsNullOrEmpty(txtCodCliente.Text))
            {
                MessageBox.Show("Registre Cliente", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Datos del Cliente no válido", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                MessageBox.Show("El monto solicitado debe ser mayor a CERO", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (Convert.ToInt32(nudCuotas.Value) == 0)
            {
                MessageBox.Show("Número de cuotas debe ser mayor a CERO", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (!this.conCreditoPeriodo.lTipoPeriodoSelected)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Periodo", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (this.conCreditoPeriodo.nPeriodoDia == 0)
            {
                MessageBox.Show("Plazo debe ser mayor a CERO", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (cboModalidadCredito.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la modalidad de créditos", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }

            if ((this.conCreditoPeriodo.idTipoPeriodo == 2) && (Convert.ToInt32(nudNroCuoGracia.Value) >= Convert.ToInt32(nudCuotas.Value)))
            {
                MessageBox.Show("El Nro. de cuotas de gracia no puede ser mayor o igual al nro de cuotas", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nudNroCuoGracia.Focus();
                nEstado = 1;
                return false;
            }

            /*SE AGREGO LA ACTIVIDAD ECONOMICA*/
            if (this.conActividadCIIU1.cboCIIU.Text.Trim() == "" || this.conActividadCIIU1.cboActividadEco.Text.Trim() == "" || this.conActividadCIIU1.cboGrupoCiiu.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar la Actividad Económica del Cliente", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.conActividadCIIU1.Enabled = true;
                nEstado = 1;
                return false;
            }

            /*if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue == 5)
            {

                if ((int)cboEstadoCredito1.SelectedValue == 1 && !chcVerificacion.Checked) //solicitado
                {
                    MessageBox.Show("Debe de registrar la verificación de dirección de cliente",
                        "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chcVerificacion.Focus();
                    nEstado = 1;
                    return false;
                }
            }*/
            if (cboSubProducto.SelectedIndex == 0)
            {
                MessageBox.Show("Solicitud no tiene un sub producto asignado", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            //if (cboPersonalCreditos.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Debe seleccionar a una responsable del crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    nEstado = 1;
            //    return false;
            //}
            if (cboDestinoCredito.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el Destino del crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (cboFuenteRecurso1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el Recurso del crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (Convert.ToInt32(cboFuenteRecurso1.SelectedValue) == 2)
            {
                if (string.IsNullOrEmpty(txtIdAdeudado.Text) || string.IsNullOrEmpty(txtcDescripcion.Text))
                {
                    MessageBox.Show("Debe seleccionar Adeudado para el crédito", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    nEstado = 1;
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtTasCompensatoriaMin.Text) || string.IsNullOrEmpty(txtTasCompensatoriaMax.Text))
            {
                MessageBox.Show("No se encuentra Rango de Tasa Compensatoria", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (Convert.ToInt32(this.cboOperacionCre1.SelectedValue) != 3 && (string.IsNullOrEmpty(txtTasaCompensatoria.Text) || txtTasaCompensatoria.nDecValor > txtTasCompensatoriaMax.nDecValor || txtTasaCompensatoria.nDecValor < txtTasCompensatoriaMin.nDecValor))
            {
                MessageBox.Show("Debe registrar Tasa Compensatoria según Rango de Tasas", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }

            if (cboModDesemb1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la Modalidad de Desembolso", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }

            if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue == 5) //carta fianza
            {
                MessageBox.Show("El producto no corresponde a Cartas Fianza", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }

            if (Convert.ToDateTime(dtFechaDesembolso.Text) < dFechaSistema && Convert.ToInt32(this.cboOperacionCre1.SelectedValue)!=(int)OperacionCredito.ReprogramacionCambioFecha)
            {
                MessageBox.Show("La Fecha de Desembolso no puede ser menor a la del sistema", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (this.conCreditoPrimeraCuota.dFecha < dtFechaDesembolso.Value)
            {
                MessageBox.Show("La Fecha de Primera Cuota no puede ser menor a la Fecha de Desembolso",
                    "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if (!estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)))
            {
                /*if (chcVerificacion.Checked)
                {
                    if (string.IsNullOrEmpty(txtVerificacionDom.Text))
                    {
                        MessageBox.Show("Debe registrar los comentarios de la verificación", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nEstado = 1;
                        txtVerificacionDom.Focus();
                        return false;
                    }
                }*/
            }

            if (estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue != 5) //carta fianza
            {
                MessageBox.Show("El tipo de operación debe ser CARTA FIANZA.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }


            Int32 CodCli = Convert.ToInt32(txtCodCliente.Text);
            Int16 Producto = Convert.ToInt16(cboSubProducto.SelectedValue);
            DataTable Validasol = cnsolicitud.CNdtValidaRegSol(CodCli, Producto);
            string Valida = Validasol.Rows[0][0].ToString();
            if (Valida.Trim() != "OK" && (int)cboOperacionCre1.SelectedValue == 1 && Transaccion == Convert.ToChar("I"))
            {
                MessageBox.Show(Validasol.Rows[0][0].ToString(), "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                nEstado = 1;
                return false;
            }
            if ((int)cboEstadoCredito1.SelectedValue == 1)
            {
                if (this.cboPersonalCreditos.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe de seleccionar asesor de negocios", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboPersonalCreditos.Focus();
                    return false;
                }
            }
            nEstado = 0;
            return true;
        }
        private void BuscarCliente()
        {
            FrmBusCli FrmBus = new FrmBusCli();
            FrmBus.ShowDialog();

            if (FrmBus.pcCodCli == "" || string.IsNullOrEmpty(FrmBus.pcCodCli))
            {
                txtCodInst.Text = "";
                txtCodAge.Text = "";
                txtCodCliente.Text = "0";
                txtNombre.Text = "";
                txtNroDocIde.Text = "";
                idClasificacionInterna = 0;
            }
            else
            {
                if (Convert.ToBoolean(FrmBus.pIndicaDatoBasico) == true)
                {
                    MessageBox.Show("Debe Registrar Datos Completos del Cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lIndicaDatoBasico = true;
                    txtCodInst.Text = "";
                    txtCodAge.Text = "";
                    txtCodCliente.Text = "0";
                    txtNombre.Text = "";
                    txtNroDocIde.Text = "";
                    idClasificacionInterna = 0;
                    return;
                }

                idClasificacionInterna = FrmBus.pnIdClasifInt;
                lblCalificacionInterna.Text = FrmBus.pcClasifInt;

                CambiarClasificacionInterna(Convert.ToInt32(FrmBus.pcCodCli), Convert.ToInt32(FrmBus.pnIdClasifInt));

                lblCalificacionInterna.Text = cClasifInternaTmp;
                                
                txtCodInst.Text = FrmBus.pcCodCliLargo.Substring(0, 3);
                txtCodAge.Text = FrmBus.pcCodCliLargo.Substring(3, 3);
                txtCodCliente.Text = FrmBus.pcCodCliLargo.Substring(6);
                txtNombre.Text = FrmBus.pcNomCli;
                txtNroDocIde.Text = FrmBus.pcNroDoc;
                nTipoCliente = FrmBus.idTipoCliente;
                
                this.nudAniosActEco.Value = FrmBus.nAniosActEco;
                this.idActividadInterna = FrmBus.idActividadInterna;

                if (this.idActividadInterna > 0)
                {
                    this.conActividadCIIU1.cargarActividadInterna(this.idActividadInterna);
                    this.conActividadCIIU1.Enabled = false;
                }

                initClienteRecurrente(nTipoCliente);
                btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);
                
            }
        }

        private void limpiar()
        {

            txtCodigoSol.Text = "";
            txtMonto.Text = "";
            nudCuotas.Value = 0;
            nudCuotas.Enabled = true;
            nudDiasGracia.Value = 0;
            nudNroCuoGracia.Value = 0;
            cboOperacionCre1.SelectedValue = 1;
            cboCanalVendedor1.SelectedValue = 0;
            cboEstadoCredito1.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 1;
            cboSubTipoCredito.SelectedValue = 2;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboPromotores1.SelectedIndex = -1;
            cboPersonalCreditos.SelectedValue = 0;
            cboModDesemb1.SelectedValue = 0;
            this.conCreditoPeriodo.limpiarControles();
            txtObservacion.Text = "";
            txtCodCliente.Text = "";
            txtNombre.Text = "";
            txtNroDocIde.Text = "";
            txtTasaMora.Text = "";
            txtIdAdeudado.Text = "0";
            txtcDescripcion.Text = "";
            conActividadCIIU1.cboActividadInterna1.SelectedIndex = -1;
            conActividadCIIU1.cboActividadInterna1.SelectedValue = 0;
            conActividadCIIU1.cboActividadEco.SelectedValue = 0;
            btn_Vincular2.Enabled = false;
            btnGestObs.Enabled = false;
            txtTasaCompensatoria.Text = "";
            txtTasCompensatoriaMin.Text = "";
            txtTasCompensatoriaMax.Text = "";
            txtSalTotalCre.Clear();
            txtMontoAmpliacion.Clear();
            txtCodInst.Text = "";
            txtCodAge.Text = "";
            txtNumEva.Text = "";
            nContador = 0;
            nidTipoPersona = 0;
            lblEstadoSolicitud.Visible = false;
            cboEstadoCredito1.Visible = false;
            lblTipoTasaCredito.Text = "";
            
            dtSolicitud = new DataTable("dtSolicitud");
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            cboTipoTasaCredito.DataSource = null;
            cboTipoTasaCredito.Enabled = true;
            idTasa = 0; nContador = 0; idEvaluacion=0; CodPro = 1; nEstado = 0; idPreSolicitud = 0;
            idCuenta = 0; idSoliCambio = 0; nidTipoPersona = 0;
            this.lConTasaNegociable = false;
            lblCliente.Text = "---";
            lblCalificacionInterna.Text = "";
            cboEstablecimiento.SelectedIndex = -1;
            

            idClasificacionInterna = 0;
            lblDesembolso.Text = "Desembolso";
        }

        private void limpiarOtraOperacion()
        {
            txtCodigoSol.Text = "";
            txtMonto.Text = "";
            nudCuotas.Value = 0;
            nudCuotas.Enabled = true;
            nudDiasGracia.Value = 0;
            cboEstadoCredito1.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 1;
            cboSubTipoCredito.SelectedValue = 2;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboPromotores1.SelectedIndex = -1;
            cboPersonalCreditos.SelectedValue = 0;
            cboModDesemb1.SelectedValue = 0;
            conCreditoPeriodo.limpiarControles();
            txtObservacion.Text = "";
            txtTasaMora.Text = "";
            txtIdAdeudado.Text = "0";
            txtcDescripcion.Text = "";

            if (this.idActividadInterna <= 0)
            {
                this.conActividadCIIU1.cboActividadInterna1.SelectedIndex = -1;
                this.conActividadCIIU1.cboActividadInterna1.SelectedValue = 0;
                this.conActividadCIIU1.cboActividadEco.SelectedValue = 0;
                this.conActividadCIIU1.Enabled = true;
            }

            btn_Vincular2.Enabled = false;
            btnGestObs.Enabled = false;
            txtTasaCompensatoria.Text = "";
            txtTasCompensatoriaMin.Text = "";
            txtTasCompensatoriaMax.Text = "";
            txtSalTotalCre.Clear();
            txtMontoAmpliacion.Clear();
            txtNumEva.Text = "";
            nidTipoPersona = 0;
            lblEstadoSolicitud.Visible = false;
            cboEstadoCredito1.Visible = false;
            lblTipoTasaCredito.Text = "";
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;
            cboTipoTasaCredito.DataSource = null;
            lblDesembolso.Text = "Desembolso";
            //lblCalificacionInterna.Text = "";
            //idClasificacionInterna = 0;
        }

        private void buscarSolicitudCliente(int idCli)
        {
            DataTable dtSolCli;
            dtSolCli = cnsolicitud.SolicitudClienteEstado(idCli, 1);

            int nValBusqueda = 0;
            if (dtSolCli.Rows.Count == 0)
            {
                cargarDatosSolicitud(0);
                cargarDatosAesorDeCliente(idCli);
                lblEstadoSolicitud.Visible = false;
                cboEstadoCredito1.Visible = false;
                btnEditar.Enabled = false;
                btnEditar.Visible = false;
                if (VerificarUsuarioCampana())
                {
                    CargarDatosCampana(idCli);
                    AsignarDatosCampana();
                }

                CargarOfertaClienteExclusivo(idCli);
            }
            if (dtSolCli.Rows.Count == 1)
            {
                int idCanalRegistro = Convert.ToInt32(dtSolCli.Rows[0]["idCanalRegistro"]);
                if (idCanalRegistro == 2)
                {
                    MessageBox.Show("Esta solicitud de créditos se realizó por el Andy Collector, continuar el flujo por ese canal", "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                var idSoli = Convert.ToInt32(dtSolCli.Rows[0]["idSolicitud"]);
                //btnAdministradorFiles1.idSolicitud = idSoli;
                //btnAdministradorFiles1.actualizarDatos();
                //btnAdministradorFiles1.lectura = false;

                btnVincularVisita1.idSolicitud = idSoli;
                btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);

                //ACTUALIZA EL MONTO EN CASO DE REFINANCIACION Y NOVACIÓN
                cnsolicitud.actualizarMontosSolRefi(idSoli);
            
                cargarDatosSolicitud(idSoli);

                int idEstado = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);

                this.grbDato_Solicitud.Enabled = (lEditar) ? true : false;
                this.cboModalidadCredito.Enabled = (lEditar) ? true : false;
                this.cboModDesemb1.Enabled = (lEditar) ? (Convert.ToInt32(cboOperacionCre1.SelectedValue).In(2, 6)) ? false : true : false;
                if (!(idEstado > 1) || idEstado == 11)
                {
                    btnEditar.Enabled = true;
                    btnEditar.Visible = true; 
                    btnGrabar1.Enabled = false;
                    btnGrabar1.Visible = false;
                    btnEnviar.Enabled = (idEstado == 1 || idEstado == 11);
                }
                else
                {
                    btnEditar.Enabled = false;
                    btnEditar.Visible = false;
                    btnGrabar1.Enabled = false;
                    btnGrabar1.Visible = true;
                    btnEnviar.Enabled = false;
                }
                
                this.btnCargaArhivos.Enabled = (idEstado == 1 || idEstado == 11 || idEstado == 0);

                lblEstadoSolicitud.Visible = !(Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]) > 1);
                cboEstadoCredito1.Visible = !(Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]) > 1);


                txtCodCliente.Enabled = false;
                btnBusCliente.Enabled = false;
                txtCodigoSol.Enabled = false;
            }
            if (dtSolCli.Rows.Count > 1)
            {
                GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                string pcTipBus = "S";
                string pcEstado = "[1,11]";
                frmBusCuenCli.CargarDatos(idCli, pcTipBus, pcEstado);
                frmBusCuenCli.ShowDialog();
                nValBusqueda = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                if (nValBusqueda == 0)
                {
                    btnCancelar1.PerformClick();
                    return;
                }
                else
                {
                    cargarDatosSolicitud(nValBusqueda);
                    lblEstadoSolicitud.Visible = true;
                    cboEstadoCredito1.Visible = true;
                }

            }

            if (estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue == 5)
            {
                btnEnviar.Enabled = true;//false;
                this.btnCargaArhivos.Enabled = true;

                int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);

                DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idSolicitud);
                if ((dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) == 0))
                {
                    btnGrabar1.Enabled = false;
                    cboEstadoCredito1.Enabled = false;
                    btnExcepciones.Enabled = false;
                }
            }

            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) != 3)
            {
                asignarTasa();
                cboTipoTasaCredito.SelectedValue = idTasa;
            }
            this.conCreditoPeriodo.actualizarDia(this.conCreditoPrimeraCuota.nPeriodoDia);
        }


        private void buscarSolicitudClienteOferta(ClsOfertaClienteExclusivoMejorado objOferta)
        {
            DataTable dtSolCli;
            dtSolCli = cnsolicitud.SolicitudClienteEstado(objOferta.idCli, 1);

            int nValBusqueda = 0;
            if (dtSolCli.Rows.Count == 0)
            {
                cargarDatosSolicitud(0);
                cargarDatosAesorDeCliente(objOferta.idCli);
                lblEstadoSolicitud.Visible = false;
                cboEstadoCredito1.Visible = false;
                btnEditar.Enabled = false;
                btnEditar.Visible = false;
                if (VerificarUsuarioCampana())
                {
                    CargarDatosCampana(objOferta.idCli);
                    AsignarDatosCampana();
                }

                CargarOfertaClienteExclusivoJC(objOferta);
            }
            if (dtSolCli.Rows.Count == 1)
            {
                int idCanalRegistro = Convert.ToInt32(dtSolCli.Rows[0]["idCanalRegistro"]);
                if (idCanalRegistro == 2)
                {
                    MessageBox.Show("Esta solicitud de créditos se realizó por el Andy Collector, continuar el flujo por ese canal", "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                var idSoli = Convert.ToInt32(dtSolCli.Rows[0]["idSolicitud"]);
                //btnAdministradorFiles1.idSolicitud = idSoli;
                //btnAdministradorFiles1.actualizarDatos();
                //btnAdministradorFiles1.lectura = false;

                btnVincularVisita1.idSolicitud = idSoli;
                btnVincularVisita1.idCli = Convert.ToInt32(txtCodCliente.Text);

                //ACTUALIZA EL MONTO EN CASO DE REFINANCIACION Y NOVACIÓN
                cnsolicitud.actualizarMontosSolRefi(idSoli);
                
                cargarDatosSolicitud(idSoli);

                int idEstado = Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]);

                this.grbDato_Solicitud.Enabled = (lEditar) ? true : false;
                this.cboModalidadCredito.Enabled = (lEditar) ? true : false;
                this.cboModDesemb1.Enabled = (lEditar) ? (Convert.ToInt32(cboOperacionCre1.SelectedValue).In(2, 6)) ? false : true : false;
                if (!(idEstado > 1) || idEstado == 11)
                {
                    btnEditar.Enabled = true;
                    btnEditar.Visible = true;
                    btnGrabar1.Enabled = false;
                    btnGrabar1.Visible = false;
                    btnEnviar.Enabled = (idEstado == 1 || idEstado == 11);
                }
                else
                {
                    btnEditar.Enabled = false;
                    btnEditar.Visible = false;
                    btnGrabar1.Enabled = false;
                    btnGrabar1.Visible = true;
                    btnEnviar.Enabled = false;
                }

                this.btnCargaArhivos.Enabled = (idEstado == 1 || idEstado == 11 || idEstado == 0);

                lblEstadoSolicitud.Visible = !(Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]) > 1);
                cboEstadoCredito1.Visible = !(Convert.ToInt32(dtSolicitud.Rows[0]["idEstado"]) > 1);


                txtCodCliente.Enabled = false;
                btnBusCliente.Enabled = false;
                txtCodigoSol.Enabled = false;
            }
            if (dtSolCli.Rows.Count > 1)
            {
                GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                string pcTipBus = "S";
                string pcEstado = "[1,11]";
                frmBusCuenCli.CargarDatos(objOferta.idCli, pcTipBus, pcEstado);
                frmBusCuenCli.ShowDialog();
                nValBusqueda = Convert.ToInt32(frmBusCuenCli.cIdCreSol);

                if (nValBusqueda == 0)
                {
                    btnCancelar1.PerformClick();
                    return;
                }
                else
                {
                    cargarDatosSolicitud(nValBusqueda);
                    lblEstadoSolicitud.Visible = true;
                    cboEstadoCredito1.Visible = true;
                }

            }

            if (estaEnDatos(Convert.ToString(clsVarApl.dicVarGen["nSubProductoCartaFianza"]), Convert.ToInt32(cboSubProducto.SelectedValue)) && (int)cboOperacionCre1.SelectedValue == 5)
            {
                btnEnviar.Enabled = true;//false;
                this.btnCargaArhivos.Enabled = true;

                int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);

                DataTable dtValidar = cnCartaFianza.ValidarDatosCompletos(idSolicitud);
                if ((dtValidar.Rows.Count > 0 && Convert.ToInt32(dtValidar.Rows[0][0]) == 0))
                {
                    btnGrabar1.Enabled = false;
                    cboEstadoCredito1.Enabled = false;
                    btnExcepciones.Enabled = false;
                }
            }

            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) != 3)
            {
                asignarTasa();
                cboTipoTasaCredito.SelectedValue = idTasa;
            }
  

        }

        private void cargarDatosAesorDeCliente(int idCli)
        {
            var dtDatosAsesor = cnsolicitud.retornaDatosAsesorDeCliente(idCli);
            if (dtDatosAsesor.Rows.Count > 0)
            {
                //var idAgenciaUsu = Convert.ToInt32(dtDatosAsesor.Rows[0]["idAgenciaUsu"]);
                var idAsesor = Convert.ToInt32(dtDatosAsesor.Rows[0]["idAsesor"]);
                DataTable dtAsesores = cboPersonalCreditos.DataSource as DataTable;
                int? idOperacion = (int?) cboOperacionCre1.SelectedValue;
                if(dtAsesores == null) return;

                if (dtAsesores.AsEnumerable().Any(x => x.Field<int>(0) == idAsesor) &&
                        idOperacion != null && idOperacion.In(1, 4, 5, 2))
                {
                    cboPersonalCreditos.SelectedValue = idAsesor;

                    //if (idAsesor == clsVarGlobal.User.idUsuario)
                    //{
                    cboPersonalCreditos.Enabled = false;
                    //}
                    //else
                    //{
                    //    cboPersonalCreditos.Enabled = true;
                    //}
                }
                else if (dtAsesores.AsEnumerable().Any(x => x.Field<int>(0) == clsVarGlobal.User.idUsuario) &&
                        idOperacion != null && idOperacion.In(1,4,5))
                {
                    cboPersonalCreditos.SelectedValue = clsVarGlobal.User.idUsuario;
                }
                else
                {
                    cboPersonalCreditos.Enabled = true;
                }
            }

            var dtCliNuevo = cncredito.CNValidaClienteEsNuevo(idCli);
            if (Convert.ToBoolean(dtCliNuevo.Rows[0][0]))
            {
                cboPersonalCreditos.Enabled = true;
            }
        }

        private void hablitarReprogramacion(bool estado)
                    {
            txtMonto.Enabled = estado;
            cboMoneda1.Enabled = estado;
            if ((int)this.nudCuotas.Value == 1)
                this.nudCuotas.Enabled = false;
            else
            nudCuotas.Enabled = estado;
            conCreditoPeriodo.lTipoPeriodoEnabled = estado;
            conCreditoPeriodo.lPeriodoEnabled = estado;
            dtFechaDesembolso.Enabled = estado;
            cboTipoCredito.Enabled = estado;
            cboSubTipoCredito.Enabled = estado;
            cboProducto.Enabled = estado;
            cboSubProducto.Enabled = estado;
            cboDestinoCredito.Enabled = estado;
            cboFuenteRecurso1.Enabled = estado;
            cboPersonalCreditos.Enabled = !estado;
            nudNroCuoGracia.Enabled = estado;
            txtTasaCompensatoria.Enabled = estado;
            cboTipoTasaCredito.Enabled = estado;
            cboPromotores1.Enabled = !estado;
            if(nidTipoPersona == 1)
                cboDetalleGasto1.Enabled = estado;
            this.lblDesembolso.Text = "Base Reprog";
        }

        private void hablitarAmpliacion(bool estado)
        {
            txtMonto.Enabled = estado;
            cboMoneda1.Enabled = !estado;
            nudCuotas.Enabled = estado;
            conCreditoPeriodo.lTipoPeriodoEnabled = estado;
            conCreditoPeriodo.lPeriodoEnabled = estado;
            dtFechaDesembolso.Enabled = estado;
            cboTipoCredito.Enabled = estado;
            cboSubTipoCredito.Enabled = estado;
            cboProducto.Enabled = estado;
            cboSubProducto.Enabled = estado;
            cboDestinoCredito.Enabled = estado;
            cboPersonalCreditos.Enabled = estado;
            cboPromotores1.Enabled = estado;
            //cboDestinoCredito.Enabled = !estado;
            //txtCodCliente.Enabled = estado;
            txtTasaCompensatoria.Enabled = estado;
        }

        private void mostrarObjetosAmpliacion(bool estado)
        {
            grbCuetas.Visible = estado;
            lblMontoAmplia.Visible = estado;
            txtMontoAmpliacion.Visible = estado;
            txtMonto.ReadOnly = estado;
            if (estado)
            {
                lblBase15.Location = new System.Drawing.Point(351, 332);
                txtObservacion.Size = new System.Drawing.Size(362, 61);
                txtObservacion.Location = new System.Drawing.Point(351, 348);
                txtMonto.ReadOnly = true;
            }
            else
            {
                lblBase15.Location = new System.Drawing.Point(7, 332);
                txtObservacion.Size = new System.Drawing.Size(699, 61);
                txtObservacion.Location = new System.Drawing.Point(7, 348);
            }
        }

        private bool VerificarUsuarioCampana()
        {
            bool lValor = true;
            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIdCargoAsesorQori"));
            List<int> lstCargoPermitidos = objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();
            int idCargoSeleccionado = lstCargoPermitidos.Find(item => item == clsVarGlobal.User.idCargo);
            if (objVarGen == null)
                lValor = false;
            else if(idCargoSeleccionado == 0)
                lValor = false;
            else
                lValor = true;
            return lValor;
        }
        private void CargarDatosCampana(int idCliente)
        {
            lstDatosCampana = cnsolicitud.ObtenerDatosCampana(idCliente);
        }
        private void AsignarDatosCampana(int nIndex = 0)
        {
            if (lstDatosCampana.Count == 0)
                return;

            clsDatosCampana objDatosCampana     = lstDatosCampana[nIndex];

            cboOperacionCre1.SelectedValue      = objDatosCampana.idOperacion;
            txtMonto.Text                       = Convert.ToString(objDatosCampana.nMonto);
            cboMoneda1.SelectedValue            = objDatosCampana.idMoneda;
            nudCuotas.Value                     = objDatosCampana.nPlazo;
            //cboTipoPeriodo.SelectedValue        = objDatosCampana.idTipoPeriodo;
            //nudPlazo.Value                      = clsVarGlobal.dFecSystem.Day;
            nudDiasGracia.Value = 0;
            nudNroCuoGracia.Value = 0;
            dtFechaDesembolso.Value = clsVarGlobal.dFecSystem;

            conCreditoPeriodo.asignarPeriodoCredito(
                objDatosCampana.idTipoPeriodo,
                clsVarGlobal.dFecSystem.Day,
                objDatosCampana.idOperacion,
                (int)nudCuotas.Value
                );
            conCreditoPrimeraCuota.asignarPrimeraCuota(
                conCreditoPeriodo.idTipoPeriodo,
                conCreditoPeriodo.nPeriodoDia,
                (int)nudDiasGracia.Value,
                this.dtFechaDesembolso.Value,
                (int)nudCuotas.Value,
                objDatosCampana.idOperacion);            

            cboPersonalCreditos.SelectedValue   = clsVarGlobal.User.idUsuario;
            cboTipoCredito.SelectedValue        = objDatosCampana.idTipoCredito;
            cboSubTipoCredito.SelectedValue     = objDatosCampana.idSubTipoCredito;
            cboProducto.SelectedValue           = objDatosCampana.idProducto;
            cboSubProducto.SelectedValue        = objDatosCampana.idSubProducto;
            cboDestinoCredito.SelectedValue     = objDatosCampana.idDestino;
            cboFuenteRecurso1.SelectedValue     = objDatosCampana.idRecurso;
            if(cboTipoTasaCredito.Items.Count > 0)
            {
                DataRowView drvTipoTasa = (DataRowView)cboTipoTasaCredito.Items[0];
                DataRow drTipoTasa = drvTipoTasa.Row;
                cboTipoTasaCredito.SelectedValue = Convert.ToInt32(drTipoTasa["idTasa"]);
            }
            conActividadCIIU1.cargarActividadInterna(objDatosCampana.idActividadInterna);
            txtTasaMora.Text                    = (Convert.ToInt32(cboTipoTasaCredito.SelectedValue) != 0) ? Convert.ToString(objDatosCampana.nTasa) : String.Empty ;
        }

        private void CargarComponenteCampana()
        {
            lUsuarioCampana = VerificarUsuarioCampana();
            if(lUsuarioCampana)
            {
                DataTable dtEstablecimientoEOB = cnsolicitud.ObtenerEstablecimientoEOB();
                cboEstablecimiento.DataSource = dtEstablecimientoEOB;
                cboEstablecimiento.DisplayMember = dtEstablecimientoEOB.Columns["cNombreEstab"].ColumnName;
                cboEstablecimiento.ValueMember = dtEstablecimientoEOB.Columns["idEstablecimiento"].ColumnName;
                cboEstablecimiento.SelectedIndex = -1;

                cboPersonalCreditos.ListarPersonalAsesorPrincipal(clsVarGlobal.nIdAgencia);

                DesplazarObjetosEOB(false);
            }
        }
        private bool ValidarCondicionesCampana()
        {
            if (String.IsNullOrEmpty(txtCodCliente.Text))
                return false;

            decimal nMontoPropuesto = Convert.ToDecimal(txtMonto.Text);
            int nNumeroCuotasPropuestas = Convert.ToInt32(nudCuotas.Value);
            List<clsDatosCampana> lstCampanaDisponible = new List<clsDatosCampana>();

            //lstDatosCampana = lstDatosCampana.Where(item => nMontoPropuesto <= item.nMonto && nNumeroCuotasPropuestas <= item.nPlazo ).ToList();
            lstCampanaDisponible = lstDatosCampana.Where(item => nMontoPropuesto <= item.nMonto).ToList();

            return (lstCampanaDisponible.Count > 0) ? true : false;
        }
        private bool validarEstablecimientoCampanaPrincipal()
        {
            bool lValor = true;
            if(VerificarUsuarioCampana() && cboEstablecimiento.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el establecimiento a donde pertenece el credito", "Validación de Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValor = false;
            }
            return lValor;
        }

        private bool validaDetalleGasto()
        {
            if(cboDetalleGasto1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Seguro de Desgravamen", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool validarSeguroConyugal()
        {
            DataTable dtValidacion = (new clsCNEvaluacion()).validarTipoSeguroConyugal(Convert.ToInt32(txtCodCliente.Text.Trim()), Convert.ToDecimal(txtMonto.Text));

            if (dtValidacion.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(dtValidacion.Rows[0]["lValido"]))
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cMensaje"].ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar validar el Tipo de Seguro Desgravamen", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void DesplazarObjetosEOB(bool lValorAmpliacion = false)
        {
            int nDesplazamientoY = 24;
            System.Drawing.Point objUbicacionOriginalLabel = new System.Drawing.Point(358, 10);
            System.Drawing.Point objUbicacionOriginalCombo = new System.Drawing.Point(483, 10);
            System.Drawing.Point objUbicacionLabel = new System.Drawing.Point(358, 44);
            System.Drawing.Point objUbicacionCombo = new System.Drawing.Point(483, 41);
            
            if (lUsuarioCampana && !lDesplazamientoEOB)
            {
                lblEstablecimiento.Location = objUbicacionLabel;
                lblEstablecimiento.Visible  = lUsuarioCampana;
                lblEstablecimiento.Enabled  = lUsuarioCampana;

                cboEstablecimiento.Location = objUbicacionCombo;
                cboEstablecimiento.Visible  = lUsuarioCampana;
                cboEstablecimiento.Enabled  = lUsuarioCampana;

                lblBase10.Top               += nDesplazamientoY;
                cboPersonalCreditos.Top     += nDesplazamientoY;

                lblBase37.Top               += nDesplazamientoY;
                cboPromotores1.Top          += nDesplazamientoY;

                lblBase11.Top               += nDesplazamientoY;
                cboTipoCredito.Top          += nDesplazamientoY;

                lblBase13.Top               += nDesplazamientoY;
                cboSubTipoCredito.Top       += nDesplazamientoY;

                lblBase14.Top               += nDesplazamientoY;
                cboProducto.Top             += nDesplazamientoY;

                lblBase20.Top               += nDesplazamientoY;
                cboSubProducto.Top          += nDesplazamientoY;

                lblBase2.Top                += nDesplazamientoY;
                cboDestinoCredito.Top       += nDesplazamientoY;

                lblBase31.Top               += nDesplazamientoY;
                cboFuenteRecurso1.Top       += nDesplazamientoY;

                lblBase32.Top               += nDesplazamientoY;
                btnAdeudado.Top             += nDesplazamientoY;
                txtIdAdeudado.Top           += nDesplazamientoY;
                txtcDescripcion.Top         += nDesplazamientoY;

                cboTipoTasaCredito.Top      += nDesplazamientoY;
                lblBase3.Top                += nDesplazamientoY;
                txtTasCompensatoriaMin.Top  += nDesplazamientoY;
                lblBase26.Top               += nDesplazamientoY;
                txtTasCompensatoriaMax.Top  += nDesplazamientoY;
                lblBase27.Top               += nDesplazamientoY;

                lblBase12.Top               += nDesplazamientoY;
                txtTasaCompensatoria.Top    += nDesplazamientoY;
                lblBase4.Top                += nDesplazamientoY;
                lblTipoTasaCredito.Top      += nDesplazamientoY;

                lblBase21.Top               += nDesplazamientoY;
                txtTasaMora.Top             += nDesplazamientoY;
                lblBase29.Top               += nDesplazamientoY;

                lblBase15.Top += nDesplazamientoY;
                txtObservacion.Height -= nDesplazamientoY;
                txtObservacion.Top += nDesplazamientoY;

                lDesplazamientoEOB = true;
            }

            grbCuetas.Visible           = lValorAmpliacion;
            lblMontoAmplia.Visible      = lValorAmpliacion;
            txtMontoAmpliacion.Visible  = lValorAmpliacion;
            txtMonto.ReadOnly           = lValorAmpliacion;

            if(lUsuarioCampana && lValorAmpliacion)
            {
                lblBase15.Location      = new System.Drawing.Point(358, 325 + nDesplazamientoY);
                txtObservacion.Size     = new System.Drawing.Size(362, 75 - nDesplazamientoY);
                txtObservacion.Location = new System.Drawing.Point(356, 341 + nDesplazamientoY);
            }
            else if(lUsuarioCampana && !lValorAmpliacion)
            {
                lblBase15.Location          = new System.Drawing.Point(7, 325 + nDesplazamientoY);
                txtObservacion.Size         = new System.Drawing.Size(692, 75 - nDesplazamientoY);
                txtObservacion.Location     = new System.Drawing.Point(7, 341 + nDesplazamientoY);
            }
        }

        private void cargarCuentasVinculadasASolicitud(int idSolicitud)
        {
            clsCNSolicitud nListCreditosAmp = new clsCNSolicitud();
            dtCreditosAmp = nListCreditosAmp.CNRetCuentasAmpliadas(idSolicitud);//Aplica para ampliación y refinanciación

            dtgCuentaCreditoVinculado.DataSource = dtCreditosAmp;
            dtgCuentaCreditoVinculado.Columns["idSolicitud"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["lPermQuitar"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaCompensatoria"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["nTasaMoratoria"].Visible = false;
            //dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Visible = false;
            dtgCuentaCreditoVinculado.Columns["idCuenta"].HeaderText = "CUENTA";
            dtgCuentaCreditoVinculado.Columns["nTotal"].HeaderText = "SALDO CREDITO";
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].HeaderText = "SALDO CAPITAL";
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].HeaderText = "SALDO INTERES";
            dtgCuentaCreditoVinculado.Columns["nSalMora"].HeaderText = "SALDO MORA";
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].HeaderText = "SALDO OTROS";
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].HeaderText = "SALDO INT. COMPENSATORIO";
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].HeaderText = "DESEMBOLSO";
            dtgCuentaCreditoVinculado.Columns["nSaldoDeudor"].HeaderText = "SALDO DEUDOR";

            dtgCuentaCreditoVinculado.Columns["idCuenta"].Width = 80;
            dtgCuentaCreditoVinculado.Columns["nTotal"].Width = 108;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].Width = 180;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nSaldoDeudor"].Width = 110;

            dtgCuentaCreditoVinculado.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCuentaCreditoVinculado.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSaldoDeudor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
            dtgCuentaCreditoVinculado.ClearSelection();

        }

        private void agregarCreditos(int idCuentaCre)
        {
            CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
            clsCredito entCredito = credito.retornaDatosCredito(idCuentaCre);

            if (dtCreditosAmp.AsEnumerable().Any(x => x.Field<int>("idCuenta") == entCredito.idCuenta))
                return;

            if (entCredito.IdMoneda != Convert.ToInt32(cboMoneda1.SelectedValue))
            {
                MessageBox.Show("Debe seleccionar creditos del mismo tipo de moneda", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int? idOperacion = (int?) cboOperacionCre1.SelectedValue;
            if(idOperacion.In(2,6) && entCredito.nInteresDia - entCredito.nInteresPagado<0)
            {
                MessageBox.Show("No se puede refinanciar un crédito con intereses pagados por adelantado.", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow drCredito = dtCreditosAmp.NewRow();
            drCredito["idSolicitud"] = "0";
            drCredito["idCuenta"] = entCredito.idCuenta;
            drCredito["nTotal"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado) +
                                    (entCredito.nInteresDia - entCredito.nInteresPagado) +
                                    (entCredito.nMoraGenerado - entCredito.nMoraPagada) +
                                    (entCredito.nOtrosGenerado - entCredito.nOtrosPagado) +
                                    (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["nSalCapital"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado);
            drCredito["nSalInteres"] = (entCredito.nInteresDia - entCredito.nInteresPagado);
            drCredito["nSalMora"] = (entCredito.nMoraGenerado - entCredito.nMoraPagada);
            drCredito["nSalOtros"] = (entCredito.nOtrosGenerado - entCredito.nOtrosPagado);
            drCredito["nSalIntComp"] = (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["lPermQuitar"] = 1;
            drCredito["nTasaCompensatoria"] = entCredito.nTasaCompensatoria;
            drCredito["nTasaMoratoria"] = entCredito.nTasaMoratoria;
            drCredito["nCapitalDesembolso"] = entCredito.nCapitalDesembolso;
            drCredito["nSaldoDeudor"] = (entCredito.nCapitalDesembolso + entCredito.nInteresPactado) - (entCredito.nCapitalPagado + entCredito.nInteresPagado);

            dtCreditosAmp.Rows.Add(drCredito);

            txtSalTotalCre.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
            txtMonto.Text = txtSalTotalCre.Text;

            if (this.objOferta != null)
            { 
                decimal nMontoCredAnte = txtSalTotalCre.nDecValor;
                txtMontoAmpliacion.Text = ((this.objOferta.nMontoOferta >= nMontoCredAnte) ? this.objOferta.nMontoOferta - nMontoCredAnte : 0).ToString();
            }
        }

        private void clasificarCredito()
        {
            DataTable dtClasCred = cnsolicitud.CNClasificarCredito(txtNroDocIde.Text.Trim());
            if (Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]) == Convert.ToInt16(cboTipoCredito.SelectedValue))
            {
                indClasif = false;
                return;
            }

            DataTable dtFamCred = cnsolicitud.CNBusFamCred(Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]), Convert.ToInt16(cboSubProducto.SelectedValue));
            if (dtFamCred.Rows.Count < 5)
            {
                //MessageBox.Show("No se pudo reclasificar el crédito", "Reclasificación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                indClasif = false;
                return;
            }

            this.CargarProductos(Convert.ToInt16(dtFamCred.Rows[1]["idProducto"])
                                , Convert.ToInt16(dtFamCred.Rows[2]["idProducto"])
                                , Convert.ToInt16(dtFamCred.Rows[3]["idProducto"])
                                , Convert.ToInt16(dtFamCred.Rows[4]["idProducto"]));
            MessageBox.Show("Su crédito fue reclasificado", "Reclasificación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            indClasif = true;

            /* - Cargado tasa Repro -- */
            if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 3)
            {
                TasaReprogramacion(idTasaRepro);
                txtTasaCompensatoria.Text = nTasaRepro.ToString("#,0.0000");
                txtTasaMora.Text = nTasaMoraRepro.ToString("#,0.0000");
            }
            
            /* - Cargado tasa Repro -- */
        }

        private int obtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }

        private clsCreditoProp retornaCreditoProp()
        {
            return new clsCreditoProp()
            {
                idOrigenCredProp = 1,
                idSolicitud = 0,
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = Convert.ToDecimal(txtMonto.Text),
                nCuotas = Convert.ToInt32(nudCuotas.Value),
                idTipoPeriodo = this.conCreditoPeriodo.idTipoPeriodo,
                nPlazoCuota = this.conCreditoPeriodo.nPeriodoDia,
                nDiasGracia = Convert.ToInt32(nudDiasGracia.Value),
                idTasa = idTasa,
                dFechaDesembolso = dtFechaDesembolso.Value.Date,
                nTasaCompensatoria = Convert.ToDecimal(txtTasaCompensatoria.Text),
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = txtObservacion.Text.Trim(),
                nCuotasGracia = Convert.ToInt32(nudNroCuoGracia.Value)
            };
        }

        private bool PermitirActualizarPorExcepcion(int idSolicitud)
        {
            bool lFlagExcepciones = true;
            DataTable dtParametros = ArmarTablaParametros();

            DataTable dtResultadoReglas = cnregladinamica.ObtenerReglasConResultado(dtParametros, this.Name);
            var reglasExcepcionables = dtResultadoReglas.AsEnumerable().Where(x => !(x.Field<string>("lResul").Equals("NA"))
                                                                           && x.Field<string>("lResul").Equals("NO")
                                                                           && x.Field<int>("lIndExcepcion") == 1
                                                                           && !x.Field<bool>("lAlertaRiesgo"));

            var reglasNoExcepcionables = dtResultadoReglas.AsEnumerable().Where(x => !(x.Field<string>("lResul").Equals("NA"))
                                                                           && x.Field<string>("lResul").Equals("NO")
                                                                           && x.Field<int>("lIndExcepcion") == 0
                                                                           && !x.Field<bool>("lAlertaRiesgo"));

            if (reglasNoExcepcionables.Any())
            {
                return false;
            }

            if (reglasExcepcionables.Any())
            {
                dtResultadoReglas = reglasExcepcionables.CopyToDataTable();
                foreach (DataRow row in dtResultadoReglas.Rows)
                {
                    DataTable dtSolAproba =
                        cnregladinamica.ConsultaSolicitudesAprobadas(Convert.ToInt32(row["idTipoOperacion"]),
                            idSolicitud);
                    if (dtSolAproba.Rows.Count == 0)
                    {
                        lFlagExcepciones = false;
                        break;
                    }
                }
            }
            else
            {
                lFlagExcepciones = false;
            }
            return lFlagExcepciones;
        }

        //private bool PermitirActualizarPorExcepcionCred(int idSolicitud)
        //{
        //    bool lFlagExcepciones = true;
        //    DataTable dtParametros = ArmarTablaParametros();

        //    DataTable dtResultadoReglas = cnregladinamica.ObtenerReglasConResultado(dtParametros, this.Name);
        //    var reglasExcepcionables = dtResultadoReglas.AsEnumerable().Where(x => !(x.Field<string>("lResul").Equals("NA"))
        //                                                                   && x.Field<string>("lResul").Equals("NO")
        //                                                                   && x.Field<int>("lIndExcepcion") == 1
        //                                                                   && !x.Field<bool>("lAlertaRiesgo"));

        //    var reglasNoExcepcionables = dtResultadoReglas.AsEnumerable().Where(x => !(x.Field<string>("lResul").Equals("NA"))
        //                                                                   && x.Field<string>("lResul").Equals("NO")
        //                                                                   && x.Field<int>("lIndExcepcion") == 0
        //                                                                   && !x.Field<bool>("lAlertaRiesgo"));

        //    if (reglasNoExcepcionables.Any())
        //    {
        //        return false;
        //    }

        //    if (reglasExcepcionables.Any())
        //    {
        //        dtResultadoReglas = reglasExcepcionables.CopyToDataTable();
        //        foreach (DataRow row in dtResultadoReglas.Rows)
        //        {
        //            DataTable dtSolAproba =
        //                //cnregladinamica.ConsultaSolicitudesAprobadas(Convert.ToInt32(row["idTipoOperacion"]),
        //                cnregladinamica.ConsultaSolicitudesAprobadasCred(Convert.ToInt32(row["idTipoOperacion"]),
        //                    idSolicitud);
        //            if (dtSolAproba.Rows.Count == 0)
        //            {
        //                lFlagExcepciones = false;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lFlagExcepciones = false;
        //    }
        //    return lFlagExcepciones;
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                btnBusCliente.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CalcularDiasGracia()
        {
            if (conCreditoPeriodo.nPeriodoDia > 0)
            {
                if (this.conCreditoPeriodo.idTipoPeriodo == 1)
                {
                    int nDiaFecAux = conCreditoPeriodo.nPeriodoDia;
                    DateTime dFecResult;
                    DateTime dFechaProxMes = dtFechaDesembolso.Value.AddMonths(1);
                    while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                    {
                        if (DateTime.TryParse(String.Format("{0}/{1}/{2}", nDiaFecAux, dFechaProxMes.Month, dFechaProxMes.Year), out dFecResult))
                        {
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1; // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                    }

                    var nDiasAuxGracia = (dFecResult.Date - dtFechaDesembolso.Value.AddMonths(1).Date).Days;
                    nudDiasGracia.Value = nDiasAuxGracia >= 0 ? nDiasAuxGracia : 0;
                }
            }
        }
        private bool validacionCreditoJornalero()
        {
            /** CREDITO JORNALERO **/
            if (frmCreJorScoreCliente.esProductoJornalero(Convert.ToInt32(cboSubProducto.SelectedValue)))
            {
                var frmscorejor = new frmCreJorScoreCliente(Convert.ToInt32(txtCodCliente.Text),
                                                            ref this.txtMonto,
                                                            Convert.ToInt32(this.cboDestinoCredito.SelectedValue),
                                                            Convert.ToInt32(this.nudCuotas.Value),
                                                            Convert.ToInt32(this.txtCodigoSol.Text != null && this.txtCodigoSol.Text != "" ? this.txtCodigoSol.Text : "-1"));
                frmscorejor.ShowDialog();
                frmscorejor.guardarScoreJornalero(false);
                if (!frmscorejor.validar()) { return false; };
            }
            return true;
            /** END CREDITO JORNALERO **/
        }

        private void grabar()
        {
            //TODO: SolTechnologies - 6.Validaciones del Porspecto Nuevo No Bancarizado

            //Obtiene parámetros para intentos rechazados
            clsVarGen valIntentosDia = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIntentosDia"));
            int nIntentosDia = Convert.ToInt32(valIntentosDia.cValVar);
            clsVarGen valIntentosMes = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIntentosMes"));
            int nIntentosMes = Convert.ToInt32(valIntentosMes.cValVar);

            int idCli = (txtCodCliente.Text != "") ? Convert.ToInt32(txtCodCliente.Text) : -1;
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
                if (Convert.ToDecimal(txtMonto.Text) > montoParametrisableMax)
                {
                    MessageBox.Show("El monto excede los S/." + montoParametrisableMax + " permitidos por el Motor de Decisiones del Modelo no bancarizado, la solicitud continuará por su flujo normal.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lvalidaProspectoMNB = false;
                }
            }

            //continuaFlujoNormal

            this.nAlmacenarTasaCredito = Convert.ToInt32(cboTipoTasaCredito.SelectedValue);
            
            btnExcepciones.Enabled = true;
            DialogResult result = DialogResult.None;
            if (!validaActualizacion())
            {
                return;
            }

            if (!ValidaTipoPeriodoRural())
            {
                return;
            }

            if (!ValidaCuotasLibres())
            {
                return;
            }

            if (!ValidaProgramaImpulsoMyPeru())
            {
                return;
            }
            validarVigenciaPlanesDeSeguro();
            
            if (cboTipoCredito.SelectedIndex != -1 && cboSubProducto.SelectedIndex != -1 && Convert.ToInt32(cboTipoCredito.SelectedValue).In(2, 10, 11, 12, 13))
            {
                clasificarCredito();
            }
            if (indClasif)
            {
                result = MessageBox.Show("¿Desea Continuar?", "Reclasificación de Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.None || result == DialogResult.Yes)
            {
                if (nEstado == 0)
                {
                    if (validarProductoSeguro())
                    {

                        ValidarSeguros();

                        objSolicitudCreditoCargaSeguro.idSolicitud          = (String.IsNullOrEmpty(txtCodigoSol.Text)) ? 0 : Convert.ToInt32(txtCodigoSol.Text);
                        objSolicitudCreditoCargaSeguro.idProducto           = Convert.ToInt32(cboSubProducto.SelectedValue);
                        objSolicitudCreditoCargaSeguro.nMontoSolicitado     = (!String.IsNullOrEmpty(txtMonto.Text)) ? Convert.ToDecimal(txtMonto.Text) : 0;                                              
                        objSolicitudCreditoCargaSeguro.nCuotas              = Convert.ToInt32(nudCuotas.Value);
                        objSolicitudCreditoCargaSeguro.idTipoPlazo          = this.conCreditoPeriodo.idTipoPeriodo;
                        objSolicitudCreditoCargaSeguro.nPlazo               = this.conCreditoPeriodo.nPeriodoDia;
                        objSolicitudCreditoCargaSeguro.idMoneda             = Convert.ToInt32(cboMoneda1.SelectedValue);
                        objSolicitudCreditoCargaSeguro.cMoneda              = cboMoneda1.Text;
                        objSolicitudCreditoCargaSeguro.dFechaDesembolso     = dtFechaDesembolso.Value;
                        objSolicitudCreditoCargaSeguro.dFechaCancelacion    = clsVarGlobal.dFecSystem;
                        objSolicitudCreditoCargaSeguro.nDiasGracia          = Convert.ToInt32(nudDiasGracia.Value);
                        objSolicitudCreditoCargaSeguro.nCuotaGracia         = Convert.ToInt32(nudNroCuoGracia.Value);
                        objSolicitudCreditoCargaSeguro.idOperacion          = Convert.ToInt32(cboOperacionCre1.SelectedValue);
                        objSolicitudCreditoCargaSeguro.idCli                = (String.IsNullOrEmpty(txtCodCliente.Text)) ? 0 : Convert.ToInt32(txtCodCliente.Text);
                        objSolicitudCreditoCargaSeguro.dFechaPrimeraCuota   = conCreditoPrimeraCuota.dFecha;
                        objSolicitudCreditoCargaSeguro.idDetalleGasto       = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
                        objSolicitudCreditoCargaSeguro.idPaqueteSeguro      = Convert.ToInt32(cboPaqueteSeguro1.SelectedValue);
                        objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro = objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.lSeleccionado) || objSolicitudCreditoCargaSeguro.idPaqueteSeguro > 0;
                        objSolicitudCreditoCargaSeguro.lEsRegistro          = true;
                        objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro   = objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro == 0 ? 1 : objSolicitudCreditoCargaSeguro.idFrmPaqueteSeguro;//Registrado en solicitud
                        objSolicitudCreditoCargaSeguro.lPlanSeguroBD        = objSolicitudCreditoCargaSeguro.idPaqueteSeguro > 0 ? true : false;
                     
                        frmSolicitudCreditoCargaSeguro frmCreditoCargaSeguro = new frmSolicitudCreditoCargaSeguro(objSolicitudCreditoCargaSeguro);
                        frmCreditoCargaSeguro.ShowDialog();
                        objSolicitudCreditoCargaSeguro = frmCreditoCargaSeguro.objSolicitudCreditoCargaSeguro;
                        objSolicitudCreditoCargaSeguro.lEsRegistro = false;
                        CargarPaqueteSeguro(objSolicitudCreditoCargaSeguro.idPaqueteSeguro,true);

                        if((objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro) || (objSolicitudCreditoCargaSeguro.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0 && !item.lSeleccionado) ))
                        {
                            decimal nMontoActual = (!String.IsNullOrEmpty(txtMonto.Text)) ? Convert.ToDecimal(txtMonto.Text) : 0;
                            if(objSolicitudCreditoCargaSeguro.lAceptacionListaSeguro)
                            {
                                txtMonto.TextChanged -= new EventHandler(txtMonto_TextChanged);
                                txtMonto.Text = Convert.ToString(objSolicitudCreditoCargaSeguro.nMontoSolicitado);
                                txtMonto.TextChanged += new EventHandler(txtMonto_TextChanged);
                            }
                            else
                            {
                                txtMonto.Text = Convert.ToString(objSolicitudCreditoCargaSeguro.nMontoCoberturaSeguro);
                            }
                            


                            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaTipoReprogramacion"));

                            List<int> lstReprogramacion = objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList(); ;

                            if (!lstReprogramacion.Any(item => item == objSolicitudCreditoCargaSeguro.idOperacion))
                            {
                                asignarTasa();
                                cboTipoTasaCredito.SelectedValue = this.nAlmacenarTasaCredito;
                            }

                            if (nMontoActual != objSolicitudCreditoCargaSeguro.nMontoSolicitado)
                            {
                                MessageBox.Show("Verifique las condiciones del crédito, estos cambiaron debido a la inclusión de los seguros. Luego debe Grabar nuevamente los cambios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }
                    if (!this.validacionCreditoJornalero())
                    {
                        return;
                    }

                    //valida para realizar la reclasificacion
                    if (!validaActualizacion())
                    {
                        return;
                    }

                    if (!validarRefiNovacion())
                    {
                        return;
                    }

                    if (!validaProductoAgricola())
                    {
                        return;
                    }

                    if (!validaTasaCampana())
                    { 
                        return; 
                    }
                    if (!validarMontoCampana())
                    {
                        return;
                    }
                    if (!validarEstablecimientoCampanaPrincipal())
                    {
                        return;
                    }
                    if (Convert.ToInt32(cboOperacionCre1.SelectedValue) != 3 && nidTipoPersona == 1)
                    {
                        if (!validaDetalleGasto())
                        {
                            return;
                        }

                        if (Convert.ToInt32(cboDetalleGasto1.SelectedValue) == 2)
                        {
                            if (!validarSeguroConyugal())
                            {
                                return;
                            }
                        }
                    }
                    
                    //if (!validaDestinos())
                    //{
                    //    return;                    
                    //}
                    lOpinionRiesgos = false;
                    if (verficarOpinionRiesgosReprogarmacion())
                    {
                        DialogResult dlres = MessageBox.Show("¿Está de acuerdo con el registro de la Solicitud de Opinión de Riesgo?", "Opinión Riesgos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlres == DialogResult.No)
                        {
                            lOpinionRiesgos = false;
                            return;
                        }
                        else {
                            lOpinionRiesgos = true;
                        }                  
                    }
                    insertarSolicitud();
                    if (lPerteneceOtraAgencia)
                    {
                        btnCancelar1.PerformClick();
                        return;
                    }

                    buscarSolicitudCliente(Convert.ToInt32(txtCodCliente.Text));                    

                    if ((int)cboOperacionCre1.SelectedValue == 2)
                    {
                        txtMonto.Enabled = false;
                    }
                    this.btn_Vincular2.Enabled = true;
                    if ((int)cboEstadoCredito1.SelectedValue == 0 || (int)cboEstadoCredito1.SelectedValue == 11)
                    {
                        grbDato_Solicitud.Enabled = true;
                        cboModalidadCredito.Enabled = true;
                        cboModDesemb1.Enabled = true;
                        btnGrabar1.Enabled = true;
                        btnGrabar1.Visible = true;
                        btnEditar.Enabled = false;
                        btnEditar.Visible = false;
                    }
                    else
                    {
                        grbDato_Solicitud.Enabled = false;
                        cboModalidadCredito.Enabled = false;
                        cboModDesemb1.Enabled = false;
                        lEditar = false;

                        btnGrabar1.Enabled = false;
                        btnGrabar1.Visible = false;
                        
                        btnEditar.Enabled = (Convert.ToInt32(cboEstadoCredito1.SelectedValue) == 1) ? true: false;
                        btnEditar.Visible = (Convert.ToInt32(cboEstadoCredito1.SelectedValue) == 1) ? true: false;
                    }
                    frmEvaluaSobreendeuda evaluaSobreendeuda = new frmEvaluaSobreendeuda(Convert.ToInt32(txtCodCliente.Text));
                    evaluaSobreendeuda.evaluarSobreendeuda();
                    //evaluaSobreendeuda.ShowDialog();
                    if (VerificarUsuarioCampana() && !ValidarCondicionesCampana() && !String.IsNullOrEmpty(txtCodCliente.Text))
                    {
                        MessageBox.Show("El monto propuesto no cumple con las condiciones de la campaña. El crédito se deberá enviar a Evaluación", "Condiciones de Campaña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //TODO: SolTechnologies - 8.Iniciación del piloto con el modelo no bancarizado pyme-consumo 
                    int idSol = (txtCodigoSol.Text != "") ? Convert.ToInt32(txtCodigoSol.Text) : -1;
                    if (lvalidaProspectoMNB)
                    {
                        //Actualiza el monto y plazo que ingresa al Motor de decisiones 
                        decimal monto = Convert.ToDecimal(txtMonto.Text);
                        int nuevoPlazoCuota = conCreditoPeriodo.nPeriodoDia;
                        int nuevoCuotas = Convert.ToInt32(nudCuotas.Value);
                        int nuevoIdPeriodo = conCreditoPeriodo.idTipoPeriodo;
                        int nuevoPlazo = (nuevoIdPeriodo == 1) ? 30 * nuevoCuotas : nuevoPlazoCuota * nuevoCuotas;

                        // Parametros del Motor de decisiones:
                        var respuestaMNB = new clsMotorDecision().CallMotorDecisionSolicitud(idSol, monto, nuevoPlazo, true, this.Name);

                        if (!respuestaMNB)
                        {
                            MessageBox.Show("No se ha podido establecer conexión con el Motor de decisiones.\n" +
                            "Si continua al proceso de evaluacion, el prospecto no sera parte del Modelo No Bancarizado.\n" +
                            "Si desea esperar al Motor de decisiones, comuniquese con un administrador", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            DialogResult dlres = MessageBox.Show("¿Desea continuar sin el Modelo No Bancarizado?", "Motor de decisiones", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dlres == DialogResult.No) {
                                this.Close();
                                this.Dispose();
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                btnGrabar1.Enabled = false;
                btnExcepciones.Enabled = false;
                btnEditar.Enabled = false;
                btnEditar.Visible = false;
            }
        }

        //TODO: SolTechnologies - 7.Determina si el prospecto pertenece al MNB
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

            //Producto
            int productoMNB = Convert.ToInt32(cboSubProducto.SelectedValue);
            var dtProductosMNB = new clsCNMotorDecision().ProductosMNB(productoMNB);
            bool validaProducto = false;
            foreach (DataRow dr in dtProductosMNB.Rows)
            {
                if (Convert.ToInt32(dr["idTipEvalCred"]) == 7 || Convert.ToInt32(dr["idTipEvalCred"]) == 1)
                {
                    validaProducto = true;
                    break;
                }
            }

            if (idClasificacionInternaCli == 9 && validaAgencia == true && validaProducto == true)
                validaProspectoMNB = true;

            return validaProspectoMNB;
        }

        private bool validaProductoAgricola()
        {
            if (estaEnDatos(clsVarApl.dicVarGen["cProductosAgricola"], Convert.ToInt32(cboSubProducto.SelectedValue)))
            {
                if (nudDiasGracia.Value > 120)
                {
                    MessageBox.Show("El número de dias de gracia no puede superar 120 días para el producto agricola", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private bool validaTasaCampana() 
        {
            bool lRes = true;

            if (nTasaCampana == 0)
            {
                return lRes;
            }
            else if (nTasaCampana > Convert.ToDecimal(txtTasaCompensatoria.Text))
            {    
                MessageBox.Show("El TEA no puede ser menor a su tasa pre aprobada que es: "+ nTasaCampana, "Validación de Tasa Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
	        {
                return lRes;
	        }

        }
        private bool validarSolicitudEAI(int idSolicitud)
        {
            DataTable dtValidarSolicitudEAI = cnsolicitud.CNValidarSolicitudEAI(idSolicitud);
            if (dtValidarSolicitudEAI.Rows.Count > 0)
            {
                int idMsg = Convert.ToInt32(dtValidarSolicitudEAI.Rows[0]["idMsg"]);
                if (idMsg == 1)
                {
                    MessageBox.Show(Convert.ToString(dtValidarSolicitudEAI.Rows[0]["cMsg"]), "Validación de producto Efectivo al Instante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEnviar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarSolicitudAct()
        {
            int nCodigoSol;
            int idSubProducto = Convert.ToInt32(cboSubProducto.SelectedValue);

            if (String.IsNullOrEmpty(txtCodigoSol.Text))
            {
                nCodigoSol = 0;
            }
            else
            {
                nCodigoSol = Convert.ToInt32(txtCodigoSol.Text);
            }

            DataTable dtValidarSolicitudAct = cnsolicitud.CNValidarSolicitudAct(Convert.ToInt32(txtCodCliente.Text), nCodigoSol, idSubProducto);
            if (dtValidarSolicitudAct.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarSolicitudAct.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show("Cliente tiene una solicitud registrada en el formulario “Clientes con campaña” o aprobado.", "Validación de número de solicitudes activas.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar1.Enabled = true;
                    btnEnviar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarBloqueoEAI()
        {
            DataTable dtValidarBloqueoEAI = cnsolicitud.CNValidarBloqueoEAI(Convert.ToInt32(txtCodCliente.Text), Convert.ToInt32(cboSubProducto.SelectedValue.ToString()));
            if (dtValidarBloqueoEAI.Rows.Count > 0)
            {
                int nMsg = Convert.ToInt32(dtValidarBloqueoEAI.Rows[0]["nMsg"]);
                if (nMsg > 0)
                {
                    MessageBox.Show(Convert.ToString(dtValidarBloqueoEAI.Rows[0]["cMsg"]), "Validación de bloqueo para Efectivo al Instante.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //btnAprobar.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnEnviar.Enabled = false;
                    return true;
                }
                return false;
            }
            return false;
        }
        private bool validarSubProductoEAI()
        {
            if (Convert.ToString(cboSubProducto.Text) == "EFECTIVO AL INSTANTE" && Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
            {
                CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
                clsCredito entCredito = new clsCredito();
                DataTable dtCredAmpliar = new DataTable();
                dtCredAmpliar = (DataTable)dtgCuentaCreditoVinculado.DataSource;

                int idCli = Convert.ToInt32(txtCodCliente.Text);
                clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                if (dtCredAmpliar.Rows.Count > 0)
                {
                    foreach (DataRow Cred in dtCredAmpliar.Rows)
                    {
                        entCredito = credito.retornaDatosCredito(Convert.ToInt32(Cred["idCuenta"].ToString()));

                        var idSubProducto = (from cred in dtDatosCuentaSolCliente.AsEnumerable()
                                             where cred.Field<int>("idCuenta") == entCredito.idCuenta
                                             select cred.Field<int>("idProducto")).FirstOrDefault();

                        if (idSubProducto != Convert.ToInt32(cboSubProducto.SelectedValue))
                        {
                            MessageBox.Show("El Sub Producto del Crédito a ampliar es diferente de Efectivo al Instante.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return true;
                        }
                    }
                }
                return false;
            }
            else if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4)
            {
                CRE.CapaNegocio.clsCNCredito credito = new CapaNegocio.clsCNCredito();
                clsCredito entCredito = new clsCredito();
                DataTable dtCredAmpliar = new DataTable();
                DataTable dtSubProducto = new DataTable();
                dtCredAmpliar = (DataTable)dtgCuentaCreditoVinculado.DataSource;
                string cSubProducto;

                int idCli = Convert.ToInt32(txtCodCliente.Text);
                clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                if (dtCredAmpliar.Rows.Count > 0)
                {
                    foreach (DataRow Cred in dtCredAmpliar.Rows)
                    {
                        entCredito = credito.retornaDatosCredito(Convert.ToInt32(Cred["idCuenta"].ToString()));

                        var idSubProducto = (from cred in dtDatosCuentaSolCliente.AsEnumerable()
                                             where cred.Field<int>("idCuenta") == entCredito.idCuenta
                                             select cred.Field<int>("idProducto")).FirstOrDefault();

                        dtSubProducto = RetornaCuentaSolCliente.CNObtenerSubProducto(Convert.ToInt32(idSubProducto));
                        cSubProducto = Convert.ToString(dtSubProducto.Rows[0]["cProducto"]);

                        if (cSubProducto == "EFECTIVO AL INSTANTE" && cSubProducto != Convert.ToString(cboSubProducto.Text))
                        {
                            MessageBox.Show("El Sub Producto del crédito ampliado es diferente de Efectivo al Instante.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }
        private bool validarMontoCampana()
        {
            int idCliente = Convert.ToInt32(txtCodCliente.Text);
            int idProducto = Convert.ToInt32(cboSubProducto.SelectedValue);
            int idOperacion = Convert.ToInt32(cboOperacionCre1.SelectedValue);

            DataTable dtValidacionMontoCampana = cnsolicitud.CNValidarMontoCampanaCliente(idCliente, idProducto, idOperacion);

            if(dtValidacionMontoCampana.Rows.Count > 0)
            {
                decimal nMontoMaximoPermitido = Convert.ToDecimal(dtValidacionMontoCampana.Rows[0]["nMontoMaximoPermitido"]);
                decimal nMontoSolicitud = Convert.ToDecimal(txtMonto.Text);
                string cTipoGrupoCamp = Convert.ToString(dtValidacionMontoCampana.Rows[0]["cTipoGrupoCamp"]);
                string cProducto = Convert.ToString(cboSubProducto.Text);
                string cNombreCampana = Convert.ToString(dtValidacionMontoCampana.Rows[0]["cGrupoCamp"]);
                string cOperacion = Convert.ToString(cboOperacionCre1.Text);
                bool lPreAprobado = Convert.ToBoolean(dtValidacionMontoCampana.Rows[0]["lPreAprobado"]);
                bool lCampanaPropuesta = Convert.ToBoolean(dtValidacionMontoCampana.Rows[0]["lCampanaPropuesta"]);
                string cMensaje = String.Empty;

                if (!lPreAprobado && lCampanaPropuesta)
                {
                    cMensaje = "El Cliente no corresponde a la campaña seleccionada";
                    MessageBox.Show(cMensaje, "Validación de Monto de Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (nMontoSolicitud > nMontoMaximoPermitido && lPreAprobado && lCampanaPropuesta)
                {
                    cMensaje = "El monto solicitado debe ser atendido con el producto regular.";
                    MessageBox.Show(cMensaje, "Validación de Monto de Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if(lPreAprobado && !lCampanaPropuesta)
                {
                    cMensaje = "El cliente no tiene una oferta para el producto seleccionado.";
                    MessageBox.Show(cMensaje, "Validación de Monto de Campaña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        //private bool validaDestinos()
        //{

        //    if (Convert.ToInt32(cboDestinoCredito.SelectedValue) == 1 &&  )
        //    {
        //        MessageBox.Show("El número de dias de gracia no puede superar 120 días para el producto agricola", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return false;
        //    }
        //    return true;
        //}

        #region Cliente Recurrente

        private void initClienteRecurrente(int idTipoCliente)
        {
            int nTipCli = 0;
            clsTipoCliente obj = new clsTipoCliente(Convert.ToInt32(txtCodCliente.Text), idTipoCliente);
            nTipCli = obj.initClienteRecurrente();
            this.setTipoCliente(nTipCli, (nTipCli==2)? "Recurrente": "Nuevo");
        }

        private void setTipoCliente(int idTipoCliente, string cTipoCliente)
        {
            nTipoCliente = idTipoCliente;
            this.lblCliente.Text = cTipoCliente;
        }

        #endregion

        private void ObtenerDestinoRefinNovado()
        {
            if (dtgCuentaCreditoVinculado.Rows.Count > 0)
            {
                int idCuentaMayor = 0;
                decimal nSaldo = -1;
                decimal nSaldoDeudor = -1;
                foreach (DataGridViewRow item in dtgCuentaCreditoVinculado.Rows)
                {
                    if (Convert.ToDecimal(item.Cells[3].Value) > nSaldo)
                    {
                        idCuentaMayor = Convert.ToInt32(item.Cells[1].Value);
                        nSaldo = Convert.ToDecimal(item.Cells[3].Value);
                    }
                }

                if (dtgCuentaCreditoSaldoMayorIgual(nSaldo))
                {
                    foreach (DataGridViewRow item in dtgCuentaCreditoVinculado.Rows)
                    {
                        if ((Convert.ToDecimal(item.Cells[3].Value) == nSaldo) && (Convert.ToDecimal(item.Cells[12].Value) > nSaldoDeudor))
                        {
                            idCuentaMayor = Convert.ToInt32(item.Cells[1].Value);
                            nSaldoDeudor = Convert.ToDecimal(item.Cells[12].Value);
                        }
                    }
                }
                DataTable dtDestino;
                clsCNSolicitud nDestino = new clsCNSolicitud();
                dtDestino = nDestino.CNObtenerDestinoOpeRefNov(idCuentaMayor);
                cboDestinoCredito.SelectedValue = Convert.ToInt32(dtDestino.Rows[0]["idDestino"]);

                if (this.objOferta != null)
                {
                    DataTable dtVerificacion;
                    dtVerificacion = nDestino.CNVerificaCampImpulsoMyperu(this.objOferta.idGrupoCamp);
                    Boolean lValor = Convert.ToBoolean(dtVerificacion.Rows[0]["lValor"]);
                    
                    if (lValor && (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4))
                    {
                        DataTable dtProducto;
                        dtProducto = nDestino.CNObtenerProdCampImpulMyperu(idCuentaMayor);

                        if (Convert.ToInt32(dtProducto.Rows[0]["idSubProductoCredito"]) == 0)
                        {
                            MessageBox.Show("El PROGRAMA IMPULSO MYPERU no permite la Ampliación de Créditos de tipo CONSUMO, debe quitar la cuenta de la lista de Créditos Vigentes.", "Validación de PROGRAMA IMPULSO MYPERU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
            }
            else
            {
                            cboTipoCredito.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["idTipoCredito"]);
                            cboSubTipoCredito.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["idSubTipoCredito"]);
                            cboProducto.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["idProductoCredito"]);
                            cboSubProducto.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["idSubProductoCredito"]);

                            cboTipoCredito.Enabled = false;
                            cboSubTipoCredito.Enabled = false;
                            cboProducto.Enabled = false;
                            cboSubProducto.Enabled = false;
                            cboDestinoCredito.Enabled = false;

                            cboDestinoCredito.SelectedValue = Convert.ToInt32(dtProducto.Rows[0]["idDestino"]);
                            asignarTasa();

                        }

                    }
                }
            }
            else
            {
                cboDestinoCredito.SelectedIndex = -1;
            }
        }

        private Boolean dtgCuentaCreditoSaldoMayorIgual(decimal nSaldo)
        {
            Boolean Valor = false;
            int Contador = 0;
            foreach (DataGridViewRow item in dtgCuentaCreditoVinculado.Rows)            // Busca si hay iguales
            {
                if (Convert.ToDecimal(item.Cells[3].Value) == nSaldo)
                    Contador++;

                if (Contador == 2)
                    Valor = true;
            }
            return Valor;
        }

        private bool ValidaProgramaImpulsoMyPeru()
        {
            if (this.objOferta != null)
            {
                clsCNSolicitud lValorProgImpuloMyPeru = new clsCNSolicitud();
                DataTable dtVerificacion;
                dtVerificacion = lValorProgImpuloMyPeru.CNVerificaCampImpulsoMyperu(this.objOferta.idGrupoCamp);
                Boolean lValor = Convert.ToBoolean(dtVerificacion.Rows[0]["lValor"]);
                          
                if (lValor && (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 4))
                {
                    if (Convert.ToDecimal(txtMontoAmpliacion.Text) != 0)
                    {
                        MessageBox.Show("El PROGRAMA IMPULSO MYPERU solo permite que el Monto de Ampliación sea 0.", "Validación de PROGRAMA IMPULSO MYPERU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    DataTable dtValidaImpulsoMyPeru;
                    clsCNSolicitud cValidacion = new clsCNSolicitud();
                    string cCuentas = "";
                    int nContador = 1;

                    foreach (DataGridViewRow item in dtgCuentaCreditoVinculado.Rows)
                    {
                        if (nContador == 1)
                        {
                            cCuentas = item.Cells[1].Value.ToString();
                        }
                        else
                        {
                            cCuentas = cCuentas + "," + item.Cells[1].Value.ToString();
                        }
                        nContador++;
                    }

                    dtValidaImpulsoMyPeru = cValidacion.CNValidaCuentasProgImpulsoMyPeru(Convert.ToInt32(this.txtCodCliente.Text), cCuentas);
                    if (dtValidaImpulsoMyPeru.Rows[0]["cRespuesta"].ToString() != "0")
                    {
                        MessageBox.Show(dtValidaImpulsoMyPeru.Rows[0]["cRespuesta"].ToString(), "Validación de PROGRAMA IMPULSO MYPERU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    return true;
                }
            }
            return true;
        }

        #endregion

        private void dtgCuentaCreditoVinculado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCuentaCreditoVinculado.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(cboOperacionCre1.SelectedValue) == 2)
                {
                    btnQuitar.Enabled = (Convert.ToInt32(this.dtgCuentaCreditoVinculado.SelectedRows[0].Cells["lPermQuitar"].Value) == 1);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string cIdCliente = Convert.ToString(txtCodCliente.Text);
            this.limpiarControles();
            lEditar = true;
            txtCodCliente.Text = cIdCliente;
            buscarSolicitudcliente();
            btnGrabar1.Enabled = true;
            btnGrabar1.Visible = true;
            btnEnviar.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCodigoSol.Text))
            {
                MessageBox.Show("No existe numero de solicitud", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idsolicitud = Convert.ToInt32(this.txtCodigoSol.Text);

            if (idsolicitud == 0)
            {
                MessageBox.Show("No existe numero de solicitud", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            int idcli = Convert.ToInt32(this.txtCodCliente.Text);


            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            int idtipocliente = Convert.ToInt32(dtSolicitud.Rows[0]["idtipopersona"]);

            if (idtipocliente == 1)
            {
                dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNCredito().DatosSolicitud(idsolicitud)));
                dtslist.Add(new ReportDataSource("DataSet2", new clsRPTCNCredito().DatosFamiliar(idcli)));


                string reportpath = "rptDatoSolicitud.rdlc";
                frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
                frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                frmreporte.ShowDialog();
            }
            else
            {
                dtslist.Add(new ReportDataSource("DataSet1", new clsRPTCNCredito().DatosSolicitud(idsolicitud)));
                dtslist.Add(new ReportDataSource("ClienteJur", new clsRPTCNCredito().DatosclienteJur(idcli)));
                dtslist.Add(new ReportDataSource("ClienteVin", new clsRPTCNCredito().DatosclienteVin(idcli)));


                string reportpath = "rptDatoSolicitudJudi.rdlc";
                frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
                frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
                frmreporte.ShowDialog();
            }

        }

        private void btnDocumento1_Click(object sender, EventArgs e)
        {
            /*frmMensaje frmMensaje = new frmMensaje();
            frmMensaje.cMotivoAproba = cComentAproba;
            frmMensaje.ShowDialog();*/
            int nNivelActual = 2;
            int nNivelAprobacion = 2;
            int idSolicitud = Convert.ToInt32(txtCodigoSol.Text);
            frmAprobaExcepcionesCred frmAprobaExcepciones = new frmAprobaExcepcionesCred( nNivelActual,nNivelAprobacion, idSolicitud,0);

            frmAprobaExcepciones.ShowDialog();
        }

        private void AlertaCreditosVinculados(int idCli)
        {
            DataTable dtRes = cncredito.CNAlertaCreditosVinculados(idCli);

            if (dtRes.Rows.Count > 0)
            {
                MessageBox.Show("El cliente tiene los siguientes vinculados con créditos en la CAJA: \n" + this.ObtenerCadenaMensaje(dtRes), "Alerta de Vinculados con créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string ObtenerCadenaMensaje(DataTable dtRes)
        {
            string cCadena = "";
            foreach (DataRow item in dtRes.Rows)
            {
                cCadena += "\n " + item["cMensaje"].ToString();
            }
            return cCadena;
        }

        private void AlertaCreditos50000(int idSolicitud, decimal? nMonto)
        {
            CRE.CapaNegocio.clsCNCredito objCre = new CRE.CapaNegocio.clsCNCredito();
            DataTable dt = objCre.CNAlertaCreditos50000(idSolicitud);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            int idTipoCliente = Convert.ToInt32(dt.Rows[0]["idTipoCli"].ToString());
            decimal nMontoLimite = Convert.ToDecimal(dt.Rows[0]["nMontoLimite"].ToString());
            nMonto = Convert.ToDecimal(dt.Rows[0]["nCapitalSolicitado"].ToString());

            if (nMonto >= nMontoLimite)
            {
                MessageBox.Show("Para montos mayores o iguales a S/ " + nMontoLimite.ToString("###,###,##0.00")+
                    ", requiere la Aprobación y Conformidad del Directorio",
                    "Información Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool validarProductoSeguro()
        {
            bool lValor = true;
            clsVarGen objVariableGeneral = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaProductoAplicaSeguro"));
            string cListaProducto = objVariableGeneral.cValVar;



            if (cListaProducto == "0")
                return true;
            List<int> lstProductosPermitidos = objVariableGeneral.cValVar.Split(',').Select(Int32.Parse).ToList();
            int idProductoSeleccionado = Convert.ToInt32(cboSubProducto.SelectedValue);

            lValor = (lstProductosPermitidos.Contains(idProductoSeleccionado)) ? false : true;

            return lValor;
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (txtCodigoSol.Text != "")
            {
                if (Convert.ToInt32(txtCodigoSol.Text) > 0)
                {
                    frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(txtCodigoSol.Text), false);
                    frmCargaArchivo.ShowDialog();
        }
            }
            else
            {
                MessageBox.Show("No se encontró una Solicitud.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CambiarClasificacionInterna(int idCli, int idClasifInterna)
        {
            clsCNBuscarCli ClasifInterna = new clsCNBuscarCli();
            DataTable Cliente1 = ClasifInterna.CNCambiarClasificacionInterna(idCli,idClasifInterna);

            idClasificacionInterna = Convert.ToInt32(Cliente1.Rows[0]["idClasifInterna"].ToString());
            cClasifInternaTmp = Convert.ToString(Cliente1.Rows[0]["cClasifInterna"].ToString());

        }

        private void CambiarClasificacionInternaxOferta(int idCli, int idClasifInterna,int idUsuarioReg, int idOferta)
        {
            clsCNBuscarCli ClasifInterna = new clsCNBuscarCli();
            DataTable dtClasficacionInterna = ClasifInterna.CNCambiarClasificacionInternaxOferta(idCli, idClasifInterna, idUsuarioReg, idOferta);

            if (dtClasficacionInterna.Rows.Count != 0)
            {
                if (Convert.ToInt32(dtClasficacionInterna.Rows[0]["nResultado"]) == 0)
                {
                    MessageBox.Show(Convert.ToString(dtClasficacionInterna.Rows[0]["cMensaje"].ToString()), "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    idClasificacionInterna = Convert.ToInt32(dtClasficacionInterna.Rows[0]["idClasifInterna"].ToString());
                    cClasifInternaTmp = Convert.ToString(dtClasficacionInterna.Rows[0]["cClasifInterna"].ToString());
                }
            }
            
            


        }

        private void VerificarClasificacionInternaxOferta(int idCli)
        {
            clsCNBuscarCli ClasifInterna = new clsCNBuscarCli();
            DataTable dtClasficacionInterna = ClasifInterna.CNVerificaClasificacionInternaxOferta(idCli);

            if (dtClasficacionInterna.Rows.Count != 0)
            {
                if (Convert.ToInt32(dtClasficacionInterna.Rows[0]["nResultado"]) == 0)
                {
                    MessageBox.Show(Convert.ToString(dtClasficacionInterna.Rows[0]["cMensaje"].ToString()), "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(dtClasficacionInterna.Rows[0]["idClasifInterna"]) != 0 && !dtClasficacionInterna.Rows[0]["cClasifInterna"].ToString().Equals("ninguna"))
                    {
                        idClasificacionInterna = Convert.ToInt32(dtClasficacionInterna.Rows[0]["idClasifInterna"].ToString());
                        cClasifInternaTmp = Convert.ToString(dtClasficacionInterna.Rows[0]["cClasifInterna"].ToString());
                        lblCalificacionInterna.Text = cClasifInternaTmp;
                    }
                }
        }

                
        }
        private void buscarSolicitudcliente()
        {
            if (txtCodCliente.Text == "")
            {
                MessageBox.Show("No se encuentra datos del código ingresado", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int CodCli = Convert.ToInt32(txtCodCliente.Text);
            btnVincularVisita1.idCli = CodCli;
            clsCNBuscarCli listarCli = new clsCNBuscarCli();
            AlertaCreditosVinculados(CodCli);         
            DataTable Cliente = listarCli.ListarclixIdCli(CodCli);
            
            if (Cliente.Rows.Count > 0)
            {
                if (Convert.ToBoolean(Cliente.Rows[0]["lIndDatosBasic"]) == true)
                {
                    MessageBox.Show("Debe Registrar Datos Completos del cliente", "Validación de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodCliente.Clear();
                    this.limpiar();
                    return;
                }
                int nIdClasif = Convert.ToInt32(Cliente.Rows[0]["idClasifInterna"].ToString());
                CambiarClasificacionInterna(CodCli, nIdClasif);
                
                txtCodInst.Text = Convert.ToString(Cliente.Rows[0]["cCodCliente"]).Substring(0, 3);
                txtCodAge.Text = Convert.ToString(Cliente.Rows[0]["cCodCliente"]).Substring(3, 3);
                txtCodCliente.Text = Convert.ToString(Cliente.Rows[0]["cCodCliente"]).Substring(6);

                lblCalificacionInterna.Text = cClasifInternaTmp;
                idClasificacionInterna = idClasificacionInterna;
                txtNombre.Text = Convert.ToString(Cliente.Rows[0]["cNombre"]);
                txtNroDocIde.Text = Convert.ToString(Cliente.Rows[0]["cDocumentoID"]);
                this.nudAniosActEco.Value = Convert.ToDecimal(Cliente.Rows[0]["nAniosActEco"]);

                this.idActividadInterna = Convert.ToInt32(Cliente.Rows[0]["idActividadInterna"]);
                if (this.idActividadInterna > 0)
                {
                    this.conActividadCIIU1.cargarActividadInterna(this.idActividadInterna);
                    this.conActividadCIIU1.Enabled = false;
                }

                this.btnGrabar1.Enabled = true;
                this.txtCodCliente.Enabled = false;
                this.btnBusCliente.Enabled = false;
                this.txtCodigoSol.Enabled = false;
                nidTipoPersona = Convert.ToInt32(Cliente.Rows[0]["IdTipoPersona"]);
                deshabilitarTipoSeguro();

                initClienteRecurrente((Cliente.Rows[0]["idTipoCliente"] == DBNull.Value) ? 0 : Convert.ToInt32(Cliente.Rows[0]["idTipoCliente"]));


                if (VerificarUsuarioCampana())
                {
                    CargarDatosCampana(CodCli);
                    AsignarDatosCampana();
                }
            }
            else
            {
                MessageBox.Show("No se encuentra datos del código ingresado", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.limpiar();
                this.btnGrabar1.Enabled = false;
                this.txtCodigoSol.Enabled = true;
                this.btnBusCliente.Enabled = true;
                this.txtCodigoSol.Enabled = true;
                return;
            }

            this.btnEnviar.Enabled = false;
            this.btnCargaArhivos.Enabled = false;
            buscarSolicitudCliente(CodCli);

            this.txtCodCliente.Enabled = false;
            this.btnBusCliente.Enabled = false;

            this.txtCodigoSol.Enabled = false;           
        }

        private void ObtenerOfertaSolicitud(int idOferta)
        {
            ClsCNClienteExclusivo objCliExclu = new ClsCNClienteExclusivo();
            DataTable dt = objCliExclu.CNObtenerOfertaClienteOferta(idOferta);
            if (dt.Rows.Count == 0)
                return;

            this.objOferta = DataTableToList.ConvertTo<ClsOfertaClienteExclusivo>(dt).ToList<ClsOfertaClienteExclusivo>()[0];

            listProd = DataTableToList.ConvertTo<ClsProductoExclusivo>(objCliExclu.CNObtenerProductos(objOferta.idGrupoProducto, objOferta.cTipoClienteExclusivo)).ToList<ClsProductoExclusivo>();
            if (listProd.Count == 0)
            {
                MessageBox.Show("No se tiene ningun producto relacionado", "Registro Solicitud de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listProd = null;
                return;
            }
        }

        private void CargarOfertaClienteExclusivo(int idCli)
        {
            VerificarClasificacionInternaxOferta(idCli);
            frmOfertasClientesExclusivos frmOferta = new frmOfertasClientesExclusivos(idCli);
            if (!frmOferta.TieneOferta(idCli))
            {
                return;
            }
            frmOferta.ShowDialog();

            this.objOferta = frmOferta.ObtenerClienteSeleccionado();
            if (objOferta == null)
            {
                return;
            }

            ClsCNClienteExclusivo objCliExclu = new ClsCNClienteExclusivo();
            //obtener los padres del producto, solo entrar a reclasificacion si es diferente te personal o consulo
            listProd = DataTableToList.ConvertTo<ClsProductoExclusivo>(objCliExclu.CNObtenerProductos(objOferta.idGrupoProducto, objOferta.cTipoClienteExclusivo)).ToList<ClsProductoExclusivo>();
            if (listProd.Count == 0)
            {
                MessageBox.Show("No se tiene ningun producto relacionado", "Registro Solicitud de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listProd = null;
                return;
            }
            if (listProd[0].cProducto == "EFECTIVO AL INSTANTE")
            {
                MessageBox.Show("Debe atender al cliente por la opción Clientes con Campaña.", "Registro Solicitud de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listProd = null;
                return;
            }

            clsCNProductos objProd = new clsCNProductos();
            DataTable dtProdPadres = objProd.RetDatosProducto(listProd[0].idProducto);
            int idTipoCredito = Convert.ToInt32(dtProdPadres.Rows[3]["IdProducto"]);
            if (this.objOferta.lCargaAutomaticoProd)
            {
                if (!this.objOferta.idGrupoProducto.In(1, 2, 3))
                {
                    this.CargarProductos(idTipoCredito
                        , Convert.ToInt32(dtProdPadres.Rows[2]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[1]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[0]["IdProducto"]));
                    this.txtMonto.Text = this.objOferta.nMontoOferta.ToString();
                    if (this.objOferta.idOperacion != 0)
                    {
                        cboOperacionCre1.SelectedValue = this.objOferta.idOperacion;
                    }
                    if (this.objOferta.idModalidadCredito != 0)
                    {
                        cboModalidadCredito.SelectedValue = this.objOferta.idModalidadCredito;
                    }

                    return;
                }

                DataTable dtClasCred = cnsolicitud.CNClasificarCredito(txtNroDocIde.Text.Trim());
                if (Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]) == idTipoCredito)
                {
                    this.CargarProductos(idTipoCredito
                        , Convert.ToInt32(dtProdPadres.Rows[2]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[1]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[0]["IdProducto"]));
                    this.txtMonto.Text = this.objOferta.nMontoOferta.ToString();
                    if (this.objOferta.idOperacion != 0)
                    {
                        cboOperacionCre1.SelectedValue = this.objOferta.idOperacion;
                    }
                    if (this.objOferta.idModalidadCredito != 0)
                    {
                        cboModalidadCredito.SelectedValue = this.objOferta.idModalidadCredito;
                    }
                    return;
                }

                DataTable dtFamCred = cnsolicitud.CNBusFamCred(Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]), listProd[0].idProducto);
                if (dtFamCred.Rows.Count < 5)
                {
                    //MessageBox.Show("No se pudo reclasificar el crédito", "Reclasificación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    indClasif = false;
                    return;
                }

                this.CargarProductos(Convert.ToInt16(dtFamCred.Rows[1]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[2]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[3]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[4]["idProducto"]));

                this.txtMonto.Text = this.objOferta.nMontoOferta.ToString();
                if (this.objOferta.idOperacion != 0)
                {
                    cboOperacionCre1.SelectedValue = this.objOferta.idOperacion;
                }
                if (this.objOferta.idModalidadCredito != 0)
                {
                    cboModalidadCredito.SelectedValue = this.objOferta.idModalidadCredito;
                }
                if (this.objOferta.idClasifInterna > 0)
                {             
                    CambiarClasificacionInternaxOferta(Convert.ToInt32(idCli), this.objOferta.idClasifInterna, clsVarGlobal.User.idUsuario, this.objOferta.idOferta);
                    lblCalificacionInterna.Text = cClasifInternaTmp;
                }
            }
            else
            {
                this.txtMonto.Text = this.objOferta.nMontoOferta.ToString();
                if (this.objOferta.idOperacion != 0)
                {
                    cboOperacionCre1.SelectedValue = this.objOferta.idOperacion;
                }
                if (this.objOferta.idModalidadCredito != 0)
                {
                    cboModalidadCredito.SelectedValue = this.objOferta.idModalidadCredito;
                }
                if (this.objOferta.idClasifInterna > 0)
                {
                    CambiarClasificacionInternaxOferta(Convert.ToInt32(idCli), this.objOferta.idClasifInterna, clsVarGlobal.User.idUsuario, this.objOferta.idOferta);
                    lblCalificacionInterna.Text = cClasifInternaTmp;
                }
            }

        }

        private void CargarOfertaClienteExclusivoJC(ClsOfertaClienteExclusivoMejorado objOferta)
        {
            VerificarClasificacionInternaxOferta(objOferta.idCli);

            ClsCNClienteExclusivo objCliExclu = new ClsCNClienteExclusivo();
            //obtener los padres del producto, solo entrar a reclasificacion si es diferente te personal o consulo
            listProd = DataTableToList.ConvertTo<ClsProductoExclusivo>(objCliExclu.CNObtenerProductos(objOferta.idGrupoProducto, objOferta.cTipoClienteExclusivo)).ToList<ClsProductoExclusivo>();
            if (listProd.Count == 0)
            {
                MessageBox.Show("No se tiene ningun producto relacionado", "Registro Solicitud de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listProd = null;
                return;
            }

            clsCNProductos objProd = new clsCNProductos();
            DataTable dtProdPadres = objProd.RetDatosProducto(listProd[0].idProducto);
            int idTipoCredito = Convert.ToInt32(dtProdPadres.Rows[3]["IdProducto"]);
            if (objOferta.lCargaAutomaticoProd == 1)
            {
                if (!objOferta.idGrupoProducto.In(1, 2, 3))
                {
                    CargarProductos(idTipoCredito
                        , Convert.ToInt32(dtProdPadres.Rows[2]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[1]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[0]["IdProducto"]));
                    this.txtMonto.Text = objOferta.nMontoOferta.ToString();
                    if (this.objOferta.idOperacion != 0)
                    {
                        cboOperacionCre1.SelectedValue = objOferta.idOperacion;
                    }
                    if (objOferta.idModalidadCredito != 0)
                    {
                        cboModalidadCredito.SelectedValue = objOferta.idModalidadCredito;
                    }

                    return;
                }

                DataTable dtClasCred = cnsolicitud.CNClasificarCredito(txtNroDocIde.Text.Trim());
                if (Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]) == idTipoCredito)
                {
                    CargarProductos(idTipoCredito
                        , Convert.ToInt32(dtProdPadres.Rows[2]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[1]["IdProducto"])
                        , Convert.ToInt32(dtProdPadres.Rows[0]["IdProducto"]));
                    this.txtMonto.Text = objOferta.nMontoOferta.ToString();
                    if (objOferta.idOperacion != 0)
                    {
                        cboOperacionCre1.SelectedValue = objOferta.idOperacion;
                    }
                    if (objOferta.idModalidadCredito != 0)
                    {
                        cboModalidadCredito.SelectedValue = objOferta.idModalidadCredito;
                    }
                    return;
                }

                DataTable dtFamCred = cnsolicitud.CNBusFamCred(Convert.ToInt16(dtClasCred.Rows[0]["idProducto"]), listProd[0].idProducto);
                if (dtFamCred.Rows.Count < 5)
                {
                    //MessageBox.Show("No se pudo reclasificar el crédito", "Reclasificación de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    indClasif = false;
                    return;
                }

                CargarProductos(Convert.ToInt16(dtFamCred.Rows[1]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[2]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[3]["idProducto"])
                                    , Convert.ToInt16(dtFamCred.Rows[4]["idProducto"]));

                this.txtMonto.Text = objOferta.nMontoOferta.ToString();
                if (objOferta.idOperacion != 0)
                {
                    cboOperacionCre1.SelectedValue = objOferta.idOperacion;
                }
                if (objOferta.idModalidadCredito != 0)
                {
                    cboModalidadCredito.SelectedValue = objOferta.idModalidadCredito;
                }
                if (objOferta.idClasifInterna > 0)
                {
                    CambiarClasificacionInternaxOferta(Convert.ToInt32(objOferta.idCli), objOferta.idClasifInterna, clsVarGlobal.User.idUsuario, objOferta.idOferta);
                    lblCalificacionInterna.Text = cClasifInternaTmp;
                }
            }
            else
            {
                this.txtMonto.Text = objOferta.nMontoOferta.ToString();
                if (objOferta.idOperacion != 0)
                {
                    cboOperacionCre1.SelectedValue = objOferta.idOperacion;
                }
                if (objOferta.idModalidadCredito != 0)
                {
                    cboModalidadCredito.SelectedValue = objOferta.idModalidadCredito;
                }
                if (objOferta.idClasifInterna > 0)
                {
                    CambiarClasificacionInternaxOferta(Convert.ToInt32(objOferta.idCli), objOferta.idClasifInterna, clsVarGlobal.User.idUsuario, objOferta.idOferta);
                    lblCalificacionInterna.Text = cClasifInternaTmp;
                }
            }

        }
        private void CargarProductos(int idTipoCre, int idSubTipoCred, int idProducto, int idSubProducto)
        {
            cboTipoCredito.SelectedValue = idTipoCre;
            cboSubTipoCredito.SelectedValue = idSubTipoCred;
            cboProducto.SelectedValue = idProducto;
            cboSubProducto.SelectedValue = idSubProducto;
        }

        private void validarVigenciaPlanesDeSeguro()
        {
            #region PlanesDeSeguro

            //VERIFICAR QUE SEA CLIENTE NATURAL
            if (!new clsCNCliente().ValidarSiEsClienteNatural(Convert.ToInt32(txtCodCliente.Text)))
            {
                MessageBox.Show("Los planes de seguro solo se puede vender a personas naturales", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPaqueteSeguro1.SelectedIndex = 0;
                return;
            }

            //Validar vigencia de planes de seguro
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(objPaqueteSeguroCN.CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            DataTable dtLsSeguros = new clsCNCreditoCargaSeguro().CNObtenerListaSegurosCliente(Convert.ToInt32(txtCodCliente.Text));
            DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                          where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                          select fila).FirstOrDefault();
            if (dr != null && Convert.ToInt32(cboOperacionCre1.SelectedValue) == 3)
            {
                MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPaqueteSeguro1.SelectedIndex = 0;
            }

            #endregion
        }

        private bool ValidaTipoOferta()
        { 
            bool  lBool = true;
            if (this.objOferta == null)
            {
                return true;
            }

            if (this.objOferta.idTipoGrupoCamp == 2)
            {
                MessageBox.Show("La oferta del cliente es Aprobada, no se enviará a evaluación", "Segmentación de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lBool = false;
            }

            return lBool;
        }

        private void deshabilitarTipoSeguro()
        {
            if (nidTipoPersona == 1)
            {
                cboDetalleGasto1.Enabled = true;
            }
            else
            {
                cboDetalleGasto1.SelectedIndex = -1;
                cboDetalleGasto1.Enabled = false;
            }
        }

        private void cboDetalleGasto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDetalleGasto1.SelectedIndex == 2)
            {
                DialogResult drRespuesta = MessageBox.Show(cboDetalleGasto1.cMsjSeguroDevolucion,
                    cboDetalleGasto1.cTituloMsjSegDevolucion,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.No == drRespuesta)
                {
                    cboDetalleGasto1.SelectedIndex = -1;
                    CargarPaqueteSeguro(1, true);
                }
            }
            if (lFrmPosConsolidada == false)
            {
                if (cboDetalleGasto1.SelectedIndex > -1)
                {
                    CargarPaqueteSeguro(idPaqueteSeguro, true);
                }
            }
        }

        public void CargarPaqueteSeguro(int idPaqueteSeguro, bool cargaInicial)
        {
           if (cboDetalleGasto1.SelectedIndex !=-1)
            {                
                int idDetalleGasto = Convert.ToInt16(cboDetalleGasto1.SelectedValue);
                if (idDetalleGasto> 0)
                {                    
                    int DetalleGasto = Convert.ToInt32(cboDetalleGasto1.SelectedValue);
                    int idAgencia = clsVarGlobal.nIdAgencia;
                    int idPerfil = clsVarGlobal.PerfilUsu.idPerfil;
                    
                    cboPaqueteSeguro1.CargarPaqueteSeguroVenta(DetalleGasto, idPerfil, idAgencia, idPaqueteSeguro);
                    cboPaqueteSeguro1.AgregarNinguno();
                    cboPaqueteSeguro1.Enabled = true;
                    if(idPaqueteSeguro != 0){
                        cboPaqueteSeguro1.SelectedValue = cargaInicial ? idPaqueteSeguro : idPaqueteSeguro;
                    }
                    else
                    {
                        cboPaqueteSeguro1.SelectedIndex = 0;
                    }
                    objSolicitudCreditoCargaSeguro.idPaqueteSeguro = Convert.ToInt32(cboPaqueteSeguro1.SelectedValue);

                }
                else
                {
                    cboPaqueteSeguro1.AgregarNinguno();
                    cboPaqueteSeguro1.Enabled = false;
                    cboPaqueteSeguro1.SelectedIndex = -1;
                }
            }
            else
            {
                cboPaqueteSeguro1.AgregarNinguno();
                cboPaqueteSeguro1.Enabled = false;
                cboPaqueteSeguro1.SelectedIndex = -1;
            }
            cboPaqueteSeguro1.DropDownWidth = cboPaqueteSeguro1.Items.Count > 1 ? 405 : cboPaqueteSeguro1.Width;
        }

        private void conCreditoPrimeraCuota_ValueChangedFecha(object sender, EventArgs e)
        {
            if (conCreditoPrimeraCuota.dFecha == null)
                return;

            this.calcularFechaPrimeraCuota();
        }

        private void cboCanalVendedor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPromotores1.filtrarPorCanal(Convert.ToInt32(cboCanalVendedor1.SelectedValue));
            int listItem = cboPromotores1.Items.Count;
            if (listItem == 1)
            {
                cboPromotores1.SelectedIndex = 0;
            }
            else
            {
                cboPromotores1.SelectedValue = 0;
            }
        }

        private bool verficarOpinionRiesgosReprogarmacion() {
            clsCNSolicitud opinionRiesgos = new clsCNSolicitud();
            return (Convert.ToInt32(opinionRiesgos.CNVerificarOpinionRiesgosReprogramacion(string.IsNullOrEmpty(txtCodigoSol.Text.Trim()) ? 0 : Convert.ToInt32(txtCodigoSol.Text.Trim()), Convert.ToInt32(cboOperacionCre1.SelectedValue), Convert.ToInt32(txtCodCliente.Text.Trim()), Convert.ToInt32(nidTipoPersona)).Rows[0]["lresultado"]) == 0) ? false : true; 
        }

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
            frmGestObs.idEtapaEvalCred = 2;
            frmGestObs.nModoFunc = 2;
            frmGestObs.idSolicitud = (this.txtCodigoSol.Text != "") ? Convert.ToInt32(txtCodigoSol.Text) : -1;
            frmGestObs.ConfigSelecFiltros(true, false, false, true);
            frmGestObs.ConfigHabilitarFiltros(false, false, true, false);
            frmGestObs.ShowDialog();
        }

        private bool ValidarIndicadorObser()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs((this.txtCodigoSol.Text != "") ? Convert.ToInt32(txtCodigoSol.Text) : -1, 2);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>("lResolCom"));
        }     
    }
}

public class DatoBusqueda
	{
		public string  pcNroDoc { get; set; }
        public string  pcNomCli { get; set; }
        public string pcCodCli { get; set; }
        public string pcDireccion { get; set; }
        public string pcCodCliLargo { get; set; }
        public string pcTipoDocumento { get; set; }
        public string pcRucCli { get; set; }
        public string pcClasifInt { get; set; }
        public int pnTipoDocumento { get; set; }
        public string pnIdClasifInt { get; set; }
        public int pnIdCondDom { get; set; }
        public bool pIndicaDatoBasico { get; set; }
        public int idEstadoCli { get; set; }
        public int idAgencia { get; set; }
        public int pnTipoPersona { get; set; }
        public int idTipoCliente { get; set; }
        public int nAniosActEco { get; set; }
        public int idActividadInterna { get; set; }
        public int idClasificacionInterna { get; set; }
	}