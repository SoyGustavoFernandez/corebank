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
using EntityLayer;
using RPT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmCanceladosSaldo : frmBase
    {
        public frmCanceladosSaldo()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                string reportpath = "";
                paramlist.Clear();
                dtslist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
                paramlist.Add(new ReportParameter("x_idagencia",Convert.ToString(cboAgencia.SelectedValue), false));
                paramlist.Add(new ReportParameter("Logo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                dtslist.Add(new ReportDataSource("dtsCondonados", new clsRPTCNCredito().CNCondonadosCRE(dFecIni.Value, dFecFin.Value, Convert.ToInt16(cboAgencia.SelectedValue))));
                reportpath = "RptResumenCancelaDeudaCNTAge.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                return;
            }
        }
        Boolean Valida()
        {
            Boolean lEstado = true;
            if (dFecFin.Value.Date < dFecIni.Value.Date)
            {
                MessageBox.Show("Fecha Final debe ser mayor a la fecha inicial");
                lEstado = false;
                return lEstado;
            }
            return lEstado;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (Valida())
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                string reportpath = "";
                paramlist.Clear();
                dtslist.Clear();
                paramlist.Add(new ReportParameter("dFecIni", dFecIni.Value.ToString(), false));
                paramlist.Add(new ReportParameter("dFecFin", dFecFin.Value.ToString(), false));
                paramlist.Add(new ReportParameter("x_idAgencia", Convert.ToInt32(cboAgencia.SelectedValue).ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                dtslist.Add(new ReportDataSource("dtsCondonados", new clsRPTCNCredito().CNDetalleCondonados(dFecIni.Value, dFecFin.Value, Convert.ToInt32(cboAgencia.SelectedValue))));
                reportpath = "RptDetalleCancSaldo.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
        }
    }
}
