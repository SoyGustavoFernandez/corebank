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
using SPL.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;


namespace SPL.Presentacion
{
    public partial class FrmImpresionMasiva : frmBase
    {
        private clsCNScoring _objCnScoring;
        public FrmImpresionMasiva()
        {
            InitializeComponent();
            cboTipoEvalScoring1.CargarPorTipoPersona(0, false);
            _objCnScoring = new clsCNScoring();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboTipoEvalScoring1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de evaluación", "Impresiones Masivas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (nudBase1.Value > nudBase2.Value)
            {
                MessageBox.Show("El Nro de Evaluación inicial mayor a el Nro de Evaluación final", "Impresiones Masivas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            DataTable dtEvaluaciones = _objCnScoring.CNImpresionMasiva((int)nudBase1.Value, (int)nudBase2.Value,Convert.ToInt32(cboTipoEvalScoring1.SelectedValue));
            string reportpath = String.Empty;
            reportpath = dtEvaluaciones.Rows.Count > 0 ? dtEvaluaciones.Rows[0]["cNomReporte"].ToString() : string.Empty;
            if (string.IsNullOrEmpty(reportpath))
            {
                MessageBox.Show("No se encontró reporte para el tipo de evaluación", "Impresión Masiva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cIdsEval", "0", false));

            dtslist.Add(new ReportDataSource("DSClientes", dtEvaluaciones));
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
