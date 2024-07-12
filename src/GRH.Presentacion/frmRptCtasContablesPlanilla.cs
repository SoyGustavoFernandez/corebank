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
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmRptCtasContablesPlanilla : frmBase
    {
        #region Variables Globales

        int permiso = 0;  

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
            cboTipoPlanilla.ListarTipoPlanillaRelacionLab(0);
            cboPeriodo.ListarTodosPeriodoDeclaracion();

            permiso = 1;

            cboRelacionLabInst.SelectedIndex = -1;
            cboTipoPlanilla.SelectedIndex = -1;
            cboPeriodo.SelectedIndex = -1;
        }

        #endregion

        #region Metodos

        public frmRptCtasContablesPlanilla()
        {
            InitializeComponent();
        }


        private bool Validar()
        {
            if (cboPeriodo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el periodo.", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtgPlanillas1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar la planilla.", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        #endregion

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1)
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
                cboTipoPlanilla.SelectedIndex = -1;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Categoría", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoPlanilla.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Planilla", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboPeriodo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cCategoria = Convert.ToString(cboRelacionLabInst.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla.Text);
            string cPeriodo = Convert.ToString(cboPeriodo.Text);

            DataTable dtRpt = new clsRPTCNRecurHum().CNLisPlanillasDeclarativas(Convert.ToInt16(cboTipoPlanilla.SelectedValue), Convert.ToInt16(cboPeriodo.SelectedValue));

            dtgPlanillas1.DataSource = dtRpt;

            if (dtRpt.Rows.Count > 0)
            {
                btnImprimir.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
                MessageBox.Show("No Existen Planillas halladas con estos filtros", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            int idPlanilla = Convert.ToInt32(dtgPlanillas1.SelectedRows[0].Cells["dtgtxtIdPlanilla"].Value);
            DataTable dtRpt = new clsRPTCNRecurHum().CNRptCtasContablesPlanilla(idPlanilla);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "RptPlanillasCtaContable.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

    }
}
