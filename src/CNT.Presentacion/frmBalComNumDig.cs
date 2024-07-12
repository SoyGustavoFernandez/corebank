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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace CNT.Presentacion
{
    public partial class frmBalComNumDig : frmBase
    {
        public frmBalComNumDig()
        {
            InitializeComponent();
        }

        private void frmBalanceGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaSistema.Value = clsVarGlobal.dFecSystem;
            NumDig.Value = 99;
            cboMoneda.CargaDatosContaTodos();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFechaSistema.Value.Date;
            int idMoneda = (int)cboMoneda.SelectedValue;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cMoneda = cboMoneda.Text;
            decimal nTipCambio = clsVarApl.dicVarGen["nTipoCambio"];
            int nNumDigito = Convert.ToInt16(NumDig.Value);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            if (nNumDigito % 2 != 0)
            {
                nNumDigito = nNumDigito + 1;
                NumDig.Value = nNumDigito;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
           
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("x_dFecha", dFecha.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_nNumDig", nNumDigito.ToString(), false));
            paramlist.Add(new ReportParameter("x_cMoneda", cMoneda, false));
            paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("x_TipoCambio", nTipCambio.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsBalComDig", new clsRPTCNContabilidad().CNBalComDigitos(dFecha, idMoneda, nNumDigito, idAgencia)));

            string reportpath = "RptBalComNumDig.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
