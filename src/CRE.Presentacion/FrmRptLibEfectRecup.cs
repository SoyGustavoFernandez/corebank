using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class FrmRptLibEfectRecup : frmBase
    {

        #region Variables

        private const string cTituloMsjes = "Reporte de liberación y efectividad de recuperación";

        #endregion

        #region Constructores

        public FrmRptLibEfectRecup()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void FrmRptLibEfectRecup_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencia.SelectedValue = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            DateTime dFecha = dtpFecha.Value.Date;
            int idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DateTime dFecSis = clsVarGlobal.dFecSystem.Date;

            DataTable dtData = new clsRPTCNCredito().CNRptLibEfectRecup(dFecha,idAgencia);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("dFechaSis", dFecSis.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = "RptEfectLibRecup.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        #endregion

        #region Métodos

        private bool Validar()
        {
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMsjes, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
