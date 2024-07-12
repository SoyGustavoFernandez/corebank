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
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmSaldoProvision : frmBase
    {
        string reportpath = "RptProvisionCreditoResumen.rdlc";
        public frmSaldoProvision()
        {
            InitializeComponent();
        }

        private void frmSaldoCredito_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value.Date;
            int idAgencia = Convert.ToInt16(cboAgencia1.SelectedValue);

            DataTable dtSaldo = new clsRPTCNCredito().CNRptSaldoProvisiones(dFecha, idAgencia);
            if (dtSaldo.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Saldos Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString(), false));
                paramlist.Add(new ReportParameter("x_RutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsSaldo", dtSaldo));
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
