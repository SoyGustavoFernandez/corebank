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

namespace CRE.Presentacion
{
    public partial class frmReporteBN : frmBase
    {
        clsRPTCNCredito cnrptcredito = new clsRPTCNCredito();
        public frmReporteBN()
        {
            InitializeComponent();
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnDesembolso_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaProceso.Value;
            DataTable dtDesembolso = cnrptcredito.CNBNDesembolso(dFecha);

            if (dtDesembolso.Rows.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dtsDesembolsoBN", dtDesembolso));

                paramList.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                string reportPath = "rptDesembolsoBN.rdlc";

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Desembolsos BN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnCobranza_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaProceso.Value;
            DataTable dtCobranza = cnrptcredito.CNBNCobranza(dFecha);

            if (dtCobranza.Rows.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dtsCobranzaBN", dtCobranza));

                paramList.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                string reportPath = "rptCobranzaBN.rdlc";

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Cobranza BN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
