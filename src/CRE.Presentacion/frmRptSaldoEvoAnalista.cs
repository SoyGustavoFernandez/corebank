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
    public partial class frmRptSaldoEvoAnalista : frmBase
    {
        public frmRptSaldoEvoAnalista()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string pcAgencia = cboAgencia1.Text;
            int pidAgencia =Convert.ToInt32(cboAgencia1.SelectedValue);
            DateTime pdFecIni = dtpFecIni.Value;
            DateTime pdFecFin = dtpFecFin.Value;
            if (valida(pdFecIni, pdFecFin))
            {
                return;
            }
            DataTable dtSaldoAna = new clsRPTCNCredito().CNSaldoEvolutivoAnalista(pdFecIni, pdFecFin, pidAgencia);
            if (dtSaldoAna.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Saldo Analista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsEvoAnalista", dtSaldoAna));
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecIni", pdFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFecFin", pdFecFin.ToString(), false));
            paramlist.Add(new ReportParameter("x_idAgencia", pidAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_cAgencia", pcAgencia.ToString(), false));
            string reportpath = "RptEvolSaldoAnalista.rdlc";

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
                MessageBox.Show("La fecha inicial no puede ser mayor a la final", "Saldo Analista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
    }
}
