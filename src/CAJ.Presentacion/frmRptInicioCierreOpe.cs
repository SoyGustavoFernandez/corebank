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
    public partial class frmRptInicioCierreOpe : frmBase
    {
        public frmRptInicioCierreOpe()
        {
            InitializeComponent();
        }
        private void frmRptInicioCierreOpe_Load(object sender, EventArgs e)
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
            if (rbtTodos.Checked)
            {
                cEstCie = "0";
            }
            else
            {
                if (rbtAbierto.Checked)
                {
                    cEstCie = "A";
                }
                if (rbtCerrado.Checked)
                {
                    cEstCie = "C";
                }
            }

           
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNomAgen", cboAgencia1.Text, false));
            paramlist.Add(new ReportParameter("dFechaSis",clsVarGlobal.dFecSystem.ToShortDateString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("dFecIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("IdAgencia", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFechaFin.ToString(), false));          
         
            paramlist.Add(new ReportParameter("cEstCie", cEstCie, false));
                                    
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsListIni", new clsRPTCNCaja().CNRptListaIniCierreOpe(idAge, dFechaIni, dFechaFin, cEstCie)));
            string reportpath = "rptRepIniCierreOpe.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

      
    }
}
