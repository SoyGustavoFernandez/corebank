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
    public partial class frmRptSaldosCajaChica : frmBase
    {
        public frmRptSaldosCajaChica()
        {
            InitializeComponent();
        }

        private void frmRptDetalleOpe_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

    
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            DateTime dFechaIni = this.dtpFecIni.Value;
            DateTime dFechaFin = this.dtpFecFin.Value;
          
            int idAge = Convert.ToInt32(cboAgencia1.SelectedValue);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("dsKardex", new clsRPTCNCaja().CNSaldosCajaChica(idAge, dFechaIni, dFechaFin)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("dFecIni", dFechaIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFechaFin.ToString(), false));
            paramlist.Add(new ReportParameter("idAge", idAge.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreAge", cboAgencia1.Text, false));
            paramlist.Add(new ReportParameter("cRutaLogo", "CRUTALOGO", false));

            string reportpath = "rptSaldosCajaChica.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
       
    }
}
