using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using DEP.CapaNegocio;
namespace GEN.ControlesBase
{
    
    public partial class ConBusCtaCliSinBloq : UserControl
    {
        #region Variables Globales
        public String cTipoBusqueda = "";
        public String cEstado = "[1]";
        public int nValBusqueda=0,idmodulo;
        public int nIdCliente, nidUserBloqueo, nIdCuenta;
        public new event KeyPressEventHandler MyKey;
        public new event EventHandler MyClic;
        public string cUserBloqueo, cAgeBloquea;
        #endregion
        #region Constructor
        public ConBusCtaCliSinBloq()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void btnBusCliente1_Click(object sender, EventArgs e)
        {
            FrmBusCli FrmBus = new FrmBusCli();
            FrmBus.ShowDialog();

            if (string.IsNullOrEmpty(FrmBus.pcCodCli))
            {
                this.txtNroCta.Focus();
                btnBusCliente.Enabled = true;
            }
            else
            {
                nIdCliente = Convert.ToInt32(FrmBus.pcCodCli);
                if (this.cTipoBusqueda == "C")
                {
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstado);
                    switch (dtDatosCuentaSolCliente.Rows.Count)
                    {
                        case 0:
                            MessageBox.Show("No se Encontró Datos", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 1:
                            nValBusqueda = Convert.ToInt32(dtDatosCuentaSolCliente.Rows[0][0]);
                            idmodulo = 1;
                            this.BusCuentaBloqueadas();
                            break;
                        default:
                            FrmBuscaCuentaCliente frmBusCuenCli = new FrmBuscaCuentaCliente();
                            frmBusCuenCli.CargarDatos(nIdCliente, this.cTipoBusqueda, this.cEstado);
                            frmBusCuenCli.ShowDialog();
                            nValBusqueda = Convert.ToInt32(frmBusCuenCli.cIdCreSol);
                            idmodulo = 1;
                            this.BusCuentaBloqueadas();
                            break;
                    }

                }
                if (this.cTipoBusqueda == "D")
                {
                    clsCNDeposito objDeposito = new clsCNDeposito();
                    DataTable dtbNumCuentas = objDeposito.CNCuentasAhorros(nIdCliente, 1, 0, 16);
                    switch (dtbNumCuentas.Rows.Count)
                    {
                        case 0:  //--No existe Cuentas
                            MessageBox.Show("No se Encontró Datos", "Buscar Cuentas del Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        case 1: //--El cliente solo tiene una cuenta
                            nValBusqueda = Convert.ToInt32(dtbNumCuentas.Rows[0]["idNum"]);
                            idmodulo = 2;
                            this.BusCuentaBloqueadas();
                            break;
                        default: //--El Cliente tiene mas de Una Cuenta
                            //==================================================
                            //--Llamar al Formulario
                            //==================================================

                            frmBusCtaAho frmbuscarCta = new frmBusCtaAho();
                            frmbuscarCta.idCli = nIdCliente;
                            frmbuscarCta.pTipBus = 2;
                            frmbuscarCta.nTipOpe = 16;  //--Tipo de Operación: 11 Retiro, 10 Deposito
                            frmbuscarCta.idestado = 1;
                            frmbuscarCta.idMon = 0;  //--Se Enviará Moneda en Caso sea Necesario
                            frmbuscarCta.ShowDialog();
                            if (!string.IsNullOrEmpty(frmbuscarCta.pnCta))
                            {
                                nValBusqueda = Convert.ToInt32(frmbuscarCta.pnCta);
                                idmodulo = 2;
                                this.BusCuentaBloqueadas();
                                if (MyClic != null)
                                    MyClic(sender, e);
                                break;
                            }

                            break;
                    }
                }
                if (MyClic != null)
                    MyClic(sender, e);

            }

        }
        private void txtNroCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13)
            {
                e.Handled = false;
                if (e.KeyChar == 13 && MyClic != null)
                {
                    if (this.cTipoBusqueda == "C") //--Créditos
                    {
                        if (string.IsNullOrEmpty(this.txtNroCta.Text.ToString().Trim()))
                        {
                            MessageBox.Show("Por Favor Ingrese la Cuenta", "Buscar Cuenta de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtNroCta.Focus();

                        }
                        else
                        {
                            nValBusqueda = Convert.ToInt32(this.txtNroCta.Text.ToString().Trim());
                            BusCuentaBloqueadas();
                            MyClic(sender, e);
                        }                        
                    }

                    if (this.cTipoBusqueda == "D") //--Ahorros
                    {
                        //---------------------------------------------------------------------------
                        //---Validar el Ingreso de Datos
                        //---------------------------------------------------------------------------
                        if (!ValidarIngresoDatos())
                        {
                            return;
                        }
                        if (!string.IsNullOrEmpty(this.txtNroCta.Text))
                        {
                            this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
                        }

                        //---------------------------------------------------------------------------
                        //---Buscar por el Codigo de la Cuenta y Validar
                        //---------------------------------------------------------------------------
                        string x_cNroCuenta = txtCodIns.Text + txtCodAge.Text + txtCodMod.Text + txtCodMon.Text + txtNroCta.Text;
                        DataTable dtRetidCta = new clsCNDeposito().CNRetornaidCuenta(x_cNroCuenta);
                        if (dtRetidCta.Rows.Count <= 0)
                        {
                            MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCodAge.Focus();
                            nValBusqueda = 0;
                            return;
                        }
                        else
                        {
                            nValBusqueda = Convert.ToInt32(dtRetidCta.Rows[0]["idCuenta"].ToString());
                            BusCuentaBloqueadas();
                            MyClic(sender, e);
                        }

                    }                   
                }
                else
                {
                    return;
                }
                if (MyKey != null)
                    MyKey(sender, e);
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion
        #region Metodos

        public void LimpiarControles()
        {
            txtCodAge.Text = "";
            txtCodMod.Text = "";
            txtCodMon.Text = "";
            txtNroCta.Text = "";
            txtCodCli.Text = "";
            txtNroDoc.Text = "";
            txtNombre.Text = "";
        }

        public void HabDeshabilitarCtrl(bool lVal)
        {
            txtCodAge.Enabled = lVal;
            txtCodMod.Enabled = lVal;
            txtCodMon.Enabled = lVal;
            txtNroCta.Enabled = lVal;
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

        private void BusCuentaBloqueadas()
        {

            clsCNRetornaNumCuenta RetornaNumCuenta = new clsCNRetornaNumCuenta();
            DataTable dtEstCuenta = RetornaNumCuenta.CNVerifEstCuentaGen(nValBusqueda, idmodulo);
            
            if (dtEstCuenta.Rows.Count>0)
            {
                if ((int)dtEstCuenta.Rows[0]["nIdUsuBloq"] > 0)
                {
                    if (this.cTipoBusqueda == "C")
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dtEstCuenta.Rows[0]["cNroCuenta"])))
                        {
                            txtCodIns.Text = String.Empty;
                            txtCodAge.Text = String.Empty;
                            txtCodMod.Text = String.Empty;
                            txtCodMon.Text = String.Empty;
                            txtNroCta.Text = Convert.ToString(dtEstCuenta.Rows[0]["idCuenta"]);
                            MessageBox.Show("ADVERTENCIA: La cuenta esta pendiente de desembolso.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            txtCodIns.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                            txtCodAge.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                            txtCodMod.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 2);
                            txtCodMon.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(8, 1);
                            txtNroCta.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9, 9);
                        }
                        
                        txtCodCli.Text = dtEstCuenta.Rows[0]["cCodCliente"].ToString();
                        txtNroDoc.Text = dtEstCuenta.Rows[0]["cDocumentoID"].ToString();
                        txtNombre.Text = dtEstCuenta.Rows[0]["cNombre"].ToString();
                        DataTable dtUsu = RetornaNumCuenta.BusUsuBlo((int)dtEstCuenta.Rows[0]["nIdUsuBloq"]);
                        cUserBloqueo = dtUsu.Rows[0]["cNombre"].ToString();
                        cAgeBloquea = dtUsu.Rows[0]["cNombreAge"].ToString();
                    }
                    if (this.cTipoBusqueda == "D")
                    {
                        txtCodIns.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(0, 3);
                        txtCodAge.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(3, 3);
                        txtCodMod.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(6, 3);
                        txtCodMon.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(9, 1);
                        txtNroCta.Text = dtEstCuenta.Rows[0]["cNroCuenta"].ToString().Substring(10, 12);
                        txtCodCli.Text = dtEstCuenta.Rows[0]["cCodCliente"].ToString();
                        txtNroDoc.Text = dtEstCuenta.Rows[0]["cDocumentoID"].ToString();
                        txtNombre.Text = dtEstCuenta.Rows[0]["cNombre"].ToString();
                        DataTable dtUsu = RetornaNumCuenta.BusUsuBlo((int)dtEstCuenta.Rows[0]["nIdUsuBloq"]);
                        cUserBloqueo = dtUsu.Rows[0]["cNombre"].ToString();
                        cAgeBloquea = dtUsu.Rows[0]["cNombreAge"].ToString();
                        HabDeshabilitarCtrl(false);
                    }
                    nidUserBloqueo = Convert.ToInt32(dtEstCuenta.Rows[0]["nIdUsuBloq"]);
                    btnBusCliente.Enabled = false;
                    
                }
                else
                {
                    MessageBox.Show("La Cuenta no se encuentra Bloqueada.", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtNroCta.SelectAll();
                    this.txtNroCta.Focus();
                    nValBusqueda = -1;
                }
              
            }
            else
            {

                MessageBox.Show("No se encontro Datos para el criterio de búsqueda", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroCta.SelectAll();
                this.txtNroCta.Focus();
                nValBusqueda = -1;
            }
        }
        #endregion

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

        private void txtNroCta_Leave(object sender, EventArgs e)
        {
            if (this.cTipoBusqueda == "D")
            {
                if (!string.IsNullOrEmpty(this.txtNroCta.Text))
                {
                    this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(12, '0');
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.txtNroCta.Text))
                {
                    this.txtNroCta.Text = this.txtNroCta.Text.ToString().PadLeft(9, '0');
                }
            }
            
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
