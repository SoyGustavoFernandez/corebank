using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEP.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class conBusCtaAho : UserControl
    {
        public int nTipOpe = 0, pnIdMon = 0, idcli = 0, idcuenta = 0, idEstCuenta = 1, idTipoDocumento;
        public new event EventHandler ClicBusCta;
        public int nidTipoPersona;
        public int idMoneda;
        clsCNDeposito objDeposito = new clsCNDeposito();
        clsCNBuscarCli ValidaCliBN = new clsCNBuscarCli();
        public bool lBloqueaBusquedaNombre = false;
        public string pcDireccion, pcTelefono, pcCodCliLargo;
        public new event EventHandler ChangeDocumentoID;

        public conBusCtaAho()
        {
            InitializeComponent();
        }

        private void btnBusCliente_Click(object sender, EventArgs e)
        {
            if (idcuenta!=0)
            {
                objDeposito.CNUpdNoUsoCuenta(idcuenta);
            }
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtNroDoc.Text = "";
            txtNombre.Text = "";
            nidTipoPersona = 0;
            idcuenta = 0;
            
            FrmBusCli frmbuscarcli = new FrmBusCli();
            frmbuscarcli.lBloqueaConsultaNombre = lBloqueaBusquedaNombre;
            frmbuscarcli.ShowDialog();
            this.pcCodCliLargo=frmbuscarcli.pcCodCliLargo;
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

        public void LimpiarControles()
        {
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtNroDoc.Text = "";
            txtNombre.Text = "";
            pcDireccion = "";
            pcTelefono = "";
        }

        public void HabDeshabilitarCtrl(bool lVal)
        {
            txtCodAge.Enabled = lVal;
            txtCodMod.Enabled = lVal;
            txtCodMon.Enabled = lVal;
            txtNroCta.Enabled = lVal;
        }

        private void DatoCuentasDep( int idCli)
        {
            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(idCli, idEstCuenta, pnIdMon, nTipOpe);
            switch (dtbNumCuentas.Rows.Count)
            {
                case 0:  //--No existe Cuentas
                    txtCodAge.Text = "";
                    txtCodMod.Text = "";
                    txtCodMon.Text = "";
                    txtNroCta.Text = "";
                    txtCodCli.Text = "";
                    txtNroDoc.Text = "";
                    txtNombre.Text = "";
                    nidTipoPersona = 0;
                    idMoneda = 0;
                    idcuenta = 0;
                    pcTelefono = "";
                    pcDireccion = "";
                    MessageBox.Show("El cliente no tienen Cuentas, para este tipo de operación, por Favor Verificar", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodAge.Focus();
                    break;
                case 1: //--El cliente solo tiene una cuenta
                    txtCodIns.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                    txtCodAge.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                    txtCodMod.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                    txtCodMon.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                    txtNroCta.Text = dtbNumCuentas.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                    txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                    txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                    txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                    nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                    idMoneda = Convert.ToInt32(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                    idcuenta = Convert.ToInt32(dtbNumCuentas.Rows[0]["idNum"].ToString());
                    idTipoDocumento = Convert.ToInt32(dtbNumCuentas.Rows[0]["idTipoDocumento"].ToString());

                    pcTelefono = dtbNumCuentas.Rows[0]["cTelefono"].ToString();
                    pcDireccion = dtbNumCuentas.Rows[0]["cDireccion"].ToString();
                    break;
                default: //--El Cliente tiene mas de Una Cuenta
                    //==================================================
                    //--Llamar al Formulario
                    //==================================================
                    frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                    frmbuscarCta.idCli = idCli;
                    frmbuscarCta.pTipBus = 2;
                    frmbuscarCta.nTipOpe = nTipOpe;  //--Tipo de Operación: 11 Retiro, 10 Deposito
                    frmbuscarCta.idMon = pnIdMon;  //--Se Enviará Moneda en Caso sea Necesario
                    frmbuscarCta.idestado = idEstCuenta;
                    frmbuscarCta.ShowDialog();
                    if (!string.IsNullOrEmpty(frmbuscarCta.pnCta))
                    {
                        txtCodIns.Text = frmbuscarCta.pcNroCta.Substring(0, 3);
                        txtCodAge.Text = frmbuscarCta.pcNroCta.Substring(3, 3);
                        txtCodMod.Text = frmbuscarCta.pcNroCta.Substring(6, 3);
                        txtCodMon.Text = frmbuscarCta.pcNroCta.Substring(9, 1);
                        txtNroCta.Text = frmbuscarCta.pcNroCta.Substring(10, 12);
                        txtCodCli.Text = dtbNumCuentas.Rows[0]["idCli"].ToString();
                        txtNroDoc.Text = dtbNumCuentas.Rows[0]["cDocumentoID"].ToString();
                        txtNombre.Text = dtbNumCuentas.Rows[0]["cNombre"].ToString();
                        nidTipoPersona = (int)dtbNumCuentas.Rows[0]["nidTipoPersona"];
                        idMoneda = frmbuscarCta.idMon;
                        idcuenta = Convert.ToInt32(frmbuscarCta.pnCta);

                        pcTelefono = dtbNumCuentas.Rows[0]["cTelefono"].ToString();
                        pcDireccion = dtbNumCuentas.Rows[0]["cDireccion"].ToString();
                    }

                    break;
            }
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
                string x_cEstado = "",
                       x_cProducto = "";

                if (dtRetidCta.Rows.Count<=0)
                {
                    MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodAge.Focus();
                    idcuenta = 0;
                    return false;
                }
                else
                {
                    x_cEstado = dtRetidCta.Rows[0]["cEstado"].ToString();
                    x_cProducto = dtRetidCta.Rows[0]["cProducto"].ToString();

                    //--===========================================================================
                    //---Validación por Estado de la Cuenta
                    //--===========================================================================
                    int x_idEstado = Convert.ToInt32(dtRetidCta.Rows[0]["idEstado"].ToString());
                    switch (x_idEstado)
                    {
                        case 1:  //--Vigente
                            break;
                        case 2: //--Cancelado
                            if (nTipOpe.In(9,10,11,12))
                            {
                                MessageBox.Show("La Cuenta se encuentra en estado Cancelado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimpiarControles();
                                txtCodAge.Focus();
                                idcuenta = 0;
                                return false;
                            }
                            break;
                        case 3: //--Extornado
                            MessageBox.Show("La Cuenta se encuentra en estado Extornado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            txtCodAge.Focus();
                            idcuenta = 0;
                            return false;
                        case 4: //--Pres Solicitado
                            if (nTipOpe.In(10,11,12))
                            {
                                MessageBox.Show("La Cuenta se encuentra en Estado Solicitado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimpiarControles();
                                txtCodAge.Focus();
                                idcuenta = 0;
                                return false;
                            }
                            break;
                        case 5: //--Anulado
                            MessageBox.Show("La Cuenta se encuentra en estado Anulado", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            txtCodAge.Focus();
                            idcuenta = 0;
                            return false;
                        case 6: //--Vencimiento por Producto
                            MessageBox.Show("La Cuenta se encuentra Denegado por Vencimiento de Producto", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            txtCodAge.Focus();
                            idcuenta = 0;
                            return false;

                        default:
                            MessageBox.Show("Estado de la Cuenta no Válido...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            txtCodAge.Focus();
                            idcuenta = 0;
                            return false;
                    }

                    //--===========================================================================
                    //---Validación por Tipo de Operación
                    //--===========================================================================                    
                    switch (nTipOpe)
                    {
                        case 9: //--Aperturas
                            if (x_idEstado!=4)
                            {
                                MessageBox.Show("El estado de la cuenta es: " + x_cEstado+ " , Para la apertura debe estar en estado SOLICITADO", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimpiarControles();
                                txtCodAge.Focus();
                                idcuenta = 0;
                                return false;
                            }
                            break;
                        case 10: //--Deposito
                            if (!Convert.ToBoolean(dtRetidCta.Rows[0]["lIsOpeDeposito"].ToString()))
                            {
                                MessageBox.Show("La Cuenta es: "+ x_cProducto+", No esta permitido para realizar Depósitos", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimpiarControles();
                                txtCodAge.Focus();
                                idcuenta = 0;
                                return false;
                            }
                            break;
                        case 11: //--Retiro
                            if (!Convert.ToBoolean(dtRetidCta.Rows[0]["lIsOpeRetiro"].ToString()))
                            {
                                MessageBox.Show("La Cuenta es: " + x_cProducto + ", No esta permitido para realizar Retiros", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LimpiarControles();
                                txtCodAge.Focus();
                                idcuenta = 0;
                                return false;
                            }
                            break;
                        case 12: //--Cancelación
                            break;
                    }


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
                    txtNroDoc.Text = dtNroCuenta.Rows[0]["cDocumentoID"].ToString();
                    txtNombre.Text = dtNroCuenta.Rows[0]["cNombre"].ToString();
                    nidTipoPersona = (int)dtNroCuenta.Rows[0]["nidTipoPersona"];
                    idMoneda = Convert.ToInt32(dtNroCuenta.Rows[0]["idMoneda"].ToString());
                    idcuenta = Convert.ToInt32(dtNroCuenta.Rows[0]["idNum"].ToString());
                }
                else
                {
                    txtCodAge.Text = "";
                    txtCodMod.Text = "";
                    txtCodMon.Text = "";
                    txtNroCta.Text = "";
                    txtCodCli.Text = "";
                    txtNroDoc.Text = "";
                    txtNombre.Text = "";
                    nidTipoPersona = 0;
                    idMoneda = 0;
                    idcuenta = 0;
                    MessageBox.Show("El Producto: " + x_cProducto+", no es Válido para el tipo de Operación", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtCodMon_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCodMon.Text))
            {
                this.txtCodMon.Text = this.txtCodMon.Text.ToString().PadLeft(1, '0');
            }
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            if (this.ChangeDocumentoID != null)
            {
                this.ChangeDocumentoID(sender, e);
            }
        }
    }
}
