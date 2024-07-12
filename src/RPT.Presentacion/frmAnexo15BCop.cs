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
    public partial class frmAnexo15BCop : frmBase
    {
        public frmAnexo15BCop()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dtpFecha.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DataTable dtMN = new clsRPTCNContabilidad().CNAnexo15BMNCop(dFecha);
            DataTable dtME = new clsRPTCNContabilidad().CNAnexo15BMECop(dFecha);

            if (dtMN.Rows.Count > 0)
            {
                clsCNMeses cnmes = new clsCNMeses();
                var dtmes = cnmes.listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == dFecha.Month).ToList();

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo15BMN", dtMN));
                dtslist.Add(new ReportDataSource("dtsAnexo15BME", dtME));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));
                paramlist.Add(new ReportParameter("nAnio", dFecha.Year.ToString(), false));
                paramlist.Add(new ReportParameter("cMes", dtmes[0]["cMes"].ToString(), false));
                paramlist.Add(new ReportParameter("cTituloReporte", "POSICION MENSUAL DE LIQUIDEZ (ANEXO 15-B)", false));

                string reportpath = "RptAnexo15BCop.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 15 B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = this.dtpFecha.Value.Date;
            DataTable dtMN = new clsRPTCNContabilidad().CNAnexo15BMNCop(dFecha);
            DataTable dtME = new clsRPTCNContabilidad().CNAnexo15BMECop(dFecha);

            if (dtMN.Rows.Count > 0)
            {
                clsCNMeses cnmes = new clsCNMeses();
                var dtmes = cnmes.listarMeses().AsEnumerable().Where(x => (int)x["idMeses"] == dFecha.Month).ToList();

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dtsAnexo15BMN", dtMN));
                dtslist.Add(new ReportDataSource("dtsAnexo15BME", dtME));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomCortoEmp"], false));
                paramlist.Add(new ReportParameter("nAnio", dFecha.Year.ToString(), false));
                paramlist.Add(new ReportParameter("cMes", dtmes[0]["cMes"].ToString(), false));
                paramlist.Add(new ReportParameter("cTituloReporte", "POSICION MENSUAL DE LIQUIDEZ (ANEXO 15-B)", false));

                string reportpath = "RptAnexo15BCop.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel).ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("No existen datos para la fecha seleccionada", "Valida Anexo 15 B", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnImprimir1.Enabled = false;
            }
        }
    }
}
