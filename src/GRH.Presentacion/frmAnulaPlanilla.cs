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

namespace GRH.Presentacion
{
    public partial class frmAnulaPlanilla : frmBase
    {
        clsCNPlanilla objPlanilla = new clsCNPlanilla();

        public frmAnulaPlanilla()
        {
            InitializeComponent();
        }

        private void cargarListaPlanillas()
        {
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla.SelectedValue);
            int idPeriodoDeclaracion = Convert.ToInt32(cboPeriodoDeclaracion.SelectedValue);

            DataTable dtListaPlanillas = new clsRPTCNRecurHum().CNLisPlanillasDeclarativas(idTipoPlanilla, idPeriodoDeclaracion);

            dtgListaPlanillas.DataSource = dtListaPlanillas;

            if (dtListaPlanillas.Rows.Count > 0)
            {
                btnAnular.Enabled = true;
            }
            else
            {
                btnAnular.Enabled = false;
                MessageBox.Show("No Existen Planillas para los filtros indicados", "Anulación de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmAnulaPlanilla_Load(object sender, EventArgs e)
        {
            cboRelacionLabInst.ListarTipoRelacionLaboralPlanillas();
            cboPeriodoDeclaracion.ListarTodosPeriodoDeclaracion();

            btnProcesar.Visible = true;
            btnCancelar.Visible = false;
        }

        private void cboRelacionLabInst_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTipoPlanilla.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst.SelectedValue));
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (cboRelacionLabInst.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar Categoría", "Anulación de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboTipoPlanilla.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar Tipo de Planilla", "Anulación de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cboPeriodoDeclaracion.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar Periodo de Pago", "Anulación de Planillas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            cargarListaPlanillas();

            cboRelacionLabInst.Enabled = false;
            cboTipoPlanilla.Enabled = false;
            cboPeriodoDeclaracion.Enabled = false;
            btnProcesar.Visible = false;
            btnCancelar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboRelacionLabInst.Enabled = true;
            cboTipoPlanilla.Enabled = true;
            cboPeriodoDeclaracion.Enabled = true;
            btnProcesar.Visible = true;
            btnCancelar.Visible = false;
        } 

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int nFilaSeleccionada = Convert.ToInt32(this.dtgListaPlanillas.CurrentRow.Index);
            DataTable dtAnularPlanilla = objPlanilla.CNAnularPlanilla(Convert.ToInt32(dtgListaPlanillas.Rows[nFilaSeleccionada].Cells["dtgtxtIdPlanilla"].Value), clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
            MessageBox.Show(dtAnularPlanilla.Rows[0]["cMensaje"].ToString(), "Anulación de Planillas", MessageBoxButtons.OK, ((int)dtAnularPlanilla.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            cargarListaPlanillas();
        }
    }
}
