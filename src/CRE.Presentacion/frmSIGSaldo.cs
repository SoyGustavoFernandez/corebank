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
    public partial class frmSIGSaldo : frmBase
    {
        public frmSIGSaldo()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            
            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;
            int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFin", dFecFin.ToString(), false));

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

            string reportpath;
            if ((int)cboAgencias.SelectedValue == 0)
            {
                dtslist.Add(new ReportDataSource("dtsSaldo", new clsRPTCNCredito().CNSIGSaldo(dFecIni, dFecFin)));
                reportpath = "RptGerenciaSaldo.rdlc";
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtsSaldo", new clsRPTCNCredito().CNSIGSaldo(dFecIni, dFecFin, idAgencia)));
                reportpath = "RptGerenciaSaldoAse.rdlc";
            }
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void frmSIGSaldo_Load(object sender, EventArgs e)
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
