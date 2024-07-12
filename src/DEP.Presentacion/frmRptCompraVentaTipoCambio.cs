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

namespace DEP.Presentacion
{
    public partial class frmRptCompraVentaTipoCambio : frmBase
    {
        clsRPTCNDeposito rptCNDeposito = new clsRPTCNDeposito();

        public frmRptCompraVentaTipoCambio()
        {
            InitializeComponent();
        }

        private void frmRptCompraVentaTipoCambio_Load(object sender, EventArgs e)
        {
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            dtpFecInicio.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
           if (dtpFecFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final de búsqueda no puede ser mayor a la fecha del sistema", "Reporte de posición de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }
            if (dtpFecInicio.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha del sistema", "Reporte de posición de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFecInicio.Value = clsVarGlobal.dFecSystem.Date;
                return;
            } 
            if (dtpFecInicio.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha final", "Reporte de posición de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           

            DateTime dFechaInicio = this.dtpFecInicio.Value;
            DateTime dFechaFinal = this.dtpFecFin.Value;

            DataTable dtResp = rptCNDeposito.CNRptCompraVentaTipoCambio(dFechaInicio, dFechaFinal);
            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Reporte de posición de cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem;

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRptCompraVentaTipoCambio", dtResp));

                string reportpath = "rptCompraVentaTipoCambio.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
        }
    }
}
