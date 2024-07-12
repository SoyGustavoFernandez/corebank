using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RPT.Presentacion
{
    public partial class frmReporte12 : frmBase
    {
        public frmReporte12()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void frmReporte12_Load(object sender, EventArgs e)
        {
            

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFecha.Value.Date;

            DataTable dtReporte12 = new clsRPTCNCredito().CNReporte12(dFecProceso);
            if (dtReporte12.Rows.Count == 0)
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte 12", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("dFecha", dFecProceso.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsReporte12", dtReporte12));

                string reportpath = "RptSBSReporte12.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
