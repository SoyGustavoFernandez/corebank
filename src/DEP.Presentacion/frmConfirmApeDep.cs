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
using EntityLayer;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using RPT.CapaNegocio;
using CLI.CapaNegocio;
using GEN.Funciones;
using SPL.Presentacion;
using ADM.CapaNegocio;
using CRE.Presentacion;
using CLI.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmConfirmApeDep : frmBase
    {
        int x_nTipOpe = 9, p_idCta = 0, p_idCtaTranf = 0, idMoneda = 0, idTipoCuenta = 0, idProd = 0, nPlaCta = 0, idTipoPersona = 0, idTasa = 0;
        clsCNDeposito clsDeposito = new clsCNDeposito();
        DataTable dtComision = new DataTable();
        DataTable dtbAhoPrg = new DataTable();
        DataTable tbAhoPrg = new DataTable();
        DataTable dtInt = new DataTable();
        clsCNFirmas cnFirma = new clsCNFirmas();
        DataTable dtbIntervCta;
        bool lIsAfectoITF, lIsDepAhoProg, lEsTrabFin, lEsReqPagInt, lEsDefTipPagInt, lEsReqEmpleador, lEsAhoProg, lEsCtaCTS, lIsDepMenEdad;
        clsFunUtiles FunTruncar = new clsFunUtiles();
        conSplaf conSplaf1 = new conSplaf();
        Decimal nMonMinOpe, nMonMinSalDis, p_nMonMinSalDis;
        private string cInterv;
        private DataTable dtcertificado = new DataTable();
        private bool lIndVal = false;
        string cMontoLetras;
        clsNumLetras objNumLetras = new clsNumLetras();

        private const int idTipoOpeRegimenReforzado = 173;
        public frmConfirmApeDep()
        {
            InitializeComponent();
        }

        private void frmConfirmApeDep_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            conBusCtaAho.nTipOpe = x_nTipOpe;  //Tipo de operacion
            conBusCtaAhoTransf.p_idTipOpePrincipal = x_nTipOpe; //Indica la Operación Principal
            conBusCtaAho.pnIdMon = 0;  //Todas las monedas
            conBusCtaAho.idEstCuenta = 4; //Para las cuentas en estado solicitado
            conBusCli.btnBusCliente.Enabled = false;
            conBusCli.txtCodCli.Enabled = false;
            CargarModalidadPago();
            CargarColumnas();
            CargarCtasbancos();
            conBusCtaAhoTransf.btnBusCliente.Enabled = false;
            conCalcVuelto.Enabled = false;
            btnAceptar.Enabled = false;
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            this.cboMotivoOperacion.ListarMotivoOperacion(x_nTipOpe, clsVarGlobal.PerfilUsu.idPerfil);
            //------------------------------------------------
            rbtMismaCta.Enabled = false;
            rbtOtrasCuentas.Enabled = false;
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Checked = false;
            //------------------------------------------------
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
        }

        private void grbBase9_Enter(object sender, EventArgs e)
        {

        }

        private void CargarCtasbancos()
        {
            DataTable dtEntidad;
            dtEntidad = clsDeposito.ListarEntidadesConCuenta();
            //--Cheque de Gerencia
            cboEntidadCheGer.DataSource = dtEntidad;
            cboEntidadCheGer.ValueMember = "idEntidad";
            cboEntidadCheGer.DisplayMember = "cNombreCorto";
            if (dtEntidad.Rows.Count > 0)
            {
                cboEntidadCheGer.SelectedIndex = 0;
            }
        }
        private void ConverNumLetras(Decimal nMontoTotal)
        {
            objNumLetras.LetraCapital = true;
            objNumLetras.MascaraSalidaDecimal = "/100 " + txtMoneda.Text;
            objNumLetras.SeparadorDecimalSalida = "con";
            objNumLetras.Decimales = 2;
            cMontoLetras = objNumLetras.ToCustomCardinal(nMontoTotal);
        }
        public void CargarColumnas()
        {
            dtcertificado.Columns.Add("idCuenta", typeof(Int32));
            dtcertificado.Columns.Add("cNroCuenta", typeof(string));
            dtcertificado.Columns.Add("nMonTasa", typeof(decimal));
            dtcertificado.Columns.Add("nPlazoCta", typeof(Int32));
            dtcertificado.Columns.Add("nMontoDeposito", typeof(decimal));
            dtcertificado.Columns.Add("dFechaApertura", typeof(DateTime));
            dtcertificado.Columns.Add("nNumeCertificado", typeof(Int32));
            dtcertificado.Columns.Add("dFechaCancelacion", typeof(DateTime));
            dtcertificado.Columns.Add("cTipoCuenta", typeof(string));
            dtcertificado.Columns.Add("cProducto", typeof(string));
            dtcertificado.Columns.Add("cNombreAge", typeof(string));
            dtcertificado.Columns.Add("cMoneda", typeof(string));
            dtcertificado.Columns.Add("cnombreInterv", typeof(string));
        }
        private async void ValidarAutrizacionUsoDatos(){
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (conBusCtaAho.nidTipoPersona == 1)
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                         
                    }
                }
                else
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 7 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        
                    }
                }

            }
        }
        private async void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (cboMotivoOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Motivo de la Operación...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoOperacion.Focus();
                return;
            }
           
            /*========================================================================================
           * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
           ========================================================================================*/
            int idCliValid = 0;
            DataRow row = dtInt.AsEnumerable().Where(x => Convert.ToBoolean(x["isReqFirma"]))
                                                    .OrderBy(x => Convert.ToInt32(x["idCli"]))
                                                    .FirstOrDefault();
            idCliValid = row != null ? Convert.ToInt32(row["idCli"]) : 0;
            var lstTitulares = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(idCliValid, "", clsVarGlobal.nIdAgencia, this.x_nTipOpe, idCliValid);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            /*========================================================================================
            * VALIDACION DE AUTORIZACION DE USO DE DATOS
            ========================================================================================*/
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (conBusCtaAho.nidTipoPersona == 1)
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (valor == false)
                        {
                            MessageBox.Show("Debe registrar la autorización de uso de datos de " + titular.Field<string>("cNombre"), "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);

                            return;
                        }
                    }
                }
                else
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 7 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;
                        bool valor = await conAutorizacionUsuDatos1.obtenerAutorizacionDatos(1, "", 0, titular.Field<string>("cNombre"), titular.Field<string>("cDocumentoID"),
                                              titular.Field<string>("cDireccion"), titular.Field<string>("cTelefono"), titular.Field<int>("IdTipoPersona"), titular.Field<int>("idTipoDocumento"));//TIPO AUTORIZACIÓN DE TRATAMIENTO DE DATOS PERSONALES

                        if (valor == false)
                        {
                            MessageBox.Show("Debe registrar la autorización de uso de datos de " + titular.Field<string>("cNombre"), "Plan de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conAutorizacionUsuDatos1.MostrarRegistroAutorizacion(1);

                            return;
                        }
                    }
                }
                
            }

             
            /*========================================================================================
           * FIN VALIDACION DE AUTORIZACION DE USO DE DATOS
           ========================================================================================*/

            /*========================================================================================
             * REGISTRO DE RASTREO
              ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(dtInt.Rows[0]["idcli"]), 0, "Inicio-Confirmación de la apertura de Cuenta de ahorro", btnAceptar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            if (!ValidarDatosTipPago())
            {
                return;
            }

            //===================================================================
            //---VALIDACION DE CLIENTE PEP
            //===================================================================
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtInt.Rows[i]["isReqFirma"].ToString()))
                {
                    string mensaje = "",
                        x_cNroDni = "";
                    int x_idEstApr = 0;
                    int CodCliente = Convert.ToInt32(dtInt.Rows[i]["idCli"].ToString());
                    int CodidTipoDocumento = Convert.ToInt32(dtInt.Rows[i]["idTipoDocumento"].ToString());



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
                }
            }

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/

            int nNumSolAprobRegimen = 0;
            foreach (var titular in lstTitulares)
            {
                clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(titular.Field<int>("idCli"),
                                                                               idMoneda,
                                                                               idProd,
                                                                               conBusCtaAho.idcuenta,
                                                                               Convert.ToDecimal(txtMontEnt.Text.ToString()));
                if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                    nNumSolAprobRegimen++;
            }

            if (nNumSolAprobRegimen > 0)
            {
                return;
            }

            int idCtaTrans = 0;
            int nPlazo = 0;
            nPlazo = Convert.ToInt32(txtPlaProd.Text.ToString());

            #region Validacion Umbrales Dolares
            decimal nMontoTotPago = txtMontApe.nDecValor;
            int idMonedaUm = conSolesDolar.getIdMoneda();
            int idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);
            int idSubProducto = idProd;
            int idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);
            

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, 9, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion

            //--==================================================
            //--Si tipo de Pago es por Transferencia
            //--==================================================
            switch (Convert.ToInt32(cboModPago.SelectedValue))  //--Modificado
            {
                case 2:  //--Pago con Transferencia
                    idCtaTrans = Convert.ToInt32(conBusCtaAhoTransf.idcuenta);
                    break;
                case 3: //--Cheques
                    idCtaTrans = 0;
                    break;
                case 4: //--Interbancario
                    idCtaTrans = 0;
                    break;
                case 5:  //--Ordenes de Pago
                    idCtaTrans = Convert.ToInt32(txtNroCta.Text);
                    break;
                case 6:  //--Cheque Gerencia
                    idCtaTrans = 0;
                    break;
                default:
                    idCtaTrans = 0;
                    break;
            }

            //============================================================
            //--Retorna Estructura Para Datos del Pago
            //============================================================
            clsCNAperturaCta DatTipPago = new clsCNAperturaCta();
            DataTable dtPag = DatTipPago.ListaCamposDep(3);
            DataRow drPag = dtPag.NewRow();
            //--Asignar Datos Para Registrar Apertura

            switch (Convert.ToInt32(cboModPago.SelectedValue))
            {
                case 1: //Pago en Efectivo
                    drPag["idTipoValorado"] = 1; //--Tipo Pago Efectivo
                    drPag["cNroCuentaDoc"] = "";
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                    drPag["nNroFolio"] = "0";
                    break;
                case 2: //con Transferencia de Cuentas
                    drPag["idTipoValorado"] = 2;
                    drPag["cNroCuentaDoc"] = conBusCtaAhoTransf.idcuenta.ToString();
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                    drPag["nNroFolio"] = "0";
                    break;
                case 3: //Tipo Cheque
                    drPag["idTipoValorado"] = 3;
                    drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                    drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                    drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                    drPag["idEntidad"] = cboEnt.SelectedValue;
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                    drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                    drPag["nNroFolio"] = "0";
                    break;
                case 4: //Tipo Interbancario
                    drPag["idTipoValorado"] = 4;
                    drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                    drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                    drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                    drPag["idEntidad"] = cboEnt.SelectedValue;
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                    drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                    drPag["nNroFolio"] = "0";
                    break;
                case 5:  //Tipo OP
                    drPag["idTipoValorado"] = 5;
                    drPag["cNroCuentaDoc"] = txtNroCta.Text.Trim();
                    drPag["cNroDocumento"] = txtNroDocu.Text.Trim();
                    drPag["cSerieDocumento"] = txtSerie.Text.Trim();
                    drPag["idEntidad"] = cboEnt.SelectedValue;
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = Convert.ToInt32(txtDiaVal.Text);
                    drPag["dFechaEmiDoc"] = dtpFecDoc.Value;
                    drPag["nNroFolio"] = txtFolio.Text;
                    break;
                case 6:  //Cheque de gerencia
                    drPag["idTipoValorado"] = 6;
                    drPag["idEntidad"] = cboEntidadCheGer.SelectedValue;
                    drPag["cNroCuentaDoc"] = txtNroCuentaGer.Text.Trim();
                    drPag["cNroDocumento"] = txtNroCheqGer.Text.Trim();
                    drPag["cSerieDocumento"] = txtSerieCheqGer.Text.Trim();
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = dtpFecCheqGer.Value;
                    drPag["nNroFolio"] = "0";
                    break;
                default:
                    drPag["idTipoValorado"] = Convert.ToInt32(cboModPago.SelectedValue); //--Otros Tipos de Pago
                    drPag["cNroDocumento"] = "000";
                    drPag["cSerieDocumento"] = "0";
                    drPag["idEntidad"] = clsVarApl.dicVarGen["idInstFin"];
                    drPag["dFechaReg"] = clsVarGlobal.dFecSystem.ToShortDateString();
                    drPag["nDiasValoriz"] = 0;
                    drPag["dFechaEmiDoc"] = clsVarGlobal.dFecSystem;
                    drPag["nNroFolio"] = "0";
                    break;
            }
            dtPag.Rows.Add(drPag);

            //--Generar XML de Datos del Tipo de Pago
            DataSet dsTipPago = new DataSet("dsDeposito");
            dsTipPago.Tables.Add(dtPag);
            string xmlTipPago = clsCNFormatoXML.EncodingXML(dsTipPago.GetXml());

            //--Variables Adicionales
            int idEntFin = clsVarApl.dicVarGen["idInstFin"];
            if (Convert.ToInt32(cboModPago.SelectedValue) > 2)
            {
                idEntFin = Convert.ToInt32(cboEnt.SelectedValue);
            }

            string cNroDocPag = txtNroDocu.Text.Trim();

            //================================================================
            //--Parámetros para Guardar Apertura
            //================================================================

            //===================================================================
            //--Generar XML de Datos Comisiones
            //===================================================================
            DataSet dsComision = new DataSet("dsDeposito");
            dsComision.Tables.Add(dtComision);
            string xmlComision = clsCNFormatoXML.EncodingXML(dsComision.GetXml());
            DataSet dsAhoPrg = new DataSet("dsDeposito");
            if (lIsDepAhoProg)
            {
                //===================================================================
                //--Generar XML de Datos Aho Programado
                //===================================================================

                dsAhoPrg.Tables.Add(tbAhoPrg);
                string xmlAhoPrg = clsCNFormatoXML.EncodingXML(dsAhoPrg.GetXml());
            }

            //===================================================================
            //--Guardar Apertura Cuenta
            //===================================================================
            int idTipPago = Convert.ToInt32(cboModPago.SelectedValue);
            int x_idMotivoOpe = Convert.ToInt32(cboMotivoOperacion.SelectedValue);

            int nCuotas = Convert.ToInt32(txtPlaProd.Text) / 30;
            int idCanal = 1;
            Decimal nMontoDep = Convert.ToDecimal (this.txtMontApe.Text),
                   nMonITFDep = Convert.ToDecimal (txtITF.Text),
                   nMonITFInt = Convert.ToDecimal (txtMonItfInt.Text);
            Decimal nMonComis = Convert.ToDecimal (txtComisiones.Text);
            Decimal nMonIntTot = Convert.ToDecimal(txtTotInteres.Text);
            Decimal nMonOpe = Convert.ToDecimal (this.txtMontEnt.Text.ToString()), //--Es el Monto Total a Recibir
                   nMonRedondeo = Convert.ToDecimal (txtRedondeo.Text.ToString()),
                   nMonCapital = Convert.ToDecimal (this.txtMontTotalOpe.Text.ToString());  //--Es el Monto Neto de la Apertura

            Decimal nMonIntAde = Convert.ToDecimal (this.txtIntAdelantado.Text),
                   nMonRedIntAde = Convert.ToDecimal (this.txtRedondeoInt.Text);
            int idKardex = 0;
            ConverNumLetras(Convert.ToDecimal (txtMontTotalOpe.Text));

            //===================================================================
            //--Generar XML de Datos Intervinientes
            //===================================================================
            DataTable tbCliIntervi = dtInt.Clone();
            for (int i = 0; i < dtInt.Rows.Count; i++)
            {
                tbCliIntervi.ImportRow(dtInt.Rows[i]);
            }

            DataSet dsInterv = new DataSet("dsDeposito");
            dsInterv.Tables.Add(tbCliIntervi);
            string xmlInterv = clsCNFormatoXML.EncodingXML(dsInterv.GetXml());

            //--===============================================================
            //--Validar Reglas de Negocio
            //--===============================================================
            if (!ValidarReglas())
            {
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsInterv.Tables.Clear();
                dsInterv.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                return;
            }

            Decimal nMonTasa = 0;

            if (string.IsNullOrEmpty(txtNuevaTasa.Text))
            {
                nMonTasa = Convert.ToDecimal (txtTasa.Text);
            }
            else
            {
                if (Convert.ToDecimal (txtNuevaTasa.Text)>0)
                {
                    nMonTasa = Convert.ToDecimal (txtNuevaTasa.Text);
                }
                else
                {
                    nMonTasa = Convert.ToDecimal (txtTasa.Text);
                }
            }

            //----------------------------------------------------------------------------------
            //--Actualizar Saldos de Caja
            //----------------------------------------------------------------------------------
            if (Convert.ToInt16(cboModPago.SelectedValue) == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMoneda, 1, nMonOpe))
                {
                    dsComision.Tables.Clear();
                    dsComision.Dispose();
                    dsInterv.Tables.Clear();
                    dsInterv.Dispose();
                    dsTipPago.Tables.Clear();
                    dsTipPago.Dispose();
                    return;
                }
                //----------------------------------------------------------------------
                //--Actualizar Saldos de Caja--Egreso
                //----------------------------------------------------------------------
                if (Convert.ToInt32(cboPagoInt.SelectedValue) == 1)
                {
                    if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt16(idMoneda), 2, nMonIntAde))
                    {
                        dsComision.Dispose();
                        dsInterv.Tables.Clear();
                        dsInterv.Dispose();
                        dsTipPago.Tables.Clear();
                        dsTipPago.Dispose();
                        return;
                    }
                }
            }

            //===================================================================
            //--Registrar Apertura de Cuenta
            //===================================================================
            clsCNAperturaCta dtRegApe = new clsCNAperturaCta();

            int nMotPagoId = Convert.ToInt16(cboModPago.SelectedValue);
            int nMotPagoIdEgreso = Convert.ToInt32(cboPagoInt.SelectedValue);

            int[] nMotPagoSaldoCaja = { 1, 5 };

            bool lModificaSaldoLinea1 = nMotPagoId.In(nMotPagoSaldoCaja) ? true : false;
            bool lModificaSaldoLinea2 = nMotPagoIdEgreso.In(nMotPagoSaldoCaja) ? true : false;

            DataTable tbRegApe = dtRegApe.RegistraConfirmApeCta(p_idCta, xmlComision, xmlTipPago, xmlInterv,
                                            nMonOpe, nMonIntAde, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, nCuotas,
                                            lEsAhoProg, chcCert.Checked, lEsCtaCTS, cNroDocPag, idEntFin, idCtaTrans, idTipPago,
                                            nMonITFDep, nMonITFInt, nMonComis, nMonRedondeo, nMonCapital, idCanal, nMonRedIntAde,
                                            lIsDepMenEdad, x_idMotivoOpe, idTasa, nMonTasa, nMonIntTot,
                                            lModificaSaldoLinea1, lModificaSaldoLinea2, this.idMoneda, clsVarGlobal.nIdAgencia);

            if (Convert.ToInt32(tbRegApe.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString() + ", NRO DE CUENTA: " + tbRegApe.Rows[0]["idNroCta"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idKardex = Convert.ToInt32(tbRegApe.Rows[0]["idKardexAho"].ToString());
                btnAceptar.Enabled = false;
                this.btnCancelar.Enabled = true;
                cboModPago.Enabled = false;
                cboMotivoOperacion.Enabled = false;
                chcCambiar.Enabled = false;
                txtMontApe.Enabled = false;
                chcOrdPago.Enabled = false;
                //--Liberar Variables
                dsInterv.Tables.Clear();
                dsInterv.Dispose();
                dtPag.Dispose();
                tbAhoPrg.Dispose();
                dtComision.Dispose();
                dtInt.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsAhoPrg.Dispose();
                //------------
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(tbRegApe.Rows[0]["idCuentaAho"]));

                if (!string.IsNullOrEmpty(conBusCtaAhoTransf.idcuenta.ToString()) && Convert.ToInt32(conBusCtaAhoTransf.idcuenta) > 0)
                {
                    clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoTransf.idcuenta));
                }
            }
            else
            {
                //--Liberar Variables
                dsComision.Tables.Clear();
                dsComision.Dispose();
                dsInterv.Tables.Clear();
                dsInterv.Dispose();
                dsTipPago.Tables.Clear();
                dsTipPago.Dispose();
                dtPag.Dispose();
                tbAhoPrg.Dispose();
                dtInt.Dispose();
                MessageBox.Show(tbRegApe.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            conCalcVuelto.Enabled = false;

            // RQ-412 Integracion de Saldos en Linea
            new Semaforo().ValidarSaldoSemaforo();

            int nIdKardex = Convert.ToInt32(tbRegApe.Rows[0]["idKardexAho"]);

            int[] nMotPago = new int[4];
            nMotPago[0] = 1;
            nMotPago[1] = 2;
            nMotPago[2] = 5;
            nMotPago[3] = 4;
            
            if (nMotPagoId.In(nMotPago)){
                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);
            }

            //----------------------------------------------------------------------
            //--Imprimir Voucher de apertura
            //----------------------------------------------------------------------
            if (nIdKardex > 0)
            {
                ImpresionVoucher(nIdKardex, clsVarGlobal.idModulo, x_nTipOpe, 1, conCalcVuelto.txtMonEfectivo.nDecValor, conCalcVuelto.txtMonDiferencia.nDecValor, 0, 1);//Parámetros que se requieren kardex,Modulo,TipoOperacion,MOntoRecibido, MontoDVuelto, KardexEgreso caso Habilitacion
            }

            //-----------------------------------------------------------------------
            //Validacion de Declaracion Jurada de Sujetos Obligados
            //-----------------------------------------------------------------------
            DeclaracionJuradaCli();

            //this.objFrmSemaforo.ValidarSaldoSemaforo();

            /*========================================================================================
                * REGISTRO DE RASTREO
            ========================================================================================*/
            this.registrarRastreo(Convert.ToInt32(dtInt.Rows[0]["idcli"]), 0, "Fin-Confirmación de Apertura de Cuenta de ahorro", btnAceptar);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            dsComision.Tables.Clear();
            dsComision.Dispose();
            dsInterv.Tables.Clear();
            dsInterv.Dispose();
            dsTipPago.Tables.Clear();
            dsTipPago.Dispose();

            EncuestaExperienciaCliente();

        }
        private void DeclaracionJuradaCli()
        {
            int idCli = 0;
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value) == 6)
                {
                    idCli = Convert.ToInt32(dtgIntervinientes.Rows[i].Cells["idcli"].Value);
                    frmDeclaracionJurada declara = new frmDeclaracionJurada(idCli);
                }
            }
        }

        private void conBusCtaAho1_ClicBusCta(object sender, EventArgs e)
        {
            LimpiarCtrl();
            ptbFirma.Image = null;
            ptbFirma.Refresh();
            btnAceptar.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                DatosCuenta(p_idCta);
                if (p_idCta > 0)
                {
                    DatosTipoPago(p_idCta);
                }
            }
        }

        private void DatosTipoPago(int idCta)
        {
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Checked = false;
            txtcNroCuenta.Visible = false;
            conBusCtaAhoTransf.idcuenta = 0;
            DataTable dtTipoPago = clsDeposito.CNDatosTipoPago(idCta, clsVarGlobal.nIdAgencia);
            if (dtTipoPago.Rows.Count > 0)
            {
                cboModPago.SelectedValue = (int)dtTipoPago.Rows[0]["idTipoPago"];
                if (this.cboModPago.SelectedIndex > 0)
                {
                    txtMontoDoc.Text = txtMontApe.Text;
                    int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
                    switch (nCodModPago)
                    {
                        case 1: //--Pago en Efectivo
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTransf"].Enabled = false;
                            this.tbcPagos.Controls["tabCheq"].Enabled = false;
                            break;
                        case 2: //--Pago con Transferencia
                            tbcPagos.SelectedIndex = 0;
                            if (Convert.ToDecimal (dtTipoPago.Rows[0]["nSaldoDisponible"].ToString()) < Convert.ToDecimal (txtMontApe.Text))
                            {
                                MessageBox.Show("NO Cuenta con Suficiente Saldo Disponible...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            conBusCtaAhoTransf.txtCodIns.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                            conBusCtaAhoTransf.txtCodAge.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                            conBusCtaAhoTransf.txtCodMod.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                            conBusCtaAhoTransf.txtCodMon.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                            conBusCtaAhoTransf.txtNroCta.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                            conBusCtaAhoTransf.txtCodCli.Text = dtTipoPago.Rows[0]["idCli"].ToString();
                            conBusCtaAhoTransf.txtNombre.Text = dtTipoPago.Rows[0]["cNombre"].ToString();
                            conBusCtaAhoTransf.txtProducto.Text = dtTipoPago.Rows[0]["cProducto"].ToString();
                            conBusCtaAhoTransf.idcuenta = Convert.ToInt32(dtTipoPago.Rows[0]["idCuentaRel"].ToString());
                            p_idCtaTranf = Convert.ToInt32(conBusCtaAhoTransf.idcuenta);
                            if (!string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text.Trim()))
                            {
                                clsDeposito.CNUpdUsoCuenta(p_idCtaTranf, clsVarGlobal.User.idUsuario);
                            }
                            if (Convert.ToBoolean(dtTipoPago.Rows[0]["lisMismaCta"].ToString()))
                            {
                                rbtMismaCta.Checked = true;
                            }
                            else
                            {
                                rbtOtrasCuentas.Checked = true;
                            }

                            break;
                        case 3: //--Pago Cheque
                            txtNroCta.Text = dtTipoPago.Rows[0]["cNroCuentaDoc"].ToString();
                            txtNroDocu.Text = dtTipoPago.Rows[0]["cNroDocumento"].ToString();
                            txtSerie.Text = dtTipoPago.Rows[0]["cSerieDocumento"].ToString();
                            cboTipoEnt.SelectedValue = (int)dtTipoPago.Rows[0]["idTipoEntidad"];
                            cboEnt.SelectedValue = (int)dtTipoPago.Rows[0]["idEntidad"];
                            cboMonedaDoc.SelectedValue = (int)dtTipoPago.Rows[0]["idMoneda"];
                            txtDiaVal.Text = dtTipoPago.Rows[0]["nDiasValoriz"].ToString();
                            txtMontoDoc.Text = txtMontApe.Text;
                            dtpFecDoc.Value = Convert.ToDateTime(dtTipoPago.Rows[0]["dFechaEmiDoc"].ToString());
                            int nEstadoValor = (int)dtTipoPago.Rows[0]["nEstadoValoriz"];
                            switch (nEstadoValor)
                            {
                                case 1: //--Falta Valorizar
                                    MessageBox.Show("Falta Valorizar el Documento para la Apertura", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    btnAceptar.Enabled = false;
                                    break;
                                case 2: //--Valorizado
                                    btnAceptar.Enabled = true;
                                    break;
                                case 3: //--Documento Rechazado
                                    MessageBox.Show("La Valorización fue Rechazada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    btnAceptar.Enabled = false;
                                    break;
                                case 4: //--Documento Vencido
                                    MessageBox.Show("El Documento se esta Vencido...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    btnAceptar.Enabled = false;
                                    break;
                                default:
                                    btnAceptar.Enabled = false;
                                    break;
                            }
                            tbcPagos.SelectedIndex = 1;
                            break;
                        case 4: //--Pago Interbancario
                            txtNroCta.Text = dtTipoPago.Rows[0]["cNroCuentaDoc"].ToString();
                            txtNroDocu.Text = dtTipoPago.Rows[0]["cNroDocumento"].ToString();
                            txtSerie.Text = dtTipoPago.Rows[0]["cSerieDocumento"].ToString();
                            cboTipoEnt.SelectedValue = (int)dtTipoPago.Rows[0]["idTipoEntidad"];
                            cboEnt.SelectedValue = (int)dtTipoPago.Rows[0]["idEntidad"];
                            cboMonedaDoc.SelectedValue = (int)dtTipoPago.Rows[0]["idMoneda"];
                            txtDiaVal.Text = dtTipoPago.Rows[0]["nDiasValoriz"].ToString();
                            txtMontoDoc.Text = txtMontApe.Text;
                            dtpFecDoc.Value = Convert.ToDateTime(dtTipoPago.Rows[0]["dFechaEmiDoc"].ToString());
                            int nEstadoValoriz = (int)dtTipoPago.Rows[0]["nEstadoValoriz"];
                            switch (nEstadoValoriz)
                            {
                                case 1: //--Falta Valorizar
                                    MessageBox.Show("Falta Valorizar el Documento para la Apertura", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    btnAceptar.Enabled = false;
                                    break;
                                case 2: //--Valorizado
                                    btnAceptar.Enabled = true;
                                    break;
                                case 3: //--Falta Valorizar
                                    MessageBox.Show("La Valorización fue Rechazada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    btnAceptar.Enabled = false;
                                    break;
                                default:
                                    break;
                            }
                            tbcPagos.SelectedIndex = 1;
                            break;
                        case 5: //--Pago con OP
                            txtcNroCuenta.Visible = true;
                            txtNroCta.Text = dtTipoPago.Rows[0]["cNroCuentaDoc"].ToString();
                            txtcNroCuenta.Text = dtTipoPago.Rows[0]["cNroCuenta"].ToString();
                            txtNroDocu.Text = dtTipoPago.Rows[0]["cNroDocumento"].ToString();
                            txtSerie.Text = dtTipoPago.Rows[0]["cSerieDocumento"].ToString();
                            dtpFecDoc.Value = Convert.ToDateTime(dtTipoPago.Rows[0]["dFechaEmiDoc"].ToString());
                            txtFolio.Text = dtTipoPago.Rows[0]["nNroFolio"].ToString();
                            p_idCtaTranf = Convert.ToInt32(txtNroCta.Text);
                            cboTipoEnt.Enabled = false;
                            cboEnt.Enabled = false;
                            cboMonedaDoc.Enabled = false;
                            txtDiaVal.Enabled = false;
                            txtMontoDoc.Text = txtMontApe.Text; // txtMontTotalOpe.Text;
                            tbcPagos.SelectedIndex = 1;
                            break;
                        case 6: //--Operacion con Cheque de Gerencia
                            txtNroCuentaGer.Text = dtTipoPago.Rows[0]["cNroCuentaDoc"].ToString();
                            txtNroCheqGer.Text = dtTipoPago.Rows[0]["cNroDocumento"].ToString();
                            txtSerieCheqGer.Text = dtTipoPago.Rows[0]["cSerieDocumento"].ToString();
                            cboEntidadCheGer.SelectedValue = (int)dtTipoPago.Rows[0]["idEntidad"];
                            cboMonedaCheGer.SelectedValue = (int)dtTipoPago.Rows[0]["idMoneda"];
                            dtpFecCheqGer.Value = Convert.ToDateTime(dtTipoPago.Rows[0]["dFechaEmiDoc"].ToString());
                            p_idCtaTranf = 0;
                            cboEntidadCheGer.Enabled = false;
                            tbcPagos.SelectedIndex = 2;
                            break;
                        default: //--Otros Tipos de Pago
                            tbcPagos.SelectedIndex = 0;
                            break;
                    }
                }
            }
            else
            {
                tbcPagos.SelectedIndex = 0;
                cboModPago.SelectedValue = 1;
                this.tbcPagos.Controls["tabTransf"].Enabled = false;
                this.tbcPagos.Controls["tabCheq"].Enabled = false;
                lblTipPago.Text = "MODALIDAD DE PAGO: EFECTIVO";
            }

            if (Convert.ToInt32(cboModPago.SelectedValue) == 1 && lEsCtaCTS == false) // si es efectivo
            {
                chcCambiar.Enabled = true;
            }
            this.calcular();
        }

        private void DatosCuenta(int idCta)
        {
            btnAceptar.Enabled = false;
            chcCambiar.Checked = false;
            chcCambiar.Enabled = false;
            txtMontApe.Enabled = false;
            //--===================================================================================
            //--Validar Bloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(idCta, x_nTipOpe, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarOtrosCtrl();
                btnCancelar.Enabled = false;
                btnAceptar.Enabled = false;
                return;
            }

            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "4", x_nTipOpe);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                {
                    int idusuBlo = Convert.ToInt32(dtbNumCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                    clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                    DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                    string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                    MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    p_idCta = 0;
                    LimpiarOtrosCtrl();
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    return;
                }
                switch (Convert.ToInt16(dtbNumCuentas.Rows[0]["idCaracteristica"].ToString()))
                {
                    case 4:
                        MessageBox.Show("La Cuenta se Encuentra Inmovilizada, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrl();
                        btnAceptar.Enabled = false;
                        btnCancelar.Enabled = false;
                        return;
                    case 5:
                        MessageBox.Show("La Cuenta se Encuentra Vencida, No puede Realizar Operaciones", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrl();
                        btnAceptar.Enabled = false;
                        btnCancelar.Enabled = false;
                        return;
                }

                if (Convert.ToInt16(dtbNumCuentas.Rows[0]["idAgencia"]) != clsVarGlobal.nIdAgencia)
                {
                        MessageBox.Show("La cuenta fue solicitada en otra Agencia, NO puede Aperturar en esta agencia", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clsDeposito.CNUpdNoUsoCuenta(idCta);
                        LimpiarOtrosCtrl();
                        btnAceptar.Enabled = false;
                        btnCancelar.Enabled = false;
                        return;
                }

                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                idTasa = Convert.ToInt32(dtbNumCuentas.Rows[0]["idTasa"].ToString());
                idMoneda = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                idTipoCuenta = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                idTipoPersona = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoPersona"].ToString());
                this.cboTipoTasa.SelectedValue = Convert.ToInt32(dtbNumCuentas.Rows[0]["idtipotasa"].ToString());
                this.txtTasa.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();
                this.txtTasaEfectiva.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();
                this.txtTasaNominal.Text = dtbNumCuentas.Rows[0]["nMonTasa"].ToString();
                this.txtMontApe.Text = dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString();
                this.txtTipCuenta.Text = dtbNumCuentas.Rows[0]["cTipoCuenta"].ToString();
                this.txtTipPersona.Text = dtbNumCuentas.Rows[0]["cPersona"].ToString();
                this.txtMoneda.Text = dtbNumCuentas.Rows[0]["cMoneda"].ToString();
                this.txtPlaProd.Text = dtbNumCuentas.Rows[0]["nPlazoCta"].ToString();
                this.txtNroFir.Text = dtbNumCuentas.Rows[0]["nNumeroFirmas"].ToString();
                lIsAfectoITF = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsAfectoITF"].ToString());
                nMonMinOpe = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMonMinOpe"].ToString());
                lIsDepAhoProg = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsDepAhoProg"].ToString());
                lEsCtaCTS = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"].ToString());
                idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"].ToString());
                nPlaCta = Convert.ToInt32(dtbNumCuentas.Rows[0]["nPlazoCta"].ToString());
                nMonMinSalDis = Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString());
                this.chcOrdPago.Checked = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsCtaOrdPago"].ToString());

            }
            else
            {
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                txtMontApe.Enabled = false;
                LimpiarCtrl();
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;
                LimpiarOtrosCtrl();
                return;
            }

            if (Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsReqEmpleador"].ToString()))
            {
                this.conBusCli.CargardatosCli(Convert.ToInt32(dtbNumCuentas.Rows[0]["idCli"].ToString()));
            }

            //--===================================================================================
            //--Cargar de Intervinientes de la Cuenta
            //--===================================================================================
            dtbIntervCta = clsDeposito.CNRetornaIntervinientesCuenta(idCta);
            dtInt = dtbIntervCta;
            if (dtbIntervCta.Rows.Count > 0)
            {
                dtgIntervinientes.DataSource = dtbIntervCta;
                ValidarAutrizacionUsoDatos();

            }
            else
            {
                MessageBox.Show("El Cuenta no Tiene Intervinientes..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsDeposito.CNUpdNoUsoCuenta(idCta);
                LimpiarCtrl();
                LimpiarOtrosCtrl();
                txtMontApe.Enabled = false;
                btnAceptar.Enabled = false;
                return;
            }
            for (int i = 0; i < dtgIntervinientes.Rows.Count; i++)
            {

                cInterv = cInterv + dtInt.Rows[i]["cNombre"].ToString() + "\n";
            }
            this.AutorizacionUsoDatos(0);
            //--===================================================================================
            //--Cargar Datos si es Ahorro Programado
            //--===================================================================================
            if (lIsDepAhoProg)
            {
                dtbAhoPrg = clsDeposito.CNRetornaAhoProgramado(idCta, 4);
                dtgPlanDeposito.DataSource = dtbAhoPrg;
                if (dtbAhoPrg.Rows.Count > 0)
                {
                    txtNumTotCuo.Text = dtbAhoPrg.Rows[0]["nNroDepos"].ToString();
                    txtNumCuoVen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()) + 1);
                    txtNumCuoPen.Text = Convert.ToString(Convert.ToInt32(dtbAhoPrg.Rows[0]["nNroDepos"].ToString()) - Convert.ToInt32(dtbAhoPrg.Rows[0]["nNumDepPag"].ToString()));
                    txtAtraso.Text = dtbAhoPrg.Rows[0]["nDiasAtrazo"].ToString();
                    txtSaldoPen.Text = Convert.ToString(Convert.ToDecimal (dtbAhoPrg.Rows[0]["nMonTotProg"].ToString()) - Convert.ToDecimal (dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString()));

                    txtSaldoDep.Text = dtbAhoPrg.Rows[0]["nMontoDeposito"].ToString();
                    txtMonCuota.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    txtMonAdel.Text = dtbAhoPrg.Rows[0]["nMonAdelantado"].ToString();
                    txtMontApe.Text = dtbAhoPrg.Rows[0]["nMontoCuota"].ToString();
                    btnAceptar.Enabled = true;
                    txtMontApe.Select();
                    txtMontApe.Focus();
                }
                else
                {
                    MessageBox.Show("La Cuenta no Tiene Cronograma de Depósitos..VERIFICAR...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clsDeposito.CNUpdNoUsoCuenta(idCta);
                    LimpiarCtrl();
                    LimpiarOtrosCtrl();
                    txtMontApe.Enabled = false;
                    btnAceptar.Enabled = false;
                    return;
                }
                chcCambiar.Visible = false;
            }
            else
            {
                chcCambiar.Visible = true;
            }

            if (lEsCtaCTS)
            {
                chcCambiar.Visible = false;
            }
            else
            {
                chcCambiar.Visible = true;
            }

            conBusCtaAho.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(false);
            conSolesDolar.iMagenMoneda(idMoneda);
            clsDeposito.CNUpdUsoCuenta(idCta, clsVarGlobal.User.idUsuario);
            this.DetalleSubProducto();
            CargarPagoIntereses();
            CargarRenovaciones();
            this.cboPagoInt.SelectedValue = Convert.ToInt32(dtbNumCuentas.Rows[0]["idPagoInt"].ToString());
            this.cboRenovacion.SelectedValue = Convert.ToInt32(dtbNumCuentas.Rows[0]["idrenovacion"].ToString());
            this.Comision();
            cboMotivoOperacion.Enabled = true;
            this.btnAceptar.Enabled = true;
            this.btnCancelar.Enabled = true;
            cboMotivoOperacion.Focus();
        }
        //==========================================================
        //--Establecer valores autorizacion de datos del cliente
        //==========================================================
        private void AutorizacionUsoDatos(int nNumSolicitud)
        {
            #region Autorizaciones de uso de datos 
            /*========================================================================================
            * VALIDACION DE AUTORIZACION DE USO DE DATOS
            ========================================================================================*/
            if (clsVarApl.dicVarGen["nIndTrabAutUsoDat"] == 1)
            {
                if (conBusCtaAho.nidTipoPersona == 1)
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 6 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.cCodCliente = "";
                        conAutorizacionUsuDatos1.idSolicitud = 0;
                        conAutorizacionUsuDatos1.pcNombre = titular.Field<string>("cNombre");
                        conAutorizacionUsuDatos1.pIdTipoPersona = titular.Field<int>("IdTipoPersona");
                        conAutorizacionUsuDatos1.pcDocumentoID = titular.Field<string>("cDocumentoID");
                        conAutorizacionUsuDatos1.pcDireccion = titular.Field<string>("cDireccion");
                        conAutorizacionUsuDatos1.pcTelefono = titular.Field<string>("cTelefono");

                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;

                    }
                }
                else
                {
                    var lstIntervinientes = dtbIntervCta.AsEnumerable().Where(x => Convert.ToInt16(x["idTipoInterv"]) == 7 && Convert.ToInt16(x["idTipoPersona"]) == 1);

                    foreach (var titular in lstIntervinientes)
                    {
                        conAutorizacionUsuDatos1.cCodCliente = "";
                        conAutorizacionUsuDatos1.idSolicitud = 0;
                        conAutorizacionUsuDatos1.pcNombre = titular.Field<string>("cNombre");
                        conAutorizacionUsuDatos1.pIdTipoPersona = titular.Field<int>("IdTipoPersona");
                        conAutorizacionUsuDatos1.pcDocumentoID = titular.Field<string>("cDocumentoID");
                        conAutorizacionUsuDatos1.pcDireccion = titular.Field<string>("cDireccion");
                        conAutorizacionUsuDatos1.pcTelefono = titular.Field<string>("cTelefono");

                        conAutorizacionUsuDatos1.lVisibleAutorizaUsoDatos = false;

                    }
                }
               
            } 

            #endregion
        }

        //==========================================================
        //--Calcular Nueva Tasa
        //==========================================================
        private void NuevaTasa(decimal nMontoApe)
        {
            if (Convert.ToInt16(cboTipoTasa.SelectedValue) == 2)
            {
                return;
            }
            //--Cargar Tasa
            if (string.IsNullOrEmpty(txtPlaProd.Text))
            {
                LimpiarCtrl();
                LimpiarOtrosCtrl();
                return;
            }
            int nPlazo = 0;
            nPlazo = Convert.ToInt32(txtPlaProd.Text.ToString());

            idTasa = 0;
            if (!recuperarTasa(nPlazo, idProd, nMontoApe, idMoneda, clsVarGlobal.nIdAgencia, idTipoPersona))
            {
                return;
            }

            //====================================
            //--Validar Pago de Intereses
            //====================================
            if (Convert.ToInt32(cboPagoInt.SelectedValue) == 1)
            {
                clsCNCalculosAho nInteres = new clsCNCalculosAho();
                Decimal /*era double*/nMontoInt = Convert.ToDecimal /*era ToDouble*/(txtMontApe.Text),
                        nTasa = Convert.ToDecimal /*era ToDouble*/(txtNuevaTasa.Text), nMonFavCliInt = 0.00m, nItf = 0.00m;
                int idMon = Convert.ToInt32(idMoneda), x_nPlazo = Convert.ToInt32(txtPlaProd.Text);
                Decimal /*era double*/nIntAdelantado, nMonNet;

                nIntAdelantado = Math.Round(nInteres.CalcularIntAdelantado(nTasa, x_nPlazo, nMontoInt), 2);
                nItf = FunTruncar.truncar((Decimal)/*era (double)*/clsVarGlobal.nITF / 100.00m * nIntAdelantado, 2, idMon);
                this.txtIntAdelantado.Text = string.Format("{0:#,#0.00}", nIntAdelantado);
                this.txtMonItfInt.Text = string.Format("{0:#,#0.00}", nItf);

                if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad Pago en Efectivo
                {
                    nMonNet = FunTruncar.redondearBCR(nIntAdelantado, ref nMonFavCliInt, idMon, true, false);
                }
                else
                {
                    nMonNet = nIntAdelantado;
                }

                this.txtRedondeoInt.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCliInt, 2));

                this.txtIntNeto.Text = string.Format("{0:#,#0.00}", nMonNet - nItf);
            }
            else
            {
                txtIntAdelantado.Text = "0.00";
                txtMonItfInt.Text = "0.00";
                this.txtRedondeoInt.Text = "0.00";
                txtIntNeto.Text = "0.00";
            }

            //================================================================
            //--Calcular Total de Interes al Pagar al final de periodo
            //================================================================
            clsCNCalculosAho nIntTot = new clsCNCalculosAho();
            Decimal /*era double*/nMontoDep = Convert.ToDecimal /*era ToDouble*/(txtMontTotalOpe.Text),
                    nTEM = Convert.ToDecimal /*era ToDouble*/(txtNuevaTasa.Text);
            int nPlaTot = Convert.ToInt32(txtPlaProd.Text);
            switch (Convert.ToInt32(cboPagoInt.SelectedValue))
            {
                case 1:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularIntAdelantado(nTEM, nPlaTot, nMontoDep)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                case 2:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularInteresAho(nTEM, nPlaTot, nMontoDep, 2)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                case 3:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularInteresAho(nTEM, 30, nMontoDep, 2)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                default:
                    txtTotInteres.Text = "0.00";
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
            }
        }

        //==========================================================
        //--Recuperar Tasa para el Producto
        //==========================================================
        private bool recuperarTasa(int nPlazo, int idProducto, Decimal nMonto, int idMoneda, int idAgencia, int idTipPe)
        {
            this.txtNuevaTasa.Text = "0.00";
            idTasa = 0;
            clsCNAperturaCta TasaAho = new clsCNAperturaCta();
            DataTable dt = TasaAho.RetornaTasaAhorros(nPlazo, idProducto, nMonto, idMoneda, idAgencia, idTipPe);
            if (dt.Rows.Count > 0)
            {
                this.txtNuevaTasa.Text = dt.Rows[0]["nTasaCompensatoria"].ToString();
                idTasa = Convert.ToInt32(dt.Rows[0]["idTasa"].ToString());
                return true;
            }
            else
            {
                MessageBox.Show("No se encontro la tasa para el subproducto", "Validación Tasa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCancelar.PerformClick();
                return false;
            }
        }

        //--================================================================
        //--Cargar Comisiones de la Cuenta
        //--================================================================
        private void Comision()
        {
            dtComision = null;
            int x_idTipoPago = Convert.ToInt32(cboModPago.SelectedValue);
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            int idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
            Decimal nMonto = Convert.ToDecimal (txtMontApe.Text);

            dtComision = clsBloq.RetornaComisionesCtaOpe(idProd, x_nTipOpe, Convert.ToInt32(idTipoPersona), Convert.ToInt16(idMoneda),
                                                        idCta, 1, clsVarGlobal.nIdAgencia, nMonto, nPlaCta, x_idTipoPago);
            if (dtComision.Rows.Count > 0)
            {
                Decimal nTotCom = Convert.ToDecimal (dtComision.Compute("SUM(nValorAplica)", ""));
                txtComisiones.Text = nTotCom.ToString();
                txtComisiones.Enabled = true;
            }
            else
            {
                txtComisiones.Text = "0.00";
                txtComisiones.Enabled = false;
            }
        }
        private void LimpiarCtrl()
        {
            //--Datos de la Cuenta
            txtProducto.Clear();
            txtTipCuenta.Clear();
            txtMoneda.Clear();
            txtTipPersona.Clear();
            txtPlaProd.Clear();

            //--Datos de Montos
            txtNuevaTasa.Text = "";
            txtITF.Text = "0.00";
            txtRedondeo.Text = "0.00";
            txtComisiones.Text = "0.00";
            txtTotInteres.Text = "0.00";
            txtIntAdelantado.Text = "0.00";
            txtRedondeoInt.Text = "0.00";
            txtMonItfInt.Text = "0.00";
            txtIntNeto.Text = "0.00";
            txtTasa.Text = "0.00";
            txtTasaEfectiva.Text = "0.00";
            txtTasaNominal.Text = "0.00";
            txtMontTotalOpe.Text = "0.00";
            txtMontApe.Text = "0.00";
            txtMontEnt.Text = "0.00";
            this.txtNroFir.Text = "0";
            ptbFirma.Image = null;
            conBusCtaAhoTransf.LimpiarControles();
            //Datos de Tipos de pago
            conBusCli.limpiarControles();

            //--Datos del Cliente
            if (dtgIntervinientes.Rows.Count > 0)
            {
                ((DataTable)dtgIntervinientes.DataSource).Rows.Clear();
            }
            //----------------------------
            idTasa = 0;
            idMoneda = 0;
            idTipoPersona = 0;
            idProd = 0;
            //--Ahorro Programado
            txtNumTotCuo.Text = "0";
            txtSaldoDep.Text = "0.00";
            txtNumCuoVen.Text = "0";
            txtNumCuoPen.Text = "0";
            txtAtraso.Text = "0";
            txtSaldoPen.Text = "0,00";
            txtMonCuota.Text = "0.00";
            txtMonAdel.Text = "0.00";

            if (dtgPlanDeposito.Rows.Count > 0)
            {
                ((DataTable)dtgPlanDeposito.DataSource).Rows.Clear();
            }

        }
        private void LimpiarOtrosCtrl()
        {
            conBusCtaAho.LimpiarControles();
            conCalcVuelto.limpiar();
        }
        public void DetalleSubProducto()
        {
            //--=====================================================
            //--Cargar parámetros del Producto y Validar
            //--=====================================================
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaParametrosProd(idProd, idMoneda, 2);
            if (Convert.ToInt32(dt.Rows[0]["idRpta"].ToString()) == 0)
            {
                chcITF.Checked = Convert.ToBoolean(dt.Rows[0]["lIsAfectoITF"].ToString());
                chcInactiva.Checked = Convert.ToBoolean(dt.Rows[0]["lIsInactiva"].ToString());
                chcRenov.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRenovProd"].ToString());
                chcCert.Checked = Convert.ToBoolean(dt.Rows[0]["lIsRequeCert"].ToString());
                //--Asignación de variables Públicas
                lEsTrabFin = Convert.ToBoolean(dt.Rows[0]["lIsTrabFinan"].ToString());
                lEsReqPagInt = Convert.ToBoolean(dt.Rows[0]["lIsReqPagInt"].ToString());
                lEsDefTipPagInt = Convert.ToBoolean(dt.Rows[0]["lIsDefTipPagInt"].ToString());
                lEsReqEmpleador = Convert.ToBoolean(dt.Rows[0]["lIsReqEmpleador"].ToString());
                lEsAhoProg = Convert.ToBoolean(dt.Rows[0]["lIsDepAhoProg"].ToString());
                lEsCtaCTS = Convert.ToBoolean(dt.Rows[0]["lIsProdCTS"].ToString());
                p_nMonMinSalDis = Convert.ToDecimal (dt.Rows[0]["nMonMinSalDis"].ToString());
                lIsDepMenEdad = Convert.ToBoolean(dt.Rows[0]["lIsDepMenEdad"].ToString());
                if (Convert.ToInt16(idTipoPersona) == 3)
                {
                    chcITF.Checked = false;
                    lIsAfectoITF = false;
                }

                //--Validar si es Cta para Orden de Pago
                if (Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))
                {
                    chcOrdPago.Checked = true;
                }

            }
            else
            {
                MessageBox.Show(dt.Rows[0]["cMensage"].ToString(), "Apertura de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void calcular()
        {
            decimal nMonto;
            Decimal nMonFavCli = 0.00m;

            if (string.IsNullOrEmpty(this.txtMontApe.Text))
            {
                nMonto = 0;
                txtMontApe.Text = "0.00";
                txtITF.Text = "0.00";
                txtComisiones.Text = "0.00";
                txtIntAdelantado.Text = "0.00";
                txtRedondeoInt.Text = "0.00";
                txtMonItfInt.Text = "0.00";
                txtIntNeto.Text = "0.00";
                txtMontTotalOpe.Text = "0.00";
                txtMontEnt.Text = "0.00";
                return;
            }
            else
            {
                nMonto = Convert.ToDecimal(this.txtMontApe.Text.ToString());
                
                /*if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad Pago en Efectivo
                {
                    nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, idMoneda, true, true);
                }

                this.txtMontApe.KeyPress -= txtMontApe_KeyPress;
                this.txtMontApe.Leave -= txtMontApe_Leave;
                this.txtMontApe.TextChanged -= txtMontApe_TextChanged;

                this.txtMontApe.Text = string.Format("{0:#,#0.00}", nMonto);

                this.txtMontApe.KeyPress += txtMontApe_KeyPress;
                this.txtMontApe.Leave += txtMontApe_Leave;
                this.txtMontApe.TextChanged += txtMontApe_TextChanged;
                 * */
                //--==========================================================
                //--Calcular Comisiones de la Cuenta
                //--==========================================================
                Comision();
                Decimal nComision = Convert.ToDecimal (txtComisiones.Text);

                //--==========================================================
                //--Validar Monto Ingresado
                //--==========================================================
                if ((Decimal)nMonto < nComision)
                {
                    txtITF.Text = "0.00";
                    txtComisiones.Text = "0.00";
                    txtIntAdelantado.Text = "0.00";
                    txtRedondeoInt.Text = "0.00";
                    txtMonItfInt.Text = "0.00";
                    txtIntNeto.Text = "0.00";
                    txtMontApe.Text = "0.00";
                    txtMontTotalOpe.Text = "0.00";
                    txtMontApe.Text = "0.00";
                    this.txtMontEnt.Text = "0.00";
                    return;
                }


                //--==========================================================
                //--Calcular ITF
                //--==========================================================
                Decimal nITF;
                if (!lIsAfectoITF)
                {
                    nITF = 0.00m;
                }
                else
                {
                    nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Decimal)nMonto, 2, idMoneda);
                }
                if (Convert.ToInt32(idTipoPersona) == 3)
                {
                    nITF = 0.00m;
                }

                //--Transferencias, entre las mismas Cuentas, no debe calcular Itf
                if (Convert.ToInt32(cboModPago.SelectedValue) == 2 && rbtMismaCta.Checked == true) //--Transferencias
                {
                    nITF = 0.00m;
                }

                this.txtITF.Text = string.Format("{0:#,#0.00}", nITF);
                this.txtComisiones.Text = string.Format("{0:#,#0.00}", Math.Round(nComision, 2));

                Decimal nMontoTotal = 0;

                nMontoTotal = (Decimal)nMonto - Math.Round(nITF, 2) - (Decimal)Math.Round(nComision, 2);
                if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad Pago en Efectivo
                {
                    nMonto = FunTruncar.redondearBCR(nMonto, ref nMonFavCli, idMoneda, true, true);
                    //nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavCli, idMoneda, true, true);
                }
                this.txtMontTotalOpe.Text = string.Format("{0:#,#0.00}", ((Decimal)nMontoTotal));// + Math.Round(nMonFavCli, 2)));
                this.txtMontEnt.Text = string.Format("{0:#,#0.00}", ((Decimal)nMonto)); //- nMonFavCli));
                this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCli, 2));
            }

            //====================================
            //--Validar Pago de Intereses
            //====================================
            if (Convert.ToInt32(cboPagoInt.SelectedValue) == 1)
            {
                clsCNCalculosAho nInteres = new clsCNCalculosAho();
                Decimal nMontoInt = Convert.ToDecimal (txtMontApe.Text),
                        nTasa = Convert.ToDecimal (txtTasa.Text), nMonFavCliInt = 0.00m, nItf = 0.00m;
                int idMon = Convert.ToInt32(idMoneda), nPlazo = Convert.ToInt32(txtPlaProd.Text);
                Decimal nIntAdelantado, nMonNet;

                nIntAdelantado = Math.Round(nInteres.CalcularIntAdelantado(nTasa, nPlazo, nMontoInt), 2);
                nItf = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * nIntAdelantado, 2, idMon);
                this.txtIntAdelantado.Text = string.Format("{0:#,#0.00}", nIntAdelantado);
                this.txtMonItfInt.Text = string.Format("{0:#,#0.00}", nItf);

                if (Convert.ToInt16(cboModPago.SelectedValue) == 1)  //Modalidad Pago en Efectivo
                {
                    nMonNet = FunTruncar.redondearBCR(nIntAdelantado, ref nMonFavCliInt, idMon, true, false);
                }
                else
                {
                    nMonNet = nIntAdelantado;
                }

                this.txtRedondeoInt.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavCliInt, 2));

                this.txtIntNeto.Text = string.Format("{0:#,#0.00}", nMonNet - nItf);
            }
            else
            {
                txtIntAdelantado.Text = "0.00";
                txtMonItfInt.Text = "0.00";
                this.txtRedondeoInt.Text = "0.00";
                txtIntNeto.Text = "0.00";
            }

            //================================================================
            //--Calcular Total de Interes al Pagar al final de periodo
            //================================================================
            clsCNCalculosAho nIntTot = new clsCNCalculosAho();
            Decimal /*era double*/nMontoDep = Convert.ToDecimal /*era ToDouble*/(txtMontTotalOpe.Text),
                    nTEM = Convert.ToDecimal /*era ToDouble*/(txtTasa.Text);
            if (string.IsNullOrEmpty(txtPlaProd.Text))
            {
                return;
            }
            int nPlaTot = Convert.ToInt32(txtPlaProd.Text);
            switch (Convert.ToInt32(cboPagoInt.SelectedValue))
            {
                case 1:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularIntAdelantado(nTEM, nPlaTot, nMontoDep)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                case 2:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularInteresAho(nTEM, nPlaTot, nMontoDep, 2)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                case 3:
                    txtTotInteres.Text = Math.Round(Convert.ToDecimal(nIntTot.CalcularInteresAho(nTEM, 30, nMontoDep, 2)), 2).ToString();
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
                default:
                    txtTotInteres.Text = "0.00";
                    lblTasa.Text = "Total Int. a Pagar:";
                    break;
            }
            if ((int)cboModPago.SelectedValue == 1)
            {
                if (conCalcVuelto.nMontoTotalpago != Convert.ToDecimal(txtMontEnt.Text.Trim()))
                {
                    conCalcVuelto.limpiar();
                }
                conCalcVuelto.nMontoTotalpago = Convert.ToDecimal(txtMontEnt.Text.Trim());
                conCalcVuelto.Enabled = true;
                conCalcVuelto.CalculoDirecto(Convert.ToDecimal(txtMontEnt.Text.Trim()));
                conCalcVuelto.txtMonEfectivo.Focus();
                conCalcVuelto.txtMonEfectivo.SelectAll();
            }
        }

        private void grbBase10_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.idcuenta.ToString()) && Convert.ToInt32(conBusCtaAho.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }

            if (!string.IsNullOrEmpty(conBusCtaAhoTransf.idcuenta.ToString()) && Convert.ToInt32(conBusCtaAhoTransf.idcuenta) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAhoTransf.idcuenta));
            }
            this.LimpiarCtrl();
            this.LimpiarOtrosCtrl();
            LimpiarCtrCheqGer();
            conBusCtaAhoTransf.LimpiarControles();
            cboModPago.SelectedValue = 1;
            conBusCtaAho.btnBusCliente.Enabled = true;
            this.btnAceptar.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            conCalcVuelto.Enabled = false;
            chcCambiar.Checked = false;
            chcCambiar.Enabled = false;
            chcCambiar.Visible = true;
            rbtMismaCta.Checked = false;
            rbtOtrasCuentas.Checked = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            dtpFecDoc.Value = clsVarGlobal.dFecSystem;
            dtpFecCheqGer.Value = clsVarGlobal.dFecSystem;
            conBusCtaAho.txtCodAge.Focus();
            conAutorizacionUsuDatos1.limpiar();
        }
        //==========================================================
        //--Cargar Tipos de Renovaciones
        //==========================================================
        private void CargarRenovaciones()
        {
            //cboRenovacion.Enabled = true;
            if (chcRenov.Checked)
            {
                clsCNOperacionDep deposito = new clsCNOperacionDep();
                DataTable dt = deposito.ListaTipoRenovacion();
                if (dt.Rows.Count > 0)
                {
                    this.cboRenovacion.DataSource = dt;
                    this.cboRenovacion.ValueMember = dt.Columns["IdRenovacion"].ToString();
                    this.cboRenovacion.DisplayMember = dt.Columns["cDescripcion"].ToString();
                }
                else
                {
                    MessageBox.Show("No Existe Tipos de Renovaciones, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                cboRenovacion.Enabled = false;
            }

        }

        //==========================================================
        //--Cargar Modalidades de Pago
        //==========================================================
        private void CargarPagoIntereses()
        {
            //cboPagoInt.Enabled = true;
            if (lEsReqPagInt)
            {
                if (lEsDefTipPagInt)
                {
                    clsCNOperacionDep deposito = new clsCNOperacionDep();
                    DataTable dt = deposito.ListaPagoInteresProd(idProd);
                    if (dt.Rows.Count > 0)
                    {
                        this.cboPagoInt.DataSource = dt;
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Existe Tipos de pago de Interes para el Concepto, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    clsCNOperacionDep deposito = new clsCNOperacionDep();
                    DataTable dt = deposito.LisTiposPagoInteres();
                    if (dt.Rows.Count > 0)
                    {
                        this.cboPagoInt.DataSource = dt;
                        this.cboPagoInt.ValueMember = dt.Columns["IdPagoInt"].ToString();
                        this.cboPagoInt.DisplayMember = dt.Columns["cDescripcion"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No Existe Tipos de pago de Intereses, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                cboPagoInt.Enabled = false;
            }
        }
        //==========================================================
        //--Cargar Modalidades de Pago--Apertura
        //==========================================================
        private void CargarModalidadPago()
        {
            clsCNOperacionDep deposito = new clsCNOperacionDep();
            DataTable dt = deposito.ListaModalidadesPago(9);
            if (dt.Rows.Count > 0)
            {
                this.cboModPago.DataSource = dt;
                this.cboModPago.ValueMember = dt.Columns["IdModpago"].ToString();
                this.cboModPago.DisplayMember = dt.Columns["cDescripcion"].ToString();


            }
            else
            {
                MessageBox.Show("No Existe Modalidades de Pago, VERIFICAR", "Validar Apertura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cboModPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboModPago.SelectedIndex > 0)
            {
                txtcNroCuenta.Visible = false;
                txtMontoDoc.Text = txtMontApe.Text;
                int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
                switch (nCodModPago)
                {
                    case 1: //--Pago En Efectivo
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        tbcPagos.SelectedIndex = 0;
                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                    case 2: //--Pago con Transferencia
                        if (Convert.ToInt32(idTipoCuenta) == 1)
                        {
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTransf"].Enabled = true;
                            this.tbcPagos.Controls["tabCheq"].Enabled = false;
                            lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        }
                        else
                        {
                            MessageBox.Show("Pago Con Transferencia es Solo para Tipos de CUENTA INDIVIDUAL", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbcPagos.SelectedIndex = 0;
                            this.tbcPagos.Controls["tabTransf"].Enabled = false;
                            this.tbcPagos.Controls["tabCheq"].Enabled = false;
                            this.cboModPago.SelectedValue = 1;
                            lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        }
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        break;
                    case 3://--Apertura con cheque Externo
                        if (Convert.ToInt32(this.cboModPago.SelectedValue) == 4)
                        {
                            txtDiaVal.Text = "0";
                            txtDiaVal.Enabled = false;
                        }
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        cboTipoEnt.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                        txtMontoDoc.Text = txtMontApe.Text;
                        lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        break;
                    case 4://--Apertura con Interbancario
                        if (Convert.ToInt32(this.cboModPago.SelectedValue) == 4)
                        {
                            txtDiaVal.Text = "0";
                            txtDiaVal.Enabled = false;
                        }
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        cboTipoEnt.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                        txtMontoDoc.Text = txtMontApe.Text;
                        lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        break;
                    case 5: //--Pago con OP
                        tbcPagos.SelectedIndex = 1;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = true;
                        cboTipoEnt.SelectedValue = clsVarApl.dicVarGen["idTipoInstFin"];
                        cboEnt.SelectedValue = clsVarApl.dicVarGen["idInstFin"];
                        cboTipoEnt.Enabled = false;
                        cboEnt.Enabled = false;
                        txtDiaVal.Text = "0";
                        txtDiaVal.Enabled = false;
                        txtMontoDoc.Text = "0.00";
                        txtMontoDoc.Enabled = false;
                        btnBuscaOP.Visible = true;
                        lblTipPago.Text = "MODALIDAD DE APERTURA: " + cboModPago.Text;
                        conCalcVuelto.limpiar();
                        conCalcVuelto.Enabled = false;
                        break;
                    case 6://--Apertura con cheque de gerencia
                        tbcPagos.SelectedIndex = 2;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text;
                        break;
                    default: //--No Definido Tipo de Pago
                        tbcPagos.SelectedIndex = 0;
                        this.tbcPagos.Controls["tabTransf"].Enabled = false;
                        this.tbcPagos.Controls["tabCheq"].Enabled = false;
                        lblTipPago.Text = "MODALIDAD DE PAGO: " + cboModPago.Text; ;
                        tbcPagos.SelectedIndex = 0;
                        conCalcVuelto.txtMonEfectivo.Focus();
                        break;
                }
            }
            else
            {
                tbcPagos.SelectedIndex = 0;
                this.tbcPagos.Controls["tabTransf"].Enabled = false;
                this.tbcPagos.Controls["tabCheq"].Enabled = false;
                lblTipPago.Text = "MODALIDAD DE PAGO: EFECTIVO";
            }
            if (!string.IsNullOrEmpty(this.conBusCtaAho.txtNroCta.Text.ToString()))
            {
                calcular();
            }
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscaOP_Click(object sender, EventArgs e)
        {
            p_idCta = 0;

            if (!ValidarOP())
            {
                return;
            }


            int idCuenta = Convert.ToInt32(txtNroCta.Text),
                            nNumero = Convert.ToInt32(txtNroDocu.Text),
                            nSerie = Convert.ToInt32(txtSerie.Text),
                            nTipValorado = 0;
            switch (Convert.ToInt16(cboModPago.SelectedValue))
            {
                case 3:  // Cheque
                    nTipValorado = 3;
                    break;
                case 5:  // Orden de Pago
                    nTipValorado = 1;
                    break;
            }
            p_idCta = idCuenta;

            //--===================================================================================
            //--ValidarBloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(p_idCta, 11, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--===================================================================================
            //--Validaciones de la Cuenta
            //--===================================================================================
            clsCNAperturaCta objAho = new clsCNAperturaCta();
            DataTable dt = objAho.RetornaDatosOrdenPago(nSerie, nNumero, idCuenta, nTipValorado, idMoneda);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["idMoneda"].ToString()) != Convert.ToInt32(cboMonedaDoc.SelectedValue))
                {
                    MessageBox.Show("La Moneda de la Orden de Pago, es Distinto a la Apertura", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToDecimal (dt.Rows[0]["nSaldoDis"].ToString()) < Convert.ToDecimal (txtMontTotalOpe.Text))
                {
                    MessageBox.Show("El Saldo Disponible es Menor al Monto de la Operación", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!Convert.ToBoolean(dt.Rows[0]["lIsCtaOrdPago"].ToString()))  //Modificado
                {
                    MessageBox.Show("La Cuenta no Puede Emitir Ordenes de Pago", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                txtMontoDoc.Text = txtMontTotalOpe.Text; //Modificado

                //--===================================================================================
                //--Validar Datos para el Retiro
                //--===================================================================================
                string Mensaje = "";
                clsCNDeposito clsDatCta = new clsCNDeposito();
                if (!clsDatCta.CNValidaOperacionAho(p_idCta, "1", 11, Convert.ToDecimal (txtMontTotalOpe.Text), ref Mensaje))
                {
                    MessageBox.Show(Mensaje, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                txtMontoDoc.Text = dt.Rows[0]["nSaldoDis"].ToString();
                txtNroCta.Enabled = false;
                txtNroDocu.Enabled = false;
                txtSerie.Enabled = false;

                clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
            }
            else
            {
                MessageBox.Show("No se Encontro Datos de la Orden de Pago", "Validar Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private bool ValidarOP()
        {
            if (string.IsNullOrEmpty(txtNroCta.Text) || Convert.ToInt32(txtNroCta.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Numero Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCta.Focus();
                txtNroCta.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtNroDocu.Text) || Convert.ToInt32(txtNroDocu.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Numero del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroDocu.Focus();
                txtNroDocu.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtSerie.Text) || Convert.ToInt32(txtSerie.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar la Serie del Documento", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNroCta.Focus();
                txtNroCta.SelectAll();
                return false;
            }
            return true;
        }

        //====================================================
        //---Mostrar Firma
        //====================================================
        private void MostrarFirma(int idCliente)
        {
            ptbFirma.Image = null;
            var objFirma = cnFirma.retornaFirma(idCliente);
            if (objFirma != null)
            {
                ptbFirma.Image = objFirma.imgFirma;
                ptbFirma.Refresh();
            }

        }

        private void LimpiarCtrCheqGer()
        {
            txtNroCuentaGer.Text = "";
            txtNroCheqGer.Text = "";
            txtSerieCheqGer.Text = "";
            cboEntidadCheGer.SelectedValue = 1;
            cboMonedaCheGer.SelectedValue = 1;
        }

        //====================================================
        //---Validar Datos Tipos de Pago
        //====================================================
        private bool ValidarDatosTipPago()
        {
            int nCodModPago = Convert.ToInt32(this.cboModPago.SelectedValue);
            switch (nCodModPago)
            {
                case 1: //--Pago En Efectivo
                    if (string.IsNullOrEmpty(conCalcVuelto.txtMonEfectivo.Text))
                    {
                        MessageBox.Show("Debe de registrar el monto de efectivo a recibir", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conCalcVuelto.txtMonEfectivo.Focus();
                        conCalcVuelto.txtMonEfectivo.SelectAll();
                        return false;
                    }
                    if (conCalcVuelto.txtMonEfectivo.nDecValor < Convert.ToDecimal(txtMontTotalOpe.Text))
                    {
                        MessageBox.Show("El Monto a recibir no puede ser menor que el monto de la transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conCalcVuelto.txtMonEfectivo.Focus();
                        conCalcVuelto.txtMonEfectivo.SelectAll();
                        return false;
                    }

                    break;
                case 2: //--Pago con Transferencia
                    if (string.IsNullOrEmpty(conBusCtaAhoTransf.txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Vincular con la Cuenta del Cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }
                    if (conBusCtaAhoTransf.idcuenta <= 0)
                    {
                        MessageBox.Show("Debe Vincular con la Cuenta del Cliente", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCtaAhoTransf.btnBusCliente.Focus();
                        return false;
                    }

                    break;
                case 3: //--Deposito Con Cheque
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de Cuenta del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        txtNroCta.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMontoDoc.Text))
                    {
                        MessageBox.Show("Debe Registrar el Monto del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (Convert.ToDecimal (txtMontoDoc.Text) <= 0)
                    {
                        MessageBox.Show("El Monto del Cheque no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (Convert.ToDecimal (txtMontoDoc.Text) < Convert.ToDecimal (txtMontTotalOpe.Text))
                    {
                        MessageBox.Show("El Monto del Cheque, es Menor al Monto de Deposito", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización del Cheque", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDiaVal.Focus();
                        txtDiaVal.Select();
                        return false;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 4: //--Deposito Interbancario
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de Cuenta del Vocher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        txtNroCta.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtMontoDoc.Text))
                    {
                        MessageBox.Show("Debe Registrar el Monto del Voucher", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (Convert.ToDecimal (txtMontoDoc.Text) <= 0)
                    {
                        MessageBox.Show("El Monto del Voucher no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (Convert.ToDecimal (txtMontoDoc.Text) < Convert.ToDecimal (txtMontTotalOpe.Text))
                    {
                        MessageBox.Show("El Monto del Voucher, es Menor al Monto de Deposito", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 5:// Orden de Pago
                    if (string.IsNullOrEmpty(txtNroCta.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de Cuenta de la Orden de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroCta.Focus();
                        txtNroCta.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroDocu.Text))
                    {
                        MessageBox.Show("Debe Registrar el Número de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNroDocu.Focus();
                        txtNroDocu.Select();
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerie.Text))
                    {
                        MessageBox.Show("Debe Registrar la Serie de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSerie.Focus();
                        txtSerie.Select();
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtDiaVal.Text))
                    {
                        MessageBox.Show("Debe Registrar los Días de Valorización de la OP", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtDiaVal.Focus();
                        txtDiaVal.Select();
                        return false;
                    }

                    if (Convert.ToDecimal (txtDiaVal.Text) < 0)
                    {
                        MessageBox.Show("Los Días de Valorización no es Válido", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    break;
                case 6: //--Retiro con Cheque de Gerencia
                    if (string.IsNullOrEmpty(txtNroCuentaGer.Text))
                    {
                        MessageBox.Show("Número de Cuenta no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtNroCheqGer.Text))
                    {
                        MessageBox.Show("Número de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (string.IsNullOrEmpty(txtSerieCheqGer.Text))
                    {
                        MessageBox.Show("Número de Serie de Cheque no Válido para la Transacción", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    if (cboEntidadCheGer.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe estar Seleccionado la Entidad Financiera", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboEntidadCheGer.Focus();
                        return false;
                    }
                    break;
            }
            return true;
        }

        private bool ValidarReglas()
        {
            String cCumpleReglas = "";
            int x_idCliente = 0;
            //idProd = Convert.ToInt16(cboSubProducto.SelectedValue);
            x_idCliente = clsVarGlobal.User.idCli;
            clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas = ValidaReglasDinamicas.ValidarReglas(ArmarTablaParametros(), this.Name,
                                                   clsVarGlobal.nIdAgencia, x_idCliente,
                                                   1, idMoneda, idProd,
                                                   Decimal.Parse(txtMontApe.Text), 0, clsVarGlobal.dFecSystem,
                                                   2, 1,
                                                   clsVarGlobal.User.idUsuario, ref nNivAuto);
            if (cCumpleReglas.Equals("NoCumple"))
            {
                btnAceptar.Enabled = false;
                return false;
            }
            return true;
        }

        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelValida";
            drfila[1] = "9";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliRegla";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProducto";
            drfila[1] = idProd.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPersona";
            drfila[1] = idTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoCuenta";
            drfila[1] = idTipoCuenta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPago";
            drfila[1] = cboModPago.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMoneda";
            drfila[1] = idMoneda.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lReqAutorizacion";
            drfila[1] = ((DataRowView)cboMotivoOperacion.SelectedItem)["lReqAutorizacion"].ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMotivoOperacion";
            drfila[1] = cboMotivoOperacion.SelectedValue.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lisCtaCTS";
            drfila[1] = lEsCtaCTS.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMonMinOpe";
            drfila[1] = nMonMinOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);

            //drfila = dtTablaParametros.NewRow();
            //drfila[0] = "nMonMinApe";
            //drfila[1] = txtMonMinApe.nDecValor.ToString();
            //dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nPlazoAho";
            drfila[1] = nPlaCta.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOperacion";
            drfila[1] = x_nTipOpe.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroFirmas";
            drfila[1] = txtNroFir.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = txtMontApe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            //drfila = dtTablaParametros.NewRow();
            //drfila[0] = "nMontoIntangible";
            //drfila[1] = txtMontoIntang.nDecValor.ToString();
            //dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoComision";
            drfila[1] = txtComisiones.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoITF";
            drfila[1] = txtITF.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRedondeo";
            drfila[1] = txtRedondeo.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoApertura";
            drfila[1] = txtMontTotalOpe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoRecibir";
            drfila[1] = txtMontApe.nDecValor.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEmpresa";
            drfila[1] = conBusCli.txtCodCli.Text;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nNroInterv";
            drfila[1] = dtInt.Rows.Count.ToString();
            dtTablaParametros.Rows.Add(drfila);

            string idClientes = "";
            string idIntervinientes = "";
            for (int i = 0; i < this.dtInt.Rows.Count; i++)
            {
                idClientes = idClientes + this.dtgIntervinientes.Rows[i].Cells["idCli"].Value.ToString() + ",";
                idIntervinientes = idIntervinientes + this.dtgIntervinientes.Rows[i].Cells["idTipoInterv"].Value.ToString() + ",";
            }

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idClientes";
            drfila[1] = "'" + idClientes.Substring(0, idClientes.Length - 1) + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idIntervinientes";
            drfila[1] = "'" + idIntervinientes.Substring(0, idIntervinientes.Length - 1) + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.Year.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Month.ToString() + "-" +
                            clsVarGlobal.dFecSystem.Day.ToString() + "'";
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
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstado";
            drfila[1] = clsVarGlobal.User.idEstado.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void cboTipoEnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoEnt.SelectedIndex >= 0)
            {
                this.cboEnt.CargarEntidades((int)cboTipoEnt.SelectedValue);
            }
        }

        private void cboTipoEnt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTipoEnt.SelectedIndex >= 0)
            {
                this.cboEnt.CargarEntidades((int)cboTipoEnt.SelectedValue);
            }
        }

        private void btnBusSolicitud1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text.Trim()))
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
            conBusCtaAho.idcuenta = 0;
            conBusCtaAhoTransf.idcuenta = 0;
            p_idCta = 0;
            p_idCtaTranf = 0;
            LimpiarCtrl();
            LimpiarOtrosCtrl();
            LimpiarCtrCheqGer();
            ptbFirma.Image = null;
            ptbFirma.Refresh();
            btnAceptar.Enabled = false;
            conCalcVuelto.Enabled = false;
            frmBusSolAhoPen frmBusSolAhor = new frmBusSolAhoPen();
            frmBusSolAhor.pidAgencia = clsVarGlobal.nIdAgencia;
            frmBusSolAhor.ShowDialog();
            if (frmBusSolAhor.idcuenta > 0)
            {
                conBusCtaAho.txtCodAge.Text = (frmBusSolAhor.cNrocuenta).ToString().Substring(3, 3);
                conBusCtaAho.txtCodMod.Text = (frmBusSolAhor.cNrocuenta).ToString().Substring(6, 3);
                conBusCtaAho.txtCodMon.Text = (frmBusSolAhor.cNrocuenta).ToString().Substring(9, 1);
                conBusCtaAho.txtNroCta.Text = (frmBusSolAhor.cNrocuenta).ToString().Substring(10, 12);
                conBusCtaAho.txtCodCli.Text = (frmBusSolAhor.cCodCliente).ToString();
                conBusCtaAho.txtNroDoc.Text = (frmBusSolAhor.cDocCli).ToString();
                conBusCtaAho.txtNombre.Text = (frmBusSolAhor.cNombre).ToString();
                conBusCtaAho.pcCodCliLargo = frmBusSolAhor.cCodCliente;
                conBusCtaAho.idTipoDocumento = frmBusSolAhor.pIdTipoDocumento;
                conBusCtaAho.nidTipoPersona = frmBusSolAhor.pIdTipoPersona;
                if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
                {
                    conBusCtaAho.idcuenta = frmBusSolAhor.idcuenta;
                    p_idCta = Convert.ToInt32(frmBusSolAhor.idcuenta);
                    DatosCuenta(p_idCta);
                    if (p_idCta > 0)
                    {
                        DatosTipoPago(p_idCta);
                    }
                }

            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            frmComisionesCta frmComisCta = new frmComisionesCta();
            frmComisCta.dtCom = dtComision;
            frmComisCta.ShowDialog();
        }

        private void dtgIntervinientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                MostrarFirma(Convert.ToInt32(dtgIntervinientes.CurrentRow.Cells["idCli"].Value));
            }
        }

        private void dtgIntervinientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgIntervinientes.Rows.Count > 0)
            {
                MostrarFirma(Convert.ToInt32(dtgIntervinientes.CurrentRow.Cells["idCli"].Value));
            }
        }

        private void frmConfirmApeDep_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_idCta > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
            }
            if (p_idCtaTranf > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(p_idCtaTranf);
            }
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

            //  List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "RptVouchers.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        }

        private void lblBase37_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {

        }

        private void btnBusCheGer_Click(object sender, EventArgs e)
        {

        }

        private void txtMontApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcular();
                NuevaTasa(Convert.ToDecimal(txtMontTotalOpe.Text));
            }
        }

        private void txtMontApe_Leave(object sender, EventArgs e)
        {
            calcular();
            NuevaTasa(Convert.ToDecimal(txtMontTotalOpe.Text));
        }

        private void txtMontApe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontApe.Text) || txtMontApe.Text == "0")
            {
                this.txtComisiones.Text = "0.00";
                this.txtITF.Text = "0.00";
                this.txtMontTotalOpe.Text = "0.00";
                this.txtRedondeo.Text = "0.00";
                this.txtMontEnt.Text = "0.00";
            }
        }

        private void chcCambiar_CheckedChanged(object sender, EventArgs e)
        {
            if (chcCambiar.Checked)
            {
                txtMontApe.Enabled = true;
                txtMontApe.Focus();
                txtMontApe.SelectAll();
            }
            else
            {
                txtMontApe.Enabled = false;
            }
        }

        private void conBusCtaAho_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCtaAho.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCtaAho.txtNroDoc.Text);
            }
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCtaAho.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        private void EncuestaExperienciaCliente()
        {
            int nTipoOperacion = 9;
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
                        frm.cDocumentocliente = conBusCtaAho.txtNroDoc.Text;
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

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }

    }
}
