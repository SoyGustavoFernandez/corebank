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
using GEN.CapaNegocio;
using GEN.Funciones;
using GEN.BotonesBase;
using EntityLayer;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;
using CNE.CapaNegocio;


namespace CNE.Presentacion
{
    public partial class frmPDPRptSaldosBilletera : frmBase
    {

        #region Variables Globales
        clsCNPdp cnRptPdp = new clsCNPdp();
        DateTime dFecSystem = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Reporte de Saldos por Billetera";        
        #endregion

        #region Eventos
        public frmPDPRptSaldosBilletera()
        {
            InitializeComponent();
            this.dtpFecInicial.Value = dFecSystem.Date;
            this.dtpFecFinal.Value = dFecSystem.Date;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Reporte();
        }
        #endregion

        #region Metodos
        private void Reporte()
        {
            if (this.dtpFecInicial.Value.Date > this.dtpFecFinal.Value.Date)
            {
                MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            DataTable dtData = cnRptPdp.cnIncreSaldos(this.dtpFecInicial.Value.Date, this.dtpFecFinal.Value.Date);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsIncreSaldos", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                
                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpFecInicial.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpFecFinal.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaSis", this.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteSaldosBilletera.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
