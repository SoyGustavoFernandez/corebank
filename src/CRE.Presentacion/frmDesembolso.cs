using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Drawing.Printing;
using GEN.PrintHelper;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;
using DEP.CapaNegocio;
using CRE.CapaNegocio;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using GEN.Servicio;
using System.Xml;
using CLI.Servicio;
using CLI.CapaNegocio;
using ADM.CapaNegocio;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmDesembolso : frmBase
    {
        #region Variables Globales
        Int32 IdSolicitudDesembolso = 0;
        public bool lDesembolso { get; set; }
        public bool lDevolucion { get; set; }
        public int idDesembolso = 0;
        public string nDesembolso;
        CLI.CapaNegocio.clsCNRetDatosCliente datoscliente = new CLI.CapaNegocio.clsCNRetDatosCliente();
        clsCNSolicitud Solicitud = new clsCNSolicitud();
        clsRPTCNPlanPagos PPG = new clsRPTCNPlanPagos();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNBuscarCli DatosCliente = new clsCNBuscarCli();
        GEN.CapaNegocio.clsCNCredito Credito = new GEN.CapaNegocio.clsCNCredito();
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        CRE.CapaNegocio.clsCNCredito cncredito = new CapaNegocio.clsCNCredito();
        clsCNClienteVinculado clientevinculo = new clsCNClienteVinculado();
        DataTable Sol = new DataTable("dtCredito");
        DataTable dtListPPG = new DataTable();
        DateTime dfec = clsVarGlobal.dFecSystem;
        clsFunUtiles utiles = new clsFunUtiles();
        clsNumLetras numeroletras = new clsNumLetras();
        Int32 IdCliente, idProd, IdTipoPersona, nidCta = 0, idKardexAho, idKardexCre, x_nTipOpe = 0, idTasa, iduser = Convert.ToInt32(clsVarGlobal.User.idUsuario), idKardexSeg;
        Decimal nTasaComp, nComision, nMonITF;
        DataTable dtComision, tbAhoPrg, dtTodosConfigGastos, dtValidaAsignaSeguro;
        decimal nITFNormal;
        decimal nMontoPrima_Total;
        DateTime dFechaDesembolso;

        DataTable dtPlanPagSol = new DataTable();
        DataTable dtDatosModGPP = new DataTable();

        private decimal nCapitalAprobado = Decimal.Zero;
        private decimal nCapitalAmpliado = Decimal.Zero;
        private decimal nMontoTotalEntrega = Decimal.Zero;

        private const int idTipoOpeRegimenReforzado = 168;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private clsCNCreditoCargaSeguro objCNCreditoSeguro = new clsCNCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroRegistrado = new clsSolicitudCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        private clsCNControlOpe objCNControlOpe = new clsCNControlOpe();
        private bool lErrorDesembolso = false;
        private bool lBloqueoActivo = false;
        private bool lSuperaMontoExposicion = false;

        private clsCNCargaArchivo objCNCargaArchivo = new clsCNCargaArchivo();
        private clsAdministracionEnvioSMS objAdministracionEnvioSMS = new clsAdministracionEnvioSMS();
        private clsBiometrico oBiometrico = new clsBiometrico();

        private clsAdministracionEnvioSMS objAdminEnvioSMSNotificacion = new clsAdministracionEnvioSMS();
        List<clsSolicitudCreditoSeguro> listaSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
        #endregion

        public frmDesembolso()
        {
            InitializeComponent();
            conBusCuentaCli1.cTipoBusqueda = "S";
            conBusCuentaCli1.cEstado = "[2]";
            x_nTipOpe = 1;
            objAdministracionEnvioSMS.cargarDatosGenerales();
            objAdministracionEnvioSMS.cargarPlantillaPlanPagos();

            int idTPlantillaSMS = 0;
            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("idTipoPSMSNotificacion")))
            {
                clsVarGen objVarTipoPlantilla = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("idTipoPSMSNotificacion"));
                idTPlantillaSMS = Convert.ToInt32(objVarTipoPlantilla.cValVar);
            }

            objAdminEnvioSMSNotificacion.cargarDatosGenerales();
            objAdminEnvioSMSNotificacion.cargarDatosPlantilla(idTPlantillaSMS);

        }
        public frmDesembolso(int idSol, List<clsSolicitudCreditoSeguro> lstCreditoSeguro)
        {
            InitializeComponent();
            conBusCuentaCli1.cTipoBusqueda = "S";
            conBusCuentaCli1.cEstado = "[2]";
            conBusCuentaCli1.txtNroBusqueda.Text = Convert.ToString(idSol);
            conBusCuentaCli1.txtNroBusqueda.Focus();
            x_nTipOpe = 1;
            objAdministracionEnvioSMS.cargarDatosGenerales();
            objAdministracionEnvioSMS.cargarPlantillaPlanPagos();

            int idTPlantillaSMS = 0;
            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("idTipoPSMSNotificacion")))
            {
                clsVarGen objVarTipoPlantilla = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("idTipoPSMSNotificacion"));
                idTPlantillaSMS = Convert.ToInt32(objVarTipoPlantilla.cValVar);
            }

            objAdminEnvioSMSNotificacion.cargarDatosGenerales();
            objAdminEnvioSMSNotificacion.cargarDatosPlantilla(idTPlantillaSMS);

            IdSolicitudDesembolso = idSol;
            listaSolicitudCreditoSeguro = lstCreditoSeguro;
        }

        #region Eventos

        private void BuscarSolicitud(Int32 CodigoSol)
        {
            if (CodigoSol == 0)
            {
                MessageBox.Show("Ingrese un número de solicitud válida", "Valida Solicitud de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                conBusCuentaCli1.txtNroBusqueda.Focus();
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = true;
                return;
            }

            Sol = Solicitud.SolicitudDesembolso(CodigoSol);

            if (Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]) == 4)
            {
                MessageBox.Show("Modalidad Desembolso: BANCO DE LA NACIÓN, No permitido.", "Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cancelarDesembolso();
                return;
            }

            if (Sol.Rows.Count > 0)
            {
                #region Validacion de Extra Prima Completo
                DataTable dtExtraPrima = Solicitud.CNObtenerExtraPrima(CodigoSol);
                if (dtExtraPrima.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dtExtraPrima.Rows[0]["lCompletado"]) == 0)
                    {
                        MessageBox.Show("Se tiene modificaciones en la Extra Prima pero no se ha completado la generación de plan de pagos, por favor complete el proceso de generación de Plan de Pagos.",
                        "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiar();
                        conBusCuentaCli1.txtNroBusqueda.Focus();
                        btnGrabar1.Enabled = false;
                        btnCancelar1.Enabled = false;
                        return;
                    }
                }
                #endregion

                if (Convert.ToInt32(Sol.Rows[0]["idSolicitudCredGrupoSol"]) > 0)
                {
                    MessageBox.Show("No se puede realizar la operación de desembolso para créditos de GRUPO SOLIDARIO en este formulario.",
                        "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    return;
                }

                int idCuentaBloqueo = Convert.ToInt32(Sol.Rows[0]["idCuenta"]);
                if (!ValidarBloqueo(idCuentaBloqueo))
                {
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    return;
                }
                else
                {
                    BloquearCuenta(idCuentaBloqueo);
                    lBloqueoActivo = true;
                }

                #region Carga de Archivos
                DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text));
                if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
                {
                    MessageBox.Show(
                    dtCargaArchivos.Rows[0]["cMsg"].ToString(), "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    return;
                }
                #endregion

                #region ValidarContraDepositos
                clsListDetGarantia dtGarantias = new clsCNGarantia().listarGarVinculadasSol(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text));

                bool lEstado = true;
                string cMensaje = "Observaciones: \n";
                foreach (clsDetGarantia dtGrt in dtGarantias)
                {
                    if (Convert.ToBoolean(dtGrt.lReqCtaDep))
                    {
                        DataTable dtDeposito = new clsCNGarantia().CNValidaCuentaDeposito(Convert.ToInt32(dtGrt.idGarantia), Convert.ToDecimal(dtGrt.nMonGravado), Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text));
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

                DataTable dtReaprob = new clsCNReaprobSol().obtenerReaprobacion(CodigoSol);
                if (Convert.ToInt32(Sol.Rows[0]["idOperacion"]).In(2, 6))
                {
                    MessageBox.Show("No se puede realizar la operación de desembolso para creditos de REFINANCIAMIENTO Y NOVACION en este formulario.\nUse la opcion de 'Ope. Refinanciación'", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    return;
                }

                if (Convert.ToInt32(Sol.Rows[0]["idOperacion"]) == 4 && verificarCuentaAmpliacion())
                {
                    cancelarDesembolso();
                    return;
                }


                if (dtReaprob.Rows.Count > 0)
                {
                    MessageBox.Show("Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edicion finalice.", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    return;
                }

                if (!validarRegistroPagare(CodigoSol))
                {
                    limpiar();
                    conBusCuentaCli1.txtNroBusqueda.Focus();
                    btnGrabar1.Enabled = false;
                    return;
                }

                objSolicitudCreditoSeguroRegistrado = objCNCreditoSeguro.CNObtenerSolicitudCargaSeguro(CodigoSol);

                decimal nMontoPrima_Estimado = 0;

                foreach (clsSolicitudCreditoSeguro objSeguro in objSolicitudCreditoSeguroRegistrado.lstSolicitudCreditoSeguro)
                {
                    if (!objSeguro.lPagoCuotas && objSeguro.lSeleccionado)
                    {
                        nMontoPrima_Estimado += objSeguro.nMontoPrima;
                    }
                }

                this.dtPlanPagSol = new clsCNReaprobSol().obtenerPlanPagosSol(CodigoSol);
                this.dtDatosModGPP = new clsCNReaprobSol().obtenerDatosModGPP(CodigoSol);

                dtpFechaSol.Value = Convert.ToDateTime(Sol.Rows[0]["dFechaRegistro"]);
                txtMonto.Text = Convert.ToString(Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"]));
                cboMoneda.SelectedValue = Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                txtNroCuotas.Text = Convert.ToString(Sol.Rows[0]["nCuotas"]);
                txtMonPriCuo.Text = Convert.ToString(Sol.Rows[0]["nMontoCuota"]);
                dtpFecPriCuo.Value = Convert.ToDateTime(Sol.Rows[0]["dFechaProg"]);
                cboModDesemb1.SelectedValue = Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]);
                IdCliente = Convert.ToInt32(Sol.Rows[0]["idCli"]);
                dFechaDesembolso = Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);

                int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);

                this.nCapitalAprobado = Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"]);
                this.nCapitalAmpliado = (Convert.ToDecimal(Sol.Rows[0]["nMontoAmpliado"]) > 0) ? Convert.ToDecimal(Sol.Rows[0]["nMontoAmpliado"]) - nMontoPrima_Estimado : 0;
                this.nMontoTotalEntrega = nCapitalAprobado - nMontoPrima_Estimado;
                txtMontoAmpliado.Text = Convert.ToString(nCapitalAmpliado);

                int idCuentaDeposito = Convert.ToInt32(Sol.Rows[0]["idCuentaDeposito"]);
                string cNroCuentaDeposito = Convert.ToString(Sol.Rows[0]["cNroCuentaDeposito"]);
                bool lCuentaDepositoAutomatico = Convert.ToBoolean(Sol.Rows[0]["lCuentaDepositoAutomatico"]);

                lblMontoEntregar.Text = idOperacion == 4 ? "Total" : "Monto a entregar";
                lblMontoAmpliado.Text = idOperacion == 4 ? "Monto ampliado a entregar" : "Monto ampliado";
                if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 2)
                {
                    if (idCuentaDeposito != 0)
                    {
                        txtCuentaAho.Text = cNroCuentaDeposito;
                        txtIdCtaAho.Text = Convert.ToString(idCuentaDeposito);
                        this.btnBuscaCtaAho.Enabled = false;
                    }
                    else
                    {
                        txtIdCtaAho.Text = "";
                        txtCuentaAho.Text = "";
                        this.btnBuscaCtaAho.Enabled = true;
                    }
                }
                else
                {
                    txtIdCtaAho.Text = "";
                    txtCuentaAho.Text = "";
                    this.btnBuscaCtaAho.Enabled = false;
                    this.chkApertCtaAho.Enabled = false;
                }


                if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
                {
                    rbtSI.Enabled = true;
                    rbtNO.Enabled = true;
                }
                else
                {
                    rbtSI.Enabled = false;
                    rbtNO.Enabled = false;
                }
                rbtNO.Checked = true;

                //Seguro Desgravamen
                //Definir el tipo de Operación  (DESEMBOLSO), Menu(Formulario frmDesembolso), y el canal VENTANILLA
                ADM.CapaNegocio.clsCNConfigGastComiSeg ConfigGastComiSeg = new ADM.CapaNegocio.clsCNConfigGastComiSeg();
                int nTipoOperacion = 1, nIdMenu = 18;
                int nNumSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);

                //================================================================================
                // Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos
                //================================================================================
                ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
                dtTodosConfigGastos = objSegDes.validarAplicaSeguroDesgravamen(nNumSolicitud, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal);
                //================================================================================
                // Fin Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos
                //================================================================================

                //dtTodosConfigGastos = ConfigGastComiSeg.ValidarSolicitudConfigGastComiSeg(nNumSolicitud, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal);


                Decimal nTasSeg = 0;
                if (dtTodosConfigGastos.Rows.Count > 0)
                {
                    nTasSeg = Convert.ToDecimal(dtTodosConfigGastos.Rows[0]["nValor"]);
                }
                if (dtTodosConfigGastos.Rows.Count > 0)
                {
                    dtValidaAsignaSeguro = Credito.CNValidaAplicaSegDes(IdCliente, clsVarGlobal.dFecSystem);
                    if (Convert.ToInt16(dtValidaAsignaSeguro.Rows[0]["nResultado"]) == 0)
                    {
                        nTasSeg = 0;
                    }
                }

                calcularMontoFinal();
                txtSeguros.Text = string.Format("{0:0.00}", (Convert.ToDecimal(txtMontTotal.Text) * nTasSeg / 100.00m) + nMontoPrima_Estimado);

                if (Convert.ToInt32(Sol.Rows[0]["nMontoAmpliado"]) > 0) // Ampliacion
                {
                    this.txtMontoAmpliado.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    this.txtMontTotal.BackColor = System.Drawing.Color.LightGreen;
                    this.txtMontoAmpliado.BackColor = System.Drawing.Color.WhiteSmoke;
                }
                if (dFechaDesembolso != clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("La fecha de desembolso sugerida no puede ser diferente a la fecha del sistema. Verifique", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGrabar1.Enabled = false;
                    return;
                }

                btnGrabar1.Enabled = true;
                btnCancelar1.Enabled = true;
                cboRptImpCre.Enabled = true;
                txtCodigoCuenta.Text = "";
            }
            else
            {
                MessageBox.Show("Solicitud no tiene Plan de Pagos generado", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                btnGrabar1.Enabled = false;
                btnCancelar1.Enabled = true;
                return;
            }
            cboRptImpCre.Enabled = false;

            cargarConfiguracionSeguro();
            objAdministracionEnvioSMS.cargarDatosOperacion(CodigoSol, Convert.ToInt32(Sol.Rows[0]["IdMoneda"]), Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"]), idProd, 1);
        }

        private void btnGrabar1_Click(object sender, System.EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            int idOpeSol = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            int idProducto = Convert.ToInt32(Sol.Rows[0]["idProducto"]);
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusCuentaCli1.nIdCliente,
                                                                               (int)cboMoneda.SelectedValue,
                                                                               idProducto,
                                                                               conBusCuentaCli1.nValBusqueda,
                                                                               idOpeSol == 4 ? Convert.ToDecimal(txtMontoAmpliado.Text.Trim()) :
                                                                                                        Convert.ToDecimal(txtMonto.Text.Trim()));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            //VALIDA CLIENTE PEP
            string mensaje = "",
                        x_cNroDni = "";
            int x_idEstApr = 0;
            int CodCliente = conBusCuentaCli1.nIdCliente;
            int CodidTipoDocumento = conBusCuentaCli1.idTipoDocumento;
            if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
            {
                MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (x_idEstApr == 1) //--Solicitado
                {
                    frmPep frmPepx = new frmPep(CodidTipoDocumento, x_cNroDni);
                    frmPepx.ShowDialog();
                }
                return;
            }

            if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
            {
                int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                Decimal nMonto;

                if (idOperacion == 4) // Ampliacion
                {
                    nMonto = Convert.ToDecimal(this.txtMontoAmpliado.Text.Trim());
                }
                else
                {
                    nMonto = Convert.ToDecimal(this.txtMonto.Text.Trim());
                }

                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(cboMoneda.SelectedValue), 2, nMonto - Convert.ToDecimal(txtImpuesto.Text)))
                {
                    return;
                }
            }

            #region Validacion Huella
            int idModalidadDesembolso = Convert.ToInt32(cboModDesemb1.SelectedValue);
            if (idModalidadDesembolso == 1 && !validarHuella())
            {
                return;
            }
            #endregion

            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = Convert.ToDecimal(txtMonto.Text.Trim());
            int idMonedaUm = Convert.ToInt16(cboMoneda.SelectedValue);
            int idMotivoOpe = (((int)cboModDesemb1.SelectedValue) == 4) ? 14 : 13;//Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            int idSubProducto = conBusCuentaCli1.idProducto;
            int idTipoPago = 1;
            int idTipoOperacion = 1;

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion


            //=================  Registro Inicio Rastreo ===================================
            this.registrarRastreo(conBusCuentaCli1.nIdCliente, Convert.ToInt32(Sol.Rows[0]["idCuenta"]), "Inicio - Registro de Desembolso", btnGrabar1);
            //==============================================================================

            insertar();
            if (lErrorDesembolso)
            {
                return;
            }

            //=================  Registro de Oferta Efectivo al Instante ===================

            DataTable dtRegistrarOfertaEAI = new DataTable();

            dtRegistrarOfertaEAI = Credito.CNRegistrarOfertaEAI(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), Convert.ToDecimal(txtMonto.Text));

            if (Convert.ToInt32(dtRegistrarOfertaEAI.Rows[0]["idMsg"].ToString()) == 0)
            {
                MessageBox.Show("Oferta Registrada Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(dtRegistrarOfertaEAI.Rows[0]["idMsg"].ToString()) == 1)
            {
                MessageBox.Show("Error al Registrar la Oferta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //==============================================================================

            clsCNImpresion Imprimir = new clsCNImpresion();

            //if (idKardexAho > 0)
            //{
            //    DataTable dtActKardexRel = new DataTable();
            //    dtActKardexRel = Credito.CNUpdKardexRelDesem(idKardexCre, idKardexAho);
            //    DataTable dtDatosOperacion1 = Imprimir.CNDatosOperacion(idKardexAho, 2, nMontoRecibido: 0, nMontoDev: 0, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            //    /* IMPRESION CON IMPRESORA TERMICA
            //    //Impresion de Voucher de Depositos
            //    if (dtDatosOperacion1.Rows.Count > 0)
            //    {
            //        string cCadena = Convert.ToString(Imprimir.CNImpresionVoucher(1, 10, dtDatosOperacion1, 1));

            //        if (string.IsNullOrEmpty(cCadena))
            //        {
            //            MessageBox.Show("Ocurrió un problema al intentar imprimir", "Extorno de Operación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //        //else
            //        //{
            //        //    List<ReportDataSource> dtslist = new List<ReportDataSource>();
            //        //    List<ReportParameter> paramlist = new List<ReportParameter>();
            //        //    paramlist.Add(new ReportParameter("cTexto", cCadena, false));
            //        //    paramlist.Add(new ReportParameter("cNombreVariable", clsVarApl.dicVarGen["CRUTALOGO"], false));
            //        //    string reportpath = "rptVoucher.rdlc";
            //        //    new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
            //        //}
            //    }*/

            //    //Emisión de Vouchera
            //    DataTable dtCobro = new clsRPTCNDeposito().CNDetalleTransaccion(idKardexAho, true);
            //    EmitirVoucher(dtCobro, idKardexAho);

            //}

            List<clsSolicitudCreditoSeguro> lstSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
            if (objSolicitudCreditoSeguroActual.lAceptacionListaSeguro)
            {
                lstSolicitudCreditoSeguro = confirmarSeguroCredito(conBusCuentaCli1.nValBusqueda, idKardexCre);
            }
            //Emision de Voucher Desembolso
            DateTime dFechaUnificacion = clsVarGlobal.dFecSystem;
            clsVarGen objFechaVoucherUni = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("dFechaVoucherUnificado"));
            dFechaUnificacion = (objFechaVoucherUni == null) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(objFechaVoucherUni.cValVar);

            if (clsVarGlobal.dFecSystem >= dFechaUnificacion)
            {
                ImpresionVoucherRelacionado(nIdKardex: idKardexCre, idModulo: 1, idTipoOpe: 1, idEstadoKardex: 1,
                            nValRec: 0,
                            nValdev: 0,
                            idKardexAd: 0, idTipoImpresion: 1);
            }
            else
            {
                ImpresionVoucher(nIdKardex: idKardexCre, idModulo: 1, idTipoOpe: 1, idEstadoKardex: 1,
                            nValRec: 0,
                            nValdev: 0,
                            idKardexAd: 0, idTipoImpresion: 1);
            }

            /*===============================================================================
                REALIZA VALIDACION DE REGISTRO DE OPERACIONES SPLAFT
                ===============================================================================*/
            if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
            {
                //Solo para desembolso en efectivo
                frmRegOpeSplaft regope = new frmRegOpeSplaft(this.idKardexCre, 2);
            }
            else if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 2)
            {
                //Solo para el Deposito a Cuenta
                frmRegOpeSplaft regope = new frmRegOpeSplaft(this.idKardexAho, 2);
            }

            //Validacion de Declaracion Jurada de Sujetos Obligados
            frmDeclaracionJurada declara = new frmDeclaracionJurada(Convert.ToInt32(this.conBusCuentaCli1.nIdCliente));
            //this.objFrmSemaforo.ValidarSaldoSemaforo();

            DataTable dtClienteBono = Solicitud.CNRecuperarBonoClienteCamp(Convert.ToInt32(Sol.Rows[0]["idCli"]), Convert.ToInt32(Sol.Rows[0]["idSolicitud"]));
            if (dtClienteBono.Rows.Count > 0)
            {
                objAdminEnvioSMSNotificacion.cargarDatosOperacion(Convert.ToInt32(Sol.Rows[0]["idSolicitud"]), Convert.ToInt32(Sol.Rows[0]["idMoneda"]), Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"]), Convert.ToInt32(Sol.Rows[0]["idProducto"]), 1);
                objAdminEnvioSMSNotificacion.registrarNotificacion();
            }
            //=================================================================================================
            objAdministracionEnvioSMS.asociarNotificacionKardex(idKardexCre);
            //=================================================================================================

            /*  Guardar Expedientes - Grupo Desembolso  */

            if (Convert.ToBoolean(Sol.Rows[0]["lCredirappPlus"]))
            {
                MessageBox.Show("Se procederá a guardar los Expedientes necesarios para este proceso.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool resExpSol = clsProcesoExp.guardarCopiaExpediente("Solicitud de Credito", Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), this, "individual", false);
                bool resExpAprob = clsProcesoExp.guardarCopiaExpediente("Aprobacion de Credito", Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), this, "individual", false);
                bool resExpDes = clsProcesoExp.guardarCopiaExpediente("Desembolso de Credito", Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), this, "individual", false);
                if (resExpSol && resExpAprob && resExpDes)
                {
                    MessageBox.Show("Se guardó correctamente los Expedientes necesarios para este proceso.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al Guardar los Expedientes, sin embargo el proceso de desembolso puede continuar.", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                clsProcesoExp.guardarCopiaExpediente("Desembolso de Credito", Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), this);
            }

            if (!lErrorDesembolso && lBloqueoActivo)
            {
                LiberarCuenta(Convert.ToInt32(Sol.Rows[0]["idCuenta"]));
                lBloqueoActivo = false;
            }

            if (idModalidadDesembolso == 1 && clsVarGlobal.User.lAutBiometricaAgencia)
            {
                oBiometrico.registrarOperacionKardexExcepcion(idKardexCre);
            }
            //=================   Registro Fin Rastreo    ================================
            this.registrarRastreo(conBusCuentaCli1.nIdCliente, Convert.ToInt32(Sol.Rows[0]["idCuenta"]), "Fin - Registro de Desembolso", btnGrabar1);
            //============================================================================   

            //this.gestionarGrupoSolidarioBono(CodCliente);

            EncuestaExperienciaCliente();

        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            int idSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            BuscarSolicitud(idSol);
            chkApertCtaAho.Checked = false;

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli1.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        private void conBusCuentaCli1_MyClic(object sender, System.EventArgs e)
        {
            int idSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            BuscarSolicitud(idSol);
            chkApertCtaAho.Checked = false;

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli1.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        private void frmDesembolso_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            cboEntidadCheGer.CargarEntidadesFondeo(0, "T");
            if (IdSolicitudDesembolso != 0)
            {
                conBusCuentaCli1.asignarCuenta(IdSolicitudDesembolso);
                BuscarSolicitud(IdSolicitudDesembolso);
                chkApertCtaAho.Checked = false;

                if (idDesembolso != Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]))
                {
                    DialogResult respMsg = MessageBox.Show("Ha realizado un cambio Mod. Desembolso: \n[" + nDesembolso + "] el cual no fue grabado. " + "\n\n Desea continuar con la operación?", "Desembolso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respMsg == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btnImprimir1_Click_1(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();


            int nNumCredito = Convert.ToInt32(txtCodigoCuenta.Text);
            dtListPPG = PPG.CNCronogramaCredito(nNumCredito);
            dtListPPG.Columns["nITF"].ReadOnly = false;

            for (int i = 0; i < dtListPPG.Rows.Count; i++)
            {
                dtListPPG.Rows[i]["nITF"] = utiles.truncar(((Convert.ToDecimal(dtListPPG.Rows[i]["nCapital"]) + Convert.ToDecimal(dtListPPG.Rows[i]["nInteres"]) + Convert.ToDecimal(dtListPPG.Rows[i]["nOtros"])) * (Decimal)clsVarGlobal.nITF) / 100.00m, 2, 1);
            }

            dtslist.Add(new ReportDataSource("dtsPPG", dtListPPG));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(nNumCredito)));

            if (cboRptImpCre.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Reporte para Imprimir", "Valida Reportes de Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboRptImpCre.Focus();
                this.cboRptImpCre.SelectAll();
            }
            else
            {
                int RPTImp = Convert.ToInt32(cboRptImpCre.SelectedValue);
                switch (RPTImp)
                {
                    case 1://Plan de pago
                        {
                            paramlist.Clear();
                            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlist.Add(new ReportParameter("idCliente", this.conBusCuentaCli1.nIdCliente.ToString(), false));
                            paramlist.Add(new ReportParameter("nNumCredito", nNumCredito.ToString(), false));
                            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
                            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

                            dtslist.Add(new ReportDataSource("dtsAgencia", new clsRPTCNAgencia().CNAgenciaUsuario(clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario)));
                            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNdocumento(IdCliente)));

                            string reportpath = "RptCalendarioCredito.rdlc";
                            new frmReporteLocal(dtslist, reportpath).ShowDialog();
                        }
                        break;
                    case 2://Pagare
                        {
                            int idSolicitud = conBusCuentaCli1.nValBusqueda;
                            int idCliente = conBusCuentaCli1.nIdCliente;

                            numeroletras.SeparadorDecimalSalida = "con ";
                            numeroletras.MascaraSalidaDecimal = Convert.ToInt32(this.cboMoneda.SelectedValue) == 1 ? "/100 Nuevos Soles" : "/100 Dólares Americanos";
                            string cMontoLetras = numeroletras.ToCustomCardinal(Convert.ToDecimal(txtMontTotal.Text));
                            string cFechaLugar = "Lima " + new clsCNMeses().retornarFechaDescMes();
                            dtslist.Clear();
                            paramlist.Clear();
                            dtslist.Add(new ReportDataSource("dsDatosPagare", cncredito.DatosImpPagare(idSolicitud)));
                            dtslist.Add(new ReportDataSource("dsRepresentante", clientevinculo.ListaClienteVinculado(idCliente)));
                            dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));

                            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                            paramlist.Add(new ReportParameter("cFechaLugar", cFechaLugar, false));
                            paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                            string reportpath = "rptPagareCredito_01.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                            dtslist.Clear();
                            paramlist.Clear();
                            dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));

                            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            paramlist.Add(new ReportParameter("cFechaLugar", cFechaLugar, false));
                            reportpath = "rptPagareCredito_02.rdlc";
                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

                        }
                        break;
                    case 3://Contrato de credito
                        {
                            int idSolicitud = conBusCuentaCli1.nValBusqueda;
                            int idCliente = conBusCuentaCli1.nIdCliente;
                            var dtCliente = datoscliente.ListarDatosCli(idCliente, "O");
                            int idTipoPersona = Convert.ToInt32(dtCliente.Rows[0][0]);
                            var dtCooperativa = DatosCliente.ListarClientes("3", clsVarApl.dicVarGen["cRUC"]);
                            int idCliCoop = Convert.ToInt32(dtCooperativa.Rows[0][0]);
                            string reportpath = "";
                            numeroletras.SeparadorDecimalSalida = "con ";
                            numeroletras.MascaraSalidaDecimal = Convert.ToInt32(this.cboMoneda.SelectedValue) == 1 ? "/100 Nuevos Soles" : "/100 Dólares Americanos";
                            string cMontoLetras = numeroletras.ToCustomCardinal(Convert.ToDecimal(txtMontTotal.Text));
                            dtslist.Clear();
                            paramlist.Clear();

                            //if (idTipoPersona==1)
                            //{
                            dtslist.Add(new ReportDataSource("dsContratoNatural", cncredito.DatosImpContratoNat(idSolicitud)));
                            dtslist.Add(new ReportDataSource("dsRepresentanteCoop", cncredito.ListaRepresentanteJur(idCliCoop)));
                            dtslist.Add(new ReportDataSource("dsInterviniente", cncredito.DetalleImpPagare(idSolicitud)));
                            dtslist.Add(new ReportDataSource("dsDetallePagare", cncredito.DetalleImpPagare(idSolicitud)));
                            dtslist.Add(new ReportDataSource("dsRepresentanteJur", cncredito.ListaRepresentanteJur(idCliente)));

                            paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            paramlist.Add(new ReportParameter("idCliCoop", idCliCoop.ToString(), false));
                            paramlist.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                            paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                            reportpath = "rptContrato.rdlc";
                            //}
                            //else
                            //{
                            //    dtslist.Add(new ReportDataSource("dsInterviniente", cncredito.DetalleImpPagare(idSolicitud)));
                            //    dtslist.Add(new ReportDataSource("dsRepresentanteCoop", cncredito.ListaRepresentanteJur(idCliCoop)));
                            //    dtslist.Add(new ReportDataSource("dsRepresentanteJur", cncredito.ListaRepresentanteJur(idCliente)));
                            //    dtslist.Add(new ReportDataSource("dsContratoJuridico", cncredito.DatosImpContratoJur(idSolicitud)));

                            //    paramlist.Add(new ReportParameter("idSolicitud", idSolicitud.ToString(), false));
                            //    paramlist.Add(new ReportParameter("idCliCoop", idCliCoop.ToString(), false));
                            //    paramlist.Add(new ReportParameter("idCli", idCliente.ToString(), false));
                            //    paramlist.Add(new ReportParameter("cMontoLetras", cMontoLetras, false));
                            //    reportpath = "rptContratoPerJuridica.rdlc";
                            //}

                            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                        }
                        break;
                    case 4://Hoja resumen
                        {
                            string reportpath = "RptHojaResumen.rdlc";
                            new frmReporteLocal(dtslist, reportpath).ShowDialog();
                        }
                        break;
                    default:
                        MessageBox.Show("Seleccione el Reporte a Imprimir");
                        break;
                }
            }
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            frmChequePorCliente frmChequeByCli = new frmChequePorCliente();
            frmChequeByCli.idCli = conBusCuentaCli1.nIdCliente.ToString();
            frmChequeByCli.idMoneda = (int)cboMoneda.SelectedValue;
            frmChequeByCli.idMotOpeBco = 0; // Todos
            frmChequeByCli.ShowDialog();
            txtNroCuentaGer.Text = frmChequeByCli.cNumeroCuenta;
            txtNroCheqGer.Text = frmChequeByCli.nNroCheque;
            txtSerieCheqGer.Text = frmChequeByCli.nSerie;
            cboEntidadCheGer.SelectedValue = (int)frmChequeByCli.idEntidad;
            cboMonedaCheGer.SelectedValue = (int)frmChequeByCli.idMoneda;
            txtMontoCheGer.Text = frmChequeByCli.nMontoCheque.ToString();
        }

        private void cboModDesemb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Int32)cboModDesemb1.SelectedValue == 3)
            {
                grbDatosCheque.Enabled = true;
            }
            else
            {
                grbDatosCheque.Enabled = false;
            }


        }

        private void rbtSI_CheckedChanged(object sender, EventArgs e)
        {
            calcularMontoFinal();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cancelarDesembolso();
        }

        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            frmBusCtaAho frmCtaAho = new frmBusCtaAho();
            frmCtaAho.idCli = IdCliente;
            frmCtaAho.pTipBus = 1;
            frmCtaAho.idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            frmCtaAho.nTipOpe = 17;  //--Cuentas para desembolso

            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNRetornaCuentasAhorros(IdCliente, 1, Convert.ToInt32(cboMoneda.SelectedValue), 1);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                frmCtaAho.ShowDialog();
                txtIdCtaAho.Text = frmCtaAho.pnCta;
                txtCuentaAho.Text = frmCtaAho.pcNroCta;
            }
            else
            {
                MessageBox.Show("NO EXISTE CUENTA DE AHORRO PARA VINCULAR" + "\n" + "Debe Aperturar una cuenta de ahorro nueva para el Desembolso", "Validar Desembolso de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdCtaAho.Text = "";
                txtCuentaAho.Text = "";
                return;
            }
        }

        #endregion

        #region Métodos

        private void limpiar()
        {
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";
            txtMonPriCuo.Text = "";
            txtMonto.Text = "";
            txtNroCuotas.Text = "";
            txtImpuesto.Text = "";
            txtMontTotal.Text = "";
            txtMontoAmpliado.Text = "";
            btnGrabar1.Enabled = true;
            cboRptImpCre.Enabled = false;
            cboModDesemb1.SelectedIndex = 0;
            btnBuscaCtaAho.Enabled = false;
            txtCodigoCuenta.Text = "";
            txtIdCtaAho.Text = "";
            txtCuentaAho.Text = "";
            chkApertCtaAho.Checked = false;
            chkApertCtaAho.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            txtNroCuentaGer.Clear();
            txtNroCheqGer.Clear();
            txtSerieCheqGer.Clear();
            cboEntidadCheGer.SelectedValue = 1;
            cboMonedaCheGer.SelectedValue = 1;
            txtMontoCheGer.Clear();
            this.txtMontTotal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMontoAmpliado.BackColor = System.Drawing.Color.WhiteSmoke;

            if (Sol.Rows.Count > 0 && lBloqueoActivo)
            {
                LiberarCuenta(Convert.ToInt32(Sol.Rows[0]["idCuenta"]));
                lBloqueoActivo = false;
            }
            objAdministracionEnvioSMS.limpiarOperacion();
            objAdminEnvioSMSNotificacion.limpiarOperacion();

            if (IdSolicitudDesembolso != 0)
            {
                this.Close();
            }
        }

        private bool validar()
        {
            if (Convert.ToInt32(Sol.Rows[0]["idModalidadDes"]) == 2 && txtIdCtaAho.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar o seleccionar un Número de Cta. Ahorros.", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text))
            {
                MessageBox.Show("Debe ingresar un Número de solicitud", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCuentaCli1.Focus();
                this.conBusCuentaCli1.txtNroBusqueda.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNombreCli.Text))
            {
                MessageBox.Show("No existen Datos de Cliente para esta solicitud", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.conBusCuentaCli1.Focus();
                this.conBusCuentaCli1.txtNroBusqueda.SelectAll();
                return false;
            }
            //if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 2)
            //{
            //    if (chkApertCtaAho.Checked == false && string.IsNullOrEmpty(txtCuentaAho.Text))
            //    {
            //        MessageBox.Show("Falta Vincular a una Cuenta de Ahorro para el Depósito del Desembolso" + "\n" + " o Aperture una, con el CHECK de Apertura", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return false;
            //    }
            //}
            if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 3)
            {
                if (string.IsNullOrEmpty(txtNroCuentaGer.Text))
                {
                    MessageBox.Show("Número de Cuenta no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtNroCheqGer.Text))
                {
                    MessageBox.Show("Número de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtSerieCheqGer.Text))
                {
                    MessageBox.Show("Número de Serie de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMontoCheGer.Text))
                {
                    MessageBox.Show("Monto de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
                if (Convert.ToDecimal(txtMontoCheGer.Text) <= 0)
                {
                    MessageBox.Show("El Monto de Cheque no Puede ser Cero(0)", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
                Decimal nMonto = 0;
                int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                if (idOperacion == 4) // Ampliacion
                {
                    nMonto = Convert.ToDecimal(this.txtMontoAmpliado.Text.Trim());
                }
                else
                {
                    nMonto = Convert.ToDecimal(this.txtMonto.Text.Trim());
                }
                if (Convert.ToDecimal(txtMontoCheGer.Text) != nMonto)
                {
                    MessageBox.Show("El Monto de Cheque no Puede ser Diferente al Monto del Desembolso", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBusqueda1.Focus();
                    return false;
                }
            }
            DataTable ValidaMontoAdeudado = Credito.CNValidaMontoAdeudado(Convert.ToInt32(Sol.Rows[0]["idSolicitud"]), clsVarGlobal.nIdAgencia);
            int nValida = Convert.ToInt32(ValidaMontoAdeudado.Rows[0]["nValido"]);
            if (nValida == 0)
            {
                MessageBox.Show("Los Fondos del Adeudado son insuficientes para cubrir el Desembolso", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            CRE.CapaNegocio.clsCNCredito Creditos = new CRE.CapaNegocio.clsCNCredito();
            DataTable dtMorcli = new DataTable();
            dtMorcli = Creditos.CNdtSumMorCli(IdCliente);
            Decimal nSalMorCli = Convert.ToDecimal(dtMorcli.Rows[0][0]);
            if (nSalMorCli > 0)
            {
                MessageBox.Show("El cliente tiene Créditos Vigentes en Mora, consulte Posición del Cliente", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            String cCumpleReglas = "";
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCli1.nIdCliente),//Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                                                   1, Convert.ToInt32(cboMoneda.SelectedValue), Convert.ToInt32(Sol.Rows[0]["idProducto"]),
                                                   Decimal.Parse(txtMonto.Text), Convert.ToInt32(Sol.Rows[0]["idSolicitud"]), clsVarGlobal.dFecSystem,
                                                   2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }
            DataTable dtReaprob = new clsCNReaprobSol().obtenerReaprobacion(this.conBusCuentaCli1.nValBusqueda);
            if (dtReaprob.Rows.Count > 0)
            {
                MessageBox.Show("Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edicion finalice.", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!validarPlanPagosMod())
            {
                MessageBox.Show("Las condiciones de la solcitud no coinciden con el plan de pago generado, por favor genere uno nuevamente", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DataTable dtEstadoSolicitud = Solicitud.CNObtenerEstadoSolicitud(conBusCuentaCli1.nValBusqueda);

            if (Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]) == 5)
            {
                MessageBox.Show("La solicitud ya fue desembolsado, por favor revisar", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]) == 3)
            {
                MessageBox.Show("No se puede desembolsar, el crédito ha sido cancelado", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!ValidarSolicitudPendientePaquete())
            {
                return false;
            }

            #region SeguroOncologico
            try
            {
                if (!ValidarCambioPrecioSeguros())
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion 

            return true;
        }

        #region SeguroOncologico
        private bool ValidarCambioPrecioSeguros()
        {
            try
            {
                clsSolicitudCreditoSeguro objSeguroOncologico = objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.lSeleccionado && x.idTipoSeguro == Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]));

                if (objSeguroOncologico != null)
                {
                    List<clsSolicitudCreditoSeguro> x_solicitud = objCNCreditoSeguro.CNObtenerSolicitudSeguroTipo(objSolicitudCreditoSeguroActual.idSolicitud);

                    //bool solicitudRechazada = Convert.ToBoolean(x_solicitud.Rows[0]["SolPlanRechazada"]);

                    //if (solicitudRechazada)
                    //{
                    //    MessageBox.Show("El precio del seguro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    btnGrabar1.Enabled = false;
                    //    return false;
                    //}
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void calcularMontoFinal()
        {
            decimal nMonto;
            if (string.IsNullOrEmpty(this.conBusCuentaCli1.txtNombreCli.Text.ToString()))
            {
                this.conBusCuentaCli1.txtNroBusqueda.Focus();
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtMonto.Text))
                {
                    nMonto = 0;
                    this.txtMonto.Text = nMonto.ToString();
                    this.txtImpuesto.Text = "0.00";
                    this.txtRedondeo.Text = "0.00";
                    this.txtMontTotal.Text = "0.00";
                    this.txtMonto.SelectAll();
                    return;
                }
                else
                {
                    nMonto = nCapitalAprobado;
                    if (nMonto == 0)
                    {
                        this.txtMonto.SelectAll();
                        this.txtMonto.Focus();
                        this.txtImpuesto.Text = "0.00";
                        this.txtRedondeo.Text = "0.00";
                        this.txtMontTotal.Text = "0.00";
                        return;
                    }
                    else
                    {
                        nMonITF = utiles.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, (Int32)this.cboMoneda.SelectedValue);
                        this.txtImpuesto.Text = string.Format("{0:0.00}", Math.Round(nMonITF, 2));
                        decimal nRedondeo = Convert.ToDecimal(Sol.Rows[0]["nMontoRedondeo"]);
                        this.txtRedondeo.Text = string.Format("{0:0.00}", Convert.ToDecimal(Sol.Rows[0]["nMontoRedondeo"]));
                        Decimal nMontoTotal;

                        if (rbtSI.Checked)
                        {
                            nMontoTotal = (Decimal)nMontoTotalEntrega - Math.Round(nMonITF, 2) + nRedondeo;
                        }
                        else
                        {
                            nMontoTotal = (Decimal)nMontoTotalEntrega;
                        }

                        this.txtMontTotal.Text = string.Format("{0:0.00}", nMontoTotal);

                        //************* Asignando el ItfNormal (Sin redondeo)********
                        nITFNormal = clsVarGlobal.nITF / 100.00m * (decimal)nMonto;
                        nITFNormal = utiles.truncarNumero(nITFNormal, 2);
                        //***********************************************************
                    }
                }
            }
        }

        //--====================================================
        //--DEPOSITO CUANDO EL TIPO DE DESEMBOLSO TRANSF CTA
        //--====================================================
        private void ralizarDepositoCtaAho(int idKardexDesembolso)
        {
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            int nidCta = Convert.ToInt32(txtIdCtaAho.Text);
            Decimal nMonComis = 0.00m;
            int idTipPago = 2,
            idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            Decimal nMonOpe = 0.00m;
            //--Cuando se da una Ampliación
            int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            if (idOperacion == 4)
            {
                nMonOpe = Convert.ToDecimal(txtMontoAmpliado.Text) - Convert.ToDecimal(txtImpuesto.Text);
            }
            else
            {
                nMonOpe = Convert.ToDecimal(txtMontTotal.Text) - Convert.ToDecimal(txtImpuesto.Text);
            }

            Decimal nMonFavCli = 0.00m;
            //--==========================================================
            //--Calcular ITF
            //--==========================================================
            cargarComisiones();

            Decimal nMontoITF = 0.00m;  //nMonITF;

            //--====================================================
            //--Variables Adicionales
            //--====================================================
            int idEntFin = 110;
            string cNroDocPag = "";
            int cCtaTrans = 0;  //--Si tipo de Pago es por Transferencia
            int nCuota = 0;
            Decimal nMonredondeo = 0.00m;

            Decimal nMonCapital = 0.00m;

            //nMonOpe = Convert.ToDecimal(this.txtMonto.Text.ToString());

            nMonCapital = nMonOpe - nComision;


            string cNomCliOpe = conBusCuentaCli1.txtNombreCli.Text;
            DataTable dtDatosCli = DatosCliente.ListarclixIdCli(IdCliente);
            string cCdniCliOpe = Convert.ToString(dtDatosCli.Rows[0]["cDocumentoID"]);
            string cDirCliOpe = Convert.ToString(dtDatosCli.Rows[0]["cDireccion"]);
            int IdTipoPersona = Convert.ToInt32(dtDatosCli.Rows[0]["IdTipoPersona"]);
            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();

            //--Generar XML de Datos del Tipo de Pago
            DataSet dsTipPago = new DataSet("dsDeposito");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());
            //--====================================================
            //--Comisiones
            //--====================================================
            int x_nTipOpe = 10;
            clsCNDeposito RetornaDatCtaAho = new clsCNDeposito();
            DataTable dtDatoCta = RetornaDatCtaAho.CNRetornaDatosCuenta(nidCta, "1", x_nTipOpe);
            idProd = Convert.ToInt32(dtDatoCta.Rows[0]["idProducto"]);

            DataSet dsComision = new DataSet("dsDeposito");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());
            //--===============================================================
            //--Registrar Operación de Deposito
            //--===============================================================

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0;

            DataTable tbRegApe = clsDeposito.CNRegistraDepositoAHO(xmlTipPago, xmlComision, nidCta, nMonOpe, idMon, nMonComis, nMontoITF, nMonredondeo, nMonCapital, clsVarGlobal.User.idUsuario,
                                                                clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nCuota, idProd, false, cNroDocPag,
                                                                idEntFin, cCtaTrans, idTipPago, IdCliente, cCdniCliOpe, cNomCliOpe, cDirCliOpe, 1, 2, idTipoTransac, lModificaSaldoLinea, idKardexDesembolso
                                                                );
            idKardexAho = Convert.ToInt32(tbRegApe.Rows[0]["idNroOpe"]);

            //--===============================================================
            //--Registrar Descuento Seguro Desgravamen
            //--===============================================================
            if (dtTodosConfigGastos.Rows.Count > 0)
            {
                Decimal nValor = Convert.ToDecimal(dtTodosConfigGastos.Rows[0]["nValor"]);
                if (Convert.ToInt16(dtValidaAsignaSeguro.Rows[0]["nResultado"]) == 0)
                {
                    nValor = 0;
                }
                if (nValor > 0)
                {
                    idKardexSeg = 0;
                    idTipPago = 2;
                    Decimal nDescuento = (Convert.ToDecimal(txtMontTotal.Text) * nValor) / 100.00m;
                    //===================================================================
                    //--Generar XML de Datos Intervinientes
                    //===================================================================
                    DataTable dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(nidCta);
                    DataSet dsIntervin = new DataSet("dsRetiro");
                    dsIntervin.Tables.Add(dtbIntervCta);
                    string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());

                    DataTable tbRegDscto = clsDeposito.CNRegistraRetiroAHO(xmlTipPago, xmlComision, xmlInterv, nidCta, nDescuento, idMon, 0.00m, 0.00m, 0.00m, nDescuento, clsVarGlobal.User.idUsuario,
                                                                        clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, idProd, cNroDocPag,
                                                                        idTipPago, IdCliente, cCdniCliOpe, cNomCliOpe, cDirCliOpe, 1, 3, idTipoTransac, lModificaSaldoLinea);

                    if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
                    {
                        idKardexSeg = Convert.ToInt32(tbRegDscto.Rows[0]["idNroOpe"]);
                    }
                    else
                    {
                        MessageBox.Show("Error en pago de Seguro Desgravamen/n Consulte con Sistemas", "Pago Seguro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            MessageBox.Show("Se Depósito Correctamente a la cuenta seleccionada", "Actualiza Déposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool retornarTasaAhorro()
        {
            int idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            idProd = 69;
            DataTable dt;

            DataTable dtDatosCli = DatosCliente.ListarclixIdCli(IdCliente);
            int IdTipoPersona = Convert.ToInt32(dtDatosCli.Rows[0]["IdTipoPersona"]);

            clsCNAperturaCta TasaAho = new clsCNAperturaCta();
            //--Cuando se da una Ampliación
            int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            if (idOperacion == 4)
            {
                dt = TasaAho.RetornaTasaAhorros(0, idProd, Convert.ToDecimal(txtMontoAmpliado.Text), idMon, clsVarGlobal.nIdAgencia, IdTipoPersona);
            }
            else
            {
                dt = TasaAho.RetornaTasaAhorros(0, idProd, Convert.ToDecimal(txtMontTotal.Text), idMon, clsVarGlobal.nIdAgencia, IdTipoPersona);
            }

            if (dt.Rows.Count > 0)
            {
                nTasaComp = Convert.ToDecimal(dt.Rows[0]["nTasaCompensatoria"]);
                idTasa = Convert.ToInt32(dt.Rows[0]["idTasa"].ToString());
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró tasa para el Subproducto de Ahorros", "Validación de Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                return false;
            }
        }

        private void frmDesembolso_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Sol.Rows.Count > 0 && lBloqueoActivo)
            {
                LiberarCuenta(Convert.ToInt32(Sol.Rows[0]["idCuenta"]));
                lBloqueoActivo = false;
            }
        }

        private void cargarComisiones()
        {
            dtComision = null;
            int x_idTipoPago = Convert.ToInt32(cboModDesemb1.SelectedValue);
            int idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            int x_nTipOpe = 10;
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            Decimal nMonto = Convert.ToDecimal(txtMonto.Text);
            int nPlazo = 0;

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, IdTipoPersona, idMon, nidCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlazo, x_idTipoPago);

            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal(dtComision.Compute("SUM(nValorAplica)", ""));
                nComision = nTotCom;
            }
            else
            {
                nComision = 0.00m;
            }
        }

        private void generarPpgAhoProgramado()
        {
            tbAhoPrg = null;
            DateTime dtpFecAhoProg = clsVarGlobal.dFecSystem;
            Decimal nMonCuota = 0;
            int nNumCuotas = 1;
            short nTipPPG = 2;
            int dia = dtpFecAhoProg.Day;
            clsCNCalculosAho objppg = new clsCNCalculosAho();
            tbAhoPrg = objppg.CalculaPpgDep(nMonCuota, clsVarGlobal.dFecSystem, dtpFecAhoProg, nNumCuotas, 0, nTipPPG, dia, 0);
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = Convert.ToInt32(Sol.Rows[0]["idSolicitud"]);
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
            drfila[1] = IdCliente;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                        clsVarGlobal.dFecSystem.Day.ToString() + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaSolicitud";
            drfila[1] = Convert.ToDateTime(dtpFechaSol.Value.ToString()).Year.ToString() + "-" +
                        Convert.ToDateTime(dtpFechaSol.Value.ToString()).Month.ToString() + "-" +
                        Convert.ToDateTime(dtpFechaSol.Value.ToString()).Day.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipoOperacion";

            drfila[1] = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoSolicitado";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMonto.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = cboMoneda.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "ModDesembolso";
            drfila[1] = cboModDesemb1.SelectedValue;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNomAge";
            drfila[1] = clsVarGlobal.cNomAge;
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
            drfila[1] = clsVarGlobal.User.dFechaIngreso.Year.ToString() + "-" +
                        clsVarGlobal.User.dFechaIngreso.Month.ToString() + "-" +
                        clsVarGlobal.User.dFechaIngreso.Day.ToString();
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
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitudCredGrupoSol";
            drfila[1] = Convert.ToInt32(Sol.Rows[0]["idSolicitudCredGrupoSol"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void EmitirVoucher(DataTable dtDatosCobro, int idKardex)
        {
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreVariable", cVarVal.ToString(), false));
            paramlist.Add(new ReportParameter("x_IdKardex", idKardex.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsCobro", dtDatosCobro));

            //  List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();


        }

        private void insertar()
        {
            if (Sol.Rows.Count == 0)
            {
                MessageBox.Show("Solicitud no tiene Plan de Pagos generado", "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            nidCta = (String.IsNullOrWhiteSpace(txtIdCtaAho.Text)) ? 0 : Convert.ToInt32(txtIdCtaAho.Text);

            nMontoPrima_Total = 0;

            foreach (clsSolicitudCreditoSeguro objSeguro in objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro)
            {
                if (!objSeguro.lPagoCuotas && objSeguro.lSeleccionado)
                {
                    nMontoPrima_Total += objSeguro.nMontoPrima;
                }
            }

            clsCreditoDesembolsoCuentaParametro objDesembolsoTransferencia = new clsCreditoDesembolsoCuentaParametro();
            objDesembolsoTransferencia.idModalidadDesembolso = Convert.ToInt32(cboModDesemb1.SelectedValue);

            #region Carga de Datos Deposito a cuenta
            //--===============================================================
            //--Datos para Grabar Operacion de Deposito
            //--===============================================================
            objDesembolsoTransferencia.objDepositoCuentaParametro.idCuenta = (String.IsNullOrWhiteSpace(txtIdCtaAho.Text)) ? 0 : Convert.ToInt32(txtIdCtaAho.Text);
            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoComision = Decimal.Zero;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idTipoPago = 2;

            objDesembolsoTransferencia.objDepositoCuentaParametro.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoOperacion = Decimal.Zero;
            //--Cuando se da una Ampliación
            objDesembolsoTransferencia.idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            if (objDesembolsoTransferencia.idOperacion == 4)
            {
                objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoOperacion = Convert.ToDecimal(txtMontoAmpliado.Text) - Convert.ToDecimal(txtImpuesto.Text);
            }
            else
            {
                objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoOperacion = Convert.ToDecimal(txtMontTotal.Text) - Convert.ToDecimal(txtImpuesto.Text);
            }

            //--==========================================================
            //--Calcular ITF
            //--==========================================================
            cargarComisiones();

            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoITF = 0.00m;  //nMonITF;

            //--====================================================
            //--Variables Adicionales
            //--====================================================
            objDesembolsoTransferencia.objDepositoCuentaParametro.idEntidadFinanciera = 110;

            objDesembolsoTransferencia.objDepositoCuentaParametro.cNumeroDocumentoPagare = String.Empty;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idCuentaTransferencia = 0;
            objDesembolsoTransferencia.objDepositoCuentaParametro.nCuota = 0;
            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoRedondeo = Decimal.Zero;
            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoCapital = Decimal.Zero;

            objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoCapital = objDesembolsoTransferencia.objDepositoCuentaParametro.nMontoOperacion - nComision;

            DataTable dtc_dtDatosCliente = DatosCliente.ListarclixIdCli(IdCliente);
            objDesembolsoTransferencia.objDepositoCuentaParametro.cNombreClienteOperacion = conBusCuentaCli1.txtNombreCli.Text;
            objDesembolsoTransferencia.objDepositoCuentaParametro.cDNIClienteOperacion = Convert.ToString(dtc_dtDatosCliente.Rows[0]["cDocumentoID"]);
            objDesembolsoTransferencia.objDepositoCuentaParametro.cDireccionClienteOperacion = Convert.ToString(dtc_dtDatosCliente.Rows[0]["cDireccion"]);
            objDesembolsoTransferencia.idTipoPersona = Convert.ToInt32(dtc_dtDatosCliente.Rows[0]["IdTipoPersona"]);
            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta objCNAperturaCta = new clsCNAperturaCta();
            DataTable dtc_dtPago = objCNAperturaCta.ListaCamposDep(3);
            DataRow dtc_drPago = dtc_dtPago.NewRow();

            //--Generar XML de Datos del Tipo de Pago
            DataSet dtc_dsTipoPago = new DataSet("dsDeposito");
            dtc_dsTipoPago.Tables.Add(dtc_dtPago);
            objDesembolsoTransferencia.objDepositoCuentaParametro.xmlTipoPago.LoadXml(dtc_dsTipoPago.GetXml());
            //--====================================================
            //--Comisiones
            //--====================================================
            DataSet dtc_dsComision = new DataSet("dsDeposito");
            dtc_dsComision.Tables.Add(dtComision);
            objDesembolsoTransferencia.objDepositoCuentaParametro.xmlComision.LoadXml(dtc_dsComision.GetXml());

            DataTable dtDatoCta = clsDeposito.CNRetornaDatosCuenta(nidCta, "1", x_nTipOpe);
            objDesembolsoTransferencia.objDepositoCuentaParametro.idProducto = (dtDatoCta.Rows.Count > 0) ? Convert.ToInt32(dtDatoCta.Rows[0]["idProducto"]) : 0;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idCuenta = nidCta;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idUsuario = clsVarGlobal.User.idUsuario;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idAgencia = clsVarGlobal.nIdAgencia;
            objDesembolsoTransferencia.objDepositoCuentaParametro.dFechaOperacion = clsVarGlobal.dFecSystem;
            objDesembolsoTransferencia.objDepositoCuentaParametro.lIsAhorroProgramado = false;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idClienteITF = IdCliente;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idCanal = 1;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idMotivoOperacion = 2;
            objDesembolsoTransferencia.objDepositoCuentaParametro.idKardexRelacion = 0;

            #endregion
            //DETALLE KARDEX
            DataTable dtDetalleKardex = new DataTable();

            dtDetalleKardex.Columns.Add("idCuenta", typeof(int));
            dtDetalleKardex.Columns.Add("idPlanPagos", typeof(int));
            dtDetalleKardex.Columns.Add("idCuota", typeof(int));
            dtDetalleKardex.Columns.Add("nMonto", typeof(decimal));
            dtDetalleKardex.Columns.Add("idTipoAfeCaj", typeof(int));
            dtDetalleKardex.Columns.Add("idTipoTransaccion", typeof(int));
            dtDetalleKardex.Columns.Add("idConcepto", typeof(int));
            dtDetalleKardex.Columns.Add("idCondicionContable", typeof(int));
            dtDetalleKardex.Columns.Add("cTipoSeguro", typeof(string));

            foreach (clsSolicitudCreditoSeguro item in objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro)
            {
                DataRow filaDetalle;
                filaDetalle = dtDetalleKardex.NewRow();
                if (item.lSeleccionado && !item.lPagoCuotas)
                {
                    filaDetalle["idCuenta"] = item.idSolicitud;
                    filaDetalle["idPlanPagos"] = 0;
                    filaDetalle["idCuota"] = 0;
                    filaDetalle["nMonto"] = item.nMontoPrima;
                    filaDetalle["idTipoAfeCaj"] = 1;
                    filaDetalle["idTipoTransaccion"] = 2;
                    filaDetalle["idConcepto"] = item.idConcepto;
                    filaDetalle["idCondicionContable"] = 1;
                    filaDetalle["cTipoSeguro"] = item.cTipoSeguro;
                    dtDetalleKardex.Rows.Add(filaDetalle);
                }
            }

            DataSet dtc_dsDetalleKardex = new DataSet("dsDetalleKardex");
            dtc_dsDetalleKardex.Tables.Add(dtDetalleKardex);
            objDesembolsoTransferencia.objDepositoCuentaParametro.xmlDetalleKardex.LoadXml(dtc_dsDetalleKardex.GetXml());

            string xmlParametrosDesembolso = clsCNFormatoXML.EncodingXML(Convert.ToString(System.Security.SecurityElement.FromString(objDesembolsoTransferencia.SerializeToString())));

            int idSolcitud = Convert.ToInt32(Sol.Rows[0]["idSolicitud"]);
            int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
            DataTable dtNumCre = new DataTable();
            dtNumCre = Credito.NumeroCreditos(IdCliente);
            int idTipoDesembolso = (int)cboModDesemb1.SelectedValue;
            if (Convert.ToInt32(dtNumCre.Rows[0]["nNumeroCreditos"]) > 0)
            {
                Sol.Rows[0]["idTipoCliente"] = 2;
            }
            else
            {
                Sol.Rows[0]["idTipoCliente"] = 1;
            }
            DataTable dtSolicitud = Sol.Copy();
            DataSet ds = new DataSet("dscredito");
            ds.Tables.Add(dtSolicitud);
            String XmlCredito = ds.GetXml();
            XmlCredito = clsCNFormatoXML.EncodingXML(XmlCredito);


            Decimal nMonto = 0;
            bool lModificaSaldoLinea = false;
            int idTipoTransac = 2; //EGRESO

            if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
                lModificaSaldoLinea = true;

            //Ampliacion
            if (idOperacion == 4)
            {
                DataTable dtCanCreAmp = new DataTable();
                nMonto = Convert.ToDecimal(this.txtMontoAmpliado.Text.Trim());
                dtCanCreAmp = Credito.CNDesembolsoCreXAmpliacion(XmlCredito, iduser, dfec, clsVarGlobal.nIdAgencia, idSolcitud, nMonITF, clsVarGlobal.idCanal, nITFNormal, idTipoDesembolso, xmlParametrosDesembolso,
                  Convert.ToInt16(cboMoneda.SelectedValue), idTipoTransac, nMonto, lModificaSaldoLinea);
                if (dtCanCreAmp.Rows.Count > 0)
                {
                    if (dtCanCreAmp.AsEnumerable().Any(item => Convert.ToInt32(item["idEstadoOperacion"]) == 0))
                    {
                        foreach (DataRow drError in dtCanCreAmp.Rows)
                        {
                            MessageBox.Show(Convert.ToString(drError["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        lErrorDesembolso = true;
                        return;
                    }
                    else
                    {
                        DataRow drResultadoDesembolso = (dtCanCreAmp.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 1).ToArray())[0];
                        txtCodigoCuenta.Text = Convert.ToString(drResultadoDesembolso["nCuenta"]);
                        conBusCuentaCli1.txtEstado.Text = Convert.ToString(drResultadoDesembolso["Estado"]);
                        idKardexCre = Convert.ToInt32(drResultadoDesembolso["Kardex"]);
                        //nMonto = Convert.ToDecimal(this.txtMontoAmpliado.Text.Trim());

                        if (dtCanCreAmp.AsEnumerable().Any(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2))
                        {
                            DataRow drResultadoDeposito = (dtCanCreAmp.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2).ToArray())[0];
                            idKardexAho = Convert.ToInt32(drResultadoDeposito["Kardex"]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el Desembolso. Contacte con area de sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                DataTable dtCre = new DataTable();
                nMonto = Convert.ToDecimal(this.txtMontTotal.Text.Trim());
                dtCre = Credito.Desembolsa(XmlCredito, iduser, dfec, clsVarGlobal.nIdAgencia, nMonITF, clsVarGlobal.idCanal, nITFNormal, idTipoDesembolso, 1, xmlParametrosDesembolso,
                    Convert.ToInt16(cboMoneda.SelectedValue), idTipoTransac, nMonto, lModificaSaldoLinea);
                if (dtCre.Rows.Count > 0)
                {
                    if (dtCre.AsEnumerable().Any(item => Convert.ToInt32(item["idEstadoOperacion"]) == 0))
                    {
                        foreach (DataRow drError in dtCre.Rows)
                        {
                            MessageBox.Show(Convert.ToString(drError["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        lErrorDesembolso = true;
                        return;
                    }
                    else
                    {
                        DataRow drResultadoDesembolso = (dtCre.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 1).ToArray())[0];
                        txtCodigoCuenta.Text = Convert.ToString(drResultadoDesembolso["nCuenta"]);
                        conBusCuentaCli1.txtEstado.Text = Convert.ToString(drResultadoDesembolso["Estado"]);
                        idKardexCre = Convert.ToInt32(drResultadoDesembolso["Kardex"]);
                        nMonto = Convert.ToDecimal(this.txtMonto.Text.Trim()) + Convert.ToDecimal(Sol.Rows[0]["nMontoRedondeo"]) - Convert.ToDecimal(txtImpuesto.Text);

                        if (dtCre.AsEnumerable().Any(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2))
                        {
                            DataRow drResultadoDeposito = (dtCre.AsEnumerable().Where(item => Convert.ToInt32(item["idOperacionEjecutada"]) == 2).ToArray())[0];
                            idKardexAho = Convert.ToInt32(drResultadoDeposito["Kardex"]);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al registrar el Desembolso. Contacte con area de sistemas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (idKardexCre != 0)
            {
                if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();
                }
            }
            MessageBox.Show("Crédito Desembolsado Correctamente", "Actualiza Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGrabar1.Enabled = false;
            btnImprimir1.Enabled = true;
            cboRptImpCre.Enabled = true;
            btnDevolver.Enabled = false;
            lDesembolso = true;
        }

        private void BloqueoCompraDeuda()
        {
            int idSolicitud = Convert.ToInt32(Sol.Rows[0]["idSolicitud"]);
            DataTable dtResult = Credito.CNMontoBloqCompraDeuda(idSolicitud);

            if (dtResult.Rows.Count > 0)
            {
                decimal nMontoBloqueo = Convert.ToDecimal(dtResult.Rows[0]["nMontoBloq"]);
                if (nMontoBloqueo > 0)
                {
                    int nidCtaAho = Convert.ToInt32(txtIdCtaAho.Text);

                    DataTable dtBloqueo = new DataTable();
                    dtBloqueo.Columns.Add("idCuenta", typeof(int));
                    dtBloqueo.Columns.Add("idBloqueo", typeof(int));
                    dtBloqueo.Columns.Add("idCaracteristicaBloq", typeof(int));
                    dtBloqueo.Columns.Add("nMonBloqueo", typeof(decimal));
                    dtBloqueo.Columns.Add("cDesMotivo", typeof(string));
                    dtBloqueo.Columns.Add("dFechaDocBloqueo", typeof(DateTime));
                    dtBloqueo.Columns.Add("lBloqueado", typeof(bool));
                    dtBloqueo.Columns.Add("idBloCta", typeof(int));
                    dtBloqueo.Columns.Add("idTipoSolicitante", typeof(int));
                    dtBloqueo.Columns.Add("cNombreSolicitante", typeof(string));

                    DataRow dr = dtBloqueo.NewRow();
                    dr["idCuenta"] = nidCtaAho;
                    dr["idBloqueo"] = 1;
                    dr["idCaracteristicaBloq"] = 8;
                    dr["nMonBloqueo"] = nMontoBloqueo;
                    dr["cDesMotivo"] = "MOTIVO: PARA COMPRA DE DEUDA DE CRÉDITO NRO. " + txtCodigoCuenta.Text.Trim();
                    dr["dFechaDocBloqueo"] = clsVarGlobal.dFecSystem.Date;
                    dr["lBloqueado"] = 1;
                    dr["idBloCta"] = 0;
                    dr["idTipoSolicitante"] = 1;
                    dr["cNombreSolicitante"] = clsVarGlobal.User.cNomUsu;

                    dtBloqueo.Rows.Add(dr);
                    dtBloqueo.TableName = "Table1";
                    DataSet dsData = new DataSet("dsBloqueo");
                    dsData.Tables.Add(dtBloqueo);
                    string xmlBloqueo = dsData.GetXml();
                    dsData.Tables.Clear();

                    dtResult = clsDeposito.CNRegistraBloqueoCuenta(xmlBloqueo, nidCtaAho, nMontoBloqueo,
                        clsVarGlobal.User.idUsuario,
                        clsVarGlobal.dFecSystem.Date, String.Empty, true, 0, String.Empty);
                    if (dtResult.Rows.Count > 0)
                    {
                        if (Convert.ToInt16(dtResult.Rows[0][0]) == 0)
                        {
                            MessageBox.Show(Convert.ToString(dtResult.Rows[0][1]), "Desembolso de créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        ////--====================================================
        ////--APERTURA DE UNA CUENTA DE AHORRO PARA EL DESEMBOLSO
        ////--====================================================
        //Boolean AperturaCtaAho()
        //{
        //    if (!RetornaTasaAho())
        //    {
        //        return false;
        //    }

        //    int cCtaTrans = 0;
        //    int nPlazo = 0,
        //        nTipoCta = 1,
        //        nNroFirmas;
        //    int idMon = Convert.ToInt32(cboMoneda.SelectedValue);

        //    DataTable dtDatosCli = DatosCliente.ListarclixIdCli(IdCliente);
        //    string cDniCliOpe = Convert.ToString(dtDatosCli.Rows[0]["cDocumentoID"]);
        //    string cDireccionCliOpe = Convert.ToString(dtDatosCli.Rows[0]["cDireccion"]);
        //    int IdTipoPersona = Convert.ToInt32(dtDatosCli.Rows[0]["IdTipoPersona"]);
        //    string cNombreCli = Convert.ToString(dtDatosCli.Rows[0]["cNombre"]);

        //    //============================================================
        //    //--Retorna Estructura Para depositos
        //    //============================================================
        //    clsCNAperturaCta deposito = new clsCNAperturaCta();
        //    DataTable dtDepos = deposito.ListaCamposDep(1);
        //    DataRow dr = dtDepos.NewRow();


        //    if (IdTipoPersona == 1)  // si es persona Natural
        //    {
        //        if (nTipoCta == 1)
        //        {
        //            nNroFirmas = 1;
        //        }
        //        else
        //        {
        //            nNroFirmas = 2;
        //        }
        //    }
        //    else
        //    {
        //        nNroFirmas = 1;
        //    }
        //    //--Asignar Datos Para Registrar Apertura
        //    dr["idEstado"] = 1;
        //    dr["idProducto"] = idProd;
        //    dr["idTipoCuenta"] = 1;
        //    dr["idTipoTasa"] = nTipoCta;
        //    dr["idTasa"] = idTasa;
        //    dr["nMonTasa"] = nTasaComp;
        //    dr["idMoneda"] = cboMoneda.SelectedValue;
        //    dr["idAgencia"] = clsVarGlobal.nIdAgencia;
        //    dr["idUsuario"] = clsVarGlobal.User.idUsuario;
        //    dr["nInteresGen"] = 0.00;
        //    dr["nInteresPag"] = 0.00;
        //    dr["nMonIntTot"] = 0.00;
        //    dr["dFechaApertura"] = clsVarGlobal.dFecSystem.ToShortDateString();
        //    dr["nNumeroFirmas"] = nNroFirmas;
        //    dr["idUsuAsig"] = clsVarGlobal.User.idUsuario;
        //    dr["dFecUltMov"] = clsVarGlobal.dFecSystem.ToShortDateString();
        //    dr["lInactiva"] = 0;
        //    dr["lIsAfectoITF"] = 0;
        //    dr["idTipoPersona"] = Convert.ToInt32(IdTipoPersona);
        //    dr["nPlazoCta"] = 0;
        //    dr["cRucEmpleador"] = "";

        //    //--Cuando se da una Ampliación
        //    int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
        //    if (idOperacion == 4)
        //    {
        //        dr["nMontoDeposito"] = Convert.ToDecimal (txtMontoAmpliado.Text)- Convert.ToDecimal (txtImpuesto.Text);
        //        dr["nSaldoDis"] = Convert.ToDecimal (txtMontoAmpliado.Text) - Convert.ToDecimal (txtImpuesto.Text); 
        //        dr["nSaldoCnt"] = Convert.ToDecimal (txtMontoAmpliado.Text) - Convert.ToDecimal (txtImpuesto.Text); 
        //    }
        //    else
        //    {
        //        dr["nMontoDeposito"] = Convert.ToDecimal (txtMontTotal.Text);
        //        dr["nSaldoDis"] = Convert.ToDecimal (txtMontTotal.Text);
        //        dr["nSaldoCnt"] = Convert.ToDecimal (txtMontTotal.Text);
        //    }

        //    dtDepos.Rows.Add(dr);

        //    //============================================================
        //    //--Retorna Estructura Para Empleador 
        //    //============================================================
        //    clsCNAperturaCta Empleador = new clsCNAperturaCta();
        //    DataTable dtEmp = Empleador.ListaCamposDep(2);
        //    DataRow drEmp = dtEmp.NewRow();

        //    //--Generar XML de Datos Empleador
        //    DataSet dsEmpleador = new DataSet("dsDeposito");
        //    dsEmpleador.Tables.Add(dtEmp);
        //    string xmlEmpleador = clsCNFormatoXML.EncodingXML(dsEmpleador.GetXml());

        //    //============================================================
        //    //--Retorna Estructura Para Datos del Pago
        //    //============================================================
        //    clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
        //    DataTable dtPag = DatTipPago.ListaCamposDep(3);
        //    DataRow drPag = dtPag.NewRow();

        //    //--Generar XML de Datos del Tipo de Pago
        //    DataSet dsTipPago = new DataSet("dsDeposito");
        //    dsTipPago.Tables.Add(dtPag);
        //    string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

        //    //--Variables Adicionales
        //    int idEntFin = clsVarApl.dicVarGen["idInstFin"];
        //    string cNroDocPag = "";

        //    //================================================================
        //    //--Parámetros para Guardar Apertura
        //    //================================================================

        //    //===================================================================
        //    //--Generar XML de Datos Deposito
        //    //===================================================================
        //    DataSet ds = new DataSet("dsDeposito");
        //    ds.Tables.Add(dtDepos);
        //    string xmlDeposito = ds.GetXml();
        //    xmlDeposito = clsCNFormatoXML.EncodingXML(xmlDeposito);

        //    //===================================================================
        //    //--Generar XML de Datos Intervinientes
        //    //===================================================================

        //    DataTable dtInt = new DataTable();
        //    dtInt.Columns.Add("codigo", typeof(string));
        //    dtInt.Columns.Add("nombres", typeof(string));
        //    dtInt.Columns.Add("documento", typeof(string));
        //    dtInt.Columns.Add("idTipoInterv", typeof(string));
        //    dtInt.Columns.Add("idCuenta", typeof(string));
        //    dtInt.Columns.Add("direccion", typeof(string));
        //    dtInt.Columns.Add("lEsAfeItf", typeof(bool));

        //    DataRow drInterv = dtInt.NewRow();
        //    drInterv["codigo"] = IdCliente;
        //    drInterv["nombres"] = cNombreCli;
        //    drInterv["documento"] = cDniCliOpe;
        //    drInterv["idTipoInterv"] = "6";
        //    drInterv["idCuenta"] = "0";
        //    drInterv["direccion"] = cDireccionCliOpe;
        //    drInterv["lEsAfeItf"] = false;

        //    dtInt.Rows.Add(drInterv);
        //    int nReg = dtInt.Rows.Count - 1;
        //    //================================================================
        //    //--Agregar Registro de Clientes, si es Juridica
        //    //================================================================
        //    if (Convert.ToInt32(IdTipoPersona) != 1)
        //    {
        //        //--Buscar Empleador si ya Fue Registrado
        //        clsCNAperturaCta dtRegApe = new clsCNAperturaCta();
        //        DataTable tbRegApe = dtRegApe.RetornaRepreJuridica(Convert.ToInt32(IdCliente));
        //        if (tbRegApe.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < tbRegApe.Rows.Count; i++)
        //            {
        //                DataRow drIntervJuridica = dtInt.NewRow();
        //                drIntervJuridica["codigo"] = Convert.ToInt32(tbRegApe.Rows[i]["idCli"].ToString());
        //                drIntervJuridica["nombres"] = tbRegApe.Rows[i]["cNombre"].ToString();
        //                drIntervJuridica["documento"] = tbRegApe.Rows[i]["cDocumentoID"].ToString();
        //                drIntervJuridica["idTipoInterv"] = "7";
        //                drIntervJuridica["idCuenta"] = "0";
        //                drIntervJuridica["direccion"] = tbRegApe.Rows[i]["cDireccion"].ToString();
        //                drIntervJuridica["lEsAfeItf"] = false;
        //                dtInt.Rows.Add(drIntervJuridica);
        //                nReg++;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("La Empresa No Tiene Respresentantes: VERIFICAR", "Validación Interviniente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            return false;
        //        }
        //    }

        //    DataSet dsInterv = new DataSet("dsDeposito");
        //    dsInterv.Tables.Add(dtInt);
        //    string xmlInterv = clsCNFormatoXML.EncodingXML(dsInterv.GetXml());

        //    //===================================================================
        //    //--Generar XML de Datos Comisiones
        //    //===================================================================
        //    CargarComisiones();
        //    DataSet dsComision = new DataSet("dsDeposito");
        //    dsComision.Tables.Add(dtComision);
        //    string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

        //    //===================================================================
        //    //--Generar XML de Datos Aho Programado
        //    //===================================================================
        //    PpgAhoProgramado();
        //    DataSet dsAhoPrg = new DataSet("dsDeposito");
        //    dsAhoPrg.Tables.Add(tbAhoPrg);
        //    string xmlAhoPrg = clsCNFormatoXML.EncodingXML(dsAhoPrg.GetXml());

        //    //===================================================================
        //    //--Guardar Apertura Cuenta
        //    //===================================================================
        //    int idTipPago = 1;
        //    int nudNroDep = 0;
        //    int nCuotas = Convert.ToInt32(nudNroDep);
        //    Decimal nMontoDep = 0.00,nMonITFDep,nMonITFInt = 0.00;
        //    Decimal nMonComis = 0.00;
        //    Decimal nMonFavCli = 0.00;
        //    Decimal nMonredondeo = 0.00;

        //    //--Cuando se da una Ampliación           
        //    if (idOperacion == 4)
        //    {
        //        nMontoDep = Convert.ToDecimal (this.txtMontoAmpliado.Text) - Convert.ToDecimal (txtImpuesto.Text); 
        //    }
        //    else
        //    {
        //        nMontoDep = Convert.ToDecimal (this.txtMontTotal.Text);
        //    }

        //    CargarComisiones();

        //    nMonITFDep = 0.00;
        //    nMonITFDep = FunTruncar.redondearBCR(nMonITFDep, ref nMonFavCli, idMon, true, true);

        //    Decimal nMonCapital = nMontoDep - nMonITFDep;
        ////===================================================================
        ////--Registrar Apertura de Cuenta
        ////===================================================================
        //DateTime dtpFecAhoProg = clsVarGlobal.dFecSystem;
        //clsCNAperturaCta dtRegApe1 = new clsCNAperturaCta();
        //DataTable tbRegApe1 = dtRegApe1.RegistraAperturaCta(xmlDeposito, xmlInterv, xmlComision, xmlEmpleador, xmlTipPago, xmlAhoPrg,
        //                                nMontoDep, 0.00, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, nCuotas, 0.00, false, false,
        //                                false, dtpFecAhoProg, false, cNroDocPag, idEntFin, cCtaTrans, idTipPago, nMonITFDep,
        //                                nMonITFInt, nMonComis, nMonredondeo, nMonCapital, clsVarGlobal.idCanal, 0);
        //if (Convert.ToInt32(tbRegApe1.Rows[0]["idRpta"].ToString()) == 0)
        //{
        //    MessageBox.Show(tbRegApe1.Rows[0]["cMensage"].ToString() + ", NRO DE CUENTA: " + tbRegApe1.Rows[0]["idNroCta"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    txtCuentaAho.Text = tbRegApe1.Rows[0]["idNroCta"].ToString();
        //    txtIdCtaAho.Text = tbRegApe1.Rows[0]["idCuentaAho"].ToString();
        //    idKardexAho = Convert.ToInt32(tbRegApe1.Rows[0]["idKardexAho"]);
        //}
        //else
        //{
        //    MessageBox.Show(tbRegApe1.Rows[0]["cMensage"].ToString(), "Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //}
        //    return true;
        //}

        private bool validarPlanPagosMod()
        {
            int idSol = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);
            DataTable dtNuevoPlanPagSol = new clsCNReaprobSol().obtenerPlanPagosSol(idSol);
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

            DataTable dtNuevoDatosModGPP = new clsCNReaprobSol().obtenerDatosModGPP(idSol);

            for (int i = 0; i < this.dtDatosModGPP.Columns.Count; i++)
            {
                if (!Object.Equals(this.dtDatosModGPP.Rows[0][i], dtNuevoDatosModGPP.Rows[0][i]))
                    return false;
            }

            bool lValida = true;

            DataTable dtCondPlanPag = new clsCNReaprobSol().obtenerResumenReaprobacion(idSol);
            if (dtCondPlanPag.Rows.Count > 0)
            {
                lValida = (Object.Equals(dtCondPlanPag.Rows[0]["nNumCuotas"], dtNuevoDatosModGPP.Rows[0]["nCuotas"]) && lValida == true) ? true : false;
                lValida = (Object.Equals(dtCondPlanPag.Rows[0]["nCapPropuesto"], dtNuevoDatosModGPP.Rows[0]["nCapitalPropuesto"]) && lValida == true) ? true : false;
                lValida = (Object.Equals(dtCondPlanPag.Rows[0]["idTipoPeriodo"], dtNuevoDatosModGPP.Rows[0]["idTipoPeriodo"]) && lValida == true) ? true : false;
            }

            return lValida;
        }

        private void cargarConfiguracionSeguro()
        {
            int nParam = 2;
            objSolicitudCreditoSeguroActual = (objSolicitudCreditoSeguroActual.idSolicitud == 0) ? objCNCreditoSeguro.CNObtenerSolicitudCargaSeguro(conBusCuentaCli1.nValBusqueda) : objSolicitudCreditoSeguroActual;
            objSolicitudCreditoSeguroActual.lEsDesembolso = true;
            frmSolicitudCreditoCargaSeguro frmSolicitudCreditoSeguro = new frmSolicitudCreditoCargaSeguro(objSolicitudCreditoSeguroActual, nParam);
            frmSolicitudCreditoSeguro.ActualizarParametroAprobado();
            if (frmSolicitudCreditoSeguro.lValidoSeguros)
            {
                btnGrabar1.Enabled = true;
            }
            else
            {
                btnGrabar1.Enabled = false;
            }
            //DESCOMENTAR PARA TRUNCAR FLUJO
            //if (objSolicitudCreditoSeguroActual.lPrimaModificada) DesactivarBotones();
        }

        #region SeguroOncologico
        private void DesactivarBotones()
        {
            if (objSolicitudCreditoSeguroActual.lAceptacionInclusionCapital)
            {
                btnGrabar1.Enabled = false;
            }
        }
        #endregion

        private List<clsSolicitudCreditoSeguro> confirmarSeguroCredito(int idSolicitud, int idKardex)
        {
            int idCuenta = (String.IsNullOrWhiteSpace(txtIdCtaAho.Text)) ? 0 : Convert.ToInt32(txtIdCtaAho.Text);
            int idCli = IdCliente;
            GEN.CapaNegocio.clsCNCredito objCNCredito = new GEN.CapaNegocio.clsCNCredito();

            bool lAfectaCaja = (Convert.ToInt32(cboModDesemb1.SelectedValue) == 2) ? false : true;
            string xmlSolicitudCreditoSeguro = objSolicitudCreditoSeguroActual.GetXml();
            DataTable dtResultadoSolicitudSeguro = objCNCreditoSeguro.CNRegistrarSolicitudCreditoSeguro(idSolicitud, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

            List<clsSolicitudCreditoSeguro> lstSeguroHabilitados = objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Where(item => item.lSeleccionado).ToList();
            string cMensaje = String.Empty;

            DataTable dtResultadoConfirmacionSeguro = objCNCreditoSeguro.CNRegistroListaSeguroCredito(idSolicitud, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            List<clsCreditoSeguro> lstCreditoSeguroCompleto = new List<clsCreditoSeguro>();
            lstCreditoSeguroCompleto = new clsCNCreditoCargaSeguro().CNObtenerListaCreditoSeguro(idSolicitud);

            List<clsCreditoSeguro> lstCreditoSeguro = lstCreditoSeguroCompleto.Where(item => item.idEstadoSeguro == 1).ToList();

            if (Convert.ToInt32(dtResultadoConfirmacionSeguro.Rows[0]["idRegistro"]) == 1)
            {
                //if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 2)
                //{
                //    //RQ400 - Excluir al multiriesgo
                //    foreach (clsSolicitudCreditoSeguro objSeguro in lstSeguroHabilitados.Where(x => x.idTipoSeguro != 1).ToList())
                //    {
                //        objSeguro.idKardexRetiro = this.retiroCuentaDesembolso(idCuenta, idCli, objSeguro.nMontoPrima);
                //        if (objSeguro.idKardexRetiro > 0)
                //        {
                //            objCNCredito.CNUpdKardexRelDesem(idKardex, objSeguro.idKardexRetiro);
                //            cMensaje = "Se ha retirado de la cuenta de ahorros relacionado al desembolso, el importe de la prima del seguro:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        else
                //        {
                //            cMensaje = "Se debe retirar manualmente de la cuenta de ahorros relacionado al desembolso, el importe de la prima del seguro:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }
                //
                //        clsCreditoSeguro objCreditoSeguro = lstCreditoSeguro.First(elem => elem.idTipoSeguro == objSeguro.idTipoSeguro);
                //        objSeguro.idKardexRecibo = this.emitirReciboSeguro(objCreditoSeguro.idCreditoSeguro, idCli, objSeguro.nMontoPrima, objSeguro.idConceptoRecibo);
                //        if (objSeguro.idKardexRecibo > 0)
                //        {
                //            objCNCredito.CNUpdKardexRelDesem(idKardex, objSeguro.idKardexRecibo);
                //            cMensaje = "Se emitió el recibo por el seguro relacionado al crédito:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        else
                //        {
                //            cMensaje = "Se debe emitir manualmente el recibo por el seguro relacionado al crédito:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }
                //    }
                //}
                //else if (Convert.ToInt32(cboModDesemb1.SelectedValue) == 1)
                //{
                //    foreach (clsSolicitudCreditoSeguro objSeguro in lstSeguroHabilitados.Where(x => x.idTipoSeguro != 1).ToList())
                //    {
                //        clsCreditoSeguro objCreditoSeguro = lstCreditoSeguro.First(elem => elem.idTipoSeguro == objSeguro.idTipoSeguro);
                //        objSeguro.idKardexRecibo = this.emitirReciboSeguro(objCreditoSeguro.idCreditoSeguro, idCli, objSeguro.nMontoPrima, objSeguro.idConceptoRecibo);
                //        if (objSeguro.idKardexRecibo > 0)
                //        {
                //            objCNCredito.CNUpdKardexRelDesem(idKardex, objSeguro.idKardexRecibo);
                //            cMensaje = "Se emitió el recibo por el seguro relacionado al crédito:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".\nEl importe de la prima del seguro se debe descontar del monto desembolsado.";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        }
                //        else
                //        {
                //            cMensaje = "Se debe emitir manualmente el recibo por el seguro relacionado al crédito:\n" + objSeguro.cTipoSeguro + " - " + Convert.ToString(objSeguro.nMontoPrima) + " " + objSeguro.cMoneda + ".\nEl importe de la prima del seguro se debe descontar del monto desembolsado.";
                //            MessageBox.Show(cMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        }
                //    }
                //}
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultadoConfirmacionSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lstSeguroHabilitados;
        }

        private bool verificarCuentaAmpliacion()
        {
            bool lValida = false;
            int idSolicitud = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            DataTable dtCuentasAmpliadas = Solicitud.CNBuscarCuentaAmpliacion(idSolicitud);

            var drCuentasCanceladas = dtCuentasAmpliadas.AsEnumerable().Where(item => Convert.ToInt32(item["idEstado"]) == 6);
            DataTable dtCuentasCanceladas = (drCuentasCanceladas.Any()) ? drCuentasCanceladas.CopyToDataTable() : dtCuentasAmpliadas.Clone();

            if (dtCuentasCanceladas.Rows.Count > 0)
            {
                List<int> lstCuentasCanceladas = dtCuentasCanceladas.AsEnumerable().Select(item => item.Field<int>("idCuenta")).ToList();
                string cMensaje = String.Empty;
                if (dtCuentasCanceladas.Rows.Count == 1)
                {
                    cMensaje = "El siguiente Crédito: " + Convert.ToString(dtCuentasCanceladas.Rows[0]["idCuenta"]) + " se encuentra en un estado cancelado.";
                }
                else
                {
                    cMensaje = "Los siguientes créditos: " + String.Join(", ", lstCuentasCanceladas) + " se encuentran cancelados.";
                }
                MessageBox.Show(cMensaje, "Valida Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValida = true;
            }
            return lValida;
        }

        private void cancelarDesembolso()
        {
            limpiar();
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            cboRptImpCre.Enabled = false;
            btnBuscaCtaAho.Enabled = false;
        }

        private bool ValidarBloqueo(int idCuenta)
        {
            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();

            DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(idCuenta);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                DataTable dtUsu = new DataTable();
                dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                MessageBox.Show("La Cuenta: " + idCuenta + " está bloqueada por el usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void BloquearCuenta(int idCuenta)
        {
            int nValBusqueda = idCuenta;
            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();

            DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nValBusqueda);
            int nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0][0].ToString());
            if (nidUserBloqueo != 0)
            {
                DataTable dtUsu = new DataTable();
                dtUsu = RetornaNumCuenta.BusUsuBlo((int)nidUserBloqueo);
                string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                MessageBox.Show("La Cuenta: " + idCuenta + " está bloqueada por el usuario: " + cUserBloqueo, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                RetornaNumCuenta.UpdEstCuenta(nValBusqueda, clsVarGlobal.User.idUsuario);
            }

        }

        public void LiberarCuenta(int idCuenta)
        {
            if (idCuenta > 0)
            {
                new clsCNRetornaNumCuenta().CNDesbloqueaCuenta(idCuenta, 1);
            }
        }

        private bool validarRegistroPagare(int _idSolicitud)
        {
            bool lValidar = true;

            DataTable dtVinculacionPagare = objCNCargaArchivo.CNVerificarVinculacionPagare(_idSolicitud);

            lSuperaMontoExposicion = Convert.ToBoolean(dtVinculacionPagare.Rows[0]["lSuperaMontoExposicion"]);
            bool lPagareCredito = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idPagareCredito"]) != 0) ? true : false;
            bool lArchivos = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idArchivos"]) != 0) ? true : false;
            bool lSustentoVinculacionArchivo = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idSustentoArchivoPagare"]) != 0) ? true : false;

            if (lSuperaMontoExposicion && !validarExcepcionProductoCampaña())
            {
                if (lArchivos && !lPagareCredito)
                {
                    MessageBox.Show("La solicitud no tiene vinculado el número de pagare.", "Vinculación de Pagaré de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValidar = false;
                }
                else if (!lArchivos && lPagareCredito)
                {
                    MessageBox.Show("La solicitud no tiene cargado el archivo del pagaré.", "Vinculación de Pagaré de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValidar = false;
                }
                else if (!lArchivos && !lPagareCredito)
                {
                    MessageBox.Show("La solicitud no tiene cargado el archivo del pagaré y no tiene vinculado el número de pagaré", "Vinculación de Pagaré de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValidar = false;
                }
            }
            return lValidar;
        }

        public bool validarExcepcionProductoCampaña()
        {
            bool lValor = false;
            if (Sol.Rows.Count > 0)
            {
                int idProductoSol = Convert.ToInt32(Sol.Rows[0]["IdProducto"]);
                clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable == "cListaProductoCampanaConsumo");
                List<int> lstProductoCampaña = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

                if (objVarGen == null)
                    lValor = false;
                else if (lstProductoCampaña.Any(item => item == idProductoSol))
                    lValor = true;
                else
                    lValor = false;
            }
            return lValor;
        }

        public bool validarHuella()
        {
            #region Huellas
            if (clsVarGlobal.User.lAutBiometricaAgencia)
            {
                int idSolicitud = conBusCuentaCli1.nValBusqueda;
                DataTable dtIntervinientes = Solicitud.CNObtenerIntervinienteSolicitudBiometrico(idSolicitud);
                int idProducto = Convert.ToInt32(Sol.Rows[0]["idProducto"]);
                int idOperacion = Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                int idTipoOperacionExcepcion = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoDesembolso"]);

                var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                        .OrderBy(x => Convert.ToInt32(x["idCli"]));

                if (!oBiometrico.validacionBiometrica(
                        listFirmantes
                        , Convert.ToInt32(cboMoneda.SelectedValue)
                        , idProducto
                        , Convert.ToDecimal(this.txtMonto.Text.ToString())
                        , idTipoOperacionExcepcion))
                {
                    return false;
                }
            }
            return true;
            #endregion
        }

        public int retiroCuentaDesembolso(int idCuenta, int idCli, decimal nMonto)
        {
            try
            {
                // Variables
                clsCNDeposito objCNDeposito = new clsCNDeposito();

                // Datos del cliente
                DataTable dtCliente = new clsCNRetDatosCliente().ListarDatosCli(idCli, "N");
                string cDocumentoID = dtCliente.Rows[0]["cDocumentoID"].ToString();
                string cNombreCliente = dtCliente.Rows[0]["cNomCli"].ToString();
                string cDireccionCliente = dtCliente.Rows[0]["cDireccionPrincipal"].ToString();

                // Datos de la cuenta
                DataTable dtCuenta = objCNDeposito.CNRetornaDatosCuenta(idCuenta, "1", 11);
                int idProducto = Int32.Parse(dtCuenta.Rows[0]["idProducto"].ToString());

                // Intervinientes            
                int idCliValid = 0;
                DataTable dtIntervinientes = objCNDeposito.CNRetornaIntervinientesCuenta(idCuenta);
                if (dtIntervinientes != null)
                {
                    DataRow row = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"])).OrderBy(x => Convert.ToInt32(x["idCli"])).FirstOrDefault();
                    idCliValid = row != null ? Convert.ToInt32(row["idCli"]) : 0;
                }
                var lstTitulares = dtIntervinientes.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);

                // Registrar INICIO rastreo
                this.registrarRastreo(idCli, idCuenta, "Inicio-Retiro de Cuenta de ahorro", btnGrabar1);

                Decimal nMonOpe = nMonto;
                Decimal nMonRedondeo = 0;
                Decimal nMonCapital = nMonto;

                Decimal nMonComis = 0;
                Decimal nMonITF = 0;
                int idModPago = 1; // EFECTIVO            
                int idMotivoOpe = 3; // RETIRO NORMAL
                int idCanal = 1;
                int idMoneda = 1; // SOLES

                // Cliente que realiza la operación
                string cDniCliOpe = cDocumentoID;
                string cNomCliOpe = cNombreCliente;
                string cDirCliOpe = cDireccionCliente;

                string cNroDocPag = cDocumentoID;
                int idTipPago = idModPago;
                int idCliITF = idCli;

                // XML de Datos del Tipo de Pago
                clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
                DataTable dtPag = DatTipPago.ListaCamposDep(3);
                DataRow drPag = dtPag.NewRow();
                DataSet dsTipPago = new DataSet("dsRetiro");
                dsTipPago.Tables.Add(dtPag);
                string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

                // XML Comisiones
                DataTable dtComision = new DataTable();
                DataSet dsComision = new DataSet("dsRetiro");
                dsComision.Tables.Add(dtComision);
                string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());

                // XML Intervinientes
                DataTable dtInterv = dtIntervinientes;
                DataSet dsIntervin = new DataSet("dsRetiro");
                dsIntervin.Tables.Add(dtInterv);
                string xmlInterv = clsCNFormatoXML.EncodingXML(dsIntervin.GetXml());

                bool lModificaSaldoLinea = true;
                int idTipoTransac = 2; //EGRESO

                DataTable dtRetiro = objCNDeposito.CNRegistraRetiroAHO(xmlTipPago, xmlComision, xmlInterv, idCuenta, nMonOpe, idMoneda, nMonComis, nMonITF, nMonRedondeo, nMonCapital, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, idProducto, cNroDocPag,
                                                                    idTipPago, idCliITF, cDniCliOpe, cNomCliOpe, cDirCliOpe, idCanal, idMotivoOpe,
                                                                    idTipoTransac, lModificaSaldoLinea);

                int idKardex = 0;
                if (Convert.ToInt32(dtRetiro.Rows[0]["idRpta"].ToString()) == 0)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    idKardex = Convert.ToInt32(dtRetiro.Rows[0]["idNroOpe"].ToString());
                }

                clsDeposito.CNUpdNoUsoCuenta(idCuenta);

                // Registro de operaciones únicas y multiples - SPLAF
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                // Registro FIN rastreo
                this.registrarRastreo(idCli, idCuenta, "Fin-Retiro de Cuenta de ahorro", btnGrabar1);

                return idKardex;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int emitirReciboSeguro(int idCreditoSeguro, int idCli, decimal nMonto, int idConceptoRecibo)
        {
            try
            {
                int idKardex = 0;

                // Variables
                int idTipoRecibo = 1; // RECIBO DE INGRESO
                int idMoneda = 1; // SOLES            
                Decimal nMontoITF = 0;
                Decimal nMontoTotal = nMonto + nMontoITF;
                string cSustento = "Venta de Seguro - CREDITO: " + Sol.Rows[0]["idCuenta"].ToString();
                int idUsuario = clsVarGlobal.User.idUsuario;
                int idAgeOrigen = clsVarGlobal.nIdAgencia;
                int idAgeDestino = clsVarGlobal.nIdAgencia;
                bool lAfecCaja = true;
                int idColaborador = 0;
                int idReciboProvisional = 0;
                string msg = "";

                clsCNImpresion objCNImpresion = new clsCNImpresion();
                clsCNControlOpe objCNControlOpe = new clsCNControlOpe();

                // Registro INICIO Rastreo
                this.registrarRastreo(idCli, 0, "Inicio  - Emitir Recibos ", btnGrabar1);

                // Guardar recibo
                string cCodigoRecibo;

                bool lModificaSaldoLinea = true;

                DataTable dtGuardarRecibo = objCNControlOpe.GuardarReciboRelacionadoSeguro(idTipoRecibo, idConceptoRecibo, idColaborador, idCli, idMoneda, nMonto,
                    nMontoITF, nMontoTotal, cSustento, clsVarGlobal.dFecSystem, idUsuario, idAgeOrigen, idAgeDestino, 0, ref msg, 0, idCreditoSeguro, lModificaSaldoLinea, idReciboProvisional
                );
                if (dtGuardarRecibo.Rows.Count > 0)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    cCodigoRecibo = dtGuardarRecibo.Rows[0]["cCodRec"].ToString();
                    idKardex = Convert.ToInt32(dtGuardarRecibo.Rows[0]["idKardex"]);
                }

                // Registro FIN Rastreo
                this.registrarRastreo(idCli, 0, "Fin - Emitir Recibos ", btnGrabar1);

                return idKardex;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private void EncuestaExperienciaCliente()
        {
            int nTipoOperacion = 1;
            clsCNExperienciaCliente cnExpCliente = new clsCNExperienciaCliente();

            string[] cPerfilAutEncuesta = clsVarApl.dicVarGen["cPerfilEcuestaCliente"].ToString().Split(',');
            int[] aPerfilAutEncuesta = Array.ConvertAll<string, int>(cPerfilAutEncuesta, int.Parse);
            if (!clsVarGlobal.PerfilUsu.idPerfil.In(aPerfilAutEncuesta))
            {
                return;
            }

            DataTable dtParamEncuesta = cnExpCliente.ListaParametrosEncuestaExpCliente(clsVarGlobal.dFecSystem, DateTime.Now, nTipoOperacion, clsVarGlobal.nIdAgencia);

            if (dtParamEncuesta.Rows.Count != 0)
            {
                if (Convert.ToBoolean(dtParamEncuesta.Rows[0]["EstadoOficina"]) == false)
                {
                    return;
                }
                if (Convert.ToInt32(dtParamEncuesta.Rows[0]["nEncuestados"]) < Convert.ToInt32(dtParamEncuesta.Rows[0]["cTotalEncuesta"]))
                {
                    if (Convert.ToInt32(dtParamEncuesta.Rows[0]["nIntervaloEncuesta"]) == Convert.ToInt32(dtParamEncuesta.Rows[0]["nIntervaloCount"]))
                    {
                        frmExperienciaClienteCalifica frm = new frmExperienciaClienteCalifica();
                        frm.idTipoOperacion = nTipoOperacion;
                        frm.cDocumentocliente = conBusCuentaCli1.txtNroDoc.Text;
                        frm.idExHorario = Convert.ToInt32(dtParamEncuesta.Rows[0]["idExHorario"]);
                        frm.ShowDialog();

                        DataTable dtIntervEncuesta = cnExpCliente.ActualizaIntervaloEncuestaExpCliente(clsVarGlobal.dFecSystem, DateTime.Now, nTipoOperacion, clsVarGlobal.nIdAgencia, 1);
                    }
                    else
                    {
                        DataTable dtIntervEncuesta = cnExpCliente.ActualizaIntervaloEncuestaExpCliente(clsVarGlobal.dFecSystem, DateTime.Now, nTipoOperacion, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtParamEncuesta.Rows[0]["nIntervaloCount"]) + 1);
                    }
                }
            }
        }

        #endregion
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            clsCNKardex cOpeCoreB = new clsCNKardex();
            DataTable dtOpeCoreB = cOpeCoreB.RetornaOperacionCanalRegistro(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), "S");

            if (Convert.ToInt32(dtOpeCoreB.Rows[0]["idCanalRegistro"]) != 1)
            {
                MessageBox.Show("La Solicitud de Credito fue creado por el siguiente Canal: " + dtOpeCoreB.Rows[0]["cCanalRegistro"].ToString() + ".\nNo puede realizar la devolución de la Solicitud.", "Devolver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!Convert.ToBoolean(dtOpeCoreB.Rows[0]["lFlujoAprobacion"]))
            {
                MessageBox.Show("La Solicitud de Crédito no tiene registrado un Nivel de Aprobación, No puede realizar la devolución de la Solicitud.", "Devolver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
            frmDevSolicitud FrmDevolverSolicitud = new frmDevSolicitud(idSolicitud);
            FrmDevolverSolicitud.lDevolucion = false;
            FrmDevolverSolicitud.ShowDialog();
            if (FrmDevolverSolicitud.lDevolucion == true)
            {
                btnDevolver.Enabled = false;
                btnGrabar1.Enabled = false;
                lDevolucion = true;
            }
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private bool ValidarSolicitudPendientePaquete()
        {
            //Validamos que no existan solicitudes de aprobación en estado pendientes para paquetes de seguro
            DataTable verificacion = new clsCNPaqueteSeguro().CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));

            if (verificacion.Rows.Count > 0)
            {
                int x_idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);
                int x_numeroSolicitud = Convert.ToInt32(verificacion.Rows[0]["idSolAproba"]);

                if (x_idEstadoSolicitud == 1) //SOLICITADO
                {
                    string x_mensaje = string.Format(clsVarApl.dicVarGen["cMensajeEstadoSolicitud"], x_numeroSolicitud);
                    MessageBox.Show(x_mensaje, "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar1.Enabled = false;
                    return false;
                }
            }

            var x_solicitud = Solicitud.SolicitudDesembolso(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));

            if (x_solicitud.Rows.Count > 0)
            {
                bool solicitudRechazada = Convert.ToBoolean(x_solicitud.Rows[0]["SolPlanRechazada"]);

                if (solicitudRechazada)
                {
                    MessageBox.Show("La solicitud ha cambiado de estado, por favor dirigirse al formulario de plan de pagos para generar el cronograma actualizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar1.Enabled = false;
                    return false;
                }
            }
            return true;
        }
    }
}
