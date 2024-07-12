using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RSG.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSG.Presentacion
{
    public partial class frmCredAmpliadosRefiOculto : frmBase
    {
        string cNomUser = clsVarGlobal.User.cNomUsu;
        DateTime dFechaSistema = clsVarGlobal.dFecSystem;
        clsCNCro cnRptRsg = new clsCNCro();

        public frmCredAmpliadosRefiOculto()
        {
            InitializeComponent();
            
            this.datePicker1.Value = dFechaSistema;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string dFecOpe = Convert.ToString(dFechaSistema);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            DateTime dFechaConsul = Convert.ToDateTime(this.datePicker1.Value);

            string dFechaConsulta = dFechaConsul.ToString("yyyy/MM/dd");


            DataTable dtData = cnRptRsg.CredAmpliadosRefiOculto(dFechaConsul);
            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsData", dtData));

                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaC", dFechaConsulta.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

                string reportPath = "rptCredAmpliadosRefiOculto.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta fecha.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
