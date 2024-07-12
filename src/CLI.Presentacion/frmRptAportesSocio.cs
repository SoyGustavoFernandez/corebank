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
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CLI.CapaNegocio;
using RPT.CapaNegocio;

namespace CLI.Presentacion
{
    public partial class frmRptAportesSocio : frmBase
    {
        public frmRptAportesSocio()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {            
            DateTime dFechaFin=dtpFechaFin.Value ;
            int idAgencia =Convert.ToInt32(cboAgencia.SelectedValue);
            string cAgencia = cboAgencia.Text;
            string cAgenOpe=clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "cRutaLogo", false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsNroAportesXSocio", new clsCNSocio().retornarAportesSocio(dFechaFin, idAgencia)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptAportesSocios.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }


        private void btnImprFondo_Click(object sender, EventArgs e)
        {
            DateTime dFechaFin = dtpFechaFin.Value;
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            string cAgencia = cboAgencia.Text;
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAgencia", cAgencia, false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "cRutaLogo", false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsFondoSegXSocio", new clsCNSocio().retornaFondoSeguroSocio(dFechaFin, idAgencia)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptAportesFondoSegSocios.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }
    }
}
