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
    public partial class frmRptConMovMonTpAho : frmBase
    {
        clsRPTCNDeposito rptCNDeposito = new clsRPTCNDeposito();

        public frmRptConMovMonTpAho()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (dtpFechaInicial.Value > dtpFechaFinal.Value)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha final", "Reporte de Concentración de Movimientos de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dtpFechaInicial.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha del Sistema", "Reporte de Concentración de Movimientos de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaInicial.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }

            if (dtpFechaFinal.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha final de búsqueda no puede ser mayor o igual a la fecha del sistema", "Reporte de Concentración de Movimientos de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFechaInicio = this.dtpFechaInicial.Value;
            DateTime dFechaFinal = this.dtpFechaFinal.Value;

            DataTable dtResp = rptCNDeposito.CNRptConMovMonTpAho(dFechaInicio, dFechaFinal);
            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Reporte de Concentración de Movimientos de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            {
                string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem;
                string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRptConMovMonTpAho", dtResp));

                string reportpath = "rptConcentracionMovAhoXMonedaAgencias.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
        }

        private void frmRptConMovMonTpAho_Load(object sender, EventArgs e)
        {
            dtpFechaFinal.Value = clsVarGlobal.dFecSystem.AddDays(-1);
            dtpFechaInicial.Value = clsVarGlobal.dFecSystem.AddDays(-1);
        }
    }
}
