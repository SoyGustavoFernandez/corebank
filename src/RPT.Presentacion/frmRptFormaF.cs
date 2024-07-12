using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmRptFormaF : frmBase
    {
        public frmRptFormaF()
        {
            InitializeComponent();
        }

        private void frmRptFormaF_Load(object sender, EventArgs e)
        {
            this.dtpFechaProceso.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboMonedas.Text.Trim() == "") {
                MessageBox.Show("Debe seleccionar el tipo de Moneda", "Reporte Forma F", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            int idMoneda = (int)cboMonedas.SelectedValue;

            DataTable dtBalance = new clsRPTCNContabilidad().CNReporteFormaF(dFecProceso, idMoneda);
            if (dtBalance.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para para la fecha seleccionada", "Reporte Forma F", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dAnio", dFecProceso.Year.ToString(), false));
                paramlist.Add(new ReportParameter("x_dMes", dFecProceso.ToString("MMMM"), false));                
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsBalanceComprobSaldo", dtBalance));

                string reportpath = "RptBalanceComprSaldo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            if (cboMonedas.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el tipo de Moneda", "Reporte Forma F", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFecProceso = this.dtpFechaProceso.Value.Date;
            int idMoneda = (int)cboMonedas.SelectedValue;

            DataTable dtBalance = new clsRPTCNContabilidad().CNReporteFormaF(dFecProceso, idMoneda);
            if (dtBalance.Rows.Count > 0)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsBalanceComprobSaldo", dtBalance));
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dAnio", dFecProceso.Year.ToString(), false));
                paramlist.Add(new ReportParameter("x_dMes", dFecProceso.ToString("MMMM"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));


                string reportpath = "RptBalanceComprSaldo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Reporte Forma F", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }
    }
}
