using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmSIGAmortizacion : frmBase
    {
        public frmSIGAmortizacion()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString(), false));
            paramlist.Add(new ReportParameter("idAgencia", cboAgencias.SelectedValue.ToString(), false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
           
            string reportpath;
            if ((int)cboAgencias.SelectedValue == 0)
            {
                dtslist.Add(new ReportDataSource("dtsDesembolso", new clsRPTCNCredito().CNRptConsolAmortiza(dtpFecIni.Value, dtpFecFin.Value)));
                reportpath = "RptGerenciaAmortizacion.rdlc";
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtsDesembolso", new clsRPTCNCredito().CNRptAmortizaAse(dtpFecIni.Value, dtpFecFin.Value, Convert.ToInt32(cboAgencias.SelectedValue))));
                reportpath = "RptGerenciaAmortizacionAse.rdlc";
            }
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmSIGAmortizacion_Load(object sender, EventArgs e)
        {
            DateTime pdFecFin = clsVarGlobal.dFecSystem;
            DateTime pdFecIni = pdFecFin.AddDays((pdFecFin.Day * -1) + 1).AddYears(-1);
            dtpFecIni.Value = pdFecIni;
            dtpFecFin.Value = pdFecFin;

        }

        Boolean Valida()
        {
            Boolean lEstado = true;
            if (dtpFecFin.Value < dtpFecIni.Value)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la fecha inicial");
                lEstado = false;
                return lEstado;
            }
            return lEstado;
        }

    }
}
