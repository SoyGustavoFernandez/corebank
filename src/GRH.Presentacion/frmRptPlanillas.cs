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
    public partial class frmRptPlanillas : frmBase
    {
        int permiso = 0;

        public frmRptPlanillas()
        {
            InitializeComponent();
        }

        private void frmRptPlanillas_Load(object sender, EventArgs e)
        {            
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
            cboTipoPlanilla.ListarTipoPlanillaRelacionLab(0);
            cboPeriodoPlanilla.ListarTodosPeriodoTipoPlanilla(0);
            permiso = 1;
            cboRelacionLabInst.SelectedIndex = -1;
            cboTipoPlanilla.SelectedIndex = -1;
            cboPeriodoPlanilla.SelectedIndex = -1;
            cboModalidadPlanilla.SelectedIndex = -1;
        }

        private void cboRelacionLabInst1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (permiso == 1)
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
                cboTipoPlanilla.SelectedIndex = -1;
            }
        }

        private void cboTipoPlanilla1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (permiso == 1)
            {
                cboPeriodoPlanilla.ListarTodosPeriodoTipoPlanilla(Convert.ToInt32(cboTipoPlanilla.SelectedValue));
                cboPeriodoPlanilla.SelectedIndex = -1;
            }
        }

        private void btnProcesar1_Click(object sender, System.EventArgs e)
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
            if (cboPeriodoPlanilla.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Periodo", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboModalidadPlanilla.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar la Modalidad", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cCategoria = Convert.ToString(cboRelacionLabInst.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla.Text);
            string cPeriodo = Convert.ToString(cboPeriodoPlanilla.Text);
            string cModalidad = Convert.ToString(cboModalidadPlanilla.Text);

            DataTable dtRpt = new clsRPTCNRecurHum().CNLisPlanillas(Convert.ToInt16(cboPeriodoPlanilla.SelectedValue), Convert.ToInt16(cboModalidadPlanilla.SelectedValue));

             if (dtgPlanillas.ColumnCount > 0)
                {
                    dtgPlanillas.Columns.Remove("idPlanilla");
                    dtgPlanillas.Columns.Remove("dFechaPlanilla");
                    dtgPlanillas.Columns.Remove("cTipoPlanilla");
                    dtgPlanillas.Columns.Remove("lVigente");
                }

                dtgPlanillas.DataSource = dtRpt.DefaultView;
            
                dtgPlanillas.Columns["idPlanilla"].Width = 10;
                dtgPlanillas.Columns["idPlanilla"].HeaderText = "Cod.";
                dtgPlanillas.Columns["idPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas.Columns["dFechaPlanilla"].Width = 30;
                dtgPlanillas.Columns["dFechaPlanilla"].HeaderText = "Fecha";
                dtgPlanillas.Columns["dFechaPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas.Columns["cTipoPlanilla"].Width = 60;
                dtgPlanillas.Columns["cTipoPlanilla"].HeaderText = "Tipo de Planilla";
                dtgPlanillas.Columns["cTipoPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgPlanillas.Columns["lVigente"].Visible = false;
            
            if (dtRpt.Rows.Count > 0)
            {
                btnImprimirRes.Enabled = true;
                btnImprimirDet.Enabled = true;
            }
            else 
            {
                btnImprimirRes.Enabled = false;
                btnImprimirDet.Enabled = false;
                MessageBox.Show("No Existen Planillas halladas con estos filtros", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                return;            
            }
        }

        private void btnImprimir1_Click(object sender, System.EventArgs e)
        {
            string cCategoria = Convert.ToString(cboRelacionLabInst.Text);
            string cTipoPlanilla = Convert.ToString(cboTipoPlanilla.Text);
            string cPeriodo = Convert.ToString(cboPeriodoPlanilla.Text);
            string cModalidad = Convert.ToString(cboModalidadPlanilla.Text);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            int filaseleccionada = Convert.ToInt32(this.dtgPlanillas.CurrentRow.Index);
            DataTable dtRpt = new clsRPTCNRecurHum().CNListarPlanillas(Convert.ToInt32(dtgPlanillas.Rows[filaseleccionada].Cells["idPlanilla"].Value));
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));

                paramlist.Add(new ReportParameter("x_cCategoria", cCategoria, false));
                paramlist.Add(new ReportParameter("x_cTipoPlanilla", cTipoPlanilla, false));
                paramlist.Add(new ReportParameter("x_cPeriodo", cPeriodo, false));
                paramlist.Add(new ReportParameter("x_cModalidad", cModalidad, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsPlanillas", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "RptPlanillas.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnImprimirDet_Click(object sender, EventArgs e)
        {
            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];

            int filaseleccionada = Convert.ToInt32(this.dtgPlanillas.CurrentRow.Index);
            DataTable dtRpt = new clsCNPlanilla().CNDetalleConceptosPorPlanilla(Convert.ToInt32(dtgPlanillas.Rows[filaseleccionada].Cells["idPlanilla"].Value));
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Clear();
                dtsList.Add(new ReportDataSource("dsDetalleConceptosPorPlanilla", dtRpt));

                string reportPath = "RptDetalleConceptosPorPlanilla.rdlc";

                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Clear();
                paramList.Add(new ReportParameter("cNomEmpresa", cNomEmpresa, false));
                paramList.Add(new ReportParameter("cNomAgencia", cNomAgencia, false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
