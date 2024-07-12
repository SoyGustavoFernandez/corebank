using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using GEN.Servicio;
using EntityLayer.SentinelData;
using System.Globalization;


namespace CRE.Presentacion
{
    public partial class frmAprobDenegSolicitud : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Autorización de Desembolso";
        clsCNSolicitud nSoliDatos = new clsCNSolicitud();
        DataTable dtDatosSolCred;
        private DataTable dtSolicitud;
        public string cNivAprob, cPerfil, cNombre, cNivelAprobacion;
        private string cLblSolicitud = "Código de Solicitud";
        public int idUsuarioAprobador = 0;
        public int idPerfilAprobador = 0;
        public string cEstadoSolicitud; 
        frmBuscarAprob frmBuscarAprob1 = new frmBuscarAprob();
        int nIdUsuarioModifica = clsVarGlobal.User.idUsuario;
        DateTime dFechaMod = clsVarGlobal.dFecSystem; // dfechamod
        DataTable dtDatosNivelAprobacion = new DataTable();
        DataTable dtDatosValidacion = new DataTable();

        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private clsCNExcepcionesCreditos objCNExcepciones = new clsCNExcepcionesCreditos();

        private int nCountClick = 0;
        private ClsOfertaClienteExclusivo objOferta;

        private int nEstadoRiesgos = 0;
        private string cMensajeRiesgos = "";

        private string cTipoPeriodo = String.Empty;

        private clsCNExpedienteLinea clsExpedienteNegocio = new clsCNExpedienteLinea();
        string cTipoPersona = string.Empty;
        DataTable dtClasificacionCliente = new DataTable();
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        Response objRespuesta;
        List<TitularConyuge> objLisTituConyuge;
        clsApiCentralRsgExterno objCentraRsgExterno = new clsApiCentralRsgExterno();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();

        Response objRespuestaTitular;
        Response objRespuestaConyuge;

        private string cTipoSolicitud = "individual";
        DataTable dtBasicoSunatTitular;
        DataColumn columnBasicoSunatTitular;
        DataRow rowBasicoSunatTitular;

        DataTable dtBasicoSunatConyuge;
        DataColumn columnBasicoSunatConyuge;
        DataRow rowBasicoSunatConyuge;
        DataSet dsContenedorConsolidada;

        DataTable dtBSunatDireccionTitular;
        DataColumn columnBSunatDireccionTitular;
        DataRow rowBSunatDireccionTitular;

        DataTable dtBSunatDireccionConyuge;
        DataColumn columnBSunatDireccionConyuge;
        DataRow rowBSunatDireccionConyuge;

        DataTable dtRlegalTitular;
        DataColumn columnRlegalTitular;
        DataRow rowRlegalTitular;

        DataTable dtRlegalConyuge;
        DataColumn columnRlegalConyuge;
        DataRow rowRlegalConyuge;

        DataTable dtlCredNoUtilizadaT;
        DataColumn columnlCredNoUtilizadaT;
        DataRow rowlCredNoUtilizadaT;

        DataTable dtlCredNoUtilizadaC;
        DataColumn columnlCredNoUtilizadaC;
        DataRow rowlCredNoUtilizadaC;

        DataTable dtDeudaTitular;
        DataColumn columnDeudaTitular;
        DataRow rowDeudaTitular;

        DataTable dtDeudaConyuge;
        DataColumn columnDeudaConyuge;
        DataRow rowDeudaConyuge;

        DataTable dtAvalistaTitular;
        DataColumn columnAvalistaTitular;
        DataRow rowAvalistaTitular;

        DataTable dtAvalistaConyuge;
        DataColumn columnAvalistaConyuge;
        DataRow rowAvalistaConyuge;

        DataTable dtAvalado;
        DataColumn columnAvaladoTitular;
        DataRow rowAvaladoTitular;

        DataTable dtAvaladoConyuge;
        DataColumn columnAvaladoConyuge;
        DataRow rowAvaladoConyuge;
        DataTable dtDeudaSentinelDirectaTitular;
        DataTable dtDeudaSentinelDirectaConyuge;

        DataTable dtMicrTitular;
        DataColumn columnMicrTitular;
        DataRow rowMicrTitular;

        DataTable dtMicrConyuge;
        DataColumn columnMicrConyuge;
        DataRow rowMicrConyuge;

        DataTable dtHistorialSentinelTitular;
        DataRow rowHistorialSentinelTitular;
        DataColumn columnHistorialSentinelTitular;

        DataTable dtHistorialSentinelConyuge;
        DataRow rowHistorialSentinelConyuge;
        DataColumn columnHistorialSentinelConyuge;

        DataTable dtClasTitularConyuge;
        DataColumn columnClasTitularConyuge;
        DataRow rowClasTitularConyuge;
        string cSemaforoTitular = string.Empty;
        string cSemaforoConyuge = string.Empty;
        string cidTipoDocumento = string.Empty;
        int nidTipoPersona;

        #endregion

        #region Eventos

