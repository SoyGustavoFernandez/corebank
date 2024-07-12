using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptMoraAgencia : frmBase
    {
        public frmRptMoraAgencia()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime pdFecha = dtpFecha.Value;
            DataTable dtMora = new clsRPTCNCredito().CNMoraAgencia(pdFecha);
            if (dtMora.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Mora Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsMoraAgencia", dtMora));
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", pdFecha.ToString(), false));
            string reportpath = "RptMoraAgencia.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptMoraProducto_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }
    }
}
