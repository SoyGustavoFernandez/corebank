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
    public partial class frmRptDesAgencia : frmBase
    {
        public frmRptDesAgencia()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime pdFecIni = dtpFecIni.Value;
            DateTime pdFecFin = dtpFecFin.Value;
            if (valida(pdFecIni, pdFecFin))
            {
                return;
            }
            DataTable dtDesem = new clsRPTCNCredito().CNDesembolsoAgencia(pdFecIni, pdFecFin);
            if (dtDesem.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Desembolso Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsDesembolsoAgencia", dtDesem));
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecIni", pdFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFecFin", pdFecFin.ToString(), false));
            string reportpath = "RptDesembolsoAgencia.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptMoraProducto_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date.AddDays(clsVarGlobal.dFecSystem.Day*-1 + 1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }
        Boolean valida(DateTime dFecIni, DateTime dFecFin)
        {
            if (dFecFin<dFecIni)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Desembolso Agencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
    }
}
