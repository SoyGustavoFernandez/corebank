using CNE.CapaNegocio;
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

namespace CNE.Presentacion
{
    public partial class frmPDPRptComisiones : frmBase
    {
        #region Variables Globales
        clsCNPdp cnRptPdp = new clsCNPdp();
        DateTime dFechaSystem = clsVarGlobal.dFecSystem;        
        string cTituloMsjes = "Reporte de Comisiones";
        #endregion

        #region Eventos
        public frmPDPRptComisiones()
        {
            InitializeComponent();            
            this.dtpFechaInicial.Value = this.dFechaSystem.Date;
            this.dtpFechaFinal.Value = this.dFechaSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {        
            Reporte();
        }
        #endregion        

        #region Metodos
        private void Reporte()
        {
            if (this.dtpFechaInicial.Value.Date > this.dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;                
            }
            
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            DataTable dtData = cnRptPdp.cnRptComisiones(this.dtpFechaInicial.Value.Date, this.dtpFechaFinal.Value.Date);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsComisiones", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpFechaInicial.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpFechaFinal.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaSis", this.dFechaSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteComisiones.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        
        #endregion 
    }
}
