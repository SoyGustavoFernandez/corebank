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
    public partial class frmPDPRptTransClientesBimVSListasLaft : frmBase
    {
        string cTituloMsjes = "Reporte de Transacciones de Clientes Bim en Listas LAFT";
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        clsCNPdp cnRptPdp = new clsCNPdp();

        public frmPDPRptTransClientesBimVSListasLaft()
        {
            InitializeComponent();
            InicializarComboTipoReporte();
        }

        void InicializarComboTipoReporte()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("nValue");
            dt.Columns.Add("cText");

            DataRow dr1 = dt.NewRow();
            dr1["nValue"] = 1;
            dr1["cText"] = "Transac. BIM-Lista LAFT";

            DataRow dr2 = dt.NewRow();
            dr2["nValue"] = 2;
            dr2["cText"] = "Transac. BIM-Lista OFAC ONU";

            dt.Rows.InsertAt(dr1, 0);
            dt.Rows.InsertAt(dr2, 1);

            cboTipoReporte.DataSource = dt;
            cboTipoReporte.DisplayMember = "cText";
            cboTipoReporte.ValueMember = "nValue";
            cboTipoReporte.SelectedIndex = 0;            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int nModalidad = Convert.ToInt32(this.cboTipoReporte.SelectedValue);
            DateTime dFechaDesde = Convert.ToDateTime(this.dtpFecDesde.Value);
            DateTime dFechaHasta = Convert.ToDateTime(this.dtpFecHasta.Value);

            if (dFechaDesde.Date > dFechaHasta.Date)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtData = cnRptPdp.ObtenerReporteTransacClientesBimListasLaft(nModalidad, dFechaDesde.Date, dFechaHasta.Date);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsRptTransCliBimListLAFT", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                string cNomAgen = clsVarGlobal.cNomAge.ToString();
                
                paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptReporteTransCliBimVSListasLAFT.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        
    }
}
