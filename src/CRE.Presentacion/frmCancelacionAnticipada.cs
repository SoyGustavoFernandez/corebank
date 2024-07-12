using System;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using CAJ.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.Collections.Generic;
using SPL.Presentacion;
using CLI.Presentacion;

namespace CRE.Presentacion
{
    public partial class frmCancelacionAnticipada : frmBase
    {

        #region Variables
        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        private const int idTipoOperacion = 2;
        public DataTable dtCredito = new DataTable("dtCredito");
        clsCNCredito Credito = new clsCNCredito();
        clsFunUtiles objFunciones = new clsFunUtiles();
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        clsCNGarantia cngarantia = new clsCNGarantia();
        conSplaf conSplaf1 = new conSplaf();
        int nNumCredito = 0, idAsesor = 0;
        DateTime dFecDesembolso;
        decimal nCapital = 0, nInteres = 0, nIntComp = 0, nMora = 0, nOtros = 0, nMontoNeto = 0;
        private int idCuentaRef = 0;
        private string cDocumentoIDRef = String.Empty;

        private const int idTipoOpeRegimenReforzado = 171;

        private DataTable dtCobs;
        private int idTipoOperacionCOBs = 7;
        int idSolicitud = 0;
       public bool bVieneCobro = false; 
       private  frmCobroCreditos frmCobroCreditos;
        conDatosReprogramacion conDatosRepro = new conDatosReprogramacion();
        int nIdKardexExtorno = 0;
        #endregion

        #region Eventos

        private void frmCancelacionAnticipada_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            HabilitarControles(false);
            btnCancelar.Enabled = false;
            conBusCuentaCli.Enabled = true;
            cboTipoPago.SelectedIndex = -1;
            cboMotCancelacion.SelectedIndex = -1;

            conCalcVuelto.Enabled = false;

            conDatosRepro.Visible = false;

            if (bVieneCobro)
            {
                if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
                {
                    HabilitarControles(true);
                    conDatPerReaOperac.Focus();
                    conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;


                }
                else
                {
                    conBusCuentaCli.txtNroBusqueda.Enabled = true;
                    conBusCuentaCli.btnBusCliente1.Enabled = true;
                }

                gastosJudiciales();

                this.cargaCondonacionesEjecutadas();
                if (this.dtCobs == null)
                {
                    this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                    this.cargaCondonacionesEjecutadas();
                }
            }

            if (idCuentaRef > 0)
            {
                CargaDatosRef(idCuentaRef, cDocumentoIDRef);
            }
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargaDatos();
            if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
            {
                HabilitarControles(true);
                conDatPerReaOperac.Focus();
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
            }
            else
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = true;
                conBusCuentaCli.btnBusCliente1.Enabled = true;
            }
            
            gastosJudiciales();
            
