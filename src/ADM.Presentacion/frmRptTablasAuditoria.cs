using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;

namespace ADM.Presentacion
{
    public partial class frmRptTablasAuditoria : frmBase
    {
        clsCNAuditoriaTablas objAuditoria = new clsCNAuditoriaTablas();

        public frmRptTablasAuditoria()
        {
            InitializeComponent();
        }

        private void frmRptTablasAuditoria_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem.Date;
            
            DataTable dt = objAuditoria.CNListarTablasDeAuditoria();
            cboTablasAuditoria.DataSource = dt;
            cboTablasAuditoria.ValueMember = dt.Columns["cNombreTablaAudit"].ToString();
            cboTablasAuditoria.DisplayMember = dt.Columns["cNombreTablaAudit"].ToString();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cTablaAudit = cboTablasAuditoria.SelectedValue.ToString();
            DateTime dFecInicial = dtpFechaIni.Value.Date;
            DateTime dFecFinal = dtpFechaFin.Value.Date;

            DataTable dtAuditoriaTabla = new clsCNAuditoriaTablas().CNVisualizarAuditoriaTabla(cTablaAudit, dFecInicial, dFecFinal);
            if (dtAuditoriaTabla.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsAuditoriaTabla", dtAuditoriaTabla));
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("x_cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("x_cNombreTabla", cTablaAudit, false));
                paramList.Add(new ReportParameter("x_dFecInicial", dFecInicial.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_dFecFinal", dFecFinal.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptDatosAuditoriaTabla.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para las fechas indicadas", "Reporte de Auditoria de Tablas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
