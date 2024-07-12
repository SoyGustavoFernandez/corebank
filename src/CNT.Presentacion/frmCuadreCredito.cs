using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmCuadreCredito : frmBase
    {
        #region Eventos
        public frmCuadreCredito()
        {
            InitializeComponent();
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            if (dFecIni > dFecFin)
            {
                MessageBox.Show("La fecha final no puede ser menor a la fecha inicio", "Reporte de Cuadre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            DataTable dtCuadreCredito = new clsRPTCNContabilidad().CuadreCreditos(dFecIni, dFecFin);


            if (dtCuadreCredito.Rows.Count == 0)
            {
                MessageBox.Show("No existen diferencias en el cuadre de creditos", "Reporte de Cuadre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsCuadreCreditos", dtCuadreCredito));

                string reportpath = "rptCuadreCredito.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void frmCuadreCredito_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }
        #endregion
    }
}
