using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmPlanillasTmp : frmBase
    {
        clsCNPlanilla objPlanilla = new clsCNPlanilla();

        public string idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla, idPeriodoDeclaracion;
        
        public frmPlanillasTmp()
        {
            InitializeComponent();
            btnSalir.Focus();
        }

        private void frmPlanillasTmp_Load(object sender, EventArgs e)
        {
            DataTable dtPlanillasProceso = objPlanilla.CNListarPlanillasProceso();

            if (dtPlanillasProceso.Rows.Count == 0)
            {
                idTipoRelLab = "";
                idTipoPlanilla = "";
                idModalidad = "";
                idPeriodoPlanilla = "";
                idPeriodoDeclaracion = "";

                Dispose();
            }
            else
            {
                dtgPlanillasProceso.DataSource = dtPlanillasProceso;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgPlanillasProceso.CurrentRow != null && dtgPlanillasProceso.Rows.Count > 0)
            {
                idTipoRelLab = Convert.ToString(dtgPlanillasProceso.CurrentRow.Cells["dtgtxtIdTipoRelLab"].Value);
                idTipoPlanilla = Convert.ToString(dtgPlanillasProceso.CurrentRow.Cells["dtgtxtIdTipoPlanilla"].Value);
                idModalidad = Convert.ToString(dtgPlanillasProceso.CurrentRow.Cells["dtgtxtIdModalidad"].Value);
                idPeriodoPlanilla = Convert.ToString(dtgPlanillasProceso.CurrentRow.Cells["dtgtxtIdPeriodoPlanilla"].Value);
                idPeriodoDeclaracion = Convert.ToString(dtgPlanillasProceso.CurrentRow.Cells["dtgtxtIdPeriodoDeclaracion"].Value);
            }
            else
            {
                idTipoRelLab = "";
                idTipoPlanilla = "";
                idModalidad = "";
                idPeriodoPlanilla = "";
                idPeriodoDeclaracion = "";
            }

            Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            idTipoRelLab = "";
            idTipoPlanilla = "";
            idModalidad = "";
            idPeriodoPlanilla = "";
            idPeriodoDeclaracion = "";
        }

        private void dtgPlanillasProceso_DoubleClick(object sender, EventArgs e)
        {
            btnAceptar.PerformClick();
        }

        private void dtgPlanillasProceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }

        private void dtgPlanillasProceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnAceptar.PerformClick();
            }
        }
    }
}
