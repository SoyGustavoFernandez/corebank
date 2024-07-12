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
    public partial class frmDevolucionGiro : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();
        clsFunUtiles FunTruncar = new clsFunUtiles();
        String cTituloMensajes = "Devolución de giros";
        int idServGiro = 0;

        int idProducto = 126;
        int idTipoOperacion = 15;
        private int idCliRem;

        private const int idTipoOpeRegimenReforzado = 180;

        #endregion

        public frmDevolucionGiro()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmDevolucionGiro_Load(object sender, EventArgs e)
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
            frmbuscarGiro.cOpcForm = 4;
            frmbuscarGiro.ShowDialog();

            if (frmbuscarGiro.pnGiro > 0)
            {
                clsCNControlServ ListarGiros = new clsCNControlServ();
                DataTable tbGiros = ListarGiros.ListadodeGiros(frmbuscarGiro.pnGiro, "", "", clsVarGlobal.nIdAgencia, 6);
                if (tbGiros.Rows[0]["idAgeRem"].ToString() != clsVarGlobal.User.idEstablecimiento.ToString())
                {
                    MessageBox.Show("EL GIRO DEBE SER DEVUELTO EN LA AGENCIA: " + tbGiros.Rows[0]["cNomAgeRem"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }

                if (tbGiros.Rows[0]["idEstado"].ToString() == "1" || tbGiros.Rows[0]["idEstado"].ToString() == "3") //cuando esta enviado o bloqueado
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
                    idCliRem = Convert.ToInt32(tbGiros.Rows[0]["idCliRem"]);
                    this.txtNomCliRem.Text = tbGiros.Rows[0]["cNombreRem"].ToString();
                    this.txtDniRem.Text = tbGiros.Rows[0]["cNroDniRem"].ToString();
                    this.cboEstablecimientoRem.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeRem"].ToString());
                    this.txtDirRem.Text = tbGiros.Rows[0]["cDirCliRem"].ToString();
                    this.txtTelefCelRem.Text = tbGiros.Rows[0]["cNumTelfRem"].ToString();
                    //Datos Beneficiario
                    this.txtNomCliBen.Text = tbGiros.Rows[0]["cNombreDes"].ToString();
                    this.txtDniBen.Text = tbGiros.Rows[0]["cNroDniDes"].ToString();
                    this.cboEstablecimientoGiroDes.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeDes"].ToString());
                    this.txtDirDes.Text = tbGiros.Rows[0]["cDirCliDes"].ToString();
                    this.txtTelefCelDes.Text = tbGiros.Rows[0]["cNumTelfDes"].ToString();

                    this.cboMoneda.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idMoneda"].ToString());
                    this.txtMonGiro.Text = tbGiros.Rows[0]["nMontoGiro"].ToString();
                    this.txtMontEnt.Text = tbGiros.Rows[0]["nMontoGiro"].ToString();     
                    habilitarControles(true);
                    chcItf.Enabled = true;
                    this.btnBusGiro.Enabled = false;
                }
                else
                {
                    MessageBox.Show("EL GIRO SE ENCUENTRA EN ESTADO " + tbGiros.Rows[0]["cNomEstado"].ToString() + ": " + tbGiros.Rows[0]["cMotivoEstado"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }

            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNroGiro.Text.Trim()))
            {
                MessageBox.Show("El Número de Giro No Existe, por Favor Verificar", "Devolución de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnBusGiro.Focus();
                return;
            }

            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(0, this.txtDniRem.Text.Trim(), clsVarGlobal.nIdAgencia, this.idTipoOperacion, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            //===================================================================
            //--Guardar Devolución del Giro
            //===================================================================
            string cDniCliRem = this.txtDniRem.Text.Trim(),
                   cNomCliRem = this.txtNomCliRem.Text.Trim(),
                   cDirCliRem = this.txtDirRem.Text.Trim();

            int idGiro = Convert.ToInt32(this.txtNroGiro.Text.ToString());
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal /*era double*/nMontoGir = Convert.ToDecimal(this.txtMonGiro.Text);
            if (String.IsNullOrEmpty(this.txtMotivo.Text))
            {
                MessageBox.Show("Ingrese motivo de devolución", "Devolución de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            String cMotivo = this.txtMotivo.Text;
            /*========================================================================================
               * VALIDACIONES PARA REGIMEN DEL CLIENTE
               ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(idCliRem,
                                                                               Convert.ToInt32(cboMoneda.SelectedValue.ToString()),
                                                                               0,
                                                                               idGiro,
                                                                              nMontoGir);
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, 2, nMontoGir))
            {
                habilitarControles(false);               
                return;
            }

            //===================================================================
            //--Montos para el Pago del Giro
            //===================================================================
            Decimal nMonITF = Convert.ToDecimal(txtITF.Text),
                    nMonRedondeo = Convert.ToDecimal(txtRedondeo.Text.ToString()),
                    nMonEntregar = Convert.ToDecimal(txtMontEnt.Text);

            bool lModificaSaldoLinea = true;
            int idTipoTransac = 2; //EGRESO

            clsCNControlServ dtRegGiro = new clsCNControlServ();
            DataTable tbRegGiro = dtRegGiro.RegDevolucionGiro(idGiro, Convert.ToDateTime(clsVarGlobal.dFecSystem), clsVarGlobal.User.idUsuario, idMon, 
                                                                clsVarGlobal.nIdAgencia, nMontoGir, cDniCliRem, cNomCliRem, cDirCliRem, cMotivo, this.idProducto, 
                                                                clsVarGlobal.idCanal, this.idTipoOperacion, Convert.ToInt32(this.cboMotivoOperacion1.SelectedValue), 
                                                                nMonITF, nMonRedondeo, nMonEntregar, lModificaSaldoLinea, idTipoTransac);

            if (Convert.ToInt32(tbRegGiro.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRegGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRegGiro.Rows[0]["nNroOperacion"].ToString(), "Devolución de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->              
                int idKardex = Convert.ToInt32(tbRegGiro.Rows[0]["nNroOperacion"]);
                ImpresionVoucher(idKardex, 9, this.idTipoOperacion, 1, Convert.ToDecimal(this.txtMonGiro.Text), 0, 0, 1);
            }
            else
            {
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString(), "Devolución de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            habilitarControles(false);
            chcItf.Enabled = false;
            this.btnNuevo.Focus();
            this.objFrmSemaforo.ValidarSaldoSemaforo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            habilitarControles(true);
            this.btnGrabar.Enabled = false;            
            this.txtMotivo.Enabled = false;
            chcItf.Enabled = false;
            this.btnBusGiro.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            habilitarControles(false);
            chcItf.Enabled = false;
            this.btnNuevo.Focus();
        }
        private void frmDevolucionGiro_FormClosing(object sender, FormClosingEventArgs e)
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
            this.txtDirRem.Clear();
            this.cboEstablecimientoGiroDes.SelectedValue = 0;
            this.txtNomCliBen.Clear();
            this.txtDniBen.Clear();
            this.txtDirDes.Clear();
            this.cboEstablecimientoRem.SelectedValue = 0;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGiro.Text = "0.00";
            this.txtITF.Text = "0.00";
            this.txtRedondeo.Text = "0.00";
            this.txtMontEnt.Text = "0.00";
            this.txtMotivo.Clear();
            this.txtTelefCelRem.Clear();
            this.txtTelefCelDes.Clear();
            chcItf.Checked = false;
        }
        
        private void habilitarControles(Boolean val)
        {
            this.btnBusGiro.Enabled = val;
            this.btnNuevo.Enabled   = !val;
            this.btnGrabar.Enabled  = val;
            this.btnCancelar.Enabled = val;
            this.txtMotivo.Enabled = val;
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
                txtRedondeo.Text = "0.00";
                txtMontEnt.Text = txtMonGiro.Text;
            }
        }
    }
}
