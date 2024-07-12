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
using DEP.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using Microsoft.Reporting.WinForms;

namespace DEP.Presentacion
{
    public partial class frmReporteCambioTasaDPF : frmBase
    {

        #region Variables Globales

        string cTituloMsjs = "Reporte de Cambio de Tasa DPF";
        
        #endregion


        #region Eventos


        public frmReporteCambioTasaDPF()
        {
            InitializeComponent();
            DateTime dFechaSystem = clsVarGlobal.dFecSystem;

            datePicker1.Value = dFechaSystem;
            datePicker2.Value = dFechaSystem;

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            clsCNDeposito cnReporteCambioTasa = new clsCNDeposito();
            
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string dFechaDesde = Convert.ToString(datePicker1.Value);
            string dFechaHasta = Convert.ToString(datePicker2.Value);
            string dFechaSis1 = Convert.ToString(dFechaSis.ToShortDateString());
            
            DataTable dtData2 = cnReporteCambioTasa.CNReporteCambioTasa(Convert.ToDateTime(datePicker1.Value), Convert.ToDateTime(datePicker2.Value));

            if (dtData2.Rows.Count > 0 && ValidaFechas())
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCambioTasa", dtData2));
                
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis1.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString(), false));

                string reportPath = "rptCambioTasaDPF.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este reporte ó la fecha desde es mayor que la fecha hasta.", cTituloMsjs, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se mostrará un reporte de los Productos vinculados para su renovación de tasa.",cTituloMsjs,MessageBoxButtons.OK,MessageBoxIcon.Information);
            clsCNDeposito cnReporteCambioTasa = new clsCNDeposito();

            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            string dFechaSis1 = Convert.ToString(dFechaSis.ToShortDateString());
            DataTable dtData2 = cnReporteCambioTasa.CNReporteAsignacionProd();

            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsAsignacionProd", dtData2));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", dFechaSis1.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));
                
                string reportPath = "rptAsignacionProductos.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este reporte.", cTituloMsjs, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        #endregion


        #region Métodos

        private bool ValidaFechas()
        {
            DateTime dFechaDesde = Convert.ToDateTime(datePicker1.Value);
            DateTime dFechaHasta = Convert.ToDateTime(datePicker2.Value);

            if (dFechaDesde > dFechaHasta)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        
        #endregion



    }
}
