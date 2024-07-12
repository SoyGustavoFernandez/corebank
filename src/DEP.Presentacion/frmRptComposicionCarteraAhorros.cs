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

namespace DEP.Presentacion
{
    public partial class frmRptComposicionCarteraAhorros : frmBase
    {
        public frmRptComposicionCarteraAhorros()
        {
            InitializeComponent();
        }

        private void frmRptComposicionCarteraAhorros_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value.Date;

            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtComposicionCartera = new clsRPTCNDeposito().CNComposicionCartera(dFecha);
            if (dtComposicionCartera.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Composición de Cartera de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgencia", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsComposicionCartera", dtComposicionCartera));

                string reportpath = "rptComposicionCarteraAhorros.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
