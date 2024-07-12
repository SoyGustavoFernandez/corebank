using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
namespace CAJ.Presentacion
{
    public partial class frmFlujoMensualBancos : frmBase
    {
        public frmFlujoMensualBancos()
        {
            InitializeComponent();
        }

        private void frmFlujoMensualBancos_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = clsVarGlobal.dFecSystem.Date.AddMonths(-1);
            dtpFechaFinal.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpFechaFinal.Value.ToShortDateString()) < Convert.ToDateTime(dtpFechaInicial.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no puede ser mayor que la Fecha Final", "Reporte de Flujo de Caja y Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFecSystem = clsVarGlobal.dFecSystem.Date;
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            DateTime dFechaInicio = dtpFechaInicial.Value;
            DateTime dFechaFinal = dtpFechaFinal.Value;
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);

            DataTable dtRptFlujoCajaBco = new clsCNFlujoCajaBco().CNRptFlujoMensualCajaBco(dFechaInicio, dFechaFinal, idMoneda);

            if (dtRptFlujoCajaBco.Rows.Count > 0)
            {
                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Clear();

                paramList.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramList.Add(new ReportParameter("x_cNomAgencia", cNomAgencia, false));
                paramList.Add(new ReportParameter("x_dFechaSis", dFecSystem.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));

                paramList.Add(new ReportParameter("x_dFechaIni", dFechaInicio.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_dFechaFin", dFechaFinal.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));

                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Clear();

                dtsList.Add(new ReportDataSource("dsFlujoCajaBco", dtRptFlujoCajaBco));

                string reportpath = "rptFlujoMensualCajaBco.rdlc";

                new frmReporteLocal(dtsList, reportpath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Flujo Mensual de Caja y Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
