using DEP.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmCalculoCTS : frmBase
    {
        public int p_idMoneda;

        txtNumRea MontoDeposito;
        txtNumRea MontoIntangible;

        public frmCalculoCTS()
        {
            InitializeComponent();
        }

        public frmCalculoCTS(txtNumRea MontoDeposito, txtNumRea MontoIntangible)
        {
            InitializeComponent();
            this.limpiarFormulario();

            this.MontoDeposito = MontoDeposito;
            this.MontoIntangible = MontoIntangible;

            this.txtMontoDeposito.Text = this.MontoDeposito.Text;            
        }

        private void frmCalculoCTS_Load(object sender, EventArgs e)
        {
            cboMoneda.SelectedValue = p_idMoneda;
            //txtTipoCambio.Text = "1.00";
            if (p_idMoneda==1)
            {
                rbtSoles.Checked = true;
            }
            else
            {
                rbtDolares.Checked = true;
            }
            this.txtNroRemuneraciones.Enabled = false;
            this.txtSaldoDisponible.Enabled = false;
            this.txtSaldoIntangible.Enabled = false;

            this.txtNroRemuneraciones.Text = Convert.ToString(clsVarApl.dicVarGen["nNroRemuneraciones"]);

            this.btnAceptar.Enabled = false;
            txtMontoDeposito.Focus();
            txtMontoDeposito.SelectAll();
        }

        private void limpiarFormulario()
        {
            this.txtMontoDeposito.Text = "0.00";
            this.txtSaldoConvert.Text = "0.00";
            this.txtRemuTotal.Text = "0.00";
            this.txtRemConvert.Text="0.00";

            this.txtSaldoDisponible.Text = "0.00";
            this.txtSaldoIntangible.Text = "0.00";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio", "Calculo CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipoCambio.Focus();
                return; 
            }
            if (Convert.ToDecimal(txtTipoCambio.Text)<=0)
            {
                MessageBox.Show("El Tipo de Cambio no es Válido", "Calculo CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipoCambio.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.txtMontoDeposito.Text) || Convert.ToDecimal(this.txtMontoDeposito.Text) <= 0)
            {
                MessageBox.Show("Ingrese un Monto de Deposito valido", "Calculo CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMontoDeposito.Focus();
                return; 
            }

            if (string.IsNullOrEmpty(this.txtRemuTotal.Text) || Convert.ToDecimal(this.txtRemuTotal.Text) <= 0)
            {
                MessageBox.Show("Ingrese una Remuneración Total valido", "Calculo CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemuTotal.Focus();
                return;
            }

            decimal nMontoDeposito = Convert.ToDecimal(this.txtMontoDeposito.Text);
            decimal nRemuTotal = Convert.ToDecimal(this.txtRemuTotal.Text);
            decimal nTipCambio = Convert.ToDecimal(this.txtTipoCambio.Text);

            //---Montos Convertidos
            decimal x_nMonDepConvert = 0,
                   x_nRemConvert = 0;

            if (rbtSoles.Checked && Convert.ToInt16(cboMoneda.SelectedValue) == 2)
            {
                x_nMonDepConvert = Math.Round(nMontoDeposito / nTipCambio, 2);
                x_nRemConvert = Math.Round(nRemuTotal / nTipCambio, 2);
            }
            else
            {
                x_nMonDepConvert = Math.Round(nMontoDeposito * nTipCambio, 2);
                x_nRemConvert = Math.Round(nRemuTotal * nTipCambio, 2);
            }
           

            txtSaldoConvert.Text = string.Format("{0:#,#0.00}", x_nMonDepConvert);
            txtRemConvert.Text = string.Format("{0:#,#0.00}", x_nRemConvert);

            if (nMontoDeposito<=nRemuTotal)
            {
                this.txtSaldoIntangible.Text = string.Format("{0:#,#0.00}", x_nMonDepConvert);
                this.txtSaldoDisponible.Text = "0.00";
            }
            else
            {
                this.txtSaldoIntangible.Text = string.Format("{0:#,#0.00}", x_nRemConvert * clsVarApl.dicVarGen["nPorcentajeCTS"]);
                this.txtSaldoDisponible.Text = string.Format("{0:#,#0.00}", (x_nMonDepConvert - x_nRemConvert) * clsVarApl.dicVarGen["nPorcentajeCTS"]);
            }

            this.btnCalcular.Enabled = false;
            this.btnAceptar.Enabled = true;
            HabDeshabCtrls(false);
        }

        private void HabDeshabCtrls(bool Val)
        {
            rbtSoles.Enabled = Val;
            rbtDolares.Enabled = Val;
            chcTipCambio.Enabled = Val;
            txtMontoDeposito.Enabled = Val;
            txtRemuTotal.Enabled = Val;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarFormulario();
            HabDeshabCtrls(true);
            this.btnCalcular.Enabled = true;
            this.btnAceptar.Enabled = false;
            txtMontoDeposito.Focus();
            txtMontoDeposito.SelectAll();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.MontoDeposito.Text = txtSaldoConvert.Text; // this.txtMontoDeposito.Text;
            this.MontoIntangible.Text = this.txtSaldoIntangible.Text;
            this.Dispose();
        }

        private void txtMontoDeposito_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMontoDeposito.Text))
            {
                txtMontoDeposito.Text=string.Format("{0:#,#0.00}",Convert.ToDecimal (txtMontoDeposito.Text));
            }
        }

        private void txtRemuTotal_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRemuTotal.Text))
            {
                txtRemuTotal.Text = string.Format("{0:#,#0.00}", Convert.ToDecimal (txtRemuTotal.Text));
            }
        }

        private void rbtSoles_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSoles.Checked)
            {
                chcTipCambio.Enabled = false;
                if (Convert.ToInt16(cboMoneda.SelectedValue) == 1)
                {
                    txtTipoCambio.Text = "1.00";
                }
                else
                {
                    txtTipoCambio.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamFij"]);
                    chcTipCambio.Enabled = true;
                }
            }            
        }

        private void rbtDolares_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDolares.Checked)
            {
                chcTipCambio.Enabled = true;
                if (Convert.ToInt16(cboMoneda.SelectedValue) == 2)
                {
                    txtTipoCambio.Text = "1.00";
                }
                else
                {
                    txtTipoCambio.Text = Convert.ToString(clsVarApl.dicVarGen["nTipCamFij"]);
                }
            }
        }

        private void chcTipCambio_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTipCambio.Checked)
            {
                txtTipoCambio.Enabled = true;
                txtTipoCambio.Focus();
            }
            else
            {
                txtTipoCambio.Enabled = false;
            }
        }             
    }
}
