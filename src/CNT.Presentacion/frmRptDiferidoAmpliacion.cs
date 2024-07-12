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
    public partial class frmRptDiferidoAmpliacion : frmBase
    {
        List<ReportParameter> paramlist = new List<ReportParameter>();

        public frmRptDiferidoAmpliacion()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value;
            parametros(dFecha);
            string reportpath = "";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsDifxAmp", new clsCNBalance().DiferidoxAmpliacion(dFecha)));
            reportpath = "RptDiferidoxAmpliacion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        void parametros(DateTime dFec)
        {
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dFec.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
        }
    }
}
