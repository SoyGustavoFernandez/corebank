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
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class FrmReImpPlanPagosGrupoSol : frmBase
    {
        private clsCNPlanPago cnplanpago = new clsCNPlanPago();
        private clsCNSolicitud cnsolicitud = new clsCNSolicitud();

        public FrmReImpPlanPagosGrupoSol()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSolGrupoSolidario.Text))
            {
                MessageBox.Show("Debe ingresar el Nro de Solicitud del Grupo Solidario", "Re-Impresión de Plan de Pagos de Grupo Solidario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idSolGrupoSolidario = Convert.ToInt32(txtSolGrupoSolidario.Text);
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtInt = cnplanpago.CNrptIntegrantesGrupo(idSolGrupoSolidario);
            DataTable dtPP = cnplanpago.CNrptPlanPagosGrupal(idSolGrupoSolidario);
            DataTable dtDatosGrup = cnplanpago.CNrptDatosCreditoGrupal(idSolGrupoSolidario);

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cNomUsu, false));
            //paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            dtslist.Add(new ReportDataSource("DatosGrupo_Credito", dtDatosGrup));
            dtslist.Add(new ReportDataSource("planPagos", dtPP));
            dtslist.Add(new ReportDataSource("integrantes", dtInt));

            string reportpath = "rptCronogramaPagosGrupal.rdlc";
            frmReporteLocal frmreporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmreporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmreporte.ShowDialog();
        }
    }
}
