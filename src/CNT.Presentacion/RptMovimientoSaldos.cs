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
using CNT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class RptMovimientoSaldos : frmBase
    {
        List<ReportParameter> paramlist = new List<ReportParameter>();
        public RptMovimientoSaldos()
        {
            InitializeComponent();
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

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            parametros();
            string reportpath = "";
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));            


            if ((int)cboAgencia.SelectedValue == 0)
            {
                dtslist.Add(new ReportDataSource("dtsOperaciones", new clsCNBalance().CNResumMovSaldo(dFecIni.Value, dFecFin.Value)));
                reportpath = "RptMovimientoSaldosCNT.rdlc";                
            }
            else
            {
                dtslist.Add(new ReportDataSource("dtsOperaciones", new clsCNBalance().CNResumMovSaldoAge(dFecIni.Value, dFecFin.Value,Convert.ToInt32(cboAgencia.SelectedValue))));
                dtslist.Add(new ReportDataSource("dtsAgencia", new clsRPTCNAgencia().CNDatoAgencia(Convert.ToInt32(cboAgencia.SelectedValue))));
                reportpath = "RptMovimientoSaldosCNTAge.rdlc";                
            }
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void RptMovimientoSaldos_Load(object sender, EventArgs e)
        {

        }    
    }
}
