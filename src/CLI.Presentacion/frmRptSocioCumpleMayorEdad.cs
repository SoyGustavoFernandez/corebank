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
    public partial class frmRptSocioCumpleMayorEdad : frmBase
    {
        public frmRptSocioCumpleMayorEdad()
        {
            InitializeComponent();
        }

      
        private void btnImprFondo_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value ;
         
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dtsSocioMayorEdad", new clsCNSocio().retornaSociosCumplenMayoriaEdad(dFechaIni, dFechaFin)));

            string reportpath = "rptSocioCumplMayorEdad.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
          
        }
    }
}
