using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmPerdidasGanancias : frmBase
    {
        public frmPerdidasGanancias()
        {
            InitializeComponent();
            dtpFecSistema.Value = clsVarGlobal.dFecSystem;
            cboMoneda.CargaDatosContaIntegrado();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecSistema.Value.Date;
            if (clsVarGlobal.dFecSystem < dFecha)
            {
                MessageBox.Show("La fecha debe ser menor o igual a la fecha del sistema", "Valida estado de resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            int idMoneda = (int)cboMoneda.SelectedValue;
            int idAgencia = (int)cboAgencia.SelectedValue;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsPerdidasGanancias", new clsRPTCNContabilidad().CNPerdidasGanancias(dFecha, idMoneda, idAgencia)));

            string reportpath = "rptPerdidasGanancias.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void btnExporExcel_Click(object sender, EventArgs e)
        {

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            DateTime dFecha = dtpFecSistema.Value.Date;
            int idMoneda = (int)cboMoneda.SelectedValue;
            int idAgencia = (int)cboAgencia.SelectedValue;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsPerdidasGanancias", new clsRPTCNContabilidad().CNPerdidasGanancias(dFecha, idMoneda, idAgencia)));

            string reportpath = "rptEPGCoop.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist,enuFormatoReporte.Excel).ShowDialog();
        }
    }
}
