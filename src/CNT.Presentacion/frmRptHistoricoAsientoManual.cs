using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmRptHistoricoAsientoManual : frmBase
    {
        public frmRptHistoricoAsientoManual()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int nVoucher = 0;
            if (dtpFecFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha del sistema", "Historial de cambios de los asientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtpFecIni.Value>dtpFecFin.Value)
            {
                 MessageBox.Show("La fecha inicio debe ser menor a la fecha final", "Historial de cambios de los asientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }
        
            if (!chcTodos.Checked)
            {
                if (txtNumVoucher.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el numero de asiento", "Historial de cambios de los asientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                nVoucher = Convert.ToInt32(txtNumVoucher.Text);
            }
            DateTime dFechaIni = dtpFecIni.Value;
            DateTime dFechaFin = dtpFecFin.Value;

            DataTable dtDatos = new clsRPTCNContabilidad().CNRptListaHistoricoAsiento(dFechaIni, dFechaFin, nVoucher);
            if (dtDatos.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Historial de cambios de los asientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
                paramlist.Add(new ReportParameter("dFecIni", dFechaIni.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFechaFin.ToString(), false));
                paramlist.Add(new ReportParameter("nVoucher", nVoucher.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dsHistAsiManual", dtDatos));
                string reportpath = "rptHistorialAsiManual.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTodos.Checked)
            {
                txtNumVoucher.Enabled = false;
                txtNumVoucher.Clear();
            }
            else
            {
                txtNumVoucher.Enabled = true;
                txtNumVoucher.Focus();
            }
        }

        private void frmRptHistoricoAsientoManual_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }
    }
}
