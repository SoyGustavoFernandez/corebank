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

namespace CRE.Presentacion
{
    public partial class frmRptInformeRiesgos : frmBase
    {
        public frmRptInformeRiesgos()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime pdFechaIni = dtpFechaIni.Value;
            DateTime pdFechaFin = dtpFechaFin.Value;
            DataTable dtInformeRiesgo = new clsRPTCNCredito().CNInformeRiesgos(pdFechaIni ,pdFechaFin);
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dsInformeRiesgos", dtInformeRiesgo));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));            
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecInicio", pdFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSistema",dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("dFecFinal", pdFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "", false));
            string reportpath = "rptInformeRiesgos.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
