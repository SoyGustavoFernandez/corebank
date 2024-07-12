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
using Microsoft.Reporting.WinForms;
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptControlGarantias : frmBase
    {
        clsCNGarantia cngarantia = new clsCNGarantia();

        public frmRptControlGarantias()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtControlGarantia = cngarantia.RptControlInsBloGar(Convert.ToInt32(txtDiasVencidos.Text));

                if (dtControlGarantia.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para los parametros seleccionados", "Polizas de garantía", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();

                dtslist.Add(new ReportDataSource("dsControlGarantia", dtControlGarantia));

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("nDias", txtDiasVencidos.Text, false));
                string reportpath = "rptControlGarantias.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private bool validar()
        {
            bool lVal = false;

            if (string.IsNullOrEmpty(txtDiasVencidos.Text))
            {
                MessageBox.Show("Por favor asigne un valor en el número de días vencidos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiasVencidos.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }
    }
}
