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
using CAJ.CapaNegocio;
using RPT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptCreditosAdeudado : frmBase
    {
        public frmRptCreditosAdeudado()
        {
            InitializeComponent();
            dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaFin=dtpFechaFin.Value ;
            string cAgenOpe=clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));

            paramlist.Add(new ReportParameter("dFechaOpe", dFechaFin.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
            
            paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
            paramlist.Add(new ReportParameter("cNombreVariable", "cRutaLogo", false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            dtslist.Add(new ReportDataSource("DSCreditoXAdeudado", new clsCNControlOpe().CNResCreditosPorAdeudado(dFechaFin)));
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            string reportpath = "rptAdeudadoCredito.rdlc";
            new frmReporteLocal(dtslist, reportpath,paramlist).ShowDialog();
            this.btnImprimir.Enabled = true;
        }

        private void frmRptCreditosAdeudado_Load(object sender, EventArgs e)
        {

        }
    }
}
