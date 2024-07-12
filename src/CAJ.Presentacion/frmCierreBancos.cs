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
using EntityLayer;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmCierreBancos : frmBase
    {
        DateTime dFecCieBcos;
        public frmCierreBancos()
        {
            InitializeComponent();
        }

        private void frmCierreBancos_Load(object sender, EventArgs e)
        {
            //dtpFecCierre.Value = clsVarGlobal.dFecSystem.Date;
            DataTable dtFec = new clsCNMovimientoBanco().RetornarFecUltCierreBco();
            dFecCieBcos = Convert.ToDateTime(dtFec.Rows[0]["dFecMin"]);
            dtpFecCierre.Value = dFecCieBcos.Date;
            cboPeriodProc.SelectedIndexChanged -= new EventHandler(cboPeriodProc_SelectedIndexChanged);
            ListarPeriodoProcesados();
            LlenarGridView(dFecCieBcos.Date);
            chcPeriodoActual.Checked = true;
            dtpFecCierre.Enabled = false;
            cboPeriodProc.SelectedIndexChanged += new EventHandler(cboPeriodProc_SelectedIndexChanged);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpFecCierre.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha de cierre no puede ser mayor a la fecha del Sistema.", "Cierre de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable result = new clsCNMovimientoBanco().CierreBancos(dtpFecCierre.Value.Date);

            if (result.Rows[0]["idMsje"].ToString() == "0")
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Cierre de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFecCierre.Value = dtpFecCierre.Value.AddDays(1).AddMonths(1).AddDays(-1);
                cboPeriodProc.SelectedIndexChanged -= new EventHandler(cboPeriodProc_SelectedIndexChanged);
                ListarPeriodoProcesados();
                cboPeriodProc.SelectedIndexChanged += new EventHandler(cboPeriodProc_SelectedIndexChanged);
                chcPeriodoActual.Checked = false;
                btnGenerar.Enabled = false;
            }
            else
            {
                MessageBox.Show(result.Rows[0]["cMsje"].ToString(), "Cierre de Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FormatoDataGridView()
        {
            dtgDatCierreBcos.Columns["dFecCierre"].Visible = false;
            dtgDatCierreBcos.Columns["idCuentaInstitucion"].Visible = true;
            dtgDatCierreBcos.Columns["idEntidad"].Visible = false;
            dtgDatCierreBcos.Columns["idTipoCuentaInst"].Visible = false;
            dtgDatCierreBcos.Columns["cNumeroCuenta"].Visible = true;
            dtgDatCierreBcos.Columns["idMoneda"].Visible = false;
            dtgDatCierreBcos.Columns["CodigoISO"].Visible = true;
            dtgDatCierreBcos.Columns["cNombreCorto"].Visible = true;
            dtgDatCierreBcos.Columns["nTEA"].Visible = false;
            dtgDatCierreBcos.Columns["nFactorInteres"].Visible = false;
            dtgDatCierreBcos.Columns["nPlazo"].Visible = false;
            dtgDatCierreBcos.Columns["nSaldoDisponible"].Visible = true;
            dtgDatCierreBcos.Columns["nSaldoContable"].Visible = true;

            dtgDatCierreBcos.Columns["idCuentaInstitucion"].HeaderText = "Cod.";
            dtgDatCierreBcos.Columns["cNumeroCuenta"].HeaderText = "Cuenta Bancaria";
            dtgDatCierreBcos.Columns["CodigoISO"].HeaderText = "Moneda";
            dtgDatCierreBcos.Columns["cNombreCorto"].HeaderText = "Instituacion Financiera";
            dtgDatCierreBcos.Columns["nSaldoDisponible"].HeaderText = "Saldo Disponible";
            dtgDatCierreBcos.Columns["nSaldoContable"].HeaderText = "Saldo Contable";

            dtgDatCierreBcos.Columns["idCuentaInstitucion"].DisplayIndex = 0;
            dtgDatCierreBcos.Columns["CodigoISO"].DisplayIndex = 1;
            dtgDatCierreBcos.Columns["cNumeroCuenta"].DisplayIndex = 2;
            dtgDatCierreBcos.Columns["cNombreCorto"].DisplayIndex = 3;
            dtgDatCierreBcos.Columns["nSaldoDisponible"].DisplayIndex = 4;
            dtgDatCierreBcos.Columns["nSaldoContable"].DisplayIndex = 5;

            dtgDatCierreBcos.Columns["idCuentaInstitucion"].FillWeight = 30;
            dtgDatCierreBcos.Columns["CodigoISO"].FillWeight = 40;
            dtgDatCierreBcos.Columns["cNumeroCuenta"].FillWeight = 100;
            dtgDatCierreBcos.Columns["cNombreCorto"].FillWeight = 100;
            dtgDatCierreBcos.Columns["nSaldoDisponible"].FillWeight = 50;
            dtgDatCierreBcos.Columns["nSaldoContable"].FillWeight = 50;
        }

        private void ListarPeriodoProcesados()
        {
            DataTable dtPeriodProc = new clsCNMovimientoBanco().ListarPeriodosProcCierreBcos();
            if (dtPeriodProc.Rows.Count == 0)
            {
                lblMsje.Text = "No se han procesado ningun cierre de Bancos.";
                lblMsje.Visible = true;
                return;
            }
            else
            {
                lblMsje.Text = "";
                lblMsje.Visible = false;
                cboPeriodProc.DataSource = dtPeriodProc;
                cboPeriodProc.ValueMember = "dFecCierre";
                cboPeriodProc.DisplayMember = "dFecCierreDisplay";
            }
        }

        private void chcPeriodoActual_CheckedChanged(object sender, EventArgs e)
        {
            if (chcPeriodoActual.Checked)
            {
                btnGenerar.Enabled = true;
                cboPeriodProc.SelectedIndex = -1;
                cboPeriodProc.Enabled = false;
                LlenarGridView(dtpFecCierre.Value.Date);
            }
            else
            {
                btnGenerar.Enabled = false;
                cboPeriodProc.SelectedIndex = -1;
                cboPeriodProc.Enabled = true;
            }
        }

        private void LlenarGridView(DateTime dFecCieBcos)
        {
            DataTable dtDatCierreBcos = new clsCNMovimientoBanco().RetornarDatosCierreBcos(dFecCieBcos);          
            dtgDatCierreBcos.DataSource = dtDatCierreBcos;
            FormatoDataGridView();
        }

        private void cboPeriodProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodProc.SelectedIndex == -1)
            {
                return;
            }
            LlenarGridView(Convert.ToDateTime(cboPeriodProc.SelectedValue));
        }
    }
}
