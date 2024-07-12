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
using GEN.CapaNegocio;


namespace GRH.Presentacion
{
    public partial class frmCertificadoPersonalContrato : frmBase
    {
        public frmCertificadoPersonalContrato()
        {
            InitializeComponent();
        }

      
        private void btnImprFondo_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni=clsVarGlobal.dFecSystem;//= dtpFechaIni.Value;
            DateTime dFechaFin = clsVarGlobal.dFecSystem;//= dtpFechaFin.Value ;
         
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsCertificado", new clsCNBuscaPersonal().ListarCertificados(Convert.ToInt32(conBusCol1.idUsu), dFechaIni, dFechaFin)));

            string reportpath = "rptContratoCertificadoPer.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
          
        }
    }
}
