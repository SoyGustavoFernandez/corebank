using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPT.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using System.Text.RegularExpressions;
using GEN.ControlesBase;

namespace SPL.Presentacion
{
    public partial class frmRptScoringSplaft : frmBase
    {
        public frmRptScoringSplaft()
        {
            InitializeComponent();
        }

        private void frmRptScoringSplaft_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = Convert.ToDateTime(clsVarGlobal.dFecSystem.Year + "-" + clsVarGlobal.dFecSystem.Month + "-" + "01");
            dtpFechaInicio.MaxDate = clsVarGlobal.dFecSystem;

            DateTime firstOfNextMonth = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddMonths(1);
            dtpFechaFin.Value = firstOfNextMonth.AddDays(-1);
            dtpFechaFin.MaxDate = clsVarGlobal.dFecSystem;           

            cboTipoEvalScoring.CargarListaTipoEval();

            cboCalifScoring.lAgregarTodos = true;
            cboCalifScoring.CargarVigentes(0);
            cboCalifScoring.SelectedValue = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {   
            Cursor.Current = Cursors.WaitCursor;
            // Vars
            String cDocumentoID    = txtDocumentoID.Text == "" ? "0" : txtDocumentoID.Text;
            int nCodigoEvaluacion = txtCodigoEvaluacion.Text == "" ? 0 : int.Parse(txtCodigoEvaluacion.Text);
            int nTipoEvaluacionID =  int.Parse(cboTipoEvalScoring.SelectedValue.ToString());
            int nCalificativoID   =  int.Parse(cboCalifScoring.SelectedValue.ToString());
            DateTime dFechaEvalInicio = dtpFechaInicio.Value.Date;
            DateTime dFechaEvalFin    = dtpFechaFin.Value.Date;          

            DataTable dtScoringSplaft = new clsRPTCNSplaft().CNScoringSplaft(cDocumentoID, nCodigoEvaluacion, dFechaEvalInicio, dFechaEvalFin, nTipoEvaluacionID, nCalificativoID);

            if (dtScoringSplaft.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cDocumentoID", cDocumentoID, false));
                paramlist.Add(new ReportParameter("nCodigoEvaluacion", nCodigoEvaluacion.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaEvalInicio", dFechaEvalInicio.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaEvalFin", dFechaEvalFin.ToString(), false));
                paramlist.Add(new ReportParameter("nTipoEvaluacionID", nTipoEvaluacionID.ToString(), false));
                paramlist.Add(new ReportParameter("nCalificativoID", nCalificativoID.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsEvalScoringCli", dtScoringSplaft));

                Cursor.Current = Cursors.Default;

                string reportpath = "rptScoringSplaft.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha encontrado registros.", "Reporte Scoring Splaft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        private void txtDocumentoID_TextChanged(object sender, EventArgs e)
        {
            txtDocumentoID.Text = validarNumeros(txtDocumentoID.Text);
        }

        private void txtCodigoEvaluacion_TextChanged(object sender, EventArgs e)
        {
            txtCodigoEvaluacion.Text = validarNumeros(txtCodigoEvaluacion.Text);
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaFin.MinDate = dtpFechaInicio.Value;
        }

        private string validarNumeros(String cadena)
        {
            int n = 0;
            String numeros = "";

            for (int i = 0; i < cadena.Length; i++)
            {
                if (int.TryParse(cadena[i].ToString(), out n))
                {
                    numeros += cadena[i];
                }
            }
            return numeros;
        }

       
    }
}
