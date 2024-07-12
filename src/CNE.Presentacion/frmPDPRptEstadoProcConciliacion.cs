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
    public partial class frmPDPRptEstadoProcConciliacion : frmBase
    {
        #region Variables Globales
        DateTime dFecSystem = clsVarGlobal.dFecSystem;
        string cTituloMsjes = "Reporte de Estado del Proceso de Conciliación";        
        clsCNPdp cnRptPdp = new clsCNPdp();
        #endregion
        
        #region Eventos
        public frmPDPRptEstadoProcConciliacion()
        {
            InitializeComponent();
            CargarComboTipoReporte();
            this.dtpFechaDesde.Value = dFecSystem.Date;
            this.dtpFechaHasta.Value = dFecSystem.Date;
        }              

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            Reporte();
        }
        #endregion

        #region Metodos
        public void CargarComboTipoReporte()
        {
            Dictionary<string, string> itemsTipoReporte = new Dictionary<string, string>();
            itemsTipoReporte.Add("0", "TODOS");
            itemsTipoReporte.Add("1", "DEPOSITOS");
            itemsTipoReporte.Add("2", "RETIROS");            

            this.cboTipoProc.DataSource = new BindingSource(itemsTipoReporte, null);
            this.cboTipoProc.DisplayMember = "Value";
            this.cboTipoProc.ValueMember = "Key";
        }

        private void Reporte()
        {   
            if (this.dtpFechaDesde.Value.Date > this.dtpFechaHasta.Value.Date)
            {
                MessageBox.Show("La Fecha Desde debe de ser menor o igual que la Fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;                
            }

            int nModalidad = Convert.ToInt16(this.cboTipoProc.SelectedValue);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            DataTable dtData = cnRptPdp.cnEstProcConciliacion(nModalidad, this.dtpFechaDesde.Value.Date, this.dtpFechaHasta.Value.Date);
            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsEstProcConc", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("nModalidad", nModalidad.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaDesde", this.dtpFechaDesde.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaHasta", this.dtpFechaHasta.Value.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaSis", this.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteEstProcConciliacion.rdlc";
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
