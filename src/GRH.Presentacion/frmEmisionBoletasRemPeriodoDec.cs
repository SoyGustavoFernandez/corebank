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
    public partial class frmEmisionBoletasRemPeriodoDec : frmBase
    {
        public frmEmisionBoletasRemPeriodoDec()
        {
            InitializeComponent();
        }

        private void frmEmisionBoletasRemPeriodoDec_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
            cboPeriodoDeclaracion.ListarTodosPeriodoDeclaracion();
        }

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.ValueMember == "" || cboRelacionLabInst.DisplayMember == "")
            {
                return;
            }
            else
            {
                cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string cDatosEmp = clsVarApl.dicVarGen["cNomEmpresa"] + "  " + clsVarApl.dicVarGen["cDirecOfiPrincipal"] + "  R.U.C. " + clsVarApl.dicVarGen["cRUC"];
            string cUbicEmp = clsVarApl.dicVarGen["cCiudadOfiPrincipal"];

            if (cboPeriodoDeclaracion.Items.Count > 0)
            {
                DataTable dtRpt = new clsRPTCNRecurHum().CNBoletaRemPorPeriodoDec(Convert.ToInt32(cboPeriodoDeclaracion.SelectedValue));

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
}
