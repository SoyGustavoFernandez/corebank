using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Servicio;
using GEN.BotonesBase;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmPrePago : frmBase
    {

        #region Variables

        private clsCNPlanPago _objplanpago = new clsCNPlanPago();
        private clsCNPlanPago _cnplanpago = new clsCNPlanPago();
        private clsCredito objCredito;
        private clsPlanPago _planpago;
        private clsPlanPago _planpagoPagados;

        decimal nCapitalKar, nInteresKar, nOtrosKar;

        private DataTable dtModificaciones;
        private DataTable _dtConfigGastos;
        private decimal nITFNormal;

        private decimal nCapitalMaxCobSeg;
        private bool lAplicaSeguro;

        public const int IdTipoOperacion = 2;
        private const int IdMotivoOperacion = 16;
        private int idSolicitudHojaTramite;
        bool lValidar = false;

        private DataTable dtGastosPlanPagos;
        private DataTable dtDetGastosPagados;
        private decimal nMontoCuotaNuevo;

        private const int idTipoOpeRegimenReforzado = 170;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();

        private DataTable dtRegSolHojaTramite;

        //REQ 400
        private clsCNCreditoCargaSeguro objCNCreditoCargaSeguro = new clsCNCreditoCargaSeguro();
        private clsSolicitudCreditoCargaSeguro objSolicitudCreditoSeguroActual = new clsSolicitudCreditoCargaSeguro();
        #endregion

        #region Constructores

        public frmPrePago()
        {
            InitializeComponent();
            this.conBusCuentaCli.cTipoBusqueda = "C";
            conBusCuentaCli.cEstado = "[5]";
        }

        public frmPrePago(int nNumCuenta)
        {
            InitializeComponent();
            conBusCuentaCli.txtNroBusqueda.Text = nNumCuenta.ToString();
            lValidar = true;
        }

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            if (ValidarInicioOpe() != "A")
            {
                Dispose();
                return;
            }

            activarControlObjetos(this, EventoFormulario.INICIO);

            rbtnCuota.Checked = true;
            rbtnTiempo.Checked = false;
            conBusCuentaCli.cTipoBusqueda = "C";
            conBusCuentaCli.cEstado = "[5]";
            conDatPerReaOperac.Enabled = false;
            conDatPerReaOperac.lMostrarMsjeJuridico = false;
            dtpFecProxPago.Value = clsVarGlobal.dFecSystem;
            conSolesDolar.iMagenMoneda(1);
            if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text))
            {
                conBusCuentaCli.asignarCuenta(Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
                CargarDatos();
                if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
                {
                    conDatPerReaOperac.Enabled = true;
                    conDatPerReaOperac.Focus();
                    conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
                    if (lValidar)
                    {
                        ActivarTitular();
                    }
                }
            }
            cboMotivoOperacion.ListarMotivoOperacion(IdTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedValue = IdMotivoOperacion;

            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgPlanPagos.CellFormatting += dtgPlanPagos_CellFormatting;
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargarDatosCuenta();
            ActivarTitular();

        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            CargarDatosCuenta();
            ActivarTitular();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {

            activarControlObjetos(this, EventoFormulario.INICIO);

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text))
            {
                MessageBox.Show("Seleccione un número de cuenta", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCuentaCli.txtNombreCli.Text))
            {
                MessageBox.Show("No existen datos de Cliente. Verifique", "Validación ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Limpiar();

            if (!Validarmonto())
                return;

            DistribuirPrePago();

            txtMonTotal.Text = string.Format("{0:#,0.00}", CalcularTotal());

            if (conCalcVuelto.nMontoTotalpago != txtMonTotal.nDecValor)
            {
                conCalcVuelto.limpiar();
            }

            conCalcVuelto.nMontoTotalpago = txtMonTotal.nDecValor;
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Text = string.Format("{0:0.00}", txtMonTotal.nDecValor);
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();
            conCalcVuelto.Enabled = true;

            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgPlanPago.CellFormatting += dtgPlanPago_CellFormatting;
        }

        private void dtgPlanPago_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            List<string> nombresColumnas = new List<string>();
            foreach (DataGridViewColumn columna in dtgPlanPago.Columns)
            {
                nombresColumnas.Add(columna.Name);
            }
            if (e.ColumnIndex == dtgPlanPago.Columns["nOtrosDataGridViewTextBoxColumn"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = Convert.ToInt32(conDatCredito.cboProducto1.SelectedValue);//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);
            x_idCliente = Convert.ToInt32(conBusCuentaCli.nIdCliente);// clsVarGlobal.User.idCli;
            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas2 = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas2 = ValidaReglasDinamicas2.ValidarReglas(ArmarTablaParametros(), //dtTablaParametros
                                                                    this.Name,            //cNombreFormulario
                                                                    clsVarGlobal.nIdAgencia,//idAgencia
                                                                    x_idCliente,            //idCliente
                                                                    1,                      //idEstadoOperac
                                                                    Convert.ToInt32(nMoneda),//idMoneda
                                                                    idProd,                 //idProducto
                                                                    Decimal.Parse(nMonto),  //nValAproba
                                                                    Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text),                      //idDocument
                                                                    clsVarGlobal.dFecSystem,//FechaSolici
                                                                    2,                      //idMotivo
                                                                    1,                      //idEstadoSOl
                                                                    clsVarGlobal.User.idUsuario,//idUsuRegist
                                                                    ref nNivAuto);          //idSolAprob
            if (cCumpleReglas2.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }

        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCuenta";
            drfila[1] = conBusCuentaCli.txtNroBusqueda.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.conBusCuentaCli.nIdCliente;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(txtMonTotal.nDecValor);
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void RegHojaTramite(int idSolicitudHojaTramite_, int idKardex_)
        {
            int idCliente = Convert.ToInt32(conBusCuentaCli.nIdCliente);
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idTipoOperacion = 1;
            int idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            int idCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
            int idCliPagador = Convert.ToInt32(conDatPerReaOperac.idCli);
            bool lCartaPoder = chbCartaPoder.Checked;
            int idTipoOpePrePago = 0;
            if (rbtnCuota.Checked == true)
            {
                idTipoOpePrePago = 1;
            }
            if (rbtnTiempo.Checked == true)
            {
                idTipoOpePrePago = 2;
            }
            int idTipoPagador = 0;
            if (rblTitular.Checked == true)
            {
                idTipoPagador = 1;
            }
            if (rblConyugue.Checked == true)
            {
                idTipoPagador = 2;
            }
            if (rblOtros.Checked == true)
            {
                idTipoPagador = 3;
            }

            GuardarSolicitudHojaTramite(idSolicitudHojaTramite_, idUsuario, idTipoOperacion, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, idKardex_);

        }

        private void GenSolHojaTramite_Click(object sender, EventArgs e)
        {
            if (VerificarTipoPagador() == true)
            {
                RegHojaTramite(0, 0);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
             * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
             ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(this.conDatPerReaOperac.idCli, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, IdTipoOperacion, Convert.ToInt32(conBusCuentaCli.nIdCliente));
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            /*========================================================================================
                      Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(txtMonTotal.nDecValor), Convert.ToString(conDatCredito.cboMoneda1.SelectedValue)))
            {
                // MessageBox.Show("Error, Businnes Rules aren´t aprobated");
                return;
            }
            /*========================================================================================
            * FIN -  Validar Regla Eob con autorizacion
            ========================================================================================*/

            #region Validar controles

            if (!Validar())
                return;

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusCuentaCli.nIdCliente,
                                                                               (int)conDatCredito.cboMoneda1.SelectedValue,
                                                                               (int)conDatCredito.cboProducto1.SelectedValue,
                                                                               conBusCuentaCli.nValBusqueda,
                                                                               txtMonTotal.nDecValor);
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            DialogResult resMsg = MessageBox.Show("Este es un proceso irreversible, desea confirmar la operación",
                                                  "Confirmación de operación", MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (resMsg != DialogResult.Yes)
                return;

            #endregion

            btnGrabar.Enabled = false;

            DateTime dFechaOpe = clsVarGlobal.dFecSystem;
            int idCanal = clsVarGlobal.idCanal;
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idAgeOpera = clsVarGlobal.nIdAgencia;
            int idMotivoOperacion = Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            int idCuenta = conBusCuentaCli.nValBusqueda;

            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), idCuenta, "Inicio - Prepago de Crédito",
                             btnGrabar);

            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,
                                  Convert.ToInt16(conDatCredito.cboMoneda1.SelectedValue), 1, txtMonTotal.nDecValor))
            {
                btnGrabar.Enabled = true;
                return;
            }

            decimal nMonRedondeo = txtRedondeo.nDecValor;

            //Guardar los Datos de la persona que está pagando la cuota
            DataSet dsPagador = new DataSet("dsPagador");

            DataTable dtPagador = new DataTable("dtPagador");
            dtPagador.Columns.Add("cNroDNI", typeof(string));
            dtPagador.Columns.Add("cNomCliente", typeof(string));
            dtPagador.Columns.Add("cDireccion", typeof(string));
            dtPagador.Rows.Add(conDatPerReaOperac.txtDocIdePerson.Text.Trim(),
                               conDatPerReaOperac.txtNombrePerson.Text.Trim(),
                               conDatPerReaOperac.txtDireccPerson.Text.Trim());

            DataTable dtDatCred = new DataTable("dtCreditos");
            dtDatCred.Columns.Add("idCuenta", typeof(int));
            dtDatCred.Columns.Add("lAplicaSeguro", typeof(bool));
            dtDatCred.Columns.Add("nCapitalMaxCobSeg", typeof(decimal));
            dtDatCred.Columns.Add("nMontoCuota", typeof(decimal));
            dtDatCred.Rows.Add(idCuenta, lAplicaSeguro, nCapitalMaxCobSeg, nMontoCuotaNuevo);

            DataTable dtPagoPrePago = new DataTable("dtPagoPrepago");
            dtPagoPrePago.Columns.Add("nMontoCapital", typeof(decimal));
            dtPagoPrePago.Columns.Add("nMontoInteres", typeof(decimal));
            dtPagoPrePago.Columns.Add("nMontoOtros", typeof(decimal));
            dtPagoPrePago.Rows.Add(nCapitalKar, nInteresKar, nOtrosKar);

            dtGastosPlanPagos.TableName = "TablaDetalleCargaGasto";
            dtDetGastosPagados.TableName = "TablaGastosPagados";

            dsPagador.Tables.Add(dtPagador);
            dsPagador.Tables.Add(dtDatCred);
            dsPagador.Tables.Add(dtGastosPlanPagos);
            dsPagador.Tables.Add(dtDetGastosPagados);
            dsPagador.Tables.Add(dtPagoPrePago);

            string xmlPagador = dsPagador.GetXml();
            xmlPagador = clsCNFormatoXML.EncodingXML(xmlPagador);
            dsPagador.Tables.Clear();

            #region Validacion Umbrales Dolares
            decimal nMontoTotPago = txtMonTotal.nDecValor;
            int idMonedaUm = (int)conDatCredito.cboMoneda1.SelectedValue;
            int idMotivoOpe = idMotivoOperacion;
            int idSubProducto = (int)conDatCredito.cboProducto1.SelectedValue;
            int idTipoPago = 1;

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, 2, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion

            bool lModificaSaldoLinea = true;
            int idTipoTransac = 1; //INGRESO
            int IdMoneda_Saldo = Convert.ToInt16(conDatCredito.cboMoneda1.SelectedValue);
            decimal nMontoOpe = txtMonTotal.nDecValor;

            clsDBResp objDbResp = _objplanpago.RegistrarPrepago(idCuenta, _planpagoPagados, xmlPagador, dFechaOpe,
                                                                idCanal, idUsuario, idAgeOpera, idMotivoOperacion,
                                                                nITFNormal, txtItf.nDecValor, nMonRedondeo,
                                                                lModificaSaldoLinea, idTipoTransac, IdMoneda_Saldo, nMontoOpe);
            if (objDbResp.nMsje == 0)
            {
                int idKardex = objDbResp.idGenerado;

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                conBusCuentaCli.LiberarCuenta();
                MessageBox.Show(
                                string.Format(
                                              "Registro de Prepago satisfactorio con kardex N°: {0}.\nA continuación puede imprimir el nuevo cronograma después de la emisión del voucher",
                                              idKardex), "Prepago de Crédito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                //---------------------------------------------------------------------------------------
                //Completar el Registro de Hoja Tramite 
                //---------------------------------------------------------------------------------------
                RegHojaTramite(idSolicitudHojaTramite, idKardex);





                //---------------------------------------------------------------------------------------
                //Emision de Voucher
                //---------------------------------------------------------------------------------------
                ImpresionVoucher(nIdKardex: idKardex, idModulo: 1, idTipoOpe: IdTipoOperacion, idEstadoKardex: 1,
                                 nValRec: conCalcVuelto.txtMonEfectivo.nDecValor,
                                 nValdev: conCalcVuelto.txtMonDiferencia.nDecValor,
                                 idKardexAd: 0, idTipoImpresion: 1);

                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                btnProcesar.Enabled = false;
                btnGenerarSolicitud.Enabled = false;
                btnImprimir.Enabled = true;
                cboMotivoOperacion.Enabled = false;
                conDatPerReaOperac.Enabled = false;
            }

            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), idCuenta, "Fin - Prepago de Crédito",
                             btnGrabar);

            /*  Guardar Expedientes - Pre Pago Credito */
            clsProcesoExp.guardarCopiaExpediente("Pre Pago Credito", Convert.ToInt32(this.conDatCredito.txtCodSolicitud.Text), this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            const string reportpath = "RptCalendarioCredito.rdlc";
            int nNumCredito = Convert.ToInt32(conBusCuentaCli.nValBusqueda);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("idCliente", this.conBusCuentaCli.nIdCliente.ToString(), false));
            paramlist.Add(new ReportParameter("nNumCredito", nNumCredito.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "CRUTALOGO", false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));

            dtslist.Add(new ReportDataSource("dtsPPG", new clsRPTCNPlanPagos().CNCronogramaCreditoGastosNoConfirmados(nNumCredito)));
            dtslist.Add(new ReportDataSource("dtsCuenta", new clsRPTCNCredito().CNDatosCuenta(nNumCredito)));
            dtslist.Add(new ReportDataSource("dtsCliente", new clsRPTCNCliente().CNDireccion(nNumCredito)));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            btnGrabar.Enabled = false;
            txtMonPrePago.Clear();
            txtMonTotal.Clear();
            Limpiar();
            conCalcVuelto.Enabled = false;
            cboMotivoOperacion.SelectedIndex = -1;
            dtgPlanPagos.DataSource = "";
            rbtnCuota.Enabled = true;
            rbtnTiempo.Enabled = true;
            dtpFecProxPago.Enabled = true;
            dtpFecProxPago.Value = clsVarGlobal.dFecSystem.Date;
            rblTitular.Checked = false;
            rblTitular.Enabled = false;
            rblConyugue.Checked = false;
            rblConyugue.Enabled = false;
            rblOtros.Checked = false;
            rblOtros.Enabled = false;
            chbCartaPoder.Checked = false;
            chbCartaPoder.Enabled = false;

            //Datos del Pagador
            conDatPerReaOperac.txtDocIdePerson.Text = string.Empty;
            conDatPerReaOperac.txtDireccPerson.Text = string.Empty;
            conDatPerReaOperac.txtNombrePerson.Text = string.Empty;

            conDatPerReaOperac.Enabled = false;

            conDatosReprogramacion.limpiarDatos();

        }

        private void frmPrePago_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void rbtnCuota_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void rbtnTiempo_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtMonPrePago_TextChanged(object sender, EventArgs e)
        {
            dtgPlanPago.DataSource = null;
            btnGrabar.Enabled = false;
            btnGenerarSolicitud.Enabled = false;
            txtItf.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtTotCapital.Text = "0.00";
            txtTotCuota.Text = "0";
            txtTotIntComp.Text = "0.00";
            txtTotInteres.Text = "0.00";
            txtTotMora.Text = "0.00";
            txtTotOtros.Text = "0.00";
            conCalcVuelto.limpiar();
        }

        private void conBusCuentaCli_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCuentaCli.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCuentaCli.txtNroDoc.Text);
            }
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        #endregion

        #region Metodos

        private void CargarDatosCuenta()
        {
            CargarDatos();

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
                return;

            conDatPerReaOperac.Enabled = true;
            conDatPerReaOperac.Focus();
            conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
        }

        private void dtgPlanPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dtgPlanPagos.Columns["nOtros"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el número de DOCUMENTO DE IDENTIDAD", "Cobro de Crédito", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el NOMBRE", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtNombrePerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la DIRECCIÓN", "Cobro de Crédito", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                conDatPerReaOperac.txtDireccPerson.Focus();
                return false;
            }

            if (cboMotivoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el motivo de operación por favor", "Validar Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text.Trim()))
            {
                MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
                return false;
            }
            if (conCalcVuelto.txtMonEfectivo.nDecValor < txtMonTotal.nDecValor)
            {
                MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción", "Validar Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
                return false;
            }
            return true;
        }

        private void LiberarCuenta()
        {
            conBusCuentaCli.txtNroBusqueda.Text = string.Empty;
            conBusCuentaCli.txtNombreCli.Text = string.Empty;
            conBusCuentaCli.txtEstado.Text = string.Empty;
            conBusCuentaCli.txtCodAge.Text = string.Empty;
            conBusCuentaCli.txtCodCli.Text = string.Empty;
            conBusCuentaCli.txtCodIns.Text = string.Empty;
            conBusCuentaCli.txtCodMod.Text = string.Empty;
            conBusCuentaCli.txtCodMon.Text = string.Empty;
            conBusCuentaCli.txtNroDoc.Text = string.Empty;

            conBusCuentaCli.LiberarCuenta();
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
            conBusCuentaCli.nValBusqueda = 0;

            dtgPlanPago.DataSource = null;
            conDatCredito.limpiarcontroles();

            txtItf.Text = "0.00";
            txtMonTotal.Text = "0.00";
            txtRedondeo.Text = "0.00";
        }

        private void CargarDatos()
        {
            if (conBusCuentaCli.nValBusqueda == 0)
            {
                conSolesDolar.Visible = false;
                return;
            }

            //Valida Impresión de calendario por cambio de tea - ley 31143
            DataTable dtValidacion = new CRE.CapaNegocio.clsCNCredito().CNValidaImpresionPendienteCalendario(Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
            if (dtValidacion.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidacion.Rows[0]["nRespuesta"]) == 1)
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cRespuesta"].ToString(), "Impresión de Cronograma de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //Validar que no exista una solicitud pendiente o aprobada
            DataTable solicDuplicada = new clsCNCondonacion().DatosSolicCond(conBusCuentaCli.nIdCliente, Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
            if (solicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show(string.Format("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   {0}\n \tAgencia:   {1}\n \tFecha:   {2}",
                                              solicDuplicada.Rows[0]["cNombre"], solicDuplicada.Rows[0]["cNombreAge"],
                                              Convert.ToDateTime(solicDuplicada.Rows[0]["dFecSolici"])
                                                     .ToShortDateString()), "Solicitud de Condonación",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                btnProcesar.Enabled = false;
                btnGenerarSolicitud.Enabled = false;
                return;
            }
            cboMotivoOperacion.SelectedValue = IdMotivoOperacion;

            int idCuenta = conBusCuentaCli.nValBusqueda;
            objCredito = new CRE.CapaNegocio.clsCNCredito().retornaDatosCredito(idCuenta);
            _planpago = _objplanpago.retonarPlanPagoTotal(idCuenta);
            btnProcesar.Enabled = false;
            btnGenerarSolicitud.Enabled = false;

            if (!ValidarCuentaParaPrepago())
                return;

            #region Congiguración de seguros

            //Definir el tipo de Operación  (GENERACION DE CALENDARIO), Menu(Formulario frmPlanPagos), y el canal VENTANILLA
            const int nTipoOperacion = 29;
            const int nIdMenu = 17;

            ClsSeguroDesgravamen objSegDes = new ClsSeguroDesgravamen();
            objSegDes.validarAplicaSeguroDesgravamen(0, nTipoOperacion, nIdMenu, clsVarGlobal.idCanal, 0, idCuenta);
            nCapitalMaxCobSeg = objSegDes.obtenerNCapitalAGarantizar();
            lAplicaSeguro = objSegDes.obternerNAplicaSeguro();

            _dtConfigGastos = new clsCNConfigGastComiSeg().CNGetConfigGastosCuenta(idCuenta);

            #endregion

            conDatCredito.cargardatoscredito(conBusCuentaCli.nValBusqueda);

            lblTextMoneda.Text = ((int)conDatCredito.cboMoneda1.SelectedValue) == 1 ? "S/." : "$";
            conSolesDolar.iMagenMoneda((int)conDatCredito.cboMoneda1.SelectedValue);
            conSolesDolar.Visible = true;

            txtMonTotal.BackColor = (int)conDatCredito.cboMoneda1.SelectedValue == 1 ? Color.LightGoldenrodYellow : Color.LightGreen;

            lblTextMoneda.Visible = true;
            cboMotivoOperacion.Enabled = false;

            DataTable listPlanPago = new clsCNPlanPago().CNdtPlanPagPosi(conBusCuentaCli.nValBusqueda);
            dtgPlanPagos.DataSource = listPlanPago;
            FormatoPlanPagos();

            dtModificaciones = _objplanpago.CNListarModificacionesSolicitud(conBusCuentaCli.nValBusqueda);

            int nNumCuoGraciaRest = _planpago.Count(x => x.idEstadocuota == 1 && x.nCapital == 0);
            clsCuota cuotaPrePago = _planpago.Where(x => clsVarGlobal.dFecSystem.Date <= x.dFechaProg)
                                                .OrderBy(x => x.idCuota).First();
            clsCuota objProximaCuota = _planpago.FirstOrDefault(x => x.idCuota == cuotaPrePago.idCuota + 1);
            DateTime dFechaPrimeracuota = clsVarGlobal.dFecSystem;

            rbtnCuota.Enabled = true;
            rbtnTiempo.Enabled = nNumCuoGraciaRest == 0;
            rbtnCuota.Checked = true;

            if (objProximaCuota != null)
            {
                dFechaPrimeracuota = objProximaCuota.dFechaProg;
            }

            if (objCredito.lUnicuota)
            {
                if (objCredito.nCuotas == 1)
                {
                    dFechaPrimeracuota = cuotaPrePago.dFechaProg;
                }
                else
                {
                    if (cuotaPrePago.dFechaProg == clsVarGlobal.dFecSystem.Date)
                    {
                        dFechaPrimeracuota = objProximaCuota.dFechaProg;
                    }
                    else
                    {
                        dFechaPrimeracuota = cuotaPrePago.dFechaProg;
                    }
                }
                rbtnCuota.Enabled = false;
                rbtnTiempo.Enabled = false;
                dtpFecProxPago.Enabled = false;
            }

            dtpFecProxPago.Value = dFechaPrimeracuota.Date;

            conDatosReprogramacion.cargarComponentes(idCuenta, true, true);

            int idSolicitud = Convert.ToInt32(conDatCredito.txtCodSolicitud.Text);
            DataTable datsolicitud = new clsCNSolicitud().ConsultaSolicitud(idSolicitud);
            short idTipoPeriodo = Convert.ToInt16(datsolicitud.Rows[0]["idTipoPeriodo"]);

            if(idTipoPeriodo == 3)
            {
                clsCuota objProximaCuotaLibre = _planpago.FirstOrDefault(x => x.idCuota == cuotaPrePago.idCuota);
                rbtnTiempo.Enabled = false;
                dtpFecProxPago.Enabled = false;
                dtpFecProxPago.Value = objProximaCuotaLibre.dFechaProg;
        }
        }

        private void FormatoPlanPagos()
        {
            void ConfigurarColumna(string nombreColumna, string encabezado, int indice, DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft, string formato = null)
            {
                var columna = dtgPlanPagos.Columns[nombreColumna];
                if (columna != null)
                {
                    columna.Visible = true;
                    columna.HeaderText = encabezado;
                    columna.DisplayIndex = indice;
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    columna.DefaultCellStyle.Alignment = alineacion;
                    if (!string.IsNullOrEmpty(formato))
                    {
                        columna.DefaultCellStyle.Format = formato;
                    }
                }
            }

            // Hacer invisible todas las columnas por defecto
            foreach (DataGridViewColumn columna in dtgPlanPagos.Columns)
            {
                columna.Visible = false;
            }

            // Configurar columnas visibles
            ConfigurarColumna("idCuota", "Nro", 0);
            ConfigurarColumna("dFechaProg", "Fecha prog.", 1);
            ConfigurarColumna("dFechaPago", "Fecha pag.", 2);
            ConfigurarColumna("dFechaValor", "Fecha val.", 3);
            ConfigurarColumna("nAtrasoCuota", "Dias atr. cuo.", 4);
            ConfigurarColumna("nNumDiaCuota", "Dias cuota", 5);
            ConfigurarColumna("nMonCuoIni", "Monto cuota", 6, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("EstadoCuota", "Estado", 7);
            ConfigurarColumna("nCapital", "Capital", 8, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nCapitalPagado", "Cap. pag.", 9, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalCap", "Saldo cap.", 10, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteres", "Int.", 11, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresFecha", "Int. Fec.", 12, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresPagado", "Int. pag.", 13, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalInt", "Saldo int.", 14, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresComp", "Int. comp.", 15, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresCompPago", "Int. comp. pag.", 16, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalIntComp", "Saldo int. comp.", 17, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraGenerado", "Mora. gen.", 18, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraPagada", "Mora. pag.", 19, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalMor", "Saldo mora", 20, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtros", "Otros", 21, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtrosPagado", "Otros pag.", 22, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalOtr", "Saldo otros", 23, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalTot", "Saldo total", 24, DataGridViewContentAlignment.MiddleRight, "#,0.00");
        }


        private bool Validarmonto()
        {
            bool lEstado = true;

            decimal nSaldoCapital = _planpago.Sum(x => x.nCapitalSaldo);

            if (txtMonPrePago.nDecValor >= nSaldoCapital)
            {
                MessageBox.Show("El monto de prepago no debe superar al saldo capital total", "Validación Saldo Capital",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonPrePago.Focus();
                txtMonPrePago.SelectAll();
                lEstado = false;
            }

            if (txtMonPrePago.nDecValor <= 0)
            {
                MessageBox.Show("Porfavor ingrese un monto correcto para el prepago", "Validación Monto",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonPrePago.Focus();
                txtMonPrePago.SelectAll();
                lEstado = false;
            }

            if (objCredito.lUnicuota)
            {
                if (txtMonPrePago.nDecValor < (objCredito.nInteresDia - objCredito.nInteresPagado) + (objCredito.nOtrosGenerado - objCredito.nOtrosPagado))
                {
                    MessageBox.Show("Error al ingresar monto de prepago. En créditos unicuota, el monto mínimo a pagar es el interés a la fecha más el saldo de otros", "Validación Monto",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMonPrePago.Focus();
                    txtMonPrePago.SelectAll();
                    lEstado = false;
                }
            }

            return lEstado;
        }

        private bool ValidarCuentaParaPrepago()
        {
            var nNumCuoParcPaga = (from item in _planpago
                                   where item.idEstadocuota == 1
                                         &&
                                         (item.nCapitalPagado > 0 || item.nInteresPagado > 0 ||
                                          item.nInteresCompPago > 0 ||
                                          item.nMoraPagada > 0 || item.nOtrosPagado > 0)
                                   select item).Count();

            if (nNumCuoParcPaga > 1)
            {
                MessageBox.Show("No se puede realizar prepago a la cuenta debido \n a que se tiene mas de 1 cuota parcialmente pagada", "Validación Prepago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var nNumCuoVencidas = (from item in _planpago
                                   where item.idEstadocuota == 1
                                       && (item.nAtrasoCuota > 0 || item.dFechaProg.Date < clsVarGlobal.dFecSystem.Date)
                                   select item).Count();

            if (nNumCuoVencidas > 0)
            {
                MessageBox.Show("No se puede realizar prepago a la cuenta debido \n a que se tiene cuotas vencidas", "Validación Prepago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!objCredito.lUnicuota) // Caso diferente de unicuotas
            {
                var nNuncuotasfaltantes = (from item in _planpago
                                           where item.idEstadocuota == 1
                                           select item).Count();

                if (nNuncuotasfaltantes < 2)
                {
                    MessageBox.Show("No se puede realizar prepago a la cuenta debido \n a que tiene menos de 2 cuotas pendientes", "Validación Prepago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            DataTable datsolicitud = new clsCNSolicitud().ConsultaSolicitud(objCredito.idSolicitud);
            int idTipoPeriodo = Convert.ToInt16(datsolicitud.Rows[0]["idTipoPeriodo"]);

            if (objCredito.nMontoCuota == 0 && idTipoPeriodo != 3)
            {
                MessageBox.Show("El monto de la cuota es 0. Por favor comunicar al area de TI.", "Validación Prepago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            btnProcesar.Enabled = true;
            txtMonPrePago.Enabled = true;
            txtMonPrePago.Focus();

            return true;
        }

        private void DistribuirPrePago()
        {
            _planpagoPagados = new clsPlanPago();
            DateTime dFechaDesembolso;
            int idSolicitud = Convert.ToInt32(conDatCredito.txtCodSolicitud.Text);
            decimal nMontoPrepago = txtMonPrePago.nDecValor;

            bool lAplicaNuevoMultirriesgo = objCNCreditoCargaSeguro.CNValidaNuevoSeguroMultiriesgo(idSolicitud);

            DataTable datsolicitud = new clsCNSolicitud().ConsultaSolicitud(idSolicitud);
            short idTipoPeriodo = Convert.ToInt16(datsolicitud.Rows[0]["idTipoPeriodo"]);
            int nPlazo = Convert.ToInt32(datsolicitud.Rows[0]["nPlazoCuota"]);

            //REQ 400: Obteniendo los seguros asociados al crédito a prepagar
            objSolicitudCreditoSeguroActual = objCNCreditoCargaSeguro.CNObtenerSolicitudCargaSeguro(idSolicitud);
            objSolicitudCreditoSeguroActual.dFechaPrimeraCuota = dtpFecProxPago.Value.Date;
            DateTime? dFechaConsiderarComoDesembolso = objCNCreditoCargaSeguro.CNObtenerFechaCoberturaSeguroMultiriesgo(objCredito.idCuenta, idTipoPeriodo);
            objSolicitudCreditoSeguroActual.dFechaDesembolso = dFechaConsiderarComoDesembolso ?? objSolicitudCreditoSeguroActual.dFechaDesembolso;

            clsCuota cuotaPrePago = _planpago.Where(x => clsVarGlobal.dFecSystem.Date <= x.dFechaProg)
                                            .OrderBy(x => x.idCuota).First();
            int nNumCuotasNuevoPpg = _planpago.Count(x => x.dFechaProg.Date >= dtpFecProxPago.Value.Date);
            decimal nSaldoInteres = _planpago.Sum(x => x.nInteresFechaSaldo);
            decimal nSaldoOtros = _planpago.Where(x => x.dFechaProg.Date <= cuotaPrePago.dFechaProg.Date).Sum(x => x.nOtrosSaldo);

            int nNumCuoGraciaRest =
                _planpago.Count(x => x.dFechaProg.Date >= dtpFecProxPago.Value.Date && x.nCapital == 0);

            int nNumCuotas =
                objCredito.nCuotas;


            dFechaDesembolso = conDatCredito.dtFechaDesembolso.Value.Date;


            if (!ValidarParaCalculoPpg())
            {
                btnGrabar.Enabled = false;
                return;
            }

            decimal nRestoPrepago = nMontoPrepago;

            TipoPrepago tipoPrepago = TipoPrepago.Cuota;
            if (rbtnCuota.Checked)
            {
                tipoPrepago = TipoPrepago.Cuota;
            }
            if (rbtnTiempo.Checked)
            {
                tipoPrepago = TipoPrepago.Plazo;
            }

            clsCNPrePago objCnPrePago = new clsCNPrePago
            {
                TipoPrepago = tipoPrepago,
                DtModificaciones = dtModificaciones,
                FecPrimeraCuota = dtpFecProxPago.Value.Date,
                Tasa = conDatCredito.txtTasaVigente.nDecValor,
                IdSolicitud = idSolicitud,
                IdCuenta = conBusCuentaCli.nIdCuenta,
                IdMoneda = Convert.ToInt32(conDatCredito.cboMoneda1.SelectedValue),
                IdTipoPeriodo = idTipoPeriodo,
                PlazoCuota = nPlazo,
                NumCuotas = nNumCuotasNuevoPpg,
                CapitalMaxCobSeg = nCapitalMaxCobSeg,
                NumCuotasGracia = nNumCuoGraciaRest,
                MontoCuota = objCredito.nMontoCuota,
                ConfigGastos = _dtConfigGastos
            };
            _planpagoPagados = objCnPrePago.DistribuirPrePago(_planpago, nMontoPrepago, dFechaDesembolso, ref nRestoPrepago);

            decimal nSaldoCapitalCred = _planpagoPagados.Last().nSaldoCapital - _planpagoPagados.Last().nCapital;

            nOtrosKar = nSaldoOtros;
            nInteresKar = nSaldoInteres;
            nCapitalKar = nRestoPrepago;

            objCnPrePago.MontoCalculo = nSaldoCapitalCred;

            int idCuotaIni = _planpagoPagados.Max(x => x.idCuota);

            clsPlanPago planPagoCalc = new clsPlanPago();

            if (idTipoPeriodo == 3)
                planPagoCalc = objCnPrePago.CronogramaPrePagoCuotasLibres(_planpago, cuotaPrePago, idCuotaIni, objCnPrePago.GastosCuotaPrePago, nNumCuotas, objSolicitudCreditoSeguroActual, lAplicaNuevoMultirriesgo);
            else
                planPagoCalc = objCnPrePago.CronogramaPagoPrePago(cuotaPrePago, idCuotaIni, objCnPrePago.GastosCuotaPrePago, nNumCuotas, objCredito.lUnicuota, objSolicitudCreditoSeguroActual, lAplicaNuevoMultirriesgo); //Enviando la lista de seguros para incluir en el calculo

            nMontoCuotaNuevo = objCnPrePago.MontoCuotaNuevo;

            _planpagoPagados.AddRange(planPagoCalc);

            _planpagoPagados.ForEach(x => x.idPlanPago = cuotaPrePago.idPlanPago + 1);

            dtgPlanPago.DataSource = null;
            dtgPlanPago.DataSource = _planpagoPagados.ToList();

            FormatGrid(cuotaPrePago.idCuota);

            dtGastosPlanPagos = objCnPrePago.GastosPlanPagos;
            dtDetGastosPagados = objCnPrePago.GastosCuotaPrePago;

            txtTotCapital.Text = string.Format("{0:#,0.00}",
                                               _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nCapital));
            txtTotCuota.Text = string.Format("{0:#,0.00}",
                                             _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nMonCuota));
            txtTotIntComp.Text = string.Format("{0:#,0.00}",
                                               _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nIntComp));
            txtTotInteres.Text = string.Format("{0:#,0.00}",
                                               _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nInteres));
            txtTotMora.Text = string.Format("{0:#,0.00}",
                                            _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nMora));
            txtTotOtros.Text = string.Format("{0:#,0.00}",
                                             _planpagoPagados.Where(p => p.idEstadocuota == 1).Sum(x => x.nOtros));
            dtgPlanPago.ClearSelection();

            btnGenerarSolicitud.Enabled = true;
        }

        private bool ValidarParaCalculoPpg()
        {
            int nNumCuotasPrePago = clsVarApl.dicVarGen["nNumCuotasPrePago"];
            decimal nMontoPrepago = txtMonPrePago.nDecValor;
            decimal nSaldoCredito = _planpago.Sum(x => x.nCapitalSaldo + x.nInteresFechaSaldo + x.nOtrosSaldo);
            decimal nSaldoCapital = _planpago.Sum(x => x.nCapitalSaldo);
            clsCuota cuotaPrePago = _planpago.Where(x => clsVarGlobal.dFecSystem.Date <= x.dFechaProg)
                                            .OrderBy(x => x.idCuota).First();
            clsCuota objProximaCuota = _planpago.FirstOrDefault(x => x.idCuota == cuotaPrePago.idCuota + 1);
            clsCuota objPrimCuoPend = _planpago.FirstOrDefault(x => x.idEstadocuota == 1);
            int nNroCuotas = _planpago.Count();

            if (nMontoPrepago > nSaldoCredito)
            {
                MessageBox.Show("El valor por prepago supera el monto total pendiente",
                                "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nSaldoCapital == 0)
            {
                MessageBox.Show("El saldo capital es igual a cero, utilice la opción de cancelación anticipada",
                                "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!objCredito.lUnicuota) // Cuando el crédito es diferente de unicuota
            {
                if (objPrimCuoPend.nCapital > 0)
                {
                    if (nMontoPrepago <= objCredito.nMontoCuota * nNumCuotasPrePago)
                    {
                        MessageBox.Show("El monto de pre-pago debe ser mayor a " + nNumCuotasPrePago + " cuota(s).",
                                        "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    if (nMontoPrepago <= (objPrimCuoPend.nCapital + objPrimCuoPend.nInteres) * nNumCuotasPrePago)
                    {
                        MessageBox.Show("El monto de pre-pago debe ser mayor a " + nNumCuotasPrePago + " cuota(s).",
                                        "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            //if ( objProximaCuota == null )
            //{
            //    MessageBox.Show("Se encuentra en la última cuota. No se puede realizar prepago.",
            //                    "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            if (!objCredito.lUnicuota)
            {
                if (objProximaCuota == null)
                {
                    MessageBox.Show("Se encuentra en la última cuota. No se puede realizar prepago.",
                                    "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (dtpFecProxPago.Value.Date > objProximaCuota.dFechaProg.Date)
                {
                    MessageBox.Show(
                                    string.Format("La fecha de pago no puede ser mayor a {0:dd/MM/yyyy}",
                                                  objProximaCuota.dFechaProg),
                                    "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }


                if (dtpFecProxPago.Value.Date < cuotaPrePago.dFechaProg.Date)
                {
                    MessageBox.Show(string.Format("La fecha de pago no puede ser menor a {0:dd/MM/yyyy}",
                                                  cuotaPrePago.dFechaProg),
                                    "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }


                if (dtpFecProxPago.Value.Date <= clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("La fecha de pago no puede ser menor o igual a la fecha del sistema",
                                    "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void FormatGrid(int idCuotaPrepago)
        {
            foreach (DataGridViewRow row in dtgPlanPago.Rows)
            {
                clsCuota cuota = (clsCuota)row.DataBoundItem;

                if (cuota.idEstadocuota == 2)
                {
                    row.DefaultCellStyle.BackColor = Color.NavajoWhite;
                }
                if (cuota.idCuota == idCuotaPrepago)
                {
                    row.DefaultCellStyle.BackColor = Color.LavenderBlush;
                }
                if (cuota.idEstadocuota == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                if (cuota.lDiferido)
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                }
            }
            dtgPlanPago.Rows[idCuotaPrepago - 1].Selected = true;
        }

        private void Limpiar()
        {
            dtgPlanPago.DataSource = null;
            btnGrabar.Enabled = false;
            btnGenerarSolicitud.Enabled = false;
            txtItf.Text = "0.00";
            txtMonTotal.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtTotCapital.Text = "0.00";
            txtTotCuota.Text = "0.00";
            txtTotIntComp.Text = "0.00";
            txtTotInteres.Text = "0.00";
            txtTotMora.Text = "0.00";
            txtTotOtros.Text = "0.00";
            nITFNormal = 0;
            conCalcVuelto.limpiar();
        }

        private string CalcularTotal()
        {
            clsFunUtiles objFunciones = new clsFunUtiles();
            decimal nMonPago = txtMonPrePago.nDecValor;
            int idMoneda = (int)conDatCredito.cboMoneda1.SelectedValue;
            decimal nITF = objFunciones.truncar(clsVarGlobal.nITF / 100.00m * nMonPago, 2, idMoneda);

            //Asignando el ItfNormal (Sin redondeo)
            nITFNormal = clsVarGlobal.nITF / 100.00m * nMonPago;

            nITFNormal = objFunciones.truncarNumero(nITFNormal, 2);

            decimal nMonFavCli = 0.00m;

            decimal nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, idMoneda, true, true);

            txtRedondeo.Text = Math.Round(nMonFavCli, 2).ToString();
            txtItf.Text = Math.Round(nITF, 2).ToString();
            return (nMonRedBcr).ToString();
        }

        #endregion

        private void ActivarTitular()
        {
            if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
                rblTitular.Checked = true;
                rblTitular.Enabled = true;
                rblConyugue.Enabled = true;
                rblOtros.Enabled = true;
            }
        }

        private void GuardarSolicitudHojaTramite(int idSolicitudHojaTramite_, int idUsuario, int idTipoOperacion, int idCuenta, int idCliPagador, int idTipoPagador, bool lCartaPoder, int idTipoOpePrePago, int idKardex_)
        {
            dtRegSolHojaTramite = _objplanpago.CNRegistrarSolHojaTramite(idSolicitudHojaTramite_, idUsuario, idTipoOperacion, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, idKardex_);
            idSolicitudHojaTramite = Convert.ToInt32(dtRegSolHojaTramite.Rows[0]["idSolicitudHojaTramite"]);
            if (idKardex_ == 0)
            {
                ImprimirVoucherHojaTramite(idSolicitudHojaTramite);
            }

            btnGrabar.Enabled = true;

        }
        private void ImprimirVoucherHojaTramite(int idSolicitudHojaTramite)
        {
            int idTipoOperacion = 1;
            string reportpath = "rptVoucherPrePago.rdlc";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("idSolicitudTramite", idSolicitudHojaTramite.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoOperacion", idTipoOperacion.ToString(), false));

            dtslist.Add(new ReportDataSource("DataSet1", _objplanpago.CNObtenerVoucherHojaTramite(idSolicitudHojaTramite, idTipoOperacion)));


            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private bool VerificarTipoPagador()
        {
            int docPag = Convert.ToInt32(conDatPerReaOperac.txtDocIdePerson.Text);
            int docCli = Convert.ToInt32(conBusCuentaCli.txtNroDoc.Text);

            if (docPag == docCli)
            {
                if (rblTitular.Checked == true)
                {
                    chbCartaPoder.Enabled = false;
                    chbCartaPoder.Checked = false;
                }
                else
                {
                    MessageBox.Show("El cliente y el Pagador son iguales, seleccionar la opción Titular", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                if (rblTitular.Checked == true)
                {
                    MessageBox.Show("El cliente y el Pagador son diferentes, seleccionar correctamente la opción tipo de pagador ", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rblTitular.Checked = false;
                    return false;
                }
                else
                {
                    if (rblTitular.Checked == false && rblConyugue.Checked == false && rblOtros.Checked == false)
                    {
                        MessageBox.Show("Debe seleccionar al menos una opción", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }

            }
            return true;
        }

        private void rblTitular_CheckedChanged(object sender, EventArgs e)
        {
            if (rblTitular.Checked)
            {
                btnGrabar.Enabled = false;
                if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                {
                    if (Convert.ToInt32(conBusCuentaCli.nIdCliente) != Convert.ToInt32(conDatPerReaOperac.idCli))
                    {
                        rblTitular.Checked = false;
                        MessageBox.Show("El cliente y el pagador son diferentes, seleccionar otra opción", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chbCartaPoder.Checked = false;
                        chbCartaPoder.Enabled = false;
                        rbtnCuota.Enabled = true;
                    }
                    else
                    {
                        rbtnCuota.Enabled = true;
                        chbCartaPoder.Checked = false;
                        chbCartaPoder.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Debe registrar un pagador", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chbCartaPoder.Enabled = false;
                    chbCartaPoder.Checked = false;
                    rblTitular.Checked = false;
                }
            }
        }

        private void rblConyugue_CheckedChanged(object sender, EventArgs e)
        {
            if (rblConyugue.Checked)
            {
                btnGrabar.Enabled = false;
                if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                {
                    if (Convert.ToInt32(conBusCuentaCli.nIdCliente) == Convert.ToInt32(conDatPerReaOperac.idCli))
                    {
                        MessageBox.Show("El cliente y el pagador son iguales", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rblConyugue.Checked = false;
                        rblTitular.Checked = true;
                    }
                    else
                        chbCartaPoder.Enabled = false;
                    chbCartaPoder.Checked = false;
                    rbtnCuota.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe registrar un pagador", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chbCartaPoder.Enabled = false;
                    chbCartaPoder.Checked = false;
                    rblConyugue.Checked = false;
                }
            }
        }
  
        private void dtgPlanPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgPlanPagos.Columns[e.ColumnIndex].Name == "nOtros")
                {
                    DataGridViewRow selectedRow = dtgPlanPagos.Rows[e.RowIndex];
                    string nCuenta = selectedRow.Cells[0].Value.ToString();

                    List<clsOtrosGastos> listaGastos = DataTableToList.ConvertTo<clsOtrosGastos>(new clsCNCargaGastosCred().listarGastosPorCuenta(Convert.ToInt32(nCuenta))) as List<clsOtrosGastos>;
                    frmDetalleOtrosGastos detalleForm = new frmDetalleOtrosGastos();
                    DataGridView dataGridViewDetalleGastos = detalleForm.dtgDetalleGastos;

                    var query = from gasto in listaGastos
                                join concepto in lstConceptos on gasto.idTipoGasto equals concepto.idConcepto
                                select new
                                {
                                    gasto.idCuota,
                                    concepto.cNombreCorto,
                                    gasto.nGasto
                                };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuota", typeof(string));

                    foreach (var item in query)
                    {
                        if (!dataTable.Columns.Contains(item.cNombreCorto))
                            dataTable.Columns.Add(item.cNombreCorto, typeof(decimal));

                        DataRow existingRow = null;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (Convert.ToInt32(row["Cuota"]) == item.idCuota)
                            {
                                existingRow = row;
                                break;
                            }
                        }
                        if (existingRow == null)
                        {
                            existingRow = dataTable.NewRow();
                            existingRow["Cuota"] = item.idCuota;
                            dataTable.Rows.Add(existingRow);
                        }
                        existingRow[item.cNombreCorto] = item.nGasto;
                    }

                    dataTable.Columns.Add("Total", typeof(decimal));

                    DataRow totalRow = dataTable.NewRow();

                    int totalFilas = dataTable.Rows.Count;
                    int totalColumnas = dataTable.Columns.Count;

                    decimal[] sumatorias = new decimal[totalColumnas];

                    for (int fila = 0; fila < totalFilas; fila++)
                    {
                        for (int columna = 0; columna < totalColumnas; columna++)
                        {
                            object cellValue = dataTable.Rows[fila][columna];
                            if (cellValue != null)
                            {
                                decimal valorCelda;
                                if (decimal.TryParse(cellValue.ToString(), out valorCelda))
                                {
                                    sumatorias[columna] += valorCelda;
                                }
                            }
                        }
                    }
                    DataRow rowSumatoria = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        rowSumatoria[columna] = sumatorias[columna];

                    dataTable.Rows.Add(rowSumatoria);

                    int ultimaFilaIndex = dataTable.Rows.Count - 1;
                    dataTable.Rows[ultimaFilaIndex][0] = "Total";

                    dataGridViewDetalleGastos.DataSource = dataTable;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            if (cell.ColumnIndex > 0 && (cell.Value == null || cell.Value is DBNull))
                            {
                                cell.Value = 0m;
                            }
                        }
                    }

                    dataGridViewDetalleGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dgvRow.Cells.Count; i++)
                        {
                            decimal valor;
                            if (dgvRow.Cells[i].Value != null && decimal.TryParse(dgvRow.Cells[i].Value.ToString(), out valor))
                                total += valor;
                        }
                        dgvRow.Cells["TOTAL"].Value = total;
                    }

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                    {
                        if (columna.Name == "Cuota")
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        else
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dataGridViewDetalleGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dataGridViewDetalleGastos.Columns["Cuota"].Width = 50;
                    dataGridViewDetalleGastos.Columns["Total"].Width = 70;

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                        if (columna.Name != "Cuota" && columna.Name != "Total")
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 

                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error interno: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgPlanPago_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgPlanPago.Columns[e.ColumnIndex].Name == "nOtrosDataGridViewTextBoxColumn")
                {
                    DataGridViewRow selectedRow = dtgPlanPago.Rows[e.RowIndex];
                    List<clsOtrosGastos> listaGastos= DataTableToList.ConvertTo<clsOtrosGastos>(dtGastosPlanPagos) as List<clsOtrosGastos>;
                    frmDetalleOtrosGastos detalleForm = new frmDetalleOtrosGastos();
                    DataGridView dataGridViewDetalleGastos = detalleForm.dtgDetalleGastos;

                    var query = from gasto in listaGastos
                                join concepto in lstConceptos on gasto.idTipoGasto equals concepto.idConcepto
                                select new
                                {
                                    gasto.idCuota,
                                    concepto.cNombreCorto,
                                    gasto.nGasto
                                };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuota", typeof(string));

                    foreach (var item in query)
                    {
                        if (!dataTable.Columns.Contains(item.cNombreCorto))
                            dataTable.Columns.Add(item.cNombreCorto, typeof(decimal));

                        DataRow existingRow = null;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (Convert.ToInt32(row["Cuota"]) == item.idCuota)
                            {
                                existingRow = row;
                                break;
                            }
                        }

                        if (existingRow == null)
                        {
                            existingRow = dataTable.NewRow();
                            existingRow["Cuota"] = item.idCuota;
                            dataTable.Rows.Add(existingRow);
                        }
                        existingRow[item.cNombreCorto] = item.nGasto;
                    }

                    dataTable.Columns.Add("Total", typeof(decimal));

                    DataRow filaTotales = dataTable.NewRow();

                    int totalFilas = dataTable.Rows.Count;
                    int totalColumnas = dataTable.Columns.Count;

                    decimal[] sumatorias = new decimal[totalColumnas];

                    for (int fila = 0; fila < totalFilas; fila++)
                    {
                        for (int columna = 0; columna < totalColumnas; columna++)
                        {
                            object cellValue = dataTable.Rows[fila][columna];
                            if (cellValue != null)
                            {
                                decimal valorCelda;
                                if (decimal.TryParse(cellValue.ToString(), out valorCelda))
                                {
                                    sumatorias[columna] += valorCelda;
                                }
                            }
                        }
                    }
                    DataRow rowSumatoria = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        rowSumatoria[columna] = sumatorias[columna];

                    dataTable.Rows.Add(rowSumatoria);

                    int ultimaFilaIndex = dataTable.Rows.Count - 1;
                    dataTable.Rows[ultimaFilaIndex][0] = "Total";

                    dataGridViewDetalleGastos.DataSource = dataTable;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            if (cell.ColumnIndex > 0 && (cell.Value == null || cell.Value is DBNull))
                            {
                                cell.Value = 0m;
                            }
                        }
                    }

                    dataGridViewDetalleGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dgvRow.Cells.Count; i++)
                        {
                            decimal valor;
                            if (dgvRow.Cells[i].Value != null && decimal.TryParse(dgvRow.Cells[i].Value.ToString(), out valor))
                                total += valor;
                        }
                        dgvRow.Cells["TOTAL"].Value = total;
                    }

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                    {
                        if (columna.Name == "Cuota")
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        else
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dataGridViewDetalleGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dataGridViewDetalleGastos.Columns["Cuota"].Width = 50;
                    dataGridViewDetalleGastos.Columns["Total"].Width = 70;

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                        if (columna.Name != "Cuota" && columna.Name != "Total")
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 

                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error interno: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rblOtros_CheckedChanged(object sender, EventArgs e)
        {
            if (rblOtros.Checked)
            {
                btnGrabar.Enabled = false;
                if (rbtnTiempo.Enabled == true)
                {
                    if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                    {
                        if (Convert.ToInt32(conBusCuentaCli.nIdCliente) == Convert.ToInt32(conDatPerReaOperac.idCli))
                        {
                            MessageBox.Show("El cliente y el pagador son iguales", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            chbCartaPoder.Enabled = false;
                            chbCartaPoder.Checked = false;
                            rblOtros.Checked = false;
                            rbtnCuota.Enabled = true;
                            rblTitular.Checked = true;
                        }
                        else
                        {
                            chbCartaPoder.Enabled = true;
                            rbtnCuota.Checked = false;
                            rbtnCuota.Enabled = false;
                            rbtnTiempo.Checked = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe registrar un pagador", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chbCartaPoder.Enabled = false;
                        chbCartaPoder.Checked = false;
                        rblOtros.Checked = false;
                    }
                }
            }
        }

        private void chbCartaPoder_CheckedChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(conBusCuentaCli.nIdCliente) != Convert.ToInt32(conDatPerReaOperac.idCli))
            {
                if (rblOtros.Checked)
                {
                    if (chbCartaPoder.Checked)
                    {
                        rbtnCuota.Enabled = true;
                    }
                    else
                    {
                        rbtnCuota.Enabled = false;
                        rbtnCuota.Checked = false;
                        rbtnTiempo.Checked = true;
                    }

                }
            }
        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }
    }
}
