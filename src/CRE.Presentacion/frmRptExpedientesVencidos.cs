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
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptExpedientesVencidos : frmBase
    {
        clsCNControlExp cnControlExp = new clsCNControlExp();
        public frmRptExpedientesVencidos()
        {
            InitializeComponent();
            txtMaxDiasExpedientes.Text = Convert.ToString(clsVarApl.dicVarGen["nNroDiasMaxPrestamoExpediente"]);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una agencias", "Expedientes Vencidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idAgencia   = Convert.ToInt32(cboAgencia.SelectedValue);
            DateTime dFeSis = clsVarGlobal.dFecSystem;
            DataTable dtRpt = cnControlExp.CNRptExpedientesVencidosDevolucion(idAgencia, dFeSis);
            if(dtRpt.Rows.Count == 0)
            {
                MessageBox.Show("No hay Elementos para este reporte", "Expedientes Vencidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string reportpath = "rptExpedientesVencidosParaDevolucion.rdlc";


            string cNomEmp      = clsVarApl.dicVarGen["cNomEmpresa"];
            String AgenEmision  = clsVarApl.dicVarGen["cNomAge"];

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaSistema", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));
            paramlist.Add(new ReportParameter("cNomAgen", AgenEmision, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));

            dtslist.Add(new ReportDataSource("dsRptExpedientes", dtRpt));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        
    }
}
