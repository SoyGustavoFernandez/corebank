using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class FrmRptAvanceMoraTramoAsesor : frmBase
    {
        #region Variables

        private const string cTituloMsjes = "Reporte avance de mora tramo asesor";

        #endregion

        #region Constructores

        public FrmRptAvanceMoraTramoAsesor()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void FrmRptAvanceMoraTramoAsesor_Load(object sender, EventArgs e)
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

            DataTable dtTiposCambios = new clsCNGenAdmOpe().RetornaTiposCambio(dFecha);
            decimal nTipoCambio = Convert.ToDecimal(dtTiposCambios.Rows[0]["nTipCamFij"]);
            DateTime dFecSis = clsVarGlobal.dFecSystem.Date;
            int nDiaMes = dFecha.Day;
            int nNumDiasMes = new DateTime(dFecha.Year, dFecha.Month, 1).AddMonths(1).AddDays(-1).Day;
            decimal nPorcAvance = nDiaMes / (decimal)nNumDiasMes;
            int nNumSemana = nDiaMes / 7 + ((nDiaMes % 7 == 0 || nDiaMes / 7 == 4) ? 0 : 1);

            DataTable dtData = new clsRPTCNCredito().CNRptAvanceMoraTramoAsesor(dFecha,idAgencia);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Apertura de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", dFecSis.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("nTipoCambio", nTipoCambio.ToString(), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("nNumSemana", nNumSemana.ToString(), false));
            paramlist.Add(new ReportParameter("nPorcAvance", nPorcAvance.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = "RptAvanceMoraTramoAsesor.rdlc";

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
