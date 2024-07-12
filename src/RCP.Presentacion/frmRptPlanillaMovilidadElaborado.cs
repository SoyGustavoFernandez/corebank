#region Referencias
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
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
#endregion

namespace RCP.Presentacion
{
    public partial class frmRptPlanillaMovilidadElaborado : frmBase
    {
        #region Variables Globales
        private clsCNPlanillaMovilidad objCNPlanillaMovilidad { get; set; }
        #endregion

        public frmRptPlanillaMovilidadElaborado()
        {
            InitializeComponent();
        }

        #region Eventos
        private void frmRptPlanillaMovilidadElaborado_Load(object sender, EventArgs e)
        {
            cargarComponentes();
            cargarDatosDefecto();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            int nAnio = Convert.ToInt32(nudAnio.Value);
            int nMes = Convert.ToInt32(cboMeses.SelectedValue);

            string cMesReporte = cboMeses.Text;
            string nAnioReporte = Convert.ToString(nAnio);

            DataTable dtDatosReporte = objCNPlanillaMovilidad.CNObtenerPlanillaMovilidadElaborador(nMes, nAnio);

            if (dtDatosReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            paramlist.Add(new ReportParameter("cMesReporte", cMesReporte, false));
            paramlist.Add(new ReportParameter("nAnioReporte", nAnioReporte, false));

            dtslist.Add(new ReportDataSource("dsPlanillaMovilidadElaborado", dtDatosReporte));

            string reportpath = "rptListaPlanillaMovilidadElaborado.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }
        #endregion

        #region Metodos
        private void cargarComponentes()
        {
            objCNPlanillaMovilidad = new clsCNPlanillaMovilidad();
        }
        private void cargarDatosDefecto()
        {
            DateTime dFechaSistema = clsVarGlobal.dFecSystem;
            int nAnio = dFechaSistema.Year;
            int nMes = dFechaSistema.Month;

            cboMeses.SelectedValue = nMes;
            nudAnio.Value = nAnio;
        }
        #endregion

    }
}
