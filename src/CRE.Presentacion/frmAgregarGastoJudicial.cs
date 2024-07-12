using ADM.CapaNegocio;
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

namespace CRE.Presentacion
{
    public partial class frmAgregarGastoJudicial : frmBase
    {
        clsCNConfigGastComiSeg ConfigGastComiSeg = new clsCNConfigGastComiSeg();
        public bool lAceptar = false;
        public frmAgregarGastoJudicial()
        {
            InitializeComponent();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAgregarGastoJudicial_Load(object sender, EventArgs e)
        {

            cboTipoGasto1.DataSource = ConfigGastComiSeg.CargarConcepto(1);
            cboTipoGasto1.DisplayMember = "cConcepto";
            cboTipoGasto1.ValueMember = "idConcepto";
            cboTipoGasto1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMoneda1.SelectedIndex = 0;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                lAceptar = true;
                this.Hide();
            }
        }

        private bool validar()
        {
            if (String.IsNullOrEmpty(txtMonto.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el monto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                return false;
            }

            if (!(Convert.ToDecimal(txtMonto.Text.Trim()) > 0 && Convert.ToDecimal(txtMonto.Text.Trim()) < 999999))
            {
                MessageBox.Show("El monto debe ser mayor a 0.00 y menor de 999,999.00", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonto.Focus();
                return false;
            }

            return true;
        }
    }
}
