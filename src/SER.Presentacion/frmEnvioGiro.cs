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
using CLI.CapaNegocio;
using SER.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using DEP.CapaNegocio;
using CLI.Presentacion;

namespace SER.Presentacion
{
    public partial class frmEnvioGiro : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        Decimal nMontoCuentaCoriente = 0.00m; //Monto disponible (se usa cuando se hace envío de giro con cargo a cuenta)
        int idMonedaCuenta          = 0; // Moneda de la Cuenta Corriente (se usa cuando se hace envío de giro con cargo a cuenta)
        String cCuenta = String.Empty;

        private const int idTipoOpeRegimenReforzado = 177;

        #endregion

        public frmEnvioGiro()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmEnvioGiro_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            activarControlObjetos(this, EventoFormulario.INICIO);

            //=============== Cargar Combo Modalidad ============================>
            cboModalidad.SelectedIndexChanged -= new
            EventHandler(cboModalidad_SelectedIndexChanged);

            Boolean lEsClienteInstitucion = false;
            cboModalidad.DataSource = cncontrolserv.ObtenerModalidadPagoEnvioGiro(lEsClienteInstitucion);
            cboModalidad.ValueMember    = "idModalidadPagoGiro";
            cboModalidad.DisplayMember  = "cModalidadPagoGiro";

            cboModalidad.SelectedIndexChanged += new
            EventHandler(cboModalidad_SelectedIndexChanged);
            //===================================================================>
            //=============== Cargar agencia destino ============================>
            this.cboAgencia.SelectedIndexChanged -= new EventHandler(cboAgencia_SelectedIndexChanged);
            cboAgencia.SoloAptosAgiros();

            //===================================================================>
            HabDesControles(false);
            //habilita combo de motivos
            this.cboMotivoOpe.ListarMotivoOperacion(13, clsVarGlobal.PerfilUsu.idPerfil);
            if (this.cboMotivoOpe.Items.Count == 0) //verifica si el perfil tiene motivos de operación
            {
                MessageBox.Show("No existen motivos de operación para este perfil", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnNuevo.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // ---- quitamos los eventos de calcular ------------------------------//
            this.cboAgencia.SelectedIndexChanged -= new EventHandler(cboAgencia_SelectedIndexChanged);
            this.txtMonGiro.Validated -= new EventHandler(txtMonGiro_Validated);
            //----------------------------------------------------------------------------------//
            limpiarControles();
            HabDesControles(false);
            grbRem.Visible = false;
            conBusCliRem.Visible = true;
            grbDes.Visible = false;
            conBusCliDes.Visible = true;
            chcCliRem.Enabled = false;
            chcCliRem.Checked = false;
            chcCliDes.Enabled = false;
            chcCliDes.Checked = false;
            conBusCliRem.txtCodCli.Enabled = false;
            conBusCliDes.txtCodCli.Enabled = false;
            this.cboAgencia.SelectedIndex = 0;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnNuevo.Enabled = true;

            //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
            cboModalidad.DataSource = null;
            cboModalidad.Items.Clear();
            this.cboModalidad.Enabled = false;
            //---------------------------------------------------------------------------->
            grbCuentaAhorro.Enabled = false;

        }

        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);

            if (!chcCliRem.Checked)
            {
                x_idCliente = conBusCliRem.idCli;

            }
                        
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
                                                                    0,                      //idDocument
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
            string cNroDni = this.conBusCliRem.txtNroDoc.Text;
            if (cNroDni =="")
            {
                cNroDni = "0";
            }


            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
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
            drfila[1] = this.conBusCliRem.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDni";
            drfila[1] = cNroDni;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMonGiro.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = Convert.ToString(Convert.ToInt32(chcCliRem.Checked));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = Convert.ToString(Convert.ToInt32(chcCliDes.Checked));
            dtTablaParametros.Rows.Add(drfila);
            
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = Convert.ToString(txtCBDNIRem.Text);
            dtTablaParametros.Rows.Add(drfila);
                        
            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniDes";
            drfila[1] = Convert.ToString(txtCBDNIDes.Text);
            dtTablaParametros.Rows.Add(drfila);
            

