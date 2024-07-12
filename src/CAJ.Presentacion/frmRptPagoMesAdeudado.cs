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
using GEN.CapaNegocio;
using EntityLayer;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptPagoMesAdeudado : frmBase
    {
        public frmRptPagoMesAdeudado()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaInicio = Convert.ToDateTime(this.dtpInicio.Value.ToShortDateString());
            DateTime dFechaFinal = Convert.ToDateTime(this.dtpFinal.Value.ToShortDateString());

            paramlist.Add(new ReportParameter("dfechaIni", dFechaInicio.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dfechaFin", dFechaFinal.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgencia", clsVarGlobal.cNomAge.ToString(), false));
            paramlist.Add(new ReportParameter("cNombreVariable", "Logo", false));
           
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dsPagosMesAdeudado", new clsRPTCNCaja().CNRepMensualAdeudado(dFechaInicio,dFechaFinal)));
            string reportpath = "RptPagMesAdeudado.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void sstBase_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmRptPagoMesAdeudado_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = clsVarGlobal.dFecSystem;
            dtpFinal.Value = clsVarGlobal.dFecSystem;
        }
    }
}
