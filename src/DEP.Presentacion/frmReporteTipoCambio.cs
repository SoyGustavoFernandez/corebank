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
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmReporteTipoCambio : frmBase
    {
        public frmReporteTipoCambio()
        {
            InitializeComponent();
            inicializaTipoBusqueda();
        }

        private void inicializaTipoBusqueda()
        {
            DataTable dtTpBus = new DataTable();
            dtTpBus.Columns.Add("value");
            dtTpBus.Columns.Add("descripcion");

            dtTpBus.Rows.Add("N", "Vigente por Fecha");
            dtTpBus.Rows.Add("H", "Historico por Fecha");

            this.cboTpBusqueda.DataSource = dtTpBus;
            this.cboTpBusqueda.ValueMember = "value";
            this.cboTpBusqueda.DisplayMember = "descripcion";
        }

        private void frmReporteTipoCambio_Load(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
            dtFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cboTpBusqueda.SelectedIndex = -1;
            dtFecInicio.Value = clsVarGlobal.dFecSystem;
            dtFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.cboTpBusqueda.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de busqueda", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string tpBusqueda = Convert.ToString(this.cboTpBusqueda.SelectedValue);

            DataTable dtTipoCambio = new clsRPTCNDeposito().CNTipoCambio(tpBusqueda, dFecInicio, dFecFin);

            if (dtTipoCambio.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el Reporte para dicho intervalo de Fechas", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                
                paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));                
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
                
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsTipoCambio", dtTipoCambio));

                string reportpath = "rptTipoCambio.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
        
        }
    }
}
