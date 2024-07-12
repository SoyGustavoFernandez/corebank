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
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using RPT.CapaNegocio;
using EntityLayer;
using GEN.Servicio;
using System.Globalization;
using EntityLayer.SentinelData;

namespace CRE.Presentacion
{
    public partial class frmReaprobacionCredito : frmBase
    {
        #region Variables Globales

        private int idSolicitud = 0;
        private DateTime dFechaHoraAprob;
        //public int idEstReaprob = 0;
        private clsCNReaprobSol cnReaprobSol = new clsCNReaprobSol();
        private clsCNAprobacionCredito cnAprobCred = new clsCNAprobacionCredito();
        private clsCreditoProp ObjCreditoProp;
        private DataTable dtSolReaprob = new DataTable("solReaprob");
        private DataTable dtCreditosAmp;
        private DataTable dtPlanPagSol = new DataTable("dtPlanPagSol");
        private DataTable dtModDatosGPP = new DataTable("dtModDatosGPP");
        private clsRPTCNPlanPagos cnRPTPlanPagos = new clsRPTCNPlanPagos();
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        string cTipoPersona = string.Empty;
        DataTable dtClasificacionCliente = new DataTable();
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        Response objRespuesta;
        List<TitularConyuge> objLisTituConyuge;
        clsApiCentralRsgExterno objCentraRsgExterno = new clsApiCentralRsgExterno();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
        private clsCNExpedienteLinea clsExpedienteNegocio = new clsCNExpedienteLinea();

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
        private decimal? nCapacidadPago;
        #endregion

        public frmReaprobacionCredito()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = "[2]";
        }

        #region Eventos

