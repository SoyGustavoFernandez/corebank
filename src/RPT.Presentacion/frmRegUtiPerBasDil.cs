using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmRegUtiPerBasDil : frmBase
    {
        DateTime dFechaProceso;

        public frmRegUtiPerBasDil()
        {
            InitializeComponent();
        }

        public frmRegUtiPerBasDil(DateTime dFecha)
        {
            InitializeComponent();
            dFechaProceso = dFecha;
        }
        private void frmRegUtiPerBasDil_Load(object sender, EventArgs e)
        {
            Consulta(dFechaProceso);
        }
        private void Consulta(DateTime dFecha)
        { 
            DataTable dtUtiPerBas = new clsRPTCNReporte().CNConsultaUtiAccBas(dFecha);
            if (dtUtiPerBas.Rows.Count>0)
            {
                btnEditar1.Enabled = true;
                txtProPonAccBas.Text = Convert.ToString(dtUtiPerBas.Rows[0]["nAccionesBasicas"]);
                txtProPonAccDil.Text = Convert.ToString(dtUtiPerBas.Rows[0]["nAccionesDiluidas"]);
                txtUtiPerEje.Text = Convert.ToString(dtUtiPerBas.Rows[0]["nUtiPerEje"]);
                txtProPonAccBas.Enabled = false;
                txtProPonAccDil.Enabled = false;
                Calcula();
                return;
            }
            else
            {
                btnEditar1.Enabled = false;
                txtProPonAccBas.Enabled = true;
                txtProPonAccDil.Enabled = true;
            }

            DataTable dtSaldoCuenta = new clsRPTCNContabilidad().CNSaldoCtaCnt(dFecha, 0, txtCtaCtb.Text);
            if (dtSaldoCuenta.Rows.Count==0)
            {
                MessageBox.Show("No existen datos para la cuenta Utilidad(Pérdida) ingresada","Utilidad(Pérdida) Básica" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar1.Enabled = false;
                return;
            }
            else
            {
                txtUtiPerEje.Text = Convert.ToString(dtSaldoCuenta.Rows[0]["nValorFinal"]);
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            txtProPonAccBas.Enabled = true;
            txtProPonAccDil.Enabled = true;
            txtProPonAccBas.Focus();
        }

        private void txtProPonAccBas_Validated(object sender, EventArgs e)
        {
            Calcula();
        }
        private void txtProPonAccDil_Validated(object sender, EventArgs e)
        {
            Calcula();

        }
        private void txtUtiAccDil_Validated(object sender, EventArgs e)
        {
        }
        private void Calcula()
        {
            if (string.IsNullOrEmpty(txtProPonAccBas.Text) || txtProPonAccBas.Text == "0")
            {
                txtUtiAccBas.Text = "0";
            }
            else
            {
                txtUtiAccBas.Text = Convert.ToString(Convert.ToDecimal(txtUtiPerEje.Text) / Convert.ToDecimal(txtProPonAccBas.Text));
            }
            if (string.IsNullOrEmpty(txtProPonAccDil.Text) || txtProPonAccDil.Text == "0")
            {
                txtUtiAccDil.Text = "0";
            }
            else
            {
                txtUtiAccDil.Text = Convert.ToString(Convert.ToDecimal(txtUtiPerEje.Text) / Convert.ToDecimal(txtProPonAccDil.Text));
            }
        }

        private void txtCtaCtb_Validated(object sender, EventArgs e)
        {
            DataTable dtSaldoCuenta = new clsRPTCNContabilidad().CNSaldoCtaCnt(dFechaProceso, 0, txtCtaCtb.Text);
            if (dtSaldoCuenta.Rows.Count == 0)
            {
                txtUtiPerEje.Text = "0";
                MessageBox.Show("No existen datos para la cuenta Utilidad(Pérdida) ingresada", "Utilidad(Pérdida) Básica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGrabar1.Enabled = false;
                return;
            }
            else
            {
                txtUtiPerEje.Text = Convert.ToString(dtSaldoCuenta.Rows[0]["nValorFinal"]);
            }
            Calcula();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            btnGrabar1.Enabled = false;
            decimal nAccBas = Convert.ToDecimal(txtProPonAccBas.Text);
            decimal nAccDil = Convert.ToDecimal(txtProPonAccDil.Text);
            decimal nUtiPer = Convert.ToDecimal(txtUtiPerEje.Text);
            DataTable dtResultado = new clsRPTCNReporte().CNInsActUtiBasDil(dFechaProceso, nAccBas, nAccDil,
                                                                           nUtiPer, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (Convert.ToInt16(dtResultado.Rows[0]["idResultado"])==0)
            {
                MessageBox.Show("Error en la grabación", "Utilidad(Pérdida) Básica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Datos actualizados correctamente", "Utilidad(Pérdida) Básica", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
