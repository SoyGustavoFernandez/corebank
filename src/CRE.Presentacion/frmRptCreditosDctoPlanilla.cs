using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using CRE.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using System.IO;

namespace CRE.Presentacion
{
    public partial class frmRptCreditosDctoPlanilla : frmBase
    {
        public frmRptCreditosDctoPlanilla()
        {
            InitializeComponent();
        }

        private void frmRptCreditosDctoPlanilla_Load(object sender, EventArgs e)
        {
            dtpFechaProceso.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnExporPdf_Click(object sender, EventArgs e)
        {
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            bool lEstEmpleado = (rbtnActivos.Checked = true ? true : false);

            DataTable dtCreditosDctoPlanilla = new clsCNCredito().CNListarCreditosDctoPlanilla(dFecProceso, lEstEmpleado);

            if (dtCreditosDctoPlanilla.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsCreditosDctoPlanilla", dtCreditosDctoPlanilla));
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("x_cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("x_dFecProces", dFecProceso.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_lEstEmpleado", lEstEmpleado.ToString(), false));

                string reportpath = "rptCreditosDctoPlanilla.rdlc";
                new frmReporteLocal(dtsList, reportpath, paramList, enuFormatoReporte.Pdf).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Reporte de Créditos para Dcto de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExporTxt_Click(object sender, EventArgs e)
        {
            string cRuta = "";
            string cNomArchivo = "";
            DateTime dFecProceso = dtpFechaProceso.Value.Date;
            bool lEstEmpleado = (rbtnActivos.Checked == true ? true : false);

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog.SelectedPath;
            }
            else
            {
                return;
            }
            
            DataTable dtCreditosDctoPlanilla = new clsCNCredito().CNListarCreditosDctoPlanilla(dFecProceso, lEstEmpleado);

            if (dtCreditosDctoPlanilla.Rows.Count > 0)
            {
                if (rbtnActivos.Checked == true)
                {
                    cNomArchivo = cRuta + "\\209-" + dFecProceso.ToString("MMyy") + ".Act";
                }
                else
                {
                    cNomArchivo = cRuta + "\\208-" + dFecProceso.ToString("MMyy") + ".Ces";
                }
                
                StreamWriter sr = new StreamWriter(@cNomArchivo);
                string pcCadena = "";

                for (int i = 0; i < dtCreditosDctoPlanilla.Rows.Count; i++)
                {
                    pcCadena = (Convert.ToString(dtCreditosDctoPlanilla.Rows[i]["cRegistro"]));
                    sr.WriteLine(pcCadena);
                }
                sr.Close();
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Reporte de Créditos para Dcto de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
