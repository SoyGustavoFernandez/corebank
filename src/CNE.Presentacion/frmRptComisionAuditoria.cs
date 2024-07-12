using CNE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CNE.Presentacion
{
    public partial class frmRptComisionAuditoria : frmBase
    {
        #region Variables Globales

        private clsCNComisionesCanalesElec cnRptComisionAuditoria = new clsCNComisionesCanalesElec();
        DateTime dFechaSystem = clsVarGlobal.dFecSystem;
        private string cTituloMsjes = "Reporte de auditoría de comisiones";

        #endregion

        #region Metodos publicos

        public frmRptComisionAuditoria()
        {
            InitializeComponent();
            this.dtpFechaInicial.Value = this.dFechaSystem.Date;
            this.dtpFechaFinal.Value = this.dFechaSystem.Date;
            this.btnImprimir.Enabled = true;
            this.cboZona.cargarZona(true, false);
            this.cboZona.SelectedValue = 0;
            this.cboZona.Enabled = false;
            CargaComboCanales();
        }

        #endregion

        #region Metodos privados

        private void CargaComboCanales() 
        {
            var dtCanales = new clsCNComisionesCanalesElec().ObtenerCanalesElectronicos();

            List<object> listCanales = new List<object>();

            foreach (DataRow row in dtCanales.Rows)
            {
                var objeto = new
                {
                    idCanal = Convert.ToInt32(row["idCanal"]),
                    cNombreCanal = row["cNombreCanal"].ToString()
                };
                listCanales.Add(objeto);
            }

            this.cboCanalEle.DataSource = listCanales;
            this.cboCanalEle.ValueMember = "idCanal";
            this.cboCanalEle.DisplayMember = "cNombreCanal";
        }

        private void Reporte()
        {
            int idCanal = Convert.ToInt32(this.cboCanalEle.SelectedValue);
            DateTime dFechaInicio = Convert.ToDateTime(this.dtpFechaInicial.Value);
            DateTime dFechaFin = Convert.ToDateTime(this.dtpFechaFinal.Value);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"].ToString();

            if (Convert.ToDateTime(this.dtpFechaInicial.Value).Date > Convert.ToDateTime(this.dtpFechaFinal.Value).Date)
            {
                MessageBox.Show("La fecha Desde debe de ser menor o igual que la fecha Hasta", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataSet dsComisionesAuditoria = cnRptComisionAuditoria.ObtenerComisionesAuditoria(idCanal, dFechaInicio, dFechaFin);

            if (dsComisionesAuditoria.Tables.Count > 0 && dsComisionesAuditoria.Tables[0].Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dtConfComisionesM", dsComisionesAuditoria.Tables[0]));
                dtsList.Add(new ReportDataSource("dtConfComisionesD", dsComisionesAuditoria.Tables[1]));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("cRutaLogo", cRutaLogo, false));

                string reportPath = "rptReporteCambiosConfComisiones.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para este intervalo de fechas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Eventos

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reporte();
        }

        #endregion
    }
}

