using CNE.CapaNegocio;
using EntityLayer;
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

namespace CNE.Presentacion
{
    public partial class frmPDPIngresoValorPatriFide : frmBase
    {
        clsCNPdp cnRptPdp = new clsCNPdp();
        int idPDPAnexo32ADet;

        public frmPDPIngresoValorPatriFide()
        {
            InitializeComponent();
            InicializarVariables();
        }

        public void InicializarVariables()
        {
            this.idPDPAnexo32ADet = 0;
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void ActivarEventos(bool lActivo)
        {
            if (lActivo)
            {                
                this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
                this.txtSaldoFide.TextChanged += new System.EventHandler(this.txtSaldoFide_TextChanged);
                this.txtValorDDI.TextChanged += new System.EventHandler(this.txtValorDDI_TextChanged);
            }
            else
            {
                this.dtpFecha.ValueChanged -= new System.EventHandler(this.dtpFecha_ValueChanged);
                this.txtSaldoFide.TextChanged -= new System.EventHandler(this.txtSaldoFide_TextChanged);
                this.txtValorDDI.TextChanged -= new System.EventHandler(this.txtValorDDI_TextChanged);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {                      
            if (this.idPDPAnexo32ADet == 0)
            {
                MessageBox.Show("No se tiene registro Fideicometido para esta fecha", "Ingreso de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.txtSaldoFide.Text.Trim()))
            {
                MessageBox.Show("Ingrese un valor de patrimonio valido", "Ingreso de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.txtValorDDI.Text.Trim()))
            {
                MessageBox.Show("Ingrese un Valor deposito disposición inmediata valido", "Ingreso de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.txtValorGarantia.Text.Trim()))
            {
                MessageBox.Show("Ingrese un Total de valor de la garantía valido", "Ingreso de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal nSaldoFide = Convert.ToDecimal(this.txtSaldoFide.Text);
            decimal nValorDepDispInm = Convert.ToDecimal(this.txtValorDDI.Text);
            decimal nToValGar = Convert.ToDecimal(this.txtValorGarantia.Text);

            cnRptPdp.IngresarValorPatriFideicometido(this.idPDPAnexo32ADet, nSaldoFide, nValorDepDispInm, nToValGar);

            MessageBox.Show("Se ingreso correctamente el Valor de Patrimonio Fidecometido S/ " + nSaldoFide + " , Valor deposito disposición inmediata S/ " + nValorDepDispInm + " y Total de valor de la garantía " + nToValGar + " al " + this.dtpFecha.Value.Date.ToString("yyyy-MM-dd") + ".", "Ingreso de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value;

            DataTable dtSaldos = cnRptPdp.ObtenerValorPatriFideicometido(dFecha);
            this.ActivarEventos(false);

            if (dtSaldos.Rows.Count != 0)
            {
                this.idPDPAnexo32ADet = Convert.ToInt32(dtSaldos.Rows[0]["idPDPAnexo32ADet"]);

                this.txtSaldoFide.Text = Convert.ToString(dtSaldos.Rows[0]["nValorPatriFide"]);
                this.txtSaldoFide.Enabled = true;

                this.txtValorDDI.Text = Convert.ToString(dtSaldos.Rows[0]["nValorDepDispInm"]);
                this.txtValorDDI.Enabled = true;

                this.txtValorGarantia.Text = Convert.ToString(dtSaldos.Rows[0]["nToValGar"]);
                this.txtValorGarantia.Enabled = true;
            }
            else
            {
                this.idPDPAnexo32ADet = 0;
                this.txtSaldoFide.Text = "";
                this.txtSaldoFide.Enabled = false;
                this.txtValorDDI.Text = "";
                this.txtValorDDI.Enabled = false;
                this.txtValorGarantia.Text = "";
                this.txtValorGarantia.Enabled = false;
            }

            this.ActivarEventos(true);
        }

        private void txtSaldoFide_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSaldoFide.Text.Trim() == string.Empty || this.txtValorDDI.Text.Trim() == string.Empty)
            {
                return;
            }

            decimal nValorGarantia = 0;
            decimal nSaldoFide = Convert.ToDecimal(this.txtSaldoFide.Text);
            decimal nValorDDI = Convert.ToDecimal(this.txtValorDDI.Text);

            nValorGarantia = nSaldoFide + nValorDDI;
            this.txtValorGarantia.Text = Convert.ToString(nValorGarantia);
        }

        private void txtValorDDI_TextChanged(object sender, EventArgs e)
        {
            if (this.txtValorDDI.Text.Trim() == string.Empty || this.txtSaldoFide.Text.Trim() == string.Empty)
            {
                return;
            }

            decimal nValorGarantia = 0;
            decimal nSaldoFide = Convert.ToDecimal(this.txtSaldoFide.Text);
            decimal nValorDDI = Convert.ToDecimal(this.txtValorDDI.Text);

            nValorGarantia = nSaldoFide + nValorDDI;
            this.txtValorGarantia.Text = Convert.ToString(nValorGarantia);
        }
    }
}
