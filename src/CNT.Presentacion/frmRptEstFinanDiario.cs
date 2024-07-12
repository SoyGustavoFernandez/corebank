using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace CNT.Presentacion
{
    public partial class frmRptEstFinanDiario : frmBase
    {
        public frmRptEstFinanDiario()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida estado financiero diario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
        

            
            paramlist.Add(new ReportParameter("x_dfecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("x_cCodSBS", "0202", false));
            paramlist.Add(new ReportParameter("x_cAnexo", "50", false));


            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsEEFFDiario", new clsRPTCNContabilidad().CNRptEEFF_Diario(dFecha)));
           
            DataSet dsReporte2D = new clsRPTCNCredito().CNReporte2D(dFecha, "0202", "50");
            DataTable dtReporte2D = dsReporte2D.Tables[0];
            dtslist.Add(new ReportDataSource("dtsReporte2D", dtReporte2D));
            string reportpath="";
            if (rbtAnual.Checked)
            {
                reportpath = "RptEEFFDiarioAnual.rdlc";
            }
            if (rbtTrimestral.Checked)
            {
                reportpath = "RptEEFFDiarioTrimestre.rdlc";
            }
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
