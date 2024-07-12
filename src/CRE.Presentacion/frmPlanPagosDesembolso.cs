﻿using ADM.CapaNegocio;
using CRE.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.Servicio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLI.Presentacion;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmPlanPagosDesembolso : frmBase
    {
        #region Variable Globales

        private DataTable dtCalendarioPagos = new DataTable("dtPlanPago");
        private DataTable dtModificaciones;
        private DataTable dtCuotasDobles;
        private DataTable dtAuxConfigGastos;
        private DataTable dtConfigGasto;
        private clsCNPlanPago cnplanpago = new clsCNPlanPago();
        private clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        private clsCNReaprobSol cnReaprobSol = new clsCNReaprobSol();
        private clsCNDeposito cnDeposito = new clsCNDeposito();
        private DataTable dtDatosModGPP = new DataTable();
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        clsCNValidaReglasDinamicas cnregladinamica = new clsCNValidaReglasDinamicas();

        private int idMoneda;
        private decimal nCapitalMaxCobSeg;
        private bool lAplicaSeguro;
        private int idTipoPersona;
        private int idProducto;

        private int idEstadoSolicitud = 0;
        private bool lSuperaMontoExposicion = false;
        private bool lCuentaAhorroVinculada = false;

        private clsCNCargaArchivo objCNCargaArchivo = new clsCNCargaArchivo();
        private clsCNAdministracionFiles clsFiles = new clsCNAdministracionFiles();


        clsAdministracionEnvioSMS objAdministracionEnvioSMS { get; set; }

        private int nConTbSeg = 0;
        private int nConTbAct = 0;

        private int idModulo = 2;
        clsCNConfiguracionImpresionContratos clsConfiguracion = new clsCNConfiguracionImpresionContratos();
        private bool lImpirmirConIntervinietes = true;

        private int idSolicitud { get; set; }
        public bool lDesembolso = false;
        public bool lDevolucion = false;

        public DateTime dFechaIncial;
        public int idOperacionCred = 0;

        private bool lVisibleSegurosOptativo = true;

        #endregion

        public frmPlanPagosDesembolso()
        {
            InitializeComponent();
            conBusCuentaCli1.cTipoBusqueda = "S";
            conBusCuentaCli1.cEstado = "[1,2,13,19]";
            conBusCuentaCli1.lResetBusqueda = true;
        }

        #region Eventos

        private void frmPlanPagos_Load(object sender, EventArgs e)
        {

            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
            dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
            conCreditoPrimeraCuota.ValueChangedFecha -= conCreditoPrimeraCuota_ValueChangedFecha;

            dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;

            IniDtGastos();

            IniEstructuradtModifica();
            objAdministracionEnvioSMS = new clsAdministracionEnvioSMS();
            objAdministracionEnvioSMS.cargarPlantillaPlanPagos();

            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
            dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
            conCreditoPrimeraCuota.ValueChangedFecha += conCreditoPrimeraCuota_ValueChangedFecha;
            btnVincularPagare.Enabled = false;
            btnHojaResumen.Enabled = false;
            btnDesembolso.Enabled = false;
            btnImprimirContratos.Enabled = false;

            conBusCuentaCli1.grbBase1.Size = new System.Drawing.Size(574, 99);
            conBusCuentaCli1.txtNombreCli.Size = new System.Drawing.Size(410, 20);
            conBusCuentaCli1.btnBusCliente1.Location = new System.Drawing.Point(505, 11);
            conBusCuentaCli1.Refresh();
            conSolicitudCargaSeguros.ValidarSeguroActivo();
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatos();
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void dtpFecDesembolso_ValueChanged(object sender, EventArgs e)
        {
            string cModDesemb = cboModDesemb.GetItemText(cboModDesemb.SelectedItem);
            //if (chcBancoNacion.Checked && dtpFecDesembolso.Value.Date.DayOfWeek == DayOfWeek.Sunday)
            if (cModDesemb == "BANCO DE LA NACION" && dtpFecDesembolso.Value.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
                cboModDesemb.SelectedValue = 1;
                //chcBancoNacion.Checked = false;
                MessageBox.Show("No puede seleccionar día domingo para desembolso por Banco de la Nación, asigne otra fecha por favor", "Validación Banco de la Nación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (chcBancoNacion.Checked && dtpFecDesembolso.Value.Date < clsVarGlobal.dFecSystem.Date)
            if (cModDesemb == "BANCO DE LA NACION" && dtpFecDesembolso.Value.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
                MessageBox.Show("Fecha de desembolso por Banco de la Nación no puede ser menor o igual a la fecha actual, asigne otra fecha por favor", "Validación Banco de la Nación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.dtpFecDesembolso.Value < clsVarGlobal.dFecSystem)
            {
                this.dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
                this.dtpFecDesembolso.MinDate = clsVarGlobal.dFecSystem;
                this.dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
                this.dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
                return;
            }

            if (this.conCreditoPeriodo.lTipoPeriodoValido &&
                (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.FechaFija || this.conCreditoPeriodo.lPeriodoDiaValido))
            {
                this.calcularFechaPrimeraCuota();
            }
            else
            {
                this.conCreditoPrimeraCuota.inicializarFecha(this.dtpFecDesembolso.Value);
            }

            this.calcularDiasPrimCuota();
        }

        private void conCreditoPrimeraCuota_ValueChangedFecha(object sender, EventArgs e)
        {
            if (conCreditoPrimeraCuota.dFecha == null)
                return;

            this.calcularFechaPrimeraCuota();
            this.calcularDiasPrimCuota();
        }

        private void conCreditoPeriodo_ChangePeriodo(object sender, EventArgs e)
        {
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.lPeriodoDiaValido && this.conCreditoPeriodo.lTipoPeriodoValido)
            {
                this.conCreditoPrimeraCuota.lFechaSelec = false;
                this.calcularFechaPrimeraCuota();
                if (this.conCreditoPeriodo.lUnicuota)
                    this.txtNumCuotaCre.Enabled = false;
                else
                    this.txtNumCuotaCre.Enabled = true;

                this.txtNumCuotaCre.Text = this.conCreditoPeriodo.nCuotas.ToString();
            }
        }

        private void conCreditoPeriodo_ChangeTipoPeriodo(object sender, EventArgs e)
        {
            this.conCreditoPrimeraCuota.habilitarFecha(this.conCreditoPeriodo.idTipoPeriodo, this.conCreditoPeriodo.idPeriodo);
            if (this.conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.nudDiasGracia.Value = 0;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = false;
            }
            else
            {

                this.nudDiasGracia.Value = 0;
                this.nudCuotasGracia.Value = 0;
                this.nudCuotasGracia.Enabled = true;
                this.nudCuotasGracia.Maximum = 80;
            }

            this.calcularFechaPrimeraCuota();

            if (conBusCuentaCli1.nValBusqueda <= 0)
                return;
            dtModificaciones.Rows.Clear();
        }

        private void btnListaAprob1_Click(object sender, EventArgs e)
        {
            frmLisSolAprob frmLiSolApr = new frmLisSolAprob();
            frmLiSolApr.idEstadoDefecto = 2;
            frmLiSolApr.ShowDialog();

            int idSolicitud = frmLiSolApr.nNumSolicitud;
            if (idSolicitud <= 0)
                return;

            conBusCuentaCli1.txtNroBusqueda.Text = idSolicitud.ToString();
            conBusCuentaCli1.nValBusqueda = frmLiSolApr.nNumSolicitud;
            conBusCuentaCli1.txtNombreCli.Text = frmLiSolApr.cNomCliente;
            conBusCuentaCli1.txtEstado.Text = frmLiSolApr.cNomEstado;
            conBusCuentaCli1.txtCodCli.Text = frmLiSolApr.idCliente;
            conBusCuentaCli1.txtNroDoc.Text = frmLiSolApr.cDocumentoID;

            conBusCuentaCli1.idTipoDocumento = frmLiSolApr.idTipoDocumento;
            conBusCuentaCli1.idTipoPersona = frmLiSolApr.idTipoPersona;
            conBusCuentaCli1.pcTelefono = frmLiSolApr.cTelefono;
            conBusCuentaCli1.pcDireccion = frmLiSolApr.cDireccion;


            int nNumsolicitud = Convert.ToInt32(frmLiSolApr.nNumSolicitud);
            CargaDatosSolicitud(nNumsolicitud);
            CargarConfiguracionesDeGasto(nNumsolicitud);
            procesarPlanPagos();
            DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(nNumsolicitud);
            if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
            {
                MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!this.conSolicitudCargaSeguros.ConSolicitudCargaSeguros_ValidaSeguros())
                return;

            if (this.conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Actualizar Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;

            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), "S", "[1,2,13,19]");

            if (dtDatosNumSolicutd.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró número de solicitud o fue Desembolsado", "Actualizar Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCargaArhivos.Enabled = false;
                btnVincularCuentaAhorro.Enabled = false;
                return;
            }

            if (dtDatosNumSolicutd.Rows[0]["cEstado"].ToString() != "APROBADO")
            {
                string cMensaje = "El estado de la solicitud es: " + dtDatosNumSolicutd.Rows[0]["cEstado"].ToString() + ".";
                MessageBox.Show(cMensaje, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CancelarRegistro();
                return;
            }

            if (this.conSolicitudCargaSeguros.RechazaListaSeguro == true)
            {
                DataTable dtActualizaEstSeguro = new clsCNCreditoCargaSeguro().CNActualizarEstadoSolicitudCreditoSeguro(idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                if (Convert.ToInt32(dtActualizaEstSeguro.Rows[0]["idRespuesta"]) == 1)
                {
                    MessageBox.Show(dtActualizaEstSeguro.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }

            procesarPlanPagos();
        }

        private async void btnGrabar1_Click(object sender, EventArgs e)
        {
            this.btnGrabar1.Enabled = false;
            if (nConTbSeg == 0)
            {
                MessageBox.Show("Debe revisar la pestaña de seguros antes de continuar", "Validación revisión de seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbcCalendario.SelectedTab = tbcCalendario.TabPages["tabSeguro"];
                nConTbSeg++;
                this.btnGrabar1.Enabled = true;
                return;
            }

            int nNumeroSeguroSeleccionado = objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Count(item => item.lSeleccionado == true);
            if (objSolicitudCreditoSeguroActual.lAceptacionListaSeguro && nNumeroSeguroSeleccionado == 0)
            {
                MessageBox.Show("No ha seleccionado un seguro de la lista.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!this.conSolicitudCargaSeguros.ConSolicitudCargaSeguros_ValidaSeguros())
                return;

            if (objSolicitudCreditoSeguroActual.lAceptacionListaSeguro && (Convert.ToInt32(cboModDesemb.SelectedValue) == 4 || chcBancoNacion.Checked == true))
            {
                MessageBox.Show("No se puede otorgar Seguros Optativos en la Modalidad Banco de la Nación.", "Validación revisión de seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.btnGrabar1.Enabled = true;
                return;
            }

            if (chcBancoNacion.Checked && idOperacionCred.In(2, 6))
            {
                MessageBox.Show("No se puede generar el plan de Pagos para \"REFINANCIACION\" y \"REFINANCIACION POR NOVACION\" en la Modalidad Banco de la Nación.", "Validación Banco de La Nación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarRegistrar())
            {
                this.btnGrabar1.Enabled = true;
                return;
            }

            #region Validación histórico de solicitud de crédito (Fecha 1ra cuota).
            int nResult = DateTime.Compare(dFechaIncial, conCreditoPrimeraCuota.dFecha);

            if (nResult != 0)
            {
                DataTable dtMotivoMensaje = cnplanpago.CNListarMotivo(Convert.ToInt32(conBusCuentaCli1.nValBusqueda));
                string cMotivoSeleccionado = "";
                int idCondHistSolCred = 0;
                DateTime dFechaAnt1raCta = DateTime.Now;
                DateTime dFecha1raCta = DateTime.Now;
                int nResultFecha = 0;

                if (dtMotivoMensaje.Rows.Count > 0)
                {
                    DataRow primeraFila = dtMotivoMensaje.Rows[0];
                    cMotivoSeleccionado = primeraFila["cMotivo"].ToString();
                    idCondHistSolCred = Convert.ToInt32(primeraFila["idCondHistSolCred"].ToString());
                    dFechaAnt1raCta = Convert.ToDateTime(primeraFila["dFechaAnt1raCta"].ToString());
                    dFecha1raCta = Convert.ToDateTime(primeraFila["dFecha1raCta"].ToString());

                    nResultFecha = DateTime.Compare(dFecha1raCta, conCreditoPrimeraCuota.dFecha);

                    if (nResultFecha != 0)
                    {
                        frmCondHistSolCred frmMotivo = new frmCondHistSolCred(dFecha1raCta, conCreditoPrimeraCuota.dFecha, cMotivoSeleccionado);
                        frmMotivo.ShowDialog();
                        if (!frmMotivo.ValidarMotivoCancelar())
                        {
                            return;
                        }
                        string cMotivo = frmMotivo.RetornaMotivo();
                        DataTable dtMotivo = cnplanpago.CNRegistrarMotivo(Convert.ToInt32(conBusCuentaCli1.nValBusqueda), clsVarGlobal.User.idUsuario, dFecha1raCta, conCreditoPrimeraCuota.dFecha, cMotivo, clsVarGlobal.dFecSystem, idCondHistSolCred);
                    }
                }
                else
                {
                    frmCondHistSolCred frmMotivo = new frmCondHistSolCred(dFechaIncial, conCreditoPrimeraCuota.dFecha, cMotivoSeleccionado);
                    frmMotivo.ShowDialog();
                    if (!frmMotivo.ValidarMotivoCancelar())
                    {
                        return;
                    }
                    string cMotivo = frmMotivo.RetornaMotivo();
                    DataTable dtMotivo = cnplanpago.CNRegistrarMotivo(Convert.ToInt32(conBusCuentaCli1.nValBusqueda), clsVarGlobal.User.idUsuario, dFechaIncial, conCreditoPrimeraCuota.dFecha, cMotivo, clsVarGlobal.dFecSystem, idCondHistSolCred);
                }
            }
            #endregion

            /*========================================================================================
            * VALIDACION DE AUTORIZACION DE USO DE DATOS
            ========================================================================================*/
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (conBusCuentaCli1.idTipoPersona == 1)
                {
                    bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, conBusCuentaCli1.txtCodCli.Text.Trim(), conBusCuentaCli1.nValBusqueda,
                            conBusCuentaCli1.txtNombreCli.Text, conBusCuentaCli1.txtNroDoc.Text,
                                               conBusCuentaCli1.pcDireccion, conBusCuentaCli1.pcTelefono, conBusCuentaCli1.idTipoPersona, conBusCuentaCli1.idTipoDocumento);//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                    if (valor == false)
                    {
                        MessageBox.Show("Debe registrar la autorización de uso de datos de " + conBusCuentaCli1.txtNombreCli.Text, "Alerta de Tratamiento de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnGrabar1.Enabled = true;
                        conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);

                        return;
                    }

                }
                else
                {
                    DataTable dtIntervcredito = new clsCNTipAutUsoDatos().CNObtenerIntervinienteBiometrico(conBusCuentaCli1.nIdCliente);

                    var listFirmantes = dtIntervcredito.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                .OrderBy(x => Convert.ToInt32(x["idCli"]));

                    foreach (var titular in listFirmantes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        conAutorizacionUsuDatos1.pcNombreJuridico = conBusCuentaCli1.txtNombreCli.Text.Trim();
                        conAutorizacionUsuDatos1.pcNroDocJuridico = conBusCuentaCli1.txtNroDoc.Text.Trim();
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                             titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (valor == false)
                        {
                            MessageBox.Show("Debe registrar la autorización de uso de datos de " + titular.Field<string>("cNombre"), "Alerta de Tratamiento de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.btnGrabar1.Enabled = true;
                            conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);

                            return;
                        }
                    }
                }

            }

            /*========================================================================================
            * FIN VALIDACION DE AUTORIZACION DE USO DE DATOS
            ========================================================================================*/

            if (!objAdministracionEnvioSMS.validarNotificacionSMS())
            {
                btnValidarSMS.Focus();
                this.btnGrabar1.Enabled = true;
                return;
            }
            if (!lValidaReglasDinamicas())
            {
                this.btnGrabar1.Enabled = true;
                return;
            }

            #region Carga de Archivos
            DataTable dtCargaArchivos = new clsCNCargaArchivo().CNObtenerArchivosObligatoriosCargados(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text));
            if (Convert.ToInt32(dtCargaArchivos.Rows[0]["idEstado"]) == 0)
            {
                MessageBox.Show(dtCargaArchivos.Rows[0]["cMsg"].ToString(), "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MostrarCargaArchivo();
                this.btnGrabar1.Enabled = true;
                return;

                //if (MessageBox.Show(dtCargaArchivos.Rows[0]["cMsg"].ToString() + "\n\n ¿Está seguro que desea continuar?", "Carga de Archivos",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                //{
                //    return;
                //}

            }
            #endregion

            #region Validar Vinculacion Pagare
            if (!validarRegistroPagare(conBusCuentaCli1.nValBusqueda))
            {
                frmVincularPagare frmpagare = new frmVincularPagare(conBusCuentaCli1.nValBusqueda);
                frmpagare.ShowDialog();
                this.btnGrabar1.Enabled = true;
                return;
            }
            #endregion

            if ((objSolicitudCreditoSeguroActual.lAceptacionListaSeguro) || objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Any(item => item.idSolicitudCreditoSeguro != 0))
            {
                validaSegurosCambiados();

                string xmlSolicitudCreditoSeguro = clsUtils.toXmlObject(objSolicitudCreditoSeguroActual);

                DataTable dtResultadoSeguro = new clsCNCreditoCargaSeguro().CNRegistrarSolicitudCreditoSeguro(conBusCuentaCli1.nValBusqueda, xmlSolicitudCreditoSeguro, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);

                if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 0 || Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == -1)
                {
                    MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (Convert.ToInt32(dtResultadoSeguro.Rows[0]["idRegistro"]) == 1)
                {
                    if ((objSolicitudCreditoSeguroActual.lstSegurosDesmarcados != null && objSolicitudCreditoSeguroActual.lstSegurosDesmarcados.Count > 0) || (objSolicitudCreditoSeguroActual.lstSegurosCambiados != null && objSolicitudCreditoSeguroActual.lstSegurosCambiados.Count > 0))
                    {
                        DataTable dtResultadoSeguroDesmarcado = new DataTable();

                        if (objSolicitudCreditoSeguroActual.lstSegurosDesmarcados != null && objSolicitudCreditoSeguroActual.lstSegurosDesmarcados.Count > 0)
                            dtResultadoSeguroDesmarcado = new clsCNCreditoCargaSeguro().CNRegistrarSustentoDesmarcado(clsUtils.toXmlObject(objSolicitudCreditoSeguroActual.lstSegurosDesmarcados));

                        //Envia correo
                        StringBuilder cMensaje = armarCuerpoCorreo(objSolicitudCreditoSeguroActual.lstSegurosCambiados, objSolicitudCreditoSeguroActual.lstSegurosDesmarcados);

                        string cAsunto = string.Format(clsVarApl.dicVarGen["cAsuntoCorreosDesmarcados"], objSolicitudCreditoSeguroActual.idSolicitud);
                        List<string> cDestinatario = new List<string>();
                        bool permitirEnvioEmailUsuario = Convert.ToBoolean(clsVarApl.dicVarGen["lCorreoSeguroDesmarcado"]);
                        if (permitirEnvioEmailUsuario)
                            cDestinatario.Add(new clsCNCreditoCargaSeguro().CNObtenerCorreoUsuarioSolicitud(objSolicitudCreditoSeguroActual.idSolicitud));
                        else
                            cDestinatario.Add("gustavo.fernandez@soltechsac.com");

                        List<string> cDestinatarioCC = new List<string> { clsVarApl.dicVarGen["cListaCCDesmarcados"] };

                        //var rpta = new clsCNServicioCorreo().enviarMensaje(cDestinatario, cAsunto, cMensaje.ToString(), null, cDestinatarioCC);
                        clsDBResp dbResp = new clsCNCreditoCargaSeguro().CNEnvioCorreosSeguroDesmarcados(cDestinatario, cAsunto, cMensaje.ToString());

                        if (dbResp.nMsje != 1)
                            MessageBox.Show(dbResp.cMsje, "Cambio en seguros", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        objSolicitudCreditoSeguroActual.lstSegurosCambiados = null;
                        objSolicitudCreditoSeguroActual.lstSegurosDesmarcados = null;
                        conSolicitudCargaSeguros.objSolicitudCreditoCargaSeguro.lstSegurosCambiados = null;
                        conSolicitudCargaSeguros.objSolicitudCreditoCargaSeguro.lstSegurosDesmarcados = null;
                    }
                    MessageBox.Show(Convert.ToString(dtResultadoSeguro.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (this.conSolicitudCargaSeguros.RechazaListaSeguro == true)
            {
                DataTable dtActualizaEstSeguro = new clsCNCreditoCargaSeguro().CNActualizarEstadoSolicitudCreditoSeguro(idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                if (Convert.ToInt32(dtActualizaEstSeguro.Rows[0]["idRespuesta"]) == 1)
                {
                    MessageBox.Show(dtActualizaEstSeguro.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }

            if (ValidarChecklist() == "ERROR")
            {
                MostrarCheckListArchivo();
                this.btnGrabar1.Enabled = true;
                return;
            }

            DataTable TablaNidCuenta0 = cnplanpago.CNRetornaCuentaXSolicitud(conBusCuentaCli1.nValBusqueda);

            int nIdCuenta0 = Convert.ToInt32(TablaNidCuenta0.Rows[0]["nIdCuenta"].ToString());

            registrarRastreo(conBusCuentaCli1.nIdCliente, nIdCuenta0, "Inicio - Registro de Plan de Pago", btnGrabar1);

            #region SETEO DE PARAMETROS A REGISTRAR

            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;
            DateTime dfecDesemb = dtpFecDesembolso.Value.Date;

            dtCalendarioPagos = conPlanPagos1.dtCalendarioPagos;
            dtCalendarioPagos.TableName = "dtPlanPago";

            foreach (DataRow item in dtCalendarioPagos.Rows)
            {
                item["nIdSolicitud"] = nNumsolicitud;
            }

            DataSet dsPlanPagos = new DataSet("dsPlanPagos");

            dsPlanPagos.Tables.Add(dtCalendarioPagos);
            //Formar el Detalle De Gastos de la Solicitud tal como va ser registrado en Base de Datos

            //dsPlanPagos.Tables.Add(cnplanpago.FormarTablaDetalleGastos(dtAuxConfigGastos, this.conPlanPagos1.dtCalendarioPagos.Rows.Count, nNumsolicitud));
            DataTable dtGastosSolicitud = conPlanPagos1.dtGastosPP ?? cnplanpago.ObtenerGastos(nNumsolicitud);
            dtGastosSolicitud.TableName = "TablaDetalleGastosSolicitud";
            dsPlanPagos.Tables.Add(dtGastosSolicitud);

            //Ubicar la ultima fecha de pago de Crédito
            DateTime dFechaUltimoPagoCredito = dtCalendarioPagos.AsEnumerable().Last().Field<DateTime>("fecha");

            dtModificaciones = conPlanPagos1.dtModificaciones;
            dtModificaciones.TableName = "dtModificaciones";

            dsPlanPagos.Tables.Add(dtModificaciones);

            dtConfigGasto.TableName = "dtConfigGasto";

            dsPlanPagos.Tables.Add(dtConfigGasto);

            #region Datos de crédito a xml

            DataTable dtDatCred = new DataTable("dtDatCred");

            dtDatCred.Columns.Add("idTipoPeriodo", typeof(int));
            dtDatCred.Columns.Add("nPlazoCuota", typeof(int));
            dtDatCred.Columns.Add("nDiasGracia", typeof(int));

            // ========================================================================================
            // Guardando la aplicación del seguro y el monto de cobertura del crédito
            // ========================================================================================
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof(decimal));
            // ========================================================================================
            // Final Guardando la aplicación del seguro y el monto de cobertura del crédito
            // ========================================================================================

            // ========================================================================================
            // Guardando la seleccion de la modalidad de desembolso
            // ========================================================================================
            dtDatCred.Columns.Add("idModalidadDes", typeof(int));
            // ========================================================================================
            // Final Guardando la seleccion de la modalidad de desembolso
            // ========================================================================================
            // Paquete de seguros
            dtDatCred.Columns.Add("idPaqueteSeguro", typeof(int));
            dtDatCred.Columns.Add("idFrmPaqueteSeguro", typeof(int));

            int idModalidadDesembolso = Convert.ToInt32(cboModDesemb.SelectedValue);

            objSolicitudCreditoSeguroActual.idPaqueteSeguro = objSolicitudCreditoSeguroActual.idPaqueteSeguro == -2 ? 0 : objSolicitudCreditoSeguroActual.idPaqueteSeguro;  //Rechazada por jefe

            dtDatCred.Rows.Add(conCreditoPeriodo.idTipoPeriodo, conCreditoPeriodo.nPeriodoDia, (int)nudDiasGracia.Value,
                                lAplicaSeguro, nCapitalMaxCobSeg, conPlanPagos1.cnplanpago.nMontoCuota, idModalidadDesembolso, objSolicitudCreditoSeguroActual.idPaqueteSeguro, objSolicitudCreditoSeguroActual.idFrmPaqueteSeguro);
            dsPlanPagos.Tables.Add(dtDatCred);

            #endregion

            string xmlPpg = dsPlanPagos.GetXml();
            xmlPpg = clsCNFormatoXML.EncodingXML(xmlPpg);
            dsPlanPagos.Tables.Clear();
            string cModDesemb = cboModDesemb.GetItemText(cboModDesemb.SelectedItem);
            //bool lDesembolsoExterno = chcBancoNacion.Checked;
            bool lDesembolsoExterno = cModDesemb == "BANCO DE LA NACION" ? true : false;
            bool lExtractoPagos = chcExtractoPagos.Checked;
            int idMedioEnvio = rbtMedEnvio1.Checked ? 1 : rbtMedEnvio2.Checked ? 2 : 3;

            #endregion

            DataTable TablaInsPpg = cnplanpago.InsPpg(xmlPpg, dfecDesemb, conPlanPagos1.txtTCEA.nDecValor, conPlanPagos1.txtTEA.nDecValor,
                Convert.ToInt32(conPlanPagos1.txtTotDias.Text), dFechaUltimoPagoCredito, lDesembolsoExterno, lExtractoPagos, idMedioEnvio);

            TablaInsPpg.Columns[0].ColumnName = "cuota";
            conPlanPagos1.dtgCalendario.DataSource = TablaInsPpg;

            cnsolicitud.CNUpdtasaSolCre(nNumsolicitud, conPlanPagos1.txtTCEA.nDecValor);

            /*-objSolicitudCreditoSeguroActual-*/


            #region Ejecucion de Notificacion por SMS
            objAdministracionEnvioSMS.ejecutarNotificacionSMS();
            #endregion 

            if (idModalidadDesembolso == 2)
            {
                MessageBox.Show("Los datos se guardaron correctamente.\nA continuación vincule la Cuenta de Ahorros e imprima la hoja resumen con el plan de pagos.", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos se guardaron correctamente.\nA continuación imprima la Hoja Resumen con el plan de pagos.", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            habilitarHojaResumen(conBusCuentaCli1.nValBusqueda);

            btnGrabar1.Enabled = false;
            btnImprimir1.Enabled = true;
            btnHojaResumen.Enabled = (idModalidadDesembolso == 2 && idTipoPersona == 1) ? false : true;
            //btnVincularCuentaAhorro.Enabled = (idModalidadDesembolso == 2) ? true : false;
            btnVincularCuentaAhorro.Enabled = (idModalidadDesembolso == 2 && idTipoPersona == 1) ? true : false;
            btnHabilitarSeguro.Enabled = false;
            btnDevolver.Enabled = false;
            btnVincularPagare.Enabled = false;
            conPlanPagos1.grbEditor.Enabled = false;
            DataTable TablaNidCuenta1 = cnplanpago.CNRetornaCuentaXSolicitud(conBusCuentaCli1.nValBusqueda);
            btnValidarSMS.Enabled = false;
            grbCondicionSol.Enabled = false;

            int nIdCuenta1 = Convert.ToInt32(TablaNidCuenta1.Rows[0]["nIdCuenta"].ToString());

            #region Valida Clientes Camp Navideña

            ValidaClienteBonoCampNavi(Convert.ToInt32(conBusCuentaCli1.nIdCliente.ToString()), Convert.ToString(txtMonAprobado.Text.ToString()), Convert.ToInt32(conBusCuentaCli1.nValBusqueda.ToString()), nIdCuenta1);

            #endregion

            registrarRastreo(conBusCuentaCli1.nIdCliente, nIdCuenta1, "Fin - Registro de Plan de Pago", btnGrabar1);



        }

        private void ValidaClienteBonoCampNavi(int idCli, string dMonto, int idSolicitud, int idCuenta)
        {

            DataTable dtValidaCliente = cnplanpago.CNValidaClienteCampNav(idCli, dMonto, idSolicitud, idCuenta);
            int nIdMsj = Convert.ToInt32(dtValidaCliente.Rows[0]["nIdMsj"].ToString());
            string cMensaje = Convert.ToString(dtValidaCliente.Rows[0]["cMensaje"].ToString());


            if (nIdMsj == 1)
            {
                MessageBox.Show(cMensaje + "\n Se enviará un SMS al cliente al momento del desembolso.", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.btnValidarSMS.Enabled = true;


            }

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idsolicitud = Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda);

            if (idsolicitud == 0)
            {
                MessageBox.Show("Debe seleccionar a un cliente con solicitud vigente", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtPpgCred = new clsRPTCNPlanPagos().ADCronogramaXSolicitud(idsolicitud);
            int idcli = Convert.ToInt32(dtPpgCred.Rows[0]["idCli"]);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false));
            //paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().DatosSolicitudImpPPG(idsolicitud)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNdocumento(idcli)));
            dtslist.Add(new ReportDataSource("dsIntervinientes", cncredito.DetalleImpPagare(idsolicitud)));

            string reportpath = "rptCalendarioPagos.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();

        }

        private void btnHojaResumen_Click(object sender, EventArgs e)
        {
            int idModalidadDesembolso = Convert.ToInt32(cboModDesemb.SelectedValue);
            DataTable dtDatosSolicitud = new DataTable("dtDatosSolicitud");
            clsCNBuscaSolicitud Solicitud = new clsCNBuscaSolicitud();
            dtDatosSolicitud = Solicitud.DatoSolicitud(conBusCuentaCli1.nValBusqueda);

            lCuentaAhorroVinculada = (Convert.ToInt32(dtDatosSolicitud.Rows[0]["idCuentaDeposito"]) != 0) ? true : false;

            if (idModalidadDesembolso == 2 && !lCuentaAhorroVinculada)
            {
                MessageBox.Show("Aún no ha vinculado la cuenta de ahorro, Debe crear o seleccionar una Cuenta de Ahorros. ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CargarConfiguracionCuentaDesembolso();

                return;

                //DialogResult drResultado = MessageBox.Show("Aun no ha vinculado la cuenta de ahorro para el desembolso.\n¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if(drResultado == DialogResult.No)
                //{
                //    return;
                //}
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idsolicitud = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);

            DataTable dtPpgCred = new clsRPTCNSolicitud().CNRptHojaResumen(idsolicitud);
            DataTable dtPpgCred1 = new clsRPTCNSolicitud().CNRptHojaResumenPlanPago(idsolicitud);

            DataTable dtVariable = new clsCNConfiguracionImpresionContratos().obtenerVariableConfiguracion();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idSolicitud", idsolicitud.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaResolucion1", clsVarApl.dicVarGen["dFechaSalidaImpContratos"].ToString(), false));
            paramlist.Add(new ReportParameter("lVisibleAutorizaUsoDatos", this.conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos.ToString(), false));

            dtslist.Add(new ReportDataSource("dsHojaResumen", dtPpgCred));
            dtslist.Add(new ReportDataSource("dtsPPG", dtPpgCred1));
            dtslist.Add(new ReportDataSource("dtVariables", dtVariable));

            //const string reportpath = "RptHojaResumen.rdlc";
            const string reportpath = "RptHojaResumenNuevo.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();

            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
            DataTable dtDatosNumSolicutd = RetornaNumSolicitud.CNRetornaNumSolicitud(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text), "S", "[1,2,13,19]");

            if (Convert.ToInt32(cboModDesemb.SelectedValue) != 4)
            {
                if (dtDatosNumSolicutd.Rows.Count != 0)
                {
                    btnDesembolso.Enabled = true;
                }
            }
            else
            {
                btnDesembolso.Enabled = (lDesembolso || lDevolucion) ? false : true;
            }

            nConTbAct = 1;
        }

        private void btnVincularPagare_Click(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli1.txtNroBusqueda.Text != "")
            {
                frmVincularPagare frmpagare = new frmVincularPagare(conBusCuentaCli1.nValBusqueda);
                frmpagare.ShowDialog();
                //habilitarHojaResumen(conBusCuentaCli1.nValBusqueda);
            }
            else
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Vincular Pagaré", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            CancelarRegistro();
        }

        private void btnVincularCuentaAhorro_Click(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Vincular cuenta de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /// Convocacion de Apertura de cuenta
            CargarConfiguracionCuentaDesembolso();
            btnHojaResumen.Enabled = true;
        }

        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            MostrarCargaArchivo();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            string cMsjCaption = "Expediente Virtual";

            if (this.conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.conBusCuentaCli1.nIdCliente == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(Convert.ToInt32(this.conBusCuentaCli1.nValBusqueda), this.conBusCuentaCli1.nIdCliente, "individual");
            frmExpLinea.ShowDialog();
            btnVincularPagare.Enabled = (lSuperaMontoExposicion) ? true : false;
            //1 x 0
            conPlanPagos1.grbEditor.Enabled = false;
        }

        private void btnValidarSMS_Click(object sender, EventArgs e)
        {
            objAdministracionEnvioSMS.registrarNotificacion();
        }

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            MostrarCheckListArchivo();
        }

        private void btnDesembolso_Click(object sender, EventArgs e)
        {
            List<clsSolicitudCreditoSeguro> listaSolicitudCreditoSeguro = new List<clsSolicitudCreditoSeguro>();
            BindingSource bsCargaSeguros = new BindingSource();
            bsCargaSeguros = this.conSolicitudCargaSeguros.bsCargaSeguros;
            listaSolicitudCreditoSeguro = (List<clsSolicitudCreditoSeguro>)bsCargaSeguros.List;
            int IdSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
            frmDesembolso FrmDesembolso = new frmDesembolso(IdSolicitud, listaSolicitudCreditoSeguro);
            FrmDesembolso.lDesembolso = false;
            FrmDesembolso.lDevolucion = false;
            FrmDesembolso.idDesembolso = Convert.ToInt32(cboModDesemb.SelectedValue);
            FrmDesembolso.nDesembolso = cboModDesemb.Text;
            FrmDesembolso.objFrmSemaforo = this.objFrmSemaforo;
            FrmDesembolso.ShowDialog();
            if (FrmDesembolso.lDesembolso == true)
            {
                btnImprimirContratos.Enabled = true;
                btnDesembolso.Enabled = false;
                btnProcesar.Enabled = false;
                btnVincularCuentaAhorro.Enabled = false;
                btnChecklist.Enabled = false;
                lDesembolso = true;
            }
            if (FrmDesembolso.lDevolucion == true)
            {
                CancelarRegistro();
                btnDesembolso.Enabled = false;
                btnProcesar.Enabled = false;
                lDevolucion = true;
            }
        }

        private void tbcCalendario_Click(object sender, EventArgs e)
        {
            tbcBase obj = sender as tbcBase;

            if (conBusCuentaCli1.txtCodCli.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar una solicitud primero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                obj.SelectedIndex = 0;
                return;
            }

            if (obj.SelectedIndex == 1)
            {
                if (conPlanPagos1.dtgCalendario.Rows.Count > 0)
                {
                    nConTbSeg = nConTbSeg + 1;
                }

            }
        }

        private void btnImprimirContratos_Click(object sender, EventArgs e)
        {
            var datosReporte = this.prepararReporte();

            if (datosReporte == null)
            {
                return;
            }

            List<ReportDataSource> dtslist = datosReporte.Item1;
            List<ReportParameter> paramlist = datosReporte.Item2;
            string reportpath = "rptContratoFirmas.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnMiniAgregarExtraPrima_Click(object sender, EventArgs e)
        {
            if (dtgConfigGasto.Rows.Count <= 0)
            {
                MessageBox.Show("No se ha encontrado ninguna configuración aplicable", "Extra Prima", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmExtraPrima frmExtraPrima = new frmExtraPrima();
            frmExtraPrima.idSolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
            frmExtraPrima.ShowDialog();

            if (frmExtraPrima.lAceptar)
            {
                txtExtraPrima.Text = frmExtraPrima.nExtraPrima.ToString();
                CargarConfiguracionesDeGasto(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));
            }
        }

        private void btnMiniCancelarExtraPrima_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtExtraPrima.Text) == 0)
            {
                return;
            }

            DataTable dtResultado = cnsolicitud.CNGuardarExtraPrima(
                0,
                "Quitado de Extra Prima",
                Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text),
                clsVarGlobal.PerfilUsu.idUsuario,
                clsVarGlobal.PerfilUsu.idPerfil
                );

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Extra Prima", MessageBoxButtons.OK, Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 1)
                {
                    txtExtraPrima.Text = "0.0";
                    CargarConfiguracionesDeGasto(Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text));
                }
                else
                {
                    return;
                }
            }
        }

        private void chcExtractoPagos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcExtractoPagos.Checked)
            {
                grbExtracto.Visible = true;
                rbtMedEnvio1.Checked = false;
                rbtMedEnvio2.Checked = false;
                rbtMedEnvio3.Checked = true;
            }
            else
            {
                grbExtracto.Visible = false;
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {

            if (this.conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Devolver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                btnProcesar.Enabled = false;
            }
        }

        private void chcBancoNacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBancoNacion.Checked == true)
            {
                cboModDesemb.SelectedValue = 4;
                cboModDesemb.Enabled = false;
            }
            if (chcBancoNacion.Checked == false)
            {
                cboModDesemb.SelectedValue = 1;
                cboModDesemb.Enabled = true;
            }
        }

        #endregion

        #region Metodos

        private void IniDtGastos()
        {
            dtAuxConfigGastos = new DataTable("TablaDetalleGastosSolicitud");

            dtAuxConfigGastos.Columns.Add("idSolicitud", typeof(int));
            dtAuxConfigGastos.Columns.Add("idPlanPagos", typeof(int));
            dtAuxConfigGastos.Columns.Add("idCuota", typeof(int));
            dtAuxConfigGastos.Columns.Add("nGasto", typeof(decimal));
            dtAuxConfigGastos.Columns.Add("nValor", typeof(decimal));
            dtAuxConfigGastos.Columns.Add("idTipoGasto", typeof(int));
            dtAuxConfigGastos.Columns.Add("idTipoValor", typeof(int));
            dtAuxConfigGastos.Columns.Add("idAplicaConc", typeof(int));
            dtAuxConfigGastos.Columns.Add("lVigente", typeof(bool));
        }

        private void IniEstructuradtModifica()
        {
            dtModificaciones = new DataTable("dtModificaciones");

            dtModificaciones.Columns.Add("cTipoAccion", typeof(string));
            dtModificaciones.Columns.Add("idTipoAccion", typeof(int));
            dtModificaciones.Columns.Add("nCuota", typeof(int));
            dtModificaciones.Columns.Add("nOtraCuota", typeof(int));
            dtModificaciones.Columns.Add("nMes", typeof(int));
            dtModificaciones.Columns.Add("cMes", typeof(string));
            dtModificaciones.Columns.Add("nAnio", typeof(int));
            dtModificaciones.Columns.Add("cAnio", typeof(string));
            dtModificaciones.Columns.Add("nMonto", typeof(decimal));
            dtModificaciones.Columns.Add("lIndTodAnios", typeof(bool));
            dtModificaciones.Columns.Add("idCuotalibre", typeof(int));
            dtModificaciones.Columns.Add("nDia", typeof(int));
        }

        private bool ValidarRegistrar()
        {
            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;
            DateTime dfecDesemb = dtpFecDesembolso.Value.Date; //Fecha de Desembolso
            DataTable dtReaprob = cnReaprobSol.obtenerReaprobacion(nNumsolicitud);

            if (nNumsolicitud <= 0)
            {
                MessageBox.Show("Se necesita cargar los datos de una solicitud para grabar el plan de pagos", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (conPlanPagos1.dtCalendarioPagos.Rows.Count <= 0)
            {
                MessageBox.Show("No se ha generado un plan de pagos para grabarlo", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dfecDesemb < clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha de desembolso no puede ser menor a la fecha del Sistema", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dtReaprob.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtReaprob.Rows[0]["idEstado"]) == 1)
                {
                    MessageBox.Show("La última instancia de aprobación del crédito refinanciado/novado debe actualizar el monto de aprobación.", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edición finalice.", "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                return false;
            }


            return true;
        }

        private bool validarRegistroPagare(int _idSolicitud)
        {
            bool lValidar = true;

            DataTable dtVinculacionPagare = objCNCargaArchivo.CNVerificarVinculacionPagare(_idSolicitud);

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

        private bool validarExcepcionProductoCampaña()
        {
            bool lValor = false;

            clsVarGen objVarGen = clsVarGlobal.lisVars.Find(item => item.cVariable == "cListaProductoCampanaConsumo");
            List<int> lstProductoCampaña = (objVarGen == null) ? new List<int>() : objVarGen.cValVar.Split(',').Select(Int32.Parse).ToList();

            if (objVarGen == null)
                lValor = false;
            else if (lstProductoCampaña.Any(item => item == idProducto))
                lValor = true;
            else
                lValor = false;

            return lValor;
        }

        private void CargarDatos()
        {
            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;

            clsCNRetornaNumSolicitud RetornaNumSolicitud = new clsCNRetornaNumSolicitud();
            DataTable dtDatosNumSolicitud = RetornaNumSolicitud.CNRetornaNumSolicitud(nNumsolicitud, "S", "[1,2,13,19]");

            if (dtDatosNumSolicitud.Rows.Count == 0)
            {
                return;
            }

            if (dtDatosNumSolicitud.Rows[0]["cEstado"].ToString() != "APROBADO")
            {
                string cMensaje = "El estado de la solicitud es: " + dtDatosNumSolicitud.Rows[0]["cEstado"].ToString() + ".";
                MessageBox.Show(cMensaje, "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CancelarRegistro();
                return;
            }

            CargaDatosSolicitud(nNumsolicitud);

            if (objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Any(x => x.lCambioPrima && x.lVigente && x.lModificado) && objSolicitudCreditoSeguroActual.lAceptacionInclusionCapital) //Truncante si es que ha cambiado la prima del seguro y está financiado
            {
                btnProcesar.Enabled = btnGrabar1.Enabled = btnDesembolso.Enabled = false;
                tbcCalendario.Enabled = false;
                return;
            }

            //Cargar Grid con Configuraciones de Gasto
            if (txtMonAprobado.Text.Length <= 0)
                return;

            /*La generación de plan de Pagos se realiza para las siguientes operaciones:
             * -OTORGAMIENTO
             * -REFINANCIACION
             * -AMPLIACION
             * -REFINANCIACION POR NOVACION
             */
            if (conBusCuentaCli1.nOperacion.In(1, 4, 2, 6))
            {
                CargarConfiguracionesDeGasto(nNumsolicitud);
            }
            else
            {
                MessageBox.Show("La solicitud no es de OTORGAMIENTO, AMPLIACIÓN, REFINANCIACIÓN o NOVACIÓN",
                    "Validar Buscar Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CancelarRegistro();
                return;

            }

            idOperacionCred = conBusCuentaCli1.nOperacion;

            DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(nNumsolicitud);
            if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
            {
                MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            procesarPlanPagos();

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli1.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
            conSolicitudCargaSeguros.ValidarSegurosQueNoSePuedenMarcar();

            conSolicitudCargaSeguros.PintarPlanesDeSeguro();

            //Validar bloqueo de seguros optativos por producto
            lVisibleSegurosOptativo = validarProductoSeguro();
            label2.Visible = lVisibleSegurosOptativo;
            conSolicitudCargaSeguros.Visible = lVisibleSegurosOptativo;
        }

        private bool validarProductoSeguro()
        {
            bool lValor = true;
            clsVarGen objVariableGeneral = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cListaProductoAplicaSeguro"));
            string cListaProducto = objVariableGeneral.cValVar;

            if (cListaProducto == "0")
                return true;
            List<int> lstProductosPermitidos = objVariableGeneral.cValVar.Split(',').Select(Int32.Parse).ToList();
            int idProductoSeleccionado = Convert.ToInt32(idProducto);

            lValor = (lstProductosPermitidos.Contains(idProductoSeleccionado)) ? false : true;

            return lValor;
        }

        private async void CargaDatosSolicitud(int nNumsolicitud)
        {
            if (nNumsolicitud <= 0)
            {
                return;
            }

            DataTable dtExtraPrima = cnsolicitud.CNObtenerExtraPrima(nNumsolicitud);
            if (dtExtraPrima.Rows.Count > 0)
            {
                txtExtraPrima.Text = dtExtraPrima.Rows[0]["nValor"].ToString();
            }
            else
            {
                txtExtraPrima.Text = "0.0";
            }

            DataTable dtReaprob = cnReaprobSol.obtenerReaprobacion(nNumsolicitud);
            if (dtReaprob.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtReaprob.Rows[0]["idEstado"]) == 1)
                {
                    MessageBox.Show(
                        "La última instancia de aprobación del crédito refinanciado/novado debe actualizar el monto de aprobación.",
                        "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CancelarRegistro();
                }
                else
                {
                    MessageBox.Show(
                        "Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edición finalice.",
                        "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CancelarRegistro();

                }
                return;
            }

            dtDatosModGPP = cnReaprobSol.obtenerDatosModGPP(nNumsolicitud);

            if (Convert.ToInt32(dtDatosModGPP.Rows[0]["idSolicitudCredGrupoSol"]) != 0)
            {
                MessageBox.Show(
                        "La solicitud pertenece a un grupo solidario, no se puede generar plan de pagos por esta opción",
                        "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtLisIntervSol = new DataTable();
            clsCNIntervCre IntervCre = new clsCNIntervCre();
            dtLisIntervSol = IntervCre.CNObtenerIntervinienteActaSolicitud(nNumsolicitud, clsVarGlobal.idModulo);
            dtgBaseIntervinientes.DataSource = dtLisIntervSol;
            FormatoGrid();

            DataTable dtSolicitud = new DataTable("dtSolicitud");
            clsCNBuscaSolicitud Solicitud = new clsCNBuscaSolicitud();
            dtSolicitud = Solicitud.DatoSolicitud(nNumsolicitud);

            if (dtSolicitud.Rows.Count > 0)
            {
                this.conBusCuentaCli1.nIdCliente = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);
            }

            conCreditoPeriodo.ChangePeriodo -= conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo -= conCreditoPeriodo_ChangeTipoPeriodo;
            dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
            conCreditoPrimeraCuota.ValueChangedFecha -= conCreditoPrimeraCuota_ValueChangedFecha;

            decimal nMonto = Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalAprobado"]);
            txtMonAprobado.Text = nMonto.ToString();
            txtNumCuotaCre.Text = dtSolicitud.Rows[0]["nCuotas"].ToString();
            //            cboTipoPeriodo1.SelectedValue = Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPeriodo"]);
            this.conCreditoPeriodo.asignarPeriodoCredito(
                Convert.ToInt32(dtSolicitud.Rows[0]["idTipoPeriodo"]),
                Convert.ToInt32(dtSolicitud.Rows[0]["nPlazoCuota"]),
                Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]),
                Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"])
                );
            this.conCreditoPeriodo.lPeriodoEnabled = false;

            nudDiasGracia.Value = (int)dtSolicitud.Rows[0]["nDiasGracia"];
            nudCuotasGracia.Value = (int)dtSolicitud.Rows[0]["nCuotasGracia"];
            dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
            DateTime dFechaDesembolsoTmp = dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value
                ? clsVarGlobal.dFecSystem
                : Convert.ToDateTime(dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"]);
            dtpFecDesembolso.Value = (dFechaDesembolsoTmp.Date < clsVarGlobal.dFecSystem) ? clsVarGlobal.dFecSystem : dFechaDesembolsoTmp;
            dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;

            conCreditoPrimeraCuota.asignarPrimeraCuota(
                conCreditoPeriodo.idTipoPeriodo,
                conCreditoPeriodo.nPeriodoDia,
                (int)nudDiasGracia.Value,
                this.dtpFecDesembolso.Value,
                Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]),
                0, default(DateTime), 0, nNumsolicitud);

            dFechaIncial = conCreditoPrimeraCuota.dFecha;

            if (conCreditoPrimeraCuota.lDiaAjustado)
            {
                MessageBox.Show("Se cambia el día de pago de " + conCreditoPeriodo.nPeriodoDia.ToString()
                    + " a " + conCreditoPrimeraCuota.dFecha.Day.ToString()
                    + ", pues la diferencia mínima en dias entre la fecha de desembolso y la fecha de primera cuota es 20."
                    , "DIA AJUSTADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.dFecha.Day);
            }
            calcularDiasPrimCuota();
            if (conCreditoPeriodo.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && Convert.ToInt32(dtSolicitud.Rows[0]["nCuotas"]) == 1)
            {
                this.conCreditoPrimeraCuota.lFechaEnabled = false;
            }

            idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            txtTasaInteres.Text = dtSolicitud.Rows[0]["nTasaAprobada"].ToString();
            idProducto = Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]);
            txtOperacion.Text = dtSolicitud.Rows[0]["cOperacion"].ToString();
            txtModalidadCre.Text = dtSolicitud.Rows[0]["cModalidadCredito"].ToString();
            cboTipoPersona.Text = dtSolicitud.Rows[0]["cTipoPersona"].ToString();
            cboMoneda.Text = dtSolicitud.Rows[0]["cMoneda"].ToString();
            txtTipoPeriodo.Text = this.conCreditoPeriodo.cboTipoPeriodo.Text;

            DataTable dtResultado = objCNCreditoCargaSeguro.CNValidarActaulizarDesgravamenEspecial(nNumsolicitud, nMonto);
            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["idResultado"]) == 0)
                {
                    MessageBox.Show(dtResultado.Rows[0]["cResultado"].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            cargarConfiguracionSeguro();
            btnHabilitarSeguro.Enabled = true;
            btnDevolver.Enabled = true;
            btnVincularPagare.Enabled = (lSuperaMontoExposicion) ? true : false;
            //1 x 0
            conPlanPagos1.grbEditor.Enabled = false;

            DataTable dtDestinoCreditoEvaluacion = cnsolicitud.ObtenerDestinoCreditoEvaluacion(Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]), 5);
            int idDestino = Convert.ToInt32(dtSolicitud.Rows[0]["idDestino"]);
            int idOperacion = Convert.ToInt32(dtSolicitud.Rows[0]["idOperacion"]);
            int idModalidadDesembolso = 0;
            idTipoPersona = Convert.ToInt32(dtSolicitud.Rows[0]["IdTipoPersona"]);
            if ((dtDestinoCreditoEvaluacion.Rows.Count > 0 && idOperacion != 2 && idOperacion != 6) || (idDestino == 29 && idOperacion != 2 && idOperacion != 6))
            {
                MessageBox.Show("La modalidad de desembolso debe ser \"TRANSFERENCIA A CUENTA\" cuando el destino de credito es \"COMPRA DEUDA\", excepto para operaciones de Refinanciación y Refinanciación por Novación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idModalidadDesembolso = 2;
                cboModDesemb.SelectedValue = idModalidadDesembolso;
                cboModDesemb.Enabled = false;
            }
            else if (idOperacion == 2 || idOperacion == 6)
            {
                MessageBox.Show("La modalidad de desembolso debe ser \"EFECTIVO\" cuando el tipo de operacion es \"REFINANCIACION - REFINANCIACIÓN POR NOVACIÓN\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idModalidadDesembolso = 1;
                cboModDesemb.SelectedValue = idModalidadDesembolso;
                cboModDesemb.Enabled = false;
                chcBancoNacion.Enabled = false;
            }
            else
            {
                if ((idTipoPersona == 2 || idTipoPersona == 3))
                {
                    MessageBox.Show("La modalidad de desembolso debe ser \"EFECTIVO\" cuando el tipo de persona es \"JURIDICA\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    idModalidadDesembolso = 1;
                    cboModDesemb.SelectedValue = idModalidadDesembolso;
                    cboModDesemb.Enabled = false;
                }
                else
                {
                    idModalidadDesembolso = 2;
                    cboModDesemb.SelectedValue = idModalidadDesembolso;
                    cboModDesemb.Enabled = true;
                }

            }
            btnProcesar.Enabled = true;
            btnListaAprob.Enabled = false;
            btnChecklist.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = false;
            conBusCuentaCli1.btnBusCliente1.Enabled = false;

            tbcCalendario.SelectedIndex = 0;
            btnVincularCuentaAhorro.Enabled = false;
            if (dtSolicitud.Rows[0]["lDesembolsoExterno"] != DBNull.Value && Convert.ToBoolean(dtSolicitud.Rows[0]["lDesembolsoExterno"]))
            {
                cboModDesemb.SelectedIndex = cboModDesemb.FindStringExact("BANCO DE LA NACION");
            }
            DataTable dtEstadoSolicitud = clsFiles.obtenerDatosSolicitud(nNumsolicitud);
            if (dtEstadoSolicitud.Rows.Count > 0)
            {
                idEstadoSolicitud = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["idEstado"]);
                idTipoPersona = Convert.ToInt32(dtEstadoSolicitud.Rows[0]["IdTipoPersona"]);
                lSuperaMontoExposicion = Convert.ToBoolean(dtEstadoSolicitud.Rows[0]["lSuperaMontoExposicion"]);
            }
            conCreditoPeriodo.ChangePeriodo += conCreditoPeriodo_ChangePeriodo;
            conCreditoPeriodo.ChangeTipoPeriodo += conCreditoPeriodo_ChangeTipoPeriodo;
            dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
            conCreditoPrimeraCuota.ValueChangedFecha += conCreditoPrimeraCuota_ValueChangedFecha;

            List<clsClienteNotificacionSMS> lstClienteNotificacion = new List<clsClienteNotificacionSMS>();
            objAdministracionEnvioSMS.cargarDatosOperacion(Convert.ToInt32(dtSolicitud.Rows[0]["idSolicitud"]), Convert.ToInt32(dtSolicitud.Rows[0]["idMoneda"]), Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalAprobado"]), Convert.ToInt32(dtSolicitud.Rows[0]["idProducto"]), 1);
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (conBusCuentaCli1.idTipoPersona == 1)
                {
                    bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, conBusCuentaCli1.txtCodCli.Text.Trim(), conBusCuentaCli1.nValBusqueda,
                        conBusCuentaCli1.txtNombreCli.Text, conBusCuentaCli1.txtNroDoc.Text,
                                           conBusCuentaCli1.pcDireccion, conBusCuentaCli1.pcTelefono, conBusCuentaCli1.idTipoPersona, conBusCuentaCli1.idTipoDocumento);//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES


                }
                else
                {
                    DataTable dtIntervinientes = new clsCNTipAutUsoDatos().CNObtenerIntervinienteBiometrico(conBusCuentaCli1.nIdCliente);

                    var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"])) //&& Convert.ToInt32(x["idCli"]) == pIdCliente)
                                                .OrderBy(x => Convert.ToInt32(x["idCli"]));

                    foreach (var titular in listFirmantes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        conAutorizacionUsuDatos1.pcNombreJuridico = conBusCuentaCli1.txtNombreCli.Text.Trim();
                        conAutorizacionUsuDatos1.pcNroDocJuridico = conBusCuentaCli1.txtNroDoc.Text.Trim();
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES



                    }
                }

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
                this.dtpFecDesembolso.Value,
                this.conCreditoPeriodo.idPeriodo);

                this.nudDiasGracia.Value = conCreditoPrimeraCuota.nDiasGracia;
                this.conCreditoPeriodo.actualizarDia(conCreditoPrimeraCuota.nPeriodoDia);

                if (this.conCreditoPrimeraCuota.lDiaAjustado)
                    this.conCreditoPeriodo.actualizarDia(this.conCreditoPrimeraCuota.nDia);
            }
        }

        private void CargarConfiguracionesDeGasto(int nNumSolicitud)
        {
            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            #region Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            DataTable dtTodosConfigGastos = objSegDes.validarAplicaSeguroDesgravamen(nNumSolicitud, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal);
            nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            lAplicaSeguro = objSegDes.obternerNAplicaSeguro();
            dtgConfigGasto.DataSource = dtTodosConfigGastos;
            conPlanPagos1.nCapitalMaxCobSeg = nCapitalMaxCobSeg;

            #endregion

            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 
            dtConfigGasto = SeleccionarTipoTasaEnConfiguracion(dtTodosConfigGastos);

            dtgConfigGasto.DataSource = dtConfigGasto;
            FormatGastos();
        }

        private bool ValidarSeguros()
        {
            List<clsMantenimientoPaqueteSeguro> lstPaqueteSeguros = DataTableToList.ConvertTo<clsMantenimientoPaqueteSeguro>(new clsCNPaqueteSeguro().CNListarTodosLosPaqueteDeSeguro()) as List<clsMantenimientoPaqueteSeguro>;

            if (objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.Find(x => x.idTipoSeguro == 1).lSeleccionado) //1	SEGURO MULTIRIESGO
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoSeguroActual.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoSeguroActual.idCli))
                {
                    MessageBox.Show("El seguro multiriesgo solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Ir al tab 2
                    return false;
                }

                //VERIFICAR QUE NO EXCEDA DE LOS 100,000.00
                if (objSolicitudCreditoSeguroActual.nMontoSolicitado > Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo supera los " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMaximoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //VERIFICAR QUE SE CUMPLA EL MONTO MINIMO
                if (objSolicitudCreditoSeguroActual.nMontoSolicitado < Convert.ToDecimal(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]))
                {
                    MessageBox.Show("El importe del préstamo para aplicar multiriesgo debe ser mayor o igual a " + Convert.ToInt32(clsVarApl.dicVarGen["nMontoMinimoMultiriesgo"]) + ", no es posible aplicar el seguro multiriesgo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


                if (objSolicitudCreditoSeguroActual.nEsSimulador != 1)
                {
                    //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                    if (objSolicitudCreditoSeguroActual.idOperacion != 2 && objSolicitudCreditoSeguroActual.idOperacion != 4)
                    {
                        //VERIFICAR SI TIENE OTRO SEGURO MULTIRIESGO
                        DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(objSolicitudCreditoSeguroActual.idCli);
                        DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                      where fila.Field<bool>("lVigente") == true && fila.Field<int>("idConcepto") == Convert.ToInt32(clsVarApl.dicVarGen["nIdConceptoMultiriesgo"]) //FILTRANDO MULTIRIESGO
                                      select fila).FirstOrDefault();
                        if (dr != null && objSolicitudCreditoSeguroActual.idOperacion == 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else if (dr != null && objSolicitudCreditoSeguroActual.idOperacion != 3)
                        {
                            MessageBox.Show("El cliente tiene un seguro multiriesgo vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    //VERIFICAR QUE EN LOS DATOS DE DIRECCION PRINCIPAL, EL CLIENTE TENGA LOS CINCO CAMPOS AGREGADOS EN ESTE REQUERIMIENTO
                    DataTable tbDirCli = new clsCNDirecCli().ListaDirCli(objSolicitudCreditoSeguroActual.idCli);
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
            else if (lstPaqueteSeguros.Select(p => p.idPaqueteSeguro).ToList().Contains(objSolicitudCreditoSeguroActual.idPaqueteSeguro))
            {
                //VERIFICAR QUE SEA CLIENTE NATURAL
                if (objSolicitudCreditoSeguroActual.nEsSimulador != 1 && !new clsCNCliente().ValidarSiEsClienteNatural(objSolicitudCreditoSeguroActual.idCli))
                {
                    MessageBox.Show("Los planes de seguro solo se puede vender a personas naturales.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //VALIDAR SI ESTAMOS EN REFINANCIACIÓN O AMPLIACIÓN PARA NO RESTRINGIR A COMPRAR UN NUEVO SEGURO
                if (objSolicitudCreditoSeguroActual.idOperacion != 2 && objSolicitudCreditoSeguroActual.idOperacion != 4)
                {
                    DataTable dtLsSeguros = objCNCreditoCargaSeguro.CNObtenerListaSegurosCliente(objSolicitudCreditoSeguroActual.idCli);
                    DataRow dr = (from fila in dtLsSeguros.AsEnumerable()
                                  where fila.Field<bool>("lVigente") == true && lstPaqueteSeguros.Select(p => p.idConcepto).ToList().Contains(fila.Field<int>("idConcepto"))
                                  select fila).FirstOrDefault();
                    if (dr != null && objSolicitudCreditoSeguroActual.idOperacion == 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ". En el proceso de REPROGRAMACIÓN debe continuar con el mismo Plan de seguro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (dr != null && objSolicitudCreditoSeguroActual.idOperacion != 3)
                    {
                        MessageBox.Show("El cliente tiene un Plan de seguro vigente, del " + dr.Field<DateTime>("dFechaIniCobertura").ToString("dd-MMM-yyyy") + " al " + dr.Field<DateTime>("dFechaFinCobertura").ToString("dd-MMM-yyyy") + ".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }

        /// <summary>
        /// Aplica estilo a Grid de Configuraciones de Gasto Aplicables
        /// </summary>
        private void FormatGastos()
        {
            dtgConfigGasto.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgConfigGasto.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgConfigGasto.Columns["lObligatorio"].Visible = true;
            dtgConfigGasto.Columns["cIdCuota"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoGasto"].Visible = true;
            dtgConfigGasto.Columns["nValor"].Visible = true;
            dtgConfigGasto.Columns["cIdTipoValor"].Visible = true;
            dtgConfigGasto.Columns["cMoneda"].Visible = true;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].Visible = true;

            dtgConfigGasto.Columns["lObligatorio"].HeaderText = "Aplicar ";
            dtgConfigGasto.Columns["cIdCuota"].HeaderText = "Cuota";
            dtgConfigGasto.Columns["cIdTipoGasto"].HeaderText = "Tipo de Gasto";
            dtgConfigGasto.Columns["nValor"].HeaderText = "Valor";
            dtgConfigGasto.Columns["cIdTipoValor"].HeaderText = "Tipo de Valor";
            dtgConfigGasto.Columns["cMoneda"].HeaderText = "Moneda";
            dtgConfigGasto.Columns["cIdAplicaConcepto"].HeaderText = "Aplicar al concepto";

            dtgConfigGasto.Columns["lObligatorio"].FillWeight = 5;
            dtgConfigGasto.Columns["cIdCuota"].FillWeight = 15;
            dtgConfigGasto.Columns["cIdTipoGasto"].FillWeight = 20;
            dtgConfigGasto.Columns["nValor"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdTipoValor"].FillWeight = 15;
            dtgConfigGasto.Columns["cMoneda"].FillWeight = 10;
            dtgConfigGasto.Columns["cIdAplicaConcepto"].FillWeight = 25;

            dtgConfigGasto.Columns["lObligatorio"].ReadOnly = false;

            //Dar permisos de lectura/Escritura al campo obligatorio
            for (int i = 0; i < dtgConfigGasto.Rows.Count; i++)
            {
                var dgcCampoObligatorio = dtgConfigGasto.Rows[i].Cells["lObligatorio"];
                dgcCampoObligatorio.ReadOnly = Convert.ToBoolean(dgcCampoObligatorio.Value);
            }
        }

        private static DialogResult MostarVentanaPregunta(string cTituloVentana)
        {
            Form frmDecision = new Form();

            Label lblTexto = new Label();

            PictureBox pictureBox = new PictureBox();

            Button btnPorcentualSimple = new Button();
            Button btnPorcentualCompuesto = new Button();

            frmDecision.Text = cTituloVentana;
            lblTexto.Text = "Existen 2 tipos de tasas (PORCENTUAL SIMPLE y PORCENTUAL COMPUESTO) en las configuraciones para ésta solicitud. Elija un tipo de Tasa.";
            lblTexto.AutoSize = false;

            btnPorcentualSimple.Text = "SIMPLE";
            btnPorcentualCompuesto.Text = "COMPUESTO";

            btnPorcentualSimple.DialogResult = DialogResult.OK;//Para la elección de Tasa Porcentual Simple
            btnPorcentualCompuesto.DialogResult = DialogResult.Cancel;//Para la elección de Tasa Porcentual Compuesta

            Icon Icono = SystemIcons.Question;
            pictureBox.Image = Icono.ToBitmap();

            lblTexto.SetBounds(65, 20, 400, 32);
            btnPorcentualSimple.SetBounds(68, 75, 135, 23);
            btnPorcentualCompuesto.SetBounds(288, 75, 165, 23);
            pictureBox.SetBounds(15, 20, 73, 50);
            //lblTexto.ForeColor = System.Drawing.Color.Navy;

            frmDecision.Height = 175;
            frmDecision.Width = 500;
            frmDecision.Controls.AddRange(new Control[] { lblTexto, btnPorcentualSimple, btnPorcentualCompuesto, pictureBox });

            frmDecision.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmDecision.StartPosition = FormStartPosition.CenterScreen;
            frmDecision.MinimizeBox = false;
            frmDecision.MaximizeBox = false;
            frmDecision.ControlBox = false;//deshabilitar el boton X del formulario
            frmDecision.CancelButton = btnPorcentualCompuesto;

            DialogResult dialogResult = frmDecision.ShowDialog();
            return dialogResult;
        }

        private static DataTable SeleccionarTipoTasaEnConfiguracion(DataTable dtTodosConfigGastos)
        {
            //Validar que sólo se trabaje con sólo un tipo de tasa PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO 

            //Contedrá los Gastos PORCENTUALES SIMPLES ó COMPUESTOS independiente de los FIJOS
            DataTable dtConfigGasto = dtTodosConfigGastos.Clone();

            bool lUsaPorcentualSimple = dtTodosConfigGastos.AsEnumerable()
                .Any(x => x.Field<string>("cIdTipoValor").ToUpper().Equals("PORCENTUAL SIMPLE"));
            bool lUsaPorcentualCompuesto = dtTodosConfigGastos.AsEnumerable()
                .Any(x => x.Field<string>("cIdTipoValor").ToUpper().Equals("PORCENTUAL COMPUESTO"));

            //Validar el uso de sólo un tipo de TASA PORCENTUAL
            if (lUsaPorcentualSimple && lUsaPorcentualCompuesto)//Existen en la configuración las 2 Tasas, entonces elegir uno de ellos
            {
                DialogResult result = MostarVentanaPregunta("Elección de tipo de Tasa:.");

                switch (result)
                {
                    case DialogResult.OK:
                        foreach (DataRow row in dtTodosConfigGastos.Rows.Cast<DataRow>()
                                                .Where(row => !row["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL COMPUESTO")))
                        {
                            dtTodosConfigGastos.ImportRow(row);
                        }
                        break;
                    case DialogResult.Cancel:
                        foreach (DataRow row in dtTodosConfigGastos.Rows.Cast<DataRow>()
                            .Where(row => !row["cIdTipoValor"].ToString().ToUpper().Equals("PORCENTUAL SIMPLE")))
                        {
                            dtTodosConfigGastos.ImportRow(row);
                        }
                        break;
                }
            }
            else//En la configuración sólo existe un tipo de tasa porcentual (SIMPLE ó COMPUESTO)
            {
                dtConfigGasto = dtTodosConfigGastos;
            }

            return dtConfigGasto;
        }

        /// <summary>
        /// Valida el procesamiento del plan de pagos
        /// </summary>
        /// <returns>Indicador verdadero o falso</returns>
        private bool ValidarDatosProcesoPp()
        {
            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;
            const string cTitulo = "Validación Plan de Pago";
            if (nNumsolicitud <= 0)
            {
                MessageBox.Show("Se necesita cargar los datos de una solicitud para generar su plan de pagos", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            string cModDesemb = cboModDesemb.GetItemText(cboModDesemb.SelectedItem);
            //if (dtpFecDesembolso.Value.Date != clsVarGlobal.dFecSystem.Date && !chcBancoNacion.Checked)
            if (dtpFecDesembolso.Value.Date != clsVarGlobal.dFecSystem.Date && cModDesemb != "BANCO DE LA NACION")
            {
                MessageBox.Show("La fecha de desembolso no puede ser diferente a la fecha del sistema. Verifique", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtpFecDesembolso.Value.Date < clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de desembolso no puede ser menor a la fecha del sistema. Verifique", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Validar Fecha de Primera Cuota            
            TimeSpan diferencia = conCreditoPrimeraCuota.dFecha - dtpFecDesembolso.Value.Date;
            int nMinDias = clsVarApl.dicVarGen["nMinDiasDesPriCuota"];
            if (diferencia.Days < nMinDias)
            {
                MessageBox.Show("La Fecha de la Primera Cuota debe ser como mínimo " + nMinDias + " días posteriores a la Fecha de Desembolso. Verifique", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Los Gastos que se desea aplicar sobre las cuotas sólo puedes tener las 
        ///	Posibles Combinaciones:
        ///	 
        ///	 ----------------------------------------------------------------
        ///	 |  TipoValor   |   Aplicar A           |   Cuota               |
        ///	 ----------------------------------------------------------------
        ///	 |  %COMPUESTO  |   SALDO CAPITAL       |   Obligatorio TODAS   | 
        ///	 ----------------------------------------------------------------       
        ///	 |  %SIMPLE     |   SALDO CAPITAL       |   Obligatorio TODAS   |
        ///	 |              |   MONTO PRESTAMO      |   Cualquier cuota     |
        ///	 |              |   CAPITAL + INTERÉS   |   Obligatorio TODAS   |
        ///	 |              |   CAPITAL             |   Obligatorio TODAS   | 
        ///	 ----------------------------------------------------------------
        ///	 |   FIJO       |                       |   Cualquier cuota     |
        ///	  ---------------------------------------------------------------
        /// 
        /// </summary>
        /// <returns>
        /// true: existe errores
        /// false: no existe errores
        /// </returns>
        private bool CargarValidarGastos()
        {
            //llamando a la función que calcula el plan de pagos en la capa de negocios          
            DataTable dtConfig = dtgConfigGasto.DataSource as DataTable;//Se utiliza sólo para mostrar al Usuario en Pantalla

            //DataTable con el que se trabajará los 'Gastos Seleccionados' (check) que afectarán al Plan de Pagos
            dtAuxConfigGastos = dtConfig.Clone();//copiar la estructura del DataTable
            StringBuilder sbMensajesError = new StringBuilder();//Definir cadena en la que se acumluará los errores a mostrar
            bool lSwitchError = false;//permitirá verificar si hay algún error en la combinación de Asignación de Gastos al Plan de Pagos

            #region Carga de Gastos

            for (int i = 0; i < dtConfig.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtConfig.Rows[i]["lObligatorio"].ToString()))
                //Trabajar solo con los Configuración de Gastos que tienen check
                {
                    DataRow dr = dtAuxConfigGastos.NewRow();
                    dr["lObligatorio"] = dtConfig.Rows[i]["lObligatorio"];
                    dr["nIdCuota"] = dtConfig.Rows[i]["nIdCuota"];
                    dr["nIdTipoGasto"] = dtConfig.Rows[i]["nIdTipoGasto"];
                    dr["nIdTipoValor"] = dtConfig.Rows[i]["nIdTipoValor"];
                    dr["nIdAplicaConcepto"] = dtConfig.Rows[i]["nIdAplicaConcepto"];
                    dr["cIdCuota"] = dtConfig.Rows[i]["cIdCuota"];
                    dr["cIdTipoGasto"] = dtConfig.Rows[i]["cIdTipoGasto"];
                    dr["nGasto"] = dtConfig.Rows[i]["nGasto"];
                    dr["nValor"] = dtConfig.Rows[i]["nValor"];
                    dr["cIdTipoValor"] = dtConfig.Rows[i]["cIdTipoValor"];
                    dr["cMoneda"] = dtConfig.Rows[i]["cMoneda"];
                    dr["cIdAplicaConcepto"] = dtConfig.Rows[i]["cIdAplicaConcepto"];
                    dr["nTasaEfectivaDiaria"] = dtConfig.Rows[i]["nTasaEfectivaDiaria"];

                    if (chcMantenerCuotasCtes.Checked) //Mantener cuotas constantes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] +
                                                       " - " + dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 1;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                     dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine +
                                                       dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }

                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                    if (chcMantenerCuotasCtes.Checked == false) //cuotas no constntes
                    {
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                        {
                            if (dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("MONTO PRESTAMO") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") ||
                                dtConfig.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL")
                                )
                            {
                                dr["nClasificTipoGasto"] = 2;
                                dtAuxConfigGastos.Rows.Add(dr);
                            }
                            else
                            {
                                sbMensajesError.Append(Environment.NewLine + dtConfig.Rows[i]["cIdTipoValor"] + " - " +
                                                       dtConfig.Rows[i]["cIdAplicaConcepto"]);
                                lSwitchError = true;
                            }
                        }
                        if (dtConfig.Rows[i]["cIdTipoValor"].Equals("FIJO"))
                        {
                            dr["nClasificTipoGasto"] = 2;
                            dtAuxConfigGastos.Rows.Add(dr);
                        }
                    }
                }
            }

            //Verificar si la elección de la combinación de asignación de Gastos al Plan de Pagos es correcta
            if (lSwitchError)
            {
                MessageBox.Show(string.Format("No se permite la siguiente Combinación de Asignación de Gastos:{0}", sbMensajesError), "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que los Gastos que afecten a SALDO CAPITAL sean sólo PORCENTUAL SIMPLE ó PROCENTUAL COMPUESTO (no ambos) sólo para que las CUOTAS sean CONSTANTES
            string cTipoValor = string.Empty;
            string cMensajeError = string.Empty;
            int nContador = 0;
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") && Convert.ToInt32(dtAuxConfigGastos.Rows[i]["nClasificTipoGasto"]) == 1)
                {
                    if (nContador == 0)
                    {
                        cTipoValor = dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString();
                        nContador++;
                    }
                    else
                    {
                        if (!cTipoValor.Equals(dtAuxConfigGastos.Rows[i]["cIdTipoValor"].ToString()))
                        {
                            cMensajeError = Environment.NewLine + "Para que las CUOTAS sean CONSTANTES" +
                                            Environment.NewLine + "Los gastos que afecten a SALDO CAPITAL deben ser" +
                                            Environment.NewLine +
                                            "PORCENTUAL SIMPLE ó PORCENTUAL COMPUESTO (no ambos a la vez)";
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show(sbMensajesError + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            //Verificar que se cumpla con la asignación a cuotas determinadas
            for (int i = 0; i < dtAuxConfigGastos.Rows.Count; i++)
            {
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL COMPUESTO"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
                if (dtAuxConfigGastos.Rows[i]["cIdTipoValor"].Equals("PORCENTUAL SIMPLE"))
                {
                    if (dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("SALDO CAPITAL") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CUOTA (CAPITAL + INTERÉS)") || dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"].Equals("CAPITAL"))
                    {
                        if (!dtAuxConfigGastos.Rows[i]["cIdCuota"].Equals("TODAS LAS CUOTAS"))
                        {
                            cMensajeError = string.Format("{0}{1}{2} - {3} con una Tasa {4}", cMensajeError,
                                Environment.NewLine, dtAuxConfigGastos.Rows[i]["cIdAplicaConcepto"],
                                dtAuxConfigGastos.Rows[i]["cIdCuota"], dtAuxConfigGastos.Rows[i]["cIdTipoValor"]);
                            lSwitchError = true;
                        }
                    }
                }
            }
            if (lSwitchError)
            {
                MessageBox.Show("No está permitido aplicar a:" + Environment.NewLine + cMensajeError, "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            #endregion

            return false;
        }

        private void CancelarRegistro()
        {
            btnGrabar1.Enabled = false;
            btnProcesar.Enabled = false;
            btnChecklist.Enabled = false;
            btnImprimir1.Enabled = false;
            btnHojaResumen.Enabled = false;
            btnVincularPagare.Enabled = false;
            btnVincularCuentaAhorro.Enabled = false;
            btnListaAprob.Enabled = true;
            btnImprimirContratos.Enabled = false;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;
            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conPlanPagos1.dtgCalendario.DataSource = null;
            conPlanPagos1.grbEditor.Enabled = false;
            cboTipoPersona.Text = "";
            cboMoneda.Text = "";
            txtTipoPeriodo.Text = "";
            chcBancoNacion.Checked = false;
            chcBancoNacion.Enabled = true;
            cboModDesemb.Enabled = false;

            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";
            conBusCuentaCli1.limpiarControles();

            txtOperacion.Text = "";
            txtModalidadCre.Text = "";
            txtMonAprobado.Text = "";
            nudDiasGracia.Value = 0;
            nudDiasPrimCuota.Value = 0;
            conCreditoPeriodo.limpiarControles();
            txtNumCuotaCre.Text = "";
            txtTasaInteres.Text = "0.00";
            conPlanPagos1.limpiarControlesTotales();

            dtgConfigGasto.DataSource = null;

            conPlanPagos1.dtgModificaciones.DataSource = null;
            conPlanPagos1.dtModificaciones.Clear();
            tbcCalendario.Enabled = true;
            tbcCalendario.SelectedIndex = 0;

            conBusCuentaCli1.txtNroBusqueda.Focus();
            dtpFecDesembolso.ValueChanged -= dtpFecDesembolso_ValueChanged;
            dtpFecDesembolso.Value = clsVarGlobal.dFecSystem;
            dtpFecDesembolso.MinDate = clsVarGlobal.dFecSystem;
            dtpFecDesembolso.ValueChanged += dtpFecDesembolso_ValueChanged;
            objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
            btnHabilitarSeguro.Enabled = false;
            btnDevolver.Enabled = false;
            btnVincularPagare.Enabled = false;
            objAdministracionEnvioSMS.limpiarOperacion();
            btnValidarSMS.Enabled = false;
            conPlanPagos1.grbEditor.Enabled = false;

            txtExtraPrima.Text = "0.0";
            dtgBaseIntervinientes.DataSource = null;
            btnDesembolso.Enabled = false;
            nConTbSeg = nConTbSeg == 0 ? 0 : nConTbSeg - 1;

            lDesembolso = false;
            lDevolucion = false;
            grbCondicionSol.Enabled = true;
            conAutorizacionUsuDatos1.limpiar();
            conSolicitudCargaSeguros.limpiar();

            lVisibleSegurosOptativo = true;
            label2.Visible = true;
            conSolicitudCargaSeguros.Visible = true;
        }

        private int calcularPlazo(DateTime dFechaDesemb, int nTipoPeriodo, int nNumeroCuotas, int nDiasGracia, int nDiapago_Periodo)
        {
            int Plazo = 0;
            DateTime dFecNewCuo = dFechaDesemb.AddDays(Convert.ToDouble(nDiasGracia));
            int nDiaFecAux = nDiapago_Periodo;

            if (nTipoPeriodo == 1)//Fecha Fija
            {
                for (int i = 1; i <= nNumeroCuotas; i++)
                {
                    var nNumMesCuo = 0;
                    var nNumAñoCuo = 0;
                    if (i == 1) // Si primera cuota
                    {
                        if ((dFecNewCuo.Day > nDiapago_Periodo))
                        {
                            nNumMesCuo = dFecNewCuo.Month + 1;
                        }
                        else
                        {
                            nNumMesCuo = dFecNewCuo.Month;
                        }
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    else
                    {
                        nNumMesCuo = dFecNewCuo.Month + 1;
                        nNumAñoCuo = dFecNewCuo.Year;
                        if (nNumMesCuo > 12)
                        {
                            nNumMesCuo = 1;
                            nNumAñoCuo = nNumAñoCuo + 1;
                        }
                    }
                    nDiaFecAux = nDiapago_Periodo;
                    while (true)
                    {
                        DateTime dfecVeriFec;
                        if (DateTime.TryParse(string.Format("{0}/{1}/{2}", nDiaFecAux, nNumMesCuo, nNumAñoCuo), out dfecVeriFec))
                        {
                            dFecNewCuo = dfecVeriFec;
                            break;
                        }
                        nDiaFecAux = nDiaFecAux - 1;
                    }

                }
                Plazo = Convert.ToInt32((dFecNewCuo - dFechaDesemb).Days);
            }
            else // Periodo Fijo
            {
                Plazo = Convert.ToInt32(nDiasGracia + (nNumeroCuotas * nDiapago_Periodo));
            }
            return Plazo;
        }

        private bool validarReaprobacion(int nNumSolicitud)
        {
            bool lValida = true;
            DataTable dtNuevoDatosModGPP = new clsCNReaprobSol().obtenerDatosModGPP(nNumSolicitud);

            for (int i = 0; i < dtDatosModGPP.Columns.Count; i++)
            {
                if (!Equals(dtDatosModGPP.Rows[0][i], dtNuevoDatosModGPP.Rows[0][i]))
                    return false;
            }

            DataTable dtCondPlanPag = cnReaprobSol.obtenerResumenReaprobacion(nNumSolicitud);

            if (dtCondPlanPag.Rows.Count > 0)
            {
                lValida = (Equals(dtCondPlanPag.Rows[0]["nNumCuotas"], dtNuevoDatosModGPP.Rows[0]["nCuotas"]) && lValida == true) ? true : false;
                //lValida = (Object.Equals(dtCondPlanPag.Rows[0]["dFechaDesemb"],dtNuevoDatosModGPP.Rows[0]["dFechaDesembolsoSugerido"]) && lValida == true) ? true : false;
                lValida = (Equals(dtCondPlanPag.Rows[0]["nCapPropuesto"], dtNuevoDatosModGPP.Rows[0]["nCapitalPropuesto"]) && lValida == true) ? true : false;
                //lValida = (Object.Equals(dtCondPlanPag.Rows[0]["nPlazoPeriodo"],dtNuevoDatosModGPP.Rows[0]["nPlazoCuota"]) && lValida == true) ? true : false;
                lValida = (Equals(dtCondPlanPag.Rows[0]["idTipoPeriodo"], dtNuevoDatosModGPP.Rows[0]["idTipoPeriodo"]) && lValida == true) ? true : false;
                lValida = (Equals(dtCondPlanPag.Rows[0]["dFecUltPago"], dtNuevoDatosModGPP.Rows[0]["dFechaUltimoPago"]) && lValida == true) ? true : false;
                lValida = (Equals(dtCondPlanPag.Rows[0]["nTotalDias"], dtNuevoDatosModGPP.Rows[0]["nTotalDiasCredito"]) && lValida == true) ? true : false;
            }

            return lValida;
        }

        private void CargarConfiguracionCuentaDesembolso()
        {
            clsCNBuscaSolicitud Solicitud = new clsCNBuscaSolicitud();
            DataTable dtSolicitud = new DataTable("dtSolicitud");
            DataTable dtCuentaDeposito = new DataTable("dtDeposito");

            int idModalidadDes = Convert.ToInt32(cboModDesemb.SelectedValue);
            int idCliente = conBusCuentaCli1.nIdCliente;
            int idSolicitud = conBusCuentaCli1.nValBusqueda;
            int idTipoOperacion = 22;
            int idEstadoCuenta = 1;
            bool lPeticionNuevaCuenta = false;
            bool lSeleccionCuenta = false;
            int idCuentaDepositoSeleccionado = 0;

            dtSolicitud = Solicitud.DatoSolicitud(idSolicitud);

            int idMoneda = Convert.ToInt32(dtSolicitud.Rows[0]["IdMoneda"]);
            int idCuentaDeposito = Convert.ToInt32(dtSolicitud.Rows[0]["idCuentaDeposito"]);
            bool lCuentaDepositoAutomatico = Convert.ToBoolean(dtSolicitud.Rows[0]["lCuentaDepositoAutomatico"]);

            idCliente = Convert.ToInt32(dtSolicitud.Rows[0]["idCli"]);

            dtCuentaDeposito = cnDeposito.CNRetornaDatosxCuenta(idCuentaDeposito, idEstadoCuenta, idMoneda, idTipoOperacion);
            string cNroCuenta = (dtCuentaDeposito.Rows.Count > 0) ? Convert.ToString(dtCuentaDeposito.Rows[0]["cNroCuenta"]) : String.Empty;

            if (!lCuentaDepositoAutomatico)
            {
                frmBusCtaAhoVinculacion frmBuscarCuenta = new frmBusCtaAhoVinculacion();
                frmBuscarCuenta.idCli = idCliente;
                frmBuscarCuenta.pTipBus = 2;
                frmBuscarCuenta.nTipOpe = idTipoOperacion;
                frmBuscarCuenta.idMon = idMoneda;
                frmBuscarCuenta.idestado = idEstadoCuenta;
                frmBuscarCuenta.idTipoPersona = idTipoPersona;

                frmBuscarCuenta.idCuentaVinculada = idCuentaDeposito;
                frmBuscarCuenta.lCuentaAutomatica = lCuentaDepositoAutomatico;
                frmBuscarCuenta.cNroCuentaVinculada = cNroCuenta;

                frmBuscarCuenta.ShowDialog();
                lPeticionNuevaCuenta = frmBuscarCuenta.lCuentaAutomatica;
                lSeleccionCuenta = frmBuscarCuenta.lSeleccion;
                if (!lSeleccionCuenta && !lPeticionNuevaCuenta)
                {
                    return;
                }

                if (lSeleccionCuenta)
                {
                    idCuentaDepositoSeleccionado = (String.IsNullOrEmpty(frmBuscarCuenta.pnCta)) ? 0 : Convert.ToInt32(frmBuscarCuenta.pnCta);
                }
                else if (lPeticionNuevaCuenta)
                {
                    idCuentaDepositoSeleccionado = idCuentaDeposito;
                }
                else
                {
                    idCuentaDepositoSeleccionado = 0;
                }
            }
            else
            {
                idCuentaDepositoSeleccionado = idCuentaDeposito;
            }

            // en aui se verifica que los id de cuentas sean iguales para recien cambiar el vinculo
            frmConfigurarCuentaDesembolso frmConfigCuentaDesembolso = new frmConfigurarCuentaDesembolso(idCliente, idSolicitud, dtSolicitud, dtCuentaDeposito, lPeticionNuevaCuenta, idCuentaDepositoSeleccionado, lCuentaDepositoAutomatico);
            frmConfigCuentaDesembolso.ShowDialog();
        }

        private void cargarConfiguracionSeguro()
        {
            int idSolicitud = conBusCuentaCli1.nValBusqueda;
            int nParam = 1;
            objSolicitudCreditoSeguroActual = (objSolicitudCreditoSeguroActual.idSolicitud == 0) ? objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud) : objSolicitudCreditoSeguroActual;
            objSolicitudCreditoSeguroActual.idFrmPaqueteSeguro = 2;//Plan de Pagos
            objSolicitudCreditoSeguroActual.lPlanSeguroBD = objSolicitudCreditoSeguroActual.idPaqueteSeguro > 0 ? true : false;

            //Actualizo la fecha de desembolso y primera cuota para cargas iniciales
            objSolicitudCreditoSeguroActual.dFechaDesembolso = dtpFecDesembolso.Value;
            objSolicitudCreditoSeguroActual.dFechaPrimeraCuota = conCreditoPrimeraCuota.dFecha;

            this.conSolicitudCargaSeguros.InicializaControl2(objSolicitudCreditoSeguroActual, nParam, false, Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]), Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]));
            this.conSolicitudCargaSeguros.ActualizarParametroAprobado();
        }

        private void calcularDiasPrimCuota()
        {
            TimeSpan nDiferencia = conCreditoPrimeraCuota.dFecha - this.dtpFecDesembolso.Value.Date;
            this.nudDiasPrimCuota.Value = nDiferencia.Days;
        }

        private void procesarPlanPagos()
        {
            if (!ValidarSeguros())
            {
                tbcCalendario.SelectedIndex = 1;
                return;
            }

            conPlanPagos1.dtgCalendario.DataSource = null;
            if (conPlanPagos1.dtgModificaciones.DataSource != null)
            {
                ((DataTable)conPlanPagos1.dtgModificaciones.DataSource).Clear();
            }
            int nNumsolicitud = conBusCuentaCli1.nValBusqueda;

            if (!ValidarDatosProcesoPp())
            {
                return;
            }

            DataTable dtSolOpiRecu = cnsolicitud.verificarSolReaprobacion(nNumsolicitud);
            if (dtSolOpiRecu.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud tiene pendiente la opinión de recuperaciones.", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ////--Validar si La solicitud de crédito todavía cuenta con uno o más expedientes que deben ser revisados
            //if (ValidarChecklist() == "ERROR")
            //{
            //    return;
            //}

            #region SETEO DE PARAMETROS PARA EL PLAN DE PAGOS

            decimal nMonDesemb = txtMonAprobado.nDecValor;                              // Monto Desembolsado
            decimal nTasaInteres = txtTasaInteres.nDecValor / 100.00m;                  // Tasa de Interes Efectiva
            DateTime dFecDesemb = dtpFecDesembolso.Value;                               // Fecha de Desembolso
            int nNumCuoCta = int.Parse(txtNumCuotaCre.Text);                            // Número de Cuotas del Crédito
            int nDiaGraCta = int.Parse(nudDiasGracia.Text);                             // Días de Gracia
            short nTipPerPag = short.Parse(conCreditoPeriodo.idTipoPeriodo.ToString());   // Tipo de periodo de pago (Fecha o Periodo Fijo)
            int nDiaFecPag = conCreditoPeriodo.nPeriodoDia;                                // Día o Periodo fijo de pago

            #endregion

            if (CargarValidarGastos())
            {
                return;
            }

            dtCuotasDobles = cnplanpago.retornarCuotasDobles(dtModificaciones, dFecDesemb, nNumCuoCta);

            //reiniciando el data table de gastos
            cnplanpago.iniciarDTGastos();

            //Actualizo la fecha de desembolso y primera cuota para cargas iniciales
            objSolicitudCreditoSeguroActual.dFechaDesembolso = dFecDesemb;
            objSolicitudCreditoSeguroActual.dFechaPrimeraCuota = conCreditoPrimeraCuota.dFecha;

            //Generar el plan de pagos manteniendo o no las cuotas a pagar constantes 
            if (nTipPerPag == 3)
                dtCalendarioPagos = cnplanpago.CalcularCuotasLibresEvalRural(nNumCuoCta, nMonDesemb, dFecDesemb, nNumsolicitud, nTasaInteres, conCreditoPrimeraCuota.dFecha, dtAuxConfigGastos, nCapitalMaxCobSeg, 1, null, this.chcMantenerCuotasCtes.Checked, objSolicitudCreditoSeguroActual);
            else
                dtCalendarioPagos = cnplanpago.CalculaPpgCuotasConstantes2(nMonDesemb, nTasaInteres, dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag,
                                                        nNumsolicitud, dtAuxConfigGastos, idMoneda, dtCuotasDobles, conCreditoPrimeraCuota.dFecha, 0, nCapitalMaxCobSeg, 0, chcMantenerCuotasCtes.Checked, 0, objSolicitudCreditoSeguroActual);

            //Valido si el botón Vincular cuenta de ahorros, hoja resumen o desembolso están habilitados, si es así, los deshabilito
            if (btnVincularCuentaAhorro.Enabled)
            {
                btnVincularCuentaAhorro.Enabled = false;
            }
            if (btnHojaResumen.Enabled)
            {
                btnHojaResumen.Enabled = false;
            }
            if (btnDesembolso.Enabled)
            {
                btnDesembolso.Enabled = false;
            }
            tbcCalendario.SelectedIndex = 0;
            foreach (DataRow item in dtCalendarioPagos.Rows)
            {
                item["nIdSolicitud"] = conBusCuentaCli1.nValBusqueda;
            }

            conPlanPagos1.dtCalendarioPagos = dtCalendarioPagos;
            conPlanPagos1.dtCargaGastos = dtAuxConfigGastos;
            conPlanPagos1.dtGastosPP = cnplanpago.ObtenerGastos(nNumsolicitud);
            conPlanPagos1.nTipPeriodo = nTipPerPag;
            conPlanPagos1.nNumCuotas = nNumCuoCta;
            conPlanPagos1.dFechaDesembolso = dFecDesemb;
            conPlanPagos1.nMonto = nMonDesemb;
            conPlanPagos1.nPlazo = nDiaFecPag;
            conPlanPagos1.nDiasGracia = nDiaGraCta;
            conPlanPagos1.nTasaInteres = txtTasaInteres.nDecValor;
            conPlanPagos1.idMoneda = idMoneda;
            conPlanPagos1.lCuotaCte = chcMantenerCuotasCtes.Checked;
            conPlanPagos1.dFecPriCuota = conCreditoPrimeraCuota.dFecha;
            conPlanPagos1.cnplanpago = cnplanpago;
            conPlanPagos1.IdSolicitud = nNumsolicitud;
            conPlanPagos1.cargarDatos();

            btnGrabar1.Enabled = (lDevolucion || lDesembolso) ? false : true;
            btnValidarSMS.Enabled = (clsVarGlobal.User.lVerificacionSMS && objAdministracionEnvioSMS.lTipoPlantillaActiva) ? true : false;
            grbCondicionSol.Enabled = true;
            btnDesembolso.Enabled = false;
            btnDevolver.Enabled = true;
            btnVincularPagare.Enabled = (lSuperaMontoExposicion) ? true : false;
            nConTbAct = 0;
            if ((int)nudCuotasGracia.Value > 0)
            {
                conPlanPagos1.modificarPlanPagos(true, 5, (int)nudCuotasGracia.Value, objSolicitudCreditoSeguroActual);
            }
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");


            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = conBusCuentaCli1.txtNroBusqueda.Text.Trim();
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
            drfila[1] = conBusCuentaCli1.nIdCliente.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "Monto";
            drfila[1] = txtMonAprobado.Text.ToString();
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

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nProcentaje";
            drfila[1] = clsVarApl.dicVarGen["nPorcAmpCre"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCapitalSocialYReservas";
            drfila[1] = clsVarApl.dicVarGen["nCapitalSocialYReservas"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSubProducto";
            drfila[1] = idProducto.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = idMoneda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            int nCantidadFila = conPlanPagos1.dtgCalendario.Rows.Count;
            DateTime dUltFechaPP = Convert.ToDateTime(conPlanPagos1.dtgCalendario["fecha", nCantidadFila - 1].Value.ToString());

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaFinPP";
            drfila[1] = "'" + dUltFechaPP.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotas";
            drfila[1] = txtNumCuotaCre.Text.ToString();
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTotalDias";
            drfila[1] = conPlanPagos1.txtTotDias.Text.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = conCreditoPeriodo.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = conCreditoPeriodo.nPeriodoDia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nudDiasGracia";
            drfila[1] = conCreditoPrimeraCuota.nDiasGracia.ToString();
            dtTablaParametros.Rows.Add(drfila);



            return dtTablaParametros;
        }

        private bool lValidaReglasDinamicas()
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            DataTable dtParametros = ArmarTablaParametros();


            cCumpleReglas = cnregladinamica.ValidarReglasCreditos(dtParametros, this.Name,
                                                               clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCli1.nIdCliente),
                                                               1, Convert.ToInt32(idMoneda), Convert.ToInt32(conBusCuentaCli1.idProducto),
                                                               Decimal.Parse(txtMonAprobado.Text), int.Parse(conBusCuentaCli1.txtNroBusqueda.Text), clsVarGlobal.dFecSystem,
                                                               2, 1,
                                                               clsVarGlobal.User.idUsuario, ref nNivAuto, true);

            if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {
                return true;
            }
            else
            {
                return false;

            }


        }

        private string ValidarChecklist()
        {
            string cRpta = "OK";
            string cXmlCheckList = "";
            DataTable dtResCheckList_ = new DataTable("dtLista");
            DataTable dtResCheckList = clsFiles.DtObtenerTipoGrupoArchivoCheckList(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text), false);
            dtResCheckList_.Merge(dtResCheckList);
            DataSet dsResCheckListTemp = new DataSet("dsCheckList");
            dsResCheckListTemp.Tables.Add(dtResCheckList_);
            cXmlCheckList = dsResCheckListTemp.GetXml();
            bool lLista = false;
            DataSet dsResPendientes = clsFiles.listarSolicitudesCreditoObsPendientes(cXmlCheckList, lLista);
            DataTable dtResPendientes = dsResPendientes.Tables[0];
            if (dtResPendientes.Rows.Count > 0)
            {
                MessageBox.Show("La solicitud de crédito todavía cuenta con uno o más documentos que deben ser revisados - Debe ingresar al botón de Checklist.", "Checklist de documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cRpta = "ERROR";
            }

            return cRpta;
        }

        public void FormatoGrid()
        {
            this.dtgBaseIntervinientes.ReadOnly = false;
            this.dtgBaseIntervinientes.AllowUserToAddRows = false;
            this.dtgBaseIntervinientes.RowHeadersVisible = false;
            this.dtgBaseIntervinientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn objColumn in this.dtgBaseIntervinientes.Columns)
            {
                objColumn.Visible = false;
                objColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.dtgBaseIntervinientes.Columns["cNombre"].Visible = true;
            this.dtgBaseIntervinientes.Columns["cTipoIntervencion"].Visible = true;
            this.dtgBaseIntervinientes.Columns["lParticipa"].Visible = true;

            this.dtgBaseIntervinientes.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgBaseIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Vínculo";
            this.dtgBaseIntervinientes.Columns["lParticipa"].HeaderText = "Participa?";

            dtgBaseIntervinientes.Columns["cNombre"].ReadOnly = true;
            dtgBaseIntervinientes.Columns["cTipoIntervencion"].ReadOnly = true;
            dtgBaseIntervinientes.Columns["lParticipa"].ReadOnly = true;

        }

        private void habilitarHojaResumen(int _idSolicitud)
        {
            bool lValidar = true;

            DataTable dtVinculacionPagare = objCNCargaArchivo.CNVerificarVinculacionPagare(_idSolicitud);

            bool lPagareCredito = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idPagareCredito"]) != 0) ? true : false;
            bool lArchivos = (Convert.ToInt32(dtVinculacionPagare.Rows[0]["idArchivos"]) != 0) ? true : false;

            if (lArchivos && !lPagareCredito)
            {
                lValidar = false;
            }
            else if (!lArchivos && lPagareCredito)
            {
                lValidar = false;
            }
            else if (!lArchivos && !lPagareCredito)
            {
                lValidar = false;
            }

            if (lValidar)
            {
                btnHojaResumen.Enabled = true;
            }
        }

        private Tuple<List<ReportDataSource>, List<ReportParameter>> prepararReporte()
        {
            int iModulo = 1;
            DataTable dtSolicitud = cnplanpago.CNObtenerCuentaSolicitud(Convert.ToInt32(conBusCuentaCli1.nValBusqueda));
            DataRow drSolicitud = dtSolicitud.Rows[0];
            int iSolicitud = Convert.ToInt32(drSolicitud["idCuenta"]);
            string cCadenaEncriptada = encriptarCadena(iModulo + "-" + iSolicitud + "-" + clsVarGlobal.PerfilUsu.idPerfil + "-" + clsVarGlobal.PerfilUsu.idUsuario + "(" + DateTime.Now.ToString() + ")");
            int nNumeroImprsion = 0;
            DataTable dtRegistro = clsConfiguracion.guardarRegistroImpresion(iModulo, iSolicitud, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.PerfilUsu.idUsuario, cCadenaEncriptada);
            if (dtRegistro.Rows.Count > 0)
            {
                if (dtRegistro.Rows[0]["idRegistro"].ToString() == "0")
                {
                    MessageBox.Show(dtRegistro.Rows[0]["cMensaje"].ToString(), "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                else
                {
                    nNumeroImprsion = Convert.ToInt32(dtRegistro.Rows[0]["idRegistro"]);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error, intente de nuevo.", "Impresión de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            DataTable dtVariable = clsConfiguracion.obtenerVariableConfiguracion();

            DataTable dtTmpInterv = new DataTable();

            string dFecha = "";
            if (lImpirmirConIntervinietes)
            {
                dtTmpInterv = clsConfiguracion.listarIntervinientesImprimir(iModulo, iSolicitud);
                mostrarNumeroImpresiones();
                DataTable dtFecha = clsConfiguracion.obtenerFechaCuenta(iModulo, iSolicitud);
                if (dtFecha.Rows.Count > 0)
                {
                    dFecha = "Lugar " + dtFecha.Rows[0]["cCiudad"] + " Fecha " + dtFecha.Rows[0]["nDia"] + " de " + dtFecha.Rows[0]["cMes"] + " del " + dtFecha.Rows[0]["nAnio"];
                }
            }
            else
            {
                dtTmpInterv = clsConfiguracion.retornaIntervinientesImprimirBlanco(dtVariable, idModulo);
                dFecha = "Lugar____________________Fecha____________de_______________del 202__";
            }

            DataTable dtIntervinientes = dtTmpInterv.Clone();
            DataTable dtFiadores = dtTmpInterv.Clone();

            if (iModulo == 1)
            {
                for (int i = 0; i < dtTmpInterv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtTmpInterv.Rows[i]["idTipoInterv"]) == 1)
                        dtIntervinientes.ImportRow(dtTmpInterv.Rows[i]);
                    else
                        dtFiadores.ImportRow(dtTmpInterv.Rows[i]);
                }
            }
            else
            {
                dtIntervinientes = dtTmpInterv;
            }

            dtslist.Add(new ReportDataSource("dtIntervinientes", dtIntervinientes));
            dtslist.Add(new ReportDataSource("dtFiadores", dtFiadores));
            dtslist.Add(new ReportDataSource("dtTestigosRuego", clsConfiguracion.retornaTestigosRuego()));
            dtslist.Add(new ReportDataSource("dtVariables", dtVariable));

            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idModulo", iModulo.ToString(), false));
            paramlist.Add(new ReportParameter("idSolicitud", iSolicitud.ToString(), false));
            paramlist.Add(new ReportParameter("nCodigo", cCadenaEncriptada, false));
            paramlist.Add(new ReportParameter("nNumeroImpresion", nNumeroImprsion.ToString(), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha, false));

            return Tuple.Create(dtslist, paramlist);
        }

        public static string encriptarCadena(string cCadenaEncriptar)
        {
            string result = string.Empty;
            byte[] encryted =
            System.Text.Encoding.Unicode.GetBytes(cCadenaEncriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        private void mostrarNumeroImpresiones()
        {
            int iModulo = 1;
            DataTable dtSolicitud = cnplanpago.CNObtenerCuentaSolicitud(Convert.ToInt32(conBusCuentaCli1.nValBusqueda));
            DataRow drSolicitud = dtSolicitud.Rows[0];
            int iSolicitud = Convert.ToInt32(drSolicitud["idCuenta"]);
            string nNumeroImpresiones = "0";
            DataTable dtImpresiones = clsConfiguracion.obtenerNumeroImpresiones(iModulo, iSolicitud);
            if (dtImpresiones.Rows.Count > 0)
            {
                nNumeroImpresiones = dtImpresiones.Rows[0]["nRegistros"].ToString();
            }

            //txtNumImpresiones.Text = nNumeroImpresiones;
            //pnlNumImpresiones.Visible = true;
        }

        private void MostrarCargaArchivo()
        {
            if (this.conBusCuentaCli1.nValBusqueda == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text), false);
            frmCargaArchivo.ShowDialog();
        }

        private void MostrarCheckListArchivo()
        {
            if (this.conBusCuentaCli1.txtNroBusqueda.Text != "")
            {
                frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text), false, true);
                frmCargaArchivo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Solicitud", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Enumeradores
        private enum AccionFormulario
        {
            DEFECTO = 0,
            ACEPTA_SEGURO = 1,
            RECHAZA_SEGURO = 2
        }
        #endregion  

        private void tbcCalendario_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbcCalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = sender as TabControl;
            if (Convert.ToInt32(tab.SelectedIndex) == 1 && nConTbAct == 1)
            {
                MessageBox.Show("Debe actualizar Solicitud para modificar condiciones", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tab.SelectedTab = tab.TabPages[0];
            }
            conSolicitudCargaSeguros.PintarPlanesDeSeguro();
        }

        private void cboModDesemb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cboSeleccionado = (ComboBox)sender;
            string cValorSeleccionado = cboSeleccionado.GetItemText(cboSeleccionado.SelectedItem);
            this.chcBancoNacion.CheckedChanged -= new System.EventHandler(this.chcBancoNacion_CheckedChanged);
            if (cValorSeleccionado == "BANCO DE LA NACION")
            {
                chcBancoNacion.Checked = true;
            }
            else
            {
                chcBancoNacion.Checked = false;
            }
            this.chcBancoNacion.CheckedChanged += new System.EventHandler(this.chcBancoNacion_CheckedChanged);
        }

        private void conSolicitudCargaSeguros_SeleccionarSeguro(object sender, EventArgs e)
        {
            if (this.conSolicitudCargaSeguros.RechazaListaSeguro == true)
            {
                DataTable dtActualizaEstSeguro = new clsCNCreditoCargaSeguro().CNActualizarEstadoSolicitudCreditoSeguro(idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                if (Convert.ToInt32(dtActualizaEstSeguro.Rows[0]["idRespuesta"]) == 1)
                {
                    MessageBox.Show(dtActualizaEstSeguro.Rows[0]["cRespuesta"].ToString(), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
            }

            procesarPlanPagos();
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private void validaSegurosCambiados()
        {
            List<clsSegurosNoPermitidos> lsSegurosPermitidos = new clsCNSeguros().CNListaSegurosNoPermitidos();

            foreach (var item in objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro)
            {
                if (item.idSolicitudCreditoSeguro == 0 || !item.lSeleccionado)
                    continue;

                //Valido si está dentro de la lista de segurosPermitidos
                if (lsSegurosPermitidos != null && lsSegurosPermitidos.Count > 0 && lsSegurosPermitidos.Any(x => x.idTipoSeguro == item.idTipoSeguro))
                {
                    //Traigo el promotor inicial del seguro
                    DataTable resp = objCNCreditoCargaSeguro.CNObtenerPromotorInicialSeguro(item.idSolicitud, item.idTipoSeguro);
                    int idUsuarioOriginal = resp.Rows.Count == 0 ? clsVarGlobal.PerfilUsu.idUsuario : Convert.ToInt32(resp.Rows[0]["idUsuarioOriginal"]);

                    if (idUsuarioOriginal == clsVarGlobal.PerfilUsu.idUsuario) //Adquirido por el mismo usuario
                        continue;

                    //Traer la información del seguro
                    clsSolicitudCreditoSeguro objSeguroEnBD = new clsCNCreditoCargaSeguro().CNObtenerSeguroIndividual(item.idSolicitudCreditoSeguro);

                    if (item.nPlazoCobertura == objSeguroEnBD.nPlazoCobertura) //Cambio en plan de seguro
                        continue;

                    //compara el objeto objSeguroEnBD con el objeto item
                    if (!item.Equals(objSeguroEnBD))
                    {
                        //Vaildo si la lista no se ha inicializado
                        if (objSolicitudCreditoSeguroActual.lstSegurosCambiados == null)
                            objSolicitudCreditoSeguroActual.lstSegurosCambiados = new List<clsSegurosDesmarcados>();

                        //Si no son iguales, se agrega a la lista de seguros cambiados
                        objSolicitudCreditoSeguroActual.lstSegurosCambiados.Add(new clsSegurosDesmarcados
                        {
                            idSolicitud = item.idSolicitud,
                            idTipoSeguro = item.idTipoSeguro,
                            idSolicitudCreditoSeguro = item.idSolicitudCreditoSeguro,
                            dFecha = DateTime.Now,
                            idUsuario = clsVarGlobal.User.idUsuario,
                            cSustento = string.Format("Cambio de cobertura: Antes ({0} meses: S/.{1}) - Ahora ({2} meses: S/.{3})", objSeguroEnBD.nPlazoCobertura, objSeguroEnBD.nMontoPrima, item.nPlazoCobertura, item.nMontoPrima),
                            idUsuReg = clsVarGlobal.User.idUsuario,
                            dFecReg = clsVarGlobal.dFecSystem,
                            lVigente = true
                        });
                    }
                }
            }
        }

        private StringBuilder armarCuerpoCorreo(List<clsSegurosDesmarcados> lstSegurosCambiados, List<clsSegurosDesmarcados> lstSegurosDesmarcados)
        {
            StringBuilder mensaje = new StringBuilder();

            #region Seguros Cambiados
            if (lstSegurosCambiados != null && lstSegurosCambiados.Count > 0)
            {
                int idSolicitud = lstSegurosCambiados.FirstOrDefault().idSolicitud;
                DataTable dtCliente = new clsCNCliente().MostrarNombreCompletoCliente(objSolicitudCreditoSeguroActual.idCli);

                mensaje.AppendLine("Estimado colaborador, se informa que se tiene un  <b>Cambio en la Venta</b> de los siguientes seguros.");
                mensaje.AppendLine("-          Solicitud de crédito: N° " + idSolicitud.ToString());
                mensaje.AppendLine("-          Cliente: " + dtCliente.Rows[0]["cNombre"].ToString());
                mensaje.AppendLine();

                foreach (var item in lstSegurosCambiados)
                {
                    // Busca el seguro en objsolicitudcreditocargaseguro para mostrar el nombre
                    var solicitudCreditoSeguro = objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idSolicitudCreditoSeguro == item.idSolicitudCreditoSeguro);

                    string seguro = solicitudCreditoSeguro != null ? solicitudCreditoSeguro.cTipoSeguro : null;

                    // Armo el mensaje en formato HTML
                    mensaje.AppendLine("<ul>");
                    mensaje.AppendLine("<li><b>Seguro:</b> " + seguro + "</li>");
                    mensaje.AppendLine("<li><b>Usuario que Cambia:</b> " + clsVarGlobal.User.cNomUsu + "</li>");
                    mensaje.AppendLine("<li><b>Fecha y Hora:</b> " + item.dFecha.ToString("dd/MM/yyyy") + " a las " + item.dFecha.ToString("hh:mm:ss") + "</li>");
                    mensaje.AppendLine("<li><b>Sustento:</b> " + item.cSustento + "</li>");
                    mensaje.AppendLine("</ul>");
                    mensaje.AppendLine("<br>");
                }
            }
            #endregion
            #region Seguros Desmarcados
            if (lstSegurosDesmarcados != null && lstSegurosDesmarcados.Count > 0)
            {
                int idSolicitud = lstSegurosDesmarcados.FirstOrDefault().idSolicitud;
                DataTable dtCliente = new clsCNCliente().MostrarNombreCompletoCliente(objSolicitudCreditoSeguroActual.idCli);

                mensaje.AppendLine("Estimado colaborador, se informa que se tiene la <b>Venta Desmarcada</b> de los siguientes seguros.");
                mensaje.AppendLine("-          Solicitud de crédito: N° " + idSolicitud.ToString());
                mensaje.AppendLine("-          Cliente: " + dtCliente.Rows[0]["cNombre"].ToString());
                mensaje.AppendLine();

                foreach (var item in lstSegurosDesmarcados)
                {
                    // Busca el seguro en objsolicitudcreditocargaseguro para mostrar el nombre
                    var solicitudCreditoSeguro = objSolicitudCreditoSeguroActual.lstSolicitudCreditoSeguro.FirstOrDefault(x => x.idSolicitudCreditoSeguro == item.idSolicitudCreditoSeguro);

                    string seguro = solicitudCreditoSeguro != null ? solicitudCreditoSeguro.cTipoSeguro : null;

                    // Armo el mensaje en formato HTML
                    mensaje.AppendLine("<ul>");
                    mensaje.AppendLine("<li><b>Seguro:</b> " + seguro + "</li>");
                    mensaje.AppendLine("<li><b>Usuario que Desmarca:</b> " + clsVarGlobal.User.cNomUsu + "</li>");
                    mensaje.AppendLine("<li><b>Fecha y Hora:</b> " + item.dFecha.ToString("dd/MM/yyyy") + " a las " + item.dFecha.ToString("hh:mm:ss") + "</li>");
                    mensaje.AppendLine("<li><b>Sustento:</b> " + item.cSustento + "</li>");
                    mensaje.AppendLine("</ul>");
                    mensaje.AppendLine("<br>");
                }
            }
            #endregion

            mensaje.AppendLine("<b>Por favor no responda este correo, fue enviado de manera automática.</b>");

            return mensaje;
        }

    }
}