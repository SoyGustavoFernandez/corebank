using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmRptResumenSaldoProvCNT : frmBase
    {
        public frmRptResumenSaldoProvCNT()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha= dtpFecha.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida resumen provisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cAgencia", clsVarGlobal.cNomAge , false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("x_dFecha", dtpFecha.Value.ToString(), false));
            paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
  

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsSaldoProvCNT", new clsRPTCNContabilidad().CNRptResumenSaldoProvisionCNT(dFecha, idAgencia)));

            string reportpath = "rptResumenSaldoProvisionCNT.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptResumenSaldoProvCNT_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }
    }
}
