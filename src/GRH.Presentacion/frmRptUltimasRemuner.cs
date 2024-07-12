using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmRptUltimasRemuner : frmBase
    {
        public frmRptUltimasRemuner()
        {
            InitializeComponent();
        }

        private void frmRptUltimasRemuner_Load(object sender, EventArgs e)
        {
            cboPeriodo.ListarPeriodoVigenteTipoPlanilla(4);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboPeriodo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Reporte de las Ultimas Remuneraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cAgencia = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtRpt = new clsRPTCNRecurHum().CN6UltRemuner(Convert.ToInt32(cboPeriodo.SelectedValue));
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNombsEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNombAgencia", cAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("ds6UltRemuneraciones", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "rpt6UltRemuneraciones.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de las Ultimas Remuneraciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
