using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using GEN.Servicio;
using CLI.Servicio;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmRefinanciacion : frmBase
    {
        #region Variable
        const decimal cero = 0.00M, nPorciento = 100.00M;
        private int idCuenta = 0, idSolicitud = 0;
        DataTable ppg;
        DataTable dtConfigGasto;
        DataTable dtRefina;
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        CRE.CapaNegocio.clsCNPlanPago cnPlanPago = new CapaNegocio.clsCNPlanPago();
        clsCNConfigGastComiSeg ConfigGastComiSeg = new clsCNConfigGastComiSeg();
        DataTable dtListPPG = new DataTable();
        clsRPTCNPlanPagos PPG = new clsRPTCNPlanPagos();
        List<ReportDataSource> dtslist = new List<ReportDataSource>();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        CRE.CapaNegocio.clsCNCredito cncredito = new CRE.CapaNegocio.clsCNCredito();
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsRPTCNPlanPagos cnRPTPlanPago = new clsRPTCNPlanPagos();

        DataTable dtPlanPagSol = new DataTable();
        DataTable dtDatosModGPP = new DataTable();
        DataTable dtDatSoli = new DataTable();

        decimal nCapitalMaxCobSeg;
        bool lAplicaSeguro;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        clsBiometrico oBiometrico = new clsBiometrico();
        #endregion

        #region Eventos

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            idSolicitud = this.conBusCuentaCli.nValBusqueda;

            cargarDatos(idSolicitud);
            gestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            idSolicitud = this.conBusCuentaCli.nValBusqueda;
            cargarDatos(idSolicitud);
            gestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            if (ValidarInicioOpe() == "A")
            {
                activarControlObjetos(this, EventoFormulario.INICIO);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Esta operacion es irreversible, ¿Desea continuar?",
                            this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (!validarHuella())
            {
                return;
            }

            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.nIdCuenta), "Inicio - Registro de Refinanciación", btnGrabar);

            ppg = cnRPTPlanPago.ADCronogramaXSolicitud(idSolicitud);

            //Ubicar la ultima fecha de pago de Crédito
            var dFechaUltimoPagoCredito = Convert.ToDateTime(ppg.Rows[ppg.Rows.Count - 1]["dFechaProg"]);
            //Calcular la TEA
            var nTEA = cnPlanPago.CalculaTEA(this.txtTasaInteres.nDecValor);
            var nTcea = (decimal)ppg.Rows[0]["nTasaCostoEfectivo"];

            int nSumaDias = 0;

            decimal nNumDias = 0;
            for (int i = 0; i < ppg.Rows.Count; i++)
            {
                nNumDias += Convert.ToDecimal(ppg.Rows[i]["nNumDiaCuota"]);
            }

            nNumDias = Math.Round(Convert.ToDecimal(nNumDias), 2);
            nSumaDias = Convert.ToInt32(nNumDias);

            var TablaInsPpg = cncredito.InsRefinanciacion(idSolicitud, clsVarGlobal.dFecSystem, nTcea, nTEA, nSumaDias, dFechaUltimoPagoCredito, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);

            if (TablaInsPpg.Rows.Count > 0 && Convert.ToInt32(TablaInsPpg.Rows[0]["nCuenta"]) != 0)
            {
                idCuenta = Convert.ToInt32(TablaInsPpg.Rows[0]["nCuenta"]);
                int idKardex = Convert.ToInt32(TablaInsPpg.Rows[0]["Kardex"]);
                MessageBox.Show("Se grabó correctamente la operación", "Registro de Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.btnGrabar.Enabled = false;

                ImpresionVoucher(nIdKardex: idKardex, idModulo: 1, idTipoOpe: 1, idEstadoKardex: 1,
                                nValRec: 0,
                                nValdev: 0,
                                idKardexAd: 0, idTipoImpresion: 1);

                if(clsVarGlobal.User.lAutBiometricaAgencia)
                {
                    oBiometrico.registrarOperacionKardexExcepcion(idKardex);
                }

                this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), idCuenta, "Fin - Registro de Refinanciación", btnGrabar);

                /*  Guardar Expedientes - Grupo Desembolso -Refi  */
                clsProcesoExp.guardarCopiaExpediente("Desembolso de Credito", idSolicitud, this);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            btnGrabar.Enabled = false;
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPeriodo.SelectedIndex >= 0)
            {
                int? idTipoPeriodo = (int?)cboTipoPeriodo.SelectedValue;
                if (idTipoPeriodo == null) return;
                if (idTipoPeriodo == 1)
                {
                    this.lblDesTipo.Text = "Día de Pago:";
                    this.nudDiaPago.Maximum = 31;
                }
                else if (idTipoPeriodo == 2)
                {
                    this.lblDesTipo.Text = "Frecuencia:";
                    this.nudDiaPago.Maximum = 1800;
                }
                else if (idTipoPeriodo == 3)
                {
                    this.lblDesTipo.Text = "Plazo en meses:";
                    this.nudDiaPago.Maximum = 48;
                }
            }
        }


        #endregion

        #region Métodos

        private void gestionContacto(string cDocumentoID)
        {
            frmGestionContacto objGC = new frmGestionContacto(cDocumentoID);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }
        private void cargarDatos(int idSolicitud)
        {
            if (idSolicitud == 0)
            {
                return;
            }
            DataTable dtReaprob = new clsCNReaprobSol().obtenerReaprobacion(idSolicitud);
            if (dtReaprob.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtReaprob.Rows[0]["idEstado"]) == 1)
                {
                    MessageBox.Show("La última instancia de aprobación del crédito refinanciado/novado debe actualizar el monto de aprobación.", "Registro Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnCancelar_Click(null, new EventArgs());
                    return;
                }
                else
                {
                    MessageBox.Show("Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edicion finalice.", "Registro Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnCancelar_Click(null, new EventArgs());
                    return;
                }
            }

            this.dtPlanPagSol = new clsCNReaprobSol().obtenerPlanPagosSol(idSolicitud);
            this.dtDatosModGPP = new clsCNReaprobSol().obtenerDatosModGPP(idSolicitud);

            if (dtPlanPagSol.Rows.Count <= 0)
            {
                MessageBox.Show("La solicitud no tiene un plan de pagos generado", "Validacion Refinanciamiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnCancelar_Click(null, new EventArgs());
                return;
            }

            dtRefina = cnsolicitud.retornaDatSolRefinanciacion(idSolicitud);

            if (dtRefina.Rows.Count <= 0)
            {
                MessageBox.Show("No se tiene solicitudes de refinanciación", "Validación solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conBusCuentaCli.LiberarCuenta();
                limpiarControles();
                return;
            }
            else
            {
                dtDatSoli = cnsolicitud.ConsultaSolicitud(idSolicitud);
                DataTable dtSol = cnsolicitud.SolicitudDesembolso(idSolicitud);

                txtMontoRefiancia.Text = dtDatSoli.Rows[0]["nCapitalAprobado"].ToString();
                dtpFechaRegistro.Value = (DateTime)dtDatSoli.Rows[0]["dFechaRegistro"];
                nudCuotas.Value = (int)dtDatSoli.Rows[0]["nCuotas"];
                nudDiasGracia.Value = (int)dtDatSoli.Rows[0]["ndiasgracia"];
                cboTipoPeriodo.SelectedValue = (int)dtDatSoli.Rows[0]["idTipoPeriodo"];

                //Evaluamos si es Cuotas Libres

                if ((int)dtDatSoli.Rows[0]["idTipoPeriodo"] != 3)
                    nudDiaPago.Value = (int)dtDatSoli.Rows[0]["nPlazoCuota"];
                else
                    nudDiaPago.Value = (int)new clsCNEvalCrediRural().ObtenerConfiguracionDiseCredRuralxSolicitud(idSolicitud).Rows[0]["nPlazoMeses"];

                txtTasaInteres.Text = dtDatSoli.Rows[0]["nTasaCompensatoria"].ToString();
                idCuenta = (int)dtRefina.Rows[0]["idCuenta"];
                cboMoneda1.SelectedValue = (int)dtDatSoli.Rows[0]["idMoneda"];
                btnGrabar.Enabled = true;
                //Validar que no exista una solicitud pendiente o aprobada
                txtMonPriCuo.Text = dtSol.Rows[0]["nMontoCuota"].ToString();
                dtpFecPriCuo.Value = Convert.ToDateTime(dtSol.Rows[0]["dFechaProg"]);
                dtpFechaSol.Value = Convert.ToDateTime(dtSol.Rows[0]["dFechaRegistro"]);

                DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(conBusCuentaCli.nIdCliente, idCuenta);
                if (SolicDuplicada.Rows.Count > 0)
                {
                    MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                    "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = true;
                    return;
                }
            }
        }

        private void limpiarControles()
        {
            idSolicitud = 0;
            idCuenta = 0;
            //entplanpago = null;
            //entcredito = null;
            txtMontoRefiancia.Text = "0.00";
            nudCuotas.Value = 1;
            nudDiaPago.Value = 1;
            nudDiasGracia.Value = 0;
            txtTasaInteres.Text = "0.00";
            conBusCuentaCli.LiberarCuenta();
            conBusCuentaCli.txtNombreCli.Text = "";
            conBusCuentaCli.txtNroBusqueda.Text = "";
            conBusCuentaCli.txtEstado.Text = "";
            conBusCuentaCli.txtCodCli.Text = "";
            conBusCuentaCli.txtNroDoc.Text = "";
        }

        private void distribuirPrePago()
        {
            int nTipoOperacion = 29, nIdMenu = 17;

            decimal nMonto = txtMontoRefiancia.nDecValor;
            decimal nTasa = txtTasaInteres.nDecValor / 100.00m;
            int nNumCuotas = (int)nudCuotas.Value;
            int nDiasGracia = (int)nudDiasGracia.Value;
            int nDiaFecPag = (int)nudDiaPago.Value;
            int idMoneda = (int)cboMoneda1.SelectedValue;
            short nTipPerPag = Convert.ToInt16(cboTipoPeriodo.SelectedValue);
            DateTime dFecProceso = dtpFechaRegistro.Value.Date;
            DateTime dFecPrimeracuota = dFecProceso;//clsVarGlobal.dFecSystem.AddDays(nDiasGracia);
            if ((int)cboTipoPeriodo.SelectedValue == 1)
            {
                int nDiaFecAux = (int)nudDiaPago.Value;
                DateTime dFecResult;

                DateTime dFechaProxMes = dFecProceso.AddMonths(1);
                while (true) // La Fecha de la nueva cuota debe ser una fecha válida
                {
                    if (DateTime.TryParse(String.Format("{0}/{1}/{2}", nDiaFecAux, dFechaProxMes.Month, dFechaProxMes.Year), out dFecResult))
                    {
                        break;
                    }
                    nDiaFecAux = nDiaFecAux - 1; // si no es una fecha válida se retrocede hasta encontrar la primera fecha (ejem 31 de c/mes)
                }
                dFecPrimeracuota = dFecResult.Date.AddDays(nDiasGracia);
            }
            else
            {
                dFecPrimeracuota = dFecProceso.AddDays((int)nudDiaPago.Value + (int)nudDiasGracia.Value);
            }

            //================================================================================
            // Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos
            //================================================================================
            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            dtConfigGasto = objSegDes.validarAplicaSeguroDesgravamen(idSolicitud, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal);
            nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            lAplicaSeguro = objSegDes.obternerNAplicaSeguro();
            //================================================================================
            // Fin Determina si aplica el seguro o no, y si no aplica elimina de  la configuracion de gastos
            //================================================================================

            //dtConfigGasto = ConfigGastComiSeg.ValidarSolicitudConfigGastComiSeg(idSolicitud, nTipoOperacion, nIdMenu,clsVarGlobal.idCanal);

            //DataTable dtCuotasDobles = new DataTable();
            //ppg = cnPlanPago.CalculaPpgCuotasConstantes(nMonto, nTasa, dFecProceso, nNumCuotas, nDiasGracia,
            //                                            nTipPerPag, nDiaFecPag, idSolicitud, dtConfigGasto, idMoneda, dtCuotasDobles, dFecPrimeracuota, 0, nCapitalMaxCobSeg);
            //this.dtgPlanPago.DataSource = ppg;

            //formatoGridPlanPago();
        }

        //private void formatoGridPlanPago()
        //{
        //    this.dtgPlanPago.Columns["dias_acu"].Visible = false;
        //    this.dtgPlanPago.Columns["nIdSolicitud"].Visible = false;
        //    this.dtgPlanPago.Columns["frc"].Visible = false;

        //    this.dtgPlanPago.Columns["cuota"].HeaderText = "N° Cuota";
        //    this.dtgPlanPago.Columns["cuota"].Width = 50;
        //    this.dtgPlanPago.Columns["cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

        //    this.dtgPlanPago.Columns["fecha"].HeaderText = "Fecha Pago";

        //    this.dtgPlanPago.Columns["dias"].HeaderText = "Frecuencia Pago";
        //    this.dtgPlanPago.Columns["dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

        //    this.dtgPlanPago.Columns["capital"].HeaderText = "Capital";
        //    this.dtgPlanPago.Columns["capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["capital"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["interes"].HeaderText = "Interés";
        //    this.dtgPlanPago.Columns["interes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["interes"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["comisiones"].HeaderText = "Comisiones";
        //    this.dtgPlanPago.Columns["comisiones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["comisiones"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["imp_cuota"].HeaderText = "Cuota";
        //    this.dtgPlanPago.Columns["imp_cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["imp_cuota"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["sal_cap"].HeaderText = "Sal. Cap.";
        //    this.dtgPlanPago.Columns["sal_cap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["sal_cap"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["itf"].HeaderText = "Itf";
        //    this.dtgPlanPago.Columns["itf"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
        //    this.dtgPlanPago.Columns["itf"].DefaultCellStyle.Format = ("#,0.00");

        //    this.dtgPlanPago.Columns["comisiones_sinSeg"].Visible = false;
        //}

        private bool validarRefinanciamiento()
        {

            int idSol = Convert.ToInt32(this.idSolicitud);
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

            DataTable dtCredRefinan = new clsCNSolicitud().CNRetCuentasAmpliadas(idSol);
            if (dtCredRefinan.AsEnumerable().Any())
            {
                if (dtCredRefinan.AsEnumerable().Any(x => x.Field<decimal>("nSalIntComp") < 0))
                {
                    MessageBox.Show("No se pueden refinanciar cuentas con intereses pagados por adelantado.", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return lValida;
        }

        private bool validar()
        {
            if (cnsolicitud.obtenerValorActualSoliRefi(idSolicitud) != Convert.ToDecimal(txtMontoRefiancia.Text))
            {
                MessageBox.Show("El saldo total de los créditos no coincide con el monto a refinanciar", "Registro de Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            /*clsDBResp objDbResp = cnsolicitud.ValidarGravamenSolCred(idSolicitud, Convert.ToDecimal(txtMontoRefiancia.Text));
            if (objDbResp.nMsje != 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/

            if (!validarRefinanciamiento())
            {
                MessageBox.Show("El plan de pagos esta desactualizado, para continuar se requiere que genere otro.", "Registro Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DataTable dtReaprob = new clsCNReaprobSol().obtenerReaprobacion(idSolicitud);
            if (dtReaprob.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtReaprob.Rows[0]["idEstado"]) == 1)
                {
                    MessageBox.Show("La última instancia de aprobación del crédito refinanciado/novado debe actualizar el monto de aprobación.", "Registro Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    MessageBox.Show("Las condiciones de la solicitud estan siendo modificadas, Intente nuevamente cuando la edicion finalice.", "Registro Refinanciación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            }

            string cCumpleReglas = "";
            int nNivAuto = 0;
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                    clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCli.nIdCliente),
                                                    1, Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToInt32(dtDatSoli.Rows[0]["idProducto"]),
                                                    Decimal.Parse(txtMontoRefiancia.Text), idSolicitud, Convert.ToDateTime(dtDatSoli.Rows[0]["dFechaRegistro"]),
                                                    2, 2, clsVarGlobal.User.idUsuario, ref nNivAuto);

            if (cCumpleReglas.Equals("NoCumple"))
            {
                return false;
            }

            if (!ValidarSolicitudPendientePaquete())
            {
                return false;
            }
            return true;
        }

        public bool validarHuella()
        {
            #region Huellas
            if (clsVarGlobal.User.lAutBiometricaAgencia)
            {
                DataTable dtIntervinientes = cnsolicitud.CNObtenerIntervinienteSolicitudBiometrico(idSolicitud);
                int idProducto = Convert.ToInt32(dtDatSoli.Rows[0]["idProducto"]);
                int idOperacion = Convert.ToInt32(dtDatSoli.Rows[0]["idOperacion"]);
                int idTipoOperacionExcepcion = (idOperacion == 2) ? Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoRefinanciacion"]) : Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoNovacion"]);

                var listFirmantes = dtIntervinientes.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                        .OrderBy(x => Convert.ToInt32(x["idCli"]));

                if (!oBiometrico.validacionBiometrica(
                        listFirmantes
                        , Convert.ToInt32(cboMoneda1.SelectedValue)
                        , idProducto
                        , Convert.ToDecimal(this.txtMontoRefiancia.Text.ToString())
                        , idTipoOperacionExcepcion))
                {
                    MessageBox.Show("La operación no se ejecutó debido a que no se pasó el control biométrico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarControles();
                    conBusCuentaCli.btnBusCliente1.Enabled = true;
                    conBusCuentaCli.txtNroBusqueda.Enabled = true;
                    btnGrabar.Enabled = false;
                    return false;
                }
            }
            return true;
            #endregion
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitud";
            drfila[1] = idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolicitudCredGrupoSol";
            drfila[1] = Convert.ToInt32(dtDatSoli.Rows[0]["idSolicitudCredGrupoSol"]);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        #endregion

        public frmRefinanciacion()
        {
            InitializeComponent();
            this.conBusCuentaCli.cTipoBusqueda = "S";
            this.conBusCuentaCli.cEstado = "[2]";
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private bool ValidarSolicitudPendientePaquete()
        {
            //Validamos que no existan solicitudes de aprobación en estado pendientes para paquetes de seguro
            DataTable verificacion = new clsCNPaqueteSeguro().CNVerificarExistenciaSolicitudReactivacionSeguroOpcional(idSolicitud);

            if (verificacion.Rows.Count > 0)
            {
                int x_idEstadoSolicitud = Convert.ToInt32(verificacion.Rows[0]["idEstadoSol"]);
                int x_numeroSolicitud = Convert.ToInt32(verificacion.Rows[0]["idSolAproba"]);

                if (x_idEstadoSolicitud == 1) //SOLICITADO
                {
                    string x_mensaje = string.Format(clsVarApl.dicVarGen["cMensajeEstadoSolicitud"], x_numeroSolicitud);
                    MessageBox.Show(x_mensaje, "Planes de Seguros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar.Enabled = false;
                    return false;
                }
            }

            var x_solicitud = new clsCNSolicitud().SolicitudDesembolso(idSolicitud);

            if (x_solicitud.Rows.Count > 0)
            {
                bool solicitudRechazada = Convert.ToBoolean(x_solicitud.Rows[0]["SolPlanRechazada"]);

                if (solicitudRechazada)
                {
                    MessageBox.Show("La solicitud ha cambiado de estado, por favor dirigirse al formulario de plan de pagos para generar el cronograma actualizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGrabar.Enabled = false;
                    return false;
                }
            }
            return true;
        }

    }
}
