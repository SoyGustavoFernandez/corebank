using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmReporteMoraPreventiva : frmBase
    {
        clsCNCredito cnCredito = new clsCNCredito();

        public frmReporteMoraPreventiva()
        {
            InitializeComponent();
        }

        private void frmReporteMoraPreventiva_Load(object sender, EventArgs e)
        {
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtCreditos = cnCredito.obtenerPreventivoMora(Convert.ToInt32(cboAgencia.SelectedValue));
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("dsCreditos", dtCreditos));

            string reportpath = "rptReportePreventivoMora.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
