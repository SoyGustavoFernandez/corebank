using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptResponsableCaja : frmBase
    {
        public frmRptResponsableCaja()
        {
            InitializeComponent();
        }
        private void frmRptResponsableCaja_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }      

    
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFechaIni = this.dtpFecIni.Value;
            DateTime dFechaFin = this.dtpFecFin.Value;
          
            int idAge = Convert.ToInt32(cboAgencia1.SelectedValue);
            string cEstCie="";           
           
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreAge", cboAgencia1.Text, false));
            paramlist.Add(new ReportParameter("dFechaSis",clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFecInicio", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFinal", dFechaFin.ToString(), false));  
                                    
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsResponsableCaja", new clsRPTCNCaja().CNRptListaResponsableCaja(idAge, dFechaIni, dFechaFin,clsVarGlobal.dFecSystem)));
            string reportpath = "RptResponsableCaja.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

      
    }
}
