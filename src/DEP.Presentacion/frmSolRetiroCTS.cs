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

namespace DEP.Presentacion
{
    public partial class frmSolRetiroCTS : frmBase
    {
        int p_idProd = 0;

        clsCNDeposito clsDeposito = new clsCNDeposito();

        public frmSolRetiroCTS()
        {
            InitializeComponent();
        }

        private void frmSolRetiroCTS_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;  //--Ope cancelación, Lista todas las cuentas vigentes
            this.cboMotivoOperacion.ListarMotivoOperacion(11, 0);
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            limpiarcontroles();
            if (conBusCtaAho.idcuenta > 0)
            {
                DatosCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
        }


        private void DatosCuenta(int idCta)
        {
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", 11); //Operación de Retiros
            if (dtbNumCuentas.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(dtbNumCuentas.Rows[0]["lisCtaCTS"]) )
                {
                    MessageBox.Show("No es una cuenta CTS, por favor verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conBusCtaAho.LimpiarControles();
                    conBusCtaAho.HabDeshabilitarCtrl(true);
                    conBusCtaAho.txtCodAge.Focus();
                    return;
                }
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                cboTipoCuenta.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString());
                txtTipoPersona.Text = dtbNumCuentas.Rows[0]["cPersona"].ToString();
                dtFecApertura.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"].ToString());
                p_idProd = Convert.ToInt32(dtbNumCuentas.Rows[0]["idProducto"]);
                txtSaldo.Text = dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString();
                txtDisponible.Text = dtbNumCuentas.Rows[0]["nSaldoDis"].ToString();
                Decimal nTotal = Math.Round(Convert.ToDecimal (dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString()) * Convert.ToDecimal (clsVarApl.dicVarGen["nPorcentajeMaxCTS"]), 2);
                txtMonMaxRet.Text = string.Format("{0:#,#0.00}", nTotal);
                
                //--===================================================================================
                //--Habilitar Controles
                //--===================================================================================
                conBusCtaAho.HabDeshabilitarCtrl(false);
                conBusCtaAho.btnBusCliente.Enabled = false;
                DesabilitarCtrls(true);
                btnEnviar.Enabled = true;
                cboMotivoOperacion.Focus();
            }
            else
            {
                MessageBox.Show("No Existen datos, por favor Verificar...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void limpiarcontroles()
        {
            //---Datos de la Cuenta
            txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            txtTipoPersona.Clear();
            dtFecApertura.Value = clsVarGlobal.dFecSystem;
            txtSaldo.Text = "0.00";
            txtDisponible.Text = "0.00";
            txtMonMaxRet.Text = "0.00";

            //---Datos de la Solicitud
            cboMotivoOperacion.SelectedValue = 1;
            txtMonRetiro.Text = "0.00";
            txtMotCambio.Clear();
        }

        private bool ValidarDatosIngresados()
        {
            if (Convert.ToInt32(cboMotivoOperacion.SelectedIndex) == -1)
            {
                MessageBox.Show("Debe seleccionar el Motivo de Retiro de CTS...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboMotivoOperacion.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotCambio.Text))
            {
                MessageBox.Show("Debe registrar el detalle del retiro de CTS...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMotCambio.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMonRetiro.Text))
            {
                 MessageBox.Show("Debe registrar el monto de retiro de CTS...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMonRetiro.Focus();
                return false;
            }

            if (Convert.ToDecimal (txtMonRetiro.Text)<=0)
            {
                MessageBox.Show("Debe registrar un monto válido, mayor a cero...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMonRetiro.Focus();
                return false;
            }

            if (Convert.ToDecimal (txtMonRetiro.Text) > Convert.ToDecimal (txtMonMaxRet.Text))
            {
                MessageBox.Show("El Monto de retiro, no puede ser mayor al Monto maximo de retiro...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMonRetiro.Focus();
                return false;
            }

            if (Convert.ToDecimal (txtMonRetiro.Text) <= Convert.ToDecimal (txtDisponible.Text))
            {
                MessageBox.Show("El Monto de retiro, no puede ser menor o igual a su saldo disponible...Revisar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMonRetiro.Focus();
                return false;
            }

            return true;
        }

        private void DesabilitarCtrls(bool Val)
        {
            cboMotivoOperacion.Enabled = Val;
            txtMonRetiro.Enabled = Val;
            txtMotCambio.Enabled = Val;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p_idProd = 0;
            conBusCtaAho.LimpiarControles();
            limpiarcontroles();
            btnEnviar.Enabled = false;
            DesabilitarCtrls(false);
            conBusCtaAho.HabDeshabilitarCtrl(true);
            conBusCtaAho.btnBusCliente.Enabled = true;
            conBusCtaAho.txtCodAge.Focus();            
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados())
            {
                return;
            }

            string x_cMotCambio = txtMotCambio.Text;
            int x_idCuenta = conBusCtaAho.idcuenta;
            decimal nMontoSol = Convert.ToDecimal(txtMonRetiro.nDecValor);

            clsCNAutorTasaEsp solicitud = new clsCNAutorTasaEsp();

            DataTable dtSol = solicitud.EnviarSolicitud(clsVarGlobal.nIdAgencia, Convert.ToInt32(conBusCtaAho.txtCodCli.Text), 123, 1, Convert.ToInt32(cboMoneda.SelectedValue),
                                                p_idProd, nMontoSol, x_idCuenta, clsVarGlobal.dFecSystem, Convert.ToInt32(cboMotivoOperacion.SelectedValue), x_cMotCambio, 1,
                                                Convert.ToDateTime("01/01/1900"), Convert.ToInt32(clsVarGlobal.User.idUsuario));
            if (Convert.ToInt32(dtSol.Rows[0]["idEstadoSol"].ToString()) == 1)
            {
                MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + dtSol.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            }
            else
            {
                MessageBox.Show(dtSol.Rows[0]["cMensaje"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            btnEnviar.Enabled = false;
            DesabilitarCtrls(false);
            btnCancelar.Focus();
        }

        private void txtMonRetiro_Leave(object sender, EventArgs e)
        {
            
        }

    }
}
