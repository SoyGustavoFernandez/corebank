using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.PrintHelper;
using GEN.Funciones;
using System.Drawing.Printing;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using SPL.Presentacion;
using CAJ.CapaNegocio;
using ADM.CapaNegocio;
using GEN.BotonesBase;
using CLI.Presentacion;
using CLI.CapaNegocio;
using RSG.CapaNegocio;
//using GEN.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCobroCreditos : frmBase
    {

        #region Variables Globales
        clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
        clsCNProgFidelizacionClie cnProgFidelizacionClie = new clsCNProgFidelizacionClie();
        clsCNVisita cnVisita;
        public const int idTipoOperacion = 2;
        public DataTable dtCredito = new DataTable("dtCredito");
        public DataTable dtPlanPago = new DataTable("dtPlanPago");
        public DataTable dtOrdenPrelacion = new DataTable("dtOrdenPrelacion");
        public string pcTipoBusqueda;
        public string pnEstadoCredito;
        string cEstadoForm = "E";
        decimal nITFNormal = 0;
        bool lCargoPlanPagos = false;
        bool lCargoKardexPagos = false;
        bool lAdelantoCuota = false;
        private int idSolicitudHojaTramite;
        clsFunUtiles objFunciones = new clsFunUtiles();
        clsCNCredito cnCredito = new clsCNCredito();
        clsCNCliente cliente = new clsCNCliente();

        private const int idTipoOpeRegimenReforzado = 169;

        private DataTable dtCobs;

        int idTipoOperacionCOBs = 7;
        int idSolicitud = 0;
        DataTable dtDetalleDesc = new DataTable();

        decimal nMontoDescBono = 0;
        int idConceptoReciboDesc = 0;
        bool lInvalidado = true;
        DataTable dtRegSolHojaTramite;
        int idTipoOperacionAde = 0;  
        int idKardexExtorno = 0;
        #endregion

        #region Eventos

        private void frmCobroCreditos_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            conCalcVuelto.Enabled = false;
            lblSegmento.Text = string.Empty;
            lblCalifica.Text = string.Empty;
            btnProgFidelizacion.Visible = false;
            btnReferidos.Enabled = false;
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            cargarDatosCuenta();
            ActivarTitular();
            //jcasas
            GEN.CapaNegocio.clsCNRetornaNumCuenta RetornaAsesor = new GEN.CapaNegocio.clsCNRetornaNumCuenta();
            DataTable dtAsesor = RetornaAsesor.RetornaAsesorCuenta(this.conBusCuentaCli.nValBusqueda);
            if (dtAsesor.Rows.Count>0)
            {
                txtAsesor.Text = dtAsesor.Rows[0][1].ToString();
            }
           
            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgPpg.CellFormatting += dtgPpg_CellFormatting;
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

            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgPpg.CellFormatting += dtgPpg_CellFormatting;

            frmGestionContacto objGC = new frmGestionContacto(this.conBusCuentaCli.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
        }

        }

        public void cargarDatosCuenta()
        {
            CargaDatos();
            if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
            {
                conDatPerReaOperac.Focus();
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;
            }

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                return;
            }
            DataTable dtGastosJudiciales = CNGastosJudiciales.ContarGastosPendientes(Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text.Trim()));
            if (dtGastosJudiciales.Rows.Count > 0 && Convert.ToInt32(dtGastosJudiciales.Rows[0]["nContador"]) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("La cuenta tiene gastos judiciales pendientes que no fueron cargados, desea continuar?", "Gastos Judiciales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    LiberarCuenta();
                    LimpiarDatos();
                    btnGrabar.Enabled = false;
                    ProcessTabKey(true);
                    ProcessTabKey(true);
                    ProcessTabKey(true);
                    conDatPerReaOperac.Enabled = true;
                    conBusCuentaCli.Enabled = true;
                    grbBase3.Enabled = true;
                    conBusCuentaCli.txtNroBusqueda.Focus();
                    //Limpiando el ItfNormal (sin redondeo)
                    nITFNormal = 0;
                    conCalcVuelto.Enabled = false;
                    btnPrePago.Enabled = true;
                    cboTipoPago.Enabled = false;
                    cboTipoPago.SelectedValue = 1;
                    conPagoBcos.Visible = false;
                    conPagoBcos.Enabled = true;
                    pnlDatCredito.Enabled = true;
                    lblAlertaCamOrdenPrelacion.Visible = false;
                    return;
                }
            }

            this.cargaCondonacionesEjecutadas();
            if (this.dtCobs == null)
            {
                this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                this.cargaCondonacionesEjecutadas();
            }
        }

        private void dtgPpg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dtgPpg.Columns["nOtros"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            CargaDatos();
            if (!string.IsNullOrEmpty(conBusCuentaCli.txtNroDoc.Text.Trim()))
            {
                conDatPerReaOperac.Focus();
                conDatPerReaOperac.txtDocIdePerson.Text = conBusCuentaCli.txtNroDoc.Text;               
            }

            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                return;
            }

            DataTable dtGastosJudiciales = CNGastosJudiciales.ContarGastosPendientes(Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text.Trim()));
            if (dtGastosJudiciales.Rows.Count > 0 && Convert.ToInt32(dtGastosJudiciales.Rows[0]["nContador"]) > 0)
            {
                DialogResult dialogResult = MessageBox.Show("La cuenta tiene gastos judiciales pendientes que no fueron cargados, desea continuar?", "Gastos Judiciales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    LiberarCuenta();
                    LimpiarDatos();
                    btnGrabar.Enabled = false;
                    ProcessTabKey(true);
                    ProcessTabKey(true);
                    ProcessTabKey(true);
                    conDatPerReaOperac.Enabled = true;
                    conBusCuentaCli.Enabled = true;
                    grbBase3.Enabled = true;
                    conBusCuentaCli.txtNroBusqueda.Focus();
                    //Limpiando el ItfNormal (sin redondeo)
                    nITFNormal = 0;
                    conCalcVuelto.Enabled = false;
                    btnPrePago.Enabled = true;
                    cboTipoPago.Enabled = false;
                    cboTipoPago.SelectedValue = 1;
                    conPagoBcos.Visible = false;
                    conPagoBcos.Enabled = true;
                    pnlDatCredito.Enabled = true;
                    lblAlertaCamOrdenPrelacion.Visible = false;
                    return;
                }
            }

            this.cargaCondonacionesEjecutadas();
            if(this.dtCobs == null)
            {
                this.idTipoOperacionCOBs = Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeAfectaCOB"]);
                this.cargaCondonacionesEjecutadas();
            }
            ActivarTitular();

            //jcasas
            GEN.CapaNegocio.clsCNRetornaNumCuenta RetornaAsesor = new GEN.CapaNegocio.clsCNRetornaNumCuenta();
            DataTable dtAsesor = RetornaAsesor.RetornaAsesorCuenta(this.conBusCuentaCli.nValBusqueda);
            if (dtAsesor.Rows.Count > 0)
            {
                txtAsesor.Text = dtAsesor.Rows[0][1].ToString();
            }

        }

        private void tbpPpg_Enter(object sender, EventArgs e)
        {
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;

            if (nNumCredito <= 0)
            {
                return;
            }

            if (lCargoPlanPagos == true)
            {
                return;
            }

            // Cargar el Plan de Pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable ListPlanPago = PlanPago.CNdtPlanPagPosi(nNumCredito);

            ////========================= Redondeo del Monto A pagar===================================================
            //foreach (DataColumn item in ListPlanPago.Columns)
            //{
            //    item.ReadOnly = false;
            //}

            //for (int i = 0; i < ListPlanPago.Rows.Count; i++)
            //{
            //    ListPlanPago.Rows[i]["nSalTot"] = Math.Round(Convert.ToDecimal (ListPlanPago.Rows[i]["nSalTot"]), 1);
            //}

            //foreach (DataColumn item in ListPlanPago.Columns)
            //{
            //    item.ReadOnly = true;
            //}
            //============================================================================
            dtgPpg.DataSource = ListPlanPago;
            FormatoPlanPagos();

            lCargoPlanPagos = true;
        }

        private void tbpKardex_Enter(object sender, EventArgs e)
        {
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;

            if (nNumCredito <= 0)
            {
                return;
            }

            if (lCargoKardexPagos == true)
            {
                return;
            }

            // cargar el kardex
            clsCNCredito Credito = new clsCNCredito();
            DataTable Listkardex = Credito.CNdtLisKardexCre(nNumCredito);
            dtgKardex.DataSource = Listkardex;
            FormatoKardexpago();

            lCargoKardexPagos = true;
        }

        private void chcPorCuotas_CheckedChanged(object sender, EventArgs e)
        {
            if (cEstadoForm == "C")
            {
                return;
            }            
            this.nudNroCuotas.Enabled = this.chcPorCuotas.Checked;
            this.txtMCMontoNeto.Enabled = !this.chcPorCuotas.Checked;
            this.nudNroCuotas.Focus();

            if (!chcPorCuotas.Checked)
            {
                nudNroCuotas.Value = 0;
            }
        }

        private void nudNroCuotas_ValueChanged(object sender, EventArgs e)
        {
            CalcularPorCuotas();
            this.btnGrabar.Enabled = false;
            pnlTipoPagador.Visible = false;
            ActivarTitular();
        }

        private void txtMCMontoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnGrabar.Enabled = false;
                pnlTipoPagador.Visible = false;
                ActivarTitular();
                if (this.conBusCuentaCli.nValBusqueda <= 0)
                {
                    this.txtMCMontoNeto.Text = "";
                    MessageBox.Show("No se encontró número de cuenta.", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrEmpty(this.txtMCMontoNeto.Text.Trim()))
                {
                    this.btnGrabar.Enabled = false;
                    return;
                }
                this.distribuiyeValores();
                //int nNumCredito = this.conBusCuentaCli.nValBusqueda;
                //clsCNCredito Credito = new clsCNCredito();
                //Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
                //nMonSalCre = Convert.ToDecimal(string.Format("{0:#,0.00}", Convert.ToDecimal(nMonSalCre.ToString())));
                //if (Math.Round(nMonSalCre, 2) < Convert.ToDecimal(this.txtMCMontoNeto.Text))
                //{
                //    MessageBox.Show("Monto a pagar no puede exceder al saldo del crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.btnGrabar.Enabled = false;
                //    return;
                //}

                //CargaDatos();

                //Decimal nMontoaPagar = Convert.ToDecimal(this.txtMCMontoNeto.Text);

                //DataTable dtPlanPagado = new DataTable("dtPlanPagado");
                ////dtPlanPagado = new clsCNPlanPago().dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
                //dtPlanPagado = new clsCNPlanPago().dtCNPagoDistConOrdenPrelacion(dtPlanPago, nMontoaPagar, true, dtOrdenPrelacion);
                //this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
                //this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
                //this.txtMCIntComp.Text = dtPlanPagado.Rows[0]["nIntCompPag"].ToString();
                //this.txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
                //this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();
                //this.txtMCTotalPago.Text = calcularTotal();

                //FormatoMonto();

                //this.btnGrabar.Enabled = true;
                //if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMCTotalPago.Text.Trim()))
                //{
                //    conCalcVuelto.limpiar();
                //}
                //conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMCTotalPago.Text.Trim());
                //conCalcVuelto.Enabled = true;
                //conCalcVuelto.txtMonEfectivo.Focus();
                //conCalcVuelto.txtMonEfectivo.SelectAll();
            }
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.SelectedIndex == -1 || cboTipoPago.SelectedValue is DataRowView)
                return;

            conPagoBcos.LimpiarControles();

            conCalcVuelto.limpiar();

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 4)
            {
                conPagoBcos.Visible = true;
                conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
                conCalcVuelto.txtMonEfectivo.Enabled = false;
            }
            else
            {
                conPagoBcos.Visible = false;
                conCalcVuelto.txtMonEfectivo.Enabled = true;
            }

            txtMCTotalPago.Text = calcularTotal();
            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMCTotalPago.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }
            conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMCTotalPago.Text.Trim());
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();
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

            //VALIDACIÓN DE CONDONACIÓN DE DEUDA

            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text), "Inicio - Registro de Cobranza de Crédito", btnGrabar);

            if (!Validar()) return;

            int idTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue),
              idEntidad = 0,
              idCtaEntidad = 0;
            if (idTipoPago == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(this.txtMoneda.Tag.ToString()), 1, Convert.ToDecimal(txtMCTotalPago.Text)))
                {
                    return;
                }
            }

            //APLICAR REGLA DINAMICA: EL usuario actual del sistema, no puede ser el mismo que pague su crédito
            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            String cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCuentaCli.nIdCliente),
                                                   1, Convert.ToInt32(this.txtMoneda.Tag), Convert.ToInt32(dtCredito.Rows[0]["idProducto"]),
                                                   Convert.ToDecimal(txtMCTotalPago.Text), int.Parse(conBusCuentaCli.txtNroBusqueda.Text), clsVarGlobal.dFecSystem,
                                                   2, 1, clsVarGlobal.User.idUsuario, ref nNivAuto);

            if (!cCumpleReglas.Equals("Cumple"))
            {
                return;
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusCuentaCli.nIdCliente,
                                                                               Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"]),
                                                                               Convert.ToInt32(dtCredito.Rows[0]["idProducto"]),
                                                                               conBusCuentaCli.nValBusqueda,
                                                                               Convert.ToDecimal(txtMCTotalPago.Text));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            btnGrabar.Enabled = false;
            //Filtramos el plan de pagos



            var resultPpg = dtPlanPago.AsEnumerable().Where(x => x.Field<decimal>("nCapitalPagado") +
                                                                 x.Field<decimal>("nInteresPagado") +
                                                                 x.Field<decimal>("nInteresCompPago") +
                                                                 x.Field<decimal>("nMoraPagada") +
                                                                 x.Field<decimal>("nOtrosPagado") != 0);
            if (resultPpg.Any())
            {
                dtPlanPago = resultPpg.CopyToDataTable();
            }

            clsCNPlanPago objCNPlanP = new clsCNPlanPago();
            dtDetalleDesc = objCNPlanP.CNVerificaDatosClienteCampNav(conBusCuentaCli.nIdCliente, conBusCuentaCli.nValBusqueda);

            if (dtDetalleDesc.Rows.Count > 0)
            {
                nMontoDescBono = Convert.ToDecimal(dtDetalleDesc.Rows[0]["dMontoBono"]);
                idConceptoReciboDesc = Convert.ToInt32(dtDetalleDesc.Rows[0]["idConcepto"]);
                string cConcepto = Convert.ToString(dtDetalleDesc.Rows[0]["cConcepto"]);
                lInvalidado = Convert.ToBoolean(dtDetalleDesc.Rows[0]["lInvalidado"]);
                int idCuotaProx = Convert.ToInt32(dtDetalleDesc.Rows[0]["idCuotaProx"]);
                int idCuotaMaxPagado = 0;

                idCuotaMaxPagado = Convert.ToInt32(dtPlanPago.AsEnumerable().Where( item => (
                        item.Field<decimal>("nCapital") +
                        item.Field<decimal>("nInteres") +
                        item.Field<decimal>("nInteresComp") +
                        item.Field<decimal>("nMora") +
                        item.Field<decimal>("nOtros")) ==
                        (item.Field<decimal>("nCapitalPagado") +
                        item.Field<decimal>("nInteresPagado") +
                        item.Field<decimal>("nInteresCompPago") +
                        item.Field<decimal>("nMoraPagada") +
                        item.Field<decimal>("nOtrosPagado"))).Max(item => item["idCuota"]));

                if (idCuotaProx <= 3 && idCuotaMaxPagado >= 3)
                {
                    if(idTipoPago == 1)
                    {
                        MessageBox.Show("La cuenta tiene un descuento de S/ " + nMontoDescBono + " en la 3° cuota por el concepto " + cConcepto + ". \n\nRecuerde realizar la entrega del bono al cliente luego de realizar el cobro y emitido el comprobante de egreso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            DataSet ds = new DataSet("dsPlanPagos");

            dtPlanPago.TableName = "dtPlanPagos";
            ds.Tables.Add(dtPlanPago);

            string xmlPpg = ds.GetXml();//Solo Plan Pagos

            clsCNPlanPago planPago = new clsCNPlanPago();

            DataTable dtDetalleCargaGasto = planPago.DistribuirGastosPagados(dtPlanPago);
            dtDetalleCargaGasto.TableName = "TablaDetalleCargaGasto";
            ds.Tables.Add(dtDetalleCargaGasto);

            //Guardar los Datos de la persona que está pagando la cuota
            {
                DataTable dtPagador = new DataTable("TablaDatosPagador");

                dtPagador.Columns.Add("cNroDNI", typeof(string));
                dtPagador.Columns.Add("cNomCliente", typeof(string));
                dtPagador.Columns.Add("cDireccion", typeof(string));

                DataRow drfila = dtPagador.NewRow();
                drfila["cNroDNI"] = conDatPerReaOperac.txtDocIdePerson.Text;
                drfila["cNomCliente"] = conDatPerReaOperac.txtNombrePerson.Text;
                drfila["cDireccion"] = conDatPerReaOperac.txtDireccPerson.Text;
                dtPagador.Rows.Add(drfila);

                ds.Tables.Add(dtPagador);
            }

            int nNumCredito = this.conBusCuentaCli.nValBusqueda;

            //Validacion de Cuotas Pagadas x Duplicidad
            DataTable dtPlanPagoAct = planPago.CNdtPlanPago(nNumCredito);

            foreach (DataRow item2 in dtPlanPago.Rows)
            {
                if(!dtPlanPagoAct.AsEnumerable().Any(row => row.Field<int>("idCuota") == item2.Field<int>("idCuota")))
                {
                    MessageBox.Show("Se ha detectado que la cuota " + item2["idCuota"].ToString() + " ya ha sido pagada, por favor actualice.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            xmlPpg = ds.GetXml();//Plan Pagos y DetalleCargaGastos en caso se haya realizado pagos
            xmlPpg = GEN.CapaNegocio.clsCNFormatoXML.EncodingXML(xmlPpg);

            ds.Tables.Clear();

            Decimal nMoraPagada = Convert.ToDecimal(this.txtMCMora.Text);
            Decimal nMonRedondeo = Convert.ToDecimal(this.txtRedondeo.Text);
            Decimal nImpuesto = Convert.ToDecimal(this.txtImpuestos.Text);

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

            #region Validacion Umbrales Dolares
            decimal nMontoTotPago = txtMCTotalPago.nDecValor;
            int idMonedaUm = Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"]);
            int idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            int idSubProducto = Convert.ToInt32(dtCredito.Rows[0]["idProducto"]);
            
            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, 2, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 1; //INGRESO

            if (idTipoPago == 1)
                lModificaSaldoLinea = true;

            DataTable TablaUpPpg = planPago.UpCobroPpg(PpgXml: xmlPpg,
                                                        dFecSis: clsVarGlobal.dFecSystem,
                                                        nUsuSis: clsVarGlobal.User.idUsuario,
                                                        nIdAgencia: clsVarGlobal.nIdAgencia,
                                                        nMoraPagada: nMoraPagada,
                                                        idCuenta: nNumCredito,
                                                        idCanal: clsVarGlobal.idCanal,
                                                        nMonRedondeo: nMonRedondeo,
                                                        nImpuesto: nImpuesto,
                                                        nITFNormal: nITFNormal,
                                                        idTipoPago: idTipoPago,
                                                        idEntidad: idEntidad,
                                                        idCtaEntidad: idCtaEntidad,
                                                        cNroTrx: cNroTrx,
                                                        idMotivoOperacion: Convert.ToInt32(cboMotivoOperacion.SelectedValue),
                                                        cXmlCobs: this.ObtenerCobsXml(),
                                                        lModificaSaldoLinea: lModificaSaldoLinea,
                                                        idTipoTransac: idTipoTransac,
                                                        idMoneda: Convert.ToInt32(this.txtMoneda.Tag.ToString()),
                                                        nMontoOpe: Convert.ToDecimal(txtMCTotalPago.Text));

            int nIdKardex,
                nIdKardexCob;
            if (TablaUpPpg.Rows.Count > 0)
            {
                nIdKardex = Convert.ToInt32(TablaUpPpg.Rows[0]["idKardex"]);
                nIdKardexCob = Convert.ToInt32(TablaUpPpg.Rows[0]["idKardexReciboCob"]);

                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show("Cobro satisfactorio con N° de operación: " + nIdKardex.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelar.Enabled = false;

                //Obtiene idestado del crédito despues de la cobranza
                var idEstado = Convert.ToInt32(TablaUpPpg.Rows[0]["idEstado"]);
                var lGarantia = Convert.ToBoolean(TablaUpPpg.Rows[0]["lGarantia"]);
                var lTieneGarAhorro = Convert.ToBoolean(TablaUpPpg.Rows[0]["lTieneGarAhorro"]);

                var dtGarantia = new clsCNGarantia().CNValidaCuentaGarantia(conBusCuentaCli.nValBusqueda);

                if (idEstado == 6 && dtGarantia.Rows.Count > 0 && Convert.ToBoolean(dtGarantia.Rows[0]["lAvisoMinutaGarantia"]))
                {
                    string cAlertaGarantia = Convert.ToString(dtGarantia.Rows[0]["cAlertaGarantia"]);
                    MessageBox.Show(cAlertaGarantia, "ALERTA: VICULADO A GARANTIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (idEstado == 6 && lGarantia && !lTieneGarAhorro)
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

                if(dtDetalleDesc.Rows.Count > 0)
                {
                    if(!lInvalidado)
                    {
                        clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
                        DataTable dtEstadoCred = objCNPlanPago.CNVerificarEstadoCredito(nNumCredito);
                        int idEstadoCred = Convert.ToInt32(dtEstadoCred.Rows[0]["idEstado"]);
                        int idMaxCuotaPagada = Convert.ToInt32(dtEstadoCred.Rows[0]["idCuotaMax"]);
                        if (idEstadoCred == 6)
                        {
                            DataTable dtEstado = objCNPlanPago.CNActualizarEstadoBonoNav(nNumCredito, conBusCuentaCli.nIdCliente, 3);
                            if (dtEstado.Rows.Count > 0)
                            {
                                if(Convert.ToInt32(dtEstado.Rows[0]["nResultado"]) == 1)
                                {
                                    MessageBox.Show("Se ha Invalidado el Bono debido que se cancelo el Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else if (idEstadoCred == 5 && idMaxCuotaPagada >= 3 )
                        {
                            if(idTipoPago == 1)
                            {
                                emitirReciboDescuento(nNumCredito, conBusCuentaCli.nIdCliente, nMontoDescBono, idConceptoReciboDesc, nIdKardex);
                            }
                            else
                            {
                                DataTable dtEstado = objCNPlanPago.CNActualizarEstadoBonoNav(nNumCredito, conBusCuentaCli.nIdCliente, 3);
                                if (dtEstado.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtEstado.Rows[0]["nResultado"]) == 1)
                                    {
                                        MessageBox.Show("Se ha Invalidado el Bono debido al Tipo de Pago con el que se realizó el Cobro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            
                        }
                    }
                }
               

                //---------------------------------------------------------------------------------------
                //Completar el Registro de Hoja Tramite 
                //---------------------------------------------------------------------------------------
                RegHojaTramite(idSolicitudHojaTramite, nIdKardex);    
	
            }
            else
            {
                MessageBox.Show("Ocurrió un problema al realizar el Cobro de Crédito", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            //Emision de Voucher
            ImpresionVoucher(nIdKardex: nIdKardex, idModulo: 1, idTipoOpe: idTipoOperacion, idEstadoKardex: 1,
                                nValRec: conCalcVuelto.txtMonEfectivo.nDecValor,
                                nValdev: conCalcVuelto.txtMonDiferencia.nDecValor,
                                idKardexAd: 0, idTipoImpresion: 1);
            
            idKardexExtorno = nIdKardex; 
            // **************************************************************************
            //Emisión del Voucher de la Cob
            // **************************************************************************
            if (nIdKardexCob != 0)
            {
                foreach (DataRow item in TablaUpPpg.Rows)
                {
                    ActualizaSaldoLinea(clsVarGlobal.User.idUsuario, Convert.ToInt32(this.txtMoneda.Tag), Convert.ToInt32(item["idTipoOperacion"]) == 5 ? 1 : 2, Convert.ToDecimal(item["nMontoPag"]));
                }
                foreach (DataRow item in TablaUpPpg.Rows)
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
            ds.Dispose();
            cEstadoForm = "E";
            this.conBusCuentaCli.LiberarCuenta();
            pnlDatCredito.Enabled = true;
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            conBusCuentaCli.Enabled = false;
            btnGrabar.Enabled = false;
            btnProcesar.Enabled = false;
            conDatPerReaOperac.Enabled = false;
            cboTipoPago.Enabled = false;
            conPagoBcos.Enabled = false;
            btnCancelar.Enabled = true;
            btnPrePago.Enabled = false;
            conCalcVuelto.Enabled = false;

            rblTitular.Enabled = false;
            rblConyugue.Enabled = false;
            rblOtros.Enabled = false;
            /*========================================================================================
             * REGISTRO DE RASTREO
             ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(conBusCuentaCli.nIdCliente), Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text), "Fin - Registro de Cobranza de Crédito", btnGrabar);

            lCargoPlanPagos = false;
            lCargoKardexPagos = false;
            btnExtorno.Enabled = true;
            btnCancelarCred1.Enabled = false;

            EncuestaExperienciaCliente();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarCobro();
            rblTitular.Checked = false;
            rblTitular.Enabled = false;
            rblConyugue.Checked = false;
            rblConyugue.Enabled = false;
            rblOtros.Checked = false;
            rblOtros.Enabled = false;
            chbCartaPoder.Checked = false;
            chbCartaPoder.Enabled = false;
            pnlTipoPagador.Visible = false;
            btnProcesar.Enabled = false;
            txtAsesor.Text = ""; 
            btnExtorno.Enabled = false;
            ActivarTitular();
            lblSegmento.Text = string.Empty;
            lblCalifica.Text = string.Empty;
            btnProgFidelizacion.Visible = false;
            btnReferidos.Enabled = false;
        }
           public void btnLimpiarCobro() 
        {
            cancelarCobro();
            rblTitular.Checked = false;
            rblTitular.Enabled = false;
            rblConyugue.Checked = false;
            rblConyugue.Enabled = false;
            rblOtros.Checked = false;
            rblOtros.Enabled = false;
            chbCartaPoder.Checked = false;
            chbCartaPoder.Enabled = false;
            pnlTipoPagador.Visible = false;
            btnProcesar.Enabled = false;
            txtAsesor.Text = ""; 
            ActivarTitular();
            lblSegmento.Text = string.Empty;
            lblCalifica.Text = string.Empty;
            btnProgFidelizacion.Visible = false;
            btnReferidos.Enabled = false;
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            this.Dispose();
        }

        private void frmCobroCreditos_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void btnPrePago_Click(object sender, EventArgs e)
        {
            int pnIdNumCuenta = conBusCuentaCli.nValBusqueda;
            LiberarCuenta();
            conBusCuentaCli.nValBusqueda = pnIdNumCuenta;

            cEstadoForm = "E";
            pnlDatCredito.Enabled = true;
            grbBase2.Enabled = false;
            grbBase3.Enabled = false;
            conBusCuentaCli.Enabled = false;
            btnGrabar.Enabled = false;
            conDatPerReaOperac.Enabled = false;
            cboTipoPago.Enabled = false;
            conPagoBcos.Enabled = false;
            btnCancelar.Enabled = true;
            btnPrePago.Enabled = false;
            conCalcVuelto.Enabled = false;


            if (dtCredito.Rows.Count > 0)
            {
                int nNumCuenta = Convert.ToInt32(dtCredito.AsEnumerable().First()["idCuenta"]);
                frmPrePago frmPrePago = new frmPrePago(nNumCuenta);
                frmPrePago.objFrmSemaforo = this.objFrmSemaforo;
                frmPrePago.ShowDialog();
            }
            else
            {
                frmPrePago frmPrePago = new frmPrePago();
                frmPrePago.objFrmSemaforo = this.objFrmSemaforo;
                frmPrePago.ShowDialog();
            }

        }

        #endregion

        #region Metodos

        private void ObtenerSegmentoCliente(int idCliente)
        {
            string cSegmento = cliente.CNObtenerSegmentoCliente(idCliente);
            lblSegmento.ForeColor = Color.Navy;
            lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Regular);
            lblSegmento.Text = cSegmento;

            //Valida si existe la variable
            bool lExiste = clsVarApl.dicVarGen.ContainsKey("cSegmentoColorVerde");
            if (lExiste)
            {
                //Obtiene el segmento con letra verde
                string cSegmentoColorVerde = clsVarApl.dicVarGen["cSegmentoColorVerde"];
                if (cSegmentoColorVerde.ToUpper() == cSegmento.ToUpper())
                {
                    lblSegmento.ForeColor = Color.Green;
                    lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Bold);
                }
            }
        }

        private void ObtenerCalificacionCliente(int idCliente)
        {
            string cCalificacion = cliente.CNObtenerCalificacionCliente(idCliente);
            lblCalifica.Text = cCalificacion;
        }

        public frmCobroCreditos()
        {
            InitializeComponent();
            this.conDatPerReaOperac.lMostrarMsjeJuridico = false;

            this.conBusCuentaCli.cTipoBusqueda = "C";
            this.conBusCuentaCli.cEstado = "[5]";

            pcTipoBusqueda = this.conBusCuentaCli.cTipoBusqueda;
            pnEstadoCredito = this.conBusCuentaCli.cEstado;

            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();

            cboTipoPago.DataSource = dtTipoPago;
            cboTipoPago.ValueMember = dtTipoPago.Columns["idTipoPago"].ToString();
            cboTipoPago.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();

            pnlDatCredito.UseAnimation = false;
            pnlDatCredito.IsExpanded = false;

            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedValue = 5;

            dtCobs = null;
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
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMCTotalPago.Text.ToString()));
            dtTablaParametros.Rows.Add(drfila);
                        
            return dtTablaParametros;
        }

        private void FormatoKardexpago()
        {
            foreach (DataGridViewColumn item in dtgKardex.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgKardex.Columns["NumOrdPag"].Visible = true;
            dtgKardex.Columns["dFechaOpe"].Visible = true;
            dtgKardex.Columns["nAtrasoPago"].Visible = true;
            dtgKardex.Columns["nMontoOperacion"].Visible = true;
            dtgKardex.Columns["nMontoCapital"].Visible = true;
            dtgKardex.Columns["nMontoInteres"].Visible = true;
            dtgKardex.Columns["nMontoIntComp"].Visible = true;
            dtgKardex.Columns["nMontoMora"].Visible = true;
            dtgKardex.Columns["nMontoOtros"].Visible = true;
            dtgKardex.Columns["nSaldoCap"].Visible = true;
            dtgKardex.Columns["cWinUser"].Visible = true;
            dtgKardex.Columns["cNombreAge"].Visible = true;
            dtgKardex.Columns["cTipoOperacion"].Visible = true;
            dtgKardex.Columns["cMotivoOperacion"].Visible = true;
            dtgKardex.Columns["cDesTipoPago"].Visible = true;
            dtgKardex.Columns["idKardex"].Visible = true;
            dtgKardex.Columns["cNomPersOpe"].Visible = true;


            dtgKardex.Columns["NumOrdPag"].HeaderText = "Nro";
            dtgKardex.Columns["dFechaOpe"].HeaderText = "Fech. ope.";
            dtgKardex.Columns["nAtrasoPago"].HeaderText = "Dias atraso";
            dtgKardex.Columns["nMontoOperacion"].HeaderText = "Monto ope.";
            dtgKardex.Columns["nMontoCapital"].HeaderText = "Monto cap.";
            dtgKardex.Columns["nMontoInteres"].HeaderText = "Monto int.";
            dtgKardex.Columns["nMontoIntComp"].HeaderText = "Monto int. comp.";
            dtgKardex.Columns["nMontoMora"].HeaderText = "Monto mora";
            dtgKardex.Columns["nMontoOtros"].HeaderText = "Monto otros";
            dtgKardex.Columns["nSaldoCap"].HeaderText = "Saldo capital";
            dtgKardex.Columns["cWinUser"].HeaderText = "Usuario";
            dtgKardex.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgKardex.Columns["cTipoOperacion"].HeaderText = "Operación";
            dtgKardex.Columns["cMotivoOperacion"].HeaderText = "Mod. operación";
            dtgKardex.Columns["cDesTipoPago"].HeaderText = "Tipo pago";
            dtgKardex.Columns["idKardex"].HeaderText = "Nro. ope.";
            dtgKardex.Columns["cNomPersOpe"].HeaderText = "Persona operación";

            dtgKardex.Columns["NumOrdPag"].DisplayIndex = 0;
            dtgKardex.Columns["idKardex"].DisplayIndex = 1;
            dtgKardex.Columns["cTipoOperacion"].DisplayIndex = 2;
            dtgKardex.Columns["cMotivoOperacion"].DisplayIndex = 3;
            dtgKardex.Columns["dFechaOpe"].DisplayIndex = 4;
            dtgKardex.Columns["nAtrasoPago"].DisplayIndex = 5;
            dtgKardex.Columns["nMontoOperacion"].DisplayIndex = 6;
            dtgKardex.Columns["nMontoCapital"].DisplayIndex = 7;
            dtgKardex.Columns["nMontoInteres"].DisplayIndex = 8;
            dtgKardex.Columns["nMontoIntComp"].DisplayIndex = 9;
            dtgKardex.Columns["nMontoMora"].DisplayIndex = 10;
            dtgKardex.Columns["nMontoOtros"].DisplayIndex = 11;
            dtgKardex.Columns["nSaldoCap"].DisplayIndex = 12;
            dtgKardex.Columns["cNomPersOpe"].DisplayIndex = 13;
            dtgKardex.Columns["cWinUser"].DisplayIndex = 14;
            dtgKardex.Columns["cNombreAge"].DisplayIndex = 15;
            dtgKardex.Columns["cDesTipoPago"].DisplayIndex = 16;

            dtgKardex.Columns["nMontoOperacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoMora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgKardex.Columns["nMontoOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgKardex.Columns["nMontoOperacion"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoMora"].DefaultCellStyle.Format = "#,0.00";
            dtgKardex.Columns["nMontoOtros"].DefaultCellStyle.Format = "#,0.00";
        }

        private void FormatoPlanPagos()
        {
            foreach (DataGridViewColumn item in dtgPpg.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgPpg.Columns["idCuota"].Visible = true;
            dtgPpg.Columns["dFechaProg"].Visible = true;
            dtgPpg.Columns["dFechaPago"].Visible = true;
            dtgPpg.Columns["nAtrasoCuota"].Visible = true;
            dtgPpg.Columns["nNumDiaCuota"].Visible = true;
            dtgPpg.Columns["nMonCuoIni"].Visible = true;
            dtgPpg.Columns["EstadoCuota"].Visible = true;
            dtgPpg.Columns["nCapital"].Visible = true;
            dtgPpg.Columns["nCapitalPagado"].Visible = true;
            dtgPpg.Columns["nSalCap"].Visible = true;
            dtgPpg.Columns["nInteres"].Visible = true;
            dtgPpg.Columns["nInteresPagado"].Visible = true;
            dtgPpg.Columns["nSalInt"].Visible = true;
            dtgPpg.Columns["nInteresComp"].Visible = true;
            dtgPpg.Columns["nInteresCompPago"].Visible = true;
            dtgPpg.Columns["nSalIntComp"].Visible = true;
            dtgPpg.Columns["nMoraGenerado"].Visible = true;
            dtgPpg.Columns["nMoraPagada"].Visible = true;
            dtgPpg.Columns["nSalMor"].Visible = true;
            dtgPpg.Columns["nOtros"].Visible = true;
            dtgPpg.Columns["nOtrosPagado"].Visible = true;
            dtgPpg.Columns["nSalOtr"].Visible = true;
            dtgPpg.Columns["nSalTot"].Visible = true;

            dtgPpg.Columns["idCuota"].HeaderText = "Nro";
            dtgPpg.Columns["dFechaProg"].HeaderText = "Fecha prog.";
            dtgPpg.Columns["dFechaPago"].HeaderText = "Fecha pag.";
            dtgPpg.Columns["nAtrasoCuota"].HeaderText = "Dias atr. cuo.";
            dtgPpg.Columns["nNumDiaCuota"].HeaderText = "Dias cuota";
            dtgPpg.Columns["nMonCuoIni"].HeaderText = "Monto cuota";
            dtgPpg.Columns["EstadoCuota"].HeaderText = "Estado";
            dtgPpg.Columns["nCapital"].HeaderText = "Capital";
            dtgPpg.Columns["nCapitalPagado"].HeaderText = "Cap. pag.";
            dtgPpg.Columns["nSalCap"].HeaderText = "Saldo cap.";
            dtgPpg.Columns["nInteres"].HeaderText = "Int.";
            dtgPpg.Columns["nInteresPagado"].HeaderText = "Int. pag.";
            dtgPpg.Columns["nSalInt"].HeaderText = "Saldo int.";
            dtgPpg.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgPpg.Columns["nInteresCompPago"].HeaderText = "Int. comp. pag.";
            dtgPpg.Columns["nSalIntComp"].HeaderText = "Saldo int. comp.";
            dtgPpg.Columns["nMoraGenerado"].HeaderText = "Mora. gen.";
            dtgPpg.Columns["nMoraPagada"].HeaderText = "Mora. pag.";
            dtgPpg.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgPpg.Columns["nOtros"].HeaderText = "Otros";
            dtgPpg.Columns["nOtrosPagado"].HeaderText = "Otros pag.";
            dtgPpg.Columns["nSalOtr"].HeaderText = "Saldo otros";
            dtgPpg.Columns["nSalTot"].HeaderText = "Saldo total";


            dtgPpg.Columns["idCuota"].DisplayIndex = 0;
            dtgPpg.Columns["dFechaProg"].DisplayIndex = 1;
            dtgPpg.Columns["dFechaPago"].DisplayIndex = 2;
            dtgPpg.Columns["nAtrasoCuota"].DisplayIndex = 3;
            dtgPpg.Columns["nNumDiaCuota"].DisplayIndex = 4;
            dtgPpg.Columns["nMonCuoIni"].DisplayIndex = 5;
            dtgPpg.Columns["EstadoCuota"].DisplayIndex = 6;
            dtgPpg.Columns["nCapital"].DisplayIndex = 7;
            dtgPpg.Columns["nCapitalPagado"].DisplayIndex = 8;
            dtgPpg.Columns["nSalCap"].DisplayIndex = 9;
            dtgPpg.Columns["nInteres"].DisplayIndex = 10;
            dtgPpg.Columns["nInteresPagado"].DisplayIndex = 11;
            dtgPpg.Columns["nSalInt"].DisplayIndex = 12;
            dtgPpg.Columns["nInteresComp"].DisplayIndex = 13;
            dtgPpg.Columns["nInteresCompPago"].DisplayIndex = 14;
            dtgPpg.Columns["nSalIntComp"].DisplayIndex = 15;
            dtgPpg.Columns["nMoraGenerado"].DisplayIndex = 16;
            dtgPpg.Columns["nMoraPagada"].DisplayIndex = 17;
            dtgPpg.Columns["nSalMor"].DisplayIndex = 18;
            dtgPpg.Columns["nOtros"].DisplayIndex = 19;
            dtgPpg.Columns["nOtrosPagado"].DisplayIndex = 20;
            dtgPpg.Columns["nSalOtr"].DisplayIndex = 21;
            dtgPpg.Columns["nSalTot"].DisplayIndex = 22;

            dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalInt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPpg.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgPpg.Columns["nMonCuoIni"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalInt"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalIntComp"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtros"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            dtgPpg.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";
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

            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void CargaDatos()
        {
            int idCondContableNormal = 0;
            int idCondContableVenc = 0;
            if (string.IsNullOrEmpty(conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;
            if (nNumCredito <= 0)
            {
                this.btnGrabar.Enabled = false;
                this.LimpiarDatos();
                return;
            }

            //Valida Impresión de calendario por cambio de tea - ley 31143
            DataTable dtValidacion = cnCredito.CNValidaImpresionPendienteCalendario(nNumCredito);
            if (dtValidacion.Rows.Count>0)
            {
                if (Convert.ToInt32(dtValidacion.Rows[0]["nRespuesta"]) == 1)
                {
                    MessageBox.Show(dtValidacion.Rows[0]["cRespuesta"].ToString(), "Impresión de Cronograma de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //Validar que no exista una solicitud pendiente o aprobada

            DataTable SolicDuplicada = new clsCNCondonacion().DatosSolicCond(conBusCuentaCli.nIdCliente, Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text));
            if (SolicDuplicada.Rows.Count > 0)
            {
                MessageBox.Show("Existe una solicitud vigente de condonación Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                                "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Solicitud de Condonación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
                return;
            }

            clsCNGrupoSolidario objGrupoSol = new clsCNGrupoSolidario();
            DataTable dtDatosGrupoSol = objGrupoSol.obtenerDatosGrupoSolidarioCredito(nNumCredito);
            if(dtDatosGrupoSol.Rows.Count > 0)
            {
                bool lCreditoGruposolidario     = false;
                string cNombreGrupoSolidario    = String.Empty;
                int idGrupoSolidario            = 0;

                lCreditoGruposolidario = Convert.ToBoolean(dtDatosGrupoSol.Rows[0]["lCreditoGruposolidario"]);
                cNombreGrupoSolidario = Convert.ToString(dtDatosGrupoSol.Rows[0]["cNombreGrupoSolidario"]);
                idGrupoSolidario = Convert.ToInt32(dtDatosGrupoSol.Rows[0]["idGrupoSolidario"]);

                if(lCreditoGruposolidario)
                {
                    MessageBox.Show("El Cliente es integrante de un Grupo Solidario / Banca Comunal, realizar el pago desde la opción \"COBRAR CRÉDITO GRUPAL\"\n  - Código de Grupo: " + idGrupoSolidario + "\n  - Nombre de Grupo: "+ cNombreGrupoSolidario +".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (this.verificarSolicitudAmpliacion(nNumCredito))
            {
                cancelarCobro();
                return;
            }

            clsCNCredito Credito = new clsCNCredito();
            dtCredito = Credito.CNdtDataCreditoCobro(nNumCredito);
            dtOrdenPrelacion = cnCredito.ObtenerOrdenPrelacion(nNumCredito, Convert.ToInt32(dtCredito.Rows[0]["idOrdenPrelacion"]));

            idCondContableNormal = Convert.ToInt32(dtCredito.Rows[0]["idCondContableNormal"]);
            idCondContableVenc = Convert.ToInt32(dtCredito.Rows[0]["idCondContableVenc"]);

            this.txtMoneda.Text = dtCredito.Rows[0]["cMoneda"].ToString();
            this.txtMoneda.Tag = dtCredito.Rows[0]["idMoneda"].ToString();
            this.lblTextMoneda.Text = ((int)dtCredito.Rows[0]["idMoneda"]) == 1 ? "S/." : "$";
            this.lblTextMoneda.Visible = true;

            this.txtTotalCuotas.Text = dtCredito.Rows[0]["nCuotas"].ToString();
            this.txtDiasAtrasoVencido.Text = dtCredito.Rows[0]["nAtraso"].ToString();
            this.txtFechaDesembolso.Text = dtCredito.Rows[0]["dFechaDesembolso"].ToString().Substring(0, 10);
            this.txtTotalADevolver.Text = dtCredito.Rows[0]["nMonTotDevolver"].ToString();
            this.txtTasaInteresMensual.Text = dtCredito.Rows[0]["nTasaCompensatoria"].ToString();

            this.txtCPSaldoCancAnt.Text = CalcularSaldoCancAnticipada(dtCredito);

            lblAlertaCamOrdenPrelacion.Visible = (Convert.ToInt32(dtCredito.Rows[0]["idOrdenPrelacion"]) != 1);

            //if (idCondContableNormal == 4 || idCondContableVenc == 4)
            //{
            //    DataTable dtConPago = cnCredito.ValidaPrimerPagoJudicial(nNumCredito);
            //    int idConPago = Convert.ToInt32(dtConPago.Rows[0][0]);
            //    if (idConPago <= 0)
            //    {
            //        MessageBox.Show("El cliente antes de realizar el pago debe apersonarse al área de recuperaciones para negociar su pago.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}

            clsCNPlanPago PlanPago = new clsCNPlanPago();
            dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtPrimeraCuotaPend.Text = PlanPago.nPrimeraCuotaPen(dtPlanPago).ToString();
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();

            DataTable dtDeudaPendiente = new DataTable("dtDeudaPendiente");
            if (dtPlanPago.Rows.Count > 0)
            {
                dtDeudaPendiente = PlanPago.dtCNDeudaPendiente(dtPlanPago, Convert.ToInt32(dtCredito.Rows[0]["nAtraso"]));
                this.txtCPCapital.Text = dtDeudaPendiente.Rows[0]["nCapitalPen"].ToString();
                this.txtCPInteres.Text = dtDeudaPendiente.Rows[0]["nInteresPen"].ToString();
                this.txtCPIntComp.Text = dtDeudaPendiente.Rows[0]["nIntCompPen"].ToString();
                this.txtCPMoraCredito.Text = dtDeudaPendiente.Rows[0]["nMoraPen"].ToString();
                this.txtCPOtros.Text = dtDeudaPendiente.Rows[0]["nOtrosPen"].ToString();
                this.txtCPTotalPendiente.Text = dtDeudaPendiente.Rows[0]["nTotalPen"].ToString();
                this.txtCPSaldoFecha.Text = Credito.nSaldoCredito(dtCredito).ToString();
                this.txtMCMontoNeto.Enabled = true;
                this.cboTipoPago.Enabled = true;

                FormatoDeuda();
            }
            else
            {
                this.txtCPCapital.Text = "0.00";
                this.txtCPInteres.Text = "0.00";
                this.txtCPIntComp.Text = "0.00";
                this.txtCPOtros.Text = "0.00";
                this.txtCPTotalPendiente.Text = "0.00";
                this.txtCPSaldoFecha.Text = "0.00";
                this.txtMCMontoNeto.Enabled = false;
                this.cboTipoPago.Enabled = false;
            }            
            
            this.btnCancelar.Enabled = true;
            this.txtMCMontoNeto.Focus();
            this.btnCancelarCred1.Enabled = true;

            conDatosReprogramacion.cargarComponentes(nNumCredito, true, false);

            // Cargando condonaciones ejecutadas

            //Obtiene el segmento del cliente y calificación
            ObtenerSegmentoCliente(this.conBusCuentaCli.nIdCliente);
            ObtenerCalificacionCliente(this.conBusCuentaCli.nIdCliente);

            btnProgFidelizacion.Visible = true;
            btnReferidos.Enabled = true;

            int idEstado = ObtenerEstadoProgramaFidelizacion(this.conBusCuentaCli.nIdCliente);
            if (idEstado != 0 || lblCalifica.Text == "NO CALIFICA")
            {
                btnProgFidelizacion.Visible = false;                
            }                       
        }

        private void LimpiarDatos()
        {
            cEstadoForm = "C";

            this.txtMoneda.Text = string.Empty;
            this.lblTextMoneda.Text = string.Empty;

            this.txtTotalCuotas.Text = string.Empty;
            this.txtDiasAtrasoVencido.Text = string.Empty;
            this.txtPrimeraCuotaPend.Text = string.Empty;
            this.txtNumCuotasVencidas.Text = string.Empty;
            this.txtNumCuotasPendientes.Text = string.Empty;

            this.txtCPCapital.Text = "0.00";
            this.txtCPInteres.Text = "0.00";
            this.txtCPIntComp.Text = "0.00";
            this.txtCPMoraCredito.Text = "0.00";
            this.txtCPOtros.Text = "0.00";
            this.txtCPTotalPendiente.Text = "0.00";
            this.txtCPSaldoFecha.Text = "0.00";
            this.txtCPSaldoCancAnt.Text = "0.00";

            this.txtMCCapital.Text = "0.00";
            this.txtMCInteres.Text = "0.00";
            this.txtMCIntComp.Text = "0.00";
            this.txtMCMora.Text = "0.00";
            this.txtMCOtros.Text = "0.00";
            this.txtMCMontoNeto.Text = "0.00";
            this.txtMCTotalPago.Text = "0.00";
            this.txtImpuestos.Text = "0.00";
            this.txtRedondeo.Text = "0.00";

            this.txtFechaDesembolso.Text = string.Empty;
            this.txtTotalADevolver.Text = string.Empty;
            this.txtTasaInteresMensual.Text = string.Empty;

            this.chcPorCuotas.Checked = false;
            this.nudNroCuotas.Value = 0;

            //Datos del cliente
            conBusCuentaCli.limpiarControles();

            //Datos del Pagador
            conDatPerReaOperac.txtDocIdePerson.Text = string.Empty;
            conDatPerReaOperac.txtDireccPerson.Text = string.Empty;
            conDatPerReaOperac.txtNombrePerson.Text = string.Empty;

            this.btnGrabar.Enabled = false;
            this.nudNroCuotas.Enabled = false;

            this.dtgPpg.DataSource = string.Empty;
            this.dtgKardex.DataSource = string.Empty;
            lCargoPlanPagos = false;
            lCargoKardexPagos = false;

            cEstadoForm = "E";
            conCalcVuelto.limpiar();
            conDatosReprogramacion.limpiarDatos();
        }

        private void LiberarCuenta()
        {
            this.conBusCuentaCli.LiberarCuenta();
            this.conBusCuentaCli.btnBusCliente1.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Enabled = true;
            this.conBusCuentaCli.txtNroBusqueda.Focus();
            this.conBusCuentaCli.nValBusqueda = 0;
            this.txtMCMontoNeto.Text = "0.00";
            this.txtCPSaldoFecha.Text = "0.00";
            txtAsesor.Text = ""; //jcasas
            lblSegmento.Text = string.Empty;
            lblCalifica.Text = string.Empty;
            btnProgFidelizacion.Visible = false;
            btnReferidos.Enabled = false;
        }

        private void FormatoDeuda()
        {
            this.txtCPCapital.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPCapital.Text));
            this.txtCPInteres.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPInteres.Text));
            this.txtCPIntComp.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPIntComp.Text));
            this.txtCPMoraCredito.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPMoraCredito.Text));
            this.txtCPOtros.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPOtros.Text));

            this.txtCPTotalPendiente.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPTotalPendiente.Text));
            this.txtCPSaldoFecha.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPSaldoFecha.Text));
            this.txtCPSaldoCancAnt.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPSaldoCancAnt.Text));

        }

        private void FormatoMonto()
        {
            this.txtMCCapital.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtMCCapital.Text));
            this.txtMCInteres.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtMCInteres.Text));
            this.txtMCOtros.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtMCOtros.Text));
            this.txtMCTotalPago.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtMCTotalPago.Text));
            this.txtCPSaldoFecha.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(txtCPSaldoFecha.Text));
        }

        private void CalcularPorCuotas()
        {
            if (cEstadoForm == "C")
            {
                return;
            }

            if (this.nudNroCuotas.Value > Convert.ToInt32(this.txtNumCuotasPendientes.Text))
            {
                MessageBox.Show("El número de cuotas a pagar NO puede exceder las cuotas a pagar ", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar.Enabled = false;
                return;
            }

            clsCNPlanPago PlanPago = new clsCNPlanPago();
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;
            dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
            this.txtPrimeraCuotaPend.Text = PlanPago.nPrimeraCuotaPen(dtPlanPago).ToString();
            this.txtNumCuotasVencidas.Text = PlanPago.nCuotasVencidas(dtPlanPago).ToString();
            this.txtNumCuotasPendientes.Text = PlanPago.nNumCuotasPen(dtPlanPago).ToString();

            this.txtMCMontoNeto.Text = PlanPago.nDeuDaCuotas(dtPlanPago, Convert.ToInt32(this.nudNroCuotas.Value)).ToString();

            Decimal nMontoaPagar = Convert.ToDecimal(this.txtMCMontoNeto.Text);
            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            //dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
            dtPlanPagado = new clsCNPlanPago().dtCNPagoDistConOrdenPrelacion(dtPlanPago, nMontoaPagar, true, dtOrdenPrelacion);
            this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
            this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
            this.txtMCIntComp.Text = dtPlanPagado.Rows[0]["nIntCompPag"].ToString();
            this.txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();
            this.txtMCTotalPago.Text = calcularTotal();

            FormatoMonto();
            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMCTotalPago.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }
            conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMCTotalPago.Text.Trim());
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();            
            this.btnProcesar.Enabled = true;
        }

        private string calcularTotal()
        {
            Decimal nMonPago = (Convert.ToDecimal(this.txtMCMontoNeto.Text));// + Convert.ToDecimal (this.txtNumRea3.Text));
            Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nMonPago, 2, Convert.ToInt32(this.txtMoneda.Tag));

            //Asignando el ItfNormal (Sin redondeo)
            nITFNormal = clsVarGlobal.nITF / 100.00m * (decimal)nMonPago;
            nITFNormal = objFunciones.truncarNumero(nITFNormal, 2);

            Decimal nMonFavCli = 0.00m;

            Decimal nMonRedBcr = 0.00m;

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
            {
                nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(this.txtMoneda.Tag), true, true);
            }
            else
            {
                nMonRedBcr = (nMonPago + nITF);
            }
            this.txtRedondeo.Text = Math.Round(nMonFavCli, 2).ToString();
            this.txtImpuestos.Text = Math.Round(nITF, 2).ToString();
            return (nMonRedBcr).ToString();
        }

        private string CalcularSaldoCancAnticipada(DataTable dtCredito)
        {
            //Rellenar Detalles de saldo de Deuda
            decimal nCapital = Convert.ToDecimal(dtCredito.Rows[0]["nCapitalDesembolso"].ToString()) -
                                Convert.ToDecimal(dtCredito.Rows[0]["nCapitalPagado"].ToString());
            decimal nInteres = Convert.ToDecimal(dtCredito.Rows[0]["nInteresDia"].ToString()) -
                                Convert.ToDecimal(dtCredito.Rows[0]["nInteresPagado"].ToString());
            decimal nInteresComp = Convert.ToDecimal(dtCredito.Rows[0]["nInteresComp"].ToString()) -
                                   Convert.ToDecimal(dtCredito.Rows[0]["nInteresCompPago"].ToString());
            decimal nMora = Convert.ToDecimal(dtCredito.Rows[0]["nMonSalMora"].ToString());
            decimal nOtros = Convert.ToDecimal(dtCredito.Rows[0]["nOtrosGenerado"].ToString()) -
                                Convert.ToDecimal(dtCredito.Rows[0]["nOtrosPagado"].ToString());
            decimal nMontoNeto = Convert.ToDecimal(nCapital + nInteres + nInteresComp + nMora + nOtros);


            //Decimal nMonPago = (Convert.ToDecimal (nMontoNeto));
            //Decimal nITF = objFunciones.truncar((Decimal)clsVarGlobal.nITF / 100.00 * nMonPago, 2, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()));
            //Decimal nMonFavCli = 0.00;

            //Decimal nMonRedBcr = objFunciones.redondearBCR((nMonPago + nITF), ref nMonFavCli, Convert.ToInt32(dtCredito.Rows[0]["IdMoneda"].ToString()), true, true);
            return nMontoNeto.ToString("#,0.00");
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNumCuotasPendientes.Text.Trim()))
            {
                MessageBox.Show("El cobro debe corresponder a algún crédito. " + Convert.ToChar(13) +
                                "Busque un crédito e ingrese el monto a pagar", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboTipoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de pago.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(this.conBusCuentaCli.txtNroBusqueda.Text.Trim()))
            {
                this.btnGrabar.Enabled = false;
                return false;
            }

            if (string.IsNullOrEmpty(this.txtMCMontoNeto.Text.Trim()))
            {
                this.btnGrabar.Enabled = false;
                return false;
            }

            if (Convert.ToInt32(cboTipoPago.SelectedValue) == 1)
            {
                if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text.Trim()))
                {
                    MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return false;
                }
                if (conCalcVuelto.txtMonEfectivo.nDecValor < Convert.ToDecimal(txtMCTotalPago.Text))
                {
                    MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción",
                        "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conCalcVuelto.txtMonEfectivo.Focus();
                    conCalcVuelto.txtMonEfectivo.SelectAll();
                    return false;
                }
            }
            if (!DatosPagador())
            {
                return false;
            }
           
            
            if (Convert.ToDecimal(this.txtMCMontoNeto.Text) > 0)
            {
                Decimal nSumMonDistrib = 0;
                if (!string.IsNullOrEmpty(this.txtMCCapital.Text.Trim()))
                    nSumMonDistrib = nSumMonDistrib + Convert.ToDecimal(this.txtMCCapital.Text.Trim());

                if (!string.IsNullOrEmpty(this.txtMCInteres.Text.Trim()))
                    nSumMonDistrib = nSumMonDistrib + Convert.ToDecimal(this.txtMCInteres.Text.Trim());

                if (!string.IsNullOrEmpty(this.txtMCIntComp.Text.Trim()))
                    nSumMonDistrib = nSumMonDistrib + Convert.ToDecimal(this.txtMCIntComp.Text.Trim());

                if (!string.IsNullOrEmpty(this.txtMCOtros.Text.Trim()))
                    nSumMonDistrib = Math.Round(nSumMonDistrib + Convert.ToDecimal(this.txtMCOtros.Text.Trim()), 2);

                if (!string.IsNullOrEmpty(this.txtMCMora.Text.Trim()))
                    nSumMonDistrib = Math.Round(nSumMonDistrib + Convert.ToDecimal(this.txtMCMora.Text.Trim()), 2);

                if (Convert.ToDecimal(this.txtMCMontoNeto.Text) != nSumMonDistrib)
                {
                    this.btnGrabar.Enabled = false;
                    MessageBox.Show("El Monto Distribuido no es igual al monto cobrado. Debe presionar ENTER para distribuir el pago " + nSumMonDistrib.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            Decimal nMonPagado = Convert.ToDecimal(this.txtMCTotalPago.Text);
            if (nMonPagado <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a 0", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            if (cboMotivoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de operación.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //if (lblAlertaCamOrdenPrelacion.Visible && (Convert.ToDecimal(txtCPCapital.Text) <= Convert.ToDecimal(txtMCCapital.Text)))
            //{
            //    MessageBox.Show("El monto a pagar no puede sobre pasar el monto de saldo cápital, El cliente debe comunicarse con la oficina de recuperaciones.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            if (lblAlertaCamOrdenPrelacion.Visible && (Convert.ToDecimal(txtCPCapital.Text) <= Convert.ToDecimal(txtMCCapital.Text) && Convert.ToDecimal(txtMCMontoNeto.Text) != Convert.ToDecimal(txtCPTotalPendiente.Text)))
            {
                MessageBox.Show("El monto a pagar no puede sobre pasar el monto de saldo cápital, El cliente debe comunicarse con la oficina de recuperaciones.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            #region Validar en caso de haber Solicitud de condonación ejecutada
            #endregion

            if (this.dtCobs != null)
            { 
                int idTipoCorr = (dtCobs.Rows[0]["idTipoCorr"] == DBNull.Value)? 0 :Convert.ToInt32(dtCobs.Rows[0]["idTipoCorr"]);
                if (idTipoCorr == TipoCorrespondencia.CancelaCredito
                        && Convert.ToDecimal(txtCPSaldoFecha.Text) != Convert.ToDecimal(txtMCMontoNeto.Text))
                {
                    MessageBox.Show("La condonación de la cuenta corresponde a una cancelación del crédito, sin embargo el Saldo Programado es mayor al Monto neto, esta condonación se debe realizar por Cancelación Anticipada", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }           
            return true;
        }

        private bool ValidarTipoPagador()
        {
            bool lRespuesta = true;
            int docPag = Convert.ToInt32(conDatPerReaOperac.txtDocIdePerson.Text);
            int docCli = Convert.ToInt32(conBusCuentaCli.txtNroDoc.Text);                        

            if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {
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
                        lRespuesta = false;
                    }
                }
                else                
                {
                     if (rblTitular.Checked == true)
                     {
                         MessageBox.Show("El cliente y el Pagador son diferentes, seleccionar correctamente la opción tipo de pagador ", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         rblTitular.Checked = false;
                         lRespuesta = false;
                     }
                     else
                     {
                         if (rblConyugue.Checked == false && rblOtros.Checked == false)
                         {
                             MessageBox.Show("Debe seleccionar al menos una opción", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                  
                             lRespuesta = false;                      
                         }
                     }

                }
                             
            }
            else
            {
                MessageBox.Show("Debe registrar un pagador", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chbCartaPoder.Enabled = false;
                chbCartaPoder.Checked = false;
                rblOtros.Checked = false;
                lRespuesta = false;
                
            }
            return lRespuesta;    
        }


        private bool verificarSolicitudAmpliacion(int idCuenta)
        {
            bool lRespuesta = false;
            DataTable dtRespuestaServidor = (new CRE.CapaNegocio.clsCNCredito()).ADBuscarSolicitudAmpliacion(idCuenta);

            if(dtRespuestaServidor.Rows.Count > 0)
            {
                string cMensaje = string.Empty;
                if (Convert.ToBoolean(dtRespuestaServidor.Rows[0]["lGrupal"]))
                {
                    cMensaje = "Se encontró una solicitud de ampliación grupal. \n\n" +
                        "Grupo Solidario: " + Convert.ToString(dtRespuestaServidor.Rows[0]["cGrupoSolidario"]) + "\n" +
                        "Solicitud Nro: " + Convert.ToString(dtRespuestaServidor.Rows[0]["idSolicitud"]) + "\n" +
                        "Estado: " + Convert.ToString(dtRespuestaServidor.Rows[0]["cEstado"]) + "\n" +
                        "\nADVERTENCIA: Si realiza el COBRO de la cuenta se ANULARÁ la solicitud de ampliación de TODO EL GRUPO.\n¿Está seguro de continuar? \n";
                }
                else
                {
                    cMensaje = "Se encontró una solicitud de ampliación. \n\tSolicitud Nro: " +
                        Convert.ToString(dtRespuestaServidor.Rows[0]["idSolicitud"]) + " - Estado: " +
                        Convert.ToString(dtRespuestaServidor.Rows[0]["cEstado"]) +
                        "\nADVERTENCIA: Si cancela la cuenta se anulará la solicitud de ampliación del cliente.\n¿Está seguro de continuar? \n";

                }

                DialogResult drResultado = MessageBox.Show(cMensaje, "Solicitud de ampliación pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                lRespuesta = (drResultado == DialogResult.No) ? true : false ;
            }
            return lRespuesta;
        }

        public void cancelarCobro()
        {
            LiberarCuenta();
            LimpiarDatos();
            btnGrabar.Enabled = false;
            ProcessTabKey(true);
            ProcessTabKey(true);
            ProcessTabKey(true);
            conDatPerReaOperac.Enabled = true;
            conBusCuentaCli.Enabled = true;
            grbBase3.Enabled = true;
            conBusCuentaCli.txtNroBusqueda.Focus();
            //Limpiando el ItfNormal (sin redondeo)
            nITFNormal = 0;
            conCalcVuelto.Enabled = false;
            btnPrePago.Enabled = true;
            cboTipoPago.Enabled = false;
            cboTipoPago.SelectedValue = 1;
            conPagoBcos.Visible = false;
            conPagoBcos.Enabled = true;
            pnlDatCredito.Enabled = true;
            lblAlertaCamOrdenPrelacion.Visible = false;
            dtCobs = null;
            btnCancelarCred1.Enabled = true;

            dtDetalleDesc = new DataTable();
            idConceptoReciboDesc = 0;
            nMontoDescBono = 0;
            idTipoOperacionAde = 0;
            dtCredito.Clear();
      
        }

        #endregion

        #region CargaAutomaticaCobs

        private void cargaCondonacionesEjecutadas()
        {
            clsCNCondonacion SolicDuplicada = new clsCNCondonacion();
            DataTable dtRes = SolicDuplicada.CNBuscarCondonacionesEjecutadasXIdCuenta(conBusCuentaCli.nValBusqueda, idTipoOperacionCOBs, idSolicitud);

            if (dtRes.Rows.Count > 0)
            {
                MessageBox.Show( dtRes.Rows[0]["msgOperacion"].ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtCobs = dtRes;
                this.cargaMontoCobsEnPago();
                //cboTipoPago.SelectedValue = 1;
                cboTipoPago.Enabled = false;
                btnPrePago.Enabled = false;
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

            txtMCMontoNeto.Text = (nMontoAPagar).ToString();
            distribuiyeValores();
            txtMCMontoNeto.Enabled = false;
            conCalcVuelto.Enabled = false;
            conCalcVuelto.txtMonEfectivo.Text = Convert.ToDecimal(txtMCTotalPago.Text).ToString("N2");
            chcPorCuotas.Enabled = false;
        }

        public void distribuiyeValores()
        {
            int nNumCredito = this.conBusCuentaCli.nValBusqueda;
            clsCNCredito Credito = new clsCNCredito();
            Decimal nMonSalCre = Credito.nSaldoCredito(dtCredito);
            nMonSalCre = Convert.ToDecimal(string.Format("{0:#,0.00}", Convert.ToDecimal(nMonSalCre.ToString())));
            if (Math.Round(nMonSalCre, 2) < Convert.ToDecimal(this.txtMCMontoNeto.Text))
            {
                MessageBox.Show("Monto a pagar no puede exceder al saldo del crédito: " + nMonSalCre.ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnGrabar.Enabled = false;
                return;
            }

            CargaDatos();

            Decimal nMontoaPagar = Convert.ToDecimal(this.txtMCMontoNeto.Text);

            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            //dtPlanPagado = new clsCNPlanPago().dtCNPagoDistribuido(dtPlanPago, nMontoaPagar, true);
            dtPlanPagado = new clsCNPlanPago().dtCNPagoDistConOrdenPrelacion(dtPlanPago, nMontoaPagar, true, dtOrdenPrelacion);
            this.txtMCCapital.Text = dtPlanPagado.Rows[0]["nCapitalPag"].ToString();
            this.txtMCInteres.Text = dtPlanPagado.Rows[0]["nInteresPag"].ToString();
            this.txtMCIntComp.Text = dtPlanPagado.Rows[0]["nIntCompPag"].ToString();
            this.txtMCMora.Text = dtPlanPagado.Rows[0]["nMoraPag"].ToString();
            this.txtMCOtros.Text = dtPlanPagado.Rows[0]["nOtrosPag"].ToString();
            this.txtMCTotalPago.Text = calcularTotal();

            FormatoMonto();
            
            this.btnProcesar.Enabled = true;
            if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMCTotalPago.Text.Trim()))
            {
                conCalcVuelto.limpiar();
            }
            conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMCTotalPago.Text.Trim());
            conCalcVuelto.Enabled = true;
            conCalcVuelto.txtMonEfectivo.Focus();
            conCalcVuelto.txtMonEfectivo.SelectAll();
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

        private void btnSolEjecutadas_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
            frmBandejaCobroCreditos bandeja = new frmBandejaCobroCreditos();
            bandeja.ShowDialog();
            conBusCuentaCli.txtNroBusqueda.Text = bandeja.getCuentaSelect().idCuenta.ToString();
            conBusCuentaCli.asignarCuenta( bandeja.getCuentaSelect().idCuenta );
            idTipoOperacionCOBs = bandeja.getCuentaSelect().idTipoOperacion;
            idSolicitud = bandeja.getCuentaSelect().idSolicitud;
            cargarDatosCuenta();
            ActivarTitular();
            GEN.CapaNegocio.clsCNRetornaNumCuenta RetornaAsesor = new GEN.CapaNegocio.clsCNRetornaNumCuenta();
            DataTable dtAsesor = RetornaAsesor.RetornaAsesorCuenta(this.conBusCuentaCli.nValBusqueda);
            if (dtAsesor.Rows.Count > 0)
            {
                txtAsesor.Text = dtAsesor.Rows[0][1].ToString();
            }
        }
        #endregion

        public int emitirReciboDescuento(int idCuenta, int idCli, decimal nMonto, int idConceptoRecibo, int idKardexOrginal)
        {
            try
            {
                int idKardex = 0;

                
                int idTipoRecibo = 2; // RECIBO DE EGRESO
                int idMoneda = 1; // SOLES            
                Decimal nMontoITF = 0;
                Decimal nMontoTotal = nMonto + nMontoITF;
                string cSustento = "BONO DSCTO INT. CAMPAÑA NAVIDEÑA - CREDITO: " + idCuenta.ToString();
                int idUsuario = clsVarGlobal.User.idUsuario;
                int idAgeOrigen = clsVarGlobal.nIdAgencia;
                int idAgeDestino = clsVarGlobal.nIdAgencia;
                bool lAfecCaja = true;
                int idColaborador = 0;
                int idReciboProvisional = 0;
                string msg = "";

                clsCNControlOpe objCNControlOpe = new clsCNControlOpe();

                // Registro INICIO Rastreo
                this.registrarRastreo(idCli, 0, "Inicio  - Emitir Recibos ", btnGrabar);

                // Guardar recibo
                string cCodigoRecibo;

                bool lModificaSaldoLinea = true;

                DataTable dtGuardarRecibo = objCNControlOpe.CNGuardarReciboRelBono(idTipoRecibo, idConceptoRecibo, idColaborador, idCli,
                    idMoneda, nMonto, nMontoITF, nMontoTotal, cSustento, clsVarGlobal.dFecSystem, idUsuario, idAgeOrigen, idAgeDestino, 0, ref msg, 0, idCuenta, idKardexOrginal,
                    lModificaSaldoLinea, idReciboProvisional
                );
                if (dtGuardarRecibo.Rows.Count > 0)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();

                    cCodigoRecibo = dtGuardarRecibo.Rows[0]["cCodRec"].ToString();
                    idKardex = Convert.ToInt32(dtGuardarRecibo.Rows[0]["idKardex"]);
                }

                // Registro FIN Rastreo
                this.registrarRastreo(idCli, 0, "Fin - Emitir Recibos ", btnGrabar);

                return idKardex;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private void GuardarSolicitudHojaTramite(int idSolicitudHojaTramite_, int idUsuarioRegistra, int idTipoOperacionAde, int idCuenta, int idCliPagador, int idTipoPagador, bool lCartaPoder, int idTipoOpePrePago, int nIdKardex)
        {   
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            dtRegSolHojaTramite = objCNPlanPago.CNRegistrarSolHojaTramite(idSolicitudHojaTramite_, idUsuarioRegistra, idTipoOperacionAde, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, nIdKardex);
            idSolicitudHojaTramite = Convert.ToInt32(dtRegSolHojaTramite.Rows[0]["idSolicitudHojaTramite"]);
            if (nIdKardex == 0)
            {
                ImprimirVoucherHojaTramite(idSolicitudHojaTramite);
            }
            
        }

        private void ImprimirVoucherHojaTramite(int idSolicitudHojaTramite)
        {
            clsCNPlanPago objCNPlanPago = new clsCNPlanPago();
            int idTipoOperacion = 2;
            string reportpath = "rptVoucherAdelantoCuota.rdlc";
            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("idSolicitudTramite", idSolicitudHojaTramite.ToString(), false));
            paramlist.Add(new ReportParameter("idTipoOperacion", idTipoOperacion.ToString(), false));

            dtslist.Add(new ReportDataSource("DataSet1", objCNPlanPago.CNObtenerVoucherHojaTramite(idSolicitudHojaTramite, idTipoOperacion)));   
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void ActivarTitular()
        {
            if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
            {               
                rblTitular.Enabled = true;
                rblConyugue.Enabled = true;
                rblOtros.Enabled = true;
                rblTitular.Checked = false;
                rblConyugue.Checked = false;
                rblOtros.Checked = false;
            }
        }

        private void rblTitular_CheckedChanged(object sender, EventArgs e)
        {
            this.btnGrabar.Enabled = false;
            if (rblTitular.Checked)
            {
                if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                {
                    if (Convert.ToInt32(conBusCuentaCli.nIdCliente) != Convert.ToInt32(conDatPerReaOperac.idCli))
                    {
                        MessageBox.Show("El cliente y el pagador son diferentes, seleccionar otra opción", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (chbCartaPoder.Checked == true)
                        {
                            rblOtros.Checked = true;
                        }
                        else
                        {
                            rblConyugue.Checked = false;
                            chbCartaPoder.Enabled = false;
                            chbCartaPoder.Checked = false;
                        }

                        rblTitular.Checked = false;
                    }
                    else
                    {
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
            this.btnGrabar.Enabled = false;
            if (rblConyugue.Checked)
            {
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

        private void rblOtros_CheckedChanged(object sender, EventArgs e)
        {
            this.btnGrabar.Enabled = false;
            if (rblOtros.Checked)
            {
                if (!string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                {
                    if (Convert.ToInt32(conBusCuentaCli.nIdCliente) == Convert.ToInt32(conDatPerReaOperac.idCli))
                    {
                        MessageBox.Show("El cliente y el pagador son iguales", "Seleccionar Tipo de Pagador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        chbCartaPoder.Enabled = false;
                        chbCartaPoder.Checked = false;
                        rblOtros.Checked = false;
                        rblTitular.Checked = true;                        
                    }
                    else                       
                        chbCartaPoder.Checked = true;                     
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

        private void RegHojaTramite(int idSolicitudHojaTramite_, int idKardex_)
        {
            int idUsuarioRegistra = clsVarGlobal.User.idUsuario;
            idTipoOperacionAde = 2;
            int idCuenta = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
            int idCliPagador = Convert.ToInt32(conDatPerReaOperac.idCli);
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
            bool lCartaPoder = chbCartaPoder.Checked;
            int idTipoOpePrePago = 0;
            int nIdKardex = idKardex_;
            if (lAdelantoCuota)
            {
                GuardarSolicitudHojaTramite(idSolicitudHojaTramite_, idUsuarioRegistra, idTipoOperacionAde, idCuenta, idCliPagador, idTipoPagador, lCartaPoder, idTipoOpePrePago, nIdKardex);
            }
        }

        private void adelanto_cuota()
        {
            if (DatosPagador())
            {
                int nNumCredito = Convert.ToInt32(conBusCuentaCli.txtNroBusqueda.Text);
                DataTable dtPpgAdelanto = new clsCNPlanPago().CNdtPlanPago(nNumCredito);
                decimal nNumCuoAde = new clsCNPlanPago().nNumCuoAdelanto(dtPpgAdelanto, Convert.ToDecimal(txtMCMontoNeto.Text));
                if (nNumCuoAde >= 2)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de adelantar sus cuotas?", "Cobro de Crédito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        pnlTipoPagador.Visible = false;
                        ActivarTitular();
                        return;
                    }
                    else
                    {
                        pnlTipoPagador.Visible = true;
                        if (ValidarTipoPagador())
                        {
                            lAdelantoCuota = true;
                            RegHojaTramite(0, 0);
                            this.btnGrabar.Enabled = true;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    lAdelantoCuota = false;
                    pnlTipoPagador.Visible = false;
                    ActivarTitular();
                    this.btnGrabar.Enabled = true;
                    MessageBox.Show("Puede continuar con el proceso de cobro de créditos", "Cobro de Créditos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            adelanto_cuota();
        }

        private bool DatosPagador()
        {
            bool lDatosPagador = true;
            if (string.IsNullOrEmpty(conDatPerReaOperac.txtDocIdePerson.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el número de DOCUMENTO DE IDENTIDAD", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conDatPerReaOperac.txtDocIdePerson.Focus();
                    lDatosPagador = false;
                }
                if (string.IsNullOrEmpty(conDatPerReaOperac.txtNombrePerson.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el NOMBRE", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conDatPerReaOperac.txtNombrePerson.Focus();
                    lDatosPagador = false;
                }
                //if (string.IsNullOrEmpty(conDatPerReaOperac.txtDireccPerson.Text.Trim()))
                //{
                //    MessageBox.Show("Debe ingresar la DIRECCIÓN", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    conDatPerReaOperac.txtDireccPerson.Focus();
                //    lDatosPagador = false;
                //}
            return lDatosPagador;
        }
    
        private void btnCobrarCredito_Click(object sender, EventArgs e)
        {

            
   
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            frmExtornaOpe frmExtorno = new frmExtornaOpe(idKardexExtorno);

            frmExtorno.ShowDialog();
        }

        private void btnCancelarCred1_Click(object sender, EventArgs e)
        {
            if (dtCredito.Rows.Count > 0)   //si hay datos 
            {
                //obtengo numero de cuenta
                int idNumCuenta = Convert.ToInt32(dtCredito.AsEnumerable().First()["idCuenta"]);

                GEN.CapaNegocio.clsCNRetornaNumCuenta RetornaNumCuenta = new GEN.CapaNegocio.clsCNRetornaNumCuenta();
                DataTable dtEstCuenta = RetornaNumCuenta.VerifEstCuenta(idNumCuenta);
                Nullable<int> nidUserBloqueo;
                nidUserBloqueo = (Nullable<int>)dtEstCuenta.Rows[0][0];

                if (nidUserBloqueo != 0)
                {
                    RetornaNumCuenta.CNDesbloqueaCuenta(idNumCuenta, 1);

                }

                //si hay dato llama al formulario con los datos del cliente
                frmCancelacionAnticipada frmcancelAnti = new frmCancelacionAnticipada(conBusCuentaCli.nIdCliente, this, conBusCuentaCli.nValBusqueda, conBusCuentaCli.txtCodCli.Text, conBusCuentaCli.txtNroDoc.Text, conBusCuentaCli.txtNombreCli.Text);
                frmcancelAnti.bVieneCobro = true;
                frmcancelAnti.ShowDialog();


            }
            //else
            //{ // Si no hay dato llama al formulario Cancelacion
            //    frmCancelacionAnticipada frmcancelacion = new frmCancelacionAnticipada();

            //    frmcancelacion.ShowDialog();
            //}
        }

        private void EncuestaExperienciaCliente()
        {
            int nTipoOperacion = 2;
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
                        frm.cDocumentocliente = conBusCuentaCli.txtNroDoc.Text;
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

        private void dtgPpg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgPpg.Columns[e.ColumnIndex].Name == "nOtros")
                {
                    DataGridViewRow selectedRow = dtgPpg.Rows[e.RowIndex];
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
                    DataRow sumRow = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        sumRow[columna] = sumatorias[columna];

                    dataTable.Rows.Add(sumRow);

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

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

        private void btnProgFidelizacion_Click(object sender, EventArgs e)
        {            
            Grabar();         
        }

        public void Grabar()
        {
            if (!Validacion())
            {
                return;
            }

            int idEstadoNue = 2; //Registrado            

            try
            {                
                DataTable result = cnProgFidelizacionClie.CNRegistrarProgFidelizacionClie(this.conBusCuentaCli.nIdCliente, idEstadoNue, clsVarGlobal.User.idUsuario);

                if (result == null)
                {
                    MessageBox.Show("Error al intentar registrar al cliente.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Convert.ToInt32(result.Rows[0]["lResult"]) == 1)
                {
                    cnProgFidelizacionClie.CNRegistrarLogEstClieProgFid(this.conBusCuentaCli.nIdCliente, idEstadoNue, clsVarGlobal.User.idUsuario);
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnProgFidelizacion.Visible = false;
                }
                else
                {                    
                    MessageBox.Show(result.Rows[0]["cMsg"].ToString(), "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("Error al intentar registrar al cliente al programa de fidelización.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validacion()
        {
            bool lRespuesta = false;

            if (this.conBusCuentaCli.nIdCliente == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }                            

            if (MessageBox.Show("Está seguro que desea registrar al cliente al Programa de Fidelización?", "Cobro de Crédito", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                return lRespuesta;
            }            
            
            int idEstado = ObtenerEstadoProgramaFidelizacion(this.conBusCuentaCli.nIdCliente);

            if (idEstado != 0)
            {
                var estProgFid = cnProgFidelizacionClie.CNObtEstProgFidelizacion();

                MessageBox.Show("El cliente ya se encuentra " + estProgFid[idEstado] + ".", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }

            if (!ProductoVigente())
            {
                MessageBox.Show("El cliente no puede ser parte del programa de fidelización,\r\nporque no cuenta con productos vigentes.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }

            if (lblCalifica.Text.Trim().ToUpper() != "CALIFICA")
            {
                MessageBox.Show(MsgNoCalifica(), "Cliente no califica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return lRespuesta;
            }

            return true;
        }

        public bool ProductoVigente()
        {            
            DataTable dtCliente = cliente.CNListaCtaActivaCliente(this.conBusCuentaCli.nIdCliente);
            if (dtCliente == null) { return false; }
            return (dtCliente.Rows.Count > 0) ? true : false;
        }      

        public string MsgNoCalifica()
        {
            //Valida si existe la variable.
            bool lExiste = clsVarApl.dicVarGen.ContainsKey("cMsgNoCalifica");
            if (lExiste)
            {
                //Obtiene el mensaje a mostrar cuando no califica.
                return clsVarApl.dicVarGen["cMsgNoCalifica"];
            }
            else
            {
                return "";
            }
        }

        public int ObtenerEstadoProgramaFidelizacion(int idCli)
        {            
            DataTable dtProgFidelizacionClie = cnProgFidelizacionClie.CNObtenerProgFidelizacionClie(idCli);            
            return (dtProgFidelizacionClie.Rows.Count != 0) ? Convert.ToInt32(dtProgFidelizacionClie.Rows[0]["idEstado"]) : 0;
        }

        private void btnReferidos_Click(object sender, EventArgs e)
        {            
            GrabarReferidos();            
        }

        public void GrabarReferidos()
        {
            if (this.conBusCuentaCli.nIdCliente == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            

            //Cliente con producto vigente
            if (!ProductoVigente())
            {
                MessageBox.Show("El cliente no puede Agregar referidos, porque no cuenta con productos vigentes.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           

            //Si el cliente es colaborador de la entidad
            if (ExisteColaborador())
            {
                MessageBox.Show("El cliente no puede Agregar referidos, porque es colaborador de la entidad.", "Cobro de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idUsuAsesor = ObtenerAsesor(this.conBusCuentaCli.nIdCliente);
            int idAgencia = ObtenerAgencia(this.conBusCuentaCli.nIdCliente);

            frmReferidosClie frm = new frmReferidosClie(this.conBusCuentaCli.nIdCliente, 0, idAgencia, idUsuAsesor, 1);
            frm.ShowDialog();            
        }      

        public bool ExisteColaborador()
        {
            DataTable result = cnProgFidelizacionClie.CNObtenerDatosColaborador(this.conBusCuentaCli.nIdCliente);
            if (result == null) { return false; }
            return (result.Rows.Count > 0) ? true : false;
        }

        public int ObtenerAsesor(int idCli)
        {
            DataTable dtAsesor = cliente.CNObtenerAsesorCliente(idCli);            
            return (dtAsesor.Rows.Count != 0) ? Convert.ToInt32(dtAsesor.Rows[0]["idAsesor"]) : 0;
        }

        public int ObtenerAgencia(int idCli)
        {
            cnVisita = new clsCNVisita();
            DataTable dtAgencia = cnVisita.CNClienteAgencia(idCli);            
            return (dtAgencia.Rows.Count != 0) ? Convert.ToInt32(dtAgencia.Rows[0]["idAgencia"]) : 0;
        }
    }
}
