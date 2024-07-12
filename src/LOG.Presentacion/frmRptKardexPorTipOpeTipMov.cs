using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmRptKardexPorTipOpeTipMov : frmBase
    {
        public frmRptKardexPorTipOpeTipMov()
        {
            InitializeComponent();
        }

        private void frmRptKardexPorTipOpeTipMov_Load(object sender, EventArgs e)
        {
            cboTipoOperacion.LisTipoOperacTodosModulo(7);  // Logistica
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            
            DateTime dFechaInicio = dtpFechaIni.Value;
            DateTime dFechaFin = dtpFechaFin.Value;
            int idTipoOperacion = (int)cboTipoOperacion.SelectedValue;
            int idTipoMovimiento = (int)cboTipoMovimiento.SelectedValue;

            DataTable dtKardexTipoOperacionTipoMovimiento = objLogistica.CNKardexPorTipoOperacionTipoMovimiento(dFechaInicio, dFechaFin, idTipoOperacion, idTipoMovimiento);

            if (dtKardexTipoOperacionTipoMovimiento.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsKardexTipoOperacionTipoMovimiento", dtKardexTipoOperacionTipoMovimiento));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("idTipoOperacion", idTipoOperacion.ToString(), false));
                paramList.Add(new ReportParameter("idTipoMovimiento", idTipoMovimiento.ToString(), false));

                string reportPath = "rptKardexPorTipOpeTipMov.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Movimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
