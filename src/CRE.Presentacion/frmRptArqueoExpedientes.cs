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
using Microsoft.Reporting.WinForms;
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptArqueoExpedientes : frmBase
    {
        public frmRptArqueoExpedientes()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboAgencia1.SelectedValue) < 0)
            {
                MessageBox.Show("Debe seleccionar una Agencia", "Valida Reporte de Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> listPar = new List<ReportParameter>();

            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            listPar.Add(new ReportParameter("idAgencia", clsVarGlobal.cNomAge, false));

            string reportpath = "";

            dtslist.Add(new ReportDataSource("dtsArqueoExpediente", new clsCNControlExp().CNArqueoExpediente(Convert.ToInt32(cboAgencia1.SelectedValue))));
            reportpath = "rptArqueoExpediente.rdlc";

            new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();
        }
    }
}
