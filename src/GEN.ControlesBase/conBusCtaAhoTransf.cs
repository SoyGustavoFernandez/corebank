using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class conBusCtaAhoTransf : UserControl
    {
        public int nTipOpe = 0, pnIdMon = 0, idcli=0, idcuenta=0, idEstCuenta=1,p_idTipOpePrincipal=0;
        public Decimal x_nMontoOpe = 0;
        Decimal x_nsaldoDisp = 0;
        public new event EventHandler ClicBusCta;
        public int nidTipoPersona;
        public int idMoneda;
        clsCNDeposito objDeposito = new clsCNDeposito();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNBuscarCli ValidaCliBN = new clsCNBuscarCli();
        public bool lBloqueaBusquedaNombre = false;

        public conBusCtaAhoTransf()
        {
            InitializeComponent();
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            if (idcuenta != 0)
            {
                objDeposito.CNUpdNoUsoCuenta(idcuenta);
            }

            txtCodIns.Text = "";
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtProducto.Text = "";
            txtNombre.Text = "";
            nidTipoPersona = 0;
            idcuenta = 0;

            if (Convert.ToBoolean(clsVarApl.dicVarGen["nIsTransfOtroCli"])) // 1 --> True solo Cuentas del Cliente
            {
                //==================================================
                //--Llamar al Formulario
                //==================================================
                int p_idCta = 0;
                frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                frmbuscarCta.idCli = idcli;
                frmbuscarCta.pTipBus = 1;
                frmbuscarCta.nTipOpe = 1;  //--Cuentas para Transferencias
                frmbuscarCta.idMon = Convert.ToInt32(pnIdMon);
                frmbuscarCta.ShowDialog();
                if (frmbuscarCta.idCli > 0 && Convert.ToInt32(frmbuscarCta.pnCta)>0)
                {
                    p_idCta = Convert.ToInt32(frmbuscarCta.pnCta);

                    if (!ValidarDatosOpe(p_idCta, x_nMontoOpe, Convert.ToDecimal (frmbuscarCta.pnMonDisp)))
                    {
                        if (ClicBusCta != null)
                            ClicBusCta(sender, e);
                        return;
                    }
                    txtCodIns.Text = frmbuscarCta.pcNroCta.ToString().Substring(0, 3);
                    txtCodAge.Text = frmbuscarCta.pcNroCta.ToString().Substring(3, 3);
                    txtCodMod.Text = frmbuscarCta.pcNroCta.ToString().Substring(6, 3);
                    txtCodMon.Text = frmbuscarCta.pcNroCta.ToString().Substring(9, 1);
                    txtNroCta.Text = frmbuscarCta.pcNroCta.ToString().Substring(10, 12);
                    txtCodCli.Text = frmbuscarCta.idCli.ToString();
                    txtNombre.Text = frmbuscarCta.pcNomCli.ToString();
                    txtProducto.Text = frmbuscarCta.pcProd.ToString();
                    idcuenta = p_idCta;
                    clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
                    if (ClicBusCta != null)
                        ClicBusCta(sender, e);
                }
                else
                {
                    LimpiarControles();
                    idcuenta = 0;
                }
                return;
            }
            
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.lBloqueaConsultaNombre = lBloqueaBusquedaNombre;
            frmbuscarcli.ShowDialog();
            if (string.IsNullOrEmpty(frmbuscarcli.pcCodCli))
            {
                if (ClicBusCta != null)
                    ClicBusCta(sender, e);
                return;
            }
            if (Convert.ToInt32(frmbuscarcli.pcCodCli)==clsVarGlobal.User.idCli)
            {
                MessageBox.Show("El Mismo usuario No Puede Realizar Operaciones con su Cuenta", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                idcuenta = 0;
                LimpiarControles();
                this.txtCodAge.Focus();
                return;
            }
            //--===================================================================================
            //--Validar la actualizacion de Datos en caso de menores de edad
            //--===================================================================================

            int idCli = Convert.ToInt32(frmbuscarcli.pcCodCli);
            DataTable dtValActCli = objDeposito.CNValidarActDatCli(idCli);
            if (Convert.ToBoolean(dtValActCli.Rows[0]["lReqUpdate"]))
            {
                MessageBox.Show("Debe de actualizar información del cliente", "Validación de datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            nidTipoPersona = frmbuscarcli.pnTipoPersona;
            DatoCuentasDep(Convert.ToInt32(frmbuscarcli.pcCodCli));         

            if (ClicBusCta != null)
                ClicBusCta(sender, e);
        }

        private bool ValidarDatosOpe(int x_idCuenta,Decimal x_nMontoOperac, Decimal x_nSaldoDisp)
        {
            //--===================================================================================
            //--Validar Bloqueo de la Cuenta
            //--===================================================================================
            string cMsg = "";
            clsCNOperacionDep clsBloq = new clsCNOperacionDep();
            if (!clsBloq.ValidarBloqueoCta(x_idCuenta, 11, ref cMsg))
            {
                MessageBox.Show(cMsg, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //--===================================================================================
            //--Validar Saldo Disponible
            //--===================================================================================
            if (p_idTipOpePrincipal==9 || p_idTipOpePrincipal==10) //--solo si es Apertura y Deposito
            {
                if (Convert.ToDecimal (x_nSaldoDisp) < x_nMontoOperac)
                {
                    MessageBox.Show("El Saldo Disponible de la Cuenta, es Menor al Monto de la operación: verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            
            //--===================================================================================
            //--Validar Datos para el Retiro
            //--===================================================================================
            string Mensaje = "";
            clsCNDeposito clsDatCta = new clsCNDeposito();
            if (!clsDatCta.CNValidaOperacionAho(x_idCuenta, "1", p_idTipOpePrincipal, x_nMontoOperac, ref Mensaje))
            {
                MessageBox.Show(Mensaje, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void DatoCuentasDep( int idCli)
        {
            idcuenta = 0;
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(idCli, idEstCuenta, Convert.ToInt32(pnIdMon), nTipOpe);
            switch (dtbNumCuentas.Rows.Count)
            {
                case 0:  //--No existe Cuentas
                    txtCodIns.Text = "";
                    txtCodAge.Text = "";
                    txtCodMod.Text = "";
                    txtCodMon.Text = "";
                    txtNroCta.Text = "";
                    txtCodCli.Text = "";
                    txtProducto.Text = "";
                    txtNombre.Text = "";
                    nidTipoPersona = 0;
                    idMoneda = 0;
                    idcuenta = 0;
                    MessageBox.Show("El cliente no tiene cuentas, para este tipo de operación, por Favor Verificar", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 1: //--El cliente solo tiene una cuenta
                    if (!ValidarDatosOpe(Convert.ToInt32(dtbNumCuentas.Rows[0]["idNum"].ToString()), x_nMontoOpe, Convert.ToDecimal(dtbNumCuentas.Rows[0]["nMonto"].ToString())))
	                {
		                return;
	                }
                    txtCodIns.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                    txtCodAge.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                    txtCodMod.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                    txtCodMon.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                    txtNroCta.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                    txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                    txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                    txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                    nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                    idMoneda = Convert.ToInt32(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                    idcuenta = Convert.ToInt32(dtbNumCuentas.Rows[0]["idNum"].ToString());
                    clsDeposito.CNUpdUsoCuenta(idcuenta, clsVarGlobal.User.idUsuario);
                    break;
                default: //--El Cliente tiene mas de Una Cuenta
                    //==================================================
                    //--Llamar al Formulario
                    //==================================================
                    frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                    frmbuscarCta.idCli = idCli;
                    frmbuscarCta.pTipBus = 2;
                    frmbuscarCta.nTipOpe =nTipOpe;  //--Tipo de Operación: 11 Retiro, 10 Deposito
                    frmbuscarCta.idMon = pnIdMon;  //--Se Enviará Moneda en Caso sea Necesario
                    frmbuscarCta.pcEstdo = idEstCuenta.ToString(); 
                    frmbuscarCta.ShowDialog();
                    if (!string.IsNullOrEmpty(frmbuscarCta.pnCta))
                    {
                        if (!ValidarDatosOpe(Convert.ToInt32(frmbuscarCta.pnCta),x_nMontoOpe, Convert.ToDecimal (frmbuscarCta.pnMonDisp)))
	                    {
		                    return;
	                    }
                        txtCodIns.Text = frmbuscarCta.pcNroCta.Substring(0, 3);
                        txtCodAge.Text = frmbuscarCta.pcNroCta.Substring(3, 3);
                        txtCodMod.Text = frmbuscarCta.pcNroCta.Substring(6, 3);
                        txtCodMon.Text = frmbuscarCta.pcNroCta.Substring(9, 1);
                        txtNroCta.Text = frmbuscarCta.pcNroCta.Substring(10, 12); 
                        txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                        txtProducto.Text = frmbuscarCta.pcProd; // dtbNumCuentas.Rows[1]["cProducto"].Value.ToString(); //0]["cProducto"].ToString();

                        txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                        nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                        idMoneda = frmbuscarCta.idMon;
                        idcuenta = Convert.ToInt32(frmbuscarCta.pnCta);
                        clsDeposito.CNUpdUsoCuenta(idcuenta, clsVarGlobal.User.idUsuario);
                    }

                    break;
            }
        }

        private void txtNroCta_Leave(object sender, EventArgs e)
        {

        }

        public void LimpiarControles()
        {
            txtCodIns.Text = "";
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtProducto.Text = "";
            txtNombre.Text = "";
        }

        private void txtNroCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
                if (e.KeyChar == 13 && ClicBusCta != null)
                {
                    if (!BusCliCtaAho())
                    {
                        //--===================================================================================
                        //--Validar la actualizacion de Datos en caso de menores de edad
                        //--===================================================================================
                        if (!string.IsNullOrEmpty(txtCodCli.Text.Trim()))
                        {
                            int idCli = Convert.ToInt32(txtCodCli.Text.Trim());
                            DataTable dtValActCli = objDeposito.CNValidarActDatCli(idCli);
                            if (Convert.ToBoolean(dtValActCli.Rows[0]["lReqUpdate"]))
                            {
                                MessageBox.Show("Debe de actualizar información del cliente", "Validación de datos de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                       
                        return;
                    }
                    ClicBusCta(sender, e);
                }

               
            }
            else
            {
                 e.Handled = true;
            }  
            
        }

        private bool ValidarIngresoDatos()
        {
            if (string.IsNullOrEmpty(this.txtCodAge.Text))
            {
                MessageBox.Show("Debe Ingresar el Código de la Agencia de la Cuenta", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCodAge.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCodMod.Text))
            {
                MessageBox.Show("Debe Ingresar el Código del Módulo", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCodMod.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCodMon.Text))
            {
                MessageBox.Show("Debe Ingresar el Código de la Moneda", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCodMon.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNroCta.Text))
            {
                MessageBox.Show("Debe Ingresar el Número de Cuenta", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroCta.Focus();
                return false;
            }
            return true;
        }

        private bool BusCliCtaAho()
        {
            idcuenta = 0;
            //---------------------------------------------------------------------------
            //---Validar el Ingreso de Datos
            //---------------------------------------------------------------------------
            if (!ValidarIngresoDatos())
            {
                return false;
            }

            if (!string.IsNullOrEmpty(txtNroCta.Text.ToString().Trim()))
            {
                //---------------------------------------------------------------------------
                //---Buscar por el Codigo de la Cuenta y Validar
                //---------------------------------------------------------------------------
                string x_cNroCuenta = txtCodIns.Text + txtCodAge.Text + txtCodMod.Text + txtCodMon.Text + txtNroCta.Text;
                DataTable dtRetidCta = new clsCNDeposito().CNRetornaidCuenta(x_cNroCuenta);
                if (dtRetidCta.Rows.Count <= 0)
                {
                    MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodIns.Focus();
                    idcuenta = 0;
                    return false;
                }
                else
                {
                    idcuenta = Convert.ToInt32(dtRetidCta.Rows[0]["idCuenta"].ToString());
                }

                DataTable dtNroCuenta = new clsCNDeposito().CNRetornaDatosxCuenta(idcuenta, idEstCuenta, pnIdMon, nTipOpe);
                if (dtNroCuenta.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtNroCuenta.Rows[0]["idCli"].ToString()) == clsVarGlobal.User.idCli)
                    {
                        MessageBox.Show("El Mismo usuario No Puede Realizar Operaciones con su Cuenta", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    if (ValidaCliBN.ValidaCliBaseNegativa(dtNroCuenta.Rows[0]["cDocumentoID"].ToString(), clsVarGlobal.idModulo, clsVarGlobal.lBaseNegativa))
                    {
                        return false;
                    }
                    txtCodIns.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                    txtCodAge.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                    txtCodMod.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                    txtCodMon.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                    txtNroCta.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                    txtCodCli.Text = dtNroCuenta.Rows[0]["idCli"].ToString();
                    txtProducto.Text = dtNroCuenta.Rows[0]["cProducto"].ToString();
                    txtNombre.Text = dtNroCuenta.Rows[0]["cNombre"].ToString();
                    nidTipoPersona = (int)dtNroCuenta.Rows[0]["nidTipoPersona"];
                    idMoneda = Convert.ToInt32(dtNroCuenta.Rows[0]["idMoneda"].ToString());
                    idcuenta = Convert.ToInt32(dtNroCuenta.Rows[0]["idNum"].ToString());
                }
                else
                {
                    txtCodIns.Text = "";
                    txtCodAge.Text = "";
                    txtCodMod.Text = "";
                    txtCodMon.Text = "";
                    txtNroCta.Text = "";
                    txtCodCli.Text = "";
                    txtProducto.Text = "";
                    txtNombre.Text = "";
                    nidTipoPersona = 0;
                    idMoneda = 0;
                    idcuenta = 0;
                    MessageBox.Show("El cliente no tiene cuentas para este tipo de operación, por Favor Verificar", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        public void LiberarCuenta()
        {
            if (idcuenta > 0)
            {
                objDeposito.CNUpdNoUsoCuenta(idcuenta);
            }
        }

        private void txtNroCta_TextChanged(object sender, EventArgs e)
        {

        }

        private void grbBase1_Enter(object sender, EventArgs e)
        {

        }
    }
}
