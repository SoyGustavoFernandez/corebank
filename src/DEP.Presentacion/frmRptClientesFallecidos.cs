using DEP.CapaNegocio;
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

namespace DEP.Presentacion
{
    public partial class frmRptClientesFallecidos : frmBase
    {
        #region Variables Globales
        clsCNDeposito clsDeposito = new clsCNDeposito();
        #endregion

        public frmRptClientesFallecidos()
        {
            InitializeComponent();
            this.dtpFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (dtpFecFin.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha del sistema", "Reporte de clientes fallecidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFecInicio.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }
            if (dtpFecInicio.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha inicial de búsqueda no puede ser mayor a la fecha final", "Reporte de clientes fallecidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                                            
            DateTime dFechaInicio = this.dtpFecInicio.Value;
            DateTime dFechaFinal = this.dtpFecFin.Value;

            DataTable dtResp = clsDeposito.CNObtenerClientesFallecidos(dFechaInicio, dFechaFinal);
            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes fallecidos", "Reporte de clientes fallecidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem;
                string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("dFechaIni", dFechaInicio.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("dFechaFin", dFechaFinal.ToShortDateString(), false));
                paramlist.Add(new ReportParameter("x_AgenEmision", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsListaClientesFallecidos", dtResp));

                string reportpath = "rptClientesFallecidos.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
        }
        #endregion


    }
}