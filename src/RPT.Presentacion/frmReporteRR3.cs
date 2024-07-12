using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReporteRR3 : frmBase
    {
        public frmReporteRR3()
        {
            InitializeComponent();

            DateTime dFecha = clsVarGlobal.dFecSystem;
            DateTime dPrimerDiaDelMes = new DateTime(dFecha.Year, dFecha.Month, 1);
            DateTime dUltimoDiaDelMes = dPrimerDiaDelMes.AddDays(-1);

            dtpFecha.MaxDate = dUltimoDiaDelMes;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {    
            DateTime dFecha = this.dtpFecha.Value.Date;
            DateTime dPrimerDiaDelMes = new DateTime(dFecha.Year, dFecha.Month, 1);
            DateTime dUltimoDiaDelMes = dPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            DataSet dsReporteRR3 = new clsRPTCNReporte().CNReporteRR3(dPrimerDiaDelMes, dUltimoDiaDelMes);
            DataTable dtReporteRR3 = dsReporteRR3.Tables[0];

            if (dtReporteRR3.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsReporteRR3", dtReporteRR3));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFecIni", dPrimerDiaDelMes.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dUltimoDiaDelMes.ToString("dd/MM/yyyy"), false));
                
                string reportpath = "rptReportRR3.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
             }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte RR3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
            }
        }

        private void btnImprimirCajCorresp_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DateTime dPrimerDiaDelMes = new DateTime(dFecha.Year, dFecha.Month, 1);
            DateTime dUltimoDiaDelMes = dPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            DataSet dsReporteRR3 = new clsRPTCNReporte().CNReporteRR3CajCorresp(dPrimerDiaDelMes, dUltimoDiaDelMes);
            DataTable dtReporteRR3 = dsReporteRR3.Tables[0];

            if (dtReporteRR3.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsReporteRR3", dtReporteRR3));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFecIni", dPrimerDiaDelMes.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dUltimoDiaDelMes.ToString("dd/MM/yyyy"), false));

                string reportpath = "rptReportRR3.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte RR3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
            }
        }

        private void btnImprimirBIM_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DateTime dPrimerDiaDelMes = new DateTime(dFecha.Year, dFecha.Month, 1);
            DateTime dUltimoDiaDelMes = dPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            DataSet dsReporteRR3 = new clsRPTCNReporte().CNReporteRR3BIM(dPrimerDiaDelMes, dUltimoDiaDelMes);
            DataTable dtReporteRR3 = dsReporteRR3.Tables[0];

            if (dtReporteRR3.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsReporteRR3", dtReporteRR3));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFecIni", dPrimerDiaDelMes.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dUltimoDiaDelMes.ToString("dd/MM/yyyy"), false));

                string reportpath = "rptReportRR3.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte RR3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
            }
        }

        private void btnImprimirPagoWeb_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DateTime dPrimerDiaDelMes = new DateTime(dFecha.Year, dFecha.Month, 1);
            DateTime dUltimoDiaDelMes = dPrimerDiaDelMes.AddMonths(1).AddDays(-1);

            DataSet dsReporteRR3 = new clsRPTCNReporte().CNReporteRR3PagoWEB(dPrimerDiaDelMes, dUltimoDiaDelMes);
            DataTable dtReporteRR3 = dsReporteRR3.Tables[0];

            if (dtReporteRR3.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                dtslist.Add(new ReportDataSource("dsReporteRR3", dtReporteRR3));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFecIni", dPrimerDiaDelMes.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecFin", dUltimoDiaDelMes.ToString("dd/MM/yyyy"), false));

                string reportpath = "rptReportRR3.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte RR3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir.Enabled = false;
            }
        }
    }
}
