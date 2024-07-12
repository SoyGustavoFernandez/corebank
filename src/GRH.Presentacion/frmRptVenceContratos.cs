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
using GEN.CapaNegocio;


namespace GRH.Presentacion
{
    public partial class frmRptVenceContratos : frmBase
    {
        public frmRptVenceContratos()
        {
            InitializeComponent();
        }

      
        private void btnImprFondo_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value ;
         
            string cAgenOpe = clsVarGlobal.cNomAge;
            DateTime dFechaSis = clsVarGlobal.dFecSystem;

            clsCNBuscaPersonal BuscaPer = new clsCNBuscaPersonal();
            DataTable dtListContratosVen = new DataTable();

            dtListContratosVen= BuscaPer.ListarVencimientoContratos(dFechaIni, dFechaFin);

            if (dtListContratosVen.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Reporte de Contratos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                
                paramlist.Add(new ReportParameter("dFechaSistema", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cAgenOpe", cAgenOpe, false));
                paramlist.Add(new ReportParameter("dFechaIni", dFechaIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dtsVenceContrato", dtListContratosVen));

                string reportpath = "rptContratoPerVence.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }          
        }
    }
}
