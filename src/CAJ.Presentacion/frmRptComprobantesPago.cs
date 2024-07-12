using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using CAJ.CapaNegocio;
namespace CAJ.Presentacion
{
    public partial class frmRptComprobantesPago : frmBase
    {
        clsCNCajaChica rptComprobante = new clsCNCajaChica();
        public frmRptComprobantesPago()
        {
            InitializeComponent();
            dtpFechaIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            cboTipoComprobantePago1.llenarDatosComprobante(1);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            string dFecIni = this.dtpFechaIni.Value.ToShortDateString();
            string dFecFin = this.dtpFechaFin.Value.ToShortDateString();
            int  ntipCompr =Convert.ToInt32(cboTipoComprobantePago1.SelectedValue.ToString());
            int idAgencia =Convert.ToInt32(cboAgencia1.SelectedValue.ToString());
            int idEstadoCpg = 0;
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            if (cboEstadoComprobante.SelectedIndex==-1)
            {
                MessageBox.Show("Debe Seleccionar el Estado del Comprobante", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTipoComprobantePago1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar el Tipo de Comprobante", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            idEstadoCpg = Convert.ToInt16(cboEstadoComprobante.SelectedValue);

            paramlist.Add(new ReportParameter("ntipCompr", ntipCompr.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dfechaIni",dFecIni, false));
            paramlist.Add(new ReportParameter("dfechaFin", dFecFin, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_RutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("idEstadoCpg", idEstadoCpg.ToString(), false));

            if (Convert.ToInt16(cboEstadoComprobante.SelectedValue)==2)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsRptComprobante", new clsCNCajaChica().ReporteComprobantes(ntipCompr, idAgencia, dtpFechaIni.Value, dtpFechaFin.Value, idEstadoCpg)));

                string reportpath = "rptComprobantesPag.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            else
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsRptComprobante", new clsCNCajaChica().ReporteComprobantesEmi(ntipCompr, idAgencia, dtpFechaIni.Value, dtpFechaFin.Value, idEstadoCpg)));

                string reportpath = "rptComprobantesEmi.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            
        }
    }
}
