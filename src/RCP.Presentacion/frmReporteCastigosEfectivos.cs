using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmReporteCastigosEfectivos : frmBase
    {
        clsCNReportes cnReportes = new clsCNReportes();
        public frmReporteCastigosEfectivos()
        {
            InitializeComponent();
            cboPeriodo1.cargarPeriodoSinTodos();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtCreditos = cnReportes.listarCreditosEfectivamenteCastigados(Convert.ToString(cboPeriodo1.SelectedValue));
            string cPeriodo = cboPeriodo1.SelectedValue.ToString(); 
            string cMes = cPeriodo.Substring(0, 2);
            string cAnio = cPeriodo.Substring(2, 4);

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Add(new ReportDataSource("dsCreditos", dtCreditos));

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramList.Add(new ReportParameter("cTitulo", "REPORTE CASTIGOS EFECTIVOS PERIODO " + cMes + " - " + cAnio , false));
            
            string reportPath = "rptReporteFinalCastigos.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
    }
}
