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
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmRptSaldoDeposito : frmBase
    {
        string ReportPatch = "rptSaldoDeposito1.rdlc";
        clsRPTCNSaldoDeposito CNSaldoDep = new clsRPTCNSaldoDeposito();
        public frmRptSaldoDeposito()
        {
            InitializeComponent();
        }

        private void frmRptSaldoDeposito_Load(object sender, EventArgs e)
        {

        }
        private void btnImprimir1_Click_1(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value.Date;

            DataTable dtSaldoDeposito = CNSaldoDep.CNSaldoDeposito(dFecha);
            if (dtSaldoDeposito.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Saldos Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));
                paramlist.Add(new ReportParameter("x_RutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsSaldoDeposito", dtSaldoDeposito));
                new frmReporteLocal(dtslist, ReportPatch, paramlist).ShowDialog();
            }
        }
    }
}
