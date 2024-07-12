using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmRptPolizasGarantia : frmBase
    {
        #region Variables

        clsCNPolizaGarantia poliza = new clsCNPolizaGarantia();

        #endregion

        public frmRptPolizasGarantia()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem.AddMonths(-1);
            dtpFecFin.Value = clsVarGlobal.dFecSystem.AddMonths(2);
        }

        private bool validar()
        {
            bool lVal = false;

            lVal = true;
            return lVal;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DataTable dtPolizasGarantia = poliza.RptPolizasGarantia(dtpFecIni.Value, dtpFecFin.Value);

            if (dtPolizasGarantia.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Polizas de garantía", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            dtslist.Add(new ReportDataSource("dsPolizasGarantia", dtPolizasGarantia));
            
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecIni", dtpFecIni.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecFin", dtpFecFin.Value.ToString("dd/MM/yyyy"), false));
            string reportpath = "rptPolizasGarantia.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
