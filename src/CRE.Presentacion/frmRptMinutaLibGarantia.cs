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
using RPT.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmRptMinutaLibGarantia : frmBase
    {
        public frmRptMinutaLibGarantia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaInicio = this.dtpFechaInicio.Value;
            DateTime dFechaFin = this.dtpFechaFin.Value;

            if (dFechaInicio > dFechaFin)
            {
                MessageBox.Show("La FECHA INICIO no debe ser MAYOR a la FECHA FIN","FECHAS INCORRECTAS",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            clsRPTCNCredito rptCredito = new clsRPTCNCredito();
            DataTable dtReporteMinutaGarantia = rptCredito.rptMinutaGarantiaAviso(dFechaInicio, dFechaFin);
            if (dtReporteMinutaGarantia.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("cNomEmp", cNomEmp, false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                paramlist.Add(new ReportParameter("dFechaInicio", dFechaInicio.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFin.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dsMinutaLibGarantiaAviso", dtReporteMinutaGarantia));

                string reportpath = "rptAvisoMinutaGarantia.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para el rango de fechas desde " + dFechaInicio.ToString("dd/MM/yyyy") +
                " hasta " + dFechaFin.ToString("dd/MM/yyyy"), "NO EXISTEN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFechaInicio.Focus();
                return;
            }
        }

        private void frmRptMinutaLibGarantia_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicio.MaxDate = clsVarGlobal.dFecSystem;
            this.dtpFechaFin.MaxDate = clsVarGlobal.dFecSystem;
        }
    }
}
