using EntityLayer;
//using GEN.Funciones;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmNumeroMontoOpinionesAnalista : frmBase
    {
        #region Variables
        clsCNCro cnRptRsg = new clsCNCro();
        DateTime dFechaHoy = clsVarGlobal.dFecSystem;
        #endregion

        public frmNumeroMontoOpinionesAnalista()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtData = cnRptRsg.rptNumeroMontoOpinionAnalista(
                    Convert.ToDateTime(dFechaIni.Value),
                    Convert.ToDateTime(dFechaFin.Value),
                    Convert.ToInt32(cboAgencia1.SelectedValue)
                );

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            dtslist.Clear();



            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            dtslist.Add(new ReportDataSource("datos", dtData));

            string reportpath = "rptNumeroMontoOpinionAnalista.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmNumeroMontoOpinionesAnalista_Load(object sender, EventArgs e)
        {
            this.dFechaIni.Value = dFechaHoy;
            this.dFechaFin.Value = dFechaHoy;
        }
    }
}
