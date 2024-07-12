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
using GRH.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace GRH.Presentacion
{
    public partial class frmRptProvisionPlanillas : frmBase
    {
        public frmRptProvisionPlanillas()
        {
            InitializeComponent();
        }

        private void frmRptProvisionPlanillas_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
        }

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.ValueMember == "" || cboRelacionLabInst.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboTipoPlanilla.ListarTipoPlanillaProvisionRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
            
            DateTime dFechaProvision = dtpFechaProvision.Value;
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
            string cTipoPlanilla = cboTipoPlanilla.Text.ToString();

            DataTable dtRpt = new clsCNPlanilla().CNProvisionPlanillas(idTipoPlanilla, dFechaProvision);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Clear();
                dtsList.Add(new ReportDataSource("dsProvisionPlanillasAgencia", dtRpt));

                string reportPath = "rptProvisionPlanillasAgencia.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Clear();
                paramList.Add(new ReportParameter("cNomEmpresa", cNomEmpresa, false));
                paramList.Add(new ReportParameter("cNomAgencia", cNomAgencia, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramList.Add(new ReportParameter("cTipoPlanilla", cTipoPlanilla, false));

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Provisiones de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
