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
    public partial class frmRptCartasCTS : frmBase
    {
        public frmRptCartasCTS()
        {
            InitializeComponent();
        }

        private void frmRptCartasCTS_Load(object sender, EventArgs e)
        {
            this.cboAgencias.AgenciasYTodos();
            this.dtFechaIni.Value = clsVarGlobal.dFecSystem.Date;
            this.dtFechaFin.Value = clsVarGlobal.dFecSystem.Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.dtFechaIni.Value > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha del sistema", "Reporte de Transferencia de Cuenta CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dtFechaFin.Value > clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("La fecha final no puede ser mayor a la fecha del sistema", "Reporte de Transferencia de Cuenta CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dtFechaIni.Value > this.dtFechaFin.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "Reporte de Transferencia de Cuenta CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una oficina", "Reporte de Transferencia de Cuenta CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFechaInicio = this.dtFechaIni.Value;
            DateTime dFechaFin = this.dtFechaFin.Value;            
            int idAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue);

            DataTable dtDatosTraslCtasCTS = new clsCNSolicCTS().CNRptCartasCTS(dFechaInicio, dFechaFin, idAgencia);

            if (dtDatosTraslCtasCTS.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Cartas CTS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFechaIni", dFechaInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFin", dFechaFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsListaCartasCTS", dtDatosTraslCtasCTS));

                string reportpath = "rptCartasCTS.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }
    }
}