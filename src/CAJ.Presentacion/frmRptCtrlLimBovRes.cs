using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using CAJ.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRptCtrlLimBovRes : frmBase
    {
        private clsCNControlLimitesBoveda oBD = new clsCNControlLimitesBoveda();

        public frmRptCtrlLimBovRes()
        {
            InitializeComponent();
            this.conRptParamCaj1.cargarFormulario();
            this.nudAnio.Value = DateTime.Now.Year;
            this.cboMeses1.SelectedValue = DateTime.Now.Month;
            this.conRptParamCaj1.continuar += new EventHandler(this.mostrarReporte);
        }

        void mostrarReporte(object sender, EventArgs e)
        {
            List<ReportParameter> listPar = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            listPar.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            listPar.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge));
            listPar.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy")));

            listPar.Add(new ReportParameter("idAgencia", this.conRptParamCaj1.cboAgencia1.SelectedValue.ToString()));
            listPar.Add(new ReportParameter("idEstablecimiento", this.conRptParamCaj1.cboEstablecimiento1.SelectedValue != null ? this.conRptParamCaj1.cboEstablecimiento1.SelectedValue.ToString() : "0"));
            listPar.Add(new ReportParameter("cZona", Convert.ToInt32(this.conRptParamCaj1.cboAgencia1.SelectedValue) != 0 ? this.conRptParamCaj1.cboAgencia1.Text : this.conRptParamCaj1.cboZona1.Text));

            dtslist.Add(new ReportDataSource("dtList", this.oBD.reporteResumenExcepciones(
                Convert.ToInt32(this.conRptParamCaj1.cboAgencia1.SelectedValue),
                Convert.ToInt32(this.conRptParamCaj1.cboEstablecimiento1.SelectedValue != null ? this.conRptParamCaj1.cboEstablecimiento1.SelectedValue : 0),
                Convert.ToInt32(this.conRptParamCaj1.cboZona1.SelectedValue),
                this.conRptParamCaj1.dtpIni.Value,
                this.conRptParamCaj1.dtpFin.Value
                )));

            string reportpath = "rptCtrllimBovRes.rdlc";
            frmReporteLocal objfrmReporteador = new frmReporteLocal(dtslist, reportpath, listPar);
            objfrmReporteador.ShowDialog();
        }
    }
}
