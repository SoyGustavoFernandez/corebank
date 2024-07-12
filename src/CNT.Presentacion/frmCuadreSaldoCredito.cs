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
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CNT.Presentacion
{
    public partial class frmCuadreSaldoCredito : frmBase
    {
        public frmCuadreSaldoCredito()
        {
            InitializeComponent();
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFecha = dtpFecha.Value.Date;
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsValidaSaldo", new clsRPTCNContabilidad().CNCuadreSaldosCredito(dFecha)));

            string reportpath = "RptValidaSaldoCre.rdlc";

            new frmReporteLocal(dtslist, reportpath).ShowDialog();

        }
    }
}
