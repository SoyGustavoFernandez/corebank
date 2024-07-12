using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
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
    public partial class frmReporteCastigos : frmBase
    {

        clsCNCredito clsCNCredito = new clsCNCredito();

        public frmReporteCastigos()
        {
            InitializeComponent();
        }

        private void frmReporteCastigos_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            DataTable dtCreditosCastigados = clsCNCredito.obtenerListaCastigos();

            if (dtCreditosCastigados.Rows.Count > 0)
            {
                dtslist.Add(new ReportDataSource("dsCreditosCastigados", dtCreditosCastigados));
                string reportpath = "rptCreditosCastigados.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
