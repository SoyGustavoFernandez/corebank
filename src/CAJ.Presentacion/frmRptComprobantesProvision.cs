using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CAJ.CapaNegocio;
namespace CAJ.Presentacion
{
    public partial class frmRptComprobantesProvision : frmBase
    {
        clsCNCajaChica rptComprobante = new clsCNCajaChica();
        public frmRptComprobantesProvision()
        {
            InitializeComponent();
            dtpFechaIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            cboTipoComprobantePago1.llenarDatosComprobante(1);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            string dFecIni = this.dtpFechaIni.Value.ToShortDateString();
            string dFecFin = this.dtpFechaFin.Value.ToShortDateString();
            int  ntipCompr =Convert.ToInt32(cboTipoComprobantePago1.SelectedValue.ToString());
            int idAgencia =Convert.ToInt32(cboAgencia1.SelectedValue.ToString());
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("ntipCompr", ntipCompr.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dfechaIni",dFecIni, false));
            paramlist.Add(new ReportParameter("dfechaFin", dFecFin, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));
            
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRptComprobante", new clsCNCajaChica().ReporteComprobantesProvision(ntipCompr, idAgencia, dtpFechaIni.Value, dtpFechaFin.Value)));

            string reportpath = "rptComproProvision.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
    }
}