            return dtTablaParametros;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(this.conBusCliRem.idCli, this.txtCBDNIRem.Text.Trim(), clsVarGlobal.nIdAgencia, 13, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            this.registrarRastreo(this.conBusCliRem.idCli, this.conBusCliDes.idCli, "Inicio - Registro de evio de giro", btnGrabar);

            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoGir = Convert.ToDecimal(this.txtTotal.Text);
            Decimal nMontoCom = Convert.ToDecimal(this.txtMonComGiro.Text);


            /*========================================================================================
            * Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(Convert.ToDecimal(txtMonGiro.Text)), Convert.ToString(Convert.ToInt32(idMon))))
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
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusCliRem.idCli,
                                                                               idMon,
                                                                               0,
                                                                               conBusCliDes.idCli,
                                                                               nMontoGir);
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }
            //===================================================================
            //--Encriptar la Clave
            //===================================================================
            clsCNSeguridad bEncryp = new clsCNSeguridad();
            string cClave = bEncryp.GeneratePasswordHash(this.txtClave.Text);

            //===================================================================
            //--Datos del Remitente
            //===================================================================
            int idCliRem;
            if (string.IsNullOrEmpty(this.conBusCliRem.txtCodCli.Text.Trim()))
            {
                idCliRem = 0;
            }
            else
            {
                idCliRem = Convert.ToInt32(this.conBusCliRem.txtCodCli.Text);
            }
            string cApePatRem = this.txtApePatRem.Text.Trim();
            string cApeMatRem = this.txtApeMatRem.Text.Trim();
            string cNomCliRem = this.txtNomCliRem.Text.Trim();
            string cNroDniRem = this.txtCBDNIRem.Text.Trim();
            string cDirCliRem = this.txtDirRem.Text.Trim();
            String cTelfRem = this.txtTelefCelRem.Text.Trim();

            int idCliDes;
            if (string.IsNullOrEmpty(this.conBusCliDes.txtCodCli.Text.Trim()))
            {
                idCliDes = 0;
            }
            else
            {
                idCliDes = Convert.ToInt32(this.conBusCliDes.txtCodCli.Text);
            }
            string cApePatDes = this.txtApePatDes.Text.Trim();
            string cApeMatDes = this.txtApeMatDes.Text.Trim();
            string cNomCliDes = this.txtNomCliDes.Text.Trim();
            string cNroDniDes = this.txtCBDNIDes.Text.Trim();
            string cDirCliDes = this.txtDirDes.Text.Trim();
            String cTelfDes = this.txtTelefCelDes.Text.Trim();
            bool lModificaSaldoLinea = true;
            int idTipoTransac = 1; //INGRESO
            decimal nMonto_Giro = Convert.ToDecimal(this.txtMonGiro.Text);

            int idAgeDes = Convert.ToInt32(this.cboAgencia.SelectedValue.ToString()),
                x_idTipoPago = (int)cboModalidad.SelectedValue;

            Decimal nMonITF = Convert.ToDecimal(txtITF.Text),
                    nMonRedondeo = Convert.ToDecimal (txtRedondeo.Text.ToString());

            decimal nMonItfGiro = 0.00m;

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
            {
                nMonItfGiro = Convert.ToDecimal(txtITF.Text);
            }
           

            clsCNControlServ dtRegGiro = new clsCNControlServ();
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)//EFECTIVO
            {
                //valida saldos
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 1, Convert.ToDecimal(this.txtMonGiro.Text)))
                {
                    HabDesControles(false);
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    return;
                }

                #region Validacion Umbrales Dolares

                decimal nMontoTotPago = nMontoGir;
                int idMonedaUm = idMon;
                int idMotivoOpe = Convert.ToInt32(this.cboMotivoOpe.SelectedValue);
                int idSubProducto = 126;
                int idTipoPago = x_idTipoPago;
                int idTipoOperacion = 13;

                GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
                if (!frmUmbDol.obtenerContinuaOperacion())
                    return;

                #endregion

                DataTable tbRetGiro = dtRegGiro.RegistrarGiro(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idMon, clsVarGlobal.nIdAgencia,
                                                            nMontoGir, nMontoCom, cClave, idCliRem, cApePatRem, cApeMatRem, cNomCliRem, cNroDniRem, cDirCliRem,
                                                            idCliDes, cApePatDes, cApeMatDes, cNomCliDes, cNroDniDes, cDirCliDes, idAgeDes, 126, clsVarGlobal.idCanal, 13, Convert.ToInt32(this.cboMotivoOpe.SelectedValue),
                                                            cTelfRem, cTelfDes, nMonItfGiro, nMonRedondeo, x_idTipoPago,
                                                            lModificaSaldoLinea, idTipoTransac, nMonto_Giro);

                if (Convert.ToInt32(tbRetGiro.Rows[0]["idRpta"].ToString()) == 0)
                {
                    // RQ-412 Integracion de Saldos en Linea
                    new Semaforo().ValidarSaldoSemaforo();
                    
                    MessageBox.Show(tbRetGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRetGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRetGiro.Rows[0]["nNroOperacion"].ToString(), "Registro de Giros", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                    int idKardex = Convert.ToInt32(tbRetGiro.Rows[0]["nNroOperacion"]);
                    
                    //-----------------------------------------------------------------------------------------------------
                    //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                    //-----------------------------------------------------------------------------------------------------
                    frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                    //-----------------------------------------------------------------------------------------------------
                    //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                    //-----------------------------------------------------------------------------------------------------
                    frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                    ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
                    //---------------------------------------------------------------------------------------------->
                }
                else
                {
                    MessageBox.Show(tbRetGiro.Rows[0]["cMensage"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//CARGO A CUENTE DE AHOORO CORRIENTE
            {
                int numCuentaAho = Convert.ToInt32(this.cCuenta);
                DataTable tbRetGiro = dtRegGiro.RegistrarGiroConCargoACuenta(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idMon, clsVarGlobal.nIdAgencia,
                                                            nMontoGir, nMontoCom, cClave, idCliRem, cApePatRem, cApeMatRem, cNomCliRem, cNroDniRem, cDirCliRem,
                                                            idCliDes, cApePatDes, cApeMatDes, cNomCliDes, cNroDniDes, cDirCliDes, idAgeDes,
                                                            numCuentaAho, 126, clsVarGlobal.idCanal, 13, Convert.ToInt32(this.cboMotivoOpe.SelectedValue),
                                                            cTelfRem, cTelfDes, nMonRedondeo, nMonITF);
                if (Convert.ToInt32(tbRetGiro.Rows[0]["idRpta"].ToString()) == 0)
                {
                    MessageBox.Show(tbRetGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRetGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRetGiro.Rows[0]["nNroOperacion"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                    int idKardex = Convert.ToInt32(tbRetGiro.Rows[0]["nNroOperacion"]);

                    //-----------------------------------------------------------------------------------------------------
                    //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                    //-----------------------------------------------------------------------------------------------------
                    frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                    //-----------------------------------------------------------------------------------------------------
                    //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                    //-----------------------------------------------------------------------------------------------------
                    frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                    ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
                    //---------------------------------------------------------------------------------------------->
                }
                else
                {
                    MessageBox.Show(tbRetGiro.Rows[0]["cMensage"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            HabDesControles(false);
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.objFrmSemaforo.ValidarSaldoSemaforo();
            grbCuentaAhorro.Enabled = false;
            this.cboModalidad.Enabled = false;

            this.registrarRastreo(this.conBusCliRem.idCli, this.conBusCliDes.idCli, "Fin - Registro de evio de giro", btnGrabar);

            // ---- quitamos los eventos de calcular ------------------------------//
            this.cboAgencia.SelectedIndexChanged -= new EventHandler(cboAgencia_SelectedIndexChanged);
            this.txtMonGiro.Validated -= new EventHandler(txtMonGiro_Validated);
        }

        private void conBusCliRem_ClicBuscar(object sender, EventArgs e)
        {
            BuscarClienteRem();
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCliDes.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }
        private void conBusCliDes_ClicBuscar(object sender, EventArgs e)
        {
            BuscarClienteDes();
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCliDes.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            HabDesControles(true);
            grbRem.Visible = false;
            conBusCliRem.Visible = true;
            grbDes.Visible = false;
            conBusCliDes.Visible = true;
            chcCliRem.Enabled = true;
            chcCliRem.Checked = false;
            chcCliDes.Enabled = true;
            chcCliDes.Checked = false;
            this.cboAgencia.SelectedIndex = 0;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.txtApePatRem.Focus();

            // ---- agregamos los eventos de calcular ------------------------------//
            this.txtMonGiro.Validated += new EventHandler(txtMonGiro_Validated);
            this.cboAgencia.SelectedIndexChanged += new EventHandler(cboAgencia_SelectedIndexChanged);
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularComision();
        }
        private void chcCliRem_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarCtrlRem();
            HabDesCtrlsRem(true);

            if (chcCliRem.Checked)
            {
                conBusCliRem.Visible = false;
                grbRem.Visible = true;
                //conBusCliRem.txtCodCli.Enabled = false;

                //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
                Boolean lEsClienteInstitucion = false;
                cboModalidad.DataSource = cncontrolserv.ObtenerModalidadPagoEnvioGiro(lEsClienteInstitucion);
                cboModalidad.ValueMember = "idModalidadPagoGiro";
                cboModalidad.DisplayMember = "cModalidadPagoGiro";
                cboModalidad.Enabled = true;
                //---------------------------------------------------------------------------->
            }
            else
            {
                conBusCliRem.Visible = true;
                grbRem.Visible = false;
                //conBusCliRem.txtCodCli.Enabled = true;

                //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
                cboModalidad.DataSource = null;
                cboModalidad.Items.Clear();
                //---------------------------------------------------------------------------->
            }
        }

        private void chcCliDes_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarCtrlDes();
            HabDesCtrlsDes(true);
            if (chcCliDes.Checked)
            {
                conBusCliDes.Visible = false;
                grbDes.Visible = true;
            }
            else
            {
                conBusCliDes.Visible = true;
                grbDes.Visible = false;
            }
        }

        private void cboModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 0 || Convert.ToInt32(cboModalidad.SelectedValue) == 1)//Sin seleccionar - EFECTIVO
            {
                grbCuentaAhorro.Enabled = false;
                this.cCuenta = String.Empty;
                txtCuentaAho.Clear();
                this.cboMotivoOpe.SelectedIndex = 0;
            }
            else//CARGO A CUENTA AHORRO CORRIENTE
            {
                grbCuentaAhorro.Enabled = true;
                this.cboMotivoOpe.SelectedIndex = 1;
            }

            if (!string.IsNullOrEmpty(this.conBusCliRem.txtNombre.Text.ToString()) && !string.IsNullOrEmpty(this.conBusCliDes.txtNombre.Text.ToString()))
            {
                calcularComision();
            }
        }

        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            int idCliRem = Convert.ToInt32(this.conBusCliRem.txtCodCli.Text); ;
            frmBusCtaAho frmCtaAho = new frmBusCtaAho();
            frmCtaAho.idCli = idCliRem;
            frmCtaAho.pTipBus = 1;
            frmCtaAho.idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            frmCtaAho.nTipOpe = 11;  //--Cuentas para Operación de Retiro

            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNRetornaCuentasAhorros(idCliRem, 1, Convert.ToInt32(cboMoneda.SelectedValue), frmCtaAho.nTipOpe);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                frmCtaAho.ShowDialog();
                this.cCuenta = frmCtaAho.pnCta;
                if (frmCtaAho.idMon != Convert.ToInt32(cboMoneda.SelectedValue)) //TIPO DE MONEDA DE LA CUENTA DEBE SER LA MISMA QUE EL GIRO
                {
                    MessageBox.Show("La cuenta debe ser en la misma moneda del giro", "Valida Envio de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cCuenta = String.Empty;
                    txtCuentaAho.Clear();
                    return;
                }
                if (!String.IsNullOrEmpty( frmCtaAho.pcNroCta))
                {
                    String cFormato =
                    frmCtaAho.pcNroCta.Substring(0, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(3, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(6, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(9, 1) + "-" +
                    frmCtaAho.pcNroCta.Substring(10);
                    txtCuentaAho.Text = cFormato;
                }
                nMontoCuentaCoriente = string.IsNullOrEmpty(frmCtaAho.pnMonDisp) ? 0.00M : Convert.ToDecimal(frmCtaAho.pnMonDisp);
                idMonedaCuenta = Convert.ToInt32(cboMoneda.SelectedValue);
            }
            else
            {
                MessageBox.Show("NO EXISTE CUENTA DE AHORRO PARA VINCULAR" + "\n" + "Debe Aperturar una cuenta de ahorro nueva para el Envio de Giro", "Valida Envio de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cCuenta = String.Empty;
                txtCuentaAho.Clear();
                return;
            }
        }
        private void txtMonGiro_Validated(object sender, EventArgs e)
        {
            calcularComision();
        }
        private void txtMonGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                calcularComision();
                this.cboAgencia.Focus();
            }
        }

        private void conBusCliRem_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCliRem.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCliRem.txtNroDoc.Text.Trim());
            }
            frmGestionContacto objGC = new frmGestionContacto(this.conBusCliRem.txtNroDoc.Text);
            if (objGC.AlertaActualizacion == 1)
            {
                objGC.ShowDialog();
            }
        }
        #endregion
        #region Metodos

        private void limpiarControles()
        {
            LimpiarCtrlRem();
            //---Datos del Destinatario
            LimpiarCtrlDes();
            //---Datos del Giro
            this.txtMonGiro.Text = "0.00";
            this.txtMonComGiro.Text = "0.00";
            txtITF.Text = "0.00";
            txtRedondeo.Text = "0.00";
            this.txtTotal.Text = "00.00";
            this.txtClave.Clear();
            this.txtReClave.Clear();
        }

        private void HabDesControles(bool Valor)
        {
            this.conBusCliRem.btnBusCliente.Enabled = Valor;
            this.conBusCliRem.txtCodCli.Enabled = Valor;
            this.chcCliRem.Enabled = Valor;
            this.chcCliDes.Enabled = Valor;
            this.txtApePatRem.Enabled = Valor;
            this.txtApeMatRem.Enabled = Valor;
            this.txtNomCliRem.Enabled = Valor;
            this.txtCBDNIRem.Enabled = Valor;
            this.txtDirRem.Enabled = Valor;
            this.txtTelefCelRem.Enabled = Valor;

            this.conBusCliDes.btnBusCliente.Enabled = Valor;
            this.conBusCliDes.txtCodCli.Enabled = Valor;
            this.txtApePatDes.Enabled = Valor;
            this.txtApeMatDes.Enabled = Valor;
            this.txtNomCliDes.Enabled = Valor;
            this.txtCBDNIDes.Enabled = Valor;
            this.txtDirDes.Enabled = Valor;
            this.txtTelefCelDes.Enabled = Valor;

            this.cboAgencia.Enabled = Valor;
            this.cboMoneda.Enabled = Valor;
            this.txtMonGiro.Enabled = Valor;
            //this.txtMonComGiro.Enabled = Valor;
            this.txtClave.Enabled = Valor;
            this.txtReClave.Enabled = Valor;
        }

        private string ValidarDatos()
        {
            //=======================================================================
            //--Validar Datos del Remitente
            //=======================================================================
            if (!this.chcCliRem.Checked)
            {
                if (string.IsNullOrEmpty(this.conBusCliRem.txtCodCli.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar un remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conBusCliRem.txtCodCli.Focus();
                    return "ERROR";
                }
            }

            if (string.IsNullOrEmpty(this.txtApePatRem.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Apellido Paterno del Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApePatRem.Select();
                this.txtApePatRem.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtApeMatRem.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Apellido Materno del Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApeMatRem.Select();
                this.txtApeMatRem.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtNomCliRem.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Nombre del Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNomCliRem.Select();
                this.txtNomCliRem.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtCBDNIRem.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Número de Documento del Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBDNIRem.Select();
                this.txtCBDNIRem.Focus();
                return "ERROR";
            }

            if (this.txtCBDNIRem.Text.Trim().Length < 8)
            {
                MessageBox.Show("El Número de documento de remitente es Inválido", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBDNIRem.Select();
                this.txtCBDNIRem.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtDirRem.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Dirección del Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDirRem.Select();
                this.txtDirRem.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtTelefCelRem.Text.Trim()) || this.txtTelefCelRem.Text.Length < 9)
            {
                MessageBox.Show("Debe Ingresar número de teléfono valido de Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTelefCelRem.Select();
                this.txtTelefCelRem.Focus();
                return "ERROR";
            }
            //=======================================================================
            //--Validar Datos del Destinatario
            //=======================================================================
            if (!this.chcCliDes.Checked)
            {
                if (string.IsNullOrEmpty(this.conBusCliDes.txtCodCli.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar un destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.conBusCliDes.txtCodCli.Focus();
                    return "ERROR";
                }
            }

            if (string.IsNullOrEmpty(this.txtApePatDes.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Apellido Paterno del Destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApePatDes.Select();
                this.txtApePatDes.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtApeMatDes.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Apellido Materno del Destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtApeMatDes.Select();
                this.txtApeMatDes.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtNomCliDes.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Nombre del Destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNomCliDes.Select();
                this.txtNomCliDes.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtCBDNIDes.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar el Número de documento del Destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBDNIDes.Select();
                this.txtCBDNIDes.Focus();
                return "ERROR";
            }

            if (this.txtCBDNIDes.Text.Trim().Length < 8)
            {
                MessageBox.Show("El Número de documento del Destinatario es Inválido", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCBDNIDes.Select();
                this.txtCBDNIDes.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.txtTelefCelDes.Text.Trim()) || this.txtTelefCelDes.Text.Length < 9)
            {
                MessageBox.Show("Debe Ingresar número de teléfono valido del Destinatario", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTelefCelDes.Select();
                this.txtTelefCelDes.Focus();
                return "ERROR";
            }
            //=======================================================================
            //--Validar Datos del Giro
            //=======================================================================

            if (this.cboAgencia.SelectedIndex<0)
            {
                MessageBox.Show("Debe Seleccionar La Agencia de Destino del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencia.Select();
                this.cboAgencia.Focus();
                return "ERROR";
            }

            /*if (this.cboAgencia.SelectedValue.ToString()==clsVarGlobal.nIdAgencia.ToString())
            {
                MessageBox.Show("La Agencia Destino, debe ser Distinto al Remitente", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencia.Select();
                this.cboAgencia.Focus();
                return "ERROR";
            }*/
            if (string.IsNullOrEmpty(this.cboMoneda.SelectedValue.ToString()))
            {
                MessageBox.Show("Debe Seleccionar la Moneda del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMoneda.Select();
                this.cboMoneda.Focus();
                return "ERROR";
            }


            if (Convert.ToDecimal(this.txtMonGiro.Text)<=0)
            {
                MessageBox.Show("Debe Ingresar el Monto Válido del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonGiro.Select();
                this.txtMonGiro.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtMonComGiro.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Comisión del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonComGiro.Select();
                this.txtMonComGiro.Focus();
                return "ERROR";
            }
            if (Convert.ToDecimal(this.txtMonComGiro.Text) == 0)
            {
                MessageBox.Show("No existe comisión para el Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencia.Focus();
                return "ERROR";
            }
            if (string.IsNullOrEmpty(this.txtClave.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Clave del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Select();
                this.txtClave.Focus();
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtReClave.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Clave Nuevamente del Giro", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtReClave.Select();
                this.txtReClave.Focus();
                return "ERROR";
            }

            if (this.txtClave.Text.Trim().Length!=4)
            {
                MessageBox.Show("la Clave del Giro, debe ser de 04 Dígitos", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Select();
                this.txtReClave.Clear();
                this.txtClave.Focus();
                return "ERROR";
            }

            if (this.txtClave.Text.Trim()!=this.txtReClave.Text.Trim())
            {
                MessageBox.Show("La Clave Ingresada no son Iguales, Por Favor Volver a Ingresar", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Clear();
                this.txtReClave.Clear();
                this.txtClave.Select();
                this.txtClave.Focus();
                return "ERROR";
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue)==0)
            {
                MessageBox.Show("Debe seleccionar la modalidad de pago por envío de Giro.", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//CARGO A CUENTA DE AHORRO
            {
                if (string.IsNullOrEmpty(this.cCuenta))
                {
                    MessageBox.Show("Debe seleccionar una cuenta de Ahorro Corriente.", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
            }
            //Verificar que la cuenta tenga Monto disponible suficiente
            if (Convert.ToInt32(cboModalidad.SelectedValue) == 2)//CARGO A CUENTE DE AHOORO CORRIENTE
            {
                 List<clsVarGen> lista  = clsVarGlobal.lisVars;
                 Decimal nTipoCambio = 0.00m;

                 foreach (clsVarGen item in lista)
                 {
                     if (item.cVariable.Equals("nTipoCambio"))
                     {
                         nTipoCambio = Convert.ToDecimal(item.cValVar);
                     }
                 }

                 int idMonedaConvert = Convert.ToInt32(cboMoneda.SelectedValue);

                 if (nMontoCuentaCoriente < ConvertirMonto(idMonedaCuenta, idMonedaConvert, Convert.ToDecimal(txtMonGiro.Text), nTipoCambio))
                 {
                     MessageBox.Show("El monto de Giro sobrepasa el monto disponible de la Cuenta Corriente seleccionada.", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return "ERROR";
                 }
            }
            return "OK";
        }

        private Decimal ConvertirMonto(int idMonedaCuenta, int idMonedaConvert,Decimal nMonto,Decimal nTipoCambio)
        {
            Decimal nMontoConvert = 0.00m;
            if (idMonedaCuenta == idMonedaConvert)
            {
                nMontoConvert = nMonto;
            }
            else
            {
                if (idMonedaCuenta < idMonedaConvert)
                {
                    nMontoConvert = nMonto * nTipoCambio;
                }
                else
                {
                    nMontoConvert = nMonto / nTipoCambio;
                }
            }
            return nMontoConvert;
        }

        private void BuscarClienteRem()
        {
            if (this.conBusCliRem.txtCodCli.Text.Trim() == String.Empty)
            {
                //===============================================
                //--Limpiar Datos
                //===============================================
                this.txtApePatRem.Clear();
                this.txtApeMatRem.Clear();
                this.txtNomCliRem.Clear();
                this.txtCBDNIRem.Clear();
                this.txtDirRem.Clear();

                this.txtApePatRem.Enabled = true;
                this.txtApeMatRem.Enabled = true;
                this.txtNomCliRem.Enabled = true;
                this.txtCBDNIRem.Enabled = true;
                this.txtDirRem.Enabled = true;
                this.txtApePatRem.Focus();

                //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
                cboModalidad.DataSource = null;
                cboModalidad.Items.Clear();
                //---------------------------------------------------------------------------->
                return;
            }

            //========================================================================
            //--Traer los datos del Cliente Buscado
            //========================================================================
            int nidCli = Convert.ToInt32(this.conBusCliRem.txtCodCli.Text);
            if (nidCli == clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El usuario operador NO puede ser remitente", "Buscar Cliente para Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //===============================================
                conBusCliRem.limpiarControles();
                return;
            }
            clsCNRetDatosCliente RetTipCli = new clsCNRetDatosCliente();
            DataTable DatosTipCli = RetTipCli.ListarDatosCli(nidCli, "O");
            if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
                DataTable DatosCliNat = RetTipCli.ListarDatosCli(nidCli, "N");
                //===================================================================================
                //--Asignando Valores: Datos Generales
                //===================================================================================
                this.txtApePatRem.Text = DatosCliNat.Rows[0]["cApellidoPaterno"].ToString();
                this.txtApeMatRem.Text = DatosCliNat.Rows[0]["cApellidoMaterno"].ToString() + " " + DatosCliNat.Rows[0]["cApellidoCasado"].ToString();
                this.txtNomCliRem.Text = (DatosCliNat.Rows[0]["cNombre"].ToString() + " " + DatosCliNat.Rows[0]["cNombreSeg"].ToString() + " " + DatosCliNat.Rows[0]["cNombreOtros"].ToString()).Trim();
                this.txtCBDNIRem.Text = DatosCliNat.Rows[0]["cDocumentoID"].ToString();
                this.txtDirRem.Text = this.conBusCliRem.txtDireccion.Text;  //DatosCliNat.Rows[0]["cDireccion"].ToString();
                this.txtTelefCelRem.Text = DatosCliNat.Rows[0]["nNumeroTelefono"].ToString();
                //===============================================
                //--Desabilitamos Botones
                //===============================================
                this.txtApePatRem.Enabled = false;
                this.txtApeMatRem.Enabled = false;
                this.txtNomCliRem.Enabled = false;
                this.txtCBDNIRem.Enabled = false;
                this.txtDirRem.Enabled = false;

                //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
                Boolean lEsClienteInstitucion = true;
                cboModalidad.DataSource     = cncontrolserv.ObtenerModalidadPagoEnvioGiro(lEsClienteInstitucion);
                cboModalidad.ValueMember    = "idModalidadPagoGiro";
                cboModalidad.DisplayMember  = "cModalidadPagoGiro";
                cboModalidad.Enabled        = true;
                //---------------------------------------------------------------------------->
            }
            else if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "2")
            {
                MessageBox.Show("Una Persona Jurídica NO Puede Realizar Giros", "Buscar Cliente para Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //----------- Cargar Modalidad de Pago por envío de Giro ---------------------->
                cboModalidad.DataSource = null;
                cboModalidad.Items.Clear();
                //---------------------------------------------------------------------------->

                //===============================================
                //--Limpiar Datos y Habilitar
                //===============================================
                this.conBusCliRem.txtCodInst.Clear();
                this.conBusCliRem.txtCodAge.Clear();
                this.conBusCliRem.txtCodCli.Clear();
                this.conBusCliRem.txtNombre.Clear();
                this.conBusCliRem.txtNroDoc.Clear();
                this.conBusCliRem.txtDireccion.Clear();
                this.txtApePatRem.Clear();
                this.txtApeMatRem.Clear();
                this.txtNomCliRem.Clear();
                this.txtCBDNIRem.Clear();
                this.txtDirRem.Clear();

                this.txtApePatRem.Enabled = true;
                this.txtApeMatRem.Enabled = true;
                this.txtNomCliRem.Enabled = true;
                this.txtCBDNIRem.Enabled = true;
                this.txtDirRem.Enabled = true;
                this.txtApePatRem.Focus();
                return;
            }
        }

        private void BuscarClienteDes()
        {
            if (this.conBusCliDes.txtCodCli.Text.Trim() == String.Empty)
            {
                //===============================================
                //--Limpiar Datos y Habilitar
                //===============================================
                this.txtApePatDes.Clear();
                this.txtApeMatDes.Clear();
                this.txtNomCliDes.Clear();
                this.txtCBDNIDes.Clear();
                this.txtDirDes.Clear();

                this.txtApePatDes.Enabled = true;
                this.txtApeMatDes.Enabled = true;
                this.txtNomCliDes.Enabled = true;
                this.txtCBDNIDes.Enabled = true;
                this.txtApePatDes.Focus();

                return;
            }

            //========================================================================
            //--Traer los datos del Cliente Buscado
            //========================================================================
            int nidCli = Convert.ToInt32(this.conBusCliDes.txtCodCli.Text);
            clsCNRetDatosCliente RetTipCli = new clsCNRetDatosCliente();
            DataTable DatosTipCli = RetTipCli.ListarDatosCli(nidCli, "O");
            if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "1")
            {
                clsCNRetDatosCliente RetCliNat = new clsCNRetDatosCliente();
                DataTable DatosCliNat = RetTipCli.ListarDatosCli(nidCli, "N");
                //===================================================================================
                //--Asignando Valores: Datos Generales
                //===================================================================================
                this.txtApePatDes.Text = DatosCliNat.Rows[0]["cApellidoPaterno"].ToString();
                this.txtApeMatDes.Text = DatosCliNat.Rows[0]["cApellidoMaterno"].ToString() + " " + DatosCliNat.Rows[0]["cApellidoCasado"].ToString();
                this.txtNomCliDes.Text = (DatosCliNat.Rows[0]["cNombre"].ToString() + " " + DatosCliNat.Rows[0]["cNombreSeg"].ToString() + " " + DatosCliNat.Rows[0]["cNombreOtros"].ToString()).Trim();
                this.txtCBDNIDes.Text = DatosCliNat.Rows[0]["cDocumentoID"].ToString();
                this.txtDirDes.Text = conBusCliDes.txtDireccion.Text;
                this.txtTelefCelDes.Text = DatosCliNat.Rows[0]["nNumeroTelefono"].ToString();
                //===============================================
                //--Desabilitamos Botones
                //===============================================
                this.txtApePatDes.Enabled = false;
                this.txtApeMatDes.Enabled = false;
                this.txtNomCliDes.Enabled = false;
                this.txtCBDNIDes.Enabled = false;
                this.txtDirDes.Enabled = false;
            }
            else if (DatosTipCli.Rows[0]["idTipoPersona"].ToString() == "2")
            {
                MessageBox.Show("Ha Una Persona Jurídica NO Puede Realizar Giros", "Buscar de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //===============================================
                //--Limpiar Datos y Habilitar
                //===============================================
                this.conBusCliDes.txtCodInst.Clear();
                this.conBusCliDes.txtCodAge.Clear();
                this.conBusCliDes.txtCodCli.Clear();
                this.conBusCliDes.txtNombre.Clear();
                this.conBusCliDes.txtNroDoc.Clear();
                this.conBusCliDes.txtDireccion.Clear();

                this.txtApePatDes.Clear();
                this.txtApeMatDes.Clear();
                this.txtNomCliDes.Clear();
                this.txtCBDNIDes.Clear();
                this.txtDirDes.Clear();

                this.txtApePatDes.Enabled = true;
                this.txtApeMatDes.Enabled = true;
                this.txtNomCliDes.Enabled = true;
                this.txtCBDNIDes.Enabled = true;
                this.txtDirDes.Enabled = true;
                this.txtApePatDes.Focus();
                return;
            }
        }

        private void LimpiarCtrlRem()
        {
            //---Datos del Remitente
            this.conBusCliRem.txtCodInst.Clear();
            this.conBusCliRem.txtCodAge.Clear();
            this.conBusCliRem.txtCodCli.Clear();
            this.conBusCliRem.txtNombre.Clear();
            this.conBusCliRem.txtNroDoc.Clear();
            this.conBusCliRem.txtDireccion.Clear();
            this.txtApePatRem.Clear();
            this.txtApeMatRem.Clear();
            this.txtNomCliRem.Clear();
            this.txtCBDNIRem.Clear();
            this.txtDirRem.Clear();
            this.txtTelefCelRem.Clear();
        }
        private void LimpiarCtrlDes()
        {
            //---Datos del Destinatario
            this.conBusCliDes.txtCodInst.Clear();
            this.conBusCliDes.txtCodAge.Clear();
            this.conBusCliDes.txtCodCli.Clear();
            this.conBusCliDes.txtNombre.Clear();
            this.conBusCliDes.txtNroDoc.Clear();
            this.conBusCliDes.txtDireccion.Clear();
            this.txtApePatDes.Clear();
            this.txtApeMatDes.Clear();
            this.txtNomCliDes.Clear();
            this.txtCBDNIDes.Clear();
            this.txtDirDes.Clear();
            this.txtTelefCelDes.Clear();
        }

        private void HabDesCtrlsRem(bool Valor)
        {
            this.conBusCliRem.btnBusCliente.Enabled = Valor;
            this.conBusCliRem.txtCodCli.Enabled = Valor;
            this.txtApePatRem.Enabled = Valor;
            this.txtApeMatRem.Enabled = Valor;
            this.txtNomCliRem.Enabled = Valor;
            this.txtCBDNIRem.Enabled = Valor;
            this.txtDirRem.Enabled = Valor;
            this.txtTelefCelRem.Enabled = Valor;
        }

        private void HabDesCtrlsDes(bool Valor)
        {
            this.conBusCliDes.btnBusCliente.Enabled = Valor;
            this.conBusCliDes.txtCodCli.Enabled = Valor;
            this.txtApePatDes.Enabled = Valor;
            this.txtApeMatDes.Enabled = Valor;
            this.txtNomCliDes.Enabled = Valor;
            this.txtCBDNIDes.Enabled = Valor;
            this.txtDirDes.Enabled = Valor;
            this.txtTelefCelDes.Enabled = Valor;
        }

        public void calcularComision()
        {
            Decimal d;
            int nRpta = 0;
            Decimal montogiro =0;

            txtRedondeo.Text = "0.00";
            txtITF.Text = string.Format("{0:#,#0.00}", 0.00);

            //--------------------------------------------------------------
            //-----Calcular el ITF
            //--------------------------------------------------------------
            Decimal nMontoTotal = 0;
            Decimal nITF;
            nITF = 0.00m;
            //if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
            //{
            //    nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text)), 2, (Int32)this.cboMoneda.SelectedValue);
            //}
            nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text)), 2, (Int32)this.cboMoneda.SelectedValue);

            txtITF.Text = string.Format("{0:#,#0.00}", nITF);


            if (cboModalidad.SelectedIndex<=0)
            {
                MessageBox.Show("Debe Seleccionar la Modalidad de Pago", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboModalidad.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(this.txtMonGiro.Text.Trim()))
            {
                if (Decimal.TryParse(this.txtMonGiro.Text, out d))
                {
                    if (Convert.ToDecimal(this.txtMonGiro.Text) <= 0)
                    {
                        MessageBox.Show("Antes de Seleccionar La Agencia, Ingrese el Monto del Giro", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtMonGiro.Focus();
                        return;
                    }
                }
            }
            if (this.cboAgencia.SelectedIndex >= 0)
            {
                /*if (this.cboAgencia.SelectedValue.ToString().Equals(clsVarGlobal.nIdAgencia.ToString()))
                {
                    MessageBox.Show("La Agencia Nueva, No Puede ser la Misma Agencia ORIGEN", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboAgencia.SelectedIndex = -1;
                    this.cboAgencia.Focus();
                    this.txtMonComGiro.Text = "0.00";
                    this.txtTotal.Text = this.txtMonGiro.Text;
                    return;
                }*/
                               
                clsCNControlServ clsSer = new clsCNControlServ();
                Decimal montogirado;
                montogirado = Convert.ToDecimal(this.txtMonGiro.Text)-Convert.ToDecimal(this.txtITF.Text);
                DataTable tbCom = clsSer.RetMonComGiro(clsVarGlobal.nIdAgencia, Convert.ToInt32(this.cboAgencia.SelectedValue.ToString()), Convert.ToInt32(this.cboMoneda.SelectedValue.ToString()), montogirado, ref nRpta);
                DataTable tbEob = clsSer.ListaEobPorAgencia(Convert.ToInt32(this.cboAgencia.SelectedValue.ToString()));
                if (tbEob.Rows.Count > 0)
                {
                    if (tbEob.Rows.Count == 1)
                    {
                        lblEobsDestino.Text = "1 EOB Destino:";
                    }
                    else
                    {
                        lblEobsDestino.Text = tbEob.Rows.Count.ToString() + " EOBs Destino:";
                    }
                    lstEobs.DataSource = tbEob;
                    lstEobs.DisplayMember = "cNombreEstab";
                    lstEobs.ValueMember = "idEstablecimiento";
                    lblEobsDestino.Visible = true;
                    lstEobs.Visible = true;
                }
                else
                {
                    lblEobsDestino.Visible = false;
                    lstEobs.Visible = false;
                }
                clsFunUtiles nRetVal = new clsFunUtiles();
                if (nRpta == 1)
                {
                    if (tbCom.Rows[0]["idTipComGiro"].ToString() == "1")
                    {
                        this.txtMonComGiro.Text = tbCom.Rows[0]["nMontoCom"].ToString();
                        this.txtTotal.Text = Convert.ToString(Math.Round(Convert.ToDecimal(montogirado), 2) - Math.Round(Convert.ToDecimal(this.txtMonComGiro.Text), 2));
                    }
                    else
                    {
                        Decimal nMonComGiro = Math.Round((Convert.ToDecimal(montogirado) * Convert.ToDecimal(tbCom.Rows[0]["nMontoCom"].ToString())) / 100.00m, 2),
                                nMonFavCli = 0.00m;
                        montogiro = montogirado - nMonComGiro;

                        if (Convert.ToInt32(cboModalidad.SelectedValue) == 1) // Pago en Efectivo
                        {
                        montogiro = nRetVal.redondearBCR(montogiro, ref nMonFavCli, 1, true, false);
                        }
                        this.txtTotal.Text = string.Format("{0:#,#0.00}", montogiro);
                        this.txtMonComGiro.Text = string.Format("{0:#,#0.00}", nMonComGiro);
                    }
                }
                else
                {
                    MessageBox.Show("No Existe Comisión Para la Agencia Seleccionada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtMonComGiro.Text = "0.00";
                    this.txtTotal.Text = this.txtMonGiro.Text;
                }



               // if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
               // {
                    nMontoTotal = Convert.ToDecimal(this.txtMonGiro.Text) - nITF - Convert.ToDecimal(this.txtMonComGiro.Text);
                //}
               // else
               // {
                 //   nMontoTotal = Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text);
               // }
                ////--------------------------------------------------------------
                ////-----Calcular el ITF
                ////--------------------------------------------------------------
                //Decimal nMontoTotal = 0;
                //Decimal nITF;
                //nITF = 0.00m;
                ////if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
                ////{
                ////    nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text)), 2, (Int32)this.cboMoneda.SelectedValue);
                ////}
                //nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text)), 2, (Int32)this.cboMoneda.SelectedValue);
                
                //txtITF.Text = string.Format("{0:#,#0.00}", nITF);

                //if (Convert.ToInt32(cboModalidad.SelectedValue) == 1)
                //{
                //    nMontoTotal = Convert.ToDecimal(this.txtMonGiro.Text) - nITF - Convert.ToDecimal(this.txtMonComGiro.Text);
                //}
                //else
                //{
                //    nMontoTotal = Convert.ToDecimal(this.txtMonGiro.Text) - Convert.ToDecimal(this.txtMonComGiro.Text);
                //}
                

                //--------------------------------------------------------------
                //-----Redondeo
                //--------------------------------------------------------------
                
                Decimal nMonFavClie = 0.00m;

                if (Convert.ToInt32(cboModalidad.SelectedValue) == 1) // Pago en EFECTIVO
                {
                    nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavClie, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                }

                this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavClie, 2));
                this.txtTotal.Text = string.Format("{0:#,#0.00}", nMontoTotal);

            }
        }
        #endregion

        private void txtMonGiro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            CLI.Presentacion.frmGestionContacto objFrmGestionContacto = new CLI.Presentacion.frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }
    }
}