            this.cargaCondonacionesEjecutadas();
            if (this.dtCobs == null)
            {
                this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                this.cargaCondonacionesEjecutadas();
            }
        }
        private void gastosJudiciales()
        {
            DataTable dtGastosJudiciales = CNGastosJudiciales.ContarGastosPendientes(conBusCuentaCli.nValBusqueda);
            if (dtGastosJudiciales.Rows.Count > 0 && Convert.ToInt32(dtGastosJudiciales.Rows[0]["nContador"]) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("La cuenta tiene gastos judiciales pendientes que no fueron cargados, desea continuar?", "Gastos Judiciales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    HabilitarControles(false);
                    LimpiarDatos();

                    //Quitando Bindings
                    if (txtTasaInteres.DataBindings.Count > 0)
                    {
                        txtTasaInteres.DataBindings.Remove(txtTasaInteres.DataBindings["Text"]);
                        txtTasaMoratoria.DataBindings.Remove(txtTasaMoratoria.DataBindings["Text"]);
                        txtDiasAtraso.DataBindings.Remove(txtDiasAtraso.DataBindings["Text"]);
                        txtProducto.DataBindings.Remove(txtProducto.DataBindings["Text"]);
                        txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Text"]);
                        txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Tag"]);
                    }

                    conBusCuentaCli.LiberarCuenta();
                    conBusCuentaCli.Enabled = true;
                    conBusCuentaCli.txtNroBusqueda.Enabled = true;
                    conBusCuentaCli.btnBusCliente1.Enabled = true;
                    conBusCuentaCli.txtNroBusqueda.Focus();
                    cboMotCancelacion.SelectedIndex = -1;
                    return;
                }
            }
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CargaDatos();
                if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
                {
                    HabilitarControles(true);
                    conDatPerReaOperac.Focus();
                    conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
                }
            }

            gastosJudiciales();

            this.cargaCondonacionesEjecutadas();
            if (this.dtCobs == null)
            {
                this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                this.cargaCondonacionesEjecutadas();
            }
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
        }
        }
        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);
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
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtTotalAPagar.Text.ToString()));
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(this.conDatPerReaOperac.idCli, this.conDatPerReaOperac.cDocumentoID, clsVarGlobal.nIdAgencia, idTipoOperacion, Convert.ToInt32(conBusCuentaCli.nIdCliente));
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text), "Inicio - Cancelación Anticipada", btnGrabar);

            if (ValidarCampos())
            {
                return;
            }

            /*========================================================================================
            * Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(Convert.ToDecimal(txtTotalAPagar.Text)), Convert.ToString(Convert.ToInt32(this.txtMoneda.Tag))))
            {
                //MessageBox.Show("Error, Businnes Rules aren´t aprobated");
                return;
            }
            /*========================================================================================
            * FIN -  Validar Regla Eob con autorizacion
            ========================================================================================*/


            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusCuentaCli.nIdCliente,
                                                                               Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"]),
                                                                               Convert.ToInt32(dtCredito.Rows[0]["idProducto"]),
                                                                               nNumCredito,
                                                                               Convert.ToDecimal(txtTotalAPagar.Text));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            btnGrabar.Enabled = false;

            DataSet ds = new DataSet("dsCancelaAnticipada");

            //Guardar los Datos de la persona que está pagando la cuota
            {
                DataTable dtPagador = new DataTable("TablaDatosPagador");

                dtPagador.Columns.Add("cNroDNI", typeof(string));
                dtPagador.Columns.Add("cNomCliente", typeof(string));
                dtPagador.Columns.Add("cDireccion", typeof(string));
                dtPagador.Columns.Add("idMotivoCancelacion", typeof(int));
                dtPagador.Columns.Add("cDetMotCancelacion", typeof(string));

                DataRow drfila = dtPagador.NewRow();
                drfila["cNroDNI"] = conDatPerReaOperac.txtDocIdePerson.Text.Trim();
                drfila["cNomCliente"] = conDatPerReaOperac.txtNombrePerson.Text.Trim();
                drfila["cDireccion"] = conDatPerReaOperac.txtDireccPerson.Text.Trim();
                drfila["idMotivoCancelacion"] = Convert.ToInt32(cboMotCancelacion.SelectedValue);
                drfila["cDetMotCancelacion"] = txtDetMotCanc.Text.Trim();
                dtPagador.Rows.Add(drfila);

                ds.Tables.Add(dtPagador);
            }

            string xmlPagador = ds.GetXml();
            xmlPagador = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPagador);

            int idCanal = 1;//El canal será Ventanilla

            //--------------------------------------------------------------------------------
            //--- Registro PEP
            //--------------------------------------------------------------------------------
            string mensaje = "",
                        x_cNroDni = "";
            int x_idEstApr = 0;
            int CodCliente = conBusCuentaCli.nIdCliente;
            int CodIddocumento = conBusCuentaCli.idTipoDocumento;

            if (!conSplaf1.ValidaAprobacionClientePep(CodCliente, ref mensaje, ref x_cNroDni, ref x_idEstApr))
            {
                MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (x_idEstApr == 1) //--Solicitado
                {
                    frmPep frmPepx = new frmPep(CodIddocumento, x_cNroDni);

                    frmPepx.ShowDialog();
                }
                btnGrabar.Enabled = true;
                return;
            }

            //
            //=================================================
            //TIPO PAGO
            //=================================================
            int idTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue), idEntidad = 0, idCtaEntidad = 0;
            string cNroTrx = "";
            if (idTipoPago != 1)
            {
                conPagoBcos.CargaResultado();
                if (!conPagoBcos.lResulta)
                {
                    btnGrabar.Enabled = true;
                    return;
                }
                idEntidad = conPagoBcos.idEntidad;
                idCtaEntidad = conPagoBcos.idCuenta;
                cNroTrx = conPagoBcos.cNroTrx;
            }
            else
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()), 1, Convert.ToDecimal(txtTotalAPagar.Text)))
                {
                    btnGrabar.Enabled = true;
                    return;
                }
            }

            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = Convert.ToDecimal(txtTotalAPagar.Text);
            int idMonedaUm = Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString());
            int idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            int idSubProducto = Convert.ToInt32(dtCredito.Rows[0]["idProducto"]);
            //int idTipoOperacion = 2;


            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion
            //
            //=================================================
            //REALIZA CANCELA ANTICIPADA
            //=================================================

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 1; //INGRESO

            if (idTipoPago == 1)
                lModificaSaldoLinea = true;

            DataTable dtRespuesta = Credito.InsCancelacionAnticipada(xmlPagador: xmlPagador,
                                                                    dFechaDelSistema: clsVarGlobal.dFecSystem,
                                                                    nUsuarioDelSistema: clsVarGlobal.User.idUsuario,
                                                                    nAgencia: clsVarGlobal.nIdAgencia,
                                                                    nNumCredito: nNumCredito,
                                                                    nImpuestos: Convert.ToDecimal(txtImpuestos.Text),
                                                                    nRedondeo: Convert.ToDecimal(txtRedondeo.Text),
                                                                    nTotalAPagar: Convert.ToDecimal(txtTotalAPagar.Text),
                                                                    idCanal: idCanal,
                                                                    idTipoPago: idTipoPago,
                                                                    idEntidad: idEntidad,
                                                                    idCtaEntidad: idCtaEntidad,
                                                                    cNroTrx: cNroTrx,
                                                                    idMotivoOperacion: Convert.ToInt32(cboMotivoOperacion.SelectedValue),
                                                                    cCobs: this.ObtenerCobsXml(),
                                                                    lModificaSaldoLinea: lModificaSaldoLinea,
                                                                    idMoneda: Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()),
                                                                    idTipoTransac: idTipoTransac
                                                                    );

            //=================================================

            int nIdKardex,
                nIdKardexCob = 0;
            if (dtRespuesta.Rows.Count > 0)
            {
                nIdKardex = Convert.ToInt32(dtRespuesta.Rows[0][0]);
                nIdKardexCob = Convert.ToInt32(dtRespuesta.Rows[0]["idKardexReciboCob"]);
                nIdKardexExtorno = nIdKardex; 

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                    
                MessageBox.Show("Cobro satisfactorio con número de operación: " + dtRespuesta.Rows[0][0].ToString(), "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var dtGarantia = cngarantia.CNValidaCuentaGarantia(conBusCuentaCli.nValBusqueda);

                if (dtGarantia.Rows.Count > 0 && Convert.ToBoolean(dtGarantia.Rows[0]["lAvisoMinutaGarantia"]))
                {
                    string cAlertaGarantia = Convert.ToString(dtGarantia.Rows[0]["cAlertaGarantia"]);
                    MessageBox.Show(cAlertaGarantia, "ALERTA: VICULADO A GARANTIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dtGarantia.Rows.Count > 0 && (int)dtGarantia.Rows[0]["idBloCta"] == 0)
                {
                    MessageBox.Show("El crédito se canceló, cliente debe de realizar el trámite \n para liberar su garantía, coordinar con su asesor", "Validar garantía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(nIdKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(nIdKardex);

            }
            else
            {
                MessageBox.Show("Ocurrió un problema al realizar el Cobro de Crédito", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HabilitarControles(false);

            //Emision de Voucher
            ImpresionVoucher(nIdKardex: nIdKardex, idModulo: 1, idTipoOpe: idTipoOperacion, idEstadoKardex: 1,
                                nValRec: conCalcVuelto.txtMonEfectivo.nDecValor,
                                nValdev: conCalcVuelto.txtMonDiferencia.nDecValor,
                                idKardexAd: 0, idTipoImpresion: 1);


            if (nIdKardexCob != 0)
            {
                foreach (DataRow item in dtRespuesta.Rows)
                {
                    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt32(this.txtMoneda.Tag), Convert.ToInt32(item["idTipoOperacion"]) == 5 ? 1 : 2, Convert.ToDecimal(item["nMontoPag"]));
                }
                foreach (DataRow item in dtRespuesta.Rows)
                {
                    ImpresionVoucher(
                            nIdKardex: Convert.ToInt32(item["idKardexReciboCob"]),
                            idModulo: 3,
                            idTipoOpe: Convert.ToInt32(item["idTipoOperacion"]) /**/,
                            idEstadoKardex: 1,
                            nValRec: Convert.ToDecimal(item["nMontoPag"]),
                            nValdev: 0,
                            idKardexAd: 0,
                            idTipoImpresion: 1);
                }
            }

            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            this.conBusCuentaCli.LiberarCuenta();
            conCalcVuelto.Enabled = false;

            //-----------------------------------------------------------------------
            //Validacion de Declaracion Jurada de Sujetos Obligados
            //-----------------------------------------------------------------------
            DeclaracionJuradaCli(conBusCuentaCli.nIdCliente);

            /*========================================================================================
             * REGISTRO DE RASTREO
              ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text), "Fin - Cancelación Anticipada", btnGrabar);
            if (bVieneCobro)
            {
                this.frmCobroCreditos.btnLimpiarCobro();
            }
            btnExtorno.Enabled = true; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            anularCancelacionAnticipada();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.conBusCuentaCli.LiberarCuenta();
        }

        private void frmCancelacionAnticipada_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.conBusCuentaCli.LiberarCuenta();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (nNumCredito <= 0)
            {
                MessageBox.Show("Seleccione la cuenta a cancelar.", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCuentaCli.txtNroBusqueda.Focus();
                return;
            }


            if (idAsesor <= 0)
            {
                MessageBox.Show("No se encontro ningun asesor para la cuenta.", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCuentaCli.txtNroBusqueda.Focus();
                return;
            }

            int idCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text.Trim());
            decimal nMontoCanc = Convert.ToDecimal(txtTotalAPagar.Text);

            DataTable dtResult = Credito.CNEnviarEmailAsesor(idAsesor, idCuenta, nMontoCanc);
            clsDBResp objDbResp = new clsDBResp(dtResult);

            MessageBox.Show(objDbResp.cMsje, "Cancelación Anticipada",
                                            MessageBoxButtons.OK,
                                            (objDbResp.nMsje == 0) ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.SelectedIndex == -1 || cboTipoPago.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }
            conPagoBcos.LimpiarControles();
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 4)
            {
                conPagoBcos.Visible = true;
                conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
            }
            else
            {
                conPagoBcos.Visible = false;
            }
            txtTotalAPagar.Text = CalcularImpuestosYRedondeo();
            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
            {
                conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtTotalAPagar.Text.Trim());
                conCalcVuelto.Enabled = true;
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
            }
            else
            {
                conCalcVuelto.Enabled = false;
            }

            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtTotalAPagar.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }



        }

        private void btnHistCli_Click(object sender, EventArgs e)
        {
            if (dtCredito.Rows.Count > 0)
            {
                FrmPosicionCli frmHistCli = new FrmPosicionCli(this.conBusCuentaCli.nIdCliente);
                frmHistCli.ShowDialog();
            }
            else
            {
                FrmPosicionCli frmPrePago = new FrmPosicionCli();
                frmPrePago.ShowDialog();
            }
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

        private void DeclaracionJuradaCli(int idCli)
        {
            frmDeclaracionJurada declara = new frmDeclaracionJurada(idCli);
        }

        public frmCancelacionAnticipada()
        {
            InitializeComponent();
            this.conDatPerReaOperac.lMostrarMsjeJuridico = false;

            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();

            cboTipoPago.DataSource = dtTipoPago;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";

            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedValue = 6;
        }
    //jcasas
        public frmCancelacionAnticipada(int idCli,frmCobroCreditos form,int numCredito, string ccodCli,string cNumDoc,string cNombre)
        {
            InitializeComponent();
            this.frmCobroCreditos = form;
      
            this.conDatPerReaOperac.lMostrarMsjeJuridico = false;

            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();

            cboTipoPago.DataSource = dtTipoPago;
            cboTipoPago.ValueMember = "idTipoPago";
            cboTipoPago.DisplayMember = "cDesTipoPago";

            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedValue = 6;
            nNumCredito = numCredito;
            this.conBusCuentaCli.buscarCuentasPorClienteRef(idCli, numCredito, ccodCli, cNumDoc, cNombre);
            idCuentaRef = numCredito;
            cDocumentoIDRef = cNumDoc;
        }
        private void CargaDatosRef(int nNumCredito, string cNumDoc)
        {

            if (nNumCredito <= 0)
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }

            if (cNumDoc == "")
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }

            this.btnGrabar.Enabled = true;
            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);

            //Valida Impresión de calendario por cambio de tea - ley 31143
            DataTable dtValidacion = Credito.CNValidaImpresionPendienteCalendario(nNumCredito);
            if (dtValidacion.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidacion.Rows[0]["nRespuesta"]) == 1)
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cRespuesta"].ToString(), "Impresión de Cronograma de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //Validar que no exista una solicitud pendiente o aprobada

            DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(conBusCuentaCli.nIdCliente, Convert.ToInt32(cNumDoc));
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                return;
            }

            if (this.verificarSolicitudAmpliacion(nNumCredito))
            {
                anularCancelacionAnticipada();
                return;
            }

            //Rellenar Detalles de saldo de Deuda
            nCapital = Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nCapitalPagado"].ToString());
            nInteres = Convert.ToDecimal(dtCredito.Rows[0]["nInteresDia"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nInteresPagado"].ToString());
            nIntComp = Convert.ToDecimal(dtCredito.Rows[0]["nInteresComp"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nInteresCompPago"].ToString());
            nMora = Convert.ToDecimal(dtCredito.Rows[0]["nMonSalMora"].ToString());
            nOtros = Convert.ToDecimal(dtCredito.Rows[0]["nOtrosGenerado"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nOtrosPagado"].ToString());
            nMontoNeto = Convert.ToDecimal(nCapital + nInteres + nIntComp + nMora + nOtros);
            idAsesor = Convert.ToInt32(dtCredito.Rows[0]["idUsuario"]);
            dFecDesembolso = Convert.ToDateTime(dtCredito.Rows[0]["dFechaDesembolso"]);

            //Datos genericos de créditos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtMoneda.Text = dtCredito.Rows[0]["cMoneda"].ToString();
            this.txtTotalCuotas.Text = dtCredito.Rows[0]["nCuotas"].ToString();
            this.txtDiasAtrasoVencido.Text = dtCredito.Rows[0]["nAtraso"].ToString();
            this.txtFechaDesembolso.Text = Convert.ToDateTime(dtCredito.Rows[0]["dFechaDesembolso"]).ToString("dd/MM/yyyy");
            this.txtMontoDesembolsado.Text = Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"]).ToString("#,0.00");
            this.txtFecVenc.Text = Convert.ToDateTime(dtCredito.Rows[0]["dFechaCulminacion"]).ToString("dd/MM/yyyy");
            this.txtPrimeraCuotaPend.Text = PlanPago.nPrimeraCuotaPen(dtPlanPago).ToString();
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();


            txtCapital.Text = String.Format("{0:#,0.00}", nCapital);
            txtInteres.Text = String.Format("{0:#,0.00}", nInteres);
            txtIntComp.Text = String.Format("{0:#,0.00}", nIntComp);
            txtMoraCredito.Text = String.Format("{0:#,0.00}", nMora);
            txtOtros.Text = String.Format("{0:#,0.00}", nOtros);
            txtMontoNeto.Text = String.Format("{0:#,0.00}", nMontoNeto);

            txtTotalAPagar.Text = CalcularImpuestosYRedondeo();


            //Dar formato a Detalles de cuenta
            txtCapital.TextAlign = HorizontalAlignment.Right;
            txtInteres.TextAlign = HorizontalAlignment.Right;
            txtIntComp.TextAlign = HorizontalAlignment.Right;
            txtMoraCredito.TextAlign = HorizontalAlignment.Right;
            txtOtros.TextAlign = HorizontalAlignment.Right;
            txtMontoNeto.TextAlign = HorizontalAlignment.Right;
            txtTotalAPagar.TextAlign = HorizontalAlignment.Right;

            txtImpuestos.TextAlign = HorizontalAlignment.Right;
            txtRedondeo.TextAlign = HorizontalAlignment.Right;

            //Asignando DataBinding
            if (txtTasaInteres.DataBindings.Count == 0)
            {
                txtTasaInteres.DataBindings.Add("Text", dtCredito, "nTasaCompensatoria");
                txtTasaMoratoria.DataBindings.Add("Text", dtCredito, "nTasaMoratoria");
                txtDiasAtraso.DataBindings.Add("Text", dtCredito, "nAtraso");
                txtProducto.DataBindings.Add("Text", dtCredito, "cProducto");
                txtMoneda.DataBindings.Add("Text", dtCredito, "cMoneda");
                txtMoneda.DataBindings.Add("Tag", dtCredito, "idMoneda");
            }
            else
            {
                txtTasaInteres.DataBindings.Remove(txtTasaInteres.DataBindings["Text"]);
                txtTasaMoratoria.DataBindings.Remove(txtTasaMoratoria.DataBindings["Text"]);
                txtDiasAtraso.DataBindings.Remove(txtDiasAtraso.DataBindings["Text"]);
                txtProducto.DataBindings.Remove(txtProducto.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Tag"]);
            }

            //Grupo Otros
            txtTasaInteres.TextAlign = HorizontalAlignment.Right;
            txtTasaMoratoria.TextAlign = HorizontalAlignment.Right;
            txtDiasAtraso.TextAlign = HorizontalAlignment.Right;
            txtProducto.TextAlign = HorizontalAlignment.Right;
            txtMoneda.TextAlign = HorizontalAlignment.Right;

            cboTipoPago.SelectedValue = 1;

            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtTotalAPagar.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }
            conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtTotalAPagar.Text.Trim());
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();

            conDatosRepro.cargarComponentes(nNumCredito, true, false);
        }
        private void CargaDatos()
        {
            nNumCredito = this.conBusCuentaCli.nValBusqueda;
            if (nNumCredito <= 0)
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }

            if (this.conBusCuentaCli.txtNroBusqueda.Text.Trim() == "")
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }

            this.btnGrabar.Enabled = true;
            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);

            //Valida Impresión de calendario por cambio de tea - ley 31143
            DataTable dtValidacion = Credito.CNValidaImpresionPendienteCalendario(nNumCredito);
            if (dtValidacion.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtValidacion.Rows[0]["nRespuesta"]) == 1)
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cRespuesta"].ToString(), "Impresión de Cronograma de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //Validar que no exista una solicitud pendiente o aprobada

            DataTable SolicDuplicada = SolicCondonacion.DatosSolicCond(conBusCuentaCli.nIdCliente, Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                return;
            }

            if (this.verificarSolicitudAmpliacion(nNumCredito))
            {
                anularCancelacionAnticipada();
                return;
            }

            //Rellenar Detalles de saldo de Deuda
            nCapital = Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nCapitalPagado"].ToString());
            nInteres = Convert.ToDecimal(dtCredito.Rows[0]["nInteresDia"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nInteresPagado"].ToString());
            nIntComp = Convert.ToDecimal(dtCredito.Rows[0]["nInteresComp"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nInteresCompPago"].ToString());
            nMora = Convert.ToDecimal(dtCredito.Rows[0]["nMonSalMora"].ToString());
            nOtros = Convert.ToDecimal(dtCredito.Rows[0]["nOtrosGenerado"].ToString()) - Convert.ToDecimal(dtCredito.Rows[0]["nOtrosPagado"].ToString());
            nMontoNeto = Convert.ToDecimal(nCapital + nInteres + nIntComp + nMora + nOtros);
            idAsesor = Convert.ToInt32(dtCredito.Rows[0]["idUsuario"]);
            dFecDesembolso = Convert.ToDateTime(dtCredito.Rows[0]["dFechaDesembolso"]);

            //Datos genericos de créditos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtMoneda.Text = dtCredito.Rows[0]["cMoneda"].ToString();
            this.txtTotalCuotas.Text = dtCredito.Rows[0]["nCuotas"].ToString();
            this.txtDiasAtrasoVencido.Text = dtCredito.Rows[0]["nAtraso"].ToString();
            this.txtFechaDesembolso.Text = Convert.ToDateTime(dtCredito.Rows[0]["dFechaDesembolso"]).ToString("dd/MM/yyyy");
            this.txtMontoDesembolsado.Text = Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"]).ToString("#,0.00");
            this.txtFecVenc.Text = Convert.ToDateTime(dtCredito.Rows[0]["dFechaCulminacion"]).ToString("dd/MM/yyyy");
            this.txtPrimeraCuotaPend.Text = PlanPago.nPrimeraCuotaPen(dtPlanPago).ToString();
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();


            txtCapital.Text = String.Format("{0:#,0.00}", nCapital);
            txtInteres.Text = String.Format("{0:#,0.00}", nInteres);
            txtIntComp.Text = String.Format("{0:#,0.00}", nIntComp);
            txtMoraCredito.Text = String.Format("{0:#,0.00}", nMora);
            txtOtros.Text = String.Format("{0:#,0.00}", nOtros);
            txtMontoNeto.Text = String.Format("{0:#,0.00}", nMontoNeto);

            txtTotalAPagar.Text = CalcularImpuestosYRedondeo();


            //Dar formato a Detalles de cuenta
            txtCapital.TextAlign = HorizontalAlignment.Right;
            txtInteres.TextAlign = HorizontalAlignment.Right;
            txtIntComp.TextAlign = HorizontalAlignment.Right;
            txtMoraCredito.TextAlign = HorizontalAlignment.Right;
            txtOtros.TextAlign = HorizontalAlignment.Right;
            txtMontoNeto.TextAlign = HorizontalAlignment.Right;
            txtTotalAPagar.TextAlign = HorizontalAlignment.Right;

            txtImpuestos.TextAlign = HorizontalAlignment.Right;
            txtRedondeo.TextAlign = HorizontalAlignment.Right;

            //Asignando DataBinding
            if (txtTasaInteres.DataBindings.Count == 0)
            {
                txtTasaInteres.DataBindings.Add("Text", dtCredito, "nTasaCompensatoria");
                txtTasaMoratoria.DataBindings.Add("Text", dtCredito, "nTasaMoratoria");
                txtDiasAtraso.DataBindings.Add("Text", dtCredito, "nAtraso");
                txtProducto.DataBindings.Add("Text", dtCredito, "cProducto");
                txtMoneda.DataBindings.Add("Text", dtCredito, "cMoneda");
                txtMoneda.DataBindings.Add("Tag", dtCredito, "idMoneda");
            }
            else
            {
                txtTasaInteres.DataBindings.Remove(txtTasaInteres.DataBindings["Text"]);
                txtTasaMoratoria.DataBindings.Remove(txtTasaMoratoria.DataBindings["Text"]);
                txtDiasAtraso.DataBindings.Remove(txtDiasAtraso.DataBindings["Text"]);
                txtProducto.DataBindings.Remove(txtProducto.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Tag"]);
            }

            //Grupo Otros
            txtTasaInteres.TextAlign = HorizontalAlignment.Right;
            txtTasaMoratoria.TextAlign = HorizontalAlignment.Right;
            txtDiasAtraso.TextAlign = HorizontalAlignment.Right;
            txtProducto.TextAlign = HorizontalAlignment.Right;
            txtMoneda.TextAlign = HorizontalAlignment.Right;

            cboTipoPago.SelectedValue = 1;

            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtTotalAPagar.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }
            conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtTotalAPagar.Text.Trim());
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();

            conDatosRepro.cargarComponentes(nNumCredito, true, false);
        }

        private string CalcularImpuestosYRedondeo()
        {
            Decimal nMonPago = (Convert.ToDecimal (this.txtMontoNeto.Text));
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()));
            Decimal nMonFavCli = 0.00m;
            Decimal nMonRedBcr = 0m;

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
            {
                nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(this.txtMoneda.Tag), true, true);
            }
            else
            {
                nMonRedBcr = (nMonPago + nITF);
            }
            this.txtRedondeo.Text = String.Format("{0:#,0.00}", Math.Round(nMonFavCli, 2));
            this.txtImpuestos.Text = String.Format("{0:#,0.00}", Math.Round(nITF, 2));
            return String.Format("{0:#,0.00}", nMonRedBcr);
        }

        private void LimpiarDatos()
        {
            //Datos del cliente
            conBusCuentaCli.txtCodIns.Text = string.Empty;
            conBusCuentaCli.txtCodAge.Text = string.Empty;
            conBusCuentaCli.txtCodMod.Text = string.Empty;
            conBusCuentaCli.txtCodMon.Text = string.Empty;
            conBusCuentaCli.txtNroBusqueda.Text = string.Empty;

            conBusCuentaCli.txtCodCli.Text = string.Empty;

            conBusCuentaCli.txtNroDoc.Text = string.Empty;
            conBusCuentaCli.txtEstado.Text = string.Empty;

            conBusCuentaCli.txtNombreCli.Text = string.Empty;

            //Motivo de la cancelación
            cboMotCancelacion.SelectedIndex = -1;
            txtDetMotCanc.Text = string.Empty;

            cboTipoPago.SelectedIndex = -1;
            //   cboMotivoOperacion.SelectedIndex = -1;
            conPagoBcos.Visible = false;

            //Datos del crédito
            txtMoneda.Text = String.Empty;
            txtTotalCuotas.Text = String.Empty;
            txtDiasAtrasoVencido.Text = String.Empty;
            txtFechaDesembolso.Text = String.Empty;
            txtMontoDesembolsado.Text = String.Empty;
            txtFecVenc.Text = String.Empty;
            txtPrimeraCuotaPend.Text = String.Empty;
            txtNumCuotasVencidas.Text = String.Empty;
            txtNumCuotasPendientes.Text = String.Empty;


            //Detalles Deuda a la Fecha
            txtCapital.Text = string.Empty;
            txtInteres.Text = string.Empty;
            txtIntComp.Text = string.Empty;
            txtMoraCredito.Text = string.Empty;
            txtOtros.Text = string.Empty;

            txtMontoNeto.Text = string.Empty;
            txtImpuestos.Text = string.Empty;
            txtRedondeo.Text = string.Empty;
            txtTotalAPagar.Text = string.Empty;

            //Detalles otros
            txtTasaInteres.Text = string.Empty;
            txtTasaMoratoria.Text = string.Empty;
            txtDiasAtraso.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtMoneda.Text = string.Empty;


            //limpiando datos del pagador
            conDatPerReaOperac.txtDocIdePerson.Text = string.Empty;
            conDatPerReaOperac.txtNombrePerson.Text = string.Empty;
            conDatPerReaOperac.txtDireccPerson.Text = string.Empty;

            conCalcVuelto.limpiar();

            btnGrabar.Enabled = false;

            conDatosRepro.limpiarDatos();
        }

        private bool ValidarCampos()
        {
            bool ltieneErrores = false;

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                MessageBox.Show("No ha seleccionado una cuenta para realizar la CANCELACIÓN ANTICIPADA", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el DOCUMENTO DE IDENTIDAD de la persona que está pagando la CANCELACIÓN ANTICIPADA", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDocIdePerson.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el NOMBRE de la persona que está pagando la CANCELACIÓN ANTICIPADA", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtNombrePerson.Focus();
                return true;
            }
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar la DIRECCIÓN de la persona que está pagando la CANCELACIÓN ANTICIPADA", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conDatPerReaOperac.txtDireccPerson.Focus();
                return true;
            }

            if (cboMotCancelacion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el MOTIVO de la CANCELACIÓN ANTICIPADA.", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotCancelacion.Focus();
                return true;
            }

            if (string.IsNullOrEmpty(txtDetMotCanc.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el DETALLE DEL MOTIVO de la CANCELACIÓN ANTICIPADA", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDetMotCanc.Focus();
                return true;
            }

            if (cboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el TIPO DE PAGO de la CANCELACIÓN ANTICIPADA.", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoPago.Focus();
                return true;
            }

            if (cboMotivoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el MOTIVO DE LA OPERACIÓN de la CANCELACIÓN ANTICIPADA.", "Cancelación Anticipada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMotivoOperacion.Focus();
                return true;
            }

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
            {
                if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text.Trim()))
                {
                    MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return true;
                }
                if (conCalcVuelto.txtMonEfectivo.nDecValor < Convert.ToDecimal(txtTotalAPagar.Text))
                {
                    MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return true;
                }
            }

            return ltieneErrores;
        }

        public void EmitirVoucher(DataTable dtDatosCobro, int idKardex)
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

            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();

        }

        private void ImprimirConstanciaCancelacion()
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("idCuenta", nNumCredito.ToString(), false));
            paramlist.Add(new ReportParameter("dFecSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("dFecDesembolso", dFecDesembolso.Date.ToString(), false));
            paramlist.Add(new ReportParameter("idCli", conBusCuentaCli.nIdCliente.ToString(), false));
            paramlist.Add(new ReportParameter("cNombre", conBusCuentaCli.txtNombreCli.Text, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            string reportpath = "RptConstanciaCancelacionCre.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void HabilitarControles(bool lHabil)
        {
            conBusCuentaCli.Enabled = lHabil;
            conDatPerReaOperac.Enabled = lHabil;
            grbMotivoOpe.Enabled = lHabil;
            cboTipoPago.Enabled = lHabil;
            btnEnviar.Enabled = lHabil;
            btnGrabar.Enabled = lHabil;
            btnEnviar.Enabled = lHabil;
            conPagoBcos.Enabled = lHabil;
            cboMotCancelacion.Enabled = lHabil;
            conCalcVuelto.Enabled = lHabil;
            if (bVieneCobro)
            {
                btnCancelar.Enabled = false;
            }
            else
            {
                btnCancelar.Enabled = true;
            }
            btnSalir.Enabled = true;
        }

        private bool verificarSolicitudAmpliacion(int idCuenta)
        {
            bool lRespuesta = false;
            DataTable dtRespuestaServidor = (new CRE.CapaNegocio.clsCNCredito()).ADBuscarSolicitudAmpliacion(idCuenta);

            if (dtRespuestaServidor.Rows.Count > 0)
            {
                string cMensaje = string.Empty;
                if (Convert.ToBoolean(dtRespuestaServidor.Rows[0]["lGrupal"]))
                {
                    cMensaje = "Se encontró una solicitud de ampliación grupal. \n\n"+
                        "Grupo Solidario: " + Convert.ToString(dtRespuestaServidor.Rows[0]["cGrupoSolidario"]) + "\n" +
                        "Solicitud Nro: " + Convert.ToString(dtRespuestaServidor.Rows[0]["idSolicitud"]) + "\n"+
                        "Estado: " + Convert.ToString(dtRespuestaServidor.Rows[0]["cEstado"]) + "\n"+
                        "\nADVERTENCIA: Si cancela la cuenta se anulará la solicitud de ampliación de TODO EL GRUPO.\n¿Está seguro de continuar? \n";
                }
                else
                {
                    cMensaje = "Se encontró una solicitud de ampliación. \n\tSolicitud Nro: " +
                        Convert.ToString(dtRespuestaServidor.Rows[0]["idSolicitud"]) + " - Estado: " +
                        Convert.ToString(dtRespuestaServidor.Rows[0]["cEstado"]) +
                        "\nADVERTENCIA: Si cancela la cuenta se anulará la solicitud de ampliación del cliente.\n¿Está seguro de continuar? \n";

                }

                DialogResult drResultado = MessageBox.Show(cMensaje, "Solicitud de ampliación pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                lRespuesta = (drResultado == DialogResult.No) ? true : false;
            }
            return lRespuesta;
        }

        private void anularCancelacionAnticipada()
        {
            HabilitarControles(false);
            LimpiarDatos();

            //Quitando Bindings
            if (txtTasaInteres.DataBindings.Count > 0)
            {
                txtTasaInteres.DataBindings.Remove(txtTasaInteres.DataBindings["Text"]);
                txtTasaMoratoria.DataBindings.Remove(txtTasaMoratoria.DataBindings["Text"]);
                txtDiasAtraso.DataBindings.Remove(txtDiasAtraso.DataBindings["Text"]);
                txtProducto.DataBindings.Remove(txtProducto.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Text"]);
                txtMoneda.DataBindings.Remove(txtMoneda.DataBindings["Tag"]);
            }

            conBusCuentaCli.LiberarCuenta();
            conBusCuentaCli.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
            cboMotCancelacion.SelectedIndex = -1;
        }

        #endregion


        #region CargaAutomaticaCobs

        private void cargaCondonacionesEjecutadas()
        {
            clsCNCondonacion SolicDuplicada = new clsCNCondonacion();
            int idTipoOperacionCOBs = 7;
            DataTable dtRes = SolicDuplicada.CNBuscarCondonacionesEjecutadasXIdCuenta(conBusCuentaCli.nValBusqueda, idTipoOperacionCOBs, 0);
            if (dtRes.Rows.Count > 0)
            {
                MessageBox.Show("El crédito con número de cuenta: " + conBusCuentaCli.nValBusqueda.ToString()
                                + ", tiene una solicitud de condonación que ha sido ejecutada, SE CARGARÁ LA INFORMACIÓN DE LAS COBS VINCULADAS A ESTA CUENTA"
                , "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtCobs = dtRes;
                this.cargaMontoCobsEnPago();

                cboTipoPago.Enabled = false;
            }
        }

        public void cargaMontoCobsEnPago()
        {
            decimal nTotalCobs = 0,
                    nMontoAPagar = 0,
                    nMontoItf = 0;

            foreach (DataRow item in this.dtCobs.Rows)
            {
                nTotalCobs += Convert.ToDecimal(item["nMonto"]);
            }

            nMontoItf = Convert.ToDecimal(dtCobs.Rows[0]["nMontoITF"]);
            nMontoAPagar = Convert.ToDecimal(dtCobs.Rows[0]["nMontoAPagar"]);

            conCalcVuelto.Enabled = false;
            conCalcVuelto.txtMonEfectivo.Text = (nMontoItf + nMontoAPagar).ToString("N2");
            
        }

        public string ObtenerCobsXml()
        {
            DataSet ds = new DataSet("xmlCobs");

            if (dtCobs == null)
            {
                return "<xmlCobs/>";
            }

            if (dtCobs.DataSet == null)
            {
                ds.Tables.Add(dtCobs);
            }
            else
            {
                ds = dtCobs.DataSet;
            }

            return ds.GetXml();
        }

        #endregion

        private void btnSolEjecutadas_Click(object sender, EventArgs e)
        {
            conBusCuentaCli.LiberarCuenta();
            frmBandejaCobroCreditos bandeja = new frmBandejaCobroCreditos();
            bandeja.ShowDialog();
            conBusCuentaCli.txtNroBusqueda.Text = bandeja.getCuentaSelect().idCuenta.ToString();
            conBusCuentaCli.asignarCuenta(bandeja.getCuentaSelect().idCuenta);
            idTipoOperacionCOBs = bandeja.getCuentaSelect().idTipoOperacion;
            idSolicitud = bandeja.getCuentaSelect().idSolicitud;
            CargaDatos();
            if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
            {
                HabilitarControles(true);
                conDatPerReaOperac.Focus();
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
            }
            else
            {
                conBusCuentaCli.txtNroBusqueda.Enabled = true;
                conBusCuentaCli.btnBusCliente1.Enabled = true;
            }
            gastosJudiciales();
            this.cargaCondonacionesEjecutadas();
            if (this.dtCobs == null)
            {
                this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                this.cargaCondonacionesEjecutadas();
            }
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            frmExtornaOpe frmExtorno = new frmExtornaOpe(nIdKardexExtorno);

            frmExtorno.ShowDialog();
        }

        private void btnProyeccion_Click(object sender, EventArgs e)
        {
            //si hay datos 
            if (dtCredito.Rows.Count > 0)
            {
                ////obtengo numero de cuenta
                int nNumCuenta = Convert.ToInt32(dtCredito.AsEnumerable().First()["idCuenta"]);

                GEN.CapaNegocio.clsCNRetornaNumCuenta RetornaNumCuenta = new GEN.CapaNegocio.clsCNRetornaNumCuenta();
                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(nNumCuenta);
                Nullable<int> nidUserBloqueo;
                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];

                if (nidUserBloqueo != 0)
                {
                    RetornaNumCuenta.CNDesbloqueaCuenta(nNumCuenta, 1);

                }
       
                //si hay dato llama al formulario frmProyeCancel
                frmProyeCancel frmcancelAnti = new frmProyeCancel(conBusCuentaCli.nIdCliente, this, conBusCuentaCli.nValBusqueda, conBusCuentaCli.txtCodCli.Text, conBusCuentaCli.txtNroDoc.Text, conBusCuentaCli.txtNombreCli.Text);

                frmcancelAnti.ShowDialog();

            }
        
         
        }
         
        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }
    }
}
