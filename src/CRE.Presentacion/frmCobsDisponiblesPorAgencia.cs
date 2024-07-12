using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCobsDisponiblesPorAgencia : frmBase
    {
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();
        public frmCobsDisponiblesPorAgencia()
        {
            InitializeComponent();
        }

        private void frmCobsDisponiblesPorAgencia_Load(object sender, EventArgs e)
        {
            txtAgencia.Text = clsVarGlobal.cNomAge;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idAgencia = clsVarGlobal.nIdAgencia;
            DataTable datos = cnCondonacion.getCobsDisponibles(idAgencia);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            //DataTable datos = (DataTable)dtgCobs.DataSource;
            dtsList.Add(new ReportDataSource("datos", datos));

            paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cWinUser, false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("cTitulo", "AGENCIA: " + clsVarApl.dicVarGen["cNomAge"], false));
            //paramList.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));

            string reportPath = "rptCobsDisponibles.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

    }
}
