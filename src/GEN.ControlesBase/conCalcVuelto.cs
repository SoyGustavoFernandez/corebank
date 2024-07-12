using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class conCalcVuelto : UserControl
    {
        public new event EventHandler MyKey;
        public decimal nMontoTotalpago=0 ;
        public bool lCorrecto = false;
        public conCalcVuelto()
        {
            InitializeComponent();
        }

        private void txtNumRea1_TextChanged(object sender, EventArgs e)
        {
            lCorrecto = false;
            if (string.IsNullOrEmpty(txtMonEfectivo.Text) || txtMonEfectivo.Text == "0")
            {
                txtMonDiferencia.Text = "0.00";
            }
            if (MyKey != null)
                MyKey(sender, e);
        }
        private void calcular()
        {
            if (!string.IsNullOrEmpty(txtMonEfectivo.Text.Trim()))
            {
                txtMonEfectivo.Text = string.Format("{0:#,#0.00}", txtMonEfectivo.nDecValor);
                if (txtMonEfectivo.nDecValor<nMontoTotalpago)
                {
                    MessageBox.Show("El Monto recibido es menor al Monto de la Operación","Validación de la transacción",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    this.txtMonDiferencia.Text = "0.00";
                    this.txtMonEfectivo.SelectAll();
                    lCorrecto = false;
                    return;
                }
                //string.Format("{0:#,#0.00}", nMonto);
                txtMonDiferencia.Text = (txtMonEfectivo.nDecValor - nMontoTotalpago).ToString();
                txtMonDiferencia.Text = string.Format("{0:#,#0.00}", txtMonDiferencia.nDecValor);
                lCorrecto = true;
            }
            else
            {

            }
        }

        public void CalculoDirecto(decimal nMontoEntregar)
        {
            if (!string.IsNullOrEmpty(txtMonEfectivo.Text.Trim()))
            {
                txtMonEfectivo.Text = string.Format("{0:#,#0.00}", nMontoEntregar);
                if (txtMonEfectivo.nDecValor < nMontoTotalpago)
                {
                    MessageBox.Show("El Monto recibido es menor al Monto de la Operación", "Validación de la transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtMonEfectivo.SelectAll();
                    return;
                }
                //string.Format("{0:#,#0.00}", nMonto);
                txtMonDiferencia.Text = (txtMonEfectivo.nDecValor - nMontoTotalpago).ToString();
                txtMonDiferencia.Text = string.Format("{0:#,#0.00}", txtMonDiferencia.nDecValor);

            }
            else
            {

            }
        }

        private void txtMonEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                calcular();
                if (MyKey != null)
                    MyKey(sender, e);
            }
        }

        private void txtMonEfectivo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonEfectivo.Text) || txtMonEfectivo.Text == "0")
            {
                txtMonDiferencia.Text = "0.00";
            }
            else
            {
                if (txtMonEfectivo.nvalor > 0)
                {
                    calcular();
                    if (MyKey != null)
                        MyKey(sender, e);
                }
            }
        }
        public void limpiar()
        {
            txtMonDiferencia.Text="0.00";
            txtMonEfectivo.Text = "0.00";
        }
    }
}