        private void frmReaprobacionCredito_Load(object sender, EventArgs e)
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
            habilitarBotones(0);
        }

        private void btnListaAprob1_Click(object sender, EventArgs e)
        {
            frmLisSolReaprob frmLiSolReapr = new frmLisSolReaprob();
            frmLiSolReapr.ShowDialog();

            this.idSolicitud = frmLiSolReapr.nNumSolicitud;

            if (this.idSolicitud > 0)
            {
                this.dFechaHoraAprob = frmLiSolReapr.dFechaHoraAprob;
                this.conBusCuentaCli1.txtNroBusqueda.Text = idSolicitud.ToString();
                this.conBusCuentaCli1.nValBusqueda = frmLiSolReapr.nNumSolicitud;
                this.conBusCuentaCli1.txtNombreCli.Text = frmLiSolReapr.cNomCliente.ToString();
                this.txtPersonalCreditos1.Text = frmLiSolReapr.cNomAsesor.ToString();
                this.conBusCuentaCli1.txtCodCli.Text = frmLiSolReapr.idCliente.ToString();
                this.conBusCuentaCli1.txtNroDoc.Text = frmLiSolReapr.cDocumentoID.ToString();

                //-------------
                this.ObjCreditoProp = cnReaprobSol.ObtenerCondicionesSolicitud(this.idSolicitud);
                this.conCreditoTasa.AsignarDatos(this.ObjCreditoProp);
                this.cargarCuentasVinculadas(this.idSolicitud);

                this.cboOperacionCre1.SelectedValue = this.ObjCreditoProp.idOperacion;
                this.dtFecAprob.Value = this.ObjCreditoProp.dFechaDesembolso.Date;

                habilitarBotones(0);

                if (this.ObjCreditoProp.idOperacion.In(2, 6))
                {
                    DataTable dtMontoRef = this.cnReaprobSol.obtenerMontoTotalRefi(this.idSolicitud);
                    decimal nDeudaTotalRef = Convert.ToDecimal(dtMontoRef.Rows[0]["nDeudaTotal"]);

                    if (this.ObjCreditoProp.nMonto != nDeudaTotalRef)
                    {
                        DialogResult dialogResult = MessageBox.Show("El monto a aprobar es distinto a la deuda actual.\n\n¿Desea efectuar la actualización?", 
                            "Crédito Refinanciado o Novación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dialogResult == DialogResult.Yes)
                        {
                            this.ObjCreditoProp.nMonto = nDeudaTotalRef;
                            this.conCreditoTasa.AsignarDatos(this.ObjCreditoProp);
                        }
                        else
                        {
                            habilitarBotones(2);
                        }
                    }
                }
                        }
            else
            {
                this.conCreditoTasa.LimpiarFormulario();
                this.idSolicitud = 0;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.cnReaprobSol.terminarReaprobacion(this.idSolicitud);

            this.conBusCuentaCli1.limpiarControles();
            this.conCreditoTasa.LimpiarFormulario();
            this.limpiarDatosCred();
            this.dtgCuentaCreditoVinculado.DataSource = null;
            this.ObjCreditoProp = null;
            this.idSolicitud = 0;

            habilitarControles(false);
            habilitarBotones(2);
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            /*this.idSolicitud = this.conBusCuentaCli1.nValBusqueda;

            if (this.idSolicitud > 0)
            {
                CargarCondSolicitud(this.idSolicitud);
            }*/
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            /*this.idSolicitud = this.conBusCuentaCli1.nValBusqueda;

            if (this.idSolicitud > 0)
            {
                this.CargarCondSolicitud(this.idSolicitud);
            }*/
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            /*if (ObjCreditoProp.idOperacion.In(2, 6))
            {
                this.habilitarControles(3, true);
            }

            if (ObjCreditoProp.idOperacion == 1)
            {
                this.habilitarControles(2, true);
            }

            this.btnGrabar1.Enabled = true;
            this.btnActualizar1.Enabled = false;
            this.txtComentario.Enabled = true;


            clsCreditoProp oCreditoMod = this.conCreditoTasa.ObtenerCreditoPropuesto();
            DataTable dtMontoRef = this.cnReaprobSol.obtenerMontoTotalRefi(this.idSolicitud);
            oCreditoMod.nMonto = Convert.ToDecimal(dtMontoRef.Rows[0]["nDeudaTotal"]);

            this.conCreditoTasa.AsignarDatos(oCreditoMod);
            */

        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (!ObjCreditoProp.idOperacion.In(2, 6))
            {
                DialogResult dr = MessageBox.Show("Solamente podrá actualizar las condiciones del crédito por única vez, ¿Está Seguro de Continuar?", "Validar Reaprobacion Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                    return;
            }
            
                
            /*if (ObjCreditoProp.idOperacion.In(2, 6))
            {
                this.habilitarControles(3, true);
            }*/

            /*if (ObjCreditoProp.idOperacion == 1)
            {
                this.habilitarControles(2, true);
            }*/

            

            DataTable dtReaprob = cnReaprobSol.validarSolReaprobRefi(this.idSolicitud, clsVarGlobal.User.idUsuario);
            if (dtReaprob.Rows.Count == 0)
            {
                this.cnReaprobSol.registrarReaprobacion(this.idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.dFechaHoraAprob);
            }

            this.dtPlanPagSol = cnReaprobSol.obtenerPlanPagosSol(this.idSolicitud);
            this.dtModDatosGPP = cnReaprobSol.obtenerDatosModGPP(this.idSolicitud);


            habilitarControles(true);
            habilitarBotones(1);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!ValidarReglas())
                return;
            
            if (!validarCapacidadPago())
                return;

            if (!ObjCreditoProp.idOperacion.In(2, 6))
            {
                DialogResult dr = MessageBox.Show("Solo podrá actualizar condiciones del crédito por única vez, ¿Está Seguro de Continuar?", "Validar Reaprobacion Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                    return;
            }

            if (!this.ObjCreditoProp.idOperacion.In(2,6))
            {
                if (this.conCreditoTasa.Monto() > this.ObjCreditoProp.nMontoSolicitado)
                {
                    MessageBox.Show("El monto propuesto es mayor a lo solicitado.", "Validar Reaprobacion Solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
            clsMsjError objMsjError = this.validarCambios();

            if (objMsjError.HasErrors)
            {
                MessageBox.Show("" + objMsjError.GetErrors());
                return;
            }

            if (!validarDatosPlanPago(this.idSolicitud))
            {
                MessageBox.Show("Las condiciones de la solicitud o el cronograma de pagos han sido cambiados. Por favor reiniciar el formulario", "Validar Reaprobacion Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            clsCreditoProp oCreditoMod = this.conCreditoTasa.ObtenerCreditoPropuesto();

            DataTable garantias = cnReaprobSol.validarGarantias(this.idSolicitud);

            if (garantias.Rows.Count > 0)
            {
                if (oCreditoMod.nMonto > Convert.ToDecimal(garantias.Rows[0]["nMontoGarantia"]))
                {
                    MessageBox.Show("El monto de las garantias no cubre al monto propuesto, revise la Vinculación de Garantias", "Validar Reaprobacion Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    this.ActualizarCondCre();
                }
            }
            else
            {
                this.ActualizarCondCre();
            }

            //this.cnReaprobSol.terminarReaprobacion(this.idSolicitud);
            if (!ObjCreditoProp.idOperacion.In(2, 6))
            {
                habilitarControles(false);
                habilitarBotones(2);
            }
            else
            {
                habilitarControles(false);
                habilitarBotones(3);
            }
        }

        #endregion

        #region Metodos
        /*private void CargarCondSolicitud(int nNumSolicitud)
        {
            ObjCreditoProp = cnReaprobSol.ObtenerCondicionesSolicitud(this.idSolicitud);

            DataTable dtReaprob = cnReaprobSol.validarSolReaprobRefi(this.idSolicitud, clsVarGlobal.User.idUsuario);
            if (dtReaprob.Rows.Count == 0)
            {
                this.cnReaprobSol.registrarReaprobacion(this.idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.dFechaHoraAprob);
            }

            this.dtPlanPagSol = cnRPTPlanPagos.ADCronogramaXSolicitud(this.idSolicitud);
            this.dtModDatosGPP = cnReaprobSol.obtenerDatosModGPP(this.idSolicitud);
            this.conCreditoTasa.AsignarDatos(ObjCreditoProp);
            this.cargarCuentasVinculadas(nNumSolicitud);
            this.cboOperacionCre1.SelectedValue = ObjCreditoProp.idOperacion;
            this.dtFecAprob.Value = this.ObjCreditoProp.dFechaDesembolso.Date;

            habilitarControles(1, true);
        }*/

        private void habilitarBotones(int nValor)
        {
            switch (nValor)  // Inicio form
            {
                case 1: // Editado
                    this.btnGrabar1.Enabled = true;
                    this.btnEditar1.Enabled = false;
                    this.btnCancelar1.Enabled = true;
                    break;

                case 2: // Cancelado
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = false;
                    this.btnCancelar1.Enabled = false;
                    break;

                case 3: // Grabado
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = true;
                    this.btnCancelar1.Enabled = false;
                    break;

                default:    // Default                    
                    this.btnGrabar1.Enabled = false;
                    this.btnEditar1.Enabled = true;
                    this.btnCancelar1.Enabled = false;

                    break;
            }
        }

        private void habilitarControles(bool lHabilitado)
        {
            this.conCreditoTasa.Enabled = lHabilitado;
            this.txtComentario.Enabled = lHabilitado;
        }


        /*private void habilitarControles(int nValor, bool lValor)
        {
            switch (nValor)  // Inicio form
            {
                case 0:
                    this.conCreditoTasa.Enabled = false;

                    this.cboOperacionCre1.Enabled = false;
                    //this.cboPersonalCreditos1.Enabled = false;
                    this.dtFecAprob.Enabled = false;
                    this.txtComentario.Enabled = false;

                    break;
                case 1:
                    this.txtComentario.Enabled = false;
                    break;

                case 2: // OTORGAMIENTO
                    this.conCreditoTasa.Enabled = true;
                    this.txtComentario.Enabled = false;

                    break;
                case 3: // REFINANCIAMIENTO Y NOVACION
                    this.conCreditoTasa.Enabled = true;
                    this.btnEditar1.Enabled = false;
                    //this.btnEditar1.Visible = false;
                    //this.btnGrabar1.Visible = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnActualizar1.Enabled = true;
                    //this.btnActualizar1.Visible = true;
                    this.btnCancelar1.Enabled = true;

                    this.txtComentario.Enabled = false;
                    break;

                default:
                    this.conCreditoTasa.Enabled = true;
                    this.btnEditar1.Enabled = true;
                    //this.btnEditar1.Visible = true;
                    //this.btnGrabar1.Visible = true;
                    this.btnGrabar1.Enabled = false;
                    this.btnActualizar1.Enabled = false;
                    //this.btnActualizar1.Visible = false;
                    this.btnCancelar1.Enabled = true;

                    this.txtComentario.Enabled = false;
                    break;
            }
        }*/

        private clsMsjError validarCambios()
        {
            clsMsjError objMsjError = new clsMsjError();

            var objCreditoTasaMsjError = this.conCreditoTasa.Validar();

            if (objCreditoTasaMsjError.HasErrors)
            {
                foreach (var err in objCreditoTasaMsjError.GetListError())
                    objMsjError.AddError(err);
            }

            if (String.IsNullOrWhiteSpace(this.txtComentario.Text))
            {
                objMsjError.AddError("Ingrese un Comentario para la Actualizacion");
            }

            return objMsjError;
        }

        private void limpiarDatosCred()
        {
            this.cboOperacionCre1.SelectedIndex = -1;
            this.dtFecAprob.Value = clsVarGlobal.dFecSystem;
            this.txtComentario.Text = "";
            this.txtComentario.Enabled = false;
        }

        private void ActualizarCondCre()
        {
            clsCreditoProp oCreditoMod = new clsCreditoProp();

            oCreditoMod = this.conCreditoTasa.ObtenerCreditoPropuesto();

            decimal nCapitalPropuesto = oCreditoMod.nMonto;
            int nCuotas = oCreditoMod.nCuotas;
            int idTipoPeriodo = oCreditoMod.idTipoPeriodo;
            int nPlazoCuota = oCreditoMod.nPlazoCuota;
            DateTime dFechaDesembolso = oCreditoMod.dFechaDesembolso;
            int nDiasGracia = oCreditoMod.nDiasGracia;
            int idTasa = oCreditoMod.idTasa;
            decimal nTEA = oCreditoMod.nTea;
            decimal nTEM = oCreditoMod.nTem;

            int nCuotasGracia = oCreditoMod.nCuotasGracia;
            int nPlazo = oCreditoMod.nPlazo;

            string cComentReaprob = this.txtComentario.Text;

            DataTable resultado = new DataTable();
            DataTable reaprobRef = new DataTable();

            if (this.ObjCreditoProp.idOperacion.In(2, 6))
            {
                reaprobRef = cnReaprobSol.validarSolReaprobRefi(this.idSolicitud, clsVarGlobal.User.idUsuario);
                int idSolReAprob = Convert.ToInt32(reaprobRef.Rows[0]["idSolReAprobacion"]);
                resultado = cnReaprobSol.actualizarCondCredRef(idSolicitud, idSolReAprob, cComentReaprob, nCapitalPropuesto, nCuotas,
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM,
                                                    nCuotasGracia, nPlazo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            }
            else
            {
                resultado = cnReaprobSol.actualizarCondCredOtor(idSolicitud, cComentReaprob, nCapitalPropuesto, nCuotas,
                                                    idTipoPeriodo, nPlazoCuota, dFechaDesembolso, nDiasGracia, idTasa, nTEA, nTEM,
                                                    nCuotasGracia, nPlazo, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, this.nCapacidadPago);
            }

            MessageBox.Show(resultado.Rows[0]["cMensaje"].ToString(), "Validar Reaprobacion Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Convert.ToInt32(resultado.Rows[0]["idError"]) == 0)
            {
                //Recupera informacion para Posicion consilidada antes de congelar
                DataTable didDescTipoDoc = clsExpedienteNegocio.obtenerIdentificaridDescTipoDoc();
                DataSet dExpedientes = clsExpedienteNegocio.getGrupoExpedienteLinea("Posicion consolidada de Cliente", this.idSolicitud, "individual");
                DataTable dtLeerTablaExpediente = dExpedientes.Tables[0];

                /*  Guardar Expedientes - Reaprobacion de Credito  */
                clsProcesoExp.guardarCopiaExpediente("Reaprobacion de Credito", this.idSolicitud, this);

                bool lPosConsolidadaExterno = false;
                if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("lPosConsolidadaExterno")))
                {
                    clsVarGen objVarPosConsolidada = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("lPosConsolidadaExterno"));
                    lPosConsolidadaExterno = Convert.ToBoolean(objVarPosConsolidada.cValVar);
                }
                if (lPosConsolidadaExterno)
                {
                    clsCNIntervCre IntervCre = new clsCNIntervCre();
                    DataTable dtLisIntervSol = IntervCre.obtenerIntervinienteSolicitud(this.idSolicitud, clsVarGlobal.idModulo, true, true);

                    foreach (DataRow row in dtLisIntervSol.Rows)
                    {
                        int idCliSel = Convert.ToInt32(row["idCli"]);
                        string cDocumentoSel = Convert.ToString(row["cDocumentoID"]);
                        /*  Guardar Expedientes - Posicion Consolidada - Congelamiento */
                        dExpedientes.Tables[0].Rows[0]["idSecundario"] = idCliSel;
                        SentinelPosicionConsolidada(idCliSel, cDocumentoSel);
                        clsProcesoExp.guardarCopiaExpedientePosicionConsolidada(Convert.ToInt32(didDescTipoDoc.Rows[0]["idDescTipoDoc"]), cTipoSolicitud, idCliSel, "Posicion consolidada de Cliente", this.idSolicitud, this, dsContenedorConsolidada, dExpedientes);
                    }
                }
            }
        }

        private void cargarCuentasVinculadas(int idSolicitud)
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

            dtgCuentaCreditoVinculado.Columns["idCuenta"].Width = 80;
            dtgCuentaCreditoVinculado.Columns["nTotal"].Width = 108;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].Width = 110;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].Width = 180;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].Width = 100;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].Width = 100;

            dtgCuentaCreditoVinculado.Columns["idCuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCuentaCreditoVinculado.Columns["nTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCuentaCreditoVinculado.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCuentaCreditoVinculado.ClearSelection();
        }

        private bool validarDatosPlanPago(int idSolicitud)
        {
            DataTable dtNuevoPlanPagSol = cnReaprobSol.obtenerPlanPagosSol(this.idSolicitud);
            if (this.dtPlanPagSol.Rows.Count == dtNuevoPlanPagSol.Rows.Count)
            {
                for (int i = 0; i < dtNuevoPlanPagSol.Rows.Count; i++)
                {
                    for (int j = 0; j < dtNuevoPlanPagSol.Columns.Count; j++)
                    {
                        if (!Object.Equals(this.dtPlanPagSol.Rows[i][j], dtNuevoPlanPagSol.Rows[i][j]))
                            return false;
                    }
                }
            }

            DataTable dtNuevoDatosModGPP = cnReaprobSol.obtenerDatosModGPP(this.idSolicitud);

            for (int i = 0; i < this.dtModDatosGPP.Columns.Count; i++)
            {
                if (!Object.Equals(this.dtModDatosGPP.Rows[0][i], dtNuevoDatosModGPP.Rows[0][i]))
                    return false;
            }

            return true;
        }

        private bool validarCapacidadPago()
        {
            decimal nCuotaAprox = this.conCreditoTasa.CuotaAprox();
            DataTable dt = this.cnReaprobSol.obtenerCapacidadPago(this.ObjCreditoProp.idSolicitud, nCuotaAprox);

            this.nCapacidadPago = dt.Rows[0].Field<decimal?>("nCapacidadPago");
            decimal? nMinimoCP = dt.Rows[0].Field<decimal?>("nMinimoCP");
            decimal? nMaximoCP = dt.Rows[0].Field<decimal?>("nMaximoCP");

            if (this.nCapacidadPago == null || nMinimoCP == null || nMaximoCP == null)
                return true;

            if (nCapacidadPago >= nMinimoCP && nCapacidadPago <= nMaximoCP)
                return true;

            string cMensaje = "- La Capacidad de Pago (" + @nCapacidadPago +
                    "%) debe ser mayor igual a " + nMinimoCP + "% y menor igual a " + nMaximoCP + "%";
            MessageBox.Show(cMensaje, "Validar Reaprobación Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return false;
        }
        #endregion

        private void frmReaprobacionCredito_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.cnReaprobSol.terminarReaprobacion(this.idSolicitud);
        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;

            x_idCliente = clsVarGlobal.User.idCli;


            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglasCreditos(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, Convert.ToInt32(this.conCreditoTasa.idMoneda.ToString()), this.ObjCreditoProp.idProducto,
                                                   Decimal.Parse(this.conCreditoTasa.MontoPropuesto.ToString()), idSolicitud, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto, true, false, idSolicitud);

            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            if (cCumpleReglas.Equals("ExcepcionRechazada"))
            {
                return false;
            }
            return true;
        }

        private DataTable ArmarTablaParametros()
        {
            clsCreditoProp oCreditoMod = new clsCreditoProp();
            oCreditoMod = this.conCreditoTasa.ObtenerCreditoPropuesto();
            int nCuotas = oCreditoMod.nCuotas;
            decimal nMonto = oCreditoMod.nMonto;

            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonto";
            drfila[1] = nMonto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = oCreditoMod.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = oCreditoMod.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
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

    }
}
