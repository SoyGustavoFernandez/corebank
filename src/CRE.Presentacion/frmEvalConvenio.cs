using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmEvalConvenio : frmBase
    {
        #region Variable Globales

        clsCNEvalConsumo cnEvalConsumo = new clsCNEvalConsumo();
        clsCNEvaluacion cnEval = new clsCNEvaluacion();
        clsCNControlExp cnExp = new clsCNControlExp();
        private CRE.CapaNegocio.clsCNCredito objCNCredito;

        // ENTIDADES
        private clsEvalCred objEvalCred;
        private clsCreditoProp objSolicitud;
        private clsCreditoProp objCreditoPropuesto;
        private List<clsReferenciaEval> listReferencia;
        private DataTable dtListaDeudas;
        private DataTable dtIngrEgre;
        private List<clsEstResEval> listEstResEval;
        private List<clsEvalCualitativa> listEvalCualitativa;
        private DataTable dtTipDestCred;
        private DataTable dtTipDestCredDetalle;
        private List<clsDestCredProp> listDestCredProp;
        string cTituloMensaje = "Evaluación convenio";

        decimal nCapacidadPago;
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();

        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        private List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();

        #region Variables Validacion
        int nPuntajeMinEvalCual = 30;
        #endregion

        private int idEstadoSolRechazado = 4;

        Transaccion nTran;

        private int idEvalCre = 0;
        private int idCanal;

        #endregion

        public frmEvalConvenio()
        {
            InitializeComponent();
            //conReferencias.Titulo = "Referencias personales y laborales";
            habilitarFormulario(false);
            nTran = Transaccion.Nuevo;
            controlBotones();
            cboCatLaboral1.Enabled = false;

            this.objCNCredito = new CRE.CapaNegocio.clsCNCredito();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
        }


        #endregion

        #region Métodos

        private void cargarEvaluacion(int idEvalCre)
        {
            #region Recupera de base de datos
            DataSet dsEvalConsumo =  cnEvalConsumo.CNCargarEvalConsumo(idEvalCre);

            if (dsEvalConsumo.Tables.Count == 0)
            {
                MessageBox.Show("No exite resultados", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // =================================================================================
            // Obtener la informacion general de la evaluacíon ->TABLE[0]
            // =================================================================================
            var aEval = DataTableToList.ConvertTo<clsEvalCred>(dsEvalConsumo.Tables[0]) as List<clsEvalCred>;
            this.objEvalCred = aEval[0];

            this.objEvalCred.idEstablecimiento = (this.objEvalCred.idEstablecimiento == 0) ? clsVarGlobal.User.idEstablecimiento : this.objEvalCred.idEstablecimiento;
            this.objEvalCred.idTipoEstablec = (this.objEvalCred.idTipoEstablec == 0) ? clsVarGlobal.User.idTipoEstablec : this.objEvalCred.idTipoEstablec;

            // =========================================================================================
	        // Obtener evaluacion cualitativa ->TABLE[1]
	        // =========================================================================================
            // this.listEvalCualitativa = DataTableToList.ConvertTo<clsEvalCualitativa>(dsEvalConsumo.Tables[1]) as List<clsEvalCualitativa>;


            // =========================================================================================
	        // Obtener las referencias personales y profesionales ->TABLE[2]
	        // =========================================================================================
            // this.listReferencia = DataTableToList.ConvertTo<clsReferenciaEval>(dsEvalConsumo.Tables[2]) as List<clsReferenciaEval>;

            // =========================================================================================
	        // Lista de deudas ->TABLE[1]
	        // =========================================================================================
            dtListaDeudas = dsEvalConsumo.Tables[1];

            // =========================================================================================
            // Estado de resultados ->TABLE[2]
            // =========================================================================================
            this.listEstResEval = DataTableToList.ConvertTo<clsEstResEval>(dsEvalConsumo.Tables[2]) as List<clsEstResEval>;

            // =========================================================================================
	        // Crédito solicitado ->TABLE[3]
	        // =========================================================================================
            var aSolicitud = DataTableToList.ConvertTo<clsCreditoProp>(dsEvalConsumo.Tables[3]) as List<clsCreditoProp>;
            if (aSolicitud.Count != 0)
            {
                this.btnGestObs.Enabled = true;
                this.objSolicitud = aSolicitud[0];
                //btnAdministradorFiles1.idSolicitud = this.objSolicitud.idSolicitud;
                //btnAdministradorFiles1.actualizarDatos();
                //btnAdministradorFiles1.Enabled = true;
            }

            // =========================================================================================
            // Obtener ingresos y egresos ->TABLE[4]
            // =========================================================================================
            this.dtIngrEgre = dsEvalConsumo.Tables[4];

            // =========================================================================================
            // Lista de Destino de crédito ->TABLE[5]
            // =========================================================================================
            this.dtTipDestCred = dsEvalConsumo.Tables[5];


            // =========================================================================================
            // Detalle destino de destino de crédito ->TABLE[6]
            // =========================================================================================
            this.dtTipDestCredDetalle = dsEvalConsumo.Tables[6];

            // =========================================================================================
            // Detalle destino de destino de crédito propuesto ->TABLE[7]
            // =========================================================================================
            this.listDestCredProp = DataTableToList.ConvertTo<clsDestCredProp>(dsEvalConsumo.Tables[7]) as List<clsDestCredProp>;

            // =============================================================================================================
	        // tipo de referencia ->TABLE[10]
	        // =============================================================================================================
            DataTable dtTipRef = dsEvalConsumo.Tables[8];

	        // =============================================================================================================
	        // tipo de vinculo evaluación ->TABLE[11]
	        // =============================================================================================================
            DataTable dtTipRefVin = dsEvalConsumo.Tables[9];

            #endregion

            #region Preparando Objetos

            this.objCreditoPropuesto = new clsCreditoProp()
            {
                idMoneda = this.objEvalCred.idMoneda,
                nMonto = this.objEvalCred.nCapitalPropuesto,
                nCuotas = this.objEvalCred.nCuotas,
                idTipoPeriodo = this.objEvalCred.idTipoPeriodo,
                nPlazoCuota = this.objEvalCred.nPlazoCuota,
                nDiasGracia = this.objEvalCred.nDiasGracia,
                dFechaDesembolso = this.objEvalCred.dFechaDesembolso,
                idProducto = this.objEvalCred.idProducto,
                cTipoCredito = this.objEvalCred.cTipoProducto,
                cSubProducto = this.objEvalCred.cSubProducto,
                idTasa = this.objEvalCred.idTasa,
                nTasaCompensatoria = this.objEvalCred.nTEA,
                idSolicitud = this.objEvalCred.idSolicitud,
                idAgencia = clsVarGlobal.nIdAgencia,
                idClasificacionInterna = this.objEvalCred.idClasificacionInterna

            };
                // -- Crédito Propuesto
            #endregion

            // #region limpiando controles
            // conCreditosSolProp1.limpiar();
            // #endregion

            #region Cargando Controles

            // conEvalCualitativa.AsignarDatos(listEvalCualitativa);
            //
            // conReferencias.AsignarDataTable(dtTipRef, dtTipRefVin);
            // conReferencias.AsignarDatos(listReferencia);
            // conReferencias.idEvalCre = this.objEvalCred.idEvalCred;

            conIngEgre1.cargarIngEgrDataTable(this.dtIngrEgre, objEvalCred.nTipoCambio, Convert.ToInt32(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"]));
            conIngEgre1.idEvalCre = this.objEvalCred.idEvalCred;

            conCreditosEval1.cargarDeudaRegistrada(this.dtListaDeudas, this.objEvalCred.lCargoRcc, this.objEvalCred.idEvalCred, this.objEvalCred.nTipoCambio);

            this.conCreditosSolProp1.cargarCreditoPropuesto(this.objCreditoPropuesto);

            conCreditosSolProp1.cargarCreditoSol(this.objSolicitud); //@todo verificar cuando carga

            conDestinoCredito1.idEvalCre = this.objEvalCred.idEvalCred;
            conDestinoCredito1.AsignarDataTable(this.dtTipDestCred, this.dtTipDestCredDetalle);
            conDestinoCredito1.AsignarDatos(this.objCreditoPropuesto.nMonto, this.listDestCredProp);
            conDestinoCredito1.EstablacerActivoAdquirir(this.objEvalCred.nActivoAdquirir);

            conEstadoResultados2.AsignarDatos(this.listEstResEval, this.objEvalCred.idProducto);

            cboCatLaboral1.SelectedValue = this.objEvalCred.idCatLab;

            rbtnDependiente.Checked = (this.objEvalCred.nTipIngreso == 1)? true: false;
            rbtnIndependiente.Checked = (this.objEvalCred.nTipIngreso == 2) ? true : false;

            txtEntFamiliar.Text = this.objEvalCred.cComEntFamiliar;
            txtSitEconomica.Text = this.objEvalCred.cComAnalisisFinan;
            txtDestinoCre.Text = this.objEvalCred.cComDestCredito;
            txtDescGarantias.Text = this.objEvalCred.cComGarantias;

            conEmpConvenio1.SetIdEmpresa(this.objEvalCred.idEmpresaConvenio);

            //txtCapacidadPago.Text = txtCapacidadPago.nDecValor.ToString("P2");

            if (this.objSolicitud != null)
            {
                txtOperacion.Text = this.objSolicitud.cOperacion;
                txtModCre.Text = this.objSolicitud.cModalidadCredito;
                txtNroSol.Text = this.objSolicitud.idSolicitud.ToString();
                btnVincularVisita1.idSolicitud = this.objSolicitud.idSolicitud;
                btnVincularVisita1.idCli = this.objSolicitud.idCli;
            }

            //cargarRcc();

            if (!this.objEvalCred.lEditar)
            {
                habilitarFormulario(false);
                MessageBox.Show("La evaluación ha sido enviada a comite no se puede editar", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                nTran = Transaccion.Elimina; // botones al envio de evaluación
                controlBotones();

            }

            int idSolicitud = 0;
            if (this.objSolicitud != null)
            {
                idSolicitud = this.objSolicitud.idSolicitud;
            }


            calcularRatios();
            #endregion
        }

        private void calcularRatios()
        {
            // Ratio
            decimal nCuotaPrestamo = conCreditosSolProp1.obtenerCuotaAproximada(),
                    nUtilidadDisponible = conEstadoResultados2.obtenerItem(EEFF.UtilidadDisponible),
                    nPorcentajeParaCuotaMaxima = ObtenerPorcentajeMaximo(); /// @verificar el porcentaje
                                                                            ///
            nCapacidadPago = (nUtilidadDisponible > 0)? (nCuotaPrestamo / nUtilidadDisponible): 0.00m;
            txtCapacidadPago.Text = nCapacidadPago.ToString("P2");


            lblBase3.Text = "(*) = Ingreso monto neto * " ;
            // Ratio 2 N
            txtCuotaMaxima.Text = nPorcentajeParaCuotaMaxima.ToString("P2");
            this.objEvalCred.nRatCapacPago = (nUtilidadDisponible > 0) ? (nCuotaPrestamo / nUtilidadDisponible) : 0;
        }

        private decimal ObtenerPorcentajeMaximo()
        {
            decimal nPorColaInt = Convert.ToDecimal(clsVarApl.dicVarGen["nPorConvColaboraCuotaMax"]);
            decimal nPorConv = Convert.ToDecimal(clsVarApl.dicVarGen["nPorConvCuotaMax"]);
            string cIdsProductoConvInt = clsVarApl.dicVarGen["nIdProductoConvenioConIntitucion"];
            string [] cProdConvInt = cIdsProductoConvInt.Split(',');
            int [] nProdConvInt = Array.ConvertAll<string, int>(cProdConvInt, int.Parse);

            if (this.objEvalCred == null)
                return 0;

            if (this.objEvalCred.idProducto.In(nProdConvInt))
            {
                return nPorColaInt;
            }
            else
            {
                return nPorConv;
            }
        }

        #region Validadores
        private clsMsjError validar()
        {
            clsMsjError obj = new clsMsjError();

            var objCondiCreditoMsjError = this.conCreditosSolProp1.Validar();
            if (objCondiCreditoMsjError.HasErrors)
            {
                foreach (var err in objCondiCreditoMsjError.GetListError())
                    obj.AddError("Cond. Crédito: " + err);
            }

            // obj.AddError()/
            if (this.nCapacidadPago > 1.00m)
            {
                obj.AddError("La capacidad de pago no puede ser mayor al 100%");
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                obj.AddError("No hay una solicitud de crédito vinculada");
            }
            else
            {
                DataTable dtResDocs = cnExp.CNValidarListaDocsEval(this.objSolicitud.idSolicitud);
                if (dtResDocs.Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(dtResDocs.Rows[0]["lResultado"]))
                    {
                        obj.AddError(dtResDocs.Rows[0]["cMensaje"].ToString());
                    }
                }

                this.objCreditoPropuesto = conCreditosSolProp1.obtenerCreditoPropuesto();
                if (this.objSolicitud.nMonto < this.objCreditoPropuesto.nMonto)
                {
                    obj.AddError("El monto propuesto no debe superar al monto solicitado");
                }
            }

            obj.addList(conDestinoCredito1.ValidarDestino());

            obj.addList(conIngEgre1.validarIngresosEgresos());

            obj.addList(conCreditosEval1.validarCreditosEval());

            if (string.IsNullOrEmpty(txtEntFamiliar.Text))
            {
                obj.AddError("Debe registrar datos personales y laborales");
            }

            if (string.IsNullOrEmpty(txtSitEconomica.Text))
            {
                obj.AddError("Debe registrar la situación económica");
            }

            if (string.IsNullOrEmpty(txtDestinoCre.Text))
            {
                obj.AddError("Debe registrar el detalle del destino de préstamo");
            }

            if (string.IsNullOrEmpty(txtDescGarantias.Text))
            {
                obj.AddError("Debe registrar la descripción de garantías");
            }

            obj.addList(conEmpConvenio1.ValidarObj());

            if (conCreditosSolProp1.obtenerCuotaAproximada() > conEstadoResultados2.obtenerItem(EEFF.CuotaMaxEndeuda))
            {
                obj.AddError("La cuota aproximada del crédito supera la cuota máxima de endeudamiento");
            }

            //if (!btnAdministradorFiles1.obligatoriosCompletos())
            //{
            //    obj.AddError(btnAdministradorFiles1.msgObligatorios);
            //}

            //DataTable dtResPlazo = cnEval.CNValidarPlazoXMonto(this.objEvalCred.idEvalCred);
            //if (dtResPlazo.Rows.Count>0)
            //{
            //    obj.AddError(dtResPlazo.Rows[0]["cMensaje"].ToString());
            //}

            #region Carga de Archivos
            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(this.objEvalCred.idSolicitud);
            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
            {
                obj.AddError(dtCargaArchivos.Rows[0]["cMsg"].ToString());
            }
            #endregion

            return obj;
        }

        #endregion
        private void formatoGrid()
        {

        }

        private void controlBotones()
        {
            //btnAdministradorFiles1.lectura = true;
            switch (nTran)
            {
                case Transaccion.Edita:
                    //btnAdministradorFiles1.lectura = false;
                    btnImprimir.Enabled = false;
                    conImpFormatEval1.Enabled = false;
                    btnEnviar.Enabled = false;
                    btnValidar.Enabled = true;
                    this.btnExcepciones.Enabled = false;
                    btnDenegar.Enabled = true;
                    btnChecklist.Enabled = true;
                    btnBusqueda.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEditar1.Enabled = false;
                    this.btnCargaArhivos.Enabled = true;
                    btn_Vincular1.Enabled = false;
                    btnHabilitarSeguro.Enabled = true;
                    break;
                case Transaccion.Nuevo:
                    btnImprimir.Enabled = false;
                    conImpFormatEval1.Enabled = false;
                    btnEnviar.Enabled = false;
                    btnValidar.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    btnDenegar.Enabled = false;
                    btnChecklist.Enabled = false;
                    btnBusqueda.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEditar1.Enabled = false;
                    this.btnCargaArhivos.Enabled = false;
                    btn_Vincular1.Enabled = false;
                    btnHabilitarSeguro.Enabled = false;
                    break;
                case Transaccion.Selecciona:
                    btnImprimir.Enabled = true;
                    conImpFormatEval1.Enabled = true;
                    btnEnviar.Enabled = true;
                    btnValidar.Enabled = true;
                    this.btnExcepciones.Enabled = true;
                    btnDenegar.Enabled = true;
                    btnChecklist.Enabled = true;
                    btnBusqueda.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnEditar1.Enabled = true;
                    this.btnCargaArhivos.Enabled = true;
                    btn_Vincular1.Enabled = true;
                    btnHabilitarSeguro.Enabled = false;
                    break;
                case Transaccion.Elimina: // caso de envio a comité
                    btnImprimir.Enabled = true;
                    conImpFormatEval1.Enabled = true;
                    btnEnviar.Enabled = false;
                    btnValidar.Enabled = false;
                    this.btnExcepciones.Enabled = false;
                    btnDenegar.Enabled = false;
                    btnChecklist.Enabled = false;
                    btnBusqueda.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnEditar1.Enabled = false;
                    this.btnCargaArhivos.Enabled = false;
                    btn_Vincular1.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void habilitarFormulario(bool lHabilitar)
        {
            // =====================================================================================
            // Evaluación Cualitativa
            // =====================================================================================
            // conReferencias.Enabled = lHabilitar;
            // conEvalCualitativa.Enabled = lHabilitar;

            // =====================================================================================
            // Ingresos egresos y créditos
            // =====================================================================================
            conCreditosEval1.Enabled = lHabilitar;
            conIngEgre1.Enabled = lHabilitar;
            conEstadoResultados2.Enabled = lHabilitar;

            // =====================================================================================
            // Propuesta de crédito
            // =====================================================================================
            conCreditosSolProp1.Enabled = lHabilitar;
            //conRcc1.Enabled = lHabilitar;
            cboCatLaboral1.Enabled = lHabilitar;
            rbtnDependiente.Enabled = lHabilitar;
            rbtnIndependiente.Enabled = lHabilitar;

            txtCapacidadPago.Enabled = lHabilitar;
            conDestinoCredito1.Enabled = lHabilitar;
            conDestinoCredito1.Enabled = lHabilitar;

            txtEntFamiliar.Enabled = lHabilitar;
            txtSitEconomica.Enabled = lHabilitar;
            txtDestinoCre.Enabled = lHabilitar;
            txtDescGarantias.Enabled = lHabilitar;
            conEmpConvenio1.Enabled = lHabilitar;
        }

        private void limpiar()
        {
            this.objEvalCred = null;
            this.objSolicitud = null;
            this.objCreditoPropuesto = null;
            this.listReferencia = null;
            this.dtListaDeudas = null;
            this.dtIngrEgre = null;
            this.listEstResEval = null;
            this.listEvalCualitativa = null;
            this.dtTipDestCred = null;
            this.dtTipDestCredDetalle = null;
            this.listDestCredProp = null;
            this.idEvalCre = 0;

            txtNroDoc.Clear();
            txtNombre.Clear();
            txtNroSol.Clear();
            txtEvalCod.Clear();
            txtOperacion.Clear();
            txtModCre.Clear();
            txtEntFamiliar.Clear();
            txtSitEconomica.Clear();
            txtDestinoCre.Clear();
            txtDescGarantias.Clear();
            txtCuotaMaxima.Clear();

            // =====================================================================================
            // Evaluación Cualitativa
            // =====================================================================================
            // conEvalCualitativa.limpiar();
            // conReferencias.limpiar();

            // =====================================================================================
            // Ingresos egresos y créditos
            // =====================================================================================
            conCreditosEval1.limpiar();
            conIngEgre1.limpiar();
            conEstadoResultados2.limpiar();


            // =====================================================================================
            // Propuesta de crédito
            // =====================================================================================
            conCreditosSolProp1.limpiar();
            // conRcc1.limpiar();
            cboCatLaboral1.SelectedIndex = -1;
            rbtnDependiente.Checked = rbtnIndependiente.Checked = false;
            txtCapacidadPago.Text = "";
            nCapacidadPago = 0;

            conDestinoCredito1.limpiarControl();
            conDestinoCredito1.HabilitarFormulario(false);

            conEmpConvenio1.limpiar();
        }

        private void CargarConfiguracionSeguro(int nMuestraFrm)
        {
            clsCreditoProp objDatos = new clsCreditoProp();
            objDatos        = conCreditosSolProp1.obtenerCreditoPropuesto();
            int idSolicitud = this.objEvalCred.idSolicitud;
            int nParam      = 1;

            if (objDatos.nPlazoCuota == 0)
            {
                MessageBox.Show("Debe seleccionar frecuencia.", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        #endregion

        private void btnDenegar_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada a esta evaluación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCambioEstadoSol frm = new frmCambioEstadoSol(this.objEvalCred.idCli, this.objEvalCred.idSolicitud);
            frm.ShowDialog();

            if (frm.idEstadoSol == idEstadoSolRechazado) // estado de solicitud rechazado
            {
                cnEval.CNCambiaLVigenteEval(this.objEvalCred.idEvalCred, false);
                MessageBox.Show("La solicitud de credito ha sido rechazada, se procederá a limpiar el formulario", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                habilitarFormulario(false);
                nTran = Transaccion.Nuevo;
                controlBotones();
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            FrmBuscarEv frmBuscarEv = new FrmBuscarEv(Convert.ToString(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"]), "Buscar evaluación convenio");
            frmBuscarEv.ShowDialog();
            if (frmBuscarEv.idEvalCred != 0)
            {
                // =====================================================================================
                // Guardando datos del cliente
                // =====================================================================================
                txtNombre.Text = frmBuscarEv.cNombreCliente;
                txtNroDoc.Text = frmBuscarEv.cNroDocumento;
                txtEvalCod.Text = frmBuscarEv.idEvalCred.ToString();

                idEvalCre = frmBuscarEv.idEvalCred;

                nTran = Transaccion.Selecciona;
                controlBotones();
                habilitarFormulario(false);
                cargarEvaluacion(idEvalCre);

                conCreditosEval1.actualizarDiseño();
            }

        }

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada a esta evaluación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmListaDocObligatoriosCre frmDocs = new frmListaDocObligatoriosCre(this.objEvalCred.idTipoPersona, this.objEvalCred.idProducto, this.objEvalCred.idSolicitud);
            frmDocs.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string cNombreFormulario = this.Name;
            string cIdTipEvalCred = Convert.ToString(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"]);

            frmNuevaEvConsumo frm = new frmNuevaEvConsumo();
            frm.cargarTipoEvaluacion(Convert.ToInt32(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"]), "convenio");
            frm.RecuperarNombreFormulario(cNombreFormulario, cIdTipEvalCred);
            frm.ShowDialog();

            if (frm.idEvalCre != 0)
            {
                // cargar todos los datos para registro de evaluación
                // cargar evaluacion cualitativa
                // cargar estado de resultados
                // cargar rcc

                this.idEvalCre = frm.idEvalCre;

                txtNombre.Text = frm.cNombreCliente;
                txtNroDoc.Text = frm.cNroDocumento;
                txtEvalCod.Text = frm.idEvalCre.ToString();
                txtOperacion.Text = frm.cOperacion;
                txtModCre.Text = frm.cModalidaCre;

                cargarEvaluacion(this.idEvalCre);
                nTran = Transaccion.Selecciona;
                controlBotones();
                habilitarFormulario(false);

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // ==========================================================================
            // Obteniendo los objetos para registro de la evaluacion
            // ==========================================================================
            string cCrePropuestoEval,
                    cCreEval,
                    cDeudas,
                    cEERR,
                    cDestinosCre,
                    cIngreEgresos,
                    cRcc,
                    cReferencia,
                    cEvalCualita;

            // obtener el crédito propuesto
            this.objCreditoPropuesto = conCreditosSolProp1.obtenerCreditoPropuesto();
            this.objCreditoPropuesto.nCuotaAprox = conCreditosSolProp1.obtenerCuotaAproximada();
            cCrePropuestoEval = this.objCreditoPropuesto.GetXml();

            // Evaluación Evaluación crédito
            this.objEvalCred.cComEntFamiliar = txtEntFamiliar.Text;
            this.objEvalCred.cComAnalisisFinan = txtSitEconomica.Text;
            this.objEvalCred.cComDestCredito = txtDestinoCre.Text;
            this.objEvalCred.cComGarantias = txtDescGarantias.Text;

            this.objEvalCred.idMoneda = objCreditoPropuesto.idMoneda;
            this.objEvalCred.nCapitalPropuesto = objCreditoPropuesto.nMonto;
            this.objEvalCred.nCuotas = objCreditoPropuesto.nCuotas;
            this.objEvalCred.idTipoPeriodo = objCreditoPropuesto.idTipoPeriodo;
            this.objEvalCred.nPlazoCuota = objCreditoPropuesto.nPlazoCuota;
            this.objEvalCred.nDiasGracia = objCreditoPropuesto.nDiasGracia;
            this.objEvalCred.dFechaDesembolso = objCreditoPropuesto.dFechaDesembolso;
            this.objEvalCred.idProducto = objCreditoPropuesto.idProducto;
            this.objEvalCred.cTipoProducto = objCreditoPropuesto.cTipoCredito;
            this.objEvalCred.cSubProducto = objCreditoPropuesto.cSubProducto;
            this.objEvalCred.idTasa = objCreditoPropuesto.idTasa;
            this.objEvalCred.nTEA = objCreditoPropuesto.nTasaCompensatoria;
            this.objEvalCred.nCuotaAprox = objCreditoPropuesto.nCuotaAprox;
            this.objEvalCred.idUsuMod = clsVarGlobal.User.idUsuario;
            this.objEvalCred.idAgencia = clsVarGlobal.nIdAgencia;
            this.objEvalCred.idEmpresaConvenio = conEmpConvenio1.obtenerEmpresa();
            this.objEvalCred.nPorCuotaMax = conEstadoResultados2.ObtenerPorcentajeMaximo();
            // this.objEvalCred.lExpuestoRcc = conRcc1.expuestoRcc();
            this.objEvalCred.nTotalDeudas = 0;//
            this.objEvalCred.lCargoRcc = conCreditosEval1.lEstadoCargaDeuda;//
            //this.objEvalCred.nMontoCuotaMaxEndeudamiento = txtCuotaMaxima.nDecValor;
            this.objEvalCred.nActivoAdquirir = conDestinoCredito1.ObtenerActivoAdquirir();

            cCreEval = this.objEvalCred.GetXml();

            // Evaluación cualitativa
            // this.listEvalCualitativa = conEvalCualitativa.EvaluacionCualitativa();
            // cEvalCualitativa = this.listEvalCualitativa.GetXml();

            // Otras deudas directas e indirectas
            this.dtListaDeudas = this.conCreditosEval1.obtDeudasTotales();
            DataSet dsDeudas = new DataSet("dsDeudas");
            this.dtListaDeudas.TableName = "dtDeudas";
            if(this.dtListaDeudas.DataSet == null)
            {
                dsDeudas.Tables.Add(dtListaDeudas);
            }
            cDeudas = dsDeudas.GetXml();

            // lista de estado de resultados
            cEERR = this.listEstResEval.GetXml();

            // detinos de créditos
            cDestinosCre = this.listDestCredProp.GetXml();


            //Ingresos y egresos
            this.dtIngrEgre = conIngEgre1.obtIngEgre();
            DataSet dsIngEgre = new DataSet("dsIngEgre");
            this.dtIngrEgre.TableName = "dtIngEgre";

            if (this.dtIngrEgre.DataSet == null)
            {
                dsIngEgre.Tables.Add(dtIngrEgre);
            }
            cIngreEgresos = dsIngEgre.GetXml();

            // Rcc
            conRcc conRcc1 = new GEN.ControlesBase.conRcc();
            conRcc1.cargarTipoCambio();
            DataTable dtRcc = conRcc1.obtenerRCC(this.objEvalCred.idEvalCred);
            DataSet dsRcc = new DataSet("dsRcc");
            if (dtRcc.DataSet == null)
            {
                dsRcc.Tables.Add(dtRcc);

            }

            cRcc = dsRcc.GetXml();
            cReferencia = (new clsReferenciaEval()).GetXml();
            cEvalCualita = (new clsEvalCualitativa()).GetXml();

            int nMuestraFrm = 0;
            CargarConfiguracionSeguro(nMuestraFrm);

            DataTable dtResultado = cnEvalConsumo.CNInsActEvaluacionConsumo(cCreEval, cEvalCualita, cReferencia, cDeudas, cEERR, cIngreEgresos, cDestinosCre, cRcc);
            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string cNombre = txtNombre.Text;
            string cNroDoc = txtNroDoc.Text;
            string cNroEval = txtEvalCod.Text;
            int idEvalAux = idEvalCre;

            limpiar();
            conCreditosEval1.CambiarEstadoLCargaFormFirst(true);
            idEvalCre = idEvalAux;
            cargarEvaluacion(idEvalCre);
            habilitarFormulario(false);
            txtNombre.Text = cNombre;
            txtNroDoc.Text = cNroDoc;
            txtEvalCod.Text = cNroEval;
            nTran = Transaccion.Selecciona;
            controlBotones();
            ValidarReglas(false);
        }

        private void cargarEERR()
        {
            // Cargar ingreso neto titular
            cargarItemAEERR(EEFF.IngNetTitular, conIngEgre1.obtIngresosSoles(DEINGREGRE.IngresosBrutos)); //

            // Descuentos Judiciales
            cargarItemAEERR(EEFF.DescuentoJudicial, conIngEgre1.obtEgresosSoles(DEINGREGRE.DescuentosJudiciales));

            // Descuentos legales
            cargarItemAEERR(EEFF.DescuentoLegales, conIngEgre1.obtEgresosSoles(DEINGREGRE.DescuentosLegales));

            // Cargar deuda directa
            cargarItemAEERR(EEFF.CuotaCredDirectos, conCreditosEval1.obtenerCuotaTotalOtrosCreditos());

            // Cargar provision de deuda indirecta
            cargarItemAEERR(EEFF.ProvCredInDirectos, conCreditosEval1.obtenerTotalDeudaIndirectaProvSum());

            // operando
            conEstadoResultados2.AsignarDatos(this.listEstResEval);

        }

        private void cargarItemAEERR(int idEEFF, decimal nMonto)
        {
            foreach (clsEstResEval item in this.listEstResEval)
	        {
                if (item.idEEFF == idEEFF)
                {
                    item.nTotalMA = nMonto;
                }
	        }
        }

        private void cargarRcc()
        {
            if (this.objEvalCred == null)
                return;
            //DataTable dtIngresos = conIngEgre1.obtIngresos().Copy();
            var dtAux = conIngEgre1.obtIngresos();
            DataTable dtIngresos = dtAux.Clone();
            (from item in dtAux.AsEnumerable()
             select item).CopyToDataTable(dtIngresos, LoadOption.OverwriteChanges);

            var dtAux2 = conIngEgre1.obtEgresos();

            DataTable dtEgresos = dtAux2.Clone();
            (from item in dtAux2.AsEnumerable()
             select item).CopyToDataTable(dtEgresos, LoadOption.OverwriteChanges);

            dtIngresos.Columns["nMontoFlujo"].ColumnName = "nMonto";
            dtEgresos.Columns["nMontoFlujo"].ColumnName = "nMonto";
            dtIngresos.Columns["IdMoneda"].ColumnName = "idMoneda";
            dtEgresos.Columns["IdMoneda"].ColumnName = "idMoneda";

            // ==========================================================================
            // Agregando Deuda Indirecta provicionada
            // ==========================================================================
            conCreditosEval1.actualizarDiseño();
            DataTable dtDeudaIndirectaProv = conCreditosEval1.obtenerTotalDeudaIndirectaProv(); // deuda en soles
            DataRow dr1 = dtEgresos.NewRow();
            dr1["idMoneda"] = dtDeudaIndirectaProv.Rows[0]["idMoneda"];
            dr1["nMonto"] = dtDeudaIndirectaProv.Rows[0]["nMonto"];

            DataRow dr2 = dtEgresos.NewRow();
            dr2["idMoneda"] = dtDeudaIndirectaProv.Rows[1]["idMoneda"];
            dr2["nMonto"] = dtDeudaIndirectaProv.Rows[1]["nMonto"];

            dtEgresos.Rows.Add(dr1);
            dtEgresos.Rows.Add(dr2);
            // ==========================================================================
            // Agregando cuotas de deuda directa
            // ==========================================================================

            DataTable dtCuotaTotal = conCreditosEval1.obtenerCuotaDeudaDirecta();

            DataRow dr3 = dtEgresos.NewRow();
            dr3["idMoneda"] = dtCuotaTotal.Rows[0]["idMoneda"];
            dr3["nMonto"] = dtCuotaTotal.Rows[0]["nMonto"];

            DataRow dr4 = dtEgresos.NewRow();
            dr4["idMoneda"] = dtCuotaTotal.Rows[1]["idMoneda"];
            dr4["nMonto"] = dtCuotaTotal.Rows[1]["nMonto"];

            dtEgresos.Rows.Add(dr3);
            dtEgresos.Rows.Add(dr4);

            //conRcc1.cargarParametros(dtIngresos, dtEgresos, this.objEvalCred.nTipoCambio, conCreditosEval1.obtenerCuotaTotalOtrosCreditos(), conCreditosSolProp1.obtenerCuotaAproximada(), this.objEvalCred.idMoneda);
        }

        private void conIngEgre1_eHandlerCambioIngrEgre(object sender, DataGridViewCellEventArgs e)
        {
            if (this.objEvalCred == null)
                return;
            //cargarRcc();
            cargarEERR();
            calcularRatios();
        }

        private void conCreditosEval1_eClickCargarDeudas(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
                return;
            this.objEvalCred.lCargoRcc = conCreditosEval1.lEstadoCargaDeuda;
            //cargarRcc();
            cargarEERR();
            calcularRatios();
        }

        private void conCreditosEval1_eCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.objEvalCred == null)
                return;
            //cargarRcc();
            cargarEERR();
            calcularRatios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            nTran = Transaccion.Nuevo;
            controlBotones();
            habilitarFormulario(false);
            //btnAdministradorFiles1.Enabled = false;
            //btnAdministradorFiles1.idSolicitud = 0;
            btnVincularVisita1.idSolicitud = 0;
            btnVincularVisita1.idCli = 0;
        }

        private void conCreditosSolProp1_eCambioCuotaAprox(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
                return;
            //cargarRcc();
            conDestinoCredito1.Actualizar(conCreditosSolProp1.obtenerCreditoPropuesto().nMonto);
            calcularRatios();
        }

        private void conIngEgre1_eClickAgregarBorrar(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
                return;
            //cargarRcc();
            cargarEERR();
            calcularRatios();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarIndicadorObser())
            {
                MessageBox.Show("Para continuar, Ud. debe Resolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string cCumpleReglas = String.Empty;
            int nNivel = 0;
            if (!validarBool())
                return;

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada a esta evaluación, no se puede enviar a evaluación", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.objCreditoPropuesto.idOrigenCredProp = 2;
            this.objCreditoPropuesto.idSolicitud = this.objEvalCred.idSolicitud;
            this.objCreditoPropuesto.cComentarios = "PROPUESTA DE EVALUACIÓN";

            if (!ValidarReglas(true)) return;
            if (this.invocarExcepciones(true))
            {
                MessageBox.Show("Tiene que resolver todas las excepciones de reglas crediticias.", this.cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //cCumpleReglas = cnregladinamica.ValidarReglas(ArmarTablaParametros(), this.Name, clsVarGlobal.nIdAgencia,
            //        this.objEvalCred.idCli, 1, this.objEvalCred.idMoneda, this.objEvalCred.idProducto
            //        , this.objEvalCred.nCapitalPropuesto, this.objSolicitud.idSolicitud, clsVarGlobal.dFecSystem
            //        , 0, 1, clsVarGlobal.User.idUsuario, ref nNivel);

            //if (cCumpleReglas.Equals("Cumple"))
            //{

            clsCreditoProp oEvalCredTemp = this.conCreditosSolProp1.obtenerCreditoPropuesto();

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
            // -----------------------------------------------------------------------

            DataTable dtResultado = cnEval.CNEnviarAComite(
                idEvalCre, 
                clsVarGlobal.User.idUsuario, 
                clsVarGlobal.dFecSystem, 
                this.objCreditoPropuesto.GetXml(),
                idCanal,
                lCanalAproCredEditable
            );

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), cTituloMensaje, MessageBoxButtons.OK, (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }

            habilitarFormulario(false);
            nTran = Transaccion.Elimina; // botones al envio de evaluación
            controlBotones();
        }

        //private DataTable ArmarTablaParametros()
        //{
        //    DataTable dtTablaParametros = new DataTable();
        //    dtTablaParametros.Columns.Add("cNombreCampo");
        //    dtTablaParametros.Columns.Add("cValorCampo");

        //    int idUsuario = this.objEvalCred.idUsuReg;

        //    DataRow drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "idSolicitud";
        //    drfila[1] = this.objEvalCred.idSolicitud;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "idCli";
        //    drfila[1] = this.objEvalCred.idCli;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "idMoneda";
        //    drfila[1] = this.objEvalCred.idMoneda;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "nCapitalPropuesto";
        //    drfila[1] = this.objEvalCred.nCapitalPropuesto;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "nTEA";
        //    drfila[1] = this.objEvalCred.nTEA;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "idTipEvalCred";
        //    drfila[1] = this.objEvalCred.idTipEvalCred;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "lExpuestoRcc";
        //    drfila[1] = this.objEvalCred.lExpuestoRcc;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "idTipoPeriodo";
        //    drfila[1] = this.objEvalCred.idTipoPeriodo;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "nPlazoCuota";
        //    drfila[1] = this.objEvalCred.nPlazoCuota;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "nCuotas";
        //    drfila[1] = this.objEvalCred.nCuotas;
        //    dtTablaParametros.Rows.Add(drfila);

        //    drfila = dtTablaParametros.NewRow();
        //    drfila[0] = "nCuotaAprox";
        //    drfila[1] = conCreditosSolProp1.obtenerCuotaAproximada();
        //    dtTablaParametros.Rows.Add(drfila);

        //    return dtTablaParametros;
        //}

        //private bool PermitirActualizarPorExcepcion(int idSolicitud)
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
        //                cnregladinamica.ConsultaSolicitudesAprobadas(Convert.ToInt32(row["idTipoOperacion"]),
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

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (!validarBool())
                return;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            habilitarFormulario(true);
            nTran = Transaccion.Edita;
            controlBotones();
        }
        private bool validarBool()
        {
            clsMsjError obj = validar();
            if (obj.HasErrors)
            {
                MessageBox.Show("* Corrija los siguientes errores: \n" + obj.GetErrors(), cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MessageBox.Show("Se ha validado correctamente todos los items", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
            {
                MessageBox.Show("No se ha seleccionado la evaluación", "Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", "Evaluación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCred.idSolicitud, this.objEvalCred.idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void cboCatLaboral1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCatLaboral1.SelectedIndex < 0)
                return;

            if (Convert.ToInt32(cboCatLaboral1.SelectedValue) == 1)
                rbtnIndependiente.Checked = true;
            else
                rbtnDependiente.Checked = true;
        }

        private void btn_Vincular1_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud != 0)
            {
                MessageBox.Show("La evaluación ya esta vinculada a la solicitud de credito n°: " + this.objEvalCred.idSolicitud.ToString(), cTituloMensaje
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmNuevaEvConsumo frmNue = new frmNuevaEvConsumo();
            frmNue.cargarTipoEvaluacion(Convert.ToInt32(clsVarApl.dicVarGen["cIdTipoEvalCreConvenio"]), "convenio");
            frmNue.cargarEvalSinSolicitud(this.objEvalCred.idCli, this.objCreditoPropuesto, this.objEvalCred);
            frmNue.ShowDialog();
            if (frmNue.idEvalCre != 0)
            {
                limpiar();
                conCreditosEval1.CambiarEstadoLCargaFormFirst(true);
                this.idEvalCre = frmNue.idEvalCre;

                txtNombre.Text = frmNue.cNombreCliente;
                txtNroDoc.Text = frmNue.cNroDocumento;
                txtEvalCod.Text = frmNue.idEvalCre.ToString();
                txtOperacion.Text = frmNue.cOperacion;
                txtModCre.Text = frmNue.cModalidaCre;

                cargarEvaluacion(frmNue.idEvalCre);
                nTran = Transaccion.Selecciona;
                controlBotones();
                habilitarFormulario(false);
            }
        }

        private void btnObservacion1_Click(object sender, EventArgs e)
        {
            if (this.objSolicitud == null)
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", cTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmVistaObservacionesApro frmVistaObsAproSol = new frmVistaObservacionesApro(this.objSolicitud.idSolicitud);
            frmVistaObsAproSol.ShowDialog();
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            this.ValidarReglas(false);
            this.invocarExcepciones(false);
        }
        private bool invocarExcepciones(bool lSilencioso)
        {
            clsCreditoProp oEvalCredTemp = this.conCreditosSolProp1.obtenerCreditoPropuesto();

            int nIdSolicitud = Convert.ToInt32(this.objEvalCred.idSolicitud);
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            int nIdCliente = Convert.ToInt32(this.objEvalCred.idCli);
            int nIdMoneda = Convert.ToInt32(this.objEvalCred.idMoneda);
            int nIdProducto = Convert.ToInt32(this.objEvalCred.idProducto);
            decimal nValAproba = Convert.ToDecimal(oEvalCredTemp.nMonto);
            int nIdUsuRegist = Convert.ToInt32(clsVarGlobal.User.idUsuario);
            string cOpcion = this.Name;
            frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(false, nIdSolicitud, nIdCliente, nIdProducto, nValAproba, this.Name, lSilencioso);

            return (objGestionExcepcion.nPendientes > 0);
        }

        private bool ValidarReglas(bool lMostrarAlerta)
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
            //////////////////**//////////////

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
            drfila[0] = "Producto";
            drfila[1] = this.objSolicitud.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            clsCreditoProp oEvalCredTemp = this.conCreditosSolProp1.obtenerCreditoPropuesto();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazo";
            drfila[1] = this.conCreditosSolProp1.PlazoTotal();
            dtTablaParametros.Rows.Add(drfila);


                drfila = dtTablaParametros.NewRow();
                drfila[0] = "idMoneda";
                drfila[1] = this.objEvalCred.idMoneda;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "nCapitalPropuesto";
                drfila[1] = this.objEvalCred.nCapitalPropuesto;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "nTEA";
                drfila[1] = this.objEvalCred.nTEA;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "idTipEvalCred";
                drfila[1] = this.objEvalCred.idTipEvalCred;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "lExpuestoRcc";
                drfila[1] = this.objEvalCred.lExpuestoRcc;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "idTipoPeriodo";
                drfila[1] = this.objEvalCred.idTipoPeriodo;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "nPlazoCuota";
                drfila[1] = this.objEvalCred.nPlazoCuota;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "nCuotas";
                drfila[1] = this.objEvalCred.nCuotas;
                dtTablaParametros.Rows.Add(drfila);

                drfila = dtTablaParametros.NewRow();
                drfila[0] = "nCuotaAprox";
                drfila[1] = conCreditosSolProp1.obtenerCuotaAproximada();
                dtTablaParametros.Rows.Add(drfila);

            decimal nMontoProp = this.conCreditosSolProp1.obtenerMontoPropuesto();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoPropuesto";
            drfila[1] = nMontoProp;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = nMontoProp;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = objEvalCred.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred.idSolicitud > 0)
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(this.objEvalCred.idSolicitud, !this.objEvalCred.lEditar);
                frmCargaArchivo.ShowDialog();
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

        private bool ValidarIndicadorObser()
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.objSolicitud.idSolicitud, 3);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>("lResolCom"));
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            if (txtNroSol.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar una solicitud de crédito válido.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTasaNegociable frm = new frmTasaNegociable();
            frm.flowLayoutPanel2.Visible = false;
            frm.grbDato_Solicitud.Visible = false;
            frm.Size = new Size(705, 500);
            frm.BuscarSolicitud(Convert.ToInt32(txtNroSol.Text));
            frm.ShowDialog();
        }
    }
}
