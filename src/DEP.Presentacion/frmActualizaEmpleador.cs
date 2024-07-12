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
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace DEP.Presentacion
{
    public partial class frmActualizaEmpleador : frmBase
    {
        clsFunUtiles FunTruncar = new clsFunUtiles();
        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNCalculosAho clsCalculos = new clsCNCalculosAho();

        int p_idCuenta = 0;

        public frmActualizaEmpleador()
        {
            InitializeComponent();
        }

        private void frmActualizaEmpleador_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;
            conBusCtaAho.idMoneda = 0;
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
            DesabilitarCtrl(false);
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!Buscar())
            {
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                conBusCtaAho.HabDeshabilitarCtrl(true);
                conBusCtaAho.txtCodAge.Focus();
            }            
        }

        private bool Buscar()
        {
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            LimpiarControles();

            if (conBusCtaAho.txtNroCta.Text.Trim() == "")
            {
                return false;
            }                    

            //========================================================================
            //--Traer los datos de la Cuenta
            //========================================================================
            p_idCuenta = 0;

            //---------------------------------------------------------------------------
            //---Buscar por el Codigo de la Cuenta y Validar
            //---------------------------------------------------------------------------
            string x_cNroCuenta = conBusCtaAho.txtCodIns.Text + conBusCtaAho.txtCodAge.Text + conBusCtaAho.txtCodMod.Text + conBusCtaAho.txtCodMon.Text + conBusCtaAho.txtNroCta.Text;
            DataTable dtRetidCta = new clsCNDeposito().CNRetornaidCuenta(x_cNroCuenta);
            if (dtRetidCta.Rows.Count <= 0)
            {
                MessageBox.Show("El Número de Cuenta Ingresado no Existe...Verificar", "Validar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.txtCodIns.Focus();
                return false;
            }
            else
            {
                p_idCuenta = Convert.ToInt32(dtRetidCta.Rows[0]["idCuenta"].ToString());
            }
            
            DataTable DatosCuenta = clsDeposito.CNRetornaDatosCuenta(p_idCuenta,"1",12);

            if (DatosCuenta.Rows.Count <= 0)
            {
                MessageBox.Show("No Hay datos de la cuenta búscada...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            bool lEsCtaCTS = Convert.ToBoolean(DatosCuenta.Rows[0]["lisCtaCTS"].ToString());

            if (!Convert.ToBoolean(DatosCuenta.Rows[0]["lIsReqEmpleador"].ToString()))
            {
                MessageBox.Show("La cuenta no requiere Empleador...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //------------------------------------------------------------------------------
            //Datos Generales de la Cuenta
            //------------------------------------------------------------------------------
            cboMoneda.SelectedValue = Convert.ToInt32(DatosCuenta.Rows[0]["idMoneda"]);
            txtTipCuenta.Text = Convert.ToString(DatosCuenta.Rows[0]["cTipoCuenta"]);
            txtProducto.Text = Convert.ToString(DatosCuenta.Rows[0]["cProducto"]);            

            if (Convert.ToBoolean(DatosCuenta.Rows[0]["lIsReqEmpleador"].ToString()))
            {
                if (!string.IsNullOrEmpty(DatosCuenta.Rows[0]["idCli"].ToString()))
                {
                    this.conBusCli.CargardatosCli(Convert.ToInt32(DatosCuenta.Rows[0]["idCli"].ToString()));
                }                
            }
            conBusCtaAho.HabDeshabilitarCtrl(false);
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            return true;
        }

        private void LimpiarControles()
        {
            cboMoneda.SelectedValue = 1;
            txtTipCuenta.Text = "";
            txtProducto.Text = "";
            conBusCli.limpiarControles();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(conBusCtaAho.txtCodCli.Text))
            {
                MessageBox.Show("Primero debe buscar una cuenta de ahorros válida...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCtaAho.txtCodAge.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCli.txtCodCli.Text))
            {
                MessageBox.Show("Primero debe buscar al empleador, para actualizar sus datos...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli.btnBusCliente.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(conBusCli.txtNroDoc.Text))
            {
                MessageBox.Show("El número de documento del empleador no es válido...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli.btnBusCliente.Focus();
                return false;
            }
            if (conBusCli.txtNroDoc.Text.ToString().Length!=11)
            {
                MessageBox.Show("El empleador tiene que ser una empresa, por favor verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCli.btnBusCliente.Focus();
                return false;
            }
            return true;
        }

        private void DesabilitarCtrl(bool Val)
        {
            conBusCli.txtCodCli.Enabled = Val;
            conBusCli.btnBusCliente.Enabled = Val;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conBusCli.btnBusCliente.Enabled = true;
            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            conBusCli.btnBusCliente.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            int idCuenta = conBusCtaAho.idcuenta;
            string cNroDoc = conBusCli.txtNroDoc.Text;

            DataTable dtActCuenta = clsDeposito.CNActualizaEmpleador(idCuenta, cNroDoc, clsVarGlobal.User.idUsuario,clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtActCuenta.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(dtActCuenta.Rows[0]["cMensaje"].ToString(), "Actualizar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(dtActCuenta.Rows[0]["cMensaje"].ToString(), "Actualizar Empleador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            conBusCli.btnBusCliente.Enabled = false;
            btnEditar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            LimpiarControles();
            conBusCtaAho.LimpiarControles();
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCli.limpiarControles();
            conBusCli.btnBusCliente.Enabled = false;
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            conBusCli.txtCodCli.Enabled = false;
            if (!string.IsNullOrEmpty(conBusCli.txtNroDoc.Text))
            {
                if (conBusCli.txtNroDoc.Text.Length!=11)
                {
                    MessageBox.Show("El empleador tiene que ser una empresa, por favor verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conBusCli.limpiarControles();
                    conBusCli.txtCodCli.Enabled = false;
                    return;
                }
            }
        }
    }
}
