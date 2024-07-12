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
using EntityLayer;
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RCP.Presentacion
{
    public partial class frmAlertaVisitaRecup : frmBase
    {
        clsCNEventoRecupera cneventorecpera = new clsCNEventoRecupera();

        public frmAlertaVisitaRecup()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPersonalCargo1.cargarPersonal("nCargosRecuperadores", clsVarGlobal.nIdAgencia);
        }

        private bool validar()
        {
            bool lVal = false;

            if (txtDiasVencer.Text.Trim() == "")
            {
                MessageBox.Show("Asigne el número de días antes de vencer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiasVencer.Focus();
                return lVal;
            }
            if (txtDiasVencer.nvalor < 0)
            {
                MessageBox.Show("Asigne el número de días antes de vencer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiasVencer.Focus();
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("nDias", txtDiasVencer.Text, false));
                paramlist.Add(new ReportParameter("idRecuperador", cboPersonalCargo1.SelectedValue.ToString(), false));

                var dtVisitaCli = cneventorecpera.rptAlertaVisitaCli(Convert.ToInt32(txtDiasVencer.Text), Convert.ToInt32(cboPersonalCargo1.SelectedValue));

                dtslist.Add(new ReportDataSource("dsAlertaVisita", dtVisitaCli));

                string reportpath = "rptAlertaVisitaCli.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
