using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmResumenCarteraProducto : frmBase
    {
        public frmResumenCarteraProducto()
        {
            InitializeComponent();
            dtpFecProceso.Value = clsVarGlobal.dFecSystem;
        }
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            DateTime dFecPro = dtpFecProceso.Value;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsSaldoCartera", new clsRPTCNCredito().CNSaldoProducto(idAgencia, dFecPro)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("x_dFecha", dFecPro.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            string reportpath = "RptSaldoProducto.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
