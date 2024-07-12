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
    public partial class frmRptInteresDevBancos : frmBase
    {
        public frmRptInteresDevBancos()
        {
            InitializeComponent();
        }

        private void frmRptDetalleOpe_Load(object sender, EventArgs e)
        {
            this.dtpFecProc.Value = clsVarGlobal.dFecSystem;
        }

    
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFecha = this.dtpFecProc.Value;
         
            int idAge = clsVarGlobal.nIdAgencia;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsKardex", new clsRPTCNCaja().CNInteresDevengadoBancos(dFecha)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecOpe", dFecha.ToString(), false));         
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false)); 
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));

            string reportpath = "rptIntDevBancos.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            this.btnImprimir.Enabled = true;
        }      
    }
}
