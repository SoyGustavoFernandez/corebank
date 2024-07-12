using GEN.ControlesBase;
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
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace SPL.Presentacion
{
    public partial class frmVisitasClientesRegimenReforzado : frmBase
    {

        private clsRPTCNSplaft _clsCNRptSplaft;
        private const string cTituloMsjes = "Reporte de visitas";

        public frmVisitasClientesRegimenReforzado()
        {
            InitializeComponent();
            _clsCNRptSplaft = new clsRPTCNSplaft();
            cboTipoRiesgoSPLAFT.ListarTodos();
            cboAgencias.AgenciasYTodos();
            cboModulo.SelectedIndex = 0;
            cboAgencias.SelectedValue = 0;
            cboTipoRiesgoSPLAFT.SelectedValue = 0;
            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;
            int idAgencia = (int)cboAgencias.SelectedValue;
            int idModulo = (int)cboModulo.SelectedValue;
            int idTipoRiesgo = (int)cboTipoRiesgoSPLAFT.SelectedValue;
            DataTable dt = _clsCNRptSplaft.CNReporteVisitasSPLAFT(dFecIni, dFecFin, idAgencia, idModulo, idTipoRiesgo);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para visualizar en el reporte.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return;
            }

            List<ReportDataSource> lstDataSources = new List<ReportDataSource>();
            lstDataSources.Add(new ReportDataSource("dsData", dt));

            List<ReportParameter> lstParameters = new List<ReportParameter>();
            lstParameters.Add(new ReportParameter("cRutaLogo", Convert.ToString(clsVarApl.dicVarGen["CRUTALOGO"]), false));
            lstParameters.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            lstParameters.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

            string rptName = "RptReporteVisitasSPLAFT.rdlc";

            new frmReporteLocal(lstDataSources, rptName, lstParameters).ShowDialog();
        }

        private bool Validar()
        {
            if (dtpFecFin.Value.Date < dtpFecIni.Value.Date)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha de inicio.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboAgencias.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione la agencia.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboModulo.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione el tipo de producto.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            if (cboTipoRiesgoSPLAFT.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de riesgo.",
                                    cTituloMsjes,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
