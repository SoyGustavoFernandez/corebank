using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
namespace LOG.Presentacion
{
    public partial class frmRptBienesEntregados : frmBase
    {
        public frmRptBienesEntregados()
        {
            InitializeComponent();
        }

        private void frmRptBienesEntregados_Load(object sender, EventArgs e)
        {
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;
            cboAgencias1.AgenciasYTodos();
            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencias1.Enabled = true;
            }
            else
            {
                cboAgencias1.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencias1.Enabled = false;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();

            DataTable dtBienesEntregados = objLogistica.CNGetBienesEntregadosColab(dtpFecInicial.Value, dtpFecFinal.Value, Convert.ToInt32(cboAlmacen.SelectedValue));

            if (dtBienesEntregados.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsBienesEntregados", dtBienesEntregados));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu.ToString(), false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("dFechaIni", dtpFecInicial.Value.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("dFechaFin", dtpFecFinal.Value.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("idAgenciaSol", cboAgencias1.SelectedValue.ToString() , false));
                paramList.Add(new ReportParameter("cAgencia", cboAgencias1.Text, false));
                

                string reportPath = "rptLogBienesEntregados.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Movimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboAgencias1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias1.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen((int)cboAgencias1.SelectedValue);
            }
        }
    }
}
