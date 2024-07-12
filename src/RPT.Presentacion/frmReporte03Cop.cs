using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace RPT.Presentacion
{
    public partial class frmReporte03Cop : frmBase
    {
        public frmReporte03Cop()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DataTable dtReporte03 = new clsRPTCNContabilidad().CNReporte03Cop(dFecha);
            if (dtReporte03.Rows.Count > 0)
            {
                clsCNMeses cnmes = new clsCNMeses();
                var dtmes = cnmes.listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == dFecha.Month).ToList();

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsReporte3", dtReporte03));
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));
                paramlist.Add(new ReportParameter("nAnio", dFecha.Year.ToString(), false));
                paramlist.Add(new ReportParameter("cMes", dtmes[0]["cMes"].ToString(), false));
                paramlist.Add(new ReportParameter("cTituloReporte", "PATRIMONIO EFECTIVO (REPORTE 3)", false));

                string reportpath = "RptReporte03Cop.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DataTable dtReporte03 = new clsRPTCNContabilidad().CNReporte03Cop(dFecha);
            if (dtReporte03.Rows.Count > 0)
            {
                clsCNMeses cnmes = new clsCNMeses();
                var dtmes = cnmes.listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == dFecha.Month).ToList();

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("dtsReporte3", dtReporte03));
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));
                paramlist.Add(new ReportParameter("nAnio", dFecha.Year.ToString(), false));
                paramlist.Add(new ReportParameter("cMes", dtmes[0]["cMes"].ToString(), false));
                paramlist.Add(new ReportParameter("cTituloReporte", "PATRIMONIO EFECTIVO (REPORTE 3)", false));

                string reportpath = "RptReporte03Cop.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Reporte 03", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }
    }
}
