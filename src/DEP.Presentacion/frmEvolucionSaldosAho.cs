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

namespace DEP.Presentacion
{
    public partial class frmEvolucionSaldosAho : frmBase
    {
        public frmEvolucionSaldosAho()
        {
            InitializeComponent();
        }

        private void frmEvolucionSaldosAho_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem.AddYears(-1);
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpFechaInicio.Value.Date;
            DateTime dFecFin = dtpFechaFin.Value.Date;

            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtEvolucionSaldos = new clsRPTCNDeposito().CNEvolucionSaldosAhorros(dFecIni, dFecFin);
            if (dtEvolucionSaldos.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el anexo", "Anexo 24", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgencia", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFecIni", dFecIni.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToShortDateString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsEvolucionSaldos", dtEvolucionSaldos));

                string reportpath = "RptEvolucionSaldosAho.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
