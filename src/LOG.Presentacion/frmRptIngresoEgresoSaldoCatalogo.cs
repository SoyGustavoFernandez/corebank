using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmRptIngresoEgresoSaldoCatalogo : frmBase
    {
        #region Variables
        private clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
        #endregion

        #region Metodos
        public frmRptIngresoEgresoSaldoCatalogo()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmRptIngresoEgresoSaldoCatalogo_Load(object sender, EventArgs e)
        {
            cboAgencia.AgenciasYTodos();
            cboAgencia.SelectedValue = 0;
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen((int)cboAgencia.SelectedValue);
            }

            if (cboAlmacen.Text == "")
            {
                btnImprimir.Enabled = false;
            }
            else
            {
                btnImprimir.Enabled = true;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtIngEgrSaldo;
            DateTime dFecha = dtpFecha.Value;
            dtIngEgrSaldo = objLogistica.CNGetIngresoEgresoSaldoCatalogo(Convert.ToInt32(cboAlmacen.SelectedValue), dFecha);

            if(dtIngEgrSaldo.Rows.Count>0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dtIngEgrSaldo", dtIngEgrSaldo));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                string reportPath = "rptIngresoEgresoSaldoCatalago.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para estos filtros seleccionados", "Reporte de Entradas Salidas y Saldos de Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
