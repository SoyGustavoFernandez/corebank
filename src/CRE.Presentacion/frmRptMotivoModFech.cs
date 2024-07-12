using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRptMotivoModFech : frmBase
    {
        public frmRptMotivoModFech()
        {
            InitializeComponent();
        }

        #region Eventos
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList  = new List<ReportDataSource>();

            if (valida()) return;

            DataTable dtMotivo = new clsRPTCNCredito().CNReporteMotivoHistorico(dFechaIni.Value, dFechaFin.Value);
            
            if (dtMotivo.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados.", "Reporte motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            dtsList.Clear();
            dtsList.Add(new ReportDataSource("DataSet1", dtMotivo));

            paramList.Clear();
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("dFechaSis", Convert.ToString(clsVarGlobal.dFecSystem.Date), false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramList.Add(new ReportParameter("dFechaIni", dFechaIni.Value.ToString(), false));
            paramList.Add(new ReportParameter("dFechaFin", dFechaFin.Value.ToString(), false));

            string reportPath = "rptMotivoHistorico.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
        #endregion

        #region Métodos
        Boolean valida()
        {
            if (this.dFechaIni.Value.Date > this.dFechaFin.Value.Date)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.", "Reporte motivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        #endregion
    }
}
