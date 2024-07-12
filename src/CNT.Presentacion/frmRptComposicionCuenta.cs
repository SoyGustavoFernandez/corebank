using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmRptComposicionCuenta : frmBase
    {
        public frmRptComposicionCuenta()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni= dtpFecha.Value.Date;
         
            if (clsVarGlobal.dFecSystem < dFechaIni)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida composición de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            //int nCuenta = Convert.ToInt32(txtCuenta.Text);
            //int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cAgencia", clsVarGlobal.cNomAge , false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("dFecha", dFechaIni.ToString(), false));
  

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsComposicionDifCuenta", new clsRPTCNContabilidad().CNRptCoposicionCuentaDiferido(dFechaIni)));

            string reportpath = "rptComposicionDifCuenta.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptResumenSaldoProvCNT_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }
    }
}
