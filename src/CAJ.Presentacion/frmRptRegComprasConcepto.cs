using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptRegComprasConcepto : frmBase
    {
        public frmRptRegComprasConcepto()
        {
            InitializeComponent();
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string dFecIni = this.dtpFecInicial.Value.ToShortDateString();
            string dFecFin = this.dtpFecFinal.Value.ToShortDateString();
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());

            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una agencia.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpFecFinal.Value < dtpFecInicial.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (new clsCNCajaChica().RptRegComprasDetalle(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia).Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();           
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaINI", dFecIni, false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin, false));
            paramlist.Add(new ReportParameter("x_cRutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("x_nIdAgencia", idAgencia.ToString(), false));

            if (rbtFecPago.Checked)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("DsCpg", new clsCNCajaChica().RptRegComprasDetalle(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia)));

                string reportpath = "RptCpgCajGenConceptoPag.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            else
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("DsCpg", new clsCNCajaChica().RptRegComprasDetalleFecEmision(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia)));

                string reportpath = "RptCpgCajGenConceptoEmi.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            
        }
    }
}
