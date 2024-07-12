using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RPT.Presentacion
{
    public partial class frmRPTConsultaSegurosDesmarcados : frmBase
    {
        public frmRPTConsultaSegurosDesmarcados()
        {
            InitializeComponent();
        }

        private void frmRPTConsultaSegurosDesmarcados_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            CargaInicial();
        }

        private void CargaInicial()
        {
            //FECHAS
            dtpDesde.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
            dtpHasta.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DateTime dFechaDesde = dtpDesde.Value;
            DateTime dFechaHasta = dtpHasta.Value;

            DataTable dtSegurosDesmarcados = new clsCNSeguros().RPTConsultaSegurosDesmarcados(dFechaDesde, dFechaHasta.AddDays(1));

            if (dtSegurosDesmarcados.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("dFechaDesde", dFechaDesde.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFechaHasta", dFechaHasta.ToString("dd/MM/yyyy"), false));

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsSegurosDesmarcados", dtSegurosDesmarcados));

            string reportpath = "rptConsultaSegurosDesmarcados.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private bool validar()
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha \"Desde\" no debe ser posterior a la fecha \"Hasta\".", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}