        public frmAprobDenegSolicitud()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[1,2,4]";
            this.btnBuenaPro1.Enabled = false;
            this.btnAprobar.Enabled = false;
            this.btnExcepciones.Enabled = false;
            this.btnDenegar.Enabled = false;

        }
     
        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            rellenarDatosSolicitud();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            rellenarDatosSolicitud();
        }
        
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            verficarOpinionRiesgos();
            if(nEstadoRiesgos == 1){
                MessageBox.Show(cMensajeRiesgos, "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.idUsuarioAprobador != 0)
            {
                int idCli = Convert.ToInt32(this.dtSolicitud.Rows[0]["idCli"]);
                int idProducto = Convert.ToInt32(this.dtSolicitud.Rows[0]["idProducto"]);
                int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim());
                int a = 0;
                string cMsjeError = ".";
                DataTable RespGarantias = new clsCNSolicitud().CNConsultaRegistroGarantias(idCli, idProducto, idSolicitud);
                clsRespuestaServidor objRespuesta = this.objCNExcepciones.validarAprobExcepcioneReglaNeg(idSolicitud, this.idUsuarioAprobador, this.idPerfilAprobador);

                if (RespGarantias.Rows.Count > 0)
                {
                    cMsjeError = RespGarantias.Rows[0]["cMsjeError"].ToString();
                    int idMsj = Convert.ToInt32(RespGarantias.Rows[0]["idError"].ToString());
                    MessageBox.Show(cMsjeError, cTituloMsjes, MessageBoxButtons.OK, idMsj == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    if (idMsj == 0)
                    { return; }
                }

                if (ValidarClienteCampana() && !ValidarCondicionesCampana())
                {
                    MessageBox.Show("Las condiciones no cumplen con las ofrecidas en campaña. No se puede aprobar por este medio", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtDatosSolCred = nSoliDatos.ConsultaSolicitud(idSolicitud);
                if ( !validarReglas(true) ) return;

                if (objRespuesta.idResultado == ResultadoServidor.Error)
                {
                    MessageBox.Show(objRespuesta.cMensaje, "ALERTA DE EXCEPCIÓN DE REGLA CREDITICIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("¿Esta seguro de aprobar esta solicitud de crédito?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idEstado = Convert.ToInt32(((Boton)sender).Tag);
                    aprobardenegar(idEstado);
                    this.btnAprobar.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    rellenarDatosSolicitud();
                }
            }
            else
            {
                MessageBox.Show("No permitido, seleccione un perfil de aprobación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            if (this.idUsuarioAprobador != 0)
            {

                if (MessageBox.Show("¿Esta seguro de denegar esta solicitud de crédito?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idEstado = Convert.ToInt32(((Boton)sender).Tag);
                    aprobardenegar(idEstado);
                    this.btnAprobar.Enabled = false;
                    this.btnDenegar.Enabled = false;
                    rellenarDatosSolicitud();
                }
            }
            else
            {
                MessageBox.Show("No permitido, seleccione un perfil de aprobación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBuenaPro1_Click(object sender, EventArgs e)
        {

            frmBuscarAprob frmBuscarAprob1 = new frmBuscarAprob();
            frmBuscarAprob1.ShowDialog();
            string cNivelAprob = frmBuscarAprob1.cNivAprob;
            string cPerfilN = frmBuscarAprob1.cPerfil;
            string cNombreN = frmBuscarAprob1.cNombre;
            int nNivelAp = Convert.ToInt32(frmBuscarAprob1.cNivelAprobacion);
            this.idUsuarioAprobador = frmBuscarAprob1.idUsuario;
            this.idPerfilAprobador = frmBuscarAprob1.idPerfil;

            if (this.idUsuarioAprobador != 0)
            {
                rellenarDatosAprobador(cNivelAprob, cPerfilN, cNombreN, nNivelAp, this.idUsuarioAprobador);
                this.idUsuarioAprobador = frmBuscarAprob1.idUsuario;
                this.idPerfilAprobador = frmBuscarAprob1.idPerfil;
                this.btnBuenaPro1.Enabled = false;
                this.btnAprobar.Enabled = true;
                this.btnExcepciones.Enabled = true;
                this.btnDenegar.Enabled = true;
            }
            else
            {
                this.idUsuarioAprobador = clsVarGlobal.User.idUsuario;
                this.idPerfilAprobador = clsVarGlobal.PerfilUsu.idPerfil;
                this.btnBuenaPro1.Enabled = true;
                this.btnAprobar.Enabled = false;
                this.btnExcepciones.Enabled = false;
                this.btnDenegar.Enabled = false;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void frmAprobDenegSolicitud_Load(object sender, EventArgs e)
        {
            CreaTablaClasificacionCliente();
            CreaTablaBasicoSunatTitular();
            CreaTablaBasicoSunatConyuge();
            CreaTablaBSunatDireccionTitular();
            CreaTablaBSunatDireccionConyuge();
            CreaTablaRLegalTitular();
            CreaTablaRLegalConyuge();
            CreaTablalCredNoUtilTitular();
            CreaTablalCredNoUtilConyuge();
            CreaTablaDeudaTitular();
            CreaTablaDeudaConyuge();
            CreaTablaAvalistaTitular();
            CreaTablaAvalistaConyuge();
            CreaTablaAvaladoTitular();
            CreaTablaAvaladoConyuge();
            CreaTablaMicrofinanzasTitular();
            CreaTablaMicrofinanzasConyuge();
            CreaTablaHistorialSentinelTitular();
            CreaTablaHistorialSentinelConyuge();

            if (clsVarGlobal.PerfilUsu.idPerfil == 34)//ASESOR DE NEGOCIOS
            {
                this.cboNivelAprobacion1.Visible = false;
                this.lblNivelAprob.Visible = false;
                this.btnBuenaPro1.Visible = false;
                this.idUsuarioAprobador = clsVarGlobal.User.idUsuario;
                this.idPerfilAprobador = clsVarGlobal.PerfilUsu.idPerfil;
                this.txtPerfil.Text = "ASESOR DE NEGOCIOS";
                this.txtNombre.Text = clsVarGlobal.User.cNomUsu;

                this.btnBuenaPro1.Enabled = false;
                this.btnAprobar.Enabled = true;
                this.btnExcepciones.Enabled = false;
                this.btnDenegar.Enabled = true;
            }
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim()),
                                                                        idUsuarioAprobador: this.idUsuarioAprobador,
                                                                        idPerfilAprobador: this.idPerfilAprobador);
                objGestionExcepcion.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nudPlazo_ValueChanged(object sender, EventArgs e)
        {
            if (this.cTipoPeriodo == "Fecha Fija")
            {
                int nDias = Convert.ToInt32(nudPlazo.Value);
                if (nDias > (int)clsVarApl.dicVarGen["nNumDiaPago"])
                {
                    nudPlazo.BackColor = Color.Red;
                }
            }
            else
            {
                nudPlazo.BackColor = SystemColors.Window;
            }
        }
        #endregion
        
        #region Metodos
        private bool validarAutorizacionDesembolso(int idSolicitud)
        {
            DataTable dtRespuestaServidor = nSoliDatos.validarAutorizacionDesembolso(idSolicitud);
            if (dtRespuestaServidor.Rows.Count > 0)
            {
                bool lAutorizado = Convert.ToBoolean(dtRespuestaServidor.Rows[0]["lAutorizado"]);
                string cMensaje = Convert.ToString(dtRespuestaServidor.Rows[0]["cMensaje"]);
                string cTitulo = Convert.ToString(dtRespuestaServidor.Rows[0]["cTitulo"]);

                if (!lAutorizado)
                {
                    MessageBox.Show(cMensaje, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return lAutorizado;
            }
            return false;
        }
        private void rellenarDatosSolicitud()
        {
            if (String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                this.limpiarControles();
                return; // regresa vacia
            }
            else
            {
                int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim());
                if (!this.validarAutorizacionDesembolso(idSolicitud)) return;

                btnAdministradorFiles1.idSolicitud = idSolicitud;
                btnAdministradorFiles1.actualizarDatos();
                dtSolicitud = nSoliDatos.ConsultaSolicitudAprobacion(idSolicitud);//consulta solicitud
                dtDatosNivelAprobacion = nSoliDatos.CargarDatosAprobadorCampana(idSolicitud);
                dtDatosValidacion = nSoliDatos.ObtenerDatosValidacionCampana(idSolicitud);
                int idOperacion = Convert.ToInt32(this.dtSolicitud.Rows[0]["idOperacion"]);
                int idTipoPlanPago = Convert.ToInt32(this.dtSolicitud.Rows[0]["idTipoPlanPago"]);

                this.ObtenerOfertaSolicitud(Convert.ToInt32(this.dtSolicitud.Rows[0]["idOferta"]));
                if (this.objOferta != null)
                {
                    if (this.objOferta.idTipoGrupoCamp == 1)
                    {
                        MessageBox.Show("Segmentación de Clientes: Cliente tiene una oferta Pre Aprobada, debe continuar con el proceso de Evaluación Resumida", "Validación de Garantía", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                #region Carga de Archivos
                DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(idSolicitud);
                #endregion

                #region ValidarContraDepositos
                clsListDetGarantia dtGarantias = new clsCNGarantia().listarGarVinculadasSol(idSolicitud);

                bool lEstado = true;
                string cMensaje = "Observaciones: \n";
                foreach (clsDetGarantia dtGrt in dtGarantias)
                {
                    if (Convert.ToBoolean(dtGrt.lReqCtaDep))
                    {
                        DataTable dtDeposito = new clsCNGarantia().CNValidaCuentaDeposito(Convert.ToInt32(dtGrt.idGarantia), Convert.ToDecimal(dtGrt.nMonGravado), idSolicitud);
                        if (!Convert.ToBoolean(dtDeposito.Rows[0]["lEstado"]) || !Convert.ToBoolean(dtDeposito.Rows[0]["lMonto"]))
                        {
                            lEstado = false;
                            cMensaje += "_ Garantía :" + dtGrt.idGarantia.ToString() + ", " + dtDeposito.Rows[0]["cMsgEstado"].ToString() + dtDeposito.Rows[0]["cMsgMonto"].ToString() + "\n";
                        }
                    }
                }
                if (!lEstado)
                {
                    MessageBox.Show(cMensaje, "Validación de Garantía", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                #endregion

                #region Autorizacin de Poliza
                DataTable dtValidacion = nSoliDatos.CNValidarAutorizacionPoliza(idSolicitud);
                bool lAutorizado = false;
                string cMensajeAutorizacionPoliza = "";
                if (dtValidacion.Rows.Count > 0)
                {
                    lAutorizado = Convert.ToInt32(dtValidacion.Rows[0]["idResultado"]) == 1 ? true : false;
                    cMensajeAutorizacionPoliza = dtValidacion.Rows[0]["cMensaje"].ToString();
                }
                #endregion

                if (!lAutorizado)
                {
                    MessageBox.Show(cMensajeAutorizacionPoliza, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiarControles();
                }
                else if (idOperacion == 5)
                {
                    MessageBox.Show("No puede Aprobar Cartas Fianza por este formulario", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiarControles();
                }
                if (!btnAdministradorFiles1.obligatoriosCompletos() &&
                    !idTipoPlanPago.In((int)TipoPlanPago.ReprogCuotaConstante, (int)TipoPlanPago.ReprogModifCalendario, (int)TipoPlanPago.ReprogPerdonDias, (int)TipoPlanPago.CalendarioInteresComp,
                     (int)TipoPlanPago.CambioTasa) && !validarExcepcionProductoCampaña())
                {
                    MessageBox.Show("REPORTES CENTRAL DE RIESGOS: La Solicitud no tiene cargado todos los Reportes Obligatorios de las Centrales de Riesgo \n Debe hacerlo mediante el formulario Registro de Solicitud de Créditos", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0 &&
                    !idTipoPlanPago.In((int)TipoPlanPago.ReprogCuotaConstante, (int)TipoPlanPago.ReprogModifCalendario, (int)TipoPlanPago.ReprogPerdonDias, (int)TipoPlanPago.CalendarioInteresComp,
                     (int)TipoPlanPago.CambioTasa) && !validarExcepcionProductoCampaña())
                {
                    MessageBox.Show(dtCargaArchivos.Rows[0]["cMsg"].ToString(), "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.txtOperacion.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cOperacion"]);
                    this.dtpFechaSol.Value = Convert.ToDateTime(this.dtSolicitud.Rows[0]["dFechaRegistro"]);
                    this.txtAsesor.Text = this.dtSolicitud.Rows[0]["cAsesor"].ToString();
                    this.cboNivelAprobacion1.SelectedValue = (DBNull.Value.Equals(this.dtSolicitud.Rows[0]["IdnivelAprobacion"])) ? 0 : Convert.ToInt32(this.dtSolicitud.Rows[0]["IdnivelAprobacion"]);
                    this.txtMonto.Text = this.dtSolicitud.Rows[0]["nCapitalSolicitado"].ToString();
                    this.txtMoneda.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cMoneda"]);
                    this.nudCuotas.Value = Convert.ToInt32(this.dtSolicitud.Rows[0]["nCuotas"]);
                    this.txtTipoPeriodo.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cDescripTipoPeriodo"]);
                    this.cTipoPeriodo = Convert.ToString(this.dtSolicitud.Rows[0]["cDescripTipoPeriodo"]);
                    this.nudPlazo.Value = Convert.ToInt32(this.dtSolicitud.Rows[0]["nPlazoCuota"]);
                    this.txtCuotasGracia.Text = Convert.ToString(this.dtSolicitud.Rows[0]["nCuotasGracia"]);
                    this.dtFechaDesembolso.Value = Convert.ToDateTime(this.dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"]);
                    this.nudDiasGracia.Value = Convert.ToInt32(this.dtSolicitud.Rows[0]["ndiasgracia"]);
                    this.txtDestino.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cDestino"]);
                    this.txtTasaCom.Text = Convert.ToString(this.dtSolicitud.Rows[0]["nTasaCompensatoria"]);
                    this.txtTem.Text = Convert.ToString(this.dtSolicitud.Rows[0]["nTEM"]);
                    this.txtTasaMora.Text = Convert.ToString(this.dtSolicitud.Rows[0]["nTasaMoratoria"]);
                    int idProducto = Convert.ToInt32(this.dtSolicitud.Rows[0]["idProducto"]);

                    this.conProducto3.cargarProductos(1, idProducto, idOperacion); // COMBO PRODUCTOS
                    /************DATOS APROBADOR *************/
                    this.txtPerfil.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cDescripcion"]);
                    this.txtNombre.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cNombreAprob"]);
                    this.txtEstado.Text = Convert.ToString(this.dtSolicitud.Rows[0]["cEstadoSol"]);
                    /******************************************/
                    int idEstado = Convert.ToInt32(this.dtSolicitud.Rows[0]["idEstado"]);
                    if (idEstado == 1)
                    {
                        this.btnBuenaPro1.Enabled = true;
                    }
                    else
                    {
                        this.btnBuenaPro1.Enabled = false;
                    }

                    if (ValidarClienteCampana())
                    {
                        CargarDatosAprobadorCampana(idSolicitud);
                    }

                    #region ValidarPDS
                    DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(idSolicitud);
                    if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
                    {
                        MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                } // fin else
            }
        }

        private void rellenarDatosAprobador(string NivelAprob, string PerfilN, string Nombre,int nivelAp,int idUsuApro)
        {

            this.txtPerfil.Text = PerfilN;
            this.txtNombre.Text = Nombre;
            this.cboNivelAprobacion1.SelectedValue = (DBNull.Value.Equals(nivelAp)) ? 0 : Convert.ToInt32(nivelAp);
         
        }

        private void CargarDatosAprobadorCampana(int idSolicitud)
        {
            if (dtDatosNivelAprobacion.Rows.Count == 0)
                return;

            string cNivelAprobacion = Convert.ToString(dtDatosNivelAprobacion.Rows[0]["cNivelAprobacion"]);
            string cPerfil = Convert.ToString(dtDatosNivelAprobacion.Rows[0]["cPerfil"]);
            string cNombre = Convert.ToString(dtDatosNivelAprobacion.Rows[0]["cNombre"]);
            int idNivelAprobacion = Convert.ToInt32(dtDatosNivelAprobacion.Rows[0]["idNivelAprobacion"]);
            this.idUsuarioAprobador = Convert.ToInt32(dtDatosNivelAprobacion.Rows[0]["idUsuario"]);
            this.idPerfilAprobador = Convert.ToInt32(dtDatosNivelAprobacion.Rows[0]["idPerfil"]);

            rellenarDatosAprobador(cNivelAprobacion, cPerfil, cNombre, idNivelAprobacion, this.idUsuarioAprobador);

            this.btnBuenaPro1.Enabled = false;
            this.btnAprobar.Enabled = true;
            this.btnExcepciones.Enabled = true;
            this.btnDenegar.Enabled = true;
        }

        private bool ValidarClienteCampana()
        {
            bool lValor = true;
            if (lValor && dtDatosValidacion.Rows.Count == 0)
                return false;
            return lValor;
        }

        private bool ValidarCondicionesCampana()
        {
            bool lValor = true;
            foreach (DataRow drFila in dtDatosValidacion.Rows)
            {
                lValor = (lValor && Convert.ToBoolean(drFila["lCumpleCondiciones"])) ? true : false;
            }
            return lValor;
        }

        private bool validarExcepcionProductoCampaña()
        {
            bool lValor = false;
            int idProductoSol = Convert.ToInt32(this.dtSolicitud.Rows[0]["idProducto"]);
            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable == "cListaProductoCampanaConsumo");
            List<int> lstProductoCampaña = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

            if (objVarGen == null)
                lValor = false;
            else if (lstProductoCampaña.Any(item => item == idProductoSol))
                lValor = true;
            else
                lValor = false;

            return lValor;
        }

        private void limpiarControles()
        {
            this.conBusCuentaCli1.limpiarControles();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.lblNroBuscar.Text = cLblSolicitud;
            this.conBusCuentaCli1.cEstado = "[1,2,4]";
            this.btnBuenaPro1.Enabled = false;
            this.btnAprobar.Enabled = false;
            this.btnExcepciones.Enabled = false;
            this.btnDenegar.Enabled = false;
            this.idUsuarioAprobador = 0;
            int nIdUsuarioModifica = clsVarGlobal.User.idUsuario;
            DateTime dFechaMod = clsVarGlobal.dFecSystem; // dfechamod
            nCountClick = 0;
            cTipoPeriodo = String.Empty;
            nudPlazo.Value = 0;
        }

        private void aprobardenegar(int idEstado)
        {
            if (String.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text.Trim()))
            {
                return;
            }
            else
            {
                int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim());

                int idnivelAprobacion = Convert.ToInt32(this.cboNivelAprobacion1.SelectedValue);
                clsDBResp objDbResp = new clsCNSolicitud().CNAprobacionesSolicitud(idSolicitud, idEstado, idnivelAprobacion, idUsuarioAprobador, nIdUsuarioModifica, dFechaMod);
                if (objDbResp.nMsje == 0)
                {
                    //Recupera informacion para Posicion consilidada antes de congelar
                    DataTable didDescTipoDoc = clsExpedienteNegocio.obtenerIdentificaridDescTipoDoc();

                    DataSet dExpedientes = clsExpedienteNegocio.getGrupoExpedienteLinea("Posicion consolidada de Cliente", Convert.ToInt32(dtDatosSolCred.Rows[0]["idSolicitud"]), "individual");
                    DataTable dtLeerTablaExpediente = dExpedientes.Tables[0];


                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information); //ACEPTADA SOLICITUD
                    /*  Guardar Expedientes - Solicitud de Credito  */
                    clsProcesoExp.guardarCopiaExpediente("Solicitud de Credito", idSolicitud, this);

                    bool lPosConsolidadaExterno = false;
                    if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("lPosConsolidadaExterno")))
                    {
                        clsVarGen objVarPosConsolidada = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("lPosConsolidadaExterno"));
                        lPosConsolidadaExterno = Convert.ToBoolean(objVarPosConsolidada.cValVar);
                }

                    if (lPosConsolidadaExterno)
                    {
                    clsCNIntervCre IntervCre = new clsCNIntervCre();
                    DataTable dtLisIntervSol = IntervCre.obtenerIntervinienteSolicitud(idSolicitud, clsVarGlobal.idModulo, true, true);

                    foreach (DataRow row in dtLisIntervSol.Rows)
                    {
                        int idCliSel = Convert.ToInt32(row["idCli"]);
                        string cDocumentoSel = Convert.ToString(row["cDocumentoID"]);
                        /*  Guardar Expedientes - Posicion Consolidada - Congelamiento */
                        dExpedientes.Tables[0].Rows[0]["idSecundario"] = idCliSel;
                        SentinelPosicionConsolidada(idCliSel, cDocumentoSel);
                        clsProcesoExp.guardarCopiaExpedientePosicionConsolidada(Convert.ToInt32(didDescTipoDoc.Rows[0]["idDescTipoDoc"]), cTipoSolicitud, idCliSel, "Posicion consolidada de Cliente", idSolicitud, this, dsContenedorConsolidada, dExpedientes);
                    }
                    }
                  
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning); // LA SOLICITUD YA ESTA APROBADA / DENEGADA
                }
            }
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli1.txtNroBusqueda.Text != "")
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text), true);
                frmCargaArchivo.ShowDialog();
                nCountClick++;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Solicitud", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ObtenerOfertaSolicitud(int idOferta)
        {
            ClsCNClienteExclusivo objCliExclu = new ClsCNClienteExclusivo();
            DataTable dt = objCliExclu.CNObtenerOfertaClienteOferta(idOferta);
            if (dt.Rows.Count == 0)
                return;

            this.objOferta = DataTableToList.ConvertTo<ClsOfertaClienteExclusivo>(dt).ToList<ClsOfertaClienteExclusivo>()[0];
        }

        private bool validarReglas(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametroReglas = armarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglasCreditos(dtTablaParametros: dtParametroReglas,
                                                                            cNombreFormulario: this.Name,
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idCli"]),
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["IdMoneda"]),
                                                                            idProducto: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idProducto"]),
                                                                            nValAproba: Convert.ToDecimal(this.dtDatosSolCred.Rows[0]["nCapitalPropuesto"]),
                                                                            idDocument: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idSolicitud"]),
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 2,
                                                                            idEstadoSol: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idEstado"]),
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto, 
                                                                            lMostrarAlerta: lMostrarAlerta,
                                                                            idRegistroExcep: Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idSolicitud"]));
            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private DataTable armarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idCli"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idSolicitud"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDetGasto";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idDetalleGasto"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idTipoPeriodo"]);
            dtTablaParametros.Rows.Add(drfila);

            int nPlazoTotal = nSoliDatos.ObtieneTotalDias(Convert.ToDateTime(this.dtDatosSolCred.Rows[0]["dFechaDesembolsoSugerido"]),
                Convert.ToInt32(this.dtDatosSolCred.Rows[0]["nCuotas"]),
                Convert.ToInt32(this.dtDatosSolCred.Rows[0]["ndiasgracia"]),
                Convert.ToInt32(this.dtDatosSolCred.Rows[0]["idTipoPeriodo"]),
                Convert.ToInt32(this.dtDatosSolCred.Rows[0]["nPlazoCuota"]));

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = nPlazoTotal;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["nCuotas"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoCuota";
            drfila[1] = Convert.ToInt32(this.dtDatosSolCred.Rows[0]["nPlazoCuota"]);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        private void verficarOpinionRiesgos()
        {
            clsCNSolicitud opinionRiesgos = new clsCNSolicitud();
            DataTable dtOpinionRiesgos = opinionRiesgos.CNVerificaOpinionRiesgo(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text.Trim()));
            List<int> listFavorable = new List<int>() { 1, 3 };
            List<int> listDesFavorable = new List<int>() { 0, 2, 4};
            if (listFavorable.Contains(Convert.ToInt32(dtOpinionRiesgos.Rows[0]["nEstado"])))
            {
                cMensajeRiesgos = dtOpinionRiesgos.Rows[0]["cMensaje"].ToString();
                nEstadoRiesgos = 0;
            }
            else if (listDesFavorable.Contains(Convert.ToInt32(dtOpinionRiesgos.Rows[0]["nEstado"])))
            {
                cMensajeRiesgos = dtOpinionRiesgos.Rows[0]["cMensaje"].ToString();
                nEstadoRiesgos = 1;
            }
        }
        public void SentinelPosicionConsolidada(int idCliSeleccion, string cDocumentoIDSel)
        {
            dsContenedorConsolidada = new DataSet();


            if (idCliSeleccion.ToString() != string.Empty)
            {

                GEN.CapaNegocio.clsCNBuscarCli listarCli = new GEN.CapaNegocio.clsCNBuscarCli();
                DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(idCliSeleccion));

                cidTipoDocumento = tablaCli.Rows[0]["idTipoDocumento"].ToString();

                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);

                if (nidTipoPersona == 1)
                {
                    cTipoPersona = "N";
                }
                if (nidTipoPersona == 2 || nidTipoPersona == 3)
                {
                    cTipoPersona = "J";
                }

                DataTable dResultadoReglaConciones = ValidaReglasDinamicas.ValidarReglasCondiciones(ArmarTablaParametrosPosicionConsolidada(idCliSeleccion, cDocumentoIDSel, cidTipoDocumento), "frmPosConCliente", cTipoPersona);

                DataTable dResumenCondiciones = new DataTable();
                dResumenCondiciones = GeneraResumenCondiciones(dResultadoReglaConciones);
                dsContenedorConsolidada.Tables.Add(dResumenCondiciones.Copy());

                DataTable dRastreo = new DataTable();

                dRastreo = cninterviniente.CNdtLstRastreoPosicionConsolidada(cDocumentoIDSel);
                dRastreo.TableName = "dtRastreo";

                dsContenedorConsolidada.Tables.Add(dRastreo.Copy());

                objLisTituConyuge = new List<TitularConyuge>();
                //Clasificacion Cliente

                dtClasificacionCliente = objCE.CNObtenerClasificacionTitularConyuge(cDocumentoIDSel, Convert.ToInt32(cidTipoDocumento));
                for (int i = 0; i < dtClasificacionCliente.Rows.Count; i++)
                {
                    TitularConyuge modelTituConyuge = new TitularConyuge();
                    modelTituConyuge.cCondicion = dtClasificacionCliente.Rows[i]["cCondicion"].ToString();
                    modelTituConyuge.ctipoDocumento = dtClasificacionCliente.Rows[i]["ctipoDocumento"].ToString();
                    modelTituConyuge.cnombre = dtClasificacionCliente.Rows[i]["cnombre"].ToString();
                    modelTituConyuge.cNumDocumento = dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString();
                    modelTituConyuge.idCli = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idCli"].ToString());
                    modelTituConyuge.cCalificacion = dtClasificacionCliente.Rows[i]["cCalificacion"].ToString();
                    modelTituConyuge.cEstadoCivil = dtClasificacionCliente.Rows[i]["cEstadoCivil"].ToString();
                    modelTituConyuge.cEdad = dtClasificacionCliente.Rows[i]["cEdad"].ToString();
                    modelTituConyuge.cTipoCliente = dtClasificacionCliente.Rows[i]["cTipoCliente"].ToString();
                    modelTituConyuge.idTipoDocumento = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idTipoDocumento"].ToString());


                    if (cTipoPersona == "N")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "D");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            modelTituConyuge.cRelNDoc = (objRespuesta.Data[0].InfBas == null) ? String.Empty : objRespuesta.Data[0].InfBas.RelNDoc;
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                        }
                        else
                        {
                            objRespuestaConyuge = objRespuesta;
                        }

                    }

                    if (cTipoPersona == "J")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "R");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                        }
                    }
                    if (objRespuesta.Data.Count == 0)
                    {
                        MessageBox.Show("Existe caida del Servicio Sentinel, Comunicarse con el departamento de sistemas", "Sentinel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        modelTituConyuge.PuntajeScore = "";
                        modelTituConyuge.nRiesgo = "";
                        modelTituConyuge.CapacidadPago = "";
                        modelTituConyuge.cRelNDoc = "";
                        objLisTituConyuge.Add(modelTituConyuge);

                        dtClasTitularConyuge.Clear();
                        for (int j = 0; j < objLisTituConyuge.Count; j++)
                        {
                            DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                            rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[j].cCondicion;
                            rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[j].idTipoDocumento);
                            rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[j].ctipoDocumento;
                            rowClasTitularConyuge["cnombre"] = objLisTituConyuge[j].cnombre;
                            rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[j].cNumDocumento;
                            rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[j].idCli);
                            rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[j].cCalificacion;
                            rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[j].cEstadoCivil;
                            rowClasTitularConyuge["cEdad"] = objLisTituConyuge[j].cEdad;
                            rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[j].cRelNDoc;
                            rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[j].cTipoCliente;

                            dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                        }

                        dsContenedorConsolidada.Tables.Add(dtBasicoSunatTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBasicoSunatConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBSunatDireccionTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBSunatDireccionConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtRlegalTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtRlegalConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtClasTitularConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtMicrTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtMicrConyuge.Copy());
                        DataTable dtCombinedDeudaSentinelVacio = new DataTable("dtDeudaSentinelDirectaTitular");
                        if (dtDeudaSentinelDirectaTitular != null)
                        {
                            dtCombinedDeudaSentinelVacio = dtDeudaSentinelDirectaTitular.Copy();
                        }

                        if (dtDeudaSentinelDirectaConyuge != null)
                        {
                            dtCombinedDeudaSentinelVacio.Merge(dtDeudaSentinelDirectaConyuge);
                        }

                        dsContenedorConsolidada.Tables.Add(dtCombinedDeudaSentinelVacio.Copy());

                        DataTable dtCombinedLineaCreditoSentinelVacio = new DataTable("dtlCredNoUtilizadaT");
                        if (dtlCredNoUtilizadaT != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio = dtlCredNoUtilizadaT.Copy();
                        }
                        if (dtlCredNoUtilizadaC != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio.Merge(dtlCredNoUtilizadaC);
                        }

                        dsContenedorConsolidada.Tables.Add(dtCombinedLineaCreditoSentinelVacio.Copy());

                        DataTable dtCombinedVencidoSentinelVacio = new DataTable("dtDeudaTitular");
                        if (dtDeudaTitular != null)
                        {
                            dtCombinedVencidoSentinelVacio = dtDeudaTitular.Copy();
                        }
                        if (dtDeudaConyuge != null)
                        {
                            dtCombinedVencidoSentinelVacio.Merge(dtDeudaConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedVencidoSentinelVacio.Copy());

                        DataTable dtCombinedAvalistaSentinelVacio = new DataTable("dtAvalistaTitular");
                        if (dtAvalistaTitular != null)
                        {
                            dtCombinedAvalistaSentinelVacio = dtAvalistaTitular.Copy();
                        }
                        if (dtAvalistaConyuge != null)
                        {
                            dtCombinedAvalistaSentinelVacio.Merge(dtAvalistaConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedAvalistaSentinelVacio.Copy());

                        DataTable dtCombinedAvaladoSentinelVacio = new DataTable("dtAvalado");
                        if (dtAvalado != null)
                        {
                            dtCombinedAvaladoSentinelVacio = dtAvalado.Copy();
                        }
                        if (dtAvaladoConyuge != null)
                        {
                            dtCombinedAvaladoSentinelVacio.Merge(dtAvaladoConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedAvaladoSentinelVacio.Copy());
                        dsContenedorConsolidada.Tables.Add(dtHistorialSentinelTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtHistorialSentinelConyuge.Copy());
                        return;
                    }
                    objLisTituConyuge.Add(modelTituConyuge);
                }
                dtClasTitularConyuge.Clear();
                for (int i = 0; i < objLisTituConyuge.Count; i++)
                {
                    DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                    rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[i].cCondicion;
                    rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[i].idTipoDocumento);
                    rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[i].ctipoDocumento;
                    rowClasTitularConyuge["cnombre"] = objLisTituConyuge[i].cnombre;
                    rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[i].cNumDocumento;
                    rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[i].idCli);
                    rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[i].cCalificacion;
                    rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[i].cEstadoCivil;
                    rowClasTitularConyuge["cEdad"] = objLisTituConyuge[i].cEdad;
                    rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[i].cRelNDoc;
                    rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[i].cTipoCliente;


                    dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtBasicoSunatTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtBasicoSunatConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtBSunatDireccionTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtBSunatDireccionConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtRlegalTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtRlegalConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtClasTitularConyuge.Copy());
                
                DataTable dtCombinedDeudaSentinel = new DataTable("dtDeudaSentinelDirectaTitular");
                if (dtDeudaSentinelDirectaTitular != null)
                {
                    dtCombinedDeudaSentinel = dtDeudaSentinelDirectaTitular.Copy();
                }

                if (dtDeudaSentinelDirectaConyuge != null)
                {
                    dtCombinedDeudaSentinel.Merge(dtDeudaSentinelDirectaConyuge);
                }

                dsContenedorConsolidada.Tables.Add(dtCombinedDeudaSentinel.Copy());

                DataTable dtCombinedLineaCreditoSentinel = new DataTable("dtlCredNoUtilizadaT");
                if (dtlCredNoUtilizadaT != null)
                {
                    dtCombinedLineaCreditoSentinel = dtlCredNoUtilizadaT.Copy();
                }
                if (dtlCredNoUtilizadaC != null)
                {
                    dtCombinedLineaCreditoSentinel.Merge(dtlCredNoUtilizadaC);
                }

                dsContenedorConsolidada.Tables.Add(dtCombinedLineaCreditoSentinel.Copy());

                DataTable dtCombinedVencidoSentinel = new DataTable("dtDeudaTitular");
                if (dtDeudaTitular != null)
                {
                    dtCombinedVencidoSentinel = dtDeudaTitular.Copy();
                }
                if (dtDeudaConyuge != null)
                {
                    dtCombinedVencidoSentinel.Merge(dtDeudaConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedVencidoSentinel.Copy());

                DataTable dtCombinedAvalistaSentinel = new DataTable("dtAvalistaTitular");
                if (dtAvalistaTitular != null)
                {
                    dtCombinedAvalistaSentinel = dtAvalistaTitular.Copy();
                }
                if (dtAvalistaConyuge != null)
                {
                    dtCombinedAvalistaSentinel.Merge(dtAvalistaConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedAvalistaSentinel.Copy());

                DataTable dtCombinedAvaladoSentinel = new DataTable("dtAvalado");
                if (dtAvalado != null)
                {
                    dtCombinedAvaladoSentinel = dtAvalado.Copy();
                }
                if (dtAvaladoConyuge != null)
                {
                    dtCombinedAvaladoSentinel.Merge(dtAvaladoConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedAvaladoSentinel.Copy());

                HistoricoSentinel_Titular();
                HistoricoSentinel_Conyuge();

                dsContenedorConsolidada.Tables.Add(dtHistorialSentinelTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtHistorialSentinelConyuge.Copy());

                if (objRespuestaTitular.Data != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaTitular.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrTitular = dtMicrTitular.NewRow();
                        rowMicrTitular["Condicion"] = "Titular";
                        rowMicrTitular["NomEnt"] = "DEUDA TOTAL";
                        rowMicrTitular["Cal"] = "SCAL";
                        rowMicrTitular["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrTitular["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrTitular["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrTitular["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrTitular["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrTitular.Rows.Add(rowMicrTitular);
                    }
                }

                if (objRespuestaConyuge != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaConyuge.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrConyuge = dtMicrConyuge.NewRow();
                        rowMicrConyuge["Condicion"] = "Conyuge";
                        rowMicrConyuge["NomEnt"] = "DEUDA TOTAL";
                        rowMicrConyuge["Cal"] = "SCAL";
                        rowMicrConyuge["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrConyuge["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrConyuge["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrConyuge["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrConyuge["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrConyuge.Rows.Add(rowMicrConyuge);
                    }
                }

                dsContenedorConsolidada.Tables.Add(dtMicrTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtMicrConyuge.Copy());
            }

        }
        public void DatosBasicoSunat(DataSenInfBasica dataBasicoSunat, string CondicionTitularConyuge)
        {
            List<DataSenInfBasica> ListaSunatInfoSentinelTitular = new List<DataSenInfBasica>();
            if (dataBasicoSunat != null)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBasicoSunatTitular.Clear();
                            DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                            rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);
                            break;
                        case "Conyuge":
                            dtBasicoSunatConyuge.Clear();
                            DataRow rowBasicoSunatConyuge = dtBasicoSunatConyuge.NewRow();

                            rowBasicoSunatConyuge["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatConyuge["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatConyuge["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatConyuge["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatConyuge["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatConyuge["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatConyuge["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatConyuge["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatConyuge["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatConyuge["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatConyuge["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatConyuge["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatConyuge["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatConyuge["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatConyuge["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatConyuge["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatConyuge.Rows.Add(rowBasicoSunatConyuge);
                            break;

                    }
                }
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBasicoSunatTitular.Clear();
                    DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                    rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                    rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                    rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                    rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                    rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                    rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                    rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                    rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                    rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                    rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                    rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                    rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                    rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                    rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                    rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                    rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                    dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);

                }

            }
        }
        public void DatosBasicoSunatDireccion(List<DataSenInfGenDirecc> dataBasicaDireccion, string CondicionTitularConyuge)
        {
            if (dataBasicaDireccion.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBSunatDireccionTitular.Clear();
                            for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                            {
                                DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                                rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                                rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                                dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                            }


                            break;
                        case "Conyuge":
                            dtBSunatDireccionConyuge.Clear();
                            for (int iDireccSunatC = 0; iDireccSunatC < dataBasicaDireccion.Count; iDireccSunatC++)
                            {
                                DataRow rowBSunatDireccionConyuge = dtBSunatDireccionConyuge.NewRow();
                                rowBSunatDireccionConyuge["Direccion"] = dataBasicaDireccion[iDireccSunatC].Direccion;
                                rowBSunatDireccionConyuge["Fuente"] = dataBasicaDireccion[iDireccSunatC].Fuente;
                                dtBSunatDireccionConyuge.Rows.Add(rowBSunatDireccionConyuge);
                            }

                            break;
                    }
                }
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBSunatDireccionTitular.Clear();
                    for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                    {
                        DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                        rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                        rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                        dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                    }

                }


            }
        }
        public void DatosBasicoSunatRLegal(List<DataSenInfGenEsRepLeg> EsRepLegDe, List<DataSenInfGenRepLeg> ListRepLeg, string CondicionTitularConyuge)
        {
            if (EsRepLegDe.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtRlegalTitular.Clear();
                            for (int iRlegalTitular = 0; iRlegalTitular < EsRepLegDe.Count; iRlegalTitular++)
                            {
                                DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                                rowRlegalTitular["TDOC"] = EsRepLegDe[iRlegalTitular].TDOC;
                                rowRlegalTitular["NDOC"] = EsRepLegDe[iRlegalTitular].NDOC.ToString();
                                rowRlegalTitular["Nombre"] = EsRepLegDe[iRlegalTitular].RazSoc.ToString();
                                rowRlegalTitular["FecIniCar"] = EsRepLegDe[iRlegalTitular].FecIniCar.ToString();
                                rowRlegalTitular["Cargo"] = EsRepLegDe[iRlegalTitular].Cargo.ToString();
                                dtRlegalTitular.Rows.Add(rowRlegalTitular);
                            }

                            break;
                        case "Conyuge":
                            dtRlegalConyuge.Clear();
                            for (int iRlegalConyuge = 0; iRlegalConyuge < EsRepLegDe.Count; iRlegalConyuge++)
                            {
                                DataRow rowRlegalConyuge = dtRlegalConyuge.NewRow();

                                rowRlegalConyuge["TDOC"] = EsRepLegDe[iRlegalConyuge].TDOC;
                                rowRlegalConyuge["NDOC"] = EsRepLegDe[iRlegalConyuge].NDOC.ToString();
                                rowRlegalConyuge["Nombre"] = EsRepLegDe[iRlegalConyuge].RazSoc.ToString();
                                rowRlegalConyuge["FecIniCar"] = EsRepLegDe[iRlegalConyuge].FecIniCar.ToString();
                                rowRlegalConyuge["Cargo"] = EsRepLegDe[iRlegalConyuge].Cargo.ToString();
                                dtRlegalConyuge.Rows.Add(rowRlegalConyuge);
                            }
                            break;
                    }
                }
            }
            if (ListRepLeg.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtRlegalTitular.Clear();
                    for (int iRlegalTitular = 0; iRlegalTitular < ListRepLeg.Count; iRlegalTitular++)
                    {
                        DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                        rowRlegalTitular["TDOC"] = ListRepLeg[iRlegalTitular].TDOC;
                        rowRlegalTitular["NDOC"] = ListRepLeg[iRlegalTitular].NDOC.ToString();
                        rowRlegalTitular["Nombre"] = ListRepLeg[iRlegalTitular].Nombre.ToString();
                        rowRlegalTitular["FecIniCar"] = ListRepLeg[iRlegalTitular].FecIniCar.ToString();
                        rowRlegalTitular["Cargo"] = ListRepLeg[iRlegalTitular].Cargo.ToString();
                        dtRlegalTitular.Rows.Add(rowRlegalTitular);
                    }


                }
            }
        }
        public void DatosBasicoLineaCredito(List<DataSenConBasUtiLinCre> UtiLinCre, string CondicionTitularConyuge)
        {
            if (UtiLinCre.Count > 0)
            {

                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtlCredNoUtilizadaT.Clear();
                        for (int iLCredNoUtili = 0; iLCredNoUtili < UtiLinCre.Count; iLCredNoUtili++)
                        {
                            DataRow rowlCredNoUtilizadaT = dtlCredNoUtilizadaT.NewRow();
                            rowlCredNoUtilizadaT["Condicion"] = "Titular";
                            rowlCredNoUtilizadaT["Inst"] = UtiLinCre[iLCredNoUtili].Inst;
                            rowlCredNoUtilizadaT["LinApr"] = UtiLinCre[iLCredNoUtili].LinApr.ToString();
                            rowlCredNoUtilizadaT["LinNoUti"] = UtiLinCre[iLCredNoUtili].LinNoUti.ToString();
                            rowlCredNoUtilizadaT["LinUti"] = UtiLinCre[iLCredNoUtili].LinUti.ToString();
                            rowlCredNoUtilizadaT["TipCred"] = UtiLinCre[iLCredNoUtili].TipCred.ToString();
                            dtlCredNoUtilizadaT.Rows.Add(rowlCredNoUtilizadaT);
                        }

                        break;
                    case "Conyuge":
                        dtlCredNoUtilizadaC.Clear();
                        for (int iLCredNoUtiliConyuge = 0; iLCredNoUtiliConyuge < UtiLinCre.Count; iLCredNoUtiliConyuge++)
                        {
                            DataRow rowlCredNoUtilizadaC = dtlCredNoUtilizadaC.NewRow();
                            rowlCredNoUtilizadaC["Condicion"] = "Cónyuge";
                            rowlCredNoUtilizadaC["Inst"] = UtiLinCre[iLCredNoUtiliConyuge].Inst;
                            rowlCredNoUtilizadaC["LinApr"] = UtiLinCre[iLCredNoUtiliConyuge].LinApr.ToString();
                            rowlCredNoUtilizadaC["LinNoUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinNoUti.ToString();
                            rowlCredNoUtilizadaC["LinUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinUti.ToString();
                            rowlCredNoUtilizadaC["TipCred"] = UtiLinCre[iLCredNoUtiliConyuge].TipCred.ToString();
                            dtlCredNoUtilizadaC.Rows.Add(rowlCredNoUtilizadaC);
                        }

                        break;
                }
            }

        }
        public void DatosDeudaProtesto(List<DataSenConBasVen> ListProtestoDeuLaboralSentinel, string CondicionTitularConyuge)
        {
            if (ListProtestoDeuLaboralSentinel != null)
            {
                if (ListProtestoDeuLaboralSentinel.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtDeudaTitular.Clear();

                            for (int iDeudaTitular = 0; iDeudaTitular < ListProtestoDeuLaboralSentinel.Count; iDeudaTitular++)
                            {
                                for (int iVenciDeudaTitular = 0; iVenciDeudaTitular < ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos.Count; iVenciDeudaTitular++)
                                {
                                    DataRow rowDeudaTitular = dtDeudaTitular.NewRow();
                                    rowDeudaTitular["Condicion"] = "Titular";
                                    rowDeudaTitular["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].IdFue;
                                    rowDeudaTitular["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].MaxDiaVen.ToString();
                                    rowDeudaTitular["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].NomFue.ToString();
                                    rowDeudaTitular["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].VenTot.ToString();
                                    rowDeudaTitular["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NomEnt.ToString();
                                    rowDeudaTitular["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].MontDeu.ToString();
                                    rowDeudaTitular["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].DiaVen.ToString();
                                    rowDeudaTitular["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NumDoc.ToString();

                                    dtDeudaTitular.Rows.Add(rowDeudaTitular);
                                }
                            }

                            break;
                        case "Conyuge":
                            dtDeudaConyuge.Clear();

                            for (int iDeudaConyuge = 0; iDeudaConyuge < ListProtestoDeuLaboralSentinel.Count; iDeudaConyuge++)
                            {
                                for (int iVenciDeudaConyuge = 0; iVenciDeudaConyuge < ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos.Count; iVenciDeudaConyuge++)
                                {
                                    DataRow rowDeudaConyuge = dtDeudaConyuge.NewRow();
                                    rowDeudaConyuge["Condicion"] = "Cónyuge";
                                    rowDeudaConyuge["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].IdFue;
                                    rowDeudaConyuge["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].MaxDiaVen.ToString();
                                    rowDeudaConyuge["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].NomFue.ToString();
                                    rowDeudaConyuge["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].VenTot.ToString();

                                    rowDeudaConyuge["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NomEnt.ToString();
                                    rowDeudaConyuge["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].MontDeu.ToString();
                                    rowDeudaConyuge["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].DiaVen.ToString();
                                    rowDeudaConyuge["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NumDoc.ToString();
                                    dtDeudaConyuge.Rows.Add(rowDeudaConyuge);

                                }

                            }


                            break;
                    }
                }
            }
        }
        public void DatosAvalista(List<DataSenAvalDe> LisAvalista, string CondicionTitularConyuge)
        {
            if (LisAvalista != null)
            {
                if (LisAvalista.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {

                        case "Titular":
                            dtAvalistaTitular.Clear();

                            for (int iAvalista = 0; iAvalista < LisAvalista.Count; iAvalista++)
                            {
                                for (int iAcredorAvalista = 0; iAcredorAvalista < LisAvalista[iAvalista].Acreedor.Count; iAcredorAvalista++)
                                {
                                    DataRow rowAvalistaTitular = dtAvalistaTitular.NewRow();
                                    rowAvalistaTitular["Condicion"] = "Titular";
                                    rowAvalistaTitular["NDoc"] = LisAvalista[iAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSoc"] = LisAvalista[iAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Sem12Mes"] = LisAvalista[iAvalista].Sem12Mes.ToString();
                                    rowAvalistaTitular["SemAct"] = LisAvalista[iAvalista].SemAct.ToString();
                                    rowAvalistaTitular["SemPre"] = LisAvalista[iAvalista].SemPre.ToString();
                                    rowAvalistaTitular["NDocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Cal"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].Cal.ToString();
                                    rowAvalistaTitular["SalDeu"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].SalDeu.ToString();
                                    rowAvalistaTitular["TipEnt"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].TipEnt.ToString();
                                    rowAvalistaTitular["FecRep"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].FecRep.ToString();

                                    dtAvalistaTitular.Rows.Add(rowAvalistaTitular);

                                }
                            }


                            break;
                        case "Conyuge":
                            dtAvalistaConyuge.Clear();

                            for (int iAvalistaConyuge = 0; iAvalistaConyuge < LisAvalista.Count; iAvalistaConyuge++)
                            {
                                for (int iAcredorAvalistaConyuge = 0; iAcredorAvalistaConyuge < LisAvalista[iAvalistaConyuge].Acreedor.Count; iAcredorAvalistaConyuge++)
                                {
                                    DataRow rowAvalistaConyuge = dtAvalistaConyuge.NewRow();
                                    rowAvalistaConyuge["Condicion"] = "Cónyuge";
                                    rowAvalistaConyuge["NDoc"] = LisAvalista[iAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSoc"] = LisAvalista[iAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Sem12Mes"] = LisAvalista[iAvalistaConyuge].Sem12Mes.ToString();
                                    rowAvalistaConyuge["SemAct"] = LisAvalista[iAvalistaConyuge].SemAct.ToString();
                                    rowAvalistaConyuge["SemPre"] = LisAvalista[iAvalistaConyuge].SemPre.ToString();

                                    rowAvalistaConyuge["NDocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Cal"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].Cal.ToString();
                                    rowAvalistaConyuge["SalDeu"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].SalDeu.ToString();
                                    rowAvalistaConyuge["TipEnt"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].TipEnt.ToString();
                                    rowAvalistaConyuge["FecRep"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].FecRep.ToString();
                                    dtAvalistaConyuge.Rows.Add(rowAvalistaConyuge);

                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosAvalado(List<DataSenAvalPor> Listavalado, string CondicionTitularConyuge)
        {
            if (Listavalado != null)
            {
                if (Listavalado.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":

                            dtAvalado.Clear();

                            for (int iAvalado = 0; iAvalado < Listavalado.Count; iAvalado++)
                            {
                                for (int iAcreedorTitular = 0; iAcreedorTitular < Listavalado[iAvalado].Acreedor.Count; iAcreedorTitular++)
                                {
                                    rowAvaladoTitular = dtAvalado.NewRow();
                                    rowAvaladoTitular["Condicion"] = "Titular";
                                    rowAvaladoTitular["ndoc"] = Listavalado[iAvalado].NDoc.ToString();
                                    rowAvaladoTitular["tDoc"] = Listavalado[iAvalado].TDoc.ToString();
                                    rowAvaladoTitular["razSoc"] = Listavalado[iAvalado].RazSoc.ToString();
                                    rowAvaladoTitular["semAct"] = Listavalado[iAvalado].SemAct.ToString();
                                    rowAvaladoTitular["Sem12Mes"] = Listavalado[iAvalado].Sem12Mes.ToString();
                                    rowAvaladoTitular["tDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TDoc.ToString();
                                    rowAvaladoTitular["nDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].NDoc.ToString();
                                    rowAvaladoTitular["razSocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].RazSoc.ToString();
                                    rowAvaladoTitular["cal"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].Cal.ToString();
                                    rowAvaladoTitular["tipEnt"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TipEnt.ToString();
                                    rowAvaladoTitular["salDeu"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].SalDeu.ToString();
                                    rowAvaladoTitular["fecRep"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].FecRep.ToString();

                                    dtAvalado.Rows.Add(rowAvaladoTitular);
                                }

                            }

                            break;
                        case "Conyuge":

                            dtAvaladoConyuge.Clear();

                            for (int iAvaladoConyuge = 0; iAvaladoConyuge < Listavalado.Count; iAvaladoConyuge++)
                            {

                                for (int iAcreedorConyuge = 0; iAcreedorConyuge < Listavalado[iAvaladoConyuge].Acreedor.Count; iAcreedorConyuge++)
                                {
                                    rowAvaladoConyuge = dtAvaladoConyuge.NewRow();
                                    rowAvaladoConyuge["Condicion"] = "Cónyuge";
                                    rowAvaladoConyuge["ndoc"] = Listavalado[iAvaladoConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["tDoc"] = Listavalado[iAvaladoConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["razSoc"] = Listavalado[iAvaladoConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["semAct"] = Listavalado[iAvaladoConyuge].SemAct.ToString();
                                    rowAvaladoConyuge["Sem12Mes"] = Listavalado[iAvaladoConyuge].Sem12Mes.ToString();

                                    rowAvaladoConyuge["tDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["nDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["razSocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["cal"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].Cal.ToString();
                                    rowAvaladoConyuge["tipEnt"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TipEnt.ToString();
                                    rowAvaladoConyuge["salDeu"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].SalDeu.ToString();
                                    rowAvaladoConyuge["fecRep"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].FecRep.ToString();
                                    dtAvaladoConyuge.Rows.Add(rowAvaladoConyuge);


                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosDeudaDirecta(List<DataSenConBasSBSMicr> DetSBSMicr, string CondicionTitularConyuge)
        {
            if (objRespuesta.Data[0].ConRap.DetSBSMicr.Count > 0)
            {
                DetSBSMicr = objRespuesta.Data[0].ConRap.DetSBSMicr;

                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtMicrTitular.Clear();
                        dtDeudaSentinelDirectaTitular = new DataTable("dtDeudaSentinelDirectaTitular");
                        for (int iSBSMicro = 0; iSBSMicro < DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();

                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrTitular["Cal"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrTitular["SalDeu"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrTitular["DiaVen"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrTitular["FchPro"] = fechaformateada(DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrTitular["FchRep"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrTitular["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 
 
                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }
                            if (DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();
                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = "";
                                rowMicrTitular["Cal"] = "SCAL";
                                rowMicrTitular["SalDeu"] = 0;
                                rowMicrTitular["DiaVen"] = 0;
                                rowMicrTitular["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrTitular["FchRep"] = "";
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrTitular["DeudaTotal"] = 0; 

                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }

                        }
                        cSemaforoTitular = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicr = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();

                        if (dtExisteDataMesAnioSBSMicr)
                        {
                            dtDeudaSentinelDirectaTitular = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaTitular.TableName = "dtDeudaSentinelDirectaTitular";
                        }

                        break;
                    case "Conyuge":
                        dtMicrConyuge.Clear();
                        dtDeudaSentinelDirectaConyuge = new DataTable("dtDeudaSentinelDirectaConyuge");
                        for (int iSBSMicro = 0; iSBSMicro < objRespuesta.Data[0].ConRap.DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrConyuge["Cal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrConyuge["SalDeu"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrConyuge["DiaVen"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrConyuge["FchRep"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrConyuge["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                            if (objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = "";
                                rowMicrConyuge["Cal"] = "SCAL";
                                rowMicrConyuge["SalDeu"] = 0;
                                rowMicrConyuge["DiaVen"] = 0;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrConyuge["FchRep"] = "";
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM"); 
                                rowMicrConyuge["DeudaTotal"] = 0; 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                        }
                        cSemaforoConyuge = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicrConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();
                        if (dtExisteDataMesAnioSBSMicrConyuge)
                        {
                            dtDeudaSentinelDirectaConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaConyuge.TableName = "dtDeudaSentinelDirectaConyuge";
            
                        }

                        break;
                }
            }
        }
        public void HistoricoSentinel_Titular()
        {
            if (dtMicrTitular.Rows.Count > 0)
            {
                dtHistorialSentinelTitular.Clear();
                var dataTitular = dtMicrTitular.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoTitular);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataTitular = 0; iDataTitular < dataTitular.Count(); iDataTitular++)
                {
                    var DataTitularAgrupada = dataTitular.ElementAt(iDataTitular);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;

                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelTitular = dtHistorialSentinelTitular.NewRow();

                    rowHistorialSentinelTitular["FechPro"] = cfechaPRo;
                    rowHistorialSentinelTitular["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataTitular).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelTitular["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelTitular["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelTitular["Calificacion"] = cCalificacion;

                    rowHistorialSentinelTitular["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelTitular["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelTitular.Rows.Add(rowHistorialSentinelTitular);
                }
            }

        }
        public void HistoricoSentinel_Conyuge()
        {
            if (dtMicrConyuge.Rows.Count > 0)
            {
                dtHistorialSentinelConyuge.Clear();
                var dataConyuge = dtMicrConyuge.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoConyuge);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataConyuge = 0; iDataConyuge < dataConyuge.Count(); iDataConyuge++)
                {
                    var DataTitularAgrupada = dataConyuge.ElementAt(iDataConyuge);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelConyuge = dtHistorialSentinelConyuge.NewRow();

                    rowHistorialSentinelConyuge["FechPro"] = cfechaPRo;
                    rowHistorialSentinelConyuge["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataConyuge).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelConyuge["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelConyuge["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelConyuge["Calificacion"] = cCalificacion;

                    rowHistorialSentinelConyuge["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelConyuge["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelConyuge.Rows.Add(rowHistorialSentinelConyuge);
                }
            }

        }
        public static string InvertirCadena(string cadena)
        {
            // Convertir a arreglo
            char[] cadenaComoCaracteres = cadena.ToCharArray();
            // Invertir el arreglo usando métodos incorporados
            Array.Reverse(cadenaComoCaracteres);
            // Convertir de nuevo el arreglo a cadena
            return new string(cadenaComoCaracteres);
        }
        public List<ListOrdenSemaforo> LLenaListaSemaforo(string cadena)
        {

            List<ListOrdenSemaforo> lista = new List<ListOrdenSemaforo>();
            for (int i = 0; i < cadena.Length; i++)
            {
                ListOrdenSemaforo objmodel = new ListOrdenSemaforo();
                objmodel.codigo = i;
                objmodel.Semaforo = cadena[i].ToString();
                //char c = dato[i];
                lista.Add(objmodel);

            }

            return lista;
        }

        private DataTable ArmarTablaParametrosPosicionConsolidada(int idCliSeleccion, string cDocumentoIDS, string idTipoDocumento)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";

            drfila[1] = idCliSeleccion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nidTipoPersona";

            drfila[1] = nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDocumentoID";
            drfila[1] = "'" + cDocumentoIDS + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDocumento";
            drfila[1] = "'" + idTipoDocumento + "'";
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        public DataTable GeneraResumenCondiciones(DataTable dt)
        {
            DataTable dtRespuesta = new DataTable("DtValidacionCondiciones");
            dtRespuesta.Columns.Add("Mensaje", typeof(string));
            dtRespuesta.Columns.Add("Resultado", typeof(string));

            DataTable dtRespuestaDetCumple = dtRespuesta.Clone();
            DataTable dtRespuestaDetNoCumple = dtRespuesta.Clone();

            DataTable dtGeneral = dtRespuesta.Clone();
            dtGeneral = dt.AsEnumerable()
                                .Where(b => Convert.ToString(b.Field<string>("cTipoCondicion")) == "GENERAL")
                                .GroupBy(x => x.Field<string>("Mensaje"))
                                .Select(y => dtRespuesta.Rows.Add(Convert.ToString(y.First().Field<string>("Mensaje")), Convert.ToString(y.First().Field<string>("Resultado")))).CopyToDataTable();

            DataTable dtProducto = dtRespuesta.Clone();
            dtProducto = dt.AsEnumerable().Where(x => Convert.ToString(x.Field<string>("cTipoCondicion")) == "PRODUCTO").CopyToDataTable();

            IEnumerable<IGrouping<string, string>> lstCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));
            IEnumerable<IGrouping<string, string>> lstNoCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "NO CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));

            foreach (IGrouping<string, string> oNoCumple in lstNoCumple)
            {
                string cNoCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "NO CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oNoCumple.Key)) ? "NO CUMPLE:" : "";
                cNoCumpleDet = cNoCumpleDet + " " + String.Join(", ", oNoCumple);
                dtRespuestaDetNoCumple.Rows.Add(oNoCumple.Key, cNoCumpleDet);
            }

            foreach (IGrouping<string, string> oCumple in lstCumple)
            {
                string cCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oCumple.Key)) ? "CUMPLE" : "";
                dtRespuestaDetCumple.Rows.Add(oCumple.Key, cCumpleDet);
            }

            dtRespuestaDetCumple.Merge(dtRespuestaDetNoCumple, true, MissingSchemaAction.AddWithKey);

            dtRespuestaDetCumple.AsEnumerable()
                .GroupBy(grp => grp.Field<string>("Mensaje"))
                .Select(x => new { Mensaje = x.Key, Resultado = String.Join(" - ", x.Select(i => i.Field<string>("Resultado"))) }).ToList()
                .ForEach(x => { dtRespuesta.Rows.Add(x.Mensaje, x.Resultado); });

            return dtRespuesta;
        }
        public string fechaformateada(string fecha)
        {
            string[] valores = fecha.Split('-');
            string Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(valores[1]));
            string Anio = valores[0];
            string Resultado = Mes.Replace(".", "").Replace("Set", "Sep") + " " + Anio;
            return Resultado;
        }

        public void CreaTablaBasicoSunatTitular()
        {

            dtBasicoSunatTitular = new DataTable("dtBasicoSunatTitular");
            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelTDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelNDOC";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RazSoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NomCom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TipCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "IniAct";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ActEco";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "FchInsRRPP";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "AgeRet";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApePat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApeMat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Nom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Sex";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "CondDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

        }
        public void CreaTablaBasicoSunatConyuge()
        {

            dtBasicoSunatConyuge = new DataTable("dtBasicoSunatConyuge");
            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelTDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelNDOC";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RazSoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NomCom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TipCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "IniAct";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ActEco";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "FchInsRRPP";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "AgeRet";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApePat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApeMat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Nom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Sex";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "CondDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

        }
        public void CreaTablaBSunatDireccionTitular()
        {

            dtBSunatDireccionTitular = new DataTable("dtBSunatDireccionTitular");
            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Direccion";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Fuente";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

        }
        public void CreaTablaBSunatDireccionConyuge()
        {

            dtBSunatDireccionConyuge = new DataTable("dtBSunatDireccionConyuge");
            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Direccion";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Fuente";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

        }
        public void CreaTablaRLegalTitular()
        {
            dtRlegalTitular = new DataTable("dtRlegalTitular");
            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "TDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "NDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Nombre";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "FecIniCar";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Cargo";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);
        }
        public void CreaTablaRLegalConyuge()
        {
            dtRlegalConyuge = new DataTable("dtRlegalConyuge");
            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "TDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "NDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Nombre";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "FecIniCar";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Cargo";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);
        }
        public void CreaTablalCredNoUtilTitular()
        {

            dtlCredNoUtilizadaT = new DataTable("dtlCredNoUtilizadaT");
            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Condicion";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Inst";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinApr";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "TipCred";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);
        }
        public void CreaTablalCredNoUtilConyuge()
        {

            dtlCredNoUtilizadaC = new DataTable("dtlCredNoUtilizadaC");
            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Condicion";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Inst";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinApr";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "TipCred";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);
        }
        public void CreaTablaDeudaTitular()
        {
            dtDeudaTitular = new DataTable("dtDeudaTitular");

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "Condicion";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.Int32");
            columnDeudaTitular.ColumnName = "idFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MaxDiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "VenTot";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomEnt";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MontDeu";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);


            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "DiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NumDoc";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

        }
        public void CreaTablaDeudaConyuge()
        {
            dtDeudaConyuge = new DataTable("dtDeudaConyuge");

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "Condicion";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.Int32");
            columnDeudaConyuge.ColumnName = "idFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MaxDiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "VenTot";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomEnt";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MontDeu";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);


            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "DiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NumDoc";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);
        }
        public void CreaTablaAvalistaTitular()
        {
            dtAvalistaTitular = new DataTable("dtAvalistaTitular");

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Condicion";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Sem12Mes";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemAct";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemPre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Cal";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SalDeu";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "TipEnt";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "FecRep";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

        }
        public void CreaTablaAvalistaConyuge()
        {
            dtAvalistaConyuge = new DataTable("dtAvalistaConyuge");

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Condicion";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Sem12Mes";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemAct";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemPre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Cal";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SalDeu";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "TipEnt";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "FecRep";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);


        }
        public void CreaTablaAvaladoTitular()
        {
            ///Crea Tabla Avalado Titular
            dtAvalado = new DataTable("dtAvalado");

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Condicion";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "ndoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "semAct";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Sem12Mes";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "nDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "cal";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tipEnt";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "salDeu";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "fecRep";
            dtAvalado.Columns.Add(columnAvaladoTitular);


        }
        public void CreaTablaAvaladoConyuge()
        {
            dtAvaladoConyuge = new DataTable("dtAvaladoConyuge");

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Condicion";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "ndoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "semAct";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Sem12Mes";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "nDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "cal";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tipEnt";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "salDeu";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "fecRep";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

        }
        public void CreaTablaMicrofinanzasTitular()
        {
            dtMicrTitular = new DataTable("dtMicrTitular");

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Condicion";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "NomEnt";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Cal";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "SalDeu";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.Int32");
            columnMicrTitular.ColumnName = "DiaVen";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchPro";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchRep";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchProNumero";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "DeudaTotal";
            dtMicrTitular.Columns.Add(columnMicrTitular);
        }
        public void CreaTablaMicrofinanzasConyuge()
        {
            dtMicrConyuge = new DataTable("dtMicrConyuge");

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Condicion";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "NomEnt";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Cal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "SalDeu";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.Int32");
            columnMicrConyuge.ColumnName = "DiaVen";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchPro";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchRep";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchProNumero";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "DeudaTotal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

        }
        public void CreaTablaHistorialSentinelTitular()
        {
            dtHistorialSentinelTitular = new DataTable("dtHistorialSentinelTitular");

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FechPro";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "SemaActual";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelTitular.ColumnName = "NroEntidad";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "DeudaTotal";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "Calificacion";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajePER";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FchProNumero";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);
            

        }
        public void CreaTablaHistorialSentinelConyuge()
        {
            dtHistorialSentinelConyuge = new DataTable("dtHistorialSentinelConyuge");

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FechPro";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "SemaActual";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelConyuge.ColumnName = "NroEntidad";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "DeudaTotal";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "Calificacion";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajePER";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FchProNumero";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);
            
        }
        public void CreaTablaClasificacionCliente()
        {

            dtClasTitularConyuge = new DataTable("dtClasTitularConyuge");
            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCondicion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idTipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "ctipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cnombre";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cNumDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idCli";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCalificacion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEstadoCivil";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEdad";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cRelNDoc";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cTipoCliente";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

        }

        #endregion
    }
}



