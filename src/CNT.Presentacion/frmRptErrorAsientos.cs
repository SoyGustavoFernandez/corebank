using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmRptErrorAsientos : frmBase
    {
        public frmRptErrorAsientos()
        {
            InitializeComponent();
        }

        private void frmRptErrorAsientos_Load(object sender, EventArgs e)
        {
            dtFecha.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtFecFin.Value.Date > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha no puede ser posterior a la de Hoy", "Reporte de Error de Asientos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtFecha.Value.Date > dtFecFin.Value.Date)
            {
                MessageBox.Show("La fecha inicio no puede mayor a la fecha final", "Reporte de Error de Asientos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            DateTime dFecha = Convert.ToDateTime(dtFecha.Value.ToShortDateString());
            DateTime dFecFin = Convert.ToDateTime(dtFecFin.Value.ToShortDateString());

            DataTable dtListaErrorAsientos = new clsRPTCNContabilidad().CNErrorAsientos(dFecha, dFecFin);


            if (dtListaErrorAsientos.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte para dicho intervalo de Fechas", "Reporte de Error de Asientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                dtslist.Add(new ReportDataSource("dsErrorAsiento", dtListaErrorAsientos));

                string reportpath = "RptErrorAsientos.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}
