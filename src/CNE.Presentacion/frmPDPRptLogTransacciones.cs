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
    public partial class frmPDPRptLogTransacciones : frmBase
    {
        #region Variables Globales
        string cTituloMsjes = "Reporte Log de Transacciones";
        DateTime dFecSystem = clsVarGlobal.dFecSystem;
        clsCNPdp cnRptPdp = new clsCNPdp();
        #endregion
        
        #region Metodos
        public frmPDPRptLogTransacciones()
        {
            InitializeComponent();

            this.cboLogTransacEstado.cboLogTransacUser(2);
            this.cboLogTransacEstado.cargarVigentesTodos(2);
            this.cboLogTransacEstado.SelectedIndex = 0;

            this.dtpFechaDesde.Value = this.dFecSystem.Date;
            this.dtpFechaHasta.Value = this.dFecSystem.Date;
        }        

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (this.dtpFechaDesde.Value.Date > this.dtpFechaHasta.Value.Date)
            {
                MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cLogTransac = Convert.ToString(this.cboLogTransacEstado.SelectedValue);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            DataTable dtData = cnRptPdp.cnLogTransac(cLogTransac, this.dtpFechaDesde.Value.Date, this.dtpFechaHasta.Value.Date);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsLogTransac", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cTransaccion", cLogTransac.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpFechaDesde.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpFechaHasta.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaSis", this.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));                
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteLogTransacciones.rdlc";
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
