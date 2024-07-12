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
using SER.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace SER.Presentacion
{
    public partial class frmPagoGiro : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        String cTituloMensajes = "Pago de giro";
        int idServGiro = 0;
        
        int idProducto = 126;
        int idTipoOperacion = 14;

        int idCliRem = 0;
        int idCliDes = 0;

        public string pcClave=String.Empty;

        private const int idTipoOpeRegimenReforzado = 178;
        #endregion
        public frmPagoGiro()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmPagoGiro_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            this.btnNuevo.PerformClick();
            //habilita combo de motivos
            this.cboMotivoOperacion1.ListarMotivoOperacion(this.idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
        }
        private void btnBusGiro_Click(object sender, EventArgs e)
        {
            chcItf.Enabled = false;

            //==================================================
            //--Llamar al Formulario
            //==================================================
            frmBusGiro frmbuscarGiro = new frmBusGiro();
            frmbuscarGiro.cOpcForm = 5;
            frmbuscarGiro.ShowDialog();

            if (frmbuscarGiro.pnGiro > 0)
            {
                clsCNControlServ ListarGiros = new clsCNControlServ();
                DataTable tbGiros = ListarGiros.ListadodeGiros(frmbuscarGiro.pnGiro, "", "", clsVarGlobal.nIdAgencia, 6);
                if (tbGiros.Rows[0]["idAgeDes"].ToString() != clsVarGlobal.nIdAgencia.ToString())
                {
                    MessageBox.Show("EL GIRO DEBE SER RECOGIDO EN LA AGENCIA: " + tbGiros.Rows[0]["cNombreAge"].ToString(), this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }
                int nidCli = Convert.ToInt32(tbGiros.Rows[0]["idCliDes"]);
                idCliDes = Convert.ToInt32(tbGiros.Rows[0]["idCliDes"]);
                idCliRem = Convert.ToInt32(tbGiros.Rows[0]["idCliRem"]);
                if (nidCli == clsVarGlobal.User.idCli)
                {
                    MessageBox.Show("EL USUARIO OPERADOR NO PUEDE SER DESTINATARIO", this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //===============================================               
                    this.btnBusGiro.Focus();
                    return;
                }
                if (tbGiros.Rows[0]["idEstado"].ToString() == "1")
                {
                    LimpiarControles();
                    DataTable dtBloquear = cncontrolserv.BloquearGiro(frmbuscarGiro.pnGiro, clsVarGlobal.User.idUsuario); //bloquear el giro
                    if (Convert.ToInt32(dtBloquear.Rows[0]["idResultado"].ToString()) < 1)
                    {
                        MessageBox.Show(dtBloquear.Rows[0]["cMensaje"].ToString(), this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnBusGiro.Focus();
                        return;
                    }
                    this.txtNroGiro.Text = frmbuscarGiro.pnGiro.ToString();
                    this.idServGiro = frmbuscarGiro.pnGiro;
                    //Datos Remitente
                    this.txtNomCliRem.Text = tbGiros.Rows[0]["cNombreRem"].ToString();
                    this.txtDniRem.Text = tbGiros.Rows[0]["cNroDniRem"].ToString();
                    this.cboAgenciaRem.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeRem"].ToString());
                    this.txtDirRem.Text = tbGiros.Rows[0]["cDirCliRem"].ToString();
                    this.txtTelefCelRem.Text = tbGiros.Rows[0]["cNumTelfRem"].ToString();
                    //Datos Beneficiario
                    this.txtNomCliBen.Text = tbGiros.Rows[0]["cNombreDes"].ToString();
                    this.txtDniBen.Text = tbGiros.Rows[0]["cNroDniDes"].ToString();
                    this.cboAgenciaDes.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeDes"].ToString());
                    this.txtDirDes.Text = tbGiros.Rows[0]["cDirCliDes"].ToString();
                    this.txtTelefCelDes.Text = tbGiros.Rows[0]["cNumTelfDes"].ToString();
                    if (string.IsNullOrEmpty(tbGiros.Rows[0]["cDirCliDes"].ToString()))
                    {
                        txtDirDes.Enabled = true;
                        txtDirDes.Focus();
                    }
                    else
                    {
                        txtDirDes.Enabled = false;
                    }

                    this.cboMoneda.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idMoneda"].ToString());
                    this.txtMonGiro.Text = tbGiros.Rows[0]["nMontoGiro"].ToString();
                    //--------------------------------------------------------------
                    //-----Redondeo
                    //--------------------------------------------------------------
                    Decimal nMonFavClie = 0.00m;
                    Decimal nMontoE =0.00m;
                    nMontoE = FunTruncar.redondearBCR(Convert.ToDecimal(txtMonGiro.Text), ref nMonFavClie, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                    this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavClie, 2));
                    this.txtMontEnt.Text = Convert.ToString(nMontoE);

                    //==================== Consultar si se ha cambiado la clave de Envío de Giro ===================>
                    DataTable dtNuevaClaveGiro = ListarGiros.BuscarNuevaClave(frmbuscarGiro.pnGiro, Convert.ToDecimal(tbGiros.Rows[0]["nMontoGiro"]));
                    if (dtNuevaClaveGiro.Rows.Count == 0)
                    {
                        pcClave = tbGiros.Rows[0]["bClaveGiro"].ToString();
                    }
                    else
                    {
                        if (dtNuevaClaveGiro.Rows[0]["idEstadoSol"].ToString() == "3") //esta ejecutado, 
                        {
                            pcClave = dtNuevaClaveGiro.Rows[0]["bClaveGiro"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("EL GIRO TIENE UNA SOLICITUD DE CAMBIO DE CLAVE PENDIENTE", "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.btnBusGiro.Focus();
                            return;
                        }
                    }
                    //==============================================================================================>
                    this.txtClave.Enabled = true;
                    this.btnGrabar.Enabled = true;
                    this.btnBusGiro.Enabled = false;
                    chcItf.Enabled = true;
                    this.txtClave.Focus();
                }
                else
                {
                    MessageBox.Show("EL GIRO SE ENCUENTRA EN ESTADO " + tbGiros.Rows[0]["cNomEstado"].ToString() + ": " + tbGiros.Rows[0]["cMotivoEstado"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.btnBusGiro.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.txtClave.Enabled = false;
            chcItf.Enabled = false;
            this.btnBusGiro.Focus();
        }

        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);

            x_idCliente = 0; ;

            
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
                                                                    Convert.ToInt32(txtNroGiro.Text),                      //idDocument
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
            drfila[0] = "cNroDni";
            drfila[1] = Convert.ToString(this.txtDniBen.Text);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMonGiro.Text));
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = Convert.ToString(1);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = Convert.ToString(0);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = Convert.ToString(this.txtDniBen.Text);
            dtTablaParametros.Rows.Add(drfila);



            return dtTablaParametros;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNroGiro.Text.Trim()))
            {
                MessageBox.Show("El Número de Giro No Existe, por Favor Verificar", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnBusGiro.Focus();
                return;
            }

            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(0, this.txtDniBen.Text.Trim(), clsVarGlobal.nIdAgencia, this.idTipoOperacion, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            /*========================================================================================
            * Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(Convert.ToDecimal(txtMonGiro.Text)), Convert.ToString(Convert.ToInt32(cboMoneda.SelectedValue.ToString()))))
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
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(idCliRem,
                                                                               Convert.ToInt32(cboMoneda.SelectedValue.ToString()),
                                                                               0,
                                                                               Convert.ToInt32(txtNroGiro.Text.ToString()),
                                                                               Convert.ToDecimal(txtMonGiro.Text));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.txtDirDes.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Dirección del Beneficiario", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDirDes.Select();
                this.txtDirDes.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtClave.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar la Clave Para Realizar la Operación", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Select();
                this.txtClave.Focus();
                return;
            }

            if (this.txtClave.Text.Trim().Length != 4)
            {
                MessageBox.Show("la Clave del Giro, debe ser de 04 Dígitos", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Clear();
                this.txtClave.Select();
                this.txtClave.Focus();
                return;
            }

            int idGiro = Convert.ToInt32(this.txtNroGiro.Text.ToString());
            //===================================================================
            //--Encriptar la Clave y Validar
            //===================================================================
            clsCNSeguridad bEncryp = new clsCNSeguridad();
            string cClave = bEncryp.GeneratePasswordHash(this.txtClave.Text);

            if (pcClave.Trim() != cClave.Trim())
            {
                MessageBox.Show("la Clave del Giro No es Correcto, Por favor Vuelva a Ingresar", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsCNControlServ dtReg = new clsCNControlServ();
                DataTable tbReg = dtReg.RegIntenFallClave(idGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                if (Convert.ToInt32(tbReg.Rows[0]["nIntentos"].ToString()) >= 3)
                {
                    MessageBox.Show(tbReg.Rows[0]["cMensage"].ToString(), "Registro de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnNuevo.Enabled = true;
                    this.btnGrabar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.txtClave.Enabled = false;
                    return;
                }

                this.txtClave.Clear();
                this.txtClave.Select();
                this.txtClave.Focus();
                return;
            }

            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================
            string cDniCliDes = this.txtDniBen.Text.Trim(),
                    cNomCliDes = this.txtNomCliBen.Text.Trim(),
                    cDirCliDes = this.txtDirDes.Text.Trim();

            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoGir = Convert.ToDecimal(this.txtMonGiro.Text);
            
            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 2, nMontoGir))
            {
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.txtClave.Enabled = false;
                return;
            }

            #region Validacion Umbrales Dolares

            decimal nMontoTotPago = nMontoGir;
            int idMonedaUm = idMon;
            int idMotivoOpe = Convert.ToInt32(this.cboMotivoOperacion1.SelectedValue);
            int idSubProducto = 126;
            int idTipoPago = 1;
            

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion

            //===================================================================
            //--Montos para el Pago del Giro
            //===================================================================
            Decimal nMonITF = Convert.ToDecimal(txtITF.Text),
                    nMonRedondeo = Convert.ToDecimal(txtRedondeo.Text.ToString()),
                    nMonEntregar = Convert.ToDecimal(txtMontEnt.Text);

            bool lModificaSaldoLinea = true;
            int idTipoTransac = 2; //EGRESO

            clsCNControlServ dtRegGiro = new clsCNControlServ();
            DataTable tbRegGiro = dtRegGiro.RegistrarPagoGiro(idGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, idMon, clsVarGlobal.nIdAgencia, nMontoGir,
                                                               cDniCliDes, cNomCliDes, cDirCliDes, this.idProducto, clsVarGlobal.idCanal, this.idTipoOperacion,
                                                               Convert.ToInt32(this.cboMotivoOperacion1.SelectedValue),
                                                               nMonITF, nMonRedondeo, nMonEntregar,
                                                               lModificaSaldoLinea, idTipoTransac);

            if (Convert.ToInt32(tbRegGiro.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRegGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRegGiro.Rows[0]["nNroOperacion"].ToString(), "Registro de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->              
                int idKardex = Convert.ToInt32(tbRegGiro.Rows[0]["nNroOperacion"]);

                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                ImpresionVoucher(idKardex, 9, this.idTipoOperacion, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
            }
            else
            {
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString(), "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtClave.Enabled = false;
            chcItf.Enabled = false;
            this.btnNuevo.Focus();

            this.objFrmSemaforo.ValidarSaldoSemaforo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.btnBusGiro.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtClave.Enabled = false;
            chcItf.Enabled = false;
            this.btnNuevo.Focus();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }        

        private void frmPagoGiro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.idServGiro != 0)
            {
                cncontrolserv.DesbloquearGiro(this.idServGiro, clsVarGlobal.User.idUsuario); //desbloquear el giro   
            }
        }
        #endregion
        #region Metodos

        private void LimpiarControles()
        {
            if (!String.IsNullOrEmpty(this.txtNroGiro.Text.ToString()))
            {
                cncontrolserv.DesbloquearGiro(Convert.ToInt32(this.txtNroGiro.Text), clsVarGlobal.User.idUsuario); //desbloquear el giro   
            }
            this.idServGiro = 0;
            this.txtNroGiro.Clear();
            this.txtNomCliRem.Clear();
            this.txtDniRem.Clear();
            this.cboAgenciaRem.SelectedValue = 0;
            this.txtDirRem.Clear();
            this.txtNomCliBen.Clear();
            this.txtDniBen.Clear();
            this.cboAgenciaDes.SelectedValue = 0;
            this.txtDirDes.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGiro.Text = "0.00";
            this.txtITF.Text = "0.00";
            this.txtRedondeo.Text = "0.00";
            this.txtMontEnt.Text = "0.00";
            this.txtClave.Clear();
            this.txtTelefCelRem.Clear();
            this.txtTelefCelDes.Clear();
            chcItf.Checked = false;
        }

        private void CalcularMontos()
        {
            txtITF.Text = "0.00";

            //--------------------------------------------------------------
            //-----Calcular el ITF
            //--------------------------------------------------------------
            Decimal nMontoTotal = 0;
            Decimal nITF;
            nITF = 0.00m;
            nITF = FunTruncar.truncar((Decimal)clsVarGlobal.nITF / 100.00m * (Convert.ToDecimal(this.txtMonGiro.Text)), 2, (Int32)this.cboMoneda.SelectedValue);
            txtITF.Text = string.Format("{0:#,#0.00}", nITF);

            nMontoTotal = Convert.ToDecimal(this.txtMonGiro.Text) - nITF;

            //--------------------------------------------------------------
            //-----Redondeo
            //--------------------------------------------------------------
            Decimal nMonFavClie = 0.00m;

            nMontoTotal = FunTruncar.redondearBCR(nMontoTotal, ref nMonFavClie, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                       

            this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavClie, 2));
            this.txtMontEnt.Text = string.Format("{0:#,#0.00}", nMontoTotal);

        }

        #endregion

        private void chcItf_CheckedChanged(object sender, EventArgs e)
        {
            if (chcItf.Checked)
            {
                CalcularMontos();
            }
            else
            {
                txtITF.Text = "0.00";
                Decimal nMonFavClie = 0.00m;
                Decimal nMontoEn = 0.00m;
                nMontoEn = FunTruncar.redondearBCR(Convert.ToDecimal(txtMonGiro.Text), ref nMonFavClie, Convert.ToInt32(cboMoneda.SelectedValue), true, false);
                this.txtRedondeo.Text = string.Format("{0:#,#0.00}", Math.Round(nMonFavClie, 2));
                txtMontEnt.Text = Convert.ToString(nMontoEn);
            }
        }

        private void txtDniBen_TextChanged(object sender, EventArgs e)
        {
            if (this.txtDniBen.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.txtDniBen.Text.Trim());
            }
        }
    }
}
