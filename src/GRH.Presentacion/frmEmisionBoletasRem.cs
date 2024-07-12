using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmEmisionBoletasRem : frmBase
    {
        int permiso = 0;  

        public frmEmisionBoletasRem()
        {
            InitializeComponent();
        }

        private void frmEmisionBoletasRem_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst1.ListarTipoRelacionLaboralPlanillas();
            cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(0);
            cboPeriodo.ListarTodosPeriodoDeclaracion();

            permiso = 1;

            cboRelacionLabInst1.SelectedIndex = -1;
            cboTipoPlanilla1.SelectedIndex = -1;
            cboPeriodo.SelectedIndex = -1;
        }

        private void cboRelacionLabInst1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (permiso == 1)
            {
                cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst1.SelectedValue));
                cboTipoPlanilla1.SelectedIndex = -1;
            }
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (cboRelacionLabInst1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Categoría", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoPlanilla1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Planilla", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboPeriodo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cCategoria = Convert.ToString(cboRelacionLabInst1.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla1.Text);
            string cPeriodo = Convert.ToString(cboPeriodo.Text);

            DataTable dtRpt = new clsRPTCNRecurHum().CNLisPlanillasDeclarativas(Convert.ToInt16(cboTipoPlanilla1.SelectedValue), Convert.ToInt16(cboPeriodo.SelectedValue));
            
            dtgPlanillas1.DataSource = dtRpt;

            if (dtRpt.Rows.Count > 0)
            {
                btnImprimir1.Enabled = true;
            }
            else
            {
                btnImprimir1.Enabled = false;
                MessageBox.Show("No Existen Planillas halladas con estos filtros", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboPeriodo.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Emisión de Boletas de Remuneración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cDatosEmp = clsVarApl.dicVarGen["cNomEmpresa"] + "  "+clsVarApl.dicVarGen["cDirecOfiPrincipal"] + "  R.U.C. " + clsVarApl.dicVarGen["cRUC"];
            string cUbicEmp = clsVarApl.dicVarGen["cCiudadOfiPrincipal"];

            int filaseleccionada = Convert.ToInt32(this.dtgPlanillas1.CurrentRow.Index);
            DataTable dtRpt = new clsRPTCNRecurHum().CNBoletasRemuner(Convert.ToInt32(dtgPlanillas1.Rows[filaseleccionada].Cells["dtgtxtIdPlanilla"].Value));
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cDatosEmpresa", cDatosEmp, false));
                paramlist.Add(new ReportParameter("x_cUbiEmpresa", cUbicEmp, false));
             
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsBoletasRemuneracion", dtRpt));

                string reportpath = "rptBoletaRemuneracion.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Emisión de Boletas de Remuneración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
