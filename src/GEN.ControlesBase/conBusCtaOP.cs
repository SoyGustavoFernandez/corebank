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

namespace GEN.ControlesBase
{
    public partial class conBusCtaOP : UserControl
    {
        public int nTipOpe = 0, pnIdMon = 0, idcli=0, idcuenta=0, idEstCuenta=1;
        public new event EventHandler ClicBusCta;
        public int nidTipoPersona;
        public int idMoneda;
        clsCNDeposito objDeposito = new clsCNDeposito();
        public conBusCtaOP()
        {
            InitializeComponent();
        }
               
        public void LimpiarControles()
        {
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtNroDoc.Text = "";
            txtNombre.Text = "";
            txtProducto.Text = "";
            txtMoneda.Text = "";
            txtNumFirmas.Text = "";
        }

        public void HabDeshabilitarCtrl(bool lVal)
        {
            txtCodAge.Enabled = lVal;
            txtCodMod.Enabled = lVal;
            txtCodMon.Enabled = lVal;
            txtNroCta.Enabled = lVal;
        }
        
        
        private void txtNroCta_Leave(object sender, EventArgs e)
        {

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
                                MessageBox.Show("Debe de actualizar información del cliente", "Validación de datos del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!string.IsNullOrEmpty(this.txtNroCta.Text))
            {
                this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
            }

            if (!string.IsNullOrEmpty(txtNroCta.Text.ToString().Trim()))
            {
                //---------------------------------------------------------------------------
                //---Buscar por el Codigo de la Cuenta y Validar
                //---------------------------------------------------------------------------
                string x_cNroCuenta = txtCodIns.Text + txtCodAge.Text + txtCodMod.Text + txtCodMon.Text + txtNroCta.Text;
                DataTable dtRetidCta = new clsCNDeposito().CNRetornaidCuenta(x_cNroCuenta);
                if (dtRetidCta.Rows.Count<=0)
                {
                    MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodAge.Focus();
                    idcuenta = 0;
                    return false;
                }
                else
                {
                    idcuenta = Convert.ToInt32(dtRetidCta.Rows[0]["idCuenta"].ToString());
                }
                
                //---------------------------------------------------------------------------
                //---Busqueda por el id Cuenta 
                //---------------------------------------------------------------------------
                DataTable dtNroCuenta = new clsCNDeposito().CNRetornaDatosxCuenta(idcuenta, idEstCuenta, pnIdMon, nTipOpe);
                if (dtNroCuenta.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtNroCuenta.Rows[0]["idCli"].ToString()) == clsVarGlobal.User.idCli)
                    {
                        MessageBox.Show("El Mismo usuario No Puede Realizar Operaciones con su Cuenta", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    //-----------------------------------------------------------
                    //-- Validamos la Moneda de la cuenta
                    //-----------------------------------------------------------
                    if (pnIdMon!=Convert.ToInt16(dtNroCuenta.Rows[0]["idMoneda"].ToString()))
                    {
                        MessageBox.Show("La Cuenta de la Orden de Pago, debe ser en la misma moneda de la Operación", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    txtCodIns.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                    txtCodAge.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                    txtCodMod.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                    txtCodMon.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                    txtNroCta.Text = dtNroCuenta.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                    txtCodCli.Text = dtNroCuenta.Rows[0]["idCli"].ToString();
                    txtNroDoc.Text = dtNroCuenta.Rows[0]["cDocumentoID"].ToString();
                    txtNombre.Text = dtNroCuenta.Rows[0]["cNombre"].ToString();
                    txtProducto.Text = dtNroCuenta.Rows[0]["cProducto"].ToString();
                    txtMoneda.Text = dtNroCuenta.Rows[0]["cMoneda"].ToString();
                    txtNumFirmas.Text = dtNroCuenta.Rows[0]["nNumeroFirmas"].ToString();

                    nidTipoPersona = (int)dtNroCuenta.Rows[0]["nidTipoPersona"];
                    idMoneda = Convert.ToInt32(dtNroCuenta.Rows[0]["idMoneda"].ToString());
                    idcuenta = Convert.ToInt32(dtNroCuenta.Rows[0]["idNum"].ToString());
                }
                else
                {
                    LimpiarControles();
                    nidTipoPersona = 0;
                    idMoneda = 0;
                    idcuenta = 0;
                    MessageBox.Show("La Cuenta no es Válido para el Tipo de Operación, por Favor Verificar", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodAge.Focus();
                    return false;
                }
            }
            return true;
        }

        public void LiberarCuenta()
        {
            if (idcuenta>0)
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

        private void txtCodAge_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCodAge.Text))
            {
                this.txtCodAge.Text = this.txtCodAge.Text.ToString().PadLeft(3, '0');
            }
        }

        private void txtCodMod_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCodMod.Text))
            {
                this.txtCodMod.Text = this.txtCodMod.Text.ToString().PadLeft(3, '0');
            }
        }

        private void txtNroCta_Leave_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtNroCta.Text))
            {
                this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
            }
        }

        private void conBusCtaAho_Load(object sender, EventArgs e)
        {
            
        }

        private void txtCodAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void txtCodMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void txtCodMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }
    }
}
