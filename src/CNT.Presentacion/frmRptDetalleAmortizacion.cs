using CNT.CapaNegocio;
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

namespace CNT.Presentacion
{
    public partial class frmRptDetalleAmortizacion : frmBase
    {
        public frmRptDetalleAmortizacion()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsAmortiza", new clsCNAmortizacion().CNReporteAmortizacion()));

            string reportpath = "RptDetalleAmortiz.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
