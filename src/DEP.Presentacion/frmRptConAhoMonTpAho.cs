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
    public partial class frmRptConAhoMonTpAho : frmBase
    {
        clsRPTCNDeposito rptCNDeposito = new clsRPTCNDeposito();

        public frmRptConAhoMonTpAho()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (dtpFechaCorte.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de proceso no puede ser mayor o igual a la Fecha del Sistema", "Reporte de concentración de ahorros por moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaCorte.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }

            DateTime dFechaCorte = this.dtpFechaCorte.Value;

            DataTable dtResp = rptCNDeposito.CNRptConAhoMonTpAho(dFechaCorte);
            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Reporte de concentración de ahorros por moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem;

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaCorte", dFechaCorte.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRptConAhoMonTpAho", dtResp));
                string reportpath = "rptConcentracionAhoXMonedaAgencias.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
        }

        private void btnImpResumen_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (dtpFechaCorte.Value >= clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de proceso no puede ser mayor o igual a la fecha del sistema", "Reporte de concentración de ahorros por moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFechaCorte.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }       
            int idMoneda = 0;
            DateTime dFecProc = dtpFechaCorte.Value;
            int idProducto = 0;
            DateTime dFechaCorte = this.dtpFechaCorte.Value;
            DataTable dtRptConAhoMonTipRes = new clsRPTCNDeposito().CNRptConAhoMonTipProRes(idMoneda, dFecProc, idProducto);

            if (dtRptConAhoMonTipRes.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Reporte de concentración de ahorros por moneda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cNombreAge = clsVarGlobal.cNomAge;
                string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                List<ReportParameter> lstParamentros = new List<ReportParameter>();
                lstParamentros.Clear();
                lstParamentros.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                lstParamentros.Add(new ReportParameter("dFecProc", dFecProc.ToShortDateString(), false));
                lstParamentros.Add(new ReportParameter("idProducto", idProducto.ToString(), false));
                lstParamentros.Add(new ReportParameter("cNombreAge", cNombreAge, false));
                lstParamentros.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));
                string cRptPath = "rptConcentracionAhoMonProRes.rdlc";

                List<ReportDataSource> lstDataSource = new List<ReportDataSource>();
                lstDataSource.Clear();
                lstDataSource.Add(new ReportDataSource("dsConAhoMonTipRes", dtRptConAhoMonTipRes));
                new frmReporteLocal(lstDataSource, cRptPath, lstParamentros).ShowDialog();
            }
        }

        private void frmRptConAhoMonTpAho_Load(object sender, EventArgs e)
        {
            dtpFechaCorte.Value = clsVarGlobal.dFecSystem;
        }
    }
}
