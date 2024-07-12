using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using EntityLayer;
using RPT.CapaNegocio;
using CNT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmRptIngresoDeposito : frmBase
    {
        List<ReportParameter> paramlist = new List<ReportParameter>();
        public frmRptIngresoDeposito()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            parametros();
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            
            string reportpath = "";

            if ((int)cboAgencia.SelectedValue == 0)
            {
                dtslist.Add(new ReportDataSource("dtsDeposito", new clsCNBalance().CNResumDeposito(dFecIni.Value, dFecFin.Value)));
                reportpath = "RptResumenDepositosCNT.rdlc";
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtsDeposito", new clsCNBalance().CNResumDepositoAge(dFecIni.Value, dFecFin.Value, Convert.ToInt32(cboAgencia.SelectedValue))));
                reportpath = "RptResumenDepositosCNTAge.rdlc";
            }
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        void parametros()
        {
            if (Valida())
            {
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
                paramlist.Add(new ReportParameter("idAgencia", cboAgencia.SelectedValue.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            }
            else
            {
                return;
            }
        }

        Boolean Valida()
        {
            Boolean lEstado = true;
            if (dFecFin.Value < dFecIni.Value)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la fecha inicial");
                lEstado = false;
                return lEstado;
            }
            return lEstado;
        }

        private void frmRptIngresoDeposito_Load(object sender, EventArgs e)
        {
            dFecIni.Value = clsVarGlobal.dFecSystem;
            dFecFin.Value = clsVarGlobal.dFecSystem;
        }
    }
}
