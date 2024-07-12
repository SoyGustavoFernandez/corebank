using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace RCP.Presentacion
{
    public partial class frmRptCredCondonacionRefinanciar : frmBase
    {
        clsCNCondonacion CNCondonacion = new clsCNCondonacion();
        public frmRptCredCondonacionRefinanciar()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            DataTable dtResp = CNCondonacion.CNCredPendientesRefinanciar(cboAgencia1.SelectedIndex);
            //GEN.Funciones.clsNumLetras numLetras = new GEN.Funciones.clsNumLetras();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsCondonaciones", dtResp));
            string reportpath = "rptCredPendientesRefinanciar.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
